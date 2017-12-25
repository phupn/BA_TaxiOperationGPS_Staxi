using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using TaxiCapture.Common;
using System.Diagnostics;
using Taxi.Business.KhachDat;
using System.Text.RegularExpressions;
using System.Threading;

namespace TaxiCapture
{
    public partial class frmMainUDPThanhNga : Form
    {
        #region Init

        private bool g_Thoat = false;        /// Khai bao du lieu toan cu
        private System.Timers.Timer g_TimerCapture = null;
        private int g_BlinkIcon = 0;
        private long g_iCount = 0;
        private List<StructCuocGoi> g_ListCuocGoiChoXuLy = new List<StructCuocGoi>();
        private Dictionary<string, StructCuocGoi> g_CuocGoiLuuLai = new Dictionary<string, StructCuocGoi>();    // nhung cuoc goi den luu lai, de tim cac cuoc goi lai
        private int g_SoPhutLuuCuocGoi = 30;    // so phut luu lai cuoc goi, neu NOW - ThoiDiemGoi > SoPhutLuuCuocGoi --> Xoa khoi ds
        private string g_ConnecString = "";
        private int g_TimerStepGetDatHen = 0;
        private long g_iCountUpdateVOCVoiceFile = 0;  // xuly doc VOC file ghi am
        private int g_iCount_GetCuocGoi = 0;          // xuly doc VOC file ghi am
        private DateTime g_ThoiDiemLayTruocVOC;       // xuly doc VOC file ghi am
        private string g_FileVOCPath = null;
        private int g_iCountXoaCuocTuDong = 0;        // dem xoa tu dong 
        private int g_SoCuocGoiGiuLai = 800;          // So cuộc gọi giữ lại trong trường hợp khách đông.
        string[] g_arrLinesTaxi;
        public frmMainUDPThanhNga()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mot dictionary luu trang thai so dien thoai cua cac line
        /// </summary>
        private Dictionary<string, CuocGoiUDP> dicCuocGoiUDP = new Dictionary<string, CuocGoiUDP>();

        /// <summary>
        /// Dictionary lưu thông tin danh bạ
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicDanhBa = new SynchronizedDictionary<string, DanhBaEx>();

        /// <summary>
        /// Danh ba bưu điện
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicDanhBa_BuuDien = new SynchronizedDictionary<string, DanhBaEx>();

        private SynchronizedDictionary<string, DanhBaEx> dicMoiGioi = new SynchronizedDictionary<string, DanhBaEx>();
        /// <summary>
        /// Lưu những cuốc khách online, lấy định kỳ 1 phút một lần.
        /// </summary>
        private SynchronizedDictionary<string, DanhBaEx> dicCuocOnline = new SynchronizedDictionary<string, DanhBaEx>();

        private SynchronizedDictionary<string, DanhBaKhachQuen> dicKhachQuen = new SynchronizedDictionary<string, DanhBaKhachQuen>();
        //--------- THÔNG TIN CS------------------------------
        /// <summary>
        /// ds user đang login vi trí CS, 3 phút quét lại một lần
        /// </summary>
        List<CheckInCheckOut> g_ListUserCheckIn = new List<CheckInCheckOut>();  
        /// <summary>
        /// ds các line của CS
        /// </summary>
        List<int> g_ListLinesCS = new List<int>();                              
        bool g_DangLayUserCheckIn = false;
        private DateTime g_ThoiDiemLayTruoc_KhachHang;
        private DateTime g_ThoiDiemLayTruoc_DoiTac;
        private DateTime g_ThoiDiemLayTruoc_CongTy;
        private int count_Sleep = 0;
        //----------------------------------------------------
        private BackgroundWorker bwSync_LoadDanhBaBuuDien = new BackgroundWorker();
        private BackgroundWorker bwSync_LoadDanhBaKhachQuen = new BackgroundWorker();
        private BackgroundWorker bwKhachDat = new BackgroundWorker();
        private BackgroundWorker bw = new BackgroundWorker();
        private BackgroundWorker bw1 = new BackgroundWorker();

        /// <summary>
        /// Số điện thoại bắt ở trạng thái 1
        /// </summary>
        string str_SoDienThoai_TT1 = string.Empty;
        #endregion

        #region ----------------Load form

        private void frmMain_Load(object sender, EventArgs e)
        {
            //if (DesignMode) return;
            if (Configuration.TrangThaiBatSo > 0)
            {
                if (KiemTraPOPUPDangChay())
                {
                    MessageBox.Show("Chương trình POPUP đã được chạy. Bạn có thể tắt đi để có thể bắt số bằng UDP.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                if (!this.MoCongUDP())
                {
                    MessageBox.Show("Cổng UDP có thể sử dụng bởi chương trình khác. Bạn liên hệ với quản trị để được hướng dẫn hoặc có thể khởi động lại hệ thống để thiết lập lại cổng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
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
                if (Configuration.TrangThaiBatSo > 0)
                {
                    bwKhachDat.DoWork += bwKhachDat_DoWork;
                    bwKhachDat.RunWorkerCompleted += bwKhachDat_RunWorkerCompleted;

                    bwSync_LoadDanhBaBuuDien.DoWork += bwSync_LoadDanhBaBuuDien_DoWork;
                    bwSync_LoadDanhBaKhachQuen.DoWork += bwSync_LoadDanhBaKhachQuen_DoWork;

                    bw.DoWork += bw_DoWorkUpdateVOCVoiceFile;
                    bw.RunWorkerCompleted += bw_RunWorkerCompletedUpdateVOCVoiceFile;

                    bw1.DoWork += bw_DoWorkUpdateNhanVien;
                    bw1.RunWorkerCompleted += bw_RunWorkerCompletedUpdateNhanVien;

                    if (!TaxiCapture.IsServerConnected(g_ConnecString))
                    {
                        statusLblServer.Text = "Server: Đang kết nối";
                        Thread.Sleep(2000);
                        Init();
                    }

                    // Check connection 
                    if (!DieuHanhTaxi.CheckConnection())
                    {
                        MessageBox.Show("Không kết nối được với cơ sở dữ liệu.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }

                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();                    
                    g_SoCuocGoiGiuLai = Configuration.GetSoCuocGoiGiuLai();
                    g_SoPhutLuuCuocGoi = TaxiCapture.GetSoPhutLuuCuocGoi();
                    g_FileVOCPath = Configuration.VocFilePath();
                    if ((!FileTools.IsExsitFile(g_FileVOCPath)))
                    {
                        MessageBox.Show("Không tồn tại file thông tin cuộc gọi.Liên lạc với quản trị hệ thống." + g_FileVOCPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                    else
                    {
                        if (Configuration.IsCardT4)
                        {
                            TaxiCapture.DeletePhoneCallVocFile_T4(DateTime.Now, g_FileVOCPath);
                        }
                        else
                        {
                            TaxiCapture.DeletePhoneCallVocFile(DateTime.Now, g_FileVOCPath);
                        }
                    }                    
                }

                g_ThoiDiemLayTruocVOC = DateTime.Now;
                g_ThoiDiemLayTruoc_KhachHang = DateTime.Now;
                g_ThoiDiemLayTruoc_DoiTac = DateTime.Now;
                g_ThoiDiemLayTruoc_CongTy = DateTime.Now;
                if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0) ;
                else ;
                //Fix Connection string
                //g_ConnecString = @"192.168.1.240\sqlexpress;Initial Catalog=Taxi_TienSa;User ID=sa;Password=123@123abc";
                g_TimerCapture = new System.Timers.Timer(500); // nửa giây quét một lần.
                g_TimerCapture.Elapsed += timerCapture_Elapsed;
                g_TimerCapture.Enabled = true;

                // Thong tin status bar
                statusLblKhoiDongLuc.Text = " Khởi động : " + string.Format("{0:HH:mm dd/MM}", DateTime.Now);
                statusLblSoCuocChoXuLy.Text = " Cuộc chờ xử lý : 0";
                statusLblServer.Text = " Server: " + GetServerName(g_ConnecString);
                statusLblDatabase.Text = " DB: " + GetDatabaseName(g_ConnecString);
                if (Configuration.TrangThaiBatSo > 0)
                {
                    //lấy ds line cấu hình
                    g_arrLinesTaxi = ThongTinCauHinh.CacLineCuaTaxiOperation.Split(";".ToCharArray());

                    // khởi tạo danh bạ lên mem
                    KhoiTaoDanhBaOnMEM();
                    // khởi tạo cuốc khách lên mem
                    KhoiTaoCuocKhachOnlineLenMEM();
                    //g_ListLinesCS = TaxiCapture.GetLineDialOutCS(g_ConnecString);
                    //g_ListUserCheckIn = TaxiCapture.GetCheckInCS(g_ConnecString);
                    bwSync_LoadDanhBaBuuDien.RunWorkerAsync();
                    bwSync_LoadDanhBaKhachQuen.RunWorkerAsync();
                }
                Text = Configuration.GetCompanyName();
                count_Sleep = 0;
                WindowState = FormWindowState.Normal;
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
        /// </summary>

        private string GetDatabaseName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString.Length > 2)
            {
                return arrString[1].Replace("Initial Catalog=", "");
            }
            return "";
        }

        /// <summary>
        /// Lấy tên server
        /// </summary>
        private string GetServerName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString.Length > 2)
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
        private void timerCapture_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (g_BlinkIcon == 0)
                {
                    notifyIcon1.Icon = TaxiOperation_CallCapture2.Properties.Resources.Taxi;
                    pictureBox1.Image = TaxiOperation_CallCapture2.Properties.Resources.Taxi.ToBitmap();
                    g_BlinkIcon = 1;
                }
                else
                {
                    notifyIcon1.Icon = TaxiOperation_CallCapture2.Properties.Resources.TongDai;
                    pictureBox1.Image = TaxiOperation_CallCapture2.Properties.Resources.TongDai.ToBitmap();
                    g_BlinkIcon = 0;
                }
                if (Configuration.TrangThaiBatSo > 0)
                {

                    g_iCount_GetCuocGoi++;
                    if (g_iCount_GetCuocGoi >= 60) // 1 phút
                    {
                        KhoiTaoCuocKhachOnlineLenMEM();
                        g_iCount_GetCuocGoi = 0;
                    }

                    // 2 phut cap nhat thong tin file VOC
                    g_iCountUpdateVOCVoiceFile++;
                    if (g_iCountUpdateVOCVoiceFile >= 2 * 60 * 2) // 2 phut
                    {

                        // lấy lại thông tin cuốc khách online
                        //KhoiTaoCuocKhachOnlineLenMEM(); //sẽ bị chạy 2 lần???

                        bw.RunWorkerAsync();

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
                }
                g_TimerStepGetDatHen++;
                if (g_TimerStepGetDatHen >= 120) //--------1 phut thuc hien quet 1 lan
                {
                    LogError.WriteLogInfo("Get Khach Dat");
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
            catch (Exception)
            {

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
                        dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien2()
        {
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
                        dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien3()
        {
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
                        dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien4()
        {
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
                        dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        private void KhoiTaoDanhBaBuuDien5()
        {
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
                        dicDanhBa_BuuDien.Add(dbbd.PhoneNumber, new DanhBaEx { PhoneNumber = dbbd.PhoneNumber, Address = dbbd.Address, IsActive = true, Name = dbbd.Name, KieuDanhBa = KieuDanhBa.BuuDien });
                    }
                }
            }
        }

        /// <summary>
        /// Côngnt - 09/07/2013
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

        private void bwSync_LoadDanhBaKhachQuen_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachVip = DanhBaKhachQuen.GetKhachQuens("SELECT *,'''' TypeName,'''' RankName FROM [dbo].[T_DMKHACHHANG] WHERE [IsActive] = 1");
                foreach (var item in lstKhachVip)
                {                    
                    // tác số điện thoại
                    string[] arrDienThoai = item.Phones.Split(";".ToCharArray());
                    for (int i = 0; i < arrDienThoai.Length; i++)
                    {
                        if (dicKhachQuen.ContainsKey(arrDienThoai[i])) continue;
                        dicKhachQuen.Add(arrDienThoai[i], item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwSync_LoadDanhBaKhachQuen_DoWork.", ex);
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
                foreach (DanhBaEx dbex in listDBMoiGioi)
                {
                    //Chưa tồn tài thì thêm vào ds
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
                listDBCongTy = DanhBaEx.GetDanhBaCONGTY_GetLast(LastUpdate);
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
                        if (item.Phones!=null&&dicKhachQuen.ContainsKey(item.Phones))
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
        /// khởi tạo cuốc khách lên mem
        /// cuốc khách sẽ được cập nhật 1 phút một lần.
        /// </summary>
        private void KhoiTaoCuocKhachOnlineLenMEM()
        {
            try
            {
                // lấy ds cuốc khách online
                dicCuocOnline.Clear();
                dicCuocOnline = TaxiCapture.GetCuocOnlines_v2(g_ConnecString);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("KhoiTaoCuocKhachOnlineLenMEM.", ex);
            }
        }

        /// <summary>
        /// Hàm thực hiện lấy 
        /// </summary>
        private void GetDiaChiTuMEM(string soDienThoai, out KieuKhachHangGoiDen kieuKhachHang, out string diaChi, out int vung, out string maDoiTac
            , out string loaiXe, out string GhiChuTiepNhan, out float KinhDo, out float ViDo, out string diaChiTra, out bool isCuocGoiLai)
        {
            diaChi = string.Empty;
            diaChiTra = string.Empty;
            vung = 0;
            maDoiTac = string.Empty;
            loaiXe = string.Empty;
            GhiChuTiepNhan = string.Empty;
            KinhDo = 0;
            ViDo = 0;
            isCuocGoiLai = false;
            kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
            try
            {
                DanhBaEx item;
                // lấy theo Moi giới
                if (dicMoiGioi.ContainsKey(soDienThoai))
                {
                    item = dicMoiGioi[soDienThoai];
                    diaChi = item.Address;
                    //vung = dicDanhBa[soDienThoai].Vung;
                    maDoiTac = item.MaDoiTac;

                    if (item.KieuDanhBa == KieuDanhBa.MoiGioi)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                    else if (item.KieuDanhBa == KieuDanhBa.CongTy)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    KinhDo = item.GPS_KinhDo;
                    ViDo = item.GPS_ViDo;
                    return;
                }
                // lấy từ cuốc online 
                if (dicCuocOnline.ContainsKey(soDienThoai))
                {
                    item = dicCuocOnline[soDienThoai];
                    diaChi = item.Address;
                    //vung = item.Vung;
                    maDoiTac = item.MaDoiTac;
                    //if (maDoiTac == string.Empty)
                    //    kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    //else
                    kieuKhachHang = item.KieuKhachHang;//KieuKhachHangGoiDen.KhachHangMoiGioi;
                    loaiXe = item.LoaiXe;
                    GhiChuTiepNhan = item.GhiChuTiepNhan;
                    KinhDo = item.GPS_KinhDo;
                    ViDo = item.GPS_ViDo;
                    diaChiTra = item.Address_Destination;
                    isCuocGoiLai = true;
                    return;
                }
                if (dicKhachQuen.ContainsKey(soDienThoai))
                {
                    DanhBaKhachQuen objKhachQuen = dicKhachQuen[soDienThoai];

                    diaChi = objKhachQuen.Address;
                    if (!string.IsNullOrEmpty(objKhachQuen.Name))
                        diaChi = String.Format("[{0}]{1}", objKhachQuen.Name, objKhachQuen.Address);

                    vung = 2;
                    maDoiTac = objKhachQuen.MaKH;

                    if (objKhachQuen.Type == 1)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangVIP;
                    else if (objKhachQuen.Type == 2)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    else if (objKhachQuen.Type == 3)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    GhiChuTiepNhan = objKhachQuen.Notes;
                    KinhDo = objKhachQuen.KinhDo;
                    ViDo = objKhachQuen.ViDo;
                    return;
                }
                // lấy theo danh bạ
                if (dicDanhBa.ContainsKey(soDienThoai))
                {
                    item = dicDanhBa[soDienThoai];
                    diaChi = item.Address;
                    //vung = item.Vung;
                    maDoiTac = item.MaDoiTac;

                    if (item.KieuDanhBa == KieuDanhBa.MoiGioi)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                    else if (item.KieuDanhBa == KieuDanhBa.CongTy || item.KieuDanhBa == KieuDanhBa.BuuDien)
                        kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                    return;
                }
                if (soDienThoai.StartsWith("04"))
                {
                    //Nếu là số điện thoại bàn ở HN thì mới check trong danh mục Bưu Điện.
                    if (dicDanhBa_BuuDien.ContainsKey(soDienThoai))
                    {
                        item = dicDanhBa_BuuDien[soDienThoai];
                        diaChi = item.Address;
                        if (item.Name != "")
                            diaChi = string.Format("[{0}]{1}", item.Name, diaChi);

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
        private void bw_DoWorkUpdateVOCVoiceFile(object sender, DoWorkEventArgs e)
        {
            DateTime temp = DateTime.Now;
            ThucHienLayFileGhiAm(g_ThoiDiemLayTruocVOC, temp, g_FileVOCPath);
            g_ThoiDiemLayTruocVOC = temp;
        }

        private void bw_RunWorkerCompletedUpdateVOCVoiceFile(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi bw_DoWorkUpdateVOCVoiceFile  ", new Exception(e.Error.Message));
            }
        }

        /// <summary>
        /// Ham thuc hien lay file ghi am tu thoi diem ThoiDiemLayTruoc toi bay gio
        /// </summary>
        private void ThucHienLayFileGhiAm(DateTime TuThoiDiem, DateTime DenThoiDiem, string VOCFilenamePath)
        {
            try
            {
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
                if (!bwKhachDat.IsBusy)
                    bwKhachDat.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi CheckAndInsertCuocGoiFromKhachDat", ex);
            }
        }

        private void bwKhachDat_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime CurrDate = DateTime.Now;
                LogError.WriteLogInfo("Get Khach Dat" + string.Format("{0:dd/MM/yyyy HH:mm:ss}", CurrDate));
                List<KhachDatBL> lstKhachDat = new KhachDatBL().GetKhachDat_ChenCuocGoi(CurrDate);
                if (lstKhachDat == null || lstKhachDat.Count <= 0)
                    return;

                lstKhachDat.ForEach(InsertCuocGoiKhachDat);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("bwKhachDat_DoWork: ", ex);                
            }
        }

        private void bwKhachDat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                LogError.WriteLogError("Khach Dat : BackgroundWorker Canceled", new Exception("Canceled"));
            }
            else if (e.Error != null)
            {
                LogError.WriteLogError("Khach Dat : BackgroundWorker (" + e.Error.Message + ")", new Exception("Error BackgroundWorker"));
            }
        }

        /// <summary>
        /// Insert Cuoc Goi tu Khach Dat Hen
        /// </summary>        
        private void InsertCuocGoiKhachDat(KhachDatBL KhachDat)
        {
            try
            {
                //đặt  line là 99 để thông nhất là line khách đặt
                TaxiCapture.InsertCuocGoiLanDau_KhachDat(g_ConnecString, 99, KhachDat.VungKenh, KhachDat.SoDienThoai, DateTime.Now, KhachDat.DiaChi, KhachDat.GhiChu, KhachDat.LoaiXe, KhachDat.SoLuongXe, KhachDat.PK_KhachDatID, KhachDat.KinhDo, KhachDat.ViDo);
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Lỗi  InsertCuocGoiKhachDat", ex);
            }
        }

        #endregion-----------------------------------------------------------
         
        #region ----------------Capture UDP-Insert Cuộc gọi

        /// <summary>
        /// Ham kiem tra Popup con dang chay hay khong
        /// </summary>
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
        /// Ham mo cong UDP
        /// </summary>
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
        /// Ham su kien co du lieu gui ve *sign
        /// </summary>
        private void axtxUDP1_UDPdata(object sender, AxtxUDPOCX.__txUDP_UDPdataEvent e)
        {
            if (!string.IsNullOrEmpty(e.bytesTotal))
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
        private void XuLyDuLieuUDP(string bytesTotal)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += bw_DoWorkProcessStaus3;
            worker.RunWorkerCompleted += bw_RunWorkerCompleted;
            worker.RunWorkerAsync(bytesTotal);
        }
        
        /// <summary>
        /// ham thuc hien xu ly cac cuoc goi tu UDP, xu ly thuan trang thai 1, 3
        /// </summary>
        private void bw_DoWorkProcessStaus3(object sender, DoWorkEventArgs e)
        {
            try
            {
                //txIP,01698390011 ,,3,1,End
                string soDacBiet = "0111111111";
                bool isGetAddress = true;
                string strUDP = (string)e.Argument; //txIP,0436425008,,02,1,End  

                if (chkGhiLogForDebug.Checked)
                    LogError.WriteLogErrorForDebug(strUDP);

                string[] arrUDP = strUDP.Split(",".ToCharArray());

                if (arrUDP.Length != 6) return;

                string SoDienThoai = arrUDP[1].Trim();

                string soDienThoaiRaw = SoDienThoai;// Giữ số điện thoại nguyên thủy không chỉnh sửa gì

                SoDienThoai = StringTools.GetSoDienThoaiChuan2(SoDienThoai, soDacBiet, Configuration.GetDauSoGoiDi);//*sign
                if (chkGhiLogForDebug.Checked) //*sign
                    LogError.WriteLogErrorForDebug("So dien thoai da format chuan: "+ SoDienThoai);
                string Line = StringTools.RemoveSoKhongODau(arrUDP[3]);

                if (!TaxiCapture.IsLineOfTaxiOperation(Line, g_arrLinesTaxi)) return;

                byte TrangThai = Convert.ToByte(arrUDP[4]);
                DateTime ThoiDiem = DateTime.Now;

                switch (TrangThai)
                {
                    case 1: // Goi Den   - Lưu tạm trên MEM
                        if (g_ListCuocGoiChoXuLy == null)
                            g_ListCuocGoiChoXuLy = new List<StructCuocGoi>();
                        try
                        {                            
                            StructCuocGoi objCuocGoiMoi = new StructCuocGoi();
                            objCuocGoiMoi.Line = Line;
                            objCuocGoiMoi.PhoneNumber = SoDienThoai;
                            objCuocGoiMoi.ThoiDiemGoiDen = ThoiDiem;
                            objCuocGoiMoi.KieuCuocGoi = TypeCall.Incoming;
                            DateTime ThoiDiemGoiLai;
                            if (SoDienThoai != soDacBiet)
                            {
                                long IDCuocGoiLai = 0;
                                objCuocGoiMoi.SoLanGoiLaiGanDay = GetSoLanGoiLai(SoDienThoai, out IDCuocGoiLai, out ThoiDiemGoiLai);
                                double sophut = (ThoiDiem - ThoiDiemGoiLai).TotalMinutes;
                                if (sophut > 0 && ThoiDiemGoiLai> DateTime.MinValue)
                                {
                                    objCuocGoiMoi.ThoiGianGoiLai = Math.Round((ThoiDiem - ThoiDiemGoiLai).TotalMinutes, 1).ToString() + " phút";
                                }
                                
                                objCuocGoiMoi.CuocGoiLaiID = IDCuocGoiLai;
                            }
                            else
                            {
                                objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                            }
                            if (SoDienThoai == soDacBiet || SoDienThoai == ThongTinCauHinh.SoDienThoaiCongTy)
                                isGetAddress = false;
                            
                            if (Configuration.TrangThaiBatSo == 1)
                            {
                                //Lưu lại số điện thoại ở trạng thái 1 để so sánh với  số điện thoại ở trạng thái 3.
                                str_SoDienThoai_TT1 = SoDienThoai;

                                #region Get Address
                                // lấy các thông số dịa chi từ Mem
                                int vung = 0;
                                string diaChi = string.Empty;
                                string diaChiTra = string.Empty;
                                KieuKhachHangGoiDen kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                                string maDoiTac = string.Empty;
                                string LoaiXe = string.Empty;
                                string GhiChuTiepNhan = string.Empty;
                                float KinhDo = 0;
                                float ViDo = 0;
                                bool isCuocGoiLai = false;
                                // lấy địa chỉ từ MEM
                                if (isGetAddress)   // thuốc những số có thể lấy được địa chỉ.
                                {
                                    GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac, out LoaiXe, out GhiChuTiepNhan, out KinhDo, out ViDo, out diaChiTra, out isCuocGoiLai);
                                    //Nếu không lấy được địa chỉ từ MEM thì lấy từ database
                                    //Vì có thể tại thời điểm này MEM đang lấy dữ liệu cuộc gọi
                                    if (objCuocGoiMoi.CuocGoiLaiID > 0)
                                    {
                                        if (diaChi == "" && isCuocGoiLai)
                                        {
                                            //GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac, out LoaiXe);
                                            DanhBaEx objDanhBa = TaxiCapture.GetCuocOnlines_ByID(g_ConnecString, objCuocGoiMoi.CuocGoiLaiID);
                                            if (!string.IsNullOrEmpty(objDanhBa.Address))
                                            {
                                                if (chkGhiLogForDebug.Checked)
                                                    LogError.WriteLogErrorForDebug("diaChi-" + objDanhBa.Address);

                                                if (objDanhBa.MaDoiTac == string.Empty)
                                                    kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                                                else
                                                    kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                                                diaChi = objDanhBa.Address;
                                                diaChiTra = objDanhBa.Address_Destination;
                                                vung = objDanhBa.Vung;
                                                maDoiTac = objDanhBa.MaDoiTac;
                                                LoaiXe = objDanhBa.LoaiXe;
                                                KinhDo = objDanhBa.GPS_KinhDo;
                                                ViDo = objDanhBa.GPS_ViDo;
                                                GhiChuTiepNhan = objDanhBa.GhiChuTiepNhan;
                                            }
                                            else
                                            {
                                                objCuocGoiMoi.CuocGoiLaiID = 0;
                                                objCuocGoiMoi.ThoiGianGoiLai = "";
                                                objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                            }
                                        }
                                        else if (!isCuocGoiLai)
                                        {
                                            objCuocGoiMoi.CuocGoiLaiID = 0;
                                            objCuocGoiMoi.ThoiGianGoiLai = "";
                                            objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                        }
                                    }
                                }
                                vung = 0;

                                // kiem tra nhung so dien thoai la so dau khong phai la 01,09,04
                                //objCuocGoiMoi.PhoneNumber = DatLaiSoDienThoaiSai(objCuocGoiMoi.PhoneNumber, soDacBiet);
                                objCuocGoiMoi.LoaiXe = LoaiXe;
                                objCuocGoiMoi.GPS_KinhDo = KinhDo;
                                objCuocGoiMoi.GPS_ViDo = ViDo;
                                objCuocGoiMoi.GhiChuTiepNhan = GhiChuTiepNhan;
                                if (chkGhiLogForDebug.Checked)//*sign
                                    LogError.WriteLogErrorForDebug(objCuocGoiMoi.CuocGoiLaiID + "-" + objCuocGoiMoi.SoLanGoiLaiGanDay + "-" + diaChi + " - " + diaChiTra + "-" + objCuocGoiMoi.GPS_KinhDo);
                                #endregion

                                objCuocGoiMoi.CuocGoiID = TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM_V2(this.g_ConnecString, 
                                                                                                        objCuocGoiMoi.Line, 
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
                                                                                                        objCuocGoiMoi.GhiChuTiepNhan,
                                                                                                        objCuocGoiMoi.GPS_KinhDo,
                                                                                                        objCuocGoiMoi.GPS_ViDo,
                                                                                                        diaChiTra);
                                if (objCuocGoiMoi.CuocGoiID > 0)
                                {
                                    // statusLblSoCuocChoXuLy.Text = "Đang thoại : " + g_ListCuocGoiChoXuLy.Count.ToString();
                                    lblGoiDen.Invoke((MethodInvoker)delegate
                                    {
                                        lblGoiDen.Text = "Gọi đến : " + Line + " - " + SoDienThoai + " - [" + g_CuocGoiLuuLai.Count.ToString() + "]";
                                    });
                                }
                                else
                                {
                                    LogError.WriteLogInfo("Gọi đến false :  " + SoDienThoai);
                                }
                            }
                            
                            lock (g_ListCuocGoiChoXuLy)
                            {
                                g_ListCuocGoiChoXuLy.Add(objCuocGoiMoi);
                            }
                            if (SoDienThoai != soDacBiet)
                                LuuCuocGoiXuLySoLanGoiLai(objCuocGoiMoi.PhoneNumber, objCuocGoiMoi.ThoiDiemGoiDen, objCuocGoiMoi.CuocGoiID, objCuocGoiMoi.LoaiXe);
                        }
                        catch (Exception ex)
                        {
                            LogError.WriteLogError(" UDP Trang thai 1 :  " + e.Argument, ex);
                        }
                        break;
                    case 2: // Goi di
                        #region Cuoc Goi Di

                        // Nhận cuốc gọi đi
                        // Lấy danh sách những nhận viên đang đăng nhập (3 phút cập nhật một lần)
                        // Tìm nhân viên 
                        try
                        {
                            VOC voc = new VOC();
                            voc.Channel = int.Parse(Line);
                            voc.StartTime = ThoiDiem;
                            voc.Duration = new DateTime(1900, 1, 1, 0, 0, 1);
                            voc.FilePath = "";
                            voc.Fomin = "DialOut";
                            voc.Code = SoDienThoai;

                            string userName = string.Empty;
                            if (!g_DangLayUserCheckIn)
                                // neu dang lay thong tin user checkIn thi khong thực hiện (3 phút lấy một lần)
                            {
                                userName = TaxiCapture.GetUserOnline(g_ListUserCheckIn, voc.Channel.ToString());
                            }
                            TaxiCapture.InsertCuocGoiDi(g_ConnecString, voc, userName,g_ListLinesCS.Contains(voc.Channel));

                            if (this.chkGhiLogForDebug.Checked)
                            {
                                LogError.WriteLogErrorForDebug("Gọi ra" + SoDienThoai);
                            }
                        }
                        catch  (Exception ex)
                        {
                            LogError.WriteLogError("Cuoc Goi Di: ", ex);
                        }
                        #endregion
                        break;
                    case 3: // Bốc máy   - Chen database , luu lai
                        #region Goi Den (Trang thai nhac may)
                        if (g_ListCuocGoiChoXuLy != null && g_ListCuocGoiChoXuLy.Count > 0)
                        {
                            try
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
                                    lock (g_ListCuocGoiChoXuLy)
                                    {
                                        StructCuocGoi objCuocGoiMoi = g_ListCuocGoiChoXuLy[iIndexRemove];
                                        if (Configuration.TrangThaiBatSo == 3)
                                        {
                                            #region Get Address
                                            // lấy các thông số dịa chi từ Mem
                                            int vung = 0;
                                            string diaChi = string.Empty;
                                            string diaChiTra = string.Empty;
                                            KieuKhachHangGoiDen kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                                            string maDoiTac = string.Empty;
                                            string LoaiXe = string.Empty;
                                            string GhiChuTiepNhan = string.Empty;
                                            float KinhDo = 0;
                                            float ViDo = 0;
                                            bool isCuocGoiLai = false;
                                            // lấy địa chỉ từ MEM
                                            if (isGetAddress)   // thuốc những số có thể lấy được địa chỉ.
                                            {
                                                GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac, out LoaiXe, out GhiChuTiepNhan, out KinhDo, out ViDo, out diaChiTra, out isCuocGoiLai);
                                                //Nếu không lấy được địa chỉ từ MEM thì lấy từ database
                                                //Vì có thể tại thời điểm này MEM đang lấy dữ liệu cuộc gọi
                                                if (objCuocGoiMoi.CuocGoiLaiID > 0)
                                                {
                                                    if (diaChi == "" && isCuocGoiLai)
                                                    {
                                                        //GetDiaChiTuMEM(SoDienThoai, out kieuKhachHang, out diaChi, out vung, out maDoiTac, out LoaiXe);
                                                        DanhBaEx objDanhBa = TaxiCapture.GetCuocOnlines_ByID(g_ConnecString, objCuocGoiMoi.CuocGoiLaiID);
                                                        if (!string.IsNullOrEmpty(objDanhBa.Address))
                                                        {
                                                            if (chkGhiLogForDebug.Checked)
                                                                LogError.WriteLogErrorForDebug("diaChi-" + objDanhBa.Address + "-" + objDanhBa.GPS_KinhDo);

                                                            if (objDanhBa.MaDoiTac == string.Empty)
                                                                kieuKhachHang = KieuKhachHangGoiDen.KhachHangBinhThuong;
                                                            else
                                                                kieuKhachHang = KieuKhachHangGoiDen.KhachHangMoiGioi;
                                                            diaChi = objDanhBa.Address;
                                                            diaChiTra = objDanhBa.Address_Destination;
                                                            vung = objDanhBa.Vung;
                                                            maDoiTac = objDanhBa.MaDoiTac;
                                                            LoaiXe = objDanhBa.LoaiXe;
                                                            KinhDo = objDanhBa.GPS_KinhDo;
                                                            ViDo = objDanhBa.GPS_ViDo;
                                                            GhiChuTiepNhan = objDanhBa.GhiChuTiepNhan;
                                                        }
                                                        else
                                                        {
                                                            objCuocGoiMoi.CuocGoiLaiID = 0;
                                                            objCuocGoiMoi.ThoiGianGoiLai = "";
                                                            objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                                        }
                                                    }
                                                    else if (!isCuocGoiLai)
                                                    {
                                                        objCuocGoiMoi.CuocGoiLaiID = 0;
                                                        objCuocGoiMoi.ThoiGianGoiLai = "";
                                                        objCuocGoiMoi.SoLanGoiLaiGanDay = 0;
                                                    }
                                                }
                                            }
                                            vung = 0;

                                            // kiem tra nhung so dien thoai la so dau khong phai la 01,09,04
                                            //objCuocGoiMoi.PhoneNumber = DatLaiSoDienThoaiSai(objCuocGoiMoi.PhoneNumber, soDacBiet);
                                            objCuocGoiMoi.LoaiXe = LoaiXe;
                                            objCuocGoiMoi.GPS_KinhDo = KinhDo;
                                            objCuocGoiMoi.GPS_ViDo = ViDo;
                                            objCuocGoiMoi.GhiChuTiepNhan = GhiChuTiepNhan;
                                            #endregion
                                            if (chkGhiLogForDebug.Checked)
                                                LogError.WriteLogErrorForDebug("Insert CuocGoi-" + diaChi + "-" + objCuocGoiMoi.GPS_KinhDo);

                                            objCuocGoiMoi.CuocGoiID = TaxiCapture.InsertCuocGoiLanDauByDiaChiFromMEM_V2(this.g_ConnecString,
                                                                                                                    objCuocGoiMoi.Line,
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
                                                                                                                    objCuocGoiMoi.GhiChuTiepNhan,
                                                                                                                   objCuocGoiMoi.GPS_KinhDo,
                                                                                                                   objCuocGoiMoi.GPS_ViDo,
                                                                                                                   diaChiTra);
                                            if (objCuocGoiMoi.CuocGoiID > 0)
                                            {                                                
                                                lblGoiDen.Invoke((MethodInvoker)delegate
                                                {
                                                    lblGoiDen.Text = "Gọi đến : " + Line + " - " + SoDienThoai + " - [" + g_CuocGoiLuuLai.Count.ToString() + "]";
                                                });
                                            }
                                            else
                                            {
                                                LogError.WriteLogInfo("Gọi đến false :  " + SoDienThoai);
                                            }
                                        }
                                        else
                                        {
                                            //Nếu Hiển thị popup ở trạng thái 1
                                            //Nếu số điện thoại ở trạng thái 1 bị sai thì lấy sdt ở trạng thái 3 update lại
                                            if (!str_SoDienThoai_TT1.Equals(SoDienThoai))
                                            {
                                                TaxiCapture.Update_Lai_SoDienThoai(g_ConnecString, objCuocGoiMoi.CuocGoiID, SoDienThoai);
                                            }
                                        }
                                        objCuocGoiMoi.ThoiDiemNgheMay = ThoiDiem;
                                        g_ListCuocGoiChoXuLy[iIndexRemove] = objCuocGoiMoi;
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError(" UDP Trang thai 3 :  " + e.Argument, ex);
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
                                        //Capnhat DB  - Duration , FileAmThanh, so chuong
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
                                LogError.WriteLogError(" UDP Trang thai 6 :  " + e.Argument, ex);
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
                                            g_ListCuocGoiChoXuLy.RemoveAt(iIndexRemove);
                                            if (g_ListCuocGoiChoXuLy != null)
                                                statusLblSoCuocChoXuLy.Text = String.Format("Đang thoại :  : {0}", g_ListCuocGoiChoXuLy.Count);
                                        }
                                        catch (Exception ex)
                                        {
                                            LogError.WriteLogError("InsertCuocGoiLanDauByDiaChiFromMEM_GoiNho_SoChuong: ",ex);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError("UDP Trang thai 5 :  " + e.Argument, ex);
                            }
                        }
                        #endregion
                        break;
                }
            }
            catch (Exception ext)
            {
                LogError.WriteLogError("UDP bw :  " + e.Argument, ext);
            }
        }

        /// <summary>
        /// Dat lai so dien thoai khi sai
        /// </summary>
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
        /// SO LAN GOI LAI
        /// hàm thực hiện lưu lại cuộc gọi
        /// để xác định cuộc gọi lại
        /// Them vao ds cuoc goi da co, 
        /// Neu trả về true là lưu được, trả về false không luu, lỗi số
        /// </summary>
        private bool LuuCuocGoiXuLySoLanGoiLai(string soDienThoai, DateTime thoiDiem, long IDCuocGoi, string LoaiXe)
        {
            if (g_CuocGoiLuuLai == null)
            {
                g_CuocGoiLuuLai = new Dictionary<string, StructCuocGoi>();
            }
            if (g_CuocGoiLuuLai.ContainsKey(soDienThoai)) // neu da ton tai trong ds thi cap nhat thoi diem va so lan goi
            {

                StructCuocGoi cuocGoi = g_CuocGoiLuuLai[soDienThoai];
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
                if (listSoDienThoaiXoa.Count > 0)
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

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi trong BackgroudWorker" + e.Result, new Exception(e.Error.Message));
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
                    if ((ListCuocGoiCanXoaIndex.Count > 0))
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
            catch 
            {
                return 10;
            }
        }
        #endregion XuLyCaptureCuocGoiUDP

        #region ----------------CUOC GOI DI

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
    }
}