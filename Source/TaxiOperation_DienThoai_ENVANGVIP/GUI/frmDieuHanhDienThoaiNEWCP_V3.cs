using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Business.QuanTri;
using Taxi.Utils;
using System.IO;
using System.Diagnostics;
using Taxi.Business.DM;
using Femiani.Forms.UI.Input;
using System.Configuration;
using System.Collections;
using Janus.Windows.UI.CommandBars;
using Taxi.Entity;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Business.KhachDat;
using Taxi.Controls;
using Taxi.Services;
using TaxiOperation_DienThoai.CheckCoDuongDai;
using Taxi.Business.CheckCoDuongDai;
using System.Linq;
using Taxi.Controls.FastTaxis;
using TaxiApplication.GUI.CheckCoDuongDai;
using Taxi.Services.WCFServices;
using Taxi.Utils.Enums;
using Taxi.Services.FastTaxi_OperationService;
using TaxiOperation_TongDai.FormFastTaxi;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.Controls.FastTaxis.TaxiChieuVe;

namespace Taxi.GUI
{

    public partial class frmDieuHanhDienThoaiNEWCP_V3 : Form
    {
        #region ==========================Init=================================

        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_DAMOI2 = "Đã mời lần 2";
        private const string LENH_CHOKHACH = "Chờ 5 phút";
        private const string LENH_DOIXE = "Đổi xe 7C/4C";
        private const string LENH_DANGGOI = "Đang gọi...";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        //private const string LENH_KHONGLIENLACDUOC = "Ko LL được";
        private const string LENH_KHONGLIENLACDUOC = "Từ chối";
        private const string LENH_HUYXE = "Hủy xe/Hoãn";
        private const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        private const string LENH_KOTHAYXE = "Ko thấy xe";
        private const string LENH_TRUOTCHUA = "Trượt/Chùa";
        private const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        private const string LENH_KHONGNOIGI = "Ko nói gì";
        private const string LENH_KHONGXE = "Ko xe xin lỗi khách";
        private const string LENH_MOIKHACH = "Mời khách";
        private const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_DAXINLOI = "Đã xin lỗi khách";

        private const string LENH_6_KIENTRAKHACH = "Kiểm tra khách";
        private const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        private const string LENH_8_RADAUNGO = "Ra đầu ngõ";
        private const string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        private const string LENH_G_GIUCXE = "Giục xe";
        private const string LENH_MATKN = "Mất kết nối";
        private const string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        private const string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        private const string LENH_KTX = "Không thấy xe";
        //-----------------------------------------------------------------------------------------
        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();
        private bool g_boolChuyenTabCuocGoiKetThuc = false; // thiet lap de load trong timer
        private bool g_boolChuyenTabCuocGoiSearch = false; // thiet lap de load trong timer
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false; // mac dinh la load luon dau tien
        private Color g_ColorOldTabCuocGoiDangThucHien;
        private int g_iStatus = 0; // Blink stauts
        private Timer TimerCapturePhone;

        private DateTime g_ThoiDiemNhanDulieuTruoc = DateTime.MinValue;
            // thời điểm nhận dữ liệu trước của truy vấn cuộc gọi mới

        private DateTime g_ThoiDiemNhanDuLieuTruocTongDai = DateTime.MinValue;
            // thời điểm nhận dữ liệu trước của truy vấn cgoị tổng đài cập nhật

        private DateTime g_TimeServer = DateTime.MinValue;
        private int g_TimerStep = 0; //
        private int g_TimerCheckLimitCG = 0; //5 phut check so cuoc goi taxiOperation
        private bool g_CGLimit = false; //
        private string g_LinesDuocCapPhep = string.Empty;
        //private string g_LoaiXeMacDinh = string.Empty;
        private int g_SoDong = 20; // số dòng của cuộc gọi đã kết thúc.
        // luu lai thong so dong duoc chon
        private int g_rowIndexSelected_CuocGoiCuaNhom = -1;
        private List<string> g_ListSoHieuXe; // Luu thong tin ds so hieu xe
        private CuocGoi cuocGoi;
        private string g_strUsername = "";
        private string g_strFullName = "";
        private string g_IPAddress = "";
        private int g_CountKetThuc = 0; //Dem so cuoc goi don duoc
        // lưu thông tin dữ liệu autocomplete
        private AutoCompleteEntryCollection g_ListDataAutoComplete = new AutoCompleteEntryCollection();
        // --- form nhập dữ liệu ------------------
        private frmDienThoaiInputDataNew_V3 g_frmInput;
        private Taxi.Business.GridLayout.GridLayout gridLayout;

        private List<string> g_ListDSMayCS = new List<string>();
        private List<DMVung_GPSEntity> G_DMVung_GPS;
        private bool g_IsMayCS1 = false; // luu giá trị là máy CS1 còn đang làm việc

        public int G_IndexKhachVIP = 0;
        public int G_IndexKhachVang = 0;
        public int G_IndexKhachBac = 0;
        public int G_IndexKHThanThiet = 0;
        private List<Province> G_arrProvince;
        private List<District> G_arrDistrict;
        private List<Commune> G_arrCommune;

        #region Danh sách cuộc gọi khác

        private List<CuocGoi> g_lstDienThoai_Khac = new List<CuocGoi>();
        private DateTime g_ThoiDiemNhanDulieuTruoc_Khac = DateTime.MinValue;
        private DateTime g_ThoiDiemNhanDuLieuTruocTongDai_Khac = DateTime.MinValue;
        private int g_TimerStep_Khac_Update = 0; //

        #endregion

        /// <summary>
        /// Cấu hình vùng mặc định
        /// </summary>
        private string g_VungMacDinh = "1";

        private frmGiamSatXe frmGSXe;
        private List<NhanVien> G_ListLaiXe = new List<NhanVien>();
        private bool hasNewCallPending = false;

        #endregion

        #region =======================Constructor=============================

        public frmDieuHanhDienThoaiNEWCP_V3()
        {

            //System.Globalization.CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            //string a = currentCulture.NumberFormat.NumberDecimalSeparator;
            InitializeComponent();
            if (!Debugger.IsAttached &&
                Global.GridConfig_CuocGoi == Grid_Config.Default)
            {
                splitContainer.Panel2Collapsed = true;
                btnCollspase.Visible = false;
            }
            else
            {
                btnCollspase.Visible = true;
            }
        }

        #endregion

        #region ====================Load Form-Set Data=========================

        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {
                if (DieuHanhTaxi.CheckConnection())
                {
                    TaxiReturn_Process.StartTimeServer();
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();

                    g_VungMacDinh = ConfigurationManager.AppSettings["VungMacDinh"] ?? "1";

                    gridDienThoai.RootTable.Columns["XeDon"].Visible = Global.MoHinh == MoHinh.TongDaiMini;
                    lblXeDon_Help.Visible = Global.MoHinh == MoHinh.TongDaiMini;
                    lblXeNhan_Help.Visible = Global.MoHinh == MoHinh.TongDaiMini;

                    G_arrProvince = Province.GetAllProvince();
                    G_arrDistrict = District.GetAllDistrict();
                    G_arrCommune = Commune.GetAllCommune();
                    //Taxi.Business.Configuration.CheckThongTinSDTCongTy();
                    //---------------------------------------------------- 
                    g_ColorOldTabCuocGoiDangThucHien = uiTabCuocGoiDangThucHien.BackColor; // luu lai mau hien tai 
                    Text = Taxi.Business.Configuration.GetCompanyName() + " - Điện thoại viên ";
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    //g_IPAddress = "192.168.100.21";
                    try
                    {
                        using (DataTable dt = QuanTriCauHinh.GetLines_LoaiXeOfPCDienThoai(g_IPAddress))
                        {
                            if (dt.Rows != null && dt.Rows.Count > 0)
                            {
                                g_LinesDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();
                                //g_LoaiXeMacDinh = dt.Rows[0]["LoaiXeID"].ToString();
                            }
                            else
                            {
                                g_LinesDuocCapPhep = string.Empty;
                                //g_LoaiXeMacDinh = string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (Debugger.IsAttached)
                    {
                        g_LinesDuocCapPhep = "1;2;3;4;5;6;7;8;9;10;11;12;13;14;15;16;17;18;19;20;21;22;23;24;25;26;27;28;29;30;31;32";
                    }

                    if (g_LinesDuocCapPhep.Length > 0)
                    {

                        ThietLapKhungTroGiup();

                        g_ListSoHieuXe = Xe.GetListSoHieuXe();
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                        g_ThoiDiemNhanDuLieuTruocTongDai = g_TimeServer;
                        g_ThoiDiemNhanDulieuTruoc_Khac = g_TimeServer;
                        g_ThoiDiemNhanDuLieuTruocTongDai_Khac = g_TimeServer;
                        Config_Common.LoadConfig_Common();
                        Config_LuoiDieu();
                        LoadAllCuocGoiHienTai(g_LinesDuocCapPhep);

                        LoadDuLieuForAutoComplete();
                        HienThiTrenLuoi(true, true);
                        if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Right)
                        {
                            LoadAllCuocGoiHienTai_Khac(g_LinesDuocCapPhep);
                            HienThiTrenLuoi_Khac(true, true);
                        }

                        CheckIn();
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi
                        gridDienThoai.Focus();

                        G_DMVung_GPS = LoadDanhMucVung_GPS();

                        LoadListLaiXe();
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this,
                            "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.",
                            "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        //LogError.WriteLogError("IP : " + g_IPAddress, new Exception("Thong tin dia chi ip"));
                        Application.Exit();
                    }

                    if (ThongTinCauHinh.GPS_TrangThai)
                    {
                        InitTimerCheckInternet();
                    }

                    KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                    statusBar.Panels["COM"].Text = " COM: " + g_COMPort;

                    //InitMemService();
                    DoFastTaxi();
                    //--------------------------LAYOUT-------------------------------------
                    loadLayout(gridDienThoai);
                    //--------------------------LAYOUT-------------------------------------

                    // hiển thị thông tin menu nhập thông tin thuê bao tuyến
                    bool HienThiKenh3 = Taxi.Business.Configuration.GetMayTinhNhapThueBao();
                    foreach (UICommand com in uiCommandBar1.Commands)
                    {
                        if (com.Key == "cmdCuocThueBao")
                        {
                            if (HienThiKenh3){
                                com.Visible = Janus.Windows.UI.InheritableBoolean.True;
                                break;
                            }
                            else com.Visible = Janus.Windows.UI.InheritableBoolean.False;
                        }
                    }
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.",
                        "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show(this, "Lỗi." + ex.Message, "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                if (TimerCapturePhone != null) TimerCapturePhone.Enabled = false;
                //LogError.WriteLogError("Lỗi khởi tạo dữ liệu form_load ", ex);
                Application.Exit();
            }
        }

        /// <summary>
        /// Cấu hình Lưới cuộc gọi
        /// </summary>
        private void Config_LuoiDieu()
        {
            gridDienThoai.RowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TiepNhan;
            gridDienThoai.SelectedFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TiepNhan;
            gridDienThoai.SelectedFormatStyle.FontBold = TriState.True;
            //gridDienThoai.RootTable.RowHeight = Config_Common.LuoiCuocGoi_RowHeight_TiepNhan;
            if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Right)
            {
                gridDienThoai_All.RowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TiepNhan_Right;
                // gridDienThoai_All.RootTable.RowHeight = Config_Common.LuoiCuocGoi_RowHeight_TiepNhan_Right;
            }
        }

        private void loadLayout(GridEX gridEX)
        {
            try
            {
                gridLayout = new Taxi.Business.GridLayout.GridLayout(ThongTinDangNhap.USER_ID, "DienThoai", Name,
                    gridEX.Name);
                gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
            }
            catch (Exception)
            {
                new MessageBox.MessageBoxBA().Show(this, "Lỗi cấu hình hiển thị.", "Thông báo lỗi",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }

        }

        /// <summary>
        /// Phân quyền trên menu theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="menu">Menu cần phân quyền</param>
        /// <param name="DataTablePermission">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// phupn update 07/03/2012
        /// </Modified> 
        private void PhanQuyenMenu(UICommandBar MenuPhanQuyen, ArrayList DanhSachQuyen)
            //Phân quyền trên menu
        {
            UICommandCollection MenuPhanQuyenItem = MenuPhanQuyen.Commands;
            foreach (UICommand mnuItem in MenuPhanQuyenItem)
            {
                if (DanhSachQuyen != null && mnuItem.Tag != null && mnuItem.Tag != "")
                {
                    mnuItem.Visible = DanhSachQuyen.Contains(mnuItem.Tag)
                        ? Janus.Windows.UI.InheritableBoolean.True
                        : Janus.Windows.UI.InheritableBoolean.False;
                    if (mnuItem.Tag != null && mnuItem.Tag.ToString().Length < 5)
                        mnuItem.Visible = Janus.Windows.UI.InheritableBoolean.True;

                    //Phân quyền các menu con (nếu có)
                    if (mnuItem.Commands.Count > 0)
                    {
                        PhanQuyenMenuItem(mnuItem, DanhSachQuyen);
                    }
                }
            }
        }

        /// <summary>
        /// Phân quyền trên menu item theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="MenuItemPhanQuyen">Menu item cần phân quyền</param>
        /// <param name="DanhSachQuyen">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// phupn update 07/03/2012
        /// </Modified>
        private void PhanQuyenMenuItem(UICommand MenuItemPhanQuyen, ArrayList DanhSachQuyen)
        {
            //UICommandCollection mnuItemCollect = MenuItemPhanQuyen.Commands;            
            //phân quyền cho menu item
            if (DanhSachQuyen != null && MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag != "")
            {
                MenuItemPhanQuyen.Visible = DanhSachQuyen.Contains(MenuItemPhanQuyen.Tag)
                    ? Janus.Windows.UI.InheritableBoolean.True
                    : Janus.Windows.UI.InheritableBoolean.False;
                if (MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag.ToString().Length < 5)
                    MenuItemPhanQuyen.Visible = Janus.Windows.UI.InheritableBoolean.True;

                //phân quyền cho các menu item con (nếu có)
                if (MenuItemPhanQuyen.Commands.Count > 0)
                {
                    for (int i = 0; i < MenuItemPhanQuyen.Commands.Count; i++)
                    {
                        UICommand mnuItem = MenuItemPhanQuyen.Commands[i];
                        if (!(mnuItem.CommandType == Janus.Windows.UI.CommandBars.CommandType.Separator))
                        {
                            PhanQuyenMenuItem(mnuItem, DanhSachQuyen);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// hàm thực hiện lấy dữ liệu autocomplete
        /// </summary>
        private void LoadDuLieuForAutoComplete()
        {
            if (g_ListDataAutoComplete == null)
                g_ListDataAutoComplete = new AutoCompleteEntryCollection();

            string address = "";
            string streetAbbr = "";
            float kd = 0;
            float vd = 0;
            using (DataTable dt = new DiaDanh().GetRoadData_Autocomplete())
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        address = row["Street"].ToString();
                        streetAbbr = row["StreetAbbr"].ToString();
                        kd = float.Parse(row["KinhDo"].ToString());
                        vd = float.Parse(row["ViDo"].ToString());

                        g_ListDataAutoComplete.Add(new AutoCompleteEntry(address, kd, vd, streetAbbr));
                        i++;
                    }
                }
            }
        }

        // NHAN TAT CAC CAC CUOC GOI
        /// <summary>
        /// lấy tất cả các cuộc gọi với line cho phép
        /// </summary>
        /// <param name="linesDuocCapPhep"></param>
        private void LoadAllCuocGoiHienTai(string linesDuocCapPhep)
        {
            g_lstDienThoai = new List<CuocGoi>();
            if (ThongTinCauHinh.FT_Active)
                g_lstDienThoai = CuocGoi.FT_DIENTHOAI_LayAllCuocGoi(linesDuocCapPhep);
            else
                g_lstDienThoai = CuocGoi.FT_DIENTHOAI_LayAllCuocGoiNotFT(linesDuocCapPhep);

        }

        #region Cuoc Gọi Line Khác/// <summary>

        /// lấy tất cả các cuộc gọi khác với line cho phép
        /// </summary>
        /// <param name="linesDuocCapPhep"></param>
        private void LoadAllCuocGoiHienTai_Khac(string linesDuocCapPhep)
        {
            g_lstDienThoai_Khac = new List<CuocGoi>();
            g_lstDienThoai_Khac = CuocGoi.FT_DIENTHOAI_LayAllCuocGoi_Khac(linesDuocCapPhep);

        }

        /// <summary>
        /// Hàm thực hiện nhận cuộc gọi mới về (Line Khác)
        /// ghép vào 
        /// </summary>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        /// <returns></returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// phupn      8/01            Create
        /// </Modified>
        private void GetAllCuocGoiMoi_Khac(List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiMoi)
        {
            hasCuocGoiMoi = false;
            List<CuocGoi> listCuocGoiMoi = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_V3_Khac(linesDuocCapPhep,
                thoiDiemNhanDulieuTruoc);

            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiMoi)
                {
                    if (!KiemTraCuocGoiDaTonTai(listCuocGoiHienTai, objCG))
                    {
                        listCuocGoiHienTai.Insert(0, objCG);
                        hasCuocGoiMoi = true;
                    }
                }
            }
        }

        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi của tổng đài mới cập nhật
        /// đẩy thông tin cập nhật vào ds cuốc khách hiện tại
        /// </summary>
        /// <param name="listCuocGoi"></param>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        private void CapNhapCuocGoiTuTongDai_Khac(ref List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoiHienTai == null)
            {
                listCuocGoiHienTai = new List<CuocGoi>();
            }
            // Lấy ds cuộc gọi có thay đổi thông tin của tổng đài
            List<CuocGoi> listCuocGoi = CuocGoi.DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3_Khac(linesDuocCapPhep,
                thoiDiemNhanDulieuTruoc);
            if (listCuocGoi != null && listCuocGoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoi)
                {
                    hasCapNhat = true;
                    TimVaCapNhatCuocGoi_Khac(ref listCuocGoiHienTai, objCG, ref hasThemMoi);
                }
            }
        }

        /// <summary>
        /// ham cap nhat nhung cuoc goi ket thuc từ các line khác
        /// </summary>
        /// <param name="listCuocGoiHienTai"></param>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="hasCuocGoiMoi"></param>
        private void CapNhatCuocGoiKetThuc_Khac(ref List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            ref bool hasCapNhat)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += String.Format("{0},", cuocGoi.IDCuocGoi);
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.DIENTHOAI_LayCacIDCuocGoiKetThuc_Khac(listIDCuocGoi,
                    linesDuocCapPhep);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    foreach (long idCuocGoi in listIDDaKetThuc)
                    {
                        int index = listCuocGoiHienTai.FindIndex(delegate(CuocGoi cuocGoiT)
                        {
                            return (cuocGoiT.IDCuocGoi == idCuocGoi);
                        });
                        if (index >= 0)
                        {
                            listCuocGoiHienTai.RemoveAt(index);
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
        }


        private void TimVaCapNhatCuocGoi_Khac(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, ref bool hasThemMoi)
        {
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < listCuocGoiHienTai.Count; i++)
                {
                    if (listCuocGoiHienTai[i].IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    listCuocGoiHienTai[index].MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                    listCuocGoiHienTai[index].MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                    listCuocGoiHienTai[index].XeNhan = cuocGoi.XeNhan;
                    listCuocGoiHienTai[index].XeDenDiem = cuocGoi.XeDenDiem;
                    listCuocGoiHienTai[index].LenhDienThoai = cuocGoi.LenhDienThoai;
                    listCuocGoiHienTai[index].LenhTongDai = cuocGoi.LenhTongDai;
                    listCuocGoiHienTai[index].Vung = cuocGoi.Vung;
                    listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                    listCuocGoiHienTai[index].PhoneNumber = cuocGoi.PhoneNumber;
                    listCuocGoiHienTai[index].Line = cuocGoi.Line;
                    listCuocGoiHienTai[index].LoaiXe = cuocGoi.LoaiXe;
                    listCuocGoiHienTai[index].SoLuong = cuocGoi.SoLuong;
                }
                else
                {
                    listCuocGoiHienTai.Insert(0, cuocGoi);
                    hasThemMoi = true;
                }
            }
            else
            {
                listCuocGoiHienTai.Insert(0, cuocGoi);
                hasThemMoi = true;
            }
        }

        /// <summary>
        /// hàm thực hiện cập nhật dữ liệu hiển thị trên lưới.
        /// Nếu hasCuocGoiMoi = False
        ///    Nếu  hasThayDoiThongTin = true --> Refesh lại lưới
        /// Nếu hasThayDoiThongTin = false 
        ///    Nếu hasCuocGoiMoi = true  --> gán mới
        /// </summary>
        private void HienThiTrenLuoi_Khac(bool hasCuocGoiMoi, bool hasThayDoiThongTin)
        {
            try
            {
                if (hasThayDoiThongTin)
                {
                    if (hasCuocGoiMoi)
                    {
                        gridDienThoai_All.DataSource = null;
                        gridDienThoai_All.DataMember = "ListDienThoai_Khac";
                        gridDienThoai_All.SetDataBinding(g_lstDienThoai_Khac, "ListDienThoai_Khac");
                    }
                    else
                    {
                        gridDienThoai_All.Refresh();
                    }
                }
                else
                {
                    gridDienThoai_All.Refresh();
                    gridDienThoai_All.Refetch();
                    //gridDienThoai.MoveToRowIndex(g_RowIndex);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        /// <summary>
        /// Hàm thực hiện nhận cuộc gọi mới về
        /// ghép vào 
        /// </summary>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        /// <returns></returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// Côngnt      17/07            Create
        /// </Modified>
        private void GetAllCuocGoiMoi(List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiMoi)
        {
            hasCuocGoiMoi = false;
            List<CuocGoi> listCuocGoiMoi;
            if(ThongTinCauHinh.FT_Active)
            listCuocGoiMoi = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_FT(linesDuocCapPhep,
                thoiDiemNhanDulieuTruoc);
            else 
                listCuocGoiMoi = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(linesDuocCapPhep,
           thoiDiemNhanDulieuTruoc);

            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiMoi)
                {
                    if (!KiemTraCuocGoiDaTonTai(listCuocGoiHienTai, objCG))
                    {
                        listCuocGoiHienTai.Insert(0, objCG);
                        hasCuocGoiMoi = true;
                        //
                    }
                    //Kiem tra cuoc goi lai
                    //long IDCG = objCG.IDCuocGoi;
                    //objCuocGoi = listCuocGoiHienTai.Find(T=> T.PhoneNumber == objCG.PhoneNumber
                    //                                    && T.CuocGoiLaiIDs.Length <=0
                    //                                    && T.PhoneNumber != ThongTinCauHinh.SoDienThoaiCongTy
                    //                                    && T.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi);
                    //if (objCuocGoi != null)
                    //{
                    //    objCG.CuocGoiLaiIDs = objCuocGoi.IDCuocGoi.ToString();
                    //}
                }
            }
        }

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string linesChoPhep, int soDong)
        {
            try
            {
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                if (ThongTinCauHinh.FT_Active)
                {
                    gridCuocGoi_KetThuc.SetDataBinding(CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyet(linesChoPhep, soDong),
                        "lstCuocGoiKetThuc");
                }
                else
                {
                    gridCuocGoi_KetThuc.SetDataBinding(CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(linesChoPhep, soDong),
                   "lstCuocGoiKetThuc");
                }
                
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("LoadCacCuocGoiKetThuc " + ex.Message);
            }
        }

        /// <summary>
        /// Load du lieu VungGPS theo Kenh
        /// </summary>
        /// <returns></returns>
        private List<DMVung_GPSEntity> LoadDanhMucVung_GPS()
        {
            return new DMVung_GPS().GetAllDSVungKenh();
        }

        /// <summary>
        /// Load danh sách lái xe của hệ thống
        /// </summary>
        private void LoadListLaiXe()
        {
            G_ListLaiXe = new NhanVien().GetListNhanViens();
        }

        #endregion

        #region ======================Validation Form==========================

        /// <summary>
        /// thiết lập panel trợ giúp
        /// </summary>
        private void ThietLapKhungTroGiup()
        {
            panelTopHelp.Location = new Point(Size.Width - (panelTopHelp.Size.Width + 15 + 32), 0);
            btnHelp.Location = new Point(Size.Width - (btnHelp.Size.Width + 15), 0);
            btnCollspase.Location = new Point(Size.Width - (btnCollspase.Size.Width + 15), 40);
        }

        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>        
        private void CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
            frm.ShowDialog();
            g_strUsername = ThongTinDangNhap.USER_ID;
            g_strFullName = ThongTinDangNhap.FULLNAME;
            if (g_strUsername.Length > 0)
            {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress))
                    // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                {
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                    if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
                    {
                        //new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //Application.Exit();
                        //return;
                        string alert = new MessageBox.MessageBoxBA().Show(this,
                            "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi",
                            Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        if (alert == "Yes")
                        {
                            ThongTinDangNhap.CheckOutByIpAddress(g_IPAddress);
                        }
                        else
                        {
                            Application.Exit();
                            return;
                        }
                    }
                    // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                    //if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                    //{
                    //    new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    ThongTinDangNhap.USER_ID = "";
                    //    g_strUsername = "";
                    //    g_strFullName = "";
                    //    Application.Exit();
                    //    return;

                    //}

                    // cap nhat trang thai
                    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi",
                            Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        if (
                            !((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) ||
                               (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Bạn không có quyền điều hành điện thoại.",
                                "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                Taxi.MessageBox.MessageBoxIconBA.Error);
                            ThongTinDangNhap.CheckOutByIpAddress(g_IPAddress);
                            ThongTinDangNhap.USER_ID = "";
                            g_strUsername = "";
                            g_strFullName = "";
                            Application.Exit();
                            return;
                        }
                    }

                    // thiet lap menu disable 
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                Text = String.Format("{0} - Điện thoại viên  [{1} - {2}] - {3} - {4}",
                    Taxi.Business.Configuration.GetCompanyName(), g_LinesDuocCapPhep, g_IPAddress,
                    ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
                statusBar.Panels["TenDangNhap"].Text = string.Format("NV : {0} - {1}", g_strUsername, g_strFullName);
                if (ThongTinDangNhap.USER_ID != "admin")
                {
                    //thực hiện phân quyền trên menu
                    PhanQuyenMenu(uiCommandBar2, ThongTinDangNhap.PermissionsFull);
                    PhanQuyenMenu(uiCommandBar1, ThongTinDangNhap.PermissionsFull);
                }
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
            }
        }

        private void checkout()
        {
            // check co dung may cua user dang ngồi không.
            if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
            {
                if (ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress))
                {
                    new MessageBox.MessageBoxBA().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.",
                        "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK,
                        Taxi.MessageBox.MessageBoxIconBA.Information);
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    statusBar.Panels["TenDangNhap"].Text = " NV điện thoại : ";
                    ThongTinDangNhap.USER_ID = "";
                    CheckIn();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this,
                        "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                }
            }

            else
                new MessageBox.MessageBoxBA().Show(this,
                    "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).",
                    "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            // nếu đúng thì cập nhật thời gian checkout.
        }

        /// <summary>
        /// Confirm có tiếp tục check in hay không. nếu có sẽ check out toàn bộ các account đã check in trên máy.
        /// </summary>
        /// <param name="msgConfirm"></param>
        /// <param name="Type">
        /// 1 : có người đăng nhập trên máy này rồi
        /// 2 : account này đã đăng nhập ở 1 máy tính khác</param>
        private void confirmCheckIn(string msgConfirm, int Type)
        {
            if (msgConfirm == "Yes")
            {
                //check out ở máy tính khác trước
                if (Type == 2 && ThongTinDangNhap.CheckOut_AllIn_OtherIP(g_strUsername, g_IPAddress))
                {
                    doCheckIn();
                }
                // check out account khác đã checkin trên máy tính này trước.
                else if (Type == 1 && ThongTinDangNhap.CheckOut_AllInIP(g_strUsername, g_IPAddress))
                {
                    doCheckIn();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this,
                        "Có lỗi checkin hệ thống. Vui lòng thử lại.",
                        "Thông báo lỗi",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK,
                        Taxi.MessageBox.MessageBoxIconBA.Error);
                    ThongTinDangNhap.USER_ID = "";
                    g_strUsername = "";
                    g_strFullName = "";
                    Application.Exit();
                    return;
                }
            }
            else
            {
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
                Application.Exit();
                return;
            }
        }

        private void doCheckIn()
        {
            // cap nhat trang thai
            if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
                Application.Exit();
                return;
            }
            else
            {
                if (!ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanh))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                    ThongTinDangNhap.USER_ID = "";
                    g_strUsername = "";
                    g_strFullName = "";
                    Application.Exit();
                    return;
                }
            }
        }

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }

        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {
            int iSoCuocGoiChuaChuyenSangTongDai = 0;
            int iSoCuocGoiChuaDonDuocXe = 0;
            if (g_lstDienThoai != null)
            {
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if (objDH.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                        iSoCuocGoiChuaChuyenSangTongDai += 1;
                    if (objDH.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                        objDH.TrangThaiLenh != TrangThaiLenhTaxi.KhongTruyenDi)
                        iSoCuocGoiChuaDonDuocXe += 1;

                }
            }
            statusBar.Panels[1].Width = 290;
            statusBar.Panels[1].Text = String.Format("Chưa chuyển tổng đài : {0}", iSoCuocGoiChuaChuyenSangTongDai);
            statusBar.Panels[2].Width = 270;
            statusBar.Panels[2].Text = String.Format("Chưa đón được khách : {0}", iSoCuocGoiChuaDonDuocXe);
            statusBar.Panels[3].Width = 270;
            statusBar.Panels[3].Text = String.Format("Đón được khách : {0}", g_CountKetThuc);

        }

        /// <summary>
        /// hàm thực hiện cập nhật dữ liệu hiển thị trên lưới.
        /// Nếu hasCuocGoiMoi = False
        ///    Nếu  hasThayDoiThongTin = true --> Refesh lại lưới
        /// Nếu hasThayDoiThongTin = false 
        ///    Nếu hasCuocGoiMoi = true  --> gán mới
        /// </summary>
        private void HienThiTrenLuoi(bool hasCuocGoiMoi, bool hasThayDoiThongTin)
        {
            try
            {
                if (hasThayDoiThongTin)
                {
                    var g_RowIndex = gridDienThoai.Row;
                    if (hasCuocGoiMoi)
                    {
                        gridDienThoai.DataSource = null;
                        gridDienThoai.DataMember = "ListDienThoai";
                        gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                    }
                    else
                    {
                        gridDienThoai.Refresh();
                    }
                    gridDienThoai.Row = g_RowIndex;
                }
                else
                {
                    gridDienThoai.Refetch();
                    //gridDienThoai.MoveToRowIndex(g_RowIndex);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// hien thi thong tin len luoi
        /// hien thi luoi cuoc goi cua nhom, nhung cuoc goi khong phai cua nhom. 
        /// </summary>
        /// <param name="listDienThoai"></param>
        /// <param name="LinesDuocCapPhep"></param>
        private void DisplayLenGrid(List<CuocGoi> listDienThoai, string LinesDuocCapPhep)
        {
            // lay lua chon dong hien tai
            if (gridDienThoai.Row >= 0)
                g_rowIndexSelected_CuocGoiCuaNhom = gridDienThoai.Row;



            List<CuocGoi> listNhungCuocGoiCuaNhom = new List<CuocGoi>();
            List<CuocGoi> listCuocGoiKhongPhaiCuaNhom = new List<CuocGoi>();

            listNhungCuocGoiCuaNhom = GetNhungCuocGoiCuaNhom(listDienThoai, LinesDuocCapPhep,
                out listCuocGoiKhongPhaiCuaNhom);

            gridDienThoai.DataSource = null;
            gridDienThoai.DataMember = "ListDienThoai";
            gridDienThoai.SetDataBinding(listNhungCuocGoiCuaNhom, "ListDienThoai");



            // thiet lap lua chon
            if ((g_rowIndexSelected_CuocGoiCuaNhom >= 0) && (gridDienThoai.RowCount > 0))
            {
                while (g_rowIndexSelected_CuocGoiCuaNhom > gridDienThoai.RowCount) g_rowIndexSelected_CuocGoiCuaNhom--;
                gridDienThoai.Row = g_rowIndexSelected_CuocGoiCuaNhom;
            }

        }

        /// <summary>
        /// nếu quá 10 phút thì format lại style cho cột ThoiDiemGoi
        /// </summary>
        /// <param name="row"></param>
        /// <param name="ThoiDiemGoi"></param>
        private void setStyleThoiDiemGoi(GridEXRow row, DateTime ThoiDiemGoi)
        {
            TimeSpan timer = g_TimeServer - ThoiDiemGoi;
            if (timer.TotalMinutes > 10 && timer.TotalMinutes <= 20)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Orange;
                RowStyle.FontBold = TriState.True;
                row.Cells["ThoiDiemGoi"].FormatStyle = RowStyle;
            }
            else if (timer.TotalMinutes > 20)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Red;
                RowStyle.FontBold = TriState.True;
                row.Cells["ThoiDiemGoi"].FormatStyle = RowStyle;
            }
        }

        /// <summary>
        /// format lại style cho cột Xe nhận
        /// </summary>
        /// <param name="row"></param>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="xeNhan"></param>
        private void setStyleXeNhan(GridEXRow row, DateTime ThoiDiemGoi, string xeNhanTD, string xeNhan, string xeDeCu,
            int ColWidth)
        {
            var g = this.CreateGraphics();
            try
            {
                if (string.IsNullOrEmpty(xeNhan))
                {
                    TimeSpan timer = g_TimeServer - ThoiDiemGoi;
                    if (timer.TotalMinutes > 1 && timer.TotalMinutes <= 5)
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan, g);

                    else if (timer.TotalMinutes > 5 && timer.TotalMinutes <= 30)
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.Orange, Color.Orange, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan, g);

                    else
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan, g);
                }
                else
                {
                    row.Cells["XeNhan_CB"].Image =
                        (Image)
                            Global.ConvertTextToImage(xeNhanTD, xeNhan, xeDeCu, Color.White, Color.Red, ColWidth,
                                Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                Config_Common.LuoiCuocGoi_FontSize_TiepNhan, g);
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("setStyleXeNhan " + ex.Message);
            }

        }

        private void setStyleXeDenDiem(GridEXRow row, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach,
            int ColWidth, DateTime thoiDiemGoi)
        {
            try
            {
                TimeSpan timer = g_TimeServer - thoiDiemGoi;
                if (timer.TotalMinutes > 10)
                    row.Cells["XeDenDiem_CB"].Image =
                        (Image)
                            Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.LightSteelBlue, Color.Blue,
                                ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 10)
                    row.Cells["XeDenDiem_CB"].Image =
                        (Image)
                            Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.MistyRose, Color.Blue,
                                ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                else
                    row.Cells["XeDenDiem_CB"].Image =
                        (Image)
                            Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.White, Color.Blue, ColWidth,
                                Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("setStyleXeDenDiem " + ex.Message);
            }
        }

        /// <summary>
        /// - Hien thi anh trang thai tuong ung voi trang thai lenh
        /// - thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
        /// - Thay mau chu cua dia chi cua khach goi lai
        /// - thay doi may cua cuoc goi khong phai cua minh phu trach
        /// </summary>
        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                CuocGoi cuocGoi = (CuocGoi) row.DataRow;
                if (cuocGoi == null) return;

                setStyleThoiDiemGoi(row, cuocGoi.ThoiDiemGoi);

                setStyleXeNhan(row, cuocGoi.ThoiDiemGoi, cuocGoi.XeNhan_TD, cuocGoi.XeNhan, cuocGoi.DanhSachXeDeCu,
                    row.Cells["XeNhan_CB"].Column.Width);

                setStyleXeDenDiem(row, cuocGoi.MOIKHACH_LenhMoiKhach, cuocGoi.XeDenDiem, cuocGoi.XeDenDiemDonKhach,
                    row.Cells["XeDenDiem_CB"].Column.Width, cuocGoi.ThoiDiemGoi);

                //if (cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI ||
                //    cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN ||
                //    cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI ||
                //    cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HUYXE ||
                //    cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE ||
                //    cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC)
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //    //RowStyle.BackColor = Color.White;
                //    RowStyle.BackColor = Color.Aquamarine;
                //    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                //}
                if (cuocGoi.LenhTongDai == LENH_MOIKHACH)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || cuocGoi.LenhDienThoai == LENH_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || cuocGoi.LenhDienThoai == LENH_HOILAIDIACHI ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                        || cuocGoi.LenhDienThoai == LENH_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                        || cuocGoi.LenhDienThoai == LENH_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || cuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
                        || cuocGoi.LenhDienThoai == LENH_TRUOTCHUA || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                        || cuocGoi.LenhDienThoai == LENH_KHONGNOIGI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                        || cuocGoi.LenhDienThoai == LENH_KOTRUCTIEP || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KOTRUCTIEP
                        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1"))
                        {
                            row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        }
                        else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("2"))
                        {
                            row.RowStyle = RowStyle;
                        }
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Config_Common.LuoiCuocGoi_MauNen_LenhMoi;
                        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1"))
                        {
                            row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        }
                        else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("2"))
                        {
                            row.RowStyle = RowStyle;
                        }
                    }
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.White;
                    if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("1"))
                    {
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi.Equals("2"))
                    {
                        row.RowStyle = RowStyle;
                    }
                }

                if (cuocGoi.LenhTongDai == LENH_6_KIENTRAKHACH
                    || cuocGoi.LenhTongDai == LENH_8_RADAUNGO)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || cuocGoi.LenhDienThoai == LENH_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || cuocGoi.LenhDienThoai == LENH_HOILAIDIACHI ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                        || cuocGoi.LenhDienThoai == LENH_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                        || cuocGoi.LenhDienThoai == LENH_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || cuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
                        || cuocGoi.LenhDienThoai == LENH_TRUOTCHUA || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                        || cuocGoi.LenhDienThoai == LENH_KHONGNOIGI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                        || cuocGoi.LenhDienThoai == LENH_KOTRUCTIEP || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KOTRUCTIEP
                        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }

                }
                else if (cuocGoi.LenhDienThoai == LENH_HUYXE_HOAN || 
                        cuocGoi.LenhDienThoai == LENH_G_GIUCXE || 
                    cuocGoi.LenhDienThoai.Contains(LENH_MATKN))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Tomato;
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.LenhDienThoai == LENH_KTX || cuocGoi.LenhDienThoai == LENH_KTX_GoiChoKhach)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.LenhTongDai == LENH_7_MOIKHACHLAN2)
                {
                    if (cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        || cuocGoi.LenhDienThoai == LENH_DAMOI2 || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI2
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                }
                else if (cuocGoi.LenhTongDai == LENH_9_TIEPTHIXEKHAC)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DOIXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DOIXE)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                }
                else if (cuocGoi.LenhTongDai == LENH_HOILAIDIACHI)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Violet;
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.LenhDienThoai == LENH_KHACHDAT)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Green;
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }
                if (cuocGoi.LenhTongDai == LENH_KHONGXE && cuocGoi.ThoiDiemGoi.AddMinutes(3) <= g_TimeServer)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Red};
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                //if (cuocGoi.ThoiDiemChuyenTongDai > Taxi.Business.Configuration.GetDienThoai_ThoiDiemChuyenTongDai())
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { ForeColor = Color.Red };
                //    row.Cells["ThoiDiemChuyenTongDai"].FormatStyle = RowStyle;
                //}
                TimeSpan timeSpan = g_TimeServer - cuocGoi.ThoiDiemGoi;
                //if (timeSpan.TotalMinutes > 1 && cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Pink };
                //    row.RowStyle = RowStyle;
                //}
                if ((cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi) ||
                    (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam) ||
                    (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai))
                    row.Cells["ImageCol"].ImageIndex = (int) cuocGoi.TrangThaiLenh;
                else if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.MoiKhachGui)
                {
                    row.Cells["ImageCol"].ImageIndex = 3;
                    //row.Cells["ImageCol"].Image = (Image)ConvertTextToImage(cuocGoi.XeNhan, cuocGoi.DanhSachXeDeCu);
                }

                if (cuocGoi.SoLanGoi == 1)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Yellow};
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.SoLanGoi >= 2)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Red};
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                }
                // neu vung la 0 thi hien thi mau do, de nhan vien chu y
                if (cuocGoi.Vung <= 0)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Tomato};
                    row.Cells["Vung"].FormatStyle = RowStyle;
                }
                else // trar lai mau binh thuong
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle()
                    {
/*RowStyle.BackColor = Color.White;*/
                        BackColor = Color.White
                    };
                    row.Cells["Vung"].FormatStyle = RowStyle;
                }
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Yellow};
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                         || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.ForestGreen;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.LightSalmon};
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                // Fast Taxi
                if (cuocGoi.FT_IsFT)
                {
                    var rowStyle = new GridEXFormatStyle();
                    {
                        rowStyle.BackColor = Color.Yellow;
                        rowStyle.ForeColor = Color.Black;
                        row.Cells["DiaChiDonKhach"].FormatStyle = rowStyle;
                    }

                }
                else // goi lai va cuoc goi chua chuyen di va so lan goi lon hon hoac bang 2
                    if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai || (cuocGoi.Vung == 0 && cuocGoi.SoLanGoi >= 2))
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {ForeColor = Color.Red};
                        row.Cells["DiaChiDonKhach"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {ForeColor = Color.Black};
                        row.Cells["DiaChiDonKhach"].FormatStyle = RowStyle;
                    }

                if (Config_Common.LuoiCuocGoi_MauNen_LoaiXe.Length > 0)
                {
                    bool HasColor_LoaiXe = false;
                    foreach (var item in Config_Common.LuoiCuocGoi_MauNen_LoaiXe)
                    {
                        if (cuocGoi.LoaiXe.Contains(item))
                        {
                            HasColor_LoaiXe = true;
                            break;
                        }
                    }
                    if (HasColor_LoaiXe)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.DodgerBlue};
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.White};
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.White};
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }

                if (cuocGoi.SoLuong > 1)
                {
                    //if (cuocGoi.XeNhan != null && cuocGoi.XeNhan.Length > 0)
                    //{
                    //    string[] SoXe = cuocGoi.XeNhan.Split(".".ToCharArray());
                    //    int SoLuongDangCo = SoXe.Length;
                    //    if (cuocGoi.SoLuong > SoLuongDangCo)
                    //    {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Red;
                    row.Cells["SoLuong"].FormatStyle = RowStyle;
                    //}
                    //else
                    //{
                    //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    //    //RowStyle.BackColor = Color.White;
                    //    RowStyle.BackColor = Color.White;
                    //    row.Cells["SoLuong"].FormatStyle = RowStyle;
                    //}
                    //}
                    // Là cuốc fast taxi Gọi đến

                }

            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("Trang Thai mau Chu " + ex.Message);
                //LogError.WriteLogError("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }

        private void HienThiAnhTrangThai_MauChu_Right(GridEXRow row)
        {
            try
            {
                CuocGoi cuocGoi = (CuocGoi) row.DataRow;
                if (cuocGoi == null) return;

                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                if (cuocGoi.LenhTongDai == LENH_MOIKHACH)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || cuocGoi.LenhDienThoai == LENH_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || cuocGoi.LenhDienThoai == LENH_HOILAIDIACHI ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                        || cuocGoi.LenhDienThoai == LENH_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                        || cuocGoi.LenhDienThoai == LENH_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || cuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC ||
                        cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
                        || cuocGoi.LenhDienThoai == LENH_TRUOTCHUA || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                        || cuocGoi.LenhDienThoai == LENH_KHONGNOIGI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                        || cuocGoi.LenhDienThoai == LENH_KOTRUCTIEP || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KOTRUCTIEP
                        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        )
                    {
                        RowStyle.BackColor = Color.White;
                        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("1"))
                        {
                            row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        }
                        else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("2"))
                        {
                            row.RowStyle = RowStyle;
                        }
                    }
                    else
                    {
                        RowStyle.BackColor = Config_Common.LuoiCuocGoi_MauNen_LenhMoi_Right;
                        if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("1"))
                        {
                            row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        }
                        else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("2"))
                        {
                            row.RowStyle = RowStyle;
                        }
                    }
                }
                else
                {
                    RowStyle.BackColor = Color.White;
                    if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("1"))
                    {
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else if (Config_Common.LuoiCuocGoi_HienThiMauNen_LenhMoi_Right.Equals("2"))
                    {
                        row.RowStyle = RowStyle;
                    }
                }

            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("Trang Thai mau Chu " + ex.Message);
                //LogError.WriteLogError("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }

        #endregion

        #region =======================Get Data Form===========================

        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION
        /// </summary>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDangTheoDoi()
        {
            try
            {

                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                const string SQLCondition = " ORDER BY ThoiDiemGoi DESC";
                return objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("GetAllCuocGoiDangTheoDoi " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// input la danh sach cac cuoc goi dang theo doi (chua ket thuc)
        /// output : cuoc goi moi nhat ((TrangThaiLenh=0)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiMoi(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiMoiNhan = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                        ListCuocGoiMoiNhan.Add(objDHTaxi);
                }
                // kiem tra xem co phai goi lai khong
                if (ListCuocGoiMoiNhan.Count > 0)
                {
                    int lenCuocGoiMoi = ListCuocGoiMoiNhan.Count;
                    int lenCuocGoi = ListAllCuocGoiDangHoatDong.Count;
                    for (int i = 0; i < lenCuocGoiMoi; i++)
                    {
                        for (int j = 0; j < lenCuocGoi; j++)
                        {
                            if ((ListAllCuocGoiDangHoatDong[j].TrangThaiLenh != TrangThaiLenhTaxi.KhongTruyenDi) &&
                                (ListCuocGoiMoiNhan[i].PhoneNumber == ListAllCuocGoiDangHoatDong[j].PhoneNumber))
                            {
                                ListCuocGoiMoiNhan[i].CuocGoiLaiIDs = "1";
                            }
                        }
                    }
                }
            }


            return ListCuocGoiMoiNhan;
        }

        /// <summary>
        /// Get tat ca cac cuoc goi tong dai moi truyen sang (TrangThaiLenh=2)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiTongDaiMoiTruyenSang(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiTongDaiTruyenSang = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if ((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam) ||
                        ((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai)))
                        ListCuocGoiTongDaiTruyenSang.Add(objDHTaxi);
                }
            }
            return ListCuocGoiTongDaiTruyenSang;

        }

        /// <summary>
        /// get tat ca cuoc goi chua co so chuong ((TrangThaiCuocGoi=9 AND TrangThaiLenh=4, khong ) OR (TrangThaiCuocGoi=7 AND TrangThaiLenh=0)
        /// Cuoc goi da nhac may (TrangThaiCuocGoi=7), Cuoc goi nho (TrangThaiCuocGoi=9)
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiChuaCoSoChuong(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiChuaChuong = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai) &&
                         (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh)) ||
                        ((objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi) &&
                         (objDHTaxi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh)))
                        ListCuocGoiChuaChuong.Add(objDHTaxi);
                }
            }
            return ListCuocGoiChuaChuong;
        }

        /// <summary>
        /// ham thuc hien chuc nang loc cac cuoc goi cua chinh nhom minh
        /// </summary>
        /// <param name="listCacCuocGois"></param>
        /// <param name="LinesDuocCapPhep"></param>
        /// <returns></returns>
        private List<CuocGoi> GetNhungCuocGoiCuaNhom(List<CuocGoi> listCacCuocGois, string LinesDuocCapPhep,
            out List<CuocGoi> listCuocGoiKhongPhaiCuaNhom)
        {
            List<CuocGoi> listNhungCuocGoiCuaNhom = new List<CuocGoi>();
            List<CuocGoi> _listCuocGoiKhongPhaiCuaNhom = new List<CuocGoi>();
            if ((listCacCuocGois != null) && (listCacCuocGois.Count > 0))
            {
                foreach (CuocGoi objDHTX in listCacCuocGois)
                {
                    if (DieuHanhTaxi.CheckLineDuocPhepsuDungMayNay(LinesDuocCapPhep, objDHTX.Line.ToString()))
                    {
                        listNhungCuocGoiCuaNhom.Add(objDHTX);
                    }
                    else
                    {
                        _listCuocGoiKhongPhaiCuaNhom.Add(objDHTX);
                    }
                }
            }
            listCuocGoiKhongPhaiCuaNhom = _listCuocGoiKhongPhaiCuaNhom;
            return listNhungCuocGoiCuaNhom;
        }

        #endregion

        #region ========================Form Events============================

        private void DatHen()
        {
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                CuocGoi objCuocGoi =
                    (CuocGoi)
                        gridDienThoai.GetRow(((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).Position).DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).GetRow();

                KhachDatBL objKhachDat = new KhachDatBL()
                {
                    CreatedBy = ThongTinDangNhap.USER_ID,
                    DiaChi = objCuocGoi.DiaChiDonKhach,
                    SoDienThoai = objCuocGoi.PhoneNumber,
                    SoLuongXe = objCuocGoi.SoLuong,
                    ThoiDiemBatDau = DateTime.Now,
                    ThoiDiemKetThuc = DateTime.Now,
                    LoaiXe = objCuocGoi.LoaiXe,
                    ThoiDiemTiepNhan = DateTime.Now,
                    VungKenh = objCuocGoi.Vung,
                    SoPhutBaoTruoc = 10,
                    GhiChu = "",
                    IsLapLai = false,
                    GioDon = DateTime.Now.AddMinutes(10)
                };
                frmKhachDat formKhachDat = new frmKhachDat(objKhachDat, g_ListDataAutoComplete, false);

                formKhachDat.ShowDialog();
            }
        }

        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
                g_boolChuyenTabCuocGoiKetThuc = true;
                g_boolChuyenTabCuocGoiSearch = false;
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridDienThoai);
                //--------------------------LAYOUT-------------------------------------
            }
            else if (e.Page.Name == "uiTabCuocGoiChoGiaiQuyet")
            {
                g_boolChuyenTabCuocGoiKetThuc = false;
                g_boolChuyenTabCuocGoiSearch = false;
                //--------------------------LAYOUT-------------------------------------
                //loadLayout(gridCuocGoi_KetThuc);
                //--------------------------LAYOUT-------------------------------------
            }
            else
            {
                g_boolChuyenTabCuocGoiKetThuc = true;
                g_boolChuyenTabCuocGoiSearch = true;
                txtDiaChi.Focus();
            }
        }

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdThayDoiMatKhau")
            {
                using (CapNhatThongTinCaNhan capNhatThongTinCaNhan = new CapNhatThongTinCaNhan())
                {
                    capNhatThongTinCaNhan.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdTinhCuoc")
            {
                using (frmTinhTienTheoKm frm = new frmTinhTienTheoKm())
                {
                    frm.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdChenThemCuocGoi")
            {
                using (
                    frmChenMoiMotCuocDienThoai frm = new frmChenMoiMotCuocDienThoai(g_LinesDuocCapPhep,
                        g_ListDataAutoComplete))
                {
                    frm.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdLogin")
            {
                CheckIn();
            }
            else if (e.Command.Key == "cmdCheckOut")
            {
                checkout();

            }
            else if (e.Command.Key == "cmdChenThemMotCuocGoi")
            {
                using (
                    frmChenMoiMotCuocDienThoai frmChenMoiMotCuocDienThoai =
                        new frmChenMoiMotCuocDienThoai(g_LinesDuocCapPhep, g_ListDataAutoComplete))
                {
                    frmChenMoiMotCuocDienThoai.ShowDialog();
                }

            } //cmdTraCuuDiaDanh
            else if (e.Command.Key == "cmdTraCuuDiaDanh")
            {
                using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
                {
                    frmDMDiaDanh.ShowDialog();
                }
            }

            else if (e.Command.Key == "cmdExit")
            {
                Application.Exit();
            }

            else if (e.Command.Key == "cmdKiemSoatXe_KiemSoatXeChiTiet")
            {
                if (frmGSXe == null || frmGSXe.Visible == false)
                {
                    frmGSXe = new frmGiamSatXe(this, G_ListLaiXe);
                    frmGSXe.Show(this);
                }
            }
            else if (e.Command.Key == "cmdKiemSoatXe_BaoRaHoatDong")
            {
                new frmRaHoatDong(this, 1, G_ListLaiXe).ShowDialog(this);
            }
            else if (e.Command.Key == "cmdKiemSoatXe_BaoNghi")
            {
                new frmRaHoatDong(this, 3, G_ListLaiXe).ShowDialog(this);
            }
            else if (e.Command.Key == "cmdKiemSoatXe_BaoVe")
            {
                new frmRaHoatDong(this, 4, G_ListLaiXe).ShowDialog(this);
            }
            else if (e.Command.Key == "cmdNoiDungTroGiup")
            {
                try
                {
                    string HDSDPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    HDSDPath = String.Format("{0}\\HDSD.pdf", HDSDPath);
                    System.Diagnostics.Process.Start(HDSDPath);
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBoxBA().Show(this, "File hướng dẫn không tồn tại.", "Thông báo lỗi",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            else if (e.Command.Key == "cmdAbout")
            {
                using (frmAbout frmAbout = new frmAbout())
                {
                    frmAbout.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdDSKenh")
            {
                //new frmDSKenh().Show();

            }
            else if (e.Command.Key == "cmdRefresh")
            {
                g_ListSoHieuXe = Xe.GetListSoHieuXe();
            }

            else if (e.Command.Key == "cmdThemKhachAo")
            {
                addPhoneNumToContact();
            }

            else if (e.Command.Key == "cmdDMLaiXe")
            {
                new frmDSNhanVien().Show();
            }

            else if (e.Command.Key == "cmdListKhachDat")
            {
                new frmListKhachDat().Show();
            }

            else if (e.Command.Key == "cmdBaoXeDiDuongDai")
            {
                if (ThongTinCauHinh.FT_ChieuVe_Active)
                    new frmUpdateTrip().ShowDialog();
            }

            else if (e.Command.Key == "cmdBanCo")
            {
                new TaxiApplication.BanCo.frmBanCo().Show();
            }

                #region--------------------------------------Quan Ly Tin Nhan - Phupn-----------------------------------------

            else if (e.Command.Key == "cmdQuanLyTinNhan_Sub")
            {
                new Messenger().ShowDialog();
            }
            //else if (e.Command.Key == "cmdGuiTinNhan")
            //{
            //    new SendMessage().ShowDialog();
            //}
            //else if (e.Command.Key == "cmdTinNhanMau")
            //{
            //    new MessageTemplate().ShowDialog();
            //}
            //--------------------------------------LAYOUT - Phupn-----------------------------------------
            else if (e.Command.Key == "cmdLuuCauHinhHienThi")
            {
                if (gridLayout != null)
                {
                    if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiChoGiaiQuyet")
                    {
                        gridLayout.setLayout(gridDienThoai.GetLayout().LayoutString);
                        gridDienThoai.LoadLayout(gridLayout.getLayout(gridDienThoai.GetLayout()));
                    }
                    else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                    {
                        gridLayout.setLayout(gridCuocGoi_KetThuc.GetLayout().LayoutString);
                        gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                    }
                }
            }
            else if (e.Command.Key == "cmdMacDinh")
            {
                if (gridLayout != null)
                {
                    if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiChoGiaiQuyet")
                    {
                        ComponentResourceManager resources =
                            new ComponentResourceManager(typeof (frmDieuHanhDienThoaiNEWCP_V3));
                        gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                        gridDienThoai.LoadLayout(gridLayout.getLayout(gridDienThoai.GetLayout()));
                    }
                    else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                    {
                        ComponentResourceManager resources =
                            new ComponentResourceManager(typeof (frmDieuHanhDienThoaiNEWCP_V3));
                        gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                        gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                    }
                }
            }
                #endregion----------------------------------------------------------------------------------
            
                #region Tra cứu thẻ MCC và chốt cơ Sân bay đường dài

            else if (e.Command.Key == "cmdCheckCo")
            {
                using (
                    ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince,
                        G_arrDistrict, G_arrCommune, ""))
                {
                    thongTinSanBay_DuongDai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdDSSanBayDuongDai")
            {
                //using (DSCuocDuongDai_SanBay dSCuocDuongDai_SanBay = new DSCuocDuongDai_SanBay(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
                //{
                //    dSCuocDuongDai_SanBay.ShowDialog();
                //}
            }
            else if (e.Command.Key == "cmdTraCuuMCC")
            {
                //using (TraCuuTheMCC traCuuTheMCC = new TraCuuTheMCC())
                //{
                //    traCuuTheMCC.ShowDialog();
                //}
            }

            #endregion
        }

        /// <summary>
        /// xu ly toolbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdCuocThueBao")
            {
                frmThongTinNhatKyThueBao frm = new frmThongTinNhatKyThueBao();
                frm.Show();
            }
            else if (e.Command.Key == "cmdTraCuuBangCuoc")
            {
                frmTraCuuBangGiaGoc frm = new frmTraCuuBangGiaGoc();
                frm.Show();
            }

            else if (e.Command.Key == "cmdTinhTienCuoc")
            {
                frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdTraCuuTheMCC")
            {
                new frmMemberCard_Search().ShowDialog();
            }
            else if (e.Command.Key == "cmdTongDai1080")
            {
                using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
                {
                    frmDMDiaDanh.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdChenMotCuocGoi")
            {
                using (
                    frmChenMoiMotCuocDienThoai frmChenMoiMotCuocDienThoai =
                        new frmChenMoiMotCuocDienThoai(g_LinesDuocCapPhep, g_ListDataAutoComplete))
                {
                    frmChenMoiMotCuocDienThoai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdCheckCo")
            {
                using (
                    ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince,
                        G_arrDistrict, G_arrCommune, ""))
                {
                    thongTinSanBay_DuongDai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdChotCoSBDD_Mini")
            {
                using (frmXeBaoDiSanBay_DuongDai_Mini thongTinSanBay_DuongDai = new frmXeBaoDiSanBay_DuongDai_Mini())
                {
                    thongTinSanBay_DuongDai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdDatHen")
            {
                //new Taxi.GUI.KhachDat.frmKhachDat(g_ListDataAutoComplete).ShowDialog();
                if (gridDienThoai.SelectedItems != null && gridDienThoai.SelectedItems.Count > 0)
                {
                    DatHen();
                    //CuocGoi cuocGoiRow = (CuocGoi)gridDienThoai.SelectedItems[0].GetRow().DataRow;
                    //if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && (cuocGoiRow.XeNhan == null || cuocGoiRow.XeNhan.Length <= 0))
                    //{

                    //}
                    //else
                    //{
                    //    new Taxi.MessageBox.MessageBox().Show(this, "Phải là cuộc gọi mới(Chưa được chuyển sang tổng đài và chưa có thông tin xe nhận-đón)", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Vui lòng chọn cuộc gọi cần đặt hẹn", "Thông báo",
                        Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            else if (e.Command.Key == "cmdTimKiemCuocGoi")
            {
                int TrangThaiCuocGoi = 0;
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
                    TrangThaiCuocGoi = 1;
                else
                    TrangThaiCuocGoi = 2;

                new Taxi.GUI.TimKiemCuocGoi(g_TimeServer, g_LinesDuocCapPhep, TrangThaiCuocGoi, "4").Show();
            }
           

            //else if (e.Command.Key == "cmdDSSanBayDuongDai")
            //{
            //    new DSCuocDuongDai_SanBay().ShowDialog();
            //}

        }

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                #region Them so dien thoai vao db cong ty

                if (e.Command.Key == "cmdThemSoDienThoai")
                {
                    addPhoneNumToContact();
                }

                #endregion Them so dien thoai vao db cong ty
            }
            if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                if (e.Command.Key == "cmdChon20Dong")
                {
                    g_SoDong = 20;
                    LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                }
                else if (e.Command.Key == "cmdChon50Dong")
                {
                    g_SoDong = 50;
                    LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                }
                else if (e.Command.Key == "cmdChon100Dong")
                {
                    g_SoDong = 100;
                    LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                }
                else if (e.Command.Key == "cmdChuyenCuocGoi")
                {
                    //new MessageBox.MessageBox().Show("");
                    runChuyenCuocGoi();
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (panelTopHelp.Visible == true)
                panelTopHelp.Visible = false;
            else
                panelTopHelp.Visible = true;
        }

        /// <summary>
        /// Hiển thị cuộc đầu tiền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void g_frmInput_HienThiCuocMoiEvent(object sender, EventArgs e)
        {
            if (g_frmInput != null)
            {
                g_frmInput.Dispose();
            } 
            hasNewCallPending = false;
            NhapDuLieuVaoTruyenDi(0);
        }

        #region XU LY HOTKEY

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Down:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex == 3)
                    {

                        if (tabControl1.SelectedIndex == 0)
                        {
                            ctrlListBook_ChoXuLy.ForcusGrid();
                        }
                        else
                        {
                            ctrlListBook_DaKetThuc.ForcusGrid();
                        }
                    }
                    return true;
                case Keys.Control | Keys.Up:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex == 3)
                    {
                        if (tabControl1.SelectedIndex == 0)
                        {
                            ctrlDanhSachXeChieuVe_ChoXuLy.ForcusGrid();
                        }
                        else
                        {
                            ctrlDanhSachXeChieuVe_DaKetThuc.ForcusGrid();
                        }
                    }
                    
                    return true;
                case Keys.Alt | Keys.F4:
                    checkout();
                    return true;
                case Keys.Alt | Keys.S:
                     if (uiTabCuocGoiDangThucHien.SelectedIndex == 3)
                     break;
                    if (g_boolChuyenTabCuocGoiSearch == true)
                        txtSoDT.Focus();
                    return true;
                case Keys.Alt | Keys.D:
                    if (g_boolChuyenTabCuocGoiSearch == true)
                        txtDiaChi.Focus();
                    return true;
                case (Keys.Alt | Keys.D1):
                case (Keys.Alt | Keys.NumPad1):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung1.Checked) chkVung1.Checked = false;
                        else chkVung1.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D2):
                case (Keys.Alt | Keys.NumPad2):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung2.Checked) chkVung2.Checked = false;
                        else chkVung2.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D3):
                case (Keys.Alt | Keys.NumPad3):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung3.Checked) chkVung3.Checked = false;
                        else chkVung3.Checked = true;
                    }
                    return true;
                case (Keys.Alt | Keys.D4):
                case (Keys.Alt | Keys.NumPad4):
                    if (g_boolChuyenTabCuocGoiSearch == true)
                    {
                        if (chkVung4.Checked) chkVung4.Checked = false;
                        else chkVung4.Checked = true;
                    }
                    return true;
                case Keys.Shift | Keys.D1:
                    uiTabCuocGoiDangThucHien.SelectedIndex = 0;
                    return true;
                case Keys.Shift | Keys.D2:
                    uiTabCuocGoiDangThucHien.SelectedIndex = 1;
                    return true;
                case Keys.Shift | Keys.D3:
                    uiTabCuocGoiDangThucHien.SelectedIndex = 2;
                    return true;
                case Keys.Shift | Keys.D4:
                    uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    return true;
                case Keys.F10:
                    new frmMemberCard_Search().ShowDialog();
                    return true;
                case Keys.Control | Keys.H:
                    ctrlListBook_ChoXuLy.ShowCtrlH();
                    return true;
                case Keys.Alt | Keys.X:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    if (tabControl1.SelectedIndex == 0)
                    {
                        ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                    }
                    else
                    {
                        ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                    }
                    return true;
                case Keys.Alt | Keys.C:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    if (tabControl1.SelectedIndex == 0)
                    {
                        ctrlListBook_ChoXuLy.ForcusControl();
                    }
                    else
                    {
                        ctrlListBook_DaKetThuc.ForcusControl();
                    }
                    return true;
                case Keys.Control | Keys.D1:
                case Keys.Control | Keys.NumPad1:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    tabControl1.SelectedIndex = 0;
                    ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                    return true;
                case Keys.Control | Keys.D2:
                case Keys.Control | Keys.NumPad2:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    tabControl1.SelectedIndex = 1;
                    ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                    return true;
                  
            }
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 3)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                        return true;
                    if ( ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                        return true;
                }
                else
                {
                    if (ctrlDanhSachXeChieuVe_DaKetThuc.FindKeyCommand(keyData))
                        return true;
                    if (ctrlListBook_DaKetThuc.FindKeyCommand(keyData))
                        return true;
                }
                if (keyData == (Keys.Control | Keys.Left))
                {
                    tabControl1.SelectedIndex = 0;
                    ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                }
                if (keyData == (Keys.Control | Keys.Right))
                {
                    tabControl1.SelectedIndex = 1;
                    ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int iRowSelect = -1;
            if (keyData == (Keys.Alt | Keys.D1)) // Mo nhap du lieu dong 1
                iRowSelect = 0;
            else if (keyData == (Keys.Alt | Keys.D2)) // Mo nhap du lieu dong 1
                iRowSelect = 1;
            else if (keyData == (Keys.Alt | Keys.D3)) // Mo nhap du lieu dong 1
                iRowSelect = 2;
            else if (keyData == (Keys.Alt | Keys.D4)) // Mo nhap du lieu dong 1
                iRowSelect = 3;
            else if (keyData == (Keys.Alt | Keys.D5)) // Mo nhap du lieu dong 1
                iRowSelect = 4;
            else if (keyData == (Keys.Alt | Keys.D6)) // Mo nhap du lieu dong 1
                iRowSelect = 5;
            else if (keyData == (Keys.Alt | Keys.D7)) // Mo nhap du lieu dong 1
                iRowSelect = 6;
            else if (keyData == (Keys.Alt | Keys.D8)) // Mo nhap du lieu dong 1
                iRowSelect = 7;
            else if (keyData == (Keys.Alt | Keys.D9)) // Mo nhap du lieu dong 1
                iRowSelect = 8;
            else if (keyData == (Keys.Alt | Keys.D0)) // Mo nhap du lieu dong 1
                iRowSelect = 9;

            if (iRowSelect >= 0)
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
                {
                    if (gridDienThoai.RowCount > iRowSelect)
                    {
                        gridDienThoai.Row = iRowSelect;
                        if (g_strUsername.Length <= 0)
                            CheckIn();
                        else
                            NhapDuLieuVaoTruyenDi(iRowSelect);

                    }
                }
                return true;
            }


            else if (keyData == (Keys.F1))
            {
                btnHelp_Click(null, null);
                return true;
            }
            //else if (keyData == (Keys.F3))
            //{
            //    DatHen();
            //    return true;
            //}
            //    //========Tim kiem cuộc gọi
            //else if (keyData == (Keys.F9))
            //{
            //    int TrangThaiCuocGoi = 0;
            //    if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            //        TrangThaiCuocGoi = 1;
            //    else
            //        TrangThaiCuocGoi = 2;

            //    new Taxi.GUI.TimKiemCuocGoi(g_TimeServer, g_LinesDuocCapPhep, TrangThaiCuocGoi, g_LoaiXeMacDinh, g_ListDataAutoComplete).Show();
            //    return true;
            //}

            return false;
        }

        #endregion

        private void txtSoDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkVung1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung2.Focus();
            else if (e.KeyCode == Keys.Up)
                txtDiaChi.Focus();
        }

        private void chkVung2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung3.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung1.Focus();
        }

        private void chkVung3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                chkVung4.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung2.Focus();
        }

        private void chkVung4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                txtSoDT.Focus();
            else if (e.KeyCode == Keys.Up)
                chkVung3.Focus();
        }

        private void txtSoDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
            else if (e.KeyCode == Keys.Down)
                chkVung1.Focus();
            else if (e.KeyCode == Keys.Up)
                txtSoDT.Focus();
        }

        private void chkVung1_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung2_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung3_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void chkVung4_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string soDt = txtSoDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string kenh = "";

            if (chkVung1.Checked) kenh = "1;";
            if (chkVung2.Checked) kenh = kenh + "2;";
            if (chkVung3.Checked) kenh = kenh + "3;";
            if (chkVung4.Checked) kenh = kenh + "4";

            List<CuocGoi> lstCuocGoi = CuocGoi.DIENTHOAI_LayAllCuocGoiChuaGiaiQuyet(kenh, soDt, diaChi);
            gridEX_All.DataSource = null;
            gridEX_All.DataMember = "ListDienThoai";
            gridEX_All.SetDataBinding(lstCuocGoi, "ListDienThoai");
        }
        private void frmDieuHanhDienThoaiNEWCP_V3_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessFastTaxi.ketThuc = true;
            try{
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
                {
                ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress);
               }
            }catch(Exception ex){

            }
               
        }

        #endregion

        #region =========================Grid Event============================

        private void gridDienThoai_DoubleClick(object sender, EventArgs e)
        {
            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi(((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).Position);
                // lua cho dong lua chon dau tien

            }

        }

        private void gridDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            if (gridDienThoai.RowCount > 0)
            {
                if (gridDienThoai.SelectedItems.Count <= 0)
                {
                    gridDienThoai.Row = 0;
                }
                int positionRowSelect = ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).Position;
                bool hasThucHienLenh = false; // dung de xac dinh có thay đổi dữ liệu và gọi update
                gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridDienThoai.SelectedItems != null && gridDienThoai.SelectedItems.Count > 0)
                {
                    CuocGoi cuocGoiRow= ((CuocGoi) gridDienThoai.SelectedItems[0].GetRow().DataRow);

                    #region Xem lịch sử cuốc điều

                    if (e.KeyData == (Keys.Control | Keys.H) && cuocGoiRow.FT_IsFT)
                    {
                        new frmLichSuCuocDieu(cuocGoiRow).ShowDialog();
                        return;
                    }

                    #endregion

                    #region Key Enter

                    if (e.KeyCode == Keys.Enter)
                    {
                        if (g_strUsername.Length <= 0)
                            CheckIn();
                        else
                            NhapDuLieuVaoTruyenDi(positionRowSelect);

                    }
                        #endregion 

                    #region F4|| Space

                    else if ((e.KeyData == Keys.F4 || e.KeyData == Keys.Space) && g_COMPort.Length > 0)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_DANGGOI;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                        try
                        {
                            CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                        }
                        catch (Exception)
                        {
                        }

                        HienThiFormGoiDienThoai(Taxi.Business.Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber,
                            cuocGoiRow.DiaChiDonKhach);
                    }
                    #endregion

                    #region Lệnh Mời khách

                    else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null &&
                            cuocGoiRow.XeNhan.Length > 0)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DAMOI;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận.", LENH_DAMOI),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }

                    }
                    //================ 2 : Gặp xe rồi
                    else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null &&
                            cuocGoiRow.XeNhan.Length > 0)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_GAPXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận.", LENH_GAPXE),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }

                    //không xe xin lỗi khách - điên thoại kết thúc
                    else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                            (cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe ||
                                cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1) &&
                            (cuocGoiRow.XeNhan == null || cuocGoiRow.XeNhan.Length <= 0))
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DAXINLOI;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                            hasThucHienLenh = true;

                            #region Gửi thông báo đã hủy cuốc fastTaxi (không xe)

                            if (cuocGoiRow.FT_IsFT)
                            {
                                SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.KhongXe_DaXinLoi);
                            }

                            #endregion
                        }
                        else
                        {
                            msgDialog.Show(this,
                                string.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và chưa có xe nhận.",
                                    LENH_DAXINLOI),
                                "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }

                    //================ 4 : máy bận
                    else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_MAYBAN;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_MAYBAN), "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }

                    //================ 5 : không liên lạc được với khách
                    else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGLIENLACDUOC;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_KHONGLIENLACDUOC),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }

                    //================ 6 : không nghe máy
                    else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGNGHEMAY;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_KHONGNGHEMAY),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    //================ 7 : không nói gì
                    else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGNOIGI;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_KHONGNOIGI),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    //================ 8 : Hủy xe / Hoãn
                    else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_HUYXE;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;

                        #region Gửi đã Hoãn tới Cho fastTaxi nếu là cuốc của fastTaxi

                        if (cuocGoiRow.FT_IsFT)
                        {
                            SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.Hoan_DaHoan);
                        }

                        #endregion
                    }
                    //================ 9 : Không trực tiếp
                    else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_KOTRUCTIEP;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                    }
                    //================ delete : Thoát cuộc gọi khác
                    else if (e.KeyCode == Keys.Delete)
                    {
                        e.Handled = true;
                       // string address = cuocGoiRow.DiaChiDonKhach;
                        string dialog = msgDialog.Show(
                            string.Format("Cuộc gọi khác {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo",
                            Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                        if (dialog == "Yes")
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.DiaChiDonKhach = cuocGoiRow.DiaChiDonKhach.Length > 0
                                ? cuocGoiRow.DiaChiDonKhach
                                : "delete";
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            cuocGoiRow.KieuCuocGoi = KieuCuocGoi.GoiKhac;
                          
                        }
                        else
                        {
                            return;
                        }
                    }
                    //================ O : Không thấy xe
                    else if (e.KeyCode == Keys.O)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_KOTHAYXE;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                    }
                    //================ T : Truot / Chua
                    else if (e.KeyCode == Keys.T)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_TRUOTCHUA;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                    }
                    //================ M : Đã mời lần 2
                    else if (e.KeyCode == Keys.M)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null &&
                            cuocGoiRow.XeNhan.Length > 0)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DAMOI2;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_DAMOI2),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    //================ D : Đổi xe
                    else if (e.KeyCode == Keys.M)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DOIXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_DOIXE),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    //================ C : Chờ 5 phút
                    else if (e.KeyCode == Keys.C)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_CHOKHACH;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_CHOKHACH), "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    //============== Backspace : xóa lệnh
                    else if (e.KeyCode == Keys.Back)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.LenhDienThoai != "")
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.LenhDienThoai = "";
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        }
                    }
                    else if (e.KeyCode == Keys.G)
                    {
                         hasThucHienLenh = true;
                         cuocGoiRow.LenhDienThoai = LENH_G_GIUCXE;
                         cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    }
                    #endregion

                    #region Nhập xe
                    //================= / : chon nhap xe nhan
                    else if (e.KeyCode == Keys.Divide && Global.MoHinh == MoHinh.TongDaiMini)
                    {
                        hasThucHienLenh = NhapXeNhan(cuocGoiRow, positionRowSelect, "");
                    }
                    //================= * : chon nhap Xe Den diem
                    else if (e.KeyCode == Keys.Multiply && Global.MoHinh == MoHinh.TongDaiMini)
                    {
                        hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", false);
                    } //================= - : chon nhap Xe Don
                    else if (e.KeyCode == Keys.Subtract & Global.MoHinh == MoHinh.TongDaiMini)
                    {
                        hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", false);
                    }
                    #endregion

                    // Lưu địa chỉ vào danh bạ
                    else if (e.KeyCode == Keys.F2)
                    {
                        addPhoneNumToContact();
                    }
                    else if (e.KeyCode == Keys.F3)
                    {
                        DatHen();
                    }
                    //============Gửi tin nhắn
                    else if (e.KeyCode == Keys.G)
                    {
                        if (ThongTinDangNhap.PermissionsFull.Contains(DanhSachQuyen.TagGuiTinNhan))
                        {
                            int KenhVung = cuocGoiRow.Line;
                            if (KenhVung > 0)
                            {
                                string TieuDe = "Tin nhắn gửi từ máy ĐHV số " + g_LinesDuocCapPhep;

                                string NoiDung =
                                    string.Format("Thời điểm gọi : {0}{1} Số điện thoại : {2}{3} Địa chỉ : {4}{5}"
                                        , cuocGoiRow.ThoiDiemGoi.ToShortTimeString(), Environment.NewLine
                                        , cuocGoiRow.PhoneNumber, Environment.NewLine
                                        , cuocGoiRow.DiaChiDonKhach, Environment.NewLine);
                                string TaiKhoan = Users.GetIPByVungKenh(KenhVung.ToString());

                                SendMessage frmMessage = new SendMessage(TieuDe, NoiDung, TaiKhoan);
                                frmMessage.Show();
                            }
                        }
                        else
                        {
                            msgDialog.Show(this, "Bạn không có quyền gửi tin nhắn.", "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        }

                    }

                        #region B : Bản đồ

                    else if (e.KeyData == Keys.B)
                    {
                        new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                    }
                        #endregion

                    else if (e.KeyData == (Keys.Control | Keys.C))
                    {
                        try
                        {
                            GridEXColumn col = gridDienThoai.CurrentColumn;
                            switch (col.DataMember)
                            {
                                case "PhoneNumber":
                                    Clipboard.SetText(cuocGoiRow.PhoneNumber);
                                    break;
                                case "DiaChiDonKhach":
                                    Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            return;
                        }
                    }

                    if (hasThucHienLenh)
                    {
                        cuocGoiRow.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                        bool updateSuccess = false;
                        if (Global.MoHinh == MoHinh.TongDaiMini)
                            updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoiRow);
                        else
                            updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi(cuocGoiRow);

                        if (!updateSuccess)
                        {
                            msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                            return;
                        }
                        else //
                        {
                            if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc ||
                                cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                            {
                                if (cuocGoiRow.FT_IsFT&& cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiKhac)
                                {
                                    SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.TiepNhanHuy);
                                }
                                SapXepLaiIndex(cuocGoiRow);
                                // remove tai luoi
                                g_lstDienThoai.Remove(cuocGoiRow);
                                HienThiTrenLuoi(false, false);

                                //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                                if (bwSync_RemoveCuocGoi != null)
                                    bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                            }
                            else
                            {
                                if (cuocGoiRow.FT_IsFT && cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiTaxi)
                                {
                                    SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.TiepNhanHuy);
                                }
                                TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                                HienThiTrenLuoi(true, false);
                            }
                        }
                    }
                }
            }
        }

        private bool NhapXeDenDiem(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    using (
                        frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriChon();
                            if (frmInput.GetGiaTriNhap().Length > 0)
                                cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    using (
                        frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        int yRow = positionRowSelect*gridDienThoai.RootTable.RowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > gridDienThoai.Height)
                        {
                            yRow = gridDienThoai.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(325, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriNhap();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            //Nếu xe đón không thuộc xe nhận thì tự động nhập xe đón vào xe nhận
                            if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDenDiem))
                            {
                                if (cuocGoiRow.XeNhan.Length <= 0)
                                    cuocGoiRow.XeNhan = cuocGoiRow.XeDenDiem;
                                else
                                    cuocGoiRow.XeNhan += "." + cuocGoiRow.XeDenDiem;
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.",
                    "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }

        private bool NhapXeDon(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    // Hiển thị ô nhập  
                    using (
                        frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow,
                            KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDon = frmInput.GetGiaTriChon();
                            if (frmInput.IsKetThuc())
                            {
                                if (frmInput.GetGiaTriNhap().Length > 0)
                                {
                                    cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                                    cuocGoiRow.XeDenDiem += "." + frmInput.GetGiaTriNhap();
                                }
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                                if (cuocGoiRow.XeDon == "000")
                                {
                                    if (cuocGoiRow.XeNhan.Length <= 0)
                                        cuocGoiRow.XeNhan = "000";
                                    else
                                        cuocGoiRow.XeNhan += ".000";
                                }
                                SapXepLaiIndex(cuocGoiRow);
                                g_lstDienThoai.Remove(cuocGoiRow);
                                HienThiTrenLuoi(false, false);
                            }
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon,
                        g_ListSoHieuXe, true, value);
                    int yRow = positionRowSelect*gridDienThoai.RootTable.RowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > gridDienThoai.Height)
                    {
                        yRow = gridDienThoai.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(340, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        cuocGoiRow.XeDon = frmInput.GetGiaTriNhap();
                        if (frmInput.IsKetThuc())
                        {
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                            if (cuocGoiRow.XeDon == "000")
                            {
                                if (cuocGoiRow.XeNhan.Length <= 0)
                                    cuocGoiRow.XeNhan = "000";
                                else
                                    cuocGoiRow.XeNhan += ".000";
                            }
                            else
                            {
                                //Nếu xe đón không thuộc xe nhận thì tự động nhập xe đón vào xe nhận
                                if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDon))
                                {
                                    if (cuocGoiRow.XeNhan.Length <= 0)
                                        cuocGoiRow.XeNhan = cuocGoiRow.XeDon;
                                    else
                                        cuocGoiRow.XeNhan += "." + cuocGoiRow.XeDon;
                                }
                            }
                            SapXepLaiIndex(cuocGoiRow);
                            g_lstDienThoai.Remove(cuocGoiRow);
                            HienThiTrenLuoi(false, false);
                        }
                        return true;
                    }
                }
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.",
                    "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuocGoiRow"></param>
        /// <param name="positionRowSelect"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool NhapXeNhan(CuocGoi cuocGoiRow, int positionRowSelect, string value)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                // Hiển thị ô nhập  
                frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhan,
                    g_ListSoHieuXe, true, value);
                int yRow = positionRowSelect*gridDienThoai.RootTable.RowHeight + 170;
                    // vị trí của dòng đầu tiên cộng thêm.
                if (yRow > gridDienThoai.Height)
                {
                    yRow = gridDienThoai.Height - frmInput.Height;
                }
                frmInput.Location = new Point(625, yRow);
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    cuocGoiRow.XeNhan = frmInput.GetGiaTriNhap();
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    return true;
                }
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.",
                    "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }

        private void SapXepLaiIndex(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                G_IndexKhachVIP--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                G_IndexKhachVang--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                G_IndexKhachBac--;
        }

        private void gridDienThoai_All_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu_Right(e.Row);
        }

        private void gridDienThoai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridDienThoai_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRigthClick.ShowCustomizeDialog();
            }
        }

        private void gridDienThoai_SizingColumn(object sender, SizingColumnEventArgs e)
        {
            // SaveLayoutGrid(gridDienThoai, "gridDienThoai");
        }

        private void gridDienThoai_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridDienThoai.SelectedItems.Count > 0)
                {
                    CuocGoi cuocGoiRow = (CuocGoi) gridDienThoai.SelectedItems[0].GetRow().DataRow;
                    lblSdt.Text = cuocGoiRow.PhoneNumber;
                    lblDiaChi.Text = cuocGoiRow.DiaChiDonKhach;
                    lblDHV.Text = cuocGoiRow.LenhTongDai;
                }
            }
            catch (Exception)
            {
            }

        }

        private void gridDienThoaiNhomKhac_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGoi_KetThuc_RowDoubleClick(object sender, RowActionEventArgs e)
        {

        }

        private void gridCuocGoi_KetThuc_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void gridCuocGoi_KetThuc_FormattingRow_1(object sender, RowLoadEventArgs e)
        {
            //HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGoi_KetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridCuocGoi_KetThuc.SelectedItems != null && gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                CuocGoi cuocGoiRow = (CuocGoi) gridCuocGoi_KetThuc.SelectedItems[0].GetRow().DataRow;
                if (e.KeyData == (Keys.Control | Keys.C))
                {
                    GridEXColumn col = gridCuocGoi_KetThuc.CurrentColumn;
                    switch (col.DataMember)
                    {
                        case "PhoneNumber":
                            Clipboard.SetText(cuocGoiRow.PhoneNumber);
                            break;
                        case "DiaChiDonKhach":
                            Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                            break;
                    }
                }
            }
        }

        private void runChuyenCuocGoi()
        {
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems != null && gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                {
                    CuocGoi cuocGoiRow =
                        (CuocGoi)
                            gridCuocGoi_KetThuc.GetRow(
                                ((GridEXSelectedItem) gridCuocGoi_KetThuc.SelectedItems[0]).Position).DataRow;
                    //TimeSpan timer = g_TimeServer - cuocGoiRow.ThoiDiemGoi;

                    //if (timer.TotalMinutes > 30)
                    //{
                    //    new MessageBox.MessageBox().Show("Chỉ được phép sửa thông tin cuộc gọi kết thúc trong vòng 30 phút", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    return;
                    //}

                    if (new MessageBox.MessageBoxBA().Show(
                        "Bạn có muốn chuyển cuộc gọi: " + cuocGoiRow.DiaChiDonKhach + " không ?", "Thông báo",
                        Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == "Yes")
                    {
                        CuocGoi.DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(cuocGoiRow.IDCuocGoi);
                        gridCuocGoi_KetThuc.Refresh();
                        //gridDienThoai.Refetch();
                    }
                }
            }
        }

        private void addPhoneNumToContact()
        {
            if (gridDienThoai.SelectedItems.Count <= 0) return;
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
            CuocGoi cuocGoi = (CuocGoi) ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).GetRow().DataRow;
            bool isAdd = true;
            if (DanhBaCongTy.GetDanhBa(cuocGoi.PhoneNumber).Length > 0)
            {
                isAdd = false;
                //msgDialog.Show(this, String.Format("Số điện thoại [{0} - {1}] này đã tồn tại. Bạn cần xóa đi để thêm lại.", cuocGoi.PhoneNumber, cuocGoi.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //return;
            }
            new frmDanhBaCongTy(new DanhBaCongTy(cuocGoi.PhoneNumber, "", cuocGoi.DiaChiDonKhach), isAdd).Show();

            //if (msgDialog.Show(this, String.Format("Bạn có đồng ý đưa số điện thoại [{0} - {1}] vào danh bạ số điện thoại công ty không?", cuocGoi.PhoneNumber, cuocGoi.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
            //{
            //    DanhBaCongTy objDanhBaCongTy = new DanhBaCongTy(cuocGoi.PhoneNumber, "", cuocGoi.DiaChiDonKhach);
            //    if (objDanhBaCongTy.Insert())
            //    {

            //        msgDialog.Show(this, "Thêm mới vào danh bạ công ty thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
            //        return;
            //    }
            //    else
            //    {

            //        msgDialog.Show(this, "Lỗi thêm mới vào danh bạ công ty", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
            //        return;
            //    }

            //}
        }

        private void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            try
            {
                if (gridDienThoai.SelectedItems.Count <= 0 && gridDienThoai.RowCount > 0)
                {
                    gridDienThoai.Row = 0;
                }
                cuocGoi = (CuocGoi) gridDienThoai.GetRow(iRowPosition).DataRow;
                var vungCurrent = int.Parse(cuocGoi.Vung.ToString());
                //Luu lại kinh độ và vĩ độ cũ để check xe có thay đổi vị trí  không
                double GPS_KinhDo_Old = cuocGoi.GPS_KinhDo;
                double GPS_ViDo_Old = cuocGoi.GPS_ViDo;

                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).GetRow();
                // Lay lai file anh hien tai 
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Tan;
                rowSelect.RowStyle = RowStyle;
                //End - Thu doi mau            
                g_frmInput = new frmDienThoaiInputDataNew_V3(cuocGoi, g_ListDataAutoComplete, g_CGLimit, G_DMVung_GPS)
                {
                    g_VungMacDinh = g_VungMacDinh,
                    g_ListSoHieuXe = g_ListSoHieuXe
                };
                g_frmInput.HienThiCuocMoiEvent += g_frmInput_HienThiCuocMoiEvent;
                if (g_frmInput.ShowDialog(this) == DialogResult.OK)
                {
                    cuocGoi = g_frmInput.GetCuocGoi;
                    cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                    bool updateSuccess = false;
                    if (Global.MoHinh == MoHinh.TongDaiMini)
                        updateSuccess = CuocGoi.FT_DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoi);
                    else
                        updateSuccess = CuocGoi.FT_DIENTHOAI_UpdateThongTinCuocGoi(cuocGoi);

                    if (!updateSuccess)
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, vui lòng liên hệ với quản trị", "Thông báo",
                            Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else
                    {
                        //Là cuốc FastTaxi
                        if (cuocGoi.FT_IsFT)
                        {
                            //Hủy điều
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhac)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.TiepNhanHuy);
                            }
                            else
                                //Nếu là cuốc gọi Taxi mới thì mới gửi
                                if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                                    cuocGoi.Vung != vungCurrent)
                                {
                                    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.ChuyenSangDam);

                                }else if (cuocGoi.LenhDienThoai == LENH_HUYXE)
                                {
                                    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Hoan_DaHoan);

                                }
                                else if (cuocGoi.XeNhan == "" && cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc && cuocGoi.LenhDienThoai == "" && cuocGoi.LenhTongDai=="")
                                {
                                    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.TiepNhanHuy);
                                }
                        }



                        #region GOI KHIEU NAI

                        //else if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiKhieuNai)
                        //{
                        //    if (cuocGoi.Vung == 11)
                        //    {
                        //        ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
                        //        objPhanAnh.DienThoai = cuocGoi.PhoneNumber;
                        //        objPhanAnh.TenKhachHang = string.Empty;
                        //        objPhanAnh.NoiDung = cuocGoi.DiaChiDonKhach;
                        //        objPhanAnh.NhanVienTiepNhan = string.Empty;

                        //        if (objPhanAnh.InsertCuocGoi(0, 5, 0, cuocGoi.IDCuocGoi) > 0)
                        //        {
                        //            DieuHanhTaxi.UpdateCuocGoiKhieuNaiKetThuc(cuocGoi.IDCuocGoi, objPhanAnh.NoiDung, cuocGoi.MaNhanVienDienThoai);
                        //            g_lstDienThoai.Remove(cuocGoi);
                        //            HienThiTrenLuoi(false, false);
                        //            //DisplayLenGrid(g_lstDienThoai, g_LinesDuocCapPhep);
                        //            return;
                        //        }
                        //        else
                        //        {
                        //            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        //            msgDialog.Show(this, "Không chuyển được dữ liệu sang bộ đàm, xin hãy liên hệ với quản trị", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //            //tra ve mau cu
                        //            RowStyle = new GridEXFormatStyle();
                        //            RowStyle.BackColor = System.Drawing.SystemColors.Window;
                        //            rowSelect.RowStyle = RowStyle;
                        //            return;
                        //        }
                        //    }
                        //}

                        #endregion

                        if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai ||
                            cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            g_lstDienThoai.Remove(cuocGoi);
                            HienThiTrenLuoi(false, false);
                            //Cap nhat vao Mem
                            if (bwSync_RemoveCuocGoi != null)
                                bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoi);
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoi, true); // c?p nh?t theo giá tr? di?n th?ai
                            HienThiTrenLuoi(true, false);
                            //Nếu có thay đổi vị trí thì cập nhật cuộc gọi vào MEM
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && GPS_KinhDo_Old != cuocGoi.GPS_KinhDo &&
                                GPS_ViDo_Old != cuocGoi.GPS_ViDo)
                            {
                                if (bwSync_AddCuocGoi != null)
                                    bwSync_AddCuocGoi.RunWorkerAsync(cuocGoi);
                            }
                        }
                    }
                }
                // Thi?t l?p l?i form
                g_frmInput = null;
                RowStyle = new GridEXFormatStyle();
                //RowStyle.BackColor = Color.White;
                RowStyle.BackColor = Color.White;
                rowSelect.RowStyle = RowStyle;
                if (hasNewCallPending)
                {
                    hasNewCallPending = false;
                    NhapDuLieuVaoTruyenDi(0);
                }

                //setStyleThoiDiemGoi(rowSelect, cuocGoi.ThoiDiemGoi);
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show(ex.Message);
            }

        }

        private int soMayMoiKhach(string vung)
        {
            int mayMKSo = 0;
            List<string> lstDSMayCSDangDangNhap = ThongTinDangNhap.GetDSMayCSDangDangNhap(vung);
            if (lstDSMayCSDangDangNhap != null)
            {
                if (lstDSMayCSDangDangNhap.Count == 1) // chi con một máy
                {
                    // Lay IP cua may CS dang con lam việc
                    string IPMayCSConHoatDong = lstDSMayCSDangDangNhap[0];
                    g_IsMayCS1 = KiemTraXemCoPhaiMayCS1DangLamViec(IPMayCSConHoatDong);
                }
            }
            return mayMKSo;
        }

        /// <summary>
        /// hàm thực hiện kiểm tra xem máy CS còn đang checkin có phải máy số một không
        /// để quyết định chỉ gửi dữ liệu sang máy 1
        /// 
        /// so sanh voi ds máy CS của vùng
        /// </summary>
        /// <param name="IPMayCSConHoatDong"></param>
        /// <returns></returns>
        private bool KiemTraXemCoPhaiMayCS1DangLamViec(string IPMayCSConHoatDong)
        {
            if (g_ListDSMayCS != null && g_ListDSMayCS.Count > 0)
            {
                foreach (string IP in g_ListDSMayCS)
                    if ((IP != IPMayCSConHoatDong) && (IPMayCSConHoatDong.CompareTo(IP) > 0))
                        return false; // máy số 
            }
            return true;
        }

        #endregion

        #region =========================Timer=================================

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Taxi.Business.Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += TimerCapturePhone_Tick;
            TimerCapturePhone.Start();

        }

        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                g_TimeServer = g_TimeServer.AddSeconds(1); // tăng thời gian của TimeServer 
                bool hasCuocGoiMoi = false;
                bool hasCuocGoiThayDoi = false;
                GetAllCuocGoiMoi(g_lstDienThoai, g_LinesDuocCapPhep, g_ThoiDiemNhanDulieuTruoc, ref hasCuocGoiMoi);
                if (hasCuocGoiMoi)
                {
                    g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                    HienThiTrenLuoi(hasCuocGoiMoi, true);
                    //Taxi Phú Bình không hiển thị popup cuộc gọi đến
                    if (Config_Common.HienThiPopup)
                    {
                        // Hien thi form nhap lieu luon khi co cuoc goi moi
                        // neu dang nhap cuoc goi thi hien thi - thong bao co cuoc goi moi.
                        if (g_frmInput != null)
                        {
                            g_frmInput.HienThiThongBaoCoCuocGoiMoi();
                            hasNewCallPending = true;
                        }
                        else //  nguoc lai thi hien thi cuoc dau tien
                        {
                            hasNewCallPending = false;
                            NhapDuLieuVaoTruyenDi(0); // vi tri dau tin cua loi
                        }
                    }
                }

                #region Cuoc Goi Line Khác

                if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Right)
                {
                    g_TimerStep_Khac_Update++;
                    if (g_TimerStep_Khac_Update >= 3)
                    {
                        hasCuocGoiMoi = false;
                        hasCuocGoiThayDoi = false;
                        CapNhapCuocGoiTuTongDai_Khac(ref g_lstDienThoai_Khac, g_LinesDuocCapPhep,
                            g_ThoiDiemNhanDuLieuTruocTongDai_Khac, ref hasCuocGoiThayDoi, ref hasCuocGoiMoi);
                        if (hasCuocGoiThayDoi)
                        {
                            HienThiTrenLuoi_Khac(hasCuocGoiMoi, hasCuocGoiThayDoi);
                            g_ThoiDiemNhanDuLieuTruocTongDai_Khac = g_TimeServer;
                                // ghi nhận lại thời điểm thực hiện lấy dữ liệu
                        }
                        g_TimerStep_Khac_Update = 0;
                    }
                }

                #endregion

                timerMsg++;
                //if (g_MoHinh != MoHinh.TongDaiMini)
                {
                    g_TimerStep++;
                    if (g_TimerStep >= 3) // 3 giây cập nhật một lần
                    {
                        hasCuocGoiMoi = false;
                        hasCuocGoiThayDoi = false;

                        CapNhapCuocGoiTuTongDai(ref g_lstDienThoai, g_LinesDuocCapPhep, g_ThoiDiemNhanDuLieuTruocTongDai,
                            ref hasCuocGoiThayDoi);
                        if (hasCuocGoiThayDoi)
                        {
                            HienThiTrenLuoi(hasCuocGoiMoi, hasCuocGoiThayDoi);
                            g_ThoiDiemNhanDuLieuTruocTongDai = g_TimeServer;
                                // ghi nhận lại thời điểm thực hiện lấy dữ liệu
                        }
                        CapNhatCuocGoiKetThucTuTongDai(ref g_lstDienThoai, g_LinesDuocCapPhep, ref hasCuocGoiMoi);
                        if (hasCuocGoiMoi)
                        {
                            HienThiTrenLuoi(true, true);
                        }

                        if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Right)
                        {
                            CapNhatCuocGoiKetThuc_Khac(ref g_lstDienThoai_Khac, g_LinesDuocCapPhep, ref hasCuocGoiMoi);
                            if (hasCuocGoiMoi)
                            {
                                HienThiTrenLuoi_Khac(false, false);
                            }
                        }
                        g_TimerStep = 0;
                    }
                }
                if (timerMsg >= 10) // 10 giây cập nhật một lần
                {
                    //-------------------------Message------------------------------
                    timerMessage();
                    timerMsg = 0;
                }

                if ((g_boolChuyenTabCuocGoiKetThuc))
                {
                    try
                    {
                        LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                    }
                    catch (Exception ex)
                    {
                    }
                    g_boolChuyenTabCuocGoiKetThuc = false;
                }
                // Xu ly dien thi anh trang thai, va trang thai mau cua chatting

                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
                //g_CountKetThuc = countCGDonDuoc();
                ViewTrangThaiCacCuocGoiO_StatusBar();
            }
            catch (Exception ex)
            {
            }
        }

        // đếm tổng số cuộc gọi đón được.
        private int countCGDonDuoc()
        {
            DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime fromDate = DateTime.Today;
                DateTime toDate = DateTime.Today;
                TimeSpan ca1 = Convert.ToDateTime(dt.Rows[0]["DauCa1"]).TimeOfDay;
                TimeSpan ca2 = Convert.ToDateTime(dt.Rows[0]["KetThucCa1"]).TimeOfDay;
                TimeSpan ca3 = Convert.ToDateTime(dt.Rows[0]["KetThucCa2"]).TimeOfDay;
                TimeSpan tsNow = DateTime.Now.TimeOfDay;
                if (tsNow >= ca1 && tsNow <= ca2)
                {
                    fromDate = fromDate.Add(ca1);
                    toDate = toDate.Add(ca2);
                }
                else if (tsNow >= ca2 && tsNow <= ca3)
                {
                    fromDate = fromDate.Add(ca2);
                    toDate = toDate.Add(ca3);
                }
                else
                {
                    fromDate = fromDate.Add(ca3);
                    toDate = toDate.Add(ca1).AddDays(1);
                }

                return CuocGoi.DIENTHOAI_DemCuocGoiDonDuoc(fromDate, toDate, ThongTinDangNhap.USER_ID);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// hàm thực hiện lấy ra các cuộc gọi của tổng đài mới cập nhật
        /// đẩy thông tin cập nhật vào ds cuốc khách hiện tại
        /// </summary>
        /// <param name="listCuocGoi"></param>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        private void CapNhapCuocGoiTuTongDai(ref List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiThayDoi)
        {
            hasCuocGoiThayDoi = false;
            // Lấy ds cuộc gọi có thay đổi thông tin của tổng đài
            List<CuocGoi> listCuocGoi = CuocGoi.DIENTHOAI_LayDSCuocGoiThayDoiByTongDai_V3(linesDuocCapPhep,
                thoiDiemNhanDulieuTruoc);
            if (listCuocGoi != null && listCuocGoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoi)
                {
                    hasCuocGoiThayDoi = true;
                    TimVaCapNhatCuocGoi(ref listCuocGoiHienTai, objCG, false);
                }
            }
        }

        /// <summary>
        /// ham cap nhat nhung cuoc goi ket thuc phia dien thoai
        /// </summary>
        /// <param name="listCuocGoiHienTai"></param>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="hasCuocGoiMoi"></param>
        private void CapNhatCuocGoiKetThucTuTongDai(ref List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            ref bool hasCapNhat)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += String.Format("{0},", cuocGoi.IDCuocGoi);
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {

                //new MessageBox.MessageBox().Show("linesDuocCapPhep " + linesDuocCapPhep);

                //new MessageBox.MessageBox().Show("listIDCuocGoi " + listIDCuocGoi);

                List<long> listIDDaKetThuc = CuocGoi.DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(listIDCuocGoi,
                    linesDuocCapPhep);
                if (listIDDaKetThuc != null && listIDDaKetThuc.Count > 0)
                {
                    foreach (long idCuocGoi in listIDDaKetThuc)
                    {
                        int index = listCuocGoiHienTai.FindIndex(delegate(CuocGoi cuocGoiT)
                        {
                            return (cuocGoiT.IDCuocGoi == idCuocGoi);
                        });
                        if (index >= 0)
                        {
                            //new MessageBox.MessageBox().Show("index " + index);
                            listCuocGoiHienTai.RemoveAt(index);
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
        }

        /// <summary>
        /// hàm tìm kiểm cuocGoi trong listCuocGoiHienTai
        /// nếu  IsCapNhatCuaDienThoai = false thì cập nhật thông tin của tổng đài
        /// ngược lại cập nhật theo thong tin điện thoại nhập
        /// </summary> 
        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi,
            bool IsCapNhatCuaDienThoai)
        {
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < listCuocGoiHienTai.Count; i++)
                {
                    if (listCuocGoiHienTai[i].IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    if (!IsCapNhatCuaDienThoai) // cap nhat theo du lieu tong dai gui sang
                    {
                        listCuocGoiHienTai[index].TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                        listCuocGoiHienTai[index].LenhTongDai = cuocGoi.LenhTongDai;
                        listCuocGoiHienTai[index].GhiChuTongDai = cuocGoi.GhiChuTongDai;
                        listCuocGoiHienTai[index].MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                        listCuocGoiHienTai[index].LenhDienThoai = cuocGoi.LenhDienThoai;
                        listCuocGoiHienTai[index].GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                        listCuocGoiHienTai[index].MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                        listCuocGoiHienTai[index].XeNhan = cuocGoi.XeNhan;
                        listCuocGoiHienTai[index].XeNhan_TD = cuocGoi.XeNhan_TD;
                        listCuocGoiHienTai[index].ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                        listCuocGoiHienTai[index].FileVoicePath = cuocGoi.FileVoicePath;
                        listCuocGoiHienTai[index].VungGPSID = cuocGoi.VungGPSID;
                        listCuocGoiHienTai[index].GPS_KinhDo = cuocGoi.GPS_KinhDo;
                        listCuocGoiHienTai[index].GPS_ViDo = cuocGoi.GPS_ViDo;
                        listCuocGoiHienTai[index].DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                        listCuocGoiHienTai[index].ThoiDiemCapNhatXeDeCu = cuocGoi.ThoiDiemCapNhatXeDeCu;
                        listCuocGoiHienTai[index].TrangThaiLenh = cuocGoi.TrangThaiLenh;
                        listCuocGoiHienTai[index].MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                        listCuocGoiHienTai[index].MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                        listCuocGoiHienTai[index].XeDenDiem = cuocGoi.XeDenDiem;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach = cuocGoi.XeDenDiemDonKhach;
                        listCuocGoiHienTai[index].Vung = cuocGoi.Vung;
                        listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                        listCuocGoiHienTai[index].PhoneNumber = cuocGoi.PhoneNumber;
                        listCuocGoiHienTai[index].DiaChiTraKhach = cuocGoi.DiaChiTraKhach;
                    }
                    else
                    {
                        if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                        {
                            listCuocGoiHienTai.RemoveAt(index); // remove cuoc goi phia dien thoai ket thuc

                        }
                        else
                        {
                            listCuocGoiHienTai[index].DiaChiTraKhach = cuocGoi.DiaChiTraKhach;
                            listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                            listCuocGoiHienTai[index].LenhDienThoai = cuocGoi.LenhDienThoai;
                            listCuocGoiHienTai[index].GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                            listCuocGoiHienTai[index].TrangThaiLenh = cuocGoi.TrangThaiLenh;
                            listCuocGoiHienTai[index].KieuCuocGoi = cuocGoi.KieuCuocGoi;
                            listCuocGoiHienTai[index].LoaiXe = cuocGoi.LoaiXe;
                            listCuocGoiHienTai[index].SoLuong = cuocGoi.SoLuong;
                            listCuocGoiHienTai[index].Vung = cuocGoi.Vung;
                            listCuocGoiHienTai[index].XeDon = cuocGoi.XeDon;
                            listCuocGoiHienTai[index].XeNhan = cuocGoi.XeNhan;
                            listCuocGoiHienTai[index].XeDenDiem = cuocGoi.XeDenDiem;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// hàm thực hiện kiểm tra xem cuộc gọi đã tồn tại hay chưa.
        /// </summary>
        /// <param name="listCuocGoiHienTai"></param>
        /// <param name="objCG"></param>
        /// <returns></returns>
        private bool KiemTraCuocGoiDaTonTai(List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi)
        {
            bool tonTai = false;
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoiHienTai)
                {
                    if (objCG.IDCuocGoi == cuocGoi.IDCuocGoi)
                    {
                        tonTai = true;
                        break;
                    }
                }
            }
            return tonTai;
        }

        private void timerNhayBaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            if (g_boolNhayMauKhiCoCuocGoiMoi)
            {

                uiTabCuocGoiChoGiaiQuyet.ImageIndex = 0;
                g_boolNhayMauKhiCoCuocGoiMoi = false;
            }
            else
            {
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = 1;
                g_boolNhayMauKhiCoCuocGoiMoi = true;
            }
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            {
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = -1;
                timerNhayBaoCuocGoiMoi.Enabled = false;

            }
        }

        //Sử dụng timer check trang thái internet để check cuộc gọi quá giới hạn luôn
        private void InitTimerCheckInternet()
        {
            g_CGLimit = CuocGoi.DIENTHOAI_CheckCuocGoiLimit();
            //checkInternet();
            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = 300000;
            TimerCapturePhone.Tick += TimerCheckInternet_Tick;
            TimerCapturePhone.Start();
        }

        private void TimerCheckInternet_Tick(object sender, EventArgs eArgs)
        {
            //g_TimerCheckLimitCG++;// 5 phút check số cuộc gọi trong bảng taxioperation (có vượt quá giới hạn ?)
            //if (g_TimerCheckLimitCG >= 300)
            //{
            //g_CGLimit = CuocGoi.DIENTHOAI_CheckCuocGoiLimit();
            //g_TimerCheckLimitCG = 0;
            //}

            //checkInternet();
        }

        private void checkInternet()
        {
            if (Global.checkInternet())
            {
                statusBar.Panels["Internet"].Text = "Có kết nối internet";
                statusBar.Panels["Internet"].Image = global::TaxiApplication.Properties.Resources.Connect;
            }
            else
            {
                statusBar.Panels["Internet"].Text = "Không có kết nối internet";
                statusBar.Panels["Internet"].Image = global::TaxiApplication.Properties.Resources.Disconnect;
            }
        }

        //-----------------------------Send Message--------------------------------------
        private Messenger frmMessenger = new Messenger();
        private int timerMsg = 0;

        private void timerMessage()
        {
            if (ThongTinDangNhap.USER_ID == "")
                return;
            // Kiem tra tin nhan
            if (frmMessenger.IsDisposed == false)
            {

                if (frmMessenger.Visible == false)
                {
                    if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                    {
                        frmMessenger.Show();
                    }
                }
                else
                {
                    frmMessenger.BringToFront();
                }
            }
            else
            {
                frmMessenger = new Messenger();
                if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
                {
                    frmMessenger.Show();
                }
            }
        }

        #endregion

        #region ----------------------Xe nhận - GPS----------------------------

        #endregion

        #region----------------------Address & GPS----------------------------

        public string ConvertAddress(string address)
        {
            string number = null;
            string street = null;
            //string requestID = null;
            string[] arrVar;
            arrVar = address.Split(' ');
            try
            {
                int Num;
                bool isNum = int.TryParse(arrVar[0].Trim(), out Num);
                if (!isNum)
                {
                    number = "10";
                    Num = 0;
                }
                else
                {
                    number = arrVar[0].Trim();
                    Num = 1;
                }

                for (int i = Num; i < arrVar.Length; i++)
                {
                    if (!arrVar[i].Contains("-"))
                    {
                        street = string.Format("{0}{1} ", street, arrVar[i].Trim());
                    }
                    else
                    {
                        break;
                    }
                }
                street = street.Substring(0, street.Length - 1);

                return String.Format("{0},{1},{2}", number, street, "Hà Nội");
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("ConvertAddress " + ex.Message);
                return "*";
            }
        }

        public static string GetGeobyAddressBA2(string address)
        {
            try
            {
                string street = address;
                int count = address.IndexOfAny(new char[] {'-'}, 0, address.Length);
                if (count >= 0)
                {
                    street = address.Substring(0, count);
                }
                return Taxi.Services.Service_Common.GetGeobyAddress(street, ThongTinCauHinh.GPS_TenTinh);

            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("GetGeobyAddressBA2 " + ex.Message);
                return "*";
            }
        }

        private void setResult(string result)
        {
            bool isSuccess = false;
            if (result.Equals("") || result.Equals("1") || result.Equals("2") || result.Equals("5"))
            {
                cuocGoi.DanhSachXeDeCu = "";
                cuocGoi.DanhSachXeDeCu_TD = "";
            }
            else
            {
                string[] arrValues = result.Split(',');
                string[] Values;
                string strSoHieuXe = "";
                //string strToaDoXe = "";
                for (int i = 0; i < arrValues.Length; i++)
                {
                    Values = arrValues[i].Split('-');
                    strSoHieuXe = string.Format("{0}{1}.", strSoHieuXe, Values[0]);
                    //strToaDoXe = string.Format("{0}{1} {2} {3},", strToaDoXe, Values[2], Values[3], Values[1]);
                }
                cuocGoi.DanhSachXeDeCu = strSoHieuXe.Substring(0, strSoHieuXe.Length - 1);
                cuocGoi.DanhSachXeDeCu_TD = result;
            }
            isSuccess = CuocGoi.DIENTHOAI_UpdateDSXeDeCu(cuocGoi);
        }

        #endregion

        #region =========================COM PORT==============================

        private string g_COMPort = "";
        public static frmCallOut frmCalling = new frmCallOut();

        /// <summary>
        /// khoitao mo cong COM
        /// thu vo cac cong COM3, COM4, COM5
        /// </summary>
        private bool KhoiTaoCOMPort()
        {

            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;

            int iLanMo = 0;
            bool IsOpenCOM = false;
            while (!IsOpenCOM && iLanMo < 3)
            {
                string PortName = string.Format("COM{0}", iLanMo + 3);
                try
                {
                    serialPort1.PortName = PortName;
                    serialPort1.Open();
                    IsOpenCOM = true;
                    g_COMPort = PortName;
                    System.Threading.Thread.Sleep(500);
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    IsOpenCOM = false;
                    // new MessageBox.MessageBox().Show("Call : " + ex.Message);
                    g_COMPort = "";
                }
                iLanMo++;
            }
            return IsOpenCOM;
        }

        private void DongCOMPort()
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        /// <summary>
        /// quy goi so dien thoai
        /// sau khi mo  COM thanh cong
        /// </summary>
        /// <param name="SoDienThoai"></param>
        private bool QuaySoGoiDien(string SoDienThoai)
        {
            try
            {
                serialPort1.PortName = g_COMPort; // thu tu cua cong com
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Open();
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    string Call = String.Format("ATDT{0}{1}{2}",
                        Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13),
                        Convert.ToChar(11));
                    serialPort1.Write(Call);
                    return true;

                    System.Threading.Thread.Sleep(1000);
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("QuaySoGoiDien " + ex.Message);

            }
            return false; // khong goi
        }

        /// <summary>
        /// ham thực hiện gửi lệnh kết thúc cuốc gọi , đều đặn 10s sẽ gưi một lần
        /// </summary>    
        private void KetThucCuocGoi()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string Call = String.Format("ATH0{0}{1}", Convert.ToChar(13), Convert.ToChar(11));
                    serialPort1.Write(Call);
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("KetThucCuocGoi " + ex.Message);
            }
        }

        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="DiaChi"></param>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi)
        {
            if (g_COMPort.Length > 0)
            {
                frmCalling.Show();
                frmCalling.Invoke(
                    (MethodInvoker) delegate()
                    {
                        frmCalling.lblSoGoi.Text = String.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                    }
                    );
                frmCalling.Refresh();
                frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);
            }
        }

        #endregion COM PORT

        #region Memory

        /// <summary>
        /// Background worker dong bo du lieu cuoc goi vao mem
        /// </summary>
        private BackgroundWorker bwSync_AddCuocGoi = new BackgroundWorker();

        private BackgroundWorker bwSync_RemoveCuocGoi = new BackgroundWorker();

        /// <summary>
        /// Khởi tạo Mem
        /// </summary>
        private void InitMemService()
        {
            try
            {
                bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Không kết nối được với Service đồng bộ xe", "Thông Báo",
                    MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
        }

        private void bwSync_AddCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCuocGoi_Memory(e.Argument as CuocGoi);
        }

        private void bwSync_RemoveCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveCuocGoi_Memory(e.Argument as CuocGoi);
        }

        /// <summary>
        /// Cập nhật thông tin cuộc gọi vào memory
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void UpdateCuocGoi_Memory(CuocGoi cuocGoi)
        {
            try
            {
                if (cuocGoi.GPS_KinhDo > 0 && cuocGoi.GPS_ViDo > 0 && ThongTinCauHinh.GPS_TrangThai)
                {
                    WCFService_Common.WCFServiceClient.Try(p => p.SaveTaxiOperation(cuocGoi.GPS_KinhDo
                        , cuocGoi.GPS_ViDo,
                        cuocGoi.LoaiXe,
                        cuocGoi.SoLuong,
                        cuocGoi.ThoiDiemGoi,
                        cuocGoi.IDCuocGoi, "", "", cuocGoi.XeNhan));
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Xóa cuộc gọi ở mem, chuyển sang cuộc gọi kết thúc
        /// </summary>
        /// <param name="cuocGoi"></param>
        private void RemoveCuocGoi_Memory(CuocGoi cuocGoi)
        {
            try
            {
                if (cuocGoi.CoGPS && cuocGoi.GPS_KinhDo > 0 && ThongTinCauHinh.GPS_TrangThai)
                {
                    //xóa cuộc gọi ở memory
                    WCFService_Common.WCFServiceClient.Try(p => p.RemoveTaxiOperation(cuocGoi.IDCuocGoi, cuocGoi.Vung,
                        cuocGoi.XeNhan, cuocGoi.XeDon));
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void btnCollspase_Click(object sender, EventArgs e)
        {
            if (!splitContainer.Panel2Collapsed)
            {
                splitContainer.Panel2Collapsed = true;
                btnCollspase.Image = global::TaxiApplication.Properties.Resources.previous;
            }
            else
            {
                splitContainer.Panel2Collapsed = false;
                splitContainer.Refresh();
                btnCollspase.Image = global::TaxiApplication.Properties.Resources.forward;
            }
        }
        //private void gridDienThoai_All_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (gridDienThoai_All.RowCount > 0)
        //    {
        //        int positionRowSelect = ((GridEXSelectedItem)gridDienThoai_All.SelectedItems[0]).Position;
        //        gridDienThoai_All.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
        //        if (gridDienThoai_All.SelectedItems != null && gridDienThoai_All.SelectedItems.Count > 0)
        //        {
        //            CuocGoi cuocGoiRow = (CuocGoi)gridDienThoai_All.SelectedItems[0].GetRow().DataRow;
        //            if ((e.KeyData == Keys.F4 || e.KeyData == Keys.Space) && g_COMPort.Length > 0)
        //            {
        //                cuocGoiRow.LenhDienThoai = LENH_DANGGOI;
        //                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
        //                try
        //                {
        //                    CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
        //                }
        //                catch (Exception)
        //                {
        //                }

        //                HienThiFormGoiDienThoai(Taxi.Business.Configuration.GetDauSoGoiDi() + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach);
        //            }
        //        }
        //    }
        //}
        
        #region Thực hiện tới FastTaxi

        void DoFastTaxi()
        {
            if (ThongTinCauHinh.FT_Active)
            {
                ProcessFastTaxi.TitleLog = "Log gửi lên server-Điện thoại";
                ProcessFastTaxi.DoFastTaxi();
            }
            if (ThongTinCauHinh.FT_ChieuVe_Active)
            {
                cmdStaxiChieuVe1.Visible = Janus.Windows.UI.InheritableBoolean.True;
                uiTabPageTaxiChieuVe.TabVisible = true;
                //BaoXeDiDuongDai1.Visible = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                cmdStaxiChieuVe1.Visible = Janus.Windows.UI.InheritableBoolean.False;
                uiTabPageTaxiChieuVe.TabVisible = false;
                //BaoXeDiDuongDai1.Visible = Janus.Windows.UI.InheritableBoolean.False;
            }
        }
        private void SendFastTaxi(CuocGoi cuocGoiRow, Enum_FastTaxi_Status status)
        {
            if (cuocGoiRow.FT_IsFT)
                ProcessFastTaxi.SendFastTaxi(cuocGoiRow, status);
        }
        #endregion
    }
}