using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using EFiling.Utils;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.QuanTri;
using System.IO;
using System.Diagnostics;
  
namespace Taxi.GUI
{
    public partial class frmDieuHanhBoDamNEW_V2: Form
    {
        private List<DieuHanhTaxi> g_lstDienThoai = new List<DieuHanhTaxi>();
        private List<DieuHanhTaxi> g_lstCuocGoiDangTheoDoi = new List<DieuHanhTaxi>();

        private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;

        private Timer TimerCapturePhone;
        private string g_strVungsDuocCapPhep = string.Empty;         
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

        //--- COM info ----

        string g_COMPort = "";
        public static frmDangGoi frmCalling = new frmDangGoi();
        //=================

        //--------------------------------

        private frmGiamSatXe frmGSXe;

        public frmDieuHanhBoDamNEW_V2()
        {
            InitializeComponent(); 
        }

        private void frmDieuHanhDienThoaiNEW_Load(object sender, EventArgs e)
        {
            frmGSXe = new frmGiamSatXe(this);
            frmGSXe.Show(this); 
            try
            {

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
                        InitTimerCapturePhone(); // Khoi tao bat cuoc goi 
 
                        KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                        statusBar.Panels["COM"].Text = " COM: " + g_COMPort;                                                             



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
                            new MessageBox.MessageBox().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

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
                
            LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep );
            m_fmProgress.lblDescription.Invoke(
                   (MethodInvoker)delegate()
                   {
                       m_fmProgress.lblDescription.Text = "Loading ... cuộc đã giải quyết" ;
                       m_fmProgress.progressBar1.Value = 80;
                   }
               );
            ///GetKiemSoatXe();
            m_fmProgress.lblDescription.Invoke(
                  (MethodInvoker)delegate()
                  {
                      m_fmProgress.lblDescription.Text = "Loading ... Kiểm soát xe";
                      m_fmProgress.progressBar1.Value = 100;
                  }
              );
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
                this.statusBar.Panels[6].Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
                g_iTimerKsXe++;
                
                if(g_iTimerKsXe >= 600 ) // 10 phut
                {
                    g_iTimerKsXe = 0;
                   // GetKiemSoatXe();
                }
                 
                if (g_lstCuocGoiDangTheoDoi != null)
                {
                    if (g_lstCuocGoiDangTheoDoi.Count > 0)
                        g_lstCuocGoiDangTheoDoi.Clear();
                }
                g_lstCuocGoiDangTheoDoi = GetAllCuocGoiDangTheoDoi(this.g_strVungsDuocCapPhep );

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
                        LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep);
                    }
                    catch (Exception ex)
                    {
                        //  LogError.WriteLog("Loi trong timer: LoadCacCuocGoiKetThuc().", ex);
                    }
                    g_boolChuyenTabCuocGoiKetThuc = false;
                }

                BlinkStatus(g_iStatus);
                if (g_iStatus == 1) g_iStatus = 2;
                else g_iStatus = 1;
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi trong timer", ex);
            }
        }



          

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
                    if ((objDHTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.DienThoai  )
                        || (objDHTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.BoDam )  
                        || (objDHTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach)
                        || (objDHTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach )
                        || (objDHTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.MoiKhachGui))
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
            else if (e.KeyData == Keys.F4 || e.KeyData == Keys.Space)
            {
                gridCuocGois.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridCuocGois.SelectedItems.Count > 0)
                {

                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                   
                    HienThiFormGoiDienThoai(objDieuHanhTaxi.PhoneNumber, objDieuHanhTaxi.DiaChiDonKhach);

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
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)gridCuocGois.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau 
                frmBanGiaInputData frm = new frmBanGiaInputData(objDieuHanhTaxi);
                
                DialogResult _DialogResult = frm.ShowDialog(this); 
                if (_DialogResult == DialogResult.OK)
                {
                    objDieuHanhTaxi = frm.GetDieuHanhTaxi;
                    objDieuHanhTaxi.BTBG_NhanVien  = g_strUsername;
                    if (objDieuHanhTaxi.BTBG_IsDaXuLy) objDieuHanhTaxi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;

                    if (!objDieuHanhTaxi.Update_BanGiaBanTin())
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Không cập nhật được dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {  
                        // Tim va xu ly ket thuc duoc goi
                        //chuyen sang bang T_TAXIOPERATION_KETTHUC
                        if (objDieuHanhTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.KetThuc)
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
                    //DieuHanhTaxi.UpdateCuocKhachKetThucKhongXacDinhXeDon(objDieuHanhTaxi.ID_DieuHanh);
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
        
        private void LoadCacCuocGoiKetThuc(string sVung)
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                g_lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                DateTime TimeServer = DieuHanhTaxi.GetTimeServer();
                string strTuDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer.Subtract(new TimeSpan(24,00,0) ));
                string strDenDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer);
                
                string NRecords = " TOP  50  ";
                //string SQLCondition = "  ((ThoiDiemGoi >= '" + strTuDate + "') AND (ThoiDiemGoi<='"+strDenDate+ "' ))   AND (TrangThaiLenh=3) ";
                 string SQLCondition = "   AND (TrangThaiLenh=3) ";
                SQLCondition += " AND (" + this.GetSQLStringQueryVung(sVung) + ") ";
                SQLCondition += " ORDER BY ThoiDiemGoi DESC";
                
                g_lstCuocGoiKetThuc = SapXepCuocGoiKetThuc( objDHTaxi.Get_CuocGoi_KetThuc(NRecords,SQLCondition));
                 

                gridCuocGoi_KetThuc.DataMember = "g_lstCuocGoiKetThuc";
                gridCuocGoi_KetThuc.SetDataBinding(g_lstCuocGoiKetThuc, "g_lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                //new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
            }

        }
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
                if ((objDieuHanhTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.BoDam))
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.DienThoai;
                else if (objDieuHanhTaxi.TrangThaiLenh == EFiling.Utils.TrangThaiLenhTaxi.DienThoai)
                    row.Cells["ImageCol"].ImageIndex = (int)TrangThaiLenhTaxi.BoDam;
                    
                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objDieuHanhTaxi.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangVIP)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Blue  ;
                    row.Cells["Line"].FormatStyle = RowStyle;
                }
                else if (objDieuHanhTaxi.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangKhongHieu)
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
                        int SoLuongDangCo = Convert.ToInt32(objDieuHanhTaxi.XeNhan.Length + 1) / 4;                        if (SoLuong > SoLuongDangCo)
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
            if (e.KeyData == Keys.F4 || e.KeyData == Keys.Space)
            {
                gridCuocGoi_KetThuc.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (gridCuocGoi_KetThuc.SelectedItems.Count > 0)
                {

                    DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)((GridEXSelectedItem)gridCuocGoi_KetThuc.SelectedItems[0]).GetRow().DataRow;

                    HienThiFormGoiDienThoai(objDieuHanhTaxi.PhoneNumber, objDieuHanhTaxi.DiaChiDonKhach);

                }

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
                    frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP();
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
                frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP();
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

            else if (e.Command.Key == "cmdKhachBaoHoan")
            {

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
                frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP();
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
                    string Call = "ATDT" + SoDienThoai + Convert.ToChar(13) + Convert.ToChar(11);
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
                                (MethodInvoker)delegate()
                                {
                                    frmCalling.lblSoGoi.Text = "Đang gọi : " + PhoneNumber + " - " + DiaChi;
                                }
                );
                frmCalling.Refresh();
                frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);
            }
        }
        #endregion COM PORT
               
    }
}