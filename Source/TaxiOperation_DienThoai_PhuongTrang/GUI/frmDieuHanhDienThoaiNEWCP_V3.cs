#region -- using --
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Fields;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Business.QuanTri;
using Taxi.Services.ServiceG5;
using Taxi.Utils;
using System.IO;
using System.Diagnostics;
using Taxi.Business.DM;
using Femiani.Forms.UI.Input;
using System.Configuration;
using System.Collections;
using Janus.Windows.UI.CommandBars;
using Taxi.Entity;
using Taxi.Business.KhachDat;
using Taxi.Services;
using TaxiApplication.Base;
using TaxiOperation_DienThoai.CheckCoDuongDai;
using Taxi.Business.CheckCoDuongDai;
using System.Linq;
using Taxi.Controls.FastTaxis;
using TaxiApplication.GUI.CheckCoDuongDai;
using Taxi.Services.WCFServices;
using Taxi.Utils.Enums;
using TaxiOperation_TongDai.FormFastTaxi;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using System.Collections.Concurrent;
using System.Threading;
using TaxiApplication.Siemens;
using Asterisk.NET.Manager;
using Taxi.Data.BanCo.Entity.DM;
#endregion

namespace Taxi.GUI
{

    public partial class frmDieuHanhDienThoaiNEWCP_V3 : Form
    {
        #region ==========================Init=================================

        #region ------- LENH -------
        private const string XENHAN = "Xe ĐK";
        private const string KenhVung = "NET";
        private const string XEDON = "Xe nhận đón";
        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_DAMOI2 = "Đã mời lần 2";
        private const string LENH_CHOKHACH = "Chờ 5 phút";
        private const string LENH_DANGRA = "Chưa có";
        private const string LENH_DOIXE = "Đổi xe 7C/4C";
        private const string LENH_DANGGOI = "Đang gọi...";
        private const string LENH_GAPXE = "Lên xe";
        private const string LENH_MAYBAN = "Máy bận";
        //private const string LENH_KHONGLIENLACDUOC = "Ko LL được";
        private const string LENH_KHONGLIENLACDUOC = "Từ chối";
        private const string LENH_HUYXE = "Hủy xe/Hoãn";
        private const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        private const string LENH_KOTHAYXE = "Ko thấy xe";
        private const string LENH_TRUOTCHUA = "Rớt điểm";
        private const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        private const string LENH_KHONGNOIGI = "Ko thấy xe";
        private const string LENH_KHONGXE = "Ko xe xin lỗi khách";
        private const string LENH_MOIKHACH = "Mời khách";
        private const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_DAXINLOI = "Đã xin lỗi khách";
        private const string LENH_GIUROI = "Giữ Rồi";
        private const string LENH_6_KIENTRAKHACH = "Kiểm tra khách";
        private const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        private const string LENH_8_RADAUNGO = "Ra đầu ngõ";
        private const string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        private const string LENH_G_GIUCXE = "Khách hối";
        private const string LENH_MATKN = "Mất kết nối";
        private const string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        private const string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        private const string LENH_KTX = "Ko thấy xe";
        private const string LENH_KOLIENLACDUOC = "Khóa máy";
        private const string LENH_THUEBAO = "Thuê bao";
        private const string LENH_THAYXE = "Thấy xe";
        private const string LENH_SPACE_DANGGOI = "Đang gọi";

        #endregion

        #region  ------- Define  -------

        //-----------------------------------------------------------------------------------------
        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();
        private bool g_boolChuyenTabCuocGoiKetThuc = false; // thiet lap de load trong timer
        private bool g_boolChuyenTabCuocGoiSearch = false; // thiet lap de load trong timer
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false; // mac dinh la load luon dau tien
        private Color g_ColorOldTabCuocGoiDangThucHien;
        private int g_iStatus = 0; // Blink stauts
        private System.Windows.Forms.Timer TimerCapturePhone;

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
      //  private CuocGoi cuocGoi;
        private string g_strUsername = "";
        private string g_strFullName = "";
        private string g_IPAddress = "";
        private int g_CountKetThuc = 0; //Dem so cuoc goi don duoc
        private int G_BanKinhTimXe = 0;
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
        // Vùng,Kinh độ,Vĩ độ
        public static Dictionary<int, List<KeyValuePair<float, float>>> G_VungToaDo;

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
        private ConcurrentQueue<CuocGoi> QueueCuocGoi = new ConcurrentQueue<CuocGoi>();
        private string G_LineGop = "";
        private DateTime g_DriverLastUpdate = DateTime.MinValue;

        /// <summary>
        /// Kết nối tổng đài siemens
        /// </summary>
        private CallCapture_OpenSpaceSiemens callCapture_OpenSpaceSiemens;

        #region ==================== Thông số kết nối tổng đài =======================
        private ManagerConnection manager = null;
        /// <summary>
        /// line của Tổng đài PBX IP cho pc này
        /// </summary>
        private string g_lineIPPBX = string.Empty;
        #endregion
        #endregion

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
                    // Lấy cấu hình.
                    Config_Common.LoadConfig_Common();
                    g_VungMacDinh = ConfigurationManager.AppSettings["VungMacDinh"] ?? "1";

                    gridDienThoai.RootTable.Columns["XeDon"].Visible = Global.MoHinh == MoHinh.TongDaiMini;
                    //

                    //lblXeDon_Help.Visible = Global.MoHinh == MoHinh.TongDaiMini;
                    lblXeNhan_Help.Visible = Global.MoHinh == MoHinh.TongDaiMini;
                    lblXeDon_.Visible = Global.MoHinh == MoHinh.TongDaiMini;

                    //  lblSpace
                    G_arrProvince = Province.GetAllProvince();
                    G_arrDistrict = District.GetAllDistrict();
                    G_arrCommune = Commune.GetAllCommune();
                    //Taxi.Business.Configuration.CheckThongTinSDTCongTy();
                    //---------------------------------------------------- 
                    g_ColorOldTabCuocGoiDangThucHien = uiTabCuocGoiDangThucHien.BackColor; // luu lai mau hien tai 
                    Text = Taxi.Business.Configuration.GetCompanyName() + " - Điện thoại viên ";
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    QuanTriCauHinh.IpAddress = g_IPAddress;
                    try
                    {
                        using (DataTable dt = QuanTriCauHinh.G5_GetLines_LoaiXeOfPCDienThoai(g_IPAddress))
                        {
                            if (dt.Rows != null && dt.Rows.Count > 0)
                            {
                                g_LinesDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();

                                if (Global.IsDebug) LogError.WriteLogErrorForDebug(string.Format("g_IPAddress : {0}_{1}", g_LinesDuocCapPhep, g_IPAddress));
                                if (Config_Common.DienThoai_DieuTuDong)
                                {
                                    Config_Common.DienThoai_DieuTuDong = dt.Columns.Contains("G5_Type") &&
                                                                         dt.Rows[0]["G5_Type"].ToString() == "1";
                                }
                                Config_Common.G5_PinMap = dt.Columns.Contains("G5_PinMap") &&
                                                                         dt.Rows[0]["G5_PinMap"].ToString() == "1";

                                if (Config_Common.GopLine || ThongTinCauHinh.GopKenh_TrangThai)
                                    G_LineGop = dt.Rows[0]["LineGop"] == DBNull.Value
                                        ? g_LinesDuocCapPhep
                                        : dt.Rows[0]["LineGop"].ToString();
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
                        LogError.WriteLogError("GetLines_LoaiXeOfPCDienThoai", ex);
                    }
                    if (Config_Common.GopLine)
                        g_LinesDuocCapPhep = G_LineGop;
                    if (Debugger.IsAttached)
                    {
                        g_LinesDuocCapPhep = "101;105;102"; //"101;102;103;104;105;106;107;108;109;101";
                    }

                    if (g_LinesDuocCapPhep.Length > 0)
                    {
                        ThietLapKhungTroGiup();                       

                        g_ListSoHieuXe = Xe.GetListSoHieuXe();
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        g_DriverLastUpdate = g_TimeServer;
                        g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                        g_ThoiDiemNhanDuLieuTruocTongDai = g_TimeServer;
                        g_ThoiDiemNhanDulieuTruoc_Khac = g_TimeServer;
                        g_ThoiDiemNhanDuLieuTruocTongDai_Khac = g_TimeServer;
                      
                        Config_LuoiDieu();
                        LoadAllCuocGoiHienTai(g_LinesDuocCapPhep);

                        LoadDuLieuForAutoComplete();
                        HienThiTrenLuoi(true, true);
                        if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Right)
                        {
                            LoadAllCuocGoiHienTai_Khac(g_LinesDuocCapPhep);
                            HienThiTrenLuoi_Khac(true, true);
                        }

                        if (!CheckIn()) return;
                        //Load danh sách xe và danh sách lái xe vào Dict
                        CommonBL.LoadVehicles();
                        CommonBL.LoadDrivers_Active();

                        if (!string.IsNullOrEmpty(Config_Common.TongDai_ServerSiemens_Address))
                        {
                            if (!Debugger.IsAttached)
                            {
                                callCapture_OpenSpaceSiemens = new CallCapture_OpenSpaceSiemens(g_LinesDuocCapPhep, Config_Common.TongDai_ServerSiemens_Address,
                                    "User", ThongTinDangNhap.LDAP_ADS_Path, ThongTinDangNhap.FULLNAME, "");
                                if (callCapture_OpenSpaceSiemens.IsConnected)
                                {
                                    statusBar.Panels["COM"].Text = "OpenSpace:" + ThongTinDangNhap.LDAP_ADS_Path;
                                }
                                try
                                {
                                    if (Global.IsDebug)
                                    {
                                        new MessageBox.MessageBoxBA().Show(Config_Common.TongDai_ServerSiemens_Address + "-" + ThongTinDangNhap.LDAP_ADS_Path + "-" + callCapture_OpenSpaceSiemens.StatusConnect);
                                    }
                                    System.Diagnostics.Process.Start(@"C:\Program Files\Siemens\HiPath ProCenter\tacmain.exe");
                                    System.Diagnostics.Process.Start(@"C:\Program Files\Unify\OpenScape Desktop Client\Client\Unify.OpenScape.exe");
                                }
                                catch (Exception ex)
                                {
                                    LogError.WriteLogError("OpenSpace:", ex);
                                }
                            }
                            else
                            {
                                callCapture_OpenSpaceSiemens = new CallCapture_OpenSpaceSiemens(g_LinesDuocCapPhep);
                            }
                        }
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi
                        gridDienThoai.Focus();
                        G_DMVung_GPS = LoadDanhMucVung_GPS();
                        G_BanKinhTimXe = ThongTinCauHinh.GPS_BKGioiHan;
                        Action ProcessVung = () =>
                        {
                            // Vùng,Kinh độ,Vĩ độ
                            G_VungToaDo = new Dictionary<int, List<KeyValuePair<float, float>>>();
                            if (G_DMVung_GPS != null)
                            {
                                try
                                {
                                    foreach (var item in G_DMVung_GPS)
                                    {
                                        G_VungToaDo.Add(item.KenhVung, item.ToaDoVung.Split('-').Select(p =>
                                        {
                                            var pi = p.Split(';');
                                            float vd = 0;
                                            float kd = 0;
                                            if (
                                                System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat
                                                    .CurrencyDecimalSeparator == ",")
                                            {
                                                //Thay thế '.' => ','
                                                pi[0] = pi[0].Replace('.', '#');
                                                pi[0] = pi[0].Replace(',', '.');
                                                pi[0] = pi[0].Replace('#', ',');

                                                pi[1] = pi[1].Replace('.', '#');
                                                pi[1] = pi[1].Replace(',', '.');
                                                pi[1] = pi[1].Replace('#', ',');
                                            }
                                            float.TryParse(pi[0], out vd);
                                            float.TryParse(pi[1], out kd);
                                            return new KeyValuePair<float, float>(kd, vd);
                                        }).ToList());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogError.WriteLogError("Lỗi load kênh vùng", ex);
                                }
                              
                            }
                        };
                        ProcessVung();
                        LoadListLaiXe(); 
                        if (Taxi.Business.Configuration.IsMKAsterisk)
                        {
                            // lấy line của PBX IP để phục vụ gọi tự động ra ngoài
                            g_lineIPPBX = AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
                            // - khởi tạo kết nối tổng đài
                            InitPBXIP();
                        }
                        else if (string.IsNullOrEmpty(Config_Common.TongDai_ServerSiemens_Address))
                        {
                            KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                            statusBar.Panels["COM"].Text = " COM: " + g_COMPort;
                        }

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
                    InitMemService();
                    DoFastTaxi();
                    //--------------------------LAYOUT-------------------------------------
                    // loadLayout(gridDienThoai);
                    //--------------------------LAYOUT-------------------------------------
                    gridCuocGoi_KetThuc.RootTable.Columns["XeDenDiem_CB"].Visible = false;
                    // hiển thị thông tin menu nhập thông tin thuê bao tuyến
                    bool HienThiKenh3 = Taxi.Business.Configuration.GetMayTinhNhapThueBao();
                    foreach (UICommand com in uiCommandBar1.Commands)
                    {
                        if (com.Key == "cmdCuocThueBao")
                        {
                            if (HienThiKenh3)
                            {
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
                LogError.WriteLogError("frmDieuHanhDienThoaiNEW_Load 2:", ex);
                if (TimerCapturePhone != null) TimerCapturePhone.Enabled = false;
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
            catch (Exception ex)
            {
                LogError.WriteLogError("loadLayout:", ex);
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
                g_lstDienThoai = CuocGoi.G5_DIENTHOAI_LayAllCuocGoi(linesDuocCapPhep);
            else
                g_lstDienThoai = CuocGoi.G5_DIENTHOAI_LayAllCuocGoiNotFT(linesDuocCapPhep);

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
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
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
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
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
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiTrenLuoi_Khac:", ex);
            }
        }

        #endregion

        /// <summary>
        /// lấy cuốc gọi và truyền về danh sách cuốc mới của staxi
        /// </summary>
        /// <param name="listCuocGoiHienTai"></param>
        /// <param name="linesDuocCapPhep"></param>
        /// <param name="thoiDiemNhanDulieuTruoc"></param>
        /// <param name="hasCuocGoiMoi"></param>
        private void GetAllCuocGoiMoiV2(List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep,
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiMoi, ref List<CuocGoi> listCuocStaxi,
            ref int countStaxi, ref DateTime DateMax ,ref bool hasResfreshCuocGoiMoi)
        {
            try
            {
                hasCuocGoiMoi = false;
                List<CuocGoi> listCuocGoiMoi;
                if (ThongTinCauHinh.FT_Active)
                    listCuocGoiMoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FT(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
                else
                    listCuocGoiMoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiMoi_FTNotFT(linesDuocCapPhep,thoiDiemNhanDulieuTruoc);
                if (listCuocStaxi == null) listCuocStaxi = new List<CuocGoi>();
                if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
                {
                    foreach (CuocGoi objCG in listCuocGoiMoi)
                    {
                        if (!KiemTraCuocGoiDaTonTai(listCuocGoiHienTai, objCG))
                        {
                            if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                                DateMax = objCG.ThoiDiemThayDoiDuLieu;

                            
                            ChenCuocSaoChep(listCuocGoiHienTai, objCG);
                           // .Insert(0, objCG);
                            if (objCG.G5_Type ==Enum_G5_Type.DienThoai&& Config_Common.TongDai_ChuyenCacCuocGoiGanCuocGoiLai)
                                ChuyenCacCuocGoiGanCuocGoiLai(listCuocGoiHienTai, objCG, 0);
                            if (objCG.FT_IsFT)
                            {
                              //  listCuocStaxi.Insert(0, objCG);
                                //listCuocGoiHienTai.Insert(0, objCG);
                                QueueCuocGoi.Enqueue(objCG);
                                countStaxi++;
                            }
                            if (objCG.G5_CopyId == 0) //Không phải là cuốc copy
                            {
                                hasResfreshCuocGoiMoi = true;
                                if (!objCG.FT_IsFT)
                                 hasCuocGoiMoi = true;
                            }
                            else
                            {
                                hasResfreshCuocGoiMoi = true;
                                //if (objCG.BookId == Guid.Empty && objCG.G5_Type == Enum_G5_Type.DieuApp && objCG.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                //{
                                //    G5ServiceSyn.InitTripSyn(objCG.IDCuocGoi, objCG.DiaChiDonKhach,
                                //        (float)objCG.GPS_KinhDo, (float)objCG.GPS_ViDo, objCG.DiaChiTraKhach,
                                //        objCG.GPS_KinhDo_Tra, objCG.GPS_ViDo_Tra, objCG.GhiChuDienThoai,
                                //        (byte)objCG.SoLuong, objCG.G5_CarType, 0, objCG.PhoneNumber, null,0,true);
                                //}
                                
                            }
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
            catch (Exception ex)
            {
                LogError.WriteLogError("GetAllCuocGoiMoiV2",ex);
            }
            
        }

        /// <summary>
        /// Chuyens the cac cuoc goi gan cuoc goi lai.
        /// </summary>
        /// <param name="listCuocHienTai">The list cuoc hien tai.</param>
        /// <param name="cg">The cg.</param>
        /// <param name="viTri">The vi tri.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  10/09/2015   created
        /// </Modified>
        private void ChuyenCacCuocGoiGanCuocGoiLai(List<CuocGoi> listCuocHienTai, CuocGoi cg, int viTri)
        {
            int n = listCuocHienTai.Count;
            int vitricuocgoi = viTri;
            for (int i = viTri + 2; i < n; i++)
            {
                if (listCuocHienTai[i].PhoneNumber == cg.PhoneNumber)
                {
                    cg.GoiLai = true;
                    var cgCurrent = listCuocHienTai[i];
                    listCuocHienTai.Insert(vitricuocgoi, cgCurrent);
                    listCuocHienTai.RemoveAt(i + 1);
                    vitricuocgoi++;
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
                    gridCuocGoi_KetThuc.SetDataBinding(
                        CuocGoi.DIENTHOAI_LayCuocGoiDaGiaiQuyetNotFT(linesChoPhep, soDong),
                        "lstCuocGoiKetThuc");
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadCacCuocGoiKetThuc:", ex);
                new MessageBox.MessageBoxBA().Show("Load Cuộc gọi kết thúc Lỗi ");
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

        private void ChenCuocSaoChep(List<CuocGoi> list, CuocGoi cuocGoi)
        {
            if(list==null) list= new List<CuocGoi>();
            int index = 0;

            if (cuocGoi.G5_CopyId > 0 && cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].IDCuocGoi == cuocGoi.G5_CopyId)
                    {
                        index = i + 1;
                        break;
                    }
                }
            }
         
            list.Insert(index,cuocGoi);
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
        private bool CheckIn()
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
                            return false;
                        }
                    }
                    // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.                   
                    if (!Config_Common.DangNhapNhieuMay &&
                        ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBoxBA().Show(this,
                            "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.",
                            "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return false;
                    }

                    // cap nhat trang thai
                    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi",
                            Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return false;
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
                            return false;
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
                return true;
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
                return true;
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
                if (gridDienThoai.InvokeRequired)
                {
                    gridDienThoai.Invoke(new Action(() => HienThiTrenLuoi(hasCuocGoiMoi, hasThayDoiThongTin)));
                   // HienThiTrenLuoi(hasCuocGoiMoi, hasThayDoiThongTin);
                    return;
                }
                if (hasThayDoiThongTin)
                {
                    var g_RowIndex = gridDienThoai.Row;
                    if (hasCuocGoiMoi)
                    {
                            gridDienThoai.DataSource = null;
                            gridDienThoai.DataMember = "ListDienThoai";
                            gridDienThoai.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                            gridDienThoai.Refresh();
                    }
                    else
                    {
                        gridDienThoai.Refresh();
                        gridDienThoai.Refetch();
                    }
                    if (g_RowIndex < gridDienThoai.RowCount)
                        gridDienThoai.Row = g_RowIndex;
                    else gridDienThoai.Row = gridDienThoai.RowCount - 1;
                }
                else
                {
                    gridDienThoai.Refetch();
                    gridDienThoai.Refresh();
                    //gridDienThoai.MoveToRowIndex(g_RowIndex);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("HienThiTrenLuoi:", ex);
                // new MessageBox.MessageBox().Show("Hiển thị trên lưới ");
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
                RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                row.Cells["ThoiDiemGoi"].FormatStyle = RowStyle;
            }
            else if (timer.TotalMinutes > 20)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.ForeColor = Color.Red;
                RowStyle.FontBold = TriState.True;
                RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
            try
            {
                if (string.IsNullOrEmpty(xeNhan))
                {
                    TimeSpan timer = g_TimeServer - ThoiDiemGoi;
                    if (timer.TotalMinutes >= 0 && timer.TotalMinutes <= 5)
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan);

                    else if (timer.TotalMinutes > 5 && timer.TotalMinutes <= 30)
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.Orange, Color.Orange, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan);

                    else
                        row.Cells["XeNhan_CB"].Image =
                            (Image)
                                Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth,
                                    Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                    Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                }
                else
                {
                    row.Cells["XeNhan_CB"].Image =
                        (Image)
                            Global.ConvertTextToImage(xeNhanTD, xeNhan, xeDeCu, Color.White, Color.Red, ColWidth,
                                Config_Common.LuoiCuocGoi_RowHeight_TiepNhan,
                                Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
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
                LogError.WriteLogError("setStyleXeDenDiem:", ex);
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

                if (!String.IsNullOrEmpty(cuocGoi.XeDungDiem))
                {
                    if (row.Cells["XeDungDiem"] != null)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Red;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["XeDungDiem"].FormatStyle = RowStyle;
                    }
                }
               
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
                        || cuocGoi.LenhDienThoai == LENH_GIUROI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GIUROI
                        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                        || cuocGoi.LenhDienThoai == LENH_GIUROI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GIUROI
                        || cuocGoi.LenhDienThoai == LENH_CHOKHACH || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_CHOKHACH
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                }
                else if (cuocGoi.LenhDienThoai == LENH_KTX || cuocGoi.LenhDienThoai == LENH_KTX_GoiChoKhach)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                }
                else if (cuocGoi.LenhTongDai == LENH_9_TIEPTHIXEKHAC)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DOIXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DOIXE)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.White;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Orange;
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                }
                else if (cuocGoi.LenhTongDai == LENH_HOILAIDIACHI)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Violet;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.LenhDienThoai == LENH_KHACHDAT)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Green;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }
                if (cuocGoi.LenhTongDai == LENH_KHONGXE && cuocGoi.ThoiDiemGoi.AddMinutes(3) <= g_TimeServer)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Red};
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                if (cuocGoi.FT_IsFT)
                {
                    row.Cells["ImageCol"].ImageIndex = 17;
                }
                else
                {
                    row.Cells["ImageCol"].ImageIndex = 1;
                }
                if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp)
                {
                    row.Cells["ImageCol"].ImageIndex = 15;
                }
                //if ((cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi) ||
                //    (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam) ||
                //    (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai))
                //    row.Cells["ImageCol"].ImageIndex = (int) cuocGoi.TrangThaiLenh;
                //else if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.MoiKhachGui)
                //{
                //    row.Cells["ImageCol"].ImageIndex = 3;
                //    //row.Cells["ImageCol"].Image = (Image)ConvertTextToImage(cuocGoi.XeNhan, cuocGoi.DanhSachXeDeCu);
                //}

                if (row.Table.Columns.Contains("SoLanGoi"))
                {
                    if (cuocGoi.SoLanGoi == 1)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Yellow};
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                    }
                    else if (cuocGoi.SoLanGoi >= 2)
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Red};
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                    }
                }

                // neu vung la 0 thi hien thi mau do, de nhan vien chu y
                if (cuocGoi.Vung <= 0)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Tomato};
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["Vung"].FormatStyle = RowStyle;
                }
                else // trar lai mau binh thuong
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle()
                    {
/*RowStyle.BackColor = Color.White;*/
                        BackColor = Color.White
                    };
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["Vung"].FormatStyle = RowStyle;
                }
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.Yellow};
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                         || cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.ForestGreen;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.LightSalmon};
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                // Fast Taxi
                if (cuocGoi.FT_IsFT && cuocGoi.G5_Type!=Enum_G5_Type.ChuyenSangDam)
                {
                    var rowStyle = new GridEXFormatStyle();
                    {
                        rowStyle.BackColor = Color.Yellow;
                        rowStyle.ForeColor = Color.Black;
                        rowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["DiaChiDonKhach"].FormatStyle = rowStyle;
                    }

                }
                else // goi lai va cuoc goi chua chuyen di va so lan goi lon hon hoac bang 2
                    if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai || (cuocGoi.Vung == 0 && cuocGoi.SoLanGoi >= 2))
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {ForeColor = Color.Red};
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["DiaChiDonKhach"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {ForeColor = Color.Black};
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.White};
                        RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() {BackColor = Color.White};
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }
                if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Config_Common.TongDai_MauNen_CuocGoiHoiDam;
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                    row.RowStyle = RowStyle;
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
                    RowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
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
                if (cuocGoi.G5_Type == Enum_G5_Type.ChuyenSangDam) //Chuyển sang điều đàm
                {
                   

                }
                else if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp) //Điều tự động
                {
                    var rowStyle = new GridEXFormatStyle();
                    {
                        rowStyle.BackColor = Color.Yellow;
                        rowStyle.ForeColor = Color.Black;
                        rowStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
                        row.Cells["PhoneNumber"].FormatStyle = rowStyle;
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TrangThaiMauChu:", ex);
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
                        || cuocGoi.LenhDienThoai == LENH_GIUROI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GIUROI
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
                LogError.WriteLogError("TrangThaiMauChu_Right:", ex);
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
                LogError.WriteLogError("GetAllCuocGoiDangTheoDoi:", ex);
                new MessageBox.MessageBoxBA().Show("Get Cuộc gọi Lỗi ");
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
                //loadLayout(gridDienThoai);
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
                    LogError.WriteLogError("cmdNoiDungTroGiup:", ex);
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
            else if (e.Command.Key == "DanhMucKhachHang")
            {
                new frmDMDanhBaCongTy().Show();
            }
            else if (e.Command.Key == "cmdDanhSachChotCoDuongDai")
            {
                new DSCuocDuongDai_SanBay().Show();
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

            #region Thue Bao Tuyen
            
            else if (e.Command.Key == "cmdThueBaoTuyen_Search")
            {
                new frmTraCuuBangGiaGoc().Show();
            }
            #endregion
            #region Khiếu nại - Phản Ánh
            else if (e.Command.Key == "cmdDSKhieuNai")
            {
                new Taxi.Controls.KhieuNai_PhanAnh.frmDSKhieuNai_PhanAnh().Show();
            }
            else if (e.Command.Key == "cmdThemKhieuNai")
            {
                new Taxi.Controls.KhieuNai_PhanAnh.frmGhiNhanPhanAnh(ThongTinDangNhap.RoleNhanVienPA).ShowDialog();
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
            panelTopHelp.Visible = panelTopHelp.Visible != true;
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
                    gridDienThoai.Focus();
                    return true;
                case Keys.Shift | Keys.D2:
                    uiTabCuocGoiDangThucHien.SelectedIndex = 1;
                    gridCuocGoi_KetThuc.Focus();
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
                    if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
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
            Application.ExitThread();
            try
            {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
                {
                    ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmDieuHanhDienThoaiNEWCP_V3_FormClosed:", ex);
            }
        }

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


        #endregion

        #region =========================Grid Event============================

        #region -------------------- lưới điều điện thoại ---------------------

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

            var msgDialog = new Taxi.MessageBox.MessageBoxBA();
            if (gridDienThoai.RowCount > 0)
            {
                if (gridDienThoai.SelectedItems.Count <= 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        gridDienThoai.Row = 0;
                    }
                    else
                    {
                        gridDienThoai.Row = gridDienThoai.RowCount - 1;
                    }
                }

                int positionRowSelect = ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).Position;
                bool hasThucHienLenh = false; // dung de xac dinh có thay đổi dữ liệu và gọi update
                gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridDienThoai.SelectedItems != null && gridDienThoai.SelectedItems.Count > 0)
                {
                    CuocGoi cuocGoiRow = ((CuocGoi) gridDienThoai.SelectedItems[0].GetRow().DataRow);
                    if (cuocGoiRow==null) return;

                    #region **************** Xem lịch sử cuốc điều ****************

                    if (e.KeyData == (Keys.Control | Keys.H) && cuocGoiRow.FT_IsFT)
                    {
                        new frmLichSuCuocDieu(cuocGoiRow).ShowDialog();
                        return;
                    }

                    #endregion

                    #region **************** Key Enter ****************************

                    if (e.KeyCode == Keys.Enter)
                    {
                        if (g_strUsername.Length <= 0)
                            CheckIn();
                        else
                            NhapDuLieuVaoTruyenDi(positionRowSelect);

                    }
                        #endregion 

                    #region **************** F4|| Space || Ctrl + C **************************

                    //else if ((e.KeyData == Keys.F4 || e.KeyData == Keys.Space) && g_COMPort.Length > 0)
                    //{
                    //    cuocGoiRow.LenhDienThoai = LENH_DANGGOI;
                    //    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    //    hasThucHienLenh = true;
                    //    try
                    //    {
                    //        CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        LogError.WriteLogError("Update_ThoiDiemMoiKhach", ex);
                    //    }

                    //    HienThiFormGoiDienThoai(Taxi.Business.Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, false);
                    //}
                    //else if (e.KeyData == (Keys.Control | Keys.Space))
                    //{

                    //    HienThiFormGoiDienThoai(Taxi.Business.Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true);

                    //    cuocGoiRow.LenhDienThoai = LENH_DANGGOI;
                    //    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    //    hasThucHienLenh = true;
                    //    CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                    //}
                    //else if (e.KeyData == (Keys.C))
                    //{
                    //    if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                    //    {
                    //        if (CommonBL.DictDriver.ContainsKey(cuocGoiRow.XeNhan))
                    //        {
                    //            T_NHANVIEN objDriver = CommonBL.DictDriver[cuocGoiRow.XeNhan];
                    //            string soDT = objDriver.DiDong;
                    //            if (!string.IsNullOrEmpty(soDT))
                    //            {
                    //                string text = string.Format("Xe {0} - {1}", cuocGoiRow.XeNhan, objDriver.TenNhanVien);
                    //                HienThiFormGoiDienThoai(soDT, text, true);
                    //            }
                    //            else
                    //            {
                    //                new MessageBox.MessageBox().Show("Thông báo", string.Format("Lái xe {0}-{1} chưa có thông tin số điện thoại", cuocGoiRow.XeNhan, objDriver.TenNhanVien), MessageBox.MessageBoxButtons.OK);
                    //            }
                    //        }
                    //        else
                    //        {
                    //            new MessageBox.MessageBox().Show("Thông báo", string.Format("Hiện tại không có lái xe nào chạy xe {0}", cuocGoiRow.XeNhan), MessageBox.MessageBoxButtons.OK);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        new MessageBox.MessageBox().Show("Thông báo", string.Format("Không gọi được. Chưa có xe nhận"), MessageBox.MessageBoxButtons.OK);
                    //    }
                    //}
                    #endregion

                    #region **************** Tập lệnh xử lý ***********************

                    #region ---------- 1:Đã mời ---------

                    else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan) &&
                            cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DAMOI;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format(
                                    "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm. và đã có xe nhận.",
                                    LENH_DAMOI),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }

                    }
                    #endregion

                    #region ---------- 2:Gặp xe  ----------
                    //================ 2 : Gặp xe rồi
                    else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan) &&
                            cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_GAPXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                            G5ServiceSyn.SendCatchUserSyn(cuocGoiRow.BookId);
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format(
                                    "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã chuyển sang {1} có {2}.",
                                    LENH_GAPXE,KenhVung, XENHAN),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region ---------- 3:Không xe xin lỗi khách  ----------

                    else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam &&
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
                                string.Format(
                                    "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và chưa có {1}.",
                                    LENH_DAXINLOI, XENHAN),
                                "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK,
                                Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- 4:Máy bận  ----------
                    //================ 4 : máy bận
                    else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_MAYBAN;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã chuyển sang {1}.", LENH_MAYBAN, KenhVung),
                                "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- 5:không liên lạc được khách  ----------
                    //================ 5 : không liên lạc được với khách
                    else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGLIENLACDUOC;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã chuyển sang {1}.",
                                    LENH_KHONGLIENLACDUOC, KenhVung),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- 6:Không nghe máy  ----------
                    //================ 6 : không nghe máy
                    else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGNGHEMAY;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.",
                                    LENH_KHONGNGHEMAY),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- 7:Không nói gì  ----------
                    //================ 7 : không nói gì
                    else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_KHONGNOIGI;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã chuyển sang {1}.",
                                    LENH_KHONGNOIGI, KenhVung),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region ---------- 8:Hủy xe/Hoãn ----------
                    //================ 8 : Hủy xe / Hoãn
                    else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                    {
                        string dialog = msgDialog.Show(
                            string.Format("Lệnh {1} {0}...?", cuocGoiRow.DiaChiDonKhach, LENH_G_GIUCXE), "Thông báo",
                            Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                        if (dialog == "Yes")
                        {
                            cuocGoiRow.LenhDienThoai = LENH_G_GIUCXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;

                            #region Gửi đã Hoãn tới Cho fastTaxi nếu là cuốc của fastTaxi

                            if (cuocGoiRow.FT_IsFT)
                            {
                                SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.Hoan_DaHoan);
                            }

                            #endregion

                            // Gửi hủy cho lái xe
                            G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId);
                        }
                        else
                        {
                            return;
                        }
                    }
                    #endregion

                    #region  ---------- 9:Giữ rồi ----------
                    //================ 9 : Không trực tiếp thay thế bằng lệnh Giữ rồi.
                    else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_GIUROI;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.", LENH_MAYBAN),
                                "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- Delete:Thoát cuốc  ----------
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
                            // Gửi hủy cho lái xe

                            if (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp && !string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                                G5ServiceSyn.SendConfirmDone(cuocGoiRow.BookId);
                            else
                                G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId);
                        }
                        else
                        {
                            return;
                        }
                    }
                    #endregion

                    #region  ---------- Comment O:Không thấy xe ----------
                    //================ O : Không thấy xe
                    //else if (e.KeyCode == Keys.O)
                    //{
                    //    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                    //    {
                    //        cuocGoiRow.LenhDienThoai = LENH_KOTHAYXE;
                    //        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    //        hasThucHienLenh = true;
                    //    }
                    //    else
                    //    {
                    //        msgDialog.Show(this,
                    //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.", LENH_MAYBAN),
                    //            "Thông báo",
                    //            Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    }
                    //}
                    #endregion

                    #region  ---------- T:Trượt/Chùa  ----------

                    //================ T : Truot / Chua
                    else if (e.KeyCode == Keys.T)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                        {
                            if (cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp)
                            {
                                if (cuocGoiRow.XeDungDiem != null && cuocGoiRow.XeDungDiem != "")
                                {
                                    string dialog = msgDialog.Show(string.Format("{1} {0}...?", cuocGoiRow.DiaChiDonKhach, LENH_TRUOTCHUA), "Thông báo",
                                        Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                                    if (dialog == "Yes")
                                    {
                                        cuocGoiRow.LenhDienThoai = LENH_TRUOTCHUA;
                                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                        hasThucHienLenh = true;

                                        // Gửi hủy cho lái xe
                                        G5ServiceSyn.SendOperatorCancel(cuocGoiRow.BookId);
                                    }
                                }
                                else
                                {
                                    msgDialog.Show(this,
                                   String.Format("[Lệnh {0}] Cuội gọi phải là cuốc gọi điều App và lái xe đã báo trượt.", LENH_TRUOTCHUA),
                                   "Thông báo",
                                   MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
                                }
                            }
                            else
                            {
                                cuocGoiRow.LenhDienThoai = LENH_TRUOTCHUA;
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                                hasThucHienLenh = true;
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có {1}", LENH_TRUOTCHUA, XENHAN),
                                "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- M:Đã mời lần 2  ----------
                    //================ M : Đã mời lần 2
                    else if (e.KeyCode == Keys.M)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan) &&
                            cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DAMOI2;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format(
                                    "[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có {1}",
                                    LENH_DAMOI2, XENHAN),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- D:Đang ra ----------
                    //================ D : Đang ra//Đổi xe
                    else if (e.KeyCode == Keys.D)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_DANGRA;//LENH_DOIXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.", LENH_DANGRA),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region ---------- C:Thấy xe  ----------
                    //================ C : Thấy xe//Chờ 5 phút
                    else if (e.KeyCode == Keys.C)
                    {
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        {
                            cuocGoiRow.LenhDienThoai = LENH_THAYXE;//LENH_CHOKHACH;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                            hasThucHienLenh = true;
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.",
                                    LENH_THAYXE), "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    #endregion

                    #region  ---------- Backspace:Xóa lệnh  ----------
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
                    #endregion

                    #region  ---------- G:Giục xe  ----------

                    //else if (e.KeyCode == Keys.G)
                    //{
                    //    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                    //    {
                    //        hasThucHienLenh = true;
                    //        cuocGoiRow.LenhDienThoai = LENH_G_GIUCXE;
                    //        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    //    }
                    //    else
                    //    {
                    //        msgDialog.Show(this,
                    //            String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.",
                    //                LENH_CHOKHACH), "Thông báo",
                    //            Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    }
                    //}
                    #endregion

                    #region  ---------- K:ko thấy xe -----------
                    //================ K :ko thấy xe//Thấy xe// Không trực tiếp
                    else if (e.KeyCode == Keys.K)
                    {
                        //if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.G5_Type == Enum_G5_Type.ChuyenSangDam)
                        //{
                        //    cuocGoiRow.LenhDienThoai = LENH_KTX;//LENH_THAYXE; //LENH_KOTRUCTIEP;
                        //    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        //    hasThucHienLenh = true;
                        //}
                        //else
                        //{
                        //    msgDialog.Show(this,
                        //        String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và cuốc điều đàm.",
                        //            LENH_KTX), "Thông báo",
                        //        Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //}
                    }
                    #endregion

                    #region  ---------- L:Không liên lạc được ----------
                    //================ K : Không liên lạc được/Thuê bao//Không liên lạc được.
                    else if (e.KeyCode == Keys.L)
                    {
                        cuocGoiRow.LenhDienThoai = LENH_KOLIENLACDUOC;//LENH_THUEBAO; // LEND_KOLIENLACDUOC;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                        hasThucHienLenh = true;
                    }
                    #endregion

                    #region  ---------- H:Hoàn thành ----------

                    else if (e.KeyCode == Keys.H)
                    {
                        // thực hiện khi có xe nhận
                        if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan) &&
                            cuocGoiRow.G5_Type == Enum_G5_Type.DieuApp)
                        {
                            string dialog = msgDialog.Show(
                                string.Format("Hoàn thành {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo",
                                Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                            if (dialog == "Yes")
                            {
                                cuocGoiRow.LenhDienThoai = "Hoàn thành";
                                cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;

                                hasThucHienLenh = true;
                                // Gửi lệnh mời khách lên server
                                G5ServiceSyn.SendConfirmDone(cuocGoiRow.BookId);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            msgDialog.Show(this,
                                String.Format(
                                    "[Lệnh Hoàn thành] Cuội gọi phải là cuộc gọi taxi và cuốc điều App và đã có xe nhận."),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }

                    }
                    #endregion

                    #region ---------- Space:Đang Gọi  ----------
                    //================ space: đang gọi
                    //else if (e.KeyCode == Keys.Space)
                    //{
                    //    cuocGoiRow.LenhDienThoai = LENH_SPACE_DANGGOI; // LEND_KOLIENLACDUOC;
                    //    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.DienThoai;
                    //    hasThucHienLenh = true;
                    //}
                    #endregion
                    #endregion

                    #region **************** Nhập xe ******************************
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

                    #region **************** Lưu danh bạ ************************
                    // Lưu địa chỉ vào danh bạ
                    else if (e.KeyCode == Keys.F2)
                    {
                        addPhoneNumToContact();
                    }
                    else if (e.KeyCode == Keys.F3)
                    {
                        DatHen();
                    }
                    #endregion

                    #region **************** Gửi tin nhắn ****************
                    //============Gửi tin nhắn
                    else if (e.KeyCode == Keys.G)
                    {
                        if (ThongTinDangNhap.PermissionsFull.Contains(DanhSachQuyen.TagGuiTinNhan))
                        {
                            int KenhVung = cuocGoiRow.Vung;
                            if (KenhVung > 0)
                            {
                                string TieuDe = "Tin nhắn gửi từ máy ĐTV số " + g_LinesDuocCapPhep;

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
                    #endregion

                    #region **************** B : Bản đồ ****************

                    else if (e.KeyData == Keys.B)
                    {
                        new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                    }
                    #endregion

                    #region **************** S : Copy **********************

                    else if (e.KeyData == (Keys.Control | Keys.C))
                    {
                        try
                        {
                            Clipboard.SetText(cuocGoiRow.PhoneNumber);
                            //GridEXColumn col = gridDienThoai.CurrentColumn;
                            //switch (col.DataMember)
                            //{
                            //    case "PhoneNumber":
                            //        Clipboard.SetText(cuocGoiRow.PhoneNumber);
                            //        break;
                            //    case "DiaChiDonKhach":
                            //        Clipboard.SetText(cuocGoiRow.DiaChiDonKhach);
                            //        break;
                            //}
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("Bản đồ", ex);
                            return;
                        }
                    }

                #endregion

                    #region **************** Cập nhật dữ liệu ****************

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
                                if (cuocGoiRow.FT_IsFT && cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiKhac)
                                {
                                    SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.TiepNhanHuy);
                                }
                                SapXepLaiIndex(cuocGoiRow);
                                // remove tai luoi
                                g_lstDienThoai.Remove(cuocGoiRow);
                                HienThiTrenLuoi(false, false);
                                try
                                {
                                    //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                                    if (bwSync_RemoveCuocGoi != null)
                                        bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                                }
                                catch (Exception ex)
                                {
                                    LogError.WriteLogError("bwSync_RemoveCuocGoi", ex);
                                }

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

                    #endregion
                }
            }
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
            catch (Exception ex)
            {
                LogError.WriteLogError("gridDienThoai_SelectionChanged", ex);
            }

        }

        #endregion

        #region -------------------- lưới khác --------------------------------

        private void gridDienThoai_All_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu_Right(e.Row);
        }

        private void gridCuocGoi_KetThuc_RowDoubleClick(object sender, RowActionEventArgs e)
        {

        }

        private void gridCuocGoi_KetThuc_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void gridCuocGoi_KetThuc_FormattingRow_1(object sender, RowLoadEventArgs e)
        {
           HienThiAnhTrangThai_MauChu(e.Row);
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

        #endregion

        #region -------------------- Hàm xử lý --------------------------------

        #region *********************************** Nhập xe đến điểm *******************************

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

        #endregion

        #region  *********************************** Nhập xe đón  ***********************************

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
                                cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
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

        #endregion

        #region  *********************************** Nhập xe nhận ***********************************

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
                    cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
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

        #endregion

        #region  *********************************** Sắp xếp ****************************************

        private void SapXepLaiIndex(CuocGoi cuocGoi)
        {
            if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                G_IndexKhachVIP--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                G_IndexKhachVang--;
            else if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                G_IndexKhachBac--;
        }

        #endregion

        #region  *********************************** Chuyển cuốc gọi ********************************

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

                        LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                        g_boolChuyenTabCuocGoiKetThuc = false;
                    }
                }
            }
        }

        #endregion

        #region  *********************************** Thêm số điện thoại *****************************

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

        #endregion

        #region  *********************************** Truyền đi **************************************

        private void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            try
            {
                if (gridDienThoai.SelectedItems.Count <= 0 && gridDienThoai.RowCount > 0)
                {
                    gridDienThoai.Row = 0;
                }

             var cuocGoi = (CuocGoi) gridDienThoai.GetRow(iRowPosition).DataRow;
                var vungCurrent = int.Parse(cuocGoi.Vung.ToString());
                //Luu lại kinh độ và vĩ độ cũ để check xe có thay đổi vị trí  không
                double GPS_KinhDo_Old = cuocGoi.GPS_KinhDo;
                double GPS_ViDo_Old = cuocGoi.GPS_ViDo;

                if (cuocGoi.Vung==0 && cuocGoi.G5_Type == Enum_G5_Type.DienThoai && !Config_Common.DienThoai_DieuTuDong)
                {
                    cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                }

                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem) gridDienThoai.SelectedItems[0]).GetRow();
                // Lay lai file anh hien tai 
                var rowStyle = new GridEXFormatStyle {BackColor = Color.Tan};
                rowSelect.RowStyle = rowStyle;
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
                    int soLuong = 0;
                    if (cuocGoi.G5_Type == Enum_G5_Type.DieuApp) // điều đàm thì không cho phép sao chép.
                    {
                        soLuong = cuocGoi.SoLuong - 1;
                        cuocGoi.SoLuong = 1;
                    }
                   
                    cuocGoi.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                    if (cuocGoi.GPS_KinhDo == 0 && cuocGoi.GPS_ViDo == 0) //địa chỉ không xác định được thì chuyển sang chế độ điều đàm.
                    {
                        cuocGoi.G5_Type = Enum_G5_Type.ChuyenSangDam;
                    }
                    //// Khởi tạo cuốc ở server rồi update BookId vào db
                    //CommandInitTrip(cuocGoi);

                    bool updateSuccess = false;
                    if (Global.MoHinh == MoHinh.TongDaiMini)
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoi);
                    else
                        updateSuccess = CuocGoi.G5_DIENTHOAI_UpdateThongTinCuocGoi(cuocGoi);

                    if (!updateSuccess)
                    {
                        var msgDialog = new MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, vui lòng liên hệ với quản trị", "Thông báo",
                            MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else
                    {   //khởi tạo cuốc ở server rồi update BookId vào db
                        //if (cuocGoi.BookId == Guid.Empty && cuocGoi.G5_Type == Enum_G5_Type.DieuApp &&
                        //    cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi &&
                        //    cuocGoi.TrangThaiLenh != TrangThaiLenhTaxi.KetThucCuaDienThoai)
                        //{
                        //    G5ServiceSyn.InitTripSyn(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach,
                        //        (float) cuocGoi.GPS_KinhDo, (float) cuocGoi.GPS_ViDo, cuocGoi.DiaChiTraKhach,
                        //        cuocGoi.GPS_KinhDo_Tra, cuocGoi.GPS_ViDo_Tra, cuocGoi.GhiChuDienThoai,
                        //        (byte)cuocGoi.SoLuong, cuocGoi.G5_CarType, 0, cuocGoi.PhoneNumber, null, soLuong);

                        //}



                        #region ++++ Là cuốc FastTaxi(Staxi) ++++

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

                                }
                                else if (cuocGoi.LenhDienThoai == LENH_HUYXE)
                                {
                                    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Hoan_DaHoan);

                                }
                                else if (cuocGoi.XeNhan == "" && cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc &&
                                         cuocGoi.LenhDienThoai == "" && cuocGoi.LenhTongDai == "")
                                {
                                    SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.TiepNhanHuy);
                                }
                        }

                        #endregion


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
                        if (soLuong > 0)
                        {
                            HienThiTrenLuoi(true, true);
                            //G5ServiceSyn.CopyCuocGoi1163353336(cuocGoi.IDCuocGoi,soLuong);
                        }
                    }
                }
                // Thi?t l?p l?i form
                g_frmInput = null;
                rowStyle = new GridEXFormatStyle();
                //RowStyle.BackColor = Color.White;
                rowStyle.BackColor = Color.White;
                rowSelect.RowStyle = rowStyle;
                if (hasNewCallPending)
                {
                    hasNewCallPending = false;
                    NhapDuLieuVaoTruyenDi(0);
                }

                //setStyleThoiDiemGoi(rowSelect, cuocGoi.ThoiDiemGoi);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("NhapDuLieuVaoTruyenDi", ex);
                //new MessageBox.MessageBox().Show(ex.Message);
            }

        }

        #endregion

        #endregion

        #endregion

        #region =========================Timer=================================

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Taxi.Business.Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new System.Windows.Forms.Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += TimerCapturePhone_Tick;
            g_TimeServer = DieuHanhTaxi.GetTimeServer();
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
                List<CuocGoi> lstCuocStaxi = new List<CuocGoi>(); // Danh sách cuốc staxi xuất hiện mới.
                int countCuocStaxi = 0;
                //Lấy cái biến DateMax này làm mốc thời gian lấy dữ liệu tiếp theo.
                //DateMax chính là thời điểm lớn nhất của danh sách các cuộc gọi trong lần timer select dc
                DateTime DateMax = DateTime.MinValue;
                if (G_LineGop != "" &&
                    (Config_Common.GopLine ||
                     (ThongTinCauHinh.GopKenh_TrangThai && g_TimeServer.TimeOfDay >= ThongTinCauHinh.GopKenh_GioBD &&
                      g_TimeServer.TimeOfDay <= ThongTinCauHinh.GopKenh_GioBD)))
                {
                    g_LinesDuocCapPhep = G_LineGop;
                }
                GetAllCuocGoiMoiV2(g_lstDienThoai, g_LinesDuocCapPhep, g_ThoiDiemNhanDulieuTruoc, ref hasCuocGoiMoi,
                    ref lstCuocStaxi, ref countCuocStaxi, ref DateMax, ref hasCuocGoiThayDoi);
                if (hasCuocGoiMoi || countCuocStaxi>0)
                {
                    g_ThoiDiemNhanDulieuTruoc = DateMax;
                   
                    try
                    {
                        //Duyệt xem có cuôc Staxi không.
                        if (countCuocStaxi > 0)
                        {
                            System.Media.SystemSounds.Asterisk.Play();
                            System.Media.SystemSounds.Asterisk.Play();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("hasCuocGoiMoi:", ex);
                    }
                    //Taxi Phú Bình không hiển thị popup cuộc gọi đến
                    // không cho pupop của cuốc staxi đi ngay(cuốc đặt xe thì vẫn cho pupop)
                    if (hasCuocGoiThayDoi)
                    {
                        HienThiTrenLuoi(true, true);
                        hasCuocGoiThayDoi = false;
                    }
                    if (Config_Common.HienThiPopup && hasCuocGoiMoi)
                    {
                       
                        //Tiếng kêu khi có cuốc gọi mới.

                        // Hien thi form nhap lieu luon khi co cuoc goi moi
                        // neu dang nhap cuoc goi thi hien thi - thong bao co cuoc goi moi.
                        CuocGoi cg = g_lstDienThoai[0];
                        if (g_frmInput != null)
                        {
                            hasNewCallPending = true;
                            //if (!(cg.FT_IsFT && cg.LenhDienThoai.ToLower() != "KHÁCH ĐẶT".ToLower()))
                            if (!cg.FT_IsFT)
                                g_frmInput.HienThiThongBaoCoCuocGoiMoi();
                            else hasNewCallPending = false;
                        }
                        else //  nguoc lai thi hien thi cuoc dau tien
                        {

                            hasNewCallPending = false;
                            //Nếu là cuốc staxi thì không cần hiển thị pupop bên điện thoại.                           
                            //if (!(cg.FT_IsFT && cg.LenhDienThoai.ToLower() != "KHÁCH ĐẶT".ToLower()))
                            if (!cg.FT_IsFT)
                                NhapDuLieuVaoTruyenDi(0); // vi tri dau tin cua loi
                        }
                        // System.Media.SystemSound
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
                        DateMax = DateTime.MinValue;
                        CapNhapCuocGoiTuTongDai_Khac(ref g_lstDienThoai_Khac, g_LinesDuocCapPhep,
                            g_ThoiDiemNhanDuLieuTruocTongDai_Khac, ref hasCuocGoiThayDoi, ref hasCuocGoiMoi, ref DateMax);
                        if (hasCuocGoiThayDoi)
                        {
                            HienThiTrenLuoi_Khac(hasCuocGoiMoi, hasCuocGoiThayDoi);
                            g_ThoiDiemNhanDuLieuTruocTongDai_Khac = DateMax;
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
                        DateMax = DateTime.MinValue;
                        CapNhapCuocGoiTuTongDai(ref g_lstDienThoai, g_LinesDuocCapPhep, g_ThoiDiemNhanDuLieuTruocTongDai,
                            ref hasCuocGoiThayDoi, ref DateMax);
                        if (hasCuocGoiThayDoi)
                        {
                            HienThiTrenLuoi(false, true);
                            g_ThoiDiemNhanDuLieuTruocTongDai = DateMax;
                            hasCuocGoiThayDoi = false;
                            // ghi nhận lại thời điểm thực hiện lấy dữ liệu
                        }
                        CapNhatCuocGoiKetThucTuTongDai(ref g_lstDienThoai, g_LinesDuocCapPhep, ref hasCuocGoiMoi);
                        if (hasCuocGoiMoi)
                        {
                            HienThiTrenLuoi(false, true);
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
                    if (CommonBL.LoadDrivers_Active_LastUpdate())
                    {
                        g_DriverLastUpdate = g_TimeServer;
                    }

                    timerMsg = 0;
                }
                //timerLoadVehicle++;
                //if (timerLoadVehicle >= 60)
                //{
                //    timerLoadVehicle = 0;
                //}

                if ((g_boolChuyenTabCuocGoiKetThuc))
                {
                    try
                    {
                        LoadCacCuocGoiKetThuc(g_LinesDuocCapPhep, g_SoDong);
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("LoadCacCuocGoiKetThuc", ex);
                    }
                    g_boolChuyenTabCuocGoiKetThuc = false;
                }
                // Xu ly dien thi anh trang thai, va trang thai mau cua chatting
                if (hasCuocGoiThayDoi)
                {
                    HienThiTrenLuoi(true, false);
                }
                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
                //g_CountKetThuc = countCGDonDuoc();
                ViewTrangThaiCacCuocGoiO_StatusBar();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("TimerCapturePhone_Tick:", ex);
            }
        }

        /// <summary>
        /// Lấy danh sách xe đề cử
        /// </summary>
        /// <param name="kinhDo"></param>
        /// <param name="viDo"></param>
        private void getXeDeCuByToaDo(double kinhDo, double viDo, string loaiXe, DateTime ThoiDiemGoi, long IDCuocGoi,
            string PhoneNumber, string DiaChiDonKhach, ref string DsXeDeCu, ref string DsXeDeCu_TD)
        {
            try
            {
                string loaiXeGPS = "";
                // string loaiXe = loaiXe;
                int SoXeTraVe = 4 + 1;
                // xử lý loại xe
                if (string.IsNullOrEmpty(loaiXe) || loaiXe.Trim() == "")
                    // neu ko co chon loai xe thi tat ca loai xe           
                    loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS("0,4,7");
                else
                    loaiXeGPS = new Taxi.Business.DM.Xe().LayDanhSachLoaiXe_GPS(loaiXe);
                string dsXeDeCu = string.Empty;
                var ngung = false;
                var soLan = 3;
                do
                {
                    soLan--;
                    try
                    {
                        dsXeDeCu = WCFService_Common.LayDanhSachXeDeCu_ToaDoV2(kinhDo,
                            viDo,
                            ThongTinCauHinh.GPS_MaCungXN,
                            loaiXeGPS,
                            ThongTinCauHinh.GPS_BKGioiHan,
                            true, SoXeTraVe, ThoiDiemGoi, IDCuocGoi,
                            PhoneNumber,
                            DiaChiDonKhach);
                        ngung = true;
                    }
                    catch (Exception ex)
                    {
                        LogError.WriteLogError("RefreshWcf:", ex);
                    }
                    if (soLan <= 0) ngung = true;

                } while (!ngung);
                DsXeDeCu_TD = dsXeDeCu;

                if (String.IsNullOrEmpty(dsXeDeCu))
                    return;
                string[] Values;
                string dsXeDeCu1 = "";
                int trangThai = 0;
                foreach (string strValue in dsXeDeCu.Split(';'))
                {
                    Values = strValue.Split('_');
                    if (Values.Length > 0)
                    {
                        string SHX = Values[0].Substring(0, Values[0].Length);
                        dsXeDeCu1 = string.Format("{0}{1}.", dsXeDeCu1, SHX);

                    }
                }
                if (dsXeDeCu1.LastIndexOf('.') > 0)
                {
                    DsXeDeCu = dsXeDeCu1.Substring(0, dsXeDeCu1.Length - 1);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("getXeDeCuByToaDo", ex);
                DsXeDeCu = "";
                DsXeDeCu_TD = "";
            }
        }

        /// <summary>
        /// Hàm tìm kênh vùng theo tọa đọ
        /// </summary>
        /// <param name="LatDes"></param>
        /// <param name="LngDes"></param>
        /// <returns></returns>
        private int getKenhByDiaChi(float LatDes, float LngDes)
        {
            try
            {
                foreach (var item in G_VungToaDo)
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
                                double vt = (LngDes - x1)/(x2 - x1);
                                if (LatDes < y1 + vt*(y2 - y1))
                                    ++cn;
                            }
                        }
                        if ((cn & 1) > 0)
                        {
                            return item.Key;
                            break;
                        } // 0 if even (out), and 1 if odd (in)
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("getKenhByDiaChi", ex);
            }

            return 1;
        }

        /// <summary>
        /// đếm tổng số cuộc gọi đón được.
        /// </summary>
        /// <returns></returns>
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
            DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiThayDoi, ref DateTime DateMax)
        {
            hasCuocGoiThayDoi = false;
            // Lấy ds cuộc gọi có thay đổi thông tin của tổng đài
            List<CuocGoi> listCuocGoi = CuocGoi.G5_DIENTHOAI_LayDSCuocGoiThayDoiByTongDai(linesDuocCapPhep,thoiDiemNhanDulieuTruoc);
            if (listCuocGoi != null && listCuocGoi.Count > 0)
            {
                foreach (CuocGoi objCG in listCuocGoi)
                {
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
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
                List<long> listIDDaKetThuc = CuocGoi.G5_DIENTHOAI_LayCacIDCuocGoiKetThucByTongDai(listIDCuocGoi,
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
            bool IsCapNhatCuaDienThoai, bool STaxi = false)
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
                    var cuocGoiCurrent = listCuocGoiHienTai[index];
                    if (STaxi)
                    {
                        cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                        cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                        cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                        cuocGoiCurrent.Vung = cuocGoi.Vung;
                        cuocGoiCurrent.FT_KM = cuocGoi.FT_KM;
                        cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                        cuocGoiCurrent.DanhSachXeDeCu_TD = cuocGoi.DanhSachXeDeCu_TD;
                    }
                    else
                    {
                        if (!IsCapNhatCuaDienThoai) // cap nhat theo du lieu tong dai gui sang
                        {
                            cuocGoiCurrent.TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                            cuocGoiCurrent.LenhTongDai = cuocGoi.LenhTongDai;
                            cuocGoiCurrent.GhiChuTongDai = cuocGoi.GhiChuTongDai;
                            cuocGoiCurrent.MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai;
                            cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                            cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                            cuocGoiCurrent.MaNhanVienDienThoai = cuocGoi.MaNhanVienDienThoai;
                            cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                            cuocGoiCurrent.XeNhan_TD = cuocGoi.XeNhan_TD;
                            cuocGoiCurrent.ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                            cuocGoiCurrent.FileVoicePath = cuocGoi.FileVoicePath;
                            cuocGoiCurrent.VungGPSID = cuocGoi.VungGPSID;
                            cuocGoiCurrent.GPS_KinhDo = cuocGoi.GPS_KinhDo;
                            cuocGoiCurrent.GPS_ViDo = cuocGoi.GPS_ViDo;
                            cuocGoiCurrent.DanhSachXeDeCu = cuocGoi.DanhSachXeDeCu;
                            cuocGoiCurrent.ThoiDiemCapNhatXeDeCu = cuocGoi.ThoiDiemCapNhatXeDeCu;
                            cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                            cuocGoiCurrent.MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                            cuocGoiCurrent.MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                            cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                            cuocGoiCurrent.XeDenDiemDonKhach = cuocGoi.XeDenDiemDonKhach;
                            cuocGoiCurrent.Vung = cuocGoi.Vung;
                            cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                            cuocGoiCurrent.PhoneNumber = cuocGoi.PhoneNumber;
                            //G5
                            cuocGoiCurrent.BookId = cuocGoi.BookId;
                            cuocGoiCurrent.LenhLaiXe = cuocGoi.LenhLaiXe;
                            cuocGoiCurrent.GhiChuLaiXe = cuocGoi.GhiChuLaiXe;
                            cuocGoiCurrent.G5_Type = cuocGoi.G5_Type;
                            cuocGoiCurrent.XeDungDiem = cuocGoi.XeDungDiem;
                            cuocGoiCurrent.SaleOffCode = cuocGoi.SaleOffCode;

                        }
                        else
                        {
                            if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                            {
                                listCuocGoiHienTai.RemoveAt(index); // remove cuoc goi phia dien thoai ket thuc

                            }
                            else
                            {
                                cuocGoiCurrent.DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                                cuocGoiCurrent.LenhDienThoai = cuocGoi.LenhDienThoai;
                                cuocGoiCurrent.GhiChuDienThoai = cuocGoi.GhiChuDienThoai;
                                cuocGoiCurrent.TrangThaiLenh = cuocGoi.TrangThaiLenh;
                                cuocGoiCurrent.KieuCuocGoi = cuocGoi.KieuCuocGoi;
                                cuocGoiCurrent.LoaiXe = cuocGoi.LoaiXe;
                                cuocGoiCurrent.SoLuong = cuocGoi.SoLuong;
                                cuocGoiCurrent.Vung = cuocGoi.Vung;
                                cuocGoiCurrent.XeDon = cuocGoi.XeDon;
                                cuocGoiCurrent.XeNhan = cuocGoi.XeNhan;
                                cuocGoiCurrent.XeDenDiem = cuocGoi.XeDenDiem;
                            }
                        }
                    }
                }
                //else
                //{
                //    ChenCuocSaoChep(listCuocGoiHienTai, cuocGoi);
                //    if (cuocGoi.G5_CopyId > 0)
                //    {
                //        if (cuocGoi.BookId == Guid.Empty && cuocGoi.G5_Type == Enum_G5_Type.DieuApp &&
                //                   cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                //        {
                //            G5ServiceSyn.InitTripSyn(cuocGoi.IDCuocGoi, cuocGoi.DiaChiDonKhach,
                //                (float)cuocGoi.GPS_KinhDo, (float)cuocGoi.GPS_ViDo, cuocGoi.DiaChiTraKhach,
                //                cuocGoi.GPS_KinhDo_Tra, cuocGoi.GPS_ViDo_Tra, cuocGoi.GhiChuDienThoai,
                //                (byte)cuocGoi.SoLuong, 0, 0, cuocGoi.PhoneNumber, null,0,true);
                //        }
                       
                //    }
                //}

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
            TimerCapturePhone = new System.Windows.Forms.Timer();
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
        private int timerLoadVehicle = 0;

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
                LogError.WriteLogError("ConvertAddress:", ex);
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
                LogError.WriteLogError("GetGeobyAddressBA2:", ex);
                new MessageBox.MessageBoxBA().Show("GetGeobyAddressBA2 " + ex.Message);
                return "*";
            }
        }

        private void setResult(string result)
        {
            //bool isSuccess = false;
            //if (result.Equals("") || result.Equals("1") || result.Equals("2") || result.Equals("5"))
            //{
            //    cuocGoi.DanhSachXeDeCu = "";
            //    cuocGoi.DanhSachXeDeCu_TD = "";
            //}
            //else
            //{
            //    string[] arrValues = result.Split(',');
            //    string[] Values;
            //    string strSoHieuXe = "";
            //    //string strToaDoXe = "";
            //    for (int i = 0; i < arrValues.Length; i++)
            //    {
            //        Values = arrValues[i].Split('-');
            //        strSoHieuXe = string.Format("{0}{1}.", strSoHieuXe, Values[0]);
            //        //strToaDoXe = string.Format("{0}{1} {2} {3},", strToaDoXe, Values[2], Values[3], Values[1]);
            //    }
            //    cuocGoi.DanhSachXeDeCu = strSoHieuXe.Substring(0, strSoHieuXe.Length - 1);
            //    cuocGoi.DanhSachXeDeCu_TD = result;
            //}
            //isSuccess = CuocGoi.DIENTHOAI_UpdateDSXeDeCu(cuocGoi);
        }

        #endregion

        #region ========================= COM PORT ============================

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
                    LogError.WriteLogError("IsOpenCOM:", ex);
                    IsOpenCOM = false;
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
                LogError.WriteLogError("QuaySoGoiDien:", ex);
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
                LogError.WriteLogError("KetThucCuocGoi:", ex);
                new MessageBox.MessageBoxBA().Show("Kết thúc cuộc gọi lỗi");
            }
        }

        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="DiaChi"></param>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi, bool isPBXIP)
        {
            frmCalling.Show();
            frmCalling.Invoke(
                (MethodInvoker)delegate()
                {
                    frmCalling.lblSoGoi.Text = String.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                }
                );
            frmCalling.Refresh();
            if (g_COMPort.Length > 0)
            {                
                if (!isPBXIP) // khong dung tong dai PBXIP
                {
                    if (g_COMPort.Length > 0)
                    {
                        frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);

                    }
                }
                else
                    frmCalling.Call(manager, g_lineIPPBX, PhoneNumber);
            }
            else if (isPBXIP)
            {
                frmCalling.Call(manager, g_lineIPPBX, PhoneNumber);
            }
        }

        #endregion COM PORT

        #region Tong dai PBX IP

        private void InitPBXIP()
        {
            try
            {
                manager = new ManagerConnection(AsteriskInfo.AST_HOSTNAME, AsteriskInfo.AST_PORT_NUMBER, AsteriskInfo.AST_USERNAME, AsteriskInfo.AST_PASSWORD);
                manager.Login();
                //new MessageBox.MessageBox().Show(string.Format("{0}-{1}-{2}-{3}", AsteriskInfo.AST_HOSTNAME, AsteriskInfo.AST_PORT_NUMBER, AsteriskInfo.AST_USERNAME, AsteriskInfo.AST_PASSWORD));
                statusBar.Panels["COM"].Text += "/PBX-ok";
            }
            catch (Exception ex)
            {
                statusBar.Panels["COM"].Text += "/PBX-err";
                LogError.WriteLogError("InitPBXIP", ex);
            }
        }
        #endregion 

        #region ========================= Memory ==============================

        /// <summary>
        /// Background worker dong bo du lieu cuoc goi vao mem
        /// </summary>
        private BackgroundWorker bwSync_AddCuocGoi = new BackgroundWorker();

        private BackgroundWorker bwSync_RemoveCuocGoi = new BackgroundWorker();

        private BackgroundWorker bwSync_UpdateCuocGoi = new BackgroundWorker();

        /// <summary>
        /// Khởi tạo Mem
        /// </summary>
        private void InitMemService()
        {
            try
            {
                bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;
                bwSync_UpdateCuocGoi.DoWork += bwSync_UpdateCuocGoi_DoWork;
                bwSync_UpdateCuocGoi.RunWorkerAsync();
                //bwSync_UpdateCuocGoi.RunWorkerAsync()
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("InitMemService:", ex);
                new MessageBox.MessageBoxBA().Show("Không kết nối được với Service đồng bộ xe", "Thông Báo",
                    MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }
        }

        private void bwSync_UpdateCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            // bool updateSuccess = true;
            while (true)
            {
                while (QueueCuocGoi.Count > 0)
                {
                    // updateSuccess = false;
                    var cuocGoi = new CuocGoi();
                    if (QueueCuocGoi.TryDequeue(out cuocGoi))
                    {
                        try
                        {
                            float KinhDo = (float) cuocGoi.GPS_KinhDo;
                            float ViDo = (float) cuocGoi.GPS_ViDo;
                            if (cuocGoi.Vung == 0)
                            {
                                cuocGoi.Vung = getKenhByDiaChi(ViDo, KinhDo);
                            }
                            cuocGoi.Vung = (cuocGoi.Vung <= 0 ? 1 : cuocGoi.Vung);
                            string dsXeDeCu = string.Empty;
                            string dsXeDeCu_TD = string.Empty;
                            getXeDeCuByToaDo(KinhDo, ViDo, cuocGoi.LoaiXe, cuocGoi.ThoiDiemGoi_FT, cuocGoi.IDCuocGoi,
                                cuocGoi.PhoneNumber, cuocGoi.DiaChiDonKhach, ref dsXeDeCu, ref dsXeDeCu_TD);
                            cuocGoi.DanhSachXeDeCu = dsXeDeCu;
                            cuocGoi.DanhSachXeDeCu_TD = dsXeDeCu_TD;
                            cuocGoi.KieuCuocGoi = KieuCuocGoi.GoiTaxi;
                            cuocGoi.SoLuong = (cuocGoi.SoLuong <= 0 ? 1 : cuocGoi.SoLuong);
                            cuocGoi.FT_KM = ProcessFastTaxi.TinhQuangDuong(cuocGoi.FT_Cust_Lat, cuocGoi.FT_Cust_Lng,
                                (float) cuocGoi.GPS_ViDo, (float) cuocGoi.GPS_KinhDo);
                            cuocGoi.DiaChiDonKhach = cuocGoi.DiaChiDonKhach.ToUpperInvariant();
                            cuocGoi.DiaChiTraKhach = cuocGoi.DiaChiTraKhach.ToUpperInvariant();
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoi, true, true);
                            HienThiTrenLuoi(true, true);

                            CuocGoi.DIENTHOAI_UpdateThongTinCuocSTaxi(cuocGoi);

                            #region Send Server

                            SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.ChuyenSangDam);

                            #endregion

                            //  updateSuccess = true;
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError("bwSync_UpdateCuocGoi_DoWork:", ex);
                        }
                        //giảm tải cho cpu.
                        Thread.Sleep(300);
                    }
                }
                //Đợi 2 giây xử lý
                Thread.Sleep(500);
                if (e.Cancel) return;
            }
        }

        private void bwSync_AddCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            //UpdateCuocGoi_Memory(e.Argument as CuocGoi);
        }

        private void bwSync_RemoveCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveCuocGoi_Memory(e.Argument as CuocGoi);
        }

        /// <summary>
        /// Cập nhật thông tin cuộc gọi vào memory
        /// </summary>
        /// <param name="cuocGoi"></param>
        //private void UpdateCuocGoi_Memory(CuocGoi cuocGoi)
        //{
        //    try
        //    {
        //        if (cuocGoi.GPS_KinhDo > 0 && cuocGoi.GPS_ViDo > 0 && ThongTinCauHinh.GPS_TrangThai)
        //        {
        //            WCFService_Common.WCFServiceClient.Try(p => p.SaveTaxiOperation(cuocGoi.GPS_KinhDo
        //                , cuocGoi.GPS_ViDo,
        //                cuocGoi.LoaiXe,
        //                cuocGoi.SoLuong,
        //                cuocGoi.ThoiDiemGoi,
        //                cuocGoi.IDCuocGoi, "", "", cuocGoi.XeNhan));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("UpdateCuocGoi_Memory:", ex);
        //    }
        //}

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
                    WCFService_Common.RemoveTaxiOperation(cuocGoi.IDCuocGoi, cuocGoi.Vung, cuocGoi.XeNhan, cuocGoi.XeDon);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RemoveCuocGoi_Memory:", ex);
            }
        }

        #endregion

        #region ========================= Thực hiện tới FastTaxi ==========================

        private void DoFastTaxi()
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

        private void gridEX_All_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }
    }
}