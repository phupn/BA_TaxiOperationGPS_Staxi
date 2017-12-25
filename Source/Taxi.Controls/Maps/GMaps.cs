using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Data.BanCo;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Taxi.Services;
using Taxi.Services.WCFServices;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using System.ComponentModel;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Controls.Maps
{
    public partial class GMaps : UserControl
    {
        #region-----------Khai bao bien---------

        GMapOverlay overlays;
        GMapOverlay polyOverlay;
        GMapOverlay ovlDiaChi;
        private T_XeOnline[] sThongTinXe = null;
        PointLatLng p;
        GMapMarker marker;
        GMapMarker marker1;
        TextBox txtAddress = new TextBox();
        TextBox txtTitleSearchDC = new TextBox();
        private int socho;
        private string SoHieuXe;
        public static int[] MDir = { 3, 2, 1, 8, 7, 6, 5, 4 };
        GiamSatXe_LienLac lienlac;
        T_XeOnline TXe;
        BackgroundWorker bwLoadMap = new BackgroundWorker();
        Timer timerbw = new Timer();
        int Timerbw_tick = 0;
        public bool isLoadSuccess = true;
        #endregion-------------End-----------------------------------------------------------------

        public GMaps()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            InitializeComponent();
            

            ini_map();
            lienlac = new GiamSatXe_LienLac();
            TXe = new T_XeOnline();
            timerVDH.Enabled = true;

            hienTrangXe1.Visible = false;
            hienTrangXe1.OnUserControlButtonClicked += new HienTrangXe.ButtonClickedEventHandler(hienTrangXe1_OnUserControlButtonClicked);

            Init_texbox();

            txtDiaChi.LostFocus += new EventHandler(txtDiaChi_LostFocus);
            txtTimXe.LostFocus += new EventHandler(txtTimXe_LostFocus);

            cboMapType.Items.Insert(0, "Chọn bản đồ");
            cboMapType.Items.Insert(1, "Bình Anh");
            cboMapType.Items.Insert(2, "Google");
            cboMapType.Items.Insert(3, "Vệ Tinh");
            cboMapType.SelectedIndex = 2;

            txtTinhThanh.Text = ThongTinCauHinh.GPS_TenTinh;
            InitTimerbw();
        }
        private void InitTimerbw()
        {
            bwLoadMap.DoWork += bwLoadMap_DoWork;

            timerbw = new Timer();
            timerbw.Interval = 1000;
            timerbw.Tick += new EventHandler(timerbw_Tick);
        }

        public void StartTimerLoadMap()
        {
            timerbw.Start();

        }
        #region ---------------------Load Data-----------------------
        private void timerbw_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                if (Global.HasGPS)
                {
                    Timerbw_tick++;
                    if (Timerbw_tick >= 5 && isLoadSuccess)
                    {
                        LoadXeOnline();
                        SetListXe();
                        Timerbw_tick = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Gmap timerbw_Tick", ex);
            }
        }

        public void LoadXeOnline()
        {
            #region Get Xe online
            isLoadSuccess = false;
            if (ThongTinCauHinh.GPS_TrangThai)
            {
                try
                {
                    if (Global.HasGPS)
                    {
                        T_XeOnline[] listXeOnline = WCFService_Common.GetListObjectXeOnline();
                        if (listXeOnline != null)
                        {
                            UpdateListXeOnline(listXeOnline);
                        }                        
                    }
                }
                catch (Exception ex)
                {
                    if (new MessageBox.MessageBoxBA().Show("Không thể kết nối đến dịch vụ đồng bộ xe GPS. Bạn có muốn thử lại không?", "Lỗi", MessageBox.MessageBoxButtonsBA.RetryCancel, MessageBox.MessageBoxIconBA.Error) != MessageBox.MessageBoxResult.Retry)
                    {
                        Global.HasGPS = false;
                        isLoadSuccess = true;
                        LogError.WriteLogError("LoadXeOnline: ", ex);
                    }
                }
            }
            #endregion
        }
        public void UpdateListXeOnline(T_XeOnline[] sThongTinXe)
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                if (!ThongTinCauHinh.GPS_TrangThai || !Global.HasGPS) return;

                for (int i = 0; i < sThongTinXe.Length; i++)
                {
                    VehicleOnline xe = new VehicleOnline();
                    xe.SoHieuXe = sThongTinXe[i].SoHieuXe;
                    xe.MaXN = sThongTinXe[i].MaCungXN;
                    xe.BienSoXe = sThongTinXe[i].BienSoXe;
                    xe.KinhDo = sThongTinXe[i].KinhDo;
                    xe.ViDo = sThongTinXe[i].ViDo;
                    xe.Huong = sThongTinXe[i].HuongDiChuyen;
                    xe.SoChoNgoi = sThongTinXe[i].SoCho;
                    xe.LoaiXeGPS = sThongTinXe[i].LoaiXeGPS;
                    xe.LoaiXe = sThongTinXe[i].LoaiXe;
                    xe.TGCapNhat = sThongTinXe[i].TGCapNhat;
                    xe.Gara = sThongTinXe[i].Gara;
                    xe.Trangthai = sThongTinXe[i].TrangThai;
                    xe.TGDungXeNoMay = sThongTinXe[i].TGDungXeNoMay;
                    xe.VCo = sThongTinXe[i].VCo;
                    xe.VGPS = sThongTinXe[i].VGPS;
                    xe.ThoidiemChenDL = sThongTinXe[i].ThoiDiemChenDuLieu;
                    xe.ThoiDiemDiChuyenGanNhat = sThongTinXe[i].TGDiChuyenGanNhat;
                    xe.TGGPS = sThongTinXe[i].TGGPS;
                    xe.TrangThaiKhac = sThongTinXe[i].TrangThaiKhac;
                    xe.TrangThaiKhacText = sThongTinXe[i].TrangThaiKhacText;
                    xe.VungID = sThongTinXe[i].VungID;
                    if (CommonData.G_Dict_Vehicle == null)
                    {
                        CommonData.G_Dict_Vehicle = new Dictionary<string, string>();
                    }
                    if (CommonData.G_Dict_Vehicle.ContainsKey(sThongTinXe[i].BienSoXe))
                        CommonData.G_Dict_Vehicle[sThongTinXe[i].BienSoXe] = sThongTinXe[i].SoHieuXe;
                    else
                        CommonData.G_Dict_Vehicle.Add(sThongTinXe[i].BienSoXe, sThongTinXe[i].SoHieuXe);

                    if (CommonData.G_Dict_VehicleOnline == null)
                    {
                        CommonData.G_Dict_VehicleOnline = new Dictionary<string, VehicleOnline>();
                    }
                    if (CommonData.G_Dict_VehicleOnline.ContainsKey(sThongTinXe[i].SoHieuXe))
                        CommonData.G_Dict_VehicleOnline[sThongTinXe[i].SoHieuXe] = xe;
                    else
                        CommonData.G_Dict_VehicleOnline.Add(sThongTinXe[i].SoHieuXe, xe);
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Không thể kết nối tới Service", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
            }
        }
        private void bwLoadMap_DoWork(object sender, DoWorkEventArgs e)
        {
            if (isLoadSuccess)
            {
                LoadXeOnline();
                //setListXe();                
            }
        }
        /// <summary>
        /// Set vị trí của Map theo vị trí cấu hình của công ty
        /// </summary>
        public void SetPositionConfig()
        {
            gmap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            txtTinhThanh.Text = ThongTinCauHinh.GPS_TenTinh;
            DataTable dt = getVungDH();

            ccbeVDH.Properties.DataSource = dt;
            ccbeVDH.Properties.DisplayMember = "NameVungDH";
            ccbeVDH.Properties.ValueMember = "Id";
        }

        private void ini_map()
        {
            //use google provider
            gmap.MapProvider = GoogleMapProvider.Instance;
            gmap.Manager.Mode = AccessMode.ServerAndCache;
            //gmap.CacheLocation = Application.ExecutablePath;

            gmap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            gmap.DisableFocusOnMouseEnter = true;
            //zoom min/max; default both = 2
            gmap.MinZoom = 2;
            gmap.MaxZoom = 22;
            gmap.ShowCenter = false;
            //set zoom
            gmap.Zoom = 14;
            //Overlay marker Xe online
            overlays = new GMapOverlay("XeOnline");
            gmap.Overlays.Add(overlays);


            //Overlay marker vung dieu hanh
            polyOverlay = new GMapOverlay("polygons");
            gmap.Overlays.Add(polyOverlay);

            //Overlay tim dia chi
            ovlDiaChi = new GMapOverlay("ovlDC");
            gmap.Overlays.Add(ovlDiaChi);

            grbSearch.BackColor = Color.FromArgb(240, 237, 229);
        }

        private void Load_Data()
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                isLoadSuccess = false;
                overlays.Markers.Clear();
                
                    if (CommonData.G_Dict_VehicleOnline == null)
                    {
                        CommonData.G_Dict_VehicleOnline = new Dictionary<string, VehicleOnline>();
                    }

                    foreach (var obj in CommonData.G_Dict_VehicleOnline)
                    {
                        VehicleOnline item = obj.Value;
                        if (item.SoChoNgoi <= 4)
                        {
                            socho = 4;
                        }
                        else
                        {
                            socho = 7;
                        }

                        //add marker to map
                        var marker = new GMapMarkerVehice(new PointLatLng(item.ViDo, item.KinhDo), MDir[item.Huong], socho, item.Trangthai, item.TrangThaiKhac);
                        marker.ToolTipText = item.SoHieuXe;
                        marker.ToolTip.Font = new Font("Arial", 9, FontStyle.Bold);
                        marker.ToolTip.Stroke = new Pen(Color.Empty, 0);
                        marker.ToolTip.TextPadding = new Size(5, 5);
                        marker.ToolTipMode = MarkerTooltipMode.Always;
                        marker.ToolTip.Offset = new Point(-15, -17);
                        try
                        {                            
                            overlays.Markers.Add(marker);
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("BanDo_Online Load_Data", ex);
                        }
                    }
                isLoadSuccess = true;

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("BanDo_Online Load_Data:", ex);
                isLoadSuccess = true;
            }
        }
        #endregion ---------------------End of load Data-----------------------
        
        #region ---------------------Load danh sach xe-----------------

        public bool SetListXe()
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return false;
                if (!ThongTinCauHinh.GPS_TrangThai || !Global.HasGPS) return false;
                                
                #region refresh hien trang xe
                if (hienTrangXe1.Visible)
                {
                    hienTrangXe1.ThongTinXe(SoHieuXe);
                }
                #endregion
                Load_Data();                

                return true;
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("Không thể kết nối tới Service", "Thông báo");
                return false;
            }
            return false;

        }
        #endregion-----------------------End of load danh sach xe-----------------
        
        #region----------------Get Vung Dieu Hanh------------------
        private DataTable getVungDH()
        {
            return lienlac.getDsVungDh();
        }
        #endregion--------------End of Get Vung Dieu Hanh------------------

        #region-----------------Load vung dieu hanh tren map------------------
        DataTable dtVungDh = new DataTable();
        private void Load_VungDH(string idVungDH)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            try
            {
                polyOverlay.Polygons.Clear();
                dtVungDh.Clear();

                dtVungDh = lienlac.getVungDh(idVungDH);

                List<PointLatLng> points = new List<PointLatLng>();
                for (int i = 0; i < dtVungDh.Rows.Count; i++)
                {
                    //cat chuoi "ToaDoVung"
                    string pl = string.Empty;
                    points.Clear();
                    pl = dtVungDh.Rows[i]["Polygon"].ToString();
                    string[] cut1 = pl.Split(',');
                    foreach (string item in cut1)
                    {
                        if (item.Length != 0)
                        {
                            string[] cut2 = item.Split(' ');
                            points.Add(new PointLatLng(double.Parse(cut2[1].ToString()), double.Parse(cut2[0].ToString())));
                        }
                        else
                        {
                            break;
                        }

                    }
                    //set polygon
                    GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                    polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                }
            }
            catch (Exception ex)
            {
                return;
            }
            
        }
        #endregion------------------End of Load vung dieu hanh tren map---------------

        #region------------Chon vung dieu hanh va khai bao textbox search--------------
        
        /// <summary>
        /// khai bao text box search xe va dia chi
        /// </summary>
        protected void Init_texbox()
        {
            var img = new PictureBox();
            img.Size = new Size(25, txtDiaChi.ClientSize.Height + 2);
            img.Location = new Point(txtDiaChi.ClientSize.Width - img.Width + 5, 0);
            img.Cursor = Cursors.Default;
            img.Image = Taxi.Controls.Properties.Resources.search;

            var img1 = new PictureBox();
            img1.Size = new Size(25, txtDiaChi.ClientSize.Height + 2);
            img1.Location = new Point(txtDiaChi.ClientSize.Width - img.Width + 5, 0);
            img1.Cursor = Cursors.Default;
            img1.Image = Taxi.Controls.Properties.Resources.search;

            txtDiaChi.Controls.Add(img);
            txtTimXe.Controls.Add(img1);
            txtDiaChi.Text = "Tìm địa chỉ";
            txtTimXe.Text = "Tìm xe";
        }

        #endregion----------------End of Chon vung dieu hanh va khai bao textbox search------

        #region------------Function search xe----------------

        public VehicleOnline Search_Xe()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return null;

            VehicleOnline xe = new VehicleOnline();            
            string soXe = txtTimXe.Text.Trim();
            if (CommonData.G_Dict_VehicleOnline.ContainsKey(soXe))
            {
                VehicleOnline item = CommonData.G_Dict_VehicleOnline[soXe];
                xe.SoHieuXe = item.SoHieuXe;
                xe.MaXN = item.MaXN;
                xe.BienSoXe = item.BienSoXe;
                xe.KinhDo = item.KinhDo;
                xe.ViDo = item.ViDo;
                xe.Huong = item.Huong;
                xe.SoChoNgoi = item.SoChoNgoi;
                xe.LoaiXeGPS = item.LoaiXeGPS;
                xe.LoaiXe = item.LoaiXe;
                xe.TGCapNhat = item.TGCapNhat;
                xe.Gara = item.Gara;
                xe.Trangthai = item.Trangthai;
                xe.VGPS = item.VGPS;
                xe.VCo = item.VCo;
                p = new PointLatLng(item.ViDo, item.KinhDo);
                return xe;
            }
            return xe;

        }
        #endregion------------------End of search xe

        #region hàm tìm xe ở bàn cờ
        public void TimXe(string f_SoHieuXe)
        {
            if (!Global.HasGPS) return;

            txtTimXe.Text = f_SoHieuXe;


            hienTrangXe1.Visible = false;
            pnSearchDiaChi.Visible = false;

            VehicleOnline info = Search_Xe();

            if (info.SoHieuXe != null)
            {
                this.SoHieuXe = info.SoHieuXe;

                TXe.BienSoXe = info.BienSoXe;
                TXe.SoHieuXe = info.SoHieuXe;
                TXe.ViDo = info.ViDo;
                TXe.KinhDo = info.KinhDo;
                TXe.LoaiXe = info.LoaiXe;
                TXe.TGCapNhat = info.TGCapNhat;
                TXe.Gara = info.Gara;
                TXe.TrangThai = info.Trangthai;
                TXe.VGPS = info.VGPS;
                TXe.VCo = info.VCo;

                //set location map
                gmap.Position = new PointLatLng(p.Lat, p.Lng);
                gmap.Zoom = 17;

                //dung control HienTrangXe
                hienTrangXe1.Refresh();
                hienTrangXe1.ThongTinXe(TXe, f_SoHieuXe);
                hienTrangXe1.Location = new Point(813, 160);
                hienTrangXe1.Visible = true;
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Không tìm thấy xe!", "Thông báo");
            }

        }
        #endregion

        #region-------------------------Event focus textbox------------------

        void txtTimXe_LostFocus(object sender, EventArgs e)
        {
            if (txtTimXe.Text == "")
            {
                txtTimXe.Text = "Tìm xe";
            }
        }

        void txtDiaChi_LostFocus(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "")
            {
                txtDiaChi.Text = "Tìm địa chỉ";
            }
        }

        void hienTrangXe1_OnUserControlButtonClicked(object sender, EventArgs e)
        {
            hienTrangXe1.Visible = false;
        }

        #endregion-------------------------End of event focus textbox--------------

        #region---------------Event of textbox dia chi va tim xe--------------------

        //tim dia chi
        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    hienTrangXe1.Visible = false;
                    ovlDiaChi.Markers.Clear();
                    //string tinhthanh = "hai phong";
                    var address = Service_Common.GetGeobyAddress(StringTools.TrimSpace(txtDiaChi.Text), StringTools.TrimSpace(txtTinhThanh.Text.Trim()));
                    if (address == "*")
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy địa chỉ hoặc địa chỉ không tồn tại!", "Thông báo");
                    }
                    else
                    {
                        var cut = address.Split(' ');
                        marker1 = new GMarkerGoogle(new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1])), GMarkerGoogleType.green);
                        ovlDiaChi.Markers.Add(marker1);
                        gmap.Position = new PointLatLng(double.Parse(cut[0]), double.Parse(cut[1]));
                        gmap.Zoom = 16;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("txtDiaChi_KeyDown: ", ex);
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



        private void txtTimXe_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (txtTimXe.Text.Equals("Tìm xe") == true)
                    {
                        txtTimXe.Text = "";
                        txtTimXe.ForeColor = Color.Black;
                    }
                    break;
            }

        }


        //Tim xe
        private void txtTimXe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!Global.HasGPS) return;
                    hienTrangXe1.Visible = false;
                    pnSearchDiaChi.Visible = false;

                    VehicleOnline info = Search_Xe();
                    if (info.SoHieuXe != null)
                    {
                        SoHieuXe = info.SoHieuXe;
                        //set location map
                        gmap.Position = new PointLatLng(p.Lat, p.Lng);
                        gmap.Zoom = 17;

                        //dung control HienTrangXe
                        hienTrangXe1.Refresh();
                        hienTrangXe1.ThongTinXe(info.SoHieuXe);
                        hienTrangXe1.Location = new Point(813, 160);
                        hienTrangXe1.Visible = true;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Không tìm thấy xe!", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("txtTimXe_KeyDown: ", ex);                
            }

        }


        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDiaChi.Text.TrimStart();

        }

        private void txtTimXe_TextChanged(object sender, EventArgs e)
        {
            txtTimXe.Text = txtTimXe.Text.TrimStart();
        }


        #endregion--------------------End of event text box-------------------

        #region-------------function tinh goc xe-------------------

        private double getdir(float x1, float y1, float x2, float y2)
        {
            double x, y, g, s, kc;
            x = x2 - x1;
            y = y2 - y1;
            s = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            kc = canculator_dis(x1, y1, x2, y2);
            if (kc < 30) return 8;
            g = Math.Acos(x / s);
            if (y < 0) g = 2 * Math.PI - g;
            g = Math.Round(4 * g / (Math.PI));
            if (g > 7) g = 0;
            return g;
        }

        private double canculator_dis(float x1, float y1, float x2, float y2)
        {
            double kc, t;
            var p1X = x1 * (Math.PI) / 180;
            var p1Y = y1 * (Math.PI) / 180;
            var p2X = x2 * (Math.PI) / 180;
            var p2Y = y2 * (Math.PI) / 180;
            kc = p2X - p1X;
            t = Math.Cos(kc);
            t = t * Math.Cos(p2Y);
            t = t * Math.Cos(p1Y);
            kc = Math.Sin(p1Y);
            kc = kc * Math.Sin(p2Y);
            t = t + kc;
            kc = Math.Acos(t);
            kc = kc * 6378137;
            return kc;
        }

        #endregion-----------------End of function tinh goc xe----------------------

        #region---------------Su kien visible panel khi drag map, scroll, exit khi panel khi click X---------
        private void gmap_OnMapDrag()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            pnSearchDiaChi.Visible = false;
            //ovlDiaChi.Markers.Clear();
        }


        public void AnMarker()
        {
            ovlDiaChi.Markers.Clear();
        }

        private void ptbDiaChi_Click(object sender, EventArgs e)
        {
            pnSearchDiaChi.Visible = false;
        }

        private void gmap_Scroll(object sender, ScrollEventArgs e)
        {
            hienTrangXe1.Visible = false;
            pnSearchDiaChi.Visible = false;
        }
        #endregion-----------End of Su kien visible panel khi drag map, scroll, exit khi panel khi click X-----

        #region---Event gmap--------
        private void gmap_OnMapZoomChanged()
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            ztbMap.Value = int.Parse(gmap.Zoom.ToString());

        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Right:
                    hienTrangXe1.Visible = false;
                    break;
            }
        }

        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            try
            {
                //thong tin xe theo toa do
                var info = CommonData.G_Dict_VehicleOnline.Values.ToList<VehicleOnline>().Where(m => m.KinhDo + 0.000005 >= item.Position.Lng && m.ViDo + 0.000005 >= item.Position.Lat && m.KinhDo - 0.000005 <= item.Position.Lng && m.ViDo - 0.000005 <= item.Position.Lat).FirstOrDefault();
                SoHieuXe = info.SoHieuXe;
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        //dung control HienTrangXe
                        hienTrangXe1.Refresh();
                        hienTrangXe1.ThongTinXe(info.SoHieuXe);

                        if (e.X + hienTrangXe1.Size.Width > this.Location.X + this.Size.Width && e.Y + hienTrangXe1.Size.Height > this.Location.Y + this.Size.Height)
                        {
                            hienTrangXe1.Location = new Point((int)e.X - hienTrangXe1.Size.Width, (int)(e.Y) - hienTrangXe1.Size.Height);
                        }
                        else if (e.X + hienTrangXe1.Size.Width > this.Location.X + this.Size.Width)
                        {
                            hienTrangXe1.Location = new Point((int)e.X - hienTrangXe1.Size.Width, (int)(e.Y));
                        }
                        else if (e.Y + hienTrangXe1.Size.Height > this.Location.Y + this.Size.Height)
                        {
                            hienTrangXe1.Location = new Point((int)e.X, (int)(e.Y) - hienTrangXe1.Size.Height);
                        }
                        else
                            hienTrangXe1.Location = new Point((int)e.X, (int)(e.Y));

                        hienTrangXe1.Visible = true;
                        break;

                    case MouseButtons.Right:
                        hienTrangXe1.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                return;
            }
            

        }

        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            gmap.Zoom += 1;
        }
        #endregion-------End event gmap------

        #region----Event zoom track bar-------
        private void ztbMap_EditValueChanged(object sender, EventArgs e)
        {
            gmap.Zoom = ztbMap.Value;
        }
        #endregion-------End------------

        #region event chọn vùng
        private void ccbeVDH_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                if (ccbeVDH.EditValue != null && !ccbeVDH.EditValue.Equals("") && !ccbeVDH.EditValue.Equals("Chọn vùng"))
                {
                    Load_VungDH(ccbeVDH.EditValue.ToString());

                    //cat chuoi "ToaDoVung"
                    string pl = dtVungDh.Rows[0]["Polygon"].ToString();
                    string[] cut1 = pl.Split(',');
                    if (cut1[0].Length != 0)
                    {
                        string[] cut2 = cut1[0].Split(' ');
                        gmap.Position = new PointLatLng(double.Parse(cut2[1].ToString()), double.Parse(cut2[0].ToString()));
                        gmap.Zoom = 14;
                    }
                }
                else
                {
                    polyOverlay.Polygons.Clear();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ccbeVDH_EditValueChanged: ",ex);                
            }

        }
        #endregion

        #region timer load lại vùng điều hành
        private void timerVDH_Tick(object sender, EventArgs e)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;            
        }
        #endregion

        #region event chọn map
        private void cboMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMapType.SelectedIndex == 1)
            {
                gmap.MapProvider = GoogleMapProvider.Instance;
            }
            else if (cboMapType.SelectedIndex == 2)
            {
                gmap.MapProvider = GoogleMapProvider.Instance;
            }
            else if (cboMapType.SelectedIndex == 3)
            {
                gmap.MapProvider = GMapProviders.OviSatelliteMap;
            }
            else
            {
                gmap.MapProvider = GoogleMapProvider.Instance;
            }
        }
        #endregion

        private void GMaps_Resize(object sender, EventArgs e)
        {
            grbSearch.Location = new Point(this.Width - grbSearch.Width, grbSearch.Location.Y);
        }

        private void GMaps_VisibleChanged(object sender, EventArgs e)
        {
            //StartTimerLoadMap();
        }
    }
}
