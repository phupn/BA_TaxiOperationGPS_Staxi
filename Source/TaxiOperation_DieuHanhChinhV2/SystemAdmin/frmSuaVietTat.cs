using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Export.Xl;
using Taxi.Entity;
using Taxi.Business.BanDoXe;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Services.BAGPS;

namespace Taxi.GUI
{
    public partial class frmSuaVietTat : Form
    {
        #region properties
        private float G_KinhDo = 0;
        private float G_ViDo = 0;
        private bool G_isAddNew = true;
        public string G_NameVN;
        private RoadEntity objRoad = new RoadEntity();

        public RoadEntity GetRoadEntity
        {
            set { objRoad = value; }
            get { return objRoad; }
        }
        
        #endregion
        public frmSuaVietTat()
        {
            InitializeComponent();
            G_isAddNew = true;
        }

        public frmSuaVietTat(RoadEntity objRoadEntity)
        {
            InitializeComponent();
            objRoad = objRoadEntity;
            G_isAddNew = false;
        }

        private void frmSuaVietTat_Load(object sender, EventArgs e)
        {
            ConfigMap();
            if (!G_isAddNew)
            {
                txtVietTat.Text = objRoad.VietTat;
                txtNameVN.Text = objRoad.NameVN;
                if (objRoad.KinhDo != 0 && objRoad.ViDo != 0)
                {
                    chkCoToaDo.Checked = true;
                    MainMap.addMarkerCustomer(new PointLatLng(objRoad.ViDo, objRoad.KinhDo), objRoad.NameVN);
                    currentMarker = MainMap.MarkerCustomer;
                }
            }
        }

        private void Refresh()
        {
            G_isAddNew = true;
            G_KinhDo = 0;
            G_ViDo = 0;
            chkCoToaDo.Checked = false;
            if (MainMap.OverlayCustom != null &&MainMap.OverlayCustom.Markers != null)
            {
                MainMap.OverlayCustom.Markers.Clear();
            }
            txtVietTat.Text = "";
            txtNameVN.Text = "";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameVN.Text == string.Empty)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn hãy nhập tên đường");
                }
                else if (txtVietTat.Text == string.Empty)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn hãy nhập tên viết tắt");
                }
                else
                {
                    string NameVN = txtNameVN.Text.Trim();
                    string NameEN = UnicodeStrings.LatinToAscii(NameVN);
                    if (currentMarker != null && currentMarker.IsVisible && chkCoToaDo.Checked)
                    {
                        G_KinhDo = (float)currentMarker.Position.Lng;
                        G_ViDo = (float)currentMarker.Position.Lat;
                    }

                    if (G_isAddNew)
                    {
                        if (new clsRoad().Insert_TenVietTat(NameEN, NameVN, txtVietTat.Text.Trim(), G_KinhDo, G_ViDo))
                        {
                            new MessageBox.MessageBoxBA().Show("Thêm mới thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                            G_NameVN = NameVN;
                            Refresh();
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show("Thêm mới thất bại", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else
                    {
                        if (new clsRoad().Update_TenVietTat(objRoad.ID, txtVietTat.Text.Trim(), NameVN, NameEN, G_KinhDo, G_ViDo))
                        {
                            G_NameVN = txtNameVN.Text.Trim();
                            new MessageBox.MessageBoxBA().Show("Cập nhật thành công", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                            Refresh();
                        }
                        else
                        {
                            new MessageBox.MessageBoxBA().Show("Cập nhật thất bại", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnThemMoi_Click: ",ex);
            }           
        }

        #region Xử lý hot key

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion

        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private MapModeEnum _mapMode;
        private int _mapZoom;
        private GMapMarkerCustom centerMarker;
        private GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        private GMapOverlay top;
        private bool isMouseDown;

        private void ConfigMap()
        {
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;

            MainMap.Position = currentPoint;
            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            if (_mapMode == Taxi.Utils.MapModeEnum.EditPoint)
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

            // get zoom  
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            top = new GMapOverlay("top");
            MainMap.Overlays.Add(top);
            CustomInitMap();
        }

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            //initConfigGPS();

        }

        private void initConfigGPS()
        {
            //if (currentMarker != null && currentMarker.Position.Lat > 0)
            //{
            //    lblGPS_KinhDo.Text = currentMarker.Position.Lng.ToString();
            //    lblGPS_ViDo.Text = currentMarker.Position.Lat.ToString();
            //}
            //lblGPS_mucZoom.Text = MainMap.Zoom.ToString();
            //lblGPS_LoaiBanDo.Text = MainMap.MapProvider.Name;
        }

        #region===================Map Events==================================

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            initConfigGPS();
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
            initConfigGPS();
        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                int zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                trackBarMap.Value = zoom;
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
                if (currentMarker != null)
                {
                    isMouseDown = true;
                    if (currentMarker.IsVisible)
                        currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                else
                {
                    MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y),txtNameVN.Text.Trim());
                    currentMarker = MainMap.MarkerCustomer;
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }
                initConfigGPS();
            }
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

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        #endregion=============================================================        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string diaChi = StringTools.TrimSpace(txtNameVN.Text);
                if (!string.IsNullOrEmpty(diaChi))
                {
                    double viDo = 0;
                    double kinhDo = 0;
                    string[] arrDiaChi = diaChi.Split(',');
                    bool isKinhDo = false;
                    bool isViDo = false;
                    if (arrDiaChi.Length == 2)
                    {
                        isKinhDo = double.TryParse(arrDiaChi[0], out kinhDo);
                        isViDo = double.TryParse(arrDiaChi[1], out viDo);
                    }

                    if (!isKinhDo || !isViDo)
                    {
                        string toaDo = Services.Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh);
                        if (toaDo != "*" && !string.IsNullOrEmpty(toaDo))
                        {
                            LogError.WriteLogError(toaDo,new Exception());
                            string[] arrString = toaDo.Split(' ');
                            viDo = Convert.ToDouble(arrString[0]);
                            kinhDo = Convert.ToDouble(arrString[1]);
                        }
                    }
                    if (kinhDo > 0 && viDo > 0)
                    {
                        MainMap.addMarkerCustomer(new PointLatLng(viDo, kinhDo), diaChi);
                        currentMarker = MainMap.MarkerCustomer;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSearch_Click: ", ex);
            }
        }
    }       
}