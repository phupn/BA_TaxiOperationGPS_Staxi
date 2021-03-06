using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using System.Linq;
using Taxi.Entity;
using Taxi.Business.DM;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business;


namespace Taxi.GUI
{
    public partial class QuanLyVung_GPS : Form
    {
        #region Fields
        private bool isAddNewForm = true;
        private bool isSelectedRow = false;
        private string G_ArrPoint_VungKenh = "";
        private int G_IdVungGPS = 0;
        private DMVung_GPSEntity gDMVung_GPSEntity = new DMVung_GPSEntity();
        
        private string[] G_ArrPoint_Background;
        private List<GMapPolygon> _otherPolygons;
        private List<GMapMarker> _otherMarkers;
        private CustomPolygon currentPolygon;
        #endregion

        #region Public properties

        /// <summary>
        /// Get set the main polygon
        /// </summary>
        public CustomPolygon MainPolygon
        {
            get
            {
                return currentPolygon;
            }
            set
            {
                currentPolygon = value;
            }
        }

        public List<GMapPolygon> OtherPolygons
        {
            get
            {
                List<GMapPolygon> rv = top.Polygons.ToList();
                rv.Remove(currentPolygon);
                return rv;
            }
            set
            {
                _otherPolygons = value;
            }
        }
        #endregion

        public QuanLyVung_GPS()
        {
            InitializeComponent();
        }

        private void QuanLyVung_GPS_Load(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            isAddNewForm = true;
            ConfigMap();
            SetObjectToEdit();
            FillDataToGrid();            
        }

        private void SetAddnewFormStatus()
        {
            txtTenVung.Focus();
            btnXoa.Enabled = false;
            isAddNewForm = true;
            txtTenVung.Text = "";
            numKenhGop.Value = 1;
            numKenhVung.Value = 1;
            numBKTimXe.Value = 0;
            G_ArrPoint_VungKenh = "";
            MainMap.ClearDrawingPolygon();
        }

        /// <summary>
        /// Fill Data to GridEX
        /// </summary>
        private void FillDataToGrid()
        {
            isSelectedRow = false;
            List<DMVung_GPSEntity> lstDMVung_GPS = new DMVung_GPS().GetAllDSVungKenh();
            gridVungGPS.DataMember = "DSVung_GPS";
            gridVungGPS.SetDataBinding(lstDMVung_GPS, "DSVung_GPS");

            //lay danh sach tat ca polygon dang co
            int count = lstDMVung_GPS.Count;
            if (count > 0)
            {
                string toDoVung = "";
                string[] arrPolygonName = new string[count];
                G_ArrPoint_Background = new string[count];
                for (int i = 0; i < count; i++)
                {                
                    toDoVung = lstDMVung_GPS[i].ToaDoVung;

                    if (string.IsNullOrEmpty(toDoVung))
                        toDoVung = "";

                    G_ArrPoint_Background[i] = toDoVung;
                    arrPolygonName[i] = lstDMVung_GPS[i].TenVungGPS;
                }
                isSelectedRow = true;

                FillPolygonsToBackgroundMap(arrPolygonName);
            }
        }

        private DMVung_GPSEntity GetDMVung_Entity()
        {
            return new DMVung_GPSEntity(G_IdVungGPS, txtTenVung.Text.Trim(), (int)numKenhVung.Value, (int)numKenhGop.Value, G_ArrPoint_VungKenh,(int)numBKTimXe.Value);
        }

        /// <summary>
        /// đỗ dữ liệu lên form
        /// </summary>
        private void FillDataToForm()
        {
            string toaDoVung = gDMVung_GPSEntity.ToaDoVung;
            txtTenVung.Text = gDMVung_GPSEntity.TenVungGPS;
            numKenhGop.Value = gDMVung_GPSEntity.KenhGop;
            numKenhVung.Value = gDMVung_GPSEntity.KenhVung;
            numBKTimXe.Value = gDMVung_GPSEntity.BanKinhTimXe;
            G_IdVungGPS = gDMVung_GPSEntity.ID;
            G_ArrPoint_VungKenh = toaDoVung;
            isAddNewForm = false;
            btnXoa.Enabled = true;
            top.Polygons.Clear();
            CustomPolygon currPolygon = GetCustomPolygon(toaDoVung);
            MainMap.SetDrawingPolygonCustom(currPolygon);
            MainMap.Position = currPolygon.Points[0];
        }

        /// <summary>
        /// ve tat ca cac polygon len map
        /// </summary>
        private void FillPolygonsToBackgroundMap(string[] polygonName)
        {
            List<GMapPolygon> polygons = new List<GMapPolygon>();
            GMapPolygon polygon;
            int i = 0;
            foreach (string Point_Background in G_ArrPoint_Background)
            {
                if (Point_Background != "")
                {
                    polygon = GetPolygon(Point_Background, polygonName[i]);
                    polygons.Add(polygon);
                }
                i++;
            }
            MainMap.SetBackGroundPolygon(polygons);
        }

        /// <summary>
        /// tra ve chuoi ToaDoVung de add vao db
        /// </summary>
        /// <returns></returns>
        private string getPolygonsString()
        {
            string strResult = "";
            if (top.Polygons.Count > 0)
            {
                List<PointLatLng> lstPointPolygons = top.Polygons[0].Points;
                // polygon phai co it nhat 3 diem
                if (lstPointPolygons.Count < 3) return "1";
                //diem dau va diem cuoi cua polygon phai giong nhau
                if (lstPointPolygons[0] != lstPointPolygons[lstPointPolygons.Count - 1]) return "2";

                foreach (PointLatLng PointPolygons in lstPointPolygons)
                {
                    strResult = string.Format("{0}{1};{2}-", strResult, PointPolygons.Lat, PointPolygons.Lng);
                }
                if (strResult.Length < 2) return "";

                strResult = strResult.Substring(0, strResult.Length - 1);
            }
            return strResult;
        }

        /// <summary>
        /// tra ve Polygon tu chuoi ToaDoVung(danh sach cac Points)
        /// </summary>
        /// <param name="strPolygons">ToaDoVung</param>
        /// <returns></returns>
        private GMapPolygon GetPolygon(string strPolygons, string polygonName)
        {
            List<PointLatLng> lstPointPolygons = new List<PointLatLng>();
            string[] arrPolygons = strPolygons.Split('-');
            string[] arrPoints;
            double lat = 0, lng = 0;
            if (arrPolygons.Length>=3)
            {
                foreach (string points in arrPolygons)
                {
                    arrPoints = points.Split(';');
                    lat = Convert.ToDouble(arrPoints[0]);
                    lng = Convert.ToDouble(arrPoints[1]);
                    lstPointPolygons.Add(new PointLatLng(lat, lng));
                }
            }
            return new GMapPolygon(lstPointPolygons, polygonName);
        }

        /// <summary>
        /// tra ve Polygon tu chuoi ToaDoVung(danh sach cac Points)
        /// </summary>
        /// <param name="strPolygons">ToaDoVung</param>
        /// <returns></returns>
        private CustomPolygon GetCustomPolygon(string strPolygons)
        {
            List<PointLatLng> lstPointPolygons = new List<PointLatLng>();
            string[] arrPolygons = strPolygons.Split('-');
            string[] arrPoints;
            double lat = 0, lng = 0;
            if (arrPolygons.Length >= 3)
            {
                foreach (string points in arrPolygons)
                {
                    arrPoints = points.Split(';');
                    lat = Convert.ToDouble(arrPoints[0]);
                    lng = Convert.ToDouble(arrPoints[1]);
                    lstPointPolygons.Add(new PointLatLng(lat, lng));
                }
            }
            return new CustomPolygon(lstPointPolygons, "CurrentPolygon");
        }

        private bool ValidForm()
        {
            if (txtTenVung.Text.Trim().Equals(""))
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập tên vùng.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }
            else if (numKenhVung.Value <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Vui lòng nhập kênh vùng.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }
            else if (!CheckVungNamTrongVungCauHinh((int)numKenhVung.Value))
            {
                new MessageBox.MessageBoxBA().Show("Vùng không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return false;
            }

            return true;
        }

        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        }

        #region Map Control
        private GMapProvider _mapType;        
        private MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;
        #region Internal variables
               
        // markers
        GMapMarker centerMarker;
        GMapMarker currentMarker;

        // layers
        GMapOverlay top;
        GMapOverlay top2;

        bool isMouseDown;
        #endregion        

        #region Public properties
        
        public MapModeEnum MapMode
        {
            get { return _mapMode; }
            set { _mapMode = value; }
        }

        #endregion

        void SetObjectToEdit()
        {

            if (_mapMode == MapModeEnum.EditPoint)
            {
                //if (currentMarker == null)
                //    currentMarker = new GMapMarkerGoogleRed(new PointLatLng());

                if (currentMarker != null)
                    top.Markers.Add(currentMarker);
            }

            if (_mapMode == MapModeEnum.EditArea)
            {
                if (currentPolygon == null)
                    currentPolygon = new CustomPolygon(new List<PointLatLng>(), "MyPolygon");

                MainMap.SetDrawingPolygon(currentPolygon);
            }
        }

        private void ConfigMap()
        {
            // config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 12;

            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            MainMap.PolygonsEnabled = true;
            MainMap.AllowDrawPolygon = true;
            MapMode = MapModeEnum.EditArea;
            // map events
            MainMap.OnPositionChanged += MainMap_OnCurrentPositionChanged;
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            if (_mapMode == MapModeEnum.EditPoint)
            {
                MainMap.MouseMove +=MainMap_MouseMove;
                MainMap.MouseDown +=MainMap_MouseDown;
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

                top2 = new GMapOverlay("top2");
                MainMap.Overlays.Add(top2);
            }
            centerMarker = new GMarkerCross(new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo));

            CbMapType.ValueMember = "Name";
            CbMapType.DataSource = GMapProviders.List;
            CbMapType.SelectedItem = GMapProviders.GoogleMap;
        }

        #region Map event methods

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);
        }

        // current point changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            centerMarker.Position = point;
        }

        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = false;
            }
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = true;
                currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
            }
            
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
                //map.Position = map.FromLocalToLatLng(e.X, e.Y);
            }
        }

        #endregion

        #region Controls events methods
        private void CbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainMap.MapProvider = CbMapType.SelectedItem as GMapProvider;
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }
        #endregion

        
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            SetAddnewFormStatus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (isAddNewForm)
                return;

            if (new DMVung_GPS().Delete(G_IdVungGPS))
            {
                lblMsg.Text = "Xóa thành công!";
                lblMsg.ForeColor = Color.DodgerBlue;
                lblMsg.Visible = true;
                SetAddnewFormStatus();
            }
            else
            {
                lblMsg.Text = "Xóa thất bại, vui lòng thử lại!";
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
            }
            FillDataToGrid();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if (!ValidForm())
                return;
            G_ArrPoint_VungKenh = getPolygonsString();
            if (G_ArrPoint_VungKenh == "1")
            {
                lblMsg.Text = "Vùng GPS phải có ít nhất 3 điểm trên bản đồ!";
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
            }
            else if (G_ArrPoint_VungKenh == "1")
            {
                lblMsg.Text = "Bạn chưa vẽ xong vùng trên bản đồ!";
                lblMsg.ForeColor = Color.Red;
                lblMsg.Visible = true;
            }
            else
            {
                //Addnew
                if (isAddNewForm)
                {
                    if (new DMVung_GPS().Insert(GetDMVung_Entity()))
                    {
                        lblMsg.Text = "Thêm mới thành công!";
                        lblMsg.ForeColor = Color.DodgerBlue;
                        lblMsg.Visible = true;
                        SetAddnewFormStatus();
                        FillDataToGrid();
                    }
                    else
                    {
                        lblMsg.Text = "Thêm mới thất bại, vui lòng thử lại!";
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Visible = true;
                    }

                }
                //Update
                else
                {
                    if (new DMVung_GPS().Update(GetDMVung_Entity()))
                    {
                        lblMsg.Text = "Cập nhật thành công!";
                        lblMsg.ForeColor = Color.DodgerBlue;
                        lblMsg.Visible = true;
                        FillDataToGrid();
                    }
                    else
                    {
                        lblMsg.Text = "Cập nhật thất bại, vui lòng thử lại!";
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Visible = true;
                    }
                }
            }
        }

        private void gridVungGPS_SelectionChanged(object sender, EventArgs e)
        {
            if (gridVungGPS.SelectedItems.Count <= 0 || isSelectedRow == false) return;

            //gDMVung_GPSEntity = (DMVung_GPSEntity)((GridEXSelectedItem)gridVungGPS.SelectedItems[0]).GetRow().DataRow;
            //FillDataToForm();
        }

        private void gridVungGPS_MouseClick(object sender, MouseEventArgs e)
        {
            if (gridVungGPS.SelectedItems.Count > 0)
            {                
                isSelectedRow = true;                
            }
        }

        private void gridVungGPS_Click(object sender, EventArgs e)
        {
            if (gridVungGPS.SelectedItems.Count > 0)
            {
                isSelectedRow = true;
                gDMVung_GPSEntity = (DMVung_GPSEntity)((GridEXSelectedItem)gridVungGPS.SelectedItems[0]).GetRow().DataRow;
                FillDataToForm();
            }
        }
    }
}