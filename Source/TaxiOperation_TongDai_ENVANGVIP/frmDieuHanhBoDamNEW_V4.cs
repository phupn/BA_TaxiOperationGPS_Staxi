using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.IO;
using System.Diagnostics;
using Taxi.Business;
using Taxi.Entity;
using Femiani.Forms.UI.Input;
using System.Collections;
using System.Collections.Concurrent;
using Janus.Windows.UI.CommandBars;
using Taxi.Controls;
using System.ComponentModel;
using TaxiOperation_DienThoai.CheckCoDuongDai;
using Taxi.Business.CheckCoDuongDai;
using Taxi.Services;
using System.Linq;
using System.Threading;
using Taxi.Controls.FastTaxis;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.GUI.CheckCoDuongDai;
using Taxi.Services.WCFServices;
using Taxi.Utils.Enums;
using Taxi.Services.FastTaxi_OperationService;
using TaxiOperation_TongDai;
using TaxiOperation_TongDai.FormFastTaxi;
using Timer = System.Windows.Forms.Timer;
using TaxiApplication;
using TaxiApplication.ServiceEnVang;
using Taxi.Data.EnVang;
using Taxi.Controls.BanCo;
using Taxi.Data.BanCo.Entity.MasterData;
using EnVangVIP.Utils.PhatAmThanh;
using TaxiOperation_BanCo.GiamSatXe;
using TaxiOperation_TongDai_ENVANGVIP;
using Taxi.Controls.Configs;
using Taxi.Data.BanCo.Entity.Config;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace Taxi.GUI
{
    public partial class frmDieuHanhBoDamNEW_V4 : Form
    {
        #region ==========================Init=================================
        //------------------LENH TONG DAI ----------------------------------------
        private const string LENH_1_MOIKHACH = "Mời khách";
        private const string LENH_2_KHONGXE_XINLOI1 = "Ko xe lần 1";
        private const string LENH_3_KHONGXE = "Ko xe xl khách";
        private const string LENH_4_HOILAIDC = "Hỏi lại địa chỉ";
        private const string LENH_5_GIUKHACH = "Giữ khách";
        private const string LENH_4_CHUYENKENH = "chuyển kênh";
        private const string LENH_6_KIENTRAKHACH = "Kiểm tra khách";
        private const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        private const string LENH_GAPCHUA = "Gặp chưa?";
        private const string LENH_8_RADAUNGO = "Ra đầu ngõ";
        private const string LENH_9_TIEPTHIXEKHAC = "Tiếp thị 7C/4C";
        //-----------------------Lenh dtv---------------------------------------
        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        //private const string LENH_KHONGLIENLACDUOC = "Ko LL được";
        private const string LENH_KHONGLIENLACDUOC = "Từ chối";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_HUYXE = "Hủy xe";
        private const string LENH_MOIKHACH = "Mời khách";

        private const string LENH_DAMOI2 = "Đã mời lần 2";
        private const string LENH_CHOKHACH = "Chờ 5 phút";
        private const string LENH_DOIXE = "Đổi xe 7C/4C";
        private const string LENH_6_KTRAKHACH = "kiểm tra khách";
        private const string LENH_Hoan = "Hoãn";
        private const string LENH_Truot = "Trượt";
        private const string LENH_G_GIUCXE = "Giục xe";
        private const string LENH_MATKN = "Mất kết nối";
        private const string LENH_HUYXE_HOAN = "Hủy xe/Hoãn";
        private const string LENH_KTX_GoiChoKhach = "Gọi cho khách,không thấy xe";
        private const string LENH_KTX = "Không thấy xe";

        /// <summary>
        /// Cuộc gọi vừa chuyển sang
        /// </summary>
        private List<CuocGoi> g_lstDienThoai_New = new List<CuocGoi>();
        private List<CuocGoi> g_lstDienThoai_New_DaDonKhach = new List<CuocGoi>();
        /// <summary>
        /// Cuộc gọi tổng đài đã tiếp nhận điều
        /// </summary>
        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();
        private List<CuocGoi> g_lstDienThoai_DaDonKhach = new List<CuocGoi>();
        private List<CuocGoi> g_lstCuocGoiKhongXe = new List<CuocGoi>(); // luu nhung cuoc khong xe lan 1, sau X phut thì sẽ hiển thị lên.
        private int g_SoGiayGioiHanKhongXe = 5;
        private DateTime g_TimeServer;
        private List<string> g_ListSoHieuXe;

        private List<CuocGoi> g_lstCuocGoiKetThuc;
        private int g_TimeStep = 0;
        private int g_timerMsg = 0;
        private Timer TimerCapturePhone;
        private string g_strVungsDuocCapPhep = string.Empty;
        private bool g_TabKetThucDuocChon = false; // lua chon cuoc goi ket thuc
        private bool g_boolChuyenTabCuocGoiSearch = false; // thiet lap de load trong timer
        private int g_SoDong = 20;  // so dong hien thi tren luoi cuoc goi ket thuc
        private DateTime g_ThoiDiemLayDuLieuTruoc;
        private DateTime g_ThoiDiemLayDuLieuTruoc_ChuaNhan;
        private DateTime g_ThoiDiemLayDuLieuTruoc_DaDonKhach;
        private int g_iStatus = 0;  // Blink stauts  
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false;
        private string g_strUsername = "";
        private string g_strFullName = "";
        private string g_IPAddress = "";
        //private string g_LoaiXe = "";
        private AutoCompleteEntryCollection g_ListDataAutoComplete = new AutoCompleteEntryCollection();
        private int g_RowIndex = 0;
        private int g_RowIndex_DaDonKhach = 0;
        private int g_CountKetThuc = 0; //Dem so cuoc goi don duoc
        //--------------------------------Message---------------------------------------------------        
        private Messenger frmMessenger = new Messenger();

        //--------------------------------LAYOUT----------------------------------------------------
        private Taxi.Business.GridLayout.GridLayout gridLayout;

        private int g_SoLuongDangNhapCS = 0;    // luu so luong nguoi dang nhap bo phan CS. 10 giay quet mot lan
        private bool g_IsMayCS1 = false;  // luu giá trị là máy CS1 còn đang làm việc
        private List<string> g_ListDSMayCS = new List<string>();
        private int g_Thoat999SoPhutGioiHan;           // so phut gioi han cho phep thoat cuoc
        private bool g_Thoat999TrangThaiTATBAT;         // trang thai tat/bat của thoat cuoc
        private int g_Thoat999SoCuocGioiHan;            // so cuoc goi gioi han duoc phep su dụng 999
        private bool g_IsThoatDuoc999 = false;
        //---------
        private int g_iTimerManHinh = 0;
        private DateTime g_ThoiDiemNhanDuLieuTruoc_ManHinh = DateTime.MinValue;
        private List<ManHinhEntity> g_ListTinNhanManHinh = new List<ManHinhEntity>();

        private int g_MayCSDuocPhanBoTruoc = 0; // Luu may CS da phan bo truoc, may CS gui thong tin sang (0 : tong dai xuly khong gui, 1: gui may mot, 2 : gui may 2)
        private List<long> g_DSCuocDaPhanBoCS = new List<long>();

        public int G_IndexKhachVIP = 0;
        public int G_IndexKhachVang = 0;
        public int G_IndexKhachBac = 0;
        public int G_IndexKHThanThiet = 0;
        private string G_KenhGop = "";
        private List<Province> G_arrProvince;
        private List<District> G_arrDistrict;
        private List<Commune> G_arrCommune;
        private frmGiamSatXe frmGSXe;
        private List<NhanVien> G_ListLaiXe = new List<NhanVien>();
        private frmHienThiBanDo_Mini frm_BanDo;
        
        frmBodamInputData_V3 frmInput;
        public Control_DieuHanhBanCo_BanCo _controlDieuHanhBanCoBanCo;/// <summary>
        /// Lưu thông tin ID của vùng (ID + ID trên GPS)
        /// </summary>
        private Dictionary<int, int> dicVungId_IDGPS;
        /// <summary>
        /// Vùng điều hành ( điểm đỗ)
        /// </summary>
        private Dictionary<int, Vung> dicVung;
        private bool isThemMoi = false;
        private bool isLoadLenhSuccess = false;
        #endregion

        #region Quản lý hiện message confirm

        public Dictionary<string, frmInfo> openedFormInfos = new Dictionary<string, frmInfo>();
        public bool DuocPhepHienMessageKhongCoTripID = false;
        /// <summary>
        /// Quản lý để truyền sang sql nhằm không load những message có message key trong mảng này
        /// </summary>
        public List<string> openedMessageKeys = new List<string>();
        private string G_VungGop = "";
        BackgroundWorker bwProcessMessage = new BackgroundWorker();

        #endregion

        #region =======================Constructor=============================
        public frmDieuHanhBoDamNEW_V4()
        {
            InitializeComponent();
            //if (//!Debugger.IsAttached && 
            //    Global.GridConfig_CuocGoi == Grid_Config.Default)
            //{
            //    splitContainer1.Panel2Collapsed = true;
            //}
            
        }
        #endregion

        #region ====================Load Form-Set Data=========================
        private void bwProcessMessage_Init()
        {
            bwProcessMessage.WorkerSupportsCancellation = true;
            bwProcessMessage.DoWork += bwProcessMessage_DoWork;
        }

        private void bwProcessMessage_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!bwProcessMessage.IsBusy)
                {
                    MessageConfirm message = (MessageConfirm)e.Argument;
                    XuLyMessageKhongCanConfirm(message);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwProcessMessage_DoWork", ex);
            }
        }
        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {
                bwProcessMessage_Init();
                isLoadLenhSuccess = true;
                if (Debugger.IsAttached)
                {
                    cmdCauHinhTapLenh.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                //Chạy cho phép chạy thời gian timer server trên phần mềm.
                Taxi.Controls.FastTaxis.TaxiChieuVe.TaxiReturn_Process.StartTimeServer();
                //#region cấu hình để debug
                Taxi.Controls.FastTaxis.TaxiChieuVe.TaxiReturn_Process.IsDebug = false;
                Taxi.Controls.FastTaxis.ProcessFastTaxi.Debug = false;
                //#endregion
                if (DieuHanhTaxi.CheckConnection())
                {
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();

                    SetCheckMenuDisconnectMobile(!ThongTinCauHinh.GPS_TrangThai);
                    SpeechHelper.Inits(ThongTinCauHinh.FolderAmThanh);
                    Config_Common.LuoiCuocGoi_FontSize_TongDai = 11;
                    Config_Common.LuoiCuocGoi_RowHeight_TongDai =19;
                    //license.CheckThongTinSDTCongTy(ThongTinCauHinh.SoDienThoaiCongTy.Trim());
                    //---------------------------------------------------- 
                    Text = Configuration.GetCompanyName() + " - Điều hành viên ";

                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    //g_LoaiXe = QuanTriCauHinh.GetLoaiXeTheoIPAddress(g_IPAddress);
                    //g_strVungsDuocCapPhep = QuanTriCauHinh.GetVungsOfPCTongDai(g_IPAddress);
                    try
                    {
                        using (DataTable dt = QuanTriCauHinh.GetLines_LoaiXeOfPCTongDai(g_IPAddress))
                        {
                            if (dt.Rows != null && dt.Rows.Count > 0)
                            {
                                g_strVungsDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();
                                if (ThongTinCauHinh.GopKenh_TrangThai)
                                    G_VungGop = dt.Rows[0]["LineGop"] == DBNull.Value ? g_strVungsDuocCapPhep : dt.Rows[0]["LineGop"].ToString();
                            }
                            else
                            {
                                g_strVungsDuocCapPhep = string.Empty;
                                //g_LoaiXeMacDinh = string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    if (Debugger.IsAttached)
                    {
                        g_strVungsDuocCapPhep = "1;2;3;4;5;6;7;8;9;10";
                    }
                    AnHienControl();
                    if (g_strVungsDuocCapPhep.Length > 0)
                    {
                        //Gán biến kiểm tra có được hiện popup cho những message ko cần thiết phải đang đi khách
                        DuocPhepHienMessageKhongCoTripID = DuocPhepHienNhungMessageKhongCoIDCuoiGoi();

                        ThietLapKhungTroGiup();
                        gridCuocGois.Focus();
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        g_ThoiDiemLayDuLieuTruoc = g_TimeServer;
                        g_ThoiDiemLayDuLieuTruoc_ChuaNhan = g_TimeServer;
                        g_ThoiDiemLayDuLieuTruoc_DaDonKhach = g_TimeServer;
                        g_ListSoHieuXe = Xe.GetListSoHieuXe();
                        g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_strVungsDuocCapPhep);

                        LayCauHinhThoatCuoc999();
                        ProcessFastTaxi.GetVehicleGPS();
                        g_ListDSMayCS = QuanTriCauHinh.GetDSMayTinhMoiKhachByVung(this.g_strVungsDuocCapPhep);

                        Config_Common.LoadConfig_Common();
                        CommonBL.WorkflowId = (int)Enum_Workflow.TongDaiVien;
                        LoadAllCuocGoiHienTai(g_strVungsDuocCapPhep);
                        LoadVungDieuHanh();
                        ReloadControlBanCo();
                        gMapsControl.SetPositionConfig();
                        //getNewManHinh();
                        //g_ThoiDiemNhanDuLieuTruoc_ManHinh = g_TimeServer;
                        CheckIn();
                        //LoadDuLieuForAutoComplete();
                        HienThiTrenLuoi(true, true);
                        HienThiTrenLuoi_DaDonKhach(true, true);
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi  
                        
                        if (ThongTinCauHinh.GopKenh_TrangThai)
                        {
                            G_KenhGop = new DMVung_GPS().GetKenhGop_ByVung(g_strVungsDuocCapPhep);
                        }

                        bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                        bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;

                        G_arrProvince = Province.GetAllProvince();
                        G_arrDistrict = District.GetAllDistrict();
                        G_arrCommune = Commune.GetAllCommune();
                        LoadListLaiXe();
                        EnVangProcess.ReloadData();
                        // hiển thị thông tin menu nhập thông tin thuê bao tuyến
                        bool HienThiKenh3 = Configuration.GetMayTinhNhapThueBao();
                        foreach (UICommand com in uiCommandBar1.Commands)
                        {
                            if (com.Key == "cmdCuocThueBao")
                            {
                                if (HienThiKenh3)
                                {
                                    com.Visible = Janus.Windows.UI.InheritableBoolean.True; break;
                                }
                                else com.Visible = Janus.Windows.UI.InheritableBoolean.False;
                            }
                        }

                        //--------------------------LAYOUT-------------------------------------
                        //loadLayout(gridCuocGois);
                        SetStyleGrid();
                        //--------------------------LAYOUT-
                        //------------------------------------

                        Config_LuoiDieu();
                        
                        InitMemService();
                        DoFastTaxi();
                        if (Global.HasSOS)
                            Taxi.Controls.SOS.ProcessCanhBaoSos.Start();

                     //   G_VehiclesGPS = ProcessFastTaxi.Vehicles_GPS;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        //LogError.WriteLogError("IP : " + g_IPAddress, new Exception("Thong tin dia chi ip"));
                        Application.Exit();
                    }
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Enabled = false;
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi khởi tạo dữ liệu, cần liên lạc với quản trị." + ex.Message, "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                //LogError.WriteLogError("Co loi khi khoi tao chuong trinh - DB ", ex);
            }

        }

        /// <summary>
        /// Set check cho command "Ngắt kết nối mobile" trên form
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/3/2015   created
        /// </Modified>
        private void SetCheckMenuDisconnectMobile(bool value)
        {
            var commandQuanTri = uiCommandManager1.CommandBars[0].Commands[0].Commands;
            for (var i = 0; i < commandQuanTri.Count; i++)
            {
                if (commandQuanTri[i].Key.Equals("cmdDisconnectMobile"))
                {
                    commandQuanTri[i].Checked = value ? Janus.Windows.UI.InheritableBoolean.True : Janus.Windows.UI.InheritableBoolean.False;
                    break;
                }
            }
        }

        public void ReloadControlBanCo()
        {
            try
            {

                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                panel_BanCo.Controls.Clear();
                System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
                int MaxWidth = 85;
                int MaxHeightCell = 20;

                if (Screen.PrimaryScreen.WorkingArea.Width >= 1360)
                {
                    MaxWidth = 250;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width >= 1280)
                {
                    MaxWidth = 220;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width >= 1024)
                {
                    MaxWidth = 180;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width < 1024)
                {
                    MaxWidth = 100;
                    MaxHeightCell = 17;
                }
                _controlDieuHanhBanCoBanCo = new Control_DieuHanhBanCo_BanCo()
                {
                    Dock = DockStyle.Fill,
                    MinWidthVung = 90,
                    MaxWidthVung = MaxWidth,
                    HeighVung = 116,
                    HeighCell = MaxHeightCell,
                    IsBanCo = true,
                    dicVung = this.dicVung,
                    dicVungId_IDGPS = this.dicVungId_IDGPS,
                    IsTongDai = true
                };
                panel_BanCo.Controls.Add(_controlDieuHanhBanCoBanCo);
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi ReloadControlBanCo " + ex.Message);
            }
        }

        private void AnHienControl()
        {
            if (EnVangManagement.ConfigEnVang)
            {
            }
            else
            {
            }
        }

        private void Config_LuoiDieu()
        {
            gridCuocGois.RowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.SelectedFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.SelectedFormatStyle.FontBold = TriState.True;
            if(EnVangManagement.ConfigEnVang)
            {
                if(gridCuocGois.RootTable.Columns["MH_LenhLaiXe"] != null) gridCuocGois.RootTable.Columns["MH_LenhLaiXe"].Visible = true;
                if(gridCuocGois.RootTable.Columns["MH_ThoiDiemGuiXe"] != null) gridCuocGois.RootTable.Columns["MH_ThoiDiemGuiXe"].Visible = true;
                if (gridCuocGois.RootTable.Columns["MH_SoLanGuiToiXe"] != null) gridCuocGois.RootTable.Columns["MH_SoLanGuiToiXe"].Visible = true;
                if (gridCuocGois.RootTable.Columns["XeDon"] != null) gridCuocGois.RootTable.Columns["XeDon"].Visible = true;
                gridCuocGois.RootTable.Columns["MOIKHACH_LenhMoiKhach"].Visible = false;
                gridCuocGois.RootTable.Columns["MOIKHACH_KhieuNai_ThongTinThem"].Visible = false;
                gridCuocGois.RootTable.Columns["MOIKHACH_NhanVien"].Visible = false;
                //gridCuocGois.RootTable.Columns["XeDenDiem_CB"].Visible = false;
            }
           // gridCuocGois.RootTable.RowHeight = Config_Common.LuoiCuocGoi_RowHeight_TongDai;
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
        {//Phân quyền trên menu
            UICommandCollection MenuPhanQuyenItem = MenuPhanQuyen.Commands;
            foreach (UICommand mnuItem in MenuPhanQuyenItem)
            {
                if (DanhSachQuyen != null && mnuItem.Tag != null && mnuItem.Tag != "")
                {
                    mnuItem.Visible = DanhSachQuyen.Contains(mnuItem.Tag) ? Janus.Windows.UI.InheritableBoolean.True : Janus.Windows.UI.InheritableBoolean.False;
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
            //UICommandCollection mnuItem = MenuItemPhanQuyen.Commands;
            //phân quyền cho menu item
            if (DanhSachQuyen != null && MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag != "")
            {
                MenuItemPhanQuyen.Visible = DanhSachQuyen.Contains(MenuItemPhanQuyen.Tag) ? Janus.Windows.UI.InheritableBoolean.True : Janus.Windows.UI.InheritableBoolean.False;
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
            DataTable dt = new DiaDanh().GetRoadData_Autocomplete();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    address = row["Street"].ToString();
                    streetAbbr = row["StreetAbbr"].ToString();
                    g_ListDataAutoComplete.Add(new AutoCompleteEntry(address, streetAbbr));
                }
            }
        }

        private void loadLayout(GridEX gridEX)
        {
            gridLayout = new Taxi.Business.GridLayout.GridLayout(ThongTinDangNhap.USER_ID, "BoDam", this.Name, gridEX.Name);
            gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
        }

        private void LayCauHinhThoatCuoc999()
        {
            // thiet lap mac dinh
            g_Thoat999SoPhutGioiHan = 15;
            g_Thoat999TrangThaiTATBAT = false;
            g_Thoat999SoCuocGioiHan = 30;


            int vung;
            string[] arrVungs = g_strVungsDuocCapPhep.Split(";".ToCharArray());
            if (int.TryParse(arrVungs[0], out vung))
            {
                DataTable dt = ThoatCuoc999.GetCauHinhBATTATByVung(vung);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    // neu ThoiDiemBatDau999 <> NULL va ThoiDiemKetThuc999 = NULL
                    DateTime thoiDiemBatDat;
                    DateTime thoiDiemKetThuc;
                    thoiDiemBatDat = dr["ThoiDiemBatDau999"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ThoiDiemBatDau999"].ToString());
                    thoiDiemKetThuc = dr["ThoiDiemKetThuc999"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["ThoiDiemKetThuc999"].ToString());

                    if (thoiDiemBatDat != DateTime.MinValue && thoiDiemKetThuc == DateTime.MinValue)
                    {
                        g_Thoat999TrangThaiTATBAT = true;   // BAT cho phep dung 999
                    }
                    else
                        g_Thoat999TrangThaiTATBAT = false;  // TAT khong cho phep dung 999
                    if (!int.TryParse(dr["SoPhutDuocThoatCuoc"].ToString(), out g_Thoat999SoPhutGioiHan))
                    {
                        g_Thoat999SoPhutGioiHan = 15;
                    }
                    if (!int.TryParse(dr["GioiHanSoCuocDuocBat"].ToString(), out g_Thoat999SoCuocGioiHan))
                    {
                        g_Thoat999SoCuocGioiHan = 40;
                    }
                }
            }
        }

        private void LoadVungDieuHanh()
        {
            List<VungDieuHanh> lstVungDieuHanh = new VungDieuHanh().GetAllVungDieuHanh();

            this.dicVung = lstVungDieuHanh.Where(t => t.FK_CodeVungGPS != null).OrderBy(t => t.Sort).ToDictionary(t => (int)t.FK_CodeVungGPS, t => new Vung
            {
                Id = t.Id,
                VungGPSID = t.FK_CodeVungGPS == null ? 0 : (int)t.FK_CodeVungGPS.Value,
                MauChu = t.ColorOfVungDH == null ? "" : t.ColorOfVungDH.ToString(),
                Ten = t.NameVungDH == null ? "" : t.NameVungDH.ToString(),
            });
            this.dicVungId_IDGPS = this.dicVung.Values.ToDictionary(t => t.Id, t => t.VungGPSID);
        }
        #endregion

        #region ======================Validation Form==========================

        /// <summary>
        /// Confirm có tiếp tục check in hay không. nếu có sẽ check out toàn bộ các account đã check in trên máy.
        /// </summary>
        /// <param name="msgConfirm"></param>
        /// <param name="Type">
        /// 1 : có người đăng nhập trên máy này rồi
        /// 2 : account này đã đăng nhập ở 1 máy tính khác</param>

        private void CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
            frm.ShowDialog();
            g_strUsername = ThongTinDangNhap.USER_ID;
            g_strFullName = ThongTinDangNhap.FULLNAME;
            if (g_strUsername.Length > 0)
            {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                {
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                    if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
                    {
                        string alert = new MessageBox.MessageBoxBA().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        if (alert == "Yes")
                        {
                            ThongTinDangNhap.CheckOutByIpAddress(g_IPAddress);
                        }
                        else
                        {
                            Application.Exit();
                            return;
                        }
                        //new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //Application.Exit();
                        //return;
                    }
                     //kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                    //nếu đang debug thì vẫn cho đăng nhập nhiều máy.
                    //if (!Debugger.IsAttached && ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
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
                        new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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

                Text = String.Format("{0} - Tổng đài viên  [{1} - {2}] - {3} - {4}", Configuration.GetCompanyName(), g_strVungsDuocCapPhep, g_IPAddress, ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
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

        //private void confirmCheckIn(string msgConfirm, int Type)
        //{
        //    if (msgConfirm == "Yes")
        //    {
        //        //check out ở máy tính khác trước
        //        if (Type == 2 && ThongTinDangNhap.CheckOut_AllIn_OtherIP(g_strUsername, g_IPAddress))
        //        {
        //            doCheckIn();
        //        }
        //        // check out account khác đã checkin trên máy tính này trước.
        //        else if (Type == 1 && ThongTinDangNhap.CheckOut_AllInIP(g_strUsername, g_IPAddress))
        //        {
        //            doCheckIn();
        //        }
        //        else
        //        {
        //            new MessageBox.MessageBox().Show(this,
        //            "Có lỗi checkin hệ thống. Vui lòng thử lại.",
        //                                            "Thông báo lỗi",
        //                                            Taxi.MessageBox.MessageBoxButtons.OK,
        //                                            Taxi.MessageBox.MessageBoxIcon.Error);
        //            ThongTinDangNhap.USER_ID = "";
        //            g_strUsername = "";
        //            g_strFullName = "";
        //            Application.Exit();
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        ThongTinDangNhap.USER_ID = "";
        //        g_strUsername = "";
        //        g_strFullName = "";
        //        Application.Exit();
        //        return;
        //    }
        //}

        //private void doCheckIn()
        //{
        //    // cap nhat trang thai
        //    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
        //    {
        //        new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //        ThongTinDangNhap.USER_ID = "";
        //        g_strUsername = "";
        //        g_strFullName = "";
        //        Application.Exit();
        //        return;
        //    }
        //    else
        //    {
        //        if (!ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanh))
        //        {
        //            new MessageBox.MessageBox().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //            ThongTinDangNhap.USER_ID = "";
        //            g_strUsername = "";
        //            g_strFullName = "";
        //            Application.Exit();
        //            return;
        //        }
        //    }
        //}

        /// <summary>
        /// thiết lập panel trợ giúp
        /// </summary>
        private void ThietLapKhungTroGiup()
        {
            //panelTopHelp.Location = new Point(this.Width - (panelTopHelp.Width + 15 + 32), 0);
            panelTopHelpEnVang.Visible = true;
            //else panelTopHelp.Visible = true;

            
            btnHelp.Location = new Point(this.Size.Width - (btnHelp.Size.Width + 15), 0);
        }

        /// <summary>
        /// Hiển thị thông tin lên lưới
        /// Nếu IsRefesh = true thì chỉ thực hiện refesh
        /// ngược lại : thì load mới
        /// </summary>
        /// <param name="IsRefesh"></param>
        private void HienThiTrenLuoi(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                g_RowIndex = gridCuocGois.Row;
                if (IsCapNhat)
                {
                    if (IsThemMoi)
                    {
                        isThemMoi = true;
                        gridCuocGois.DataSource = null;
                        gridCuocGois.DataMember = "ListDienThoai";
                        gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                        if (gridCuocGois.RowCount > 0)
                        {
                            gridCuocGois.MoveToRowIndex(g_RowIndex + 1);
                        }
                    }
                    else
                    {
                        gridCuocGois.Refetch();
                    }
                }
                else
                {
                    gridCuocGois.Refresh();
                    gridCuocGois.Refetch();
                    //gridCuocGois.Refetch();
                    gridCuocGois.MoveToRowIndex(g_RowIndex);
                }
            }
            catch (Exception)
            {
            }
        }

        private void HienThiTrenLuoi_DaDonKhach(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                g_RowIndex_DaDonKhach = grid_DaDonKhach.Row;
                if (IsCapNhat)
                {
                    if (IsThemMoi)
                    {
                        isThemMoi = true;
                        grid_DaDonKhach.DataSource = null;
                        grid_DaDonKhach.DataMember = "ListDienThoai_DaDonKhach";
                        grid_DaDonKhach.SetDataBinding(g_lstDienThoai_DaDonKhach, "ListDienThoai_DaDonKhach");
                        if (grid_DaDonKhach.RowCount > 0)
                        {
                            grid_DaDonKhach.MoveToRowIndex(g_RowIndex_DaDonKhach + 1);
                        }
                    }
                    else
                    {
                        grid_DaDonKhach.Refetch();
                    }
                }
                else
                {
                    grid_DaDonKhach.Refresh();
                    grid_DaDonKhach.Refetch();
                    //gridCuocGois.Refetch();
                    grid_DaDonKhach.MoveToRowIndex(g_RowIndex_DaDonKhach);
                }
            }
            catch (Exception)
            {
            }
        }
        
        /// <summary>
        /// Hiển thị thông tin lên lưới
        /// Nếu IsRefesh = true thì chỉ thực hiện refesh
        /// ngược lại : thì load mới
        /// </summary>
        /// <param name="IsRefesh"></param>
        private void HienThiTrenLuoi_KETTHUC(bool IsCapNhat, bool IsThemMoi)
        {
            //if (!IsCapNhat)
            //{
            //    if (IsThemMoi)
            //    {
            gridCuocGoi_KetThuc.DataSource = null;
            gridCuocGoi_KetThuc.DataMember = "g_lstCuocGoiKetThuc";
            gridCuocGoi_KetThuc.SetDataBinding(g_lstCuocGoiKetThuc, "g_lstCuocGoiKetThuc");
            //    }
            //}
            //else
            //{
            //    gridCuocGoiKetThuc.Refresh();
            //}

        }

        /// <summary>
        /// nếu quá 5 phút thì format lại style cho cột ThoiDiemGoi
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
        private void setStyleXeNhan(GridEXRow row, DateTime ThoiDiemGoi, string xeNhanTD, string xeNhan, string xeDeCu, int ColWidth)
        {
            if (string.IsNullOrEmpty(xeNhan))
            {
                //int rowheight = 20;
                //float fontsize = 9F;
                //if (G_RowHeight < Config_Common.LuoiCuocGoi_RowHeight_TongDai)
                //{
                //    rowheight = G_RowHeight;
                //}
                //else
                //{
                //    rowheight = Config_Common.LuoiCuocGoi_RowHeight_TongDai;
                //}
                TimeSpan timer = g_TimeServer - ThoiDiemGoi;
                if (timer.TotalMinutes > 1 && timer.TotalMinutes < 5) 
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);

                else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 30)
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Orange, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);

                else
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.White, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);
            }
            else
            {
                row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage(xeNhanTD, xeNhan, xeDeCu, Color.White, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);
            }
        }

        private void setStyleXeDenDiem(GridEXRow row, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, int ColWidth, DateTime thoiDiemGoi)
        {
            TimeSpan timer = g_TimeServer - thoiDiemGoi;
            if (timer.TotalMinutes > 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.LightSteelBlue, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);
            else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.MistyRose, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);
            else
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.White, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TongDai, Config_Common.LuoiCuocGoi_FontSize_TongDai);
        }

        /// <summary>
        /// Kiểm tra cuộc gọi có lỗi không để bôi đỏ ô lệnh lái xe và đưa lên đầu. Nếu lỗi sẽ trả về true
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/31/2015   created
        /// </Modified>
        private bool KiemTraCuocGoiCoLoiKhong(CuocGoi cuocGoi)
        {
            if (cuocGoi.MH_LenhLaiXe == EnVangManagement.LENH_KHONGXENHAN
                    || cuocGoi.MH_LenhLaiXe == EnVangManagement.LENH_LAIXEHUY
                    || cuocGoi.MH_LenhLaiXe == EnVangManagement.LENH_TRUOTKHACH)
            {
                return true;
            }
            return false;
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
                CuocGoi cuocGoi = (CuocGoi)row.DataRow;
                if (cuocGoi == null)
                    return;
              
                //Set màu cho ô MH_LenhLaiXe của dòng
                var LenhLaiXeBackColor = Color.White;
                if (!string.IsNullOrEmpty(cuocGoi.MH_LenhLaiXe)) LenhLaiXeBackColor = Color.Red;
                GridEXFormatStyle LenhLaiXeRowStyle = new GridEXFormatStyle();
                LenhLaiXeRowStyle.BackColor = LenhLaiXeBackColor;
                row.Cells["MH_LenhLaiXe"].FormatStyle = LenhLaiXeRowStyle;
                //Kết thúc set màu cho ô MH_LenhLaiXe của dòng
                setStyleThoiDiemGoi(row, cuocGoi.ThoiDiemGoi);
                setStyleXeNhan(row, cuocGoi.ThoiDiemGoi, cuocGoi.XeNhan_TD, cuocGoi.XeNhan, cuocGoi.DanhSachXeDeCu, row.Cells["XeNhan_CB"].Column.Width);
                setStyleXeDenDiem(row, cuocGoi.MOIKHACH_LenhMoiKhach, cuocGoi.XeDenDiem, cuocGoi.XeDenDiemDonKhach, row.Cells["XeDenDiem_CB"].Column.Width, cuocGoi.ThoiDiemGoi);
                if (cuocGoi.LenhTongDai == LENH_MOIKHACH)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || cuocGoi.LenhDienThoai == LENH_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || cuocGoi.LenhDienThoai == LENH_4_HOILAIDC || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_4_HOILAIDC
                        || cuocGoi.LenhDienThoai == LENH_3_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_3_KHONGXE
                        || cuocGoi.LenhDienThoai == LENH_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || cuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
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
               
                if ( cuocGoi.LenhTongDai == LENH_6_KIENTRAKHACH
                    || cuocGoi.LenhTongDai == LENH_8_RADAUNGO)
                {
                    if (cuocGoi.LenhDienThoai == LENH_DAMOI || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || cuocGoi.LenhDienThoai == LENH_GAPXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || cuocGoi.LenhDienThoai == LENH_4_HOILAIDC || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_4_HOILAIDC
                        || cuocGoi.LenhDienThoai == LENH_3_KHONGXE || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_3_KHONGXE
                        || cuocGoi.LenhDienThoai == LENH_MAYBAN || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || cuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC || cuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
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
                else if (cuocGoi.LenhTongDai == LENH_4_HOILAIDC)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.White;
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.LenhDienThoai == LENH_KHACHDAT)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Green;
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }
                if (cuocGoi.LenhTongDai == LENH_3_KHONGXE && cuocGoi.ThoiDiemGoi.AddMinutes(3) <= g_TimeServer)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightSalmon;
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                if (cuocGoi.FT_IsFT)
                {
                    row.Cells["ImageCol"].ImageIndex = 21;
                }
                else
                {
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                }
                //if ((cuocGoi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.BoDam))
                //    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.BoDam;
                //else if (cuocGoi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai)
                //    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                //else if (cuocGoi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.MoiKhachGui)
                //    row.Cells["ImageCol"].ImageIndex = 3;
                //else if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                //{
                //    row.Cells["ImageCol"].ImageIndex = 0;
                //}

                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (cuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
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
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Tomato;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                

                if (Config_Common.LuoiCuocGoi_MauNen_LoaiXe!=null&&Config_Common.LuoiCuocGoi_MauNen_LoaiXe.Length > 0)
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
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.DodgerBlue };
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.White };
                        row.Cells["LoaiXe"].FormatStyle = RowStyle;
                    }
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.White };
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }

                if (cuocGoi.SoLanGoi == 1)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Yellow };
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                }
                else if (cuocGoi.SoLanGoi >= 2)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
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
                }
                //if (cuocGoi.MaNhanVienTongDai == "")
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //    RowStyle.BackColor = Color.LightBlue;
                //    row.RowStyle = RowStyle;
                //}
                //else
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                //    RowStyle.BackColor = Color.White;
                //    row.RowStyle = RowStyle;
                //}
                if (cuocGoi.FT_IsFT)
                {
                    var rowStyle = new GridEXFormatStyle();
                    rowStyle.BackColor = Color.Yellow;
                    rowStyle.BackColorGradient = Color.Yellow;rowStyle.ForeColor = Color.Black;
                    rowStyle.BackColorAlphaMode = AlphaMode.Opaque;
                    row.Cells["DiaChiDonKhach"].FormatStyle = rowStyle;
                }
                else if (!cuocGoi.FT_IsFT && cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiLai)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.Cells["DiaChiDonKhach"].FormatStyle = RowStyle;
                }
                if (string.IsNullOrEmpty(cuocGoi.MaNhanVienTongDai))
                {
                     Janus.Windows.GridEX.GridEXFormatStyle rowcol = new GridEXFormatStyle();
                     if (Config_Common.Grid_CuocChuaXuLy_BackGround != null)
                     {
                         rowcol.BackColor = Config_Common.Grid_CuocChuaXuLy_BackGround;
                     }else
                     rowcol.BackColor = Color.BlanchedAlmond;
                     row.RowStyle = rowcol;
                }
                if (row.RowStyle!=null&&row.RowStyle.BackColor == Color.White)
                    row.RowStyle.BackColor = Config_Common.TongDai_MauNen_LuoiCuocGoi;
                // Thực hiện mầu theo cấu hình
                MangerCommand.ProcessMobileCommandFormat(cuocGoi, row);
             }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("HienThiAnhTrangThai_MauChu " + ex.Message);
                //LogError.WriteLogError("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }

        private void checkout()
        {
            // check co dung may cua user dang ngồi không.
            if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
            {
                if (ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress))
                {
                    new MessageBox.MessageBoxBA().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    statusBar.Panels["TenDangNhap"].Text = "NV: ";
                    ThongTinDangNhap.USER_ID = "";
                    CheckIn();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                }
            }
            else
                new MessageBox.MessageBoxBA().Show(this, "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            // nếu đúng thì cập nhật thời gian checkout.
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

        #region =======================Get Data Form===========================
        /// <summary>
        /// Hàm xử lý lấy ds các cuộc gọi vùng đang xử lý
        /// của vùng được cấp phép
        /// </summary>
        /// <param name="vungsDuocCapPhep"></param>
        private void LoadAllCuocGoiHienTai(string vungsDuocCapPhep)
        {
            g_lstDienThoai = new List<CuocGoi>();
            if(ThongTinCauHinh.FT_Active)
                g_lstDienThoai = CuocGoi.FT_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep, ref g_lstDienThoai_New);
            else
                g_lstDienThoai = CuocGoi.EnVangVIP_TONGDAI_LayAllCuocGoi(vungsDuocCapPhep, ref g_lstDienThoai_New);

            g_lstDienThoai_DaDonKhach = CuocGoi.EnVangVIP_TONGDAI_LayAllCuocGoi_DaDonKhach(vungsDuocCapPhep, ref g_lstDienThoai_New_DaDonKhach);
            //var db = g_lstDienThoai.Where(p => p.FT_IsFT).ToList();
            SapXepCuocGoiThanThiet();
        }
        private void SapXepCuocGoiThanThiet()
        {
            List<CuocGoi> lstDienThoai = new List<CuocGoi>();
            int index = 0;
            string indexRemove = "";
            foreach (CuocGoi objCuocGoi in g_lstDienThoai)
            {
                if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP
                    || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                    || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    lstDienThoai.Add(objCuocGoi);
                    indexRemove = indexRemove + (index).ToString() + ";";
                }
                index++;
            }
            if (indexRemove.Length > 0)
            {
                string[] array = indexRemove.Split(';');

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length > 0)
                    {
                        try
                        {
                            g_lstDienThoai.RemoveAt(Convert.ToInt16(array[i]) - i);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }

                }

                foreach (CuocGoi item in lstDienThoai)
                {
                    if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                    {
                        g_lstDienThoai.Insert(0, item);
                        G_IndexKhachVIP++;
                    }
                    else if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                    {
                        g_lstDienThoai.Insert(G_IndexKhachVIP, item);
                        G_IndexKhachVang++;
                    }
                    else if (item.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                    {
                        g_lstDienThoai.Insert(G_IndexKhachVang, item);
                        G_IndexKhachBac++;
                    }
                }

            }
        }

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string vungsDuocCapPhep, int soDong)
        {
            try
            {
                if (ThongTinCauHinh.FT_Active)
                    g_lstCuocGoiKetThuc = CuocGoi.FT_TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong);
                else 
                    g_lstCuocGoiKetThuc = CuocGoi.FT_TONGDAI_LayCuocGoiDaGiaiQuyetNotFT(vungsDuocCapPhep, soDong);
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(g_lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("LoadCacCuocGoiKetThuc " + ex.Message);
            }
        }
               
        /// <summary>
        /// hàm thực hiện lấy các cuộc gọi các cuộc gọi thay đổi, thêm mới phía điện thoai
        /// </summary>
        /// <param name="vungsDuocCapPhep">Vùng được cấp phép của máy tính</param>
        /// <param name="thoiDiemLayDuLieuTruoc">Thời điểm đã thực hiện lấy dữ liệu trước</param>
        /// <returns></returns>
        private void LoadCuocGoiMoiTongDai_ChuaNhan(ref List<CuocGoi> listCuocGoi_ChuaNhanXuLy, string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoi_ChuaNhanXuLy == null)
            {
                listCuocGoi_ChuaNhanXuLy = new List<CuocGoi>();
            }
            // cuộc gọi chưa có trong cuộc gọi chưa nhận thì chèn mới
            List<CuocGoi> listCuocGoiMoi;
            //Nếu trạng thái Sử dụng staxi kích hoạt thì lấy những cuốc có cả các cuốc gọi trên staxi;
            if(ThongTinCauHinh.FT_Active)
                listCuocGoiMoi = CuocGoi.FT_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            else
                listCuocGoiMoi = CuocGoi.EnVangVIP_TONGDAI_LayCuocGoiMoiTuDienThoai(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    CuocGoi objCG = listCuocGoiMoi[i];
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
                    int index = -1;
                    for (int j = 0; j < listCuocGoi_ChuaNhanXuLy.Count; j++)
                    {
                        if (objCG.IDCuocGoi == listCuocGoi_ChuaNhanXuLy[j].IDCuocGoi) // da co 1 cuoc ton tai
                        {
                            index = j; break;
                        }
                    }
                    if (index == -1) // cos cuoc moi
                    {
                        hasThemMoi = true;
                        if (objCG.FT_IsFT)
                        {
                            listCuocGoi_ChuaNhanXuLy.Insert(0, objCG);
                        }
                        else
                        {
                            if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                            {
                                listCuocGoi_ChuaNhanXuLy.Insert(G_IndexKhachVIP, objCG);
                                G_IndexKhachVIP++;
                            }
                            else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                            {
                                listCuocGoi_ChuaNhanXuLy.Insert(G_IndexKhachVIP + G_IndexKhachVang, objCG);
                                G_IndexKhachVang++;
                            }
                            else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                            {
                                listCuocGoi_ChuaNhanXuLy.Insert(G_IndexKhachVang + G_IndexKhachBac, objCG);
                                G_IndexKhachBac++;
                            }
                            else
                            {
                                G_IndexKHThanThiet = G_IndexKhachVIP + G_IndexKhachVang + G_IndexKhachBac;
                                listCuocGoi_ChuaNhanXuLy.Insert(G_IndexKHThanThiet, objCG);
                            }
                            // Neu la cuoc goi lai, tim cuoc goi taxi cua cuoc goi do va day len tren gan cuoc goi taxi
                            if (objCG.KieuCuocGoi == KieuCuocGoi.GoiLai)
                            {
                                // tìm đến cuộc gọi taxi của số này, chèn cuộc đó lên đầu.
                                int viTri = -1;
                                for (int k = 0; k < listCuocGoi_ChuaNhanXuLy.Count; k++)
                                {
                                    if (listCuocGoi_ChuaNhanXuLy[k].PhoneNumber == objCG.PhoneNumber && listCuocGoi_ChuaNhanXuLy[k].KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                    {
                                        viTri = k;
                                        break;
                                    }
                                }
                                if (viTri > 1) // loaij bo vi tri nay vi se chen ngay vao vi tri so 1
                                {
                                    listCuocGoi_ChuaNhanXuLy.Insert(G_IndexKHThanThiet + 1, listCuocGoi_ChuaNhanXuLy[viTri]);
                                    listCuocGoi_ChuaNhanXuLy.RemoveAt(viTri + 1);
                                }
                            }
                        }
                        
                        
                    }
                    else // cap nhat thong tin cua dien thoai gui sang cho
                    {
                        listCuocGoi_ChuaNhanXuLy[index].DiaChiTraKhach = objCG.DiaChiTraKhach;
                        listCuocGoi_ChuaNhanXuLy[index].DiaChiDonKhach = objCG.DiaChiDonKhach;
                        listCuocGoi_ChuaNhanXuLy[index].SoLanGoi = objCG.SoLanGoi;
                        listCuocGoi_ChuaNhanXuLy[index].Vung = objCG.Vung;
                        listCuocGoi_ChuaNhanXuLy[index].LoaiXe = objCG.LoaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].SoLuong = objCG.SoLuong;
                        listCuocGoi_ChuaNhanXuLy[index].KieuKhachHangGoiDen = objCG.KieuKhachHangGoiDen;
                        listCuocGoi_ChuaNhanXuLy[index].IsCuocGiaLap = objCG.IsCuocGiaLap;
                        listCuocGoi_ChuaNhanXuLy[index].KieuCuocGoi = objCG.KieuCuocGoi;
                        listCuocGoi_ChuaNhanXuLy[index].LenhDienThoai = objCG.LenhDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuDienThoai = objCG.GhiChuDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].LenhTongDai = objCG.LenhTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuTongDai = objCG.GhiChuTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].MaNhanVienTongDai = objCG.MaNhanVienTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].MaNhanVienDienThoai = objCG.MaNhanVienDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].ThoiDiemChuyenTongDai = objCG.ThoiDiemChuyenTongDai;

                        listCuocGoi_ChuaNhanXuLy[index].DanhSachXeDeCu = objCG.DanhSachXeDeCu;
                        listCuocGoi_ChuaNhanXuLy[index].DanhSachXeDeCu_TD = objCG.DanhSachXeDeCu_TD;
                        listCuocGoi_ChuaNhanXuLy[index].ThoiDiemCapNhatXeDeCu = objCG.ThoiDiemCapNhatXeDeCu;
                        listCuocGoi_ChuaNhanXuLy[index].XeNhan = objCG.XeNhan;
                        listCuocGoi_ChuaNhanXuLy[index].XeNhan_TD = objCG.XeNhan_TD;
                        


                        listCuocGoi_ChuaNhanXuLy[index].MOIKHACH_NhanVien = objCG.MOIKHACH_NhanVien;
                        listCuocGoi_ChuaNhanXuLy[index].MOIKHACH_LenhMoiKhach = objCG.MOIKHACH_LenhMoiKhach;

                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiem = objCG.XeDenDiem;
                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiemDonKhach = objCG.XeDenDiemDonKhach;
                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiemDonKhach_TD = objCG.XeDenDiemDonKhach_TD;
                        //listCuocGoiHienTai[index].x = objCG.MOIKHACH_LenhMoiKhach;
                        ////TinNhan
                        listCuocGoi_ChuaNhanXuLy[index].GPS_KinhDo = objCG.GPS_KinhDo;
                        listCuocGoi_ChuaNhanXuLy[index].GPS_ViDo = objCG.GPS_ViDo;
                        listCuocGoi_ChuaNhanXuLy[index].PhoneNumber = objCG.PhoneNumber;
                        //FastTaxi
                        listCuocGoi_ChuaNhanXuLy[index].FT_Date = objCG.FT_Date;
                        listCuocGoi_ChuaNhanXuLy[index].FT_IsFT = objCG.FT_IsFT;
                        listCuocGoi_ChuaNhanXuLy[index].FT_SendDate = objCG.FT_SendDate;
                        listCuocGoi_ChuaNhanXuLy[index].FT_Status = objCG.FT_Status;

                        listCuocGoi_ChuaNhanXuLy[index].DaGuiDSXeNhan = objCG.DaGuiDSXeNhan;
                        listCuocGoi_ChuaNhanXuLy[index].CenterConfirm = objCG.CenterConfirm;
                        listCuocGoi_ChuaNhanXuLy[index].XeDon = objCG.XeDon;
                        listCuocGoi_ChuaNhanXuLy[index].MH_LenhLaiXe = objCG.MH_LenhLaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuLaiXe = objCG.GhiChuLaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].MH_SoLanGuiToiXe = objCG.MH_SoLanGuiToiXe;
                        listCuocGoi_ChuaNhanXuLy[index].MH_ThoiDiemGuiXe = objCG.MH_ThoiDiemGuiXe;
                        listCuocGoi_ChuaNhanXuLy[index].KhongDungMobileService = objCG.KhongDungMobileService;
                        if (KiemTraCuocGoiCoLoiKhong(listCuocGoi_ChuaNhanXuLy[index]))
                        {
                            listCuocGoi_ChuaNhanXuLy.Insert(0, listCuocGoi_ChuaNhanXuLy[index]);
                            listCuocGoi_ChuaNhanXuLy.RemoveAt(index + 1);
                        }
                    }
                    if (index != -1 && index <= listCuocGoi_ChuaNhanXuLy.Count - 1)
                    {
                        XuLyThongTinThayDoi(listCuocGoi_ChuaNhanXuLy[index]);
                    }
                }
            }
        }

        private void LoadCuocGoiMoiTongDai_DaDonKhach(ref List<CuocGoi> listCuocGoi_ChuaNhanXuLy, string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoi_ChuaNhanXuLy == null)
            {
                listCuocGoi_ChuaNhanXuLy = new List<CuocGoi>();
            }
            // cuộc gọi chưa có trong cuộc gọi chưa nhận thì chèn mới
            List<CuocGoi> listCuocGoiMoi = CuocGoi.EnVangVIP_TONGDAI_LayCuocGoiMoiTuDienThoai_DaDonKhach(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    CuocGoi objCG = listCuocGoiMoi[i];
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
                    int index = -1;
                    for (int j = 0; j < listCuocGoi_ChuaNhanXuLy.Count; j++)
                    {
                        if (objCG.IDCuocGoi == listCuocGoi_ChuaNhanXuLy[j].IDCuocGoi) // da co 1 cuoc ton tai
                        {
                            index = j; break;
                        }
                    }
                    if (index == -1) // cos cuoc moi
                    {
                        hasThemMoi = true;
                        listCuocGoi_ChuaNhanXuLy.Insert(0, objCG);                            
                    }
                    else // cap nhat thong tin cua dien thoai gui sang cho
                    {
                        listCuocGoi_ChuaNhanXuLy[index].DiaChiTraKhach = objCG.DiaChiTraKhach;
                        listCuocGoi_ChuaNhanXuLy[index].DiaChiDonKhach = objCG.DiaChiDonKhach;
                        listCuocGoi_ChuaNhanXuLy[index].SoLanGoi = objCG.SoLanGoi;
                        listCuocGoi_ChuaNhanXuLy[index].Vung = objCG.Vung;
                        listCuocGoi_ChuaNhanXuLy[index].LoaiXe = objCG.LoaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].SoLuong = objCG.SoLuong;
                        listCuocGoi_ChuaNhanXuLy[index].KieuKhachHangGoiDen = objCG.KieuKhachHangGoiDen;
                        listCuocGoi_ChuaNhanXuLy[index].IsCuocGiaLap = objCG.IsCuocGiaLap;
                        listCuocGoi_ChuaNhanXuLy[index].KieuCuocGoi = objCG.KieuCuocGoi;
                        listCuocGoi_ChuaNhanXuLy[index].LenhDienThoai = objCG.LenhDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuDienThoai = objCG.GhiChuDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].LenhTongDai = objCG.LenhTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuTongDai = objCG.GhiChuTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].MaNhanVienTongDai = objCG.MaNhanVienTongDai;
                        listCuocGoi_ChuaNhanXuLy[index].MaNhanVienDienThoai = objCG.MaNhanVienDienThoai;
                        listCuocGoi_ChuaNhanXuLy[index].ThoiDiemChuyenTongDai = objCG.ThoiDiemChuyenTongDai;

                        listCuocGoi_ChuaNhanXuLy[index].DanhSachXeDeCu = objCG.DanhSachXeDeCu;
                        listCuocGoi_ChuaNhanXuLy[index].DanhSachXeDeCu_TD = objCG.DanhSachXeDeCu_TD;
                        listCuocGoi_ChuaNhanXuLy[index].ThoiDiemCapNhatXeDeCu = objCG.ThoiDiemCapNhatXeDeCu;
                        listCuocGoi_ChuaNhanXuLy[index].XeNhan = objCG.XeNhan;
                        listCuocGoi_ChuaNhanXuLy[index].XeNhan_TD = objCG.XeNhan_TD;

                        listCuocGoi_ChuaNhanXuLy[index].XeDon = objCG.XeDon;
                        listCuocGoi_ChuaNhanXuLy[index].ThoiGianDonKhach = objCG.ThoiGianDonKhach;

                        listCuocGoi_ChuaNhanXuLy[index].MOIKHACH_NhanVien = objCG.MOIKHACH_NhanVien;
                        listCuocGoi_ChuaNhanXuLy[index].MOIKHACH_LenhMoiKhach = objCG.MOIKHACH_LenhMoiKhach;

                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiem = objCG.XeDenDiem;
                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiemDonKhach = objCG.XeDenDiemDonKhach;
                        listCuocGoi_ChuaNhanXuLy[index].XeDenDiemDonKhach_TD = objCG.XeDenDiemDonKhach_TD;
                        //listCuocGoiHienTai[index].x = objCG.MOIKHACH_LenhMoiKhach;
                        ////TinNhan
                        listCuocGoi_ChuaNhanXuLy[index].GPS_KinhDo = objCG.GPS_KinhDo;
                        listCuocGoi_ChuaNhanXuLy[index].GPS_ViDo = objCG.GPS_ViDo;
                        listCuocGoi_ChuaNhanXuLy[index].PhoneNumber = objCG.PhoneNumber;
                        //FastTaxi
                        listCuocGoi_ChuaNhanXuLy[index].FT_Date = objCG.FT_Date;
                        listCuocGoi_ChuaNhanXuLy[index].FT_IsFT = objCG.FT_IsFT;
                        listCuocGoi_ChuaNhanXuLy[index].FT_SendDate = objCG.FT_SendDate;
                        listCuocGoi_ChuaNhanXuLy[index].FT_Status = objCG.FT_Status;

                        listCuocGoi_ChuaNhanXuLy[index].DaGuiDSXeNhan = objCG.DaGuiDSXeNhan;
                        listCuocGoi_ChuaNhanXuLy[index].CenterConfirm = objCG.CenterConfirm;
                        listCuocGoi_ChuaNhanXuLy[index].XeDon = objCG.XeDon;
                        listCuocGoi_ChuaNhanXuLy[index].MH_LenhLaiXe = objCG.MH_LenhLaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].GhiChuLaiXe = objCG.GhiChuLaiXe;
                        listCuocGoi_ChuaNhanXuLy[index].MH_SoLanGuiToiXe = objCG.MH_SoLanGuiToiXe;
                        listCuocGoi_ChuaNhanXuLy[index].MH_ThoiDiemGuiXe = objCG.MH_ThoiDiemGuiXe;
                        listCuocGoi_ChuaNhanXuLy[index].KhongDungMobileService = objCG.KhongDungMobileService;
                        if (KiemTraCuocGoiCoLoiKhong(listCuocGoi_ChuaNhanXuLy[index]))
                        {
                            listCuocGoi_ChuaNhanXuLy.Insert(0, listCuocGoi_ChuaNhanXuLy[index]);
                            listCuocGoi_ChuaNhanXuLy.RemoveAt(index + 1);
                        }
                    }
                    //if (index != -1 && index <= listCuocGoi_ChuaNhanXuLy.Count - 1) 
                    //    XuLyThongTinThayDoi(listCuocGoi_ChuaNhanXuLy[index]);
                }
            }
        }


        /// <summary>
        /// hàm thực hiện lấy các cuộc gọi các cuộc gọi thay đổi phía điện thoai mà nhân viên tổng đài đã nhận xử lý
        /// </summary>
        /// <param name="vungsDuocCapPhep">Vùng được cấp phép của máy tính</param>
        /// <param name="thoiDiemLayDuLieuTruoc">Thời điểm đã thực hiện lấy dữ liệu trước</param>
        /// <returns></returns>
        private void LoadCuocGoiMoiTongDai_DaNhan(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, ref DateTime DateMax)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoiHienTai == null)
                listCuocGoiHienTai = new List<CuocGoi>();

            // cuộc gọi chưa có trong cuộc gọi thì chèn mới
            // nếu có rồi thì cập nhật
            List<CuocGoi> listCuocGoiMoi;
            if(ThongTinCauHinh.FT_Active)
                listCuocGoiMoi = CuocGoi.FT_TONGDAI_LayCuocGoiDaNhanXuLy(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            else 
                listCuocGoiMoi = CuocGoi.FT_TONGDAI_LayCuocGoiDaNhanXuLyNotFT(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    CuocGoi objCG = listCuocGoiMoi[i];
                    if (DateMax < objCG.ThoiDiemThayDoiDuLieu)
                        DateMax = objCG.ThoiDiemThayDoiDuLieu;
                    int index = -1;
                    for (int j = 0; j < listCuocGoiHienTai.Count; j++)
                    {
                        if (objCG.IDCuocGoi == listCuocGoiHienTai[j].IDCuocGoi) // da co 1 cuoc ton tai
                        {
                            index = j; break;
                        }
                    }
                    if (index == -1) // cos cuoc moi
                    {
                        hasThemMoi = true;
                        if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                        {
                            listCuocGoiHienTai.Insert(0, objCG);
                            G_IndexKhachVIP++;
                        }
                        else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVIP, objCG);
                            G_IndexKhachVang++;
                        }
                        else if (objCG.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVang, objCG);
                            G_IndexKhachBac++;
                        }
                        else
                        {
                            G_IndexKHThanThiet = G_IndexKhachVIP + G_IndexKhachVang + G_IndexKhachBac;
                            listCuocGoiHienTai.Insert(G_IndexKHThanThiet, objCG);
                        }
                        // Neu la cuoc goi lai, tim cuoc goi taxi cua cuoc goi do va day len tren gan cuoc goi taxi
                        if (objCG.KieuCuocGoi == KieuCuocGoi.GoiLai)
                        {
                            // tìm đến cuộc gọi taxi của số này, chèn cuộc đó lên đầu.
                            int viTri = -1;
                            for (int k = 0; k < listCuocGoiHienTai.Count; k++)
                            {
                                if (listCuocGoiHienTai[k].PhoneNumber == objCG.PhoneNumber && listCuocGoiHienTai[k].KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                                {
                                    viTri = k;
                                    break;
                                }
                            }
                            if (viTri > 1) // loaij bo vi tri nay vi se chen ngay vao vi tri so 1
                            {
                                listCuocGoiHienTai.Insert(G_IndexKHThanThiet + 1, listCuocGoiHienTai[viTri]);
                                listCuocGoiHienTai.RemoveAt(viTri + 1);
                            }
                        }
                    }
                    else // cap nhat thong tin cua dien thoai gui sang cho
                    {
                        listCuocGoiHienTai[index].DiaChiTraKhach = objCG.DiaChiTraKhach;
                        listCuocGoiHienTai[index].DiaChiDonKhach = objCG.DiaChiDonKhach;
                        listCuocGoiHienTai[index].SoLanGoi = objCG.SoLanGoi;
                        listCuocGoiHienTai[index].Vung = objCG.Vung;
                        listCuocGoiHienTai[index].LoaiXe = objCG.LoaiXe;
                        listCuocGoiHienTai[index].SoLuong = objCG.SoLuong;
                        listCuocGoiHienTai[index].KieuKhachHangGoiDen = objCG.KieuKhachHangGoiDen;
                        listCuocGoiHienTai[index].IsCuocGiaLap = objCG.IsCuocGiaLap;
                        listCuocGoiHienTai[index].KieuCuocGoi = objCG.KieuCuocGoi;
                        listCuocGoiHienTai[index].LenhDienThoai = objCG.LenhDienThoai;
                        listCuocGoiHienTai[index].GhiChuDienThoai = objCG.GhiChuDienThoai;
                        listCuocGoiHienTai[index].LenhTongDai = objCG.LenhTongDai;
                        listCuocGoiHienTai[index].GhiChuTongDai = objCG.GhiChuTongDai;
                        listCuocGoiHienTai[index].MaNhanVienTongDai = objCG.MaNhanVienTongDai;
                        listCuocGoiHienTai[index].MaNhanVienDienThoai = objCG.MaNhanVienDienThoai;
                        listCuocGoiHienTai[index].ThoiDiemChuyenTongDai = objCG.ThoiDiemChuyenTongDai;

                        listCuocGoiHienTai[index].DanhSachXeDeCu = objCG.DanhSachXeDeCu;
                        listCuocGoiHienTai[index].DanhSachXeDeCu_TD = objCG.DanhSachXeDeCu_TD;
                        listCuocGoiHienTai[index].ThoiDiemCapNhatXeDeCu = objCG.ThoiDiemCapNhatXeDeCu;
                        listCuocGoiHienTai[index].XeNhan = objCG.XeNhan;
                        listCuocGoiHienTai[index].XeNhan_TD = objCG.XeNhan_TD;

                        listCuocGoiHienTai[index].MOIKHACH_NhanVien = objCG.MOIKHACH_NhanVien;
                        listCuocGoiHienTai[index].MOIKHACH_LenhMoiKhach = objCG.MOIKHACH_LenhMoiKhach;

                        listCuocGoiHienTai[index].XeDenDiem = objCG.XeDenDiem;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach = objCG.XeDenDiemDonKhach;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach_TD = objCG.XeDenDiemDonKhach_TD;
                        //listCuocGoiHienTai[index].x = objCG.MOIKHACH_LenhMoiKhach;
                        ////TinNhan
                        listCuocGoiHienTai[index].GPS_KinhDo = objCG.GPS_KinhDo;
                        listCuocGoiHienTai[index].GPS_ViDo = objCG.GPS_ViDo;
                        listCuocGoiHienTai[index].PhoneNumber = objCG.PhoneNumber;
                        //FastTaxi
                        listCuocGoiHienTai[index].FT_Date = objCG.FT_Date;
                        listCuocGoiHienTai[index].FT_IsFT = objCG.FT_IsFT;
                        listCuocGoiHienTai[index].FT_SendDate = objCG.FT_SendDate;
                        listCuocGoiHienTai[index].FT_Status = objCG.FT_Status;

                        listCuocGoiHienTai[index].DaGuiDSXeNhan = objCG.DaGuiDSXeNhan;
                        listCuocGoiHienTai[index].CenterConfirm = objCG.CenterConfirm;
                        listCuocGoiHienTai[index].XeDon = objCG.XeDon;
                        listCuocGoiHienTai[index].MH_LenhLaiXe = objCG.MH_LenhLaiXe;
                        listCuocGoiHienTai[index].GhiChuLaiXe = objCG.GhiChuLaiXe;
                        listCuocGoiHienTai[index].MH_SoLanGuiToiXe = objCG.MH_SoLanGuiToiXe;
                        listCuocGoiHienTai[index].MH_ThoiDiemGuiXe = objCG.MH_ThoiDiemGuiXe;
                        listCuocGoiHienTai[index].KhongDungMobileService = objCG.KhongDungMobileService;
                        if (KiemTraCuocGoiCoLoiKhong(listCuocGoiHienTai[index]))
                        {
                            listCuocGoiHienTai.Insert(0, listCuocGoiHienTai[index]);
                            listCuocGoiHienTai.RemoveAt(index + 1);
                        }
                    }
                    if (index != -1 && index <= listCuocGoiHienTai.Count - 1) XuLyThongTinThayDoi(listCuocGoiHienTai[index]);
                }
            }
        }

        /// <summary>
        /// ham nhan cuoc goi moi tu dien thoai ve, va cap nhat vao DB trang thai phan bo cho CS.
        /// </summary>
        private void NhanCuocGoiMoiVaPhanBoCS()
        {
            try
            {
                //List<CuocGoi> lstTongDaiCuocGoiMoi = new List<CuocGoi>();
                //lstTongDaiCuocGoiMoi = GetAllCuocGoiDienThoai(g_lstDienThoai);
                //if ((lstTongDaiCuocGoiMoi != null) && (lstTongDaiCuocGoiMoi.Count > 0)) // Co cuoc goi moi
                //{
                string strSQL = "";
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if (!KiemTraDaDuocPhanBoChua(objDH))
                    {
                        if (g_SoLuongDangNhapCS > 0)
                        {
                            if (g_SoLuongDangNhapCS >= 2) // phan bo deu ra hai may
                            {
                                if (objDH.KieuCuocGoi == KieuCuocGoi.GoiLai)
                                {
                                    // tim lai cuoc goi truoc de xem da phan cho may nao
                                    try
                                    {
                                        //TimPhanBoCSCuocKhachGoiLai(Convert.ToInt64(objDH.CuocGoiLaiIDs));
                                        if (g_IsMayCS1)
                                            g_MayCSDuocPhanBoTruoc = 1;
                                        else
                                            g_MayCSDuocPhanBoTruoc = 2;
                                    }
                                    catch (Exception ex)
                                    {
                                        g_MayCSDuocPhanBoTruoc = 1;
                                    }
                                }
                                else
                                {
                                    if (g_MayCSDuocPhanBoTruoc == 0) g_MayCSDuocPhanBoTruoc = 1;
                                    else if (g_MayCSDuocPhanBoTruoc == 1) g_MayCSDuocPhanBoTruoc = 2;
                                    else if (g_MayCSDuocPhanBoTruoc == 2) g_MayCSDuocPhanBoTruoc = 1;
                                }
                                //strSQL += "  UPDATE T_TAXIOPERATION SET TrangThaiLenh = 5 , CAMON_DanhGia = " + g_MayCSDuocPhanBoTruoc.ToString() + " WHERE ID = " + objDH.IDCuocGoi.ToString() + " AND CAMON_DanhGia IS NULL " + Environment.NewLine;

                            }
                            else
                            {
                                if (g_IsMayCS1)
                                    g_MayCSDuocPhanBoTruoc = 1;
                                else
                                    g_MayCSDuocPhanBoTruoc = 2;
                            }
                            strSQL += "  UPDATE T_TAXIOPERATION SET TrangThaiLenh = 5 , CAMON_DanhGia = " + g_MayCSDuocPhanBoTruoc.ToString() + " WHERE ID = " + objDH.IDCuocGoi.ToString() + " AND CAMON_DanhGia IS NULL " + Environment.NewLine;
                            LuuCuocDaPhanBo(objDH);
                        }
                    }
                }
                // else khong can thuc hien phan bo
                if (strSQL.Length > 0)
                    DieuHanhTaxi.UpdateCSPhanBoCuocGoi(strSQL);


                //}
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// hàm kiểm tra một mã của cuốc gọi đã được phân bổ chưa
        /// trả về : true khi đã phânbổ
        ///          false khi chưa phân bổ
        /// </summary>
        /// <param name="DH"></param>
        /// <returns></returns>
        private bool KiemTraDaDuocPhanBoChua(CuocGoi DH)
        {
            if (g_DSCuocDaPhanBoCS != null && g_DSCuocDaPhanBoCS.Count > 0)
            {
                foreach (long Item in g_DSCuocDaPhanBoCS)
                {
                    if (DH.IDCuocGoi == Item)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// hàm thuc hien luu lai cuoc da phan bo
        /// mục đích là để kiểm soát cuộc đã phân bổ, để không phải phân lại
        /// </summary>
        /// <param name="DH"></param>
        private void LuuCuocDaPhanBo(CuocGoi DH)
        {
            if (g_DSCuocDaPhanBoCS != null)
                g_DSCuocDaPhanBoCS.Insert(0, DH.IDCuocGoi);
        }

        /// <summary>
        /// hàm thực hiện tìm cuốc khách có IDDIeuHanh, 
        /// lấy thông tin máy đã phân bổ.
        /// Nếu không tim thấy đặt = 1  
        /// </summary>
        /// <param name="IDDieuHanh"></param>
        /// <returns></returns>
        private int TimPhanBoCSCuocKhachGoiLai(long IDDieuHanh)
        {
            int retMayPhanBo = 1;
            if (g_lstDienThoai != null && g_lstDienThoai.Count > 0)
            {
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if (objDH.IDCuocGoi == IDDieuHanh)
                    {
                        retMayPhanBo = (int)objDH.CamOn_DanhGia;
                        break;
                    }
                }
            }
            return retMayPhanBo;
        }

        /// <summary>
        /// Load danh sách lái xe của hệ thống
        /// </summary>
        private void LoadListLaiXe()
        {
            G_ListLaiXe = new NhanVien().GetListNhanViens();
        }
        private void HienThiPopupDieuXeStaxi(int RowIndex)
        {
            if (gridCuocGois.SelectedItems.Count <= 0 && gridCuocGois.RowCount > 0)
            {
                gridCuocGois.Row = 0;
            }
            CuocGoi cuocGoi = (CuocGoi)gridCuocGois.GetRow(RowIndex).DataRow;
            if (cuocGoi != null && cuocGoi.FT_IsFT)
            {
                NhapDuLieuVaoTruyenDi(cuocGoi);
            }
        }
        #endregion

        #region ========================Form Events============================

        private void btnHelp_Click(object sender, EventArgs e)
        {
            panelTopHelpEnVang.Visible = !panelTopHelpEnVang.Visible;
        }

        private void HideShowPanel(Panel panel)
        {
            panel.Visible = !panel.Visible;
        }

        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabCuocGoiChoGiaiQuyet")
            {
                g_TabKetThucDuocChon = false;
                g_boolChuyenTabCuocGoiSearch = false;
                //--------------------------LAYOUT-------------------------------------
                //loadLayout(gridCuocGois);

            }
            else if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
                g_TabKetThucDuocChon = true;
                g_boolChuyenTabCuocGoiSearch = false;
                //--------------------------LAYOUT-------------------------------------
                //loadLayout(gridCuocGoi_KetThuc);
            }
            else
            {
                txtDiaChi.Focus();
                g_boolChuyenTabCuocGoiSearch = true;
            }
        }

        /// <summary>
        /// xử lý lênh toolbar
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdTinhTien
            //cmdTraCuuVeHuy
            //cmdHoiThongTin1080
            //cmdXeRaHoatDong
            //cmdXeveGara
            if (e.Command.Key == "cmdCuocThueBao")
            {
                new frmThongTinNhatKyThueBao().Show();
            }
            else if (e.Command.Key == "cmdTinhTien")
            {
                new frmTinhTienTheoKm().Show();
            }
            else if (e.Command.Key == "cmdTraCuuVeHuy")
            {
                using (frmTraCuu frmTraCuu = new frmTraCuu())
                {
                    frmTraCuu.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdHoiThongTin1080")
            {
                using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
                {
                    frmDMDiaDanh.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdCheckCo")
            {
                using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
                {
                    thongTinSanBay_DuongDai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdChotCo_SBDD_Mini")
            {
                using (frmXeBaoDiSanBay_DuongDai_Mini thongTinSanBay_DuongDai = new frmXeBaoDiSanBay_DuongDai_Mini())
                {
                    thongTinSanBay_DuongDai.ShowDialog();
                }
            }
            else if (e.Command.Key == "cmdTraCuuTheMCC")
            {
                new frmMemberCard_Search().ShowDialog();
            }
            else if (e.Command.Key == "cmdTimKiemCuocGoi")
            {
                int TrangThaiCuocGoi = 0;
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
                    TrangThaiCuocGoi = 1;
                else
                    TrangThaiCuocGoi = 2;

                new Taxi.GUI.TimKiemCuocGoi(g_TimeServer, g_strVungsDuocCapPhep, TrangThaiCuocGoi, "4").Show();
            }
            else if (e.Command.Key == "cmdKiemSoatXe")
            {
                if (frmGSXe == null)
                {
                    frmGSXe = new frmGiamSatXe(this, G_ListLaiXe);
                    frmGSXe.Show(this);
                }
            }
            else if (e.Command.Key == "BaoXeDiDuongDai")
            {
                if(ThongTinCauHinh.FT_ChieuVe_Active)
                    new frmUpdateTrip().ShowDialog();
            }
            #region ===== Xe Báo ======
            else if (e.Command.Key == "cmdBaoRaKinhDoanh")
            {
                new frmGiamSatXe_BaoRaKinhDoanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoKhaiThac")
            {
                new frmGiamSatXe_BaoKhaiThac().ShowDialog();
            }
            //else if (e.Command.Key == "cmdBaoHoatDong")
            //{
            //    new frmGiamSatXe_BaoHoatDong().ShowDialog();
            //}
            else if (e.Command.Key == "cmdBaoRoiXe")
            {
                new frmGiamSatXe_BaoRoiXe().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoVe")
            {
                new frmGiamSatXe_BaoVe().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoXinDiemDo")
            {
                new frmGiamSatXe_ChuyenVung_XinDiemDo().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoMatLienLac")
            {
                new frmGiamSatXe_XeMatLienLac().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoAnCa")
            {
                new frmGiamSatXe_AnCa().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoDiemTra")
            {
                new frmGiamSatXe_BaoDiemTra().ShowDialog();
            }
            #endregion
           
            
        }

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdTinhCuoc")
            {
                //    if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0)
                //    {
                //frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                //frm.ShowDialog();
                //}
                //else
                //{
                //    frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                //    frm.ShowDialog();
                //  }

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
            else if (e.Command.Key == "cmdThayDoiMatKhau")
            {
                new CapNhatThongTinCaNhan().ShowDialog();
            }
            else if (e.Command.Key == "cmdTinhCuoc")
            {
                //frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                //frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdLogin")
            {
                CheckIn();

            }
            else if (e.Command.Key == "cmdCheckOut")
            {
                checkout();

            } // cmdTraCuuDiaDanh
            else if (e.Command.Key == "cmdTraCuuDiaDanh")
            {
                new frmDMDiaDanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdBaoKhaiThacCK")
            {
                new frmBaoXeKhaiThac().ShowDialog();
            }
            else if (e.Command.Key == "cmdTroGiup")
            {
                //try
                //{
                //    string HDSDPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                //    HDSDPath = HDSDPath + "\\" + "HDSD.pdf";
                //    System.Diagnostics.Process.Start(HDSDPath);
                //}
                //catch (Exception ex)
                //{
                //    new MessageBox.MessageBox().Show(this, "File hướng dẫn không tồn tại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                //}
            }
            else if (e.Command.Key == "cmdAbout")
            {
                new frmAbout().ShowDialog();
            }
            else if (e.Command.Key == "cmdRefresh")
            {
                g_ListSoHieuXe = Xe.GetListSoHieuXe();
                LoadListLaiXe();
            }
            else if (e.Command.Key == "cmdDMLaiXe")
            {
                new frmDSNhanVien().Show();
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
                        gridLayout.setLayout(gridCuocGois.GetLayout().LayoutString);
                        gridCuocGois.LoadLayout(gridLayout.getLayout(gridCuocGois.GetLayout()));
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhBoDamNEW_V4));
                        gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                       // gridCuocGois.LoadLayout(gridLayout.getLayout(gridCuocGois.GetLayout()));
                    }
                    else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                    {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhBoDamNEW_V4));
                        gridLayout.setLayout(resources.GetString("gridEXLayout3.LayoutString"));
                        gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                    }
                }
            }
            #endregion----------------------------------------------------------------------------------

            else if (e.Command.Key == "cmdTraCuuTheMCC")
            {
                //new TraCuuTheMCC().ShowDialog();
            }
            else if (e.Command.Key == "cmdChotCo")
            {
                new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, "").ShowDialog();
            }
            else if (e.Command.Key == "cmdDSSanBayDuongDai")
            {
                new DSCuocDuongDai_SanBay(G_arrProvince, G_arrDistrict, G_arrCommune).ShowDialog();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_8")
            {
                Config_Common.LuoiCuocGoi_RowHeight_TongDai = 18;
                Config_Common.LuoiCuocGoi_FontSize_TongDai = 9;
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_7")
            {
                Config_Common.LuoiCuocGoi_RowHeight_TongDai = 17;
                Config_Common.LuoiCuocGoi_FontSize_TongDai = 8;
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_6")
            {
                Config_Common.LuoiCuocGoi_RowHeight_TongDai = 15;
                Config_Common.LuoiCuocGoi_FontSize_TongDai = 7;
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_BT")
            {
                Config_Common.LoadConfig_Common();
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_Lon")
            {
                Config_Common.LoadConfig_Common();
                Config_Common.LuoiCuocGoi_RowHeight_TongDai += 5;
                Config_Common.LuoiCuocGoi_FontSize_TongDai +=3;
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdSetStyleGrid_LonNhat")
            {
                Config_Common.LoadConfig_Common();
                Config_Common.LuoiCuocGoi_RowHeight_TongDai += 10;
                Config_Common.LuoiCuocGoi_FontSize_TongDai += 7;
                SetStyleGrid();
            }
            else if (e.Command.Key == "cmdthemThongTinDuongDai")
            {
                if (ThongTinCauHinh.FT_ChieuVe_Active)
                    new frmUpdateTrip().ShowDialog();
            }
            else if (e.Command.Key == "cmdDanhSachXeDiDuongDai")
            {
                new Taxi.Controls.FastTaxis.TaxiDieuXe.frmTestThemMoi().Show();
            }
            else if (e.Command.Key == "cmdReloadBanCo")
            {
                ReloadControlBanCo();
            }
            else if (e.Command.Key == "cmdDisconnectMobile")
            {
                SetCheckMenuDisconnectMobile(ThongTinCauHinh.GPS_TrangThai); // Vì GPS_TrangThai lúc này sẽ ngược lại nên cứ thế gọi gán vào.
                var ketNoiToiMobile = !ThongTinCauHinh.GPS_TrangThai;
                var result = CuocGoi.EnVangVip_sp_ChangeDisconnectMobile(ketNoiToiMobile);
                ThongTinCauHinh.GPS_TrangThai = ketNoiToiMobile;
            }
            else if (e.Command.Key == "cmdCauHinhTapLenh")
            {
                new frmMobileOperationCommands().Show();
            }
        }

        private void SetStyleGrid()
        {
            GridEXFormatStyle style = new GridEXFormatStyle();
            style.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);
            

            gridCuocGois.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);
            gridCuocGois.AlternatingRowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.AlternatingRowFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);

            gridCuocGois.RowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.RowFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);

            gridCuocGois.SelectedFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.SelectedFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai, FontStyle.Bold);

            //gridCuocGois.SelectedFormatStyle.FontBold = TriState.True;
            gridCuocGois.RootTable.RowHeight = Config_Common.LuoiCuocGoi_RowHeight_TongDai;
            gridCuocGois.RootTable.GridEX.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);
            gridCuocGois.FocusCellFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            gridCuocGois.FocusCellFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);

            this.gridCuocGois.PreviewRowFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);
            this.gridCuocGois.PreviewRowFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            
            this.gridCuocGois.SelectedInactiveFormatStyle.Font = new System.Drawing.Font("Tahoma", Config_Common.LuoiCuocGoi_FontSize_TongDai);
            this.gridCuocGois.SelectedInactiveFormatStyle.FontSize = Config_Common.LuoiCuocGoi_FontSize_TongDai;
            //this.gridCuocGois.BackColor = Config_Common.TongDai_MauNen_LuoiCuocGoi;
            this.gridCuocGois.PreviewRowFormatStyle.BackColor = Config_Common.TongDai_MauNen_LuoiCuocGoi;
        }

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (gridCuocGoi_KetThuc.SelectedItems.Count <= 0) return;
            if (e.Command.Key == "mnuThemKhachAo")
            {
                //// GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                //DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem) gridCuocGoi_KetThuc  .SelectedItems[0]).GetRow().DataRow;
                //MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();


                //if (DanhBaKhachAo.GetDanhBa(objDieuHanhTaxi.PhoneNumber ).Length > 0)
                //{

                //    msgDialog.Show(this, "Khách ảo [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] này đã tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information);
                //    return;
                //}
                //if (msgDialog.Show(this, "Bạn có đồng ý đưa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] vào danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                //{
                //    DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber,"", objDieuHanhTaxi.DiaChiDonKhach);
                //    if (objKhachAo.Insert())
                //    {

                //        msgDialog.Show(this, "Thêm mới khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //        return;
                //    }
                //    else
                //    {

                //        msgDialog.Show(this, "Lỗi thêm mới khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information  );
                //        return;
                //    }

                //}

            }
            else if (e.Command.Key == "mnuXoaKhachAo")
            {
                //// GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                //DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                //MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                //if (msgDialog.Show(this, "Bạn có đồng ý xóa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] trong danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                //{
                //    DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber,"", objDieuHanhTaxi.DiaChiDonKhach);
                //    if (objKhachAo.Delete(objDieuHanhTaxi.PhoneNumber ))
                //    {

                //        msgDialog.Show(this, "Xóa khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                //        return;
                //    }
                //    else
                //    {

                //        msgDialog.Show(this, "Lỗi xóa khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information);
                //        return;
                //    }

                //}
            }
            else if (e.Command.Key == "cmdChon20Dong")
            {
                g_SoDong = 20;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_SoDong);
            }
            else if (e.Command.Key == "cmdChon50Dong")
            {
                g_SoDong = 50;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_SoDong);
            }
            else if (e.Command.Key == "cmdChon100Dong")
            {
                g_SoDong = 100;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_SoDong);
            }
            else if (e.Command.Key == "cmdChuyenCuocGoi")
            {
                runChuyenCuocGoi();
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
                    CuocGoi cuocGoiRow = (CuocGoi)gridCuocGoi_KetThuc.GetRow(((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).Position).DataRow;
                    TimeSpan timer = g_TimeServer - cuocGoiRow.ThoiDiemGoi;

                    //if (timer.TotalMinutes > 30)
                    //{
                    //    new MessageBox.MessageBox().Show("Chỉ được phép sửa thông tin cuộc gọi kết thúc trong vòng 30 phút", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    return;
                    //}

                    if (new MessageBox.MessageBoxBA().Show("Bạn có muốn chuyển cuộc gọi: " + cuocGoiRow.DiaChiDonKhach + " không ?", "Thông báo",
                                             Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == "Yes")
                    {
                        CuocGoi.DIENTHOAI_UpdateCGKetThuc2ChuaGiaiQuyet(cuocGoiRow.IDCuocGoi);
                    }
                }
            }
        }
                
        #region Tab Search Cuoc Goi
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

        #endregion
        private void frmDieuHanhBoDamNEW_V3_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessFastTaxi.ketThuc = true;
            //Tổng đài không cần checkout, Tránh checkout nhầm bên Điện Thoại
            //try{
            //    if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
            //    {
            //        ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress);
            //   }
            //}catch(Exception ex){

            //}
        }
        #endregion

        #region XU LY HOTKEY
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    frmBaoXeKhaiThac frmXeKhaithac = new frmBaoXeKhaiThac();
                    frmXeKhaithac.Show();
                    return true;
                case Keys.F2:
                    frmGuiLenhLaiXe frmGuiLenhLaiXe = new frmGuiLenhLaiXe();
                    frmGuiLenhLaiXe.Show();
                    return true;
                case Keys.Alt | Keys.F4:
                    checkout();
                    return true;
                case Keys.Alt | Keys.S:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                    {
                        if (g_boolChuyenTabCuocGoiSearch == true)
                            txtSoDT.Focus();
                        return true;
                    }
                    else break;

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
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 0;
                    return true;
                case Keys.Shift | Keys.D2:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 1)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 1;
                    return true;
                case Keys.Shift | Keys.D3:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 2)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 2;
                    return true;
                case Keys.Shift | Keys.D4:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                    return true;
                case Keys.Shift | Keys.D5:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 4)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 4;
                    return true;
                case Keys.F10:
                    new frmMemberCard_Search().ShowDialog();
                    return true;
                case Keys.Control | Keys.H:
                    if (ThongTinCauHinh.FT_ChieuVe_Active)
                    {
                        ctrlListBook_ChoXuLy.ShowCtrlH();
                        return true;
                    }
                    break;
                    //LuanBH : Check đóng form info popup theo phím tắt
                case Keys.Control | Keys.O:
                    if (openedFormInfos.Count > 0)
                    {
                        KeyValuePair<string, frmInfo> pair = openedFormInfos.ElementAt(openedFormInfos.Count - 1);
                        pair.Value.XuLyLenhLaiXe(1);
                        return true;
                    }
                    break;
                case Keys.Control | Keys.K:
                    if (openedFormInfos.Count > 0)
                    {
                        KeyValuePair<string, frmInfo> pair = openedFormInfos.ElementAt(openedFormInfos.Count - 1);
                        pair.Value.XuLyLenhLaiXe(0);
                        return true;
                    }
                    break;
                case Keys.Alt | Keys.X:
                    if (ThongTinCauHinh.FT_Active)
                    {
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
                    } break;
                case Keys.Alt | Keys.C:
                    if (ThongTinCauHinh.FT_Active)
                    {
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
                    }
                    break;
                case Keys.Control | Keys.D1:
                case Keys.Control | Keys.NumPad1:
                    if (ThongTinCauHinh.FT_Active)
                    {
                        if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                            uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                        tabControl1.SelectedIndex = 0;
                        ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                        return true;
                    } break;
                case Keys.Control | Keys.D2:
                case Keys.Control | Keys.NumPad2:
                    if (ThongTinCauHinh.FT_Active)
                    {
                        if (uiTabCuocGoiDangThucHien.SelectedIndex != 3)
                            uiTabCuocGoiDangThucHien.SelectedIndex = 3;
                        tabControl1.SelectedIndex = 1;
                        ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                        return true;
                    } 
                    break;
                case Keys.Shift | Keys.L:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 0;
                    gridCuocGois.Focus();
                    gridCuocGois.Select();
                    break;

            }

            if (ThongTinCauHinh.FT_Active)
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 3)
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                            return true;
                        if (ctrlListBook_ChoXuLy.FindKeyCommand(keyData))
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

            }
           
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (keyData == (Keys.F1))
            //{
            //    btnHelp_Click(null, null);
            //    return true;
            //}

            return false;
        }
        #endregion

        #region =========================Grid Event============================

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
                frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhan, g_ListSoHieuXe, true, value)
                {
                    G_ListCuocGoi = g_lstDienThoai
                };
                int yRow = this.Height - gridCuocGois.Height - frmInput.Height;//this.Height- positionRowSelect * gridCuocGois.RootTable.RowHeight + 170; // vị trí của dòng đầu tiên cộng thêm.
                //if (yRow > gridCuocGois.Height)
                //{
                //    yRow = this.Height - gridCuocGois.Height - frmInput.Height;
                //}
                frmInput.Location = new Point(625, yRow);
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    string xeNhan = frmInput.GetGiaTriNhap();
                    if (string.IsNullOrEmpty(xeNhan)) return false;
                    var lstXeNhan = xeNhan.Split(".".ToCharArray());
                    var error = string.Empty;
                    foreach (string xe in lstXeNhan)
                    {
                        if(_controlDieuHanhBanCoBanCo.dicGiamSat_AnCa.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang ăn ca. Xin nhập lại", xe);
                            break;
                        }
                        if (_controlDieuHanhBanCoBanCo.dicGiamSat_MatLL.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang mất liên lạc. Xin nhập lại", xe);
                            break;
                        }
                        if (_controlDieuHanhBanCoBanCo.dicGiamSat_RoiXe.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} đang rời xe. Xin nhập lại", xe);
                            break;
                        }
                        if (_controlDieuHanhBanCoBanCo.dicGiamSat_BaoHong.ContainsKey(xe))
                        {
                            error = string.Format("Xe {0} báo hỏng. Vui lòng điều xe khác", xe);
                            break;
                        }

                        //if (Config_Common.ChenCuoc_HoaHong)
                        //{
                        //    if (_controlDieuHanhBanCoBanCo.dicXeHoatDong.ContainsKey(xe))
                        //    {
                        //        GiamSatXe_HoatDong item = _controlDieuHanhBanCoBanCo.dicXeHoatDong[xe];
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
                    }

                    if(!string.IsNullOrEmpty(error))
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, error, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return false;
                    }

                    //var messageCarExistsInGrid = KiemTraXeCoTrongCuocKhachHienTai(cuocGoiRow.IDCuocGoi, xeNhan);
                    //if (!string.IsNullOrEmpty(messageCarExistsInGrid))
                    //{
                    //    var result = new MessageBox.MessageBox().Show(this, messageCarExistsInGrid, "Thông báo", MessageBox.MessageBoxButtons.OKCancel, MessageBox.MessageBoxIcon.Question);
                    //    if (result != "OK") return false;
                    //}

                    cuocGoiRow.XeNhan = xeNhan;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    if (!string.IsNullOrEmpty(cuocGoiRow.XeNhan) && 
                        (cuocGoiRow.DaGuiDSXeNhan == null || cuocGoiRow.DaGuiDSXeNhan == 0) && 
                        !Global.ChoPhepDienThoaiNhapXe
                        && CanSendMobile(cuocGoiRow.KhongDungMobileService)
                        && !cuocGoiRow.KhongDungMobileService.Value
                        )
                    {
                        if (EnVangProcess.SendInitTrip(cuocGoiRow))
                        {
                            CuocGoi.DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(cuocGoiRow.IDCuocGoi, 1);
                        }
                        else
                        {
                            CuocGoi.DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(cuocGoiRow.IDCuocGoi, 0);
                        }
                    }
                    return true;
                }
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }

        private bool NhapXeDenDiem(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                if (isChoice)
                {
                    using (frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            cuocGoiRow.XeDenDiem = frmInput.GetGiaTriChon();
                            if (Config_Common.ChenXeDenDiemVaoXeNhan == 1)
                            {
                                if (frmInput.GetGiaTriNhap().Length > 0)
                                    cuocGoiRow.XeNhan += "." + frmInput.GetGiaTriNhap();
                            }
                          
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            //Nếu xe đón không thuộc xe nhận thì tự động nhập xe đón vào xe nhận
                            //if (!cuocGoiRow.XeNhan.Contains(cuocGoiRow.XeDenDiem))
                            //{
                            //    if (cuocGoiRow.XeNhan.Length <= 0)
                            //        cuocGoiRow.XeNhan = cuocGoiRow.XeDenDiem;
                            //    else
                            //        cuocGoiRow.XeNhan += "." + cuocGoiRow.XeDenDiem;
                            //}
                            return true;
                        }
                    }
                }
                else
                {
                    // Hiển thị ô nhập  
                    using (frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeNhanDenDiem, g_ListSoHieuXe, true, value))
                    {
                        frmInput.G_ListCuocGoi = g_lstDienThoai;
                        int yRow = this.Height - gridCuocGois.Height - frmInput.Height;// positionRowSelect * gridCuocGois.RootTable.RowHeight + 170;
                        // vị trí của dòng đầu tiên cộng thêm.
                        //if (yRow > gridCuocGois.Height)
                        //{
                        //    yRow = gridCuocGois.Height - frmInput.Height;
                        //}
                        frmInput.Location = new Point(325, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            var xeDenDiem = frmInput.GetGiaTriNhap();
                            if (string.IsNullOrEmpty(xeDenDiem)) return false;
                            string error = string.Empty;
                            if (string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                            {
                                error = "Hãy nhập xe nhận trước";
                            }

                            if (!EnVangManagement.KiemTraPTDSThuocDSKhac(xeDenDiem, cuocGoiRow.XeNhan))
                            {
                                error = "Hãy nhập xe đến điểm thuộc danh sách xe nhận";
                            }
                            
                            if(!string.IsNullOrEmpty(error))
                            {
                                new Taxi.MessageBox.MessageBoxBA().Show(this, error, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                return false;
                            }

                            cuocGoiRow.XeDenDiem = xeDenDiem;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }

        private void HienThiNhapXeDenDiem()
        {
            CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
            int positionRowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position;
            bool hasThucHienLenh = false;
            hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", true);
            // có thực hiện lệnh, gọi cập nhật 
            if (hasThucHienLenh)
            {
                cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi(cuocGoiRow))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                else //
                {
                    if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                    {
                        SapXepLaiIndex(cuocGoiRow);
                        // remove tai luoi
                        g_lstDienThoai.Remove(cuocGoiRow);
                        HienThiTrenLuoi(false, false);
                        if (!bwSync_RemoveCuocGoi.IsBusy)
                        {                            
                            //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                            bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                        }
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                        HienThiTrenLuoi(true, false);
                    }

                }
            }
        }

        private void HienThiNhapXeDon()
        {
            CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
            int positionRowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position;
            bool hasThucHienLenh = false;
            hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", true);
            // có thực hiện lệnh, gọi cập nhật 
            if (hasThucHienLenh)
            {
                cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi(cuocGoiRow))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    return;
                }
                else //
                {
                    if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                    {
                        SapXepLaiIndex(cuocGoiRow);
                        // remove tai luoi
                        g_lstDienThoai.Remove(cuocGoiRow);
                        HienThiTrenLuoi(false, false);

                        #region SendToMasterSignedCar - Nhập xe đón
                        //Xe đón thay đổi thì xử lý gửi
                        //if (cuocGoiRow.FT_IsFT)
                        //{
                        //    SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeDon);
                        //}
                        #endregion
                        if (!bwSync_RemoveCuocGoi.IsBusy)
                        {
                            //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                            bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                        }
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                        HienThiTrenLuoi(true, false);
                    }

                }
            }
        }

        private bool NhapXeDon(CuocGoi cuocGoiRow, int positionRowSelect, string value, bool isChoice)
        {
            if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
            {
                //Nếu là cuộc gọi FastTaxi và khách hàng chưa xác nhận đã gặp xe thì cảnh báo
                if (cuocGoiRow.FT_IsFT && cuocGoiRow.FT_Status != Enum_FastTaxi_Status.NhapXeDon )
                {
                    if (new MessageBox.MessageBoxBA().Show("Khách hàng chưa xác nhận đã gặp xe. Bạn có muốn tiếp tục nhập xe đón không ?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question).ToLower().Equals("no"))
                    {
                        return false;
                    }
                }
                if (isChoice)
                {
                    // Hiển thị ô nhập  
                    using (frmInputXeNhan_Don frmInput = new frmInputXeNhan_Don(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value))
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
                                cuocGoiRow.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
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
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, true, value);
                    int yRow = this.Height - gridCuocGois.Height - frmInput.Height;// positionRowSelect * gridCuocGois.RootTable.RowHeight + 170; // vị trí của dòng đầu tiên cộng thêm.
                    //if (yRow > gridCuocGois.Height)
                    //{
                    //    yRow = gridCuocGois.Height - frmInput.Height;
                    //}
                    frmInput.Location = new Point(340, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        var xeDon = frmInput.GetGiaTriNhap();

                        string error = string.Empty;
                        if (string.IsNullOrEmpty(cuocGoiRow.XeDenDiem))
                        {
                            error = "Hãy nhập xe đến điểm trước";
                        }

                        if (!EnVangManagement.KiemTraPTDSThuocDSKhac(xeDon, cuocGoiRow.XeNhan))
                        {
                            error = "Hãy nhập xe đón thuộc danh sách xe đến điểm";
                        }

                        if (!string.IsNullOrEmpty(error))
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, error, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                            return false;
                        }

                        cuocGoiRow.XeDon = xeDon;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                        cuocGoiRow.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                        SapXepLaiIndex(cuocGoiRow);
                        g_lstDienThoai.Remove(cuocGoiRow);
                        HienThiTrenLuoi(false, false);
                        return true;
                    }
                }
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe đón.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
            return false;
        }


        /// <summary>
        /// Xus the ly cuoc goi huy.
        /// </summary>
        /// <param name="cuocGoi">The cuoc goi.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/13/2015   created
        /// </Modified>
        private void XuLyCuocGoiHuy(ref CuocGoi cuocGoi)
        {
            cuocGoi.LenhTongDai = EnVangManagement.LENH_HUYXE;
            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
            
            EnVangProcess.SendOperatorCancel(cuocGoi);
            #region Gửi đã Hoãn tới Cho fastTaxi nếu là cuốc của fastTaxi
            if (cuocGoi.FT_IsFT)
            {
                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Hoan_DaHoan);
            }
            #endregion
        }

        private void XuLyCuocGoiTruot(ref CuocGoi cuocGoi)
        {
            cuocGoi.LenhTongDai = EnVangManagement.LENH_TRUOTCHUA;
            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
            if(cuocGoi.MH_LenhLaiXe != EnVangManagement.LENH_TRUOTCHUA && 
                !cuocGoi.KhongDungMobileService.Value) 
                EnVangProcess.SendOperatorCancel(cuocGoi);
        }

        /// <summary>
        /// Xử lý key down dòng trong trường hợp én vàng không cho phép điều hành điều xe
        /// </summary>
        /// <param name="msgDialog">The MSG dialog.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        /// <param name="cuocGoiRow">The cuoc goi row.</param>
        /// <param name="hasThucHienLenh">if set to <c>true</c> [has thuc hien lenh].</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/13/2015   created
        /// </Modified>
        private void XuLyKeyDownTrenDongNew(MessageBox.MessageBoxBA msgDialog, KeyEventArgs e, CuocGoi cuocGoiRow, int positionRowSelect, ref bool hasThucHienLenh)
        {
            // Thực hiện lệnh theo cấu hình trong bảng lệnh
            if (MangerCommand.ProcessMobileCommandByKey(e.KeyCode, ref cuocGoiRow, ref hasThucHienLenh)) { hasThucHienLenh = true; return; }
            if (e.KeyCode == Keys.Enter)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi(cuocGoiRow);
                // lua cho dong lua chon dau tien

            }
            #region ================ 1 :  Mời khách
            else if ((e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1))
            {
                // thực hiện khi có xe nhận
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                {
                    string LenhTongDai_Old = cuocGoiRow.LenhTongDai;
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_1_MOIKHACH;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    cuocGoiRow.ChuyenMK = true;
                    #region Gửi mời khách đến fastTaxi là cuốc fastTaxi
                    if (cuocGoiRow.FT_IsFT && LenhTongDai_Old != LENH_1_MOIKHACH)
                    {
                        //Mời khách
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.MoiKhach);
                    }
                    #endregion
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_1_MOIKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== 2 : Không xe lần 1
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    if (cuocGoiRow.XeNhan.Trim().Length > 0 || cuocGoiRow.XeDon.Trim().Length > 0)
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi đã có xe nhận hoặc xe đón.", LENH_3_KHONGXE),
                            "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    else
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_2_KHONGXE_XINLOI1;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                        cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1;
                    }
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_2_KHONGXE_XINLOI1), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                #region Gửi không xe tới Cho fastTaxi nếu là cuốc của fastTaxi
                if (hasThucHienLenh && cuocGoiRow.FT_IsFT)
                {

                    //“[Không xe]”
                    //Func<bool> func = () => Service_Common.FastTaxi.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Taxi.Services.FastTaxi_OperationService.Enum_TaxiOperation_CallStatus.KhongXe);
                    //var content = string.Format("1.Không xe");
                    //Create_SendFastTaxi(func, cuocGoiRow.IDCuocGoi, content, Enum_FastTaxi_Status.MoiKhach);
                }
                #endregion
            }
            #endregion

            #region ============== 3 : Không xe
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    if (cuocGoiRow.XeNhan.Trim().Length > 0)
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi đã có xe nhận đón.", LENH_3_KHONGXE),
                            "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    else
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_3_KHONGXE;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam; cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                        #region Gửi không xe tới Cho fastTaxi nếu là cuốc của fastTaxi
                        if (cuocGoiRow.FT_IsFT)
                        {
                            //Không xe
                            SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.KhongXe);
                        }
                        #endregion
                    }

                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_3_KHONGXE), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }

            }
            #endregion

            #region ============== 4 : hỏi lại địa chỉ
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_4_HOILAIDC;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_4_HOILAIDC), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== 5 : giữ khách
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_5_GIUKHACH;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_5_GIUKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== 6 : Kiểm tra khách
            else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_6_KTRAKHACH;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_6_KTRAKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== 7 : Mời khách lần 2
            else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_7_MOIKHACHLAN2;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    cuocGoiRow.ChuyenMK = true;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_7_MOIKHACHLAN2), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                #region Gửi mời khách lần 2 tới Cho fastTaxi nếu là cuốc của fastTaxi
                //if (hasThucHienLenh && cuocGoiRow.FT_IsFT)
                //{
                //    ////Mời khách 2
                //    //var flg = Service_Common.FastTaxi.SendToMasterCatchingCar(cuocGoiRow.PhoneNumber);
                //    ////“[Địa chỉ đón]-[Địa chỉ trả]-[SL xe]-[Loại xe]-[Xe nhận]”
                //    //var content = string.Format("1.{0}-{1}-{2}-{3}-{4}", cuocGoiRow.DiaChiDonKhach, cuocGoiRow.DiaChiTraKhach, cuocGoiRow.SoLuong, cuocGoiRow.LoaiXe, cuocGoiRow.XeNhan);
                //    //CuocGoi.FT_History_Create((int)cuocGoiRow.IDCuocGoi, content, (int)Enum_FastTaxi_Status.MoiKhach, true, flg);
                //}
                #endregion
            }
            #endregion

            #region ============== 8 : Ra đầu ngõ
            else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_8_RADAUNGO;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_8_RADAUNGO), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== 9 : Tiếp thị 7C/4C
            else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_9_TIEPTHIXEKHAC;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi", LENH_9_TIEPTHIXEKHAC), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ============== G : Gặp chưa?
            else if (e.KeyCode == Keys.G)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = LENH_GAPCHUA;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_GAPCHUA), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion
            else if (e.KeyCode == Keys.H)
            {
                string dialog = msgDialog.Show(string.Format("Hủy cuốc {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (dialog == "Yes")
                {
                    XuLyCuocGoiHuy(ref cuocGoiRow);
                    hasThucHienLenh = true;
                }
            }

            #region ================ T : Truot
            else if (e.KeyCode == Keys.T)
            {
                if (cuocGoiRow.XeDon == "")
                {
                    new MessageBox.MessageBoxBA().Show("Cuộc gọi phải là gọi taxi và có xe nhận đón");
                    return;
                }
                else
                {
                    string dialog = msgDialog.Show(string.Format("Trượt cuốc {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                    if (dialog == "Yes")
                    {
                        XuLyCuocGoiTruot(ref cuocGoiRow);
                        hasThucHienLenh = true;
                    }
                }
                
            }
            #endregion

            #region Không xe

            else if (e.KeyCode == Keys.O)
            {
                if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                {
                    if (cuocGoiRow.XeDon.Trim().Length > 0)
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi đã có xe nhận đón.", LENH_3_KHONGXE),
                            "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    else
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_3_KHONGXE;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam; cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                    }
                }
                else
                {
                    msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_3_KHONGXE), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            #endregion

            #region ================= / / F2 : chon nhap xe nhan
            else if ((e.KeyCode == Keys.Divide || e.KeyCode == Keys.F2) && (cuocGoiRow.DaGuiDSXeNhan == null || cuocGoiRow.DaGuiDSXeNhan == 0))
            {
                var xenhanCurrent = cuocGoiRow.XeNhan;
                hasThucHienLenh = NhapXeNhan(cuocGoiRow, positionRowSelect, "");
            }
            else if (e.KeyCode == Keys.Back)
            {
                // thực hiện khi có xe nhận
                if (cuocGoiRow.LenhTongDai != "")
                {
                    hasThucHienLenh = true;
                    cuocGoiRow.LenhTongDai = "";
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                }
            }
            #endregion

            #region ================= */F3 : chon nhap xe den diem
            else if (!CanSendMobile(cuocGoiRow.KhongDungMobileService) && (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.F3))
            {

                var xeDenDiemCurrent = cuocGoiRow.XeDenDiem;
                hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", false);
            }
            #endregion

            #region ================= - / F4 : chon nhap Xe Don
            else if (!CanSendMobile(cuocGoiRow.KhongDungMobileService) && (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.F4))
            {
                var xeDonCurrent = cuocGoiRow.XeDon;
                hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", false);
            }
            #endregion
        }

        /// <summary>
        /// Xử Lý Keydown cũ
        /// </summary>
        /// <param name="msgDialog">The MSG dialog.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        /// <param name="cuocGoiRow">The cuoc goi row.</param>
        /// <param name="positionRowSelect">The position row select.</param>
        /// <param name="hasThucHienLenh">if set to <c>true</c> [has thuc hien lenh].</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/13/2015   created
        /// </Modified>
        private void XuLyKeyDownTrenDongOLD(MessageBox.MessageBoxBA msgDialog, KeyEventArgs e, CuocGoi cuocGoiRow, int positionRowSelect, ref bool hasThucHienLenh)
        {
            if (e.KeyCode == Keys.Enter)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(cuocGoiRow);
                    // lua cho dong lua chon dau tien

                }

                #region ================ 1 :  Mời khách
                else if ((e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1))
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && !string.IsNullOrEmpty(cuocGoiRow.XeNhan))
                    {
                        string LenhTongDai_Old = cuocGoiRow.LenhTongDai;
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_1_MOIKHACH;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                        cuocGoiRow.ChuyenMK = true;
                        #region Gửi mời khách đến fastTaxi là cuốc fastTaxi
                        if (cuocGoiRow.FT_IsFT && LenhTongDai_Old != LENH_1_MOIKHACH)
                        {
                            //Mời khách
                            SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.MoiKhach);
                        }
                        #endregion
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_1_MOIKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }                    
                }
                #endregion

                #region ============== 2 : Không xe lần 1
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        if (cuocGoiRow.XeNhan.Trim().Length > 0 || cuocGoiRow.XeDon.Trim().Length > 0)
                        {
                            msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi đã có xe nhận hoặc xe đón.", LENH_3_KHONGXE),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                        else
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.LenhTongDai = LENH_2_KHONGXE_XINLOI1;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1;
                        }
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_2_KHONGXE_XINLOI1), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    #region Gửi không xe tới Cho fastTaxi nếu là cuốc của fastTaxi
                    if (hasThucHienLenh && cuocGoiRow.FT_IsFT)
                    {
                       
                        //“[Không xe]”
                        //Func<bool> func = () => Service_Common.FastTaxi.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Taxi.Services.FastTaxi_OperationService.Enum_TaxiOperation_CallStatus.KhongXe);
                        //var content = string.Format("1.Không xe");
                        //Create_SendFastTaxi(func, cuocGoiRow.IDCuocGoi, content, Enum_FastTaxi_Status.MoiKhach);
                    }
                    #endregion
                }
                #endregion

                #region ============== 3 : Không xe
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        if (cuocGoiRow.XeNhan.Trim().Length > 0)
                        {
                            msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi đã có xe nhận đón.", LENH_3_KHONGXE),
                                "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                        else
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.LenhTongDai = LENH_3_KHONGXE;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                            #region Gửi không xe tới Cho fastTaxi nếu là cuốc của fastTaxi
                            if (cuocGoiRow.FT_IsFT)
                            {
                                //Không xe
                                SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.KhongXe);
                            }
                            #endregion
                        }
                     
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_3_KHONGXE), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    
                }
                #endregion

                #region ============== 4 : hỏi lại địa chỉ
                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_4_HOILAIDC;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_4_HOILAIDC), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== 5 : giữ khách
                else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_5_GIUKHACH;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_5_GIUKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== 6 : Kiểm tra khách
                else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_6_KTRAKHACH;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_6_KTRAKHACH), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== 7 : Mời khách lần 2
                else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_7_MOIKHACHLAN2;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                        cuocGoiRow.ChuyenMK = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_7_MOIKHACHLAN2), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    #region Gửi mời khách lần 2 tới Cho fastTaxi nếu là cuốc của fastTaxi
                    //if (hasThucHienLenh && cuocGoiRow.FT_IsFT)
                    //{
                    //    ////Mời khách 2
                    //    //var flg = Service_Common.FastTaxi.SendToMasterCatchingCar(cuocGoiRow.PhoneNumber);
                    //    ////“[Địa chỉ đón]-[Địa chỉ trả]-[SL xe]-[Loại xe]-[Xe nhận]”
                    //    //var content = string.Format("1.{0}-{1}-{2}-{3}-{4}", cuocGoiRow.DiaChiDonKhach, cuocGoiRow.DiaChiTraKhach, cuocGoiRow.SoLuong, cuocGoiRow.LoaiXe, cuocGoiRow.XeNhan);
                    //    //CuocGoi.FT_History_Create((int)cuocGoiRow.IDCuocGoi, content, (int)Enum_FastTaxi_Status.MoiKhach, true, flg);
                    //}
                    #endregion
                }
                #endregion

                #region ============== 8 : Ra đầu ngõ
                else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_8_RADAUNGO;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_8_RADAUNGO), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== 9 : Tiếp thị 7C/4C
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_9_TIEPTHIXEKHAC;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi", LENH_9_TIEPTHIXEKHAC), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== G : Gặp chưa?
                else if (e.KeyCode == Keys.G)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan != null && cuocGoiRow.XeNhan != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = LENH_GAPCHUA;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi. Và đã có xe nhận", LENH_GAPCHUA), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============== Backspace : xóa lệnh
                else if (e.KeyCode == Keys.Back)
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.LenhTongDai != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = "";
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.BoDam;
                    }
                }
                #endregion

                #region ============== K : chuyển kênh
                else if (e.KeyCode == Keys.K)
                {

                    // Hiển thị ô nhập  
                    frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapChuyenKenh, g_ListSoHieuXe, true)
                    {
                        G_ListCuocGoi = g_lstDienThoai
                    };
                    int yRow = positionRowSelect * gridCuocGois.RootTable.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                    if (yRow > gridCuocGois.Height)
                    {
                        yRow = gridCuocGois.Height - frmInput.Height;
                    }
                    frmInput.Location = new Point(625, yRow);
                    if (frmInput.ShowDialog() == DialogResult.OK)
                    {
                        SapXepLaiIndex(cuocGoiRow);
                        g_lstDienThoai.Remove(cuocGoiRow);
                        //TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                        HienThiTrenLuoi(false, false); // Refresh
                    }
                }
                #endregion

            #region ============== + : Ghi Chú điều
            else if (e.KeyCode == Keys.Add)
            {
                // Hiển thị ô nhập  
                frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapGhiChuTongDai, g_ListSoHieuXe, true)
                {
                    G_ListCuocGoi = g_lstDienThoai
                };
                int yRow = positionRowSelect * gridCuocGois.RootTable.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                if (yRow > gridCuocGois.Height)
                {
                    yRow = gridCuocGois.Height - frmInput.Height;
                }
                frmInput.Location = new Point(625, yRow);
                if (frmInput.ShowDialog() == DialogResult.OK)
                {
                    cuocGoiRow.GhiChuTongDai = frmInput.GetGiaTriNhap();
                  //  cuocGoiRow.XeDungDiem
                    HienThiTrenLuoi(true, false);
                }
            }
            #endregion

                #region ================= / / F2 : chon nhap xe nhan
                else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.F2)
                {
                    var xenhanCurrent = cuocGoiRow.XeNhan;
                    hasThucHienLenh = NhapXeNhan(cuocGoiRow, positionRowSelect, "");

                    #region Gửi xe nhận tới Cho fastTaxi nếu là cuốc của fastTaxi
                    if (hasThucHienLenh && cuocGoiRow.FT_IsFT && xenhanCurrent.Trim() != cuocGoiRow.XeNhan.Trim())
                    {
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeNhan);
                    }
                    #endregion
                }
                #endregion

                #region ================= */F3 : chon nhap xe den diem
                else if (e.KeyCode == Keys.Multiply || e.KeyCode == Keys.F3)
                {

                    var xeDenDiemCurrent = cuocGoiRow.XeDenDiem;
                    hasThucHienLenh = NhapXeDenDiem(cuocGoiRow, positionRowSelect, "", false);
                    #region Gửi xe nhận tới Cho fastTaxi nếu là cuốc của fastTaxi
                    if (hasThucHienLenh && cuocGoiRow.FT_IsFT && xeDenDiemCurrent.Trim() != cuocGoiRow.XeDenDiem.Trim())
                    {
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeNhan_XeDenDiem);
                    }
                    #endregion
                }
                #endregion

                #region ================= - / F4 : chon nhap Xe Don
                else if ((e.KeyCode == Keys.Subtract || e.KeyCode == Keys.F4))
                {
                    var xeDonCurrent = cuocGoiRow.XeDon;
                    hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "", false);

                    #region SendToMasterSignedCar - Nhập xe đón
                    //Xe đón thay đổi thì xử lý gửi
                    if (cuocGoiRow.FT_IsFT&&hasThucHienLenh && xeDonCurrent != cuocGoiRow.XeDon && cuocGoiRow.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach &&
                        cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                    {
                        SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.NhapXeDon);
                    }
                    #endregion
                }
                #endregion

                #region ================= T : Ket thuc truot
                else if (e.KeyCode == Keys.T)
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeDon != null && cuocGoiRow.XeDon.Length > 0)
                    {
                        string dialog = msgDialog.Show(string.Format("Trượt cuốc {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                        if (dialog == "Yes")
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.LenhTongDai = LENH_Truot;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiTruot;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                            #region Gửi trượt tới Cho fastTaxi nếu là cuốc của fastTaxi
                            // trượt
                            if (cuocGoiRow.FT_IsFT)
                            {
                                SendFastTaxi(cuocGoiRow, Enum_FastTaxi_Status.Truot);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh trượt] " + "Cuộc gọi phải là gọi taxi và có xe nhận đón.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                    
                }
                #endregion

                #region ================= H : Ket thuc hoãn
                else if (e.KeyCode == Keys.H)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && cuocGoiRow.XeNhan=="")
                    {
                        string dialog = msgDialog.Show(string.Format("Hoãn cuốc {0}...?", cuocGoiRow.DiaChiDonKhach), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                        if (dialog == "Yes")
                        {
                            hasThucHienLenh = true;
                            cuocGoiRow.LenhTongDai = LENH_Hoan;
                            cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiHoan;
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                        
                            #region Gửi Hoãn tới Cho fastTaxi nếu là cuốc của fastTaxi
                            if (cuocGoiRow.FT_IsFT)
                            {
                               SendFastTaxi( cuocGoiRow, Enum_FastTaxi_Status.Hoan);
                            }
                            #endregion
                        }
                    }
                    else 
                    {
                        msgDialog.Show(this, "[Lệnh hoãn] " + "Cuội gọi phải là cuộc gọi taxi và chưa có xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }                    
                }
                #endregion

                #region ================= L : Ket thuc cuộc gọi lại
                else if (e.KeyCode == Keys.L)
                {

                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiLai)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = "Gọi lại";
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh gọi lại] Cuội gọi phải là cuộc gọi lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ================= M : Ket thuc cuộc gọi hỏi đàm
                else if (e.KeyCode == Keys.M)
                {

                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiHoiDam)
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.LenhTongDai = "Hỏi đàm";
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh hỏi đàm] Cuội gọi phải là cuộc gọi hỏi đàm.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ================= X : Chuyển thành Gọi Taxi
                else if (e.KeyCode == Keys.C)
                {

                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiLai)
                    {
                        CuocGoi.TONGDAI_UpdateCuocGoiTaxi(cuocGoiRow.IDCuocGoi);
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh Gọi Taxi] Cuội gọi phải là cuộc gọi lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                #endregion

                #region ============Gửi tin nhắn
                //else if (e.KeyCode == Keys.G)
                //{
                //    if (ThongTinDangNhap.PermissionsFull.Contains(DanhSachQuyen.TagGuiTinNhan))
                //    {
                //        int KenhVung = cuocGoiRow.Line;
                //        if (KenhVung > 0)
                //        {
                //            string TieuDe = "Tin nhắn gửi từ máy ĐHV số " + g_strVungsDuocCapPhep;

                //            string NoiDung = string.Format("Thời điểm gọi : {0}{1} Số điện thoại : {2}{3} Địa chỉ : {4}{5}"
                //                                            , cuocGoiRow.ThoiDiemGoi.ToShortTimeString(), Environment.NewLine
                //                                            , cuocGoiRow.PhoneNumber, Environment.NewLine
                //                                            , cuocGoiRow.DiaChiDonKhach, Environment.NewLine);
                //            string TaiKhoan = Users.GetIPByVungKenh(KenhVung.ToString());

                //            SendMessage frmMessage = new SendMessage(TieuDe, NoiDung, TaiKhoan);
                //            frmMessage.Show();
                //        }
                //    }
                //    else
                //    {
                //        msgDialog.Show(this, "Bạn không có quyền gửi tin nhắn.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                //    }

                //}
                #endregion

                #region Control|C : Copy
                else if (e.KeyData == (Keys.Control | Keys.C))
                {
                    GridEXColumn col = gridCuocGois.CurrentColumn;
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
                #endregion

                #region B : Bản đồ
                else if (e.KeyData == Keys.B)
                {
                    new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                }
                else if (e.KeyData == (Keys.Control | Keys.B))
                {
                    if (frm_BanDo != null && frm_BanDo.Visible)
                    {
                        HienThiBanDo(null, false);
                    }
                    else
                    {
                        HienThiBanDo(cuocGoiRow, true);
                        gridCuocGois.Focus();
                    }
                }
                #endregion

                #region  X : Thoat cuoc don khach khong xac dinh
                else if (e.KeyData == Keys.X)
                {
                    hasThucHienLenh = NhapXeDon(cuocGoiRow, positionRowSelect, "000", false);
                }

                #endregion
        }

        #region Cuộc gọi chờ giải quyết
        private void gridDienThoai_DoubleClick(object sender, EventArgs e)
        {
            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi((CuocGoi)gridCuocGois.GetRow(((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position).DataRow);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.RowCount > 0)
            {
                if (gridCuocGois.SelectedItems.Count <= 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        gridCuocGois.Row = 0;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        gridCuocGois.Row = gridCuocGois.RowCount - 1;
                    }
                }
                //if (gridCuocGois.SelectedItems.Count > 0)
                //{
                CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
                int positionRowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position;
                bool hasThucHienLenh = false;  // dung de xac dinh có thay đổi dữ liệu và gọi update
                string xeNhanCu = cuocGoiRow.XeNhan;
                #region Xem lịch sử cuốc điều
                if (e.KeyData == (Keys.Control | Keys.H) && cuocGoiRow.FT_IsFT)
                {
                    new frmLichSuCuocDieu(cuocGoiRow).ShowDialog();
                    return;
                }
                #endregion

                if (EnVangManagement.ConfigEnVang) XuLyKeyDownTrenDongNew(msgDialog, e, cuocGoiRow, positionRowSelect, ref hasThucHienLenh);
                else XuLyKeyDownTrenDongOLD(msgDialog, e, cuocGoiRow, positionRowSelect, ref hasThucHienLenh);

                #region có thực hiện lệnh, gọi cập nhật
                if (hasThucHienLenh)
                {
                    //Chuyen sang moi khách
                    if (cuocGoiRow.LenhTongDai == LENH_1_MOIKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_5_GIUKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_4_HOILAIDC ||
                        cuocGoiRow.LenhTongDai == LENH_2_KHONGXE_XINLOI1 ||
                        cuocGoiRow.LenhTongDai == LENH_6_KIENTRAKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_3_KHONGXE ||
                        cuocGoiRow.LenhTongDai == LENH_6_KTRAKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_7_MOIKHACHLAN2 ||
                        cuocGoiRow.LenhTongDai == LENH_GAPCHUA)
                    {
                        cuocGoiRow.ChuyenMK = true;
                    }
                    cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_EV(cuocGoiRow))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                    else //
                    {
                        if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            SapXepLaiIndex(cuocGoiRow);
                            // remove tai luoi
                            g_lstDienThoai.Remove(cuocGoiRow);
                            HienThiTrenLuoi(false, false);
                            if (!bwSync_RemoveCuocGoi.IsBusy)
                            {
                                //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                                bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                            }
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                            HienThiTrenLuoi(true, false);
                        }

                    }
                }
                #endregion

            }
        }

        private void gridCuocGois_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void gridCuocGois_LoadingRow(object sender, RowLoadEventArgs e)
        {
            //if (e.Row.RowType == RowType.Record && e.Row.Cells["LoaiXe"].Value != null)
            //{
            //    string loaiXe = e.Row.Cells["LoaiXe"].Value.ToString();
            //    if (loaiXe != null && loaiXe != "0")
            //        e.Row.Cells["LX_DiaChi"].Text = string.Format("[{0}]-{1}", e.Row.Cells["LoaiXe"].Value, e.Row.Cells["DiaChiDonKhach"].Value);

            //    else
            //        e.Row.Cells["LX_DiaChi"].Text = e.Row.Cells["DiaChiDonKhach"].Value.ToString();
            //}
        }

        private void gridCuocGois_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGois_SelectionChanged(object sender, EventArgs e)
        {
            if (!isThemMoi)
            {
                gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridCuocGois.SelectedItems.Count > 0)
                {
                    CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
                    if (cuocGoiRow != null)
                    {
                        lblSdt.Text = cuocGoiRow.PhoneNumber;
                        lblDiaChi.Text = cuocGoiRow.DiaChiDonKhach;
                        lblDTV.Text = cuocGoiRow.LenhDienThoai;
                        if (g_RowIndex != gridCuocGois.CurrentRow.RowIndex)
                        {
                            if (frm_BanDo != null && frm_BanDo.Visible)
                            {
                                HienThiBanDo(cuocGoiRow, false);
                            }
                            g_RowIndex = gridCuocGois.CurrentRow.RowIndex;
                        }
                    }
                }
            }
        }

        #endregion

        #region Da Don Khach
        private void grid_DaDonKhach_DoubleClick(object sender, EventArgs e)
        {
            grid_DaDonKhach.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grid_DaDonKhach.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi((CuocGoi)grid_DaDonKhach.GetRow(((GridEXSelectedItem)grid_DaDonKhach.SelectedItems[0]).Position).DataRow);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_DaDonKhach_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            grid_DaDonKhach.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grid_DaDonKhach.RowCount > 0)
            {
                if (grid_DaDonKhach.SelectedItems.Count <= 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        grid_DaDonKhach.Row = 0;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        grid_DaDonKhach.Row = grid_DaDonKhach.RowCount - 1;
                    }
                }
                CuocGoi cuocGoiRow = (CuocGoi)grid_DaDonKhach.SelectedItems[0].GetRow().DataRow;
                int positionRowSelect = ((GridEXSelectedItem)grid_DaDonKhach.SelectedItems[0]).Position;
                bool hasThucHienLenh = false;  // dung de xac dinh có thay đổi dữ liệu và gọi update
                string xeNhanCu = cuocGoiRow.XeNhan;
                #region Xem lịch sử cuốc điều
                if (e.KeyData == (Keys.Control | Keys.H) && cuocGoiRow.FT_IsFT)
                {
                    new frmLichSuCuocDieu(cuocGoiRow).ShowDialog();
                    return;
                }
                #endregion

                if (EnVangManagement.ConfigEnVang) XuLyKeyDownTrenDongNew(msgDialog, e, cuocGoiRow, positionRowSelect, ref hasThucHienLenh);

                #region có thực hiện lệnh, gọi cập nhật
                if (hasThucHienLenh)
                {
                    //Chuyen sang moi khách
                    if (cuocGoiRow.LenhTongDai == LENH_1_MOIKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_5_GIUKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_4_HOILAIDC ||
                        cuocGoiRow.LenhTongDai == LENH_2_KHONGXE_XINLOI1 ||
                        cuocGoiRow.LenhTongDai == LENH_6_KIENTRAKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_3_KHONGXE ||
                        cuocGoiRow.LenhTongDai == LENH_6_KTRAKHACH ||
                        cuocGoiRow.LenhTongDai == LENH_7_MOIKHACHLAN2 ||
                        cuocGoiRow.LenhTongDai == LENH_GAPCHUA)
                    {
                        cuocGoiRow.ChuyenMK = true;
                    }
                    cuocGoiRow.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_EV(cuocGoiRow))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        return;
                    }
                    else //
                    {
                        if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            SapXepLaiIndex(cuocGoiRow);
                            // remove tai luoi
                            g_lstDienThoai.Remove(cuocGoiRow);
                            HienThiTrenLuoi(false, false);
                            if (!bwSync_RemoveCuocGoi.IsBusy)
                            {
                                //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                                bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                            }
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                            HienThiTrenLuoi(true, false);
                        }

                    }
                }
                #endregion

            }
        }
        private void grid_DaDonKhach_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_DaDonKhach.SelectedItems.Count > 0)
            {
                if (g_RowIndex_DaDonKhach != grid_DaDonKhach.CurrentRow.RowIndex)
                {
                    g_RowIndex_DaDonKhach = grid_DaDonKhach.CurrentRow.RowIndex;
                }
            }
        }
        #endregion

        #region Đã giải quyết
        
        private void gridCuocGoi_KetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode != Keys.Enter)
            //    return;
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems != null && gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                CuocGoi cuocGoiRow = (CuocGoi)gridCuocGoi_KetThuc.SelectedItems[0].GetRow().DataRow;
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
                if (e.KeyData == Keys.Enter)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                    {
                        //gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                        //if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
                        //{
                        //    GridEXRow row = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
                        //    NhapDulieu_DiaChiTraKhach(row);
                        //}
                        //CuocGoi cuocGoiRow = (CuocGoi)gridCuocGoi_KetThuc.GetRow(((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).Position).DataRow;
                        TimeSpan timeSpan;
                        timeSpan = g_TimeServer - cuocGoiRow.ThoiDiemGoi;
                        if (cuocGoiRow.XeDon != null && cuocGoiRow.XeDon.Length > 0)
                        {
                            timeSpan.Add(new TimeSpan(0, 0, cuocGoiRow.ThoiGianDonKhach));
                        }
                        if (timeSpan.TotalSeconds > 30 * 60)  // lớn hơn 10 phút từ thời điểm nhập xe đón
                        {
                            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                            msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                            return;
                        }
                        NhapDuLieuVaoTruyenDi(cuocGoiRow);
                    }
                }
                else if (e.KeyData == Keys.B)
                {
                    new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                }
                
                // Ban Do Xe Nhan
                else if (e.KeyData == Keys.X)
                {
                    new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                }
            }
        }

        private void gridCuocGoi_KetThuc_DoubleClick(object sender, EventArgs e)
        {
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems != null && gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                {
                    CuocGoi cuocGoiRow = (CuocGoi)gridCuocGoi_KetThuc.GetRow(((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).Position).DataRow;
                    TimeSpan timeSpan;
                    timeSpan = g_TimeServer - cuocGoiRow.ThoiDiemGoi;
                    if (cuocGoiRow.XeDon != null && cuocGoiRow.XeDon.Length > 0)
                    {
                        timeSpan.Add(new TimeSpan(0, 0, cuocGoiRow.ThoiGianDonKhach));
                    }
                    if (timeSpan.TotalSeconds > 10 * 60)  // lớn hơn 10 phút từ thời điểm nhập xe đón
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                    NhapDuLieuVaoTruyenDi(cuocGoiRow);
                }
            }
        }

        private void gridCuocGoi_KetThuc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRigthClick.ShowCustomizeDialog();
            }
        }

        private void gridCuocGoi_KetThuc_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //HienThiAnhTrangThai_MauChu(e.Row);
        }

        #endregion
        private void HienThiBanDo(CuocGoi cuocGoiRow, bool IsReActive)
        {
            if (frm_BanDo == null)
            {
                frm_BanDo = new frmHienThiBanDo_Mini(cuocGoiRow);
                frm_BanDo.Show();
            }
            else
            {
                if (frm_BanDo.Visible == true)
                {
                    if (cuocGoiRow == null)
                    {
                        frm_BanDo.Close();
                    }
                    else
                    {
                        frm_BanDo.RefreshForm(cuocGoiRow);
                    }
                }
                else
                {
                    if (IsReActive)
                    {
                        frm_BanDo.Visible = true;
                        frm_BanDo.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý lệnh điều hành nhập trên form sau khi đã cập nhật
        /// </summary>
        /// <param name="lenhDieuHanh">The lenh dieu nhanh.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/10/2015   created
        /// </Modified>
        private void XuLyLenhDieuHanhNhap(ref CuocGoi cuocGoi)
        {
            switch (cuocGoi.LenhTongDai)
            {
                case EnVangManagement.LENH_TRUOTCHUA:
                    XuLyCuocGoiTruot(ref cuocGoi);
                    break;
                case EnVangManagement.LENH_HUYXE:
                    XuLyCuocGoiHuy(ref cuocGoi);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// - Nhan vao vi tri cua mot dong trong list cac cuoc goi dang hien hanh
        /// - lay gia tri len form 
        /// - nhap vao truyen di
        /// 
        /// </summary>
        /// <param name="iRowPosition"></param>
        private void NhapDuLieuVaoTruyenDi(CuocGoi cuocGoi)
        {
            //Thu doi mau
            GridEXFormatStyle RowStyle = new GridEXFormatStyle();
            GridEXRow rowSelect;
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            {
                rowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                RowStyle.BackColor = Color.Tan;
                rowSelect.RowStyle = RowStyle;
            }
            else if(tab_CGDaDonKhach.Selected)
            {
                rowSelect = ((GridEXSelectedItem)grid_DaDonKhach.SelectedItems[0]).GetRow();
                RowStyle.BackColor = Color.Tan;
                rowSelect.RowStyle = RowStyle;
            }
            else
            {
                rowSelect = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
                RowStyle.BackColor = Color.Tan;
                rowSelect.RowStyle = RowStyle;
            }

            if (uiTabCuocGoiDangThucHien.SelectedIndex == 0 || tab_CGDaDonKhach.Selected)
            {
                string xeNhan_Old = cuocGoi.XeNhan;
                string xeDon_Old = cuocGoi.XeDon;
                string LenhTongDai_old=cuocGoi.LenhTongDai;
                var TrangThaiCuocGoi_old = cuocGoi.TrangThaiCuocGoi;
                frmInput = new frmBodamInputData_V3(g_TimeServer, cuocGoi, g_ListSoHieuXe, false, g_SoLuongDangNhapCS, g_IsThoatDuoc999)
                {
                    G_ListCuocGoi = g_lstDienThoai,
                    dicGiamSat_AnCa = _controlDieuHanhBanCoBanCo.dicGiamSat_AnCa,
                    dicGiamSat_RoiXe = _controlDieuHanhBanCoBanCo.dicGiamSat_RoiXe,
                    dicGiamSat_MatLL = _controlDieuHanhBanCoBanCo.dicGiamSat_MatLL,
                    dicGiamSat_BaoHong = _controlDieuHanhBanCoBanCo.dicGiamSat_BaoHong,
                    dicXeHoatDong = _controlDieuHanhBanCoBanCo.dicXeHoatDong
                };
                DialogResult ketQua = frmInput.ShowDialog(this);
                if (ketQua == DialogResult.OK)
                {
                    cuocGoi = frmInput.GetCuocGoi;
                    cuocGoi.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    
                    #region XU LY CUOC GOI KHONG XE LẦN 1
                    // xử lý cuộc gọi không xe, sau 3 phút, hoặc số phút theo caauss hình thì sẽ hiển thị lại cuộc ogoij khong xe
                    if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1)
                    {
                        cuocGoi.CamOn_ThoiDiemChen = g_TimeServer;
                        if (!g_lstCuocGoiKhongXe.Contains(cuocGoi))
                            g_lstCuocGoiKhongXe.Add(cuocGoi);
                        g_lstDienThoai.Remove(cuocGoi);
                        HienThiTrenLuoi(false, false); // Refresh
                       // return;
                    }
                    #endregion

                    if (frmInput.lenhDHChanged && !string.IsNullOrEmpty(cuocGoi.XeDon))
                    {
                        XuLyLenhDieuHanhNhap(ref cuocGoi);
                    }

                    //Chuyen sang moi khách
                    if (cuocGoi.LenhTongDai == LENH_1_MOIKHACH || cuocGoi.LenhTongDai == LENH_5_GIUKHACH || cuocGoi.LenhTongDai == LENH_2_KHONGXE_XINLOI1
                        || cuocGoi.LenhTongDai == LENH_6_KIENTRAKHACH || cuocGoi.LenhTongDai == LENH_3_KHONGXE)
                    {
                        cuocGoi.ChuyenMK = true;
                    }

                    if ((!string.IsNullOrEmpty(cuocGoi.XeNhan) && 
                        (cuocGoi.DaGuiDSXeNhan == null || cuocGoi.DaGuiDSXeNhan == 0) 
                        && !Global.ChoPhepDienThoaiNhapXe && 
                        cuocGoi.TrangThaiCuocGoi != Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiTruot
                        && CanSendMobile(cuocGoi.KhongDungMobileService)
                        && !cuocGoi.KhongDungMobileService.Value)
                        || cuocGoi.isResendMobile)
                    {
                        if (cuocGoi.isResendMobile)
                        {
                            cuocGoi.XeDenDiem = "";
                            cuocGoi.XeDon = "";
                            cuocGoi.MH_LenhLaiXe = "";
                            cuocGoi.GhiChuLaiXe = "";
                        }
                        if (EnVangProcess.SendInitTrip(cuocGoi))
                        {
                            CuocGoi.DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(cuocGoi.IDCuocGoi, 1);
                        }
                        else
                        {
                            CuocGoi.DIENTHOAI_CapNhatDaGuiDSXeNhan_EnVangVip(cuocGoi.IDCuocGoi, 0);
                        }
                    }

                    if (!CuocGoi.FT_TONGDAI_UpdateThongTinCuocGoi_EV(cuocGoi))
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else
                    {
                        #region FastTaxi
                        // là cuốc fastTaxi
                        if (cuocGoi.FT_IsFT)
                        {
                            #region SendToMasterSignedCar - Nhập xe nhận
                            //Xe nhận thay đổi thì xử lý gửi
                            if (cuocGoi.XeNhan != xeNhan_Old)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeNhan);
                            }
                            #endregion

                            #region SendToMasterSignedCar - Nhập xe đón
                            //Xe đón thay đổi thì xử lý gửi
                            if (cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach &&
                                cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeDon);
                            }
                            #endregion

                            #region thay đổi có xe đón
                            if (cuocGoi.XeDon != xeDon_Old)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.NhapXeDon);
                            }
                            #endregion

                            #region SendToMasterCatchingCar - Mời khách
                            //Mời khách
                            if (LenhTongDai_old.ToLower() != LENH_1_MOIKHACH.ToLower() && cuocGoi.LenhTongDai.ToLower() == LENH_1_MOIKHACH.ToLower() &&
                                cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.MoiKhach);
                            }
                            #endregion

                            #region SendToMasterBookingFail - Không xe
                            //Không xe
                            if ((LenhTongDai_old.ToLower() != LENH_3_KHONGXE.ToLower() || TrangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiKhongXe) && (cuocGoi.LenhTongDai.ToLower() == LENH_3_KHONGXE.ToLower() ||
                                cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe))
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.KhongXe);
                            }
                            #endregion

                            #region SendToMasterBookingFail -Trượt
                            // Trượt
                            if ((LenhTongDai_old != "trượt" || TrangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiTruot) &&
                                (cuocGoi.LenhTongDai == "trượt" || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiTruot))
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Truot);
                            }
                            #endregion

                            #region SendToMasterBookingFail -Hoãn
                            // Hoãn 
                            if ((LenhTongDai_old.ToLower() != "hoãn".ToLower() || TrangThaiCuocGoi_old != TrangThaiCuocGoiTaxi.CuocGoiHoan) &&
                                (cuocGoi.LenhTongDai.ToLower() == "hoãn".ToLower() || cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiHoan)
                                && !cuocGoi.KhongDungMobileService.Value)
                            {
                                SendFastTaxi(cuocGoi, Enum_FastTaxi_Status.Hoan);
                            }
                            #endregion
                        }
                        #endregion
                        if (cuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            if(CanSendMobile(cuocGoi.KhongDungMobileService)) 
                                EnVangProcess.SendConfirmDone(cuocGoi, 1);
                            RemoveCuocGoi(cuocGoi);
                            HienThiTrenLuoi(false, false); // Refresh
                            if (!bwSync_RemoveCuocGoi.IsBusy)
                            {
                                //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                                bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoi);
                            }
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoi, true);
                            HienThiTrenLuoi(true, false); // Refresh
                            //Nếu cuộc gọi có thay đổi xe nhận thì cập nhật thông tin cuộc gọi vào MEM
                            if (cuocGoi.KieuCuocGoi == KieuCuocGoi.GoiTaxi && xeNhan_Old != cuocGoi.XeNhan)
                            {
                                if (!bwSync_AddCuocGoi.IsBusy)
                                {
                                    bwSync_AddCuocGoi.RunWorkerAsync(cuocGoi);
                                }
                            }
                        }
                    }

                }
                else if (ketQua == DialogResult.Ignore) // chuyeern vung
                {
                    RemoveCuocGoi(cuocGoi);
                    HienThiTrenLuoi(false, false); // Refresh
                }
            }
            else
            {
                frmInput = new frmBodamInputData_V3(g_TimeServer, cuocGoi, g_ListSoHieuXe, true, g_SoLuongDangNhapCS, g_IsThoatDuoc999)
                {
                    G_ListCuocGoi = g_lstDienThoai,
                    dicGiamSat_AnCa = _controlDieuHanhBanCoBanCo.dicGiamSat_AnCa,
                    dicGiamSat_RoiXe = _controlDieuHanhBanCoBanCo.dicGiamSat_RoiXe,
                    dicGiamSat_MatLL = _controlDieuHanhBanCoBanCo.dicGiamSat_MatLL,
                    dicGiamSat_BaoHong = _controlDieuHanhBanCoBanCo.dicGiamSat_BaoHong,
                    dicXeHoatDong = _controlDieuHanhBanCoBanCo.dicXeHoatDong
                };
                DialogResult ketQua = frmInput.ShowDialog(this);
                if (ketQua == DialogResult.OK)
                {
                    cuocGoi = frmInput.GetCuocGoi;
                    cuocGoi.MaNhanVienTongDai = ThongTinDangNhap.USER_ID;
                    if (cuocGoi.LenhTongDai == LENH_1_MOIKHACH || cuocGoi.LenhTongDai == LENH_5_GIUKHACH
                        || cuocGoi.LenhTongDai == LENH_6_KIENTRAKHACH || cuocGoi.LenhTongDai == LENH_3_KHONGXE)
                    {
                        cuocGoi.ChuyenMK = true;

                    }

                    if (!CuocGoi.TONGDAI_UpdateThongTinCuocGoi_KETTHUC(cuocGoi))
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi(ref g_lstCuocGoiKetThuc, cuocGoi, true);
                        HienThiTrenLuoi_KETTHUC(true, false); // Refresh
                    }
                }
            }

            //tra ve mau cu
            RowStyle = new GridEXFormatStyle();
            //RowStyle.BackColor = Color.White;
            RowStyle.BackColor = Color.White;
            rowSelect.RowStyle = RowStyle;
        }

        private void RemoveCuocGoi(CuocGoi cuocGoi)
        {
            SapXepLaiIndex(cuocGoi);
            g_lstDienThoai.Remove(cuocGoi);
        }

        private void RemoveCuocGoi_ChuaNhan(CuocGoi cuocGoi)
        {
            g_lstDienThoai_New.Remove(cuocGoi);
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
        /// <summary>
        /// Thực hiện sắp xếp xe chưa có xe nhận đẩy lên đầu
        /// </summary>
        /// <param name="listCuocGoiHienTai">danh sách cuốc khách</param>
        private void SapXepXeChuaCoXeNhan(ref List<CuocGoi> listCuocGoiHienTai)
        {
            return;
            if (Config_Common.LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan > 0||Config_Common.LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan > 0)
            {
                int n = listCuocGoiHienTai.Count;
                //số lượng cuốc gọi chưa có xe nhận.
                int start = listCuocGoiHienTai.Count(p => string.IsNullOrEmpty(p.XeNhan)||p.LenhDienThoai!=string.Empty);
                // lấy cuốc đầu tiên có xe nhận.
                CuocGoi itemFisrt = listCuocGoiHienTai.FirstOrDefault(p => !string.IsNullOrEmpty(p.XeNhan) );
                if (itemFisrt != null)
                {

                    int index = listCuocGoiHienTai.IndexOf(itemFisrt);
                    //kiểm tra cuốc gọi có xe nhận có nằm trong khoảng 0-start là vùng ko được xử lý sắp xếp.
                    // nếu có thuộc thì sẽ sắp xếp từ vị trí cuốc khách đầu tiên có xe nhận.
                    if (index < start)
                        start = index;
                }
                for (int i = start; i < n; i++)
                {
                    CuocGoi item = listCuocGoiHienTai[i];
                    int soPhut=(int)(g_TimeServer-item.ThoiDiemGoi).TotalMinutes;
                    if (((item.XeNhan == null || item.XeNhan.Trim() == string.Empty) &&((!item.FT_IsFT && soPhut> Config_Common.LuoiCuocGoi_CuocGoi_HienThiLenDauKhongXeNhan)||(item.FT_IsFT&&soPhut>Config_Common.LuoiCuocGoi_Staxi_HienThiLenDauKhongXeNhan))))
                    {
                        listCuocGoiHienTai.Remove(item);
                        listCuocGoiHienTai.Insert(0, item);
                    }
                }              
            }
        }
        private void NhapDulieu_DiaChiTraKhach(GridEXRow row)
        {
            //CuocGoi objDieuHanhTaxi = (CuocGoi)row.DataRow;
            //// kiểm tra thời gian
            //TimeSpan timeSpan;
            //timeSpan = g_TimeServer - objDieuHanhTaxi.ThoiDiemGoi;
            //if (objDieuHanhTaxi.XeDon != null && objDieuHanhTaxi.XeDon.Length > 0)
            //{
            //    timeSpan.Add(new TimeSpan(0, 0, objDieuHanhTaxi.ThoiGianDonKhach));
            //}
            //if (timeSpan.TotalSeconds > 5 * 60)  // lớn hơn 5 phút từ thời điểm nhập xe đón
            //{
            //    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
            //    msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //    return;
            //}
            ////Thu doi mau
            //GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
            //GridEXFormatStyle RowStyle = new GridEXFormatStyle();
            //RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
            //rowSelect.RowStyle = RowStyle;
            ////End - Thu doi mau
            ////frmBoDamInputDataCuocKetThuc frm = new frmBoDamInputDataCuocKetThuc(objDieuHanhTaxi, true);
            //if (frm.ShowDialog(this) == DialogResult.OK)
            //{

            //    LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep, g_SoDong);

            //}
            //else
            //{  //tra ve mau cu
            //    RowStyle = new GridEXFormatStyle();
            //    RowStyle.BackColor = System.Drawing.SystemColors.Window;
            //    rowSelect.RowStyle = RowStyle;
            //    return;
            //}
            //RowStyle = new GridEXFormatStyle();
            //RowStyle.BackColor = System.Drawing.SystemColors.Window;
            //rowSelect.RowStyle = RowStyle;
            //return;

        }

        /// <summary>
        /// hàm cập nhật dữ liệu cuộc gọi thay đổi vào dữ liệu của dsCuocGoi
        /// Nếu isDuLieuCuaTongDai = True (dữ liệu phía tổng dài thay đổi, nhap trên form và cập nhật luôn)
        /// Ngược lại :
        ///     cập nhật dữ liệu phía điện thoại thay đổi
        /// </summary>
        /// <param name="listCuocGoiHienTai">ds cuộc gọi hiện tại</param>
        /// <param name="cuocGoi"></param>
        /// <param name="isDuLieuCuaTongDai"></param>
        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool isDuLieuCuaTongDai)
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
                    if (isDuLieuCuaTongDai)
                    {
                        listCuocGoiHienTai[index].TrangThaiCuocGoi = cuocGoi.TrangThaiCuocGoi;
                        listCuocGoiHienTai[index].LenhTongDai = cuocGoi.LenhTongDai;
                        listCuocGoiHienTai[index].GhiChuTongDai = cuocGoi.GhiChuTongDai;
                        listCuocGoiHienTai[index].MaNhanVienTongDai = cuocGoi.MaNhanVienTongDai == listCuocGoiHienTai[index].MaNhanVienTongDai ? listCuocGoiHienTai[index].MaNhanVienTongDai : cuocGoi.MaNhanVienTongDai;
                        listCuocGoiHienTai[index].XeNhan = cuocGoi.XeNhan;
                        listCuocGoiHienTai[index].XeNhan_TD = cuocGoi.XeNhan_TD;
                        listCuocGoiHienTai[index].XeDon = cuocGoi.XeDon;
                        listCuocGoiHienTai[index].DiaChiTraKhach = cuocGoi.DiaChiTraKhach;
                        listCuocGoiHienTai[index].ThoiGianDieuXe = cuocGoi.ThoiGianDieuXe;
                        listCuocGoiHienTai[index].ThoiGianDonKhach = cuocGoi.ThoiGianDonKhach;listCuocGoiHienTai[index].MOIKHACH_LenhMoiKhach = cuocGoi.MOIKHACH_LenhMoiKhach;
                        listCuocGoiHienTai[index].MOIKHACH_NhanVien = cuocGoi.MOIKHACH_NhanVien;
                        listCuocGoiHienTai[index].XeDenDiem = cuocGoi.XeDenDiem;
                        listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                        listCuocGoiHienTai[index].FT_Date = cuocGoi.FT_Date;
                        listCuocGoiHienTai[index].FT_SendDate = cuocGoi.FT_SendDate;
                        listCuocGoiHienTai[index].FT_IsFT = cuocGoi.FT_IsFT;
                        listCuocGoiHienTai[index].FT_Status = cuocGoi.FT_Status;
                        listCuocGoiHienTai[index].KhongDungMobileService = cuocGoi.KhongDungMobileService.Value;
                    }
                }
            }
        }

        #endregion

        #region =========================Timer=================================

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += new EventHandler(TimerCapturePhone_Tick);
            TimerCapturePhone.Start();
            g_TimeServer = DieuHanhTaxi.GetTimeServer();

        }
        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        ///   - 1 giay lay cuoc goi moi chuyen sang
        ///   - 3 giay xu ly cuoc goi ket thuc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        private void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                g_TimeServer = g_TimeServer.AddSeconds(1);
                DateTime DateMax = DateTime.MinValue;
                if (G_KenhGop != "" && g_TimeServer.TimeOfDay >= ThongTinCauHinh.GopKenh_GioBD && g_TimeServer.TimeOfDay <= ThongTinCauHinh.GopKenh_GioBD)
                {
                    g_strVungsDuocCapPhep = G_KenhGop;
                }
                bool hasThemMoi = false;
                bool hasCapNhat = false;
                if (ThongTinCauHinh.GPS_TrangThai && isLoadLenhSuccess)
                {
                    XuLyNhanLenhTuLaiXe();                    
                }
                if (uiTabCuocGoiChoGiaiQuyet.Selected)
                {
                    LoadCuocGoiMoiTongDai_ChuaNhan(ref g_lstDienThoai, g_strVungsDuocCapPhep, g_ThoiDiemLayDuLieuTruoc_ChuaNhan, ref hasCapNhat, ref hasThemMoi, ref DateMax);
                    if (hasCapNhat)
                    {
                        HienThiTrenLuoi(hasCapNhat, hasThemMoi);
                        g_ThoiDiemLayDuLieuTruoc_ChuaNhan = DateMax;
                         //Tăng thêm 1s để khắc phục lỗi luôn lấy cuốc khách có thời gian thay đổi dữ liệu =DateMax.
                        g_ThoiDiemLayDuLieuTruoc_ChuaNhan = g_ThoiDiemLayDuLieuTruoc_ChuaNhan.AddSeconds(1);
                    }
                }
                //else if (tab_CGDaDonKhach.Selected)
                {
                    hasThemMoi = false;
                    hasCapNhat = false;
                    DateMax = DateTime.MinValue;
                    LoadCuocGoiMoiTongDai_DaDonKhach(ref g_lstDienThoai_DaDonKhach, g_strVungsDuocCapPhep, g_ThoiDiemLayDuLieuTruoc_DaDonKhach, ref hasCapNhat, ref hasThemMoi, ref DateMax);
                    if (hasCapNhat)
                    {
                        HienThiTrenLuoi_DaDonKhach(hasCapNhat, hasThemMoi);
                        g_ThoiDiemLayDuLieuTruoc_DaDonKhach = DateMax;
                        //Tăng thêm 1s để khắc phục lỗi luôn lấy cuốc khách có thời gian thay đổi dữ liệu =DateMax.
                        g_ThoiDiemLayDuLieuTruoc_DaDonKhach = g_ThoiDiemLayDuLieuTruoc_DaDonKhach.AddSeconds(1);
                    }
                }

                //hasThemMoi = false;
                //hasCapNhat = false;
                //if (Global.GridConfig_CuocGoi == Grid_Config.Has_Grid_Bottom)
                //{
                //    LoadCuocGoiMoiTongDai_DaNhan(ref g_lstDienThoai, g_strVungsDuocCapPhep, g_ThoiDiemLayDuLieuTruoc, ref hasCapNhat, ref hasThemMoi, ref DateMax);
                //    if (hasCapNhat) // co thay doilieu du  moi cap nhat cuoc goi
                //    {
                //        HienThiTrenLuoi(hasCapNhat, hasThemMoi);
                //        g_ThoiDiemLayDuLieuTruoc = DateMax;
                //    }
                //}

                g_TimeStep++;
                g_timerMsg++;
                if (g_TimeStep >= 3)  // 3 giay thuc hien mot lan
                {
                    if (uiTabCuocGoiChoGiaiQuyet.Selected)
                    {
                        hasCapNhat = false;
                        CapNhatCuocGoiDaKetThucByDienThoai(ref g_lstDienThoai, g_strVungsDuocCapPhep, ref hasCapNhat);
                        if (hasCapNhat)
                        {
                            HienThiTrenLuoi(false, false);
                        }
                    }
                    else if (tab_CGDaDonKhach.Selected)
                    {
                        hasCapNhat = false;
                        CapNhatCuocGoiDaKetThucByDienThoai_DaDonKhach(ref g_lstDienThoai_DaDonKhach, g_strVungsDuocCapPhep, ref hasCapNhat);
                        if (hasCapNhat)
                        {
                            HienThiTrenLuoi_DaDonKhach(false, false);
                        }
                    }
                    //sau 3s thì mới thực hiện kiểm tra và sắp xếp cho lưới
                 //   SapXepXeChuaCoXeNhan(ref g_lstDienThoai);
                    g_TimeStep = 0;
                }

                if (g_timerMsg >= 10)  // 10 giay thuc hien mot lan
                {//-------------------------Message------------------------------

                    ProcessFastTaxi.GetVehicleGPS();

                    timerMessage();

                    g_timerMsg = 0;
                    //gridCuocGois.Refetch();
                    
                    #region XU LY CUOC GOI XIN LOI KHACH
                    // neeuc so cuộc gọi xin lỗi khách lần 1 thì sau x phút sẽ đẩy lại.
                    if (g_lstCuocGoiKhongXe != null && g_lstCuocGoiKhongXe.Count > 0)
                    {
                        int i = -1; bool hasXoa = false;
                        foreach (CuocGoi cuocGoi in g_lstCuocGoiKhongXe)
                        {
                            i++;
                            if ((cuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1) && (g_TimeServer - cuocGoi.ThoiDiemThayDoiDuLieu).Seconds >= g_SoGiayGioiHanKhongXe) // thông số cấu hình
                            {
                                // Kiểm tra cuộc gọi đã tồn tại chưa, nếu rồi thì không thêm vào
                                bool bFind = false;
                                foreach (CuocGoi item in g_lstDienThoai)
                                {
                                    if (cuocGoi.IDCuocGoi == item.IDCuocGoi)
                                    {
                                        bFind = true;
                                        break;
                                    }
                                }
                                if (!bFind)
                                {
                                    g_lstDienThoai.Insert(0, cuocGoi);
                                    HienThiTrenLuoi(true, true);
                                    hasXoa = true;
                                    break;
                                }

                            }
                        }
                        if (hasXoa)
                            g_lstCuocGoiKhongXe.RemoveAt(i);
                    }
                    #endregion


                }

                //NhanCuocGoiMoiVaPhanBoCS();

                if (g_TabKetThucDuocChon)
                {
                    LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_SoDong);
                    g_TabKetThucDuocChon = false;
                }

                //g_CountKetThuc = countCGDonDuoc();
                //ViewTrangThaiCacCuocGoiO_StatusBar();

                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
            }
            catch (Exception ex)
            {
                LoadAllCuocGoiHienTai(g_strVungsDuocCapPhep);
                HienThiTrenLuoi(true, true);
                //new MessageBox.MessageBox().Show("TimerCapturePhone_Tick " + ex.Message);
                //LogError.WriteLogError("Lỗi trong timer", ex);
            }
        }

        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {
            try
            {
                int iSoCuocGoiChuaDieuXe = 0;
                int iSoCuocGoiChuaDonDuocKhach = 0;
                if (g_lstDienThoai != null)
                {
                    foreach (CuocGoi objDH in g_lstDienThoai)
                    {
                        if (objDH == null || objDH.XeNhan == null) continue;
                        if (objDH.XeNhan.Length <= 0)
                            iSoCuocGoiChuaDieuXe += 1;
                        if (objDH.XeNhan.Length > 0)
                            iSoCuocGoiChuaDonDuocKhach += 1;
                    }
                }
                this.statusBar.Panels[1].Width = 170;
                this.statusBar.Panels[1].Text = "Chưa điều xe : " + iSoCuocGoiChuaDieuXe.ToString();
                this.statusBar.Panels[2].Width = 180;
                this.statusBar.Panels[2].Text = "Chưa đón được khách : " + iSoCuocGoiChuaDonDuocKhach.ToString();

                //this.statusBar.Panels[3].Width = 170;
                //this.statusBar.Panels[3].Text = String.Format("Đón được khách : {0}", g_CountKetThuc);

            }
            catch (Exception)
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

                return CuocGoi.TONGDAI_DemCuocGoiDonDuoc(fromDate, toDate, ThongTinDangNhap.USER_ID);
            }
            else
            {
                return 0;
            }
        }

        //-----------------------------Send Message--------------------------------------
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

        private void timerNhayBaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            //if (g_boolNhayMauKhiCoCuocGoiMoi)
            //{
            //    uiTabCuocGoiChoGiaiQuyet.ImageIndex = 0;
            //    g_boolNhayMauKhiCoCuocGoiMoi = false;
            //}
            //else
            //{

            //    g_boolNhayMauKhiCoCuocGoiMoi = true;
            //    uiTabCuocGoiChoGiaiQuyet.ImageIndex = 1;

            //}
            //if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            //{
            //    timerBaoCoDuLieuDienThoaiGui.Enabled = false;
            //    uiTabCuocGoiChoGiaiQuyet.ImageIndex = -1;
            //} uiTabCuocGoiChoGiaiQuyet.Refresh();
        }

        /// <summary>
        /// Hàm thực hiện cập nhật thông tin cuộc gọi đã kết thúc 
        /// 
        /// </summary>
        /// <param name="listDienThoai"></param>
        /// <param name="vungsDuocCapPhep"></param>
        /// <param name="thoiDiemLayDuLieuTruoc"></param>
        /// <param name="hasCapNhat"></param>
        private void CapNhatCuocGoiDaKetThucByDienThoai(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool hasCapNhat)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += cuocGoi.IDCuocGoi.ToString() + ",";
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.EnVangVip_TONGDAI_LayCacIDCuocGoiKetThucByDienThoai(listIDCuocGoi, vungsDuocCapPhep);
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
                            //g_ListTinNhanManHinh.RemoveAll(M => M.FK_CuocGoiID == idCuocGoi);

                            SapXepLaiIndex(listCuocGoiHienTai.Find(T => T.IDCuocGoi == idCuocGoi));

                            listCuocGoiHienTai.RemoveAt(index);

                            if (index <= g_RowIndex)
                            {
                                g_RowIndex = g_RowIndex - 1;
                            }
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                    //if (hasCapNhat)
                    //{
                    //    gridManHinh.DataSource = null;
                    //    gridManHinh.DataMember = "dtTinNhanManHinh";
                    //    gridManHinh.SetDataBinding(g_ListTinNhanManHinh, "dtTinNhanManHinh");
                    //    gridManHinh.Refresh();
                    //}
                }
            }
            else
                hasCapNhat = false;
        }

        private void CapNhatCuocGoiDaKetThucByDienThoai_DaDonKhach(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool hasCapNhat)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += cuocGoi.IDCuocGoi.ToString() + ",";
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.EnVangVIP_LayCacIDCuocGoiKetThucByDienThoai_DaDonKhach(listIDCuocGoi, vungsDuocCapPhep);
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

                            if (index <= g_RowIndex)
                            {
                                g_RowIndex = g_RowIndex - 1;
                            }
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
            else
                hasCapNhat = false;
        }
        private void CapNhatCuocGoiDaKetThucByDienThoai_ChuaNhan(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool hasCapNhat)
        {
            hasCapNhat = false;
            // lấy ds các ID cuộc gọi hiện có
            string listIDCuocGoi = "";
            if (listCuocGoiHienTai != null && listCuocGoiHienTai.Count > 0)
            {
                foreach (CuocGoi cuocGoi in listCuocGoiHienTai)
                {
                    listIDCuocGoi += cuocGoi.IDCuocGoi.ToString() + ",";
                }
                if (listIDCuocGoi.EndsWith(","))
                {
                    listIDCuocGoi = listIDCuocGoi.Substring(0, listIDCuocGoi.Length - 1);
                }
            }
            if (listIDCuocGoi.Length > 0) // co  cuoc  goi
            {
                List<long> listIDDaKetThuc = CuocGoi.TONGDAI_LayCacIDCuocGoiKetThucByDienThoai_ChuaNhan(listIDCuocGoi, vungsDuocCapPhep);
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
                            //g_ListTinNhanManHinh.RemoveAll(M => M.FK_CuocGoiID == idCuocGoi);

                            SapXepLaiIndex(listCuocGoiHienTai.Find(T => T.IDCuocGoi == idCuocGoi));

                            listCuocGoiHienTai.RemoveAt(index);

                            if (index <= g_RowIndex)
                            {
                                g_RowIndex = g_RowIndex - 1;
                            }
                            hasCapNhat = true; // co cap nhat du lieu luoi
                        }
                    }
                }
            }
            else
                hasCapNhat = false;
        }

        #endregion

        #region ----------------------Xe nhận - GPS----------------------------
        private string g_Return_TD = string.Empty;
        private string g_Return = string.Empty;
        private string g_XeNhan_Truoc = string.Empty;
        private bool updateDSXeNhan_ToaDo(CuocGoi cuocGoi)
        {
            try
            {
                double KD = cuocGoi.GPS_KinhDo;
                double VD = cuocGoi.GPS_ViDo;
                if (KD == 0 || VD == 0)
                    return false;

                string dsXeNhan = cuocGoi.XeNhan;//Chuỗi xe nhận hiện tại vừa nhập
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
                    if (cuocGoi.XeNhan_TD == null || cuocGoi.XeNhan_TD == "")
                    {
                        //-------Nếu Tọa độ xe nhận cũ không có, lấy lại tọa độ của xe nhận cũ
                        string toaDoTruoc = getToaDoXeNhanMoi(cuocGoi.XeNhan, KD, VD);
                        if (toaDoTruoc != "")
                            arrDSToaDoTruoc = toaDoTruoc.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
                    }
                    else
                    {
                        arrDSToaDoTruoc = cuocGoi.XeNhan_TD.Split(',');//-----Cắt chuỗi tọa độ xe nhận cũ
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

                return CuocGoi.TONGDAI_UPDATE_XENHAN_TOADO(cuocGoi.IDCuocGoi, dsToaDo);
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("updateDSXeNhan_ToaDo " + ex.Message);
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
                //dsToaDo = string.Format("{0}{1},", dsToaDo, Taxi.Services.Service_Common.LayToaDoXeNhan(KD, VD, ThongTinCauHinh.GPS_MaCungXN, arrDSXeNhan[i]));
            }
            if (dsToaDo.Length > 1)
                dsToaDo = dsToaDo.Substring(0, dsToaDo.Length - 1);
            return dsToaDo;
        }
        #endregion

        #region ====================== Memory==================================
       
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
                new MessageBox.MessageBoxBA().Show("Không kết nối được với Service đồng bộ xe", "Thông Báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                ThongTinCauHinh.GPS_TrangThai = false;
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
                    WCFService_Common.WCFServiceClient.Try(p => p.RemoveTaxiOperation(cuocGoi.IDCuocGoi, cuocGoi.Vung, cuocGoi.XeNhan, cuocGoi.XeDon));
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion
        
        #region Các thành phần FastTaxi

        private void DoFastTaxi()
        {
            if (ThongTinCauHinh.FT_Active)
            {
                ProcessFastTaxi.TitleLog = "Log gửi lên server-Tổng đài";
                ProcessFastTaxi.DoFastTaxi();
            }
            if (ThongTinCauHinh.FT_ChieuVe_Active)
            {
                //cmdTaxiChieuVe.Visible = Janus.Windows.UI.InheritableBoolean.True;
                uiTabPage_TaxiChieuVe.TabVisible = true;
                BaoXeDiDuongDai1.Visible = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                //cmdTaxiChieuVe.Visible = Janus.Windows.UI.InheritableBoolean.False;
                uiTabPage_TaxiChieuVe.TabVisible = false;
                BaoXeDiDuongDai1.Visible =Janus.Windows.UI.InheritableBoolean.False;
            }
        }

        private void SendFastTaxi(CuocGoi cuocGoiRow, Enum_FastTaxi_Status status)
        {
         
            ProcessFastTaxi.SendFastTaxi(cuocGoiRow, status);
        }

        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_DaKetThuc)
            {
                ctrlDanhSachXeChieuVe_DaKetThuc.SearchDieuKetThuc();
                ctrlListBook_DaKetThuc.ReSearch();
            }
        }

        private void ctrlListBook_ChoXuLy_EventGridSelect(string SoXe)
        {
            ctrlDanhSachXeChieuVe_ChoXuLy.SelectGridByVehicle(SoXe);
        }


        /// <summary>
        /// Xử lý nhận lệnh từ lái xe: Mở 1 messagebox cho chọn thực hiện lệnh lái xe hay không
        /// </summary>
        /// <param name="cuocGoiThayDoi">The cuoc goi thay doi.</param>
        /// <param name="type">The type.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/31/2015   created
        /// Haunv 03/09/2015 Update Thêm try-catch log error
        /// </Modified>
        private void XuLyNhanLenhTuLaiXe()
        {
            try
            {
                var strOpenedMessageKeys = string.Join(";", openedMessageKeys);

                List<MessageConfirm> messages = CuocGoi.DIENTHOAI_LayMessageConfirm_EnVangVIP(g_strVungsDuocCapPhep, false, strOpenedMessageKeys);
                if (DuocPhepHienMessageKhongCoTripID)
                {
                    List<MessageConfirm> messageRequest = CuocGoi.EnVangVip_sp_GetMessageWithNoId(strOpenedMessageKeys);
                    messages.AddRange(messageRequest);
                }

                if (messages.Count == 0) return;
                foreach (var message in messages)
                {
                    // Kiểm tra có cần mở dialog và đã mở hay chưa
                    if (message.CanConfirm)
                    {
                        //message.BienSoXe = EnVangProcess.GetVehiclePlatesFromPrivateCode(message.SoHieuXe);
                        if (string.IsNullOrEmpty(message.BienSoXe))
                        {
                            CuocGoi.DIENTHOAI_SuaMessageConfirm_EnVangVip(message.IDCuocGoi, string.Empty, message.MaMessage, true, message.SoHieuXe);
                            continue;
                        }
                        var messageKey = message.MaMessage + "-" + message.XeDon;
                        if (!openedFormInfos.ContainsKey(messageKey))
                        {
                            var control = this.ActiveControl;
                            var popUp = EnVangManagement.OpenFormInfo(message, this);
                            //Thread.Sleep(100);
                            if (control != null)
                            {
                                if(frmInput != null && frmInput.Visible)
                                {
                                    frmInput.Activate();
                                }
                                else
                                {
                                    this.Activate();
                                }
                                control.Focus();
                            }
                            // Thêm tên của dialog sẽ mở vào mảng  để kiểm tra mở trùng
                            openedFormInfos.Add(messageKey, popUp);
                            openedMessageKeys.Add(messageKey);
                        }
                    }
                    else
                    {
                        if (!bwProcessMessage.IsBusy)
                            bwProcessMessage.RunWorkerAsync(message);
                    }

                    Thread.Sleep(100);
                }
                isLoadLenhSuccess = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("XuLyNhanLenhTuLaiXe", ex); 
                isLoadLenhSuccess = true;
            }
           
        }

        /// <summary>
        /// Xử lý những message không cần confirm
        /// </summary>
        /// <param name="message">The message.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public void XuLyMessageKhongCanConfirm(MessageConfirm message, byte result = 1)
        {
            string messageKey = message.MaMessage + "-" + message.XeDon;
            bool isKetThuc = false;
            if (openedFormInfos.ContainsKey(messageKey) && openedMessageKeys.Contains(messageKey))
            {
                openedFormInfos[messageKey].Dispose();
                openedFormInfos.Remove(messageKey);
                openedMessageKeys.Remove(messageKey);
            }

            if (message.MaMessage == EnVangManagement.MA_LENH_DAKETTHUC && result == 1)
            {
                //if (tab_CGDaDonKhach.Selected)
                {
                    foreach (var cuocGoi in g_lstDienThoai_DaDonKhach)
                    {
                        if (cuocGoi.IDCuocGoi == message.IDCuocGoi)
                        {
                            cuocGoi.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                            cuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                            CuocGoi.DIENTHOAI_SuaMessageConfirm_EnVangVip(cuocGoi.IDCuocGoi, EnVangManagement.MessageCodes[EnVangManagement.MA_LENH_DAKETTHUC], EnVangManagement.MA_LENH_DAKETTHUC, false, message.SoHieuXe);
                            CapNhatDongDuLieu(cuocGoi, null);
                            isKetThuc = true;
                            break;
                        }
                    }
                    if (!isKetThuc)
                    {
                        foreach (var cuocGoi_ChoGiaiQuyet in g_lstDienThoai)
                        {
                            if (cuocGoi_ChoGiaiQuyet.IDCuocGoi == message.IDCuocGoi)
                            {
                                cuocGoi_ChoGiaiQuyet.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                                cuocGoi_ChoGiaiQuyet.TrangThaiLenh = TrangThaiLenhTaxi.KetThucCuaDienThoai;
                                CuocGoi.DIENTHOAI_SuaMessageConfirm_EnVangVip(cuocGoi_ChoGiaiQuyet.IDCuocGoi, EnVangManagement.MessageCodes[EnVangManagement.MA_LENH_DAKETTHUC], EnVangManagement.MA_LENH_DAKETTHUC, false, message.SoHieuXe);
                                CapNhatDongDuLieu(cuocGoi_ChoGiaiQuyet, null);
                                isKetThuc = true;
                                break;
                            }
                        }
                    }
                }
                //else if (uiTabCuocGoiChoGiaiQuyet.Selected)
                {
                    
                }
            }
            GC.Collect();
        }

        private void ProcessMessage(MessageConfirm message, byte result = 1)
        {

        }

        /// <summary>
        /// Cập nhật dòng dữ liệu khi có thay đổi
        /// </summary>
        /// <param name="cuocGoiRow">The cuoc goi row.</param>
        /// <param name="msgDialog">The MSG dialog.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  8/7/2015   created
        /// </Modified>
        public void CapNhatDongDuLieu(CuocGoi cuocGoiRow, MessageBox.MessageBoxBA msgDialog)
        {
            if (uiTabCuocGoiChoGiaiQuyet.Selected)
            {
                cuocGoiRow.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                bool updateSuccess = false;
                if (Global.MoHinh == MoHinh.TongDaiMini)
                    updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoiRow);
                else
                    updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi(cuocGoiRow);

                if (!updateSuccess)
                {
                    //LogError.WriteLogErrorForDebug("CapNhatDongDuLieu : Cho giai quyet");
                    //if (msgDialog == null) msgDialog = new MessageBox.MessageBox();
                    //msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo",
                    //    Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
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
                        g_lstDienThoai_DaDonKhach.Remove(cuocGoiRow);
                        HienThiTrenLuoi_DaDonKhach(false, false);

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
            else if (tab_CGDaDonKhach.Selected)
            {
                cuocGoiRow.MaNhanVienDienThoai = ThongTinDangNhap.USER_ID;
                bool updateSuccess = false;
                if (Global.MoHinh == MoHinh.TongDaiMini)
                    updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi_Mini(cuocGoiRow);
                else
                    updateSuccess = CuocGoi.DIENTHOAI_UpdateThongTinCuocGoi(cuocGoiRow);

                if (!updateSuccess)
                {
                    //LogError.WriteLogErrorForDebug("CapNhatDongDuLieu : Da Don Khach");
                    return;
                }
                else //
                {
                    if (cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc ||
                        cuocGoiRow.TrangThaiLenh == TrangThaiLenhTaxi.KetThucCuaDienThoai)
                    {
                        // remove tai luoi
                        g_lstDienThoai_DaDonKhach.Remove(cuocGoiRow);
                        HienThiTrenLuoi_DaDonKhach(false, false);

                        //Xóa cuộc gọi trên MEM,chuyển sang kết thúc
                        if (bwSync_RemoveCuocGoi != null)
                            bwSync_RemoveCuocGoi.RunWorkerAsync(cuocGoiRow);
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi(ref g_lstDienThoai_DaDonKhach, cuocGoiRow, true);
                        HienThiTrenLuoi_DaDonKhach(true, false);
                    }
                }
            }
        }

        /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        /// <param name="lstDienThoai"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        private string KiemTraXeCoTrongCuocKhachHienTai(long idCuocGoi, string SoHieuXe)
        {
            string[] arrTaxi = SoHieuXe.Split('.');
            foreach (CuocGoi objDH in g_lstDienThoai)
            {
                if (objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (Array.IndexOf(arrTaxi, arrXeDaNhan[i]) > -1 && objDH.IDCuocGoi != idCuocGoi)
                        {
                            return string.Format("Xe {0} đã nhận đón ở địa chỉ {1}", arrXeDaNhan[i], objDH.DiaChiDonKhach);
                        }
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Xử lý thông tin xe đón do bên server gửi đến
        /// </summary>
        /// <param name="cuocGoiThayDoi">The cuoc goi thay doi.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/29/2015   created
        /// </Modified>
        private void XuLyThongTinThayDoi(CuocGoi cuocGoiThayDoi)
        {
            if (cuocGoiThayDoi == null) return;
            if (frmInput != null && frmInput.Visible && frmInput.GetCuocGoi.IDCuocGoi == cuocGoiThayDoi.IDCuocGoi)
            {
                frmInput.XuLyThongTinXeDon(cuocGoiThayDoi);
                frmInput.XuLyThongTinLenhLaiXe(cuocGoiThayDoi);
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

        /// <summary>
        /// Kiểm tra xem có được hiện những message confirm không có trip id không
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  9/8/2015   created
        /// </Modified>
        private bool DuocPhepHienNhungMessageKhongCoIDCuoiGoi()
        {
            var vungDuocCapPhep = g_strVungsDuocCapPhep.Split(";".ToCharArray());
            if (vungDuocCapPhep.Count() > 0)
            {
                foreach (string vung in vungDuocCapPhep)
                {
                    if (vung.Equals("1"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}