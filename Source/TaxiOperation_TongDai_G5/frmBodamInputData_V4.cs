﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Windows.Forms;
using Taxi.Common;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Utils.Enums;
using Taxi.Data.FastTaxi;
using System.Linq;
using DanhSachQuyen = Taxi.Business.DanhSachQuyen;
using Taxi.Data.BanCo.Entity;
using Taxi.MessageBox;
using Taxi.Data.G5;

namespace Taxi.GUI
{
    public partial class frmBodamInputData_V4: Form 
    {
        #region ==========================Init=================================

        public const string XeDaDon = "000";
        public static bool IsOnShowDiaLog = false;

        public enum BangMaValidate
        {
            ValidateSuccess = 0,            // Form khong phai
            NhapChinhXacXe =  1,            // Bạn phải nhập chính xác số hiệu xe.Nếu số hiệu xe thiếu, bạn báo quản trị bổ sung.
            NhapXeDonThuocXeNhan =2,        // Bạn phải nhập xe đón thuộc xe nhận.
            NhapKenh = 3,                   // Bạn phải nhập kênh (vùng) theo quy định.
            NhapHoan = 4,                   // Bạn không thể nhập hoãn, khi điện thoại chưa báo hoãn.
            NhapTruot = 5,                  // Bạn không thể nhập trượt nếu chưa có xe nhận.
            NhapXinLoi = 6,                 // Bạn không thể chọn không xe xin lỗi khi đã có xe nhận.
            NhapXeNhan = 7,                 // Bạn vừa nhập xe nhận không thuộc xe đón.
            XeNhanDaDonOCuocGoiKhac = 8,    // Bạn vừa nhập xe nhận không thuộc xe đón.
            MoiKhachChuaCoXeDon=9,          // Bạn mời khách chưa có xe đón.
        }

        private const string MSG_1_NHAPCHINHXACXE = "Bạn phải nhập chính xác số hiệu xe.Bạn báo quản trị bổ sung xe nếu thiếu.";
        private const string MSG_2_NHAPXEDONTHUOCXENHAN = "Trùng lặp xe Nhận/đón.";
        //private const string MSG_3_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định.";
        //private const string MSG_4_NHAPHOAN = "Bạn không thể nhập hoãn, khi điện thoại chưa báo hoãn.";
        //private const string MSG_5_NHAPTRUOT = "Bạn không thể nhập trượt nếu chưa có xe nhận.";
        //private const string MSG_6_NHAPXINLOI = "Bạn không thể chọn không xe xin lỗi khi đã có xe nhận.";        
        //private const string MSG_7_MANHINHKONGCOXEDECU = "Không tồn tại xe đề cử. Bạn phải chọn ra xe đề cử.";
        private string MSG_8_XENHANDANHANDIEMKHAC = "Xe nhận này đã nhận đón ở địa chỉ khác.";
        private const string MSG_9_MoiKhachKhongXeDon = "[Lệnh mời khách] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận.";
        //------------------LENH TONG DAI --------------new Janus--------------------------
        //private  string LENH_1_MOIKHACH = "mời khách";
        //private  string LENH_2_GIUKHACH = "giữ khách";
        //private  string LENH_3_HOILAIDC = "hỏi lại địa chỉ";
        //private  string LENH_4_CHUYENKENH = "chuyển kênh";
        //private  string LENH_5_KHONGXE_XINLOI = "Ko xe lần 1";
        //private  string LENH_5_2_KHONGXE_XINLOI = "Ko xe xin lỗi khách";        
        //private  string LENH_6_KTRAKHACH = "kiểm tra khách";       
        private   List<string> g_ListSoHieuXe;
        private CuocGoi g_CuocGoi;
        private DateTime g_TimeServer;
        private bool g_isCuocGoiKetThuc=false;
        private int G_XeDonLength = 0;
        private bool g_CloseForm = true;    // kiểm soát đóng form
        private bool g_IsKetThuc = false;        
        public bool IsChangeDiaChiDon = false;
        public bool IsChangeDiaChiTra = false;

        public CuocGoi GetCuocGoi
        {
            get 
            {                  
                return g_CuocGoi; 
            }
        }
        private BackgroundWorker bw = new BackgroundWorker();
        public List<CuocGoi> G_ListCuocGoi { get; set; }
        #endregion

        #region =======================Constructor=============================
        public frmBodamInputData_V4(DateTime timeServer, CuocGoi cuocGoi, List<string> listSoHieuXe, bool isCuocGoiKetThuc, int soLuongCS, bool IsThoatCuoc999)
        {
            InitializeComponent();

            g_isCuocGoiKetThuc = isCuocGoiKetThuc;
            g_CuocGoi = cuocGoi;
            g_ListSoHieuXe = listSoHieuXe;
            g_TimeServer = timeServer;
            txtDiaChiDon.ReadOnly = !ThongTinDangNhap.HasPermission(DanhSachQuyen.CuocGoi_TD_SuaDiaChiDon);
        }

        #endregion

        #region ========================Load Form==============================
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            IsOnShowDiaLog = true;
            //SetCommandFromDB();
            SetDuLieuLenForm(g_CuocGoi);
            HienThiControl(g_CuocGoi);
            SetControlForKetThuc(g_CuocGoi);            
            if (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                ActiveControl = editLenhTongDai;
            }
            if (maskXeNhan.Enabled)
            {
                ActiveControl = maskXeNhan;
                int length = maskXeNhan.Text.Length;
                if (length > 0)
                {
                    maskXeNhan.SelectionLength = 0;
                    maskXeNhan.SelectionStart = length + 1;
                    
                    SendKeys.Send("{END}");
                }
            }
            if (g_CuocGoi.DanhSachXeDeCu != "" && g_CuocGoi.GPS_KinhDo > 0 && g_CuocGoi.GPS_ViDo > 0)
            {
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
        }

        //private void SetCommandFromDB()
        //{
        //    try
        //    {   
        //        //*command
        //        if (CommonBL.Commands.Count > 0)
        //        {
        //            LENH_1_MOIKHACH = CommonBL.GetNameByCode(CommandCode.MoiKhach,2);
        //            LENH_2_GIUKHACH = CommonBL.GetNameByCode(CommandCode.GiuKhach, 2);
        //            LENH_3_HOILAIDC = CommonBL.GetNameByCode(CommandCode.HoiLaiDiaChi, 2);
        //            LENH_4_CHUYENKENH = CommonBL.GetNameByCode(CommandCode.ChuyenKenh, 2);
        //            LENH_5_KHONGXE_XINLOI = CommonBL.GetNameByCode(CommandCode.KoXeLan1, 2);
        //            LENH_5_2_KHONGXE_XINLOI = CommonBL.GetNameByCode(CommandCode.KhongXeXL, 2);
        //            LENH_6_KTRAKHACH = CommonBL.GetNameByCode(CommandCode.KiemTraKhach, 2);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("SetCommandFromDB: ",ex);
        //    }
        //}

        private void SetDuLieuLenForm(CuocGoi cuocGoi)
        {
            lblLinePhoneTime.Text = "[" + cuocGoi.Line + "]  " + cuocGoi.PhoneNumber + "  " + cuocGoi.ThoiDiemGoi;
            txtDiaChiDon.Text = cuocGoi.DiaChiDonKhach;
            lblSoLuong_LoaiXe.Text = LayThongTinLoaiXe(cuocGoi.SoLuong.ToString(), cuocGoi.LoaiXe);
            lblDSXeDeCu.Text = string.Empty;
            lblTimeCapNhatXeDeCu.Visible = false;
            if (!string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu))
            {
                lblDSXeDeCu.Text = cuocGoi.DanhSachXeDeCu;
                lblTimeCapNhatXeDeCu.Visible = true;
                TimeSpan timeSpan = g_TimeServer - cuocGoi.ThoiDiemCapNhatXeDeCu;
                lblTimeCapNhatXeDeCu.Text = string.Format("(cập nhật : {0:0} phút trước)", timeSpan.TotalMinutes);
            }
            if (!string.IsNullOrEmpty(cuocGoi.XeNhan))
            {
                maskXeNhan.Text = cuocGoi.XeNhan + ".";
                maskXeNhan.SelectionStart = maskXeNhan.Text.Length;
            }
            else maskXeNhan.Text = "";
            if (!string.IsNullOrEmpty(cuocGoi.BTBG_NoiDungXuLy))
            {
                maskXeMK.Text = cuocGoi.BTBG_NoiDungXuLy + ".";
                maskXeMK.SelectionStart = maskXeMK.Text.Length;
            }
            else maskXeMK.Text = "";

            maskXeDon.Text = cuocGoi.XeDon;
            editLenhTongDai.Text = cuocGoi.LenhTongDai;
            editGhiChu.Text = cuocGoi.GhiChuTongDai;
            txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach;
            if (g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
            {
                chkKhongXe.Text = "Không x(&e)"; 
            }
            if (g_CuocGoi.FT_IsFT)
            {
                lblLinePhoneTime.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber,
                              cuocGoi.FT_SendDate);
                label24.Text = string.Format("{0:HH:mm}", g_CuocGoi.FT_Date);
                label24.Visible = true;
                if (cuocGoi.FT_AllowCall)
                {
                    lbl_FTAllowCall.Text = "";
                }
                else
                {
                    lbl_FTAllowCall.Text = "Khách không muốn nhận cuộc gọi";
                }
            }
            else
            {
                lblLinePhoneTime.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber,
                                cuocGoi.ThoiDiemGoi);
                label24.Text = string.Format("{0:HH:mm}", g_CuocGoi.ThoiDiemGoi);
                label24.Visible = false;
            } 
           
        }
        /// <summary>
        /// Hàm thực hiện set control cho xử lý kết thúc
        /// </summary>
        private void SetControlForKetThuc(CuocGoi cuocGoi)
        {
            // Xu ly ket thuc
            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoi.XeNhan))
                chkTruot.Enabled = true;
            else
                chkTruot.Enabled = false;
            // Điện thoại đã chọn hoãn //
            if (cuocGoi.LenhDienThoai.Contains("khách hoãn") || cuocGoi.LenhDienThoai.Contains("Hủy xe/Hoãn")){
                chkHoan.Enabled = true;
                if( cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan)
                    chkHoan.Checked = true;
            }
            else
                chkHoan.Enabled = false;
            
            // không xe
            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length <= 0){

                chkKhongXe.Enabled = true;
                if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    chkKhongXe.Checked = true;
                }
              
            }
            else
                chkKhongXe.Enabled = false;
            // gọi lại
            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                chkDaNhanGoiLai.Enabled = true;
                maskXeNhan.Enabled = false;
                maskXeDon.Enabled = false;
                editLenhTongDai.Enabled = true;
            }
            else
            {
                chkDaNhanGoiLai.Enabled = false;
            }
            // kết thúc hỏi đàm
            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
            {
                chkKetThucHoiDam.Enabled = true;
                maskXeNhan.Enabled = false;
                maskXeDon.Enabled = false;
                editLenhTongDai.Enabled = false;
            }
            else
            {
                chkKetThucHoiDam.Enabled = false;
            }
            if (g_isCuocGoiKetThuc)
            {
                //maskXeDon.Enabled = false;
                editLenhTongDai.Enabled = false;
                editGhiChu.Enabled = true;
                editGhiChu.Text = string.Format("Xe đón cũ là {0}", maskXeDon.Text.Trim());
            }
        }        

        #endregion

        #region =========================Get Data==============================
        /// <summary>
        /// hàm nhận dữ liệu từ form, trả về biến
        /// </summary>
        private void GetDuLieuTuForm(ref CuocGoi cuocGoi, string xeNhan, string xeDon,string xeMK,bool IsXeNhan=false)
        {
            if (IsXeNhan && xeMK != "")
                cuocGoi.XeNhan = StringTools.LocBoTrungXe(string.Format("{0}.{1}", xeNhan, xeMK));
            else
                cuocGoi.XeNhan = StringTools.LocBoTrungXe(xeNhan);
            cuocGoi.XeDon = StringTools.LocBoTrungXe(xeDon);
            cuocGoi.BTBG_NoiDungXuLy = StringTools.LocBoTrungXe(xeMK);
            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.BoDam; // tong dai truyen sang
            //cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;            
            if (!txtDiaChiDon.ReadOnly&&IsChangeDiaChiDon)
                cuocGoi.DiaChiDonKhach = txtDiaChiDon.Text.Trim().ToUpper();
            if(IsChangeDiaChiTra)
            cuocGoi.DiaChiTraKhach = txtDiaChiTra.Text;
            if (cuocGoi.XeDon.Length > 0)
            {
                if (g_IsKetThuc)
                {
                    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                }
            }
            cuocGoi.LenhTongDai = StringTools.TrimSpace(editLenhTongDai.Text);
            cuocGoi.GhiChuTongDai = StringTools.TrimSpace(editGhiChu.Text);

            if (chkTruot.Checked) // cuoc goi truot
            {
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                cuocGoi.LenhTongDai = "Cuốc trượt";
                cuocGoi.XeDon = string.Empty;
            }
            else if (chkHoan.Checked)
            {
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                cuocGoi.LenhTongDai = "Cuốc hoãn";
                cuocGoi.XeDon = string.Empty;
            }
            else if (chkKhongXe.Checked)
            {
                if (chkKhongXe.Text.Contains("1"))
                    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1;
                else
                    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
            }
            else if (chkDaNhanGoiLai.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiLai;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc; 
            }
            else if (chkKetThucHoiDam.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiHoiDam;
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.TrangThaiKhac;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            }
            else
            {
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
            }

            int vung = 0;
            try
            {                
                if (txtVung.Text.Length > 0)
                {
                    vung = Convert.ToInt32(txtVung.Text);
                } 
            }
            catch 
            {
                vung = 0;
            }
            if (vung > 0)
            {
                cuocGoi.Vung = vung;
            }
        }

        /// <summary>
        /// Hàm trả về thông số lượng loại xe.
        /// </summary>
        private string LayThongTinLoaiXe(string soLuong, string loaiXe)
        {
            if (string.IsNullOrEmpty(loaiXe))
            {
                loaiXe = "Không XĐ";
            }
            return string.Format("{0} xe {1}", soLuong, loaiXe);
        }
        #endregion

        #region ======================Validation Form==========================
        /// <summary>
        /// Hàm thực hiện validate form
        /// </summary>
        private BangMaValidate ValidateFormNhap()
        {
            // Check xe nhận
            string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text);
            if (!string.IsNullOrEmpty(xeNhan))
            {
                if (!KiemTraXeNhan(xeNhan))
                {
                    return BangMaValidate.NhapChinhXacXe;
                }
                if (StringTools.KiemTraTrungLapXeChay(xeNhan))
                {
                    return BangMaValidate.NhapXeDonThuocXeNhan;
                }
                if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0 && KiemTraXeCoTrongCuocKhachHienTai(xeNhan))
                {
                    if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan == 1)
                    {
                        return BangMaValidate.XeNhanDaDonOCuocGoiKhac;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(MSG_8_XENHANDANHANDIEMKHAC);
                        return BangMaValidate.ValidateSuccess;
                    }
                }
            }
            // Kiểm tra xe đó có nằm trong xe nhận
            string xeDon = StringTools.ConvertToChuoiXeNhanChuan(maskXeDon.Text);
            if (!string.IsNullOrEmpty(xeDon))
            {
                if (StringTools.KiemTraTrungLapXeChay(xeDon))
                {
                    return BangMaValidate.NhapXeDonThuocXeNhan;
                }
            }
            // Kiểm tra nhập kênh khi không xe chuyển vùng
            //if (editLenhTongDai.Text == LENH_1_MOIKHACH && (xeNhan == null || xeNhan.Trim() == ""))
            //{
            //    return BangMaValidate.MoiKhachChuaCoXeDon;
            //}


            return BangMaValidate.ValidateSuccess;
        }
        /// <summary>
        /// hien thi thong bao 
        /// </summary>
        private void HienThiThongBao(BangMaValidate maValidate)
        {
            lblThongBao.Visible = true;
            string message = string.Empty;
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                message = string.Empty;
                lblThongBao.Visible = false;
            }
            else if (maValidate == BangMaValidate.NhapChinhXacXe)
            {
                message = MSG_1_NHAPCHINHXACXE;
            }
            else if (maValidate == BangMaValidate.NhapXeDonThuocXeNhan)
            {
                message = MSG_2_NHAPXEDONTHUOCXENHAN;
            }
            else if (maValidate == BangMaValidate.XeNhanDaDonOCuocGoiKhac)
            {
                message = MSG_8_XENHANDANHANDIEMKHAC;
            }
            else if (maValidate == BangMaValidate.MoiKhachChuaCoXeDon)
            {
                message = MSG_9_MoiKhachKhongXeDon;
            }
            lblThongBao.Text = message;
        }

        private void HienThiControl_GoiTaxi()
        {
            lblVungChuyen.Visible = false;
            txtVung.Visible = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
            if (g_CuocGoi.XeNhan == null || g_CuocGoi.XeNhan != "")
            {
                chkHoan.Enabled = true;
            }
            chkKhongXe.Enabled = false;
            chkDaNhanGoiLai.Enabled = false;
            chkKetThucHoiDam.Enabled = false;
        }
        /// <summary>
        /// hàm thực hiện hiển thị control cuộc gọi lại
        /// </summary>
        private void HienThiControl_GoiLai()
        {
            lblVungChuyen.Visible = false;
            txtVung.Visible = false;

            maskXeNhan.Enabled = false;
            maskXeMK.Enabled = false;
            maskXeDon.Enabled = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
            chkKhongXe.Enabled = false;
            chkKetThucHoiDam.Enabled = false;

            chkDaNhanGoiLai.Enabled = true;
            chkDaNhanGoiLai.Checked = true;
            editLenhTongDai.Enabled = true;
            //chkDaNhanGoiLai.Checked = true;
        }

        private void HienThiControl(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
            {
                HienThiControl_GoiTaxi();
            }
            else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                HienThiControl_GoiLai();
            }
            else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
            {
                HienThiControl_GoiHoiDam();
            }

            IsFastTaxi.Visible = g_CuocGoi.FT_IsFT;
            if (!g_CuocGoi.FT_IsFT)
            {
                var height_TieuDe = panel_TieuDe.Height;
                panel_TieuDe.Visible = false;
                this.Height = this.Height - height_TieuDe;
            }
        }

        private void HienThiControl_GoiHoiDam()
        {
            lblVungChuyen.Visible = false;
            txtVung.Visible = false;

            maskXeNhan.Enabled = false;
            maskXeDon.Enabled = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
            chkKhongXe.Enabled = false;
            chkDaNhanGoiLai.Enabled = false;

            chkKetThucHoiDam.Enabled = true;
            chkKetThucHoiDam.Checked = true;
        }

        /// <summary>
        /// Hàm kiểm tra xe nhận có nằm trong dsXe hệ thống đã nhập
        /// INPUT :
        ///      - xeNhan : 2343.6732.9000
        /// OUPPUT : True : xe nhan nằm trong dsXe của hệ thống
        ///          False: xe nhận không nằm trong ds xe của hệ thống.
        /// </summary>
        private bool KiemTraXeNhan(string xeNhan)
        {
            try
            {
                bool ret = true;
                if (xeNhan.Length <= 0) return true;
                if (g_ListSoHieuXe == null || g_ListSoHieuXe.Count <= 0) return false;

                string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
                G_XeDonLength = arrXeNhan.Length;
                for (int i = 0; i < G_XeDonLength; i++)
                {
                    bool timThayXe = false;
                    foreach (string xe in g_ListSoHieuXe)
                    {
                        if (xe == arrXeNhan[i] || arrXeNhan[i] == XeDaDon)
                        {
                            timThayXe = true;
                            break; // thoát khỏi vòng ds xe
                        }
                    }
                    ret &= timThayXe;
                    if (!ret) { break; }  // có một xe không thuộc ds
                }
                return ret;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KiemTraXeNhan: ", ex);
                return false;
            }
        }

        /// <summary>
        /// Kiem tra xe da co trong ds chua
        /// </summary>
        private bool KiemTraXeCoTrongCuocKhachHienTai(string SoHieuXe)
        {
            string[] arrTaxi = SoHieuXe.Split('.');
            foreach (CuocGoi objDH in G_ListCuocGoi)
            {
                if (objDH.IDCuocGoi == g_CuocGoi.IDCuocGoi) continue;
                if (objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (Array.IndexOf(arrTaxi, arrXeDaNhan[i]) > -1)
                        {
                            MSG_8_XENHANDANHANDIEMKHAC = string.Format("Xe {0} đã nhận đón ở địa chỉ {1}", arrXeDaNhan[i],objDH.DiaChiDonKhach);
                            return true;
                        }
                }
            }
            return false;
        }

        #endregion
        
        #region ========================Form Events============================

        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi trang thai lenh
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            BangMaValidate maValidate = ValidateFormNhap();

            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                string xeDon = StringTools.ConvertToChuoiXeNhanChuan(maskXeDon.Text).Trim('.');
                string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text).Trim('.');
                string xeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(g_CuocGoi.XeDenDiem).Trim('.');
                string xeMK = StringTools.ConvertToChuoiXeNhanChuan(maskXeMK.Text).Trim('.');

                #region  Xe vi phạm
                if (Config_Common.TongDai_CheckXeViPham)
                {
                    string xeViPham = LoiViPham.Inst.GetXeViPham(xeNhan + "." + xeDon + "." + xeDenDiem, DateTime.Now);
                    if (!string.IsNullOrEmpty(xeViPham))
                    {
                        new MessageBox.MessageBoxBA().Show(this, string.Format("Xe {0} đang vi phạm lỗi", xeViPham), "Thông báo");
                        g_CloseForm = false; // chưa đóng form
                        return;
                    }
                }

                #endregion

                #region XeDon
                if (xeDon.Length > 0 && xeDon != g_CuocGoi.XeDon)
                {
                    //Nếu là cuộc gọi FastTaxi và khách hàng chưa xác nhận đã gặp xe thì cảnh báo
                    if (g_CuocGoi.FT_IsFT && g_CuocGoi.FT_Status != Enum_FastTaxi_Status.NhapXeDon)
                    {
                        if (new MessageBox.MessageBoxBA().Show("Khách hàng chưa xác nhận đã gặp xe. Bạn có muốn tiếp tục nhập xe đón không ?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question).ToLower().Equals("no"))
                        {
                            return;
                        }
                    }
                    if (xeDon == XeDaDon)
                    {
                        if (xeNhan.Length <= 0)
                            xeNhan = XeDaDon;
                        g_IsKetThuc = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(xeDon))
                        {
                            G_XeDonLength = xeDon.Split('.').Length;
                            if (G_XeDonLength < g_CuocGoi.SoLuong)
                            {
                                string message = "Chưa đủ xe số lượng xe yêu cầu";
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message, xeDon))
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK)
                                    {
                                        if (confirmXeDon.Result == 2)
                                        {
                                            if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                            {
                                                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                                return;
                                            }
                                            g_IsKetThuc = true;
                                        }
                                        else
                                        {
                                            g_IsKetThuc = false;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        g_IsKetThuc = false;
                                        return;
                                    }
                                }

                            }
                            else if (G_XeDonLength > g_CuocGoi.SoLuong)
                            {
                                new MessageBox.MessageBoxBA().Show("Xe đón vượt số lượng yêu cầu. Vui lòng kiểm tra lại");
                                g_IsKetThuc = false;
                                return;
                            }
                            else
                            {
                                g_IsKetThuc = true;
                            }
                            if (Config_Common.TongDai_HienThiCanhBao_XeDonTrungXeNhan > 0 && !StringTools.KiemTraXeDonThuocXeNhan(xeDon, xeNhan))
                            {
                                string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                                using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message, xeDon))
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK)
                                    {
                                        xeDon = confirmXeDon.XeDonResult;
                                        if (!new Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_CuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                        {
                                            new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo",MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        g_IsKetThuc = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region XeNhan

                string xeNhanCu = g_CuocGoi.XeNhan;

                if (xeNhan != "" && xeNhan != xeNhanCu)
                {
                    //if (!string.IsNullOrEmpty(xeNhanCu))
                    {
                        if (Config_Common.TDV_VALIDATE_XENHAN_APP)
                        {
                            string xeNhanMoi = StringTools.GetXeNhanMoi(xeNhanCu, xeNhan);
                            List<T_TaxiOperation> lstItem = T_TaxiOperation.Inst.GetList_XeDangNhanApp(g_CuocGoi.IDCuocGoi, xeNhanMoi);
                            if (lstItem != null && lstItem.Count > 0)
                            {
                                T_TaxiOperation item = lstItem[0];
                                frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.TrungXeNhanApp, item.MessageAlert, item.Id);
                                {
                                    confirmXeDon.ShowDialog();
                                    if (confirmXeDon.DialogResult == DialogResult.OK && confirmXeDon.Result == 1)
                                    {
                                        //xeDon = confirmXeDon.XeDonResult;
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.Retry;
                                        return;
                                    }
                                }
                            }
                        }
                        else if (Config_Common.TDV_XENHAN_RADIO_TO_APP)
                        {
                            string xeNhanMoi = StringTools.GetXeNhanMoi(xeNhanCu, xeNhan);
                            if (CommonBL.DictApp_Current != null && CommonBL.DictApp_Current.Count > 0)
                            {
                                if (CommonBL.DictApp_Current.ContainsKey(xeNhanMoi))
                                {
                                    string info = string.Format("Cuốc khách gối : {0} - {1}", g_CuocGoi.PhoneNumber, g_CuocGoi.DiaChiDonKhach);
                                    Taxi.Services.WCFServicesApp.SendText(CommonBL.ConvertSangBienSo(xeNhanMoi), info, CommonBL.DictApp_Current[xeNhanMoi]);
                                    g_CuocGoi.LenhTongDai = "Đã gửi cuốc gối cho lx";
                                }
                            }
                        }
                    }
                }
                #endregion

                #region XeMK

                string xeMKCu = g_CuocGoi.BTBG_NoiDungXuLy;

                if (xeMK != "" && xeMK != xeMKCu)
                {

                    if (!string.IsNullOrEmpty(xeMKCu))
                    {
                        StringTools.GetXeNhanMoi(xeMKCu, xeMK);
                    }

                    if (Config_Common.CanhBaoKhiNhapXe == 0 && !ValidateXeMK(xeMK, xeNhan))
                    {
                        g_CloseForm = false;
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                }
                #endregion

                #region chuyen vung
                int vungCu = g_CuocGoi.Vung;
                
                if (txtVung.Text.Trim() != "") // chuyen vung , dung DialogResult.Ignore 
                {
                    try
                    {
                        int kenhVung = Convert.ToInt32(txtVung.Text.Trim());
                        if (vungCu == kenhVung)
                        {
                            g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.TongGuiSangMoiKhach;
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                        if (!CheckVungNamTrongVungCauHinh(kenhVung))
                        {
                            MessageBox.MessageBoxBA msg = new MessageBox.MessageBoxBA();
                            msg.Show("Vùng chuyển phải nằm trong các vùng bộ đàm đã cấu hình.");
                            this.DialogResult = DialogResult.Cancel;
                            g_CloseForm = false;
                            return;
                        }
                        if (g_isCuocGoiKetThuc)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            GetDuLieuTuForm(ref g_CuocGoi, xeNhan, xeDon, xeMK, !xeMK.Equals(g_CuocGoi.BTBG_NoiDungXuLy));
                            if (CuocGoi.TONGDAI_UpdateChuyenVung(g_CuocGoi.IDCuocGoi,ThongTinDangNhap.USER_ID,g_CuocGoi.Vung,g_CuocGoi.LenhTongDai))
                            {
                                this.DialogResult = DialogResult.Ignore;
                                g_CloseForm = true;
                            }
                        }
                    }
                    catch 
                    {
                    }
                    
                }
                else
                {
                    GetDuLieuTuForm(ref g_CuocGoi, xeNhan, xeDon, xeMK, !xeMK.Equals(g_CuocGoi.BTBG_NoiDungXuLy));
                    this.DialogResult = DialogResult.OK;
                }
                #endregion
        
                g_CloseForm = true;
                this.Close();
            }
            else
            {
                HienThiThongBao(maValidate);
                g_CloseForm = false; 
            }
        }
        private bool ValidateXeMK(string xeMK, string xeNhan)
        {
            try
            {
                if (string.IsNullOrEmpty(xeMK))
                {
                    return true;
                }
                if (string.IsNullOrEmpty(xeNhan) || (!string.IsNullOrEmpty(xeNhan) && !xeMK.Split('.').All(p => xeNhan.Split('.').Any(pi => !string.IsNullOrEmpty(pi.Trim()) && pi.Trim() == p))))
                {
                    new MessageBox.MessageBoxBA().Show("Xe MK không thuộc xe nhận");
                    return false;
                }
            }
            catch 
            {
               
            }
            return true;
        }
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
            return bCheck;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            Close();
        }
        private void frmBodamInputDataMaiLinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_CloseForm)//Đóng Form
            {
                e.Cancel = false;
                IsOnShowDiaLog = false;
            }
            else
            {
                g_CloseForm = true;
                e.Cancel = true;                
            }
        }        
        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhongXe.Checked)
            {
                if (g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    editLenhTongDai.Text = CommonBL.GetNameByCodeEnum(Enum_CommandCode.TDV_KoXeLan1, 2);
                }
                else
                    editLenhTongDai.Text = CommonBL.GetNameByCodeEnum(Enum_CommandCode.TDV_KhongXeXL, 2);
            }
            else
            {
                editLenhTongDai.Text = ""; 
            }
        }

        private bool _isGhiChu = false;
        private void editLenhTongDai_TextChanged(object sender, EventArgs e)
        {
            //if(_isGhiChu) return;
            //_isGhiChu = true;
            //if (editLenhTongDai.Text.StartsWith("1"))
            //{
            //    editLenhTongDai.Text = LENH_1_MOIKHACH;
            //}
            //else if (editLenhTongDai.Text.StartsWith("2"))
            //{
            //    if (StringTools.TrimSpace(maskXeNhan.Text).Length <= 0 && StringTools.TrimSpace(maskXeDon.Text).Length <= 0)
            //    {
            //        if (chkKhongXe.Text.Contains("1"))
            //            editLenhTongDai.Text = LENH_5_2_KHONGXE_XINLOI;
            //        else
            //            editLenhTongDai.Text = LENH_5_KHONGXE_XINLOI;
            //        chkKhongXe.Checked = true;
            //    }
            //    else
            //    {
            //        chkKhongXe.Checked = false;
            //    }
            //}
            //else if (editLenhTongDai.Text.StartsWith("3"))
            //{
            //    if (StringTools.TrimSpace(maskXeNhan.Text).Length <= 0 && StringTools.TrimSpace(maskXeDon.Text).Length <= 0)
            //    {                    
            //        editLenhTongDai.Text = LENH_5_2_KHONGXE_XINLOI;
            //        chkKhongXe.Checked = true;
            //    }
            //    else
            //    {
            //        chkKhongXe.Checked = false;
            //    }
            //}
            //else if (editLenhTongDai.Text.StartsWith("4"))
            //{
            //    editLenhTongDai.Text = LENH_3_HOILAIDC;
            //}
            //else if (editLenhTongDai.Text.StartsWith("5"))
            //{
            //    editLenhTongDai.Text = LENH_2_GIUKHACH;
            //}
            //else if (editLenhTongDai.Text.StartsWith("6"))
            //{
            //    editLenhTongDai.Text = LENH_6_KTRAKHACH;
            //}
            //else if (editLenhTongDai.Text.StartsWith("9"))
            //{
            //    editLenhTongDai.Text = LENH_4_CHUYENKENH;
            //    txtVung.Visible = true;
            //    txtVung.Focus();
            //}
            //_isGhiChu = false;
        }
        private void editXeNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                return;
            }

            if (e.Cancelled)
            {

            }
        }

        #region XU LY HOTKEY
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                g_CloseForm = true;
                Close();
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                this.btnOK_Click(null, new EventArgs());
                if (this.DialogResult == DialogResult.Retry)
                {
                    g_CloseForm = false;
                    return true;                    
                }
                if (this.DialogResult != DialogResult.No && this.DialogResult != DialogResult.Ignore)
                    this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                btnOK.Focus(); this.btnOK_Click(null, new EventArgs());
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.H))
            {
                btnCancel.Focus(); this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                maskXeNhan.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                maskXeDon.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                editLenhTongDai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                txtVung.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                editGhiChu.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.M))
            {
                chkKetThucHoiDam.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                if (!txtDiaChiDon.ReadOnly)
                    txtDiaChiDon.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                chkTaxiGroupDon.Focus();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void maskXeNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                if (!txtDiaChiDon.ReadOnly)
                    txtDiaChiDon.Focus();
                else 
                    editGhiChu.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                
                if (maskXeMK.Visible == true)
                {
                    maskXeMK.Focus();
                }
                else
                {
                   maskXeDon.Focus();
                }
            }
        }
        private void maskXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                maskXeMK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhTongDai.Focus();
            }
        }

        private void Process_Command_KeyDown(KeyEventArgs e)
        {
            int keyInput = (int)e.KeyData;
            bool isCommand = false; //biến check xem có phải command đã cấu hình ko
            if (editLenhTongDai.Text.Length == 1)
            {
                int[] StatusCommand_Num = { 3, 4 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe)
                List<TaxiOperationCommand> lstCommand = CommonBL.Commands.FindAll(a => a.FunctionUsing == (int)Enum_ChucNangNhiemVu.TongDaiVien && a.CommandCode != Enum_CommandCode.System);
                MessageBoxBA msgDialog = new MessageBoxBA();
                foreach (var command in lstCommand)
                {
                    if (keyInput == command.Shortcuts)
                    {
                        isCommand = true;
                    }
                    else if (keyInput >= 96 && keyInput <= 105)
                    {
                        //Command là phím 0-9 (tính cả bên dãy phím số)
                        if (keyInput - command.Shortcuts == 48)
                            isCommand = true; // ưu tiên phím số vì có 2 chỗ nhập phím số
                        else continue;
                    }
                    else
                    {
                        continue;
                    }

                    if (isCommand)
                    {                        
                        string commandText = command.Command;
                        if (command.CallType != null && (KieuCuocGoi)command.CallType != KieuCuocGoi.GoiTaxi)
                        {
                            lblThongBao.Text = string.Format("Phải là cuộc gọi xe mới được thực hiện lệnh [{0}]", commandText);
                            return;
                        }
                        else if (command.RequireVehicle && string.IsNullOrEmpty(g_CuocGoi.XeNhan))
                        {
                            lblThongBao.Text = string.Format("Phải có xe nhận mới được thực hiện lệnh [{0}]", commandText);
                            return;
                        }
                        //Hoặc trường hợp không xe xin lỗi khách thì bắt buộc phải ko dc có xe nhận
                        else if ((!command.RequireVehicle
                            && !string.IsNullOrEmpty(g_CuocGoi.XeNhan)
                            && (command.CommandCode == Enum_CommandCode.TDV_KhongXeXL)))
                        {
                            lblThongBao.Text = string.Format("Phải chưa có xe nhận mới được thực hiện lệnh [{0}]", command.Command);
                            return;
                        }
                        int[] CallStatusNum = { 1, 2, 3, 4, 6 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe, Không xe lần 1)
                        if (command.CallStatus != null && CallStatusNum.Contains(command.CallStatus.Value))
                        {
                            g_CuocGoi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)command.CallStatus;
                        }
                        if (command.IsSend_CallCust != null) g_CuocGoi.ChuyenMK = (bool)command.IsSend_CallCust;

                        editLenhTongDai.Text = commandText;
                        break;
                    }
                }
            }
        }
        private void editLenhTongDai_KeyUp(object sender, KeyEventArgs e)
        {
            Process_Command_KeyDown(e);
        }

        private void editLenhTongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                if (maskXeDon.Visible == true)
                {
                    maskXeDon.Focus();
                }
                else
                {
                    maskXeNhan.Focus();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                editGhiChu.Focus();
            }
        }
        private void txtVung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                editLenhTongDai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editGhiChu.Focus();
            }
        }
        private void editGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                editLenhTongDai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkTruot.Focus();
            }
        }
        private void chkTruot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                editLenhTongDai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkHoan.Focus();
            }
        }
        private void chkHoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                chkTruot.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkKhongXe.Focus();
            }
        }
        private void chkKhongXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                chkHoan.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkDaNhanGoiLai.Focus();
            }
        }
        private void chkDaNhanGoiLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                chkKhongXe.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkKetThucHoiDam.Focus();
            }
        }
        private void chkKetThucHoiDam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                chkDaNhanGoiLai.Focus();
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
                chkKetThucHoiDam.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnCancel.Focus();
            }
        }

        private void txtDiaChiDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (maskXeDon.Visible == true)
                {
                    maskXeDon.Focus();
                }
                else
                {
                    maskXeNhan.Focus();
                }
            }
        }
        #endregion XU LY HOTKEY

        #endregion

        private void chkTaxiGroupDon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaxiGroupDon.Checked)
            {
                maskXeDon.Text = XeDaDon;
                if (maskXeNhan.Text.Length <= 0)
                    maskXeNhan.Text = XeDaDon;
                else
                    maskXeNhan.Text =XuLyChuoi(maskXeNhan.Text)+XeDaDon;
            }
            else
            {
                maskXeDon.Text = XuLyChuoi(maskXeDon.Text.Replace(XeDaDon, ""));
                maskXeNhan.Text = XuLyChuoi(maskXeNhan.Text.Replace(XeDaDon, ""));
            }
        }

        private string XuLyChuoi(string str)
        {
            while (str.IndexOf("..") > 0)
            {
                str = str.Replace("..", ".");
            }
            return str;
        }

        private void chkTruot_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkHoan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskXeMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
            if (e.KeyCode == Keys.Up)
            {
                if (maskXeNhan.Visible)
                    maskXeNhan.Focus();
                else
                    txtDiaChiDon.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {

                if (maskXeDon.Visible == true)
                {
                    maskXeDon.Focus();
                }
                else
                {
                    maskXeDon.Focus();
                }
            }
        }

        private void txtDiaChiDon_TextChanged(object sender, EventArgs e)
        {
            IsChangeDiaChiDon = true;
        }

        private void txtDiaChiTra_TextChanged(object sender, EventArgs e)
        {
            IsChangeDiaChiTra = true;
        }

        private void maskXeDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void maskXeMK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }       
    }
}