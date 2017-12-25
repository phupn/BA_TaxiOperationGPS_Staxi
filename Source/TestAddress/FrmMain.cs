using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace TestAddress
{
    public partial class FrmMain : Form
    {
        #region===Form event===
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //TaxiServices.Authentication auth = new TaxiServices.Authentication();
            //auth.Password = "BA-8B-10-80-49-8E-45-A1-0E-CE-73-2A-25-1C-50-C1-51-AB-CB-96";
            //auth.UserName = "thanhcongtaxi";
            
            //TaxiServices.TaxiOperation_ServicesSoapClient service = new TaxiServices.TaxiOperation_ServicesSoapClient();
            //string call = service.GetCallsInfo_Test(auth, DateTime.Now, "thanhcongtaxi.vn");
            //TaxiServices.CallInfo[] call2 = service.GetCallsInfo(auth, DateTime.Now, "thanhcongtaxi.vn");
            ConfigMap();
            lblZoom.Text = MainMap.Zoom.ToString();
            txtDiaChi.Select();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }
        #endregion
        private double _kinhDo;
        private double _viDo;

        #region MAP
        private void ConfigMap()
        {
            try
            {
                // config gmaps
                // MainMap.CacheLocation = Application.StartupPath + "\\Map";
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MainMap.MapProvider = BinhAnhMapProvider.Instance;
                MainMap.MaxZoom = 19;
                MainMap.MinZoom = 7;
                MainMap.Zoom = 15;
                MainMap.Dock = DockStyle.Fill;
                MainMap.DragButton = MouseButtons.Left;
                //Them Overlay cho MainMap
                MainMap.SetAddingMarker();

                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
                MainMap.MouseClick += MainMap_MouseClick;

                MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;

                // get zoom  
                trackBarMap.Minimum = MainMap.MinZoom;
                trackBarMap.Maximum = MainMap.MaxZoom;
                trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

                MainMap.Position = new PointLatLng(20.9742831854914, 105.845975875854);//Lấy ở Hà Nội!
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
                MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("TestAddress.ConfigMap", exx);
            }
        }

        #region===================Map Events==================================

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            //trackBarMap.Minimum = MainMap.MinZoom;
            //trackBarMap.Maximum = MainMap.MaxZoom;
        }

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
            lblZoom.Text = MainMap.Zoom.ToString();
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
           
        }
        void MainMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (MainMap.OverlayCustom != null || MainMap.OverlayCustom.Markers.Count > 0)
                {
                    MainMap.OverlayCustom.Markers.Clear();
                }

                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                try
                {
                    string strDiaChi = Taxi.Services.Service_Common.GetAddressByGeoBA((float)point.Lat, (float)point.Lng);

                    MainMap.addMarkerCustomer(point, strDiaChi);
                    txtKetQuaToaDo.Text = point.Lat + "," + point.Lng;
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("MainMap_MouseDown:", ex);
                }
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
        }
        #endregion=============================================================

        #endregion=============================================================

        #region=== event control===
        private void ckbGoogleMap_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbGoogleMap.Checked)
            {
                MainMap.MapProvider = GoogleMapProvider.Instance;
            }
            else
            {
                MainMap.MapProvider = BinhAnhMapProvider.Instance;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                if (!string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
                {
                    SearchByAddress();
                    txtKinhDo.Text = "";
                    txtViDo.Text = "";
                }
                else if (!string.IsNullOrEmpty(txtKinhDo.Text.Trim()) && !string.IsNullOrEmpty(txtViDo.Text.Trim()))
                {
                    SearchByLatLng();
                    txtDiaChi.Text = "";
                    txtKetQuaToaDo.Text = "";
                }
            }
        }

        private void txtDiaChi_EditValueChanged(object sender, EventArgs e)
        {
            //    if (!string.IsNullOrEmpty(txtKinhDo.Text) || !string.IsNullOrEmpty(txtViDo.Text))
            //    {
            //        txtKinhDo.Text = "";
            //        txtViDo.Text = "";
            //    }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTenTinh.Text = "Hà Nội";
            txtDiaChi.Text = "";
            txtKinhDo.Text = "";
            txtViDo.Text = "";
            txtKetQuaToaDo.Text = "";
            lblMsg.Text = "";
            ckbGoogleMap.Checked = false;
            if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
            {
                MainMap.OverlayCustom.Markers.Clear();
            }
        }

        #endregion

        #region===Method===
        private void SearchByAddress()
        {
            string address = txtDiaChi.Text.Trim();
            string toaDo = Taxi.Services.Service_Common.GetGeobyAddressV3(txtTenTinh.Text, address, ckbGoogleMap.Checked);
            if (toaDo != "*" && toaDo != string.Empty)
            {
                string[] arrString = toaDo.Split(' ');
                _viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                _kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                txtKetQuaToaDo.Text = _viDo + "," + _kinhDo;
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                {
                    MainMap.OverlayCustom.Markers.Clear();
                }
                MainMap.addMarkerCustomer2(_kinhDo, _viDo, address);
                MainMap.Zoom = 17;
                lblMsg.Text = "";
            }
            else
            {
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                {
                    MainMap.OverlayCustom.Markers.Clear();
                }
                lblMsg.Text = "Không tìm thấy địa chỉ này";
                txtKetQuaToaDo.Text = "";
            }
        }
        private void SearchByLatLng()
        {
            double lat = float.Parse(txtViDo.Text);
            double lng = float.Parse(txtKinhDo.Text);
            try
            {
                string strDiaChi = Taxi.Services.Service_Common.GetAddressByGeoBAV2((float)lat, (float)lng, ckbGoogleMap.Checked);
                if (string.IsNullOrEmpty(strDiaChi))
                {
                    if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                    {
                        MainMap.OverlayCustom.Markers.Clear();
                    }
                    lblMsg.Text = "Không tìm thấy địa chỉ này";
                    txtKetQuaToaDo.Text = "";
                }
                else
                {
                    MainMap.addMarkerCustomer2(lng, lat, strDiaChi);
                    MainMap.Zoom = 17;
                    lblMsg.Text = "";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SearchByLatLng:", ex);
            }
        }
        private bool DoValidate()
        {
            if (string.IsNullOrEmpty(txtTenTinh.Text))
            {
                lblMsg.Text = "Bạn chưa nhập Tỉnh/TP";
                txtTenTinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()) && (string.IsNullOrEmpty(txtKinhDo.Text.Trim())) && (string.IsNullOrEmpty(txtViDo.Text.Trim())))
            {
                lblMsg.Text = "Bạn chưa nhập thông tin tìm kiếm";
                txtDiaChi.Select();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()) && ((string.IsNullOrEmpty(txtKinhDo.Text.Trim())) || (string.IsNullOrEmpty(txtViDo.Text.Trim()))))
            {
                lblMsg.Text = "Bạn chưa nhập đủ thông tin tọa độ.";
                txtKinhDo.Focus();
                return false;
            }
            return true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D))
            {
                txtDiaChi.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                txtKinhDo.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                txtViDo.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                ckbGoogleMap.Checked = !ckbGoogleMap.Checked;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                txtTenTinh.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                txtKetQuaToaDo.Select();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void shButton1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }
    }
}
