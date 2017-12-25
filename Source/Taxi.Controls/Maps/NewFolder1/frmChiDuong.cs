using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Business;
using Taxi.Common.Attributes;
using Taxi.Common.Extender;
//using Taxi.Controls.Extender;
using Taxi.Controls.GMapResources;
using Taxi.Services;
using Taxi.Utils;
using Taxi.Controls.Base;

namespace TaxiOperation_BanCo.DieuXe
{
    public partial class frmChiDuong : FormBase
    {
        #region Field

        private int _splitterDistance = 0;
        private int _splitContainerIndex;
        private GMapMarker _markerA;
        private GMapMarker _markerB;
        private GMapMarker _marker1;
        private GMapMarker _marker2;
        private bool _flgmarkerA = false;
        private bool _flgmarkerB = false;
        private bool _flgmarker1 = false;
        private bool _flgmarker2 = false;

        #endregion

        #region Map

        private GMapMarker _currentMarker;
        private bool _isMouseDown = false;
        public frmChiDuong()
        {
            InitializeComponent();
        }
        private void ConfigMap()
        {
            if (IsDesign) return;
            //config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);

            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = ThongTinCauHinh.GPS_MucZoom;
            var top = new GMapOverlay("top");
            MainMap.Overlays.Add(top);
            var route = new GMapOverlay("Route");
            MainMap.Overlays.Add(route);

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
            if (e.Button == MouseButtons.Left && _isMouseDown)
            {
                _isMouseDown = false;
                var address = Service_Common.GetAddressByGeoBA((float)_currentMarker.Position.Lat, (float)_currentMarker.Position.Lng);
                if (!address.Equals("*") && _currentMarker is GMapMarkerCustomType)
                {

                    switch (_currentMarker.As<GMapMarkerCustomType>().Type)
                    {
                        case MarkerCustomType.A:
                            _currentMarker.ToolTipText = _currentMarker.ToolTipText.Split(':')[0] + ":" + address;
                            this._markerA = _currentMarker;
                            if (txtDiemXuatPhat.Text.Trim() == "" || _flgmarkerA) txtDiemXuatPhat.Text = address;
                            break;
                        case MarkerCustomType.B:
                            _currentMarker.ToolTipText = _currentMarker.ToolTipText.Split(':')[0] + ":" + address;
                            this._markerB = _currentMarker;
                            if (txtDiemDungCuoi.Text.Trim() == "" || _flgmarkerB) txtDiemDungCuoi.Text = address;
                            break;
                        case MarkerCustomType.None:
                            var index = _currentMarker.ToolTipText.Remove(0, 4).Trim().Split(':')[0].To<int>();
                            _currentMarker.ToolTipText = string.Format("Điểm {0}:{1}", index, address);
                            switch (index)
                            {
                                case 1:
                                    if (txtDiemDen1.Text.Trim() == "" || _flgmarker1) txtDiemDen1.Text = address;
                                    break;
                                case 2:
                                    if (txtDiemDen2.Text.Trim() == "" || _flgmarker2) txtDiemDen2.Text = address;
                                    break;
                            }

                            break;
                    }
                    Route();

                }
                _currentMarker = null;
            }
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

        #region Event

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                ConfigMap();
                _splitContainerIndex = splitContainer1.SplitterDistance;
                SendKeys.Send("%");
                //groupBox.BindShControl();
                txtTimDiaChi.EditValue = null;
                //groupBox.FindIShInput().ForEach(p => ((Control)p).TextChanged += Action);
            }
            catch
            {

            }
        }

        private void Action(object sender, EventArgs e)
        {
            lblMsg.Text = "";
        }

        [MethodWithKey(Keys = Keys.Control | Keys.Space)]
        private void AnHienThongTin()
        {
            splitContainer1_MouseDoubleClick(null, null);
        }

        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var temp = splitContainer1.SplitterDistance;
            splitContainer1.SplitterDistance = _splitterDistance;
            _splitterDistance = temp > 0 && temp != _splitContainerIndex ? _splitContainerIndex : temp;
            btnDown.Visible = splitContainer1.SplitterDistance == 0;
            btnUp.Visible = splitContainer1.SplitterDistance != 0;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            splitContainer1_MouseDoubleClick(sender, null);
        }

        private void txtDiemXuatPhat_CoolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var ad = GetGeobyAddress(((TextBox)sender).Text);
                if (ad.Equals("*"))
                {
                    MessageBox.Show("Không tìm thấy điểm xuất phát");
                    ((TextBox)sender).Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerA != null)
                {
                    _markerA.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerA.ToolTipText = "Điểm xuất phát:" + ((TextBox)sender).Text;
                    MainMap.Position = _markerA.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerAOne(double.Parse(cut[0]), double.Parse(cut[1]),
                        "Điểm xuất phát:" + ((TextBox)sender).Text);
                    _markerA = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerA = false;
                Route();

            }
        }

        private void txtDiemDungCuoi_CoolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var ad = GetGeobyAddress(((TextBox)sender).Text);
                if (ad.Equals("*"))
                {
                    MessageBox.Show("Không tìm thấy điểm dừng cuối");
                    ((TextBox)sender).Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_markerB != null)
                {
                    _markerB.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _markerB.ToolTipText = "Điểm dừng cuối:" + ((TextBox)sender).Text;
                    MainMap.Position = _markerB.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarkerBOne(double.Parse(cut[0]), double.Parse(cut[1]),
                        "Điểm dừng cuối:" + ((TextBox)sender).Text);
                    _markerB = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarkerB = false;
                Route();

            }
        }

        private void txtDiemDen1_CoolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var ad = GetGeobyAddress(((TextBox)sender).Text);
                if (ad.Equals("*"))
                {
                    MessageBox.Show("Không tìm thấy điểm 1");
                    ((TextBox)sender).Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_marker1 != null)
                {
                    _marker1.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    MainMap.Position = _marker1.Position;
                    _marker1.ToolTipText = "Điểm 1:" + ((TextBox)sender).Text;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 1:" + ((TextBox)sender).Text,
                        MarkerCustomType.Chartreuse, MarkerTooltipMode.OnMouseOver);
                    _marker1 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarker1 = false;
                Route();
            }
        }

        private void txtDiemDen2_CoolKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (((TextBox)sender).Text == "")
                {
                    txtDiemDungCuoi.Focus();
                    return;
                }
                var ad = GetGeobyAddress(((TextBox)sender).Text);
                if (ad.Equals("*"))
                {
                    //MessageBox.Show("Không tìm thấy điểm 2");
                    //((TextBox) sender).Focus();
                    return;
                }
                var cut = ad.Split(' ');
                if (_marker2 != null)
                {
                    _marker2.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    _marker2.ToolTipText = "Điểm 2:" + ((TextBox)sender).Text;
                    MainMap.Position = _marker2.Position;
                }
                else
                {
                    MainMap.IsPosition = true;
                    MainMap.AddMarker_2(double.Parse(cut[0]), double.Parse(cut[1]), "Điểm 2:" + ((TextBox)sender).Text,
                        MarkerCustomType.Pink, MarkerTooltipMode.OnMouseOver);
                    _marker2 = MainMap.MarkerCustomer;
                    MainMap.IsPosition = false;
                }
                _flgmarker2 = false;
                Route();
                //if (txtDiemDen2.EnterMoveNextControl) txtDiemDungCuoi.Focus();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //groupBox.FindIShInput().ForEach(p => p.Clear());
            this._markerA = null;
            this._markerB = null;
            this._marker1 = null;
            this._marker2 = null;
            _flgmarkerA = false;
            _flgmarker1 = false;
            _flgmarker2 = false;
            _flgmarkerB = false;
            lbl_XP_1.Text = "0";
            lbl_1_2.Text = "0";
            lbl_Cuoi.Text = "0";
            lblTong.Text = "0";
            lblThoiGianduKien.Text = "";
            txtTimDiaChi.EditValue = null;
            MainMap.ClearAllMarkers();
            MainMap.ClearRoute();
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            txtDiemXuatPhat.Focus();
            lblMsg.Text = "";
        }

        private void shButton2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtTimDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var address = GetGeobyAddress(txtTimDiaChi.Text);

                if (address == null || address == "*" || address.Split(' ').Length != 2)
                {
                    MessageBox.Show("Không tìm thấy địa chỉ hoặc địa chỉ không tồn tại!", "Thông báo");
                }
                else
                {
                    var cut = address.Split(' ');
                    MainMap.Position = new PointLatLng(cut[0].To<float>(), cut[1].To<float>());
                    MainMap.Zoom = 14;
                }
                txtTimDiaChi.Focus();
            }
        }

        private void txtTimDiaChi_Leave(object sender, EventArgs e)
        {
            if (txtTimDiaChi.Text.Trim() == "") txtTimDiaChi.EditValue = null;
        }

        #endregion

        #region Function

        /// <summary>
        /// Thêm đường vào bản đồ và lấy độ dài của đoạn đường
        /// </summary>
        /// <param name="start">Điểm bắt đầu</param>
        /// <param name="end">Điểm kết thúc</param>
        /// <param name="color">mầu</param>
        /// <returns>KM</returns>
        private KeyValuePair<double, string> AddRoute(PointLatLng start, PointLatLng end, Color color)
        {
            GDirections direction;
            DirectionsStatusCode directionStatus = GMapProviders.GoogleMap.GetDirections(out direction, start, end, false, false, false, false, false);
            GMapRoute route = new GMapRoute(direction.Route, "MyRoute");
            if (route.Points != null && route.Points.Count > 0)
                MainMap.AddRoute(route, CommonUtils.SetTransparency(100, color));
            else
            {
                throw new Exception("Không tìm thấy đường");
            }
            return new KeyValuePair<double, string>(route.Distance, route.Name);
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
            return AddRoute(start, end, color);
        }

        /// <summary>
        /// Xử lý tìm đường theo từ điểm và nếu không có thì tìm theo service google
        /// </summary>
        public string GetGeobyAddress(string diaChi)
        {
            diaChi = StringTools.TrimSpace(diaChi);
            var address = Service_Common.GetGeobyAddressV2(diaChi);
            //double lat = 0;
            //double lng = 0;
            //if (!address.Equals("*"))
            //{
            //    //double.TryParse(address.Split(' ')[0], out lat);
            //    //double.TryParse(address.Split(' ')[1], out lng);
            //    return address;
            //}

            return address;
        }

        public string GetAddressByGeo(double lat, double lng)
        {
            var address = Service_Common.GetAddressByGeoBA((float)lat, (float)lng);
            return address;
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

                MainMap.ClearRoute();
                if (_markerA != null && _marker1 != null)
                {
                    lan += 2;
                    lat += (_markerA.Position.Lat + _marker1.Position.Lat);
                    lng += (_markerA.Position.Lng + _marker1.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerA.ToolTipText.Split(':')[0],
                        _marker1.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerA.Position, _marker1.Position, inputText1.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_XP_1.Text = value.Key.ToString("N1");
                }
                if (_marker1 != null && _marker2 != null)
                {
                    lan += 2;
                    lat += (_marker1.Position.Lat + _marker2.Position.Lat);
                    lng += (_marker1.Position.Lng + _marker2.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _marker1.ToolTipText.Split(':')[0],
                        _marker2.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_marker1.Position, _marker2.Position, inputText2.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_1_2.Text = value.Key.ToString("N1");
                }
                if (_marker1 != null && _marker2 == null && _markerB != null)
                {
                    lan += 2;
                    lat += (_marker1.Position.Lat + _markerB.Position.Lat);
                    lng += (_marker1.Position.Lng + _markerB.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _marker1.ToolTipText.Split(':')[0],
                        _markerB.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_marker1.Position, _markerB.Position, inputText3.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_Cuoi.Text = value.Key.ToString("N1");
                }
                if (_marker2 != null && _marker1 == null && _markerA != null)
                {
                    lan += 2;
                    lat += (_marker2.Position.Lat + _markerA.Position.Lat);
                    lng += (_marker2.Position.Lng + _markerA.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerA.ToolTipText.Split(':')[0],
                        _marker2.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerA.Position, _marker2.Position, inputText1.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_XP_1.Text = value.Key.ToString("N1");
                }
                if (_marker2 != null && _markerB != null)
                {
                    lan += 2;
                    lat += (_marker2.Position.Lat + _markerB.Position.Lat);
                    lng += (_marker2.Position.Lng + _markerB.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _marker2.ToolTipText.Split(':')[0],
                        _markerB.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_marker2.Position, _markerB.Position, inputText3.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_Cuoi.Text = value.Key.ToString("N1");
                }
                if (_markerA != null && _markerB != null && _marker1 == null && _marker2 == null)
                {
                    lan += 2;
                    lat += (_markerA.Position.Lat + _markerB.Position.Lat);
                    lng += (_markerA.Position.Lng + _markerB.Position.Lng);
                    routemsg = string.Format("{0}-{1}", _markerA.ToolTipText.Split(':')[0],
                        _markerB.ToolTipText.Split(':')[0]);
                    var value = AddDirections(_markerA.Position, _markerB.Position, inputText3.BackColor);
                    //time += ConvertTime(value.Value);
                    lbl_Cuoi.Text = value.Key.ToString("N1");
                }
                lblTong.Text =
                    (lbl_XP_1.Text.To<float>() + lbl_1_2.Text.To<float>() + lbl_Cuoi.Text.To<float>()).ToString("N1");
                //lblThoiGianduKien.Text = ConvertTimeString(time);
                if (lan > 0)
                    MainMap.Position = new PointLatLng(lat / lan, lng / lan);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message + ":" + routemsg;
            }

        }

        public long ConvertTime(string name)
        {
            var time = name.Split('/')[1];
            var time2 = time.Trim().Split(' ');
            if (time2.Count() == 4)
            {
                // ngày giờ phút
                var hours = time2[0].Trim().To<int>();
                var minutos = time2[2].Trim().To<int>();
                return hours * 60 + minutos;
            }
            else
            {
                var minutos = time2[0].Trim().To<int>();
                return minutos;
            }
        }

        public string ConvertTimeString(long time)
        {
            var timeStr = string.Empty;

            var minutos = time % 60;
            var hour = (time - minutos) / 60;
            if (hour > 0)
                timeStr += string.Format(" {0} Giờ", hour);
            if (minutos > 0)
                timeStr += string.Format(" {0} Phút", minutos);
            return timeStr;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmChiDuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(721, 387);
            this.Name = "frmChiDuong";
            this.ResumeLayout(false);

        }
    }
}
