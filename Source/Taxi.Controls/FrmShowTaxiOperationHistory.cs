using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Services.BAGIS;

namespace Taxi.Controls
{
    public partial class FrmShowTaxiOperationHistory : FormBase
    {
        public bool IsShow = false;
        private TaxiperationHistory _model;
        public FrmShowTaxiOperationHistory()
        {
            InitializeComponent();
        }
        private void FrmShowTaxiOperationHistory_Load(object sender, EventArgs e)
        {
            ConfigMap();           
        }
        public void SetModel(TaxiperationHistory model)
        {
            _model = model;
            panTop.Fill(model);
            if (_model.GPS_ViDo > 0 && _model.GPS_KinhDo > 0)
            {
                MainMap.addMarkerMG(new PointLatLng(_model.GPS_ViDo, _model.GPS_KinhDo), _model.DiaChiDonKhach);
            }
        }

        #region MAP

        // Toyota MyDinh Building
        private PointLatLng currentPoint = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
        private GMapProvider _mapType;
        private Taxi.Utils.MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        GMapMarkerCustom centerMarker;
        GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;

        bool isMouseDown;
        private void ShowMap()
        {
            //if (grpViTri.Visible == true)
            //{
            //    this.ClientSize = new System.Drawing.Size(425, 367);
            //    grpViTri.Visible = false;
            //}
            //else
            //{
            //    this.ClientSize = new System.Drawing.Size(337, 169);
            //    grpViTri.Visible = true;
            //}
        }

        private void ConfigMap()
        {
            try
            {
                // config gmaps
                MainMap.CacheLocation = Application.StartupPath + "\\Map";
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MainMap.MapProvider = GMapProviders.GoogleMap;
                MainMap.MaxZoom = 19;
                MainMap.MinZoom = 7;
                MainMap.Zoom = 17;

                MainMap.Position = currentPoint;
                MainMap.PolygonsEnabled = false;
                MainMap.AllowDrawPolygon = false;

                // map events
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

                // add custom layers  
                {
                    top = new GMapOverlay("top");
                    MainMap.Overlays.Add(top);
                }

                CustomInitMap();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ConfigMap: " , ex);
            }

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
                    MainMap.addMarkerCustomer(MainMap.FromLocalToLatLng(e.X, e.Y), txtAddress.Text.Trim());
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
        
        #endregion
    }
}
