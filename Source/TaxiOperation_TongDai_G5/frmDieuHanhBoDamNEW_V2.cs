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
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.IO;
using System.Diagnostics;
using TaxiOperation_TongDai.Properties;
using Taxi.Business.GridLayout;
  
namespace Taxi.GUI
{
    public partial class frmDieuHanhBoDamNEW_V2: Form
    {
        private List<DieuHanhTaxi> g_lstDienThoai = new List<DieuHanhTaxi>();
        private List<DieuHanhTaxi> g_lstCuocGoiDangTheoDoi = new List<DieuHanhTaxi>();

        private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;
        private int g_Count = 0;  // Dem so lan trong timer
        private bool g_bKetThucTimer = false;
        private Timer TimerCapturePhone;
        private string g_strVungsDuocCapPhep = string.Empty;
        private int g_SoDong = 20;
        private bool g_boolChuyenTabCuocGoiKetThuc = false;
        private int g_iStatus = 0;  // Blink stautste
        private long g_iTimerKsXe = 0;
        private int g_TimerCheckKhachHen = 0;
        private fmProgress m_fmProgress = null;

        private Color g_ColorOldTabCuocGoiDangThucHien;
        private bool g_boolNhayMauKhiCoCuocGoiMoi = false;

        private string g_strUsername = "";
        private string g_IPAddress = "";

        private DateTime g_TimeServer = DateTime.MinValue;
        private int g_iCountTuDongGuiMoiKhach = 0;

        // ---- Phục vụ xử lý tự động ----
        private List<long> g_lstCuocTuDongMoiLai = new List<long>();
        private List<long> g_lstCuocTuDongCoXeNhanGiuKhach = new List<long>();
        private List<long> g_lstCuocTuDongChuaCoXeNhanGiuKhach = new List<long>();

        //--------------------------------
        // -- Thong tin CS ---------------
        private int g_SoLuongDangNhapCS = 0;    // luu so luong nguoi dang nhap bo phan CS. 10 giay quet mot lan
        private int g_MayCSDuocPhanBoTruoc = 0; // Luu may CS da phan bo truoc, may CS gui thong tin sang (0 : tong dai xuly khong gui, 1: gui may mot, 2 : gui may 2)
        private int g_TimerKiemTraCSDangNhap = 0; // bien dem timer de check CS dang dang nhap
        private List<long> g_DSCuocDaPhanBoCS = new List<long>();
        private List<string> g_ListDSMayCS = new List<string>();
        private bool g_IsMayCS1 = false;  // luu giá trị là máy CS1 còn đang làm việc
        
        //--------------------------------LAYOUT----------------------------------------------------
        private GridLayout gridLayout;
        private void loadLayout(GridEX gridEX)
        {
            gridLayout = new GridLayout(ThongTinDangNhap.USER_ID, "BoDam", this.Name, gridEX.Name);
            gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
        }
        //--------------------------------LAYOUT----------------------------------------------------

        private frmGiamSatXe frmGSXe;

        private Messenger frmMessenger = new Messenger();

        public frmDieuHanhBoDamNEW_V2()
        {
            InitializeComponent();
        }

        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {           
            try
            {
                //-----------Set location for panel message
                pnlMessage.Location = new Point(this.Width - pnlMessage.Width - 14, 0);
                if (DieuHanhTaxi.CheckConnection())
                {
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    //---------------------------------------------------- 
                    this.Text = Configuration.GetCompanyName() + " - " + this.Text;
                    g_IPAddress = QuanTriCauHinh.GetIPPC();
                    this.g_strVungsDuocCapPhep = QuanTriCauHinh.GetVungsOfPCTongDai(g_IPAddress);
                    if (g_strVungsDuocCapPhep.Length > 0)
                    {
                        LoadDuLieuKhoiDau();
                        CheckIn();
                        g_TimeServer = DieuHanhTaxi.GetTimeServer();
                        g_SoLuongDangNhapCS = ThongTinDangNhap.GetSoLuongCSDangNhapThuocVung(this.g_strVungsDuocCapPhep);
                        g_ListDSMayCS = QuanTriCauHinh.GetDSMayTinhMoiKhachByVung(this.g_strVungsDuocCapPhep);
                        g_bKetThucTimer = true ; // thuc hien noi dung trong timer

                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();

                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi
                        
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Error);
                        Application.Exit();
                    }                    
                    
                    statusBar.Panels["TenDangNhap"].Text = "NV: " + ThongTinDangNhap.USER_ID;
                    gridCuocGois.Focus();
                     
                }
                else
                {
                    new MessageBox.MessageBox().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                TimerCapturePhone.Enabled = false;
                new MessageBox.MessageBox().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                //  LogError.WriteLog("Co loi khi khoi tao chuong trinh - DB ", ex);
            }

        }


        #region ChẹckIn/CheckOut
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>
        private void CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
           if(frm.ShowDialog() == DialogResult.OK)
           {
              g_strUsername = ThongTinDangNhap.USER_ID;

              if (g_strUsername.Length > 0)
              {
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                {
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    //--------------------------LAYOUT-------------------------------------
                    loadLayout(gridCuocGois);
                    //--------------------------LAYOUT-------------------------------------
                }
                else
                {
                    // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                    if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống. Người đã sử dụng trước phải checkout ra thì bạn mới vào được hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }
                    // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                    if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        Application.Exit();
                        return;

                    }
                    // cap nhat trang thai
                    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        ThongTinDangNhap.USER_ID = "";
                        g_strUsername = "";
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
                        {
                            new MessageBox.MessageBox().Show(this, "Bạn không có quyền điều hành tổng đài.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

                            ThongTinDangNhap.USER_ID = "";
                            g_strUsername = "";
                            Application.Exit();
                            return;
                        }
                    }
                    // thiet lap menu disable 
                    cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    statusBar.Panels["TenDangNhap"].Text = "NV : " + g_strUsername;
                    
                }
              }
            }
            else
            {
                cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                g_strUsername = "";

            }
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

                LoadAllCuocGoiHienTai(this.g_strVungsDuocCapPhep );
                m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = "Loading ... cuộc gọi chờ giải quyết";
                   m_fmProgress.progressBar1.Value = 50;
               }
               );
                
            //LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep );
            //m_fmProgress.lblDescription.Invoke(
            //       (MethodInvoker)delegate()
            //       {
            //           m_fmProgress.lblDescription.Text = "Loading ... cuộc đã giải quyết" ;
            //           m_fmProgress.progressBar1.Value = 80;
            //       }
            //   );
            ///GetKiemSoatXe();
            //m_fmProgress.lblDescription.Invoke(
            //      (MethodInvoker)delegate()
            //      {
            //          m_fmProgress.lblDescription.Text = "Loading ... Kiểm soát xe";
            //          m_fmProgress.progressBar1.Value = 100;
            //      }
            //  );
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
                new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
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
                g_Count++;
                if (g_bKetThucTimer)
                {
                    g_bKetThucTimer = false; // Khoa thuc hien noi dung timer

                    statusBar.Panels[6].Text = string.Format("{0:HH:mm:ss}", DateTime.Now);

                    if (g_lstCuocGoiDangTheoDoi != null)
                    {
                        if (g_lstCuocGoiDangTheoDoi.Count > 0)
                            g_lstCuocGoiDangTheoDoi.Clear();
                    }
                    g_lstCuocGoiDangTheoDoi = GetAllCuocGoiDangTheoDoi(this.g_strVungsDuocCapPhep);

                    // Phan bo CS--------------
                    g_TimerKiemTraCSDangNhap++;
                    if (g_TimerKiemTraCSDangNhap >= 10)
                    {
                        List<string> lstDSMayCSDangDangNhap = ThongTinDangNhap.GetDSMayCSDangDangNhap(this.g_strVungsDuocCapPhep);
                        if(lstDSMayCSDangDangNhap!=null )
                            g_SoLuongDangNhapCS = lstDSMayCSDangDangNhap.Count;

                        if (g_SoLuongDangNhapCS == 1) // chi con một máy
                        {
                            // Lay IP cua may CS dang con lam việc
                            string IPMayCSConHoatDong = lstDSMayCSDangDangNhap[0];
                            g_IsMayCS1 = KiemTraXemCoPhaiMayCS1DangLamViec(IPMayCSConHoatDong);
                        }
                        g_TimerKiemTraCSDangNhap = 0;
                    }
                    NhanCuocGoiMoiVaPhanBoCS();
                    //-------------------------
                    NhanCacCuocGoiMoiVe();
                    // Dien thoai ket thuc cuoc goi , can remove cuoc goi do phia TongDai
                    XoaCacCuocGoi_DienThoaiKetThuc();
                    //Cap nhat thong tin thay doi - luc chat giua hai cai
                    if (CapNhatThongTinCuocGoiBiThayDoi())
                    {
                        gridCuocGois.Refresh();
                    }
                    g_iCountTuDongGuiMoiKhach++;
                    if (g_iCountTuDongGuiMoiKhach >= 180)  // ba phút xử lý một lần
                    {
                        g_iCountTuDongGuiMoiKhach = 0;                        
                       
                    }
                    g_TimerCheckKhachHen++;
                    if (g_TimerCheckKhachHen > 10 * 60) //   : 10 phut - xoa các cuộc TUDONG MOI 
                    {
                        g_TimerCheckKhachHen = 0;
                        RemoveCuocDaPhanBoKetThuc();                     
                    }

                    ViewTrangThaiCacCuocGoiO_StatusBar();

                    if (g_boolChuyenTabCuocGoiKetThuc)
                    {
                        try
                        {
                            LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep,g_SoDong);
                        }
                        catch (Exception ex)
                        {
                            //  LogError.WriteLog("Loi trong timer: LoadCacCuocGoiKetThuc().", ex);
                        }
                        g_boolChuyenTabCuocGoiKetThuc = false;
                    }
                    if (g_Count >= 10)
                    {
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
                        //get tin nhan moi - hien thi noi dung tin nhan tren goc phai man hinh
                        getNewMessage();

                        g_Count = 0;                 
                    }
                    BlinkStatus(g_iStatus);
                    if (g_iStatus == 1) g_iStatus = 2;
                    else g_iStatus = 1;

                    g_bKetThucTimer = true;
                }                
            }            
            catch (Exception ex)
            {
                g_bKetThucTimer = true;
                //  LogError.WriteLog("Lỗi trong timer", ex);
            }
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
                    if ((IP != IPMayCSConHoatDong ) && (IPMayCSConHoatDong.CompareTo( IP) > 0 ))
                        return false; // máy số 
            }
            return true;
        }
        /// <summary>
        /// ham nhan cuoc goi moi tu dien thoai ve, va cap nhat vao DB trang thai phan bo cho CS.
        /// </summary>
        private void NhanCuocGoiMoiVaPhanBoCS()
        {
            try
            {
                List<DieuHanhTaxi> lstTongDaiCuocGoiMoi = new List<DieuHanhTaxi>();
                lstTongDaiCuocGoiMoi = GetAllCuocGoiDienThoai(g_lstCuocGoiDangTheoDoi);
                if ((lstTongDaiCuocGoiMoi !=  null) && (lstTongDaiCuocGoiMoi.Count > 0)) // Co cuoc goi moi
                {
                    string strSQL = "";
                    foreach (DieuHanhTaxi objDH in lstTongDaiCuocGoiMoi)
                    {
                        if (!KiemTraDaDuocPhanBoChua(objDH))
                        {
                            if (g_SoLuongDangNhapCS >= 2) // phan bo deu ra hai may
                            {
                                if (objDH.KieuCuocGoi == KieuCuocGoi.GoiLai)
                                {
                                    // tim lai cuoc goi truoc de xem da phan cho may nao
                                    try
                                    {
                                        g_MayCSDuocPhanBoTruoc = TimPhanBoCSCuocKhachGoiLai(Convert.ToInt64(objDH.CuocGoiLaiIDs));
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
                                strSQL += "  UPDATE T_TAXIOPERATION SET CAMON_DanhGia = " + g_MayCSDuocPhanBoTruoc.ToString() + " WHERE ID = " + objDH.ID_DieuHanh.ToString() + " AND CAMON_DanhGia IS NULL " + Environment.NewLine;

                            }
                            else if (g_SoLuongDangNhapCS == 1) // phan bo cho mot may
                            {
                                if (g_IsMayCS1)
                                    g_MayCSDuocPhanBoTruoc = 1;
                                else
                                    g_MayCSDuocPhanBoTruoc = 2;

                                strSQL += "  UPDATE T_TAXIOPERATION SET CAMON_DanhGia = " + g_MayCSDuocPhanBoTruoc.ToString() + " WHERE ID = " + objDH.ID_DieuHanh.ToString() + " AND CAMON_DanhGia IS NULL " + Environment.NewLine;
                            }
                            LuuCuocDaPhanBo(objDH);
                        }
                    }
                    // else khong can thuc hien phan bo
                    if(strSQL.Length >0)
                        DieuHanhTaxi.UpdateCSPhanBoCuocGoi(strSQL);
                }                 
            }
            catch (Exception ex)
            {
                
            }
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
                foreach (DieuHanhTaxi objDH in g_lstDienThoai)
                {
                    if (objDH.ID_DieuHanh == IDDieuHanh)
                    {
                        retMayPhanBo = (int) objDH.CamOn_DanhGia;
                        break;
                    }
                }
            }
            return retMayPhanBo;
        }
        #region Luu thong tin cuoc PhanBo
        /// <summary>
        /// hàm thuc hien luu lai cuoc da phan bo
        /// mục đích là để kiểm soát cuộc đã phân bổ, để không phải phân lại
        /// </summary>
        /// <param name="DH"></param>
        private void LuuCuocDaPhanBo(DieuHanhTaxi  DH)
        {
            if (g_DSCuocDaPhanBoCS != null)
                g_DSCuocDaPhanBoCS.Insert(0, DH.ID_DieuHanh);
        }
        /// <summary>
        /// hàm kiểm tra một mã của cuốc gọi đã được phân bổ chưa
        /// trả về : true khi đã phânbổ
        ///          false khi chưa phân bổ
        /// </summary>
        /// <param name="DH"></param>
        /// <returns></returns>
        private bool KiemTraDaDuocPhanBoChua(DieuHanhTaxi  DH)
        {
            if (g_DSCuocDaPhanBoCS != null && g_DSCuocDaPhanBoCS.Count > 0)
            {
                foreach (long Item in g_DSCuocDaPhanBoCS)
                {
                    if (DH.ID_DieuHanh == Item)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// hàm xóa bỏ các IĐieuHanh đã kết thúc 
        /// </summary>
        private void RemoveCuocDaPhanBoKetThuc()
        {
            try
            {
                List<int> lstRemove = new List<int>();
                if (g_lstCuocGoiDangTheoDoi == null || g_lstCuocGoiDangTheoDoi.Count <= 0)
                {
                    g_DSCuocDaPhanBoCS.Clear();
                }
                else
                {

                    for (int i = 0; i < g_DSCuocDaPhanBoCS.Count; i++)
                    {
                        bool bChuaKetThuc = true;
                        foreach (DieuHanhTaxi objDH in g_lstCuocGoiDangTheoDoi)
                        {
                            if (g_DSCuocDaPhanBoCS[i] == objDH.ID_DieuHanh)
                            {
                                bChuaKetThuc = false;
                                break;
                            }
                        }
                        if (bChuaKetThuc) // cuoc goi da ket thuc
                        {
                            lstRemove.Add(i);
                        }
                    }

                    if (lstRemove != null && lstRemove.Count > 0)
                    {
                        foreach (int Item in lstRemove)
                        {
                            g_DSCuocDaPhanBoCS.RemoveAt(Item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion 

        private void bw_DoWorkUpdateNhanVien(object sender, DoWorkEventArgs e)
        {
            List<DieuHanhTaxi> lstCuocGoiMoiVe = (List<DieuHanhTaxi>)e.Argument;
            if (lstCuocGoiMoiVe != null && lstCuocGoiMoiVe.Count > 0)
            {
                foreach(DieuHanhTaxi objDH in lstCuocGoiMoiVe){
                    DieuHanhTaxi.Update_BoDam(objDH.MaVung, ThongTinDangNhap.USER_ID);
                }
            }

            // Xoa cac ucoc tu dong khi co khoang thoi gian qua dai
            DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(30, this.g_strVungsDuocCapPhep);
        }
        private void bw_RunWorkerCompletedUpdateNhanVien(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
        

        #region Ham xu ly TỰ ĐỘNG GỬI qua mời khách
        /// <summary>
        /// input : 
        ///     - ds cac cuoc dang xu ly
        /// output : 
        ///     - tự động chèn thay đổi theo dữ liệu.
        ///  gữi khách kô xe
        ///  gữi khách (đã có xe)
        ///  reset  lại trắng
        /// </summary>
        private void HamXuLyGuiTuDongSangMoiKhach()
        {
            if (g_lstDienThoai != null && g_lstDienThoai.Count > 0)
            {
                foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
                {
                    if (objDHTX.KieuCuocGoi == KieuCuocGoi.GoiTaxi)
                    {
                        // Tìm khoảng thời gian để có thể gửi sang máy mời khách
                        TimeSpan timeSpan = new TimeSpan();
                        timeSpan = g_TimeServer - objDHTX.ThoiDiemGoi;
                        if (timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGiuKhachLai)
                        {
                            if (objDHTX.XeNhan.Length > 0) // da co xe nhan 
                            {
                                // tim xe da chen chua 
                                bool bFind = false;
                                foreach (long id in g_lstCuocTuDongMoiLai)
                                {
                                    if (id == objDHTX.ID_DieuHanh)
                                    {
                                        bFind = true; break;      // Đã gửi 
                                    }
                                }
                                if (!bFind)
                                {
                                    // đặt lại thông tin mời khách như chưa mời (như điện thoại mới gửi sang
                                    DieuHanhTaxi.UpdateTuDongMoiGiuKhach(objDHTX.ID_DieuHanh, "", "");
                                    g_lstCuocTuDongMoiLai.Add(objDHTX.ID_DieuHanh); // luu lai cuoc gọi de không chèn lại
                                }
                            }
                        }
                        //  nếu có xe nhận mà chưa có xe đón gửi thông tin giữ khác
                        else if (timeSpan.TotalMinutes < ThongTinCauHinh.SoPhutGiuKhachLai && timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGiuKhachCoXeNhan)
                        {
                            if (objDHTX.XeNhan.Length > 0 && objDHTX.LenhTongDai != "giữ khách")
                            {
                                // tim xe da chen chua 
                                bool bFind = false;
                                foreach (long id in g_lstCuocTuDongCoXeNhanGiuKhach)
                                {
                                    if (id == objDHTX.ID_DieuHanh)
                                    {
                                        bFind = true; break;
                                    }
                                }
                                if (!bFind)
                                {
                                    DieuHanhTaxi.UpdateTuDongMoiGiuKhach(objDHTX.ID_DieuHanh, "giữ khách", "");
                                    g_lstCuocTuDongCoXeNhanGiuKhach.Add(objDHTX.ID_DieuHanh);
                                }
                            }
                        }
                        else if (timeSpan.TotalMinutes < ThongTinCauHinh.SoPhutGiuKhachCoXeNhan && timeSpan.TotalMinutes >= ThongTinCauHinh.SoPhutGiuKhachChuaCoXeNhan)
                        {
                            if (objDHTX.XeNhan.Length <= 0 && objDHTX.LenhTongDai != "giữ khách chưa có xe")
                            {
                                // tim xe da chen chua 
                                bool bFind = false;
                                foreach (long id in g_lstCuocTuDongChuaCoXeNhanGiuKhach)
                                {
                                    if (id == objDHTX.ID_DieuHanh)
                                    {
                                        bFind = true; break;
                                    }
                                }
                                if (!bFind)
                                {
                                    DieuHanhTaxi.UpdateTuDongMoiGiuKhach(objDHTX.ID_DieuHanh, "giữ khách chưa có xe", "");
                                    g_lstCuocTuDongChuaCoXeNhanGiuKhach.Add(objDHTX.ID_DieuHanh);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// hàm tự động xóa các cuộc gọi gọi lưu trữ thông tin đã tự động mời
        /// </summary>
        private void XoaCacCuocLuuTruDaMoiTuDong()
        {
            try
            {
                List<int> lstRemoveCuocTuDongMoiLai = new List<int>();
                List<int> lstRemoveCuocTuDongCoXeNhanGiuKhach = new List<int>();
                List<int> lstRemoveCuocTuDongChuaCoXeNhanGiuKhach = new List<int>();

                if (g_lstDienThoai != null && g_lstDienThoai.Count > 0)
                {
                    if (g_lstCuocTuDongMoiLai != null && g_lstCuocTuDongMoiLai.Count > 0)
                    {

                        for (int i = 0; i < g_lstCuocTuDongMoiLai.Count; i++)
                        {
                            bool bFind = false;
                            for (int j = 0; j < g_lstDienThoai.Count; j++)
                            {
                                if (g_lstCuocTuDongMoiLai[i] == g_lstDienThoai[j].ID_DieuHanh ) { bFind = true; break; }
                            }
                            if (!bFind) lstRemoveCuocTuDongMoiLai.Add(i);
                        }
                    }
                    ///CoXeNhanGiuKhach

                    if (g_lstCuocTuDongCoXeNhanGiuKhach != null && g_lstCuocTuDongCoXeNhanGiuKhach.Count > 0)
                    {

                        for (int i = 0; i < g_lstCuocTuDongCoXeNhanGiuKhach.Count; i++)
                        {
                            bool bFind = false;
                            for (int j = 0; j < g_lstDienThoai.Count; j++)
                            {
                                if (g_lstCuocTuDongCoXeNhanGiuKhach[i] == g_lstDienThoai[j].ID_DieuHanh ) { bFind = true; break; }
                            }
                            if (!bFind) lstRemoveCuocTuDongCoXeNhanGiuKhach.Add(i);
                        }
                    }
                    /// CuocTuDongChuaCoXeNhanGiuKhach
                    if (g_lstCuocTuDongChuaCoXeNhanGiuKhach != null && g_lstCuocTuDongChuaCoXeNhanGiuKhach.Count > 0)
                    {

                        for (int i = 0; i < g_lstCuocTuDongChuaCoXeNhanGiuKhach.Count; i++)
                        {
                            bool bFind = false;
                            for (int j = 0; j < g_lstDienThoai.Count; j++)
                            {
                                if (g_lstCuocTuDongChuaCoXeNhanGiuKhach[i] == g_lstDienThoai[j].ID_DieuHanh ) { bFind = true; break; }
                            }
                            if (!bFind) lstRemoveCuocTuDongChuaCoXeNhanGiuKhach.Add(i);
                        }
                    }
                    // XOA BO
                    if (lstRemoveCuocTuDongMoiLai.Count > 0)
                    {
                        for (int i = 0; i < lstRemoveCuocTuDongMoiLai.Count; i++)
                        {
                            g_lstCuocTuDongMoiLai.RemoveAt(lstRemoveCuocTuDongMoiLai[i]);
                        }
                        lstRemoveCuocTuDongMoiLai.Clear();
                    }
                    //CuocTuDongCoXeNhanGiuKhach
                    if (lstRemoveCuocTuDongCoXeNhanGiuKhach.Count > 0)
                    {
                        for (int i = 0; i<lstRemoveCuocTuDongCoXeNhanGiuKhach.Count; i++)
                        {
                            g_lstCuocTuDongCoXeNhanGiuKhach.RemoveAt(lstRemoveCuocTuDongCoXeNhanGiuKhach[i]);
                        }
                        lstRemoveCuocTuDongCoXeNhanGiuKhach.Clear();
                    }
                    // 
                    if (lstRemoveCuocTuDongChuaCoXeNhanGiuKhach.Count > 0)
                    {
                        for (int i = 0;i< lstRemoveCuocTuDongChuaCoXeNhanGiuKhach.Count; i++)
                        {
                            g_lstCuocTuDongChuaCoXeNhanGiuKhach.RemoveAt(lstRemoveCuocTuDongChuaCoXeNhanGiuKhach[i]);
                        }
                        lstRemoveCuocTuDongChuaCoXeNhanGiuKhach.Clear();
                    }
                }
                else
                {
                    g_lstCuocTuDongMoiLai.Clear();
                    g_lstCuocTuDongCoXeNhanGiuKhach.Clear();
                    g_lstCuocTuDongChuaCoXeNhanGiuKhach.Clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion Ham xu ly TỰ ĐỘNG GỬI qua mời khách

        #region Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        /// <summary>
        /// nhung cuoc goi dang co o T_TAXIOPERATION
        /// </summary>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDangTheoDoi(string sVung)
        {
            try
            {                
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                string SQLCondition = "";
                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";
                //  SQLCondition += " ORDER BY ThoiDiemGoi DESC";    // Giam sap xep cho may chu
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
                    if ((objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai  )                         
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach)
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach )
                        || (objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.MoiKhachGui))
                           ListCuocGoiDienThoaiMoiGoiSang.Add(objDHTaxi);
                }
            }
            return ListCuocGoiDienThoaiMoiGoiSang;

        }
        /// <summary>
        /// ham lay ta cac cac cuoc goi dien thoai moi chuyen sang
        /// </summary>
        /// <param name="ListAllCuocGoiDangHoatDong"></param>
        /// <returns></returns>
        private List<DieuHanhTaxi> GetAllCuocGoiDienThoai(List<DieuHanhTaxi> ListAllCuocGoiDangHoatDong)
        {
            List<DieuHanhTaxi> ListCuocGoiDienThoaiMoiGoiSang = new List<DieuHanhTaxi>();
            if (ListAllCuocGoiDangHoatDong != null)
            {
                foreach (DieuHanhTaxi objDHTaxi in ListAllCuocGoiDangHoatDong)
                {
                    if ( objDHTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.DienThoai) 
                        ListCuocGoiDienThoaiMoiGoiSang.Add(objDHTaxi);
                }
            }
            return ListCuocGoiDienThoaiMoiGoiSang;

        }



        #endregion Ham Xu ly tai client (Nhat tat ca cuoc goi dang doat dong, sau do loc ra)

        private void CheckCuocGoiKhachHen()
        {
            // lay tat cac cac cuoc dang hen
            // kiem tra xem co den gio chua
            // hien thi cach báo o cuoi mang hinh

            if (g_lstDienThoai != null)
            {   int iRow =0;
                foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
                {
                    if (objDHTX.KieuKhachHangGoiDen == KieuKhachHangGoiDen.KhachHangHen)
                    {
                        if (CuocGoiKhachHen.CanhBaoDenGioKhachHen(CuocGoiKhachHen.GetKhachHen(objDHTX.ID_DieuHanh)))
                        {
                            // tim row of grid
                            gridCuocGois.Row = iRow;
                            // view dialog
                              frmDienThoaiHenKhach frm = new frmDienThoaiHenKhach(objDHTX);
                              frm.Show();
                            break;
                        }
                    }
                    iRow++;    
                }
            }
        }
        /// <summary>
        /// Nhung cuoc goi moi ve la nhung cuoc goi co TrangThaiLenh = ienThoai =1 dien thoai chuyen sang
        ///     - Load trong DB xem co cuoc  goi nao moi ve khong
        ///     - Them vao dau tien cua luoi
        /// </summary>
        private List<DieuHanhTaxi> NhanCacCuocGoiMoiVe()
        {
            try
            {
                List<DieuHanhTaxi> lstTongDaiCuocGoiMoi = new List<DieuHanhTaxi>();
                lstTongDaiCuocGoiMoi = GetAllCuocGoiDienThoaiMoiGoiSang(g_lstCuocGoiDangTheoDoi);
                if (lstTongDaiCuocGoiMoi == null) 
                    return null; ;
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
                return lstTongDaiCuocGoiMoi;
            }
            catch (Exception ex)
            {
                return null;
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
                        return; 
                    }
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
                  if (g_lstDienThoai == null) 
                      g_lstDienThoai = new List<DieuHanhTaxi>();
                  
                  g_lstDienThoai.Insert(0,objDHTX); // Chèn vào đầu
                  // Chèn gần số vùa gọi lại
                  if (objDHTX.CuocGoiLaiIDs != null && objDHTX.CuocGoiLaiIDs.Length > 0)
                  {
                      long ID = Convert.ToInt64(objDHTX.CuocGoiLaiIDs);
                      int indexRemove = -1;
                      for (int i = 0; i < g_lstDienThoai.Count; i++)
                      {
                          if (g_lstDienThoai[i].ID_DieuHanh == ID)
                          {
                              indexRemove = i; break;
                          }
                      }
                      if (indexRemove > 0)
                      {
                          DieuHanhTaxi[] arrCuocGoi = g_lstDienThoai.ToArray(); // copy ra mang tam
                          g_lstDienThoai.Clear();                               // xoa tam
                          if (g_lstDienThoai == null) 
                              g_lstDienThoai = new List<DieuHanhTaxi>();
                          g_lstDienThoai.Insert(0, objDHTX);
                          g_lstDienThoai.Insert(1, arrCuocGoi[indexRemove]);
                          if (arrCuocGoi.Length > 2)
                          {
                              int indexChen = 2;
                              for (int i = 1; i < arrCuocGoi.Length; i++)
                              {
                                  if(i != indexRemove )
                                  {
                                      g_lstDienThoai.Insert(indexChen, arrCuocGoi[i]);
                                      indexChen++;
                                  }
                              }
                          } 
                      }
                  } 
                  boolOK = true;// co su thay doi trong danh sach
              }
           }          
          // g_lstDienThoai.Sort(delegate(DieuHanhTaxi call1, DieuHanhTaxi call2) { return call2.ThoiDiemGoi.CompareTo(call1.ThoiDiemGoi); }); 

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
       
        private void LoadAllCuocGoiHienTai(string sVung)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();



                string SQLCondition = " AND ((TrangThaiLenh=1) OR (TrangThaiLenh=2) OR  (TrangThaiLenh=5) OR (TrangThaiLenh=6 ) OR (TrangThaiLenh=7 )) ";

                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ")";

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


                frmBodamInputData_V2 frm = new frmBodamInputData_V2(objDieuHanhTaxi, this.g_SoLuongDangNhapCS, this.g_TimeServer );

                frm.DSXeNhanDangHoatDong = GetDSXeNhanDangHoatDong();
                DialogResult _DialogResult = frm.ShowDialog(this);
                if (_DialogResult == DialogResult.OK)
                {
                    objDieuHanhTaxi = frm.GetDieuHanhTaxi;
                    objDieuHanhTaxi.MaNhanVienTongDai = g_strUsername;

                    if ((objDieuHanhTaxi.TrangThaiLenh != TrangThaiLenhTaxi.KetThuc) && (objDieuHanhTaxi.KieuCuocGoi!= KieuCuocGoi.GoiLai ))
                        objDieuHanhTaxi.TrangThaiLenh = TrangThaiLenhTaxi.TongGuiSangMoiKhach;

                    if (!objDieuHanhTaxi.Update_BoDam())
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Không truyền được thông tin đi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        //-------Xu ly cuoc goi khach hen-----
                        //if (objDieuHanhTaxi.LenhDienThoai.Contains("khách hẹn"))
                        //{
                        //    CuocGoiKhachHen objKhachHen = new CuocGoiKhachHen();
                        //    objKhachHen = CuocGoiKhachHen.GetKhachHen(objDieuHanhTaxi.ID_DieuHanh);
                        //    if (!objKhachHen.IsDaGiaiQuyet)
                        //    {
                        //        objKhachHen.IsDaGiaiQuyet = true;
                        //        objDieuHanhTaxi.Update_MaNhanVienTongDai();

                        //        objKhachHen.ThoiDiemBatDau = objDieuHanhTaxi.ThoiDiemGoi;
                        //        objKhachHen.BaoTruocSoPhut = 10;
                        //        objKhachHen.GhiChu = "";
                        //        if (!objKhachHen.Insert_Update())
                        //        {
                        //            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        //            msgDialog.Show(this, "Lỗi cập nhật thông tin khách hẹn.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        //            return;
                        //        }
                        //    }
                        //}
                        //-------   |||||||||  ---------------

                        // Tim va xu ly ket thuc duoc goi
                        //chuyen sang bang T_TAXIOPERATION_KETTHUC
                        if (objDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KetThuc)
                        {
                            
                            if (g_lstDienThoai != null)
                            {
                                DieuHanhTaxi objTemp = new DieuHanhTaxi();
                                foreach (DieuHanhTaxi objDHTX in g_lstDienThoai)
                                {
                                    if (objDHTX.ID_DieuHanh == objDieuHanhTaxi.ID_DieuHanh)
                                    {
                                        objTemp = objDHTX;
                                        break;
                                    }
                                }
                                if (objTemp != null)
                                    g_lstDienThoai.Remove(objTemp);
                            }

                            gridCuocGois.DataSource = null;
                            gridCuocGois.DataMember = "ListDienThoai";
                            gridCuocGois.SetDataBinding(g_lstDienThoai, "ListDienThoai");
                            gridCuocGois.Refresh();
                        }
                        else
                        {
                            TimVaCapNhatVaoDanhSach(objDieuHanhTaxi);
                            gridCuocGois.Refresh();
                        }
                    }
                }
                else if (_DialogResult == DialogResult.Ignore)
                {
                    DieuHanhTaxi.UpdateCuocKhachKetThucKhongXacDinhXeDon(objDieuHanhTaxi.ID_DieuHanh);
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


        private void NhapDulieu_DiaChiTraKhach(GridEXRow row )
        {
             
            
            DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)row.DataRow;
            if (((StringTools.TrimSpace(objDieuHanhTaxi.GhiChuTongDai).Length <= 0) && (objDieuHanhTaxi.XeDon.Length > 0)))
            { }
            else
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Không tồn tại xe đón, không thể nhập địa chỉ.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }

            //Thu doi mau
            GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
            GridEXFormatStyle RowStyle = new GridEXFormatStyle();
            RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
            rowSelect.RowStyle = RowStyle;
            //End - Thu doi mau
            frmBodamInputData_V2 frm = new frmBodamInputData_V2(objDieuHanhTaxi,g_TimeServer, true);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                objDieuHanhTaxi = frm.GetDieuHanhTaxi;
                if (frm.IsCapNhatDCTraKhach)
                {
                    if (!objDieuHanhTaxi.Update_BoDam_CapNhatDiaChiTraKhack())
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Không truyền được thông tin đi [Dia chi tra khach]", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {  
                        if (!objDieuHanhTaxi.Update_BoDam_CapNhatSanBay_DuongDai())
                        {
                            MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                            msgDialog.Show(this, "Không truyền được thông tin đi [San bay-Duong dai]", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                            return;
                        }
                        gridCuocGoi_KetThuc.DataSource = null;
                        LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep,g_SoDong);                    

                    }        
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
                //--------------------------LAYOUT-------------------------------------
                loadLayout(gridCuocGois);
                //--------------------------LAYOUT-------------------------------------
                
            }
            else if (e.Page.Name == "uiTabCuocGoiKetThuc")
            {
              g_boolChuyenTabCuocGoiKetThuc = true;
              //--------------------------LAYOUT-------------------------------------
              loadLayout(gridCuocGoi_KetThuc);
              //--------------------------LAYOUT-------------------------------------
               
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
                        NhapDulieu_DiaChiTraKhach(row); 
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
            else if (keyData == Keys.F1)
            {
                this.frmGSXe.Activate();
                this.frmGSXe.SetViTriDatTrenManHinh();
                this.frmGSXe.LoadTrangThaiCuaXe();
            }
            else if (keyData == Keys.F5)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT,1).ShowDialog();
            }
            else if (keyData == Keys.F6)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 2).ShowDialog();
            }
            else if (keyData == Keys.F7)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 3).ShowDialog();
            }
            else if (keyData == Keys.F8)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 4).ShowDialog();
            }
            return false;
        }
        #endregion XU LY HOTKEY

        #region XuLy Nhap DIA CHI TRA KHACH-CUOC GOI DA GIAI QUYET
        
        private void gridCuocGoi_KetThuc_DoubleClick(object sender, EventArgs e)
        {
            gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
            {
                 GridEXRow row = ((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow();
                NhapDulieu_DiaChiTraKhach(row);              
            }
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
                    RowStyle.BackColor = Color.LightCyan; // xanh nhat
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 10 && timeSpan.TotalMinutes < 15)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Turquoise;    // xanhdam hon
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
                }
                else if (timeSpan.TotalMinutes >= 15)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.LightPink;
                    row.Cells["XeNhan"].FormatStyle = RowStyle;
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
                NhapDulieu_DiaChiTraKhach(row);              
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
                    if ((objDH.XeNhan.Length <= 0))
                        iSoCuocGoiChuaDieuXe += 1;
                    if ((objDH.XeNhan.Length > 0) && (objDH.XeDon.Length <= 0))
                        iSoCuocGoiChuaDonDuocKhach += 1;


                }
            }
            if (g_lstCuocGoiKetThuc != null)
            {
                foreach (DieuHanhTaxi objDH in g_lstCuocGoiKetThuc)
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
            this.statusBar.Panels[3].Text = "Số xe chưa báo điểm trả khách: " + iSoXeChuaNhapDiaChiTraKhach.ToString(); 
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
                        new MessageBox.MessageBox().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        statusBar.Panels["TenDangNhap"].Text = "NV: ";
                        ThongTinDangNhap.USER_ID = "";
                        CheckIn();
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    }
                }
                else
                    new MessageBox.MessageBox().Show(this, "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
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
                    new MessageBox.MessageBox().Show(this, "File hướng dẫn không tồn tại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                }
            }
            else if (e.Command.Key == "cmdAbout")
            {
                new frmAbout().ShowDialog();
            }

            //--------------------------------------Quan Ly Tin Nhan - Phupn-----------------------------------------
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhBoDamNEW_V2));
                        gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                        gridCuocGois.LoadLayout(gridLayout.getLayout(gridCuocGois.GetLayout()));
                    }
                    else if (uiTabCuocGoiDangThucHien.SelectedTab.Name == "uiTabCuocGoiKetThuc")
                    {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDieuHanhBoDamNEW_V2));
                        gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                        gridCuocGoi_KetThuc.LoadLayout(gridLayout.getLayout(gridCuocGoi_KetThuc.GetLayout()));
                    }
                }
            }
            //----------------------------------------------------------------------------------
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
            else if (e.Command.Key == "cmdXeRaHoatDong")
            {

                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 1).ShowDialog();
            }
            else if (e.Command.Key == "cmdXeveGara")
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 4).ShowDialog();
            }
            else if (e.Command.Key == "cmdCauHinhChuyenCS")
            {
                new frmCauHinhChuyenChamSoc().ShowDialog();
            }
            else if (e.Command.Key == "cmdBangKiemSoatXe")
            {
                if (frmGSXe == null)
                {
                    frmGSXe = new frmGiamSatXe(this);
                    frmGSXe.Show(this);
                }
            }
        }
        
        #endregion XuLyTrenMenu

        private void gridCuocGoi_KetThuc_Click(object sender, EventArgs e)
        {

        }

        #region  XY LY KHACH AO

        private void mnuRigthClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (gridCuocGoi_KetThuc.SelectedItems.Count <= 0) return;
            if(e.Command .Key == "mnuThemKhachAo")
            {  
                // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem) gridCuocGoi_KetThuc  .SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();

                
                if (DanhBaKhachAo.GetDanhBa(objDieuHanhTaxi.PhoneNumber ).Length > 0)
                {

                    msgDialog.Show(this, "Khách ảo [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] này đã tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information);
                    return;
                }
                if (msgDialog.Show(this, "Bạn có đồng ý đưa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] vào danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                {
                    DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber,"", objDieuHanhTaxi.DiaChiDonKhach);
                    if (objKhachAo.Insert())
                    {
                       
                        msgDialog.Show(this, "Thêm mới khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        msgDialog.Show(this, "Lỗi thêm mới khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information  );
                        return;
                    }

                }
                
            }
            else if (e.Command.Key == "mnuXoaKhachAo")
            {
                // GridEXRow row = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                if (msgDialog.Show(this, "Bạn có đồng ý xóa số điện thoại [" + objDieuHanhTaxi.PhoneNumber + " - " + objDieuHanhTaxi.DiaChiDonKhach + "] trong danh sách khách ảo không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question) == DialogResult.Yes.ToString())
                {
                    DanhBaKhachAo objKhachAo = new DanhBaKhachAo(objDieuHanhTaxi.PhoneNumber,"", objDieuHanhTaxi.DiaChiDonKhach);
                    if (objKhachAo.Delete(objDieuHanhTaxi.PhoneNumber ))
                    {

                        msgDialog.Show(this, "Xóa khách ảo thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        msgDialog.Show(this, "Lỗi xóa khách ảo", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,  Taxi.MessageBox.MessageBoxIcon.Information);
                        return;
                    }

                }
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
            frmBaoCaoBieuMau14 frm = new frmBaoCaoBieuMau14();
            frm.ShowDialog(this);
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
    }
}