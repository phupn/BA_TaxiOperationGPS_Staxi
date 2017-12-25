using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using Taxi.Business;
using Taxi.Controls.GMapResources;
using Taxi.Entity;
using Taxi.Common.Extender;

namespace Taxi.Controls
{
    public partial class ExtendedGMapControl : GMapControl
    {
        #region Fields

        private bool _allowDrawPolygon = false;

        #endregion

        #region Internal variables

        // markers
        private GMapMarker selectedVertice;
        private GMapMarker selectedIntermediatePoint;

        // layers
        private GMapOverlay OverlayFirst;
        private GMapOverlay OverlayPolygon_Vertices;
        private GMapOverlay OverlayPolygon_Auxiliary;//Polygon bổ sung
        private GMapOverlay OverlayBackground;
        public GMapOverlay OverlayRoute;
        public GMapOverlay OverlayCustom;
        public GMapOverlay OverlayXeDeCu;
        private GMapOverlay OverlayXeNhan;
        public GMapOverlay OverlayXeG5;
        private bool isMouseDown;
        private bool polygonIsComplete = false;
        private bool isDraggingVertice = false;
        private bool isDraggingIntermediatePoint = false;

        private CustomPolygon _polygon;
        private GMapPolygon _polygonBackground;
        //private CustomPolygon _polygonCustom;
        public GMapMarker MarkerCustomer;
        public GMapMarker MarkerXeDeCu;
        public GMapMarker MarkerXeG5;
        public GMapMarker MarkerXeNhan;
        public GMapMarker MarkerA;
        public GMapMarker MarkerB;
        #endregion

        #region Constructors

        public ExtendedGMapControl()
        {
            InitializeComponent();
            DragButton = MouseButtons.Left;
        }

        public ExtendedGMapControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region Properties
        
        public bool AllowDrawPolygon
        {
            get { return _allowDrawPolygon; }
            set { _allowDrawPolygon = value; }
        }

        #endregion

        #region Public methods
        /// <summary>
        /// Khoi tao over lay Custom.
        /// </summary>
        public void SetAddingMarker()
        {           
            // add custom layers  
            {
                OverlayCustom = new GMapOverlay("custom");
                this.Overlays.Add(OverlayCustom);
            }
        }

        /// <summary>
        /// xoa marker tren overlay Custom
        /// </summary>
        public void ClearAddingMarker()
        {
            if (OverlayCustom !=null && OverlayCustom.Markers.Count > 0)
            {
                OverlayCustom.Markers.Clear();
            }
        }

        /// <summary>
        /// Khoi tao overlay XeDeCu.
        /// </summary>
        public void SetAddingMarkerXeDeCu()
        {
            // add custom layers  
            {
                if (OverlayXeDeCu != null)
                {
                    OverlayXeDeCu = new GMapOverlay("XeDeCuOverlay");
                    this.Overlays.Add(OverlayXeDeCu);
                }                
            }
        }

        /// <summary>
        /// xoa marker tren overlay XeDeCu
        /// </summary>
        public void ClearAddingMarkerXeDeCu()
        {
            if (OverlayXeDeCu != null && OverlayXeDeCu.Markers.Count > 0)
            {
                OverlayXeDeCu.Markers.Clear();
            }
        }

        /// <summary>
        /// Khoi tao overlay XeNhan.
        /// </summary>
        public void SetAddingMarkerXeNhan()
        {
            // add custom layers  
            {
                OverlayXeNhan = new GMapOverlay("XeNhanOverlay");
                this.Overlays.Add(OverlayXeNhan);
            }
        }

        /// <summary>
        /// xoa marker tren overlay XeNhan
        /// </summary>
        public void ClearAddingMarkerXeNhan()
        {
            if (OverlayXeNhan != null && OverlayXeNhan.Markers.Count > 0)
            {
                OverlayXeNhan.Markers.Clear();
            }
        }

        /// <summary>
        /// Khoi tao overlay Polygon.
        /// </summary>
        public void SetDrawingPolygon(CustomPolygon polygon)
        {
            OverlayFirst = this.Overlays[0];

            _polygon = polygon;
            // add custom layers  
            {
                OverlayPolygon_Auxiliary = new GMapOverlay("auxiliary");//Overlay phụ
                this.Overlays.Add(OverlayPolygon_Auxiliary);
                OverlayPolygon_Vertices = new GMapOverlay("vertices");//overlay đỉnh
                this.Overlays.Add(OverlayPolygon_Vertices);
                OverlayRoute = new GMapOverlay("route");//overlay dẫn đường
                this.Overlays.Add(OverlayRoute);
            }

            if (!OverlayFirst.Polygons.Contains(_polygon))
                OverlayFirst.Polygons.Add(_polygon);

            //auxiliar.Markers.Clear();
            //vertices.Markers.Clear();

            //clear polygon
            _polygon.Points.Clear();
            this.UpdatePolygonLocalPosition(_polygon);

            polygonIsComplete = false;

        }

        /// <summary>
        /// Xóa polygon
        /// </summary>
        public void ClearDrawingPolygon()
        {
            if (this.PolygonsEnabled && _allowDrawPolygon)
            {
                if (OverlayPolygon_Auxiliary != null)
                    OverlayPolygon_Auxiliary.Markers.Clear();
                if (OverlayPolygon_Vertices != null)
                    OverlayPolygon_Vertices.Markers.Clear();

                //clear polygon
                if (_polygon != null)
                {
                    _polygon.Points.Clear();
                    this.UpdatePolygonLocalPosition(_polygon);
                }
                polygonIsComplete = false;
            }
        }

        public void SetDrawingPolygonCustom(CustomPolygon polygon)
        {
            ClearDrawingPolygon();
            OverlayFirst = this.Overlays[0];
            _polygon = polygon;
            {
                OverlayPolygon_Auxiliary = new GMapOverlay("auxiliary");
                this.Overlays.Add(OverlayPolygon_Auxiliary);
                OverlayPolygon_Vertices = new GMapOverlay("vertices");
                this.Overlays.Add(OverlayPolygon_Vertices);
            }
            //draw the polygon
            if (polygon.Points.Count > 2)
            {
                for (int i = 0; i < polygon.Points.Count; i++)
                {
                    GMapMarkerRedCircle vertice = null;
                    if (i == polygon.Points.Count - 1)
                        vertice = (GMapMarkerRedCircle)OverlayPolygon_Vertices.Markers[0];
                    else
                        vertice = new GMapMarkerRedCircle(polygon.Points[i]);

                    OverlayPolygon_Vertices.Markers.Add(vertice);
                    if (i > 0)
                    {
                        PointLatLng intermedium = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[i - 1], OverlayPolygon_Vertices.Markers[i]);
                        GMapMarkerGraySquare intermediatePoint = new GMapMarkerGraySquare(intermedium);
                        OverlayPolygon_Auxiliary.Markers.Add(intermediatePoint);
                    }
                }
                polygonIsComplete = true;
            }

            if (!OverlayFirst.Polygons.Contains(_polygon))
                OverlayFirst.Polygons.Add(_polygon);
        }

        /// <summary>
        /// Vẽ nhiều polygons
        /// </summary>
        /// <param name="polygons"></param>
        public void SetBackGroundPolygon(List<GMapPolygon> polygons)
        {
            
            this.Overlays[1].Clear();
            
            double LatCenter = 0, LngCenter = 0;
            double x1 = 0, x2 = 0, y1 = 0, y2 = 0;
            OverlayBackground = new GMapOverlay("background");
            //custom = new GMapOverlay("custom");
            OverlayBackground = this.Overlays[1];
            //custom = this.Overlays[0]

            foreach (GMapPolygon polygon in polygons)
            {
                _polygonBackground = polygon;
                OverlayBackground.Polygons.Add(_polygonBackground);

                x1 = polygon.Points.Min(p => p.Lat);
                x2 = polygon.Points.Max(p => p.Lat);
                y1 = polygon.Points.Min(p => p.Lng);
                y2 = polygon.Points.Max(p => p.Lng);
                LatCenter = x1 + ((x2 - x1) / 2);
                LngCenter = y1 + ((y2 - y1) / 2);
                AddCustomMarker(LatCenter, LngCenter, polygon.Name);//Add LabelMarker giữa polygon
            }
            ClearDrawingPolygon();
        }

        /// <summary>
        /// Xóa tất cả các marker và Overlay trên bản đồ
        /// </summary>
        public void ClearAll()
        {
            foreach (GMapOverlay overlay in Overlays)
            {
                overlay.Markers.Clear();
            }

            Overlays.Clear();
            _polygon = null;
            OverlayPolygon_Auxiliary = null;
            OverlayPolygon_Vertices = null;
            OverlayCustom = null;
            OverlayXeNhan = null;
            OverlayXeDeCu = null;
        }

        /// <summary>
        /// Xóa tất cả các marker trên bản đồ
        /// </summary>
        public void ClearAllMarkers()
        {
            foreach (GMapOverlay overlay in this.Overlays)
            {
                overlay.Markers.Clear();
            }
            Refresh();
        }

        public bool IsPosition = false;
        public void AddCustomMarker(double Lat, double Lng, string tooltip)
        {
            // tạo marker tại vị trí vừa tìm đc  
            OverlayBackground = this.Overlays[1];
            GMapMarker LabelPolygon = new GMapMarkerPolygonLabel(new PointLatLng(Lat, Lng));
            LabelPolygon.ToolTipText = tooltip;
            LabelPolygon.ToolTip.Stroke.Color = Color.Red;
            LabelPolygon.ToolTip.Stroke.Width = 2;
            LabelPolygon.IsVisible = true;
            LabelPolygon.Offset = LabelPolygon.ToolTipPosition;
            LabelPolygon.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            OverlayBackground.Markers.Add(LabelPolygon);
        }

        public void AddMarker(double Lat, double Lng, string tooltip)
        {
            OverlayCustom = new GMapOverlay("custom");
            this.Overlays.Add(OverlayCustom);
            GMapMarkerRedCircle marker = new GMapMarkerRedCircle(new PointLatLng(Lat, Lng));
            OverlayCustom.Markers.Add(marker);
        }
        public void AddMarker_2(double Lat, double Lng, string tooltip, MarkerCustomType type, MarkerTooltipMode mode = MarkerTooltipMode.Always, string title = "")
        {
            if (this.Overlays.Count == 0) this.Overlays.Add(new GMapOverlay());
            OverlayCustom = this.Overlays[0];
            //this.Overlays.Add(OverlayCustom);
            var marker = new GMapMarkerCustomType(new PointLatLng(Lat, Lng), type);
            marker.ToolTipText = tooltip;
            marker.ToolTipMode = mode;
            marker.Title = title;
            OverlayCustom.Markers.Add(marker);
            MarkerCustomer = marker;
            if (IsPosition)
                this.Position = marker.Position;
        }

        public void AddMarkerAOne(double Lat, double Lng, string tooltip)
        {
            AddMarkerOne(Lat, Lng, tooltip, MarkerCustomType.A);
        }
        public void AddMarkerBOne(double Lat, double Lng, string tooltip)
        {
            AddMarkerOne(Lat, Lng, tooltip, MarkerCustomType.B);
        }
        public void AddMarkerCOne(double Lat, double Lng, string tooltip)
        {
            AddMarkerOne(Lat, Lng, tooltip, MarkerCustomType.C);
        }
        public void AddMarkerDOne(double Lat, double Lng, string tooltip)
        {
            AddMarkerOne(Lat, Lng, tooltip, MarkerCustomType.D);
        }
        public void AddMarkerCustomOne(double Lat, double Lng, string tooltip)
        {
            AddMarkerOne(Lat, Lng, tooltip, MarkerCustomType.Custom);
        }
        public void AddMarkerOne(double Lat, double Lng, string tooltip, MarkerCustomType type)
        {
            if (this.Overlays.Count == 0) this.Overlays.Add(new GMapOverlay());
            OverlayCustom = this.Overlays[0];

            var marker = OverlayCustom.Markers.FirstOrDefault(
                   p => p is GMapMarkerCustomType && p.As<GMapMarkerCustomType>().Type == type);
            if (marker == null)
            {
                marker = new GMapMarkerCustomType(new PointLatLng(Lat, Lng), type);
                marker.ToolTipText = tooltip;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                OverlayCustom.Markers.Add(marker);
            }
            else
            {
                marker.ToolTipText = tooltip;
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.Position = new PointLatLng(Lat, Lng);
            }
            if (IsPosition)
                this.Position = marker.Position;
            MarkerCustomer = marker;

        }
        public void AddMarkerBlueCircle(double Lng,double Lat, string tooltip, bool hasFocusPosition)
        {            
            OverlayCustom = this.Overlays[1];
            OverlayCustom.Markers.Clear();
            GMapMarkerBlueCircle marker = new GMapMarkerBlueCircle(new PointLatLng(Lat, Lng));
            marker.ToolTipText = tooltip;
            marker.ToolTipMode = MarkerTooltipMode.Always;
            if (marker.ToolTip != null)
                marker.ToolTip.Stroke.Color = Color.Yellow;

            OverlayCustom.Markers.Add(marker);
            if (hasFocusPosition)
                this.Position = new PointLatLng(Lat, Lng);
        }

        public void AddMarkerRedCircle(double Lat, double Lng, string tooltip)
        {
            OverlayBackground = this.Overlays[0];
            GMapMarkerRedCircle marker = new GMapMarkerRedCircle(new PointLatLng(Lat, Lng));
            marker.ToolTipText = tooltip;
            if (marker.ToolTip != null)
            {
                marker.ToolTip.Stroke.Color = Color.Red;
                marker.ToolTip.Stroke.Width = 2;
            }
            marker.IsVisible = true;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            OverlayBackground.Markers.Add(marker);
        }

        public void AddMarkerRedCircle_WithTag(double Lat, double Lng, string tooltip, object tag)
        {
            OverlayBackground = this.Overlays[0];
            GMapMarkerRedCircle marker = new GMapMarkerRedCircle(new PointLatLng(Lat, Lng));
            marker.ToolTipText = tooltip;
            if (marker.ToolTip != null)
            {
                marker.ToolTip.Stroke.Color = Color.Red;
                marker.ToolTip.Stroke.Width = 2;
            }
            marker.Tag = tag;
            marker.IsVisible = true;
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            OverlayBackground.Markers.Add(marker);
        }

        public GMapMarkerRedCircle AddMarkerRed(PointLatLng point)
        {
            OverlayCustom = new GMapOverlay("custom");
            this.Overlays.Add(OverlayCustom);
            GMapMarkerRedCircle marker = new GMapMarkerRedCircle(point);
            OverlayCustom.Markers.Add(marker);
            return marker;
        }
        public GMapMarker AddMarkerEnum(double lat, double lng, EnumMarkerCustom enumMarker)
        {
            return AddMarkerEnum(new PointLatLng(lat, lng), enumMarker);
        }
        public GMapMarker AddMarkerEnum(PointLatLng point,EnumMarkerCustom enumMarker)
        {
            OverlayCustom = this.Overlays[1];
            var marker = new GMapMarkerCustomEnum(point, enumMarker);
            OverlayCustom.Markers.Add(marker);
            return marker;
        }
        /// <summary>
        /// add marker có biểu tượng icon A
        /// </summary>
        /// <param name="point">PointLatLng</param>
        /// <param name="toolTip"></param>
        /// <param name="hasClearAllMarker">xóa tất cả marker</param>
        /// <param name="hasRemoveMarker">xóa marker A cũ</param>
        /// <param name="overlay">thứ tự overlay</param>
        /// <returns></returns>
        public GMapMarker AddMarkerA(PointLatLng point, string toolTip = "", bool hasClearAllMarker = true, bool hasRemoveMarker = false, int overlay = 0, bool hasGotoPosition = false)
        {
            OverlayCustom = this.Overlays[overlay];
            if (hasClearAllMarker && OverlayCustom != null && OverlayCustom.Markers.Count > 0)
            {
                if (hasClearAllMarker )
                {
                    OverlayCustom.Markers.Clear();                    
                }
                else if (hasRemoveMarker)
                {
                    OverlayCustom.Markers.Remove(MarkerA);
                }
            }

            MarkerA = new GMapMarkerA(point);
            MarkerA.ToolTipText = toolTip;
            MarkerA.ToolTipMode = MarkerTooltipMode.Always;
            MarkerA.ToolTip.Stroke.Color = Color.Blue;
            OverlayCustom.Markers.Add(MarkerA);
            if (hasGotoPosition)
                Position = MarkerA.Position;
            return MarkerA;
        }

        /// <summary>
        /// add marker có biểu tượng icon A
        /// </summary>
        /// <param name="point">PointLatLng</param>
        /// <param name="toolTip"></param>
        /// <param name="hasClearAllMarker">xóa tất cả marker</param>
        /// <param name="hasRemoveMarker">xóa marker A cũ</param>
        /// <param name="overlay">thứ tự overlay</param>
        /// <returns></returns>
        public GMapMarker AddMarkerB(PointLatLng point, string toolTip = "", bool hasClearAllMarker = true, bool hasRemoveMarker = false, int overlay = 0, bool hasGotoPosition = false)
        {
            OverlayCustom = this.Overlays[overlay];
            if (hasClearAllMarker && OverlayCustom != null && OverlayCustom.Markers.Count > 0)
            {
                if (hasClearAllMarker)
                {
                    OverlayCustom.Markers.Clear();
                }
                else if (hasRemoveMarker)
                {
                    OverlayCustom.Markers.Remove(MarkerB);
                }
            }

            MarkerB = new GMapMarkerB(point);
            MarkerB.ToolTipText = toolTip;
            MarkerB.ToolTipMode = MarkerTooltipMode.Always;
            MarkerB.ToolTip.Stroke.Color = Color.Red;
            OverlayCustom.Markers.Add(MarkerB);
            if (hasGotoPosition)
                Position = MarkerB.Position;
            return MarkerB;
        }
        public GMapMarker addMarkerXeNhan1(int trangThai, double Lng, double Lat, string tooltip)
        {
            OverlayXeDeCu = this.Overlays[1];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeNhan = new GMapMarkerVehice2(new PointLatLng(Lat, Lng), trangThai);
            MarkerXeNhan.ToolTipText = tooltip;
            MarkerXeNhan.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeNhan.ToolTip.Stroke.Color = Color.Blue;
            OverlayXeDeCu.Markers.Add(MarkerXeNhan);
            return MarkerXeNhan;
        }
        public void addMarkerXeNhan(int trangThai, double Lng, double Lat, string tooltip)
        {
            OverlayXeDeCu = this.Overlays[1];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeNhan = new GMapMarkerVehice2(new PointLatLng(Lat, Lng), trangThai);
            MarkerXeNhan.ToolTipText = tooltip;
            MarkerXeNhan.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeNhan.ToolTip.Stroke.Color = Color.Blue;
            OverlayXeDeCu.Markers.Add(MarkerXeNhan);
        }

        public void addMarkerXeNhan2(int trangThai, double Lng, double Lat, string tooltip)
        {
            OverlayCustom = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeNhan = new GMapMarkerVehice2(new PointLatLng(Lat, Lng), trangThai);
            MarkerXeNhan.ToolTipText = tooltip;
            MarkerXeNhan.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeNhan.ToolTip.Stroke.Color = Color.Blue;
            OverlayCustom.Markers.Add(MarkerXeNhan);
        }

        /// <summary>
        /// marker danh sach xe de cu theo trang thai
        /// </summary>
        /// <param name="trangThai"></param>
        /// <param name="point"></param>
        /// <param name="tooltip"></param>
        public void addMarkerXeDeCu(int trangThai, double Lng, double Lat, string tooltip)
        {
            OverlayXeDeCu = this.Overlays[1];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeDeCu = new GMapMarkerVehice(new PointLatLng(Lat, Lng), trangThai);
            MarkerXeDeCu.ToolTipText = tooltip;
            MarkerXeDeCu.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeDeCu.ToolTip.Stroke.Color = Color.Red;
            OverlayXeDeCu.Markers.Add(MarkerXeDeCu);
        }

        /// <summary>
        /// marker danh sach xe de cu theo trang thai
        /// </summary>
        /// <param name="trangThai"></param>
        /// <param name="Lng"></param>
        /// <param name="Lat"></param>
        /// <param name="tooltip"></param>
        public void addMarkerXeDeCu2(int trangThai, PointLatLng point, string tooltip)
        {
            OverlayXeDeCu = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeDeCu = new GMapMarkerVehice(point, trangThai);
            MarkerXeDeCu.ToolTipText = tooltip;
            MarkerXeDeCu.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeDeCu.ToolTip.Stroke.Color = Color.Red;
            MarkerXeDeCu.ToolTip.Stroke.Width = 1;
            OverlayXeDeCu.Markers.Add(MarkerXeDeCu);
        }

        /// <summary>
        /// marker danh sach xe de cu theo trang thai
        /// </summary>
        /// <param name="trangThai"></param>
        /// <param name="Lng"></param>
        /// <param name="Lat"></param>
        /// <param name="tooltip"></param>
        public void addMarkerXeDeCu3(int trangThai,double Lng, double Lat, string tooltip)
        {
            OverlayXeDeCu = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc            
            MarkerXeDeCu = new GMapMarkerVehice(new PointLatLng(Lat, Lng), trangThai);
            MarkerXeDeCu.ToolTipText = tooltip;
            MarkerXeDeCu.ToolTipMode = MarkerTooltipMode.Always;
            MarkerXeDeCu.ToolTip.Stroke.Color = Color.Red;
            MarkerXeDeCu.ToolTip.Stroke.Width = 1;
            OverlayXeDeCu.Markers.Add(MarkerXeDeCu);
        }
        public void AddMarkerXeG5(int trangThai, double Lng, double Lat, string tooltip)
        {
            if (MarkerXeG5 != null)
            {
                OverlayXeG5.Markers.Remove(MarkerXeG5);
            }
           
                OverlayXeG5 = this.Overlays[0];
                // tạo marker tại vị trí vừa tìm đc            
                MarkerXeG5 = new GMapMarkerVehice(new PointLatLng(Lat, Lng), trangThai,true);
                MarkerXeG5.ToolTipText = tooltip;
                MarkerXeG5.ToolTipMode = MarkerTooltipMode.Always;
                MarkerXeG5.ToolTip.Stroke.Color = Color.Red;
                MarkerXeG5.ToolTip.Stroke.Width = 1;
                OverlayXeG5.Markers.Add(MarkerXeG5);
   
        }

        /// <summary>
        /// Marker hinh nguoi
        /// </summary>
        /// <param name="position"></param>
        public void addMarkerCustomer(PointLatLng point, string tooltip)
        {
            OverlayCustom = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc
            OverlayCustom.Markers.Clear();
            MarkerCustomer = new GMapMarkerCustomer(point);
            MarkerCustomer.ToolTipText = tooltip;
            MarkerCustomer.ToolTipMode = MarkerTooltipMode.Always;
            if (MarkerCustomer.ToolTip != null)
                MarkerCustomer.ToolTip.Stroke.Color = Color.Yellow;
            OverlayCustom.Markers.Add(MarkerCustomer);
            Position = point;
        }

        public void addMarkerMG(PointLatLng point, string tooltip)
        {
            OverlayCustom = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc
            OverlayCustom.Markers.Clear();
            MarkerCustomer = new GMapMarkerMG(point);
            MarkerCustomer.ToolTipText = tooltip;
            MarkerCustomer.ToolTipMode = MarkerTooltipMode.Always;
            if (MarkerCustomer.ToolTip != null)
                MarkerCustomer.ToolTip.Stroke.Color = Color.Yellow;
            OverlayCustom.Markers.Add(MarkerCustomer);
            Position = point;
        }

        /// <summary>
        /// marker hinh nguoi
        /// </summary>
        public void addMarkerCustomer2(double Lng, double Lat, string tooltip)
        {
            try
            {
                OverlayCustom = this.Overlays[0];
                var oldToolTip = tooltip;
                OverlayCustom.Markers.Clear();
                MarkerCustomer = new GMapMarkerCustomer(new PointLatLng(Lat, Lng));
                MarkerCustomer.ToolTipText = oldToolTip;
                MarkerCustomer.ToolTipMode = MarkerTooltipMode.Always;
                MarkerCustomer.ToolTip.Stroke.Color = Color.Yellow;
                OverlayCustom.Markers.Add(MarkerCustomer);

                Position = new PointLatLng(Lat, Lng);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("addMarkerCustomer2: ", ex);
            }
        }
        /// <summary>
        /// marker hinh nguoi khong clear marker
        /// </summary>
        public void addMarkerCustomer3(double Lng, double Lat, string tooltip)
        {
            OverlayCustom = this.Overlays[0];
            // tạo marker tại vị trí vừa tìm đc
            MarkerCustomer = new GMapMarkerCustomer(new PointLatLng(Lat, Lng));
            MarkerCustomer.ToolTipText = tooltip;
            MarkerCustomer.ToolTipMode = MarkerTooltipMode.Always;
            MarkerCustomer.ToolTip.Stroke.Color = Color.Yellow;
            OverlayCustom.Markers.Add(MarkerCustomer);
            Position = new PointLatLng(Lat, Lng);
        }


        /// <summary>
        /// marker hình lá cờ
        /// </summary>
        public void addMarkerCustomer4(double Lng, double Lat, string tooltip, bool isClearMarker)
        {
            try
            {
                OverlayCustom = this.Overlays[0];
                // tạo marker tại vị trí vừa tìm đc
                if (isClearMarker)
                    OverlayCustom.Markers.Clear();
                MarkerCustomer = new GMapMarkerCustomer(new PointLatLng(Lat, Lng), Taxi.Controls.Properties.Resources._32_Map_Marker_Flag__Right_Azure);
                MarkerCustomer.ToolTipText = tooltip;
                MarkerCustomer.ToolTipMode = MarkerTooltipMode.Always;
                MarkerCustomer.ToolTip.Stroke.Color = Color.Yellow;
                OverlayCustom.Markers.Add(MarkerCustomer);

                Position = new PointLatLng(Lat, Lng);
            }
            catch (Exception ex) { }
           
        }
        #endregion

        #region Map event methods
        private void ExtendedGMapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;

                if (this.PolygonsEnabled && _allowDrawPolygon)
                {
                    #region OnDrop vertice
                    if (selectedVertice != null)
                    {

                        //until the poligon is complete, make auxiliary lines joining the vertices
                        if (!polygonIsComplete && OverlayPolygon_Vertices.Markers.Count > 1)
                        {
                            int verticeIndex = OverlayPolygon_Vertices.Markers.IndexOf(selectedVertice);
                            Pen pen = new Pen(Brushes.DarkGray, 3);
                            GMapMarkerLine auxLine = new GMapMarkerLine(selectedVertice.Position, OverlayPolygon_Vertices.Markers[verticeIndex - 1].Position, pen);
                            OverlayPolygon_Auxiliary.Markers.Add(auxLine);
                        }


                        if (isDraggingVertice)
                        {
                            isDraggingVertice = false;

                            if (polygonIsComplete)
                            {
                                _polygon.Points.Clear();
                                _polygon.Points.AddRange(OverlayPolygon_Vertices.Markers.Select(m => m.Position));
                                this.UpdatePolygonLocalPosition(_polygon);

                                //rearrangement intermediate points
                                int selectedIndex = OverlayPolygon_Vertices.Markers.IndexOf(selectedVertice);
                                //previous point
                                if (selectedIndex == 0)
                                {
                                    GMapMarker intermediatePoint = OverlayPolygon_Auxiliary.Markers.Last();
                                    intermediatePoint.Position = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[OverlayPolygon_Vertices.Markers.Count - 2], OverlayPolygon_Vertices.Markers[selectedIndex]);
                                }
                                else
                                    OverlayPolygon_Auxiliary.Markers[selectedIndex - 1].Position = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[selectedIndex - 1], OverlayPolygon_Vertices.Markers[selectedIndex]);
                                //next point
                                OverlayPolygon_Auxiliary.Markers[selectedIndex].Position = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[selectedIndex], OverlayPolygon_Vertices.Markers[selectedIndex + 1]);
                            }
                        }

                        selectedVertice = null;
                    }
                    #endregion
                    #region OnDrop intermediate point
                    //if dragging intermediate point dragging is finish
                    if (selectedIntermediatePoint != null)
                    {
                        if (isDraggingIntermediatePoint)
                        {
                            isDraggingIntermediatePoint = false;
                            //make a new vertice
                            GMapMarkerRedCircle newVertice = new GMapMarkerRedCircle(selectedIntermediatePoint.Position);
                            //remove the old intermediate point
                            int selectedIndex = OverlayPolygon_Auxiliary.Markers.IndexOf(selectedIntermediatePoint);
                            OverlayPolygon_Auxiliary.Markers.Remove(selectedIntermediatePoint);

                            //add the new vertice, in the correct position of the vertices collection
                            int newVerticeIndex = selectedIndex + 1;

                            OverlayPolygon_Vertices.Markers.Insert(newVerticeIndex, newVertice);

                            //update polygon
                            _polygon.Points.Clear();
                            _polygon.Points.AddRange(OverlayPolygon_Vertices.Markers.Select(m => m.Position));
                            this.UpdatePolygonLocalPosition(_polygon);

                            //make and add new intermediate points
                            PointLatLng intermediatePosition1 = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[newVerticeIndex - 1], OverlayPolygon_Vertices.Markers[newVerticeIndex]);
                            GMapMarkerGraySquare intermediatePoint1 = new GMapMarkerGraySquare(intermediatePosition1);

                            PointLatLng intermediatePosition2 = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[newVerticeIndex], OverlayPolygon_Vertices.Markers[newVerticeIndex + 1]);
                            GMapMarkerGraySquare intermediatePoint2 = new GMapMarkerGraySquare(intermediatePosition2);

                            OverlayPolygon_Auxiliary.Markers.Insert(selectedIndex, intermediatePoint1);
                            OverlayPolygon_Auxiliary.Markers.Insert(selectedIndex + 1, intermediatePoint2);

                        }

                        selectedIntermediatePoint = null;
                    }
                    #endregion
                }
            }
        }

        private void ExtendedGMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (OverlayPolygon_Vertices == null)
                {
                    OverlayPolygon_Vertices = new GMapOverlay("vertices");
                    this.Overlays.Add(OverlayPolygon_Vertices);
                }
                isMouseDown = true;

                if (this.PolygonsEnabled && _allowDrawPolygon)
                {
                    //if the polygon is incomplete, click will be create new vertices
                    if (!polygonIsComplete)
                        if (selectedVertice == null)
                        {
                            GMapMarkerRedCircle marker = new GMapMarkerRedCircle(this.FromLocalToLatLng(e.X, e.Y));
                            OverlayPolygon_Vertices.Markers.Add(marker);
                            this.selectedVertice = marker;
                        }
                }
                else
                {
                    //if (OverlayCustom != null && OverlayCustom.Markers.Count < 1)
                    //{
                    //    OverlayCustom.Markers.Clear();
                    //    GMapMarkerRedCircle marker = new GMapMarkerRedCircle(this.FromLocalToLatLng(e.X, e.Y));
                    //    OverlayCustom.Markers.Add(marker);
                    //}
                }
            }
        }

        private void ExtendedGMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs args)
        {
            if (this.PolygonsEnabled && _allowDrawPolygon)
            {
                #region close polygon
                //only can create the polygon if the polygon is incomplete
                if (!polygonIsComplete && this.selectedVertice != null)
                {
                    //the polygon only be closed if the click is on the first vertice, and is not the first time
                    if (OverlayPolygon_Vertices.Markers.First() == this.selectedVertice && OverlayPolygon_Vertices.Markers.Count > 1)
                    {
                        this.OverlayPolygon_Vertices.Markers.Add(this.selectedVertice);

                        //add the vertices to polygon (make polygon)
                        _polygon.Points.AddRange(OverlayPolygon_Vertices.Markers.Select(m => m.Position));
                        this.UpdatePolygonLocalPosition(_polygon);

                        polygonIsComplete = true;
                        OverlayPolygon_Auxiliary.Markers.Clear();
                        //add new intermediate points between the vertices
                        for (int i = 0; i < OverlayPolygon_Vertices.Markers.Count; i++)
                        {
                            if (i != OverlayPolygon_Vertices.Markers.Count - 1)
                            {
                                PointLatLng middle = CalculateMiddlePoint(OverlayPolygon_Vertices.Markers[i], OverlayPolygon_Vertices.Markers[i + 1]);
                                GMapMarkerGraySquare intermediatePoint = new GMapMarkerGraySquare(middle);
                                OverlayPolygon_Auxiliary.Markers.Add(intermediatePoint);
                            }
                        }
                    }
                }
                #endregion
            }
        }

        private void ExtendedGMapControl_OnMarkerEnter(GMapMarker item)
        {
            if (this.PolygonsEnabled && _allowDrawPolygon)
            {
                //select the marker that was clicked
                if (OverlayPolygon_Vertices.Markers.Contains(item))
                    this.selectedVertice = item;

                if (OverlayPolygon_Auxiliary.Markers.Contains(item))
                    this.selectedIntermediatePoint = item;
            }
        }

        private void ExtendedGMapControl_OnMarkerLeave(GMapMarker item)
        {
            //if the marker is being dragged, then is not deselected
            if (!isDraggingVertice)
                selectedVertice = null;

            if (!isDraggingIntermediatePoint)
                selectedIntermediatePoint = null;
        }

        private void ExtendedGMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                if (this.PolygonsEnabled && _allowDrawPolygon)
                {
                    //if there is a selected vertice
                    if (this.selectedVertice != null)
                    {
                        //drag the selected vertice
                        this.selectedVertice.Position = this.FromLocalToLatLng(e.X, e.Y);
                        isDraggingVertice = true;
                    }
                    else
                    {
                        //else, if there is a selected intermediate point, be dragg
                        if (this.selectedIntermediatePoint != null)
                        {
                            this.selectedIntermediatePoint.Position = this.FromLocalToLatLng(e.X, e.Y);
                            isDraggingIntermediatePoint = true;
                        }
                    }
                }
            }
        }

        private void ExtendedGMapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.PolygonsEnabled)
            //{
            //    PointLatLng point = this.FromLocalToLatLng(e.X, e.Y);
            //    foreach (GMapPolygon polygon in this.Overlays[0].Polygons)
            //    {
            //        if (Functions.PointInPolygon(point, polygon.Points.ToArray()))
            //        {
            //            if (polygon.Name != null)
            //            {
            //                ToolTip tip = new ToolTip();
            //                tip.SetToolTip(this, polygon.Name.ToString());
            //                tip.Show("",this.FindForm(),5000);
            //            }
            //        }
            //    }
            //}
        }

        #endregion

        #region functions

        private PointLatLng CalculateMiddlePoint(params GMapMarker[] marks)
        {
            return CalculateMiddlePoint(marks.ToList());
        }

        private PointLatLng CalculateMiddlePoint(List<GMapMarker> marks)
        {
            List<PointLatLng> points = marks.Select(m => m.Position).ToList();

            PointLatLng point = Functions.CalculateMiddlePoint(points.ToList());

            return point;
        }

        private PointLatLng CalculateMiddlePoint(List<PointLatLng> marks)
        {
            PointLatLng point = Functions.CalculateMiddlePoint(marks);

            return point;
        }

        //public static bool IsInPolygon(List<DMVung_GPSEntity> poly, Point point)
        //{
        //    var coef = poly.Skip(1).Select((p, i) =>
        //                                    (point.Y - poly[i].Y) * (p.X - poly[i].X)
        //                                  - (point.X - poly[i].X) * (p.Y - poly[i].Y))
        //                            .ToList();

        //    if (coef.Any(p => p == 0))
        //        return true;

        //    for (int i = 1; i < coef.Count(); i++)
        //    {
        //        if (coef[i] * coef[i - 1] < 0)
        //            return false;
        //    }
        //    return true;
        //}
        #endregion

        private void ExtendedGMapControl_Load(object sender, EventArgs e)
        {
            //TODO: probar
            //if (_polygon == null)
            //{
            //    SetDrawingPolygon(new GMapPolygon(new List<PointLatLng>(), ""));
            //}
        }

        #region GetGoogle
        /// <summary>
        /// Get tọa độ by google API
        /// </summary>
        /// <param name="Address"></param>
        /// <returns>lat lng</returns>
        public  string GetGeoByAddress_Google(string Address)
        {
            var url = string.Format("http://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false", Address);
            //Thêm try catch
            try
            {
                var request = WebRequest.Create(url);
                using (WebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        var dsResult = new DataSet();
                        dsResult.ReadXml(reader);
                        if (dsResult.Tables.Count > 0)
                        {
                            var row = dsResult.Tables["result"].Rows[0];
                            var geometryId =dsResult.Tables["geometry"].Select("result_id = " + row["result_id"])[0]["geometry_id"].ToString();

                            var location = dsResult.Tables["location"].Select("geometry_id = " + geometryId)[0];
                            return string.Format("{0} {1}", location["lat"], location["lng"]);
                        }
                        return "*";
                    }
                }
            }
            catch
            {
                return "*";
            }

        }
        #endregion
        public void AddRoute(MapRoute route, Color c)
        {
            if (route == null) return;
            AddRoute(route.Points, c);         
        }
        public void AddRoute(List<PointLatLng> Points, Color c)
        {
            for (int i = 0; i < 2 - this.Overlays.Count; )
            {
                this.Overlays.Add(new GMapOverlay());
            }
            OverlayCustom = this.Overlays[1];
            var r = new GMapRoute(Points, "My route");
            r.Stroke.Color = c;
            r.IsHitTestVisible = true;
            OverlayCustom.Routes.Add(r);
            ZoomAndCenterRoute(r);
        }
        public void ClearRoute()
        {
            if (this.Overlays != null && this.Overlays.Count > 1 && this.Overlays[1] != null)
            {
                OverlayCustom = this.Overlays[1];
                OverlayCustom.Routes.Clear();                
            }

        }
    }
}
