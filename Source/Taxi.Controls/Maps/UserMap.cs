using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using GMap.NET.WindowsForms;
using Taxi.Services;
using Taxi.Business;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using System.Globalization;

namespace Taxi.Controls.Maps
{
    public delegate void EventUserMapSearch(string ChuoiTimKiem);
    public partial class UserMap : UserControlBase
    {
        /// <summary>
        /// Sự kiện tìm kiếm
        /// </summary>
        [Description("Sự kiện tìm kiếm.\nkhi có thì ko tìm kiếm theo mặc định.")]
        public event EventUserMapSearch EventSearch;
        [Description("Sau khi tìm kiếm xong thì thực hiện đến sự kiện này")]
        public event EventUserMapSearch AlterSearch;
        [Description("Sự kiện kích nút ok")]
        public event EventHandler EventOk;
        /// <summary>
        /// Chuỗi tìm kiếm.
        /// </summary>
        public string DiaChiTimKiem { get; set; }
        /// <summary>
        /// Địa chỉ tìm thấy
        /// </summary>
        public string DiaChi { get; set; }
        /// <summary>
        /// Vĩ độ
        /// </summary>
        public float Lat { get; set;}
        /// <summary>
        /// Kinh độ
        /// </summary>
        public float Lng { get; set; }
        private int _zoom;
        [Description("Độ phóng")]
        public int Zoom
        {
            get
            {
                if (shZoomMap != null)
                    _zoom = shZoomMap.Value;
                return _zoom;
            }
            set
            {
                _zoom = value;
                if (shZoomMap != null)
                    shZoomMap.Value = _zoom;
            }
        }
        private GMapMarker marker;
        private GMapMarker currentMarker;
        private bool IsMarker { get; set; }
        private bool IsMouseUp { get; set; }
        /// <summary>
        /// Inis the map.
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  16/09/2015   created
        /// </Modified>
        private void iniMap()
        {
            //use google provider
            gmap.MapProvider= GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            //gmap.CacheLocation = Application.ExecutablePath;
            gmap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            gmap.DisableFocusOnMouseEnter = true;
            //zoom min/max; default both = 2
            gmap.MinZoom = 2;
            gmap.MaxZoom = 22;
            gmap.ShowCenter = false;
            gmap.OnMapZoomChanged += gmap_OnMapZoomChanged;
            gmap.OnMarkerEnter += gmap_OnMarkerEnter;
            gmap.OnMarkerLeave += gmap_OnMarkerLeave;
            gmap.MouseDown += gmap_MouseDown;
            gmap.MouseMove += gmap_MouseMove;
            gmap.MouseUp += gmap_MouseUp;
            gmap.MouseDoubleClick+=gmap_MouseDoubleClick;

            shZoomMap.Properties.Minimum = 2;
            shZoomMap.Properties.Maximum = 22;
            if(_zoom == null||_zoom<=0)
            Zoom = ThongTinCauHinh.GPS_MucZoom;
        }

        void gmap_MouseUp(object sender, MouseEventArgs e)
        {
            currentMarker = null;
            IsMouseUp = false;
        }

        void gmap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                IsMouseUp = true;
            }
        }

        void gmap_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseUp && currentMarker!=null)
            {
              var pos=  currentMarker.Position = gmap.FromLocalToLatLng(e.X, e.Y);
              this.Lat = (float)pos.Lat;// float.Parse(cut[0], CultureInfo.InvariantCulture);
              this.Lng = (float)pos.Lng;// float.Parse(cut[1], CultureInfo.InvariantCulture);
              try
              {
                  string address = Service_Common.GetAddressByGeoBA(this.Lat, this.Lng);
                  this.DiaChi = address;
                  currentMarker.ToolTipText = address;
              }
              catch (Exception ex)
              {

              }

              //  gmap.Position = gmap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        void gmap_OnMarkerLeave(GMapMarker item)
        {
            IsMarker = false;
            //currentMarker = null;
        }

        void gmap_OnMarkerEnter(GMapMarker item)
        {
            if (marker == item)
            {
                IsMarker = true;
                currentMarker = item;
            }
        }

        void gmap_OnMapZoomChanged()
        {
            Zoom = (int)gmap.Zoom;
        }
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (gmap.Zoom < gmap.MaxZoom)
            {
                int zoom = (int)(gmap.Zoom + 1);
                if (zoom > gmap.MaxZoom)
                {
                    zoom = gmap.MaxZoom;
                }
                Zoom = zoom;
                gmap.Position = gmap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ChuoiTimKiem"></param>
        private void FuncSearch(string ChuoiTimKiem)
        {
            try
            {
                this.Lat = 0.0f;
                this.Lng = 0.0f;
                this.DiaChi = string.Empty;
                this.DiaChiTimKiem = ChuoiTimKiem;
                if (gmap.Overlays.Count <1)
                {
                    gmap.Overlays.Add(new GMapOverlay("DiaChi"));
                }
                gmap.Overlays[0].Markers.Clear();
                string address = Taxi.Services.Service_Common.GetGeobyAddress(ChuoiTimKiem, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                if (address == "*")
                {
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ hoặc địa chỉ không tồn tại!", "Thông báo");
                }
                else
                {
                    string[] cut = address.Split(' ');
                    this.Lat = float.Parse(cut[0], CultureInfo.InvariantCulture);
                    this.Lng = float.Parse(cut[1], CultureInfo.InvariantCulture);
                    this.DiaChi = ChuoiTimKiem;

                    marker = new GMarkerGoogle(new PointLatLng(this.Lat, this.Lng), GMarkerGoogleType.green);
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    marker.ToolTipText = ChuoiTimKiem;
                    gmap.Overlays[0].Markers.Add(marker);
                    gmap.Position = new PointLatLng(this.Lat, this.Lng);
                    gmap.Zoom = 16;
                }
               
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("UserMap.FuncSearch", ex);
                new MessageBox.MessageBoxBA().Show("Không tìm thấy dịch vụ tìm kiếm địa chị!", "Thông báo");
            }
           
        }

        public void Bind()
        {
            iniMap();
            txtSearchAddress.Text = this.DiaChiTimKiem;
            if (gmap.Overlays.Count < 1)
            {
                gmap.Overlays.Add(new GMapOverlay("DiaChi"));
            }
            gmap.Overlays[0].Markers.Clear();
            if (this.Lat > 0 && this.Lng > 0)
            {                
                marker = new GMarkerGoogle(new PointLatLng(this.Lat, this.Lng), GMarkerGoogleType.green);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = this.DiaChiTimKiem;
                gmap.Overlays[0].Markers.Add(marker);
                gmap.Position = new PointLatLng(this.Lat, this.Lng);
                gmap.Zoom = 16;
            }
            else if (!string.IsNullOrEmpty(txtSearchAddress.Text))
            {
                FuncSearch(txtSearchAddress.Text.Trim());
            }
           
        }
        public UserMap()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            InitializeComponent();
        }

        private void shZoomMap_EditValueChanged(object sender, EventArgs e)
        {
            gmap.Zoom = shZoomMap.Value;
        }

        private void txtSearchAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DiaChiTimKiem = txtSearchAddress.Text;
                if (EventSearch != null)
                {
                    EventSearch(DiaChiTimKiem);
                }
                else
                {
                    FuncSearch(DiaChiTimKiem);
                }
                if (AlterSearch != null)
                {
                    AlterSearch(DiaChiTimKiem);
                }
            }
        }
      
        private void UserMap_Load(object sender, EventArgs e)
        {
          //  if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (EventOk != null)
            {
                if (DiaChi.Trim() == "")
                    DiaChi = DiaChiTimKiem;
                EventOk(btnOk, null);
            }
        }

        private void txtSearchAddress_Leave(object sender, EventArgs e)
        {
            if (txtSearchAddress.Text.Trim() == "")
                txtSearchAddress.EditValue = null;
        }

        private void txtSearchAddress_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearchAddress.Text.Trim() == "")
                txtSearchAddress.EditValue = null;
        }

    }
}
