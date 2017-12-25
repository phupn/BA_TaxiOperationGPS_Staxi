using System;
using System.Windows.Forms;
using BAGPS;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Taxi.Business;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class frmMap : FormBase
    {
        public frmMap()
        {
            InitializeComponent();
        }

        #region Map
        private GMapMarker _currentMarker;
        private GMapMarker _MarkerA;
        private bool _isMouseDown = false;

        public string DiaChi;
        public PointLatLng ToaDo;
        private void ConfigMap()
        {
            //if (IsDesign) return;
            //config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);

            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 5;
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
            ztbMap.Minimum = MainMap.MinZoom;
            ztbMap.Maximum = MainMap.MaxZoom;
            ztbMap.Value = Convert.ToInt32(MainMap.Zoom);
            ztbMap.ValueChanged += ztbMap_EditValueChanged;
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
            if (e.Button == MouseButtons.Right && _isMouseDown)
            {
                var d = MainMap.FromLocalToLatLng(e.X, e.Y);
                if (_currentMarker == null)
                {
                  //  MainMap.AddMarkerCustomOne(d.Lat, d.Lng, "");
                    
                }
                else
                {
                    _currentMarker.Position = d;
                }
                if (_MarkerA != null)
                {
                    var diachi = BAService.GetAddressByGeo(float.Parse(d.Lat.ToString()), float.Parse(d.Lng.ToString()));
                    ToaDo = d;
                    DiaChi = diachi;
                    _MarkerA.ToolTipText = diachi;
                }
            }
            MainMap.Refresh(); // force instant invalidation
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _isMouseDown = true;
                var d = MainMap.FromLocalToLatLng(e.X, e.Y);
                var diachi = BAService.GetAddressByGeo(float.Parse(d.Lat.ToString()), float.Parse(d.Lng.ToString()));
                if (_currentMarker == null)
                {
                    MainMap.addMarkerCustomer(d, diachi);
                    _MarkerA = MainMap.MarkerCustomer;
                    _isMouseDown = false;
                }
                else
                {
                    _currentMarker.Position = d;
                }
              
                ToaDo = d;
                DiaChi = diachi;
                _MarkerA.ToolTipText = diachi;
            }
        }

        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isMouseDown == true)
            {
                
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

        #region Sự kiện
        private void frmMap_Load(object sender, EventArgs e)
        {
            ConfigMap();
            if (ToaDo!=null&&!string.IsNullOrEmpty(DiaChi))
            {
                MainMap.Position = ToaDo;
                MainMap.addMarkerCustomer(ToaDo, DiaChi);
                _MarkerA = MainMap.MarkerCustomer;
                MainMap.Zoom = 16;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                var dt=MainMap.GetGeoByAddress_Google(txtTimKiem.Text);
                if (dt.Contains("*"))
                {
                    MessageBox.Show("Không tìm thấy địa chỉ");
                }
                else
                {
                    var d = new PointLatLng(double.Parse(dt.Split(' ')[0]),double.Parse(dt.Split(' ')[1]));
                    if (_MarkerA == null)
                    {
                        DiaChi = txtTimKiem.Text;
                        MainMap.addMarkerCustomer(d, txtTimKiem.Text);
                        _MarkerA = MainMap.MarkerCustomer;
                        _isMouseDown = false;
                    }
                    else
                    {
                        DiaChi = txtTimKiem.Text;
                        _MarkerA.Position = d;
                        _MarkerA.ToolTipText = txtTimKiem.Text;
                    }
                    MainMap.Position = d;
                    MainMap.Zoom = 16;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
