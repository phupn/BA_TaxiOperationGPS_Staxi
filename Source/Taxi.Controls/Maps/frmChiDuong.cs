using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Services;
using Taxi.Utils;
using Taxi.Common.Extender;
using Taxi.Business;
using Taxi.Controls.GMapResources;
using Taxi.Common.Attributes;
using Femiani.Forms.UI.Input;
using GMap.NET.WindowsForms.Markers;
using Staxi.Utils.MapUtility;

namespace Taxi.Controls.Maps
{
    public partial class frmChiDuong : FormBase
    {
        #region Properties

        private int _splitterDistance = 0;
        private int _splitContainerIndex;
        private GMapMarker _markerStart;
        private GMapMarker _markerEnd;
        private GMapMarker _markerStop1;
        private GMapMarker _markerStop2;
        private bool _flgmarkerA = false;
        private bool _flgmarkerB = false;
        private bool _flgmarker1 = false;
        private bool _flgmarker2 = false;

        private double G_StartLat = 0;
        private double G_StartLng = 0;
        public string G_StartAddress = "";
        private double G_EndLat = 0;
        private double G_EndLng = 0;
        public string G_EndAddress = "";
        public int G_TongTienChieuDi = 0;
        public int G_TongTienChieuVe = 0;
        public int G_CarType = 0;
        #endregion
        public frmChiDuong()
        {
            InitializeComponent();
        }
        public frmChiDuong(string startAddress, double start_Lat, double start_Lng, string endAddress, double end_Lat, double end_Lng)
        {
            InitializeComponent();
            Ctrl_TinhTienTheoKM_V2.TinhTienTheoKM_V2_Custom();
            G_StartLat = start_Lat;
            G_StartLng = start_Lng;
            if (startAddress != "")
            {
                G_StartAddress = startAddress + ",";
            }
            G_EndLng = end_Lng;
            G_EndLat = end_Lat;
            if (endAddress != "")
            {
                G_EndAddress = endAddress + ",";
            }
            txtStart.Items = RealTimeEnvironment.listDataAutoComplete_HN;
            txtEnd.Items = RealTimeEnvironment.listDataAutoComplete_HN;
            txtStop1.Items = RealTimeEnvironment.listDataAutoComplete_HN;
            txtStop2.Items = RealTimeEnvironment.listDataAutoComplete_HN;
        }

        /// <summary>
        /// Show form bao gồm thông tin từ form tiếp nhận gửi sang
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="start_Lat"></param>
        /// <param name="start_lng"></param>
        /// <param name="endAddress"></param>
        /// <param name="end_Lat"></param>
        /// <param name="end_lng"></param>
        public void ShowForm(string startAddress, double start_Lat, double start_Lng, string endAddress, double end_Lat, double end_Lng)
        {
            RefreshForm();
            if (start_Lat > 0 && start_Lng > 0)
            {
                MainMap.Position = new PointLatLng(start_Lat, start_Lng);
                btnStart_Click(null, null);
            }
            else if (startAddress != "")
            {
                txtStart.Text = startAddress;
                btnStart_Click(null, null);                
            }
            if (end_Lat > 0 && end_Lng > 0)
            {
                MainMap.Position = new PointLatLng(end_Lat, end_Lng);
                btnEnd.PerformClick();
            }
            else if (endAddress != "")
            {
                txtEnd.Text = endAddress;
                btnEnd_Click(null, null);
            }
            Route();
            txtStart.Text = startAddress;
            txtEnd.Text = endAddress;
        }

        private void frmChiDuong_Load(object sender, EventArgs e)
        {
            if (Config_Common.DTV_FixPrice && Config_Common.DTV_ROUTE_SERVICE > 0)
            {
                chkAvoidHighway.Visible = false;
            }
            Ctrl_TinhTienTheoKM_V2.NoneItemAll = true;
            Ctrl_TinhTienTheoKM_V2.SelectItemLoaiXeFirst = true;
            //ipLoaiXe.NoneItemAll = true;
            ResetTextAddress();
            ConfigMap();

            avoidHighways = chkAvoidHighway.Checked;
            ShowForm(G_StartAddress, G_StartLat, G_StartLng, G_EndAddress, G_EndLat, G_EndLng);
        }
        private void ResetTextAddress()
        {
            txtStart.Text = "";
            txtStop1.Text = "";
            txtStop2.Text = "";
            txtEnd.Text = "";
        }

        [MethodWithKey(Keys = Keys.F3)]
        private void AnHienThongTin()
        {
            splitContainer.SetPanelCollapsed(!splitContainer.IsPanelCollapsed);
        }

        [MethodWithKey(Keys = Keys.F5)]
        private void RefreshForm()
        {
            ResetTextAddress();
            txt_SearchAddress.Text = "";
            lbl_KM1.Text = "0";
            lbl_KM2.Text = "0";
            lbl_KM3.Text = "0";
            lblKM_Sum.Text = "0";
            //lblMoney.Text = "0";
            lblMsg.Text = "";
            //lbl_Time.Text = "0";
            
            this._markerStart = null;
            this._markerEnd = null;
            this._markerStop1 = null;
            this._markerStop2 = null;
            _flgmarkerA = false;
            _flgmarker1 = false;
            _flgmarker2 = false;
            _flgmarkerB = false;

            MainMap.ClearAllMarkers();
            MainMap.ClearRoute();
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            txtStart.Focus();

            Calculator();
        }

        [MethodWithKey(Keys = Keys.F2)]
        private void Search()
        {
            lblMsg.Text = "";

            #region Validate

            if (_markerStart == null)
            {
                lblMsg.Text = "Chưa có điểm xuất phát";
                txtStart.Focus();
                return;
            }
            //if (_markerStop1 == null)
            //{
            //    lblMsg.Text = "Chưa có điểm đến 1";
            //    txtStop1.Focus();
            //    return;
            //}
            if (_markerEnd == null)
            {
                lblMsg.Text = "Chưa có điểm dừng cuối";
                txtEnd.Focus();
                return;
            }

            #endregion

            Route();
        }

        #region Map

        private GMapMarker _currentMarker;
        private bool _isMouseDown = false;
        private void ConfigMap()
        {
            if (IsDesign) return;
            //config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            if (G_StartLat > 0 && G_StartLng > 0)
            {
                MainMap.Position = new PointLatLng(G_StartLat, G_StartLng);
            }
            else
            {
                MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            }
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = ThongTinCauHinh.GPS_MucZoom;
            var top = new GMapOverlay("top");
            MainMap.Overlays.Add(top);
            var route = new GMapOverlay(lbl_KM1.ForeColor.Name);
            MainMap.Overlays.Add(route);
            var route2 = new GMapOverlay(lbl_KM2.ForeColor.Name);
            MainMap.Overlays.Add(route2);
            var route3 = new GMapOverlay(lbl_KM3.ForeColor.Name);
            MainMap.Overlays.Add(route3);

            //MainMap.Position = currentPoint;
            MainMap.PolygonsEnabled = false;
            MainMap.AllowDrawPolygon = false;

            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            MainMap.MouseMove += MainMap_MouseMove;
            MainMap.MouseDown += MainMap_MouseDown;
            MainMap.MouseUp += MainMap_MouseUp;
            MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
            MainMap.OnMarkerEnter += MainMap_OnMarkerEnter;
            MainMap.OnMarkerLeave += MainMap_OnMarkerLeave;
            // get zoom  
            ztbMap.Properties.Minimum = MainMap.MinZoom;
            ztbMap.Properties.Maximum = MainMap.MaxZoom;
            ztbMap.Value = Convert.ToInt32(MainMap.Zoom);
            ztbMap.EditValueChanged += ztbMap_EditValueChanged;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
        }

        #region Event
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.D1))
            {
                txtStart.Focus();
                //txtStart.SelectAll();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D2))
            {
                txtStop1.Focus();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D3))
            {
                txtStop2.Focus();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                txtEnd.Focus();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.D4))
            {
                txtEnd.Focus();
                return true;
            }

            else if (keyData == (Keys.F6))
            {
                Ctrl_TinhTienTheoKM_V2.FocusLoaiXe();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ztbMap_EditValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = ztbMap.Value;
        }

        private void MainMap_OnMapZoomChanged()
        {
            ztbMap.Value = (int)MainMap.Zoom;
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isMouseDown)
            {
                var d = MainMap.FromLocalToLatLng(e.X, e.Y);
                if (_currentMarker == null)
                {
                    MainMap.AddMarkerCustomOne(d.Lat, d.Lng, "");
                }
                else
                {
                    _currentMarker.Position = d;
                }
            }
            MainMap.Refresh(); // force instant invalidation
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                var d = MainMap.FromLocalToLatLng(e.X, e.Y);
                if (_currentMarker == null)
                {
                    _isMouseDown = false;
                }
                else
                {
                    _currentMarker.Position = d;
                }
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && _isMouseDown)
            //{
            //    _isMouseDown = false;
            //    var address = Service_Common.GetAddressByGeoBA((float)_currentMarker.Position.Lat, (float)_currentMarker.Position.Lng);
            //    if (!address.Equals("*")  && !address.Trim().Equals("") && _currentMarker is GMapMarkerCustomType)
            //    {

            //        switch (_currentMarker.As<GMapMarkerCustomType>().Type)
            //        {
            //            case MarkerCustomType.A:
            //                _currentMarker.ToolTipText = _currentMarker.ToolTipText.Split(':')[0] + ":" + address;
            //                this._markerStart = _currentMarker;
            //                if (txtStart.Text.Trim() == "" || _flgmarkerA) txtStart.Text = address;
            //                break;
            //            case MarkerCustomType.B:
            //                _currentMarker.ToolTipText = _currentMarker.ToolTipText.Split(':')[0] + ":" + address;
            //                this._markerEnd = _currentMarker;
            //                if (txtEnd.Text.Trim() == "" || _flgmarkerB) txtEnd.Text = address;
            //                break;
            //            case MarkerCustomType.None:
            //                var index = _currentMarker.ToolTipText.Remove(0, 4).Trim().Split(':')[0].To<int>();
            //                _currentMarker.ToolTipText = string.Format("Điểm {0}:{1}", index, address);
            //                switch (index)
            //                {
            //                    case 1:
            //                        if (txtStop1.Text.Trim() == "" || _flgmarker1) txtStop1.Text = address;
            //                        break;
            //                    case 2:
            //                        if (txtStop2.Text.Trim() == "" || _flgmarker2) txtStop2.Text = address;
            //                        break;
            //                }

            //                break;
            //        }
            //        Route();

            //    }
            //    _currentMarker = null;
            //}
        }

        private void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MainMap.Zoom < MainMap.MaxZoom)
            {
                var zoom = (int)(MainMap.Zoom + 1);
                if (zoom > MainMap.MaxZoom)
                {
                    zoom = MainMap.MaxZoom;
                }
                ztbMap.Value = zoom;
                MainMap.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void MainMap_OnMarkerEnter(GMapMarker item)
        {
            _currentMarker = item;
        }

        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!_isMouseDown) _currentMarker = null;
        }

        #endregion

        #endregion

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        //private void btn_UpDown_Click(object sender, EventArgs e)
        //{
        //    if (pnlInfo.Height < 180)
        //    {
        //        pnlInfo.Size = new Size(pnlInfo.Width, 185);
        //    }
        //    else
        //    {
        //        pnlInfo.Size = new Size(pnlInfo.Width, 25);
        //    }
        //}

        private void btnStart_Click(object sender, EventArgs e)
        {
            string strAddress = txtStart.Text.Trim();
            if (!string.IsNullOrEmpty(strAddress) && txtStart.KinhDo <= 0 && txtStart.ViDo <= 0)
            {
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad.Equals("*") || ad.Trim().Equals(""))
                {
                    lblMsg.Text = "Không tìm thấy điểm xuất phát";
                    txtStart.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStart != null)
                {
                    _markerStart.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerStart.ToolTipText = "Điểm xuất phát:" + strAddress;
                    MainMap.Position = _markerStart.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerAOne(double.Parse(cut[0]), double.Parse(cut[1]),
                        "Điểm xuất phát:" + strAddress);
                    _markerStart = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
            }
            else
            {
                double kinhdo, vido = 0;
                var address = "";
                var position = MainMap.Position;
                if (txtStart.KinhDo > 0 && txtStart.ViDo > 0)
                {
                    kinhdo = txtStart.KinhDo;
                    vido = txtStart.ViDo;
                    position = new PointLatLng(vido, kinhdo);
                    address = strAddress;
                }
                else
                {
                    kinhdo = position.Lng;
                    vido = position.Lat;
                    address = Service_Common.GetAddressByGeoBA((float)vido, (float)kinhdo);
                }
                _flgmarkerA = true;
                if (_markerStart != null)
                {

                    _markerStart.Position = position;
                    _markerStart.ToolTipText = "Điểm xuất phát:" + address;
                    MainMap.Position = _markerStart.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerAOne(vido, kinhdo, "Điểm xuất phát:" + address);
                    _markerStart = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                txtStart.Text = address;

            }
            Route();
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            string strAddress = txtStop1.Text.Trim();
            if (!string.IsNullOrEmpty(strAddress) && txtStop1.KinhDo <= 0 && txtStop1.ViDo <= 0)
            {
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad.Trim().Equals("*") || ad.Trim().Equals(""))
                {
                    lblMsg.Text = "Không tìm thấy điểm 1";
                    txtStop1.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStop1 != null)
                {
                    _markerStop1.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    MainMap.Position = _markerStop1.Position;
                    _markerStop1.ToolTipText = "Điểm 1:" + strAddress;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 1:" + strAddress, MarkerCustomType.B, MarkerTooltipMode.OnMouseOver);
                    _markerStop1 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
            }
            else
            {
                double kinhdo, vido = 0;
                var address = "";
                var position = MainMap.Position;//.FromLocalToLatLng(MainMap.Width / 2, MainMap.Height / 2);
                if (txtStop1.KinhDo > 0 && txtStop1.ViDo > 0)
                {
                    kinhdo = txtStop1.KinhDo;
                    vido = txtStop1.ViDo;
                    position = new PointLatLng(vido, kinhdo);
                    address = strAddress;
                }
                else
                {
                    kinhdo = position.Lng;
                    vido = position.Lat;
                    address = Service_Common.GetAddressByGeoBA((float)vido, (float)kinhdo);
                }
                _flgmarker1 = true;
                if (_markerStop1 != null)
                {
                    _markerStop1.Position = position;
                    _markerStop1.ToolTipText = "Điểm 1:" + address;
                    MainMap.Position = _markerStop1.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(vido, kinhdo, "Điểm 1:" + address, MarkerCustomType.B, MarkerTooltipMode.OnMouseOver);
                    _markerStop1 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                txtStop1.Text = address;
            }
            Route();
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            string strAddress = txtStop2.Text.Trim();
            if (!string.IsNullOrEmpty(strAddress) && txtStop2.KinhDo <= 0 && txtStop2.ViDo <= 0)
            {
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad.Trim().Equals("*") || ad.Trim().Equals(""))
                {
                    lblMsg.Text = "Không tìm thấy điểm 2";
                    txtStop2.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStop2 != null)
                {
                    _markerStop2.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    MainMap.Position = _markerStop2.Position;
                    _markerStop2.ToolTipText = "Điểm 2:" + strAddress;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 2:" + strAddress,
                        MarkerCustomType.C, MarkerTooltipMode.OnMouseOver);
                    _markerStop2 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }

            }
            else
            {
                double kinhdo, vido = 0;
                var address = "";
                var position = MainMap.Position;//.FromLocalToLatLng(MainMap.Width / 2, MainMap.Height / 2);
                if (txtStop2.KinhDo > 0 && txtStop2.ViDo > 0)
                {
                    kinhdo = txtStop2.KinhDo;
                    vido = txtStop2.ViDo;
                    position = new PointLatLng(vido, kinhdo);
                    address = strAddress;
                }
                else
                {
                    kinhdo = position.Lng;
                    vido = position.Lat;
                    address = Service_Common.GetAddressByGeoBA((float)vido, (float)kinhdo);
                }
                _flgmarker2 = true;                
                if (_markerStop2 != null)
                {
                    _markerStop2.Position = position;
                    _markerStop2.ToolTipText = "Điểm 2:" + address;
                    MainMap.Position = _markerStop2.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(vido, kinhdo, "Điểm 2:" + address,
                        MarkerCustomType.C, MarkerTooltipMode.OnMouseOver);
                    _markerStop2 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                txtStop2.Text = address;
            }
            Route();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            string strAddress = txtEnd.Text.Trim();
            if (!string.IsNullOrEmpty(strAddress) && txtStop2.KinhDo <= 0 && txtStop2.ViDo <= 0)
            {
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad.Trim().Equals("*") || ad.Trim().Equals(""))
                {
                    lblMsg.Text = "Không tìm thấy điểm dừng cuối";
                    txtEnd.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerEnd != null)
                {
                    _markerEnd.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    MainMap.Position = _markerEnd.Position;
                    _markerEnd.ToolTipText = "Điểm dừng cuối:" + strAddress;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerDOne(double.Parse(cut[0]), double.Parse(cut[1]),
                        "Điểm dừng cuối:" + strAddress);
                    _markerEnd = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }

            }
            else
            {
                double kinhdo, vido = 0;
                var address = "";
                var position = MainMap.Position;//.FromLocalToLatLng(MainMap.Width / 2, MainMap.Height / 2);
                if (txtEnd.KinhDo > 0 && txtEnd.ViDo > 0)
                {
                    kinhdo = txtEnd.KinhDo;
                    vido = txtEnd.ViDo;
                    position = new PointLatLng(vido, kinhdo);
                    address = strAddress;
                }
                else
                {
                    kinhdo = position.Lng;
                    vido = position.Lat;
                    address = Service_Common.GetAddressByGeoBA((float)vido, (float)kinhdo);
                }
                _flgmarkerB = true;                
                if (_markerEnd != null)
                {
                    _markerEnd.Position = position;
                    _markerEnd.ToolTipText = "Điểm dừng cuối:" + address;
                    MainMap.Position = _markerEnd.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerDOne(vido, kinhdo, "Điểm dừng cuối:" + address);
                    _markerEnd = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                txtEnd.Text = address;
            }
            Route();
        }

        #region Function
        private bool avoidHighways { get; set; }
        private bool avoidToy { get; set; }
        /// <summary>
        // Thêm đường vào bản đồ và lấy độ dài của đoạn đườn        /// </summary>
        /// <param name="start">Điểm bắt đầu</param>
        /// <param name="end">Điểm kết thúc</param>
        /// <param name="color">mầu</param>
        /// <returns>KM</returns>
        private KeyValuePair<double, string> AddRoute(PointLatLng start, PointLatLng end, Color color)
        {
            try
            {
            GDirections direction;
            DirectionsStatusCode directionStatus = GMapProviders.GoogleMap.GetDirections(out direction, start, end, avoidHighways, false, false, false, false);
            GMapRoute route = new GMapRoute(direction.Route, "MyRoute");
            if (route.Points != null && route.Points.Count > 0)
                MainMap.AddRoute(route, CommonUtils.SetTransparency(100, color));
            else
            {
                lblMsg.Text = "Không tìm thấy đường";
            }
            return new KeyValuePair<double, string>(route.Distance, route.Name);

            }
            catch (Exception ex)
            {
                lblMsg.Text = "Không tìm thấy đường";
                LogError.WriteLogError("AddRoute:", ex);
                return new KeyValuePair<double, string>(0, "");
            }
        }

        private KeyValuePair<double, string> AddRoute_ByService_Company(PointLatLng start, PointLatLng end, Color color)
        {
            try
            {
                float fromLat, fromLng, toLat, toLng = 0;
                float.TryParse(start.Lat.ToString(), out fromLat);
                float.TryParse(start.Lng.ToString(), out fromLng);
                float.TryParse(end.Lat.ToString(), out toLat);
                float.TryParse(end.Lng.ToString(), out toLng);

                Taxi.Services.WCFServiceGEO.PriceResponse itemReturn = Service_Common.GetPrice(fromLat, fromLng, toLat, toLng, Config_Common.DTV_ROUTE_SERVICE, G_CarType);
                if (itemReturn != null && itemReturn.Price > 0)
                {
                    if (color.Name == lbl_KM1.ForeColor.Name)
                    {
                        if (MainMap.Overlays[1].Markers != null && MainMap.Overlays[1].Markers.Count > 0)
                        {
                            MainMap.Overlays[1].Markers.Clear();
                        }
                    }
                    else if (color.Name == lbl_KM2.ForeColor.Name)
                    {
                        if (MainMap.Overlays[2].Markers != null && MainMap.Overlays[2].Markers.Count > 0)
                        {
                            MainMap.Overlays[2].Markers.Clear();
                        }
                    }
                    else if (color.Name == lbl_KM3.ForeColor.Name)
                    {
                        if (MainMap.Overlays[3].Markers != null && MainMap.Overlays[3].Markers.Count > 0)
                        {
                            MainMap.Overlays[3].Markers.Clear();
                        }
                    }
                    var lstCoordinate = MapHelper.PolylineAlgorithmDecode(itemReturn.Polyline);

                    PointLatLng itemStart = new PointLatLng();
                    PointLatLng itemEnd = new PointLatLng();
                    Pen pen = new Pen(color, 3);
                    for (int i = 1; i < lstCoordinate.Count(); i++)
                    {
                        Coordinate itemCoor1 = lstCoordinate.ElementAt(i - 1);
                        Coordinate itemCoor2 = lstCoordinate.ElementAt(i);

                        itemStart = new PointLatLng(itemCoor1.Latitude, itemCoor1.Longitude);
                        itemEnd = new PointLatLng(itemCoor2.Latitude, itemCoor2.Longitude);
                        GMapMarkerLine auxLine = new GMapMarkerLine(itemStart, itemEnd, pen);
                        if (color.Name == lbl_KM1.ForeColor.Name)
                        {
                            MainMap.Overlays[1].Markers.Add(auxLine);                            
                        }
                        else if (color.Name == lbl_KM2.ForeColor.Name)
                        {
                            MainMap.Overlays[2].Markers.Add(auxLine);
                        }
                        else if (color.Name == lbl_KM3.ForeColor.Name)
                        {
                            MainMap.Overlays[3].Markers.Add(auxLine);
                        }

                    }
                }
                return new KeyValuePair<double, string>(Math.Round((double)itemReturn.Distance / 1000, 1), color.Name);

            }
            catch (Exception)
            {
                return new KeyValuePair<double, string>(0, "");
            }
        }

        /// <summary>
        /// Hàm vẽ đường và thêm mũi tên chỉ hướng
        /// </summary>
        /// <param name="start">Điểm bắt đầu</param>
        /// <param name="end">Điểm kết thúc</param>
        /// <param name="color"> mầu</param>
        /// <returns>KM</returns>
        public KeyValuePair<double, string> AddDirections(PointLatLng start, PointLatLng end, Color color)
        {
            if (Config_Common.DTV_ROUTE_SERVICE > 0)
            {
                return AddRoute_ByService_Company(start, end, color);
            }
            else
            {
                return AddRoute(start, end, color);
            }
        }
        private void Route()
        {
            var routemsg = string.Empty;
            lblMsg.Text = "";
            try
            {
                double lat = 0;
                double lng = 0;
                //long time = 0;
                var lan = 0;
                MainMap.Zoom = 10;
                MainMap.ClearRoute();
                if (_markerStart != null && _markerStop1 != null)
                {
                    lan += 2;
                    lat += (_markerStart.Position.Lat + _markerStop1.Position.Lat);
                    lng += (_markerStart.Position.Lng + _markerStop1.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStart.ToolTipText.Split(':')[0],
                        _markerStop1.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStart.Position, _markerStop1.Position, lbl_KM1.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM1.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerStop1.Position;
                }
                if (_markerStop1 != null && _markerStop2 != null)
                {
                    lan += 2;
                    lat += (_markerStop1.Position.Lat + _markerStop2.Position.Lat);
                    lng += (_markerStop1.Position.Lng + _markerStop2.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStop1.ToolTipText.Split(':')[0],
                        _markerStop2.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStop1.Position, _markerStop2.Position, lbl_KM2.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM2.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerStop2.Position;
                }
                if (_markerStop1 != null && _markerStop2 == null && _markerEnd != null)
                {
                    lan += 2;
                    lat += (_markerStop1.Position.Lat + _markerEnd.Position.Lat);
                    lng += (_markerStop1.Position.Lng + _markerEnd.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStop1.ToolTipText.Split(':')[0],
                        _markerEnd.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStop1.Position, _markerEnd.Position, lbl_KM3.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM3.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerEnd.Position;
                }
                if (_markerStop2 != null && _markerStop1 == null && _markerStart != null)
                {
                    lan += 2;
                    lat += (_markerStop2.Position.Lat + _markerStart.Position.Lat);
                    lng += (_markerStop2.Position.Lng + _markerStart.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStart.ToolTipText.Split(':')[0],
                        _markerStop2.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStart.Position, _markerStop2.Position, lbl_KM1.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM1.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerStop2.Position;
                }
                if (_markerStop2 != null && _markerEnd != null)
                {
                    lan += 2;
                    lat += (_markerStop2.Position.Lat + _markerEnd.Position.Lat);
                    lng += (_markerStop2.Position.Lng + _markerEnd.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStop2.ToolTipText.Split(':')[0],
                        _markerEnd.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStop2.Position, _markerEnd.Position, lbl_KM3.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM3.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerEnd.Position;
                }
                if (_markerStart != null && _markerEnd != null && _markerStop1 == null && _markerStop2 == null)
                {
                    lan += 2;
                    lat += (_markerStart.Position.Lat + _markerEnd.Position.Lat);
                    lng += (_markerStart.Position.Lng + _markerEnd.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerStart.ToolTipText.Split(':')[0],
                        _markerEnd.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerStart.Position, _markerEnd.Position, lbl_KM3.ForeColor);
                    //time += ConvertTime(value.Value);
                    lbl_KM3.Text = value.Key.ToString("N1");
                    MainMap.Position = _markerEnd.Position;
                }
                lblKM_Sum.Text =
                    (lbl_KM1.Text.To<float>() + lbl_KM2.Text.To<float>() + lbl_KM3.Text.To<float>()).ToString("N1");
                //lblThoiGianduKien.Text = ConvertTimeString(time);
                //if (lan > 0)
                //    MainMap.Position = new PointLatLng(lat / lan, lng / lan);
                Calculator();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("route" + ex.Message + ":" + routemsg, ex);
                lblMsg.Text = "Lỗi không tìm thấy đường";
            }

        }

        private void Calculator()
        {
            try
            {
            string strKM = lblKM_Sum.Text.Trim();
            if (strKM != "" && strKM != "0")
            {
                double km = 0;
                double.TryParse(lblKM_Sum.Text.Trim(), out km);

                Ctrl_TinhTienTheoKM_V2.Calculate(km);
                if(int.TryParse(Ctrl_TinhTienTheoKM_V2.G_TongTienChieuDi.ToString(), out G_TongTienChieuDi))
                {
                    int.TryParse(Ctrl_TinhTienTheoKM_V2.G_TongTienChieuVe.ToString(), out G_TongTienChieuVe);
                }
                else
                {
                    lblMsg.Text = "Chưa có thông tin tiền";
                }
            }


            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi tính toán giá tiền", ex);
                lblMsg.Text = "Lỗi tính toán giá tiền";
            }
        }
        #endregion

        private void txt_SearchAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var address = Service_Common.GetGeobyAddressV2_Gooogle_Full(txt_SearchAddress.Text.Trim());

                if (address == null || address == "*" || address == "" || address.Split(' ').Length != 2)
                {
                    lblMsg.Text = "Không tìm thấy địa chỉ hoặc địa chỉ không tồn tại!";
                }
                else
                {
                    var cut = address.Split(' ');
                    MainMap.Position = new PointLatLng(cut[0].To<float>(), cut[1].To<float>());
                    MainMap.Zoom = 14;
                }
                txt_SearchAddress.Focus();
            }
        }

        private void frmChiDuong_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void txtStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string strAddress = txtStart.Text.Trim();
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad == null || ad.Equals("*") || ad == "")
                {
                    lblMsg.Text = "Không tìm thấy điểm xuất phát";
                    txtStart.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStart != null)
                {
                    _markerStart.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerStart.ToolTipText = "Điểm xuất phát:" + strAddress;
                    MainMap.Position = _markerStart.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerAOne(double.Parse(cut[0]), double.Parse(cut[1]),"Điểm xuất phát:" + strAddress);
                    _markerStart = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerA = false;
                Route();
            }
        }

        private void txtStop1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string strAddress = txtStop1.Text.Trim();
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad == null || ad.Equals("*") || ad == "")
                {
                    lblMsg.Text = "Không tìm thấy điểm đến 1";
                    txtStop1.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStop1 != null)
                {
                    _markerStop1.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerStop1.ToolTipText = "Điểm đến 1:" + strAddress;
                    MainMap.Position = _markerStop1.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 1:" + strAddress,
                        MarkerCustomType.B, MarkerTooltipMode.OnMouseOver);
                    _markerStop1 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerA = false;
                Route();
            }
        }

        private void txtStop2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string strAddress = txtStop2.Text.Trim();
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad == null || ad.Equals("*") || ad == "")
                {
                    lblMsg.Text = "Không tìm thấy điểm đến 2";
                    txtStop2.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerStop2 != null)
                {
                    _markerStop2.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerStop2.ToolTipText = "Điểm đến 2:" + strAddress;
                    MainMap.Position = _markerStop2.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 2:" + strAddress,
                        MarkerCustomType.C, MarkerTooltipMode.OnMouseOver);
                    _markerStop2 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerA = false;
                Route();
            }
        }

        private void txtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string strAddress = txtEnd.Text.Trim();
                var ad = Service_Common.GetGeobyAddressV2_Full(strAddress);
                if (ad == null || ad.Equals("*") || ad == "")
                {
                    lblMsg.Text = "Không tìm thấy điểm cuối";
                    txtEnd.Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerEnd != null)
                {
                    _markerEnd.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerEnd.ToolTipText = "Điểm cuối:" + strAddress;
                    MainMap.Position = _markerEnd.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm cuối:" + strAddress,
                        MarkerCustomType.C, MarkerTooltipMode.OnMouseOver);
                    _markerEnd = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerA = false;
                Route();
            }
        }


        [MethodWithKey(Keys = (Keys.Alt | Keys.T))]
        private void chkAvoidHighway_CheckedChanged(object sender, EventArgs e)
        {
            avoidHighways = chkAvoidHighway.Checked;
            Route();
        }

        private void btnChotHD_Click(object sender, EventArgs e)
        {
            if (Ctrl_TinhTienTheoKM_V2.G_TongTienChieuDi > 0)
                G_TongTienChieuDi = (int)Ctrl_TinhTienTheoKM_V2.G_TongTienChieuDi;
            G_StartAddress = txtStart.Text.Trim();
            G_EndAddress = txtEnd.Text.Trim();
            if (string.IsNullOrEmpty(G_EndAddress))
            {
                G_EndAddress = txtStop1.Text.Trim();
            }

            if (G_TongTienChieuDi <= 0)
            {
                lblMsg.Text = "Chưa có thông tin tiền, nên bạn không thể chốt được";
                return;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }
    }
}
