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
using Taxi.Business;
using Taxi.Business.BanDoXe;
using Taxi.Entity;
using Janus.Windows.GridEX;

namespace TaxiOperation_MoiGioi
{
    public partial class frmPOI : Form
    {
        private string G_NameVN = "";
        private clsPOIEntity objRoad = new clsPOIEntity();
        #region constructor
        public frmPOI()
        {
            InitializeComponent();
            ConfigMap();

            //LoadAllRoad();
            LoadType();
        }
        #endregion
        
        #region Method

        private void LoadType()
        {
            DataTable dt = new clsRoad().T_POI_Type();
            cbType.DataSource = dt;
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "TypeId";
        }

        private void LoadAllRoad()
        {
            try
            {
                clsRoad clsRoads = new clsRoad();
                List<clsPOIEntity> lstRoad = clsRoads.T_GetAllPOI_Type(Convert.ToInt16(cbType.SelectedValue));
                //gridBaoCaoBieuMau1.DataSource = lstRoad;
                gridVietTatTenDuong.SetDataBinding(lstRoad, "ListRoad");

                //GridEXFilterCondition Filter = new GridEXFilterCondition(gridVietTatTenDuong.RootTable.Columns["NameVN"], ConditionOperator.Equal, G_NameVN);

                //if (gridVietTatTenDuong.Find(Filter, -1, 1))
                //{
                //    GridEXRow row = ((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow();

                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //    RowStyle.BackColor = System.Drawing.Color.DodgerBlue;
                //    row.RowStyle = RowStyle;
                //    //gridVietTatTenDuong.RootTable.ApplyFilter(ab);
                //}

                if (lstRoad != null && lstRoad.Count > 0)
                {
                    MainMap.Overlays[0].Markers.Clear();
                    foreach (clsPOIEntity item in lstRoad)
                    {
                        MainMap.AddMarkerRedCircle(item.ViDo, item.KinhDo, item.NameVN);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void deleteRecord()
        {
            if (gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.CurrentRow.RowIndex >= 0)
            {                
                int Id = objRoad.ID;
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dialog == DialogResult.Yes)
                {
                    if (new clsRoad().T_Delete_TenVietTat(Id))
                    {
                        LoadAllRoad();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridVietTatTenDuong_FilterApplied(object sender, EventArgs e)
        {
            //GridEXFilterCondition a = gridVietTatTenDuong.RootTable.FilterApplied;
        }

        public string GetGeobyAddressBA3(string address)
        {
            string result;
            try
            {
                using (BAGis.gisSoapClient BAgis = new BAGis.gisSoapClient())
                {
                    BAGis.GSAuthenticationHeader auth = new BAGis.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    //BAgis.GSAuthenticationHeaderValue = auth;
                    BAGis.GSAddressResult rs = BAgis.GetGeoByName3(auth, address, "vn");
                    result = String.Format("{0} {1}", rs.Lat, rs.Lng);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        private void SetDataToForm()
        {
            if (gridVietTatTenDuong.SelectedItems != null && gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.SelectedItems[0].RowType == Janus.Windows.GridEX.RowType.Record)
            {
                objRoad = (clsPOIEntity)((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow().DataRow;
                txtNameVN.Text = objRoad.NameVN;
                txtVietTat.Text = objRoad.VietTat;
                MainMap.AddMarkerBlueCircle(objRoad.ViDo, objRoad.KinhDo);
            }
        }
        #endregion

        #region Map Control
        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(21.0298404693604, 105.830619812012);
        private GMapProvider _mapType;
        private MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        //GMapMarkerCustom centerMarker;
        GMapMarker currentMarker;
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
            MainMap.MaxZoom = 19;
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
            //if (e.Button == MouseButtons.Right)
            //{
            //    if (currentMarker != null)
            //    {
            //        isMouseDown = true;
            //        if (currentMarker.IsVisible)
            //            currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            //    }
            //    else
            //    {
            //        MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y), "");
            //        currentMarker = MainMap.MarkerCustomer;
            //        //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            //    }
            //    initConfigGPS();
            //}
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
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
                case Keys.Delete:
                    deleteRecord();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridVietTatTenDuong_Click(object sender, EventArgs e)
        {
            SetDataToForm();
        }

        private void gridVietTatTenDuong_SelectionChanged(object sender, EventArgs e)
        {
            SetDataToForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (txtNameVN.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên đường");
                return;
            }
            else if (txtVietTat.Text == string.Empty)
            {
                MessageBox.Show("Bạn hãy nhập tên viết tắt");
                return;
            }
            else
            {
                
                string NameVN = txtNameVN.Text.Trim();
                if (new clsRoad().T_Update_TenVietTat(objRoad.ID, txtVietTat.Text.Trim(), NameVN, objRoad.KinhDo, objRoad.ViDo))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllRoad();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteRecord();
        }
        #endregion

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadAllRoad();
        }

        private void cbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadAllRoad();
        }

        
    }
}
