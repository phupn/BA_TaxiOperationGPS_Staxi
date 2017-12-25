using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Services;
using Taxi.Data.BanCo;
using System.Configuration;
using System.Data.SqlClient;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Data.BanCo.Entity.MasterData;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.Controls.Maps
{
    public partial class HienTrangXe : UserControl
    {

        GiamSatXe_LienLac lienlac;//= new GiamSatXe_LienLac();
        public HienTrangXe()
        {
               InitializeComponent();
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            { 
                lienlac = new GiamSatXe_LienLac();
                //listXe = new List<VehicleOnline>();
            }

        }

        #region------------Khai bao bien------------------

        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnUserControlButtonClicked;

        //List<VehicleOnline> listXe;
        string DieuHoa, may, TrangThaiXe, loaixe, socho, gara, vdh,TrangThaiLaiXe, TenLaiXe, Phone, DungXeNoMay, DaDung;
        DateTime ThoiDiemCB;
        int timedung, DiemDoGPS, DiemDoKhaiBao;
        TextBox txtInfoHeader = new TextBox();
        
        #endregion--------------End-------------------------

        #region-------Thong tin xe--------------
        private void ResetThongTinXe()
        {
            DieuHoa = may = TrangThaiXe = loaixe = socho = gara = vdh = TrangThaiLaiXe = TenLaiXe = Phone = DungXeNoMay = DaDung = "";
        }

        private void ShowHienTrangXe(VehicleOnline xeonline, string SoHieuXe)
        {
            
            #region--Kiem tra tra trang thai xe va dua thong tin vao panel--

            var address = !Taxi.Business.ThongTinCauHinh.GPS_TrangThai ? "" : Service_Common.GetAddressByGeoBA(xeonline.ViDo, xeonline.KinhDo);
            #region Thông tin xe
            pnMarker.Visible = true;
            pnMarker.Refresh();

            if ((xeonline.Trangthai & 3) > 0)
            {
                TrangThaiXe = "Có khách";
            }
            else if ((xeonline.Trangthai & 3) <= 0)
            {
                TrangThaiXe = "Không khách";
            }
            if ((xeonline.Trangthai & 8) == 0)
            {
                may = "Bật";
                DungXeNoMay = "\r\nDừng xe nổ máy: \t" + xeonline.TGDungXeNoMay;
            }
            else if ((xeonline.Trangthai & 8) > 0)
            {
                may = "Tắt";
            }
            if ((xeonline.Trangthai & 32) > 0)
            {
                DieuHoa = "Tắt";
            }
            else if ((xeonline.Trangthai & 32) == 0)
            {
                DieuHoa = "Bật";
            }

            int.TryParse((xeonline.TGGPS - xeonline.ThoiDiemDiChuyenGanNhat).ToString("mm"), out timedung);

            if ((xeonline.TrangThaiKhac) == -2 && (xeonline.VGPS) >= 3 && timedung < 0)
            {
                DaDung = "";
            }
            else
            {
                DaDung = "\r\nĐã dừng:\t\t" + timedung.ToString() + " phút";
            }

            var dt = lienlac.Map_HienTrangXe(SoHieuXe);
            string BienSoXe = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["TenNhanVien"] != null && !dt.Rows[0]["TenNhanVien"].ToString().Equals(""))
                {
                    //TenLaiXe = "Tên lái xe:\t" + dt.Rows[0]["TenNhanVien"].ToString();
                    //Phone = "Sđt:\t" + dt.Rows[0]["DiDong"].ToString();
                    loaixe = dt.Rows[0]["TenLoaiXe"].ToString() + " ";
                    socho = dt.Rows[0]["SoCho"].ToString();
                    gara = "\r\nGara: \t\t" + dt.Rows[0]["Name"].ToString();

                }
                else if (dt.Rows[0]["TenNhanVien"].ToString().Equals(""))
                {
                    //TenLaiXe = "Tên lái xe:\t" + dt.Rows[0]["TenNhanVien"].ToString();
                    //Phone = "Sđt:\t" + dt.Rows[0]["DiDong"].ToString();
                    loaixe = dt.Rows[0]["TenLoaiXe"].ToString() + " ";
                    socho = dt.Rows[0]["SoCho"].ToString();
                    gara = "\r\nGara: \t\t" + dt.Rows[0]["Name"].ToString();

                }

                BienSoXe = dt.Rows[0]["BienKiemSoat"].ToString();
                loaixe = dt.Rows[0]["TenLoaiXe"].ToString() + " ";
                socho = dt.Rows[0]["SoCho"].ToString();
                gara = "\r\nGara: \t\t" + dt.Rows[0]["Name"].ToString();

                #region Thời điểm kd
                DateTime det = DateTime.MinValue;
                var tdkd = string.Empty;
                //txtThoiDiemKD.Visible = true;
                tdkd += string.Format("Tên lX:\t {0}", dt.Rows[0]["TenNhanVien"]);
                tdkd += string.Format("\r\nSDT:\t  {0}", dt.Rows[0]["DiDong"]);
                if (DateTime.TryParse(dt.Rows[0]["ThoiDiemBao"].ToString(), out det) && det > DateTime.MinValue)
                    tdkd += string.Format("\r\nRa KD:         {0:HH:mm dd/MM/yyyy}", dt.Rows[0]["ThoiDiemBao"]);

                #endregion

                string strDiemDo = "";
                var getInfoKD = lienlac.GetInfoKD(SoHieuXe);

                if (getInfoKD != null && getInfoKD.Rows.Count > 0)
                {
                    DiemDoKhaiBao = dt.Rows[0]["DiemDo"] == DBNull.Value ? 0 : int.Parse(dt.Rows[0]["DiemDo"].ToString());
                    //txtDiemDo.Visible = true;
                    //txtDiemDo.Text = "Điểm đỗ:      " + getInfoKD.Rows[0]["ViTriDiemBao"].ToString()
                    //                        + "\r\nThời điểm:  " + ((DateTime)getInfoKD.Rows[0]["ThoiDiemBao"]).ToString("HH:mm dd/MM/yyyy");
                    strDiemDo = "Điểm đỗ:      " + getInfoKD.Rows[0]["ViTriDiemBao"].ToString()
                                            + "\r\nThời điểm:  " + ((DateTime)getInfoKD.Rows[0]["ThoiDiemBao"]).ToString("HH:mm dd/MM/yyyy");
                }
                var getTrangThai = lienlac.GetTrangThaiBySoXe(SoHieuXe);
                if (getTrangThai != null && getTrangThai.Rows.Count > 0)
                {
                    //txtDiemDo.Text = txtDiemDo.Text + "\r\nTrạng thái:   " + getTrangThai.Rows[0]["TrangThai"];
                    strDiemDo += "\r\nTrạng thái:   " + getTrangThai.Rows[0]["TrangThai"];
                    if (getTrangThai.Rows[0]["LyDoVe"] != DBNull.Value && string.IsNullOrEmpty(getTrangThai.Rows[0]["LyDoVe"].ToString()))
                    {
                        strDiemDo += "\r\nLý do về:     " + getTrangThai.Rows[0]["LyDoVe"];
                        //txtDiemDo.Text = txtDiemDo.Text + "\r\nLý do về:     " + getTrangThai.Rows[0]["LyDoVe"];
                    }
                }

                txtThoiDiemKD.Text = tdkd + "\r\n" + strDiemDo;
            }
            else
            {
                BienSoXe = xeonline.BienSoXe;
                var strXeKhongKD = string.Empty;
                //kiểm tra xem có xin nghỉ ko đi kinh doanh không - nếu có thì hiển hị lý do nghỉ
                var nghi = lienlac.GetVehicleNotWorkingBySoXe(SoHieuXe);
                if (nghi != null && nghi.Rows.Count > 0)
                {
                    strXeKhongKD += string.Format("\r\nLý do nghỉ: {0}", nghi.Rows[0]["ReasonName"]);
                }
                txtThoiDiemKD.Text = strXeKhongKD;
            }
            DataTable dtVungDh = (new VungDieuHanh()).VDHById(xeonline.VungID);
            if (dtVungDh!= null && dtVungDh.Rows.Count > 0)
            {
                vdh = dtVungDh.Rows[0]["NameVungDH"].ToString();
                DiemDoGPS = int.Parse(dtVungDh.Rows[0]["Id"].ToString());
            }
            else
            {
                vdh = "Không xác định";
                DiemDoGPS = 0;
            }

            DateTime hientai = CommonBL.GetTimeServer();
            DataTable dtCheckAnCa = lienlac.CheckAnCa(SoHieuXe);

            if (dtCheckAnCa.Rows.Count > 0)
            {
                switch (int.Parse(dtCheckAnCa.Rows[0]["TrangThaiLaiXeBao"].ToString()))
                {
                    case 6:
                        TrangThaiLaiXe = "ăn ca";
                        break;
                    case 7:
                        TrangThaiLaiXe = "rời xe";
                        break;
                    case 11:
                        TrangThaiLaiXe = "mất liên lạc";
                        break;
                }
                ThoiDiemCB = DateTime.Parse(dtCheckAnCa.Rows[0]["ThoiDiemBao"].ToString());
                var tongtime = (hientai - ThoiDiemCB);
                var SoPhut = 0;
                var strSoPhutBao = "";
                int.TryParse(dtCheckAnCa.Rows[0]["SoPhutNghi"].ToString(), out SoPhut);
                if (SoPhut > 0)
                {
                    strSoPhutBao = " " + SoPhut + " phút";
                }
                if (TrangThaiLaiXe != "")
                {
                    TrangThaiLaiXe = ((dt.Rows.Count == 1 && dt.Rows[0]["IsHoatDong"].ToString().Contains("1"))
                        ? ""
                        : "Báo " + TrangThaiLaiXe + strSoPhutBao + "\r\nThời điểm: " + ThoiDiemCB.ToString("HH:mm dd/MM/yyyy"));
                    //txtCanhBao.Visible = true;
                    txtCanhBao.Text = TrangThaiLaiXe
                        + (TrangThaiLaiXe == "" ? "" : "\r\nTổng thời gian: " + tongtime.Hours + " giờ " + tongtime.Minutes + " phút");

                }
            }
           
            //txtAddress.BackColor = Color.FromArgb(250, 246, 237);
            txtInfoHeader.ForeColor = Color.Red;
            txtInfoHeader.TextAlign = HorizontalAlignment.Center;
            txtInfoHeader.Font = new Font(txtInfoHeader.Font, FontStyle.Bold);
            txtInfoHeader.Height = 26;
            txtInfoHeader.Width = 437;
            txtInfoHeader.Text = "   Hiện trạng xe: " + SoHieuXe + "-" + BienSoXe;
            txtInfoHeader.ReadOnly = true;

            txtVitri.Text = "Vị trí: " + address;

            txtInfoXe.Text = "Loại xe: \t\t" + loaixe + socho + " chỗ"
                + "\r\nNgày/giờ: \t" + xeonline.TGGPS.ToString("HH:mm dd/MM/yyyy");

            //if (!string.IsNullOrEmpty(TenLaiXe))
            //{
            //    txtInfoXe.Text += "\r\n" + TenLaiXe;
            //}
            //if (!string.IsNullOrEmpty(Phone))
            //{
            //    txtInfoXe.Text += "\r\n" + Phone;
            //}
            string strInfoXe = "Loại xe: \t\t" + loaixe + socho + " chỗ"
                + "\r\nNgày/giờ:  \t" + xeonline.TGGPS.ToString("HH:mm dd/MM/yyyy");
            if (TenLaiXe != null && TenLaiXe != "")
                strInfoXe += "\r\n" + TenLaiXe;
            if (Phone != null && Phone != "")
                strInfoXe += "\r\n" + Phone;

            strInfoXe += "\r\nVận tốc GPS/Cơ: \t" + xeonline.VGPS + "/" + xeonline.VCo + " Km/h";
            if (gara != "")
                strInfoXe += gara;
            if (DieuHoa != "")
                strInfoXe += "\r\nĐiều hòa: \t" + DieuHoa;
            if (DungXeNoMay != "")
                strInfoXe += DungXeNoMay;
            if (may != "")
                strInfoXe += "\r\nMáy: \t\t" + may;
            if (TrangThaiXe != "")
                strInfoXe += "\r\nTrạng thái xe: \t" + TrangThaiXe;
            if (vdh != "")
                strInfoXe += "\r\nĐiểm đỗ:\t\t" + vdh;
            if (DaDung != "")
                strInfoXe += DaDung;

            txtInfoXe.Text = strInfoXe;
            #endregion
            #region Doanh thu xe
            string strDoanhThuXe = "";
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

            var objTongCuoc = new Taxi.Services.WCFServices.TongCuoc_Ca();
                if(Global.HasGPS)
                   objTongCuoc = WCFService_Common.GetTongCuoc(BienSoXe, false);
            if (objTongCuoc != null)
            {
                double kmCoKhach = objTongCuoc.kmCoKhachField;
                double kmRong = objTongCuoc.kmRongField;
                string strKmCoKhach_Rong = "";
                if (xeonline.KmWithPassenger > 0)
                {
                    kmCoKhach = kmCoKhach - xeonline.KmWithPassenger;
                    xeonline.WaitingTime = xeonline.WaitingTime > 0 ? xeonline.WaitingTime : 0;
                }
                kmRong = kmRong + xeonline.EmptyKm;
                strKmCoKhach_Rong = String.Format("{0} km/{1} km", kmCoKhach, kmRong);

                strDoanhThuXe = String.Format("Tổng cuốc:\t{0}", objTongCuoc.tongCuocKhachField);
                if (kmCoKhach > 0)
                    strDoanhThuXe += String.Format("\r\nKm CK/Rỗng:\t{0}", strKmCoKhach_Rong);

                strDoanhThuXe += String.Format(info, "\r\nTổng doanh thu:\t{0:c0}", objTongCuoc.tongTienField);
            }            
            
            if ((xeonline.Trangthai & 3) > 0)
            {
                strDoanhThuXe += String.Format(info, "\r\nTiền cuốc ht:\t{0:c0}", xeonline.Money);
                strDoanhThuXe += String.Format("\r\nThời gian chờ:\t{0} phút", xeonline.FreeWatingTime);
                strDoanhThuXe += String.Format("\r\nKm cuốc đang chạy: {0} km", xeonline.KmWithPassenger);
            }
            txtDoanhThu.Text = strDoanhThuXe;
          
            #endregion
            #region Thông tin cuốc hàng

            var cuochang = "";
            if (Global.TaxiOperation_Module == TaxiOperation_Module.DieuXeTai ||
                    Global.TaxiOperation_Module == TaxiOperation_Module.Luong)
            {
                var db = new TaxiOperation_Truck().GetTruckBySoXe(SoHieuXe.Trim());
                if (db != null)
                {

                    cuochang += string.Format("ĐC đón:    {0}", db.DiaChiDon);
                    cuochang += string.Format("\r\nĐiện thoại:{0}", db.SoDT);
                    cuochang += string.Format("\r\nTG Điều:   {0:HH:mm dd/MM}", db.TGDieuXe);
                    if (db.TGGap != null)
                        cuochang += string.Format("\r\nTG Gặp KH: {0:HH:mm dd/MM}", db.TGGap);
                    if (!String.IsNullOrEmpty(db.DiaChiTra))
                        cuochang += string.Format("\r\nĐC Trả:   {0}", db.DiaChiTra);
                }
                txtCuocHang.Text = cuochang;
                txtCuocHang.ForeColor = Color.Black;
                txtCuocHang.Font = new Font(txtCuocHang.Font.FontFamily, txtCuocHang.Font.Size, FontStyle.Bold);
            }
            #endregion
            pnMarker.Controls.Add(txtInfoHeader);
            pnMarker.BackColor = Color.White;

            #endregion-------------------End-------------------------------
        }

        public VehicleOnline ThongTinXe(Taxi.Services.WCFServices.T_XeOnline objVehicleOnline, string soHieuXe)
        {
            ResetThongTinXe();
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                //txtCanhBao.Visible = false;
                txtCanhBao.Text = "";
                //txtThoiDiemKD.Visible = false;
                txtThoiDiemKD.Text = "";
                //txtDiemDo.Text = "";
                var xeonline = new VehicleOnline
                {
                    BienSoXe = objVehicleOnline.BienSoXe,
                    SoHieuXe = objVehicleOnline.SoHieuXe,
                    ViDo = objVehicleOnline.ViDo,
                    KinhDo = objVehicleOnline.KinhDo,
                    LoaiXe = objVehicleOnline.LoaiXe,
                    TGCapNhat = objVehicleOnline.TGCapNhat,
                    ThoidiemChenDL = objVehicleOnline.ThoiDiemChenDuLieu,
                    ThoiDiemDiChuyenGanNhat = objVehicleOnline.TGDiChuyenGanNhat,
                    Gara = objVehicleOnline.Gara,
                    Trangthai = objVehicleOnline.TrangThai,
                    VGPS = objVehicleOnline.VGPS,
                    TGGPS = objVehicleOnline.TGGPS,
                    VCo = objVehicleOnline.VCo,
                    VungID = objVehicleOnline.VungID,
                    TongCuoc = objVehicleOnline.TongCuoc,
                    TongDoanhThu = objVehicleOnline.TongDoanhThu,
                    KmCoKhach = objVehicleOnline.KmCoKhach,
                    KmRong = objVehicleOnline.KmRong,
                    Money = objVehicleOnline.Money,
                    FreeWatingTime = objVehicleOnline.FreeWatingTime,
                    WaitingTime = objVehicleOnline.WaitingTime,
                    EmptyKm = objVehicleOnline.EmptyKm,
                    KmWithPassenger = objVehicleOnline.KmWithPassenger
                };

                ShowHienTrangXe(xeonline, xeonline.SoHieuXe);
                return xeonline;
            }
            return null;
        }
        
        /// <summary>
        /// Thông tin xe ở bên bàn cờ
        /// </summary>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        public VehicleOnline ThongTinXe(string SoHieuXe)
        {
            ResetThongTinXe();
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                //txtDiemDo.Text = "";
                if (SoHieuXe.IndexOf(".") >= 0) SoHieuXe = SoHieuXe.Split('.')[0];

                //this.listXe = Maps.GMaps.lDsXe;
                var xeonline = new VehicleOnline();
                #region--Lap tim thong tin xe xe---
                if (CommonData.G_Dict_VehicleOnline!=null &&CommonData.G_Dict_VehicleOnline.Count > 0)
                {
                    if (CommonData.G_Dict_Vehicle.ContainsKey(SoHieuXe))
                    {
                        SoHieuXe = CommonData.G_Dict_Vehicle[SoHieuXe];
                    }
                    if (CommonData.G_Dict_VehicleOnline.ContainsKey(SoHieuXe))
                    {
                        VehicleOnline item = CommonData.G_Dict_VehicleOnline[SoHieuXe];
                        xeonline.BienSoXe = item.BienSoXe;
                        xeonline.SoHieuXe = item.SoHieuXe;
                        xeonline.ViDo = item.ViDo;
                        xeonline.KinhDo = item.KinhDo;
                        xeonline.LoaiXe = item.LoaiXe;
                        xeonline.TGCapNhat = item.TGCapNhat;
                        xeonline.Gara = item.Gara;
                        xeonline.Trangthai = item.Trangthai;
                        xeonline.VGPS = item.VGPS;
                        xeonline.VCo = item.VCo;
                        xeonline.TGGPS = item.TGGPS;
                        xeonline.VungID = item.VungID;
                        xeonline.ThoidiemChenDL = item.ThoidiemChenDL;
                        xeonline.ThoiDiemDiChuyenGanNhat = item.ThoiDiemDiChuyenGanNhat;
                        xeonline.TrangThaiKhac = item.TrangThaiKhac;
                    }
                    ShowHienTrangXe(xeonline, xeonline.SoHieuXe);
                }
                else
                {
                    ShowHienTrangXe(xeonline, SoHieuXe);
                }
                #endregion-------------End-----------------------
                
                return xeonline;
            }
            return null;
        }

        #endregion----------End thong tin xe-------------------------

        #region---Event picture box click--
        private void ptbExit_Click(object sender, EventArgs e)
        {
            if (OnUserControlButtonClicked != null)
                OnUserControlButtonClicked(this, e);
            CloseForm();
        }

        private void CloseForm()
        {            
            this.Visible = false;
        }

        #endregion-------------End-----------

        private void pnMarker_MouseDown(object sender, MouseEventArgs e)
        {
            MoveFormWithoutMouseAtTitleBar(sender, e);
        }

        private void MoveFormWithoutMouseAtTitleBar(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 1);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    }
}

