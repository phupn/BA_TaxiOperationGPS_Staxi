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

namespace Taxi.GUI
{
    public partial class frmHienThiBanDo : Form
    {
        private CuocGoi g_CuocGoi;
        private TaxiOperation_TongDai.BAGPS.Service BAService = new TaxiOperation_TongDai.BAGPS.Service();
        public frmHienThiBanDo()
        {
            InitializeComponent();
            ConfigMap();
        }

        public frmHienThiBanDo(CuocGoi cuocGoi)
        {
            InitializeComponent();
            g_CuocGoi = cuocGoi;
            ConfigMap();
        }

        private void frmHienThiBanDo_Load(object sender, EventArgs e)
        {
            //Add market Địa điểm của khách.
            // debug nếu chưa có tọa độ phải lấy lại tọa độ theo địa chỉ...
            //if (g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo >0)
            //{
            //    MainMap.addMarkerCustomer2(g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo, g_CuocGoi.DiaChiDonKhach);
            //}
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
        }

        #region ==========================MAPS=================================
        private EFiling.Utils.MapModeEnum _mapMode;
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
            MainMap.Position = new PointLatLng(21.029094, 105.779958);
            if (_mapMode == EFiling.Utils.MapModeEnum.EditPoint)
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
                if (currentMarker.IsVisible)
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                //else
                //{
                //    //PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                //    //string strDiaChi = new TaxiOperation_TongDai.BAGPS.Service().GetAddressByGeo((float)point.Lat, (float)point.Lng);

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
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2]), Convert.ToDouble(Values[3]), string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
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
                TaxiOperation_TongDai.WCFSyncService.T_XeOnline XeOnline = new TaxiOperation_TongDai.WCFSyncService.T_XeOnline();
                XeOnline = new TaxiOperation_TongDai.WCFSyncService.SyncServiceOnlineClient().GetXeOnlineBySHX(soHieuXe);
                if (XeOnline == null)
                {
                    new MessageBox.MessageBox().Show(string.Format("Không tồn tại xe {0} trên hệ thống", soHieuXe), "Thông Báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                }
                else
                {
                    if (XeOnline.ThoiDiemChenDuLieu <= DateTime.Now.AddMinutes(-150))
                    {
                        new MessageBox.MessageBox().Show(string.Format("Xe {0} đã mất tín hiệu GPS.", soHieuXe), "Thông Báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    }
                    else
                    {

                        //PointLatLng point = new PointLatLng(XeOnline.ViDo, XeOnline.KinhDo);
                        string strDiaChi = string.Format("[{0}]:{1}", soHieuXe, BAService.GetAddressByGeo((float)XeOnline.ViDo, (float)XeOnline.KinhDo));
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
                new MessageBox.MessageBox().Show("Lỗi, không tìm thấy xe", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }

        private void txtTimDuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                TimDuong();
            }
        }

        private void TimDuong()
        {
            string diaChi = getDiaChiChuan(txtTimDuong.Text);
            if (!string.IsNullOrEmpty(diaChi))
            {
                double viDo = 0;
                double kinhDo = 0;
                string toaDo = GetGeobyAddressBA2(diaChi);
                if (toaDo != "*" && toaDo != string.Empty)
                {
                    string[] arrString = toaDo.Split(' ');
                    viDo = Convert.ToDouble(arrString[0]);
                    kinhDo = Convert.ToDouble(arrString[1]);
                }
                else
                {
                    new MessageBox.MessageBox().Show("Không tìm thấy địa chỉ","Thông báo", Taxi.MessageBox.MessageBoxButtons.OK);
                }
                if (kinhDo == 0 && viDo == 0)
                    return;

                MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi);
            } 
        }

        private string GetGeobyAddressBA2(string address)
        {
            try
            {
                string street = address;
                string city = ThongTinCauHinh.GPS_TenTinh;
                return BAService.GetGeobyAddressBA_HN(String.Format("{0},{1}", street, city));
            }
            catch (Exception ex)
            {
                return "*";
            }
        }        

        private string getDiaChiChuan(string diaChi)
        {
            string strDiaChi = diaChi;
            //----Bỏ phần xe nhận cuộc gọi lại
            int count2 = diaChi.IndexOfAny(new char[] { ']' }, 0, diaChi.Length);
            if (count2 >= 0)
            {
                strDiaChi = diaChi.Substring(count2 + 1, diaChi.Length - count2 - 1);

            }

            int index = strDiaChi.IndexOf("-");
            if (index > 0)
            {
                strDiaChi = StringTools.TrimSpace(strDiaChi.Substring(0, index));
            }
            return strDiaChi;
        }
    }
}