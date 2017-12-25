using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Taxi.Services;

namespace Taxi.Controls.Maps
{
    public partial class sub_map : UserControl
    {
        GMapMarker marker;
        public GMapMarker MarkerCustomer;
        public GMapOverlay overlays;
        public GMapOverlay overlays_XeDeCu;
        public static double KinhDo=0;
        public static double ViDo = 0;

        public sub_map()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            InitializeComponent();
            ini_map();

            var img1 = new PictureBox();
            img1.Size = new Size(25, txtDiaChi.ClientSize.Height + 2);
            img1.Location = new Point(txtDiaChi.ClientSize.Width - img1.Width + 5, 0);
            img1.Cursor = Cursors.Default;
            img1.Image = Taxi.Controls.Properties.Resources.search;

            txtDiaChi.Controls.Add(img1);
        }


        private void ini_map()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            //use google provider
            gmap.MapProvider = GoogleMapProvider.Instance;
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            //gmap.CacheLocation = Application.ExecutablePath;
            gmap.Position = new PointLatLng(20.841514, 106.683023);
            gmap.DisableFocusOnMouseEnter = true;
            //zoom min/max; default both = 2
            gmap.MinZoom = 2;
            gmap.MaxZoom = 22;
            gmap.ShowCenter = false;
            //set zoom
            gmap.Zoom = 14;
            overlays = new GMapOverlay("DiaChi");
            overlays_XeDeCu = new GMapOverlay("XeDeCu");

            gmap.Overlays.Add(overlays);
            gmap.Overlays.Add(overlays_XeDeCu);
            zoomTrackBarControl1.Value = 14;
            
        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            gmap.Zoom = zoomTrackBarControl1.Value;
        }

        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            gmap.Zoom += 1;
        }

        private void gmap_OnMapZoomChanged()
        {
            zoomTrackBarControl1.Value = int.Parse(gmap.Zoom.ToString());
        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            overlays.Markers.Clear();
            switch(e.Button)
            {
                case MouseButtons.Left:
                    marker = new GMarkerGoogle(new PointLatLng(gmap.FromLocalToLatLng(e.X, e.Y).Lat, gmap.FromLocalToLatLng(e.X, e.Y).Lng), GMarkerGoogleType.green);
                    overlays.Markers.Add(marker);
                    KinhDo = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                    ViDo = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                    break;
                case MouseButtons.Right:
                    overlays.Markers.Clear();
                    break;
            }
        }

        public void setLocation(double ViDo,double KinhDo) {
            if (ViDo != 0 && KinhDo != 0)
            {
                overlays.Markers.Clear();
                gmap.Position = new PointLatLng(ViDo, KinhDo);
                marker = new GMarkerGoogle(new PointLatLng(ViDo, KinhDo), GMarkerGoogleType.green);
                overlays.Markers.Add(marker);
            }
            else {
                gmap.Position = new PointLatLng(20.841514, 106.683023);
            }
        }


        private void txtDiaChi_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (txtDiaChi.Text.Equals("Tìm địa chỉ") == true)
                    {
                        txtDiaChi.Text = "";
                        txtDiaChi.ForeColor = Color.Black;
                    }
                    break;
            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDiaChi.Text.TrimStart();

        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string address;
                address = "";// BAGPSServices.ServiceClient.GetGeobyAddressBA3(txtDiaChi.Text);
                if (address == "*")
                {
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ hoặc địa chỉ không tồn tại!", "Thông báo");
                }
                else
                {
                    string[] cut = address.Split(' ');
                    marker = new GMarkerGoogle(new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1])), GMarkerGoogleType.green);
                    overlays.Markers.Add(marker);
                    gmap.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                    gmap.Zoom = 16;
                }
            }
        }
    }
}
