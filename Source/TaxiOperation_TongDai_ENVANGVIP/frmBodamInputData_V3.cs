using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using System.Threading;
using Taxi.Business.DM;
using Taxi.Entity;
using Janus.Windows.GridEX;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using Taxi.Services;
using TaxiOperation_TongDai;
using Taxi.Services.WCFServices;
using Taxi.Utils.Enums;
using TaxiApplication;
using Taxi.Controls.FastTaxis;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace Taxi.GUI
{
    public partial class frmBodamInputData_V3: Form
    {
        #region ==========================Init=================================

        private string MSG_8_XENHANDANHANDIEMKHAC = "Xe nhận này đã nhận đón ở địa chỉ khác.";
        private string MSG_CoXeDangNghi = string.Empty;

        //------------------LENH TONG DAI ----------------------------------------
        private const string LENH_1_MOIKHACH = "mời khách";
        private const string LENH_2_GIUKHACH = "giữ khách";
        private const string LENH_3_HOILAIDC = "hỏi lại địa chỉ";
        private const string LENH_4_CHUYENKENH = "chuyển kênh";
        private const string LENH_5_KHONGXE_XINLOI = "Ko xe lần 1";
        private const string LENH_5_2_KHONGXE_XINLOI = "Ko xe xin lỗi khách";        
        private const string LENH_6_KTRAKHACH = "kiểm tra khách";
       

        // ---------------- 
        // global variables
        private   List<string> g_ListSoHieuXe;
        private CuocGoi g_cuocGoi;
        private DateTime g_TimeServer;
        private bool g_isCuocGoiKetThuc=false;
        private int G_XeDonLength = 0;
        private bool g_CloseForm = true;    // kiểm soát đóng form
        private bool g_IsKetThuc = false;
        private bool g_IsThoatDuoc999 = false;
        public bool IsKetThuc()
        {
            return g_IsKetThuc;
        }
        public CuocGoi GetCuocGoi
        {
            get 
            {                  
                return g_cuocGoi; 
            }
        }
        private BackgroundWorker bw = new BackgroundWorker();
        public List<CuocGoi> G_ListCuocGoi { get; set; }
        public bool lenhDHChanged = true;
        public bool isLoadForm = true;
        public bool isResendMobile = false;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_AnCa;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_MatLL;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_RoiXe;
        public Dictionary<string, GiamSatXe_LienLac> dicGiamSat_BaoHong;
        public Dictionary<string, GiamSatXe_HoatDong> dicXeHoatDong;
        #endregion

        #region =======================Constructor=============================
        public frmBodamInputData_V3(DateTime timeServer, CuocGoi cuocGoi, List<string> listSoHieuXe, bool isCuocGoiKetThuc, int soLuongCS, bool IsThoatCuoc999)
        {
            InitializeComponent();
            g_isCuocGoiKetThuc = isCuocGoiKetThuc;
            g_cuocGoi = cuocGoi;
            g_ListSoHieuXe = listSoHieuXe;
            g_TimeServer = timeServer;
            //if (soLuongCS == 0)
            //    maskXeDon.Visible = true;
            //else
            //    maskXeDon.Visible = false;

            g_IsThoatDuoc999 = IsThoatCuoc999;
                
            txtDiaChiDon.ReadOnly = !ThongTinDangNhap.HasPermission(DanhSachQuyen.CuocGoi_TD_SuaDiaChiDon);
            
        }
        
        #endregion

        #region ========================Load Form==============================
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            SetDuLieuLenForm(g_cuocGoi);
            HienThiControl(g_cuocGoi);
            SetControlForKetThuc(g_cuocGoi);
            ThayDoiTrangThaiNhomControl(g_cuocGoi);
            if (g_cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiLai)
            {
                ActiveControl = editLenhTongDai;
            }
            if (maskXeNhan.Enabled)
            {
                ActiveControl = maskXeNhan;
                int length = maskXeNhan.Text.Length;
                if (length > 0)
                {
                    maskXeNhan.TextBox.SelectionLength = 0;
                    maskXeNhan.TextBox.SelectionStart = length;
                    SendKeys.Send("{RIGHT}");
                }
            }
            if (g_cuocGoi.DanhSachXeDeCu != "" && g_cuocGoi.GPS_KinhDo > 0 && g_cuocGoi.GPS_ViDo > 0)
            {
                bw.DoWork += bw_DoWork;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
            if (chkMobileService.Checked)
            {
                maskXeDon.TextBox.Enabled = true;
                maskXeNhan.TextBox.Enabled = true;
            }
            //chkMobileService.Visible = false;
            isLoadForm = false;
            XuLyThongTinLenhLaiXe(g_cuocGoi);
        }

        /// <summary>
        /// hàm thực hiện set dữ liệu lên form
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// 
        private void SetDuLieuLenForm(CuocGoi cuocGoi)
        {
            lblLinePhoneTime.Text = "[" + cuocGoi.Line + "]  " + cuocGoi.PhoneNumber + "  " + cuocGoi.ThoiDiemGoi;
            txtDiaChiDon.Text = cuocGoi.DiaChiDonKhach;
            lblSoLuong_LoaiXe.Text = LayThongTinLoaiXe(cuocGoi.SoLuong.ToString(), cuocGoi.LoaiXe);
            lblDSXeDeCu.Text = string.Empty;
            lblTimeCapNhatXeDeCu.Visible = false;
            lblLenhLX.Text = cuocGoi.MH_LenhLaiXe;
            lblGhiChuLX.Text = cuocGoi.GhiChuLaiXe;
            
            if(!string.IsNullOrEmpty(cuocGoi.XeDon))
            {
                maskXeNhan.TextBox.Enabled = false;
            }
                       
            if (cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length > 0)
            {
                maskXeNhan.TextBox.Text = cuocGoi.XeNhan + ".";
                maskXeNhan.TextBox.SelectionStart = maskXeNhan.TextBox.Text.Length;
            }
            else
            {
                if (cuocGoi.DanhSachXeDeCu != null && cuocGoi.DanhSachXeDeCu.Length > 0)
                {
                    lblDSXeDeCu.Text = cuocGoi.DanhSachXeDeCu;
                    lblTimeCapNhatXeDeCu.Visible = true;
                    TimeSpan timeSpan = g_TimeServer - cuocGoi.ThoiDiemCapNhatXeDeCu;
                    lblTimeCapNhatXeDeCu.Text = string.Format("(cập nhật : {0:0} phút trước)", timeSpan.TotalMinutes);
                }
            }
            maskXeDon.Text = cuocGoi.XeDon;
            editLenhTongDai.TextBox.Text = cuocGoi.LenhTongDai;
            editGhiChu.TextBox.Text = cuocGoi.GhiChuTongDai;
            txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach;

            if (g_cuocGoi.FT_IsFT)
            {
                lblLinePhoneTime.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber,
                              cuocGoi.FT_SendDate);
                label24.Text = string.Format("{0:HH:mm}", g_cuocGoi.FT_Date);
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
                label24.Text = string.Format("{0:HH:mm}", g_cuocGoi.ThoiDiemGoi);
                label24.Visible = false;
                //chkHoan.Enabled = true;
                //chkKhongXe.Enabled = true;
                //chkDaNhanGoiLai.Enabled = true;
                //chkKetThucHoiDam.Enabled = true;
            }
            
            if(EnVangManagement.ConfigEnVang)
            {
                lblLenhTD.Text = "(t: trượt, h: hủy/hoãn)";
               // if (cuocGoi.XeDon == null || cuocGoi.XeDon == "")
                {                    
                    maskXeDon.TextBox.Enabled = false;
                }
            }

            if ((cuocGoi.KhongDungMobileService != null && cuocGoi.KhongDungMobileService.Value) || !ThongTinCauHinh.GPS_TrangThai)
            {
                chkMobileService.Checked = true;
                chkMobileService.Enabled = false;
            }

            //XuLyThongTinLenhLaiXe(cuocGoi);
        }
        /// <summary>
        /// hàm thực hiện set control cho xử lý kết thúc
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void SetControlForKetThuc(CuocGoi cuocGoi)
        {
            // Xu ly ket thuc
            if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiTaxi && cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length > 0)
                chkTruot.Enabled = true;
            else
                chkTruot.Enabled = false;
            // Điện thoại đã chọn hoãn //
            if (cuocGoi.LenhDienThoai.Contains("khách hoãn") || cuocGoi.LenhDienThoai.Contains("Hủy xe/Hoãn")){
                chkHoan.Enabled = true;
                if( cuocGoi.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiHoan)
                    chkHoan.Checked = true;
            }
            else
                chkHoan.Enabled = false;
           
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
        /// <param name="cuocGoi"></param>
        private void GetDuLieuTuForm(ref CuocGoi cuocGoi, string xeNhan, string xeDon)
        {
            //--update xe nhận và tọa độ
            //updateDSXeNhan_ToaDo();

            cuocGoi.XeNhan = xeNhan;
            cuocGoi.XeDon = xeDon;
            lenhDHChanged = cuocGoi.LenhTongDai != StringTools.TrimSpace(editLenhTongDai.TextBox.Text);
            cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.BoDam; // tong dai truyen sang
            //cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;            
            if (!txtDiaChiDon.ReadOnly)
                cuocGoi.DiaChiDonKhach = txtDiaChiDon.Text.Trim();
            cuocGoi.DiaChiTraKhach = txtDiaChiTra.Text;
            if (cuocGoi.XeDon.Length > 0)
            {
                if (g_IsKetThuc)
                {
                    cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                    cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                }
            }
            cuocGoi.LenhTongDai = StringTools.TrimSpace(editLenhTongDai.TextBox.Text);
            cuocGoi.GhiChuTongDai = StringTools.TrimSpace(editGhiChu.TextBox.Text);

            if (chkTruot.Checked) // cuoc goi truot
            {
                cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiTruot;
                cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                cuocGoi.XeDon = string.Empty;
            }
            if (chkHoan.Checked)
            {
                cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiHoan;
                cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                cuocGoi.XeDon = string.Empty;
            }
            cuocGoi.KhongDungMobileService = chkMobileService.Checked;
            //if (chkDaNhanGoiLai.Checked && cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiLai)
            //{
            //    cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
            //    cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
            //}

            int vung = 0;
            try
            {                
                if (txtVung.Text.Length > 0)
                {
                    vung = Convert.ToInt32(txtVung.Text);
                } 
            }
            catch (Exception ex)
            {
                vung = 0;
            }
            if (vung > 0)
            {
                cuocGoi.Vung = vung;
            }
        }

        /// <summary>
        /// hàm trả về thông số lượng loại xe.
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <returns></returns>
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
        /// hàm thực hiện validate form
        /// </summary>
        /// <param name="g_CuocGoi"></param>
        /// <returns></returns>
        private EnVangManagement.BangMaValidate ValidateFormNhap(CuocGoi cuocGoi)
        {
            // Check xe nhận
            string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.TextBox.Text);
            if (xeNhan != null && xeNhan.Length > 0)
            {
                MSG_CoXeDangNghi = string.Empty;
                if(!EnVangManagement.ValidateNhieuSoHieuXe(xeNhan))
                {
                    return EnVangManagement.BangMaValidate.XeTimKhongDungDinhDang;
                }
                if (!Global.KhongCheckXeOnline)
                {
                    if (!KiemTraXeNhan(xeNhan))
                    {
                        return EnVangManagement.BangMaValidate.NhapChinhXacXe;
                    }
                }
                if (StringTools.KiemTraTrungLapXeChay(xeNhan))
                {
                    return EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan;
                }
                else if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0 && KiemTraXeCoTrongCuocKhachHienTai(cuocGoi.IDCuocGoi, xeNhan))
                {
                    if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan == 1)
                    {
                        return EnVangManagement.BangMaValidate.XeNhanDaDonOCuocGoiKhac;
                    }
                    else
                    {
                        var result = new MessageBox.MessageBoxBA().Show(this, MSG_8_XENHANDANHANDIEMKHAC, "Thông báo", MessageBox.MessageBoxButtonsBA.OKCancel, MessageBox.MessageBoxIconBA.Question);
                        if (result == "OK") return EnVangManagement.BangMaValidate.ValidateSuccess;
                        else return EnVangManagement.BangMaValidate.KhongChapNhanXeDonOCuocKhac;
                    }
                }
            }
            // Kiểm tra xe đó có nằm trong xe nhận
            string xeDon = StringTools.ConvertToChuoiXeNhanChuan(maskXeDon.Text);
            if (xeDon != null && xeDon.Length > 0)
            {
                if (StringTools.KiemTraTrungLapXeChay(xeDon))
                {
                    return EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan;
                }
            }
            // Kiểm tra nhập kênh khi không xe chuyển vùng
            if (editLenhTongDai.Text == LENH_1_MOIKHACH && (xeNhan == null || xeNhan.Trim() == ""))
            {
                return EnVangManagement.BangMaValidate.MoiKhachChuaCoXeDon;
            }
            return EnVangManagement.BangMaValidate.ValidateSuccess;
        }

        /// <summary>
        /// hien thi thong bao 
        /// </summary>
        /// <param name="maValidate"></param>
        private void HienThiThongBao(EnVangManagement.BangMaValidate maValidate)
        {
            lblThongBao.Visible = true;
            string message = string.Empty;
            if (maValidate == EnVangManagement.BangMaValidate.ValidateSuccess)
            {
                message = string.Empty;
                lblThongBao.Visible = false;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapChinhXacXe)
            {
                message = EnVangManagement.MSG_1_NHAPCHINHXACXE;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.NhapXeDonThuocXeNhan)
            {
                message = EnVangManagement.MSG_2_NHAPXEDONTHUOCXENHAN;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.XeNhanDaDonOCuocGoiKhac)
            {
                message = MSG_8_XENHANDANHANDIEMKHAC;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.MoiKhachChuaCoXeDon)
            {
                message = EnVangManagement.MSG_9_MoiKhachKhongXeDon;
            }
            else if (maValidate == EnVangManagement.BangMaValidate.CoXeDangNghi)
            {
                message = MSG_CoXeDangNghi;
            }
            lblThongBao.Text = message;
        }

        /// <summary>
        /// Hiển thị control là gọi taxi
        /// UnVisibile
        ///    - lblChuyenVung
        ///    - txtVung        
        /// Disable
        ///    -chkTruot
        ///    -chkHoan
        ///     - chkKhongXe
        ///     - chkDaNhanGoiLai
        ///     - KetthucHoiDam
        /// </summary>
        private void HienThiControl_GoiTaxi()
        {
            lblVungChuyen.Visible = false;
            txtVung.Visible = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
            if (g_cuocGoi.XeNhan == null || g_cuocGoi.XeNhan != "")
            {
                chkHoan.Enabled = true;
            }
        }
        /// <summary>
        /// hàm thực hiện hiển thị control cuộc gọi lại
        /// </summary>
        private void HienThiControl_GoiLai()
        {
            lblVungChuyen.Visible = false;
            txtVung.Visible = false;

            maskXeNhan.TextBox.Enabled = false;
            maskXeDon.TextBox.Enabled = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
            editLenhTongDai.Enabled = true;
            //chkDaNhanGoiLai.Checked = true;
        }

        private void HienThiControl(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiTaxi)
            {
                HienThiControl_GoiTaxi();
            }
            else if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiLai)
            {
                HienThiControl_GoiLai();
            }
            else if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiHoiDam)
            {
                HienThiControl_GoiHoiDam();
            }
            ////Nếu có nội dung tin nhắn chưa đọc thì hiển thị nội dung lên màn hinh
            //if (cuocGoi.TinNhanDHV_DaDoc == false)//{
            //    setViewMessageControl(true);
            //    txtTinNhan.Text = cuocGoi.TinNhanDHV;
            //}
            //else
            //{
            //    setViewMessageControl(false);
            //    txtTinNhan.Text = "";
            //}
            IsFastTaxi.Visible = g_cuocGoi.FT_IsFT;
            if (!g_cuocGoi.FT_IsFT)
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

            maskXeNhan.TextBox.Enabled = false;
            maskXeDon.TextBox.Enabled = false;

            chkTruot.Enabled = false;
            chkHoan.Enabled = false;
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
            var existInDB = EnVangManagement.KiemTraPTDSThuocDSKhac(xeNhan, g_ListSoHieuXe,ref G_XeDonLength);
            var existInOnline = true;
            if(!chkMobileService.Checked)
            {
                var privateCodes = ProcessFastTaxi.GetVehiclePlatesFromPrivateCode(xeNhan, ".");
                existInOnline = !string.IsNullOrEmpty(privateCodes);
            }
            return existInDB && existInOnline;
        }

        /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        /// <param name="lstDienThoai"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        private bool KiemTraXeCoTrongCuocKhachHienTai(long idCuocGoi, string SoHieuXe)
        {
            string[] arrTaxi = SoHieuXe.Split('.');
            foreach (CuocGoi objDH in G_ListCuocGoi)
            {
                if (objDH.IDCuocGoi == g_cuocGoi.IDCuocGoi) continue;
                if (objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (Array.IndexOf(arrTaxi, arrXeDaNhan[i]) > -1 && objDH.IDCuocGoi != idCuocGoi)
                        {
                            MSG_8_XENHANDANHANDIEMKHAC = string.Format("Xe {0} đã nhận đón ở địa chỉ {1}", arrXeDaNhan[i], objDH.DiaChiDonKhach);
                            return true;
                        }
                }
            }
            return false;
        }

        /// <summary>
        /// Input :
        ///     - SoXeDon : 2  
        ///     - XeDon : 123.356
        /// Output :
        ///     - True if la dung
        ///     - False if la sai
        /// </summary>
        /// <param name="SoXeDon"></param>
        /// <param name="XeDon"></param>
        /// <returns></returns>        
        private bool CheckSoXeDonVoiXeDon(int SoXeDon, string XeDon)
        {
            int intSoXe = 0;

            string[] arrXeDons = XeDon.Split(".".ToCharArray());
            intSoXe = arrXeDons.Length;

            if (SoXeDon == intSoXe)
                return true;
            else return false;
        }

        #endregion Validate dữ liệu Form          
        
        #region ========================Form Events============================

        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            EnVangManagement.BangMaValidate maValidate = new EnVangManagement.BangMaValidate();
            if ((!maskXeDon.TextBox.Enabled && !maskXeNhan.TextBox.Enabled) || chkTruot.Checked || chkTaxiGroupDon.Checked)
            {
                maValidate = EnVangManagement.BangMaValidate.ValidateSuccess;
                if (chkTaxiGroupDon.Checked && (maskXeDon.Text == "" || maskXeDon.Text.Trim()==""))
                {
                    lblThongBao.Text = "Cuộc gọi phải là gọi taxi và có xe nhận đón";                   
                    return;
                }
            }
            else
            {
                maValidate = ValidateFormNhap(g_cuocGoi);
            }

            if (maValidate == EnVangManagement.BangMaValidate.ValidateSuccess)
            {
                g_cuocGoi.KhongDungMobileService = chkMobileService.Checked;
                string xeDon = StringTools.ConvertToChuoiXeNhanChuan(maskXeDon.Text);
                string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text);
                string xeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(g_cuocGoi.XeDenDiem);
                #region XeDon
                if (xeDon != null && xeDon.Length > 0 && xeDon != g_cuocGoi.XeDon)
                {
                    //Nếu là cuộc gọi FastTaxi và khách hàng chưa xác nhận đã gặp xe thì cảnh báo
                    if (g_cuocGoi.FT_IsFT && g_cuocGoi.FT_Status != Enum_FastTaxi_Status.NhapXeDon)
                    {
                        if (new MessageBox.MessageBoxBA().Show("Khách hàng chưa xác nhận đã gặp xe. Bạn có muốn tiếp tục nhập xe đón không ?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question).ToLower().Equals("no"))
                        {
                            return;
                        }
                    }
                    if (G_XeDonLength < g_cuocGoi.SoLuong)
                    {
                        string message = "Chưa đủ xe số lượng xe yêu cầu";
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(Taxi.Utils.KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message, xeDon))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == DialogResult.OK)
                            {
                                if (confirmXeDon.Result == 2)
                                {
                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_cuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                    else if (G_XeDonLength > g_cuocGoi.SoLuong)
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
                                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_cuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan))
                                {
                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                #endregion

                #region XeNhan

                string xeNhanCu = g_cuocGoi.XeNhan;
                var error = string.Empty;

                if (xeNhan != "" && !chkTruot.Checked && !chkTaxiGroupDon.Checked)
                {
                    var lstXeNhan = xeNhan.Split(".".ToCharArray());
                    foreach (string xe in lstXeNhan)
                    {
                        if (dicGiamSat_AnCa.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang ăn ca. Xin nhập lại", xe);
                            break;
                        }
                        if (dicGiamSat_MatLL.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang mất liên lạc. Xin nhập lại", xe);
                            break;
                        }
                        if (dicGiamSat_RoiXe.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang rời xe. Xin nhập lại", xe);
                            break;
                        }
                        if (dicGiamSat_BaoHong.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} báo hỏng. Vui lòng điều xe khác", xe);
                            break;
                        }
                        //if (Config_Common.ChenCuoc_HoaHong)
                        //{
                        //    if (dicXeHoatDong.ContainsKey(xe))
                        //    {
                        //        GiamSatXe_HoatDong item = dicXeHoatDong[xe];
                        //        if (item.TrangThaiLaiXeBao != (int)Enum_TrangThaiLaiXeBao.BaoDiemDo
                        //            && (item.TrangThaiLaiXeBao == (int)Enum_TrangThaiLaiXeBao.BaoRaKinhDoanh && item.DiemDo.Value == 0))
                        //        {
                        //            error = string.Format("Xe {0} chưa báo điểm đỗ", xe);
                        //            break;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        error = string.Format("Xe {0} chưa ra kinh doanh", xe);
                        //        break;
                        //    }
                        //}
                        if (chkDieuLai.Checked)
                        {
                            g_cuocGoi.isResendMobile = true;
                            g_cuocGoi.XeDon = "";
                        }
                    }
                }
                else
                {
                    if (chkDieuLai.Checked)
                    {
                        error = string.Format("Vui lòng nhập xe nhận");
                    }
                }

                if (!string.IsNullOrEmpty(error))
                {
                    lblThongBao.Text = error;
                    g_CloseForm = false; // chưa đóng form
                    return;
                }
                #endregion

                #region chuyen vung
                int vungCu = g_cuocGoi.Vung;
                
                if (txtVung.Text.Trim() != "") // chuyen vung , dung DialogResult.Ignore 
                {
                    try
                    {
                        int kenhVung = 0;
                        kenhVung = Convert.ToInt32(txtVung.Text.Trim());
                        if (vungCu == kenhVung)
                        {
                            g_cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach;
                            this.DialogResult = DialogResult.OK;
                            return;
                        }
                        if (!CheckVungNamTrongVungCauHinh(kenhVung))
                        {
                            MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
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
                            GetDuLieuTuForm(ref g_cuocGoi, xeNhan, xeDon);
                            if (CuocGoi.TONGDAI_UpdateChuyenVung(g_cuocGoi.IDCuocGoi,ThongTinDangNhap.USER_ID,g_cuocGoi.Vung,g_cuocGoi.LenhTongDai))
                            {
                                this.DialogResult = DialogResult.Ignore;
                                g_CloseForm = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    
                }
                else
                {
                    GetDuLieuTuForm(ref g_cuocGoi, xeNhan, xeDon);
                    this.DialogResult = DialogResult.OK;
                }
                #endregion

                if(!chkMobileService.Checked)
                {
                    if (chkTaxiGroupDon.Checked && !string.IsNullOrEmpty(g_cuocGoi.XeDon))
                    {
                        g_cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    }
                }
                else
                {
                    if(!string.IsNullOrEmpty(g_cuocGoi.XeDon))
                    {
                        g_cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    }
                }
                
                g_CloseForm = true;
                this.Close();
            }
            else
            {
                HienThiThongBao(maValidate);
                g_CloseForm = false; // chưa đóng form
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            Close();
        }

        private void frmBodamInputDataMaiLinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_CloseForm)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }        

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// kiem soat nhap phim 1;2;3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void editLenhTongDai_TextChanged(object sender, EventArgs e)
        {
            if (!EnVangManagement.ConfigEnVang) EditLenhTongDaiTextChangeOld();
            else EditLenhTongDaiTextChangeNew();
        }

        /// <summary>
        /// Event cho lệnh tổng đài cũ
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/12/2015   created
        /// </Modified>
        private void EditLenhTongDaiTextChangeOld()
        {
            if (editLenhTongDai.TextBox.Text.StartsWith("1"))
            {
                editLenhTongDai.TextBox.Text = LENH_1_MOIKHACH;
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("2"))
            {
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("3"))
            {
                if (StringTools.TrimSpace(maskXeNhan.Text).Length <= 0 && StringTools.TrimSpace(maskXeDon.Text).Length <= 0)
                {
                    // if (chkKhongXe.Text.Contains("1"))
                    editLenhTongDai.TextBox.Text = LENH_5_2_KHONGXE_XINLOI;
                    // else
                    // editLenhTongDai.TextBox.Text = LENH_5_KHONGXE_XINLOI;
                }
                else
                {
                }
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("4"))
            {
                editLenhTongDai.TextBox.Text = LENH_3_HOILAIDC;
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("5"))
            {
                editLenhTongDai.TextBox.Text = LENH_2_GIUKHACH;
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("6"))
            {
                editLenhTongDai.TextBox.Text = LENH_6_KTRAKHACH;
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("9"))
            {
                editLenhTongDai.TextBox.Text = LENH_4_CHUYENKENH;
                txtVung.Visible = true;
                txtVung.Focus();
            }            
        }

        /// <summary>
        /// Edit lệnh tổng đài cho én vàng
        /// </summary>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/12/2015   created
        /// </Modified>
        private void EditLenhTongDaiTextChangeNew()
        {
            if (editLenhTongDai.TextBox.Text.StartsWith("t"))
            {
                editLenhTongDai.TextBox.Text = EnVangManagement.LENH_TRUOTCHUA;
            }
            else  if (editLenhTongDai.TextBox.Text.StartsWith("h"))
            {
                editLenhTongDai.TextBox.Text = EnVangManagement.LENH_HUYXE;
            }
        }

        private void editXeNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
            //{

            //    e.Handled = false;

            //}
            //else if (e.KeyChar == (char)Keys.Enter)
            //{
            //    e.Handled = false;
            //}
            //else
            //    e.Handled = true;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //string xeNhan = e.Argument.ToString();
            //if (!KiemTraXeDonThuocXeNhan(xeNhan,g_cuocGoi.DanhSachXeDeCu))
            //{
            //    T_XeOnline XeOnline = new SyncServiceOnlineClient().GetXeOnlineBySHX(xeNhan);
            //    new Taxi.Data.CuocGoi().TONGDAI_GhiLog_XeNhan(g_cuocGoi.IDCuocGoi,xeNhan,g_cuocGoi.GPS_KinhDo,g_cuocGoi.GPS_ViDo,g_cuocGoi.DanhSachXeDeCu,g_cuocGoi.DanhSachXeDeCu_TD);
            //}
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // MessageBox.Show("Processing cancelled.");
                return;
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
            else if (keyData == (Keys.Alt | Keys.U))
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
            else if (keyData == (Keys.Alt | Keys.A))
            {
                chkTaxiGroupDon.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                if (!txtDiaChiDon.ReadOnly)
                    txtDiaChiDon.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                if (chkMobileService.Enabled)
                {
                    chkMobileService.Checked = !chkMobileService.Checked;
                }
                return true;
            }
            return false;
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
                if (maskXeDon.Visible == true)
                {
                    maskXeDon.Focus();
                }
                else
                {
                    editLenhTongDai.Focus();
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
                maskXeNhan.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhTongDai.Focus();
            }
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
            }
            else if (e.KeyCode == Keys.Down)
            {
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

        #region -----------------------Xe nhận - GPS--------------------------------
        private string CheckXeNhanQuaXa(string xeNhan, double KD, double VD)
        {
            if (KD <= 0) return xeNhan.TrimEnd('.').TrimStart('.');

            string XeNhan = string.Empty;
            double KhoangCach = 0;
            string[] arrXeNhan = xeNhan.Split('.');
            if (arrXeNhan.Length > 0)
            {                
                for (int i = 0; i < arrXeNhan.Length; i++)
                {
                    try
                    {
                        KhoangCach = new SyncServiceOnlineClient().GetKCXeNhan_DiemDonKhach(KD, VD, ThongTinCauHinh.GPS_MaCungXN, arrXeNhan[i]);
                    }
                    catch (Exception ex)
                    {
                        return xeNhan;
                    }
                    
                    if (KhoangCach > ThongTinCauHinh.GPS_BKXeNhan)
                    {
                        string message = string.Format("Xe {0} cách điểm đón khách {1}(km).Đã phát đàm và vẫn cho nhận?", arrXeNhan[i], Math.Round(KhoangCach / 1000, 1));
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(Taxi.Utils.KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa, message))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == DialogResult.OK)
                            {
                                if (confirmXeDon.Result == 1)
                                {
                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(g_cuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, Taxi.Utils.KieuCanhBaoKhiNhapThongTin.XeNhanQuaXa))
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                    }
                                }
                                else
                                {
                                    XeNhan += arrXeNhan[i] + ".";
                                }
                            }
                            else
                            {
                                XeNhan = xeNhan;
                            }
                        }
                    }
                    else if (KhoangCach == -1)
                    {
                        new MessageBox.MessageBoxBA().Show(string.Format("Xe {0} đang mất tín hiệu", arrXeNhan[i]), "Xe nhận mất tín hiệu", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        //XeNhan += arrXeNhan[i] + ".";
                    }
                    else if (KhoangCach == -2)
                    {
                        new MessageBox.MessageBoxBA().Show(string.Format("Lỗi, không tìm được xe {0}", arrXeNhan[i]), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        //XeNhan += arrXeNhan[i] + ".";
                    }
                }
            }
            return XeNhan.TrimEnd('.');
        }
        
        private string g_Return_TD = string.Empty;
        private string g_Return = string.Empty;
        private string g_XeNhan_Truoc = string.Empty;
        private bool updateDSXeNhan_ToaDo()
        {
            try
            {
                double KD = g_cuocGoi.GPS_KinhDo;
                double VD = g_cuocGoi.GPS_ViDo;
                if (KD == 0 || VD == 0)
                    return false;

                string dsXeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text);//Chuỗi xe nhận hiện tại vừa nhập
                if (dsXeNhan == "")
                    return false;

                string dsToaDo = "";
                string[] arrDSToaDoTruoc = null;
                string[] arrDSXeNhan = dsXeNhan.Split('.');//-----Cắt chuỗi xe nhận vừa nhập
                string[] arrDSXeNhanTruoc = null;
                string dsXeNhanTruoc = "";
                string dsToaDoTruoc = "";
                string dsXeNhanMoi = "";
                string[] arrDSToaDoMoi;

                if (g_XeNhan_Truoc != "")//-----TH đã có xe nhận đã nhập trước đó
                {
                    if (g_cuocGoi.XeNhan_TD == null || g_cuocGoi.XeNhan_TD == "")
                    {
                        //-------Nếu Tọa độ xe nhận cũ không có, lấy lại tọa độ của xe nhận cũ
                        string toaDoTruoc = getToaDoXeNhanMoi(g_cuocGoi.XeNhan, KD, VD);
                        if (toaDoTruoc != "")
                            arrDSToaDoTruoc = toaDoTruoc.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }
                    else
                    {
                        arrDSToaDoTruoc = g_cuocGoi.XeNhan_TD.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }

                    arrDSXeNhanTruoc = g_XeNhan_Truoc.Split('.');//-----Cắt chuỗi xe nhận cũ
                    //----phân tích chuỗi xe nhận vừa nhập để so sánh xem xe nhận nào là cũ và xe nào là mới nhập
                    for (int i = 0; i < arrDSXeNhan.Length; i++)
                    {
                        if (arrDSXeNhan[i] != "")//-----Nếu xe nhận khác rỗng
                        {
                            //---duyệt trong chuỗi xe nhận trước đó
                            for (int j = 0; j < arrDSXeNhanTruoc.Length; j++)
                            {
                                if (arrDSXeNhanTruoc[j] == arrDSXeNhan[i])//----Nếu xe nhận cũ có nằm trong danh sách xe nhận vừa nhập
                                {//---Gán xe nhận và tọa độ trước ra 1 chuỗi khác (1)
                                    dsXeNhanTruoc = string.Format("{0}{1}.", dsXeNhanTruoc, arrDSXeNhan[i]);
                                    dsToaDoTruoc = string.Format("{0}{1},", dsToaDoTruoc, arrDSToaDoTruoc[j]);
                                    break;
                                }
                                else//----Nếu xe nhận cũ không nằm trong danh sách xe nhận vừa nhập 
                                {
                                    //-----Kiểm tra xem xe nhận có tồn tại trong chuỗi đã nhập trước đó ko.
                                    if (Array.IndexOf(arrDSXeNhan, arrDSXeNhanTruoc[j]) == -1)
                                    {
                                        dsXeNhanMoi = string.Format("{0}{1}.", dsXeNhanMoi, arrDSXeNhan[i]);//Gán xe nhận mới vào chuỗi khác (2)
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (dsXeNhanMoi.LastIndexOf(',') > 0)
                        dsXeNhanMoi = dsXeNhanMoi.Substring(0, dsXeNhanMoi.Length - 1);
                }
                else//-----TH chưa có xe nhận trước đó
                {
                    dsXeNhanMoi = dsXeNhan;
                }

                if (dsXeNhanMoi != "")
                {
                    dsToaDo = string.Format("{0}{1},", dsToaDoTruoc, getToaDoXeNhanMoi(dsXeNhanMoi, KD, VD));//----Tọa độ của danh sách xe nhận đã sắp xếp
                    g_Return = string.Format("{0}{1}.", dsXeNhanTruoc, dsXeNhanMoi);//----Danh sách xe nhận đã sắp xếp
                }
                else
                {
                    dsToaDo = dsToaDoTruoc;//----Tọa độ của danh sách xe nhận đã sắp xếp
                    g_Return = dsXeNhanTruoc;//----Danh sách xe nhận đã sắp xếp
                }
                if (dsToaDo.LastIndexOf(',') > 0)
                    dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
                if (g_Return.LastIndexOf('.') > 0)
                    g_Return = g_Return.Substring(0, g_Return.Length - 1);

                g_Return_TD = dsToaDo;// chuoi toa do cua xe nhan da sap xep

                return CuocGoi.TONGDAI_UPDATE_XENHAN_TOADO(g_cuocGoi.IDCuocGoi, dsToaDo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string getToaDoXeNhanMoi(string dsXeNhan, double KD, double VD)
        {
            string dsToaDo = "";
            string[] arrDSXeNhan = dsXeNhan.Split('.');
            for (int i = 0; i < arrDSXeNhan.Length; i++)
            {
                //gọi service trả về tọa độ của 1 xe đang có tín hiệu
                dsToaDo = "";// string.Format("{0}{1},", dsToaDo, Taxi.Services.Service_Common.ServiceSoapClient.LayToaDoXeNhan(KD, VD, ThongTinCauHinh.GPS_MaCungXN, arrDSXeNhan[i]));
            }
            if (dsToaDo.Length > 1)
                dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
            return dsToaDo;
        }
        #endregion

        private void btnBanDo_Click(object sender, EventArgs e)
        {

        }

        private void chkTaxiGroupDon_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkTaxiGroupDon.Checked)
            //{
            //    maskXeDon.Text = "000";
            //    if (maskXeNhan.Text.Length <= 0)
            //        maskXeNhan.Text = "000";
            //    else
            //        maskXeNhan.Text =XuLyChuoi(maskXeNhan.Text)+"000";
            //}
            //else
            //{
            //    maskXeDon.Text = maskXeDon.Text.Replace("000","");
            //    maskXeNhan.Text = maskXeNhan.Text.Replace("000", "");
            //}
        }

        string XuLyChuoi(string str)
        {
            while (str.IndexOf("..") > 0)
            {

                str = str.Replace("..", ".");
            }
            return str;
        }

        private void chkTruot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTruot.Checked == false)
            {
                maskXeNhan.TextBox.Enabled = true;
            }
            else
            {
                maskXeNhan.TextBox.Enabled = false;
            }
        }

        private void chkHoan_CheckedChanged(object sender, EventArgs e)
        {

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
            var enable = false;
            if (chkDieuLai.Checked || ((cuocGoi.DaGuiDSXeNhan == null || cuocGoi.DaGuiDSXeNhan == 0) && (cuocGoi.CenterConfirm == null || cuocGoi.CenterConfirm == 0))) enable = true;

            maskXeNhan.TextBox.Enabled = enable;
            txtDiaChiDon.Enabled = enable;
            txtDiaChiTra.Enabled = enable;
            chkTaxiGroupDon.Enabled = cuocGoi.MH_LenhLaiXe == "Đã đón" || cuocGoi.MH_LenhLaiXe == "Đã kết thúc";
            if(!CanSendMobile(cuocGoi.KhongDungMobileService))
            {
                maskXeDon.TextBox.Enabled = true;
            }
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
            lblLenhLX.Text = cuocGoi.MH_LenhLaiXe;

            if (!chkTaxiGroupDon.Checked) chkTaxiGroupDon.Checked = cuocGoi.MH_LenhLaiXe == "Đã đón" || cuocGoi.MH_LenhLaiXe == "Đã kết thúc";

            if (cuocGoi.MH_LenhLaiXe == EnVangManagement.LENH_TRUOTKHACH)
            {
                chkTruot.Checked = true;
                chkTaxiGroupDon.Enabled = false;
            }
            else
            {
                chkTaxiGroupDon.Enabled = true;
            }
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
            maskXeDon.TextBox.Text = cuocGoi.XeDon;
        }

        private void chkMobileService_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobileService.Checked && !isLoadForm)
            {
                new MessageBox.MessageBoxBA().Show("Cuộc gọi sẽ không được chuyển xuống cho Smartphone của lái xe");
            }
        }

        /// <summary>
        /// Quyết định xem cuộc gọi có thể send mobile hay không
        /// </summary>
        /// <param name="KhongDungMobileService">The khong dung mobile service.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/3/2015   created
        /// </Modified>
        private bool CanSendMobile(bool? KhongDungMobileService)
        {
            return Global.HasInternet == 1 && ThongTinCauHinh.GPS_TrangThai && (KhongDungMobileService == null || !KhongDungMobileService.Value);
        }

        private void chkDieuLai_CheckedChanged(object sender, EventArgs e)
        {
            maskXeNhan.TextBox.Enabled = true;
            chkTruot.Checked = false;
        }
    }
}