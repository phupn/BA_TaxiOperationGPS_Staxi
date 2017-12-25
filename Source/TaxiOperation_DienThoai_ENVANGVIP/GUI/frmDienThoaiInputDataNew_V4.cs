using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Femiani.Forms.UI.Input;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using DienThoai;
using System.Drawing.Drawing2D;
using Taxi.Entity;
using Taxi.Business.KhachDat;
using Taxi.Controls;
using System.Globalization;
using System.Configuration;
using Taxi.Controls.FastTaxis;
using Taxi.Services;
using Taxi.Utils.Enums;
using Taxi.Data.EnVang;
using System.Text.RegularExpressions;
using TaxiApplication;
using Taxi.Controls.Maps;
using Taxi.Controls.Base;

namespace Taxi.GUI
{
    /// <summary>
    ///  - Tach phan validate thong tin nhập 
    ///  - Tách phần báo lỗi validate
    /// </summary>
    /// <Modified>        
    ///	Name		Date		    Comment 
    /// Congnt      07/14            Update
    /// Phupn       22/3/2012           Update
    /// </Modified> 
    public partial class frmDienThoaiInputDataNew_V4 : FormBase
    {
        #region ==========================Init=================================

        // Gửi sự kiện có cuộc gọi mới. Hiển thị thông báo có cuộc gọi mới có chuyển tới
        public delegate void HienThiCuocMoiEventHandler(object sender, EventArgs e);
        public event HienThiCuocMoiEventHandler HienThiCuocMoiEvent;
        public void OnHienThiCuocMoiEvent(EventArgs e)
        {
            if (HienThiCuocMoiEvent != null)
                HienThiCuocMoiEvent(new object(), e);
        }
        //-------------------------------------------------------

        public double G_ViDo = 0;
        public double G_KinhDo = 0;
        public string LenhDienThoai_Current;
        public enum LenhDienThoaiKieu
        {
            DaMoi = 1,  // đã mời
            GapXe = 2,  // gặp xe
            MayBan = 3,  // máy bận
            KhongLienLacDuoc = 4, // Không LL được
            HuyXe = 5,    // Hủy xe
        }
        private string g_LoaiXeMacDinh = "KIA";
        //private string g_IDLoaiXe;
        private CuocGoi g_CuocGoi;
        private bool g_CloseForm = false;
        /// <summary>
        /// cuộc gọi có GPS hay không
        /// </summary>
        private bool g_GPS = false;
        /// <summary>
        /// Cuộc gọi đã vượt mức giới hạn cho phép hoặc không được phép sử dụng GPS
        /// g_CGLimit = true : giới hạn, không được phép sử dụng GPS
        /// </summary>
        private bool g_CGLimit = false; //
        private AutoCompleteEntryCollection g_ListDataAutoComplete;
        private int G_BanKinhTimXe = 0;
        private List<DMVung_GPSEntity> G_DMVung_GPS;
        private string G_DiaChiFull = string.Empty;
        private string[] G_Address = new string[2];
        private int[] arrINum = new int[4];//1[~] 2[/] 3[-] 4[ ]
        private string[] arrRegex = new string[] { "N", "/", "-", " " };
        public CuocGoi GetCuocGoi
        {
            get { return g_CuocGoi; }
        }
        public string g_VungMacDinh { set; get; }
        public List<string> g_ListSoHieuXe { set; get; }
        private string g_XeNhan = "";
        private string g_XeDon = "";
        private int g_XeDonLength = 0;
        private string XeYeuThich = string.Empty;
        public bool noteChanged = true;
        public bool lenhDHChanged = true;

        private string MSG_CoXeDangNghi = string.Empty;
        private bool g_DiaChiTra_TimKiem;
        private float g_DiaChiTra_Lat;
        private float g_DiaChiTra_Lng;

        #endregion

        #region =======================Constructor=============================
        /// <summary>
        /// Khởi tạo màn hình nhập điện thoại
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmDienThoaiInputDataNew_V4(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            this.SetDesktopLocation(440, 100);
            AnHienControl(cuocGoi);
            SetGiaTriControl(cuocGoi);
            //---------------------Set giá trị biến toàn cục----------------------------
            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            g_CGLimit = CGLimit;
            G_DMVung_GPS = DMVung_GPS;
            //---------------------Initial Map----------------------------
            ConfigMap();
        }

        /// <summary>
        /// Ẩn hiện control trên form
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/11/2015   created
        /// </Modified>
        private void AnHienControl(CuocGoi cuocGoi)
        {
            var visible = Global.ChoPhepDienThoaiNhapXe;
            pnlDieuXe.Visible = visible;
            if(!visible)
            {
                this.Height = this.Height - pnlDieuXe.Height;
                pnlLenh.Location = new Point(pnlLenh.Location.X, pnlLenh.Location.Y - pnlDieuXe.Height);
                pnlActionButton.Location = new Point(pnlActionButton.Location.X, pnlActionButton.Location.Y - pnlDieuXe.Height);
                panel2.Height = panel2.Height - pnlDieuXe.Height; 
            }
        }

        /// <summary>
        /// Điền giá trị lên các control của form
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/11/2015   created
        /// </Modified>
        private void SetGiaTriControl(CuocGoi cuocGoi)
        {
            editSoLuongXe.TextBox.Text = "1";
            lblDisplayXeDeCu.Text = "";
            lblLenhLaiXe.Text = "";
            lblGhiChuLX.Text = "";
            chkGoiTaxi.Checked = true;
            ThayDoiTrangThaiNhomControl(cuocGoi);
            XuLyThongTinLenhLaiXe(cuocGoi);
        }
        #endregion

        #region ===================Load Form-Set Data==========================

        private void frmDienThoaiInputDataMaiLinh_Load(object sender, EventArgs e)
        {
            EnableControl();
            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
            txtDiaChiTra.Items = g_ListDataAutoComplete;
           
            g_CloseForm = false;
            lblCoCuocGoiMoi.Visible = false;
            //txtDiaChiDonKhach.A();
            txtDiaChiDonKhach.Select();
            txtDiaChiDonKhach.Focus();
            SetDuLieuLenForm(g_CuocGoi);
            if (g_CuocGoi.FT_IsFT)
            {
                chkGoiKhieuNai.Visible = false;
                chkGoiLai.Visible = false;
                chkGoiDichVu.Visible = false;
            }
        }

        /// <summary>
        /// Set ẩn hiện control
        /// </summary>
        private void EnableControl()
        {
            if (Global.MoHinh == MoHinh.TongDaiMini)
            {
                
                editGhiChu.Visible = false;
            }
            else
            {
                
                editGhiChu.Visible = true;
            }
        }

        /// <summary>
        /// Dia chi de lay GPS
        /// </summary>
        /// <param name="diaChi"></param>
        /// <returns></returns>
        private string getDiaChiChuan(string diaChi)
        {
            string strDiaChi = diaChi;
            G_DiaChiFull = StringTools.TrimSpace(diaChi);
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

        private void ValidateDiaChiNhap(string strValue)
        {
            if (strValue.Length > 0)
                {
                    string returnValue = string.Empty;
                    // Giải thích viết trước
                    arrINum[2] = strValue.IndexOf(arrRegex[2]);//Có ghi giải thích hay không
                    if (arrINum[2] > 0)
                    {                        
                        returnValue = strValue.Substring(0,arrINum[2]);// phần trước ghi chú
                        G_Address[1] = strValue.Substring(arrINum[2]);// phần ghi chú
                        arrINum[3] = returnValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        if (arrINum[3] > 0)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            G_Address[0] = StringTools.FormatBuilding(strValue.Substring(0, arrINum[3])) + returnValue;
                        }
                    }
                    else
                    {
                        returnValue = strValue;
                        arrINum[3] = strValue.IndexOf(arrRegex[3]);//Có Số nhà hay ko
                        if (arrINum[3] > 0)
                        {
                            returnValue = returnValue.Substring(arrINum[3] + 1);
                            G_Address[0] = StringTools.FormatBuilding(strValue.Substring(0, arrINum[3])) + returnValue;
                        }
                    }
                }
        }

        /// <summary>
        /// hàm thực hiện set dữ liệu lên form
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void SetDuLieuLenForm(CuocGoi cuocGoi)
        {
            if (cuocGoi != null)
            {
                string diaChi = cuocGoi.DiaChiDonKhach;

                txtDiaChiDonKhach.Text = diaChi;
                txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach;
                lblInfo.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber, cuocGoi.ThoiDiemGoi);
                SetThongTinLoaiCuocGoi(cuocGoi.KieuCuocGoi);
                //if (cuocGoi.FT_IsFT)
                    SetThongTinLoaiXe_FastTaxi(cuocGoi.LoaiXe);
                if (cuocGoi.SoLuong > 0)
                {
                    editSoLuongXe.TextBox.Text = cuocGoi.SoLuong.ToString();
                }
                
                // neeus cuoc goi chua chuyen mot kenh nao va so lan goi >= 2 thi dat ma dinh la cuoc goi lai
                if (cuocGoi.SoLanGoi >= 1 || cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                {
                    chkGoiLai.Checked = true;
                    //editVung.Text = "2";
                }
                
                editLenhDienThoai.Text = cuocGoi.LenhDienThoai;
                editGhiChu.Text = cuocGoi.GhiChuDienThoai;
                lblGhiChuLX.Text = cuocGoi.GhiChuLaiXe;
                if(Global.ChoPhepDienThoaiNhapXe)
                {
                    txtXeNhan.Text = cuocGoi.XeNhan;
                    txtXeDon.Text = cuocGoi.XeDon;
                }
                
               
                lblLenhLaiXe.Text = cuocGoi.MH_LenhLaiXe;
                //if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioiKhac)
                if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    if (cuocGoi.LoaiCuocKhach == Utils.LoaiCuocKhach.ChoKhachDuongDai)
                    {
                        chkMGDuongDai.Checked = true;
                    }
                    else
                    {
                        chkMGDuongDai.Checked = false;
                    }
                    chkMGDuongDai.Enabled = true;
                }
                else
                {
                    chkMGDuongDai.Enabled = false;
                }
                if (g_CGLimit == false && ThongTinCauHinh.GPS_TrangThai)
                {
                    //Cuộc gọi đối tác
                    if (string.IsNullOrEmpty(cuocGoi.MaDoiTac) && cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                    {
                        if (cuocGoi.GPS_KinhDo != 0 && cuocGoi.GPS_ViDo != 0)
                        {
                            btnGPS.Enabled = true;
                            btnGPS.Enabled = true;
                            g_CGLimit = false;
                        }
                        else
                        {
                            btnGPS.Enabled = false;
                            btnGPS.Enabled = false;
                            g_CGLimit = true;
                        }
                    }

                    if (!string.IsNullOrEmpty(cuocGoi.MaDoiTac) && cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                    {
                        ThongTinKhachHangVip thongTin = CuocGoi.DIENTHOAI_LayXeUaThich_EnVangVIP(cuocGoi.IDCuocGoi);
                        if(!string.IsNullOrEmpty(thongTin.Location))
                        {
                            var location = thongTin.Location.Split(",".ToCharArray());
                            cuocGoi.GPS_ViDo = Convert.ToDouble(location[0]);
                            cuocGoi.GPS_KinhDo = Convert.ToDouble(location[1]);
                        }
                        XeYeuThich = thongTin.PrivateCode_Favourite;
                        lblDisplayXeDeCu.Text = XeYeuThich;
                    }

                    lbl_FTAllowCall.Text = string.Empty;
                    lbl_FTAllowCall.Visible = false;
                    // là cuốc FastTaxi
                    if (cuocGoi.FT_IsFT)
                    {
                        IsFastTaxi.Visible = true;
                        lblInfo.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber,
                            cuocGoi.FT_SendDate);
                        //lblInfo.Text = string.Format("{0} {1:HH:mm dd/MM}",cuocGoi.PhoneNumber,cuocGoi.FT_SendDate);
                        label7.Text = string.Format("{0:HH:mm}", cuocGoi.FT_Date);
                        btnGPS.Visible = true;
                        btnRemoveGPS.Visible = false;
                        btnDatHen.Visible = false;
                        label7.Visible = true;
                        if (ProcessFastTaxi.TinhQuangDuong(cuocGoi.FT_Cust_Lat, cuocGoi.FT_Cust_Lng,
                            (float) cuocGoi.GPS_ViDo,
                            (float) cuocGoi.GPS_KinhDo) > ThongTinCauHinh.FT_SoKM)
                        {
                            picWarning.Visible = true;
                            MainMap.addMarkerCustomer2(cuocGoi.FT_Cust_Lng, cuocGoi.FT_Cust_Lat, "");
                        }
                        else picWarning.Visible = false;

                        if (!cuocGoi.FT_AllowCall)
                        {
                            lbl_FTAllowCall.Text = "Khách không muốn nhận cuộc gọi";
                            lbl_FTAllowCall.Visible = true;
                        }
                    }
                    else
                    {
                        label7.Visible = false;
                        btnGPS.Visible = true;
                        btnRemoveGPS.Visible = true;
                    }

                    if (cuocGoi.DanhSachXeDeCu != null && cuocGoi.DanhSachXeDeCu.Length > 0 )
                    {
                        if (!cuocGoi.DanhSachXeDeCu.EndsWith(XeYeuThich))
                        {
                            lblDisplayXeDeCu.Text = cuocGoi.DanhSachXeDeCu + "." + XeYeuThich;
                        }
                        else
                        {
                            lblDisplayXeDeCu.Text = cuocGoi.DanhSachXeDeCu;
                        }
                    }

                    int solan = cuocGoi.SoLanGoi;
                    txtSoLan.Text = solan.ToString();
                    if (solan == 1)
                        txtSoLan.BackColor = Color.Yellow;
                    else if (solan >= 2)
                        txtSoLan.BackColor = Color.Red;
                    //Set Marker nếu có tọa độ.
                    if (cuocGoi.GPS_KinhDo != 0 && cuocGoi.GPS_ViDo != 0)
                    {
                        G_KinhDo = cuocGoi.GPS_KinhDo;
                        G_ViDo = cuocGoi.GPS_ViDo;

                        MainMap.addMarkerCustomer4(cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo, diaChi, false);


                        if (cuocGoi.Vung > 0)
                        {
                            editVung.TextBox.Text = cuocGoi.Vung.ToString();
                        }
                        else
                        {
                            setKenhByDiaChi((float)cuocGoi.GPS_ViDo, (float)cuocGoi.GPS_KinhDo);
                        }

                        //set marker xe de cu
                        if (!string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu) && !string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu_TD))
                        {
                            setMarkerDSXeDeCu(cuocGoi.DanhSachXeDeCu, cuocGoi.DanhSachXeDeCu_TD);
                            g_DSXeDeCu = cuocGoi.DanhSachXeDeCu;
                            g_DSXeDeCu_TD = cuocGoi.DanhSachXeDeCu_TD;
                        }
                        else
                        {
                            getXeByToaDo(cuocGoi.GPS_KinhDo, cuocGoi.GPS_ViDo);
                        }
                        //set market xe nhan
                        if (!string.IsNullOrEmpty(cuocGoi.XeNhan) && !string.IsNullOrEmpty(cuocGoi.XeNhan_TD))
                        {
                            setMarkerDSXeNhan(cuocGoi.XeNhan, cuocGoi.XeNhan_TD);
                        }
                    }
                    else
                    {
                        if (cuocGoi.Vung > 0)
                        {
                            editVung.TextBox.Text = cuocGoi.Vung.ToString();
                        }
                        else
                            editVung.TextBox.Text = g_VungMacDinh;
                    }
                    g_GPS = cuocGoi.CoGPS;
                }
                else
                {
                    g_GPS = false;
                    if (cuocGoi.Vung > 0)
                    {
                        editVung.TextBox.Text = cuocGoi.Vung.ToString();
                    }
                    else
                        editVung.Text = g_VungMacDinh;
                }
                LenhDienThoai_Current = cuocGoi.LenhDienThoai;
                g_DiaChiTra_Lng = cuocGoi.GPS_KinhDo_Tra;
                g_DiaChiTra_Lat = cuocGoi.GPS_ViDo_Tra;
                
            }
        }

        private void SetControlForKhongXe()
        {
            chkGoiTaxi.Enabled = false;
            chkGoiLai.Enabled = false;
            chkGoiKhieuNai.Enabled = false;
            chkGoiDichVu.Enabled = false;
            //chkGoiHoiDam.Enabled = false;
            chkGoiKhac.Enabled = false;
            //txtDiaChiDonKhach .Enabled = !chkKhongXeXinLoi.Enabled;
            editLenhDienThoai.Enabled = true;
            editGhiChu.Enabled = false;
            //chkXe4.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkXe7.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkKhongXe.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkXeLIMO7.Enabled = !chkKhongXeXinLoi.Enabled;
            //editSoLuongXe.Enabled = !chkKhongXeXinLoi.Enabled;
            //editVung.Enabled = !chkKhongXeXinLoi.Enabled;
            //chkKhachHoan.Enabled = !chkKhongXeXinLoi.Enabled;


        }

        private void SetThongTinLoaiCuocGoi(KieuCuocGoi kieuCuocGoi)
        {
            if (kieuCuocGoi == KieuCuocGoi.GoiTaxi)
            {
                chkGoiTaxi.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                chkGoiLai.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiKhieuNai)
            {
                chkGoiKhieuNai.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiDichVu)
            {
                chkGoiDichVu.Checked = true;
            }
            else if (kieuCuocGoi == KieuCuocGoi.GoiKhac)
            {
                chkGoiKhac.Checked = true;
            }
        }
        /// <summary>
        /// hàm thực hiện set thông tin loại xe
        /// Input : 
        ///     - KIA,VIO,INO,LIMO
        /// Ouput :
        ///      Set lên check box
        /// </summary>
        /// <param name="p"></param>
        private void SetThongTinLoaiXe(string loaiXe)
        {
            if (loaiXe != null && loaiXe.Length > 0)
            {
                string strLoaiXe = "";
                strLoaiXe = loaiXe;
                if (loaiXe.Contains("4c"))
                {
                    chk4Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("4c,", "");
                }
                if (loaiXe.Contains("7c"))
                {
                    chk7Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Replace("7c,", "");
                }
                txtLoaiXe.Text = strLoaiXe;
            }
        }

        private void SetThongTinLoaiXe_FastTaxi(string loaiXe)
        {
            if (loaiXe != null && loaiXe.Length > 0)
            {
                string strLoaiXe = "";
                strLoaiXe = loaiXe;
                if (loaiXe.Contains("4"))
                {
                    chk4Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Remove(0,2);
                }
                if (loaiXe.Contains("7"))
                {
                    chk7Cho.Checked = true;
                    strLoaiXe = strLoaiXe.Remove(0, 2);
                }
                txtLoaiXe.Text = strLoaiXe;
            }
        }

        /// <summary>
        /// Nhập kênh tự động theo địa chỉ.
        /// </summary>
        /// <param name="viDo">kinh độ của địa chỉ khách</param>
        /// <param name="kinhDo">Vi độ của địa chỉ khách</param>
        private void setKenhByDiaChi(float viDo, float kinhDo)
        {
            int vung = getKenhByDiaChi((float)viDo, (float)kinhDo);
            if (vung > 0)
                editVung.Text = vung.ToString();
            else
                editVung.Text = g_VungMacDinh;
        }

        /// <summary>
        /// Thay đổi trạng thái cho phép sử dụng của các control thay đổi thông tin nhận xe
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        private void ThayDoiTrangThaiNhomControl(CuocGoi cuocGoi)
        {
            var enable = false ;
            if ((cuocGoi.DaGuiDSXeNhan == null || cuocGoi.DaGuiDSXeNhan == 0) && (cuocGoi.CenterConfirm == null || cuocGoi.CenterConfirm == 0)) enable = true;
            txtXeNhan.Enabled = enable;
            txtDiaChiDonKhach.Enabled = enable;
            txtDiaChiTra.Enabled = enable;
            txtLoaiXe.Enabled = enable;
            chk4Cho.Enabled = enable;
            chk7Cho.Enabled = enable;
            editSoLuongXe.Enabled = enable;
            editVung.Enabled = enable;
            chkGoiKhac.Enabled = enable;
            chkGoiTaxi.Enabled = enable;
            chkGoiLai.Enabled = enable;
            chkGoiKhieuNai.Enabled = enable;
            chkGoiDichVu.Enabled = enable;
            chkDaDon.Enabled = !string.IsNullOrEmpty(cuocGoi.XeDon);
        }

        /// <summary>
        /// Xử lý thông tin xe đón lấy từ server
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        public void XuLyThongTinXeDon(CuocGoi cuocGoi)
        {
            ThayDoiTrangThaiNhomControl(cuocGoi);
            txtXeDon.Text = cuocGoi.XeDon;
        }

        /// <summary>
        /// Xử lý thông tin lệnh lái xe khi dữ liệu trên lưới được thay đổi.
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/1/2015   created
        /// </Modified>
        public void XuLyThongTinLenhLaiXe(CuocGoi cuocGoi)
        {
            lblLenhLaiXe.Text = cuocGoi.MH_LenhLaiXe;
            chkDaDon.Checked = cuocGoi.MH_LenhLaiXe == "Đã đón" || cuocGoi.MH_LenhLaiXe == "Đã kết thúc";
        }

        #endregion        

        #region ======================Validation Form==========================
        /// <summary>
        /// hàm thực hiện validate thông tin form nhập
        /// co cuoc goi truyen vao
        /// </summary>
        /// <returns></returns>
        private EnVangManagement.BangMaValidate ValidateFormNhap(CuocGoi cuocGoi)
        {
            if (chkGoiTaxi.Checked)
            {
                g_XeDon = StringTools.ConvertToChuoiXeNhanChuan(txtXeDon.Text);
                g_XeNhan = StringTools.ConvertToChuoiXeNhanChuan(txtXeNhan.Text);
                //g_XeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(txtXeDenDiem.Text);
                if (g_XeNhan != null && g_XeNhan.Length > 0)
                {
                    MSG_CoXeDangNghi = string.Empty;

                    var restingVehicles = EnVangManagement.CheckRestingVehicle(txtXeNhan.Text);

                    if (!EnVangManagement.ValidateNhieuSoHieuXe(txtXeNhan.Text))
                    {
                        return EnVangManagement.BangMaValidate.XeNhanKhongDungDinhDang;
                    }
                    else if (!KiemTraXeNhan(g_XeNhan))
                    {
                        return EnVangManagement.BangMaValidate.NhapChinhXacXe;
                    }
                    else if (StringTools.KiemTraTrungLapXeChay(g_XeNhan))
                    {
                        return EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                    else if (!string.IsNullOrEmpty(restingVehicles))
                    {
                        MSG_CoXeDangNghi = restingVehicles;
                        return EnVangManagement.BangMaValidate.CoXeDangNghi;
                    }
                }
                // Kiểm tra xe đón có được nhập không
                if (g_XeDon != null && g_XeDon.Length > 0)
                {
                    // Kiểm tra có trùng lặp xe đón
                    if (StringTools.KiemTraTrungLapXeChay(g_XeDon))
                    {
                        return EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                }
            }
            // Không nhập địa chỉ
            string diaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            if (diaChi.Length <= 0 && !chkGoiKhac.Checked && !chkGoiKhieuNai.Checked && !chkGoiDichVu.Checked)
            {
                txtDiaChiDonKhach.Focus();
                return EnVangManagement.BangMaValidate.NhapThongTinDiaChi;
            }
            // Không chọn một loại cuộc gọi nào
            if ((chkGoiTaxi.Checked == false) && (chkGoiLai.Checked == false) && (chkGoiKhieuNai.Checked == false) && (chkGoiDichVu.Checked == false) && (chkGoiKhac.Checked == false))
            {
                chkGoiTaxi.Focus();
                return EnVangManagement.BangMaValidate.NhapMotLoaiCuocGoi;
            }

            if (chkGoiTaxi.Checked || chkGoiLai.Checked)
            {
                #region Kenh
                //Kenh
                //byte kenh = 0;
                try
                {
                    string kenh = editVung.Text.Trim();
                    if (editVung.Text.Trim() == "" || !CheckVungNamTrongVungCauHinh(Convert.ToInt16(kenh)))  // kiểm tra kênh có nằm trong vùng quy đinh.
                    {
                        editVung.Focus();
                        return EnVangManagement.BangMaValidate.NhapKenh;
                    }
                }
                catch (Exception ex)
                {
                    editVung.Focus();
                    return EnVangManagement.BangMaValidate.NhapKenh;
                }


                #endregion Kenh
                if (chkGoiTaxi.Checked)
                {
                    #region So luong xe
                    // Kiểm tra số lượng xe
                    byte soLuongXe = 0;
                    try
                    {
                        soLuongXe = Convert.ToByte(editSoLuongXe.Text);
                    }
                    catch (Exception ex)
                    {
                        soLuongXe = 0;
                    }
                    if (soLuongXe == 0)
                    {
                        editSoLuongXe.Focus();
                        return EnVangManagement.BangMaValidate.NhapSoLuongXe;
                    }
                    #endregion So luong xe
                }
            }
            if (!chkGoiKhac.Checked && cuocGoi.GetLenhDienThoaiCurrent() == EnVangManagement.LENH_HUYXE)
            {
                return EnVangManagement.BangMaValidate.DienThoaiDaHuy;
            }
            if (chkDaGiaiQuyet.Checked && cuocGoi.XeNhan.Trim().Length>0)
            {
                return EnVangManagement.BangMaValidate.DaGiaiQuyet;
            }
            return EnVangManagement.BangMaValidate.ValidateSuccess;
        }
        
        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeNhan(string xeNhan)
        {
            g_XeDonLength = g_XeDon.Split(".".ToCharArray()).Length;
            var existInDB = EnVangManagement.KiemTraPTDSThuocDSKhac(xeNhan, g_ListSoHieuXe);
            var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(xeNhan, ".");
            var existInOnline = !string.IsNullOrEmpty(privateCodes);
            return existInDB && existInOnline;
        }

        

        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (!string.IsNullOrEmpty(ThongTinCauHinh.CacVungTongDai))
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

        /// <summary>
        /// hàm hiển thị thông báo yêu cầu nhập dữ liệu
        /// </summary>
        /// <param name="maValidate"></param>
        private void HienThiThongBao(EnVangManagement.BangMaValidate maValidate)
        {
            if (maValidate == EnVangManagement.BangMaValidate.ValidateSuccess)
            {
                lblThongBao.Text = EnVangManagement.MSG_VALIDATESUCCESS;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapThongTinDiaChi)
            {
                lblThongBao.Text = EnVangManagement.MSG_1_NHAPTHONGTINDIACHI;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapMotLoaiCuocGoi)
            {
                lblThongBao.Text = EnVangManagement.MSG_2_NHAPTHONGTINLOAICUOCGOI;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapSoLuongXe)
            {
                lblThongBao.Text = EnVangManagement.MSG_3_NHAPSOLUONGXE;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapKenh)
            {
                lblThongBao.Text = EnVangManagement.MSG_4_NHAPKENH;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.ChonKhongXeXinLoiKhach)
            {
                lblThongBao.Text = EnVangManagement.MSG_5_CHONKHONGXE;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.Msg6_KhongTimThayDCBanDo)
            {
                lblThongBao.Text = EnVangManagement.MSG_6_BANDO;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.Msg7_ChuaNhapKenh)
            {
                lblThongBao.Text = EnVangManagement.MSG_7_CHUANHAPKENH;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.Msg8_TaiBanDo)
            {
                lblThongBao.Text = EnVangManagement.MSG_8_TAIBANDO;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.Msg9_ChonKenhTK)
            {
                lblThongBao.Text = EnVangManagement.MSG_9_CHONKENHTK;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.Msg10_ChonLoaiXe)
            {
                lblThongBao.Text = EnVangManagement.MSG_12_CHONLOAIXE;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapChinhXacXe)
            {
                lblThongBao.Text = EnVangManagement.MSG_13_NHAPCHINHXACXE;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan)
            {
                lblThongBao.Text = EnVangManagement.MSG_14_NHAPXEDONTHUOCXENHAN;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.DienThoaiDaHuy)
            {
                lblThongBao.Text = EnVangManagement.MSG_15_DienThoaiDaHuy;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.DaGiaiQuyet)
            {
                lblThongBao.Text = EnVangManagement.MSG_16_DaGiaiQuyet;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.XeNhanKhongDungDinhDang)
            {
                lblThongBao.Text = EnVangManagement.MSG_17_XeNhanKhongDungDinhDang;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.CoXeDangNghi)
            {
                lblThongBao.Text = MSG_CoXeDangNghi;
            }
        }

        /// <summary>
        /// hàm thực hiện đặt cấu hình các 
        /// control khi có cuộc gọi là taxi
        /// </summary>
        private void HienThiControl_GoiTaxi()
        {
         
            if (chkGoiTaxi.Checked)
            {
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;
                EnableControl();
            }   
        }

        /// <summary>
        /// thay đổi dữ liệu hàm checkbox gọi lại
        /// </summary>
        private void HienThiControl_GoiLai()
        {
            if (chkGoiLai.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;
            }
                // loai xe
            //chkXeKia.Enabled = !chkGoiLai.Checked;
            //chkXeVios.Enabled = !chkGoiLai.Checked;
            //chkCAR.Enabled = !chkGoiLai.Checked;
            editSoLuongXe.Enabled = !chkGoiLai.Checked;
        }

        private void HienThiControl_GoiKhieuNai()
        {
            if (chkGoiKhieuNai.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;
            }
            //chkXeKia.Enabled = !chkGoiKhieuNai.Checked;
            //chkXeVios.Enabled = !chkGoiKhieuNai.Checked;
            //chkCAR.Enabled = !chkGoiKhieuNai.Checked;
            chk4Cho.Enabled = !chkGoiKhieuNai.Checked;
            chk7Cho.Enabled = !chkGoiKhieuNai.Checked;
            txtLoaiXe.Enabled = !chkGoiKhieuNai.Checked;
            editSoLuongXe.Enabled = !chkGoiKhieuNai.Checked;
            editVung.Enabled = !chkGoiKhieuNai.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        private void HienThiControl_GoiDichVu()
        {
            if (chkGoiDichVu.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai .Checked = false;
                chkGoiKhac.Checked = false;
            }
            chk4Cho.Enabled = !chkGoiDichVu.Checked;
            chk7Cho.Enabled = !chkGoiDichVu.Checked;
            txtLoaiXe.Enabled = !chkGoiDichVu.Checked;
            editSoLuongXe.Enabled = !chkGoiDichVu.Checked;
            editVung.Enabled = !chkGoiDichVu.Checked;
        }



        private void HienThiControl_GoiKhac()
        {
            if (chkGoiKhac.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
            }
            chk4Cho.Enabled = !chkGoiKhac.Checked;
            chk7Cho.Enabled = !chkGoiKhac.Checked;
            txtLoaiXe.Enabled = !chkGoiKhac.Checked;
            editSoLuongXe.Enabled = !chkGoiKhac.Checked;
            editVung.Enabled = !chkGoiKhac.Checked;
        }
        /// <summary>
        /// <Public>hàm thực hiện hiển thị có cuộc gọi mới
        /// </summary>
        public void HienThiThongBaoCoCuocGoiMoi()
        {
            lblCoCuocGoiMoi.Visible = true;

        }

        private void setVung(string vung)
        {
            editVung.Focus();
            editVung.Text = vung;
        }
        #endregion 
        
        #region =======================Get Data Form===========================
        /// <summary>
        /// hàm cập nhật thông tin cuộc gọi mới nhập vào
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void GetThongTinNhapMoi(ref CuocGoi cuocGoi)
        {
                       
            cuocGoi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            lenhDHChanged = cuocGoi.LenhDienThoai != editLenhDienThoai.Text;
            cuocGoi.LenhDienThoai = StringTools.TrimSpace(editLenhDienThoai.Text);
            noteChanged = cuocGoi.GhiChuDienThoai != editGhiChu.Text;
            cuocGoi.GhiChuDienThoai = StringTools.TrimSpace(editGhiChu.Text);
            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
            cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
            
            if (chkMGDuongDai.Checked)
            {
                cuocGoi.LoaiCuocKhach = Utils.LoaiCuocKhach.ChoKhachDuongDai;
            }
            else
            {
                cuocGoi.LoaiCuocKhach = Utils.LoaiCuocKhach.ChoKhachNoiTinh;
            }
            if (chkGoiTaxi.Checked)
            {
                if (cuocGoi.Vung != Convert.ToByte(editVung.Text) && Convert.ToByte(editVung.Text) > 0)
                {
                    cuocGoi.FT_Status = Enum_FastTaxi_Status.ChuyenSangDam;
                }
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiTaxi;
                cuocGoi.LoaiXe = GetThongTinLoaiXeChon_FastTaxi();
                cuocGoi.SoLuong = Convert.ToByte(editSoLuongXe.Text);
                if (editVung.Text.Trim() != "")
                {
                    cuocGoi.Vung = Convert.ToByte(editVung.Text);
                }
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
                cuocGoi.SoLanGoi = 0;
                if (Global.ChoPhepDienThoaiNhapXe)
                {
                    cuocGoi.XeNhan = g_XeNhan;
                    cuocGoi.XeDon = g_XeDon;
                }
                cuocGoi.DanhSachXeDeCu = lblDisplayXeDeCu.Text;
                if (cuocGoi.XeDon != null && cuocGoi.XeDon.Length > 0)
                {
                    if (g_XeDonLength == cuocGoi.SoLuong && chkDaDon.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        TaxiApplication.ServiceEnVang.EnVangProcess.SendConfirmDone(cuocGoi, 1);
                    }
                }
             
            }
            else if (chkGoiLai.Checked)
            {
                cuocGoi.SoLuong = Convert.ToByte(editSoLuongXe.Text);
                cuocGoi.LoaiXe = GetThongTinLoaiXeChon_FastTaxi();
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiLai;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
            }
            else if (chkGoiKhieuNai.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhieuNai;
            }
            else if (chkGoiDichVu.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiDichVu;
            }
            else if (chkGoiKhac.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
            }
            
                if (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai || cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiDichVu)
                {
                    g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
                else
                {
                    //if (g_CuocGoi.XeNhan == "")
                    //    g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    //else
                    //    lblThongBao.Text = "Chỉ được kết thúc cuộc gọi Khiếu nại/Dịch vụ";
                }
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.IsVisible && g_GPS)
                {
                    cuocGoi.GPS_ViDo = MainMap.MarkerCustomer.Position.Lat;
                    cuocGoi.GPS_KinhDo = MainMap.MarkerCustomer.Position.Lng;
                    cuocGoi.DanhSachXeDeCu = g_DSXeDeCu;
                    cuocGoi.DanhSachXeDeCu_TD = g_DSXeDeCu_TD;
                }
                else
                {
                    cuocGoi.GPS_ViDo = 0;
                    cuocGoi.GPS_KinhDo = 0;
                    cuocGoi.DanhSachXeDeCu = "";
                    cuocGoi.DanhSachXeDeCu_TD = "";
                }
                if (chkCipucha.Checked)
                {
                    cuocGoi.KieuKhachHangGoiDen = KieuKhachHangGoiDen.KhachHangMoiGioiKhac;
                }
                cuocGoi.CoGPS = g_GPS;
                cuocGoi.DiaChiTraKhach=txtDiaChiTra.Text;
                //Đã xin lỗi khách và kết thúc luôn
                if (cuocGoi.LenhDienThoai == EnVangManagement.LENH_DAXINLOI)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                }
                if (this.g_DiaChiTra_TimKiem)
                {
                    cuocGoi.GPS_KinhDo_Tra = this.g_DiaChiTra_Lng;
                    cuocGoi.GPS_ViDo_Tra = this.g_DiaChiTra_Lat;
                }
         
        }

        private string GetThongTinLoaiXeChon()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe = "4c,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7c,";
            }
            loaiXe += txtLoaiXe.Text.Trim();
            return loaiXe;
            //if (chkXeVios.Checked)
            //{
            //    loaiXe += DSLoaiXe.VIOS + ",";
            //}
            //if (chkXeKia.Checked)
            //{
            //    loaiXe += DSLoaiXe.MORNING + ",";
            //}
            //if (chkCAR.Checked)
            //{
            //    loaiXe += DSLoaiXe.CARENS + ",";
            //}
            //if (chkCAR.Checked)
            //{
            //    loaiXe += DSLoaiXe.INOVA + ",";
            //}
            //if (loaiXe.Length > 0)
            //{
            //    loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            //}
            
        }

        private string GetThongTinLoaiXeChon_GetXeDeCu()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe += "4,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7,";
            }
            if (loaiXe.Length > 0)
            {
                loaiXe = loaiXe.Substring(0, loaiXe.Length - 1);
            }
            return loaiXe;
        }

        private string GetThongTinLoaiXeChon_FastTaxi()
        {
            string loaiXe = string.Empty;
            if (chk4Cho.Checked)
            {
                loaiXe = "4,";
            }
            if (chk7Cho.Checked)
            {
                loaiXe += "7 ";
            }
            loaiXe += txtLoaiXe.Text.Trim();
            return loaiXe;
        }

        /// <summary>
        /// function get kenh vung theo dia chi (toa do)
        /// </summary>
        /// <param name="LatDes"></param>
        /// <param name="LngDes"></param>
        /// <returns></returns>
        private int getKenhByDiaChi(float LatDes, float LngDes)
        {
            int numVung = 0;
            string[] arrToaDoVung;
            string[] ToaDo;
            string[] ToaDoCuoi;
            float[] x = new float[2], y = new float[2];
            foreach (DMVung_GPSEntity DMVung_GPS in G_DMVung_GPS)
            {
                if (string.IsNullOrEmpty(DMVung_GPS.ToaDoVung)) continue;
		        
                arrToaDoVung = DMVung_GPS.ToaDoVung.Split('-');// danh sach cac diem thuoc vung GPS
                if (arrToaDoVung.Length <= 0) continue;

                int length = arrToaDoVung.Length - 1;
                int cn = 0;
                for (int i = 0; i < arrToaDoVung.Length - 1; i++)
                {
                    ToaDo = arrToaDoVung[i].Split(';');                    
                    x[0] = float.Parse(ToaDo[1]);// KD
                    y[0] = float.Parse(ToaDo[0]);//VD

                    ToaDoCuoi = arrToaDoVung[i + 1].Split(';');
                    x[1] = float.Parse(ToaDoCuoi[1]);
                    y[1] = float.Parse(ToaDoCuoi[0]);

                    if (((x[0] <= LngDes) && (x[1] > LngDes)) || ((x[0] > LngDes) && (x[1] <= LngDes)))
                    {
                        double vt = (LngDes - x[0]) / (x[1] - x[0]);
                        if (LatDes < y[0] + vt * (y[1] - y[0]))
                            ++cn;
                    }
                }
                if ((cn & 1) > 0)
                {
                    G_BanKinhTimXe = DMVung_GPS.BanKinhTimXe;
                    if (G_BanKinhTimXe == 0)
                        G_BanKinhTimXe = ThongTinCauHinh.GPS_BKGioiHan;
                    numVung = DMVung_GPS.KenhVung;
                    break;
                }// 0 if even (out), and 1 if odd (in)
            }
            return numVung;
        }        

        #endregion        

        #region ========================Form Events============================

        /// <summary>
        /// Focus vào textbox và set selection start
        /// </summary>
        /// <param name="textBox">The text box.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/1/2015   created
        /// </Modified>
        private void FocusVaoTextBox(TextBox textBox)
        {
            textBox.Focus();
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            EnVangManagement.BangMaValidate maValidate = ValidateFormNhap(g_CuocGoi);
            HienThiThongBao(maValidate);
            if (maValidate == EnVangManagement.BangMaValidate.ValidateSuccess)
            {
                g_CloseForm = true;
                GetThongTinNhapMoi(ref g_CuocGoi);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                g_CloseForm = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnRemoveGPS_Click(object sender, EventArgs e)
        {
            if (g_CGLimit == false)
            {
                g_GPS = false;
                MainMap.ClearAllMarkers();
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
        }

        private void btnGPS_Click(object sender, EventArgs e)
        {
            try
            {
                if (g_CGLimit) return;
                string diaChiGPS = string.Empty;

                if (ThongTinCauHinh.GPS_TrangThai == true)
                {
                    if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();

                    string strDiaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                    //Kinh độ và vĩ độ đã gán sẵn theo địa chỉ
                    G_ViDo = txtDiaChiDonKhach.ViDo;
                    G_KinhDo = txtDiaChiDonKhach.KinhDo;
                    diaChiGPS = getDiaChiChuan(strDiaChi);

                    if (G_ViDo == 0 && G_KinhDo == 0)
                    {
                        if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.Position.Lat > 0)
                        {
                            G_ViDo = MainMap.MarkerCustomer.Position.Lat;
                            G_KinhDo = MainMap.MarkerCustomer.Position.Lng;
                        }
                        else
                        {
                            string toaDo = Taxi.Services.Service_Common.GetGeobyAddress(diaChiGPS, ThongTinCauHinh.GPS_TenTinh).Replace(',','.');
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo = Double.Parse(arrString[0], CultureInfo.InvariantCulture);
                                G_KinhDo = Double.Parse(arrString[1], CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                lblThongBao.Text = EnVangManagement.MSG_6_BANDO;
                            }
                        }
                    }
                    //txtDiaChiDonKhach.Text = G_DiaChiFull;
                    //txtTimXe.Text = diaChiGPS;
                    if (G_KinhDo == 0 && G_ViDo == 0)
                    {
                        g_GPS = false;
                        return;
                    }
                    else
                    {
                        g_GPS = true;
                        MainMap.addMarkerCustomer2(G_KinhDo, G_ViDo, diaChiGPS);
                        if(string.IsNullOrEmpty(txtDiaChiDonKhach.Text))
                        {
                            txtDiaChiDonKhach.Text = diaChiGPS;
                        }
                        //Nhập Kênh tự động theo địa chỉ vùng
                        setKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);

                        getXeByToaDo(G_KinhDo, G_ViDo);
                    }
                }   
                editVung.Select();
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show(ex.Message);
                lblThongBao.Text = EnVangManagement.MSG_10_BANDO;
                g_GPS = false;
            }
        }

        /// <summary>
        /// Determines if a Point is inside a polygon.
        /// </summary>
        /// <returns>Return True if the point is inside Polygon.</returns>
        public static bool IsInsidePolygon(PointF[] polygon, PointF point)
        {
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddPolygon(polygon);
                return gp.IsVisible(point.X, point.Y);
            }
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiTaxi();
            //if (chkGoiTaxi.Checked && ThongTinCauHinh.GPS_TrangThai)
            //{
            //    setMarker();
            //}
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiLai();
            if (chkGoiLai.Checked)
            {
                editLenhDienThoai.TextBox.Text = "gọi lại";
            }
            else
            {
                editLenhDienThoai.TextBox.Text = "";
            }
        }

        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhieuNai();
            editVung.TextBox.Text = "";
        }

        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiDichVu();
            editVung.TextBox.Text = "";
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhac();
            editVung.TextBox.Text = "";
        }

        private void editLenhDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (editLenhDienThoai.TextBox.Text.StartsWith("1"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_DAMOI;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("2"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_MAYBAN;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("3"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_KHONGNGHEMAY;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("4"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_KHONGNOIGI;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("5"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_DAMOI2;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("6"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_CHOSODT;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("h"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_HUYXE;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("t"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_TRUOTCHUA;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("o"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_KOTHAYXE;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("7"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_7_KhongXeXinLoiKhach;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("x"))
            {
                editLenhDienThoai.TextBox.Text = EnVangManagement.LENH_DADON;
            }
        }

        private void chkKhongXeXinLoi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkThemXeDeCu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiaChiDonKhach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtDiaChiTra.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDiaChiDonKhach.TextReturn != "")
                    new MessageBox.MessageBoxBA().Show("test");
            }
        }

        private void DatHen()
        {
            if (g_CuocGoi!=null && g_CuocGoi.FT_IsFT) return;
            int soLuongXe = 1;
            int vungKenh = 1;
            int.TryParse(editSoLuongXe.Text.Trim(), out soLuongXe);
            int.TryParse(editVung.Text.Trim(), out vungKenh);
            var c = this.GetCuocGoi;
            KhachDatBL objKhachDat = new KhachDatBL()
            {
                CreatedBy = ThongTinDangNhap.USER_ID,
                DiaChi = txtDiaChiDonKhach.Text.Trim(),
                SoDienThoai = g_CuocGoi.PhoneNumber,
                SoLuongXe = soLuongXe,
                ThoiDiemBatDau = c.FT_Date?? DateTime.Now,
                ThoiDiemKetThuc = c.FT_Date ?? DateTime.Now,
                LoaiXe = GetThongTinLoaiXeChon_FastTaxi(),
                ThoiDiemTiepNhan = c.FT_SendDate ?? DateTime.Now,
                VungKenh = vungKenh,
                SoPhutBaoTruoc = 10,
                GhiChu = "",
                IsLapLai = false,
                GioDon = (c.FT_Date ?? DateTime.Now).AddMinutes(10)
            };
            frmKhachDat formKhachDat = new frmKhachDat(objKhachDat, g_ListDataAutoComplete, false);

            if (formKhachDat.ShowDialog() == DialogResult.OK)
            {
                txtDiaChiDonKhach.Text = formKhachDat.GetKhachDat();
                editLenhDienThoai.Text = "KHÁCH ĐẶT";
                chkGoiKhac.Checked = true;
            }

        }

        /// <summary>
        /// Tìm kiếm theo địa chỉ
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        private void txtTimDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string diaChi = getDiaChiChuan(txtTimDiaChi.Text);
                if (!string.IsNullOrEmpty(diaChi))
                {
                    double viDo = 0;
                    double kinhDo = 0;
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                        kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                    }
                    else
                    {
                        g_GPS = false;
                        lblThongBao.Text = EnVangManagement.MSG_6_BANDO;
                        MainMap.ClearAllMarkers();
                    }
                    if (kinhDo == 0 && viDo == 0)
                        return;

                    MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi);
                }
                else
                {
                    lblThongBao.Text = EnVangManagement.MSG_19_PhaiNhapDiaChi;
                }
            }
        }
        private void picDiaChiTra_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new FrmBanDo();
                frm.userMap1.DiaChiTimKiem = txtDiaChiTra.Text;
                frm.userMap1.Lng = g_DiaChiTra_Lng;
                frm.userMap1.Lat = g_DiaChiTra_Lat;
                frm.userMap1.Bind();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtDiaChiTra.Text = frm.userMap1.DiaChi;
                    g_DiaChiTra_Lng = frm.userMap1.Lng;
                    g_DiaChiTra_Lat = frm.userMap1.Lat;
                    g_DiaChiTra_TimKiem = true;
                }
            }
            catch (Exception ex)
            {

            }
            
        }
        #region Xử lý HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {            
            if (keyData == Keys.Down && FindFocusedControl(txtDiaChiDonKhach) && txtDiaChiDonKhach.IsCompleted)
            {
                txtDiaChiTra.Focus();
                return true;
            }
            else if (keyData == Keys.Down && btnOK.Focused)
            {
                return true;
            }
            else if (keyData == Keys.Up && btnOK.Focused)
            {
                if (Global.MoHinh != MoHinh.TongDaiMini) editGhiChu.Focus();
                else
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// function tim xem control do co dang dc focus khong
        /// </summary>
        /// <param name="control"></param>
        /// <returns>focused = true</returns>
        public static bool FindFocusedControl(Control control)
        {
            var container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control != null;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                g_CloseForm = true;
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }            
            else if (keyData == Keys.F3)
            {
                DatHen();
                return true;
            }
            else if (keyData == Keys.F2)
            {
                uiTabPage1.Selected = true;
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                uiTabPage2.Selected = true;
                txtDiaChi_Search.Select();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                chkGoiTaxi.Focus();
                if (chkGoiTaxi.Checked)
                    chkGoiTaxi.Checked = false;
                else
                {
                    chkGoiTaxi.Checked = true;
                    if (g_CuocGoi.Vung <= 0)
                        editVung.Text = g_VungMacDinh;
                    else
                        editVung.Text = g_CuocGoi.Vung.ToString();
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                chkGoiLai.Focus();
                if (chkGoiLai.Checked)
                    chkGoiLai.Checked = false;
                else
                    chkGoiLai.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.I))
            {
                chkGoiKhieuNai.Focus();
                if (chkGoiKhieuNai.Checked)
                {
                    chkGoiKhieuNai.Checked = false;
                }
                else
                {
                    chkGoiKhieuNai.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                chkGoiDichVu.Focus();
                if (chkGoiDichVu.Checked)
                {
                    chkGoiDichVu.Checked = false;
                }
                else
                {
                    chkGoiDichVu.Checked = true;
                }

                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                chkGoiKhac.Focus();
                if (chkGoiKhac.Checked)
                {
                    chkGoiKhac.Checked = false;
                }
                else
                {
                    chkGoiKhac.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.S))
            {
                editSoLuongXe.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                editVung.Focus();
                btnGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.H))
            {
                FocusVaoTextBox(txtXeNhan);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                editLenhDienThoai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.U))
            {
                if (Global.MoHinh != MoHinh.TongDaiMini)
                    editGhiChu.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.P))
            {
                btnGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.B))
            {
                btnRemoveGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                txtTimDiaChi.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                txtTimXe.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                if (chkMGDuongDai.Checked)
                    chkMGDuongDai.Checked = false;
                else chkMGDuongDai.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.O))
            {
                txtXeDon.Focus();
                txtXeDon.SelectionStart = txtXeDon.Text.Length;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Q))
            {
                chkDaGiaiQuyet.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.E))
            {
                txtLoaiXe.Focus();
                return true;
            }
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                if (uiTab1.SelectedTab == uiTabPage2)
                {
                    return false;
                }
                else
                {
                    if (!txtTimXe.Focused && !txtTimDiaChi.Focused)
                    {
                        btnOK_Click(null, null);
                        if (DialogResult == DialogResult.Cancel) return true;
                        if (!g_CloseForm) return true;
                        DialogResult = DialogResult.OK;
                        Close();
                        return true;
                    }
                }

            }
            else if (keyData == Keys.F1)
            {
                OnHienThiCuocMoiEvent(new EventArgs());
            }
            else if (keyData == (Keys.Shift | Keys.D1) || keyData == (Keys.Shift | Keys.NumPad1))
            {
                setVung("1");
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.D2) || keyData == (Keys.Shift | Keys.NumPad2))
            {
                setVung("2");
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.D3) || keyData == (Keys.Shift | Keys.NumPad3))
            {
                setVung("3");
                return true;
            }
            //else if (keyData == (Keys.Shift | Keys.D4) || keyData == (Keys.Shift | Keys.NumPad4))
            //{
            //    setVung("4");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D5) || keyData == (Keys.Shift | Keys.NumPad5))
            //{
            //    setVung("5");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D6) || keyData == (Keys.Shift | Keys.NumPad6))
            //{
            //    setVung("6");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D7) || keyData == (Keys.Shift | Keys.NumPad6))
            //{
            //    setVung("7");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D8) || keyData == (Keys.Shift | Keys.NumPad8))
            //{
            //    setVung("8");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D9) || keyData == (Keys.Shift | Keys.NumPad9))
            //{
            //    setVung("9");
            //    return true;
            //}
            //else if (keyData == (Keys.Shift | Keys.D0) || keyData == (Keys.Shift | Keys.NumPad0))
            //{
            //    setVung("10");
            //    return true;
            //}
            else if (keyData == Keys.F10)
            {
                //using (Taxi.GUI.QuanLyThe.TraCuuTheMCC traCuuTheMCC = new Taxi.GUI.QuanLyThe.TraCuuTheMCC())
                //{
                //    traCuuTheMCC.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.F11))
            {
                //using (Taxi.GUI.CheckCoDuongDai.ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new Taxi.GUI.CheckCoDuongDai.ThongTinSanBay_DuongDai())
                //{
                //    thongTinSanBay_DuongDai.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.Shift | Keys.F11))
            {
                //using (TaxiOperation_DienThoai.CheckCoDuongDai.DSCuocDuongDai_SanBay dsSanBay_DuongDai = new TaxiOperation_DienThoai.CheckCoDuongDai.DSCuocDuongDai_SanBay())
                //{
                //    dsSanBay_DuongDai.ShowDialog();
                //}
                return true;
            }
            else if (keyData == (Keys.F7))
            {
                //new Taxi.GUI.frmTinhTienTheoKm().Show();
                return true;
            }
            else if (keyData == (Keys.F8))
            {
                new frmDMDiaDanh().Show();
                return true;
            }
            else if (keyData == (Keys.F9))
            {
                new Taxi.GUI.TimKiemCuocGoi(DieuHanhTaxi.GetTimeServer(), "", 1, g_LoaiXeMacDinh).Show();
                return true;
            }
            else if (keyData == (Keys.F12))
            {
                if (string.IsNullOrEmpty(g_CuocGoi.XeNhan))
                {
                    //using (Taxi.GUI.KhachDat.frmKhachDat frmKhachDat = new Taxi.GUI.KhachDat.frmKhachDat(g_CuocGoi, g_ListDataAutoComplete))
                    //{
                    //    DialogResult dialog = frmKhachDat.ShowDialog();
                    //    if (dialog == DialogResult.OK)
                    //    {
                    //        Close();
                    //    }
                    //}
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Phải là cuộc gọi mới(Chưa được chuyển sang tổng đài và chưa có thông tin xe nhận-đón)", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                return true;
            }

            return false;
        }

        //Tìm điểm theo địa chỉ
        private void txtTimXe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!EnVangManagement.ValidateSoHieuXe(txtTimXe.Text))
                {
                    lblThongBao.Text = EnVangManagement.MSG_20_XeTimKhongDungDinhDang;
                    return;
                }
                var vehicle = Taxi.Services.WCFService_Common.WCFServiceClient.TryGet(p => p.GetXeOnlineBySHX(txtTimXe.Text)).Value;
                if (string.IsNullOrEmpty(vehicle.SoHieuXe))
                {
                    lblThongBao.Text = EnVangManagement.MSG_18_KhongTimThayXe;
                    MainMap.ClearAddingMarkerXeDeCu();
                    return;
                }
                else
                {
                    lblThongBao.Text = "";
                }
                MainMap.ClearAddingMarkerXeDeCu();
                vehicle.TrangThai = (Convert.ToInt32(vehicle.TrangThai) & 8) == 0 ? 1 : 0; //---0 : xe tắt máy; 1 : xe bật máy.
                MainMap.addMarkerXeDeCu(vehicle.TrangThai, vehicle.KinhDo, vehicle.ViDo, vehicle.SoHieuXe);
                MainMap.Position = new PointLatLng(vehicle.ViDo, vehicle.KinhDo);
            }
        }        

        // Xử lý phím lên xuống
        private void txtDiaChiDonKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtDiaChiTra.Focus();
            }
        }

        private void txtDiaChiTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtDiaChiDonKhach.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtLoaiXe.Focus();
            }
        }

        private void chkGoiTaxi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtDiaChiDonKhach.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiLai.Focus();
            }
        }

        private void chkGoiLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiTaxi.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiKhieuNai.Focus();
            }
        }

        private void chkGoiKhieuNai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiLai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiDichVu.Focus();
            }
        }

        private void chkGoiDichVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiKhieuNai.Focus();
            }
            //else if (e.KeyCode == Keys.Down)
            //{
            //    chkGoiHoiDam.Focus();
            //}
        }

        private void chkGoiHoiDam_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    chkGoiDichVu.Focus();
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //    chkGoiKhac.Focus();
            //}
        }

        private void chkGoiKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //chkGoiHoiDam.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Global.MoHinh != MoHinh.TongDaiMini)
                    editLenhDienThoai.Focus();
                else
                {
                    //txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                }
                    
            }
        }

        //LOAI XE
        private void chkXeKI4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtLoaiXe.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chk7Cho.Focus();
            }
        }

        private void chkCipucha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiKhac.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editSoLuongXe.Focus();
            }
        }

        private void editSoLuongXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chk7Cho.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editVung.Focus();
            }
        }

        private void editVung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editSoLuongXe.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if(txtXeNhan.Enabled)
                {
                    FocusVaoTextBox(txtXeNhan);
                }
                else if(txtXeDon.Enabled)
                {
                    FocusVaoTextBox(txtXeDon);
                }
                else
                {
                    editLenhDienThoai.Focus();
                }
            }
        }

        private void editLenhDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtXeDon.Enabled)
                {
                    FocusVaoTextBox(txtXeDon);
                }
                else if (txtXeNhan.Enabled)
                {
                    FocusVaoTextBox(txtXeNhan);
                }
                else
                {
                    editVung.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                editGhiChu.Focus();
            }
            
        }

        private void editGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editLenhDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }

        private void btnOK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (Global.MoHinh != MoHinh.TongDaiMini)
                    editGhiChu.Focus();
                else
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnCancel.Focus();
            }
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnGPS.Focus();
            }
        }
        #endregion Xử lý HOTKEY
        #endregion
        
        #region ==========================MAPS=================================
        private int KenhID = 0;
        private string MaCungXN = string.Empty;
        private string g_DSXeDeCu;
        private string g_DSXeDeCu_TD;
        bool isMarker = false;
        XeOnline clsXeOnline = new XeOnline();
        private GMapProvider _mapType;
        private Taxi.Utils.MapModeEnum _mapMode;
        private int _mapZoom;
        //private object Object;

        // markers
        GMapMarkerCustom centerMarker;
        //GMapMarker currentMarker;
        private List<GMapMarker> _otherMarkers;
        // layers
        GMapOverlay top;
        GMapOverlay OverlayXeDeCu;
        GMapOverlay OverlayXeNhan;

        bool isMouseDown;

        private void ConfigMap()
        {
            if (ThongTinCauHinh.GPS_TrangThai == true && g_CGLimit == false)
            {
                btnGPS.Enabled = true;
                btnRemoveGPS.Enabled = true;
            }
            else
            {
                if (g_CGLimit)
                    lblThongBao.Text = "Thông báo : Tạm thời ngắt GPS vì có quá nhiều cuộc gọi chưa giải quyết!";
                btnGPS.Enabled = false;
                btnRemoveGPS.Enabled = false;
            }
            // config gmaps
            MainMap.CacheLocation = Application.StartupPath + "\\Map";
            //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; 
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            if (Config_Common.MAP_Provider == 0)
                MainMap.MapProvider = GMapProviders.GoogleMap;
            else
                MainMap.MapProvider = GMapProviders.BinhAnhMap;
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


            // get zoom  
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
            trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

            
            //CbMapType.ValueMember = "Name";
            //CbMapType.DataSource = GMapProviders.List;
            //CbMapType.SelectedItem = GMapProviders.GoogleMap;

            CustomInitMap();
        }

        private void CustomInitMap()
        {
            MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
            MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;
            
        }

        #region===================Map Events==================================

        private void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            trackBarMap.Minimum = MainMap.MinZoom;
            trackBarMap.Maximum = MainMap.MaxZoom;
        }

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
                if (MainMap.OverlayCustom == null || MainMap.OverlayCustom.Markers.Count <= 0)
                    //currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                //else
                {
                    PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                    string strDiaChi = Taxi.Services.Service_Common.GetAddressByGeoBA((float)point.Lat, (float)point.Lng);

                    MainMap.addMarkerCustomer(point, strDiaChi);
                    g_GPS = true;
                    //currentMarker = MainMap.MarkerCustomer;
                }
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown)
            {
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && MainMap.MarkerCustomer.IsVisible)
                {

                    MainMap.MarkerCustomer.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                    string strDiaChi = Taxi.Services.Service_Common.GetAddressByGeoBA((float)MainMap.MarkerCustomer.Position.Lat, (float)MainMap.MarkerCustomer.Position.Lng);
                    MainMap.MarkerCustomer.ToolTipText = strDiaChi;
                    if (MainMap.OverlayXeDeCu != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();
                }
            }
            MainMap.Refresh(); // force instant invalidation
        }

        #endregion=============================================================        

        private void setMarker()
        {
            if (top.Markers.Count == 0)
            {
                if (g_CuocGoi.GPS_KinhDo != 0)
                {
                    MainMap.addMarkerCustomer2(g_CuocGoi.GPS_KinhDo, g_CuocGoi.GPS_ViDo, g_CuocGoi.DiaChiDonKhach);
                }
                else
                {
                    string strDiaChi =getDiaChiChuan( StringTools.TrimSpace(txtDiaChiDonKhach.Text));
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddress(strDiaChi, ThongTinCauHinh.GPS_TenTinh);

                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        double viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                        double kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                        MainMap.addMarkerCustomer2(kinhDo, viDo,strDiaChi);
                    }
                    else
                    {
                        lblThongBao.Text = EnVangManagement.MSG_6_BANDO;
                    }
                }
            }
        }

        /// <summary>
        /// Lấy danh sách xe đề cử
        /// </summary>
        /// <param name="kinhDo"></param>
        /// <param name="viDo"></param>
        private void getXeByToaDo(double kinhDo, double viDo)
        {
            string loaiXeGPS = "";
            string loaiXe = GetThongTinLoaiXeChon_GetXeDeCu();
            int SoXeTraVe = 4 + Convert.ToInt16(editSoLuongXe.Text);

            if(string.IsNullOrEmpty(loaiXe)) // neu ko co chon loai xe thi tat ca loai xe           
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS("0,4,7");
            else
                loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS(loaiXe);

            string dsXeDeCu = string.Empty;
            var ngung = false;
            var soLan = 3;

            if (chkDaGiaiQuyet.Checked)
            {
                do
                {
                    soLan--;
                    try
                    {
                        dsXeDeCu = WCFService_Common.WCFServiceClient.TryGet(p => p.LayDanhSachXeDeCu_ToaDoV2(kinhDo,
                            viDo,
                            ThongTinCauHinh.GPS_MaCungXN,
                            loaiXeGPS,
                            0,
                            true, SoXeTraVe, g_CuocGoi.ThoiDiemGoi, g_CuocGoi.IDCuocGoi,
                            g_CuocGoi.PhoneNumber,
                            txtDiaChiDonKhach.Text.Trim())).Value;
                        ngung = true;
                    }
                    catch
                    {
                        WCFService_Common.RefreshWcf();
                    }
                    if (soLan <= 0) ngung = true;

                } while (!ngung);

            }
            else
            {
                do
                {
                    soLan--;
                    try
                    {
                        dsXeDeCu = WCFService_Common.WCFServiceClient.TryGet(p => p.LayDanhSachXeDeCu_ToaDoV2(kinhDo,
                                                                      viDo,
                                                                      ThongTinCauHinh.GPS_MaCungXN,
                                                                      loaiXeGPS,
                                                                      G_BanKinhTimXe,
                                                                      true, SoXeTraVe, g_CuocGoi.ThoiDiemGoi, g_CuocGoi.IDCuocGoi,
                                                                      g_CuocGoi.PhoneNumber,
                                                                      txtDiaChiDonKhach.Text.Trim())).Value;
                        ngung = true;
                    }
                    catch
                    {
                        WCFService_Common.RefreshWcf();
                    }
                    if (soLan <= 0) ngung = true;

                } while (!ngung);
              
             }
            setResult(dsXeDeCu.Trim());            
        }

        /// <summary>
        /// Vẽ xe đề cử lên bản đồ
        /// </summary>
        /// <param name="result">danh sách xe đề cử có tọa độ - Service trả về</param>
        private void setResult(string result)
        {
            try
            {
               // new MessageBox.MessageBox().Show(result);
                if (String.IsNullOrEmpty(result))
                    return;


                string[] Values;
                string dsXeDeCu = "";
                int trangThai = 0;
                foreach (string strValue in result.Split(';'))
                {
                    //"SHXe_KhoangCach_KD_VD_TrangThai"
                    Values = strValue.Split('_');
                    if (Values.Length > 0)
                    {
                        // --TH SHX = '1234-2' chi lay 1234 (4 ky tu dau tien)
                        string SHX = Values[0].Substring(0, Values[0].Length);
                        dsXeDeCu = string.Format("{0}{1}.", dsXeDeCu, SHX);
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt32(Values[4]) & 8) == 0 ? 1 : 0; //---0 : xe tắt máy; 1 : xe bật máy.
                        }

                        MainMap.addMarkerXeDeCu(trangThai,
                            Convert.ToDouble(Values[2].Replace(',','.'), Global.CultureSystem),
                            Convert.ToDouble(Values[3].Replace(',', '.'), Global.CultureSystem),
                            string.Format("{0}-{1}", SHX, Values[1]));
                    }
                }
                if (dsXeDeCu.LastIndexOf('.') > 0)
                {
                    g_DSXeDeCu = dsXeDeCu.Substring(0,dsXeDeCu.Length-1);
                    g_DSXeDeCu_TD = result;
                }
            }
            catch (Exception ex)
            {
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
            lblDisplayXeDeCu.Text = g_DSXeDeCu + "." + XeYeuThich;
            if(string.IsNullOrEmpty(g_CuocGoi.XeNhan) && Global.ChoPhepDienThoaiNhapXe)
            {
                txtXeNhan.Text = lblDisplayXeDeCu.Text;
            }
        }

        /// <summary>
        /// vẽ xe đề cử lên bản đô
        /// </summary>
        /// <param name="DSXeDeCu"></param>
        /// <param name="DSXeDeCu_TD"></param>
        private void setMarkerDSXeDeCu(string DSXeDeCu, string DSXeDeCu_TD)
        {
            try
            {
                int trangThai = 0;
                string[] arrDSXeDeCu = DSXeDeCu.Split('.');
                string[] arrDSXeDeCu_TD = DSXeDeCu_TD.Split(';');
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
                        MainMap.addMarkerXeDeCu(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem), Convert.ToDouble(Values[3], Global.CultureSystem), string.Format("{0}-{1}", arrDSXeDeCu[i], Values[1]));
                    }
                }                
            }
            catch(Exception ex)
            {
                lblThongBao.Text = EnVangManagement.MSG_11_BANDO;
            }
        }

        /// <summary>
        /// vẽ xe nhận lên bản đồ
        /// </summary>
        /// <param name="DSXeNhan"></param>
        /// <param name="DSXeNhan_TD"></param>
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
                    Values = arrDSXeNhan_TD[i].Split('-');
                    if (Values.Length > 0)
                    {
                        if (!String.IsNullOrEmpty(Values[4]))
                        {
                            trangThai = (Convert.ToInt16(Values[4]) & 8) == 0 ? 1 : 0;//---0 : xe tắt máy; 1 : xe bật máy.
                        }
                        MainMap.addMarkerXeNhan(trangThai, Convert.ToDouble(Values[2], Global.CultureSystem), Convert.ToDouble(Values[3], Global.CultureSystem), string.Format("{0}-{1}", arrDSXeNhan[i], Values[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = EnVangManagement.MSG_12_BANDO;
            }
        }

        private void trackBarMap_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBarMap.Value;
        }        

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            string sVung = StringTools.TrimSpace(editVung.Text);
            if (sVung == "11")
            {
                chkGoiKhieuNai.Checked = true;
            }
        }

        private void btnDatHen_Click(object sender, EventArgs e)
        {
            DatHen();
        }

        private void chkCipucha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCipucha.Checked)
                editVung.Text = "3";
        }

        private void chkXe7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chk4Cho.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editSoLuongXe.Focus();
            }
        }

        private void txtLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtDiaChiTra.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chk4Cho.Focus();
            }
        }

        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkVung1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung2_Search.Focus();
            else if (e.KeyCode == Keys.Up)
                txtDiaChi_Search.Focus();
        }

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                txtDiaChi_Search.Focus();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                chkVung1_Search.Focus();
            else if (e.KeyCode == Keys.Up)
                txtSoDT_Search.Focus();
        }

        private void chkVung1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung2_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string soDt = txtSoDT_Search.Text.Trim();
            string diaChi = txtDiaChi_Search.Text.Trim();
            string kenh = "";

            if (chkVung1_Search.Checked) kenh = "1;";
            if (chkVung2_Search.Checked) kenh = kenh + "2;";

            List<CuocGoi> lstCuocGoi = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet(kenh, soDt, diaChi);
            gridEX_All.DataSource = null;
            gridEX_All.DataMember = "ListDienThoai";
            gridEX_All.SetDataBinding(lstCuocGoi, "ListDienThoai");
        }

        private void txtXeNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editVung.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if(txtXeDon.Enabled)
                {
                    txtXeDon.Focus();
                }
                else
                {
                    editLenhDienThoai.Focus();
                }
            }
        }

        private void txtXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtXeNhan.Enabled)
                {
                    FocusVaoTextBox(txtXeNhan);
                }
                else
                {
                    editVung.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhDienThoai.Focus();
            }
        }

        private void chkTruot_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkHoan_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkMGDuongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnDatHen.Focus();}
        }
     
        #endregion        

        private void chkDaDon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void picDiaChiTra_EditValueChanged(object sender, EventArgs e)
        {

        }

       

    }
}