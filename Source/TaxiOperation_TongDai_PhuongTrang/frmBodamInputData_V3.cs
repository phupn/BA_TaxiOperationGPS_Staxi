using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Services.WCFServices;
using Taxi.Utils.Enums;
using Taxi.Data.FastTaxi;

namespace Taxi.GUI
{
    public partial class frmBodamInputData_V3: Form
    {
        #region ==========================Init=================================

        public string XeDaDon = "000";
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
        private const string MSG_3_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định.";
        private const string MSG_4_NHAPHOAN = "Bạn không thể nhập hoãn, khi điện thoại chưa báo hoãn.";
        private const string MSG_5_NHAPTRUOT = "Bạn không thể nhập trượt nếu chưa có xe nhận.";
        private const string MSG_6_NHAPXINLOI = "Bạn không thể chọn không xe xin lỗi khi đã có xe nhận.";
        //-- Message cho  lenh man hinh
        private const string MSG_7_MANHINHKONGCOXEDECU = "Không tồn tại xe đề cử. Bạn phải chọn ra xe đề cử.";
        private string MSG_8_XENHANDANHANDIEMKHAC = "Xe nhận này đã nhận đón ở địa chỉ khác.";
        private const string MSG_9_MoiKhachKhongXeDon = "[Lệnh mời khách] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận.";

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
            if (cuocGoi.DanhSachXeDeCu != null && cuocGoi.DanhSachXeDeCu.Length > 0)
            {
                lblDSXeDeCu.Text = cuocGoi.DanhSachXeDeCu;
                lblTimeCapNhatXeDeCu.Visible = true;
                TimeSpan timeSpan = g_TimeServer - cuocGoi.ThoiDiemCapNhatXeDeCu;
                lblTimeCapNhatXeDeCu.Text = string.Format("(cập nhật : {0:0} phút trước)", timeSpan.TotalMinutes);
            }
            if (cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length > 0)
            {
                maskXeNhan.TextBox.Text = cuocGoi.XeNhan + ".";
                maskXeNhan.TextBox.SelectionStart = maskXeNhan.TextBox.Text.Length;
            }
            else maskXeNhan.TextBox.Text = "";

           //maskXeNhan.Text = cuocGoi.XeNhan;
            maskXeDon.Text = cuocGoi.XeDon;
            editLenhTongDai.TextBox.Text = cuocGoi.LenhTongDai;
            editGhiChu.TextBox.Text = cuocGoi.GhiChuTongDai;
            txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach;
            if (g_cuocGoi.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || g_cuocGoi.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
            {
                chkKhongXe.Text = "Không x(&e)"; 
            }
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
            
            // không xe
            if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiTaxi && cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length <= 0){

                chkKhongXe.Enabled = true;
                if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    chkKhongXe.Checked = true;
                }
              
            }
            else
                chkKhongXe.Enabled = false;
            // gọi lại
            if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiLai)
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
            if (cuocGoi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiHoiDam)
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
        /// <param name="cuocGoi"></param>
        private void GetDuLieuTuForm(ref CuocGoi cuocGoi, string xeNhan, string xeDon)
        {
            //--update xe nhận và tọa độ
            //updateDSXeNhan_ToaDo();

            cuocGoi.XeNhan = xeNhan;
            cuocGoi.XeDon = xeDon;
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
            if (chkKhongXe.Checked)
            {
                if (chkKhongXe.Text.Contains("1"))
                    cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1;
                else
                    cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.BoDam;
            }
            else
            {
                cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
            }
            if (chkDaNhanGoiLai.Checked)
            {
                cuocGoi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiLai;
                cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc; 
            }
            if (chkKetThucHoiDam.Checked)
            {
                cuocGoi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiHoiDam;
                cuocGoi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac;
                cuocGoi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
            }
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
        private BangMaValidate ValidateFormNhap(CuocGoi cuocGoi)
        {
            // Check xe nhận
            string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text);
            if (xeNhan != null && xeNhan.Length > 0)
            {
                if (!KiemTraXeNhan(xeNhan))
                {
                    return BangMaValidate.NhapChinhXacXe;
                }
                else if (StringTools.KiemTraTrungLapXeChay(xeNhan))
                {
                    return BangMaValidate.NhapXeDonThuocXeNhan;
                }
                else if (Config_Common.TongDai_HienThiCanhBao_NhapTrungXeNhan > 0 && KiemTraXeCoTrongCuocKhachHienTai(xeNhan))
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
            if (xeDon != null && xeDon.Length > 0)
            {
                if (StringTools.KiemTraTrungLapXeChay(xeDon))
                {
                    return BangMaValidate.NhapXeDonThuocXeNhan;
                }
            }
            // Kiểm tra nhập kênh khi không xe chuyển vùng
            if (editLenhTongDai.Text == LENH_1_MOIKHACH && (xeNhan == null || xeNhan.Trim() == ""))
            {
                return BangMaValidate.MoiKhachChuaCoXeDon;
            }


            return BangMaValidate.ValidateSuccess;
        }
        /// <summary>
        /// hien thi thong bao 
        /// </summary>
        /// <param name="maValidate"></param>
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
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeNhan(string xeNhan)
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
                    if (xe == arrXeNhan[i] || arrXeNhan[i] == this.XeDaDon)
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

        /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        /// <param name="lstDienThoai"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        private bool KiemTraXeCoTrongCuocKhachHienTai(string SoHieuXe)
        {
            string[] arrTaxi = SoHieuXe.Split('.');
            foreach (CuocGoi objDH in G_ListCuocGoi)
            {
                if (objDH.IDCuocGoi == g_cuocGoi.IDCuocGoi) continue;
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
            BangMaValidate maValidate = ValidateFormNhap(g_cuocGoi);

            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                string xeDon = StringTools.ConvertToChuoiXeNhanChuan(maskXeDon.Text);
                string xeNhan = StringTools.ConvertToChuoiXeNhanChuan(maskXeNhan.Text);
                string xeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(g_cuocGoi.XeDenDiem);

                #region  Xe vi phạm
                if (Config_Common.TongDai_CheckXeViPham)
                {
                    string xeViPham = LoiViPham.Inst.GetXeViPham(xeNhan + "." + xeDon + "." + xeDenDiem, DateTime.Now);
                    if (!string.IsNullOrEmpty(xeViPham))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, string.Format("Xe {0} đang vi phạm lỗi", xeViPham), "Thông báo");
                        g_CloseForm = false; // chưa đóng form
                        return;
                    }
                }

                #endregion

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
                    if (xeDon ==this.XeDaDon)
                    {
                        if (xeNhan.Length <= 0)
                            xeNhan = this.XeDaDon;
                        //else
                        //    xeNhan += "." + this.XeDaDon;
                        g_IsKetThuc = true;
                    }
                    else
                    {
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
                }
                #endregion

                #region XeNhan

                string xeNhanCu = g_cuocGoi.XeNhan;

                if (xeNhan != "" && xeNhan != xeNhanCu)
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();                    
                    
                    string xeNhan_Filter = string.Empty;
                    if (!string.IsNullOrEmpty(xeNhanCu))
                    {
                        xeNhan_Filter = StringTools.GetXeNhanMoi(xeNhanCu, xeNhan);
                    }
                    else                 
                    {
                        xeNhan_Filter = xeNhan;
                    }

                    //if (g_cuocGoi.XeDon != null && g_cuocGoi.XeDon.Length > 0)
                    //{                        
                    //    if (KiemTraXeDonThuocXeNhan(xeNhan_Filter, g_cuocGoi.XeDon))
                    //    {
                    //        msgDialog.Show(this, string.Format("Xe [{0}] đã báo đón khách !", xeNhan_Filter), "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //        g_CloseForm = false;
                    //        DialogResult = DialogResult.Cancel;
                    //        return;
                    //    }
                    //}
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
            if (chkKhongXe.Checked)
            {
                if (g_cuocGoi.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1 || g_cuocGoi.TrangThaiCuocGoi == Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    editLenhTongDai.TextBox.Text = LENH_5_2_KHONGXE_XINLOI;
                }
                else
                    editLenhTongDai.TextBox.Text = LENH_5_KHONGXE_XINLOI;
            }
            else
            {
                editLenhTongDai.TextBox.Text = ""; 
            }
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
            if (editLenhTongDai.TextBox.Text.StartsWith("1"))
            {
                editLenhTongDai.TextBox.Text = LENH_1_MOIKHACH;
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("2"))
            {
                if (StringTools.TrimSpace(maskXeNhan.Text).Length <= 0 && StringTools.TrimSpace(maskXeDon.Text).Length <= 0)
                {
                    if (chkKhongXe.Text.Contains("1"))
                        editLenhTongDai.TextBox.Text = LENH_5_2_KHONGXE_XINLOI;
                    else
                        editLenhTongDai.TextBox.Text = LENH_5_KHONGXE_XINLOI;
                    chkKhongXe.Checked = true;
                }
                else
                {
                    chkKhongXe.Checked = false;
                }
            }
            else if (editLenhTongDai.TextBox.Text.StartsWith("3"))
            {
                if (StringTools.TrimSpace(maskXeNhan.Text).Length <= 0 && StringTools.TrimSpace(maskXeDon.Text).Length <= 0)
                {
                    // if (chkKhongXe.Text.Contains("1"))
                        editLenhTongDai.TextBox.Text = LENH_5_2_KHONGXE_XINLOI;
                    // else
                   // editLenhTongDai.TextBox.Text = LENH_5_KHONGXE_XINLOI;
                    chkKhongXe.Checked = true;
                }
                else
                {
                    chkKhongXe.Checked = false;
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
                //chkTaxiGroupDon.Checked = !chkTaxiGroupDon.Checked;
                chkTaxiGroupDon.Focus();
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
                //dsToaDo = string.Format("{0}{1},", dsToaDo, Taxi.Services.Service_Common.ServiceSoapClient.LayToaDoXeNhan(KD, VD, ThongTinCauHinh.GPS_MaCungXN, arrDSXeNhan[i]));
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
            if (chkTaxiGroupDon.Checked)
            {
                maskXeDon.Text = this.XeDaDon;
                if (maskXeNhan.Text.Length <= 0)
                    maskXeNhan.Text = this.XeDaDon;
                else
                    maskXeNhan.Text =XuLyChuoi(maskXeNhan.Text)+this.XeDaDon;
            }
            else
            {
                maskXeDon.Text = XuLyChuoi(maskXeDon.Text.Replace(this.XeDaDon, ""));
                maskXeNhan.Text = XuLyChuoi(maskXeNhan.Text.Replace(this.XeDaDon, ""));
            }
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

        }

        private void chkHoan_CheckedChanged(object sender, EventArgs e)
        {

        }        
    }
}