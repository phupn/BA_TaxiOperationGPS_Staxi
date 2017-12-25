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
using Taxi.Utils;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.IO;
using System.Diagnostics;
using TaxiOperation_MoiKhach;
using Asterisk.NET.Manager;
  
namespace Taxi.GUI
{
    public partial class frmMoiKhach_V2: Form
    {
        private List<DieuHanhTaxi> g_lstDienThoai = new List<DieuHanhTaxi>();
        private List<DieuHanhTaxi> g_lstCuocGoiDangTheoDoi = new List<DieuHanhTaxi>();

        private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;
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
        private string g_IPAddress = "";
        private bool   g_bKetThucTimer ;
        private Int16 g_MayCS = 0; // vùng chăm sóc máy nhận về (1,2)
        private int g_CountKiemTraMayCS = 0;  // bien dem kiem tra cs la may gi

        //--- COM info ----
        string g_COMPort = "";
        public static frmCallOut frmCalling = new frmCallOut();
        //=================
        //--- Thoat cuoc 999 ----
        private int  g_Thoat999SoPhutGioiHan;           // so phut gioi han cho phep thoat cuoc
        private bool g_Thoat999TrangThaiTATBAT;         // trang thai tat/bat của thoat cuoc
        private int g_Thoat999SoCuocGioiHan;            // so cuoc goi gioi han duoc phep su dụng 999
        //================= 
        private int g_SoLuongDangNhapCS = 0;            // luu so luong nguoi dang nhap bo phan CS. 10 giay quet mot lan
        private int g_iTimerLayMayCS = 0;
        private string g_LinesDuocCapPhep = string.Empty;
        public frmMoiKhach_V2()
        {
            InitializeComponent(); 
        }
        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
             
            try
            {

                if (DieuHanhTaxi.CheckConnection())
                {
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    // Lấy cấu hình.
                    Config_Common.LoadConfigCommon();                  
                    this.Text = Configuration.GetCompanyName() + " - " + this.Text;
                    this.g_SOPHUTCANHBAO = Configuration.GetSoPhutCanhBaoMoiKhach();
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    this.g_strVungsDuocCapPhep = QuanTriCauHinh.GetLineVungOfPC(g_IPAddress,KieuMayTinh.MAYMOIKHACH );

                    if (Debugger.IsAttached)
                    {
                        g_strVungsDuocCapPhep = "1;2;3";
                    }
                    if (g_strVungsDuocCapPhep.Length > 0)
                    {
                        if (!CheckIn()) return;
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        //-----------Set location for panel message
                        pnlMessage.Location = new Point(Width - pnlMessage.Width - 14, 0);
                        // Lấy ds các máy mời khách cùng vùng
                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();

                        if (this.IsLaMayMoiKhach1())
                        {
                            g_MayCS = 1;
                        }
                        else g_MayCS = 2;
                        g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_strVungsDuocCapPhep);

                        LoadDuLieuKhoiDau();
                        gridCuocGois.Focus();
                        g_bKetThucTimer = true;
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi
                        if (Configuration.IsMKAsterisk)
                        {
                            // lấy line của PBX IP để phục vụ gọi tự động ra ngoài
                            g_lineIPPBX = Configuration.LineIPPBX;//AsteriskInfo.GetLineIPPBX(g_LinesDuocCapPhep);
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
                        new MessageBox.MessageBoxBA().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK,  Taxi.MessageBox.MessageBoxIconBA.Error);
                        ////  LogError.WriteLog("IP : " + g_IPAddress, new Exception("Thong tin dia chi ip"));
                        Application.Exit();
                    } 
                    statusBar.Panels["TenDangNhap"].Text = "NV: ";               

                    KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                    //statusBar.Panels["COM"].Text = " COM: " + g_COMPort;
                    LayCauHinhThoatCuoc999();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK,  Taxi.MessageBox.MessageBoxIconBA.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                TimerCapturePhone.Enabled = false;
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                ////  LogError.WriteLog("Co loi khi khoi tao chuong trinh - DB "ll, ex);
            }

        }


        private void LayCauHinhThoatCuoc999()
        {
            // thiet lap mac dinh
            g_Thoat999SoPhutGioiHan     = 15;
            g_Thoat999TrangThaiTATBAT   = false  ;
            g_Thoat999SoCuocGioiHan      = 30;


            int vung ;
            string[] arrVungs = g_strVungsDuocCapPhep.Split(";".ToCharArray());
            if(int.TryParse(arrVungs[0],out vung))
            {
                DataTable dt = ThoatCuoc999.GetCauHinhBATTATByVung(vung);
                if(dt != null && dt.Rows.Count >0)
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
                    if(! int.TryParse (dr["SoPhutDuocThoatCuoc"].ToString (),out g_Thoat999SoPhutGioiHan))
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

        /// <summary>
        /// ham tra trang thai xem may co phai la may moi khach 1 hay khong ?
        /// May moi khach 1 la may co IP min trong cac may MK
        /// </summary>
        /// <returns></returns>
        private bool IsLaMayMoiKhach1()
        {
            // cung lop ip 
            bool bMayMoiKhach1 = true ;
            List<string> lstIPMoiKhach = QuanTriCauHinh.GetDSMayTinhMoiKhachByVung(this.g_strVungsDuocCapPhep);
            if (lstIPMoiKhach != null && lstIPMoiKhach.Count > 0)
            {                 
                foreach (string strItem in lstIPMoiKhach)
                {
                     if((strItem != this.g_IPAddress ) && (strItem.CompareTo (this.g_IPAddress)>0)) 
                         return false ;
                }
            }

            return bMayMoiKhach1;
        }
    
        #region ChẹckIn/CheckOut
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>
        private bool CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
            frm.ShowDialog();
            g_strUsername = ThongTinDangNhap.USER_ID;

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
                    //if (Config_Common.DangNhapNhieuMay && ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                    //{
                    //    new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    //    ThongTinDangNhap.USER_ID = "";
                    //    g_strUsername = "";
                    //    //g_strFullName = "";
                    //    Application.Exit();
                    //    return false;
                    //}

                    // cap nhat trang thai
                    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        Application.Exit();
                        return false;
                    }
                    else
                    {
                        if (! ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHCSKH)   )
                        {
                            new MessageBox.MessageBoxBA().Show(this, "Bạn không có quyền máy CSKH.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

                            ThongTinDangNhap.USER_ID = "";
                            g_strUsername = "";
                            Application.Exit();
                            return false;
                        } 
                    }
                    // thiet lap menu disable 
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    statusBar.Panels["TenDangNhap"].Text = "NV : " + g_strUsername;
                }
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";
                return false;
            }
            return true;
        }

        #endregion 


        #region LOAD du lieu luc dau
      
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

            }                
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

                LoadAllCuocGoiHienTai(this.g_strVungsDuocCapPhep, this.g_MayCS);
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
        
        #endregion LOAD du lieu luc dau

        #region Nhan cuoc goi moi co

        #region Cac ham lien quan toi Timer Capture Phone
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
                if (g_bKetThucTimer)
                {
                    g_bKetThucTimer = false;
                    //this.statusBar.Panels[5].Width = 170;
                    this.statusBar.Panels[6].Text = string.Format("{0:HH:mm:ss}", DateTime.Now);

                    if (g_bTimeKetThucCuocGoi)  // da bat goi so 
                    {
                        g_iTimeKetThucCuocGoi++;
                        if (g_iTimeKetThucCuocGoi >= 15)
                        {

                            g_iTimeKetThucCuocGoi = 0;
                            g_bTimeKetThucCuocGoi = false;
                        }
                    } 
                    if ((g_lstCuocGoiDangTheoDoi != null) && (g_lstCuocGoiDangTheoDoi.Count > 0))
                    {
                        g_lstCuocGoiDangTheoDoi.Clear();
                    }
                    //g_CountKiemTraMayCS++;
                    //if (g_CountKiemTraMayCS == 10)
                    //{
                    //    if (this.IsLaMayMoiKhach1())
                    //    {
                    //        g_MayCS = 2;
                    //    }
                    //    else g_MayCS = 1;
                    //    g_CountKiemTraMayCS=0;

                    //}

                    g_lstCuocGoiDangTheoDoi = GetAllCuocGoiDangTheoDoi(this.g_strVungsDuocCapPhep, this.g_MayCS);

                    NhanCacCuocGoiMoiVe();
                    // Dien thoai ket thuc cuoc goi , can remove cuoc goi do phia TongDai
                    XoaCacCuocGoi_DienThoaiKetThuc();
                    //Cap nhat thong tin thay doi - luc chat giua hai cai
                    if (CapNhatThongTinCuocGoiBiThayDoi())
                    {
                        gridCuocGois.Refresh();
                    }

                    ViewTrangThaiCacCuocGoiO_StatusBar();

                    if (g_boolChuyenTabCuocGoiKetThuc)
                    {
                        try
                        {
                            LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep, g_soDong);
                        }
                        catch (Exception ex)
                        {
                            // //  LogError.WriteLog("Loi trong timer: LoadCacCuocGoiKetThuc().", ex);
                        }
                        g_boolChuyenTabCuocGoiKetThuc = false;
                    }

                    // Get thong tin Message
                    g_iTimerMessage++;
                    if (g_iTimerMessage >= 10)
                    {
                        getNewMessage();
                        g_iTimerMessage = 0;   // đặt lại lần quét tiếp theo
                    }

                    g_iTimerLayMayCS++;
                    if (g_iTimerLayMayCS >= 120)
                    {
                        g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_strVungsDuocCapPhep);
                        g_iTimerLayMayCS = 0;
                    }

                    BlinkStatus(g_iStatus);
                    if (g_iStatus == 1) g_iStatus = 2;
                    else g_iStatus = 1;
                    g_bKetThucTimer = true;
                }
            }
            catch (Exception ex)
            {
               // //  LogError.WriteLog("Lỗi trong timer", ex);
                g_bKetThucTimer = true;
            }
        }


        #region Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION
        /// </summary>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDangTheoDoi(string sVung, int MayMoiKhachSo)
        {
            try
            {                
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                string SQLCondition = ""; 
                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";

                //if (MayMoiKhachSo == 0)
                //{
                //    SQLCondition += " ";
                //}
                //else 
                //    if (MayMoiKhachSo == 1)
                //    SQLCondition += " AND ((CAMON_DanhGia IS NULL) OR (CAMON_DanhGia =1) OR (CAMON_DanhGia =0)) ";
                //else SQLCondition += " AND (CAMON_DanhGia = 2)  ";

                SQLCondition += " ORDER BY ThoiDiemGoi DESC";
                return objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private string GetSQLStringQueryVung(string Vung)
        {
            string strReturn = " (1<>1) " ;
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
        private List<DieuHanhTaxi> GetAllCuocGoiDienThoaiMoiGoiSang(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiDienThoaiMoiGoiSang = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if (objDHTaxi != null)
                    {
                        if (
                            //objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach
                            //|| objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach
                            //|| objDHTaxi.GoiKhieuNai || (objDHTaxi.TrangThaiLenh == TrangThaiLenhTaxi.DienThoai 
                            //&& 
                            objDHTaxi.KieuCuocGoi == KieuCuocGoi.GoiTaxi)

                            ListCuocGoiDienThoaiMoiGoiSang.Add(objDHTaxi);
                    }
                }
            }
            return ListCuocGoiDienThoaiMoiGoiSang;

        }
        #endregion Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

    
        /// <summary>
        /// Nhung cuoc goi moi ve la nhung cuoc goi co TrangThaiLenh = ienThoai =1 dien thoai chuyen sang
        ///     - Load trong DB xem co cuoc  goi nao moi ve khong
        ///     - Them vao dau tien cua luoi
        /// </summary>
        private void NhanCacCuocGoiMoiVe()
        {
            try
            {
             
                List<DieuHanhTaxi> lstTongDaiCuocGoiMoi = new List<DieuHanhTaxi>();
                lstTongDaiCuocGoiMoi = GetAllCuocGoiDienThoaiMoiGoiSang(g_lstCuocGoiDangTheoDoi); 
                if (lstTongDaiCuocGoiMoi == null) return;
                if (lstTongDaiCuocGoiMoi.Count > 0) // Co cuoc goi moi
                {
                    if (GhepThemCuocGoiMoiNhanVaoDau(lstTongDaiCuocGoiMoi))
                    {
                        gridCuocGois .DataSource = null;
                        gridCuocGois.DataMember = "ListDienThoai";
                        gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                        timerBaoCoDuLieuDienThoaiGui.Enabled = true;
                    }                   
                }
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Co loi nhan cuoc goi moi ve", ex);
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Cap nhat thong tin cuôc gọi bị thay đổi
        /// Từ bên điện thoại gửi sang
        /// </summary>
        private bool  CapNhatThongTinCuocGoiBiThayDoi()
        {      
            bool boolOK = false;
            try
            {
             
                List<DieuHanhTaxi> lstCuocGoiDienThoaiGuiSang = new List<DieuHanhTaxi>();
                lstCuocGoiDienThoaiGuiSang = GetAllCuocGoiDienThoaiMoiGoiSang(g_lstCuocGoiDangTheoDoi); 
                if (lstCuocGoiDienThoaiGuiSang == null) return false;
                if (lstCuocGoiDienThoaiGuiSang.Count > 0) //Co cuoc goi TongDai gui sang
                {
                    foreach (DieuHanhTaxi objCuocGoiDienThoai in lstCuocGoiDienThoaiGuiSang)
                    {
                        if (g_lstDienThoai.Count > 0)
                        {
                            for (int i = 0; i < g_lstDienThoai.Count;i++)
                            {
                                if (objCuocGoiDienThoai.ID_DieuHanh == ((DieuHanhTaxi)g_lstDienThoai[i]).ID_DieuHanh)
                                {
                                    g_lstDienThoai[i] = (DieuHanhTaxi)objCuocGoiDienThoai;
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
                List<DieuHanhTaxi> lstDienThoaiServer = new List<DieuHanhTaxi>(); // cuoc dien thoai hien co o server
                List<DieuHanhTaxi> lstTongDaiNoExist = new List<DieuHanhTaxi>(); // cuoc dien thoai hien tai dang co 



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
                        return; }
                    foreach (DieuHanhTaxi objDHTX_TongDai in g_lstDienThoai)
                    {
                        bool boolHas = false;
                        foreach (DieuHanhTaxi objDHTX_Server in lstDienThoaiServer)
                        {
                            if (objDHTX_TongDai.ID_DieuHanh == objDHTX_Server.ID_DieuHanh)
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
                    if (lstTongDaiNoExist == null) return ;
                    foreach (DieuHanhTaxi objDHTX_Delete in lstTongDaiNoExist)
                    {
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
                    gridCuocGois .DataSource = null;
                    gridCuocGois.DataMember = "ListDienThoai";
                    gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                }
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Ghep them cac cuoc goi moi, sau do sap xep theo thoi gian
        /// </summary>
        /// <param name="ListOfNewCalls"></param>
        private bool GhepThemCuocGoiMoiNhanVaoDau(List<DieuHanhTaxi> ListOfNewCalls)
        {
            bool boolOK = false;

            if (ListOfNewCalls == null) return false;
          foreach(DieuHanhTaxi objDHTX in ListOfNewCalls)
          {
              if (!KiemTraXemCuocGoiDaDuocThemVaoChua(objDHTX))
              {
                  if (g_lstDienThoai == null) g_lstDienThoai = new List<DieuHanhTaxi>();
                  g_lstDienThoai.Add(objDHTX);
                  boolOK = true;// co su thay doi trong danh sach
              }
          }         
          g_lstDienThoai.Sort(delegate(DieuHanhTaxi call1, DieuHanhTaxi call2) { return call2.ThoiDiemGoi.CompareTo(call1.ThoiDiemGoi); }); 

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
            DieuHanhTaxi[] arrDH = g_lstDienThoai.ToArray();
            DieuHanhTaxi temp;
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
            List<DieuHanhTaxi> listCuocGoiKhongCoXeNhan = new List<DieuHanhTaxi>();
            List<DieuHanhTaxi> listCuocGoiCoXeNhan = new List<DieuHanhTaxi>();
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
            foreach (DieuHanhTaxi objDH in listCuocGoiKhongCoXeNhan)
            {
                g_lstDienThoai.Add(objDH);
            }
            foreach (DieuHanhTaxi objDH in listCuocGoiCoXeNhan)
            {
                g_lstDienThoai.Add(objDH);
            }

            listCuocGoiCoXeNhan.Clear();
            listCuocGoiCoXeNhan = null;

            listCuocGoiKhongCoXeNhan.Clear();
            listCuocGoiKhongCoXeNhan = null;
            arrDH = null;

        }
        private bool KiemTraXemCuocGoiDaDuocThemVaoChua(DieuHanhTaxi DHTaxi)
        {
            bool boolOK = false;
            if (g_lstDienThoai == null) return false;
            foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
            {
                if (objDHTX.ID_DieuHanh == DHTaxi.ID_DieuHanh)
                {
                    boolOK = true;
                    break;
                }
            }
            return boolOK;
        }

        #endregion Cac ham lien quan toi Timer Capture Phone


        #endregion Nhan cuoc goi moi co




        #region XU LY CUOC CHUA KET THUC
        /// <summary>
        /// Load nhung cuoc dien thoai cho tong dai
        ///   -  Cuoc dien thoai do dien thoai gui sang va  cua chinh minh dang xu ly (TrangThaiLenhTaxi=1 & 2)
        ///   -  Cuoc dien thoai nam trong vung cua minh
        /// </summary>
       
        private void LoadAllCuocGoiHienTai(string sVung, int MayMoiKhachSo)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();

                

                string SQLCondition = "";// AND (   (TrangThaiLenh=5) OR (TrangThaiLenh=6 ) OR (TrangThaiLenh=7 ) OR (GoiKhieuNai=1) ) "; // Cuộc gọi điện thoại gửi sang, cuộc gọi tổng đai 

                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";

                //if (MayMoiKhachSo == 1)
                //    SQLCondition += " AND ((CAMON_DanhGia IS NULL) OR (CAMON_DanhGia =1)) ";
                //else SQLCondition += " AND (CAMON_DanhGia = 2)  ";

                SQLCondition += " ORDER BY ThoiDiemGoi DESC";
                g_lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
                gridCuocGois.DataMember = "ListDienThoai";
                gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                
            }
            catch(Exception ex)
            {

            }
        }
        #endregion XU LY CUOC CHUA KET THUC

        #region XU LY NHAP DU LIEU VA TRUYEN DI

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
            if (e.KeyCode == Keys.Enter)
            {
                gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridCuocGois.SelectedItems.Count > 0)
                {
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).Position);
                    // lua cho dong lua chon dau tien 
                }
            } 
            else if (e.KeyData == Keys.F4 || e.KeyData == Keys.Space)
            {
                gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridCuocGois.SelectedItems.Count > 0)
                {                     
                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;   
                    g_bTimeKetThucCuocGoi = true;
                    objDieuHanhTaxi.LenhDienThoai = "Đang gọi...";
                    DieuHanhTaxi.Update_ThoiDiemMoiKhach(objDieuHanhTaxi.ID_DieuHanh, ThongTinDangNhap.USER_ID);
                    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + objDieuHanhTaxi.PhoneNumber, objDieuHanhTaxi.DiaChiDonKhach, true); 
                }
            }
        }
         
        /// <summary>
        /// - Nhan vao vi tri cua mot dong trong list cac cuoc goi dang hien hanh
        /// - lay gia tri len form 
        /// - nhap vao truyen di
        /// 
        /// </summary>
        /// <param name="iRowPosition"></param>
        private void NhapDuLieuVaoTruyenDi( int iRowPosition)
        {

            gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGois.SelectedItems.Count > 0)
            {
                // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;
                //End - Thu doi mau
            
                LENHCUATONGDAI_MOIKHACH LenhTongDai = GetLenhTongDai(objDieuHanhTaxi);

                if (LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI)
                {
                   frmKhieuNaiInputData frmKhieuNai =  new frmKhieuNaiInputData(objDieuHanhTaxi);
                   if (frmKhieuNai.ShowDialog() == DialogResult.OK)
                   {
                       objDieuHanhTaxi.MOIKHACH_NhanVien = ThongTinDangNhap.USER_ID;
                       if (!objDieuHanhTaxi.Update_MOIKHACH_KhieuNai())
                       {

                           MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                           msgDialog.Show(this, "Không lưu được thông tin khiếu nại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                           return;
                       }
                       else if (objDieuHanhTaxi.TrangThaiLenh == TrangThaiLenhTaxi.KetThuc) 
                       {
                           objDieuHanhTaxi.Update_KetThucCuocGoi(objDieuHanhTaxi.ID_DieuHanh, objDieuHanhTaxi.TrangThaiLenh);
                       }
                   }
                   RowStyle = new GridEXFormatStyle();
                   RowStyle.BackColor = System.Drawing.SystemColors.Window;
                   rowSelect.RowStyle = RowStyle; 
                   return; // ket thuc khieu nai
                }

                frmMoiKhachInputData_V2 frm = new frmMoiKhachInputData_V2(objDieuHanhTaxi, LenhTongDai, IsThoatDuoc999(objDieuHanhTaxi,g_TimeServer));
              
                DialogResult _DialogResult=frm.ShowDialog(this);
                if (_DialogResult== DialogResult.OK)
                {
                    objDieuHanhTaxi = frm.GetDieuHanhTaxi;
                    objDieuHanhTaxi.MOIKHACH_NhanVien = g_strUsername;
                   
                    if(LenhTongDai==LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH || LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH)
                    {
                        if (!objDieuHanhTaxi.Update_MOIKHACH_MoiKhachGiu())
                        {
                            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                            msgDialog.Show(this, "Không lưu được thông tin mời, giữ khách", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                            return;
                        }
                        else
                            objDieuHanhTaxi.Update_KetThucCuocGoi(objDieuHanhTaxi.ID_DieuHanh, TrangThaiLenhTaxi.MoiKhachGui);// cập nhạt trạng thái mời kháhc gửi
                    }                    
                    else if (LenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI)
                    {                        
                        if (!objDieuHanhTaxi.Update_MOIKHACH_KhongXeXinLoi())
                        {
                            MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                            msgDialog.Show(this, "Không lưu được thông tin cuộc gọi không xe xin lỗi. Có thể tổng đài đã thay đổi thông tin cuộc gọi.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                            return;
                        }
                        else
                        {
                            objDieuHanhTaxi.Update_KetThucCuocGoi(objDieuHanhTaxi.ID_DieuHanh, objDieuHanhTaxi.TrangThaiLenh);
                        }
                    }
                    TimVaCapNhatVaoDanhSach(objDieuHanhTaxi);
                    gridCuocGois.Refresh();
                   
                }
                else if (_DialogResult == DialogResult.Ignore)
                {
                    if (objDieuHanhTaxi.ID_DieuHanh > 0)
                    {
                        DieuHanhTaxi.UpdateCuocKhachKetThucKhongXacDinhXeDon(objDieuHanhTaxi.ID_DieuHanh, ThongTinDangNhap.USER_ID, objDieuHanhTaxi.XeNhan);
                    }
                }
                else
                {  //tra ve mau cu
                    RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = System.Drawing.SystemColors.Window;
                    rowSelect.RowStyle = RowStyle;
                    return;
                }
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
                return;
            }
            
        }
        /// <summary>
        /// Ham thuc hien check xem co du dieu kien dung 999
        /// Tra ve :
        ///     TRUE : duoc phep thoat
        ///     FALSE: khong duoc phep thoat         
        /// </summary>
        /// <param name="cuocGoi"></param>
        /// <param name="timeServer"></param>
        /// <returns></returns>
        private bool IsThoatDuoc999(DieuHanhTaxi cuocGoi, DateTime timeServer)
        {

            TimeSpan timeSpan = timeServer - cuocGoi.ThoiDiemGoi;
            bool bGioiHanCuoc = false;
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
        /// <summary>
        /// Hamf 
        /// </summary>
        /// <param name="objDieuHanhTaxi"></param>
        /// <returns></returns>
        private LENHCUATONGDAI_MOIKHACH GetLenhTongDai( DieuHanhTaxi objDieuHanhTaxi)
        {
            if (objDieuHanhTaxi.LenhTongDai.Contains("mời khách"))
            {
                return LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH;
            }
            else if (objDieuHanhTaxi.LenhTongDai.Contains("giữ khách"))
            {
                return LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH;
            }
            else if (objDieuHanhTaxi.LenhTongDai.Contains("không xe xin lỗi khách"))
            {
                return LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI;
            }
            else if (objDieuHanhTaxi.GoiKhieuNai)
            {
                return LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI;
            }

            return LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH;
        }

        /// <summary>
        /// tra ve ds xe nhan dang co
        /// </summary>
        /// <returns></returns>
        private string GetDSXeNhanDangHoatDong()
        {
            string strDSXeNhan ="";
            try{
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
            catch(Exception ex)
            {
                return "";
            }
        }
        
    
        /// <summary>
        /// Tim tỏng sach va cap nhat du lieu vao 
        /// </summary>
        /// <param name="objDieuHanhTaxi"></param>
        private void TimVaCapNhatVaoDanhSach(DieuHanhTaxi objDieuHanhTaxi)
        {
            if (g_lstDienThoai == null) return ;
            foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
            {
                if (objDieuHanhTaxi.ID_DieuHanh == objDHTX.ID_DieuHanh)
                {
                    objDHTX.XeNhan = objDieuHanhTaxi.XeNhan;
                    objDHTX.XeDon = objDieuHanhTaxi.XeDon;
                    objDHTX.LenhTongDai = objDieuHanhTaxi.LenhTongDai;
                    objDHTX.GhiChuTongDai = objDieuHanhTaxi.GhiChuTongDai;
                    objDHTX.TrangThaiLenh = objDieuHanhTaxi.TrangThaiLenh;
                    objDHTX.ThoiGianDieuXe = objDieuHanhTaxi.ThoiGianDieuXe;
                    objDHTX.ThoiGianDonKhach = objDieuHanhTaxi.ThoiGianDonKhach;
                    objDHTX.MOIKHACH_KhieuNai_DaXyLy = objDieuHanhTaxi.MOIKHACH_KhieuNai_DaXyLy;
                    objDHTX.MOIKHACH_KhieuNai_ThongTinThem = objDieuHanhTaxi.MOIKHACH_KhieuNai_ThongTinThem;
                    objDHTX.MOIKHACH_LenhMoiKhach = objDieuHanhTaxi.MOIKHACH_LenhMoiKhach;

                    break;
                }
            }
        }

        #endregion XU LY NHAP DU LIEU VA TRUYEN DI



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
              g_boolChuyenTabCuocGoiKetThuc = false ;
              
             // GetKiemSoatXe();
            }
            
        }

        


        #region XuLyCacCuocGoi ket thuc

        /// <summary>
        /// hàm trả về ds sách cuộc gọi 
        /// </summary>
        /// <param name="linesChoPhep">line của máy này được phép</param>
        /// <param name="soDong">so dòng (row)</param>
        private void LoadCacCuocGoiKetThuc(string vungsDuocCapPhep, int soDong)
        {
            try
            {
                gridCuocGoi_KetThuc.DataMember = "lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(DieuHanhTaxi.TONGDAI_LayCuocGoiDaGiaiQuyet(vungsDuocCapPhep, soDong), "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {

            }
         }

        //private void LoadCacCuocGoiKetThuc(string sVung)
        //{
        //    try
        //    {
        //        DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
        //        g_lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

        //        DateTime TimeServer = DieuHanhTaxi.GetTimeServer();
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
        private List<DieuHanhTaxi> SapXepCuocGoiKetThuc(List<DieuHanhTaxi> listCuocGoiKT)
        {
            // Danh sach cac cuoc chua co dia chi
            List<DieuHanhTaxi> listCuocGoiChuaCoDCDonKhach = new List<DieuHanhTaxi>();
            //danh sach cac cuoc co co dia chi
            List<DieuHanhTaxi> listCuocGoiDaCoDCDonKhach = new List<DieuHanhTaxi>();
            // danh sach cuoc goi trượt, hoãn, không xe, goi lai
            List<DieuHanhTaxi> listCuocGoiTruotHoanKhongXeGoiLai = new List<DieuHanhTaxi>();
            // Danh sach cuoi cung ghep tu hai danh sach tren
            List<DieuHanhTaxi> listCuocGoiGhep = new List<DieuHanhTaxi>();
            if (listCuocGoiKT == null) return null;
            foreach (DieuHanhTaxi objDHTX in listCuocGoiKT)
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
                foreach (DieuHanhTaxi objDHTX in listCuocGoiChuaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiDaCoDCDonKhach != null)
            {
                foreach (DieuHanhTaxi objDHTX in listCuocGoiDaCoDCDonKhach)
                {
                    listCuocGoiGhep.Add(objDHTX);
                }
            }
            if (listCuocGoiTruotHoanKhongXeGoiLai != null)
            {
                foreach (DieuHanhTaxi objDHTX in listCuocGoiTruotHoanKhongXeGoiLai)
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
        private bool CheckHoanKhongXeTruotGoiLai(DieuHanhTaxi objDHTX)
        {
            if(objDHTX.LenhTongDai.Contains("không xe") )return true;
            else if (objDHTX.GhiChuTongDai.Contains("trượt")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("gọi lại")) return true;
            else if (objDHTX.GhiChuTongDai.Contains("hoãn")) return true;

            return false;

        }

        #endregion XuLyCacCuocGoi ket thuc


        #region XU LY HOTKEY

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
                if (uiTabCuocGoiDangThucHien.SelectedIndex==1 )
                {
                    if (gridCuocGoi_KetThuc.RowCount > iRowSelect)
                    {
                        gridCuocGoi_KetThuc.Row = iRowSelect;
                        GridEXRow row = gridCuocGoi_KetThuc.GetRow(iRowSelect);
                        ///NhapDulieu_DiaChiTraKhach(row); 
                    }
                    return true ;
                }

                if (gridCuocGois .RowCount > iRowSelect)
                {
                    gridCuocGois.Row = iRowSelect;
                    if (g_strUsername.Length <= 0)
                        CheckIn();
                    else
                        NhapDuLieuVaoTruyenDi(iRowSelect);
                    
                }
                return true;
            }

            if (keyData == (Keys.Shift | Keys.D1))
            {
                if(uiTabCuocGoiDangThucHien.SelectedIndex!=0)
                     uiTabCuocGoiDangThucHien.SelectedIndex = 0;
            }else
            if (keyData == (Keys.Shift | Keys.D2))
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex != 1)
                    uiTabCuocGoiDangThucHien.SelectedIndex = 1;
            }
            else if (keyData == (Keys.Shift | Keys.D3))
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex != 2)
                {
                    uiTabCuocGoiDangThucHien.SelectedIndex = 2;
                }
            }
               
            return false;
        }
        #endregion XU LY HOTKEY

        #region XuLy Nhap DIA CHI TRA KHACH-CUOC GOI DA GIAI QUYET
        
        private void gridCuocGoi_KetThuc_DoubleClick(object sender, EventArgs e)
        {
            //gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            //if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            //{
            //     GridEXRow row = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
            //    NhapDulieu_DiaChiTraKhach(row);              
            //}
        }

        #endregion XuLy Nhap DIA CHI TRA KHACH-CUOC GOI DA GIAI QUYET
        
        
        private void gridCuocGois_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void gridCuocGoi_KetThuc_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
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


                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)row.DataRow;
                if ((objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.BoDam))
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                else if (objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai)
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.BoDam;
                    
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objDieuHanhTaxi.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue  ;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangKhongHieu)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Red;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                if (objDieuHanhTaxi.LenhTongDai.ToLower() == "mời khách")
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    if (objDieuHanhTaxi.MOIKHACH_LenhMoiKhach.ToLower() == "đã mời")
                    {
                       
                        RowStyle.BackColor = Color.Yellow;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        row.Cells["MOIKHACH_LenhMoiKhach"].FormatStyle = RowStyle;
                    }
                    else
                    {
                      
                        RowStyle.BackColor = Color.Red;
                        row.RowStyle = RowStyle;
                    } 
                }
                if (objDieuHanhTaxi.LenhTongDai == "giữ khách")
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    if (objDieuHanhTaxi.MOIKHACH_LenhMoiKhach == "đã giữ")
                    {

                        RowStyle.BackColor = Color.Pink;
                        row.Cells["LenhTongDai"].FormatStyle = RowStyle;
                        row.Cells["MOIKHACH_LenhMoiKhach"].FormatStyle = RowStyle;
                    }
                    else
                    {

                        RowStyle.BackColor = Color.Pink;
                        row.RowStyle = RowStyle;
                    }
                }
                if (objDieuHanhTaxi.LenhDienThoai.Contains("gọi lại"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }

                if (objDieuHanhTaxi.GhiChuTongDai.Contains("trượt"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["GhiChu"].FormatStyle = RowStyle;

                }
                if (objDieuHanhTaxi.ThoiGianDieuXe > Configuration.GetGioiHanThoiGianDieuXe())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["ThoiGianDieuXe"].FormatStyle = RowStyle;

                }
                if (objDieuHanhTaxi.ThoiGianDonKhach  > Configuration.GetGioiHanThoiGianDonKhach ())
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    //row.Cells["GhiChuTongDai"].FormatStyle = RowStyle;
                    row.Cells["ThoiGianDonKhach"].FormatStyle = RowStyle;

                }
                if (objDieuHanhTaxi.LoaiXe.Contains("7"))
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Cyan;
                    row.Cells["LoaiXe"].FormatStyle = RowStyle;
                }
                if (objDieuHanhTaxi.SoLuong.Length > 0)
                {
                    int SoLuong = Convert.ToInt32(objDieuHanhTaxi.SoLuong);
                    if(objDieuHanhTaxi.XeNhan.Length>0)
                    {
                        int SoLuongDangCo = Convert.ToInt32(objDieuHanhTaxi.XeNhan.Length + 1) / 4; 
                        if (SoLuong > SoLuongDangCo)
                        {
                            GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                            RowStyle.BackColor = Color.Red ;
                            row.Cells["SoLuong"].FormatStyle = RowStyle;
                        }
                        else
                        {
                            GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                            RowStyle.BackColor = System.Drawing.SystemColors.Window; 
                            row.Cells["SoLuong"].FormatStyle = RowStyle;
                        }
                        
                    }
                }
                // Hien thi mau cho cham soc khach hang
                if (objDieuHanhTaxi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTot)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightCoral;
                    row.Cells["Time"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTrungBinh)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.SpringGreen;
                    row.Cells["Time"].FormatStyle = RowStyle;
                }

                // Hiển thị màu theo thời gian để cảnh báo
                TimeSpan timeSpan = g_TimeServer - objDieuHanhTaxi.ThoiDiemGoi;
                if (timeSpan.TotalMinutes >= 5 && timeSpan.TotalMinutes < 10)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightCyan  ; // xanh nhat
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 10 && timeSpan.TotalMinutes < 15)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Turquoise;    // xanhdam hon
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 15  )
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightPink;
                    row.Cells["XeNhan"].FormatStyle= RowStyle;
                }
                // Nen cua dia chi may tim - cho phep thoat cuoc 999
                if ((g_lstDienThoai != null && g_lstDienThoai.Count >= g_Thoat999SoCuocGioiHan) && g_Thoat999TrangThaiTATBAT && timeSpan.TotalMinutes >= g_Thoat999SoPhutGioiHan)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Indigo;
                    RowStyle.ForeColor = Color.White;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }
                else
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.White ;
                    RowStyle.ForeColor = Color.Black;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle; 
                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }



        #region Thanh trang thai

        private void BlinkStatus(int iStatus)
        {
            statusBar.Panels[0].ImageIndex = iStatus;
        }

        private void gridCuocGoi_KetThuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();             
               // NhapDulieu_DiaChiTraKhach(row);              
            }
        }



        private void ViewTrangThaiCacCuocGoiO_StatusBar()
        {

            int iSoCuocGoiChuaDieuXe = 0;
            int iSoCuocGoiChuaDonDuocKhach = 0;
            int iSoXeChuaNhapDiaChiTraKhach = 0;
            if (g_lstDienThoai != null)
            {
                foreach (DieuHanhTaxi objDH in g_lstDienThoai)
                {
                    if ((objDH.XeNhan == null || objDH.XeNhan.Length <= 0))
                        iSoCuocGoiChuaDieuXe += 1;
                    if (objDH.XeNhan != null && objDH.XeDon == null && (objDH.XeNhan.Length > 0) && (objDH.XeDon.Length <= 0))
                        iSoCuocGoiChuaDonDuocKhach += 1;


                }
            }
            //if (g_lstCuocGoiKetThuc != null)
            //{
            //    foreach (DieuHanhTaxi objDH in g_lstCuocGoiKetThuc)
            //    {
            //        if (objDH.XeDon != null && (StringTools.TrimSpace(objDH.XeDon).Length > 0) && (StringTools.TrimSpace(objDH.DiaChiTraKhach).Length <= 0))
            //        {
            //            iSoXeChuaNhapDiaChiTraKhach += 1; 
            //        }
            //    }
            //}
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

        #endregion Thanh trang thai


        #region XuLyTrenMenu

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
             if (e.Command.Key == "cmdTinhCuoc") 
             {
            //    if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0)
            //    {
                    frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                    frm.ShowDialog();
                //}
                //else
                //{
                //    frmTinhTienTheoKm frm = new frmTinhTienTheoKm();
                //    frm.ShowDialog();
               //  }
                 
            }
            else  if (e.Command.Key == "cmdThayDoiMatKhau")
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
                if (ThongTinDangNhap.IsUserPostionTrust (g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
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
            else if(e.Command.Key == "cmdNoiDungTroGiup")
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
        }

        #endregion XuLyTrenMenu

        private void gridCuocGoi_KetThuc_Click(object sender, EventArgs e)
        {

        }

        #region  XY LY KHACH AO

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
              
               if (e.Command.Key == "cmdChon20Dong")
                {
                    g_soDong = 20;
                    LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong);
                }
                else if (e.Command.Key == "cmdChon50Dong")
                {
                    g_soDong = 50;
                    LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong);
                }
                else if (e.Command.Key == "cmdChon100Dong")
                {
                    g_soDong = 100;
                    LoadCacCuocGoiKetThuc(g_strVungsDuocCapPhep, g_soDong);
                }
            if (g_boolChuyenTabCuocGoiKetThuc)
            {
                if (gridCuocGoi_KetThuc.SelectedItems.Count <= 0) return;
                if (e.Command.Key == "mnuThemKhachAo")
                {
                    // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();


                    if (DanhBaKhachAo.GetDanhBa(objDieuHanhTaxi.PhoneNumber).Length > 0)
                    {

                        msgDialog.Show(this, "Khách ảo [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] này đã tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        return;
                    }
                    if (msgDialog.Show(this, "Bạn có đồng ý đưa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] vào danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                    {
                        DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber, "", objDieuHanhTaxi.DiaChiDonKhach);
                        if (objKhachAo.Insert())
                        {

                            msgDialog.Show(this, "Thêm mới khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            return;
                        }
                        else
                        {

                            msgDialog.Show(this, "Lỗi thêm mới khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            return;
                        }

                    }

                }
                else if (e.Command.Key == "mnuXoaKhachAo")
                {
                    // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    if (msgDialog.Show(this, "Bạn có đồng ý xóa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] trong danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                    {
                        DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber, "", objDieuHanhTaxi.DiaChiDonKhach);
                        if (objKhachAo.Delete(objDieuHanhTaxi.PhoneNumber))
                        {

                            msgDialog.Show(this, "Xóa khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            return;
                        }
                        else
                        {

                            msgDialog.Show(this, "Lỗi xóa khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            return;
                        }

                    }
                }

                else if (e.Command.Key == "cmdCall")
                {

                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                    g_bTimeKetThucCuocGoi = true;
                    HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + objDieuHanhTaxi.PhoneNumber, objDieuHanhTaxi.DiaChiDonKhach, true);

                }

               
            }
            else  
            {
               

                if (e.Command.Key == "cmdCall")
                {
                   
                        DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                        g_bTimeKetThucCuocGoi = true;
                        HienThiFormGoiDienThoai(Configuration.GetDauSoGoiDi + objDieuHanhTaxi.PhoneNumber, objDieuHanhTaxi.DiaChiDonKhach, true);
                        DieuHanhTaxi.Update_ThoiDiemMoiKhach(objDieuHanhTaxi.ID_DieuHanh, ThongTinDangNhap.USER_ID);
                   
                }
                else if (e.Command.Key == "cmdChuyenCS")
                {
                    string strSQL = "";
                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                    // lấy thông tin CS hiện tại
                    int ChuyenMayCS = 0;
                    if (objDieuHanhTaxi.CamOn_DanhGia == KieuKhachDanhGiaCAMON.DanhGiaTot)
                        ChuyenMayCS = 2;// chuyển máy 2
                    else
                        ChuyenMayCS = 1;
                    strSQL += "  UPDATE T_TAXIOPERATION SET TrangThaiLenh = '6',  MOIKHACH_KhieuNai_ThongTinThem ='chuyen dieu' ,  CAMON_DanhGia = " + ChuyenMayCS.ToString() + " WHERE ID = " + objDieuHanhTaxi.ID_DieuHanh.ToString();
                    if (strSQL.Length > 0)
                    {
                        DieuHanhTaxi.UpdateCSPhanBoCuocGoi(strSQL);
                        g_lstDienThoai.Remove(objDieuHanhTaxi);
                        gridCuocGois.Refresh();
                    }
                }
            }
        }
        #endregion

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
                    listOfXeCapNhatTrangThai.Add(KiemSoatXeLienLac.CapNhatTrangThaiXe(objKSLLXe,timeCurrentServer));
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

        private void OnXeLienLacClickHandler(object XeLienLac, Taxi.Controls.XeLienLacEventArgs XeLienLacInfo)
        {
            //frmNhapThongTinKiemSoatXe frm = new frmNhapThongTinKiemSoatXe(3, XeLienLacInfo.SoHieuXe);
           
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    GetKiemSoatXe();
            //}
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

        private void gridCuocGoi_KetThuc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnuRigthClick.ShowCustomizeDialog(); 
            }
        }

        private void btnBaoCaoXeHoatDong_Click(object sender, EventArgs e)
        {
             
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
             
        }

        private void frmMoiKhach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }



        #region COM PORT
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
                    string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
                    serialPort1.Write(Call);
                    return true;

                    System.Threading.Thread.Sleep(1000);
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {
                 

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
                 
            }
        }

        #region ==================== Thông số kết nối tổng đài =======================
        private ManagerConnection manager = null;
        /// <summary>
        /// line của Tổng đài PBX IP cho pc này
        /// </summary>
        private string g_lineIPPBX = string.Empty;
        public string g_LinesDuocCapPhepGoiRa = string.Empty;
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
                LogError.WriteLogError("InitPBXIP", ex);
            }
        }
        #endregion
        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="DiaChi"></param>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi, bool isPBXIP)
        {
            if (frmCalling == null) frmCalling = new frmCallOut();
            frmCalling.Show();
            if (g_COMPort.Length > 0)
            {
                frmCalling.Invoke(
                                (MethodInvoker)delegate()
                                {
                                    frmCalling.lblSoGoi.Text = string.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                                }
                );
                frmCalling.Refresh();
                if (isPBXIP)
                {
                    frmCalling.Call(manager, g_lineIPPBX, PhoneNumber);
                }
                //frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);
            }
            else if (isPBXIP)
            {
                frmCalling.Invoke(
                                   (MethodInvoker)delegate()
                                   {
                                       frmCalling.lblSoGoi.Text = string.Format("Đang gọi : {0} - {1}", PhoneNumber, DiaChi);
                                   }
                   );
                frmCalling.Refresh();
                frmCalling.Call(manager, g_lineIPPBX, PhoneNumber);
            }
        }
        #endregion COM PORT 

        #region MESSAGE _ CHATTING 
        
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
                    pnlMessage.Visible = false;
                    txtNDTinNhan.Text = "";
                    return;
                }
                if (dtMsg.Rows.Count <= 0)
                {
                    pnlMessage.Visible = false;
                    txtNDTinNhan.Text = "";
                    return;
                }

                pnlMessage.Visible = true;
                txtNDTinNhan.Text = dtMsg.Rows[0]["Contents"].ToString();
                dtMsg.Dispose();
            }
            catch (Exception ex)
            {
                return;
            }
        }

       
        #endregion

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            //if (gridCuocGoi_KetThuc.SelectedItems == null || gridCuocGoi_KetThuc.SelectedItems.Count <= 0)
            //    uiContextMenu1.Close();
        }

         
    }
}