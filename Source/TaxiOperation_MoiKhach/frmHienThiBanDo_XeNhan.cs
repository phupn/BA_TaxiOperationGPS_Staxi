using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using GMap.NET.WindowsForms;
using GMap.NET;
using Taxi.Utils;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using Janus.Windows.GridEX;
using Taxi.Entity;
using Taxi.Services.WCFServices;
using Taxi.Services.Operations;
using Taxi.Services;

namespace Taxi.GUI
{
    public partial class frmHienThiBanDo_XeNhan : Form
    {
        private CuocGoi g_CuocGoi;
        List<XeDonDeCuEntity> G_LstXeDonDeCu = new List<XeDonDeCuEntity>();

        public frmHienThiBanDo_XeNhan()
        {
            InitializeComponent();
        }

        public frmHienThiBanDo_XeNhan(CuocGoi cuocGoi)
        {
            InitializeComponent();
            g_CuocGoi = cuocGoi;
            ConfigMap();

        }

        private void frmHienThiBanDo_XeNhan_Load(object sender, EventArgs e)
        {
            lblDCDon.Text = g_CuocGoi.DiaChiDonKhach;
            lblSoDT.Text = g_CuocGoi.PhoneNumber;
            lblLenhMK.Text = g_CuocGoi.Vung.ToString();
            lblLenhDTV.Text = g_CuocGoi.LenhDienThoai;
            lblGhiChu.Text = g_CuocGoi.GhiChuDienThoai;
            lblThoiGian.Text = g_CuocGoi.ThoiDiemGoi.ToString("HH:mm dd/MM/yyyy");
            //Add market Địa điểm của khách.
            // debug nếu chưa có tọa độ phải lấy lại tọa độ theo địa chỉ...
            if (g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo > 0)
            {
                MainMap.addMarkerCustomer2(g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo, g_CuocGoi.DiaChiDonKhach);
            }
            //if (!string.IsNullOrEmpty(g_CuocGoi.DanhSachXeDeCu) && !string.IsNullOrEmpty(g_CuocGoi.DanhSachXeDeCu_TD))
            //{
            //    //Add market Danh Sách xe đề cử.
            //    setMarkerDSXeDeCu(g_CuocGoi.DanhSachXeDeCu, g_CuocGoi.DanhSachXeDeCu_TD);
            //}
            //if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && !string.IsNullOrEmpty(g_CuocGoi.XeNhan_TD))
            //{
            //    //Add market Danh Sách xe nhận.
            //    setMarkerDSXeNhan(g_CuocGoi.XeNhan, g_CuocGoi.XeNhan_TD);
            //}

            if (!string.IsNullOrEmpty(g_CuocGoi.XeDenDiemDonKhach) && !string.IsNullOrEmpty(g_CuocGoi.XeDenDiemDonKhach_TD))
            {
                //Add market Danh Sách xe nhận.
                setMarkerDSXeDonKhach(g_CuocGoi.XeDenDiemDonKhach, g_CuocGoi.XeDenDiemDonKhach_TD);
            }

            DataTable dt = CuocGoi.TONGDAI_LayThongTinXeDon_ID(g_CuocGoi.IDCuocGoi);
            if (dt != null && dt.Rows.Count > 0)
            {
                setMarkerDSXeDonKhachDeCu(dt.Rows[0]["XeDenDiemDonKhachDeCu"].ToString(), dt.Rows[0]["XeDenDiemDonKhachDeCu_TD"].ToString());
            }

            if (G_LstXeDonDeCu != null && G_LstXeDonDeCu.Count > 0)
            {
                gridEX.DataMember = "dtXeDonDeCu";
                gridEX.SetDataBinding(G_LstXeDonDeCu, "dtXeDonDeCu");
                gridEX.Visible = true;
            }
            txtTimXe.Focus();
            txtTimXe.Select();
        }

        #region ==========================MAPS=================================
        private Taxi.Utils.MapModeEnum _mapMode;
        GMapMarker currentMarker;
        GMapOverlay top;
        GMapOverlay OverlayXeDeCu;
        GMapOverlay OverlayXeNhan;

        bool isMouseDown;

        private void ConfigMap()
        {
            //// config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; //Application.StartupPath + "\\Map";
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            MainMap.MapProvider = GMapProviders.GoogleMap;
            MainMap.MaxZoom = 19;
            MainMap.MinZoom = 7;
            MainMap.Zoom = 15;
            MainMap.Dock = DockStyle.Fill;

            //MainMap.PolygonsEnabled = false;            
            // map events

            // add custom layers  
            {
                top = new GMapOverlay("top");
                MainMap.Overlays.Add(top);

                OverlayXeDeCu = new GMapOverlay("OverlayXeDeCu");
                MainMap.Overlays.Add(OverlayXeDeCu);

                OverlayXeNhan = new GMapOverlay("OverlayXeNhan");
                MainMap.Overlays.Add(OverlayXeNhan);
            }

            pnlBanDo.Controls.Add(MainMap);
            MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
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
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

            // get zoom  
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);
        }
        #region===================Map Events==================================

        private void MainMap_OnMapZoomChanged()
        {
            trackBarMap.Value = (int)MainMap.Zoom;
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
                isMouseDown = true;
                //if (currentMarker.IsVisible)
                //    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                //else
                //{
                //    //PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                //    //string strDiaChi = new TaxiOperation_MoiKhach.BAGPS.Service().GetAddressByGeo((float)point.Lat, (float)point.Lng);

                //    //MainMap.addMarkerCustomer(point, strDiaChi);
                //}
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
        #endregion=============================================================

        private void setMarkerDSXeDeCu(string DSXeDeCu, string DSXeDeCu_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeDeCu = DSXeDeCu.Split('.');
                string[] arrDSXeDeCu_TD = DSXeDeCu_TD.Split(',');
                string[] Values;
                for (int i = 0; i < arrDSXeDeCu.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeDeCu_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (Values[4] != "")
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeDeCu(trangThai, Convert.ToDouble(Values[2]), Convert.ToDouble(Values[3]), string.Format("{0}-{1}", arrDSXeDeCu[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void setMarkerDSXeNhan(string DSXeNhan, string DSXeNhan_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeNhan = DSXeNhan.Split('.');
                string[] arrDSXeNhan_TD = DSXeNhan_TD.Split(',');
                string[] Values;
                double KinhDo = 0;
                double ViDo = 0;
                for (int i = 0; i < arrDSXeNhan.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeNhan_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        ViDo = Convert.ToDouble(Values[3]);
                        KinhDo = Convert.ToDouble(Values[2]);
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2]), Convert.ToDouble(Values[3]), string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void setMarkerDSXeDonKhach(string DSXeDonKhach, string DSXeDonKhach_TD)
        {
            try
            {

                //int trangThai = 0;
                string[] arrDSXeDonKhach = DSXeDonKhach.Split('.');
                string[] arrDSXeDonKhach_TD = DSXeDonKhach_TD.Split(',');
                string[] Values;
                double KinhDo = 0;
                double ViDo = 0;
                for (int i = 0; i < arrDSXeDonKhach.Length; i++)
                {
                    //"SHXe-KhoangCach-KD-VD-TrangThai"
                    Values = arrDSXeDonKhach_TD[i].Split('_');
                    if (Values.Length > 0)
                    {
                        if (!String.IsNullOrEmpty(Values[3]))
                        {
                            //    trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                            //}
                            ViDo = Convert.ToDouble(Values[3]);
                            KinhDo = Convert.ToDouble(Values[2]);
                            MainMap.addMarkerXeNhan(3, KinhDo, ViDo, string.Format("{0}-{1}", arrDSXeDonKhach[i], Service_Common.GetAddressByGeoBA((float)ViDo, (float)KinhDo)));
                            G_LstXeDonDeCu.Add(new XeDonDeCuEntity(
                                                    Values[0],
                                                    KinhDo,
                                                    ViDo,
                                                    DateTime.Parse(Values[5])
                                        ));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void setMarkerDSXeDonKhachDeCu(string DSXeDonKhach, string DSXeDonKhach_TD)
        {
            try
            {
                if (DSXeDonKhach == "") return;
                //int trangThai = 0;
                string[] arrDSXeDonKhach = DSXeDonKhach.Split(',');
                string[] arrDSXeDonKhach_TD = DSXeDonKhach_TD.Split(',');
                string[] Values;
                double KinhDo = 0;
                double ViDo = 0;

                for (int i = 0; i < arrDSXeDonKhach.Length; i++)
                {
                    //"SHXe_KhoangCach_KD_VD_TrangThai_TGDon"
                    Values = arrDSXeDonKhach_TD[i].Split('_');
                    if (Values.Length > 0)
                    {


                        if (!String.IsNullOrEmpty(Values[3]))
                        {
                            //    trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                            //}
                            ViDo = Convert.ToDouble(Values[3]);
                            KinhDo = Convert.ToDouble(Values[2]);

                            MainMap.addMarkerXeNhan(2, KinhDo, ViDo, string.Format("{0}-{1}", arrDSXeDonKhach[i], Service_Common.GetAddressByGeoBA((float)ViDo, (float)KinhDo)));

                            G_LstXeDonDeCu.Add(new XeDonDeCuEntity(
                                                    Values[0],
                                                    KinhDo,
                                                    ViDo,
                                                    DateTime.Parse(Values[5])
                                        ));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                case Keys.Alt | Keys.X:
                    txtTimXe.Focus();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }

        private void txtTimXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TimXe(StringTools.TrimSpace(txtTimXe.Text));
            }
        }

        private void TimXe(string soHieuXe)
        {
            try
            {
                T_XeOnline XeOnline = new T_XeOnline();
                XeOnline = new SyncServiceOnlineClient().GetXeOnlineBySHX(soHieuXe);
                if (XeOnline == null)
                {
                    new MessageBox.MessageBoxBA().Show(string.Format("Không tồn tại xe {0} trên hệ thống", soHieuXe), "Thông Báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    if (XeOnline.ThoiDiemChenDuLieu <= DieuHanhTaxi.GetTimeServer().AddMinutes(-150))
                    {
                        new MessageBox.MessageBoxBA().Show(string.Format("Xe {0} đã mất tín hiệu GPS.", soHieuXe), "Thông Báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    else
                    {

                        //PointLatLng point = new PointLatLng(XeOnline.ViDo, XeOnline.KinhDo);
                        string strDiaChi = string.Format("[{0}]:{1}", soHieuXe, Service_Common.GetAddressByGeoBA((float)XeOnline.ViDo, (float)XeOnline.KinhDo));
                        int trangThai = 0;//xe tắt máy
                        if ((XeOnline.TrangThai & 3) > 0)
                        {
                            trangThai = 2;//xe co khach
                        }
                        else if ((XeOnline.TrangThai & 8) == 0)
                        {
                            trangThai = 1;//xe bật máy.
                        }
                        //if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)                        
                        //    MainMap.OverlayXeDeCu.Markers.Clear();
                        //if (MainMap.MarkerXeDeCu != null)
                        //    MainMap.MarkerXeDeCu.Overlay.Clear();

                        MainMap.addMarkerXeDeCu3(trangThai, XeOnline.KinhDo, XeOnline.ViDo, strDiaChi);
                        MainMap.Position = new PointLatLng(XeOnline.ViDo, XeOnline.KinhDo);
                    }
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi, không tìm thấy xe", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }
    }
}