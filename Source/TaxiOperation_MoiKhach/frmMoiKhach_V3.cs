using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.IO;
using System.Diagnostics;
using TaxiOperation_MoiKhach;
using Taxi.Entity;
using Taxi.Controls;
using Taxi.Services;
using Taxi.Services.WCFServices;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using Taxi.Controls.FastTaxis.TaxiTrip;
using Taxi.Controls.FastTaxis;
using Asterisk.NET.Manager;
 
namespace Taxi.GUI
{
    public partial class frmMoiKhach_V3 : Form
    {
        #region ==========================Init=================================
        private List<CuocGoi> g_lstDienThoai = new List<CuocGoi>();
        private List<CuocGoi> g_lstCuocGoiDangTheoDoi = new List<CuocGoi>();

        private List<CuocGoi> g_lstCuocGoiKetThuc;
        private DateTime g_TimeServer;
        private Timer TimerCapturePhone;
        private string g_strVungsDuocCapPhep = string.Empty;
        private int g_soDong = 20; // cap nhat so dong cuoc ket thuc
        private bool g_boolChuyenTabCuocGoiKetThuc = false;
        private int g_iStatus = 0;  // Blink stautste
        private long g_iTimerKsXe = 0;
        private int g_iTimerMessage = 0; // kiểm tra thông tin message - chatting
        private int g_iTimeKetThucCuocGoi = 0;
        private bool g_bTimeKetThucCuocGoi = false;
        

        private int g_TimerCheckCanhBaoMoiKhach = 0; // tới một ngưỡng thời gian quy định (config) nếu mà cuốc khách chưa có trạng thái thôngt in mới khách thì cảnh báo
        private int g_SOPHUTCANHBAO = 0;
        private fmProgress m_fmProgress = null;

        private Color g_ColorOldTabCuocGoiDangThucHien;
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false;

        private string g_strUsername = "";
        private string g_strFullName = "";
        private string g_IPAddress = "";
        //private bool g_bKetThucTimer;
        private Int16 g_MayCS = 0; // vùng chăm sóc máy nhận về (1,2)
        private int g_CountKiemTraMayCS = 0;  // bien dem kiem tra cs la may gi

        //--- COM info ----
        string g_COMPort = "";
        public static frmCallOut frmCalling = new frmCallOut();
        //=================
        //--- Thoat cuoc 999 ----
        private int g_Thoat999SoPhutGioiHan;           // so phut gioi han cho phep thoat cuoc
        private bool g_Thoat999TrangThaiTATBAT;         // trang thai tat/bat của thoat cuoc
        private int g_Thoat999SoCuocGioiHan;            // so cuoc goi gioi han duoc phep su dụng 999
        //================= 
        private int g_SoLuongDangNhapCS = 0;            // luu so luong nguoi dang nhap bo phan CS. 10 giay quet mot lan
        private int g_iTimerLayMayCS = 0;

        private DateTime g_ThoiDiemLayDuLieuTruoc;
        private int g_RowIndex = 0;
        private int g_TimeStep = 0;
        private int g_timerMsg = 0;
        //---------
        private int g_iTimerManHinh = 0;
        private DateTime g_ThoiDiemNhanDuLieuTruoc_ManHinh = DateTime.MinValue;
        private List<ManHinhEntity> g_ListTinNhanManHinh = new List<ManHinhEntity>();

        private const string LENH_DAMOI = "Đã mời";
        private const string LENH_DANGGOI = "Đang gọi...";
        private const string LENH_GAPXE = "Gặp xe";
        private const string LENH_MAYBAN = "Máy bận";
        private const string LENH_KHONGLIENLACDUOC = "Ko LL được";
        private const string LENH_HUYXE = "Hủy xe/Hoãn";
        private const string LENH_KOTRUCTIEP = "Ko trực tiếp";
        private const string LENH_KOTHAYXE = "Ko thấy xe";
        private const string LENH_TRUOTCHUA = "Trượt/Chùa";
        private const string LENH_KHONGNGHEMAY = "Ko nghe máy";
        private const string LENH_KHONGNOIGI = "Ko nói gì";
        private const string LENH_KHONGXE = "Ko xe xl khách";
        private const string LENH_2_KHONGXE_XINLOI1 = "Ko xe lần 1";
        private const string LENH_MOIKHACH = "Mời khách";
        private const string LENH_7_MOIKHACHLAN2 = "Mời lần 2";
        private const string LENH_HOILAIDIACHI = "Hỏi lại địa chỉ";
        private const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        private const string LENH_DAXINLOI = "Đã xin lỗi khách";
        private const string LENH_6_KTRAKHACH = "kiểm tra khách";
        private const string LENH_DANGRA = "Đang ra";
        private const string LENH_TUCHOI = "Từ chối";
        private const string LENH_CHOSOLX = "Cho Số LX";
        private const string LENH_CHOKHACH = "Chờ khách";

        private List<string> g_ListSoHieuXe;

        public int G_IndexKhachVIP = 0;
        public int G_IndexKhachVang = 0;
        public int G_IndexKhachBac = 0;
        public int G_IndexKHThanThiet = 0;
        private Taxi.Business.GridLayout.GridLayout gridLayout;

        /// <summary>
        /// Background worker dong bo du lieu cuoc goi vao mem
        /// </summary>
        private BackgroundWorker bwSync_AddCuocGoi = new BackgroundWorker();
        private BackgroundWorker bwSync_RemoveCuocGoi = new BackgroundWorker();
        #endregion

        #region ==================== Thông số kết nối tổng đài =======================
        private ManagerConnection manager = null;
        /// <summary>
        /// line của Tổng đài PBX IP cho pc này
        /// </summary>
        private string g_lineIPPBX = string.Empty;
        private string g_lineIPPBX2 = string.Empty;
        public string g_LinesDuocCapPhepGoiRa = string.Empty;
        private string g_LinesDuocCapPhep = string.Empty;
        #endregion

        #region Tong dai PBX IP

        private void InitPBXIP()
        {
            try
            {
                manager = new ManagerConnection(AsteriskInfo.AST_HOSTNAME, AsteriskInfo.AST_PORT_NUMBER, AsteriskInfo.AST_USERNAME, AsteriskInfo.AST_PASSWORD);
                manager.Login();

                statusBar.Panels["COM"].Text = "/PBX-ok";
            }
            catch (Exception ex)
            {
                statusBar.Panels["COM"].Text = "/PBX-err";
                LogError.WriteLogError("InitPBXIP:" + string.Format("{0}-{1}-{2}-{3}", AsteriskInfo.AST_HOSTNAME, AsteriskInfo.AST_PORT_NUMBER, AsteriskInfo.AST_USERNAME, AsteriskInfo.AST_PASSWORD), ex);
            }
        }
        #endregion
        #region =======================Constructor=============================
        public frmMoiKhach_V3()
        {
            InitializeComponent();
        }

        #endregion

        #region ====================Load Form-Set Data=========================
        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            try
            {
                ThietLapKhungTroGiup();
                if (DieuHanhTaxi.CheckConnection())
                {
                    // Bắt đầu thời gian server.
                    TaxiReturn_Process.StartTimeServer();
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    // Lấy cấu hình.
                    Config_Common.LoadConfigCommon();
                    this.Text = string.Format("{0} - {1}", Configuration.GetCompanyName(), this.Text);
                    this.g_SOPHUTCANHBAO = Configuration.GetSoPhutCanhBaoMoiKhach();
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    this.g_strVungsDuocCapPhep = QuanTriCauHinh.GetLineVungOfPC(g_IPAddress, KieuMayTinh.MAYMOIKHACH);
                    //if (Debugger.IsAttached)
                    //{
                    //    g_strVungsDuocCapPhep = "1;2;3";
                    //}
                    if (Configuration.LineMoiKhach != "")
                    {
                        g_strVungsDuocCapPhep = Configuration.LineMoiKhach;
                    }
                    if (g_strVungsDuocCapPhep.Length > 0)
                    {
                        if (!CheckIn()) return;
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        //-----------Set location for panel message
                        //pnlMessage.Location = new Point(Width - pnlMessage.Width - 14, 0);
                        
                        
                        // Lấy ds các máy mời khách cùng vùng
                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();

                        getNewManHinh();
                        g_ThoiDiemNhanDuLieuTruoc_ManHinh = g_TimeServer;
                        if (ThongTinDangNhap.isMayCS1(g_IPAddress))
                        {
                            g_MayCS = 1;
                        }
                        else g_MayCS = 2;
                        if (Debugger.IsAttached)
                        {
                            g_MayCS = 1;
                        }
                        g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_strVungsDuocCapPhep);
                        
                        Text = String.Format("{0} - Mời khách số {5}-[{1} - {2}] - {3} - {4}", Configuration.GetCompanyName(), g_strVungsDuocCapPhep, g_IPAddress, ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME, g_MayCS);
                
                        LoadDuLieuKhoiDau();
                        g_ThoiDiemLayDuLieuTruoc = g_TimeServer;
                        gridCuocGois.Focus();
                       // g_bKetThucTimer = true;
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi

                        g_ListSoHieuXe = Xe.GetListSoHieuXe();
                        if (ThongTinCauHinh.FT_ChieuVe_Active)
                        {
                            tabTaxiChieuVe.TabVisible = true;
                            cmdTaxiChieuVe.Visible = Janus.Windows.UI.InheritableBoolean.True;
                            cmdBaoXeDiDuongDai3.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        }
                        else
                        {
                            tabTaxiChieuVe.TabVisible = false;
                            cmdTaxiChieuVe.Visible = Janus.Windows.UI.InheritableBoolean.False;
                            cmdBaoXeDiDuongDai3.Visible = Janus.Windows.UI.InheritableBoolean.False;
                        }
                        if (Configuration.IsMKAsterisk)
                        {
                            // lấy line của PBX IP để phục vụ gọi tự động ra ngoài
                            g_lineIPPBX = Configuration.LineIPPBX;//AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
                            g_lineIPPBX2 = Configuration.LineIPPBX2;//AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
                            // - khởi tạo kết nối tổng đài
                            InitPBXIP();
                            if (g_lineIPPBX == "")
                            {
                                if (string.IsNullOrEmpty(g_LinesDuocCapPhepGoiRa))
                                    g_lineIPPBX = AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
                                else
                                    g_lineIPPBX = AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhepGoiRa);
                                if (Debugger.IsAttached)
                                {
                                    g_lineIPPBX = "117";
                                }
                            }
                        }
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ////  LogError.WriteLog("IP : " + g_IPAddress, new Exception("Thong tin dia chi ip"));
                        Application.Exit();
                    }
                    statusBar.Panels["TenDangNhap"].Text = "NV: " + ThongTinDangNhap.USER_ID + " - "+ ThongTinDangNhap.FULLNAME;

                    KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                    statusBar.Panels["COM"].Text = " COM: " + g_COMPort;
                    LayCauHinhThoatCuoc999();

                    bwSync_AddCuocGoi.DoWork += bwSync_AddCuocGoi_DoWork;
                    bwSync_RemoveCuocGoi.DoWork += bwSync_RemoveCuocGoi_DoWork;
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
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                ////  LogError.WriteLog("Co loi khi khoi tao chuong trinh - DB "ll, ex);
            }

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

        private void LoadDuLieuKhoiDau()
        {
            // Create a background thread
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            // Create a progress form on the UI thread
            m_fmProgress = new fmProgress();

            // Kick off the Async thread
            bw.RunWorkerAsync();

            // Lock up the UI with this modal progress form.
            try
            {
                m_fmProgress.ShowDialog(this);
                m_fmProgress = null;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadDuLieuKhoiDau:", ex);
            }
        }

        #region Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION
        /// </summary>
        /// <returns></returns>
        private List<CuocGoi> GetAllCuocGoiDangTheoDoi(string sVung, int MayMoiKhachSo)
        {
            try
            {
                CuocGoi objDHTaxi = new CuocGoi();
                string SQLCondition = "";
                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";

                //if (MayMoiKhachSo == 0)
                //{
                //    SQLCondition += " ";
                //}
                ////else 
                //    if (MayMoiKhachSo == 1)
                //    SQLCondition += " AND ((CAMON_DanhGia IS NULL) OR (CAMON_DanhGia =1) OR (CAMON_DanhGia =0)) ";
                //else SQLCondition += " AND (CAMON_DanhGia = 2)  ";

                SQLCondition += " ORDER BY ThoiDiemGoi DESC";
                return objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadDuLieuKhoiDau:", ex);
                return null;
            }
        }
        private string GetSQLStringQueryVung(string Vung)
        {
            string strReturn = " (1<>1) ";
            string[] arrVung = Vung.Split(";".ToCharArray());

            foreach (string strV in arrVung)
            {
                if (strV.Length > 0) strReturn += " OR (Vung = " + strV + ") ";
            }
            return strReturn;
        }
        /// <summary>
        /// cuoc goi dien thoai moi gui sang : TrangThaiLenh = 1
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<CuocGoi> GetAllCuocGoiDienThoaiMoiGoiSang(List<CuocGoi> ListAllCuocGoiDangHoatDong)
        {
            List<CuocGoi> ListCuocGoiDienThoaiMoiGoiSang = new List<CuocGoi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (CuocGoi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach
                        || objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach
                        || objDHTaxi.GoiKhieuNai || (objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai && objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi))

                        ListCuocGoiDienThoaiMoiGoiSang.Add(objDHTaxi);
                }
            }
            return ListCuocGoiDienThoaiMoiGoiSang;

        }
        #endregion Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        private void loadLayout(GridEX gridEX)
        {
            try
            {
                gridLayout = new Taxi.Business.GridLayout.GridLayout(ThongTinDangNhap.USER_ID, "MoiKhach", Name, gridEX.Name);
                gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
            }
            catch (Exception)
            {
                new MessageBox.MessageBoxBA().Show(this, "Lỗi cấu hình hiển thị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }

        }

        #endregion

        #region ======================Validation Form==========================
        /// <summary>
        /// ham tra trang thai xem may co phai la may moi khach 1 hay khong ?
        /// May moi khach 1 la may co IP min trong cac may MK
        /// </summary>
        /// <returns></returns>
        private bool IsLaMayMoiKhach1()
        {
            // cung lop ip 
            bool bMayMoiKhach1 = true;
            List<string> lstIPMoiKhach = QuanTriCauHinh.GetDSMayTinhMoiKhachByVung(this.g_strVungsDuocCapPhep);
            if (lstIPMoiKhach != null && lstIPMoiKhach.Count > 0)
            {
                foreach (string strItem in lstIPMoiKhach)
                {
                    if ((strItem != this.g_IPAddress) && (strItem.CompareTo(this.g_IPAddress) > 0))
                        return false;
                }
            }

            return bMayMoiKhach1;
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
                            return false;
                        }
                        //new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //Application.Exit();
                        //return;
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
                        new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        g_strFullName = "";
                        Application.Exit();
                        return false;
                    }
                    else
                    {
                        if (!Debugger.IsAttached&& !(ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHCSKH)))
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Bạn không có quyền điều hành mời khách.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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

                statusBar.Panels["TenDangNhap"].Text = string.Format("NV : {0} - {1}", g_strUsername, g_strFullName);
                //if (ThongTinDangNhap.USER_ID != "admin")
                //{
                //    //thực hiện phân quyền trên menu
                //    PhanQuyenMenu(uiCommandBar2, ThongTinDangNhap.PermissionsFull);
                //    PhanQuyenMenu(uiCommandBar1, ThongTinDangNhap.PermissionsFull);
                //}
                return true;
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                g_strFullName = "";
                Application.Exit();
                return false;
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
                CuocGoi objCuocGoi = (CuocGoi)row.DataRow;
                if ((objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.BoDam))
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.BoDam;
                else if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai)
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                else if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.MoiKhachGui)
                    row.Cells["ImageCol"].ImageIndex = 3;
                else if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi)
                    row.Cells["ImageCol"].ImageIndex =0;
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                //if (objCuocGoi.MOIKHACH_LenhMoiKhach != LENH_DAMOI && !string.IsNullOrEmpty(objCuocGoi.XeDenDiem))
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                //    row.Cells["XeDenDiem"].FormatStyle = RowStyle;
                //}
                //else
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Aquamarine };
                //    row.Cells["XeDenDiem"].FormatStyle = RowStyle;
                //}

                if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Yellow };
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang
                   || objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.ForestGreen;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                //if (objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI ||
                //    objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN ||
                //    objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI ||
                //    objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_HUYXE ||
                //    objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE ||
                //    objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC)
                //{
                //    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Aquamarine };
                //    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                //}
                if (objCuocGoi.LenhTongDai == LENH_MOIKHACH || objCuocGoi.LenhTongDai == LENH_7_MOIKHACHLAN2)
                {
                    if (objCuocGoi.LenhDienThoai == LENH_DAMOI || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_DAMOI
                        || objCuocGoi.LenhDienThoai == LENH_GAPXE || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_GAPXE
                        || objCuocGoi.LenhDienThoai == LENH_HOILAIDIACHI || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_HOILAIDIACHI
                        || objCuocGoi.LenhDienThoai == LENH_KHONGXE || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGXE
                        || objCuocGoi.LenhDienThoai == LENH_MAYBAN || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_MAYBAN
                        || objCuocGoi.LenhDienThoai == LENH_KHONGLIENLACDUOC || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGLIENLACDUOC
                        || objCuocGoi.LenhDienThoai == LENH_TRUOTCHUA || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_TRUOTCHUA
                        || objCuocGoi.LenhDienThoai == LENH_KHONGNOIGI || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_KHONGNOIGI
                        || objCuocGoi.LenhDienThoai == LENH_KOTRUCTIEP || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_KOTRUCTIEP
                        || objCuocGoi.LenhDienThoai == LENH_TUCHOI || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_TUCHOI
                        || objCuocGoi.LenhDienThoai == LENH_DANGRA || objCuocGoi.MOIKHACH_LenhMoiKhach == LENH_DANGRA
                        )
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Red;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                    else
                    {
                        GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                        RowStyle.BackColor = Color.Red;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                    }
                }
                else if (objCuocGoi.LenhTongDai == LENH_HOILAIDIACHI)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Violet };
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.LenhDienThoai == LENH_KHACHDAT)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Green };
                    row.Cells["LenhDienThoai"].FormatStyle = RowStyle;
                }

                if (objCuocGoi.SoLanGoi == 1)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Yellow };
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.SoLanGoi >= 2)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                    row.Cells["SoLanGoi"].FormatStyle = RowStyle;
                }

                if ((objCuocGoi.LenhTongDai == LENH_KHONGXE || objCuocGoi.LenhTongDai == LENH_2_KHONGXE_XINLOI1) && objCuocGoi.ThoiDiemGoi.AddMinutes(3) <= g_TimeServer)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                    row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                }

                if (objCuocGoi.ThoiGianDieuXe > Configuration.GetGioiHanThoiGianDieuXe())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { ForeColor = Color.Red };
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["ThoiGianDieuXe"].FormatStyle = RowStyle;

                }
                if (objCuocGoi.ThoiGianDonKhach > Configuration.GetGioiHanThoiGianDonKhach())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { ForeColor = Color.Red };
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["ThoiGianDonKhach"].FormatStyle = RowStyle;

                }
                if (objCuocGoi.LoaiXe.Contains("7"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Cyan };
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }
                if (objCuocGoi.SoLuong > 0)
                {
                    int SoLuong = Convert.ToInt32(objCuocGoi.SoLuong);
                    if (objCuocGoi.XeNhan.Length > 0)
                    {
                        //int SoLuongDangCo = Convert.ToInt32(objCuocGoi.XeNhan.Split(',').Length + 1) / 4;
                        if (SoLuong > objCuocGoi.XeNhan.Split(',').Length)
                        {
                            GridEXFormatStyle RowStyle = new GridEXFormatStyle() { BackColor = Color.Red };
                            row.Cells["SoLuong"].FormatStyle = RowStyle;
                        }
                        else
                        {
                            GridEXFormatStyle RowStyle = new GridEXFormatStyle()
                            {
                                BackColor = Color.Aquamarine
                            };
                            row.Cells["SoLuong"].FormatStyle = RowStyle;
                        }

                    }
                }
                // Hien thi mau cho cham soc khach hang
                if (objCuocGoi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTot)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightCoral;
                    row.Cells["Time"].FormatStyle = RowStyle;
                }
                else if (objCuocGoi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTrungBinh)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.SpringGreen;
                    row.Cells["Time"].FormatStyle = RowStyle;
                }

                // Hiển thị màu theo thời gian để cảnh báo
                TimeSpan timeSpan = g_TimeServer - objCuocGoi.ThoiDiemGoi;

                // Nen cua dia chi may tim - cho phep thoat cuoc 999
                if ((g_lstDienThoai != null && g_lstDienThoai.Count >= g_Thoat999SoCuocGioiHan) && g_Thoat999TrangThaiTATBAT && timeSpan.TotalMinutes >= g_Thoat999SoPhutGioiHan)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Indigo;
                    //RowStyle.ForeColor = Color.White;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    //RowStyle.BackColor = Color.White;
                    RowStyle.ForeColor = Color.Black;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }

                setStyleXeNhan(row, objCuocGoi.ThoiDiemGoi, objCuocGoi.XeNhan_TD, objCuocGoi.XeNhan, objCuocGoi.DanhSachXeDeCu, row.Cells["XeNhan_CB"].Column.Width);

                setStyleXeDenDiem(row, objCuocGoi.MOIKHACH_LenhMoiKhach, objCuocGoi.XeDenDiem, objCuocGoi.XeDenDiemDonKhach, row.Cells["XeDenDiem_CB"].Column.Width,objCuocGoi.ThoiDiemGoi);

            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("HienThiAnhTrangThai_MauChu " + ex.Message);
                //  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }

        private void setStyleXeDenDiem(GridEXRow row, string lenhMoiKhach, string xeDenDiem, string xeDenDiemDonKhach, int ColWidth, DateTime thoiDiemGoi)
        {
            TimeSpan timer = g_TimeServer - thoiDiemGoi;
            if (timer.TotalMinutes > 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.LightSteelBlue, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 10)
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.MistyRose, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            else
                row.Cells["XeDenDiem_CB"].Image = (Image)Global.ConvertTextToImage2(xeDenDiemDonKhach, xeDenDiem, Color.Aquamarine, Color.Blue, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                
        }

        private void setStyleXeNhan(GridEXRow row, DateTime ThoiDiemGoi, string xeNhanTD, string xeNhan, string xeDeCu, int ColWidth)
        {
            if (string.IsNullOrEmpty(xeNhan))
            {
                TimeSpan timer = g_TimeServer - ThoiDiemGoi;
                if (timer.TotalMinutes > 1 && timer.TotalMinutes < 5)
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Aquamarine, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                else if (timer.TotalMinutes >= 5 && timer.TotalMinutes <= 30)
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Orange, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
                else
                    row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage("", "", "", Color.Aquamarine, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
            }
            else
                row.Cells["XeNhan_CB"].Image = (Image)Global.ConvertTextToImage(xeNhanTD, xeNhan, xeDeCu, Color.Aquamarine, Color.Red, ColWidth, Config_Common.LuoiCuocGoi_RowHeight_TiepNhan, Config_Common.LuoiCuocGoi_FontSize_TiepNhan);
        }

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }

        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {

            int iSoCuocGoiChuaDieuXe = 0;
            int iSoCuocGoiChuaDonDuocKhach = 0;
            int iSoXeChuaNhapDiaChiTraKhach = 0;
            if (g_lstDienThoai != null)
            {
                foreach (CuocGoi objDH in g_lstDienThoai)
                {
                    if ((objDH.XeNhan.Length <= 0))
                        iSoCuocGoiChuaDieuXe += 1;
                    if ((objDH.XeNhan.Length > 0) && (objDH.XeDon.Length <= 0))
                        iSoCuocGoiChuaDonDuocKhach += 1;


                }
            }
            if (g_lstCuocGoiKetThuc != null)
            {
                foreach (CuocGoi objDH in g_lstCuocGoiKetThuc)
                {
                    if ((StringTools.TrimSpace(objDH.XeDon).Length > 0) && (StringTools.TrimSpace(objDH.DiaChiTraKhach).Length <= 0))
                    {
                        iSoXeChuaNhapDiaChiTraKhach += 1;
                    }
                }
            }
            this.statusBar.Panels[1].Width = 170;
            this.statusBar.Panels[1].Text = "Cuộc gọi chưa điều xe : " + iSoCuocGoiChuaDieuXe.ToString();
            this.statusBar.Panels[2].Width = 260;
            this.statusBar.Panels[2].Text = "Cuộc gọi đã điều chưa đón được khách : " + iSoCuocGoiChuaDonDuocKhach.ToString();
            this.statusBar.Panels[3].Width = 210;
            if (serialPort1.IsOpen)
                this.statusBar.Panels[3].Text = "COM: " + "Open - " + serialPort1.PortName;
            else
                this.statusBar.Panels[3].Text = "COM: " + "Close";
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
                if (IsCapNhat)
                {
                    if (IsThemMoi)
                    {
                        gridCuocGois.DataSource = null;
                        gridCuocGois.DataMember = "ListDienThoai";
                        gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                        gridCuocGois.MoveToRowIndex(g_RowIndex + 1);
                    }
                    else
                    {
                        gridCuocGois.Refresh();
                        gridCuocGois.Refresh();
                    }
                }
                else
                {
                    gridCuocGois.Refresh(); 
                    gridCuocGois.Refetch();
                    if (gridCuocGois.RowCount > g_RowIndex)
                    {
                        gridCuocGois.MoveToRowIndex(g_RowIndex);
                    }
                    else if (gridCuocGois.RowCount > 0)
                    {
                        gridCuocGois.MoveToRowIndex(0);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// thiết lập panel trợ giúp
        /// </summary>
        private void ThietLapKhungTroGiup()
        {
            panelTopHelp.Location = new Point(this.Width - (panelTopHelp.Width + 15 + 32), 0);
            panelTopHelp.Visible = true;
            btnHelp.Location = new Point(this.Size.Width - (btnHelp.Size.Width + 15), 0);
        }
        #endregion

        #region =======================Get Data Form===========================
        public void GetKiemSoatXe()
        {
            List<KiemSoatXeLienLac> listOfXe = new List<KiemSoatXeLienLac>();
            List<KiemSoatXeLienLac> listOfXeCapNhatTrangThai = new List<KiemSoatXeLienLac>();
            listOfXe = KiemSoatXeLienLac.GetTrangThaiAllXe_KSLL();
            DateTime timeCurrentServer = DieuHanhTaxi.GetTimeServer();
            if ((listOfXe != null) && (listOfXe.Count > 0))
            {
                foreach (KiemSoatXeLienLac objKSLLXe in listOfXe)
                {
                    listOfXeCapNhatTrangThai.Add(KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSLLXe, timeCurrentServer));
                }
            }

            if ((listOfXeCapNhatTrangThai != null) && (listOfXeCapNhatTrangThai.Count > 0))
            {
                //    danhsachXeMatLienLac.ViewListXe(KieuMatLienLac.XeMatLienLac, listOfXeCapNhatTrangThai);
                //    danhsachXeXinNghi.ViewListXe(KieuMatLienLac.XeXinNghi, listOfXeCapNhatTrangThai);
                //    danhsachXeDiSanBay.ViewListXe(KieuMatLienLac.XeDiSanBay, listOfXeCapNhatTrangThai);
                //    danhsa chXeDiDuongDai.ViewListXe(KieuMatLienLac.XeDiDuongDai, listOfXeCapNhatTrangThai);
            }
        }

        #endregion

        #region ========================Form Events============================
        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabCuocGoiChoGiaiQuyet")
            {

            g_boolChuyenTabCuocGoiKetThuc = false;

            }
            else if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
                g_boolChuyenTabCuocGoiKetThuc = true;

            }
            else if (e.Page.Name == "uiTabKiemSoatXe")
            {
                g_boolChuyenTabCuocGoiKetThuc = false;

                // GetKiemSoatXe();
            }

        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            //if (gridCuocGoi_KetThuc.SelectedItems == null || gridCuocGoi_KetThuc.SelectedItems.Count <= 0)
            //    uiContextMenu1.Close();
        }

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdTinhCuoc")
            {
                frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdThayDoiMatKhau")
            {
                new CapNhatThongTinCaNhan().ShowDialog();
            }
            else if (e.Command.Key == "cmdTinhCuoc")
            {
                frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                frm.ShowDialog();
            }
            else if (e.Command.Key == "cmdLogin")
            {
                CheckIn();

            }
            else if (e.Command.Key == "cmdCheckOut")
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

            } // cmdTraCuuDiaDanh
            else if (e.Command.Key == "cmdTraCuuDiaDanh")
            {
                new frmDMDiaDanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdNoiDungTroGiup")
            {
                try
                {
                    string HDSDPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    HDSDPath = HDSDPath + "\\" + "HDSD.pdf";
                    System.Diagnostics.Process.Start(HDSDPath);
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBoxBA().Show(this, "File hướng dẫn không tồn tại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            else if (e.Command.Key == "cmdAbout")
            {
                new frmAbout().ShowDialog();
            }
            else if (e.Command.Key == "cmdRefresh")
            {
                g_ListSoHieuXe = Xe.GetListSoHieuXe();
            }

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
                        ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMoiKhach_V3));
                        gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                        gridCuocGois.LoadLayout(gridLayout.getLayout(gridCuocGois.GetLayout()));
                    }
                    else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                    {
                        ComponentResourceManager resources = new ComponentResourceManager(typeof(frmMoiKhach_V3));
                        gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                        gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                    }
                }
            }
            else if (e.Command.Key == "cmdBaoXeDiDuongDai")
            {
                if(ThongTinCauHinh.FT_ChieuVe_Active)
                    new frmUpdateTrip().ShowDialog();
            }
        }

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (gridCuocGoi_KetThuc.SelectedItems.Count <= 0) return;
            if (e.Command.Key == "cmdChon20Dong")
            {
                g_soDong = 20;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong, g_MayCS);
            }
            else if (e.Command.Key == "cmdChon50Dong")
            {
                g_soDong = 50;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong, g_MayCS);
            }
            else if (e.Command.Key == "cmdChon100Dong")
            {
                g_soDong = 100;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong, g_MayCS);
            }
            else if (e.Command.Key == "cmdChon200Dong")
            {
                g_soDong = 200;
                LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong, g_MayCS);
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

        private void btnXeBaoHoatDong_Click(object sender, EventArgs e)
        {

            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(1);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    this.GetKiemSoatXe();
            //}            
        }

        private void btnXeBaoDiem_Click(object sender, EventArgs e)
        {
            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(2);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    this.GetKiemSoatXe();
            //}     
        }

        private void btnXeMatLienLac_Click(object sender, EventArgs e)
        {
            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(3);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    this.GetKiemSoatXe();
            //}     
        }

        private void btnXeBaoVe_Click(object sender, EventArgs e)
        {
            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(4);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    this.GetKiemSoatXe();
            //}     
        }

        private void OnXeLienLacClickHandler(object XeLienLac, Taxi.Controls.XeLienLacEventArgs XeLienLacInfo)
        {
            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(3, XeLienLacInfo.SoHieuXe);

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    GetKiemSoatXe();
            //}
        }

        private void btnBaoCaoXeHoatDong_Click(object sender, EventArgs e)
        {

        }

        private void uiCommandBar1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //cmdTinhTien
            //cmdTraCuuVeHuy
            //cmdHoiThongTin1080
            //cmdXeRaHoatDong
            //cmdXeveGara
            if (e.Command.Key == "cmdTinhTien")
            {
                frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                frm.ShowDialog();
                //if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0)
                //{                   
                //}
                //else
                //{
                //    //frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP();
                //    //frm.ShowDialog();
                //}
            }
            else if (e.Command.Key == "cmdTraCuuVeHuy")
            {
                new frmTraCuu().ShowDialog();
            }
            else if (e.Command.Key == "cmdHoiThongTin1080")
            {
                new frmDMDiaDanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdKhoiTaoCOM")
            {
                frmCall frm = new frmCall(this.g_COMPort);
                frm.ShowDialog(this);
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
            else if (e.Command.Key == "cmdBaoXeDiDuongDai")
            {
                new frmUpdateTrip().ShowDialog();
            }
        }

        private void frmMoiKhach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int iRowSelect = -1;
            if (keyData == (Keys.Alt | Keys.D1)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 0;

            }
            else if (keyData == (Keys.Alt | Keys.D2)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 1;
            }
            else if (keyData == (Keys.Alt | Keys.D3)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 2;
            }
            else if (keyData == (Keys.Alt | Keys.D4)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 3;
            }
            else if (keyData == (Keys.Alt | Keys.D5)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 4;
            }
            else if (keyData == (Keys.Alt | Keys.D6)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 5;
            }
            else if (keyData == (Keys.Alt | Keys.D7)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 6;
            }
            else if (keyData == (Keys.Alt | Keys.D8)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 7;
            }
            else if (keyData == (Keys.Alt | Keys.D9)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 8;
            }

            else if (keyData == (Keys.Alt | Keys.D0)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 9;
            }

            if (iRowSelect >= 0)
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex == 1)
                {
                    if (gridCuocGoi_KetThuc.RowCount > iRowSelect)
                    {
                        gridCuocGoi_KetThuc.Row = iRowSelect;
                        GridEXRow row = gridCuocGoi_KetThuc.GetRow(iRowSelect);
                        ///NhapDulieu_DiaChiTraKhach(row); 
                    }
                    return true;
                }

                if (gridCuocGois.RowCount > iRowSelect)
                {
                    gridCuocGois.Row = iRowSelect;
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(iRowSelect);

                }
                return true;
            }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                //case Keys.Control | Keys.H:
                //    ctrlListBook_ChoXuLy.ShowCtrlH();
                //    return true;
                case Keys.Control | Keys.Down:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex == 2)
                    {

                        //if (tabControl1.SelectedIndex == 0)
                        //{
                        //    ctrlListBook_ChoXuLy.ForcusGrid();
                        //}
                        //else
                        //{
                        //    ctrlListBook_DaKetThuc.ForcusGrid();
                        //}
                    }
                    else
                    {
                        if (gridManHinh.Focused)
                            gridCuocGois.Select();
                        else if (gridCuocGois.Focused)
                            gridManHinh.Select(); 
                    }
                                      
                    return true;
                 case Keys.Control | Keys.Up:
                    if (uiTabCuocGoiDangThucHien.SelectedIndex == 2)
                    {
                        //if (tabControl1.SelectedIndex == 0)
                        //{
                        //    ctrlDanhSachXeChieuVe_ChoXuLy.ForcusGrid();
                        //}
                        //else
                        //{
                        //    ctrlDanhSachXeChieuVe_DaKetThuc.ForcusGrid();
                        //}
                    }
                    else
                    {
                        if (gridManHinh.Focused)
                            gridCuocGois.Select();
                        else if (gridCuocGois.Focused)
                            gridManHinh.Select();
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
            }
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 2)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    //if (ctrlDanhSachXeChieuVe_ChoXuLy.FindKeyCommand(keyData))
                    //    return true;
                    //if (ctrlListBook_ChoXuLy.FindKeyCommand(keyData))
                    //    return true;
                }
                else
                {
                    //if (ctrlDanhSachXeChieuVe_DaKetThuc.FindKeyCommand(keyData))
                    //    return true;
                    //if (ctrlListBook_DaKetThuc.FindKeyCommand(keyData))
                    //    return true;
                }
                //if (keyData == (Keys.Control | Keys.Left))
                //{
                //    tabControl1.SelectedIndex = 0;
                //    ctrlDanhSachXeChieuVe_ChoXuLy.ForcusControl();
                //}
                //if (keyData == (Keys.Control | Keys.Right))
                //{
                //    tabControl1.SelectedIndex = 1;
                //    ctrlDanhSachXeChieuVe_DaKetThuc.ForcusControl();
                //}
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region =========================Grid Event============================
        private void gridDienThoai_DoubleClick(object sender, EventArgs e)
        {
            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position);

            }
        }

        private void gridDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            bool hasThucHienLenh = false;  // dung de xac dinh có thay đổi dữ liệu và gọi update
            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                
                int positionRowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position;
                CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
                if (cuocGoiRow == null) return;

                cuocGoiRow.MOIKHACH_NhanVien = ThongTinDangNhap.USER_ID;
                if (e.KeyCode == Keys.Enter)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position);
                     
                }
                else if (e.KeyData == Keys.F4 || e.KeyData == Keys.Space)
                {
                    //CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                    if (gridCuocGois.SelectedItems.Count > 0)
                    {
                        g_bTimeKetThucCuocGoi = true;
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_DANGGOI;
                        hasThucHienLenh = true;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                        HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true,g_lineIPPBX);
                    }
                }

                else if (e.KeyData == (Keys.Control | Keys.Space))
                {
                    //CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                    if (gridCuocGois.SelectedItems.Count > 0)
                    {
                        g_bTimeKetThucCuocGoi = true;
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_DANGGOI;
                        hasThucHienLenh = true;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        CuocGoi.Update_ThoiDiemMoiKhach(cuocGoiRow.IDCuocGoi, ThongTinDangNhap.USER_ID);
                        HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + cuocGoiRow.PhoneNumber, cuocGoiRow.DiaChiDonKhach, true, g_lineIPPBX2);
                    }
                } 
                #region Lệnh Mời khách
                else if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_CHOKHACH;//LENH_DAMOI;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận.", LENH_DAMOI), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }

                }
                //================ 2 : Gặp xe rồi
                else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_GAPXE;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận.", LENH_GAPXE), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                
                //không xe xin lỗi khách - điên thoại kết thúc
                else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi && (cuocGoiRow.TrangThaiCuocGoi == Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe || 
                                                                            cuocGoiRow.TrangThaiCuocGoi == Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1))
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_DAXINLOI;
                        cuocGoiRow.TrangThaiCuocGoi = TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, "[Không xe xin lỗi khách] Cuội gọi phải là cuộc gọi taxi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                
                //================ 4 : máy bận
                else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_MAYBAN;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_MAYBAN), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                
                //================ 5 : không liên lạc được với khách
                else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_KHONGLIENLACDUOC;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi.", LENH_KHONGLIENLACDUOC), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }

                //================ 6 : không nghe máy
                else if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_KHONGNGHEMAY;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận đón.", LENH_KHONGNGHEMAY), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                //================ 7 : không nói gì=>Cho số lx
                else if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    if (cuocGoiRow.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_CHOSOLX;
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                        hasThucHienLenh = true;
                    }
                    else
                    {
                        msgDialog.Show(this, String.Format("[Lệnh {0}] Cuội gọi phải là cuộc gọi taxi và đã có xe nhận đón.", LENH_KHONGNOIGI), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
                //================ 8 : Hủy xe / Hoãn
                else if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_HUYXE;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //================ 9 : Không trực tiếp
                else if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_KOTRUCTIEP;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //================ O : Không thấy xe
                else if (e.KeyCode == Keys.O)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_KOTHAYXE;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //================ R : Đang Ra
                else if (e.KeyCode == Keys.R)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_DANGRA;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //================ T : Từ chối
                else if (e.KeyCode == Keys.C)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_TUCHOI;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //================ T : Không thấy xe
                else if (e.KeyCode == Keys.T)
                {
                    cuocGoiRow.MOIKHACH_LenhMoiKhach = LENH_TRUOTCHUA;
                    cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    hasThucHienLenh = true;
                }
                //============== Backspace : xóa lệnh
                else if (e.KeyCode == Keys.Back)
                {
                    // thực hiện khi có xe nhận
                    if (cuocGoiRow.MOIKHACH_LenhMoiKhach != "")
                    {
                        hasThucHienLenh = true;
                        cuocGoiRow.MOIKHACH_LenhMoiKhach = "";
                        cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                    }
                }
                #endregion

                else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Subtract)
                {
                    if (cuocGoiRow.KieuCuocGoi != KieuCuocGoi.GoiLai)
                    {
                        // Hiển thị ô nhập  
                        frmInputOnGrid frmInput = new frmInputOnGrid(cuocGoiRow, KieuNhapTrenGridTongDai.NhapXeDon, g_ListSoHieuXe, IsThoatDuoc999(cuocGoiRow, g_TimeServer));
                        int yRow = positionRowSelect * gridCuocGois.RootTable.RowHeight + 130; // vị trí của dòng đầu tiên cộng thêm.
                        if (yRow > gridCuocGois.Height)
                        {
                            yRow = gridCuocGois.Height - frmInput.Height;
                        }
                        frmInput.Location = new Point(625, yRow);
                        if (frmInput.ShowDialog() == DialogResult.OK && frmInput.IsKetThuc())
                        {
                            cuocGoiRow.XeDon = frmInput.GetGiaTriNhap();
                            cuocGoiRow.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                            hasThucHienLenh = true;
                        }
                    }
                    else
                    {
                        msgDialog.Show(this, "[Lệnh trượt] " + "Cuội gọi lại, không nhập xe đón.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }

                if (hasThucHienLenh)
                {
                    cuocGoiRow.MOIKHACH_NhanVien = ThongTinDangNhap.USER_ID;
                    if (!CuocGoi.MK_UpdateThongTinCuocGoi(cuocGoiRow))
                    {
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, cuocGoiRow, true);
                            HienThiTrenLuoi(true, false);
                        }
                    }
                }
                
            }
        }

        private void gridCuocGois_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGois_SelectionChanged(object sender, EventArgs e)
        {
            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                CuocGoi cuocGoiRow = (CuocGoi)gridCuocGois.SelectedItems[0].GetRow().DataRow;
                if (cuocGoiRow == null) return;
                g_RowIndex = gridCuocGois.CurrentRow.RowIndex;
                lblSdt.Text = cuocGoiRow.PhoneNumber;
                lblDiaChi.Text = cuocGoiRow.DiaChiDonKhach;
                lblDHV.Text = cuocGoiRow.LenhTongDai;
            }
        }

        private void gridCuocGoi_KetThuc_FormattingRow(object sender, RowLoadEventArgs e)
        {
            //HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGoi_KetThuc_Click(object sender, EventArgs e)
        {

        }

        private void gridCuocGoi_KetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems != null && gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                CuocGoi cuocGoiRow = (CuocGoi)gridCuocGoi_KetThuc.SelectedItems[0].GetRow().DataRow;
                if (e.KeyCode == Keys.Enter)
                {
                    gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDiCuocGoiKetThuc(((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).Position);
                }
                else if (e.KeyData == Keys.B)
                {
                    //new frmHienThiBanDo(cuocGoiRow).Show();
                }
                // Ban Do Xe Nhan
                else if (e.KeyData == Keys.X)
                {
                    //new frmHienThiBanDo_XeNhan(cuocGoiRow).Show();
                }
            }
        }

        private void gridCuocGoi_KetThuc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRigthClick_CGChuaGiaiQuyet.ShowCustomizeDialog();
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
                    NhapDuLieuVaoTruyenDiCuocGoiKetThuc(((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).Position);
            }
        }

        /// <summary>
        /// - Nhan vao vi tri cua mot dong trong list cac cuoc goi dang hien hanh
        /// - lay gia tri len form 
        /// - nhap vao truyen di
        /// 
        /// </summary>
        /// <param name="iRowPosition"></param>
        private void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {

            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                if (objCuocGoi == null) return;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Tan;
                rowSelect.RowStyle = RowStyle;
                //End - Thu doi mau

                LENHCUATONGDAI_MOIKHACH LenhTongDai = GetLenhTongDai(objCuocGoi);

                if (LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI)
                {
                    frmKhieuNaiInputData_V3 frmKhieuNai = new frmKhieuNaiInputData_V3(objCuocGoi);
                    if (frmKhieuNai.ShowDialog() == DialogResult.OK)
                    {

                        objCuocGoi.MOIKHACH_NhanVien = ThongTinDangNhap.USER_ID;
                        if (!objCuocGoi.Update_MOIKHACH_KhieuNai())
                        {

                            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                            msgDialog.Show(this, "Không lưu được thông tin khiếu nại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                            return;
                        }
                        else if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            objCuocGoi.Update_KetThucCuocGoi(objCuocGoi.IDCuocGoi, objCuocGoi.TrangThaiLenh);
                        }
                    }
                    RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Tan;
                    rowSelect.RowStyle = RowStyle;
                    return; // ket thuc khieu nai
                }

                // congnt add
                if (objCuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXeLan1)
                {
                    MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                    msg.Show(this, "Cuốc khách đang không xe lần 1. Bạn đợi một chút để điều lại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    return;
                }
                else if (objCuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.CuocGoiKhongXe)
                {
                    LenhTongDai = LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI;
                }

                // congnt end 

                frmMoiKhachInputData_V3 frm = new frmMoiKhachInputData_V3(objCuocGoi, LenhTongDai, IsThoatDuoc999(objCuocGoi, g_TimeServer), g_ListSoHieuXe);

                DialogResult _DialogResult = frm.ShowDialog(this);
                if (_DialogResult == DialogResult.OK)
                {
                    objCuocGoi = frm.GetCuocGoi;
                    objCuocGoi.MOIKHACH_NhanVien = g_strUsername;

                    if (LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH || LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH)
                    {
                        objCuocGoi.MOIKHACH_KhieuNai_DaXyLy = false;
                        objCuocGoi.MOIKHACH_XinLoi_DaXinLoi = false;
                        //objCuocGoi.MOIKHACH_KhieuNai_ThongTinThem = "";
                        objCuocGoi.MOIKHACH_ThoiDiemMoi_Giu = g_TimeServer;

                        //if (!objCuocGoi.Update_MOIKHACH_MoiKhachGiu())
                        //{
                        //    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        //    msgDialog.Show(this, "Không lưu được thông tin mời, giữ khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //    return;
                        //}
                        //else
                        //    objCuocGoi.Update_KetThucCuocGoi(objCuocGoi.IDCuocGoi, TrangThaiLenhTaxi.MoiKhachGui);// cập nhạt trạng thái mời kháhc gửi
                    }
                    else if (LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI)
                    {
                        objCuocGoi.MOIKHACH_KhieuNai_DaXyLy = false;

                        //objCuocGoi.MOIKHACH_KhieuNai_ThongTinThem = "";
                        objCuocGoi.MOIKHACH_ThoiDiemMoi_Giu = g_TimeServer;
                        //if (!objCuocGoi.Update_MOIKHACH_KhongXeXinLoi())
                        //{
                        //    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        //    msgDialog.Show(this, "Không lưu được thông tin cuộc gọi không xe xin lỗi. Có thể tổng đài đã thay đổi thông tin cuộc gọi.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //    return;
                        //}
                        //else
                        //{
                        //    objCuocGoi.Update_KetThucCuocGoi(objCuocGoi.moiIDCuocGoi, objCuocGoi.TrangThaiLenh);
                        //}
                    }
                    //TimVaCapNhatVaoDanhSach(objCuocGoi);

                    if (!CuocGoi.MK_UpdateThongTinCuocGoi_V4(objCuocGoi))
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Không lưu được dữ liệu, xin hãy liên hệ với quản trị.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                        return;
                    }
                    else //
                    {
                        if (objCuocGoi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc)
                        {
                            SapXepLaiIndex(objCuocGoi);
                            // remove tai luoi
                            g_lstDienThoai.Remove(objCuocGoi);
                            HienThiTrenLuoi(false, false); // Refresh

                            //Cap nhat vao Mem
                            bwSync_RemoveCuocGoi.RunWorkerAsync(objCuocGoi);
                        }
                        else
                        {
                            TimVaCapNhatCuocGoi(ref g_lstDienThoai, objCuocGoi, true);
                            HienThiTrenLuoi(true, false); // Refresh
                        }

                    }
                }
                //else if (_DialogResult == DialogResult.Ignore)
                //{
                //    if (objCuocGoi.IDCuocGoi > 0)
                //    {
                //        CuocGoi.UpdateCuocKhachKetThucKhongXacDinhXeDon(objCuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID, objCuocGoi.XeNhan);
                //    }
                //}
                else
                {
                    RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Aquamarine;
                    rowSelect.RowStyle = RowStyle;
                    return;
                }
                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                //RowStyle.BackColor = Color.White;
                RowStyle.BackColor = Color.Aquamarine;
                rowSelect.RowStyle = RowStyle;
                return;
            }

        }

        private void NhapDuLieuVaoTruyenDiCuocGoiKetThuc(int iRowPosition)
        {
            // GridEXRow row = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
            CuocGoi objDieuHanhTaxi = (CuocGoi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
            //Thu doi mau
            GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
            GridEXFormatStyle RowStyle = new GridEXFormatStyle();
            RowStyle.BackColor = SystemColors.Highlight;
            rowSelect.RowStyle = RowStyle;

            //End - Thu doi mau 

            // kiểm tra thời gian
            TimeSpan timeSpan;
            timeSpan = g_TimeServer - objDieuHanhTaxi.ThoiDiemGoi;
            if (objDieuHanhTaxi.XeDon != null && objDieuHanhTaxi.XeDon.Length > 0)
            {
                timeSpan.Add(new TimeSpan(0, 0, objDieuHanhTaxi.ThoiGianDonKhach));
            }
            if (timeSpan.TotalSeconds > 8 * 60)  // lớn hơn 8 phút từ thời điểm nhập xe đón
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Quá giờ giới hạn cho phép bạn nhập thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }

            frmMoiKhachInputDataCuocKetThuc frm = new frmMoiKhachInputDataCuocKetThuc(objDieuHanhTaxi, LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH, IsThoatDuoc999(objDieuHanhTaxi, g_TimeServer), g_ListSoHieuXe);

            DialogResult _DialogResult = frm.ShowDialog(this);
            if (_DialogResult == DialogResult.OK)
            {
                LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep, g_soDong, g_MayCS);
                gridCuocGoi_KetThuc.Refresh();

            }
            else if (_DialogResult == DialogResult.Ignore)
            {
                if (objDieuHanhTaxi.IDCuocGoi > 0)
                {
                    // DieuHanhTaxi.UpdateCuocKhachKetThucKhongXacDinhXeDon(objDieuHanhTaxi.ID_DieuHanh, ThongTinDangNhap.USER_ID, objDieuHanhTaxi.XeNhan);
                }
            }
            else
            {  //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
                return;
            }
            RowStyle = new GridEXFormatStyle();
            RowStyle.BackColor = SystemColors.Window;
            rowSelect.RowStyle = RowStyle;
            return;

        }

        private bool IsThoatDuoc999(CuocGoi cuocGoi, DateTime timeServer)
        {

            TimeSpan timeSpan = timeServer - cuocGoi.ThoiDiemGoi;
            if (g_SoLuongDangNhapCS > 1)
            {
                //khi co 2 may cung dang nhap thi giam so cuoc gioi han di mot phan 2
                if ((g_lstDienThoai != null && g_lstDienThoai.Count >= ((int)g_Thoat999SoCuocGioiHan / 2)) && g_Thoat999TrangThaiTATBAT && timeSpan.TotalMinutes >= g_Thoat999SoPhutGioiHan)
                {
                    return true;    // đủ điều kiện thoát 999
                }
            }
            else
            {
                if ((g_lstDienThoai != null && g_lstDienThoai.Count >= g_Thoat999SoCuocGioiHan) && g_Thoat999TrangThaiTATBAT && timeSpan.TotalMinutes >= g_Thoat999SoPhutGioiHan)
                {
                    return true;    // đủ điều kiện thoát 999
                }
            }


            return false;       // không đủ điều kiện thoát cuốc 999
        }
        #endregion

        #region Memory
        private void bwSync_AddCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCuocGoi_Memory(e.Argument as CuocGoi);
        }

        private void bwSync_RemoveCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        {
            RemoveCuocGoi_Memory(e.Argument as CuocGoi);
        }

        /// <summary>
        /// Update thông tin cuộc gọi vào memory
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
                    cuocGoi.IDCuocGoi, "", "", ""));
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// update thông tin cuộc gọi ở memory sang kết thúc
        /// </summary>
        /// <param name="IDCuocGoi"></param>
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
                g_TimeServer = g_TimeServer.AddSeconds(1);
                bool hasThemMoi = false;
                bool hasCapNhat = false;
                LoadCuocGoiMoiThayDoiTuDTV_TDV(ref g_lstDienThoai, g_strVungsDuocCapPhep, g_ThoiDiemLayDuLieuTruoc, ref hasCapNhat, ref hasThemMoi, g_MayCS);

                if (hasCapNhat) // co thay doi du lieu moi cap nhat cuoc goi
                {
                    HienThiTrenLuoi(hasCapNhat, hasThemMoi);
                    g_ThoiDiemLayDuLieuTruoc = g_TimeServer;
                }
                g_TimeStep++;
                //g_timerMsg++;
                if (g_TimeStep >= 3)  // 3 giay thuc hien mot lan
                {
                    CapNhatCuocGoiDaKetThuc(ref g_lstDienThoai, g_strVungsDuocCapPhep, ref hasCapNhat, g_MayCS);
                    if (hasCapNhat)
                    {
                        
                        HienThiTrenLuoi(false, false);
                    }
                    g_TimeStep = 0;
                }

                if (g_boolChuyenTabCuocGoiKetThuc)
                {
                    try
                    {
                        LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep, g_soDong, g_MayCS);
                    }
                    catch (Exception ex)
                    {
                        //new MessageBox.MessageBox().Show("TimerCapturePhone_Tick " + ex.Message);
                        // //  LogError.WriteLog("Loi trong timer: LoadCacCuocGoiKetThuc().", ex);
                    }
                    g_boolChuyenTabCuocGoiKetThuc = false;
                }


                
                //-----------Get Data ManHinh : 3s cap nhat 1 lan
                //g_iTimerManHinh++;
                //if (g_iTimerManHinh >= 3)
                //{
                //    getNewManHinh_ThoiDiemChen(g_ThoiDiemNhanDuLieuTruoc_ManHinh);
                //    g_ThoiDiemNhanDuLieuTruoc_ManHinh = g_TimeServer;
                //    g_iTimerManHinh = 0;
                //}

                // Get thong tin Message
                g_iTimerMessage++;
                if (g_iTimerMessage >= 10)
                {
                    //gridCuocGois.Refresh();
                    getNewMessage();
                    g_iTimerMessage = 0;   // đặt lại lần quét tiếp theo
                    LayCauHinhThoatCuoc999();
                }

                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
               // g_bKetThucTimer = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiKhach_TimeCapturePhone", ex);
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "KhoiKhach_TimeCapturePhone", DateTime.Now, ex.Message);
              //  g_bKetThucTimer = true;
            }
        }

        private void LoadCuocGoiMoiThayDoiTuDTV_TDV(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, DateTime thoiDiemLayDuLieuTruoc, ref bool hasCapNhat, ref bool hasThemMoi, int MayCS)
        {
            hasThemMoi = false;
            hasCapNhat = false;
            // nếu chưa có ds cuộc gọi hiện tại
            if (listCuocGoiHienTai == null)
            {
                listCuocGoiHienTai = new List<CuocGoi>();
            }
            // cuộc gọi chưa có trong cuộc gọi thì chèn mới
            // nếu có rồi thì cập nhật
            List<CuocGoi> listCuocGoiMoi = CuocGoi.MK_LayCuocGoiMoiTuDTV_TDV(vungsDuocCapPhep, thoiDiemLayDuLieuTruoc, MayCS);
            if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
            {
                hasCapNhat = true;
                for (int i = 0; i < listCuocGoiMoi.Count; i++)
                {
                    int index = -1;
                    for (int j = 0; j < listCuocGoiHienTai.Count; j++)
                    {
                        if (listCuocGoiMoi[i].IDCuocGoi == listCuocGoiHienTai[j].IDCuocGoi) // da co 1 cuoc ton tai
                        {
                            index = j; break;
                        }
                    }
                    if (index == -1) // cos cuoc moi
                    {
                        //g_RowIndex = g_RowIndex - 1;
                        //listCuocGoiHienTai.Insert(0, listCuocGoiMoi[i]);
                        hasThemMoi = true;
                        if (listCuocGoiMoi[i].KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVIP)
                        {
                            listCuocGoiHienTai.Insert(0, listCuocGoiMoi[i]);
                            G_IndexKhachVIP++;
                        }
                        else if (listCuocGoiMoi[i].KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangVang)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVIP, listCuocGoiMoi[i]);
                            G_IndexKhachVang++;
                        }
                        else if (listCuocGoiMoi[i].KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangBac)
                        {
                            listCuocGoiHienTai.Insert(G_IndexKhachVang, listCuocGoiMoi[i]);
                            G_IndexKhachBac++;
                        }
                        else
                        {
                            G_IndexKHThanThiet = G_IndexKhachVIP + G_IndexKhachVang + G_IndexKhachBac;
                            listCuocGoiHienTai.Insert(G_IndexKHThanThiet, listCuocGoiMoi[i]);
                            // Neu la cuoc goi lai, tim cuoc goi taxi cua cuoc goi do va day len tren gan cuoc goi taxi
                            if (listCuocGoiMoi[i].KieuCuocGoi == KieuCuocGoi.GoiLai)
                            {
                                // tìm đến cuộc gọi taxi của số này, chèn cuộc đó lên đầu.
                                int viTri = -1;
                                for (int k = 0; k < listCuocGoiHienTai.Count; k++)
                                {
                                    if (listCuocGoiHienTai[k].PhoneNumber == listCuocGoiMoi[i].PhoneNumber && listCuocGoiHienTai[k].KieuCuocGoi == KieuCuocGoi.GoiTaxi)
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
                    }
                    else // cap nhat thong tin cua dien thoai gui sang cho
                    {
                        listCuocGoiHienTai[index].DiaChiDonKhach = listCuocGoiMoi[i].DiaChiDonKhach;
                        listCuocGoiHienTai[index].SoLanGoi = listCuocGoiMoi[i].SoLanGoi;
                        listCuocGoiHienTai[index].Vung = listCuocGoiMoi[i].Vung;
                        listCuocGoiHienTai[index].LoaiXe = listCuocGoiMoi[i].LoaiXe;
                        listCuocGoiHienTai[index].SoLuong = listCuocGoiMoi[i].SoLuong;
                        listCuocGoiHienTai[index].KieuKhachHangGoiDen = listCuocGoiMoi[i].KieuKhachHangGoiDen;
                        listCuocGoiHienTai[index].IsCuocGiaLap = listCuocGoiMoi[i].IsCuocGiaLap;
                        listCuocGoiHienTai[index].KieuCuocGoi = listCuocGoiMoi[i].KieuCuocGoi;
                        listCuocGoiHienTai[index].LenhDienThoai = listCuocGoiMoi[i].LenhDienThoai;
                        listCuocGoiHienTai[index].GhiChuDienThoai = listCuocGoiMoi[i].GhiChuDienThoai;
                        listCuocGoiHienTai[index].LenhTongDai = listCuocGoiMoi[i].LenhTongDai;
                        listCuocGoiHienTai[index].GhiChuTongDai = listCuocGoiMoi[i].GhiChuTongDai;

                        listCuocGoiHienTai[index].MaNhanVienTongDai = listCuocGoiMoi[i].MaNhanVienTongDai;
                        listCuocGoiHienTai[index].MaNhanVienDienThoai = listCuocGoiMoi[i].MaNhanVienDienThoai;
                        listCuocGoiHienTai[index].ThoiDiemChuyenTongDai = listCuocGoiMoi[i].ThoiDiemChuyenTongDai;

                        listCuocGoiHienTai[index].DanhSachXeDeCu = listCuocGoiMoi[i].DanhSachXeDeCu;
                        listCuocGoiHienTai[index].DanhSachXeDeCu_TD = listCuocGoiMoi[i].DanhSachXeDeCu_TD;
                        listCuocGoiHienTai[index].ThoiDiemCapNhatXeDeCu = listCuocGoiMoi[i].ThoiDiemCapNhatXeDeCu;
                        listCuocGoiHienTai[index].XeNhan = listCuocGoiMoi[i].XeNhan;
                        listCuocGoiHienTai[index].GPS_KinhDo = listCuocGoiMoi[i].GPS_KinhDo;
                        listCuocGoiHienTai[index].GPS_ViDo = listCuocGoiMoi[i].GPS_ViDo;
                        listCuocGoiHienTai[index].XeNhan = listCuocGoiMoi[i].XeNhan;
                        listCuocGoiHienTai[index].XeNhan_TD = listCuocGoiMoi[i].XeNhan_TD;

                        listCuocGoiHienTai[index].MOIKHACH_NhanVien = listCuocGoiMoi[i].MOIKHACH_NhanVien;
                        listCuocGoiHienTai[index].MOIKHACH_LenhMoiKhach = listCuocGoiMoi[i].MOIKHACH_LenhMoiKhach;
                        listCuocGoiHienTai[index].XeDenDiem = listCuocGoiMoi[i].XeDenDiem;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach = listCuocGoiMoi[i].XeDenDiemDonKhach;
                        listCuocGoiHienTai[index].XeDenDiemDonKhach_TD = listCuocGoiMoi[i].XeDenDiemDonKhach_TD;
                        listCuocGoiHienTai[index].TrangThaiCuocGoi = listCuocGoiMoi[i].TrangThaiCuocGoi;
                        ////TinNhan
                        //listCuocGoiHienTai[index].TinNhanDHV = listCuocGoiMoi[i].TinNhanDHV;
                        //listCuocGoiHienTai[index].TinNhanDHV_DaDoc = listCuocGoiMoi[i].TinNhanDHV_DaDoc;

                        //hasThemMoi = false;
                    }
                }
            }
        }

        private void CapNhatCuocGoiDaKetThuc(ref List<CuocGoi> listCuocGoiHienTai, string vungsDuocCapPhep, ref bool hasCapNhat, int MayCS)
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
                List<long> listIDDaKetThuc = CuocGoi.MK_LayCacIDCuocGoiKetThucByDTV_TDV(listIDCuocGoi, vungsDuocCapPhep, MayCS);
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            LoadAllCuocGoiHienTai_v3();
            if (m_fmProgress == null) return;
            m_fmProgress.lblDescription.Invoke(
           (MethodInvoker)delegate()
           {
               m_fmProgress.lblDescription.Text = "Loading ... cuộc gọi chờ giải quyết";
               m_fmProgress.progressBar1.Value = 50;
           }
           );

            //LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep );
            //m_fmProgress.lblDescription.Invoke(
            //    (MethodInvoker)delegate()
            //    {
            //        m_fmProgress.lblDescription.Text = "Loading ... cuộc đã giải quyết" ;
            //        m_fmProgress.progressBar1.Value = 80;
            //    }
            //);

            if (m_fmProgress.Cancel)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was canceled.
                e.Cancel = true;
                return;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. First we should hide the
            // modal Progress Form to unlock the UI. The we need to inspect our
            // response to see if an error occured, a cancel was requested or
            // if we completed succesfully.

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // MessageBox.Show("Processing cancelled.");
                return;
            }
        }

        /// <summary>
        /// Load nhung cuoc dien thoai cho tong dai
        ///   -  Cuoc dien thoai do dien thoai gui sang va  cua chinh minh dang xu ly (TrangThaiLenhTaxi=1 & 2)
        ///   -  Cuoc dien thoai nam trong vung cua minh
        /// </summary>

        private void LoadAllCuocGoiHienTai(string sVung, int MayMoiKhachSo)
        {
            try
            {
                CuocGoi objDHTaxi = new CuocGoi();



                string SQLCondition = "";// AND (   (TrangThaiLenh=5) OR (TrangThaiLenh=6 ) OR (TrangThaiLenh=7 ) OR (GoiKhieuNai=1) ) "; // Cuộc gọi điện thoại gửi sang, cuộc gọi tổng đai 

                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";

                if (MayMoiKhachSo == 1)
                    SQLCondition += " AND ((CAMON_DanhGia IS NULL) OR (CAMON_DanhGia =1)) ";
                else SQLCondition += " AND (CAMON_DanhGia = 2)  ";

                SQLCondition += " ORDER BY ThoiDiemGoi DESC";
                g_lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
                gridCuocGois.DataMember = "ListDienThoai";
                gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("LoadAllCuocGoiHienTai", ex);
                //new MessageBox.MessageBox().Show("LoadAllCuocGoiHienTai " + ex.Message);
            }
        }

        private void LoadAllCuocGoiHienTai_v3()
        {
            g_lstDienThoai = new List<CuocGoi>();
            g_lstDienThoai = CuocGoi.MK_LayAllCuocGoi(g_strVungsDuocCapPhep, g_MayCS);
            gridCuocGois.DataMember = "ListDienThoai";
            gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
            SapXepCuocGoiThanThiet();
            gridCuocGois.Refresh();
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
        /// Nhung cuoc goi moi ve la nhung cuoc goi co TrangThaiLenh = ienThoai =1 dien thoai chuyen sang
        ///     - Load trong DB xem co cuoc  goi nao moi ve khong
        ///     - Them vao dau tien cua luoi
        /// </summary>
        private void NhanCacCuocGoiMoiVe()
        {
            try
            {

                List<CuocGoi> lstTongDaiCuocGoiMoi = new List<CuocGoi>();
                lstTongDaiCuocGoiMoi = GetAllCuocGoiDienThoaiMoiGoiSang(g_lstCuocGoiDangTheoDoi);
                if (lstTongDaiCuocGoiMoi == null) return;
                if (lstTongDaiCuocGoiMoi.Count > 0) // Co cuoc goi moi
                {
                    if (GhepThemCuocGoiMoiNhanVaoDau(lstTongDaiCuocGoiMoi))
                    {
                        gridCuocGois.DataSource = null;
                        gridCuocGois.DataMember = "ListDienThoai";
                        gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                        timerBaoCoDuLieuDienThoaiGui.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("NhanCuocGoiMoiVe " + ex.Message);
                ////  LogError.WriteLog("Co loi nhan cuoc goi moi ve", ex);
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Cap nhat thong tin cuôc gọi bị thay đổi
        /// Từ bên điện thoại gửi sang
        /// </summary>
        private bool CapNhatThongTinCuocGoiBiThayDoi()
        {
            bool boolOK = false;
            try
            {

                List<CuocGoi> lstCuocGoiDienThoaiGuiSang = new List<CuocGoi>();
                lstCuocGoiDienThoaiGuiSang = GetAllCuocGoiDienThoaiMoiGoiSang(g_lstCuocGoiDangTheoDoi);
                if (lstCuocGoiDienThoaiGuiSang == null) return false;
                if (lstCuocGoiDienThoaiGuiSang.Count > 0) //Co cuoc goi TongDai gui sang
                {
                    foreach (CuocGoi objCuocGoiDienThoai in lstCuocGoiDienThoaiGuiSang)
                    {
                        if (g_lstDienThoai.Count > 0)
                        {
                            for (int i = 0; i < g_lstDienThoai.Count; i++)
                            {
                                if (objCuocGoiDienThoai.IDCuocGoi == ((CuocGoi)g_lstDienThoai[i]).IDCuocGoi)
                                {
                                    g_lstDienThoai[i] = (CuocGoi)objCuocGoiDienThoai;
                                    boolOK = true;// co cuoc goi thay doi
                                    break;
                                }
                            }
                        }
                    }
                }
                return boolOK;//
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
                //new MessageBox.MessageBox().Show("CapNhatThongTinCuocGoiBiThayDoi " + ex.Message);
                return false;
            }
            return false;


        }

        /// <summary>
        /// Lay tat cac cac cuoc goi hien dang co trong TatcaCuocGoiHienHanh
        /// Kiem tra cuoc goi phia TongDai con ton tai trong TatcaCuocGoiHienHanh
        ///     - Neu khong co thi Remove
        ///     - Neu cô thi de lai
        /// </summary>
        private void XoaCacCuocGoi_DienThoaiKetThuc()
        {
            // Lay danh sach cuoc goi hien hanh (phia server)
            try
            {
                List<CuocGoi> lstDienThoaiServer = new List<CuocGoi>(); // cuoc dien thoai hien co o server
                List<CuocGoi> lstTongDaiNoExist = new List<CuocGoi>(); // cuoc dien thoai hien tai dang co 



                lstDienThoaiServer = g_lstCuocGoiDangTheoDoi; //string SQLCondition = " ORDER BY ThoiDiemGoi DESC"; // Cai tien them - theo vung

                bool boolCocuocGoiKetThuc_DienThoai = false;
                if (lstDienThoaiServer == null)
                {
                    g_lstDienThoai.Clear();
                    gridCuocGois.DataSource = null;
                    gridCuocGois.DataMember = "ListDienThoai";
                    gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");

                    return;

                }
                if (lstDienThoaiServer.Count > 0) // server con cuoc goi
                {
                    if (g_lstDienThoai == null)
                    {
                        g_lstDienThoai.Clear();
                        gridCuocGois.DataSource = null;
                        gridCuocGois.DataMember = "g_lstCuocGoiDangTheoDoi";
                        gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                        return;
                    }
                    foreach (CuocGoi objDHTX_TongDai in g_lstDienThoai)
                    {
                        bool boolHas = false;
                        foreach (CuocGoi objDHTX_Server in lstDienThoaiServer)
                        {
                            if (objDHTX_TongDai.IDCuocGoi == objDHTX_Server.IDCuocGoi)
                            {
                                boolHas = true;
                                break;
                            }
                        }
                        if (!boolHas)
                        {
                            boolCocuocGoiKetThuc_DienThoai = true;
                            lstTongDaiNoExist.Add(objDHTX_TongDai);
                        }
                    }
                    if (lstTongDaiNoExist == null) return;
                    foreach (CuocGoi objDHTX_Delete in lstTongDaiNoExist)
                    {
                        SapXepLaiIndex(objDHTX_Delete);
                        g_lstDienThoai.Remove(objDHTX_Delete);
                    }
                }
                else // khong con cuoc goi nao
                {
                    if (g_lstDienThoai.Count > 0) // phia dien thoai van con cuoc goi
                    {
                        g_lstDienThoai.Clear();
                        boolCocuocGoiKetThuc_DienThoai = true;
                    }
                }
                if (boolCocuocGoiKetThuc_DienThoai)
                {
                    gridCuocGois.DataSource = null;
                    gridCuocGois.DataMember = "ListDienThoai";
                    gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("XoaCacCuocGoi_DienThoaiKetThuc " + ex.Message);
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Ghep them cac cuoc goi moi, sau do sap xep theo thoi gian
        /// </summary>
        /// <param name="ListOfNewCalls"></param>
        private bool GhepThemCuocGoiMoiNhanVaoDau(List<CuocGoi> ListOfNewCalls)
        {
            bool boolOK = false;

            if (ListOfNewCalls == null) return false;
            foreach (CuocGoi objDHTX in ListOfNewCalls)
            {
                if (!KiemTraXemCuocGoiDaDuocThemVaoChua(objDHTX))
                {
                    if (g_lstDienThoai == null) g_lstDienThoai = new List<CuocGoi>();
                    g_lstDienThoai.Add(objDHTX);
                    boolOK = true;// co su thay doi trong danh sach
                }
            }
            g_lstDienThoai.Sort(delegate(CuocGoi call1, CuocGoi call2) { return call2.ThoiDiemGoi.CompareTo(call1.ThoiDiemGoi); });

            //if (g_lstDienThoai.Count > 1)
            //    SortDienThoai();
            return boolOK;

        }
        /// <summary>
        /// sap xep ds g_lstDienThoai theo thu tu thoi gian tu lon toi be, neu bang thi uu tien thu tu line
        /// </summary>
        /// <param name="call1"></param>
        /// <param name="call2"></param>
        private void SortDienThoai()
        {
            CuocGoi[] arrDH = g_lstDienThoai.ToArray();
            CuocGoi temp;
            for (int i = 0; i < arrDH.Length; i++)
            {
                for (int j = i + 1; j < arrDH.Length - 1; j++)
                {
                    if (arrDH[j].ThoiDiemGoi.CompareTo(arrDH[i].ThoiDiemGoi) > 0)
                    {
                        temp = arrDH[i];
                        arrDH[i] = arrDH[j];
                        arrDH[j] = temp;
                    }
                }
            }
            // sắp xếp những cuốc có xe nhận xuống dưới
            List<CuocGoi> listCuocGoiKhongCoXeNhan = new List<CuocGoi>();
            List<CuocGoi> listCuocGoiCoXeNhan = new List<CuocGoi>();
            for (int i = 0; i < arrDH.Length; i++)
            {
                if (arrDH[i].XeNhan.Length <= 0)
                {
                    listCuocGoiKhongCoXeNhan.Add(arrDH[i]);
                }
                else
                    listCuocGoiCoXeNhan.Add(arrDH[i]);
            }

            // -- END ----
            g_lstDienThoai.Clear();
            foreach (CuocGoi objDH in listCuocGoiKhongCoXeNhan)
            {
                g_lstDienThoai.Add(objDH);
            }
            foreach (CuocGoi objDH in listCuocGoiCoXeNhan)
            {
                g_lstDienThoai.Add(objDH);
            }

            listCuocGoiCoXeNhan.Clear();
            listCuocGoiCoXeNhan = null;

            listCuocGoiKhongCoXeNhan.Clear();
            listCuocGoiKhongCoXeNhan = null;
            arrDH = null;

        }

        private bool KiemTraXemCuocGoiDaDuocThemVaoChua(CuocGoi DHTaxi)
        {
            bool boolOK = false;
            if (g_lstDienThoai == null) return false;
            foreach (CuocGoi objDHTX in g_lstDienThoai)
            {
                if (objDHTX.IDCuocGoi == DHTaxi.IDCuocGoi)
                {
                    boolOK = true;
                    break;
                }
            }
            return boolOK;
        }

        #region XuLyCacCuocGoi ket thuc

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string vungsDuocCapPhep, int soDong, int MayCS)
        {
            try
            {
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(CuocGoi.MK_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong,MayCS), "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("LoadCacCuocGoiKetThuc " + ex.Message);
            }
        }

        //private void LoadCacCuocGoiKetThuc(string sVung)
        //{
        //    try
        //    {
        //        CuocGoi objDHTaxi = new CuocGoi();
        //        g_lstCuocGoiKetThuc = new List<CuocGoi>();

        //        DateTime TimeServer = CuocGoi.GetTimeServer();
        //        string strTuDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer.Subtract(new TimeSpan(24,00,0) ));
        //        string strDenDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer);

        //        string NRecords = " TOP  50  ";
        //        //string SQLCondition = "  ((ThoiDiemGoi >= '" + strTuDate + "') AND (ThoiDiemGoi<='"+strDenDate+ "' ))   AND (TrangThaiLenh=3) ";
        //         string SQLCondition = "   AND (TrangThaiLenh=3) ";
        //        SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ") ";
        //        SQLCondition += " ORDER BY ThoiDiemGoi DESC";

        //        g_lstCuocGoiKetThuc = SapXepCuocGoiKetThuc( objDHTaxi.Get_CuocGoi_KetThuc(NRecords,SQLCondition));


        //        gridCuocGoi_KetThuc.DataMember = "g_lstCuocGoiKetThuc";
        //        gridCuocGoi_KetThuc.SetDataBinding(g_lstCuocGoiKetThuc, "g_lstCuocGoiKetThuc");
        //    }
        //    catch (Exception ex)
        //    {
        //        //TimerCapturePhone.Stop();
        //        //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
        //    }

        //}
        /// <summary>
        /// Sap xep cuoc goi ket thuc theo tieu chi
        /// danh sach dua vao da duoc sap xep theo thoi gian
        /// - Nhung cuoc goi chua nhap dia len truoc - Theo thu thu thoi gian 
        /// - Nhung cuoc goi da nhap dien chi  sau  - Theo thu thu thoi gian 
        /// </summary>
        /// <param name="listCuocGoiKT"></param>
        /// <returns></returns>
        private List<CuocGoi> SapXepCuocGoiKetThuc(List<CuocGoi> listCuocGoiKT)
        {
            // Danh sach cac cuoc chua co dia chi
            List<CuocGoi> listCuocGoiChuaCoDCDonKhach = new List<CuocGoi>();
            //danh sach cac cuoc co co dia chi
            List<CuocGoi> listCuocGoiDaCoDCDonKhach = new List<CuocGoi>();
            // danh sach cuoc goi trượt, hoãn, không xe, goi lai
            List<CuocGoi> listCuocGoiTruotHoanKhongXeGoiLai = new List<CuocGoi>();
            // Danh sach cuoi cung ghep tu hai danh sach tren
            List<CuocGoi> listCuocGoiGhep = new List<CuocGoi>();
            if (listCuocGoiKT == null) return null;
            foreach (CuocGoi objDHTX in listCuocGoiKT)
            {
                if (CheckHoanKhongXeTruotGoiLai(objDHTX))
                    listCuocGoiTruotHoanKhongXeGoiLai.Add(objDHTX);
                else if (StringTools.TrimSpace(objDHTX.DiaChiTraKhach).Length > 0)
                    listCuocGoiDaCoDCDonKhach.Add(objDHTX);
                else
                    listCuocGoiChuaCoDCDonKhach.Add(objDHTX);
            }
            // Ghep hai 
            if (listCuocGoiChuaCoDCDonKhach != null)
            {
                foreach (CuocGoi objDHTX in listCuocGoiChuaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiDaCoDCDonKhach != null)
            {
                foreach (CuocGoi objDHTX in listCuocGoiDaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiTruotHoanKhongXeGoiLai != null)
            {
                foreach (CuocGoi objDHTX in listCuocGoiTruotHoanKhongXeGoiLai)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            return listCuocGoiGhep;
        }
        /// <summary>
        /// kiem tra xem mot cuoc goi la gi 
        /// true : if la không xe, trượt, gọi lại, hoãn
        /// </summary>
        /// <param name="objDHTX"></param>
        /// <returns></returns>
        private bool CheckHoanKhongXeTruotGoiLai(CuocGoi objDHTX)
        {
            if (objDHTX.LenhTongDai.Contains("không xe")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("trượt")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("gọi lại")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("hoãn")) return true;

            return false;

        }

        #endregion XuLyCacCuocGoi ket thuc

        
        /// <summary>
        /// Hamf 
        /// </summary>
        /// <param name="objCuocGoi"></param>
        /// <returns></returns>
        private LENHCUATONGDAI_MOIKHACH GetLenhTongDai(CuocGoi objCuocGoi)
        {
            if (objCuocGoi.LenhTongDai != null)
            {
                if (objCuocGoi.LenhTongDai.Contains("mời khách"))
                {
                    return LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH;
                }
                else if (objCuocGoi.LenhTongDai.Contains("giữ khách"))
                {
                    return LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH;
                }
                else if (objCuocGoi.LenhTongDai.Contains("không xe xin lỗi khách"))
                {
                    return LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI;
                }
                else if (objCuocGoi.GoiKhieuNai)
                {
                    return LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI;
                }
            }
            return LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH;
        }

        /// <summary>
        /// tra ve ds xe nhan dang co
        /// </summary>
        /// <returns></returns>
        private string GetDSXeNhanDangHoatDong()
        {
            string strDSXeNhan = "";
            try
            {
                int iRow = gridCuocGois.RowCount;
                if (iRow > 0)
                {
                    for (int i = 0; i < iRow; i++)
                    {
                        strDSXeNhan += gridCuocGois.GetRow(i).Cells["XeNhan"].Text;
                    }
                }
                return strDSXeNhan;
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("GetDSXeNhanDangHoatDong " + ex.Message);
                return "";
            }
        }


        /// <summary>
        /// Tim tỏng sach va cap nhat du lieu vao 
        /// </summary>
        /// <param name="objCuocGoi"></param>
        private void TimVaCapNhatVaoDanhSach(CuocGoi objCuocGoi)
        {
            if (g_lstDienThoai == null) return;
            foreach (CuocGoi objDHTX in g_lstDienThoai)
            {
                if (objCuocGoi.IDCuocGoi == objDHTX.IDCuocGoi)
                {
                    objDHTX.XeNhan = objCuocGoi.XeNhan;
                    objDHTX.XeDon = objCuocGoi.XeDon;
                    objDHTX.LenhTongDai = objCuocGoi.LenhTongDai;
                    objDHTX.GhiChuTongDai = objCuocGoi.GhiChuTongDai;
                    objDHTX.TrangThaiLenh = objCuocGoi.TrangThaiLenh;
                    objDHTX.ThoiGianDieuXe = objCuocGoi.ThoiGianDieuXe;
                    objDHTX.ThoiGianDonKhach = objCuocGoi.ThoiGianDonKhach;
                    objDHTX.MOIKHACH_KhieuNai_DaXyLy = objCuocGoi.MOIKHACH_KhieuNai_DaXyLy;
                    objDHTX.MOIKHACH_KhieuNai_ThongTinThem = objCuocGoi.MOIKHACH_KhieuNai_ThongTinThem;
                    objDHTX.MOIKHACH_LenhMoiKhach = objCuocGoi.MOIKHACH_LenhMoiKhach;

                    break;
                }
            }
        }

        private void TimVaCapNhatCuocGoi(ref List<CuocGoi> listCuocGoiHienTai, CuocGoi cuocGoi, bool IsCapNhatCuaDienThoai)
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
                        listCuocGoiHienTai[index].DiaChiDonKhach = cuocGoi.DiaChiDonKhach;
                    }
                }
            }
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

                g_boolNhayMauKhiCoCuocGoiMoi = true;
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = 1;

            }
            if (uiTabCuocGoiDangThucHien.SelectedIndex == 0)
            {
                timerBaoCoDuLieuDienThoaiGui.Enabled = false;
                uiTabCuocGoiChoGiaiQuyet.ImageIndex = -1;
            } uiTabCuocGoiChoGiaiQuyet.Refresh();
        }

        /// <summary>
        /// Lấy nội dung tin nhắn gần nhất có trạng thái = 1 (là luôn luôn hiển thị)
        /// </summary>
        private void getNewMessage()
        {
            try
            {
                DataTable dtMsg = new Chatting().GetNewMessage(ThongTinDangNhap.USER_ID);
                if (dtMsg == null)
                {
                    //pnlMessage.Visible = false;
                    //txtNDTinNhan.Text = "";
                    return;
                }
                if (dtMsg.Rows.Count <= 0)
                {
                    //pnlMessage.Visible = false;
                    //txtNDTinNhan.Text = "";
                    return;
                }

                //pnlMessage.Visible = true;
                //txtNDTinNhan.Text = dtMsg.Rows[0]["Contents"].ToString();
                dtMsg.Dispose();
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("getNewMessage " + ex.Message);
                return;
            }
        }
        #endregion

        #region ========================COM PORT===============================
        /// <summary>
        /// khoitao mo cong COM
        /// thu vo cac cong COM3, COM4, COM5
        /// </summary>
        private bool KhoiTaoCOMPort()
        {

            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;

            int iLanMo = 0; bool IsOpenCOM = false;
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
                if ((serialPort1 != null) && (serialPort1.IsOpen))
                {
                    string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11)); //"ATDT" + SoDienThoai + Convert.ToChar(13) + Convert.ToChar(11);
                    serialPort1.Write(Call);
                    return true;

                    System.Threading.Thread.Sleep(1000);
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("QuaySoGoiDen " + ex.Message);
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
                    string Call = "ATH0" + Convert.ToChar(13) + Convert.ToChar(11);
                    serialPort1.Write(Call);
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("KetThucCuocGoi " + ex.Message);
            }
        }

        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="DiaChi"></param>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi, bool isPBXIP, string line)
        {
            if (frmCalling == null) frmCalling = new frmCallOut();
            frmCalling.Show();
            if (g_COMPort.Length > 0)
            {
                frmCalling.Show();
                frmCalling.Invoke(
                                (MethodInvoker)delegate()
                                {
                                    frmCalling.lblSoGoi.Text = string.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                                }
                );
                frmCalling.Refresh();
                //frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);

                if (isPBXIP)
                {
                    frmCalling.Call(manager, line, PhoneNumber);
                }
            }
            else if (isPBXIP)
            {
                frmCalling.Invoke(
                                   (MethodInvoker)delegate()
                                   {
                                       frmCalling.lblSoGoi.Text = string.Format("Đang gọi {2} : {0} - {1}", PhoneNumber, DiaChi, line);
                                   }
                   );
                frmCalling.Refresh();
                frmCalling.Call(manager, line, PhoneNumber);
            }
        }
        #endregion COM PORT

        #region ========================Màn Hình===============================
        /// <summary>
        /// Lấy nội dung thông báo cho Grid ManHinh
        /// </summary>
        private void getNewManHinh()
        {
            try
            {
                //g_ListTinNhanManHinh = new ManHinhBL().GetNewManHinh(g_strVungsDuocCapPhep, "MK");
                //if (g_ListTinNhanManHinh != null && g_ListTinNhanManHinh.Count > 0)
                //{
                //    gridManHinh.DataSource = null;
                //    gridManHinh.DataMember = "dtTinNhanManHinh";
                //    gridManHinh.SetDataBinding(g_ListTinNhanManHinh, "dtTinNhanManHinh");
                //}
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("getNewManHinh " + ex.Message);
                return;
            }
        }

        /// <summary>
        /// Lấy nội dung thông báo cho Grid ManHinh _ loc chi lay nhung tin nhan moi
        /// </summary>
        private void getNewManHinh_ThoiDiemChen(DateTime thoiDiemChen)
        {
            try
            {
                List<ManHinhEntity> listTinNhanManHinh = new ManHinhBL().GetNewManHinh_ThoiDiemChen(g_strVungsDuocCapPhep, "MK", thoiDiemChen);
                if (g_ListTinNhanManHinh != null && g_ListTinNhanManHinh.Count > 0)
                {
                    foreach (ManHinhEntity TinNhanManHinh in listTinNhanManHinh)
                    {
                        g_ListTinNhanManHinh.Insert(0, TinNhanManHinh);
                    }

                    gridManHinh.DataSource = null;
                    gridManHinh.DataMember = "dtTinNhanManHinh";
                    gridManHinh.SetDataBinding(g_ListTinNhanManHinh, "dtTinNhanManHinh");
                }
            }
            catch (Exception ex)
            {
                //new MessageBox.MessageBox().Show("getNewManHinh_ThoiDiemChen " + ex.Message);
                return;
            }
        }

        /// <summary>
        /// Nhan thong tin Man Hinh Tin Nhan - Update len cuoc goi
        /// </summary>
        /// <param name="positionRow"></param>
        private void updateCuocGoiByManHinh(int positionRow)
        {
            ManHinhEntity ManHinhTinNhan = (ManHinhEntity)gridManHinh.GetRow(positionRow).DataRow;
            string xeNhan = ManHinhTinNhan.XeNhan;
            string xeBao = ManHinhTinNhan.SoHieuXe;
            string xeDon = "";
            if (xeNhan.Contains(xeBao))
            {
                xeNhan = StringTools.TrimSpace(String.Format("{0}.{1}", xeNhan, xeBao));
            }
            if (ManHinhTinNhan.LoaiTinNhan == LoaiTinNhanMH.Huy)
            {
                if (xeNhan.Contains(xeBao))
                {
                    xeNhan = StringTools.TrimSpace(xeNhan.Replace(xeBao,""));
                } 
            }
            xeNhan = StringTools.ConvertToChuoiXeNhanChuan(xeNhan);
            
            if (ManHinhTinNhan.LoaiTinNhan == LoaiTinNhanMH.KhachDaLenXe)
            {
                xeDon = ManHinhTinNhan.XeDon;
                if (ManHinhTinNhan.SoLuong > 1)
                {
                    xeDon = StringTools.TrimSpace(String.Format("{0}.{1}", xeDon, xeBao));
                }
            }

            if (new ManHinhBL().UpdateCuocGoi_ByManHinh(ManHinhTinNhan.ID, ManHinhTinNhan.FK_CuocGoiID, ManHinhTinNhan.SoHieuXe,
                                                        ManHinhTinNhan.TinNhan, ManHinhTinNhan.GuiChoAi, ManHinhTinNhan.LoaiTinNhan.ToString(),xeNhan,xeDon))
            {
                new MessageBox.MessageBoxBA().Show("Cập nhật thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Cập nhật lỗi.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }

        /// <summary>
        /// Huy thong tin Man Hinh tin nhan
        /// </summary>
        /// <param name="positionRow"></param>
        private void deleteManHinhTinNhan(int positionRow)
        {
            ManHinhEntity ManHinhTinNhan = (ManHinhEntity)gridManHinh.GetRow(positionRow).DataRow;
            if (new ManHinhBL().DeleteManHinh(ManHinhTinNhan.ID))
            {
                new MessageBox.MessageBoxBA().Show("Hủy thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Quá trình hủy bị lỗi.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gridManHinh.RowCount > 0 && gridManHinh.SelectedItems != null && gridManHinh.SelectedItems.Count > 0)
            {
                updateCuocGoiByManHinh(((GridEXSelectedItem)gridManHinh.SelectedItems[0]).Position);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridManHinh.RowCount > 0 && gridManHinh.SelectedItems != null && gridManHinh.SelectedItems.Count > 0)
            {
                deleteManHinhTinNhan(((GridEXSelectedItem)gridManHinh.SelectedItems[0]).Position);
            }
        }

        private void gridManHinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridManHinh.RowCount > 0 && gridManHinh.SelectedItems != null && gridManHinh.SelectedItems.Count > 0)
            {
                //type = 1 : update
                //type = 1 : delete
                int type = 0;
                int posRow = -1;
                switch (e.KeyData)
                {
                    #region Huy thong tin man hinh tin nhan
                    case (Keys.Alt | Keys.H):
                        type = 2;
                        posRow = ((GridEXSelectedItem)gridManHinh.SelectedItems[0]).Position;
                        break;
                    case (Keys.Shift | Keys.D1):
                        type = 2;
                        posRow = 0;
                        break;
                    case (Keys.Shift | Keys.D2):
                        type = 2;
                        posRow = 1;
                        break;
                    case (Keys.Shift | Keys.D3):
                        type = 2;
                        posRow = 2;
                        break;
                    case (Keys.Shift | Keys.D4):
                        type = 2;
                        posRow = 3;
                        break;
                    case (Keys.Shift | Keys.D5):
                        type = 2;
                        posRow = 4;
                        break;
                    case (Keys.Shift | Keys.D6):
                        type = 2;
                        posRow = 5;
                        break;
                    case (Keys.Shift | Keys.D7):
                        type = 2;
                        posRow = 6;
                        break;
                    case (Keys.Shift | Keys.D8):
                        type = 2;
                        posRow = 7;
                        break;
                    case (Keys.Shift | Keys.D9):
                        type = 2;
                        posRow = 8;
                        break;
                    case (Keys.Shift | Keys.D0):
                        type = 2;
                        posRow = 9;
                        break;
                    #endregion

                    #region Nhan thong tin Man Hinh tin nhan
                    case (Keys.Alt | Keys.N):
                        type = 1;
                        posRow = ((GridEXSelectedItem)gridManHinh.SelectedItems[0]).Position;
                        break;
                    case (Keys.Control | Keys.D1):
                        type = 1;
                        posRow = 0;
                        break;
                    case (Keys.Control | Keys.D2):
                        type = 1;
                        posRow = 1;
                        break;
                    case (Keys.Control | Keys.D3):
                        type = 1;
                        posRow = 2;
                        break;
                    case (Keys.Control | Keys.D4):
                        type = 1;
                        posRow = 3;
                        break;
                    case (Keys.Control | Keys.D5):
                        type = 1;
                        posRow = 4;
                        break;
                    case (Keys.Control | Keys.D6):
                        type = 1;
                        posRow = 5;
                        break;
                    case (Keys.Control | Keys.D7):
                        type = 1;
                        posRow = 6;
                        break;
                    case (Keys.Control | Keys.D8):
                        type = 1;
                        posRow = 7;
                        break;
                    case (Keys.Control | Keys.D9):
                        type = 1;
                        posRow = 8;
                        break;
                    case (Keys.Control | Keys.D0):
                        type = 1;
                        posRow = 9;
                        break;
                    #endregion
                }

                if (type > 0 && posRow >= 0 && gridManHinh.RowCount > posRow)
                {
                    gridManHinh.Row = posRow;
                    if (type == 1)
                        updateCuocGoiByManHinh(posRow);
                    else if (type == 2)
                        deleteManHinhTinNhan(posRow);
                }
            }
        }
        #endregion        

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (panelTopHelp.Visible == true)
                panelTopHelp.Visible = false;
            else
                panelTopHelp.Visible = true;
        }

        private void mnuRightClick_GridCuocGoi_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            //if (e.Command.Key == "cmdCall")
            //{

            //    CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
            //    g_bTimeKetThucCuocGoi = true;
            //    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi() + objCuocGoi.PhoneNumber, objCuocGoi.DiaChiDonKhach);
            //    CuocGoi.Update_ThoiDiemMoiKhach(objCuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID);

            //}
            //else if (e.Command.Key == "cmdChuyenCS")
            //{
            //    string strSQL = "";
            //    CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
            //    // lấy thông tin CS hiện tại
            //    int ChuyenMayCS = 0;
            //    if (objCuocGoi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTot)
            //        ChuyenMayCS = 2;// chuyển máy 2
            //    else
            //        ChuyenMayCS = 1;

            //    DateTime dt = g_TimeServer;
            //    strSQL += "  UPDATE T_TAXIOPERATION SET TrangThaiLenh = '6',ThoiDiemThayDoiDuLieu=" + g_TimeServer + ",  MOIKHACH_KhieuNai_ThongTinThem ='chuyen dieu' ,  CAMON_DanhGia = " + ChuyenMayCS.ToString() + " WHERE ID = " + objCuocGoi.IDCuocGoi.ToString();
            //    if (strSQL.Length > 0)
            //    {
            //        CuocGoi.UpdateCSPhanBoCuocGoi(strSQL);
            //        g_lstDienThoai.Remove(objCuocGoi);
            //        //gridCuocGois.Refresh();
            //        //gridCuocGois.Refetch();
            //    }
            //}
        }

        private void uiContextMenu2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
             {
                if (gridCuocGois.SelectedItems.Count > 0)
                {
                    if (e.Command.Key == "cmdCall")
                    {

                        CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                        g_bTimeKetThucCuocGoi = true;

                        objCuocGoi.MOIKHACH_LenhMoiKhach = LENH_DANGGOI;
                        HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + objCuocGoi.PhoneNumber, objCuocGoi.DiaChiDonKhach, true,g_lineIPPBX);
                        CuocGoi.Update_ThoiDiemMoiKhach(objCuocGoi.IDCuocGoi, ThongTinDangNhap.USER_ID);
                    }
                    else if (e.Command.Key == "cmdChuyenCS")
                    {
                        string strSQL = "";
                        CuocGoi objCuocGoi = (CuocGoi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                        if (objCuocGoi == null) return;
                        // lấy thông tin CS hiện tại
                        int ChuyenMayCS = 0;
                        if (g_MayCS == 1)
                            ChuyenMayCS = 2;// chuyển máy 2
                        else
                            ChuyenMayCS = 1;
                        DateTime dt = g_TimeServer;
                        strSQL += "  UPDATE T_TAXIOPERATION SET TrangThaiLenh = '6',ThoiDiemThayDoiDuLieu='" + g_TimeServer + "',  MOIKHACH_KhieuNai_ThongTinThem ='chuyen dieu' ,  CAMON_DanhGia = " + ChuyenMayCS.ToString() + " WHERE ID = " + objCuocGoi.IDCuocGoi.ToString();
                        if (strSQL.Length > 0)
                        {
                            if (CuocGoi.UpdateCSPhanBoCuocGoi(strSQL))
                            {
                                SapXepLaiIndex(objCuocGoi);
                                g_lstDienThoai.Remove(objCuocGoi);
                                HienThiTrenLuoi(false, false);
                            }
                            else
                                new MessageBox.MessageBoxBA().Show(this, "Chuyển không thành công", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                           
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void frmMoiKhach_V3_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessFastTaxi.ketThuc = true;
            try{
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
                {
                ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress);
               }

                Process.GetCurrentProcess().Kill();
            }catch(Exception ex){

            }
        }
        

        #region======== Comments====================
        //private void btnKiemTraTrangThaiXe_Click(object sender, EventArgs e)
        //{
        //    if (editSoHieuXe.Text.Length <= 0)
        //    {
        //        lblTrangThaiXe.Text = "";
        //    }

        //    if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
        //    {
        //       lblTrangThaiXe.Text = "Số hiệu xe này không tồn tại";        
        //        return;
        //    }
        //    if (StringTools.TrimSpace(editSoHieuXe.Text).Length  < 3)
        //    {
        //        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
        //        msgDialog.Show(this, "Bạn phải nhập đúng số hiệu xe", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
        //        return;
        //    }
        //    else
        //    {
        //        if (!KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
        //        {
        //            lblTrangThaiXe.Text = "Xe không hoạt động.";

        //        }
        //        else
        //        {
        //            string strStatus = string.Empty;
        //            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
        //            objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
        //            objKSXe = KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSXe);
        //            if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
        //            {
        //                if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
        //                {
        //                    strStatus = "" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " - " + objKSXe.ViTriDiemDen ;

        //                }
        //                else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
        //                {
        //                    strStatus = "" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + ", đi sân bay.";

        //                }
        //                else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
        //                {
        //                    strStatus = "" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";

        //                }
        //                if (objKSXe.IsMatLienLac) strStatus += "";
        //            }
        //            else
        //            {
        //                strStatus = "Xe nghỉ: " + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";
        //            }

        //            lblTrangThaiXe.Text = strStatus;
        //        }       
        //    }
        //}

        //private void editSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (editSoHieuXe.Text.Length <= 0)
        //    {
        //        lblTrangThaiXe.Text = "";
        //    }

        //    if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
        //    {
        //        lblTrangThaiXe.Text = "Số hiệu xe này không tồn tại";
        //        return;
        //    }
        //    if (StringTools.TrimSpace(editSoHieuXe.Text).Length < 3)
        //    {
        //        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
        //        msgDialog.Show(this, "Bạn phải nhập đúng số hiệu xe", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
        //        return;
        //    }
        //    else
        //    {
        //        if (!KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
        //        {
        //            lblTrangThaiXe.Text = "Xe không hoạt động.";

        //        }
        //        else
        //        {
        //            string strStatus = string.Empty;
        //            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
        //            objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
        //            objKSXe = KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSXe);
        //            if (!(objKSXe.TrangThaiLaiXeBao == KieuLaiXeBao.BaoNghi)) // kong phai nghi 
        //            {
        //                if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
        //                {
        //                    strStatus = "Xe HĐ:  " + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";

        //                }
        //                else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
        //                {
        //                    strStatus = "Xe HĐ:   " + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";

        //                }
        //                else if (objKSXe.LoaiChoKhach == LoaiChoKhach.ChoKhachNoiTinh)
        //                {
        //                    strStatus = "Xe HĐ:  " + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";

        //                }
        //                if (objKSXe.IsMatLienLac) strStatus += "  Xe mất LL ";
        //            }
        //            else
        //            {
        //                strStatus = "Xe nghỉ:" + string.Format("{0: HH:mm}", objKSXe.ThoiDiemBao) + " " + objKSXe.ViTriDiemBao + " ";
        //            }

        //            lblTrangThaiXe.Text = strStatus;
        //        }
        //    }
        //}
        //private void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    this.GetKiemSoatXe();
        //}


        #endregion
    }
}