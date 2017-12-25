using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Fields;
using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Utils;
using Femiani.Forms.UI.Input;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using System.Drawing.Drawing2D;
using Taxi.Entity;
using Taxi.Business.KhachDat;
using System.Globalization;
using Taxi.Services;
using Taxi.Utils.Enums;
using Taxi.Common.Extender;
using Taxi.Data.DM;
using DevExpress.Utils;
using TaxiApplication.Base;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtons;
using MessageBoxIcon = Taxi.MessageBox.MessageBoxIcon;
using System.Linq;
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
    public partial class frmDienThoaiInputDataNew_V4_Lab : Form
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
        public enum BangMaValidate
        {
            ValidateSuccess = 0,
            NhapThongTinDiaChi = 1,    // Bạn phải nhập thông tin vào trường địa chỉ.
            NhapMotLoaiCuocGoi = 2,    // Bạn phải chọn một loại cuộc gọi.
            NhapSoLuongXe = 3,    // Bạn phải nhập số lượng xe.
            NhapKenh = 4,    // Bạn phải nhập kênh (vùng) theo quy định.
            ChonKhongXeXinLoiKhach = 5, // Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.
            Msg6_KhongTimThayDCBanDo = 6,
            Msg7_ChuaNhapKenh = 7,
            Msg8_TaiBanDo = 8,
            Msg9_ChonKenhTK = 9,
            Msg10_ChonLoaiXe = 10,
            NhapChinhXacXe = 13,
            NhapXeDonThuocXeNhan = 14,
            DienThoaiDaHuy=15,
            /// <summary>
            /// Đã giải quyết là cuốc không có xe nhận.
            /// </summary>
            DaGiaiQuyet=16
        }

        private const string MSG_VALIDATESUCCESS = "";
        private const string MSG_1_NHAPTHONGTINDIACHI = "Bạn phải nhập thông tin vào trường địa chỉ.";
        private const string MSG_2_NHAPTHONGTINLOAICUOCGOI = "Bạn phải chọn một loại cuộc gọi.";
        private const string MSG_3_NHAPSOLUONGXE = "Bạn phải nhập số lượng xe.";
        private const string MSG_4_NHAPKENH = "Bạn phải nhập kênh (vùng) theo quy định. Kiểm tra lại kênh (vùng) cấu hình.";
        private const string MSG_5_CHONKHONGXE = "Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.";
        private const string MSG_6_BANDO = "Không tìm thấy địa chỉ này trên bản đồ";
        private const string MSG_7_CHUANHAPKENH = "Hãy nhập số kênh";
        private const string MSG_8_TAIBANDO = "Lỗi tải bản đồ";
        private const string MSG_9_CHONKENHTK = "Bạn hãy chọn kênh cần tìm kiếm";
        private const string MSG_10_BANDO = "Lỗi trong quá trình xử lý lấy tọa độ trên bản đồ";
        private const string MSG_11_BANDO = "Lỗi vẽ xe đề cử lên bản đồ";
        private const string MSG_12_BANDO = "Lỗi vẽ xe nhận lên bản đồ";
        private const string MSG_12_CHONLOAIXE = "Chưa chọn loại xe";
        private const string MSG_13_NHAPCHINHXACXE = "Bạn phải nhập chính xác số hiệu xe.Bạn báo quản trị bổ sung xe nếu thiếu.";
        private const string MSG_14_NHAPXEDONTHUOCXENHAN = "Trùng lặp xe Nhận/đến điểm/đón.";
        private const string MSG_15_DienThoaiDaHuy = "Khách hàng đã hủy cuốc.";
        private const string MSG_16_DaGiaiQuyet = "Đã giải quyết là cuốc không có xe nhận.";
    
        public enum LenhDienThoaiKieu
        {
            DaMoi = 1,  // đã mời
            GapXe = 2,  // gặp xe
            MayBan = 3,  // máy bận
            KhongLienLacDuoc = 4, // Không LL được
            HuyXe = 5,    // Hủy xe
        }

        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        private const string LENH_KHONGLIENLACDUOC = "Từ chối";
        private const string LENH_HUYXE = "Hủy xe/Hoãn";
        private const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        private const string LENH_GIUROI = "Giữ rồi";
        private const string LENH_KOTHAYXE = "Ko thấy xe";
        private const string LENH_TRUOTCHUA = "Trượt/Chùa";
        private const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        private const string LENH_KHONGNOIGI = "Ko nói gì";
        private const string LENH_KHONGXE = "Ko xe xin lỗi khách";
        private const string LENH_MOIKHACH = "Mời khách";
        private const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_DAXINLOI = "Đã xin lỗi khách";
        private string g_LoaiXeMacDinh = "KIA";
        private const string LENH_G_GIUCXE = "Giục xe";
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
        private string G_DiaChi = "";
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
        private string g_XeDenDiem = "";
        private int g_XeDonLength = 0;

        private const string CuocThuKhongDon = "";
        /// <summary>
        /// Trạng thái có cuốc mới.
        /// </summary>
        private bool IsNew { get; set; }
        /// <summary>
        /// Cảnh báo cuốc điều app chưa có lấy GPS
        /// </summary>
        private bool CanhBaoGPS = false;
        /// <summary>
        /// Trạng thái cuốc gọi lại điều app
        /// </summary>
        private bool CuocGoiLaiAppLaiXe = false;
        /// <summary>
        /// Trạng thái cuốc hiện tại là cuộc gọi lại.
        /// </summary>
        private bool CuocGoiLai = false;
        /// <summary>
        /// Trạng thái cuốc hiện tại là cuốc điều app
        /// </summary>
        private bool CuocDieuApp = false;
        ///// <summary>
        ///// Trạng thái cuốc hiện tại là có xe nhận
        ///// </summary>
        private bool CuocCoXeNhan = false;
        //private List<string> DanhSachXeNhanDieuApp;
        private int CheckTextChangeDiaChi = 0;
        #endregion

        #region =======================Constructor=============================
        /// <summary>
        /// hàm khởi tạo truyển dữ liệu lên
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        public frmDienThoaiInputDataNew_V4_Lab(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete)
        {
            InitializeComponent();
            editSoLuongXe.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            ConfigMap();
            shGridControl1.UseEmbeddedNavigator = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmDienThoaiInputDataNew_V4_Lab(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, string IDLoaiXeMacDinh)
        {
            InitializeComponent();
            editSoLuongXe.TextBox.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            ConfigMap();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmDienThoaiInputDataNew_V4_Lab(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit)
        {
            InitializeComponent();
            //this.SetDisplayRectLocation(550,550);
            this.SetDesktopLocation(440, 100);
            editSoLuongXe.TextBox.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            g_CGLimit = CGLimit;

            //---------------------Initial Map----------------------------
            ConfigMap();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="listDataAutoComplete"></param>
        /// <param name="IDLoaiXeMacDinh">Loại xe mặc định config trên PC</param>
        public frmDienThoaiInputDataNew_V4_Lab(CuocGoi cuocGoi, AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            //this.SetDisplayRectLocation(550,550);
            this.SetDesktopLocation(440, 100);
            editSoLuongXe.TextBox.Text = "1";
            chkGoiTaxi.Checked = true;

            g_CuocGoi = cuocGoi;
            g_ListDataAutoComplete = listDataAutoComplete;
            g_CGLimit = CGLimit;

            G_DMVung_GPS = DMVung_GPS;
            //---------------------Initial Map----------------------------
            ConfigMap();
        }

        #endregion

        #region ===================Load Form-Set Data==========================

        private void frmDienThoaiInputDataMaiLinh_Load(object sender, EventArgs e)
        {
            txtDiaChi_GPS.TextChanged += txtDiaChi_GPS_TextChanged;
            EnableControl();
            CanhBaoGPS = (Config_Common.DienThoai_DieuApp_CanhBaoGPS && (g_CuocGoi.Vung == 0 || g_CuocGoi.Vung == null));
           
            //Cuốc gọi lại
            CuocGoiLai = g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai;
            //Cuốc điều app
            CuocDieuApp = (g_CuocGoi.BookId != Guid.Empty || g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp);
            //Cuốc gọi có xe nhận
            CuocCoXeNhan = !string.IsNullOrEmpty(g_CuocGoi.XeNhan);
            //Cuộc gọi lại cuốc mà cuốc trước là cuốc gọi đã điều app
            CuocGoiLaiAppLaiXe = CuocGoiLai && CuocDieuApp;

            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
            txtDiaChi_GPS.Items = g_ListDataAutoComplete;
            txtDiaChi_GPS.Text = "";
            g_CloseForm = false;
            lblCoCuocGoiMoi.Visible = false;
          //  lblTenKhachHang.Text = DanhBaCongTy.GetName(g_CuocGoi.PhoneNumber).ToUpperInvariant();
            //txtDiaChiDonKhach.A();
            txtDiaChiDonKhach.Select();
            txtDiaChiDonKhach.Focus();
            SetDuLieuLenForm(g_CuocGoi);
            if (g_CuocGoi.FT_IsFT)
            {
                chkGoiKhieuNai.Visible = false;
                chkGoiLai.Visible = false;
                chkGoiDichVu.Visible = false;
                chkGoiHoiDam.Visible = false;

                cbkCuocDieuApp.Enabled = false;
                chkDaGiaiQuyet.Visible = false;
            }
           // if (!g_CuocGoi.FT_IsFT)
            {
                var height_TieuDe = panel_TieuDe.Height;
                panel_TieuDe.Visible = false;
                this.Height = this.Height - height_TieuDe;
            }
            if (Config_Common.DienThoai_LayLichSuCuoc > 0)
            {
                try
                {
                    shGridControl1.DataSource = CuocGoi.DienThoai_LayLichSuTheoSoDienThoai(g_CuocGoi.PhoneNumber, g_CuocGoi.ThoiDiemGoi_FT, Config_Common.DienThoai_LayLichSuCuoc > 4 ? Config_Common.DienThoai_LayLichSuCuoc : 4);
                    shGridControl1.Refresh();
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBox().Show(ex.Message);
                }
                shGridControl1.UseEmbeddedNavigator = false;
            }
            else
            {
                panel_LichSuCuocGoi.Visible = false;
            }
            if (Config_Common.DienThoai_InfoKH)
            {
                picInfo.Visible = false;
               var KHInfo = KhachHangDungThe.Inst.GetKH(g_CuocGoi.PhoneNumber, DateTime.Now.Date);
                if (KHInfo != null)
                {
                    picInfo.Visible = true;

                    var toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
                    var toolTipItem1 = new DevExpress.Utils.ToolTipItem();

                    toolTipTitleItem1.Text = "Thông tin khách hàng";
                    toolTipItem1.Text = string.Format("Họ tên:{0}\nSDT:{1}\nMã KH:{2}\nĐịa chỉ:{3}", KHInfo.TenKhachHang, KHInfo.SoDienThoai, KHInfo.MaKhachHang, KHInfo.DiaChi);
                    var super = new SuperToolTip();
                    super.Items.Add(toolTipTitleItem1);
                    super.Items.Add(toolTipItem1);
                    picInfo.SuperTip = super;
                }
            }
           
            if (Config_Common.GetThongTinGhiChuKH)
            {
                if (g_CuocGoi.Vung == 0)
                {
                    if (editGhiChu.Text == string.Empty)
                        editGhiChu.Text = KhachHangDungThe.Inst.GetGhiChuByPhoneOfKhachHang(g_CuocGoi.PhoneNumber);
                    else
                    {
                        editGhiChu.Text =(editGhiChu.Text +';'+ KhachHangDungThe.Inst.GetGhiChuByPhoneOfKhachHang(g_CuocGoi.PhoneNumber)).Trim(';');
                    }
                }
            }
            pG5KetThuc.Visible = false;
            picG5.Visible = false;
            if (Config_Common.DienThoai_DieuTuDong)
            {
                cbkCuocDieuApp.Visible = true;
            }
            else
            {
                cbkCuocDieuApp.Visible = false;
            }
            if (g_CuocGoi.KieuCuocGoi== KieuCuocGoi.GoiTaxi && g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp && !g_CuocGoi.FT_IsFT)
            {
                ShowDieuApp(true,false);
                if (!string.IsNullOrEmpty(g_CuocGoi.XeDungDiem))
                {
                    chkTruotG5.Visible = true;
                }
                else
                {
                    chkTruotG5.Visible = false;
                }
            }
            else
            {
                ShowDieuApp(false);
                if (CuocGoiLaiAppLaiXe)
                {
                    pG5KetThuc.Visible = true;
                    chkTruotG5.Visible = false;
                }
            }
            
            lblThongBao.Text = string.Empty;
            
            if (Config_Common.G5_PinMap)
            {
                picLen_Click(null, null);
            }
            else
            {
                picXuong_Click(null, null);
            }
            if (!CheckPhoneNumber(g_CuocGoi.PhoneNumber) || (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam) || (g_CuocGoi.Vung > 0 && g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && (g_CuocGoi.BookId != Guid.Empty || g_CuocGoi.FT_IsFT || !string.IsNullOrEmpty(g_CuocGoi.LenhLaiXe) || !string.IsNullOrEmpty(g_CuocGoi.XeNhan))))
            {
                cbkCuocDieuApp.Enabled = false;
            }
           
        }

        void txtDiaChi_GPS_TextChanged(object sender, EventArgs e)
        {
            CheckTextChangeDiaChi = 1;
        }

        /// <summary>
        /// Set ẩn hiện control
        /// </summary>
        private void EnableControl()
        {
            if (Global.MoHinh == MoHinh.TongDaiMini)
            {
                pnlTongDai.Visible = true;
                editGhiChu.Visible = false;
            }
            else
            {
                pnlTongDai.Visible = false;
                editGhiChu.Visible = true;
            }
            if (chkGoiTaxi.Checked && cbkCuocDieuApp.Checked)
            {
                CanhBaoGPS = true;
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
                if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp && !cuocGoi.FT_IsFT && cuocGoi.Vung>0)//.DiaChiDonKhach.ToLower().Contains(CuocThuKhongDon.ToLower()))
                {
                    cbkCuocDieuApp.Checked = true;
                }
                if (cuocGoi.SanBay_DuongDai == "1")
                {
                    cbkSanBay.Checked = true;
                }
                else
                {
                    cbkSanBay.Checked = false;
                }
                /*
                 * Lệnh lái xe khi điều app thì luôn khác rỗng. cuốc điều đàm và ko điều app thì LenhLaiXe==null
                 * FT_IsFT=true là cuốc đặt app không xe nhận chuyển sang điểm đàm.
                 * 
                 * */
                
                txtDiaChiDonKhach.Text = diaChi.ToUpper();
                txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach.ToUpper();
                lblInfo.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber, cuocGoi.ThoiDiemGoi);
                SetThongTinLoaiCuocGoi(cuocGoi.KieuCuocGoi);
                if (cuocGoi.FT_IsFT)
                    SetThongTinLoaiXe_G5(cuocGoi.LoaiXe);
                else
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


                if (!CuocGoiLaiAppLaiXe)
                {
                    editLenhDienThoai.Text = cuocGoi.LenhDienThoai;
                    editGhiChu.Text = cuocGoi.GhiChuDienThoai;
                }
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
               
                // hiển thị lựa chọn không xe
                //if (cuocGoi.XeNhan.Length <= 0 && cuocGoi.LenhTongDai.Contains("không xe"))
                //{
                //    chkKhongXeXinLoi.Enabled = true;
                //    SetControlForKhongXe();
                //}
                //else
                //{
                //    chkKhongXeXinLoi.Enabled = false;
                //}
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
                    lbl_FTAllowCall.Text = string.Empty;
                    lbl_FTAllowCall.Visible = false;
                    // là cuốc FastTaxi
                    if (cuocGoi.FT_IsFT)
                    {
                        pG5KetThuc.Visible = false;
                        chkDaGiaiQuyet.Visible = true;
                        IsFastTaxi.Visible = true;
                        //lblInfo.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber,
                        //    cuocGoi.FT_SendDate);
                        //lblInfo.Text = string.Format("{0} {1:HH:mm dd/MM}",cuocGoi.PhoneNumber,cuocGoi.FT_SendDate);
                        label7.Text = string.Format("{0:HH:mm}", cuocGoi.FT_Date);
                        btnGPS.Visible = true;
                        btnRemoveGPS.Visible = false;
                        btnDatHen.Visible = false;
                        label7.Visible = true;
                        if (cuocGoi.FT_KM > ThongTinCauHinh.FT_SoKM)
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
                    if (Global.MoHinh == MoHinh.TongDaiMini)
                    {
                        if (cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length > 0)
                        {
                            txtXeNhan.Text = cuocGoi.XeNhan + ".";
                            txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                        }
                        if (cuocGoi.XeDenDiem != null && cuocGoi.XeDenDiem.Length > 0)
                        {
                            txtXeDenDiem.Text = cuocGoi.XeDenDiem + ".";
                            txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
                        }if (cuocGoi.XeDon != null && cuocGoi.XeDon.Length > 0)
                        {
                            txtXeDon.Text = cuocGoi.XeDon + ".";
                            txtXeDon.SelectionStart = txtXeDon.Text.Length;
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
                        if (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam) // Nếu là cuốc điều đàm thì sẽ thực hiện xem xe đề cử
                        {
                            //set marker xe de cu
                            if (!string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu) &&
                                !string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu_TD))
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
                if ((cuocGoi.Vung == 0 || cuocGoi.Vung == null) && (cuocGoi.LoaiXe == null || cuocGoi.LoaiXe==""))
                {
                    chk4Cho.Checked = true;
                }
                LenhDienThoai_Current = cuocGoi.LenhDienThoai;
                
            }
        }

        private void SetControlForKhongXe()
        {
            chkGoiTaxi.Enabled = false;
            chkGoiLai.Enabled = false;
            chkGoiKhieuNai.Enabled = false;
            chkGoiDichVu.Enabled = false;
            chkGoiHoiDam.Enabled = false;
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
            else if (kieuCuocGoi == KieuCuocGoi.GoiHoiDam)
            {
                chkGoiHoiDam.Checked = true;
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
            try
            {
                if (loaiXe != null && loaiXe.Length > 0)
                {
                    string strLoaiXe = "";
                    strLoaiXe = loaiXe;

                    if (loaiXe.Contains("4") && loaiXe.Length>=2)
                    {
                        chk4Cho.Checked = true;
                        strLoaiXe = strLoaiXe.Remove(0, 2);
                    }
                    if (loaiXe.Contains("7") && loaiXe.Length >=2)
                    {
                        chk7Cho.Checked = true;
                        strLoaiXe = strLoaiXe.Remove(0, 2);
                    }
                    txtLoaiXe.Text = strLoaiXe;
                }
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("SetThongTinLoaiXe_FastTaxi", exx);
            }
           
        }
        private void SetThongTinLoaiXe_G5(string loaixe)
        {
            if (loaixe.Contains("4"))
            {
                chk4Cho.Checked = true;
            }
            if (loaixe.Contains("7"))
            {
                chk7Cho.Checked = true;
            }
            txtLoaiXe.Text = loaixe;
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
        
        #endregion        

        #region ======================Validation Form==========================
        /// <summary>
        /// hàm thực hiện validate thông tin form nhập
        /// co cuoc goi truyen vao
        /// </summary>
        /// <returns></returns>
        private BangMaValidate ValidateFormNhap(CuocGoi cuocGoi)
        {
            if (chkGoiTaxi.Checked && Global.MoHinh == MoHinh.TongDaiMini)
            {
                g_XeDon = StringTools.ConvertToChuoiXeNhanChuan(txtXeDon.Text);
                g_XeNhan = StringTools.ConvertToChuoiXeNhanChuan(txtXeNhan.Text);
                g_XeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(txtXeDenDiem.Text);
                if (g_XeNhan != null && g_XeNhan.Length > 0)
                {
                    if (!KiemTraXeNhan(g_XeNhan))
                    {
                        return BangMaValidate.NhapChinhXacXe;
                    }
                    else if (StringTools.KiemTraTrungLapXeChay(g_XeNhan))
                    {
                        return BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                }
                // Kiểm tra xe đó có nằm trong xe đón
                if (g_XeDenDiem != null && g_XeDenDiem.Length > 0)
                {
                    if (StringTools.KiemTraTrungLapXeChay(g_XeDenDiem))
                    {
                        return BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                }
                // Kiểm tra xe đó có nằm trong xe đón
                if (g_XeDon != null && g_XeDon.Length > 0)
                {
                    if (StringTools.KiemTraTrungLapXeChay(g_XeDon))
                    {
                        return BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                }
            }
            // Không nhập địa chỉ
            string diaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
            if (diaChi.Length <= 0 && chkGoiKhac.Checked == false)
            {
                txtDiaChiDonKhach.Focus();
                return BangMaValidate.NhapThongTinDiaChi;
            }
            // Không chọn một loại cuộc gọi nào
            if ((chkGoiTaxi.Checked == false) && (chkGoiLai.Checked == false) && (chkGoiKhieuNai.Checked == false) && (chkGoiDichVu.Checked == false) &&
                (chkGoiHoiDam.Checked == false) && (chkGoiKhac.Checked == false))
            {
                chkGoiTaxi.Focus();
                return BangMaValidate.NhapMotLoaiCuocGoi;
            }

            if (chkGoiTaxi.Checked || chkGoiLai.Checked || chkGoiHoiDam.Checked ||  chkGoiKhieuNai.Checked )
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
                        return BangMaValidate.NhapKenh;
                    }
                }
                catch (Exception ex)
                {
                    editVung.Focus();
                    return BangMaValidate.NhapKenh;
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
                        return BangMaValidate.NhapSoLuongXe;
                    }
                    #endregion So luong xe
                }
            }
            if (!chkGoiKhac.Checked&& cuocGoi.GetLenhDienThoaiCurrent() == LENH_HUYXE)
            {          
                return BangMaValidate.DienThoaiDaHuy;
            }
            if (chkDaGiaiQuyet.Checked && cuocGoi.XeNhan.Trim().Length>0)
            {
                return BangMaValidate.DaGiaiQuyet;
            }
            return BangMaValidate.ValidateSuccess;
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
            string[] arrXeDon = g_XeDon.Split(".".ToCharArray());
            g_XeDonLength = arrXeDon.Length;
            for (int i = 0; i < arrXeNhan.Length; i++)
            {
                bool timThayXe = false;
                foreach (string xe in g_ListSoHieuXe)
                {
                    if (xe == arrXeNhan[i])
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
        private void HienThiThongBao(BangMaValidate maValidate)
        {
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                lblThongBao.Text = MSG_VALIDATESUCCESS;
            }
            else if (maValidate == BangMaValidate.NhapThongTinDiaChi)
            {
                lblThongBao.Text = MSG_1_NHAPTHONGTINDIACHI;
            }
            else if (maValidate == BangMaValidate.NhapMotLoaiCuocGoi)
            {
                lblThongBao.Text = MSG_2_NHAPTHONGTINLOAICUOCGOI;
            }
            else if (maValidate == BangMaValidate.NhapSoLuongXe)
            {
                lblThongBao.Text = MSG_3_NHAPSOLUONGXE;
            }
            else if (maValidate == BangMaValidate.NhapKenh)
            {
                lblThongBao.Text = MSG_4_NHAPKENH;
            }
            else if (maValidate == BangMaValidate.ChonKhongXeXinLoiKhach)
            {
                lblThongBao.Text = MSG_5_CHONKHONGXE;
            }
            else if (maValidate == BangMaValidate.Msg6_KhongTimThayDCBanDo)
            {
                lblThongBao.Text = MSG_6_BANDO;
            }
            else if (maValidate == BangMaValidate.Msg7_ChuaNhapKenh)
            {
                lblThongBao.Text = MSG_7_CHUANHAPKENH;
            }
            else if (maValidate == BangMaValidate.Msg8_TaiBanDo)
            {
                lblThongBao.Text = MSG_8_TAIBANDO;
            }
            else if (maValidate == BangMaValidate.Msg9_ChonKenhTK)
            {
                lblThongBao.Text = MSG_9_CHONKENHTK;
            }
            else if (maValidate == BangMaValidate.Msg10_ChonLoaiXe)
            {
                lblThongBao.Text = MSG_12_CHONLOAIXE;
            }
            else if (maValidate == BangMaValidate.NhapChinhXacXe)
            {
                lblThongBao.Text = MSG_13_NHAPCHINHXACXE;
            }
            else if (maValidate == BangMaValidate.NhapXeDonThuocXeNhan)
            {
                lblThongBao.Text = MSG_14_NHAPXEDONTHUOCXENHAN;
            }
            else if (maValidate == BangMaValidate.DienThoaiDaHuy)
            {
                lblThongBao.Text = MSG_15_DienThoaiDaHuy;
            }
            else if (maValidate == BangMaValidate.DaGiaiQuyet)
            {
                lblThongBao.Text = MSG_16_DaGiaiQuyet;
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
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = true;
                EnableControl();}   
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
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
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
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
                cbkCuocDieuApp.Enabled = false;
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
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
                cbkCuocDieuApp.Enabled = false;
            }
            //chkXeKia.Enabled = !chkGoiDichVu.Checked;
            //chkXeVios.Enabled = !chkGoiDichVu.Checked;
            //chkCAR.Enabled = !chkGoiDichVu.Checked;
            chk4Cho.Enabled = !chkGoiDichVu.Checked;
            chk7Cho.Enabled = !chkGoiDichVu.Checked;
            txtLoaiXe.Enabled = !chkGoiDichVu.Checked;
            editSoLuongXe.Enabled = !chkGoiDichVu.Checked;
            editVung.Enabled = !chkGoiDichVu.Checked;
        }

        private void HienThiControl_GoiHoiDam()
        {
            if (chkGoiHoiDam.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
                cbkCuocDieuApp.Enabled = false;
            }

            //chkXeKia.Enabled = !chkGoiHoiDam.Checked;
            //chkXeVios.Enabled = !chkGoiHoiDam.Checked;
            //chkCAR.Enabled = !chkGoiHoiDam.Checked;
            chk4Cho.Enabled = !chkGoiKhieuNai.Checked;
            chk7Cho.Enabled = !chkGoiKhieuNai.Checked;
            txtLoaiXe.Enabled = !chkGoiKhieuNai.Checked;
            editSoLuongXe.Enabled = !chkGoiHoiDam.Checked;
            editVung.Enabled = true;
        }

        private void HienThiControl_GoiKhac()
        {
            if (chkGoiKhac.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
                pnlTongDai.Visible = false;
            }
            //chkXeKia.Enabled = !chkGoiKhac.Checked;
            //chkXeVios.Enabled = !chkGoiKhac.Checked;
            //chkCAR.Enabled = !chkGoiKhac.Checked;
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
            IsNew = true;
            lblCoCuocGoiMoi.Visible = true;

        }

        private void setVung(string vung)
        {
            //DateTime gopKenhTuGio = ThongTinCauHinh.GopKenh_TuGio;

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
            // Nếu vùng ==0 || == null || G5_Type=DienThoai tức là cuốc chưa được xử lý
            if (cuocGoi.Vung == 0 || cuocGoi.Vung == null || cuocGoi.G5_Type ==Enum_G5_Type.DienThoai)
            {
                // Xu Ly luong du lieu
                if (cbkCuocDieuApp.Checked && cbkCuocDieuApp.Enabled)
                    cuocGoi.G5_Type = Enum_G5_Type.DieuApp;
                else
                    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
            }
            cuocGoi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text).ToUpper();
            cuocGoi.LenhDienThoai = StringTools.TrimSpace(editLenhDienThoai.Text);
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
                //Nếu là cuốc đặt không xe từ app KH thì sẽ chuyển sang đàm luôn.
                if (cuocGoi.FT_IsFT)
                {
                    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                }
                if (editVung.Text.Trim() != "")
                {
                    cuocGoi.Vung = Convert.ToByte(editVung.Text);
                }
                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;
                //if (chkKhachHoan.Checked)
                //{
                //    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                //}
                //if (chkKhongXeXinLoi.Checked)
                //{
                //    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                //    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                //}
                cuocGoi.SoLanGoi = 0;

                // Kiểm tra nếu có CuocGoiLaiIDs >0 --> thi set lại để không phải là cuộc gọi lại
                //if (cuocGoi.CuocGoiLaiIDs != null && cuocGoi.CuocGoiLaiIDs.Length > 0)
                //{
                //    cuocGoi.CuocGoiLaiIDs = "";
                //}

                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    cuocGoi.XeNhan = g_XeNhan;
                    cuocGoi.XeDon = g_XeDon;
                    cuocGoi.XeDenDiem = g_XeDenDiem;
                    if (cuocGoi.XeDon.Length > 0)
                    {
                        if (g_XeDonLength == cuocGoi.SoLuong)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            cuocGoi.TrangThaiLenh =  TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        }
                    }
                    if (chkHoan.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                    }
                    else if (chkTruot.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                    }
                    else if (chkKhongXe.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeNhan = "";
                        cuocGoi.XeDenDiem = "";
                        cuocGoi.XeDon = "";
                    }
                }
                if (pG5KetThuc.Visible)
                {
                    if (chkHoanG5.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                        G5ServiceSyn.SendOperatorCancel(cuocGoi.BookId);
                    }
                    else if (chkTruotG5.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                        G5ServiceSyn.SendOperatorCancel(cuocGoi.BookId);
                    }
                }
            }
            else if (chkGoiLai.Checked)
            {
                cuocGoi.SoLuong = Convert.ToByte(editSoLuongXe.Text);
                cuocGoi.LoaiXe = GetThongTinLoaiXeChon_FastTaxi();
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiLai;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
                //Nếu là mô hình tổng đài mini hoặc cuốc điều app có xe nhận thì kết thúc
                if (Global.MoHinh == MoHinh.TongDaiMini)//||CuocGoiLaiAppLaiXe)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
                if (pG5KetThuc.Visible)
                {
                    if (chkHoanG5.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                        G5ServiceSyn.SendOperatorCancel(cuocGoi.BookId);
                    }
                    else if (chkTruotG5.Checked)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        cuocGoi.XeDon = "";
                        G5ServiceSyn.SendOperatorCancel(cuocGoi.BookId);
                    }
                }
            }
            else if (chkGoiKhieuNai.Checked)
            {
               // cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhieuNai;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
            }
            else if (chkGoiDichVu.Checked)
            {
               // cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiDichVu;
                //cuocGoi.Vung = Convert.ToByte(editVung.Text);
            }
            else if (chkGoiHoiDam.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiHoiDam;
                cuocGoi.Vung = Convert.ToByte(editVung.Text);
                cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
            }
            else if (chkGoiKhac.Checked)
            {
                cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
            }
            if (chkDaGiaiQuyet.Checked)
            {
                if (cuocGoi.FT_IsFT)
                {
                    cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
                if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai || cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiDichVu)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }
                else
                {
                    if (cuocGoi.XeNhan == "")
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    else
                        lblThongBao.Text = "Chỉ được kết thúc cuộc gọi Khiếu nại/Dịch vụ";
                }
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
            cuocGoi.DiaChiTraKhach=txtDiaChiTra.Text.ToUpper();
            cuocGoi.G5_CarType = string.Empty;
            //Đã xin lỗi khách và kết thúc luôn
            if (cuocGoi.LenhDienThoai == LENH_DAXINLOI)
            {
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            }
            if (cbkSanBay.Checked && cbkSanBay.Visible)
            {
                cuocGoi.SanBay_DuongDai = "1";
                if (chk4Cho.Checked)
                {
                    cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString();
                }
                if (chk7Cho.Checked)
                {
                    if (string.IsNullOrEmpty(cuocGoi.G5_CarType))
                    {
                        cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                    }
                    else
                    {
                        cuocGoi.G5_CarType += "," + ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                    }
                }
            }
            else
            {
                cuocGoi.SanBay_DuongDai = "";
                if (chk4Cho.Checked)
                {
                    cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe4Cho).ToString();
                }
                if (chk7Cho.Checked)
                {
                    if (string.IsNullOrEmpty(cuocGoi.G5_CarType))
                    {
                        cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe7Cho).ToString();
                    }else{
                        cuocGoi.G5_CarType +=","+ ((int)Enum_G5_CarType.Xe7Cho).ToString();
                    }
                }
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
            loaiXe +=","+ txtLoaiXe.Text.Trim();
            return  string.Join(",",loaiXe.Split(',').Select(pi=>pi.Trim()).Where(p=>!string.IsNullOrEmpty(p)).Distinct());
        }

        /// <summary>
        /// function get kenh vung theo dia chi (toa do)
        /// </summary>
        /// <param name="LatDes"></param>
        /// <param name="LngDes"></param>
        /// <returns></returns>
        private int getKenhByDiaChi(float LatDes, float LngDes)
        {
            if (frmDieuHanhDienThoaiNEWCP_V3.G_VungToaDo != null)
            {
                foreach (var item in frmDieuHanhDienThoaiNEWCP_V3.G_VungToaDo)
                {
                    if (item.Value.Count > 0)
                    {
                        int cn = 0;
                        for (int i = 0; i < item.Value.Count - 1; i++)
                        {
                            float x1 = item.Value[i].Key;
                            float y1 = item.Value[i].Value;
                            float x2 = item.Value[i + 1].Key;
                            float y2 = item.Value[i + 1].Value;
                            if (((x1 <= LngDes) && (x2 > LngDes)) || ((x1 > LngDes) && (x2 <= LngDes)))
                            {
                                double vt = (LngDes - x1) / (x2 - x1);
                                if (LatDes < y1 + vt * (y2 - y1))
                                    ++cn;
                            }
                        }
                        if ((cn & 1) > 0)
                        {
                            return item.Key;
                        }// 0 if even (out), and 1 if odd (in)
                    }
                }
            }
            
            return 0;
        }        

        #endregion        
         
        #region ========================Form Events============================

        private void btnOK_Click(object sender, EventArgs e)
        {            
            BangMaValidate maValidate = ValidateFormNhap(g_CuocGoi);
            HienThiThongBao(maValidate);
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                if (chkTruotG5.Checked)
                {
                    if (g_CuocGoi.G5_Type== Enum_G5_Type.DieuApp&&string.IsNullOrEmpty(g_CuocGoi.XeDungDiem))
                    {
                        g_CloseForm = false;
                        lblThongBao.Text = "[Lệnh Trượt] là cuốc gọi điều App và lái xe báo trượt";
                        return;
                    }
                }
                if (cbkCuocDieuApp.Checked && CanhBaoGPS && chkGoiTaxi.Checked)
                {
                    if (MainMap.MarkerCustomer==null||!MainMap.MarkerCustomer.IsVisible || MainMap.MarkerCustomer.Position.Lat == 0 || MainMap.MarkerCustomer.Position.Lng==0)
                    {
                       string rs= new MessageBox.MessageBox().Show(
                            "Cuốc điều app, bạn phải xác định tọa độ. Bạn có  lấy tọa độ ?", "Thông báo",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                       if (rs == "" || rs.ToLower() == "Cancel".ToLower())
                        {
                            g_CloseForm = false;
                            return;
                        }
                        if (rs.ToLower() == "Yes".ToLower())
                        {
                            btnGPS.PerformClick();
                            g_CloseForm = false;
                            return;
                        }
                        if (!string.IsNullOrEmpty(CuocThuKhongDon))
                        {
                            txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                        }
                       
                        //if (rs.ToLower() == "Cancel".ToLower())
                        //{
                        //    DialogResult = DialogResult.Cancel;
                        //    g_CloseForm = true;
                        //    return;
                        //}
                       
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(CuocThuKhongDon)&&cbkCuocDieuApp.Checked && cbkCuocDieuApp.Enabled)
                    {
                        txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                        txtDiaChiDonKhach.Text = CuocThuKhongDon.ToUpper() + " " + txtDiaChiDonKhach.Text.ToUpper().Trim();
                    }
                }

                if (CuocGoiLaiAppLaiXe)
                {
                    //Nếu cuộc gọi lại và yêu cầu gọi thêm xe==>Thành cuốc gọi mới.
                    if (chkGoiTaxi.Checked && chkGoiTaxi.Visible)
                    {
                        g_CuocGoi.BookId = Guid.Empty;
                        g_CuocGoi.XeNhan = string.Empty;
                    }
                    //Nếu hoãn cuốc cũ và kết thúc cuốc hiện tại.
                    if (((chkHoanG5.Checked && chkHoanG5.Visible) || (chkHoan.Visible && chkHoan.Checked))&&CuocCoXeNhan)
                    {
                        G5ServiceSyn.SendOperatorCancel(g_CuocGoi.BookId);
                    }
                    else  //Nếu cuộc gọi lại và gửi lệnh giục xe lái xe.
                        if (cbkGuiLenhLenLaiXe.Checked && cbkGuiLenhLenLaiXe.Visible && chkGoiLai.Checked && chkGoiLai.Visible)
                        {
                            //Lấy danh sach xe nhận(Biển số xe) điều app từ cuốc trước
                            string TextCommand = "Giục xe";
                            int cmdId = Config_Common.CmdIdGiucXe;
                            if (!string.IsNullOrEmpty(editGhiChu.Text) && editGhiChu.Text.ToUpper()!=TextCommand.ToUpper())
                            {
                                //Nếu khách lệnh giục xe thì chuyển sang gửi text
                                cmdId = Config_Common.CmdIdGhiChu;
                                TextCommand = editGhiChu.Text;
                            }
                            G5ServiceSyn.SendText(G5ServiceSyn.ConvertVehicle(g_CuocGoi.XeNhan), TextCommand, g_CuocGoi.BookId, cmdId);
                        }
                }    
                
               
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
            lblThongBao.Text = string.Empty;
            if (g_CGLimit == false)
            {
               
                g_GPS = false;
                MainMap.ClearAllMarkers();
                MainMap.MarkerCustomer = null;
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
        }

        private void btnGPS_Click(object sender, EventArgs e)
        {
            GetGPS(false);
        }
        private void GetGPS(bool IsCheck)
        {
            try
            {
                lblThongBao.Text = string.Empty;
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
                            string toaDo = Taxi.Services.Service_Common.GetGeobyAddressBA_HN_First(diaChiGPS, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                            //new MessageBox.MessageBox().Show(toaDo);
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo = Double.Parse(arrString[0], CultureInfo.InvariantCulture);
                                G_KinhDo = Double.Parse(arrString[1], CultureInfo.InvariantCulture);
                                //new MessageBox.MessageBox().Show(G_ViDo.ToString() + "-" + Global.CultureSystem.DisplayName);
                                //new MessageBox.MessageBox().Show(Convert.ToDouble(arrString[1], new CultureInfo("vi-VN")).ToString());
                                //new MessageBox.MessageBox().Show(Convert.ToDouble(arrString[1], CultureInfo.InvariantCulture).ToString());
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                        }
                    }
                    txtDiaChiDonKhach.Text = G_DiaChiFull.ToUpper();
                    txtDiaChi_GPS.Text = diaChiGPS;
                    if (G_KinhDo == 0 && G_ViDo == 0)
                    {
                        g_GPS = false;
                        return;
                    }
                    else
                    {
                        g_GPS = true;
                        MainMap.addMarkerCustomer2(G_KinhDo, G_ViDo, diaChiGPS);
                        //Nhập Kênh tự động theo địa chỉ vùng
                        setKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);
                        if (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            getXeByToaDo(G_KinhDo, G_ViDo);
                        }
                    }
                }
                string diaChi = getDiaChiChuan(txtDiaChi_GPS.Text);
                if (!string.IsNullOrEmpty(diaChi))
                {
                    double viDo = 0;
                    double kinhDo = 0;
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddressBA_HN_First(diaChi, ThongTinCauHinh.GPS_TenTinh);
                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                        kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                    }
                    else
                    {
                        lblThongBao.Text = MSG_6_BANDO;
                    }
                    if (kinhDo == 0 && viDo == 0)
                        return;

                    MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi);
                } editVung.Select();
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show(ex.Message);
                lblThongBao.Text = MSG_10_BANDO;
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
                //Nếu là cuốc gọi lại của có xe nhận từ app lái xe thì hiển thị lệnh gửi lên lái xe
                if (CuocGoiLaiAppLaiXe)
                {
                    editGhiChu.Text = LENH_G_GIUCXE;
                    cbkGuiLenhLenLaiXe.Visible = true;
                    cbkGuiLenhLenLaiXe.Checked = true;
                    pG5KetThuc.Visible = true;
                }
                IsTextChangeLenh = true;
                editLenhDienThoai.TextBox.Text = "gọi lại";
                IsTextChangeLenh = false;
            }
            else
            {
                if (CuocGoiLaiAppLaiXe)
                {
                    cbkCuocDieuApp.Enabled = true;
                    editGhiChu.Text = "";
                    pG5KetThuc.Visible = false;
                }
                editLenhDienThoai.TextBox.Text = "";
                cbkGuiLenhLenLaiXe.Visible = false;
                cbkGuiLenhLenLaiXe.Checked = false;
            }
        }

        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhieuNai();
            if (chkGoiKhieuNai.Checked)
            {
                editVung.TextBox.Text = "11";
            }
            else
            {
                editVung.TextBox.Text = "";
            }            
        }

        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiDichVu();
            editVung.TextBox.Text = "";
        }

        private void chkGoiHoiDam_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiHoiDam();
            if (chkGoiHoiDam.Checked)
            {                
                editLenhDienThoai.TextBox.Text = "hỏi đàm";
                editVung.Focus();
            }
            else
            {
                editLenhDienThoai.TextBox.Text = "";
            }
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhac();
            editVung.TextBox.Text = "";
        }

        private bool IsTextChangeLenh = false;
        private void editLenhDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (editLenhDienThoai.TextBox.SelectionStart> 3)
                return;
            if (IsTextChangeLenh) return;
            IsTextChangeLenh = true;
            if (editLenhDienThoai.TextBox.Text.StartsWith("1"))
            {
                editLenhDienThoai.TextBox.Text = LENH_DAMOI;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("2"))
            {              
                editLenhDienThoai.TextBox.Text = LENH_GAPXE;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("3"))
            {
                editLenhDienThoai.TextBox.Text = LENH_DAXINLOI;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("4"))
            {
                editLenhDienThoai.TextBox.Text = LENH_MAYBAN;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("5"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KHONGLIENLACDUOC;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("6"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KHONGNGHEMAY;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("7"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KHONGNOIGI;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("8"))
            {
                editLenhDienThoai.TextBox.Text = LENH_HUYXE;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("9"))
            {
                editLenhDienThoai.TextBox.Text = LENH_GIUROI;
            }
            else
            if (editLenhDienThoai.TextBox.Text.StartsWith("G") || editLenhDienThoai.TextBox.Text.StartsWith("g"))
            {
                editLenhDienThoai.TextBox.Text = LENH_G_GIUCXE;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("KD") || editLenhDienThoai.TextBox.Text.StartsWith("kd"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KHACHDAT;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("TC") || editLenhDienThoai.TextBox.Text.StartsWith("tc"))
            {
                editLenhDienThoai.TextBox.Text = LENH_TRUOTCHUA;
            }
            if (editLenhDienThoai.TextBox.Text.StartsWith("KTX") || editLenhDienThoai.TextBox.Text.StartsWith("ktx"))
            {
                editLenhDienThoai.TextBox.Text = LENH_KOTHAYXE;
            }
            IsTextChangeLenh = false;
        }

        private void chkKhongXeXinLoi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkThemXeDeCu_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiaChiDonKhach_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    btnOK.Focus();
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //    chkGoiTaxi.Focus();
            //}
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtDiaChiDonKhach.TextReturn != "")
            //        new MessageBox.MessageBox().Show("test");
            //}
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

        #region Xử lý HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {            
            if (keyData == Keys.Down && FindFocusedControl(txtDiaChiDonKhach) && txtDiaChiDonKhach.IsCompleted)
            {
                txtLoaiXe.Focus();
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
            if (keyData == (Keys.Control | Keys.Down)) {
                picXuong_Click(null, null);
                return true;
            }
            if (keyData == (Keys.Control | Keys.Up))
            {
                picLen_Click(null, null);
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
            else if (keyData == (Keys.Control|Keys.F))
            {
                txtDiaChi_GPS.Focus();
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
                    if (g_CuocGoi.Vung == null || g_CuocGoi.Vung <= 0)
                        editVung.Text = g_VungMacDinh;
                    else
                        editVung.Text = g_CuocGoi.Vung.ToString();
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                if (chkGoiLai.Enabled)
                {
                    chkGoiLai.Focus();
                    if (chkGoiLai.Checked)
                        chkGoiLai.Checked = false;
                    else
                        chkGoiLai.Checked = true;
                }
                
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.I))
            {
                if (chkGoiKhieuNai.Enabled)
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
                }
              
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                if (chkGoiDichVu.Enabled)
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
                }              

                return true;
            }
            else if (keyData == (Keys.Alt | Keys.M))
            {
                if (chkGoiHoiDam.Enabled)
                {
                    chkGoiHoiDam.Focus();
                    if (chkGoiHoiDam.Checked)
                    {
                        chkGoiHoiDam.Checked = false;
                    }
                    else
                    {
                        chkGoiHoiDam.Checked = true;
                    }
                }
                
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.K))
            {
                if (chkGoiKhac.Enabled)
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
            else if (keyData == (Keys.Alt | Keys.T))
            {
                if (pnlTongDai.Visible)
                {
                    chkTruot.Checked = chkTruot.Checked != true;
                }
                else
                {
                    if (pG5KetThuc.Visible)
                    {
                        chkTruotG5.Checked = !chkTruotG5.Checked;
                    }
                    else
                    {

                        editLenhDienThoai.Focus();
                    }
                    
                }
                  
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.O))
            {
                if (pnlTongDai.Visible)
                {
                    if (chkKhongXe.Checked == true)
                        chkKhongXe.Checked = false;
                    else
                        chkKhongXe.Checked = true;
                }
                else
                {
                   
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.H))
            {
                if (pnlTongDai.Visible)
                {
                    if (chkHoan.Checked == true)
                        chkHoan.Checked = false;
                    else
                        chkHoan.Checked = true;
                }
                else
                {
                    if (pG5KetThuc.Visible)
                    {
                        chkHoanG5.Checked = !chkHoanG5.Checked;
                    }
                }
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
            else if (keyData == (Keys.Alt | Keys.C))
            {
                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    txtXeDenDiem.Focus();
                    txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
                }
                //if (chkCipucha.Checked == true)
                //    chkCipucha.Checked = false;
                //else
                //    chkCipucha.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                if (chkMGDuongDai.Checked)
                    chkMGDuongDai.Checked = false;
                else chkMGDuongDai.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    txtXeDon.Focus();
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Z))
            {
                if (Global.MoHinh == MoHinh.TongDaiMini)
                {
                    txtXeNhan.Focus();
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                }
                else
                {
                    if (cbkCuocDieuApp.Enabled && cbkCuocDieuApp.Visible)
                    {
                        cbkCuocDieuApp.Focus();
                        cbkCuocDieuApp.Checked = !cbkCuocDieuApp.Checked;
                    }
                }
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
            //else if (keyData == (Keys.Alt | Keys.Z))
            //{
            //    cbkCuocTest.Focus();
            //     cbkCuocTest.Checked = !cbkCuocTest.Checked;
            //    return true;
            //}
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                if (uiTab1.SelectedTab == uiTabPage2)
                {
                    return false;
                }
                else
                {
                    //Đang focused TextDiaChi và thay đổi địa chỉ thì sẽ nhập tìm kiếm
                    if (txtDiaChi_GPS.IsFocused && CheckTextChangeDiaChi>0)
                    {
                        CheckTextChangeDiaChi --;
                        string diaChi = getDiaChiChuan(txtDiaChi_GPS.Text);
                        if (!string.IsNullOrEmpty(diaChi))
                        {
                            double viDo = 0;
                            double kinhDo = 0;
                            string toaDo = Taxi.Services.Service_Common.GetGeobyAddressBA_HN_First(diaChi, ThongTinCauHinh.GPS_TenTinh);
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                                kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                            if (kinhDo != 0 && viDo != 0)
                                MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi);
                        }
                        return true;
                    }
                    else
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
                if(IsNew)
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
            else if (keyData == (Keys.Shift | Keys.D4) || keyData == (Keys.Shift | Keys.NumPad4))
            {
                setVung("4");
                return true;
            }
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
                    new MessageBox.MessageBox().Show(this, "Phải là cuộc gọi mới(Chưa được chuyển sang tổng đài và chưa có thông tin xe nhận-đón)", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                }
                return true;
            }
            else if (keyData == (Keys.Alt|Keys.Y))
            {
                if (cbkSanBay.Enabled && cbkSanBay.Visible)
                {
                    cbkSanBay.Checked = !cbkSanBay.Checked;
                    cbkSanBay.Focus();

                }
                return true;
            }

            return false;
        }

        //Tìm điểm theo địa chỉ
        private void txtDiaChi_GPS_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    string diaChi = getDiaChiChuan(txtDiaChi_GPS.Text);
            //    if (!string.IsNullOrEmpty(diaChi))
            //    {
            //        double viDo = 0;
            //        double kinhDo = 0;
            //        string toaDo = Taxi.Services.Service_Common.GetGeobyAddressBA_HN_First(diaChi, ThongTinCauHinh.GPS_TenTinh);
            //        if (toaDo != "*" && toaDo != string.Empty)
            //        {
            //            string[] arrString = toaDo.Split(' ');
            //            viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
            //            kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);                        
            //        }
            //        else
            //        {
            //            lblThongBao.Text = MSG_6_BANDO;
            //        }
            //        if (kinhDo == 0 && viDo == 0)
            //            return;

            //        MainMap.addMarkerCustomer2(kinhDo, viDo, diaChi); 
            //    }                
            //}
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
                if (Global.MoHinh == MoHinh.TongDaiMini)
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                else
                    editLenhDienThoai.Focus();
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
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiHoiDam.Focus();
            }
        }

        private void chkGoiHoiDam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiDichVu.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiKhac.Focus();
            }
        }

        private void chkGoiKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkGoiHoiDam.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (Global.MoHinh != MoHinh.TongDaiMini)
                    editLenhDienThoai.Focus();
                else
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
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
                if (Global.MoHinh != MoHinh.TongDaiMini)
                    editLenhDienThoai.Focus();
                else
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
            }

        }

        private void editLenhDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editVung.Focus();
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
            }

            pnlBanDo.Controls.Add(MainMap);

           
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

            // kiểm tra và thiết lặp vị trí mặc định của bản đồ

            if(ThongTinCauHinh.GPS_KinhDo>0 && ThongTinCauHinh.GPS_ViDo>0)
                MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);

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
                {
                    PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                    try
                    {                        
                        string strDiaChi = Taxi.Services.Service_Common.GetAddressByGeoBA((float)point.Lat, (float)point.Lng);

                        MainMap.addMarkerCustomer(point, strDiaChi);
                    }
                    catch (Exception ex)
                    {
                        new MessageBox.MessageBox().Show("Không lấy được vị trí trên bản đồ");
                        LogError.WriteLogError("MainMap_MouseDown:", ex);
                    }
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
                    string toaDo = Taxi.Services.Service_Common.GetGeobyAddressBA_HN_First(strDiaChi, ThongTinCauHinh.GPS_TenTinh);

                    if (toaDo != "*" && toaDo != string.Empty)
                    {
                        string[] arrString = toaDo.Split(' ');
                        double viDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                        double kinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                        MainMap.addMarkerCustomer2(kinhDo, viDo,strDiaChi);
                    }
                    else
                    {
                        lblThongBao.Text = MSG_6_BANDO;
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
            var soLan = 2;

            if (chkDaGiaiQuyet.Checked)
            {
                do
                {
                    soLan--;
                    try
                    {
                        dsXeDeCu = WCFService_Common.LayDanhSachXeDeCu_ToaDoV2(kinhDo,
                            viDo,
                            ThongTinCauHinh.GPS_MaCungXN,
                            loaiXeGPS,
                            0,
                            true, SoXeTraVe, g_CuocGoi.ThoiDiemGoi, g_CuocGoi.IDCuocGoi,
                            g_CuocGoi.PhoneNumber,
                            txtDiaChiDonKhach.Text.Trim());
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
                        dsXeDeCu = WCFService_Common.LayDanhSachXeDeCu_ToaDoV2(kinhDo,
                                                                      viDo,
                                                                      ThongTinCauHinh.GPS_MaCungXN,
                                                                      loaiXeGPS,
                                                                      G_BanKinhTimXe,
                                                                      true, SoXeTraVe, g_CuocGoi.ThoiDiemGoi, g_CuocGoi.IDCuocGoi,
                                                                      g_CuocGoi.PhoneNumber,
                                                                      txtDiaChiDonKhach.Text.Trim());
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
                            Convert.ToDouble(Values[2], Global.CultureSystem),
                            Convert.ToDouble(Values[3], Global.CultureSystem),
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
                lblThongBao.Text = MSG_11_BANDO;
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
                lblThongBao.Text = MSG_12_BANDO;
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
                txtDiaChiDonKhach.Focus();
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
                txtDiaChi_GPS.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
            }
        }

        private void txtXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtXeDenDiem.Focus();
                txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkTruot.Focus();
            }
        }

        private void chkTruot_CheckedChanged(object sender, EventArgs e)
        {
            chkHoan.Checked = false;
            chkKhongXe.Checked = false;
        }

        private void chkHoan_CheckedChanged(object sender, EventArgs e)
        {
            chkTruot.Checked = false;
            chkKhongXe.Checked = false;
        }

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            chkTruot.Checked = false;
            chkHoan.Checked = false;
        }

        private void txtXeDenDiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtXeNhan.Focus();
                txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtXeDon.Focus();
                txtXeDon.SelectionStart = txtXeDon.Text.Length;
            }
        }

        private void chkMGDuongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                btnDatHen.Focus();}
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var dr=gridView1.GetDataRow(e.RowHandle);
                if (dr.Table.Columns.Contains("IsKetThuc") && dr["IsKetThuc"]!=DBNull.Value && dr["IsKetThuc"].ToString() == "1")
                {
                    e.Appearance.BackColor = Color.PeachPuff;
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "DiaChiDonKhach")
            {
                var dr = gridView1.GetDataRow(e.RowHandle);
                if (dr.Table.Columns.Contains("FT_IsFT") && dr["FT_IsFT"] != DBNull.Value && bool.Parse(dr["FT_IsFT"].ToString())==true)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void shGridControl1_Resize(object sender, EventArgs e)
        {
            grcolDiaChiDon.Width = shGridControl1.Width - grcolGhiChuDTV.Width - grcolGhiChuTDV.Width - grcolThoiGianGoi.Width - grcolXeDon.Width -grcolXeNhan.Width;
            if (grcolDiaChiDon.Width < 190) grcolDiaChiDon.Width = 190;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0 && Config_Common.DienThoai_LayDiaChiLichSu)
                txtDiaChiDonKhach.Text=gridView1.GetDataRow(e.RowHandle)["DiaChiDonKhach"].To<string>();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkTruotG5_CheckedChanged(object sender, EventArgs e)
        {
            chkHoanG5.Checked = false;
        }

        private void chkHoanG5_CheckedChanged(object sender, EventArgs e)
        {
            chkTruotG5.Checked = false;
            cbkGuiLenhLenLaiXe.Checked = false;
        }

        private void picLen_Click(object sender, EventArgs e)
        {
            panel_LichSuCuocGoi.Visible =false;
            picLen.Visible = false;
            picXuong.Visible = true;
            Config_Common.G5_PinMap = true;
            QuanTriCauHinh.G5_Update_PinMap(QuanTriCauHinh.IpAddress,"1");
        }

        private void picXuong_Click(object sender, EventArgs e)
        {
            panel_LichSuCuocGoi.Visible = true;
            picLen.Visible = true;
            picXuong.Visible = false;
            Config_Common.G5_PinMap = false;
            QuanTriCauHinh.G5_Update_PinMap(QuanTriCauHinh.IpAddress, "0");
        }

        private void ShowDieuApp(bool isDieuApp,bool IsGPS=true)
        {
            try
            {
                if (isDieuApp)
                {
                    cbkSanBay.Enabled = false;
                    cbkSanBay.Checked = false;
                    editLenhDienThoai.Enabled = false;
                    picG5.Visible = true;
                    this.Text = "Điện thoại viên (Enter : Điều App, ESC : Đóng )";
                    btnOK.Text = "Điều App";
                    if (!cbkCuocDieuApp.Enabled)
                        pG5KetThuc.Visible = true;
                    else pG5KetThuc.Visible = false;

                    chkGoiLai.Enabled = false;
                    chkGoiKhieuNai.Enabled = false;
                    chkGoiDichVu.Enabled = false;
                    chkGoiHoiDam.Enabled = false;
                    chkDaGiaiQuyet.Enabled = false;
                    if (cbkCuocDieuApp.Enabled && IsGPS)
                        btnGPS.PerformClick();
                }
                else
                {
                    cbkSanBay.Enabled = true;
                    editLenhDienThoai.Enabled = true;
                    picG5.Visible = false;
                    this.Text = "Điện thoại viên (Enter : Cập nhật, ESC : Đóng )";
                    btnOK.Text = "Cập nhật";
                    pG5KetThuc.Visible = false;

                    chkGoiLai.Enabled = true;
                    chkGoiKhieuNai.Enabled = true;
                    chkGoiDichVu.Enabled = true;
                    chkGoiHoiDam.Enabled = true;
                    chkDaGiaiQuyet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ShowDieuApp", ex);
            }
            
        }
        private void ShowCuocSanBay(bool isCuocSanBay)
        {
            if (isCuocSanBay)
            {
                cbkCuocDieuApp.Enabled = false;
                cbkCuocDieuApp.Checked = false;
                picAirPlane.Visible = true;
                lblCoCuocGoiMoi.Text = "SÂN BAY";
                lblCoCuocGoiMoi.Visible = true;
            }
            else
            {
                cbkCuocDieuApp.Enabled = true;
                picAirPlane.Visible = false;
                lblCoCuocGoiMoi.Text = "CÓ CUỘC GỌI MỚI (F1 : CHUYỂN)";
                lblCoCuocGoiMoi.Visible = IsNew;
            }
        }

        private void cbkCuocDieuApp_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CuocThuKhongDon))
            {
                if (cbkCuocDieuApp.Checked)
                {
                    txtDiaChiDonKhach.Text = CuocThuKhongDon.ToUpper() + " " + txtDiaChiDonKhach.Text.ToUpper().Trim();
                }
                else
                {
                    txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                }
            }
           
            ShowDieuApp(cbkCuocDieuApp.Checked);
        }

        private void cbkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            ShowCuocSanBay(cbkSanBay.Checked);
        }
        //private void chkKhongXe_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Up)
        //    {
        //        chkXe7.Focus();
        //    }
        //    else if (e.KeyCode == Keys.Down)
        //    {
        //        editSoLuongXe.Focus();
        //    }
        //}        
        #endregion        

        #region === Check So điện thoại có thể điều  app ===

        /// <summary>
        /// Kiểm tra số điện thoại có đúng định dạng để cho phép điều app
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null || phoneNumber.Length < 10) return false;

            if (!phoneNumber.StartsWith("+84") && !phoneNumber.StartsWith("84") && !phoneNumber.StartsWith("01") && !phoneNumber.StartsWith("09")&&!phoneNumber.StartsWith("06")&&!phoneNumber.StartsWith("0")) return false;
            return true;
        }

        #endregion
        
    }
}