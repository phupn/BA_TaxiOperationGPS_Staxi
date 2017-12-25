using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using TaxiCapture.Common;
using Taxi.Utils;
using System.Collections;
using System.Diagnostics;
using Taxi.Business.KhachDat;
using System.Text.RegularExpressions;
using System.Threading;

namespace TaxiCapture
{
    public partial class frmMainUDPThanhNga : Form
    {
        #region Init
        public frmMainUDPThanhNga()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khai bao du lieu toan cu
        /// </summary>
        // Khai bao timer
        private bool g_Thoat = false;
        private System.Timers.Timer timerCapture = null;
        private int g_BlinkIcon = 0;
        long g_iCount = 0;
        private List<StructCuocGoi> g_ListCuocGoiChoXuLy = new List<StructCuocGoi>();
        private Dictionary<string, StructCuocGoi> g_CuocGoiLuuLai = new Dictionary<string, StructCuocGoi>();    // nhung cuoc goi den luu lai, de tim cac cuoc goi lai
        private int g_SoPhutLuuCuocGoi = 30;    // so phut luu lai cuoc goi, neu NOW - ThoiDiemGoi > SoPhutLuuCuocGoi --> Xoa khoi ds
        private bool g_HasSoDauTongDai = false;
        private string g_ConnecString = "";
        private int g_TimerStepGetDatHen = 0;
        private long g_iCountUpdateVOCVoiceFile = 0;  // xuly doc VOC file ghi am
        private int g_iCount_GetCuocGoi = 0;  // xuly doc VOC file ghi am
        private DateTime g_ThoiDiemLayTruocVOC;       // xuly doc VOC file ghi am
        private string g_FileVOCPath = null;
        private int g_iCountXoaCuocTuDong = 0;        // dem xoa tu dong 
        private int g_SoCuocGoiGiuLai = 800;  // So cuộc gọi giữ lại trong trường hợp khách đông.
        string[] g_arrLinesTaxi;
        /// <summary>
        /// mot dictionary luu trang thai so dien thoai cua cac line
        /// </summary>
        private Dictionary<string, CuocGoiUDP> dicCuocGoiUDP = new Dictionary<string, CuocGoiUDP>();

        /// <summary>
        /// dictionary lưu thông tin danh bạ
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicDanhBa = new SynchronizedDictionary<string, DanhBaEx>();

        /// <summary>
        /// Danh ba bưu điện
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicDanhBa_BuuDien = new SynchronizedDictionary<string, DanhBaEx>();

        private SynchronizedDictionary<string, DanhBaEx> dicMoiGioi = new SynchronizedDictionary<string, DanhBaEx>();
        /// <summary>
        /// lưu những cuốc khách online, lấy định kỳ 1 phút một lần.
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicCuocOnline = new SynchronizedDictionary<string, DanhBaEx>();

        private SynchronizedDictionary<string, DanhBaKhachQuen> dicKhachQuen = new SynchronizedDictionary<string, DanhBaKhachQuen>();

        /// <summary>
        /// SDT lái xe - cuốc khách gọi
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicCuocOnline_Driver = new SynchronizedDictionary<string, DanhBaEx>();

        //--------- THÔNG TIN CS------------------------------
        /// <summary>
        /// ds user đang login vi trí CS, 3 phút quét lại một lần
        /// </summary>
        List<CheckInCheckOut> g_ListUserCheckIn = new List<CheckInCheckOut>();  // 
        /// <summary>
        /// ds các line của CS
        /// </summary>
        List<int> g_ListLinesCS = new List<int>();                              // 
        bool g_DangLayUserCheckIn = false;
        int g_CountLayUserCheckIn = 0;
        private DateTime g_ThoiDiemLayTruoc_KhachHang;
        private DateTime g_ThoiDiemLayTruoc_DoiTac;
        private DateTime g_ThoiDiemLayTruoc_CongTy;
        private int count_Sleep = 0;
        //----------------------------------------------------
        private BackgroundWorker bwSync_LoadDanhBaBuuDien = new BackgroundWorker();

        private BackgroundWorker bwSync_LoadDanhBaKhachQuen = new BackgroundWorker();
        BackgroundWorker bw = new BackgroundWorker(); 
        BackgroundWorker bw1 = new BackgroundWorker();
        private bool IsLoadSuccess = false;
        /// <summary>
        /// Số điện thoại bắt ở trạng thái 1
        /// </summary>
        string str_SoDienThoai_TT1 = string.Empty;
        #endregion

        #region ----------------Load form

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (KiemTraPOPUPDangChay())
            {
                MessageBox.Show("Chương trình POPUP đã được chạy. Bạn có thể tắt đi để có thể bắt số bằng UDP.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }
            if (!this.MoCongUDP())
            {
                MessageBox.Show("Cổng UDP có thể sử dụng bởi chương trình khác. Bạn liên hệ với quản trị để được hướng dẫn hoặc có thể khởi động lại hệ thống để thiết lập lại cổng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }
            g_ConnecString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

            this.Init();
        }

        /// <summary>
        /// Khoi tao du lieu luc dau
        /// </summary>
        private void Init()
        {
            count_Sleep++;
            try
            {
                bwSync_LoadDanhBaBuuDien.DoWork += bwSync_LoadDanhBaBuuDien_DoWork;

                bwSync_LoadDanhBaKhachQuen.DoWork += bwSync_LoadDanhBaKhachQuen_DoWork;

                bw.DoWork += new DoWorkEventHandler(bw_DoWorkUpdateVOCVoiceFile);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompletedUpdateVOCVoiceFile);

                bw1.DoWork += new DoWorkEventHandler(bw_DoWorkUpdateNhanVien);
                bw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompletedUpdateNhanVien);

                if (!TaxiCapture.IsServerConnected(g_ConnecString))
                {
                    statusLblServer.Text = "Server: Đang kết nối";
                    Thread.Sleep(2000);
                    Init();
                }
                // Lay thong tin he thong
                ThongTinCauHinh.LayThongTinCauHinh();
                //new LicenseBL().CheckLicense();

                //license.CheckThongTinSDTCongTy(ThongTinCauHinh.SoDienThoaiCongTy.Trim());
                g_ThoiDiemLayTruocVOC = DateTime.Now;
                g_ThoiDiemLayTruoc_KhachHang = DateTime.Now;
                g_ThoiDiemLayTruoc_DoiTac = DateTime.Now;
                g_ThoiDiemLayTruoc_CongTy = DateTime.Now;
                if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0) g_HasSoDauTongDai = true;
                else g_HasSoDauTongDai = false;
                //Fix Connection string
                //g_ConnecString = @"192.168.1.240\sqlexpress;Initial Catalog=Taxi_TienSa;User ID=sa;Password=123@123abc";

                g_SoCuocGoiGiuLai = Configuration.GetSoCuocGoiGiuLai();
                g_SoPhutLuuCuocGoi = TaxiCapture.GetSoPhutLuuCuocGoi();
                g_FileVOCPath = Configuration.VocFilePath();
                //g_FileVOCPath = Configuration.LogIncomingPath();

                if ((!FileTools.IsExsitFile(g_FileVOCPath)) && !Debugger.IsAttached)
                {
                    MessageBox.Show("Không tồn tại file thông tin cuộc gọi.Liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                    return;
                }
                else
                {
                    //if (Configuration.IsCardT4)
                    //{
                    //    TaxiCapture.DeletePhoneCallVocFile_T4(DateTime.Now, g_FileVOCPath);
                    //}
                    //else
                    //{
                    //    //TaxiCapture.DeletePhoneCallVocFile(DateTime.Now, g_FileVOCPath);
                    //}
                }
                // check connection 
                if (!DieuHanhTaxi.CheckConnection())
                {
                    MessageBox.Show("Không kết nối được với cơ sở dữ liệu.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                    return;
                }
                /// end check connection
                timerCapture = new System.Timers.Timer(500); // nửa giây quét một lần.
                timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Elapsed);
                timerCapture.Enabled = true;

                // Thong tin status bar
                statusLblKhoiDongLuc.Text = " Khởi động : " + string.Format("{0:HH:mm dd/MM}", DateTime.Now);
                statusLblSoCuocChoXuLy.Text = " Cuộc chờ xử lý : 0";
                statusLblServer.Text = " Server: " + GetServerName(g_ConnecString);
                statusLblDatabase.Text = " DB: " + GetDatabaseName(g_ConnecString);
                //lấy ds line cấu hình
                g_arrLinesTaxi = ThongTinCauHinh.CacLineCuaTaxiOperation.Split(";".ToCharArray());

                // khởi tạo danh bạ lên mem
                KhoiTaoDanhBaOnMEM();
                // khởi tạo cuốc khách lên mem
                //KhoiTaoCuocKhachOnlineLenMEM();
                g_ListLinesCS = TaxiCapture.GetLineDialOutCS(g_ConnecString);
                g_ListUserCheckIn = TaxiCapture.GetCheckInCS(g_ConnecString);

                Text = Configuration.GetCompanyName();
                count_Sleep = 0;
                WindowState = FormWindowState.Normal;
                IsLoadSuccess = true;
                bwSync_LoadDanhBaBuuDien.RunWorkerAsync();
                bwSync_LoadDanhBaKhachQuen.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Init:" + ex.Message);
                if (count_Sleep >= 5)
                {
                    Application.Exit();
                }
                Thread.Sleep(5000);
                Init();
            }
        }

        /// <summary>
        /// ham lay thong tin db tu connectionstring
        /// Data Source=pccongnt\SQLEXPRESS;Initial Catalog=DBName;User ID=sa ;Password=scongnt
        /// 
        /// </summary>
        /// <param name="ConnecString"></param>
        /// <returns>DBName</returns>
        private string GetDatabaseName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString != null && arrString.Length > 2)
            {
                return arrString[1].Replace("Initial Catalog=", "");
            }
            return "";
        }

        /// <summary>
        /// Lấy tên server
        /// </summary>
        /// <param name="ConnectString"></param>
        /// <returns></returns>
        private string GetServerName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString != null && arrString.Length > 2)
            {
                return arrString[0].Replace("Data Source=", "");
            }
            return "";
        }
        
        private void bwSync_LoadDanhBaBuuDien_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien1();
            }
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien2();
            } 
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien3();
            } 
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien4();
            } 
            Thread.Sleep(1000);
            //if (IsLoadSuccess)
            {
                KhoiTaoDanhBaBuuDien5();
            }
        }

        private void bwSync_LoadDanhBaKhachQuen_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachVip = DanhBaKhachQuen.GetKhachQuens("SELECT *,'''' TypeName,'''' RankName FROM [dbo].[T_DMKHACHHANG] WHERE [IsActive] = 1");
                foreach (var item in lstKhachVip)
                {
                    if (dicKhachQuen.ContainsKey(item.Phones)) continue;
                    dicKhachQuen.Add(item.Phones, item);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwSync_LoadDanhBaKhachQuen_DoWork.", ex);
                return;
            }
        }

        #endregion

        #region ----------------Timer
        /// <summary>
        /// hàm xử lý trong timer
        /// 
        /// Tổ chức.
        ///    - Yêu tiên bắt số 1/2 giấy bắt số gọi đến một lần
        ///    - Số bắt được lưu vào ds cuộc gọi đến
        ///    - Dùng backgroudworker để xác định các cuộc gọi
        ///         - Phân chuông của cuộc gọiđã nghe máy, tính vào lúc đã có được ghi âm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timerCapture_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                try
                {
                    if (g_BlinkIcon == 0)
                    {
                        notifyIcon1.Icon = global::TaxiOperation_Tansonic.Properties.Resources.Taxi;
                        pictureBox1.Image = global::TaxiOperation_Tansonic.Properties.Resources.Taxi.ToBitmap();
                        g_BlinkIcon = 1;
                    }
                    else
                    {
                        notifyIcon1.Icon = global::TaxiOperation_Tansonic.Properties.Resources.TongDai;
                        pictureBox1.Image = global::TaxiOperation_Tansonic.Properties.Resources.TongDai.ToBitmap();
                        g_BlinkIcon = 0;
                    }

                    g_iCount_GetCuocGoi++;
                    if (g_iCount_GetCuocGoi >= 60) // 1 phút
                    {
                        KhoiTaoCuocKhachOnlineLenMEM();
                        g_iCount_GetCuocGoi = 0;
                    }


                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("timerCapture_Elapsed 1.", ex);
                }

                // 2 phut cap nhat thong tin file VOC
                g_iCountUpdateVOCVoiceFile++;
                if (g_iCountUpdateVOCVoiceFile >= 2 * 60 * 2) // 2 phut
                {

                    // lấy lại thông tin cuốc khách online
                    //KhoiTaoCuocKhachOnlineLenMEM(); //sẽ bị chạy 2 lần???
                    if (!bw.IsBusy)
                    {
                        bw.RunWorkerAsync();
                    }
                    g_iCountUpdateVOCVoiceFile = 0;

                }

                //g_CountLayUserCheckIn++;
                //if (g_CountLayUserCheckIn > 3 * 60)    // 3 phút
                //{
                //    g_DangLayUserCheckIn = true;
                //    g_ListUserCheckIn = TaxiCapture.GetCheckInCS(g_ConnecString);
                //    g_DangLayUserCheckIn = false;
                //    g_CountLayUserCheckIn = 0;
                //}
                g_iCountXoaCuocTuDong++;
                if (g_iCountXoaCuocTuDong >= 300) // 5phut)
                {
                    bw1.RunWorkerAsync();

                    if (DateTime.Now.Day <= 1 && DateTime.Now.Hour <= 1 && DateTime.Now.Minute < 20)  // Dau thang van chay lay lai thong tin VOC file
                        g_FileVOCPath = Configuration.VocFilePath();
                    g_iCountXoaCuocTuDong = 0;
                    // XOA THONG TIN LUU XU LY CUOC GOI LAI
                    XoaCuocGoiDaGoiLau();

                    // khoi động lại danh bạ 
                    KhoiTaoDanhBaOnMEM_KhachHang_GetLast(g_ThoiDiemLayTruoc_KhachHang);
                    KhoiTaoDanhBaOnMEM_DoiTac_GetLast(g_ThoiDiemLayTruoc_DoiTac);
                    KhoiTaoDanhBaOnMEM_CongTy_GetLast(g_ThoiDiemLayTruoc_CongTy);
                    if (Global.RemoveCallAuto)
                        new CuocGoi().DeleteCallAuto();
                }

                g_iCount++;
                if (g_iCount >= 120 * 60 * 2)  // 120 phut
                {
                    DeleteNhungCuocDuThua();
                    g_iCount = 0;
                }

                g_TimerStepGetDatHen++;
                if (g_TimerStepGetDatHen >= 120) //--------1 phut thuc hien quet 1 lan
                {
                    CheckAndInsertCuocGoiFromKhachDat();
                    g_TimerStepGetDatHen = 0;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi trong timer.", ex);
            }
        }

        private void bw_DoWorkUpdateNhanVien(object sender, DoWorkEventArgs e)
        {
            //List<DieuHanhTaxi> lstCuocGoiMoiVe = (List<DieuHanhTaxi>)e.Argument;
            //if (lstCuocGoiMoiVe != null && lstCuocGoiMoiVe.Count > 0)
            //{
            //    foreach (DieuHanhTaxi objDH in lstCuocGoiMoiVe)
            //    {
            //        DieuHanhTaxi.Update_BoDam(objDH.MaVung, ThongTinDangNhap.USER_ID);
            //    }
            //}

            // Xoa cac ucoc tu dong khi co khoang thoi gian qua dai
            //if (ThongTinCauHinh.KichHoachTaxiGroupDon)
            //{
            //    if (g_SoCuocGoiGiuLai < 300) g_SoCuocGoiGiuLai = 300; // kiểm tra lại giá trị
            //    DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(g_SoCuocGoiGiuLai);
            //}
            //else
            //    DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(30, ThongTinCauHinh.CacVungTongDai);
            try
            {
                if (Global.RemoveCallAuto)
                    DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(g_SoCuocGoiGiuLai);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("DoWorkUpdateNhanVien.", ex);
                return;
            }
            
        }

        private void bw_RunWorkerCompletedUpdateNhanVien(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi XoaTuDongCacCuocKhachQuaLau  ", new Exception(e.Error.Message));
            }
        }
        #endregion

        #region ----------------Lấy danh bạ đẩy lên Memory
        private void KhoiTaoDanhBaBuuDien1()
        {
            try
            {
                IsLoadSuccess = false;
                lock (dicDanhBa_BuuDien)
                {
                    // lấy ds danh ba buu dien
                    List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                    listDBBuuDien = DanhBa.GetDanhBa_BuuDien_1();
                    // thêm vào dic
                    foreach (DanhBaCongTy dbbd in listDBBuuDien)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                        {
                            dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                        }
                    }
                }
                IsLoadSuccess = true;

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaBuuDien1.", ex);
            }
        }

        private void KhoiTaoDanhBaBuuDien2()
        {
            try
            {
                IsLoadSuccess = false;
                lock (dicDanhBa_BuuDien)
                {
                    // lấy ds danh ba buu dien
                    List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                    listDBBuuDien = DanhBa.GetDanhBa_BuuDien_2();
                    // thêm vào dic
                    foreach (DanhBaCongTy dbbd in listDBBuuDien)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                        {
                            dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                        }
                    }
                }
                IsLoadSuccess = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaBuuDien2.", ex);
            }
        }

        private void KhoiTaoDanhBaBuuDien3()
        {
            try
            {
                IsLoadSuccess = false;
                lock (dicDanhBa_BuuDien)
                {
                    // lấy ds danh ba buu dien
                    List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                    listDBBuuDien = DanhBa.GetDanhBa_BuuDien_3();
                    // thêm vào dic
                    foreach (DanhBaCongTy dbbd in listDBBuuDien)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                        {
                            dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                        }
                    }
                }
                IsLoadSuccess = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaBuuDien3.", ex);
            }
        }

        private void KhoiTaoDanhBaBuuDien4()
        {
            try
            {
                IsLoadSuccess = false;
                lock (dicDanhBa_BuuDien)
                {
                    // lấy ds danh ba buu dien
                    List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                    listDBBuuDien = DanhBa.GetDanhBa_BuuDien_4();
                    // thêm vào dic
                    foreach (DanhBaCongTy dbbd in listDBBuuDien)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                        {
                            dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                        }
                    }
                }
                IsLoadSuccess = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaBuuDien4.", ex);
            }
        }

        private void KhoiTaoDanhBaBuuDien5()
        {
            try
            {
                IsLoadSuccess = false;
                lock (dicDanhBa_BuuDien)
                {
                    // lấy ds danh ba buu dien
                    List<DanhBaCongTy> listDBBuuDien = new List<DanhBaCongTy>();
                    listDBBuuDien = DanhBa.GetDanhBa_BuuDien_5();
                    // thêm vào dic
                    foreach (DanhBaCongTy dbbd in listDBBuuDien)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicDanhBa_BuuDien.ContainsKey(dbbd.PhoneNumber))
                        {
                            dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx() { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                        }
                    }
                }
                IsLoadSuccess = true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaBuuDien5.", ex);
            }
        }

        /// <summary>
        /// Côngnt - 09/07/2013
        /// 
        /// khởi tạo danh bạ trên mem
        /// </summary>
        private void KhoiTaoDanhBaOnMEM()
        {
            try
            {
                dicDanhBa.Clear();
                dicDanhBa_BuuDien.Clear();
                dicMoiGioi.Clear();
                dicKhachQuen.Clear();
                // lấy ds môi giới
                List<DanhBaEx> listDBMoiGioi = DanhBaEx.GetDanhBaMoiGioi();
                // thêm vào dic
                if (dicMoiGioi == null) dicMoiGioi = new SynchronizedDictionary<string, DanhBaEx>();
                foreach (DanhBaEx dbex in listDBMoiGioi)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicMoiGioi.ContainsKey(dbex.PhoneNumber))
                    {
                        dicMoiGioi.Add(dbex.PhoneNumber, dbex);
                    }
                }
                // lấy ds danh ba công ty
                List<DanhBaEx> listDBCongTy = new List<DanhBaEx>();
                listDBCongTy = DanhBaEx.GetDanhBaCongTy();
                // thêm vào dic
                foreach (DanhBaEx dbcty in listDBCongTy)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa.ContainsKey(dbcty.PhoneNumber))
                    {
                        dicDanhBa.Add(dbcty.PhoneNumber, dbcty);
                    }
                }

                // lấy ds danh ba lái xe
                List<DanhBaEx> listDBLaiXe = new List<DanhBaEx>();
                listDBLaiXe = DanhBaEx.GetDanhBaLaiXe();
                // thêm vào dic
                foreach (DanhBaEx item in listDBLaiXe)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa.ContainsKey(item.PhoneNumber))
                    {
                        dicDanhBa.Add(item.PhoneNumber, item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM.", ex);
            }

        }

        /// <summary>
        /// Lấy danh bạ doi tac khi vừa mới bật chương trình
        /// </summary>
        private void KhoiTaoDanhBaOnMEM_DoiTac_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> listDBMoiGioi = DanhBaEx.GetDanhBaMoiGioi_LastUpdate(LastUpdate);
                // thêm vào dic
                if (dicMoiGioi == null) dicMoiGioi = new SynchronizedDictionary<string, DanhBaEx>();
                if (listDBMoiGioi == null || listDBMoiGioi.Count <= 0) return;
                lock (dicMoiGioi)
                {
                    g_ThoiDiemLayTruoc_DoiTac = DateTime.Now;
                    foreach (DanhBaEx dbex in listDBMoiGioi)
                    {
                        // chưa tồn tài thì thêm vào ds
                        if (!dicMoiGioi.ContainsKey(dbex.PhoneNumber))
                        {
                            if (dbex.IsActive)
                                dicMoiGioi.Add(dbex.PhoneNumber, dbex);
                            else
                                dicMoiGioi.Remove(dbex.PhoneNumber);
                        }
                        else
                        {
                            if (dbex.IsActive)
                                dicMoiGioi[dbex.PhoneNumber] = dbex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_DoiTac_GetLast.", ex);
            }
        }

        /// <summary>
        /// Lấy danh bạ cong ty khi vừa mới bật chương trình
        /// </summary>
        private void KhoiTaoDanhBaOnMEM_CongTy_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaEx> listDBCongTy = new List<DanhBaEx>();
                if (dicDanhBa == null) dicDanhBa = new SynchronizedDictionary<string, DanhBaEx>();

                listDBCongTy = DanhBaEx.GetDanhBaCONGTY_GetLast(LastUpdate);
                if (listDBCongTy == null || listDBCongTy.Count <= 0) return;

                g_ThoiDiemLayTruoc_CongTy = DateTime.Now;
                // thêm vào dic
                foreach (DanhBaEx dbcty in listDBCongTy)
                {
                    // chưa tồn tài thì thêm vào ds
                    if (!dicDanhBa.ContainsKey(dbcty.PhoneNumber))
                    {
                        dicDanhBa.Add(dbcty.PhoneNumber, dbcty);
                    }
                    else
                    {
                        dicDanhBa[dbcty.PhoneNumber] = dbcty;
                    }
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_CongTy_GetLast.", ex);
            }
        }

        /// <summary>
        /// Lấy danh bạ những khách hàng vừa mới thay đổi
        /// </summary>
        private void KhoiTaoDanhBaOnMEM_KhachHang_GetLast(DateTime LastUpdate)
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachVip = DanhBaKhachQuen.GetKhachQuens_LastUpdate(LastUpdate);
                if (lstKhachVip != null && lstKhachVip.Count > 0)
                {
                    g_ThoiDiemLayTruoc_KhachHang = DateTime.Now;
                    foreach (var item in lstKhachVip)
                    {
                        if (dicKhachQuen.ContainsKey(item.Phones))
                        {
                            dicKhachQuen[item.Phones] = item;
                        }
                        else
                        {
                            dicKhachQuen.Add(item.Phones, item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_KhachHang_GetLast.", ex);
            }
        }

        /// <summary>
        /// congnt - 09/07/2013
        /// 
        /// khởi tạo cuốc khách lên mem
        /// cuốc khách sẽ được cập nhật 1 phút một lần.
        /// </summary>
        private void KhoiTaoCuocKhachOnlineLenMEM()
        {
            try
            {
                // lấy ds cuốc khách online
                dicCuocOnline.Clear();
                dicCuocOnline = TaxiCapture.GetCuocOnlines_v2(g_ConnecString, out dicCuocOnline_Driver);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoDanhBaOnMEM_KhachHang_GetLast.", ex);
            }
        }

        /// <summary>
        /// hàm thực hiện lấy 
        /// </summary>
        /// <param name="soDienThoai"></param>
        /// <param name="diaChi"></param>
        /// <param name="vung"></param>
        /// <param name="?"></param>
        private void GetDiaChiTuMEM(string soDienThoai, out KieuKhachHangGoiDen kieuKhachHang, out string diaChi, out int vung,
                                    out string maDoiTac, out string loaiXe, out string ghichuDT, out string ghichuTD, out bool isCuocGoiLai
            , out string xeNhan, out Guid bookID, out long IdCuocGoi, out int soLanGoiLai)
        {
            diaChi = string.Empty;
            vung = 0;
            maDoiTac = string.Empty;
            loaiXe = string.Empty;
            ghichuDT = string.Empty;
            ghichuTD = string.Empty;
            xeNhan = string.Empty;
            bookID = Guid.Empty;
            kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
            isCuocGoiLai = false;
            IdCuocGoi = 0;
            soLanGoiLai = 0;
            try
            {
                if (chkGhiLogForDebug.Checked)
                {
                    LogError.WriteLogErrorForDebug(string.Format("GetDiaChiTuMEM:'-{0}'", soDienThoai));
                }
                //Lấy theo sdt lái xe đang đón cuốc khách điều app
                if (dicCuocOnline_Driver != null)
                {
                    if (dicCuocOnline_Driver.ContainsKey(soDienThoai))
                    {
                        DanhBaEx item = dicCuocOnline_Driver[soDienThoai];
                        diaChi = string.Format("LX{0}-{1}", item.XeNhan, item.TenLaiXe);
                        //vung = item.Vung;
                        maDoiTac = item.MaDoiTac;
                        ghichuDT = string.Format("{0}--{1}", item.Address, item.GhiChuDienThoai);
                        ghichuTD = item.GhiChuTongDai;
                        kieuKhachHang = item.KieuKhachHang;
                        loaiXe = item.LoaiXe;
                        xeNhan = item.XeNhan;
                        bookID = item.BookId;
                        IdCuocGoi = item.IdCuocGoi;
                        soLanGoiLai = item.SoLanGoi;
                        isCuocGoiLai = true;
                        //if (g_Debug)
                        //{
                        //    LogError.WriteLogErrorForDebug(string.Format("CuocOnline:'-{0}'-{1}-{2}", item.PhoneNumber, item.Address, item.BookId));
                        //}
                        return;
                    }
                }
                // lấy theo Moi giới
                if (dicMoiGioi.ContainsKey(soDienThoai))
                {
                    diaChi = dicMoiGioi[soDienThoai].Address;
                    //vung = dicDanhBa[soDienThoai].Vung;
                    maDoiTac = dicMoiGioi[soDienThoai].MaDoiTac;

                    if (dicMoiGioi[soDienThoai].KieuDanhBa == KieuDanhBa.MoiGioi)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                    else if (dicMoiGioi[soDienThoai].KieuDanhBa == KieuDanhBa.CongTy)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    return;
                }
                // lấy từ cuốc online 
                if (dicCuocOnline != null && dicCuocOnline.ContainsKey(soDienThoai))
                {
                    DanhBaEx item = dicCuocOnline[soDienThoai];
                    diaChi = item.Address;
                    //vung = dicCuocOnline[soDienThoai].Vung;
                    maDoiTac = item.MaDoiTac;
                    ghichuDT = item.GhiChuDienThoai;
                    ghichuTD = item.GhiChuTongDai;

                    loaiXe = item.LoaiXe;
                    kieuKhachHang = item.KieuKhachHang;
                    loaiXe = item.LoaiXe;
                    xeNhan = item.XeNhan;
                    bookID = item.BookId;
                    isCuocGoiLai = true;
                    return;
                }
                // lấy theo danh bạ
                if (dicDanhBa != null && dicDanhBa.ContainsKey(soDienThoai))
                {
                    DanhBaEx objDanhBa = dicDanhBa[soDienThoai];
                    diaChi = objDanhBa.Address;
                    //vung = dicDanhBa[soDienThoai].Vung;
                    maDoiTac = objDanhBa.MaDoiTac;

                    if (objDanhBa.KieuDanhBa == KieuDanhBa.MoiGioi)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                    else if (objDanhBa.KieuDanhBa == KieuDanhBa.CongTy || objDanhBa.KieuDanhBa == KieuDanhBa.BuuDien)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    return;
                }
                if (dicKhachQuen.ContainsKey(soDienThoai))
                {
                    DanhBaKhachQuen objKhachQuen = dicKhachQuen[soDienThoai];

                    diaChi = objKhachQuen.Address;
                    if (objKhachQuen.Name != null && objKhachQuen.Name != "")
                        diaChi = String.Format("[{0}]{1}", objKhachQuen.Name, objKhachQuen.Address);

                    vung = 2;
                    maDoiTac = objKhachQuen.MaKH;

                    if (objKhachQuen.Type == 1)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangVIP;
                    else if (objKhachQuen.Type == 2)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    else if (objKhachQuen.Type == 3)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    return;
                }
                if (soDienThoai.StartsWith("04"))
                {
                    //Nếu là số điện thoại bàn ở HN thì mới check trong danh mục Bưu Điện.
                    if (dicDanhBa_BuuDien.ContainsKey(soDienThoai))
                    {
                        DanhBaEx objDanhBa = dicDanhBa_BuuDien[soDienThoai];
                        diaChi = objDanhBa.Address;
                        if (dicDanhBa_BuuDien[soDienThoai].Name != "")
                            diaChi = string.Format("[{0}]{1}", dicDanhBa_BuuDien[soDienThoai].Name, diaChi);

                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDiaChiTuMEM.", ex);
            }
        }

        #endregion Lấy danh bạ đẩy lên Memory

        #region ----------------Update VOC

        /// <summary>
        /// Ham lay ds VOC va cap nhat file ghi am
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWorkUpdateVOCVoiceFile(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime temp = DateTime.Now;
                ThucHienLayFileGhiAm(g_ThoiDiemLayTruocVOC, temp, g_FileVOCPath);
                g_ThoiDiemLayTruocVOC = temp.AddMinutes(-1); //Vớt thêm những cuốc chèn dữ liệu ghi âm muộn
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bw_DoWorkUpdateVOCVoiceFile.", ex);
            }
        }

        private void bw_RunWorkerCompletedUpdateVOCVoiceFile(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi bw_DoWorkUpdateVOCVoiceFile  ", new Exception(e.Error.Message));
            }

        }

        /// <summary>
        /// Hamf thuc hien lay file ghi am tu thoi diem ThoiDiemLayTruoc toi bay gio
        /// </summary>
        /// <param name=" "></param>
        private void ThucHienLayFileGhiAm(DateTime TuThoiDiem, DateTime DenThoiDiem, string VOCFilenamePath)
        {
            try
            {
                // Lay VOC file 
                List<VOC> lstVOC = new List<VOC>();
                if (Configuration.IsCardT4)
                {
                    lstVOC = TaxiCapture.GetThongTinCuocGoiTrongVOC_T4(TuThoiDiem, DenThoiDiem, VOCFilenamePath);
                }
                else
                {
                    lstVOC = TaxiCapture.GetThongTinCuocGoiTrongVOC(TuThoiDiem, DenThoiDiem, VOCFilenamePath);
                }
                if (lstVOC != null && lstVOC.Count > 0)
                {
                    foreach (VOC objVoc in lstVOC)
                    {
                        if (chkGhiLogForDebug.Checked)
                        {
                            LogError.WriteLogErrorForDebug("objVoc: " + objVoc.Code + "-" + objVoc.StartTime.ToLongDateString() + "-" + objVoc.Fomin + "-" + objVoc.FilePath);
                        }
                        TaxiCapture.InsertVOC(objVoc, this.g_ConnecString);
                        // LogError.WriteLogError(string.Format("VOC : line {0}, phone : {1}, thoidiem : {2:HH:mm:ss dd/MM},Foming : {3}, file : {4} ", objVoc.Channel, objVoc.Code, objVoc.StartTime,objVoc.Fomin,objVoc.FilePath), new Exception(""));

                    }
                }
                if (chkGhiLogForDebug.Checked)
                {
                    LogError.WriteLogErrorForDebug("ThucHienLayFileGhiAm lstVOC" + lstVOC.Count + "-" + TuThoiDiem.ToLongTimeString() + "-" + DenThoiDiem.ToLongTimeString() + "-" + VOCFilenamePath);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ThucHienLayFileGhiAm :", ex);
            }
        }
        #endregion

        #region ----------------Khách đặt hẹn
        private void CheckAndInsertCuocGoiFromKhachDat()
        {
            try
            {
                using (BackgroundWorker bwKhachDat = new BackgroundWorker())
                {
                    bwKhachDat.DoWork += bwKhachDat_DoWork;
                    bwKhachDat.RunWorkerCompleted += bwKhachDat_RunWorkerCompleted;
                    // Kick off the Async thread
                    bwKhachDat.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi  CheckAndInsertCuocGoiFromKhachDat", new Exception("CheckAndInsertCuocGoiFromKhachDat"));
            }
        }

        private void bwKhachDat_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime CurrDate = DateTime.Now;
            List<KhachDatBL> lstKhachDat = new KhachDatBL().GetKhachDat_ChenCuocGoi(CurrDate);
            if (lstKhachDat == null || lstKhachDat.Count <= 0)
                return;

            lstKhachDat.ForEach(InsertCuocGoiKhachDat);
        }

        private void bwKhachDat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                LogError.WriteLogError("Khach Dat : BackgroundWorker Canceled", new Exception("Canceled"));
            }

            else if (!(e.Error == null))
            {
                LogError.WriteLogError("Khach Dat : BackgroundWorker (" + e.Error.Message + ")", new Exception("Error BackgroundWorker"));
            }
        }

        /// <summary>
        /// Insert Cuoc Goi tu Khach Dat Hen
        /// </summary>
        /// <param name="KhachDat"></param>
        private void InsertCuocGoiKhachDat(KhachDatBL KhachDat)
        {
            try
            {
                //đặt  line là 99 để thông nhất là line khách đặt
                TaxiCapture.InsertCuocGoiLanDau_KhachDat(g_ConnecString, 99, KhachDat.VungKenh, KhachDat.SoDienThoai, DateTime.Now, KhachDat.DiaChi, KhachDat.GhiChu, KhachDat.LoaiXe, KhachDat.SoLuongXe, KhachDat.PK_KhachDatID, KhachDat.KinhDo, KhachDat.ViDo);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi  InsertCuocGoiKhachDat", new Exception("InsertCuocGoiKhachDat"));
            }
        }

        #endregion-----------------------------------------------------------

        #region ----------------Capture UDP-Insert Cuộc gọi

        /// <summary>
        /// ham kiem tra Popup con dang chay hay khong
        /// </summary>
        /// <returns></returns>
        private bool KiemTraPOPUPDangChay()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToLower() == "popup")
                    return true;
            }

            return false;
        }

        /// <summary>
        /// ham mo cong UDP
        /// </summary>
        /// <returns></returns>
        private bool MoCongUDP()
        {
            try
            {
                axtxUDP1.UDPConnect();
                return true;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi mo cong UDP ", ex);
                return false;

            }
        }

        /// <summary>
        /// ham su kien co du lieu gui ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axtxUDP1_UDPdata(object sender, AxtxUDPOCX.__txUDP_UDPdataEvent e)
        {
            if (e.bytesTotal != null && e.bytesTotal.Length > 0)
            {
                string sUDP = StringTools.RemoveSpace(e.bytesTotal);
                if (sUDP.Length > 0)
                {
                    XuLyDuLieuUDP(sUDP);
                }
            }
        }

        /// <summary>
        /// INPUT : 
        ///      txIP,0436425008,,02,1,End      
        /// OUPPUT :
        ///      Goi den, bat mat, cup may, am thanh
        /// </summary>
        /// <param name="bytesTotal"></param>
        private void XuLyDuLieuUDP(string bytesTotal)
        {
            BackgroundWorker bwXuLyDuLieuUDP = new BackgroundWorker();
            bwXuLyDuLieuUDP.DoWork += new DoWorkEventHandler(bwXuLyDuLieuUDP_DoWorkProcessStaus3);
            bwXuLyDuLieuUDP.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwXuLyDuLieuUDP_RunWorkerCompleted);

            bwXuLyDuLieuUDP.RunWorkerAsync(bytesTotal);
        }
        
        /// <summary>
        /// ham thuc hien xu ly cac cuoc goi tu UDP, xu ly thuan trang thai 1, 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bwXuLyDuLieuUDP_DoWorkProcessStaus3(object sender, DoWorkEventArgs e)
        {
            try
            {
                //txIP,01698390011 ,,3,1,End
                //T4 : txIP,01278939393 ,,7,5,End
                string soDacBiet = "0111111111";
                bool isGetAddress = true;
                string strUDP = (string)e.Argument; //txIP,0436425008,,02,1,End  

                if (chkGhiLogForDebug.Checked)
                    LogError.WriteLogErrorForDebug(strUDP);


                string[] arrUDP = strUDP.Split(",".ToCharArray());

                if (arrUDP != null && arrUDP.Length != 6) return;

                string soDienThoaiRaw = string.Empty;
                string SoDienThoai = arrUDP[1].Trim();
                if (SoDienThoai.Length <= 5)
                {
                    return;
                }
                // giữ số điện thoại nguyên thủy không chỉnh sửa gì
                soDienThoaiRaw = SoDienThoai;
                SoDienThoai = StringTools.GetSoDienThoaiChuan(soDienThoaiRaw, soDacBiet, Configuration.GetDauSoGoiDi).Trim();
                
                string Line = StringTools.RemoveSoKhongODau(arrUDP[3]);
                //có thể gặp trường hợp ko lấy được line. Sẽ gán cuộc gọi vào line 1
                int line = 1;
                int.TryParse(Line, out line);

                if (!TaxiCapture.IsLineOfTaxiOperation(Line, g_arrLinesTaxi)) return;

                byte TrangThai = Convert.ToByte(arrUDP[4]);
                DateTime ThoiDiem = DateTime.Now;

                string CDRfile = "";
                switch (TrangThai)
                {
                    case 1: // Goi Den   - Lưu tạm trên MEM
                        if (g_ListCuocGoiChoXuLy == null)
                            g_ListCuocGoiChoXuLy = new List<StructCuocGoi>();

                        try
                        {
                            if (SoDienThoai == soDacBiet || SoDienThoai == ThongTinCauHinh.SoDienThoaiCongTy)
                                isGetAddress = false;
                            if (Configuration.TrangThaiBatSo == 1)
                            {
                                //str_SoDienThoai_TT1 = SoDienThoai;
                                long callID = -1;
                                callID = ProcessInsertCall(SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile);
                                
                                if(callID <= 0)
                                {
                                    callID = ProcessInsertCall(SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile);
                                    LogError.WriteLogError(string.Format("State 1 : Không chèn được firstcall: {0}{1}{2}{3}{4}", SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile), new Exception("")) ;    // không chèn mới được vào db thì thoát
                                    return;
                                }
                                else
                                {
                                    lblGoiDen.Invoke((MethodInvoker)delegate()
                                    {
                                        lblGoiDen.Text = "Gọi đến : " + Line + " - " + SoDienThoai + " - [" + g_CuocGoiLuuLai.Count.ToString() + "]";
                                    });
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError(" UDP Trang thai 1 :  " + e.Argument.ToString(), ex);
                        }
                        break;
                    case 2: // Goi di
                        #region Cuoc Goi Di

                        // Nhận cuốc gọi đi
                        // Lấy danh sách những nhận viên đang đăng nhập (3 phút cập nhật một lần)
                        // Tìm nhân viên 

                        VOC voc = new VOC();
                        voc.Channel = int.Parse(Line);
                        voc.StartTime = ThoiDiem;
                        voc.Duration = new DateTime(1900, 1, 1, 0, 0, 1);
                        voc.FilePath = "";
                        voc.Fomin = "DialOut";
                        voc.Code = SoDienThoai;

                        string userName = string.Empty;
                        if (!g_DangLayUserCheckIn)   // neu dang lay thong tin user checkIn thi khong thực hiện (3 phút lấy một lần)
                        {
                            userName = TaxiCapture.GetUserOnline(g_ListUserCheckIn, voc.Channel.ToString());
                        }
                        TaxiCapture.InsertCuocGoiDi(g_ConnecString, voc, userName, g_ListLinesCS.Contains(voc.Channel));

                        //lblGoiDi.Invoke(
                        //    (MethodInvoker)delegate()
                        //    {
                        //        lblGoiDi.Text = string.Format("{0:HH:mm:ss dd/MM} : {1}-{2}", voc.StartTime, voc.Channel, voc.Code);
                        //    }
                        //    );

                        #endregion
                        break;
                    case 3: // Bốc máy   - Chen database , luu lai
                        #region Goi Den (Trang thai nhac may)

                        //if (chkGhiLogForDebug.Checked)
                        //    LogError.WriteLogErrorForDebug(String.Format(" Bốc máy :  {0}", strUDP));
                        if (g_ListCuocGoiChoXuLy != null)
                        {
                            try
                            {
                                StructCuocGoi objCuocGoiMoi = new StructCuocGoi();               
                                //if (iIndexRemove >= 0)
                                {
                                    //lock (g_ListCuocGoiChoXuLy)
                                    {
                                        #region bắt số ở Trạng thái 3
                                        
                                        if (Configuration.TrangThaiBatSo == 3)
                                        {
                                            long callID = -1;
                                            callID = ProcessInsertCall(SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile);

                                            if (callID <= 0)
                                            {
                                                callID = ProcessInsertCall(SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile);
                                                LogError.WriteLogError(string.Format("State 3 : Không chèn được firstcall: {0}{1}{2}{3}{4}", SoDienThoai, line.ToString(), ThoiDiem, soDienThoaiRaw, CDRfile), new Exception(""));    // không chèn mới được vào db thì thoát
                                                return;
                                            }
                                            else
                                            {
                                                lblGoiDen.Invoke((MethodInvoker)delegate()
                                                {
                                                    lblGoiDen.Text = "Gọi đến: " + Line + " - " + SoDienThoai + " - [" + g_CuocGoiLuuLai.Count.ToString() + "]";
                                                });
                                            }
                                        }
                                        #endregion
                                        try
                                        {
                                            if (g_ListCuocGoiChoXuLy.Count > 0)
                                            {
                                                int iIndexRemove = -1;
                                                for (int i = 0; i < g_ListCuocGoiChoXuLy.Count; i++)
                                                {
                                                    if (g_ListCuocGoiChoXuLy[i].Line == Line && g_ListCuocGoiChoXuLy[i].PhoneNumber == SoDienThoai) // trong ds co so dien thoai trung voi so line
                                                    {
                                                        iIndexRemove = i;

                                                        break;
                                                    }
                                                }
                                                if (iIndexRemove >= 0)
                                                {
                                                    objCuocGoiMoi = g_ListCuocGoiChoXuLy[iIndexRemove];

                                                }
                                                //if (Configuration.TrangThaiBatSo == 1)
                                                //{
                                                //    //Nếu Hiển thị popup ở trạng thái 1
                                                //    //Nếu số điện thoại ở trạng thái 1 bị sai thì lấy sdt ở trạng thái 3 update lại
                                                //    if (!str_SoDienThoai_TT1.Equals(SoDienThoai))
                                                //    {
                                                //        TaxiCapture.Update_Lai_SoDienThoai(g_ConnecString, objCuocGoiMoi.CuocGoiID, SoDienThoai);
                                                //    }
                                                //}
                                                objCuocGoiMoi.ThoiDiemNgheMay = ThoiDiem;
                                                g_ListCuocGoiChoXuLy[iIndexRemove] = objCuocGoiMoi;
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            LogError.WriteLogError("ThoiDiemNgheMay :  ", ex);
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError(" UDP Trang thai 3 :  " + e.Argument.ToString(), ex);
                            }
                        }

                        #endregion
                        break;

                    case 4:   // Ket thuc cuoc goi - tao file ghi am txIP,D:\GhiAm\TxRec\REC201101\20110101\02--A-0436425008---20110101111048.wav,,02,6,End  
                        #region

                        if (g_ListCuocGoiChoXuLy != null && g_ListCuocGoiChoXuLy.Count > 0)
                        {
                            try
                            {
                                int iIndexRemove = -1;
                                for (int i = 0; i < g_ListCuocGoiChoXuLy.Count; i++)
                                {
                                    if (g_ListCuocGoiChoXuLy[i].Line == Line) // trong ds co so dien thoai trung voi so line
                                    {
                                        iIndexRemove = i;
                                        break;
                                    }
                                }
                                if (iIndexRemove >= 0)
                                {
                                    lock (g_ListCuocGoiChoXuLy)
                                    {
                                        StructCuocGoi objCuocGio = g_ListCuocGoiChoXuLy[iIndexRemove];
                                        //objCuocGio.fileAmThanhPath = SoDienThoai; 
                                        TimeSpan timeSpan = ThoiDiem - objCuocGio.ThoiDiemNgheMay;
                                        if (timeSpan.Hours >= 0 && timeSpan.Hours <= 23 && timeSpan.Minutes >= 0 && timeSpan.Minutes <= 59 && timeSpan.Seconds >= 0 && timeSpan.Seconds <= 59)

                                            objCuocGio.KhoangThoiGianHoiThoai = new DateTime(1900, 1, 1, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                                        else
                                            objCuocGio.KhoangThoiGianHoiThoai = new DateTime(1900, 1, 1, 0, 0, 1);
                                        g_ListCuocGoiChoXuLy[iIndexRemove] = objCuocGio;
                                                                            
                                        int soChuong = GetSoChuong(g_ListCuocGoiChoXuLy[iIndexRemove].ThoiDiemGoiDen, g_ListCuocGoiChoXuLy[iIndexRemove].ThoiDiemNgheMay);
                                        if (chkGhiLogForDebug.Checked)
                                            LogError.WriteLogErrorForDebug(String.Format(" Cúp máy :  {0} - {1}- {2}", soDienThoaiRaw, soChuong, g_ListCuocGoiChoXuLy[iIndexRemove].KhoangThoiGianHoiThoai));
                                        // Update database - 
                                        ///Capnhat DB  - Duration , FileAmThanh, so chuong
                                        TaxiCapture.Update_DienThoai_KetThucCuocGoiDenCoBatMay(g_ConnecString, g_ListCuocGoiChoXuLy[iIndexRemove].CuocGoiID, soChuong, g_ListCuocGoiChoXuLy[iIndexRemove].KhoangThoiGianHoiThoai, g_ListCuocGoiChoXuLy[iIndexRemove].fileAmThanhPath, TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh, TrangThaiLenhTaxi.KhongTruyenDi);
                                        //{
                                        //    LogError.WriteLogError("Loi luu xuong DB cuoc goi ket thuc - update thong tin cuoc goi case TrangThai(6) ", new Exception("Loi luu cuoc goi da Bat May"));
                                        //}
                                        // Xoa bo iIndexRemove 
                                        g_ListCuocGoiChoXuLy.RemoveAt(iIndexRemove);

                                        //if (g_ListCuocGoiChoXuLy != null)
                                        //    statusLblSoCuocChoXuLy.Text = "Đang thoại : " + g_ListCuocGoiChoXuLy.Count.ToString();
                                    }


                                }

                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError(" UDP Trang thai 6 :  " + e.Argument.ToString(), ex);
                            }
                        }
                        #endregion
                        break;
                    case 5:   // khong nhac may - goi nho
                        #region
                        if (g_ListCuocGoiChoXuLy != null && g_ListCuocGoiChoXuLy.Count > 0)
                        {
                            try
                            {
                                if (chkGhiLogForDebug.Checked)
                                    LogError.WriteLogErrorForDebug(String.Format(" Không nhấc máy :  {0}", strUDP));

                                int iIndexRemove = -1;
                                for (int i = 0; i < g_ListCuocGoiChoXuLy.Count; i++)
                                {
                                    if (g_ListCuocGoiChoXuLy[i].Line == Line && g_ListCuocGoiChoXuLy[i].PhoneNumber == SoDienThoai) // trong ds co so dien thoai trung voi so line
                                    {
                                        iIndexRemove = i;
                                        break;
                                    }
                                }
                                if (iIndexRemove >= 0)
                                {
                                    lock (g_ListCuocGoiChoXuLy)
                                    {
                                        StructCuocGoi objCuocGio = g_ListCuocGoiChoXuLy[iIndexRemove];
                                        objCuocGio.ThoiDiemKhongNhacMay = ThoiDiem;
                                        g_ListCuocGoiChoXuLy[iIndexRemove] = objCuocGio;
                                        int soChuong = GetSoChuong(g_ListCuocGoiChoXuLy[iIndexRemove].ThoiDiemGoiDen, ThoiDiem);
                                        string maDoiTac = "";
                                    
                                        try
                                        {
                                            TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM_GoiNho_SoChuong(this.g_ConnecString, objCuocGio.Line, objCuocGio.PhoneNumber, objCuocGio.ThoiDiemGoiDen, objCuocGio.kieuKhachHangGoiDen, maDoiTac, objCuocGio.SoLanGoiLaiGanDay, soChuong);

                                            // Xoa bo iIndexRemove 
                                            g_ListCuocGoiChoXuLy.RemoveAt(iIndexRemove);
                                            if (g_ListCuocGoiChoXuLy != null)
                                                statusLblSoCuocChoXuLy.Text = String.Format("Đang thoại :  : {0}", g_ListCuocGoiChoXuLy.Count);

                                        }
                                        catch (Exception)
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError(" UDP Trang thai 5 :  " + e.Argument.ToString(), ex);
                            }


                        }
                        #endregion
                        break;
                }
            }
            catch (Exception ext)
            {
                LogError.WriteLogError(" UDP bw :  " + e.Argument.ToString(), ext);
            }
        }


        /// <summary>
        /// Hàm xử lý Insert cuộc gọi cho PDH
        /// </summary>
        private long ProcessInsertCall(string SoDienThoai, string Line, DateTime ThoiDiem, string PhoneNumberRaw, string CDRfile)
        {
            try
            {
                #region Get Address
                // lấy các thông số dịa chi từ Mem
                int vung = 0;
                string diaChi = string.Empty;
                KieuKhachHangGoiDen kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                string maDoiTac = string.Empty;
                string LoaiXe = string.Empty;
                string GhiChuDT = string.Empty;
                string GhiChuTD = string.Empty;
                string xeNhan = string.Empty;
                Guid bookID = Guid.Empty;
                bool isCuocGoiLai = false;
                long idCuocGoi = 0;
                int SoLanGoi = 0;
                float kinhdo = 0;
                float vido = 0;
                int g5_CarType = 0;
                StructCuocGoi objCuocGoiMoi = new StructCuocGoi();
                objCuocGoiMoi.Line = Line;
                objCuocGoiMoi.PhoneNumber = SoDienThoai.Trim();
                objCuocGoiMoi.ThoiDiemGoiDen = ThoiDiem;
                objCuocGoiMoi.KieuCuocGoi = TypeCall.Incoming;
                objCuocGoiMoi.fileAmThanhPath = CDRfile;
                string IsSanBayDuongDai = "0";
                // lấy địa chỉ từ MEM            
                {
                    #region Lấy thông tin cuộc gọi trong DB trước (bảng chưa kết thúc)

                    DanhBaEx objDanhBa = new DanhBaEx();
                    //if(!g_CuocGoiLuuLai.ContainsKey(SoDienThoai))
                        objDanhBa =TaxiCapture.GetCuocOnlines_ByID_PhoneNumber(g_ConnecString, objCuocGoiMoi.CuocGoiLaiID, SoDienThoai);
                    if (objDanhBa != null && objDanhBa.Address != "")
                    {
                        diaChi = objDanhBa.Address;
                        vung = objDanhBa.Vung;
                        maDoiTac = objDanhBa.MaDoiTac;
                        LoaiXe = objDanhBa.LoaiXe;
                        GhiChuDT = objDanhBa.GhiChuDienThoai;
                        GhiChuTD = objDanhBa.GhiChuTongDai;
                        xeNhan = objDanhBa.XeNhan;
                        bookID = objDanhBa.BookId;
                        kinhdo = objDanhBa.GPS_KinhDo;
                        vido = objDanhBa.GPS_ViDo;
                        g5_CarType = objDanhBa.G5_CarType;

                        objCuocGoiMoi.CuocGoiLaiID = objDanhBa.IdCuocGoi;

                        byte.TryParse((objDanhBa.SoLanGoi + 1).ToString(), out objCuocGoiMoi.SoLanGoiLaiGanDay);

                        if (objDanhBa.MaDoiTac == string.Empty)
                            kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                        else
                            kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                        DateTime ThoiDiemGoiLai = objDanhBa.ThoiDiemGoi;
                        double sophut = (ThoiDiem - ThoiDiemGoiLai).TotalMinutes;
                        if (sophut > 0 && ThoiDiemGoiLai > DateTime.MinValue)
                        {
                            objCuocGoiMoi.ThoiGianGoiLai = Math.Round((ThoiDiem - ThoiDiemGoiLai).TotalMinutes, 1).ToString() + " phút";
                        }
                    }
                    #endregion

                    else
                    {
                        GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac,
                            out LoaiXe, out GhiChuDT, out GhiChuTD, out isCuocGoiLai, out xeNhan, out bookID,
                            out idCuocGoi, out SoLanGoi);

                        long IDCuocGoiLai = 0;
                        DateTime ThoiDiemGoiLai = DateTime.MinValue;
                        objCuocGoiMoi.SoLanGoiLaiGanDay = GetSoLanGoiLai(SoDienThoai, out IDCuocGoiLai, out ThoiDiemGoiLai);
                        if (IDCuocGoiLai == 0 && idCuocGoi > 0)
                        {
                            IDCuocGoiLai = idCuocGoi;
                            byte.TryParse((SoLanGoi + 1).ToString(), out objCuocGoiMoi.SoLanGoiLaiGanDay);
                        }
                        if (IDCuocGoiLai > 0)
                        {
                            objCuocGoiMoi.CuocGoiLaiID = IDCuocGoiLai;
                            double sophut = (ThoiDiem - ThoiDiemGoiLai).TotalMinutes;
                            //Thêm 1 bước check lại số phút gọi lại cho chắc. vì có thể cuốc đó chưa xóa khỏi MEM dc.
                            if (sophut > 0 && ThoiDiemGoiLai > DateTime.MinValue)// && sophut <= g_SoPhutLuuCuocGoi)
                            {
                                objCuocGoiMoi.ThoiGianGoiLai = Math.Round(sophut, 1).ToString() + " phút";
                            }
                            else
                            {
                                //objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                //if (g_CuocGoiLuuLai.ContainsKey(SoDienThoai))
                                //    g_CuocGoiLuuLai.Remove(SoDienThoai);
                            }
                        }
                        else
                        {
                            objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                        }

                        //Nếu không lấy được địa chỉ từ MEM thì lấy từ database
                        //Vì có thể tại thời điểm này MEM đang lấy dữ liệu cuộc gọi
                        if (objCuocGoiMoi.CuocGoiLaiID > 0)
                        {
                            objCuocGoiMoi.KieuCuocGoi = TypeCall.Incoming;

                            if (diaChi == "" || idCuocGoi <= 0)
                            {
                                //GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac, out LoaiXe);
                                DanhBaEx objDanhBa2 = TaxiCapture.GetCuocOnlines_ByID(g_ConnecString, objCuocGoiMoi.CuocGoiLaiID);
                                if (!string.IsNullOrEmpty(objDanhBa2.Address))
                                {
                                    if (objDanhBa2.MaDoiTac == string.Empty)
                                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                                    else
                                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                                    diaChi = objDanhBa2.Address;
                                    vung = objDanhBa2.Vung;
                                    maDoiTac = objDanhBa2.MaDoiTac;
                                    LoaiXe = objDanhBa2.LoaiXe;
                                    GhiChuDT = objDanhBa2.GhiChuDienThoai;
                                    GhiChuTD = objDanhBa2.GhiChuTongDai;
                                    xeNhan = objDanhBa2.XeNhan;
                                    bookID = objDanhBa2.BookId;
                                    byte.TryParse((objDanhBa2.SoLanGoi + 1).ToString(), out objCuocGoiMoi.SoLanGoiLaiGanDay);
                                }
                                else
                                {
                                    objCuocGoiMoi.CuocGoiLaiID = 0;
                                    objCuocGoiMoi.ThoiGianGoiLai = "";
                                    objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                }
                            }
                            else if (diaChi != "" && !isCuocGoiLai)
                            {
                                objCuocGoiMoi.CuocGoiLaiID = 0;
                                //objCuocGoiMoi.ThoiGianGoiLai = "";
                                objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                            }
                        }
                    }
                }

                // kiem tra nhung so dien thoai la so dau khong phai la 01,09,04
                //objCuocGoiMoi.PhoneNumber = DatLaiSoDienThoaiSai(objCuocGoiMoi.PhoneNumber, soDacBiet);
                objCuocGoiMoi.LoaiXe = LoaiXe;
                objCuocGoiMoi.GhiChuDT = GhiChuDT;
                objCuocGoiMoi.GhiChuTD = GhiChuTD;
                objCuocGoiMoi.GPS_KinhDo = kinhdo;
                objCuocGoiMoi.GPS_ViDo = vido;
                objCuocGoiMoi.G5_CarType = g5_CarType;
                //if (g_Debug)
                //{
                //    LogError.WriteLogErrorForDebug(string.Format("ProcessInsertCall : -{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}",
                //                                            objCuocGoiMoi.Line,
                //                                            objCuocGoiMoi.PhoneNumber,
                //                                            objCuocGoiMoi.ThoiDiemGoiDen,
                //                                            diaChi,
                //                                            ((int)(KieuKhachHangGoiDen)kieuKhachHang).ToString(),
                //                                            maDoiTac,
                //                                            vung,
                //                                            objCuocGoiMoi.SoLanGoiLaiGanDay,
                //                                            objCuocGoiMoi.LoaiXe,
                //                                            objCuocGoiMoi.ThoiGianGoiLai,
                //                                            objCuocGoiMoi.Line,
                //                                            PhoneNumberRaw
                //                                            ));
                //}
                #endregion

                objCuocGoiMoi.CuocGoiID = TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM_V8(g_ConnecString, objCuocGoiMoi.Line,
                                                                                                objCuocGoiMoi.PhoneNumber,
                                                                                                objCuocGoiMoi.ThoiDiemGoiDen,
                                                                                                diaChi,
                                                                                                vung,
                                                                                                kieuKhachHang,
                                                                                                maDoiTac,
                                                                                                objCuocGoiMoi.SoLanGoiLaiGanDay,
                                                                                                objCuocGoiMoi.CuocGoiLaiID,
                                                                                                objCuocGoiMoi.LoaiXe,
                                                                                                objCuocGoiMoi.ThoiGianGoiLai,
                                                                                                objCuocGoiMoi.GhiChuDT,
                                                                                                objCuocGoiMoi.GhiChuTD,
                                                                                                IsSanBayDuongDai,
                                                                                                xeNhan,
                                                                                                bookID, 
                                                                                                objCuocGoiMoi.GPS_KinhDo,
                                                                                                objCuocGoiMoi.GPS_ViDo,
                                                                                                objCuocGoiMoi.G5_CarType
                                                                                                );

                if (objCuocGoiMoi.CuocGoiID > 0)
                {
                    //Thêm vào danh sách cuộc gọi chờ xử lý trên MEM (g_ListCuocGoiChoXuLy)
                    lock (g_ListCuocGoiChoXuLy)
                    {
                        g_ListCuocGoiChoXuLy.Add(objCuocGoiMoi);
                    }
                    //Lưu lại số lần gọi lại (g_CuocGoiLuuLai)
                    LuuCuocGoiXuLySoLanGoiLai(objCuocGoiMoi.PhoneNumber, objCuocGoiMoi.ThoiDiemGoiDen, objCuocGoiMoi.CuocGoiID, objCuocGoiMoi.LoaiXe);


                    //objCuocGoiMoi.ServerDBThoiDiemGoiDen = DateTime.Now;  // lưu thời điểm theo server khi gọi vào để tinh số chuông

                    //if (lstCuocGoiChoThongTinGhiAm == null)
                    //    lstCuocGoiChoThongTinGhiAm = new List<StructCuocGoi>();
                    //lstCuocGoiChoThongTinGhiAm.Add(objCuocGoiMoi);
                }
                return objCuocGoiMoi.CuocGoiID;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("ProcessInsertCall " + CDRfile, ex);
                return 0;
            }
        }

        /// <summary>
        /// dat  lai so dien thoai khi sai
        /// </summary>
        /// <param name="soDienThoai"></param>
        /// <returns></returns>
        private string DatLaiSoDienThoaiSai(string soDienThoai, string soDacBiet)
        {
            if (soDienThoai.Length < 10)
                return soDacBiet;
            
            string soDau = soDienThoai.Substring(0, 2);
            string pattern = @"^0[1-9]";
            Regex myRegex = new Regex(pattern);

            if (myRegex.IsMatch(soDienThoai))
            {
                return soDienThoai;
            }
            ////0433262626
            //if (soDau == "01" || soDau == "09" || soDau == "05")
            //    return soDienThoai;

            LogError.WriteLogInfo("DatLaiSoDienThoaiSai :  " + soDienThoai);
            return soDacBiet;
        }

        #region XU LY LAY SO LAN GOI LAI

        /// <summary>
        /// ham lay ra ds cuoc goi dang xu ly, cach day so phut
        /// </summary>
        private void KhoiTaoDanhSachCuocGoiDangXuLy()
        {

        }

        /// <summary>
        /// SO LAN GOI LAI
        /// hàm thực hiện lưu lại cuộc gọi
        /// để xác định cuộc gọi lại
        /// Them vao ds cuoc goi da co, 
        /// 
        /// Neu trả về true là lưu được, trả về false không luu, lỗi số
        /// </summary>
        /// <param name="cuocGoiMoi"></param>
        private bool LuuCuocGoiXuLySoLanGoiLai(string soDienThoai, DateTime thoiDiem, long IDCuocGoi, string LoaiXe)
        {
            if (g_CuocGoiLuuLai == null)
            {
                g_CuocGoiLuuLai = new Dictionary<string, StructCuocGoi>();
            }
            if (g_CuocGoiLuuLai.ContainsKey(soDienThoai)) // neu da ton tai trong ds thi cap nhat thoi diem va so lan goi
            {

                StructCuocGoi cuocGoi = g_CuocGoiLuuLai[soDienThoai];
                //TimeSpan timeSpan = new TimeSpan();
                //timeSpan = thoiDiem - cuocGoi.ThoiDiemGoiDen;
                //if (timeSpan.TotalSeconds <= 10)  // số này 10 giây gần đây gọi lại thì ghi nhận lỗi
                //    return false;

                cuocGoi.ThoiDiemGoiDen = thoiDiem;
                cuocGoi.SoLanGoiLaiGanDay++;
                g_CuocGoiLuuLai[soDienThoai] = cuocGoi; // gan lai bang gia tri moi cua so lan goi lai
            }
            else  // chua co trong ds thi them moi
            {
                StructCuocGoi cuocGoi = new StructCuocGoi();
                cuocGoi.PhoneNumber = soDienThoai;
                cuocGoi.ThoiDiemGoiDen = thoiDiem;
                cuocGoi.SoLanGoiLaiGanDay = 0;
                cuocGoi.CuocGoiID = IDCuocGoi;
                cuocGoi.LoaiXe = LoaiXe;
                g_CuocGoiLuuLai.Add(soDienThoai, cuocGoi);
            }

            return true;  // ghi nhận không lỗi.
        }
        /// <summary>
        /// SO LAN GOI LAI
        /// ham se tim trong ds cuoc goi Luu den xu ly goi lai g_CuocGoiLuuLai
        /// </summary>
        /// <param name="soDienThoai"></param>
        /// <returns></returns>
        private byte GetSoLanGoiLai(string soDienThoai,out long idCuocGoiLai, out DateTime thoiDiemGoiTruoc)
        {
            thoiDiemGoiTruoc = DateTime.MinValue;
            if (g_CuocGoiLuuLai.ContainsKey(soDienThoai)) // neu da ton tai trong ds thi cap nhat thoi diem va so lan goi
            {
                idCuocGoiLai = g_CuocGoiLuuLai[soDienThoai].CuocGoiID;
                thoiDiemGoiTruoc = g_CuocGoiLuuLai[soDienThoai].ThoiDiemGoiDen;
                if (g_CuocGoiLuuLai[soDienThoai].SoLanGoiLaiGanDay == 0)
                {
                   return 1; 
                }
                return g_CuocGoiLuuLai[soDienThoai].SoLanGoiLaiGanDay;
            }
            idCuocGoiLai = 0;
            return 0;
        }
        /// <summary>
        /// SO LAN GOI LAI
        /// ham thuc hien xoa so phut gioi han
        /// </summary>
        private void XoaCuocGoiDaGoiLau()
        {
            try
            {
                if (g_CuocGoiLuuLai == null || g_CuocGoiLuuLai.Count <= 0) return;

                List<string> listSoDienThoaiXoa = new List<string>();
                foreach (StructCuocGoi cuocGoi in g_CuocGoiLuuLai.Values)
                {
                    if ((DateTime.Now - cuocGoi.ThoiDiemGoiDen).Minutes > g_SoPhutLuuCuocGoi)
                    {
                        listSoDienThoaiXoa.Add(cuocGoi.PhoneNumber);
                    }
                }
                if (listSoDienThoaiXoa != null && listSoDienThoaiXoa.Count > 0)
                {
                    foreach (string soDienThoai in listSoDienThoaiXoa)
                    {
                        g_CuocGoiLuuLai.Remove(soDienThoai);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(" XoaCuocGoiDaGoiLau : ", ex);
            }
        }

        #endregion XU LY LAY SO LAN GOI LAI

        private void bwXuLyDuLieuUDP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi trong BackgroudWorker" + e.Result.ToString(), new Exception(e.Error.Message));
            }
        }

        private void DeleteNhungCuocDuThua()
        {
            try
            {
                if ((g_ListCuocGoiChoXuLy == null) || (g_ListCuocGoiChoXuLy.Count <= 0)) return;

                List<int> ListCuocGoiCanXoaIndex = new List<int>();
                int Index = -1;
                for (int i = 0; i < g_ListCuocGoiChoXuLy.Count; i++)
                {
                    Index++;
                    TimeSpan timespan = DateTime.Now - g_ListCuocGoiChoXuLy[i].ThoiDiemGoiDen;
                    if (timespan.Minutes > 120)  // có cuộc gọi nhỡ
                    {
                        ListCuocGoiCanXoaIndex.Add(Index);

                    }
                }
                lock (g_ListCuocGoiChoXuLy)
                {
                    /// xóa trong g_ListCuocGoiLogInComing
                    /// ...
                    if ((ListCuocGoiCanXoaIndex != null) && (ListCuocGoiCanXoaIndex.Count > 0))
                    {
                        foreach (int IndexXoa in ListCuocGoiCanXoaIndex)
                        {
                            if ((IndexXoa >= 0) && (g_ListCuocGoiChoXuLy.Count > 0))
                                g_ListCuocGoiChoXuLy.RemoveAt(IndexXoa);
                        }

                        ListCuocGoiCanXoaIndex.Clear();
                        ListCuocGoiCanXoaIndex = null;
                    }

                    if (g_ListCuocGoiChoXuLy.Count > 32)
                    {
                        g_ListCuocGoiChoXuLy.Clear();
                        LogError.WriteLogError("DeleteNhungCuocDuThua  XOA TAT CA", new Exception(""));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi trong DeleteNhungCuocDuThua ", ex);
            }
        }

        /// <summary>
        /// Diem  so lan do chuong
        /// </summary>
        /// <param name="ThoiDiemGoi"></param>
        /// <param name="ThoiDiemGoiNhacMay"></param>
        /// <returns></returns>
        private int GetSoChuong(DateTime ThoiDiemGoi, DateTime ThoiDiemGoiNhacMay)
        {
            try
            {
                TimeSpan timeSpan = (ThoiDiemGoiNhacMay - ThoiDiemGoi);
                int SoChuong = 0;
                SoChuong = Convert.ToInt32((timeSpan.Hours * 3600 + timeSpan.Minutes * 60 + timeSpan.Seconds) / 5) + 1;
                if (SoChuong >= 10) SoChuong = 10;
                if (SoChuong <= 0) SoChuong = 1;
                return SoChuong;     //(int)((SoGiayCuoi - SoGiayDau) / 5) + 1;
            }
            catch (Exception ex)
            {
                return 10;
            }
        }
        #endregion XuLyCaptureCuocGoiUDP

        #region ----------------CUOC GOI DI


        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            //try
            //{

            //    DataTable dt = new DataTable();
            //    dt = TaxiCapture.GetEarlyPhoneDialOut(g_FileVOCPath);
            //    if ((dt != null) && (dt.Rows.Count > 0))
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
            //            if (!objGoiDi.Insert())
            //            {
            //                LogError.WriteLogError("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogError.WriteLogError("Loi luu xuong DB cuoc goi di ", ex);
            //}
        }
        #endregion

        #region ----------------Form Events

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thoát chương trình sẽ không thể bắt số điện thoại-điều hành cuộc gọi");
            if (MessageBox.Show(this, "Bạn có đồng ý đồng ý thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                g_Thoat = true;
                this.axtxUDP1.UDPclose();
                Application.Exit();

            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_Thoat) e.Cancel = false;
            else e.Cancel = true;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;

        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void btnSystemTray_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string sUDP = StringTools.RemoveSpace(textBox1.Text);

            //sUDP = "txIP," + sUDP + ",,01,1,End";

            XuLyDuLieuUDP(sUDP);

        }
        #endregion

        #region Temps


        /// <summary>
        /// Coongnt - 06/07/2013
        /// 
        /// ham thuc hien khoi tao cac line cua
        /// </summary>
        //private void KhoiTaoDSLineForUDP()
        //{
        //    // lấy thông số từ line cầu hình, hình thành lên ds khởi động sẵn
        //    if (dicCuocGoiUDP == null) dicCuocGoiUDP = new Dictionary<string, CuocGoiUDP>();

        //    string linesGoiDen = ThongTinCauHinh.CacLineCuaTaxiOperation;
        //    // mỗi line một cuộc gọi khởi động sẵn

        //    foreach(string line in linesGoiDen.Split(";".ToCharArray ()))
        //    {
        //        try
        //        {

        //            CuocGoiUDP cuocUDP = new CuocGoiUDP();
        //            cuocUDP.CuocGoiID = 0; 
        //            cuocUDP.Line = line;
        //            cuocUDP.PhoneNumber = string.Empty;
        //            cuocUDP.ThoiDiemGoiDen = new DateTime(1900, 1, 1);

        //            dicCuocGoiUDP.Add(line, cuocUDP);

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi cấu hình line gọi đến.Liên lạc với quản trị hệ thống. LINES: " + linesGoiDen, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            Environment.Exit(1);
        //            return;
        //        }
        //    }

        //}

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //    Application.Restart();
        //} 
        /// <summary>
        /// ham tra ve ds connection string cua cong ty ung voi line cua cong ty do
        /// </summary>
        /// <param name="Line"></param>
        /// <returns></returns>
        //private string GetConnectionStringFromLines(string Line)
        //{
        //    if (Line != null && Line.Length > 0)
        //    {
        //        if (KiemTraLineTrongListLine(Line, g_LinesHN)) return g_ConnectionStringHN;
        //        else if (KiemTraLineTrongListLine(Line, g_LinesCP)) return g_ConnectionStringCP;
        //        else if (KiemTraLineTrongListLine(Line, g_LinesTou)) return g_ConnectionStringTou;
        //        else if (KiemTraLineTrongListLine(Line, g_Lines3A)) return g_ConnectionString3A;

        //    }
        //    return "";
        //}
        /// <summary>
        /// input : 1;2;3;4;5
        ///         2
        /// output : true thuoc 
        ///          false
        /// </summary>
        /// <param name="Line"></param>
        /// <param name="g_LinesHN"></param>
        /// <returns></returns>
        //private bool KiemTraLineTrongListLine(string Line, string Lines)
        //{
        //    if (Lines.Length > 0 && Line.Length > 0)
        //    {
        //        string[] arrLine = Lines.Split(";".ToCharArray());
        //        for (int i = 0; i < arrLine.Length; i++)
        //        {
        //            if (arrLine[i] == Line) return true;
        //        }
        //    }

        //    return false;
        //}
        #endregion
    }
}