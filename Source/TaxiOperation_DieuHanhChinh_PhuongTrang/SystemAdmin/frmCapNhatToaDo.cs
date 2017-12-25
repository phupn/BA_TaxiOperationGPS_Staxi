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
using Taxi.Utils;
using Taxi.Services.BAGPS;

namespace TaxiOperation_MoiGioi
{
    public partial class frmCapNhatToaDo : Form
    {
        private string G_ID = string.Empty;
        #region constructor
        public frmCapNhatToaDo()
        {
            InitializeComponent();
            ConfigMap();
        }
        #endregion
        
        #region Method
        private void LoadData()
        {
            try
            {
                DataTable dt = new CapNhatToaDo().GET_ALL(cbType.SelectedIndex, chkAll.Checked);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridVietTatTenDuong.SetDataBinding(dt, "ListRoad");
                    
                    MainMap.Overlays[0].Markers.Clear();
                    foreach (DataRow item in dt.Rows)
                    {
                        MainMap.AddMarkerRedCircle(Convert.ToDouble( item["ViDo"]), Convert.ToDouble(item["KinhDo"]), item["DiaChi"].ToString());
                    }
                }

                //GridEXFilterCondition Filter = new GridEXFilterCondition(gridVietTatTenDuong.RootTable.Columns["DiaChi"], ConditionOperator.Equal, G_NameVN);

                //if (gridVietTatTenDuong.Find(Filter, -1, 1))
                //{
                //    GridEXRow row = ((GridEXSelectedItem)gridVietTatTenDuong.SelectedItems[0]).GetRow();

                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //    RowStyle.BackColor = System.Drawing.Color.DodgerBlue;
                //    row.RowStyle = RowStyle;
                //    //gridVietTatTenDuong.RootTable.ApplyFilter(ab);
                //}
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
            if (gridVietTatTenDuong.SelectedItems != null && gridVietTatTenDuong.SelectedItems.Count > 0 && gridVietTatTenDuong.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = gridVietTatTenDuong.SelectedItems[0].GetRow();
                string kinhDo = row.Cells["KinhDo"].Text;
                string viDo = row.Cells["ViDo"].Text;
                txtKinhDo.Text = kinhDo;
                txtViDo.Text = viDo;
                txtDiaChi.Text = row.Cells["DiaChi"].Text;
                G_ID = row.Cells["ID"].Text;
                if (viDo != "" && viDo != "0" && kinhDo != "" && kinhDo != "0")
                {
                    MainMap.addMarkerCustomer3(Convert.ToDouble(kinhDo), Convert.ToDouble(viDo), txtDiaChi.Text);
                        currentMarker = MainMap.MarkerCustomer;
                    //currentMarker == MainMap.ma
                }
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
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                if (currentMarker != null)
                {
                    isMouseDown = true;
                    if (currentMarker.IsVisible)
                        currentMarker.Position = point;                    
                }
                else
                {
                    MainMap.addMarkerCustomer3(point.Lng, point.Lat, txtDiaChi.Text);
                    currentMarker = MainMap.MarkerCustomer;
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                txtKinhDo.Text = point.Lng.ToString();
                txtViDo.Text = point.Lat.ToString();
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (currentMarker.IsVisible)
                {
                    PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                    currentMarker.Position = point;
                    txtKinhDo.Text = point.Lng.ToString();
                    txtViDo.Text = point.Lat.ToString();
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
                case Keys.Escape:
                    this.Close();
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
            try
            {
                if (txtKinhDo.Text == string.Empty || txtViDo.Text == string.Empty)
                {
                    return;
                }
                else
                {
                    if (new CapNhatToaDo().UPDATE(cbType.SelectedIndex, G_ID, Convert.ToDouble(txtKinhDo.Text), Convert.ToDouble(txtViDo.Text),"","",""))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
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
        }

        private void frmCapNhatToaDo_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strDiaChi = txtDiaChi.Text.Trim();
                if (string.IsNullOrEmpty(strDiaChi))
                {
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddress(strDiaChi, ThongTinCauHinh.GPS_TenTinh);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        MainMap.addMarkerCustomer3(Convert.ToDouble(arrString[1]), Convert.ToDouble(arrString[0]), strDiaChi);
                        currentMarker = MainMap.MarkerCustomer;
                        txtKinhDo.Text = arrString[1];
                        txtViDo.Text = arrString[0];
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tọa độ");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        
    }
}
