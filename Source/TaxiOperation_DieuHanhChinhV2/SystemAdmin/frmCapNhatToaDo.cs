using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Data;
using Taxi.Business.BanDoXe;
using Taxi.Entity;
using Janus.Windows.GridEX;
using Taxi.Business;
using Taxi.GUI;
using Taxi.Utils;
using Taxi.Services.BAGPS;
using Taxi.Data.G5.DanhMuc;
using Taxi.Controls.POI;
using Taxi.MessageBox;

namespace TaxiOperation_MoiGioi
{
    public partial class frmCapNhatToaDo : Form
    {
        private int G_ID;
        private List<POICommon> G_ListPOI;
        private POICommon G_POI;
        private int GridSelectionRow;
        #region constructor
        public frmCapNhatToaDo()
        {
            InitializeComponent();
            ConfigMap();
        }
        #endregion
        
        #region Method

        private void frmCapNhatToaDo_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                G_ListPOI = POICommon.Inst.GetPoints(cbType.SelectedIndex, chkAll.Checked);
                
                if (G_ListPOI != null)
                {
                    gridControl.DataSource = G_ListPOI;
                    //gridVietTatTenDuong.SetDataBinding(G_ListPOI, "ListRoad");
                    
                    MainMap.Overlays[0].Markers.Clear();
                    foreach (POICommon item in G_ListPOI)
                    {
                        MainMap.AddMarkerRedCircle_WithTag(Convert.ToDouble(item.Lat), Convert.ToDouble(item.Lng), item.NameVN,item.ID);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridVietTatTenDuong_FilterApplied(object sender, EventArgs e)
        {
            //GridEXFilterCondition a = gridVietTatTenDuong.RootTable.FilterApplied;
        }

        private void SetDataToForm()
        {
            try
            {
                if (gridView.FocusedRowHandle > 0)
                {                    
                    G_POI = (POICommon)gridView.GetFocusedRow();

                    //string kinhDo = objPOICommon.Lng;
                    //string viDo = objPOICommon.Lat;
                    txtKinhDo.Text = G_POI.Lng.ToString();
                    txtViDo.Text = G_POI.Lat.ToString();
                    txtDiaChi.Text = G_POI.DiaChi;
                    lblInfo.Text = G_POI.NameVN;
                    txtVietTat.Text = G_POI.VietTat;
                    txtNameVN.Text = G_POI.NameVN;
                    G_ID = G_POI.ID;
                    if (G_POI.Lat > 0 && G_POI.Lng > 0)
                    {
                        MainMap.AddMarkerBlueCircle(Convert.ToDouble(G_POI.Lng), Convert.ToDouble(G_POI.Lat), lblInfo.Text, true);
                        //currentMarker = MainMap.marker;
                        //currentMarker == MainMap.ma
                    }
                    else
                    {
                        if (MainMap.Overlays[1] != null && MainMap.Overlays[1].Markers != null && MainMap.Overlays[1].Markers.Count > 0)
                        {
                            MainMap.Overlays[1].Markers.Clear();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CapNhatToaDo SetDataToForm", ex);
            }
        }
        #endregion

        #region Map Control
        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        //GMapMarkerCustom centerMarker;
        //GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;
        GMapOverlay selected;

        bool isMouseDown;

        private void ConfigMap()
        {
            // config gmaps
            
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.MaxZoom = 25;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;

            MainMap.Position = currentPoint;
            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            if (_mapMode == MapModeEnum.EditPoint)
            {
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
            }
            else
            {
                MainMap.MouseMove -= MainMap_MouseMove;
                MainMap.MouseDown -= MainMap_MouseDown;
                MainMap.MouseUp -= MainMap_MouseUp;
            }
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;

            //// get zoom  
            //trackBarMap.Minimum = MainMap.MinZoom;
            //trackBarMap.Maximum = MainMap.MaxZoom;
            //trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);

                selected = new GMapOverlay("selected");
                MainMap.Overlays.Add(selected);
            }
        }

        #region===================Map Events==================================

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                string address = Taxi.Services.Service_Common.GetAddressByGeoBAV2((float)point.Lat, (float)point.Lng, false);
                if (MainMap.Overlays[1] != null && MainMap.Overlays[1].Markers != null && MainMap.Overlays[1].Markers.Count > 0)
                {
                    isMouseDown = true;
                    if (MainMap.Overlays[1].Markers[0].IsVisible)
                    {
                        MainMap.Overlays[1].Markers[0].Position = point;
                        MainMap.Overlays[1].Markers[0].ToolTipText = address;
                    }
                }
                else
                {
                    MainMap.AddMarkerBlueCircle(point.Lng, point.Lat, address, false);
                    //currentMarker = MainMap.MarkerCustomer;
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                txtKinhDo.Text = point.Lng.ToString();
                txtViDo.Text = point.Lat.ToString();

                //DialogResult result = new frmPOI("", "", address, point.Lat, point.Lng).ShowDialog();
                //if (result == System.Windows.Forms.DialogResult.OK)
                //{
                //    if (MainMap.Overlays[0] != null && MainMap.Overlays[0].Markers != null && MainMap.Overlays[0].Markers.Count > 0)
                //    {
                //        MainMap.Overlays[0].Markers.Clear();
                //    }
                //    MainMap.AddMarkerRedCircle(point.Lat, point.Lng, address);
                //}
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (MainMap.Overlays[1] != null && MainMap.Overlays[1].Markers != null && MainMap.Overlays[1].Markers.Count > 0 && MainMap.Overlays[1].Markers[0].IsVisible)
                {
                    PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                    //MainMap.Overlays[1].Markers[0].Position = point;
                    //txtKinhDo.Text = point.Lng.ToString();
                    //txtViDo.Text = point.Lat.ToString();
                }

            }
            MainMap.Refresh(); // force instant invalidation
        }
        #endregion=============================================================        
        #endregion

        #region Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F:
                    txtDiaChi.Focus();
                    return true;
                case Keys.F1:
                    gridView.Focus();
                    return true;
                case Keys.F2:
                    btnSave_Click(null, null);
                    return true;
                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridVietTatTenDuong_SelectionChanged(object sender, EventArgs e)
        {
            SetDataToForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKinhDo.Text == string.Empty || txtViDo.Text == string.Empty)
                {
                    
                }
                else
                {
                    double lat = Convert.ToDouble(txtViDo.Text);
                    double lng = Convert.ToDouble(txtKinhDo.Text);
                    string viettat = txtVietTat.Text.Trim();
                    string nameVN = txtNameVN.Text.Trim();
                    string diachi = txtDiaChi.Text.Trim();
                    if (new CapNhatToaDo().UPDATE(cbType.SelectedIndex, G_ID.ToString(), lng, lat, nameVN, diachi, viettat))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        POICommon objPOI = new POICommon() ;
                        foreach (var item in G_ListPOI)
                        {
                            if (item.ID == G_ID)
                            {
                                objPOI = item;
                                break;
                            }
                        }
                        objPOI.Lat = lat;
                        objPOI.Lng = lng;
                        gridControl.Refresh();
                        gridControl.RefreshDataSource();
                        //MainMap.AddMarkerRedCircle(lat, lng, lblInfo.Text);
                        //LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
            if (cbType.SelectedIndex == 2)
            {
                btnAddPOI.Visible = true;
            }
            else
            {
                btnAddPOI.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strDiaChi = txtDiaChi.Text.Trim();
                if (!string.IsNullOrEmpty(strDiaChi))
                {
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddressV2(strDiaChi);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');

                        if (MainMap.Overlays[1] != null && MainMap.Overlays[1].Markers != null && MainMap.Overlays[1].Markers.Count > 0)
                        {
                            MainMap.Overlays[1].Markers.Clear();
                        }
                        MainMap.AddMarkerBlueCircle(Convert.ToDouble(arrString[1]), Convert.ToDouble(arrString[0]), strDiaChi, true);
                        //currentMarker = MainMap.MarkerCustomer;
                        txtKinhDo.Text = arrString[1];
                        txtViDo.Text = arrString[0];
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tọa độ");
                    }
                }


                Cursor.Position = new Point(this.Location.X + 350, this.Location.Y + 43);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnSearch_Click(null, null);
        }

        private void btnAddPOI_Click(object sender, EventArgs e)
        {
            frmPOI frmPoi = new frmPOI();
            frmPoi.ShowDialog();
            LoadData();
        }

        private void btnXoaPOI_Click(object sender, EventArgs e)
        {
            try
            {
                var result = new MessageBoxBA().Show("Bạn có chăc muốn xóa POI không?","Thông báo",MessageBoxButtonsBA.YesNo,MessageBoxIconBA.Question);
                if (result == "Yes")
                {
                    int success=new POICommon().DeletePOI(G_ID.ToString());
                    if (success != -10)
                    {
                        new MessageBoxBA().Show("Xóa POI thành công!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
              LogError.WriteLogError("btnXoaPOI_Click: ", ex);
            }
        }

        private void btnSuaPOI_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnXoaPOI_Click: ", ex);
            }
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SetDataToForm();
        }

        private void gridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if (cbType.SelectedIndex < 2)
                {
                    return;
                }
                POICommon row = (POICommon)e.Row;
                if (row != null)
                {
                    double kinhdo = double.Parse(txtKinhDo.Text.Trim());
                    double vido = double.Parse(txtViDo.Text.Trim());
                    DialogResult conFirm;
                    if (kinhdo != row.KinhDo || vido != row.ViDo)
                    {
                        conFirm = MessageBox.Show("Bạn có muốn thay đổi vị trí?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else conFirm = System.Windows.Forms.DialogResult.Yes;

                    if (conFirm == System.Windows.Forms.DialogResult.Yes)
                    {
                        {
                            G_POI.ID = row.ID;
                            G_POI.NameVN = row.NameVN;
                            G_POI.VietTat = row.VietTat;
                            G_POI.DiaChi = row.DiaChi;

                            G_POI.KinhDo = kinhdo;
                            G_POI.ViDo = vido;
                            G_POI.LastUpdate = CommonBL.GetTimeServer();
                            G_POI.Update();
                            gridView.RefreshData();
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CapNhatToaDo gridView_RowUpdated", ex);
            }
        }
    }
}
