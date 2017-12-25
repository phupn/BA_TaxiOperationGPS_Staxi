#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Common;
using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Controls.DanhMuc;
using Taxi.Controls.ThueBaoTuyen;
using Taxi.Utils;
using Femiani.Forms.UI.Input;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using Taxi.Entity;
using Taxi.Business.KhachDat;
using System.Globalization;
using Taxi.Services;
using Taxi.Utils.Enums;
using Taxi.Common.Extender;
using Taxi.Data.DM;
using DevExpress.Utils;
using TaxiApplication.Base;
using TaxiApplication.Properties;
using MessageBoxButtons = Taxi.MessageBox.MessageBoxButtonsBA;
using MessageBoxIcon = Taxi.MessageBox.MessageBoxIconBA;
using System.Linq;
using System.Data;
using Taxi.Controls;
using TaxiApplication.GUI.FrmCanhBaoDieuApp;
using Taxi.Data.FastTaxi;
using Taxi.Services.ServiceG5;
using Taxi.Data.G5.DanhMuc;
using Taxi.Data.BanCo.Entity;
using Taxi.MessageBox;
using Taxi.Controls.Maps;

#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.GUI 
{
    /// <summary>
    ///  - Tach phan validate thong tin nhập 
    ///  - Tách phần báo lỗi validate
    /// </summary>
    /// <Modified>        
    ///	Name		Date		        Comment 
    /// Congnt      07/14               Update
    /// Phupn       22/3/2012           Update
    /// </Modified> 
    public partial class frmDienThoaiInputDataNew_V3 : Form  
    {
        #region ==========================Init=================================        
        // Gửi sự kiện có cuộc gọi mới. Hiển thị thông báo có cuộc gọi mới có chuyển tới
        public delegate void HienThiCuocMoiEventHandler(object sender, EventArgs e);
        public delegate DateTime GetTimeServerEventHandler();
        public delegate void HienThiPopUpCuocGoiMoiHandler();
        public event HienThiCuocMoiEventHandler HienThiCuocMoiEvent;
        public event GetTimeServerEventHandler GetTimeServerEvent;
        public event HienThiPopUpCuocGoiMoiHandler HienThiPopUpCuocGoiMoiEvent;
        public event CallOut EventCallOut;

        public void OnHienThiCuocMoiEvent(EventArgs e)
        {
            if (HienThiCuocMoiEvent != null)
                HienThiCuocMoiEvent(new object(), e);
        }

        public void OnHienThiPopUpCuocGoiMoiEvent()
        {
            if (HienThiPopUpCuocGoiMoiEvent != null)
                HienThiPopUpCuocGoiMoiEvent();
        }

        public DateTime GetTimeServer()
        {
            if (GetTimeServerEvent != null)
                return GetTimeServerEvent();
            return DateTime.Now;
        }
        public event EventHandler<TaxiEventArgs> OKCloseFormEvent;
        public double G_ViDo = 0;
        public double G_KinhDo = 0;
        public double G_ViDo_Tra = 0;
        public double G_KinhDo_Tra = 0;     
        public enum BangMaValidate
        {
            ValidateSuccess = 0,
            NhapThongTinDiaChi = 1,     // Bạn phải nhập thông tin vào trường địa chỉ.
            NhapMotLoaiCuocGoi = 2,     // Bạn phải chọn một loại cuộc gọi.
            NhapSoLuongXe = 3,          // Bạn phải nhập số lượng xe.
            NhapKenh = 4,               // Bạn phải nhập kênh (vùng) theo quy định.
            ChonKhongXeXinLoiKhach = 5, // Bạn không thể chọn không xe xin lỗi khách, khi có xe nhận.
            Msg6_KhongTimThayDCBanDo = 6,
            Msg7_ChuaNhapKenh = 7,
            Msg8_TaiBanDo = 8,
            Msg9_ChonKenhTK = 9,
            Msg10_ChonLoaiXe = 10,
            NhapChinhXacXe = 13,
            NhapXeDonThuocXeNhan = 14,
            DienThoaiDaHuy = 15,
            DaGiaiQuyet = 16,           // Đã giải quyết là cuốc không có xe nhận.
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

        //private const string LENH_HUYXE = "Hủy xe/Hoãn";
        //private const string LENH_KOTHAYXE = "Ko thấy xe";
        //private const string LENH_TRUOTCHUA = "Trượt/Chùa";
        //private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        //private const string LENH_DAXINLOI = "Đã xin lỗi khách";
        //private const string LENH_G_GIUCXE = "Giục xe";
        //private const string LENH_NhamKH = "Nhầm khách";
        private const string g_LoaiXeMacDinh = "KIA";
        private CuocGoi g_CuocGoi;
        private bool g_CloseForm = false;
        public bool g_DialogResult = false;
        /// <summary>
        /// Cuộc gọi có GPS hay không
        /// </summary>
        private bool g_GPS = false;
        /// <summary>
        /// Cuộc gọi đã vượt mức giới hạn cho phép hoặc không được phép sử dụng GPS. g_CGLimit = true : giới hạn, không được phép sử dụng GPS
        /// </summary>
        public bool g_CGLimit = false; 
        public AutoCompleteEntryCollection g_ListDataAutoComplete;        
        public CuocGoi GetCuocGoi
        {
            get { return g_CuocGoi; }
        }
        public CuocGoi.ThongTinGoiLai thongTinGoiLai;

        public List<string> g_ListSoHieuXe { set; get; }
        public List<Business.DM.NhanVien> ListNhanVien { set; internal get; }

        private string g_XeNhan = "";
        private string g_XeDon = "";
        private string g_XeDenDiem = "";
        private int g_XeDonLength = 0;
        private const string CuocThuKhongDon = "";
        /// <summary>
        /// Trạng thái có cuốc mới.
        /// </summary>
        public bool g_IsNew { get; set; }

        /// <summary>
        /// Trạng thái cuốc đã điều app
        /// </summary>
        private bool g_CuocDaDieuApp = false;

        /// <summary>
        /// Trạng thái cuốc gọi lại điều app
        /// </summary>
        private bool g_CuocGoiLaiAppLaiXe = false;

        /// <summary>
        /// Trạng thái cuốc hiện tại là cuộc gọi lại.
        /// </summary>
        private bool g_CuocGoiLai = false;

        /// <summary>
        /// Trạng thái cuốc hiện tại là có xe nhận
        /// </summary>
        private bool CuocCoXeNhan = false;
        private int CheckTextChangeDiaChi = 0;
        private bool cbkCuocDieuAppEnabled = false;
        private bool cbkDieuLaiEnabled = false;
        private const string TxtDieuApp = "Điều App";
        private const string TxtTitleDieuApp = "Điện thoại viên (Enter : Điều App, ESC : Đóng )";
        private const string TxtCapNhat = "Cập nhật";
        private const string TxtTitleCapNhat = "Điện thoại viên (Enter : Cập nhật, ESC : Đóng )";
        public CuocGoi.CheckChange GetCheckChange;        
        private bool IsLoading = true;
        #endregion

        #region =======================Constructor=============================

        public frmDienThoaiInputDataNew_V3()
        {
            try
            {
                InitializeComponent();
                if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                    return;
                editSoLuongXe.Text = "1";
                chkGoiTaxi.Checked = true;
                gridHistory.UseEmbeddedNavigator = false;
                InitForm();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDienThoaiInputDataNew_V3: ", ex);
            }
        }

        /// <summary>
        /// Hàm khởi tạo truyển dữ liệu lên
        /// </summary>
        public frmDienThoaiInputDataNew_V3(AutoCompleteEntryCollection listDataAutoComplete, bool CGLimit, List<DMVung_GPSEntity> DMVung_GPS)
        {
            InitializeComponent();
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            editSoLuongXe.Text = "1";
            chkGoiTaxi.Checked = true;
            g_ListDataAutoComplete = listDataAutoComplete;

            //g_CGLimit = CGLimit;
            gridHistory.UseEmbeddedNavigator = false;
            InitForm();
        }

        private void InitForm()
        {
            this.WindowState = FormWindowState.Normal;
            if (Config_Common.DTV_INPUT_MINI)
            {
                this.Size = new Size(this.Size.Width - 163, this.Size.Height);
            }
            else
            {
                panel1_Top.Controls.Remove(panel1_Top_Bottom);
                panel1_Top_Fill.Controls.Add(panel1_Top_Bottom);
                panel1_Top.Size = new System.Drawing.Size(panel1_Top.Size.Width, panel1_Top.Size.Height - panel1_Top_Bottom.Size.Height);
                panel1_Top_Bottom.Height = panel1_Top_Bottom.Size.Height + 15;
            }

            ConfigMap();
            txtDiaChi_GPS.TextChanged += txtDiaChi_GPS_TextChanged;
            if (((g_CuocGoi != null && g_CuocGoi.G5_Type != Enum_G5_Type.DieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.CuocAppKH) && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini) || (Config_Common.App_DieuXeHopDong && Global.HasCarRole && g_CuocGoi != null && g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
            {
                pnlTongDai.Visible = true;
                chkKhongXe.Visible = true;
                cbkChuyenSangDam.Visible = false;                
            }
            else
            {
                pnlTongDai.Visible = false;
                chkKhongXe.Visible = false;
                cbkChuyenSangDam.Visible = true;
                editGhiChu.Visible = true;
            }
            txtDiaChiDonKhach.Items = g_ListDataAutoComplete;
            txtDiaChi_GPS.Items = g_ListDataAutoComplete;
            txtDiaChiTra.Items = g_ListDataAutoComplete;
            
            if (Config_Common.DienThoai_DieuTuDong)//*sign
            {
                if (Config_Common.CoDieuApp)
                    chkCuocDieuApp.Visible = true;
                else
                    chkCuocDieuApp.Visible = false;
            }
            else
            {
                chkCuocDieuApp.Visible = false;
            }

            //if (Config_Common.G5_PinMap)
            //{
            //    panel_LichSuCuocGoi.Visible = false;
            //}
            //else
            //{
            //    panel_LichSuCuocGoi.Visible = true;
            //}
            if (!Config_Common.App_DieuXeHopDong)
            {
                chkXeHD.Visible = false;
            }
        }

        #endregion

        #region ===================Load Form-Set Data==========================

        private void frmDienThoaiInputDataNew_V3_Load(object sender, EventArgs e) 
        {
            if (g_IsNew)
            {
                OnHienThiPopUpCuocGoiMoiEvent();
                g_IsNew = false;
            }
        }

        private void RefreshForm()
        {
            G_MarkerA = null;
            G_MarkerB = null;
            G_ViDo = 0;
            G_KinhDo = 0;
            G_ViDo_Tra = 0;
            G_KinhDo_Tra = 0;
            chkShowPhoneAppDriver.Visible = false;
            chkShowPhoneAppDriver.Checked = false;
            chkSanBay.Visible = true;
            chkSanBay.Checked = false;
            chkMGDuongDai.Visible = true;
            //dtpGioDon.Visible = false;
            ipLoaiXeChange = true;
            MainMap.ClearAllMarkers();
            //MainMap.MarkerCustomer = null;
            lblCoCuocGoiMoi.Visible = false;
            chk4Cho.Checked = false;
            chk7Cho.Checked = false;
            if (Config_Common.App_DieuXeHopDong)
            {
                chkXeHD.Visible = true;
                chkXeHD.Checked = false;
            }
            chkDaGiaiQuyet.Checked = false;
            chkDaGiaiQuyet.Visible = true;
            chkGoiDichVu.Checked = false;
            chkGoiHoiDam.Checked = false;
            chkGoiKhac.Checked = false;
            chkGoiKhieuNai.Checked = false;
            chkGoiLai.Checked = false;
            chkGoiTaxi.Checked = true;
            //chkHoan.Checked = false;
            chkHoanG5.Checked = false;
            chkKhongXe.Checked = false;
            chkMGDuongDai.Checked = false; 
            chkMGDuongDai.Enabled = true;
            //chkTruot.Checked = false;
            chkTruotG5.Checked = false;
            
            chkVung1_Search.Checked = false;
            chkVung2_Search.Checked = false;
            txtCuocGoiKoThanhCong.Text = "";
            txtTenKH.Text = "";
            txtDiaChi_GPS.Text = "";
            txtDiaChi_Search.Text = "";
            txtDiaChiDonKhach.Text = "";
            txtDiaChiTra.Text = "";
            //txtDiaChiTraKhach.Text = "";
            txtLoaiXe.Text = "";
            txtSoDT_Search.Text = "";
            txtSoLan.Text = "";
            txtXeDenDiem.Text = "";
            txtXeDon.Text = "";
            txtXeNhan.Text = "";
            editGhiChu.Text = "";
            editLenhDienThoai.Text = "";
            editSoLuongXe.Text = "1";
            editVung.Text = "1";
            chkCuocDieuApp.Enabled = true;
            chkCuocDieuApp.Checked = false;
            cbkCuocDieuAppEnabled = false;
            IsFastTaxi.Visible = false;
            picAirPlane.Visible = false;
            picWarning.Visible = false;
            picInfo.Visible = false;
            lblCoCuocGoiMoi.Visible = false;
            chkGoiLai.Visible = true;
            chkGoiKhieuNai.Visible = true;
            chkGoiDichVu.Visible = true;
            chkGoiHoiDam.Visible = true;
            if (((g_CuocGoi != null && g_CuocGoi.G5_Type != Enum_G5_Type.DieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.CuocAppKH) && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini) || (Config_Common.App_DieuXeHopDong && Global.HasCarRole && g_CuocGoi != null && g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
            {
                pnlTongDai.Visible = true;
                //editGhiChu.Visible = false;
                txtXeNhan.Enabled = true;
                txtXeNhan.Text = string.Empty;
                txtXeDenDiem.Text = string.Empty;
                txtXeDon.Text = string.Empty;
                pG5KetThuc.Visible = true;
                //chkTruot.Visible = false;
                chkKhongXe.Visible = true;
                cbkChuyenSangDam.Visible = false;
                //chkHoan.Visible = false;
            }
            else
            {
                pnlTongDai.Visible = false;
                chkKhongXe.Visible = false;
                editGhiChu.Visible = true;
                cbkChuyenSangDam.Visible = true;
            }
            chkDieuLai.Checked = false;
            chkDieuLai.Visible = false;
            // Reset phần tìm kiếm
            txtSoDT_Search.Text = string.Empty;
            txtDiaChi_Search.Text = string.Empty;
            chkVung1_Search.Checked = false;
            chkVung2_Search.Checked = false;
            uiTab1.SelectedTab = uiTabPage1;
            grcAll.DataSource = null;
            //RefreshLoaiXe();
            ipLoaiXeChange = false;
            chkGuiLenhLenLaiXe.Visible = false;
            chkGuiLenhLenLaiXe.Checked = false;
            ipLoaiXe.Enabled = CommonBL.IsStaxiLoaiXe;
            btnDatHen.Visible = true;
            GetCheckChange = new CuocGoi.CheckChange();
            IsChangeDiaChiDonKhach = false;
            thongTinGoiLai = null;
            g_CuocGoiLaiAppLaiXe = false;
            chkNhamKHG5.Visible = false;
            chkNhamKHG5.Checked = false;
            chkTruotG5.Visible = false;
            chkTruotG5.Checked = false;
            cbkChuyenSangDam.Checked = false;
            cbkChuyenSangDam.Visible = false;

            if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)
                MainMap.OverlayXeDeCu.Markers.Clear();
            ucDSLaiXe1.SetListNhanVien(CommonBL.ListDriver_Active);

            btnGPS.Enabled = true;
            btnRemoveGPS.Enabled = true;
        }

        /// <summary>
        /// Xác Định cuốc có hiển thị checkbox điều lại hay ko
        /// </summary>
        private bool g_HasDieuLai = false;
        /// <summary>
        /// Xác định cuốc có hiển thị checkbox chuyển sang đàm hay ko
        /// </summary>
        private bool g_HasChuyenDam = false;
        /// <summary>
        /// Xác định cuốc có hiển thị checkbox Hoãn cuốc
        /// </summary>
        private bool g_HasHoanCuoc = false;
        /// <summary>
        /// Xác định cuốc có hiển thị checkbox Trượt cuốc
        /// </summary>
        private bool g_HasTruotCuoc = false;
        /// <summary>
        /// Xác định cuốc có hiển thị checkbox Nhầm khách hay ko
        /// </summary>
        private bool g_HasNhamKhach = false;
        /// <summary>
        /// Là cuốc điều app nhầm khách
        /// </summary>
        private bool g_HasAppNhamKhach = false;
        private bool g_HasAppKHNhamKhach = false;

        /// <summary>
        /// Load thông tin cuộc gọi
        /// </summary>        
        public void LoadCuocGoi(CuocGoi cuocGoi)
        {
            IsLoading = true;
            g_CuocGoi = cuocGoi;
            RefreshForm();
            g_CuocGoiLai = g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai;
            CuocCoXeNhan = !string.IsNullOrEmpty(g_CuocGoi.XeNhan);

            #region Cuộc gọi lại cuốc mà cuốc trước là cuốc gọi đã điều app
            if (g_CuocGoiLai)
            {
                if (g_CuocGoi.BookId != Guid.Empty)
                {
                    thongTinGoiLai = CuocGoi.GetThongTinGoiLaiByBookId(g_CuocGoi.BookId);
                    if (thongTinGoiLai != null)
                    {
                        //Chưa có xe dùng điểm và điều app và có xe nhận
                        if (thongTinGoiLai.G5_Type == "3") // không cần có xe nhận cũng cho hoãn (lúc đang điều app) && !string.IsNullOrEmpty(thongTinGoiLai.XeNhan))
                            g_CuocGoiLaiAppLaiXe = true;
                    }
                }
                else if (!string.IsNullOrEmpty(g_CuocGoi.CuocGoiLaiIDs))
                {
                    thongTinGoiLai = CuocGoi.GetThongTinGoiLai(g_CuocGoi.CuocGoiLaiIDs);
                    if (thongTinGoiLai != null)
                    {
                        //Chưa có xe dùng điểm và điều app và có xe nhận
                        if (thongTinGoiLai.G5_Type == "3") // không cần có xe nhận cũng cho hoãn (lúc đang điều app) && !string.IsNullOrEmpty(thongTinGoiLai.XeNhan))
                            g_CuocGoiLaiAppLaiXe = true;
                    }
                }                
            }
            #endregion

            txtDiaChi_GPS.Text = "";
            g_CloseForm = false;
            lblCoCuocGoiMoi.Visible = false;
            //dtpGioDon.Enabled = false;
            SetDuLieuLenForm(g_CuocGoi);
            txtDiaChiDonKhach.Select();
            txtDiaChiDonKhach.Focus();
            if (g_CuocGoi.FT_IsFT)
            {
                chkGoiKhieuNai.Visible = false;
                chkGoiLai.Visible = false;
                chkGoiDichVu.Visible = false;
                chkGoiHoiDam.Visible = false;

                chkCuocDieuApp.Enabled = false;
                chkDaGiaiQuyet.Visible = false;
                if (g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                {
                    chkHoanG5.Visible = false;
                }
            }

            #region Lấy lịch sử cuốc
            if (Config_Common.DienThoai_LayLichSuCuoc > 0)
            {
                try
                {
                    DataTable dt = CuocGoi.DienThoai_LayLichSuTheoSoDienThoai(g_CuocGoi.PhoneNumber, g_CuocGoi.ThoiDiemGoi_FT, Config_Common.DienThoai_LayLichSuCuoc > 4 ? Config_Common.DienThoai_LayLichSuCuoc : 4);
                    gridHistory.DataSource = dt;
                    gridHistory.Refresh();
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("DienThoai_LayLichSuCuoc", ex);
                }
                gridHistory.UseEmbeddedNavigator = false;
            }
            else
            {
                panel1_Top_Bottom.Visible = false;
            }
            #endregion

            #region Get Thông tin khách hàng
            if (Config_Common.DienThoai_InfoKH)
            {
                picInfo.Visible = false;
                var KHInfo = KhachHangDungThe.Inst.GetKH(g_CuocGoi.PhoneNumber, GetTimeServer().Date);
                if (KHInfo != null)
                {
                    picInfo.Visible = true;
                    var toolTipTitleItem1 = new ToolTipTitleItem();
                    var toolTipItem1 = new ToolTipItem();
                    toolTipTitleItem1.Text = "Thông tin khách hàng";
                    toolTipItem1.Text = string.Format("Họ tên:{0}\nSDT:{1}\nMã KH:{2}\nĐịa chỉ:{3}", KHInfo.TenKhachHang, KHInfo.SoDienThoai, KHInfo.MaKhachHang, KHInfo.DiaChi);
                    var super = new SuperToolTip();
                    super.Items.Add(toolTipTitleItem1);
                    super.Items.Add(toolTipItem1);
                    picInfo.SuperTip = super;
                    txtTenKH.Text = KHInfo.TenKhachHang;
                }
            }

            if (Config_Common.GetThongTinGhiChuKH)
            {
                if (g_CuocGoi.Vung == 0)
                {
                    if (editGhiChu.Text == string.Empty)
                        editGhiChu.Text = KhachHangDungThe.Inst.GetGhiChuByPhoneOfKhachHang(g_CuocGoi.PhoneNumber);
                    else
                        editGhiChu.Text = (editGhiChu.Text + ';' + KhachHangDungThe.Inst.GetGhiChuByPhoneOfKhachHang(g_CuocGoi.PhoneNumber)).Trim(';');
                }
            }

            #endregion
            
            //picG5.Visible = false;
            cbkDieuLaiEnabled = true;
            if (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                && (g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp
                    || ((g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp
                        || g_CuocGoi.G5_Type == Enum_G5_Type.CuocAppKH
                        || g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai
                        || g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam
                        || g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai) && g_CuocGoi.G5_SendDate != null && g_CuocGoi.BookId != Guid.Empty)
                    )
                //&& !g_CuocGoi.FT_IsFT
                )
            {
                g_CuocDaDieuApp = true;
                ShowDieuApp(true, false);                
            }
            else if (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                && (g_CuocGoi.G5_Type == Enum_G5_Type.None || g_CuocGoi.G5_Type == Enum_G5_Type.DienThoai))
            {
                if (Config_Common.DTV_DefaultApp)
                {
                    chkCuocDieuApp.Checked = true;
                }
            }
            else
            {
                g_CuocDaDieuApp = false;
                ShowDieuApp(false);
            }

            #region Cuốc điều app

            //Xác Định cuốc có hiển thị checkbox điều lại hay ko
            g_HasDieuLai = false;
            //Xác định cuốc có hiển thị checkbox chuyển sang đàm hay ko
            g_HasChuyenDam = false;
            //Xác định cuốc có hiển thị checkbox Hoãn cuốc
            g_HasHoanCuoc = false;
            //Xác định cuốc có hiển thị checkbox Trượt cuốc
            g_HasTruotCuoc = false;
            //Xác định cuốc có hiển thị checkbox Nhầm khách hay ko
            g_HasNhamKhach = false;
            g_HasAppNhamKhach = (cuocGoi.G5_Type == Enum_G5_Type.DieuApp || cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp) && (cuocGoi.G5_StepLast == Enum_G5_Step.WrongCustomer || cuocGoi.G5_StepLast == Enum_G5_Step.DriverCancel);
            g_HasAppKHNhamKhach = cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) || !string.IsNullOrEmpty(g_CuocGoi.XeDungDiem)) && (g_CuocGoi.G5_StepLast == Enum_G5_Step.WrongCustomer || cuocGoi.G5_StepLast == Enum_G5_Step.SourceCancel_Customer);
            if ((cuocGoi.G5_Type != Enum_G5_Type.DienThoai || cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp) && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi) //Là cuốc đã điều và gọi taxi
            {
                var timeoutServer = GetTimeServer();
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked)
                    pG5KetThuc.Visible = true;

                #region === Hiển thị điều lại ===
                if ((//Hoặc là cuốc điều app Không xe,ko xe nhận,chưa sang đàm Hoặc có xe dừng điểm
                     ((cuocGoi.G5_Type == Enum_G5_Type.DieuApp || cuocGoi.G5_Type == Enum_G5_Type.CuocVangLai) &&
                        (cuocGoi.G5_StepLast == Enum_G5_Step.AckInitTrip || cuocGoi.LenhLaiXe == "Ko xe nhận" || cuocGoi.G5_StepLast == Enum_G5_Step.Driver_Guest ||
                            (
                             (!string.IsNullOrEmpty(cuocGoi.XeDungDiem)) && 
                             (cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc") && string.IsNullOrEmpty(cuocGoi.XeDon)
                            ) )                        
                    )
                    //Hoặc thời gian điều app quá Thời gian thời gian cho phép
                    || (Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai > 0 && 
                        (timeoutServer - (cuocGoi.G5_SendDate ?? cuocGoi.ThoiDiemGoi)).TotalMinutes > Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonDieuLai)
                    //Hoặc cuốc điều app không xe nhận, chuyển về trung tâm để chăm sóc khách hàng
                    || (Config_Common.DienThoai_AppkhongXe_ChoPhepDieuLai && cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                    || (!string.IsNullOrEmpty(cuocGoi.XeNhan) && Config_Common.DienThoai_DieuApp_CoXeNhanChoPhepDieuLai)
                    //Nhầm khách
                    || g_HasAppNhamKhach
                    || g_HasAppKHNhamKhach
                    // Hoặc trường hợp chưa điều app
                    || (cuocGoi.LenhDienThoai == "Chuyển App" && cuocGoi.LenhLaiXe == "")
                    )
                    && !(cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && cuocGoi.G5_StepLast == Enum_G5_Step.SourceCancel_Customer)
                    )
                {
                    //Nếu có cấu hình số 87 = 1 và đã có xe nhận *sign
                    //if ((!string.IsNullOrEmpty(cuocGoi.XeNhan) && Config_Common.DienThoai_DieuApp_CoXeNhanChoPhepDieuLai)) 
                    {
                        g_HasDieuLai = true;
                        chkDieuLai.Visible = g_HasDieuLai;
                        cbkDieuLaiEnabled = g_HasDieuLai;
                    }
                }
                
                #endregion

                #region === Hoãn cuốc ===
                //1.Cuốc đã điều.
                if (((cuocGoi.G5_Type == Enum_G5_Type.DieuApp &&cuocGoi.Vung > 0) 
                    ||cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc")
                    //Cuốc hợp đồng mà đã gặp khách rồi thì ko cho hoãn
                    && (cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong  || (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && cuocGoi.G5_StepLast != Enum_G5_Step.CatchedUser))
                    )
                {
                    g_HasHoanCuoc = true;
                    chkHoanG5.Visible = g_HasHoanCuoc;
                    chkHoanG5.Enabled = g_HasHoanCuoc;
                }

                #endregion

                #region ===Trượt===
                if (//Là cuốc điều app
                    cuocGoi.G5_Type == Enum_G5_Type.DieuApp &&
                    //Có xe nhận
                    (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && 
                    //Đã có xe dừng điểm hoặc thời điểm điều đã quá 5 phút
                    ((!string.IsNullOrEmpty(g_CuocGoi.XeDungDiem)) || (GetTimeServer() - (g_CuocGoi.G5_SendDate ?? g_CuocGoi.ThoiDiemGoi)).TotalMinutes > 5) && 
                    //Cấu hình 103 = 1 : cho phép trượt khi có xe nhận
                    (Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan))
                    //Cuốc hợp đồng mà đã gặp khách rồi thì ko cho trượt
                    && (cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong || (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && cuocGoi.G5_StepLast != Enum_G5_Step.CatchedUser))
                    )
                {
                    g_HasTruotCuoc = true;
                    chkTruotG5.Visible = g_HasTruotCuoc;
                }
                #endregion

                #region ===Chuyển đàm===
                //1.Cuốc đã điều.
                //2.Vượt quá thời gian cho phép.
                if (((cuocGoi.G5_Type == Enum_G5_Type.DieuApp || cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp || cuocGoi.G5_Type == Enum_G5_Type.CuocVangLai)
                    && (string.IsNullOrEmpty(cuocGoi.XeNhan) || cuocGoi.G5_StepLast == Enum_G5_Step.DriverCancelLast || cuocGoi.G5_StepLast == Enum_G5_Step.DriverCancel || cuocGoi.G5_StepLast == Enum_G5_Step.WrongCustomer))
                    && cuocGoi.Vung > 0
                    && (g_HasAppNhamKhach || g_HasAppKHNhamKhach
                        || !String.IsNullOrEmpty(cuocGoi.XeDungDiem) || !String.IsNullOrEmpty(cuocGoi.XeDon)
                        || (Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam > 0 && ((timeoutServer - (cuocGoi.G5_SendDate ?? cuocGoi.ThoiDiemGoi)).TotalMinutes > Config_Common.DienThoai_DieuApp_ThoiGianChoPhepChonChuyenDam))
                        || (string.IsNullOrEmpty(cuocGoi.XeNhan) && cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc")
                        )
                    && cuocGoi.LenhLaiXe != "Chờ LX nhận cuốc" //Phải đợi lệnh server hoặc timeout
                    )
                {
                    g_HasChuyenDam = true;
                    cbkChuyenSangDam.Visible = g_HasChuyenDam;
                }
                #endregion

                #region ==== Nhầm KH===
                //App Có xe nhận và chưa có xe dừng điểm
                //Hoặc cuốc nhầm khách từ app KH
                if ((cuocGoi.G5_Type == Enum_G5_Type.DieuApp || cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp) 
                    && !string.IsNullOrEmpty(g_CuocGoi.XeNhan) 
                    && ( g_HasAppKHNhamKhach || g_HasAppNhamKhach || !String.IsNullOrEmpty(g_CuocGoi.XeDon))
                    //Cuốc hợp đồng mà đã gặp khách rồi thì ko cho nhầm khách
                    && (cuocGoi.LoaiCuocKhach != LoaiCuocKhach.ChoKhachHopDong || (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong && cuocGoi.G5_StepLast != Enum_G5_Step.CatchedUser))
                    )
                {
                    g_HasNhamKhach = true;
                    chkNhamKHG5.Visible = g_HasNhamKhach;
                }                
                #endregion
            }
            #endregion

            else if (g_CuocGoiLaiAppLaiXe && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
            {
                g_HasHoanCuoc = true;
                chkHoanG5.Visible = g_HasHoanCuoc;
                pG5KetThuc.Visible = true;
                //cbkChuyenSangDam.Visible = true;
            }

            lblThongBao.Text = string.Empty;

            if ((Config_Common.CheckPhoneNumber == 1 && CommonBL.IsPhoneNumber_Valid(g_CuocGoi.PhoneNumber)) 
                || (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam) 
                || (g_CuocGoi.Vung > 0 && g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && (g_CuocGoi.BookId != Guid.Empty || g_CuocGoi.FT_IsFT || !string.IsNullOrEmpty(g_CuocGoi.LenhLaiXe) || !string.IsNullOrEmpty(g_CuocGoi.XeNhan)))
                )
            {
                cbkCuocDieuAppEnabled = true;
                chkCuocDieuApp.Enabled = false;
                if ((g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp || g_CuocGoi.G5_Type == Enum_G5_Type.CuocAppKH || g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai) 
                    && !string.IsNullOrEmpty(g_CuocGoi.XeNhan) 
                    && string.IsNullOrEmpty(g_CuocGoi.XeDungDiem))
                    chkGuiLenhLenLaiXe.Visible = true;
            }
            else
            {
                if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS)
                {
                    chkCuocDieuApp.Enabled = true;
                    var rs = ThongTinCauHinh.GPS_TrangThai;
                    ThongTinCauHinh.GPS_TrangThai = false;
                    if (!chkCuocDieuApp.Checked)
                        chkCuocDieuApp.Checked = true;
                    ThongTinCauHinh.GPS_TrangThai = rs;
                }
            }
            if (chkGuiLenhLenLaiXe.Checked)
            {
                editGhiChu.Text = editGhiChu.Text.Trim();
                if (editGhiChu.Text == "")
                    editGhiChu.Text = CommandCode.LENH_G_GIUCXE; //CommonBL.GetNameByCode(CommandCode.GiucXe, 1);
            }
            txtDiaChiDonKhach.Focus();
            this.ActiveControl = txtDiaChiDonKhach;
            IsChangeDiaChiDonKhach = false;
            IsChangeDiaChiTraKhach = false;
            IsChangeXeDon = false;
            IsChangeXeNhan = false;

            if (((g_CuocGoi != null && g_CuocGoi.G5_Type != Enum_G5_Type.DieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.CuocAppKH) && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini) || (cuocGoi.SanBay_DuongDai == "1" && Global.IsDieuSanBay) || (Config_Common.App_DieuXeHopDong && Global.HasCarRole && g_CuocGoi != null && cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
            {
                pnlTongDai.Visible = true;
                cbkChuyenSangDam.Visible = false;
                string LineDuocCapPhep = Global.LineDuocCapPhep + ";";
                if (LineDuocCapPhep.IndexOf(cuocGoi.Line + ";") >= 0 && string.IsNullOrEmpty(cuocGoi.XeNhan))
                {
                    chkKhongXe.Visible = true;
                }
                else
                {
                    chkKhongXe.Visible = false;
                }
                //editGhiChu.Visible = false;
                label7.Visible = false;
                if (cuocGoi.ThoiGianHen == null || cuocGoi.ThoiGianHen == DateTime.MinValue)
                {
                    dtpGioDon.SetValue(cuocGoi.ThoiDiemGoi);
                }
                else
                {
                    dtpGioDon.SetValue(cuocGoi.ThoiGianHen);
                }
                txtXeNhan.Enabled = true;

                if (cuocGoi != null)
                {
                    txtXeNhan.Text = cuocGoi.XeNhan;
                    txtXeDenDiem.Text = cuocGoi.XeDenDiem;
                    txtXeDon.Text = cuocGoi.XeDon;
                }
                else
                {
                    txtXeNhan.Text = string.Empty;
                    txtXeDenDiem.Text = string.Empty;
                    txtXeDon.Text = string.Empty;
                }
            }
            else
            {
                pnlTongDai.Visible = false;
                //cbkChuyenSangDam.Visible = true;
                chkKhongXe.Visible = false;
                editGhiChu.Visible = true;
                if(cuocGoi.ThoiDiemGoi>cuocGoi.ThoiGianHen)
                    dtpGioDon.SetValue(cuocGoi.ThoiDiemGoi);
            }
            //Hiển thị các checkbox
            ShowHide_CheckBoxDieu(g_HasDieuLai, g_HasChuyenDam, g_HasHoanCuoc, g_HasTruotCuoc, g_HasNhamKhach);

            IsLoading = false;
            if (!Visible)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(()=>ShowDialog()));
                    return;
                }
                else
                {
                    ShowDialog();
                }
            }

            if (g_CuocGoi.G5_Type == Enum_G5_Type.CuocAppKH || g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai)
            {
                editGhiChu.Focus();
            }
        }

        private void ShowHide_CheckBoxDieu(bool hasDieuLai, bool hasChuyenDam, bool hasHoan, bool hasTruot, bool hasNhamKhach)//*sign
        {
            chkDieuLai.Visible = hasDieuLai;
            cbkChuyenSangDam.Visible = hasChuyenDam;
            chkHoanG5.Visible = hasHoan;
            chkTruotG5.Visible = hasTruot;
            chkNhamKHG5.Visible = hasNhamKhach;
        }

        private void txtDiaChi_GPS_TextChanged(object sender, EventArgs e)
        {
            CheckTextChangeDiaChi = 1;
        }

        /// <summary>
        /// Dia chi de lay GPS
        /// </summary>
        private string GetDiaChiChuan(string diaChi)
        {
            string strDiaChi = diaChi;
            //G_DiaChiFull = StringTools.TrimSpace(diaChi);
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

        /// <summary>
        /// Hàm thực hiện set dữ liệu lên form
        /// </summary>
        private void SetDuLieuLenForm(CuocGoi cuocGoi)
        {
            if (cuocGoi != null)
            {
                string diaChi = cuocGoi.DiaChiDonKhach;
                if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp && !cuocGoi.FT_IsFT && cuocGoi.Vung > 0)//.DiaChiDonKhach.ToLower().Contains(CuocThuKhongDon.ToLower()))
                {
                    chkCuocDieuApp.Checked = true;
                }
                 /*
                 * Lệnh lái xe khi điều app thì luôn khác rỗng. cuốc điều đàm và ko điều app thì LenhLaiXe==null
                 * FT_IsFT=true là cuốc đặt app không xe nhận chuyển sang điểm đàm.
                 */
                txtTenKH.Text = cuocGoi.DiaChiGoi;
                if (Config_Common.DTV_Address_UPPER)
                {
                    txtDiaChiDonKhach.Text = diaChi.ToUpper();
                    txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach.ToUpper();
                }
                else
                {
                    txtDiaChiDonKhach.Text = diaChi;
                    txtDiaChiTra.Text = cuocGoi.DiaChiTraKhach;
                }
                lblInfo.Text = string.Format("[{0}] - {1} - {2:HH:mm dd/MM}", cuocGoi.Line, cuocGoi.PhoneNumber, cuocGoi.ThoiDiemGoi);
                SetThongTinLoaiCuocGoi(cuocGoi.KieuCuocGoi);
                

                //Loại xe
                if (cuocGoi.SanBay_DuongDai == "1" || cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachSanBay)
                {
                    chkSanBay.Checked = true;
                }
                else
                {
                    chkSanBay.Checked = false;
                }
                if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                {
                    chkXeHD.Checked = true;
                    this.picG5.EditValue = Resources.ic_car_time_01;
                }
                else
                {
                    this.picG5.EditValue = Resources.ic_GPS_01_Red;
                    if (cuocGoi.G5_StepLast == Enum_G5_Step.Driver_Guest)
                    {
                        this.picG5.EditValue = Resources.ic_car_P;
                    }
                    chkXeHD.Checked = false;
                }
                if (cuocGoi.SoLuong > 0)
                {
                    editSoLuongXe.Text = cuocGoi.SoLuong.ToString();
                }
                txtLoaiXe.Text = cuocGoi.LoaiXe;
                if (CommonBL.IsStaxiLoaiXe)
                {
                    RefreshLoaiXe();
                    SetG5LoaiXe(cuocGoi.G5_CarType, txtLoaiXe.Text);
                }
                else
                {
                    SetThongTinLoaiXe_G5(txtLoaiXe.Text, cuocGoi.G5_CarType);
                }
                //RefreshLoaiXe();
                
                //RefreshLoaiXe();
                // Nếu cuoc goi chua chuyen mot kenh nao va so lan goi >= 2 thi dat ma dinh la cuoc goi lai
                if (cuocGoi.SoLanGoi >= 1 || cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                {
                    chkGoiLai.Checked = true;
                    //editVung.Text = "2";
                }


                if (!g_CuocGoiLaiAppLaiXe)
                {
                    editLenhDienThoai.Text = cuocGoi.LenhDienThoai;
                }
                editGhiChu.Text = cuocGoi.GhiChuDienThoai;
                //if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioiKhac)
                //if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                    {
                        chkMGDuongDai.Checked = true;
                    }
                    else
                    {
                        chkMGDuongDai.Checked = false;
                    }                    
                }
                //else
                //{
                //    chkMGDuongDai.Enabled = false;
                //}

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
                            btnRemoveGPS.Enabled = true;
                            //g_CGLimit = false;
                        }
                        //else
                        //{
                        //    btnGPS.Enabled = false;
                        //    btnRemoveGPS.Enabled = false;
                        //    //g_CGLimit = true;
                        //}
                    }
                    lbl_FTAllowCall.Text = string.Empty;
                    lbl_FTAllowCall.Visible = false;
                    // là cuốc FastTaxi
                    if (cuocGoi.FT_IsFT)
                    {
                        //pG5KetThuc.Visible = false;
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
                            //picWarning.Visible = true;
                            //MainMap.addMarkerCustomer2(cuocGoi.FT_Cust_Lng, cuocGoi.FT_Cust_Lat, "");
                        }
                        else picWarning.Visible = false;

                        //if (!cuocGoi.FT_AllowCall)
                        //{
                        //    lbl_FTAllowCall.Text = "Khách không muốn nhận cuộc gọi";
                        //    lbl_FTAllowCall.Visible = true;
                        //}
                    }
                    else
                    {
                        label7.Visible = false;
                        btnGPS.Visible = true;
                        btnRemoveGPS.Visible = true;
                    }
                    if (cuocGoi.SanBay_DuongDai == "1" || cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong || cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                    {
                        dtpGioDon.SetValue(cuocGoi.ThoiGianHen);
                    }
                    else
                    {
                        dtpGioDon.SetValue(cuocGoi.ThoiDiemGoi);
                    }
                    //Cuoc dieu app thi ko cho nhap xe nhan xe don
                    if (cuocGoi.G5_Type != Enum_G5_Type.CuocAppKH && cuocGoi.G5_Type != Enum_G5_Type.DieuApp && 
                        (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || (cuocGoi.SanBay_DuongDai == "1" && Config_Common.DieuSanBay != 01) || Global.HasCarRole))
                    {
                        if (!string.IsNullOrEmpty(cuocGoi.XeNhan))
                        {
                            txtXeNhan.Text = cuocGoi.XeNhan + ".";
                            txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                            if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                            {
                                txtXeNhan.Enabled = false;
                            }
                        }
                        if (!string.IsNullOrEmpty(cuocGoi.XeDenDiem))
                        {
                            txtXeDenDiem.Text = cuocGoi.XeDenDiem + ".";
                            txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
                        } if (!string.IsNullOrEmpty(cuocGoi.XeDon))
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
                        G_KinhDo_Tra = cuocGoi.GPS_KinhDo_Tra;
                        G_ViDo_Tra = cuocGoi.GPS_ViDo_Tra;
                        G_MarkerA = MainMap.AddMarkerA(new PointLatLng(cuocGoi.GPS_ViDo, cuocGoi.GPS_KinhDo), diaChi, true, true, 0, true);
                            

                        if (cuocGoi.Vung > 0)
                        {
                            editVung.Text = cuocGoi.Vung.ToString();
                        }
                        else
                        {
                            SetKenhByDiaChi((float)cuocGoi.GPS_ViDo, (float)cuocGoi.GPS_KinhDo);
                        }
                        if (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam || g_CuocGoi.G5_Type == Enum_G5_Type.DienThoai) // Nếu là cuốc điều đàm thì sẽ thực hiện xem xe đề cử
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
                            editVung.Text = cuocGoi.Vung.ToString();
                        }
                        else
                            editVung.Text = Config_Common.VungMacDinh;
                    }
                    g_GPS = cuocGoi.CoGPS;
                }
                else
                {
                    g_GPS = false;
                    if (cuocGoi.Vung > 0)
                    {
                        editVung.Text = cuocGoi.Vung.ToString();
                    }
                    else
                        editVung.Text = Config_Common.VungMacDinh;
                }
                                
            }
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

        private void SetThongTinLoaiXe_G5(string loaixe, string CarType)
        {
            bool CheckLoaiXe = true;
            if (!string.IsNullOrEmpty(CarType))
            {
                if ((CarType == ((int)Enum_G5_CarType.Xe4Cho).ToString()) || (CarType == ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString()))
                {
                    chk4Cho.Checked = true;
                    CheckLoaiXe = false;
                }
                else if ((CarType == ((int)Enum_G5_CarType.Xe7Cho).ToString()) || (CarType == ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString()))
                {
                    chk7Cho.Checked = true;
                    CheckLoaiXe = false;
                }
            }
            if (CheckLoaiXe && !string.IsNullOrEmpty(loaixe))
            {
                loaixe.Split(',').All(p =>
                {
                    if (p.Contains("4"))
                    {
                        chk4Cho.Checked = true;
                    }
                    else if (p.Contains("7"))
                    {
                        chk7Cho.Checked = true;
                    }
                    else
                    {
 
                    }
                    return true;
                });
            }
            int start = loaixe.IndexOf('(') + 1;
            int end = loaixe.IndexOf(')');
            if (!string.IsNullOrEmpty(loaixe))
            {
                if (start > 0 && end > 0 && end - start > 0)
                {
                    txtLoaiXe.Text = loaixe.Substring(start, end - start);
                }
                else
                {
                    txtLoaiXe.Text = loaixe;
                }
            }
        }

        /// <summary>
        /// Nhập kênh tự động theo địa chỉ.
        /// </summary>
        /// <param name="viDo">kinh độ của địa chỉ khách</param>
        /// <param name="kinhDo">Vi độ của địa chỉ khách</param>
        private void SetKenhByDiaChi(float viDo, float kinhDo)
        {
            int vung = getKenhByDiaChi(viDo, kinhDo);
            if (vung > 0)
                editVung.Text = vung.ToString();
            else
                editVung.Text = Config_Common.VungMacDinh;
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
            if (chkGoiTaxi.Checked && (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || (Config_Common.DieuSanBay !=0 && cuocGoi.SanBay_DuongDai == "1") || chkXeHD.Checked ))
            {
                g_XeDon = StringTools.ConvertToChuoiXeNhanChuan(txtXeDon.Text);
                g_XeNhan = StringTools.ConvertToChuoiXeNhanChuan(txtXeNhan.Text);
                g_XeDenDiem = StringTools.ConvertToChuoiXeNhanChuan(txtXeDenDiem.Text);
                if (!string.IsNullOrEmpty(g_XeNhan))
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
                if (!string.IsNullOrEmpty(g_XeDenDiem))
                {
                    if (StringTools.KiemTraTrungLapXeChay(g_XeDenDiem))
                    {
                        return BangMaValidate.NhapXeDonThuocXeNhan;
                    }
                }
                // Kiểm tra xe đó có nằm trong xe đón
                if (!string.IsNullOrEmpty(g_XeDon))
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
            if ((chkGoiTaxi.Checked == false) 
                && (chkGoiLai.Checked == false) 
                && (chkGoiKhieuNai.Checked == false) 
                && (chkGoiDichVu.Checked == false) 
                &&(chkGoiHoiDam.Checked == false) 
                && (chkGoiKhac.Checked == false))
            {
                chkGoiTaxi.Focus();
                return BangMaValidate.NhapMotLoaiCuocGoi;
            }

            if (chkGoiTaxi.Checked || chkGoiLai.Checked || chkGoiHoiDam.Checked || chkGoiKhieuNai.Checked)
            {
                #region Kenh
                try
                {
                    string kenh = editVung.Text.Trim();
                    //Nếu là cuốc gọi lại của app thì ko phải check vùng.
                    if (!g_CuocGoiLaiAppLaiXe && (editVung.Text.Trim() == "" || !CheckVungNamTrongVungCauHinh(Convert.ToInt16(kenh)))) // kiểm tra kênh có nằm trong vùng quy đinh.
                    {
                        //Chỉ áp dụng điều chỉ định cho phép nhập vùng null
                        if (g_CuocGoi.Vung == 0 && !chkCuocDieuApp.Checked && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini && Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS)
                            return BangMaValidate.ValidateSuccess;
                        editVung.Focus();
                        return BangMaValidate.NhapKenh;
                    }
                    if (chkGoiLai.Checked && !chkDaGiaiQuyet.Checked && (editVung.Text.Trim() == "" || !CheckVungNamTrongVungCauHinh(Convert.ToInt16(kenh))))
                    {
                        return BangMaValidate.NhapKenh;
                    }
                }
                catch 
                {
                    editVung.Focus();
                    return BangMaValidate.NhapKenh;
                }


                #endregion Kenh

                if (chkGoiTaxi.Checked)
                {
                    #region So luong xe
                    // Kiểm tra số lượng xe
                    byte soLuongXe;
                    try
                    {
                        soLuongXe = Convert.ToByte(editSoLuongXe.Text);
                    }
                    catch 
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
            if (!chkGoiKhac.Checked && cuocGoi.GetLenhDienThoaiCurrent() == CommonBL.GetNameByCodeEnum(Enum_CommandCode.DTV_HuyHoan, 1))
            {
                return BangMaValidate.DienThoaiDaHuy;
            }
            //Fix Loi khi cap nhat da giai quyet va co xe nhan
            if (chkDaGiaiQuyet.Checked && (!g_CuocGoiLai && cuocGoi.XeNhan.Trim().Length > 0))
            {
                if (g_CuocGoiLaiAppLaiXe && chkGoiLai.Checked)
                    return BangMaValidate.ValidateSuccess;
                return BangMaValidate.DaGiaiQuyet;
            }
            //
            return BangMaValidate.ValidateSuccess;
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
                    if (xe.ToUpper() == arrXeNhan[i].ToUpper())
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
            chkDaGiaiQuyet.Enabled = !chkGoiTaxi.Checked;
            if (g_CuocGoi != null && g_CuocGoi.G5_SendDate != null)
            {
                chkDaGiaiQuyet.Enabled = false;
            }

            if (chkGoiTaxi.Checked)
            {
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                if (((g_CuocGoi != null && g_CuocGoi.G5_Type != Enum_G5_Type.DieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.CuocAppKH) && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini) || (Config_Common.App_DieuXeHopDong && Global.HasCarRole && g_CuocGoi != null && g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong))
                {
                    pnlTongDai.Visible = true;
                    chkKhongXe.Visible = true;
                    cbkChuyenSangDam.Visible = false;
                    //editGhiChu.Visible = false;
                }
                else
                {
                    pnlTongDai.Visible = false;
                    cbkChuyenSangDam.Visible = g_HasChuyenDam;
                    chkKhongXe.Visible = false;
                    editGhiChu.Visible = true;
                }
                chkCuocDieuApp.Enabled = !cbkCuocDieuAppEnabled;
                //EnableControl();
                //if (g_CuocGoiLaiAppLaiXe)
                {
                    chkDaGiaiQuyet.Checked = false;
                }
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
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
                chkKhongXe.Visible = false;
                cbkChuyenSangDam.Visible = false;
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
                cbkChuyenSangDam.Visible = false;
                chkKhongXe.Visible = false;
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
            }
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
                chkGoiKhieuNai.Checked = false;
                chkGoiHoiDam.Checked = false;
                chkGoiKhac.Checked = false;
                pnlTongDai.Visible = false;
                cbkChuyenSangDam.Visible = false;
                chkKhongXe.Visible = false;
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
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
                chkKhongXe.Visible = false;
                cbkChuyenSangDam.Visible = false;
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
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
                cbkChuyenSangDam.Visible = false;
                chkKhongXe.Visible = false;
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
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
        /// Hàm thực hiện hiển thị có cuộc gọi mới
        /// </summary>
        public void HienThiThongBaoCoCuocGoiMoi()
        {
            g_IsNew = true;
            lblCoCuocGoiMoi.Visible = true;
            OnHienThiPopUpCuocGoiMoiEvent();
        }

        private void setVung(string vung)
        {
            editVung.Focus();
            editVung.Text = vung;
        }
        #endregion

        #region =======================Get Data Form===========================
        /// <summary>
        /// Hàm cập nhật thông tin cuộc gọi mới nhập vào
        /// </summary>        
        private void GetThongTinNhapMoi(ref CuocGoi cuocGoi)
        {
            try
            {
                if (Config_Common.DienThoai_ChuyenKhachMGThanhKhachThuong)
                {
                    //Cuộc gọi môi giới nhưng đón ở địa khác thì
                    if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi
                        && IsChangeDiaChiDonKhach
                        && cuocGoi.Vung == 0
                        && !cuocGoi.DiaChiDonKhach.Equals(txtDiaChiDonKhach.Text.Trim())
                        )
                    {
                        cuocGoi.KieuKhachHangGoiDen = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    }
                }
                cuocGoi.DiaChiDonKhach = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                if (Config_Common.DTV_Address_UPPER)
                {
                    cuocGoi.DiaChiDonKhach = cuocGoi.DiaChiDonKhach.ToUpper();                    
                }
                else
                {
                    cuocGoi.DiaChiDonKhach = cuocGoi.DiaChiDonKhach; 
                }
                cuocGoi.LenhDienThoai = StringTools.TrimSpace(editLenhDienThoai.Text).Trim();
                cuocGoi.GhiChuDienThoai = StringTools.TrimSpace(editGhiChu.Text).Trim();
                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                cuocGoi.DiaChiGoi = StringTools.TrimSpace(txtTenKH.Text);

                cuocGoi.SanBay_DuongDai = "";
                if (chkMGDuongDai.Checked)
                {
                    cuocGoi.LoaiCuocKhach = LoaiCuocKhach.ChoKhachDuongDai;
                }
                else if (chkSanBay.Checked && chkSanBay.Visible)
                {
                    cuocGoi.SanBay_DuongDai = "1";
                    cuocGoi.LoaiCuocKhach = LoaiCuocKhach.ChoKhachSanBay;
                }
                else if (chkXeHD.Checked)
                {
                    cuocGoi.LoaiCuocKhach = LoaiCuocKhach.ChoKhachHopDong;                    
                }
                else
                {
                    cuocGoi.LoaiCuocKhach = LoaiCuocKhach.ChoKhachNoiTinh;
                }
                if (!chkMGDuongDai.Checked)
                {
                    ResetLongValues();
                }
                cuocGoi.MoneyTrip = 0;

                #region Gọi taxi
                //LogError.WriteLogInfo(string.Format("{0}-{1}", cuocGoi.IDCuocGoi, "Log3"));
                if (chkGoiTaxi.Checked)
                {
                    //LogError.WriteLogInfo(string.Format("{0}-{1}", cuocGoi.IDCuocGoi, "Log6"));
                    if (!chkDieuLai.Checked)
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh;

                    if (chkCuocDieuApp.Checked && !cbkChuyenSangDam.Checked)
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.DieuApp;
                        //cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe;
                    }
                    else if (cbkChuyenSangDam.Checked && cbkChuyenSangDam.Visible)
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                        cuocGoi.XeNhan = "";
                    }
                    if (!string.IsNullOrEmpty(editVung.Text) && cuocGoi.Vung != Convert.ToByte(editVung.Text) && Convert.ToByte(editVung.Text) > 0)
                    {
                        if (chkGoiTaxi.Checked)
                        {
                            cuocGoi.FT_Status = Enum_FastTaxi_Status.ChuyenSangDam;                            
                        }
                    }
                    cuocGoi.SoLuong = Convert.ToByte(editSoLuongXe.Text);

                    // LogError.WriteLogInfo(string.Format("{0}-{1}", cuocGoi.IDCuocGoi, "Log4"));
                    //Nếu là cuốc đặt không xe từ app KH thì sẽ chuyển sang đàm luôn.
                    //if (cuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && !cbkDieuLai.Checked && !cbkCuocDieuApp.Checked
                    //    && cuocGoi)
                    //{
                    //    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    //}
                    //Nếu trước đó là cuốc điều app, khi khách hàng gọi lại.
                    //muốn điều cuốc app mới thì xóa bookid đi
                    if (cuocGoi.G5_Type == Enum_G5_Type.DienThoai && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                    {
                        cuocGoi.BookId = Guid.Empty;
                        cuocGoi.XeNhan = "";
                    }
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiTaxi;
                    // Nếu vùng ==0 || == null || G5_Type=DienThoai tức là cuốc chưa được xử lý
                    if (cuocGoi.Vung == 0 || cuocGoi.G5_Type == Enum_G5_Type.DienThoai || chkDieuLai.Checked)
                    {
                        // Xu Ly luong du lieu
                        if (chkCuocDieuApp.Checked && chkCuocDieuApp.Enabled)
                            cuocGoi.G5_Type = Enum_G5_Type.DieuApp;
                        else
                        {
                            cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                        }
                        //LogError.WriteLogInfoCuocGoi(cuocGoi.IDCuocGoi,string.Format( "Input_GetCuocGoi_2:{0}_{1}_{2}_{3}", cuocGoi.Vung, cuocGoi.G5_Type, cbkDieuLai.Checked, cbkCuocDieuApp.Checked));
                    }

                    //LogError.WriteLogInfo(string.Format("{0}-{1}", cuocGoi.IDCuocGoi, "Log5"));
                    if (editVung.Text.Trim() != "")
                    {
                        cuocGoi.Vung = Convert.ToByte(editVung.Text);
                    }
                    cuocGoi.SoLanGoi = 0;

                    if (chkSanBay.Checked || chkXeHD.Checked || Config_Common.DTV_ThoiGianHen)
                    {
                        g_CuocGoi.ThoiGianHen = (DateTime)dtpGioDon.GetValue();
                    }
                    else
                    {
                        g_CuocGoi.ThoiGianHen = cuocGoi.ThoiDiemGoi;
                    }
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || Global.IsDieuSanBay || chkXeHD.Checked)
                    {
                        cuocGoi.XeNhan = g_XeNhan;
                        cuocGoi.XeDon = g_XeDon;
                        cuocGoi.XeDenDiem = g_XeDenDiem;
                        if (cuocGoi.XeDon.Length > 0)
                        {
                            if (g_XeDonLength == cuocGoi.SoLuong)
                            {
                                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            }
                        }

                        if (chkKhongXe.Checked)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            cuocGoi.XeNhan = "";
                            cuocGoi.XeDenDiem = "";
                            cuocGoi.XeDon = "";
                        }
                        else if (chkHoanG5.Checked)
                        {
                            if (g_CuocDaDieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.ChuyenSangDam)
                            {
                                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                IsChangeXeDon = true;
                                cuocGoi.XeDon = "";
                            }
                        }
                        else if (chkTruotG5.Checked)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            IsChangeXeDon = true;
                            cuocGoi.XeDon = "";
                        }
                    }
                    else if (pG5KetThuc.Visible)
                    {
                        if (chkHoanG5.Checked)
                        {                            
                            if (g_CuocDaDieuApp && g_CuocGoi.G5_Type != Enum_G5_Type.ChuyenSangDam)
                            {
                                cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                IsChangeXeDon = true;
                                cuocGoi.XeDon = "";
                            }
                        }
                        else if (chkTruotG5.Checked)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            IsChangeXeDon = true;
                            cuocGoi.XeDon = "";
                        }
                        else if (chkNhamKHG5.Checked && !chkDieuLai.Checked)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot; //TrangThaiCuocGoiTaxi.NhamKhach;
                            cuocGoi.XeDon = "";
                            IsChangeXeDon = true;
                            if (!cbkChuyenSangDam.Checked)
                                cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        }

                        //LogError.WriteLogInfo(string.Format("{0}-{1}", cuocGoi.IDCuocGoi, "Log10"));
                    }

                }

                #endregion

                #region Gọi lại

                else if (chkGoiLai.Checked)
                {
                    cuocGoi.SoLuong = string.IsNullOrEmpty(editSoLuongXe.Text) ? 0 : Convert.ToByte(editSoLuongXe.Text);
                    cuocGoi.Vung = string.IsNullOrEmpty(editVung.Text) ? 0 : Convert.ToByte(editVung.Text);
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiLai;
                    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    //Nếu là mô hình tổng đài mini hoặc cuốc điều app có xe nhận thì kết thúc
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong || g_CuocGoiLaiAppLaiXe)
                    {
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    }
                    if (pG5KetThuc.Visible)
                    {
                        if (chkHoanG5.Checked && chkHoanG5.Visible)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            cuocGoi.XeDon = "";
                        }
                        else if (chkTruotG5.Checked)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            cuocGoi.XeDon = "";
                        }
                    }
                }

                #endregion

                #region Gọi KN, DV,HDam,Khac
                
                else if (chkGoiKhieuNai.Checked)
                {
                    // cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhieuNai;
                    cuocGoi.Vung = Convert.ToByte(editVung.Text);
                }
                else if (chkGoiDichVu.Checked)
                {
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;//*sign
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiDichVu;
                    //cuocGoi.Vung = Convert.ToByte(editVung.Text);
                }
                else if (chkGoiHoiDam.Checked)
                {
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiHoiDam;
                    cuocGoi.Vung = Convert.ToByte(editVung.Text);
                    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || Config_Common.App_DieuXeHopDong)
                    {
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                    }
                }
                else if (chkGoiKhac.Checked)
                {
                    cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                }

                #endregion

                #region Đã giải quyết
                
                if (chkDaGiaiQuyet.Checked)
                {
                    if (cuocGoi.FT_IsFT)
                    {
                        cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        LogError.WriteLogInfoCuocGoi(cuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_3"));
                    }
                    if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai || cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiDichVu)
                    {
                        cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                        LogError.WriteLogInfoCuocGoi(cuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_4"));
                    }
                    else
                    {
                        if (cuocGoi.XeNhan == "" || chkGoiLai.Checked)
                        {
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;

                            LogError.WriteLogInfoCuocGoi(cuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_5"));
                        }
                        else
                            lblThongBao.Text = "Chỉ được kết thúc cuộc gọi Khiếu nại/Dịch vụ";
                    }
                }
                #endregion

                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && g_GPS)
                {
                    if (G_MarkerA != null && G_MarkerA.Position != null)
                    {
                        cuocGoi.GPS_ViDo = G_MarkerA.Position.Lat;
                        cuocGoi.GPS_KinhDo = G_MarkerA.Position.Lng;
                    }
                    if (G_MarkerB != null && G_MarkerB.Position != null)
                    {
                        cuocGoi.GPS_ViDo_Tra = G_MarkerB.Position.Lat;
                        cuocGoi.GPS_KinhDo_Tra = G_MarkerB.Position.Lng;
                    }
                    cuocGoi.DanhSachXeDeCu = g_DSXeDeCu;
                    cuocGoi.DanhSachXeDeCu_TD = g_DSXeDeCu_TD;
                }
                else
                {
                    cuocGoi.GPS_ViDo = 0;
                    cuocGoi.GPS_KinhDo = 0;
                    cuocGoi.GPS_ViDo_Tra = 0;
                    cuocGoi.GPS_KinhDo_Tra = 0;
                    cuocGoi.DanhSachXeDeCu = "";
                    cuocGoi.DanhSachXeDeCu_TD = "";
                } 
                cuocGoi.CoGPS = g_GPS;
                if (IsChangeDiaChiTraKhach && Config_Common.DTV_Address_UPPER)
                    cuocGoi.DiaChiTraKhach = txtDiaChiTra.Text.ToUpper().Trim();
                else
                {
                    cuocGoi.DiaChiTraKhach = txtDiaChiTra.Text.Trim();
                }
                cuocGoi.G5_CarType = string.Empty;

                //Đã xin lỗi khách và kết thúc luôn
                //if (cuocGoi.LenhDienThoai == LENH_DAXINLOI)//CommonBL.GetNameByCode(CommandCode.DaXinLoi, 1))//LENH_DAXINLOI
                //{
                //    cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                //    //LogError.WriteLogInfoCuocGoi(cuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_6"));
                //}

                #region Loại xe
                string tenLoaiXe = "";
                if (CommonBL.IsStaxiLoaiXe)
                {
                    cuocGoi.G5_CarType = GetG5LoaiXe(ref tenLoaiXe);
                }
                else
                {
                    //GetG5_LoaiXe
                    if (chkSanBay.Checked && chkSanBay.Visible)
                    {
                        if (chk4Cho.Checked)
                        {
                            tenLoaiXe = "4 Chỗ";
                            cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString();
                        }
                        if (chk7Cho.Checked)
                        {

                            if (string.IsNullOrEmpty(cuocGoi.G5_CarType))
                            {
                                tenLoaiXe = "7 Chỗ";
                                cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                            }
                            else
                            {
                                tenLoaiXe = "4 Chỗ,7 Chỗ";
                                cuocGoi.G5_CarType += "," + ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                            }
                        }
                    }
                    else if (chkXeHD.Checked)
                    {
                        if (chk4Cho.Checked)
                        {
                            tenLoaiXe = "4 Chỗ";
                            cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe4ChoHopDong).ToString();
                        }
                        if (chk7Cho.Checked)
                        {

                            if (string.IsNullOrEmpty(cuocGoi.G5_CarType))
                            {
                                tenLoaiXe = "7 Chỗ";
                                cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString();
                            }
                            else
                            {
                                tenLoaiXe = "4 Chỗ,7 Chỗ";
                                cuocGoi.G5_CarType += "," + ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString();
                            }
                        }
                    }
                    else
                    {
                        if (chk4Cho.Checked)
                        {
                            tenLoaiXe = "4 Chỗ";
                            cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe4Cho).ToString();
                        }
                        if (chk7Cho.Checked)
                        {
                            if (string.IsNullOrEmpty(cuocGoi.G5_CarType))
                            {
                                tenLoaiXe = "7 Chỗ";
                                cuocGoi.G5_CarType = ((int)Enum_G5_CarType.Xe7Cho).ToString();
                            }
                            else
                            {
                                tenLoaiXe = "4 Chỗ,7 Chỗ";
                                cuocGoi.G5_CarType += "," + ((int)Enum_G5_CarType.Xe7Cho).ToString();
                            }
                        }
                    }
                    tenLoaiXe = string.Format("{0}({1})", tenLoaiXe, txtLoaiXe.Text);
                }
                cuocGoi.LoaiXe = tenLoaiXe;

                #endregion

                cuocGoi.ShowPhoneAppDriver = chkShowPhoneAppDriver.Checked;
                if (chkShowPhoneAppDriver.Checked && !cuocGoi.LenhDienThoai.Contains(CommandCode.LENH_SHOWPHONENUMBER))
                {
                    cuocGoi.LenhDienThoai += CommandCode.LENH_SHOWPHONENUMBER;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetThongTinNhanMoi:", ex);
            }
        }

        private string GetThongTinLoaiXeChon_FastTaxi()
        {
            string loaiXe = ipLoaiXe.EditValue.ToString();
            return loaiXe;
        }

        //private string GetThongTinLoaiXeChon_FastTaxi()
        //{
        //    string loaiXe = string.Empty;
        //    if (chk4Cho.Checked && !txtLoaiXe.Text.Contains("4"))
        //    {
        //        loaiXe = "4,";
        //    }
        //    if (chk7Cho.Checked && !txtLoaiXe.Text.Contains("7"))
        //    {
        //        loaiXe += "7 ";
        //    }
        //    loaiXe += "," + txtLoaiXe.Text.Trim();
        //    return string.Join(",", loaiXe.Split(',').Select(pi => pi.Trim()).Where(p => !string.IsNullOrEmpty(p)).Distinct());
        //}

        /// <summary>
        /// Function get kenh vung theo dia chi (toa do)
        /// </summary>
        private int getKenhByDiaChi(float LatDes, float LngDes)
        {
            if (RealTimeEnvironment.VungToaDo != null)
            {
                foreach (var item in RealTimeEnvironment.VungToaDo)
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
            
            editGhiChu.Text = editGhiChu.Text.Trim();
            TaxiEventArgs myEventArgs = new TaxiEventArgs();
            myEventArgs.VungCurrent = g_CuocGoi.Vung;

            #region Cuốc Online App KH đang đặt - Cuốc vãng lai ko xe nhận
            if (g_CuocGoi.G5_Type == Enum_G5_Type.CuocAppKH || (g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai && g_CuocGoi.XeNhan != ""))//Cuốc online đặt từ AppKH
            {
                if (chkGuiLenhLenLaiXe.Checked && chkGuiLenhLenLaiXe.Visible)
                {
                    try
                    {
                        //Lấy danh sach xe nhận(Biển số xe) điều app từ cuốc trước
                        string TextCommand = editGhiChu.Text;//CommonBL.GetNameByCode(CommandCode.GiucXe,1);//"Giục xe"
                        int cmdId = Config_Common.CmdIdGiucXe;
                        string xeGui = (string.IsNullOrEmpty(g_CuocGoi.XeNhan) && thongTinGoiLai != null) ? thongTinGoiLai.XeNhan : g_CuocGoi.XeNhan;
                        string BookId = ((g_CuocGoi.BookId == Guid.Empty) && thongTinGoiLai != null) ? thongTinGoiLai.BookId : g_CuocGoi.BookId.ToString();
                        if (!string.IsNullOrEmpty(editGhiChu.Text) && editGhiChu.Text.ToUpper() != TextCommand.ToUpper())
                        {
                            //Nếu khác lệnh giục xe thì chuyển sang gửi text
                            cmdId = Config_Common.CmdIdGhiChu;
                        }
                        if (g_CuocGoiLai)
                        {
                            string rs = new MessageBox.MessageBoxBA().Show(string.Format("Gửi lệnh \"{0}\". kết thúc cuốc?", TextCommand), "Bạn có muốn gửi lệnh cho lái xe?",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rs == "" || rs.ToLower() == "no".ToLower())
                            {
                                g_CloseForm = false;
                                return;
                            }
                        }
                        g_CuocGoi.GhiChuDienThoai = editGhiChu.Text.Trim();
                        //LogError.WriteLogInfo("SendText:Giục xe GL");
                        G5ServiceSyn.SendText(xeGui, TextCommand, new Guid(BookId), g_CuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, cmdId);
                        //LogError.WriteLogInfoCuocGoi(g_CuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_10"));
                        CuocGoi.G5_DIENTHOAI_UpdateGhiChuDTV_ByBookId(g_CuocGoi.IDCuocGoi, g_CuocGoi.BookId, g_CuocGoi.GhiChuDienThoai);
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("GuiLenhLenhLaiXe:", ex);
                    }
                }
                //Neu la cuoc online tu app kh thi ko luu du lieu. chi cho gui ghi chu xuong cho lai xe
                g_DialogResult = false;
                this.Visible = false;
                Hide();
                OKCloseFormEvent(this, myEventArgs);
            }
            #endregion

            else
            {
                BangMaValidate maValidate = ValidateFormNhap(g_CuocGoi);
                HienThiThongBao(maValidate);
                if (maValidate == BangMaValidate.ValidateSuccess)
                {
                    if (chkGoiTaxi.Checked && chkDieuLai.Checked)
                    {
                        StaxiBook objBook = StaxiBook.GetByBookID(g_CuocGoi.BookId);
                        if (objBook != null && objBook.BookId != Guid.Empty)
                        {
                            lblThongBao.Text = string.Format("KH đã đặt lại và có xe {0} nhận đón, bạn không được điều lại nữa", objBook.XeNhan);
                            return;
                        }
                        else
                        {
                            g_CuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe;
                            g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                        }
                    }

                    #region Khi trượt hoặc quá 5 phút thì sẽ thực hiện cho phép chuyển sang đàm.

                    if (cbkChuyenSangDam.Visible && cbkChuyenSangDam.Checked && g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        //StaxiBook objBook = StaxiBook.GetByBookID(g_CuocGoi.BookId);
                        //if (objBook != null && objBook.BookId != Guid.Empty)
                        //{
                        //    lblThongBao.Text = string.Format("KH đã đặt lại và có xe {0} nhận đón, bạn không được điều đàm nữa", objBook.XeNhan);
                        //    return;
                        //}
                        //else
                        {
                            g_CuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                            //Khi Sang đàm thì sẽ làm sạch lệnh điện thoại.
                            //g_CuocGoi.LenhDienThoai = "app chuyển đàm";
                            g_CuocGoi.XeNhan = "";
                            g_CuocGoi.XeDenDiem = "";
                            g_CuocGoi.XeDon = "";
                            GetCheckChange.XeNhan = IsChangeXeNhan;
                        }
                    }
                    #endregion

                    #region Cảnh báo "Bạn phải xác định tọa độ" : Config_Common.DienThoai_RequiredGPS
                    if (Config_Common.DienThoai_RequiredGPS && chkGoiTaxi.Checked)
                    {
                        if (G_MarkerA == null || G_MarkerA.Position.Lat == 0)
                        {
                            lblThongBao.Text = "Bạn phải xác định tọa độ.";
                            return;
                        }
                    }
                    #endregion

                    #region Check trùng địa chỉ với những cuốc đang điều : Config_Common.DienThoai_CanhBaoTrungDiaChi
                    //check trùng địa chỉ, truyền ID, địa chỉ so sánh trong stored
                    if (Config_Common.DienThoai_CanhBaoTrungDiaChi)
                    {
                        if (chkGoiTaxi.Checked && g_CuocGoi.KieuKhachHangGoiDen != KieuKhachHangGoiDen.KhachHangMoiGioi && g_CuocGoi.Vung == 0)
                        {
                            string soDienThoai = "";
                            if (CuocGoi.G5_DIENTHOAI_CheckTrungDiaChiDon(g_CuocGoi.IDCuocGoi, txtDiaChiDonKhach.Text.Trim(), ref soDienThoai))
                            {
                                string rs = new MessageBox.MessageBoxBA().Show(string.Format("Địa chỉ đón khách trùng với cuốc có SĐT:{0}.\nBạn có muốn tiếp tục không?", soDienThoai), "Thông báo",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rs == "" || rs.ToLower() == "No".ToLower())
                                {
                                    g_CloseForm = false;
                                    return;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Trượt cuốc

                    if (chkTruotG5.Checked && g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                    {
                        if ((!string.IsNullOrEmpty(g_CuocGoi.XeDungDiem) 
                            ||(!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && Config_Common.DienThoai_DieuApp_TruotKhiCoXeNhan) 
                            ||Config_Common.DienThoai_DieuApp_Truot == 0 
                            ||((GetTimeServer() - (g_CuocGoi.G5_SendDate ?? g_CuocGoi.ThoiDiemGoi)).TotalMinutes > Config_Common.DienThoai_DieuApp_Truot)))
                        {
                            if (g_CuocGoi.G5_StepLast == Enum_G5_Step.SourceCancel_Customer
                            || (g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && g_CuocGoi.G5_StepLast == Enum_G5_Step.DriverCancel))
                            {
                                G5ServiceSyn.SendOperatorDispatched(g_CuocGoi.BookId, "", g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                            }
                            else
                                G5ServiceSyn.SendOperatorCancel(g_CuocGoi.BookId, g_CuocGoi.LoaiCuocKhach, "Trượt hoãn");
                        }
                        else
                        {
                            g_CloseForm = false;
                            lblThongBao.Text = "[Lệnh Trượt] là cuốc gọi điều App và lái xe báo trượt";
                            return;
                        }
                    }
                    #endregion

                    #region Khi Điều app hiện lên thì kiểm tra tọa độ.

                    if (chkCuocDieuApp.Checked && chkCuocDieuApp.Enabled && chkCuocDieuApp.Visible && chkGoiTaxi.Checked)
                    {
                        if (Config_Common.CoCheDieuApp == EnumCoCheDieuApp.DieuChiDinhGPS && QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                        {
                            //if (string.IsNullOrEmpty(txtXeNhan.Text))
                            //{
                            //    lblThongBao.Text = "[Điều app] Vui lòng nhập xe nhận";
                            //    txtXeNhan.Focus();
                            //    g_CloseForm = false;
                            //    return;
                            //}
                            if (Config_Common.DTV_APP_NOT_LOCATION && (G_MarkerA == null || G_MarkerA.Position.Lat == 0))
                            {
                                g_GPS = true;
                                G_MarkerA = MainMap.AddMarkerA(new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo), txtDiaChiDonKhach.Text.Trim(), true, true, 0, true);
                            }
                        }
                        else
                        {
                            if (G_MarkerA == null || G_MarkerA.Position.Lat == 0)
                            {
                                string rs = new MessageBox.MessageBoxBA().Show(
                                     "Cuốc điều app, bạn phải xác định tọa độ.", "Thông báo",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //if (rs == "" || rs.ToLower() == "Cancel".ToLower() || rs.ToLower() == "Cancel".ToLower())
                                {
                                    g_CloseForm = false;
                                    return;
                                }
                                //else if (rs.ToLower() == "Yes".ToLower())
                                //{
                                //    btnGPS.PerformClick();
                                //    g_CloseForm = false;
                                //    return;
                                //}
                                //if (!string.IsNullOrEmpty(CuocThuKhongDon))
                                //{
                                //    txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                                //}
                            }
                        }

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(CuocThuKhongDon) && chkCuocDieuApp.Checked && chkCuocDieuApp.Enabled)
                        {
                            txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                            txtDiaChiDonKhach.Text = CuocThuKhongDon.ToUpper() + " " + txtDiaChiDonKhach.Text.ToUpper().Trim();
                            if (Config_Common.DTV_Address_UPPER)
                            {
                                txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper();
                            }
                        }
                    }
                    #endregion

                    if (g_CuocGoiLai)
                    {
                        //Nếu cuộc gọi lại và yêu cầu gọi thêm xe==>Thành cuốc gọi mới.
                        if (chkGoiTaxi.Checked && chkGoiTaxi.Visible)
                        {
                            g_CuocGoi.BookId = Guid.Empty;
                            g_CuocGoi.XeNhan = string.Empty;
                        }
                    }

                    #region Hoãn cuốc
                    //Gọi lại hoãn cuốc : Hoãn cuốc cũ và kết thúc cuốc hiện tại.              
                    if (g_CuocGoi.BookId != null
                        && g_CuocGoi.BookId != Guid.Empty
                        && ((chkHoanG5.Checked && chkHoanG5.Visible))
                        && (CuocCoXeNhan || g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp || g_CuocGoi.LenhLaiXe == "Chờ LX nhận cuốc")
                        && g_CuocGoi.G5_Type != Enum_G5_Type.ChuyenSangDam)//&& (g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp || g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp))
                    {                        
                        if (g_CuocGoi.G5_StepLast == Enum_G5_Step.SourceCancel_Customer
                            || (g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && g_CuocGoi.G5_StepLast == Enum_G5_Step.DriverCancel))
                        {
                            G5ServiceSyn.SendOperatorDispatched(g_CuocGoi.BookId, "", g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                        }
                        else
                        {
                            G5ServiceSyn.SendOperatorCancel(g_CuocGoi.BookId, g_CuocGoi.LoaiCuocKhach, "Hoãn cuốc");
                        }
                    }
                    #endregion

                    #region Gọi lại - Gửi lệnh giục xe

                    //Nếu cuộc gọi lại và gửi lệnh giục xe lái xe.
                    if (chkGuiLenhLenLaiXe.Checked && chkGuiLenhLenLaiXe.Visible)
                    {
                        try
                        {
                            //Lấy danh sach xe nhận(Biển số xe) điều app từ cuốc trước
                            string TextCommand = "Giục xe";
                            int cmdId = Config_Common.CmdIdGiucXe;
                            string xeGui = (string.IsNullOrEmpty(g_CuocGoi.XeNhan) && thongTinGoiLai != null) ? thongTinGoiLai.XeNhan : g_CuocGoi.XeNhan;
                            string BookId = ((g_CuocGoi.BookId == null || g_CuocGoi.BookId == Guid.Empty) && thongTinGoiLai != null) ? thongTinGoiLai.BookId : g_CuocGoi.BookId.ToString();
                            if (!string.IsNullOrEmpty(editGhiChu.Text) && editGhiChu.Text.ToUpper() != TextCommand.ToUpper())
                            {
                                //Nếu khách lệnh giục xe thì chuyển sang gửi text
                                cmdId = Config_Common.CmdIdGhiChu;
                                TextCommand = editGhiChu.Text;
                                //LogError.WriteLogInfoCuocGoi(g_CuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_8"));
                            }
                            if (g_CuocGoiLai)
                            {
                                string rs = new MessageBox.MessageBoxBA().Show(string.Format("Gửi lệnh \"{0}\". kết thúc cuốc?", TextCommand), "Bạn có muốn gửi lệnh cho lái xe?",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (rs == "" || rs.ToLower() == "no".ToLower())
                                {
                                    g_CloseForm = false;
                                    return;
                                }
                                //LogError.WriteLogInfoCuocGoi(g_CuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_9"));
                            }
                            //LogError.WriteLogInfo("SendText:Giục xe GL");
                            G5ServiceSyn.SendText(xeGui, TextCommand, new Guid(BookId), g_CuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong, cmdId);
                            //LogError.WriteLogInfoCuocGoi(g_CuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_10"));
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("GuiLenhLenhLaiXe:", ex);
                        }
                    }

                    #endregion

                    #region ===Nhầm Khách ==
                    if (g_CuocGoi.BookId != null && chkNhamKHG5.Checked && chkNhamKHG5.Visible && (g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp || g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp))
                    {
                        G5ServiceSyn.SendOperatorCancel(g_CuocGoi.BookId, g_CuocGoi.LoaiCuocKhach, CommandCode.LENH_NhamKH, SourceCancelType.Mistake);
                        //LogError.WriteLogInfoCuocGoi(g_CuocGoi.IDCuocGoi, string.Format("Input_GetCuocGoi_11"));
                    }
                    #endregion

                    g_CloseForm = true;                    
                    //*sign ghi lịch sử sửa địa chỉ đón khách!
                    string strAddressOld = g_CuocGoi.DiaChiDonKhach;
                    GetThongTinNhapMoi(ref g_CuocGoi);                    
                    if (chkDieuLai.Visible && chkDieuLai.Checked)
                    {
                        GetCheckChange.DiaChiDon = false;
                        GetCheckChange.DiaChiTra = false;
                    }
                    else
                    {
                        GetCheckChange.DiaChiDon = !IsChangeDiaChiDonKhach;
                        GetCheckChange.DiaChiTra = !IsChangeDiaChiTraKhach;
                    }

                    GetCheckChange.XeNhan = !IsChangeXeNhan;
                    GetCheckChange.XeDon = !IsChangeXeDon;
                    
                    #region Cuốc điều app nhưng khách lên nhầm xe của hãng

                    if (g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                    {
                        if (!string.IsNullOrEmpty(g_CuocGoi.XeDon) && g_CuocGoi.XeDon != g_CuocGoi.XeNhan)
                        {
                            G5ServiceSyn.SendWrongCustomer(g_CuocGoi.BookId, g_CuocGoi.XeDon, g_CuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong);
                        }
                    }
                    #endregion

                    #region Lưu lại lịch sử sửa địa chỉ cuốc
                    if (strAddressOld.ToLower() != g_CuocGoi.DiaChiDonKhach.ToLower()
                        && g_CuocGoi.MaDoiTac.Length > 0)
                    {
                        SaveAddressTrace(g_CuocGoi, strAddressOld);
                    }
                    #endregion

                    g_DialogResult = true;
                    this.Visible = false;
                    Hide();
                    OKCloseFormEvent(this, myEventArgs);
                }
                else
                {
                    g_CloseForm = false;
                }
            }
        }

        private void SaveAddressTrace(CuocGoi pCuocGoi, string pAddressOld)
        {
            AddressTraceEntity objTrace= new AddressTraceEntity();
            objTrace.ID = pCuocGoi.IDCuocGoi;
            objTrace.PhoneNumber = pCuocGoi.PhoneNumber;
            objTrace.ThoiDiemGoi = pCuocGoi.ThoiDiemGoi;
            objTrace.DiaChiDonKhachCu = pAddressOld;
            objTrace.DiaChiDonKhachMoi = pCuocGoi.DiaChiDonKhach;
            objTrace.KieuKhachHangGoiDen = ((int)pCuocGoi.KieuKhachHangGoiDen).ToString();
            objTrace.XeDon = pCuocGoi.XeDon;
            objTrace.GhiChuDienThoai = pCuocGoi.GhiChuDienThoai;
            objTrace.GhiChuTongDai = pCuocGoi.GhiChuTongDai;
            objTrace.KieuCuocGoi = (int)pCuocGoi.KieuCuocGoi;
            objTrace.MaDoiTac = pCuocGoi.MaDoiTac;
            objTrace.GhiChuLaiXe = pCuocGoi.GhiChuLaiXe;
            objTrace.BookId = pCuocGoi.BookId;
            objTrace.G5_Type = (int)pCuocGoi.G5_Type;
            objTrace.UpdatedTime = CommonBL.GetTimeServer();
            objTrace.UpdatedBy = ThongTinDangNhap.USER_ID;
            try
            {
                objTrace.Insert();
            }
            catch(Exception ex)
            {                
                LogError.WriteLogError("Lỗi lưu lịch sử sửa địa chỉ cuốc -> SaveAddressTrace", ex);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_CloseForm = true;
            g_DialogResult = false;
            this.Visible = false;
            Hide();
        }

        private void btnRemoveGPS_Click(object sender, EventArgs e)
        {
            lblThongBao.Text = string.Empty;
            //if (g_CGLimit == false)
            //{

            g_GPS = false;
            MainMap.ClearAllMarkers();
            MainMap.MarkerA = null;
            MainMap.MarkerB = null;
            G_MarkerA = null;
            G_MarkerB = null;
            g_DSXeDeCu = "";
            g_DSXeDeCu_TD = "";
            //}
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
                //if (g_CGLimit) return;

                if (ThongTinCauHinh.GPS_TrangThai == true)
                {
                    if (MainMap.OverlayXeDeCu != null && MainMap.OverlayXeDeCu.Markers != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();

                    string strDiaChi = StringTools.TrimSpace(txtDiaChiDonKhach.Text);
                    string strDiaChi_Tra = StringTools.TrimSpace(txtDiaChiTra.Text);
                    //Kinh độ và vĩ độ đã gán sẵn theo địa chỉ
                    if (IsChangeDiaChiDonKhach)
                    {
                        G_ViDo = txtDiaChiDonKhach.ViDo;
                        G_KinhDo = txtDiaChiDonKhach.KinhDo;
                    } 
                    if (IsChangeDiaChiTraKhach)
                    {
                        G_ViDo_Tra = txtDiaChiTra.ViDo;
                        G_KinhDo_Tra = txtDiaChiTra.KinhDo;
                    }
                    string diaChiGPS = GetDiaChiChuan(strDiaChi);
                    string diaChiGPS_Tra = GetDiaChiChuan(strDiaChi_Tra);

                    if (G_ViDo == 0 && G_KinhDo == 0)
                    {
                        if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && G_MarkerA != null && G_MarkerA.Position.Lat > 0)
                        {
                            G_ViDo = G_MarkerA.Position.Lat;
                            G_KinhDo = G_MarkerA.Position.Lng;
                        }
                        else
                        {
                            string toaDo = Service_Common.GetGeobyAddress(diaChiGPS, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo = Double.Parse(arrString[0], CultureInfo.InvariantCulture);
                                G_KinhDo = Double.Parse(arrString[1], CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                        }
                    }
                    if (G_ViDo_Tra == 0 && G_KinhDo_Tra == 0 && !txtDiaChiTra.Text.Trim().Equals(""))
                    {
                        if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && G_MarkerB != null)
                        {
                            G_ViDo_Tra = G_MarkerB.Position.Lat;
                            G_KinhDo_Tra = G_MarkerB.Position.Lng;
                        }
                        else
                        {
                            string toaDo = Service_Common.GetGeobyAddress(diaChiGPS_Tra, ThongTinCauHinh.GPS_TenTinh).Replace(',', '.');
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo_Tra = Double.Parse(arrString[0], CultureInfo.InvariantCulture);
                                G_KinhDo_Tra = Double.Parse(arrString[1], CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO + "_1";
                            }
                        }
                    }
                    if (Config_Common.DTV_Address_UPPER)
                    {
                        txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper();
                        txtDiaChiTra.Text = txtDiaChiTra.Text.ToUpper();
                    }
                    else
                    {
                        txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text;
                        txtDiaChiTra.Text = txtDiaChiTra.Text;
                    }
                    txtDiaChi_GPS.Text = diaChiGPS;
                    if (G_KinhDo == 0 && G_ViDo == 0)
                    {
                        g_GPS = false;
                        lblThongBao.Text = MSG_6_BANDO + "_2";
                        return;
                    }
                    else
                    {
                        g_GPS = true;
                        G_MarkerA = MainMap.AddMarkerA(new PointLatLng(G_ViDo, G_KinhDo), diaChiGPS, true, true, 0, true);
                        if (G_ViDo_Tra > 0 && G_KinhDo_Tra > 0)
                            G_MarkerB = MainMap.AddMarkerB(new PointLatLng(G_ViDo_Tra, G_KinhDo_Tra), diaChiGPS_Tra, false, true, 0, false);

                        //Nhập Kênh tự động theo địa chỉ vùng
                        SetKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);
                        if (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam || g_CuocGoi.G5_Type == Enum_G5_Type.DienThoai)
                        {
                            getXeByToaDo(G_KinhDo, G_ViDo);
                        }
                    }
                }

                if (Config_Common.DTV_ALTZ_FOCUSADDRESS > 0)
                {
                    txtDiaChiDonKhach.Focus();
                    txtDiaChiDonKhach.SelectText_Length(Config_Common.DTV_ALTZ_FOCUSADDRESS);
                }
                else editVung.Select();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetGPS", ex);
                lblThongBao.Text = MSG_10_BANDO;
                g_GPS = false;
            }
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiTaxi();
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiLai();
            if (chkGoiLai.Checked)
            {
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
                //Nếu là cuốc gọi lại của có xe nhận từ app lái xe thì hiển thị lệnh gửi lên lái xe
                if (g_CuocGoiLaiAppLaiXe)
                {
                    if (editGhiChu.Text.Trim() != "")
                        editGhiChu.Text = CommandCode.LENH_G_GIUCXE;
                    chkGuiLenhLenLaiXe.Visible = true;
                    if (string.IsNullOrEmpty(editGhiChu.Text.Trim()))
                        chkGuiLenhLenLaiXe.Checked = true;
                    //pG5KetThuc.Visible = QuanTriCauHinh.MoHinh == MoHinh.TD_DT;
                    chkDaGiaiQuyet.Checked = true;
                    chkHoanG5.Visible = true;
                    pG5KetThuc.Visible = true;
                }
                IsTextChangeLenh = true;
                if (string.IsNullOrEmpty(editLenhDienThoai.Text))
                    editLenhDienThoai.Text = "gọi lại";
                IsTextChangeLenh = false;
            }
            else
            {
                if (g_CuocGoiLaiAppLaiXe)
                {
                    // cbkCuocDieuApp.Enabled = true;
                    editGhiChu.Text = "";
                    //pG5KetThuc.Visible = false;
                    chkHoanG5.Checked = false;
                }
                editLenhDienThoai.Text = "";
                chkGuiLenhLenLaiXe.Visible = false;
                chkGuiLenhLenLaiXe.Checked = false;
            }
        }

        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhieuNai();
            if (chkGoiKhieuNai.Checked)
            {
                editVung.Text = "11";
            }
            else
            {
                editVung.Text = "";
            }
        }

        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiDichVu();
            editVung.Text = "";
        }

        private void chkGoiHoiDam_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiHoiDam();
            if (chkGoiHoiDam.Checked)
            {
                editLenhDienThoai.Text = "hỏi đàm";
                editVung.Focus();
            }
            else
            {
                editLenhDienThoai.Text = "";
            }
        }

        private bool _changeLenhDienThoai = false;
        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            HienThiControl_GoiKhac();
            editVung.Text = "";
        }
        
        private void Process_Command_KeyDown(KeyEventArgs e)
        {
            int keyInput = (int)e.KeyData;
            bool isCommand = false; //biến check xem có phải command đã cấu hình ko
            if (editLenhDienThoai.Text.Length == 1)
            {
                IsTextChangeLenh = true;
                int[] StatusCommand_Num = { 3, 4 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe)
                List<TaxiOperationCommand> lstCommand = CommonBL.Commands.FindAll(a => a.FunctionUsing == (int)Enum_ChucNangNhiemVu.DienThoaiVien && a.CommandCode != Enum_CommandCode.System);
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
                        bool isApp = ((g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp
                                       || g_CuocGoi.G5_Type == Enum_G5_Type.CuocAppKH
                                       || g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai
                                       || g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp)
                           && g_CuocGoi.BookId != Guid.Empty
                           && g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                           );

                        bool isCuocKhongXe = (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi
                                    && (g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam)
                                    && (g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe
                                            || g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1
                                            || g_CuocGoi.LenhLaiXe == CommandCode.PMDH_CONST_Msg_NoCarAccept
                                            || Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc == 1)
                                    && (g_CuocGoi.XeNhan == null || g_CuocGoi.XeNhan.Length <= 0));

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
                            && (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi)))
                        {
                            lblThongBao.Text = string.Format("Phải chưa có xe nhận mới được thực hiện lệnh [{0}]", command.Command);
                            return;
                        }

                        if ((command.Status != null && StatusCommand_Num.Contains(command.Status.Value))
                            //Trường hợp đặc biệt, có cấu hình kết thúc không xe ở ĐTV
                        || (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi
                            && Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc == 1
                            && (g_CuocGoi.XeNhan == null || g_CuocGoi.XeNhan.Length <= 0)
                            )
                        //Trường hợp Hủy Hoãn
                        || (isApp && (command.CommandCode == Enum_CommandCode.DTV_HuyHoan || command.CommandCode == Enum_CommandCode.DTV_TruotChua))
                            //Trường hợp không xe xin lỗi khách
                        || (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi && isCuocKhongXe)
                        )
                        {
                            string dialog = msgDialog.Show(
                                string.Format("[{0}] Kết thúc địa chỉ {1} ?", commandText.ToUpper(), g_CuocGoi.DiaChiDonKhach), "LỆNH KẾT THÚC CUỐC",
                                MessageBoxButtonsBA.YesNo, MessageBoxIconBA.Question);
                            if (dialog.ToUpper() == "no".ToUpper())
                            {
                                return;
                            }
                            else
                            {
                                g_CuocGoi.TrangThaiLenh = (TrangThaiLenhTaxi)command.Status;
                                if (command.CommandCode == Enum_CommandCode.DTV_HuyHoan)
                                {
                                    g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                    g_CuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                                }
                                else if (command.CommandCode == Enum_CommandCode.DTV_TruotChua)
                                {
                                    g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                    g_CuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                                }
                                else if (command.CommandCode == Enum_CommandCode.DTV_DaXinLoi)
                                {
                                    g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                    g_CuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                                }
                            }
                        }
                        if (command.CommandCode == Enum_CommandCode.DTV_HuyHoan)
                        {
                            chkGuiLenhLenLaiXe.Checked = false;
                            if (pG5KetThuc.Visible)
                                chkHoanG5.Checked = true;
                        }
                        int[] CallStatusNum = { 1, 2, 3, 4, 6 };//Chỉ gán lại trạng thái cuộc gọi nếu là các trạng thái kết thúc (đón được, trượt, hoãn, không xe, Không xe lần 1)
                        if (command.CallStatus != null && CallStatusNum.Contains(command.CallStatus.Value))
                        {
                            //Cuộc gọi không xe thì ĐTV có thể kết thúc cuộc gọi.
                            if (g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                            {
                                g_CuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            }
                            //Lấy theo cấu hình lệnh
                            else
                            {
                                if (g_CuocGoi.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiHoan
                                || g_CuocGoi.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiTruot
                                || g_CuocGoi.TrangThaiCuocGoi != TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                                {
                                    g_CuocGoi.TrangThaiCuocGoi = (TrangThaiCuocGoiTaxi)command.CallStatus;
                                }
                            }
                        }

                        editLenhDienThoai.Text = commandText;
                        break;
                    }
                }
            }
            IsTextChangeLenh = false;
        }

        private bool IsTextChangeLenh = false;
        private void editLenhDienThoai_TextChanged(object sender, EventArgs e)
        {
            //if (editLenhDienThoai.SelectionStart > 3)
            //    return;
            //if (IsTextChangeLenh || IsLoading) return;
            //IsTextChangeLenh = true;
            ////chkHoan.Checked = false;
            //_changeLenhDienThoai = true;
            //chkHoanG5.Checked = false;
            //_changeLenhDienThoai = false;
            
            ////*command
            //if (editLenhDienThoai.Text.StartsWith("1") )
            //{
            //    if (g_CuocGoi.LenhTongDai == CommonBL.GetNameByCode(CommandCode.MoiKhach, 2))
            //    {
            //        editLenhDienThoai.Text = CommonBL.GetNameByKey((int)Keys.D1, 1);//Lệnh đã mời.
            //    }
            //    else
            //    {
            //        new MessageBox.MessageBoxBA().Show("Không được nhập lệnh đã mời khách khi chưa mời khách!");
            //    }
            //}
            //else if (editLenhDienThoai.Text.StartsWith("2"))
            //{
            //    if (string.IsNullOrEmpty(g_CuocGoi.XeNhan))
            //    {
            //        new MessageBox.MessageBoxBA().Show("Không được nhập lệnh gặp xe khi chưa có xe nhận!");
            //    }
            //    else
            //    {
            //        //editLenhDienThoai.Text = LENH_GAPXE;
            //        editLenhDienThoai.Text = CommonBL.GetNameByKey((int)Keys.D2, 1);
            //    }
            //}
            //else if (editLenhDienThoai.Text.StartsWith("3"))
            //{
            //    if (g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe
            //        || g_CuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1
            //        || Config_Common.DienThoai_ChoPhepKetThucKhongXeTruoc == 1)
            //    {
            //        //editLenhDienThoai.Text = LENH_DAXINLOI;
            //        editLenhDienThoai.Text = CommonBL.GetNameByKey((int)Keys.D3, 1);    
            //    }
            //    else
            //    {
            //        new MessageBox.MessageBoxBA().Show("Không được nhập lệnh đã xin lỗi khi chưa có lệnh không xe xin lỗi khách!");
            //    }                
            //}
            //else if (editLenhDienThoai.Text.StartsWith("4"))
            //{
            //    //editLenhDienThoai.Text = LENH_MAYBAN;
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.D4, 1);
            //}
            //else if (editLenhDienThoai.Text.StartsWith("5"))
            //{
            //    if (g_CuocGoi.XeNhan.Length > 0)
            //    {
            //        //editLenhDienThoai.Text = LENH_KHONGLIENLACDUOC;
            //        editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.D5, 1);
            //    }
            //    else
            //    {
            //        new MessageBox.MessageBoxBA().Show("Không được nhập lệnh từ chối khi chưa có xe nhận!");
            //    }
            //}
            //else if (editLenhDienThoai.Text.StartsWith("6"))
            //{
            //    //editLenhDienThoai.Text = LENH_KHONGNGHEMAY;
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.D6, 1);
            //}
            //else if (editLenhDienThoai.Text.StartsWith("7"))
            //{
            //    //editLenhDienThoai.Text = LENH_KHONGNOIGI;
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.D7, 1);
            //}
            //else if (editLenhDienThoai.Text.StartsWith("8"))
            //{
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int)Keys.D8,1);
            //    chkGuiLenhLenLaiXe.Checked = false;
            //    if (pG5KetThuc.Visible)
            //        chkHoanG5.Checked = true;
            //    //else chkHoan.Checked = true;
            //}
            //else if (editLenhDienThoai.Text.StartsWith("9"))
            //{
            //    //editLenhDienThoai.Text = LENH_GIUROI;
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.D9, 1);
            //}
            //else if (editLenhDienThoai.Text.StartsWith("G") || editLenhDienThoai.Text.StartsWith("g"))
            //{
            //    //editLenhDienThoai.Text = LENH_G_GIUCXE;
            //    editLenhDienThoai.Text = CommonBL.GetNameByKey((int) Keys.G, 1);
            //}

            //if (editLenhDienThoai.Text.StartsWith("KD") || editLenhDienThoai.Text.StartsWith("kd"))
            //{
            //    //editLenhDienThoai.Text = LENH_KHACHDAT;
            //    editLenhDienThoai.Text = LENH_KHACHDAT; //CommonBL.GetNameByCode(CommandCode.KhachDat, 1);
            //}
            //if (editLenhDienThoai.Text.StartsWith("TC") || editLenhDienThoai.Text.StartsWith("tc"))
            //{
            //    editLenhDienThoai.Text = LENH_TRUOTCHUA; //CommonBL.GetNameByCode(CommandCode.TruotChua, 1);                
            //}
            //if (editLenhDienThoai.Text.StartsWith("KTX") || editLenhDienThoai.Text.StartsWith("ktx"))
            //{
            //    editLenhDienThoai.Text = LENH_KOTHAYXE; //CommonBL.GetNameByCode(CommandCode.KhongThayXe, 1);
            //}
            //IsTextChangeLenh = false;
        }
        private void DatHen()
        {
            if (g_CuocGoi != null && g_CuocGoi.FT_IsFT) return;
            int soLuongXe ;
            int vungKenh ;
            int.TryParse(editSoLuongXe.Text.Trim(), out soLuongXe);
            int.TryParse(editVung.Text.Trim(), out vungKenh);
            var c = this.GetCuocGoi;
            KhachDatBL objKhachDat = new KhachDatBL
            {
                CreatedBy = ThongTinDangNhap.USER_ID,
                DiaChi = txtDiaChiDonKhach.Text.Trim(),
                SoDienThoai = g_CuocGoi.PhoneNumber,
                SoLuongXe = soLuongXe,
                ThoiDiemBatDau = c.FT_Date ?? DateTime.Now,
                ThoiDiemKetThuc = c.FT_Date ?? DateTime.Now,
                LoaiXe = GetThongTinLoaiXeChon_FastTaxi(),
                TenLoaiXe = g_CuocGoi.LoaiXe,
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
                editLenhDienThoai.Text = CommandCode.LENH_KHACHDAT;
                editVung.Text = vungKenh.ToString();
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
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked) editGhiChu.Focus();
                else
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
                return true;
            }
            if (keyData == Keys.Escape)
            {
                g_CloseForm = true;                
                g_DialogResult = false;
                this.Visible = false;
                Hide();                
                return true;
            }
            else if (keyData == Keys.F3)
            {
                DatHen();
                return true;
            }
            else if (keyData == Keys.F2)
            {
                uiTab1.SelectedTab = uiTabPage1;
                txtDiaChiDonKhach.Focus();
                return true;
            }
            else if (keyData == Keys.F4)
            {
                uiTab1.SelectedTab = uiTabPage2;
                txtDiaChi_Search.Select();
                return true;
            }
            else if (keyData == Keys.F5 && chkDieuLai.Visible)
            {
                chkDieuLai.Focus();
                chkDieuLai.Checked = !chkDieuLai.Checked;
                return true;
            }
            //else if (keyData == Keys.F6 && chkNhamKHG5.Visible)
            //{
            //    chkNhamKHG5.Focus();
            //    chkNhamKHG5.Checked = !chkNhamKHG5.Checked;
            //    return true;
            //}
            else if (keyData == (Keys.Control | Keys.F))
            {
                txtDiaChi_GPS.Focus();                
                return true;
            }
            else if (keyData == (Keys.Control | Keys.R))
            {
                picG5_MouseClick(null, null);
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
                        editVung.Text = Config_Common.VungMacDinh;
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
            else if (keyData == (Keys.Control | Keys.Y))
            {
                if (cbkChuyenSangDam.Visible)
                    cbkChuyenSangDam.Checked = true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                if (uiTab1.SelectedTab == uiTabPage2)
                {
                    txtDiaChi_Search.Focus();
                    return true;
                }
                else
                {
                    if (pG5KetThuc.Visible && cbkChuyenSangDam.Visible)
                    {
                        cbkChuyenSangDam.Checked = !cbkChuyenSangDam.Checked;
                    }
                    else if (chkGoiDichVu.Enabled && chkGoiDichVu.Visible)
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
            }
            else if (keyData == (Keys.Alt | Keys.F))
            {
                uiTab1.SelectedTab = tabDSLaiXe;
                ucDSLaiXe1.Focus();
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
                if (uiTab1.SelectedTab == uiTabPage2)
                {
                    txtSoDT_Search.Focus();
                    return true;
                }
                else
                {
                    editSoLuongXe.Focus();
                    editSoLuongXe.SelectAll();
                    return true;
                }
            }
            else if (keyData == (Keys.Alt | Keys.V))
            {
                editVung.Focus();
                editVung.SelectAll();
                //btnGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.B) && btnRemoveGPS.Enabled && btnRemoveGPS.Visible)
            {
                btnRemoveGPS_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                //if (pnlTongDai.Visible)
                //{
                //    chkTruot.Checked = chkTruot.Checked != true;
                //}
                //else
                {
                    if (pG5KetThuc.Visible && chkTruotG5.Visible && chkTruotG5.Enabled)
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
                //if (pnlTongDai.Visible)
                //{
                //    if (chkHoan.Checked == true)
                //        chkHoan.Checked = false;
                //    else
                //        chkHoan.Checked = true;
                //}
                //else
                {
                    if (pG5KetThuc.Visible && chkHoanG5.Visible && chkHoanG5.Enabled)
                    {
                        chkHoanG5.Checked = !chkHoanG5.Checked;
                    }
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.U))
            {
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked)
                    editGhiChu.Focus();
                return true;
            }

            else if (keyData == (Keys.Alt | Keys.P) && btnGPS.Enabled && btnGPS.Visible)
            {
                btnGPS.PerformClick();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || chkXeHD.Checked)
                {
                    txtXeNhan.Focus();
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                }
                else
                {
                    ucDSLaiXe1_EventCallOut(g_CuocGoi.PhoneNumber, g_CuocGoi.DiaChiDonKhach);
                }
                //if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                //{
                //    txtXeDenDiem.Focus();
                //    txtXeDenDiem.SelectionStart = txtXeDenDiem.Text.Length;
                //}
                //if (chkCipucha.Checked == true)
                //    chkCipucha.Checked = false;
                //else
                //    chkCipucha.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {

                if (chkMGDuongDai.Enabled)
                {
                    if (chkMGDuongDai.Checked)
                        chkMGDuongDai.Checked = false;
                    else chkMGDuongDai.Checked = true;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini || chkXeHD.Checked)
                {
                    txtXeDon.Focus();
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Z))
            {
                //if (QuanTriCauHinh.MoHinh == MoHinh.TongDaiMini)
                //{
                //    txtXeNhan.Focus();
                //    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
                //}
                //else
                {
                    if (chkCuocDieuApp.Enabled && chkCuocDieuApp.Visible)
                    {
                        chkCuocDieuApp.Focus();
                        chkCuocDieuApp.Checked = !chkCuocDieuApp.Checked;
                    }
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Q))
            {
                if (chkDaGiaiQuyet.Visible && chkDaGiaiQuyet.Enabled)
                {
                    chkDaGiaiQuyet.Checked = !chkDaGiaiQuyet.Checked;
                }
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
                    if ((txtDiaChiDonKhach.IsFocused && txtDiaChiDonKhach.IsPopup) || (txtDiaChiTra.IsFocused && txtDiaChiTra.IsPopup))
                    {
                        return true;
                    }
                    //Đang focused TextDiaChi và thay đổi địa chỉ thì sẽ nhập tìm kiếm
                    if (txtDiaChi_GPS.IsFocused && CheckTextChangeDiaChi > 0)
                    {                        
                        CheckTextChangeDiaChi--;
                        string diaChi = GetDiaChiChuan(txtDiaChi_GPS.Text);
                        if (!string.IsNullOrEmpty(diaChi))
                        {
                            lblThongBao.Text = "";
                            string toaDo = Service_Common.GetGeobyAddress(diaChi, ThongTinCauHinh.GPS_TenTinh);
                            if (toaDo != "*" && toaDo != string.Empty)
                            {
                                string[] arrString = toaDo.Split(' ');
                                G_ViDo = Convert.ToDouble(arrString[0], Global.CultureSystem);
                                G_KinhDo = Convert.ToDouble(arrString[1], Global.CultureSystem);
                            }
                            else
                            {
                                lblThongBao.Text = MSG_6_BANDO;
                            }
                            if (G_KinhDo != 0 && G_ViDo != 0)
                            {
                                G_MarkerA = MainMap.AddMarkerA(new PointLatLng(G_ViDo, G_KinhDo), diaChi, true, true, 0, true);
                                g_GPS = true;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        btnOK.PerformClick();
                        //if (DialogResult == DialogResult.Cancel) return true;
                        if (!g_DialogResult) return true;

                        if (!g_CloseForm) return true;
                        //DialogResult = DialogResult.OK;
                        g_DialogResult = true;
                        //Close();
                        return true;
                    }
                }

            }
            else if (keyData == Keys.F1)
            {
                if (g_IsNew)
                {
                    OnHienThiCuocMoiEvent(new EventArgs());
                }
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
            else if (keyData == (Keys.Alt | Keys.D3))
            {
                ipLoaiXe.Focus();
                return true;
            }

            else if (keyData == (Keys.Alt | Keys.D1))
            {
                if (gvHistory.RowCount > 0)
                {
                    GetHistory(0);
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D2))
            {
                if (gvHistory.RowCount > 1)
                {
                    GetHistory(1);
                }
                return true;
            }
            //else if (keyData == (Keys.Alt | Keys.D3))
            //{
            //    if (gvHistory.RowCount > 2)
            //    {
            //        GetHistory(2);
            //    }
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.D4))
            //{
            //    if (gvHistory.RowCount > 3)
            //    {
            //        GetHistory(3);
            //    }
            //    return true;
            //}
            //else if (keyData == (Keys.Alt | Keys.D5))
            //{
            //    if (gvHistory.RowCount > 4)
            //    {
            //        GetHistory(4);
            //    }
            //    return true;
            //}
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
                if (chkGuiLenhLenLaiXe.Enabled && chkGuiLenhLenLaiXe.Visible)
                {
                    if (chkGuiLenhLenLaiXe.Checked)
                        chkGuiLenhLenLaiXe.Checked = false;
                    else
                    {
                        chkGuiLenhLenLaiXe.Checked = true;
                        editGhiChu.Focus();
                    }
                }
                return true;
            }
            else if (keyData == (Keys.F8))
            {
                chkShowPhoneAppDriver.Checked = !chkShowPhoneAppDriver.Checked;
                return true;
            }
            else if (keyData == (Keys.F9))
            {
                new TimKiemCuocGoi(DieuHanhTaxi.GetTimeServer(), "", 1, g_LoaiXeMacDinh).Show();
                return true;
            }
            else if (keyData == (Keys.F12))
            {
                if (string.IsNullOrEmpty(g_CuocGoi.XeNhan))
                {

                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Phải là cuộc gọi mới(Chưa được chuyển sang tổng đài và chưa có thông tin xe nhận-đón)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.Y))
            {
                if (chkSanBay.Enabled && chkSanBay.Visible)
                {
                    chkSanBay.Checked = !chkSanBay.Checked;

                }
                return true;
            }
            else if (keyData == Keys.F6)
            {
                if (chkXeHD.Enabled && chkXeHD.Visible && Config_Common.App_DieuXeHopDong)
                {
                    chkXeHD.Checked = !chkXeHD.Checked;
                }
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
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked)
                    editLenhDienThoai.Focus();
                else
                    txtXeNhan.SelectionStart = txtXeNhan.Text.Length;
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
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked)
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
            else
            {
                //Process_Command_KeyDown(e);
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
                if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini || !chkXeHD.Checked)
                    editGhiChu.Focus();
                else
                    txtXeDon.SelectionStart = txtXeDon.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnCancel.Focus();
            }
        }

        private void btnDatHen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //if (QuanTriCauHinh.MoHinh != MoHinh.TongDaiMini)
                //    editGhiChu.Focus();
                //else
                //    txtXeDon.SelectionStart = txtXeDon.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }
        
        private void btnGPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnCancel.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnRemoveGPS.Focus();
            }
        }
        private void btnRemoveGPS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnGPS.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                //btnRemoveGPS.Focus();
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

        private string g_DSXeDeCu;
        private string g_DSXeDeCu_TD;
        // layers
        private GMapOverlay top;
        private GMapOverlay OverlayXeDeCu;
        private GMapMarker G_MarkerA;
        private GMapMarker G_MarkerB;
        bool isMouseDown;

        private void ConfigMap()
        {
            try
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
                if (Config_Common.MAP_Provider == 0)
                    CbMapType.SelectedIndex = 0;
                else
                    CbMapType.SelectedIndex = 1;
                // config gmaps
                MainMap.CacheLocation = Application.StartupPath + "\\Map";
                //MainMap.CacheLocation = System.Configuration.ConfigurationManager.AppSettings["MapPath"]; 
                MainMap.Manager.Mode = AccessMode.ServerAndCache;
                MainMap.MaxZoom = 19;
                MainMap.MinZoom = 7;
                MainMap.Zoom = 17;
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

                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseUp += MainMap_MouseUp;
                MainMap.MouseDoubleClick += MainMap_MouseDoubleClick;
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;
                MainMap.OnMapTypeChanged += MainMap_OnMapTypeChanged;

                // get zoom  
                trackBarMap.Minimum = MainMap.MinZoom;
                trackBarMap.Maximum = MainMap.MaxZoom;
                trackBarMap.Value = Convert.ToInt32(MainMap.Zoom);

                // kiểm tra và thiết lặp vị trí mặc định của bản đồ
                if (ThongTinCauHinh.GPS_KinhDo > 0 && ThongTinCauHinh.GPS_ViDo > 0)
                    MainMap.Position = new PointLatLng(ThongTinCauHinh.GPS_ViDo, ThongTinCauHinh.GPS_KinhDo);
            }
            catch (Exception exx)
            {
                LogError.WriteLogError("frmDienThoaiInputDataNew_V3.ConfigMap", exx);
            }

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
                if (Config_Common.DTV_INPUT_FIX_POINT_MG && g_CuocGoi.MaDoiTac != null && g_CuocGoi.MaDoiTac != "" && g_CuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    return;
                }
                isMouseDown = false;
                if (MainMap.OverlayCustom == null)
                {
                    MainMap.OverlayCustom = new GMapOverlay();
                }

                if (MainMap.OverlayCustom.Markers.Count > 0)
                {
                    MainMap.OverlayCustom.Markers.Clear();
                }
                PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
                try
                {
                    string building = "";
                    string strDiaChi = Service_Common.GetAddressByGeo_BA_WithBuilding((float)point.Lat, (float)point.Lng, out building);
                    if (Config_Common.DTV_AddressByPinMap)
                    {
                        txtDiaChiDonKhach.Text = strDiaChi;
                        if (building != null)
                        {

                            int length = building.Length;
                            if (length >= 5) length = 0;
                            //Cursor.Position = txtLoaiXe.Location;
                            txtDiaChiDonKhach.Focus();                            
                            txtDiaChiDonKhach.SelectText_Length(length);
                        }
                    }
                    G_MarkerA = MainMap.AddMarkerA(point, strDiaChi, true, true, 0, true);
                    G_KinhDo = point.Lng;
                    G_ViDo = point.Lat;
                    g_GPS = true;
                }
                catch (Exception ex)
                {
                    G_MarkerA = null;
                    G_KinhDo = 0;
                    G_ViDo = 0;
                    g_GPS = false;
                    new MessageBox.MessageBoxBA().Show("Không lấy được vị trí trên bản đồ");
                    LogError.WriteLogError("MainMap_MouseDown:", ex);
                }
            }
        }

        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isMouseDown = true;                
            }
        }

        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isMouseDown && !Config_Common.DTV_INPUT_FIX_POINT_MG)
            {
                if (Config_Common.DTV_INPUT_FIX_POINT_MG && g_CuocGoi.MaDoiTac != null && g_CuocGoi.MaDoiTac != "" && g_CuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    return;
                }
                if (MainMap.OverlayCustom != null && MainMap.OverlayCustom.Markers.Count > 0 && G_MarkerA.IsVisible)
                {
                    G_MarkerA.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                    string strDiaChi = Service_Common.GetAddressByGeoBA((float)G_MarkerA.Position.Lat, (float)G_MarkerA.Position.Lng);
                    G_MarkerA.ToolTipText = strDiaChi;
                    if (MainMap.OverlayXeDeCu != null)
                        MainMap.OverlayXeDeCu.Markers.Clear();
                }
            }
            MainMap.Refresh(); // force instant invalidation
        }

        #endregion=============================================================

        private int G_BanKinhTimXe = 0;

        /// <summary>
        /// Lấy danh sách xe đề cử
        /// </summary>
        /// <param name="kinhDo"></param>
        /// <param name="viDo"></param>
        private void getXeByToaDo(double kinhDo, double viDo)
        {
            try
            {
                if (!Config_Common.GPS_GetXeOnline) return;
                string loaiXeGPS = "";
                string loaiXe = GetThongTinLoaiXeChon_GetXeDeCu();
                int SoXeTraVe = 4 + Convert.ToInt16(editSoLuongXe.Text);

                if (string.IsNullOrEmpty(loaiXe)) // neu ko co chon loai xe thi tat ca loai xe           
                    loaiXeGPS = new Business.DM.Xe().LayDanhSachLoaiXe_GPS("0,4,7");
                else
                    loaiXeGPS = new Business.DM.Xe().LayDanhSachLoaiXe_GPS(loaiXe);

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
                        catch (Exception ex)
                        {
                            LogError.WriteLogError(ex.Message, ex);
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
                        catch (Exception ex)
                        {
                            LogError.WriteLogError(ex.Message, ex);
                        }
                        if (soLan <= 0) ngung = true;

                    } while (!ngung);

                }
                setResult(dsXeDeCu.Trim());
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("getXeByToaDo", ex);
            }
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
                    g_DSXeDeCu = dsXeDeCu.Substring(0, dsXeDeCu.Length - 1);
                    g_DSXeDeCu_TD = result;
                }
            }
            catch
            {
                g_DSXeDeCu = "";
                g_DSXeDeCu_TD = "";
            }
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
            catch 
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
            catch 
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
        private void chkVung1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung2_Search.Focus();
            else if (e.KeyCode == Keys.Up)
                txtDiaChi_Search.Focus();
        }
        private void chkVung3_Search_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung4_Search_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung2_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung3_Search.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung1_Search.Focus();
        }

        private void chkVung3_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung4_Search.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung2_Search.Focus();
        }
        private void Search()
        {
            string soDt = txtSoDT_Search.Text.Trim();
            string diaChi = txtDiaChi_Search.Text.Trim();
            string kenh = "";

            if (chkVung1_Search.Checked) kenh = "1;";
            if (chkVung2_Search.Checked) kenh = kenh + "2;";
            if (chkVung3_Search.Checked) kenh = kenh + "3;";
            if (chkVung4_Search.Checked) kenh = kenh + "4;";
            List<CuocGoi> lstCuocGoi = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet_TC(kenh, soDt, diaChi);
            grcAll.DataSource = null;
            grcAll.DataSource = lstCuocGoi;
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
                chkTruotG5.Focus();
            }
        }

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            //chkTruot.Checked = false;
            //chkHoan.Checked = false;
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
                btnDatHen.Focus();
            }
        }

        private void shGridControl1_Resize(object sender, EventArgs e)
        {
            grcolDiaChiDon.Width = gridHistory.Width - grcolGhiChuDTV.Width - grcolGhiChuTDV.Width - grcolThoiGianGoi.Width - grcolXeDon.Width - grcolXeNhan.Width;
            if (grcolDiaChiDon.Width < 190) grcolDiaChiDon.Width = 190;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkTruotG5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTruotG5.Checked)
            {
                chkHoanG5.Checked = false;
                chkNhamKHG5.Checked = false;
                cbkChuyenSangDam.Checked = false;
                chkGuiLenhLenLaiXe.Checked = false;
                editLenhDienThoai.Text = CommandCode.LENH_TRUOTCHUA;
                chkDieuLai.Checked = false;
            }
            else
            {
                editLenhDienThoai.Text = "";
            }
        }

        private void chkHoanG5_CheckedChanged(object sender, EventArgs e)
        {
            if(_changeLenhDienThoai)
                return;
            IsTextChangeLenh = true;
            if (chkHoanG5.Checked)
            {
                chkTruotG5.Checked = false;
                chkNhamKHG5.Checked = false;
                chkGuiLenhLenLaiXe.Checked = false;

                chkDieuLai.Checked = false;
                chkDieuLai.Visible = false;

                cbkChuyenSangDam.Checked = false;
                cbkChuyenSangDam.Visible = false;

                editLenhDienThoai.Text = CommandCode.LENH_HUYXE;
                if ((g_CuocGoi.G5_Type == Enum_G5_Type.CuocKhongXeApp && g_CuocGoi.FT_IsFT)|| (g_CuocGoi.G5_Type == Enum_G5_Type.CuocVangLai && g_CuocGoi.XeNhan == ""))
                {
                    chkDaGiaiQuyet.Checked = true;
                }
            }
            else
            {
                chkDieuLai.Visible = g_HasDieuLai;//g_CuocGoi.G5_Type != Enum_G5_Type.ChuyenSangDam &&
                                    //(!g_HasAppKHNhamKhach || g_HasAppNhamKhach);
                cbkChuyenSangDam.Visible = g_HasChuyenDam;
                chkDaGiaiQuyet.Checked = false;
                editLenhDienThoai.Text = "";
            }
            IsTextChangeLenh = false;
        }

        private void ShowDieuApp(bool isDieuApp, bool IsGPS = true)
        {
            try
            {
                //txt.Visible = isDieuApp;
                if (isDieuApp)
                {
                    chkShowPhoneAppDriver.Visible = (g_CuocGoi.G5_StepLast == Enum_G5_Step.None || chkDieuLai.Checked) && chkCuocDieuApp.Enabled && chkCuocDieuApp.Checked && Config_Common.AppLX_CMDID_ShowPhoneNumber > 0;
                    chkGoiKhac.Enabled = false;
                    chkSanBay.Visible = false;
                    if (chkXeHD.Checked)
                    {
                        chkMGDuongDai.Visible = false;
                    }
                    //cbkSanBay.Checked = false;
                    //editLenhDienThoai.Enabled = false;
                    //picG5.Visible = true;
                    if (g_CuocGoi.Vung > 0 && !chkDieuLai.Checked)
                    {
                        this.Text = TxtTitleCapNhat;
                        btnOK.Text = TxtCapNhat;
                        if (g_CuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai && chkCuocDieuApp.Checked)
                        {
                            btnOK.Text = TxtDieuApp;                            
                        }
                    }
                    else
                    {
                        this.Text = TxtTitleDieuApp;
                        btnOK.Text = TxtDieuApp;
                    }
                    chkGoiLai.Enabled = false;
                    chkGoiKhieuNai.Enabled = false;
                    chkGoiDichVu.Enabled = false;
                    chkGoiHoiDam.Enabled = false;
                    chkDaGiaiQuyet.Enabled = false;
                    if (chk4Cho.Checked && chk7Cho.Checked && chkCuocDieuApp.Checked)//Có điều app nhưng check cả 4 chỗ và 7 chỗ
                    {
                        chk4Cho.Checked = false;
                        chk7Cho.Checked = false;
                        //if (!IsLoading)
                        //    new MessageBox.MessageBox().Show("Chưa chọn loại xe");
                    }
                    if (chkCuocDieuApp.Enabled && IsGPS)
                        btnGPS.PerformClick();
                }
                else
                {
                    chkShowPhoneAppDriver.Visible = false;
                    chkGoiKhac.Enabled = true;
                    if ((g_CuocGoi.G5_Type != Enum_G5_Type.CuocAppKH && g_CuocGoi.G5_Type != Enum_G5_Type.CuocVangLai
                        && chkCuocDieuApp.Enabled && chkCuocDieuApp.Visible) || g_CuocGoi.G5_SendDate == null)
                        chkSanBay.Visible = true;
                    //picG5.Visible = false;
                    this.Text = "Điện thoại viên (Enter : Cập nhật, ESC : Đóng )";
                    btnOK.Text = "Cập nhật";
                    
                    chkGoiLai.Enabled = true;
                    chkGoiKhieuNai.Enabled = true;
                    chkGoiDichVu.Enabled = true;
                    chkGoiHoiDam.Enabled = true;
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
                picAirPlane.Visible = true;
                lblCoCuocGoiMoi.Text = "SÂN BAY";
                lblCoCuocGoiMoi.Visible = true;
                //dtpGioDon.Enabled = true;
                chkCuocDieuApp.Enabled = false;
                chkCuocDieuApp.Checked = false;
                chkMGDuongDai.Checked = false;
            }
            else
            {
                //cbkCuocDieuApp.Enabled = true;
                picAirPlane.Visible = false;
                lblCoCuocGoiMoi.Text = "CÓ CUỘC GỌI MỚI (F1 : CHUYỂN)";
                lblCoCuocGoiMoi.Visible = g_IsNew;
                //dtpGioDon.Enabled = false;
                chkCuocDieuApp.Enabled = true;
            }
            if (ipLoaiXeChange) return;
            ipLoaiXeChange = true;
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }

        private void chkCuocDieuApp_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CuocThuKhongDon))
            {
                if (Config_Common.DTV_Address_UPPER)
                {
                    if (chkCuocDieuApp.Checked)
                    {
                        txtDiaChiDonKhach.Text = CuocThuKhongDon.ToUpper() + " " + txtDiaChiDonKhach.Text.ToUpper().Trim();
                    }
                    else
                    {
                        txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.ToUpper().Replace(CuocThuKhongDon.ToUpper(), "").Trim();
                    }
                }
                else
                {
                    if (chkCuocDieuApp.Checked)
                    {
                        txtDiaChiDonKhach.Text = CuocThuKhongDon + " " + txtDiaChiDonKhach.Text.Trim();
                    }
                    else
                    {
                        txtDiaChiDonKhach.Text = txtDiaChiDonKhach.Text.Replace(CuocThuKhongDon, "").Trim();
                    }
                }
            }

            ShowDieuApp(chkCuocDieuApp.Checked);
        }

        private void chkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            ShowCuocSanBay(chkSanBay.Checked);
        }

        private void chkMGDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMGDuongDai.Checked)
            {
                chkSanBay.Checked = false;
                if (Config_Common.App_DieuXeHopDong)
                    chkXeHD.Checked = false;
                if (Config_Common.NhapTuyenDuongDai && !IsLoading)
                {
                    frmNhapTuyenDuongDai frmDuongDai = new frmNhapTuyenDuongDai();
                    frmDuongDai.LoaiXeID = ipLoaiXe.EditValue.ToString();
                    frmDuongDai.CuocGoi = g_CuocGoi;
                    frmDuongDai.ShowDialog();
                    if (!frmDuongDai.IsSuccess && g_CuocGoi.Long_TuyenID.Length<2)
                    {
                        chkMGDuongDai.Checked = false;
                    }
                    else
                    {
                        ipLoaiXe.EditValue = frmDuongDai.IDLoaiXeStaxi.ToString();
                        //string ghichuDuongDai = string.Format("{0}");
                    }
                }
            }
        }

        private void ResetLongValues()
        {
            if (Config_Common.NhapTuyenDuongDai && !IsLoading)
            {
                g_CuocGoi.Long_LoaiXeID = string.Empty;
                g_CuocGoi.Long_TuyenID = string.Empty;
                g_CuocGoi.Long_ChieuID = 0;
                g_CuocGoi.Long_GiaTien = 0;
                g_CuocGoi.Long_Km = 0;
                g_CuocGoi.Long_ThoiGian = 0;
            }
        }
        #endregion

        #region === Check So điện thoại có thể điều  app ===
        
        #endregion

        private void cbkChuyenSangDam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkChuyenSangDam.Checked)
            {
                chkTruotG5.Checked = false;
                chkHoanG5.Checked = false;
                chkHoanG5.Enabled = false;
                chkDieuLai.Checked = false;
                chkDieuLai.Visible = false;
                chkGuiLenhLenLaiXe.Checked = false; 
                if (editGhiChu.Text.Trim().Equals("Bạn gọi cho KH, Tiếp thị lại"))
                {
                    editGhiChu.Text = "";
                }
            }
            else
            {
                if (g_HasDieuLai)
                {
                    chkDieuLai.Visible = true;
                }
                if (g_HasHoanCuoc)
                {
                    chkHoanG5.Enabled = true;                    
                }
            }
        }
        private void frmDienThoaiInputDataNew_V3_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void chk4Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange || IsLoading) return;
            ipLoaiXeChange = true;
            if (chk4Cho.Checked)
            {
                if (chkCuocDieuApp.Checked)
                    chk7Cho.Checked = false;
            }
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }

        private void chkXeHD_CheckedChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange || !Config_Common.App_DieuXeHopDong || IsLoading) return;
            ipLoaiXeChange = true;
            if (chkXeHD.Checked)
            {
                chk7Cho.Checked = false;
                chk4Cho.Checked = false;
                if (!chkCuocDieuApp.Checked)
                    chkCuocDieuApp.Checked = true;
                //dtpGioDon.Enabled = true;
            }
            pnlTongDai.Visible = chkXeHD.Checked && Global.HasCarRole;
            //dtpGioDon.Enabled = chkXeHD.Checked;
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }

        private void chk7Cho_CheckedChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange || IsLoading) return;
            ipLoaiXeChange = true;
            if (chk7Cho.Checked)
            {
                if (chkCuocDieuApp.Checked)
                    chk4Cho.Checked = false;
            }
            RefreshLoaiXe();
            ipLoaiXeChange = false;
        }
        private string GetG5LoaiXe(ref string pTenLoaiXe)
        {
            if (CommonBL.ListStaxiLoaiXe.Count == 0)
            {
                string ipLoaiX = string.Empty;
                string idLoaiXe = "";
                if (chk4Cho.Checked)
                {
                    ipLoaiX = "4 Chỗ";
                    idLoaiXe = "7";
                }
                else if (chk7Cho.Checked)
                {
                    ipLoaiX = "7 Chỗ";
                    idLoaiXe = "10";
                }
                if (string.IsNullOrEmpty(txtLoaiXe.Text))
                    pTenLoaiXe = ipLoaiX;
                else
                    pTenLoaiXe = string.Format("{0}({1})", ipLoaiX, txtLoaiXe.Text);
                return idLoaiXe;
            }
            else
            {
                if (string.IsNullOrEmpty(txtLoaiXe.Text))
                    pTenLoaiXe = ipLoaiXe.Text;
                else
                {
                    if (chk7Cho.Checked && chk4Cho.Checked)
                        pTenLoaiXe = txtLoaiXe.Text;
                    else
                        pTenLoaiXe = ipLoaiXe.Text;
                }
                return ipLoaiXe.EditValue.To<string>();
            }
        }

        private string GetG5_LoaiXe(ref string pTenLoaiXe)
        {
            string idLoaiXe = "";
            if (chkSanBay.Checked && chkSanBay.Visible)
            {
                if (chk4Cho.Checked)
                {
                    pTenLoaiXe = "4 Chỗ";
                    idLoaiXe = ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString();
                }
                if (chk7Cho.Checked)
                {

                    if (string.IsNullOrEmpty(txtLoaiXe.Text))
                    {
                        pTenLoaiXe = "7 Chỗ";
                        idLoaiXe = ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                    }
                    else
                    {
                        pTenLoaiXe = "4 Chỗ,7 Chỗ";
                        idLoaiXe += "," + ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString();
                    }
                }
            }
            else if (chkXeHD.Checked)
            {
                if (chk4Cho.Checked)
                {
                    pTenLoaiXe = "4 Chỗ";
                    idLoaiXe = ((int)Enum_G5_CarType.Xe4ChoHopDong).ToString();
                }
                if (chk7Cho.Checked)
                {

                    if (string.IsNullOrEmpty(txtLoaiXe.Text))
                    {
                        pTenLoaiXe = "7 Chỗ";
                        idLoaiXe = ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString();
                    }
                    else
                    {
                        pTenLoaiXe = "4 Chỗ,7 Chỗ";
                        idLoaiXe += "," + ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString();
                    }
                }
            }
            else
            {
                if (chk4Cho.Checked)
                {
                    pTenLoaiXe = "4 Chỗ";
                    idLoaiXe = ((int)Enum_G5_CarType.Xe4Cho).ToString();
                }
                if (chk7Cho.Checked)
                {
                    if (string.IsNullOrEmpty(txtLoaiXe.Text))
                    {
                        pTenLoaiXe = "7 Chỗ";
                        idLoaiXe = ((int)Enum_G5_CarType.Xe7Cho).ToString();
                    }
                    else
                    {
                        pTenLoaiXe = "4 Chỗ,7 Chỗ";
                        idLoaiXe += "," + ((int)Enum_G5_CarType.Xe7Cho).ToString();
                    }
                }
            }
            pTenLoaiXe = string.Format("{0}({1})", pTenLoaiXe, txtLoaiXe.Text);
            return idLoaiXe;
        }

        private void SetG5LoaiXe(string G5LoaiXeId, string LoaiXe)
        {
            // dtpGioDon.SetValue(cuocGoi.ThoiDiemGoi);
            if ((g_CuocGoi.Vung == 0) && string.IsNullOrEmpty(LoaiXe))
            {
                if (Config_Common.DienThoai_ChonLoaiXe < 0)
                {
                    chk4Cho.Checked = false;
                    chk7Cho.Checked = false;
                    chkXeHD.Checked = false;

                    if (Config_Common.DienThoai_ChonLoaiXe == -1)
                    {
                        ipLoaiXeChange = true;
                        RefreshLoaiXe();
                        ipLoaiXeChange = false;
                    }
                }
                else if (Config_Common.DienThoai_ChonLoaiXe == 0)
                {
                    chk4Cho.Checked = true;
                    txtLoaiXe.Text = "4 Chỗ";
                    G5LoaiXeId = ((int)Enum_G5_CarType.Xe4Cho).ToString();
                    chk7Cho.Checked = false;
                    chkXeHD.Checked = false;
                }
                else if (Config_Common.DienThoai_ChonLoaiXe == 1)
                {
                    chk7Cho.Checked = true;
                    txtLoaiXe.Text = "7 Chỗ";
                    G5LoaiXeId = ((int)Enum_G5_CarType.Xe7Cho).ToString();
                    chk4Cho.Checked = false;
                    chkXeHD.Checked = false;
                }
                else if (Config_Common.DienThoai_ChonLoaiXe == 2 && Config_Common.App_DieuXeHopDong)
                {
                    chk7Cho.Checked = false;
                    chk4Cho.Checked = false;
                    chkXeHD.Checked = true;
                }
            }
            if (CommonBL.ListStaxiLoaiXe.Count == 0)
            {
                if (G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho).ToString() 
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho_Nho).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho_Rong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4ChoHopDong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString())
                {
                    chk4Cho.Checked = true;
                }
                else if (G5LoaiXeId == ((int)Enum_G5_CarType.Xe7Cho).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString())
                {
                    chk7Cho.Checked = true;
                }
            }
            else
            {
                ipLoaiXe.EditValue = G5LoaiXeId;
                ipLoaiXe.RefreshEditValue();
                if (G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho_Nho).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4Cho_Rong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4ChoHopDong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe4ChoSanBay).ToString())
                {
                    chk4Cho.Checked = true;
                }
                else if (G5LoaiXeId == ((int)Enum_G5_CarType.Xe7Cho).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe7ChoHopDong).ToString()
                    || G5LoaiXeId == ((int)Enum_G5_CarType.Xe7ChoSanBay).ToString())
                {
                    chk7Cho.Checked = true;
                }
            }

            int start = LoaiXe.IndexOf('(') + 1;
            int end = LoaiXe.IndexOf(')');
            if (!string.IsNullOrEmpty(LoaiXe) )
            {
                var loaixe = ipLoaiXe.EditValue.To<string>().Split(',').Select(p => p.Trim().To<int>()).ToList();
                var lx = (CommonBL.ListStaxiLoaiXe.FirstOrDefault(p => loaixe.Any(pi => p.StaxiType == pi)));
                if (lx != null && ipLoaiXe.EditValue != null && (string)ipLoaiXe.EditValue != "")
                {
                    if (lx.Seat == 4)
                    {
                        chk4Cho.Checked = true;
                    }
                    else if (lx.Seat == 7)
                    {
                        chk7Cho.Checked = true;
                    }
                    else if (lx.Seat == 0 && lx.OrderBy == 0)
                    {
                        chk7Cho.Checked = true;
                        chk4Cho.Checked = true;
                    }
                    ipLoaiXe.EditValue = G5LoaiXeId;

                }
                else
                {
                    if (LoaiXe.Contains("4c"))
                    {
                        chk4Cho.Checked = true;
                    }
                    if (LoaiXe.Contains("7c"))
                    {
                        chk7Cho.Checked = true;
                    }
                }
                if(start > 0 && end > 0 && end - start > 0)
                {
                    txtLoaiXe.Text = LoaiXe.Substring(start, end - start);
                }
                else 
                {
                    txtLoaiXe.Text = LoaiXe;
                }
            }
        }

        private bool ipLoaiXeChange = false;
        private void ipLoaiXe_EditValueChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange || (ipLoaiXe.IsPopupOpen && !ipLoaiXeChange) || (!ipLoaiXe.IsPopupOpen && ipLoaiXeChange) || IsLoading)
                return;
            ipLoaiXeChange = true;
            chk4Cho.Checked = false;
            chk7Cho.Checked = false;
            chkSanBay.Checked = false;
            if (Config_Common.App_DieuXeHopDong)
                chkXeHD.Checked = false;
            var loaixe = ipLoaiXe.EditValue.To<string>().Split(',').Select(p => p.Trim().To<int>()).ToList();
            var lx = (CommonBL.ListStaxiLoaiXe.FirstOrDefault(p => loaixe.Any(pi => p.StaxiType == pi)));
            if (lx != null && ipLoaiXe.EditValue != null && (string) ipLoaiXe.EditValue != "")
            {
                var lstCarType = CommonBL.ListStaxiLoaiXe;
                if (lx.Seat != 4 && lx.Seat != 7)
                {
                    ipLoaiXe.Properties.DataSource = lstCarType;
                }
                else
                {
                    lstCarType = CommonBL.ListStaxiLoaiXe.Where(p => p.Seat == lx.Seat).ToList();
                    if (!chkSanBay.Visible)
                    {
                        lstCarType = lstCarType.Where(p => p.Type != StaxiCarType_Type.AriPort).ToList();
                    }
                    if (!chkXeHD.Visible)
                    {
                        lstCarType = lstCarType.Where(p => p.Type != StaxiCarType_Type.Car).ToList();
                    }
                    ipLoaiXe.Properties.DataSource = lstCarType;
                    if (lx.Seat == 4)
                    {
                        chk4Cho.Checked = true;
                    }
                    else if (lx.Seat == 7)
                    {
                        chk7Cho.Checked = true;
                    }
                }
                if (lx.Type == StaxiCarType_Type.AriPort)
                {
                    chkSanBay.Checked = true;
                }
                else if (lx.Type == StaxiCarType_Type.Car && Config_Common.App_DieuXeHopDong)
                    chkXeHD.Checked = true;

                ipLoaiXe.EditValue = lx.StaxiType;
                ipLoaiXe.RefreshEditValue();
                ipLoaiXe.Refresh();
                ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
            }
            else
            {
                RefreshLoaiXe();
            }
            ipLoaiXeChange = false;
        }

        private void chk4Cho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtLoaiXe.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                chk7Cho.Focus();
            }
        }
        private void chk7Cho_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                chk4Cho.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                ipLoaiXe.Focus();
            }
        }

        private void chkXeHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                chkSanBay.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                chkDieuLai.Focus();
            }
        }

        private void RefreshLoaiXe()
        {
            ipLoaiXe.Enabled = true;
            var lstCarType = CommonBL.ListStaxiLoaiXe;
            if (chkSanBay.Checked)
            {
                lstCarType = lstCarType.Where(p => p.Type == StaxiCarType_Type.AriPort).ToList();
            }
            else if (chkXeHD.Checked)
            {
                lstCarType = lstCarType.Where(p => p.Type == StaxiCarType_Type.Car).ToList();
            }

            if (!chkSanBay.Visible)
            {
                lstCarType = lstCarType.Where(p => p.Type != StaxiCarType_Type.AriPort).ToList();
            }
            if (!Config_Common.App_DieuXeHopDong)
            {
                lstCarType = lstCarType.Where(p => p.Type != StaxiCarType_Type.Car).ToList();
            }

            if (!(chk4Cho.Checked && chk7Cho.Checked))
            {
                txtLoaiXe.Text = "";
                if (chk4Cho.Checked)
                    lstCarType = lstCarType.Where(p => p.Seat == 4).ToList();
                else if (chk7Cho.Checked)
                    lstCarType = lstCarType.Where(p => p.Seat == 7).ToList();
            }
            else if (txtLoaiXe.Text == "")
            {
                txtLoaiXe.Text = "4c, 7c";
                ipLoaiXe.Enabled = false;
            }
            ipLoaiXe.Properties.DataSource = lstCarType;
            ipLoaiXe.EditValue = null;
            ipLoaiXe.RefreshEditValue();
            ipLoaiXe.Refresh();
            if (ipLoaiXe.Properties.Items.Count > 0)
            {
                ipLoaiXe.Properties.Items[0].CheckState = CheckState.Checked;
                if (lstCarType.First().Type == StaxiCarType_Type.AriPort && !chkSanBay.Checked)
                {
                    chkSanBay.Checked = true;
                }
                if (lstCarType.First().Type == StaxiCarType_Type.Car && !chkXeHD.Checked)
                    chkXeHD.Checked = true;

            }
            ipLoaiXe.Properties.DropDownRows = ipLoaiXe.Properties.Items.Count > ipLoaiXe.RowCount ? ipLoaiXe.RowCount : ipLoaiXe.Properties.Items.Count;
        }
        private void ipLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (ipLoaiXe.IsPopupOpen) return;
            if (e.KeyCode == Keys.Left)
            {
                chk7Cho.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                editSoLuongXe.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                ipLoaiXe.ShowPopup();
            }
        }
        private void cbkDieuLai_CheckedChanged(object sender, EventArgs e)
        {
            if (ipLoaiXeChange) return;
            if (chkDieuLai.Checked)
            {
                //chkNhamKHG5.Checked = false;
                //chkNhamKHG5.Visible = false;
                cbkChuyenSangDam.Checked = false;
                cbkChuyenSangDam.Visible = false;
                chkTruotG5.Checked = false;
                chkTruotG5.Visible = false;
                chkHoanG5.Checked = false;
                chkHoanG5.Enabled = false;
                chkCuocDieuApp.Enabled = true;
                //tempGhiChu = editGhiChu.Text;
                //editGhiChu.Text = string.Empty;
                if (editGhiChu.Text.Trim().Equals("Bạn gọi cho KH, Tiếp thị lại"))
                {
                    editGhiChu.Text = "";   
                }
                if (Config_Common.DienThoai_DieuLai_TickDieuApp)
                {
                    chkCuocDieuApp.Checked = true;
                }
                if (chkCuocDieuApp.Checked)
                {
                    this.Text = TxtTitleDieuApp;
                    btnOK.Text = TxtDieuApp;
                }
                if (g_CuocGoi.ShowPhoneAppDriver)
                {
                    chkShowPhoneAppDriver.Checked = true;
                }
            }
            else
            {
                chkCuocDieuApp.Enabled = false;

                if (g_CuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                {
                    chkCuocDieuApp.Checked = true;
                }
                else
                {
                    chkCuocDieuApp.Checked = false;
                }

                this.Text = TxtTitleCapNhat;
                btnOK.Text = TxtCapNhat;
                
                cbkChuyenSangDam.Visible = g_HasChuyenDam;
                chkTruotG5.Visible = g_HasTruotCuoc;
                chkHoanG5.Enabled = g_HasHoanCuoc;

                //chkNhamKHG5.Visible = g_HasAppKHNhamKhach || g_HasAppNhamKhach || g_HasNhamKhach;
            }
        }
        private bool IsChangeDiaChiDonKhach = false;
        private bool IsChangeDiaChiTraKhach = false;
        private bool IsChangeXeNhan = false;
        private bool IsChangeXeDon = false;
        private void txtDiaChiDonKhach_TextChanged(object sender, EventArgs e)
        {
            if (txtDiaChiDonKhach.Text.Length == 0 || txtDiaChiDonKhach.Text == "")
            {
                IsChangeDiaChiDonKhach = false;
            }
            else
            {
                IsChangeDiaChiDonKhach = true;
            }
        }
        private void txtDiaChiTra_TextChanged(object sender, EventArgs e)
        {
            IsChangeDiaChiTraKhach = true;
        }
        private void txtXeNhan_TextChanged(object sender, EventArgs e)
        {
            IsChangeXeNhan = true;
        }

        private void txtXeDon_TextChanged(object sender, EventArgs e)
        {
            IsChangeXeDon = true;
        }
        private bool IsGhiChu = false;
        private void editGhiChu_TextChanged(object sender, EventArgs e)
        {
            if (IsGhiChu || IsLoading) return;
            IsGhiChu = true;
            //if (editGhiChu.Text.StartsWith("1") || editGhiChu.Text.ToUpper() == "Giục xe".ToUpper())
            //{
            //    editGhiChu.Text = "Giục xe";
            //    editGhiChu.SelectionStart = 0;
            //}
            //else if (editGhiChu.Text.StartsWith("2") || editGhiChu.Text.ToUpper() == "khách đang chờ xe".ToUpper())
            //{
            //    editGhiChu.Text = "khách đang chờ xe";
            //    editGhiChu.SelectionStart = 0;
            //}
            //else if (editGhiChu.Text.StartsWith("3") || editGhiChu.Text.ToUpper() == "Khách cần xe gấp".ToUpper())
            //{
            //    editGhiChu.Text = "Khách cần xe gấp";
            //    editGhiChu.SelectionStart = 0;
            //}
            //else if (editGhiChu.Text.StartsWith("4") || editGhiChu.Text.ToUpper() == "Đã giữ khách".ToUpper())
            //{
                
            //    editGhiChu.Text = "Đã giữ khách";
            //    editGhiChu.SelectionStart = 0;
            //}
            //else if (editGhiChu.Text.StartsWith("5") || editGhiChu.Text.ToUpper() == "Đã mời".ToUpper())
            //{
            //    editGhiChu.Text = "Đã mời";
            //    editGhiChu.SelectionStart = 0;
            //}
            if (!string.IsNullOrEmpty(g_CuocGoi.XeNhan) && editGhiChu.Text.Trim() != "")
            {
                chkGuiLenhLenLaiXe.Checked = true;
                chkGuiLenhLenLaiXe.Enabled = true;
            }
            else
            {
                chkGuiLenhLenLaiXe.Checked = false;
                chkGuiLenhLenLaiXe.Enabled = false;
            }
            IsGhiChu = false;
        }

        private void chkNhamKHG5_CheckedChanged(object sender, EventArgs e)
        {
            IsTextChangeLenh = true;
            if (chkNhamKHG5.Checked)
            {
                if (chkTruotG5.Checked)
                    chkTruotG5.Checked = false;
                if (chkHoanG5.Checked)
                    chkHoanG5.Checked = false;
                editLenhDienThoai.Text = CommandCode.LENH_NhamKH;
                chkDieuLai.Visible = !g_HasAppKHNhamKhach || g_HasAppNhamKhach;
            }
            else
            {
                //if (cbkDieuLaiEnabled)
                { 
                    chkDieuLai.Visible = cbkDieuLaiEnabled; 
                    chkDieuLai.Checked = false; 
                }
                editLenhDienThoai.Text = "";
            }
            IsTextChangeLenh = false;
        }

        private void ucDSLaiXe1_EventCallOut(string PhoneNumber, string DiaChi)
        {
            if (EventCallOut != null)
            {
                EventCallOut(PhoneNumber, DiaChi);
            }
        }
        private void grvAll_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (grvAll.RowCount > 0)
            //{
            //    CuocGoi cg = grvAll.GetFocusedRow() as CuocGoi;
            //    if (cg.FT_IsFT && cg.G5_Type == Enum_G5_Type.CuocKhongXeApp)
            //    {
            //        if (e.Column.FieldName == "DiaChiDonKhach")
            //        {
            //            e.Appearance.BackColor = Color.Yellow;
            //            //e.Appearance.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }
        private void cbkCuocDieuApp_EnabledChanged(object sender, EventArgs e)
        {
            if (chkCuocDieuApp.Visible)
            {
                btnRemoveGPS.Enabled = btnGPS.Enabled = chkCuocDieuApp.Enabled;
            }
        }

        private void CbMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbMapType.SelectedIndex == 0)
                MainMap.MapProvider = GMapProviders.GoogleMap;
            else
                MainMap.MapProvider = GMapProviders.BinhAnhMap;
        }

        #region Luoi lich su

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var dr = gvHistory.GetDataRow(e.RowHandle);
                if (dr.Table.Columns.Contains("IsKetThuc") && dr["IsKetThuc"] != DBNull.Value && dr["IsKetThuc"].ToString() == "1")
                {
                    e.Appearance.BackColor = Color.PeachPuff;
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0 && e.Column.FieldName == "DiaChiDonKhach")
            {
                var dr = gvHistory.GetDataRow(e.RowHandle);
                if (dr.Table.Columns.Contains("FT_IsFT") && dr["FT_IsFT"] != DBNull.Value && bool.Parse(dr["FT_IsFT"].ToString()) == true)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GetHistory(e.RowHandle);

            }
        }

        private void GetHistory(int rowhandle)
        {
            try
            {
                lblThongBao.Text = "";
                if (Config_Common.DienThoai_LayDiaChiLichSu)
                {
                    var dataRow = gvHistory.GetDataRow(rowhandle);
                    if (dataRow == null) return;
                    txtDiaChiDonKhach.KinhDo = 0F;
                    txtDiaChiDonKhach.ViDo = 0F;
                    txtDiaChiDonKhach.Text = dataRow["DiaChiDonKhach"].To<string>();
                    txtDiaChiTra.Text = dataRow["DiaChiTraKhach"].To<string>();
                    //editLenhDienThoai.Text = dataRow["LenhDienThoai"].To<string>();
                    editGhiChu.Text = dataRow["GhiChuDienThoai"].To<string>();
                    if (Config_Common.DienThoai_LayGPSLichSuCuoc)
                    {
                        var G_KinhDo_Temp = dataRow["GPS_KinhDo"].To<double>();
                        var G_ViDo_Temp = dataRow["GPS_ViDo"].To<double>();
                        var G_KinhDo_Tra_Temp = dataRow["GPS_KinhDo_Tra"].To<double>();
                        var G_ViDo_Tra_Temp = dataRow["GPS_ViDo_Tra"].To<double>();
                        if (G_KinhDo_Temp == 0 && G_ViDo_Temp == 0)
                        {
                            if (chkCuocDieuApp.Checked)//Chỉ khi không là còn điều app thì mới cho lấy tọa độ 0,0
                            {
                                lblThongBao.Text = "Địa chỉ chưa lấy tọa độ";
                                return;
                            }
                        }
                        if (G_KinhDo_Temp == 0 && G_ViDo_Temp == 0)
                        {
                            G_KinhDo = G_KinhDo_Temp;
                            G_ViDo = G_ViDo_Temp;
                            G_KinhDo_Tra = G_KinhDo_Tra_Temp;
                            G_ViDo_Tra = G_ViDo_Tra_Temp;
                            g_GPS = false;
                        }
                        else
                        {
                            G_KinhDo = G_KinhDo_Temp;
                            G_ViDo = G_ViDo_Temp;
                            g_GPS = true;
                            G_MarkerA = MainMap.AddMarkerA(new PointLatLng(G_ViDo, G_KinhDo), txtDiaChiDonKhach.Text, true, true, 0, true);
                            if (G_KinhDo_Tra_Temp > 0 && G_ViDo_Tra_Temp > 0)
                                G_MarkerB = MainMap.AddMarkerB(new PointLatLng(G_ViDo_Tra, G_KinhDo_Tra), txtDiaChiTra.Text, false, true, 0, false);

                            if (chkCuocDieuApp.Visible == true && chkCuocDieuApp.Enabled == true && Config_Common.DTV_DefaultApp)
                            {
                                chkCuocDieuApp.Checked = true;
                            }
                            else
                            {
                                //Nhập Kênh tự động theo địa chỉ vùng
                                SetKenhByDiaChi((float)G_ViDo, (float)G_KinhDo);
                            }
                            if (!chkCuocDieuApp.Checked && g_CuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam || g_CuocGoi.G5_Type == Enum_G5_Type.DienThoai)
                            {
                                getXeByToaDo(G_KinhDo, G_ViDo);
                            }
                        }
                    }

                    IsChangeDiaChiDonKhach = false;
                }
            }
            catch 
            {

            }
        }

        #endregion

        private void btnCustomer_pic_Click(object sender, EventArgs e)
        {
            ucDSLaiXe1_EventCallOut(g_CuocGoi.PhoneNumber, g_CuocGoi.DiaChiDonKhach);
        }

        private void editLenhDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Process_Command_KeyDown(e);
        }

        private void editLenhDienThoai_KeyUp(object sender, KeyEventArgs e)
        {
            Process_Command_KeyDown(e);
        }

        private void num_ShowDialog_ValueChanged(object sender, EventArgs e)
        {

        }

        private void num_7Cho_ValueChanged(object sender, EventArgs e)
        {

        }

        private void picG5_MouseClick(object sender, MouseEventArgs e)
        {
            GetGPS(false);
            frmChiDuong formChiDuong = new frmChiDuong(txtDiaChiDonKhach.Text.Trim(), G_ViDo, G_KinhDo, txtDiaChiTra.Text.Trim(), G_ViDo_Tra, G_KinhDo_Tra);
            if(formChiDuong.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                g_CuocGoi.Money_Contract = formChiDuong.G_TongTienChieuDi;
                
                if (Config_Common.DTV_FixPrice)
                {
                    txtDiaChiDonKhach.Text = string.Format("[{0:#,###} vnđ]{1}", g_CuocGoi.Money_Contract, formChiDuong.G_StartAddress);
                    txtDiaChiTra.Text = formChiDuong.G_EndAddress;
                    editGhiChu.Text = string.Format("Tiền hợp đồng : {0:#,###} vnđ", g_CuocGoi.Money_Contract);
                }
            }
        }

        private void btnSaveDTV_Click(object sender, EventArgs e)
        {

        }
        
    }
}
