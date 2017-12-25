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
using EFiling.Utils;
using System.Collections;

namespace TaxiCapture
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// Khai bao du lieu toan cu
        /// </summary>
        // Khai bao timer
        private bool g_Thoat = false;
        private System.Timers.Timer timerCapture = null ;
        private DateTime g_ThoiDiemLayDuLieuTruocDay = DateTime.Now;

        private string g_FileLogIncomingPath = null;
        private string g_FileInComPath= null;
        private string g_FileVOCPath = null;
        /// <summary>
        /// biến kiểm soát kết thúc hết các thủ tục trong timer thì mới thực hiện tiếp timer
        /// </summary>
        /// 
       
        private bool g_bKetThucBackgroundWork = true;
        private bool g_bTimerHoanThanh = true;
        private int g_iKhoiDongLai = 0;
        private int g_iSoGiayChuaKetThucLenh = 0;
        private int g_BlinkIcon = 0;

        int g_iCount = 0;

        private List<StructCuocGoi> g_ListCuocGoiLogInComing = new List<StructCuocGoi>();
         
      

        private bool g_HasSoDauTongDai = false;
        private string  g_ConnecString = "";




        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        /// <summary>
        /// Khoi tao du lieu luc dau
        /// </summary>
        private void Init()
        {
            // Lay thong tin he thong
            ThongTinCauHinh.LayThongTinCauHinh();
            if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0) g_HasSoDauTongDai = true;
            else g_HasSoDauTongDai = false;
            g_ConnecString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];


            g_FileLogIncomingPath = Configuration.LogIncomingPath();
            g_FileInComPath = Configuration.InComFilenamePath();
            g_FileVOCPath = Configuration.VocFilePath();

            if ((!FileTools.IsExsitFile(g_FileLogIncomingPath)) || (!FileTools.IsExsitFile(g_FileInComPath)) || (!FileTools.IsExsitFile(g_FileVOCPath)))
            {
                MessageBox.Show("Không tồn tại file thông tin cuộc gọi.Liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            // check connection 
            if (!DieuHanhTaxi.CheckConnection())
            {
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }  
            /// end check connection
            timerCapture = new System.Timers.Timer(500); // nửa giây quét một lần.
            timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Elapsed);
            timerCapture.Enabled = true;
            try
            {
                // Xoa toan bo du lieu hien tai cua he thong phan cung
                TaxiCapture.DeletePhoneCallInCom(DateTime.Now, g_FileInComPath);
                TaxiCapture.DeletePhoneCallLogIncomming(DateTime.Now, g_FileLogIncomingPath);
                TaxiCapture.DeletePhoneCallVocFile(DateTime.Now, g_FileVOCPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi thiết lập (reset) các cuộc gọi.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                 
            }

            CaptureCuocGoiDi();
            TaxiCapture.DeletePhoneCallVocFile_CuocGoiDi( g_FileVOCPath);
            
            g_bKetThucBackgroundWork = true;
            g_bTimerHoanThanh = true;
            g_iKhoiDongLai = 0;
        }
        
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
                if (g_BlinkIcon == 0)
                {
                    notifyIcon1.Icon = global::TaxiOperation_CallCapture2.Properties.Resources.Taxi;
                    g_BlinkIcon = 1;
                }
                else
                {
                    notifyIcon1.Icon = global::TaxiOperation_CallCapture2.Properties.Resources.TongDai;
                    g_BlinkIcon = 0;
                }
                
                if (g_bTimerHoanThanh)
                {
                    g_bTimerHoanThanh = false;
                    List<StructCuocGoi> ListLog;
                    if (!ThongTinCauHinh.HasTongDai)
                        ListLog = TaxiCapture.GetNhungCuocGoiMoiCuaLogInComing(g_FileLogIncomingPath);
                    else // Co lay du lieu tu tong dai 
                        ListLog = TaxiCapture.GetNhungCuocGoiMoiCuaTongDai_COMPort(g_ConnecString , g_ThoiDiemLayDuLieuTruocDay);
                    //cap nhat vao danh sach theo doi cuoc goi nho + cuoc goi chua co chuong, thoi luong cuoc goi
                    if ((ListLog != null) && (ListLog.Count > 0))
                    {
                        List<StructCuocGoi> ListLogNew = InsertCuocGoiLanDauLogIncoming(ListLog);
                        //cong them vao g_ListCuocGoiLogInComing
                        AddToListLogIncoming(ListLogNew);

                        ListLog.Clear();
                        ListLog = null;
                    }

                    // Xử lý backgroundwordker
                    if (g_bKetThucBackgroundWork)
                    {

                        g_bKetThucBackgroundWork = false;
                        BackgroundWorker bw = new BackgroundWorker();
                        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

                        bw.RunWorkerAsync();

                    }

                    g_bTimerHoanThanh = true;
                    g_ThoiDiemLayDuLieuTruocDay = DateTime.Now;
                }

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi trong timer.", ex);
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // kiem tra la co cuoc goi moi hoac cuoc goi dang theo doi thi thuc hien
            if ((g_ListCuocGoiLogInComing != null) && (g_ListCuocGoiLogInComing.Count > 0))
            {
                XacDinhCuocGoiNho_InCom();                 
                XacDinhCuocGoiCoDuration_VOC();
            }

            // Xoa nhung truong hop du thua
            g_iCount++;
            if (g_iCount > 300)
            {
                // Xoa nhung cuoc du thua
                DeleteNhungCuocDuThua();
                g_iCount = 0;
            }


            if (DateTime.Now.Hour == 3 && DateTime.Now.Minute == 1 && DateTime.Now.Second < 5)
            {
                CaptureCuocGoiDi();
                TaxiCapture.DeletePhoneCallVocFile_CuocGoiDi(g_FileVOCPath);
            
            }
            
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi trong BackgroudWorker", new Exception(e.Error.Message));
            }
            g_bKetThucBackgroundWork = true;
            
        }

        private void DeleteNhungCuocDuThua()
        {
           
            if ((g_ListCuocGoiLogInComing == null) || (g_ListCuocGoiLogInComing.Count <= 0)) return;
            List<int> ListCuocGoiCanXoaIndex = new List<int>();
            int Index = -1;
            for (int i = 0; i < g_ListCuocGoiLogInComing.Count; i++)
            {
                Index++;
                TimeSpan timespan = DateTime.Now - g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen;
                if (timespan.Minutes>5)  // có cuộc gọi nhỡ
                {
                    ListCuocGoiCanXoaIndex.Add(Index);
                     
                }
            }

            /// xóa trong g_ListCuocGoiLogInComing
            /// ...
            if ((ListCuocGoiCanXoaIndex != null) && (ListCuocGoiCanXoaIndex.Count > 0) )
            {
                foreach (int IndexXoa in ListCuocGoiCanXoaIndex)
                {
                    if ((IndexXoa >= 0) && (g_ListCuocGoiLogInComing.Count > 0))
                        g_ListCuocGoiLogInComing.RemoveAt(IndexXoa);
                }

                ListCuocGoiCanXoaIndex.Clear();
                ListCuocGoiCanXoaIndex = null;
            }
          
             
        }


         
        #region CUOCGIO_MOI - LogInComing
        /// <summary>
        ///  cong them vao g_ListCuocGoiLogInComing
        /// </summary>
        /// <param name="ListLog"></param>
        private void AddToListLogIncoming(List<StructCuocGoi> ListLog)
        {
            
            if (g_ListCuocGoiLogInComing == null) g_ListCuocGoiLogInComing = new List<StructCuocGoi>();
            for (int i = 0; i <ListLog.Count; i++)
            {
                g_ListCuocGoiLogInComing.Add(ListLog[i]);
            }
        }
        /// <summary>
        /// hàm chèn một ds cuộc gọi mới
        ///   - trả về 1 ds cuộc gọi mới có thay đổi IDCuôcGọi
        /// </summary>
        /// <param name="ListLog"></param>
        /// <returns></returns>
        private List<StructCuocGoi>  InsertCuocGoiLanDauLogIncoming(List<StructCuocGoi> ListLog)
        {
           
            List<StructCuocGoi> ListLogReturn = new List<StructCuocGoi>();
                // Cap nhat database - chèn cuộc gọi lần đầu
                for(int i=0;i < ListLog.Count ;i++) 
                {
                    StructCuocGoi objCuocGoiNew = ListLog[i];
                    /// Lap lai 5 lan neu khong chen duoc
                    
                    int iLan = 0;
                    long IDCuocGoi = -1;
                    while ((IDCuocGoi<=0) && (iLan < 5))
                    {
                         string SoDienThoai = objCuocGoiNew.PhoneNumber ;
                        // 437856099 or 906228313 thi them 0 
                        if ((SoDienThoai.Length >= 9) && (SoDienThoai.Substring(0,1) != "0")) SoDienThoai = "0" + SoDienThoai;
                        if (SoDienThoai.Length > 10)     SoDienThoai = TaxiCapture.LocSoDienThoai(SoDienThoai);

                        IDCuocGoi = TaxiCapture.InsertCuocGoiLanDau(this.g_ConnecString, objCuocGoiNew.Line, SoDienThoai, objCuocGoiNew.ThoiDiemGoiDen);
                        iLan++;

                        if (IDCuocGoi <= 0)
                            if (IDCuocGoi == -2) iLan = 5;
                            else
                                System.Threading.Thread.Sleep(50);
                    }
                    if ((IDCuocGoi <= 0) || (iLan>=5))
                    {
                        LogError.WriteLogError("Loi  : luu du lieu vao database [InsertCuocGoiLanDau], " + IDCuocGoi.ToString(), new Exception("Loi luu lan dau cuoc goi tu log file"));

                    }
                    else
                    {
                        objCuocGoiNew.CuocGoiID = IDCuocGoi;
                        ListLogReturn.Add(objCuocGoiNew);
                    }
                }

                return ListLogReturn;
            
        }
        #endregion CUOCGIO_MOI

        
        #region CUOCGOINHO - InCom
        /// <summary>
        /// xac dịnh các cuộc gọi nhỡ trong g_ListCuocGoiLogInComing
        /// </summary>
        private void XacDinhCuocGoiNho_InCom()
        {
            
            // lay thong tin cuoc goi
            // NEU co : luu Index de xoa list cuoc goi cho giai quyet
            // NEU khong :m...
            if ((g_ListCuocGoiLogInComing != null) && (g_ListCuocGoiLogInComing.Count > 0))
            {
               
                UpdateDataBase_And_DeleteCuocGoiNho();
            }
        }

        /// <summary>
        /// cập nhật db cuộc gọi nhỡ
        /// xóa trong g_ListCuocGoiLogInComing ds cuộc gọi đang theo doi
        /// </summary>
        /// <param name="ListInCom"></param>
        private void UpdateDataBase_And_DeleteCuocGoiNho()
        {
             
            List<int> ListCuocGoiCanXoaIndex = new List<int>();
            int Index = -1;
            for (int i = 0; i < g_ListCuocGoiLogInComing.Count; i++ )
            {
                Index++;
                DateTime ThoiGianKhongNhacMay = TaxiCapture.GetThongTinCuaCuocGoiNhoInCom(g_ListCuocGoiLogInComing[i].PhoneNumber, g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, g_FileInComPath);
                if (ThoiGianKhongNhacMay != DateTime.MinValue)  // có cuộc gọi nhỡ
                {
                    ListCuocGoiCanXoaIndex.Add(Index);
                    // cap nhat DB 
                    if (!TaxiCapture.Update_DienThoai_CuocGoiNho(this.g_ConnecString, g_ListCuocGoiLogInComing[i].CuocGoiID, GetSoChuong(g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, ThoiGianKhongNhacMay), "gọi nhỡ", TrangThaiCuocGoiTaxi.TrangThaiKhac, TrangThaiLenhTaxi.KetThucCuaDienThoai))
                    {
                        LogError.WriteLogError("Loi luu xuong DB", new Exception("Loi luu cuoc goi nho"));

                    }
                }
            }                

            /// xóa trong g_ListCuocGoiLogInComing
            /// ...
            if ((ListCuocGoiCanXoaIndex != null)&& (ListCuocGoiCanXoaIndex.Count > 0))
            {
                foreach (int IndexXoa in ListCuocGoiCanXoaIndex)
                {
                    if ((IndexXoa >= 0) && (g_ListCuocGoiLogInComing.Count >0))
                         g_ListCuocGoiLogInComing.RemoveAt(IndexXoa); 
                }
                ListCuocGoiCanXoaIndex.Clear();
                ListCuocGoiCanXoaIndex = null;
            }
           
             
        }

        #endregion CUOCGOINHO

        #region CUOCGOI_CO_NGHEMAY-- VOC

        /// <summary>
        /// xac điịnh cuoc goi da nghe máy
        /// có luôn duration + file voice
        /// </summary>
        private  void   XacDinhCuocGoiCoNgheMay_VOC()
        {         
            
            if ((g_ListCuocGoiLogInComing == null) || (g_ListCuocGoiLogInComing.Count <= 0)) return;
            int len = g_ListCuocGoiLogInComing.Count ;
            for (int i = 0; i < len  ;i++ )
            {
                if (g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen > g_ListCuocGoiLogInComing[i].ThoiDiemNgheMay) // chi chon nhung cuoc chua nghe may
                {
                    DateTime ThoiGianNhacMay = TaxiCapture.GetThongTinCuaCuocGoiDaNgheMay_VOC(g_ListCuocGoiLogInComing[i].PhoneNumber, g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, g_FileVOCPath);
                    if (ThoiGianNhacMay != DateTime.MinValue)  // có cuộc gọi nhỡ
                    {

                        // cap nhat DB 
                        if (!TaxiCapture.Update_DienThoai_SoChuong(this.g_ConnecString, g_ListCuocGoiLogInComing[i].CuocGoiID, GetSoChuong(g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, ThoiGianNhacMay)))
                        {
                            LogError.WriteLogError("Loi luu xuong DB", new Exception("Loi luu update so chuong"));                            
                        }
                        else
                        {
                            StructCuocGoi cuocgoi = new StructCuocGoi();
                            cuocgoi.CuocGoiID = g_ListCuocGoiLogInComing[i].CuocGoiID;
                            cuocgoi.PhoneNumber = g_ListCuocGoiLogInComing[i].PhoneNumber;
                            cuocgoi.fileAmThanhPath = g_ListCuocGoiLogInComing[i].fileAmThanhPath;
                            cuocgoi.KhoangThoiGianHoiThoai = g_ListCuocGoiLogInComing[i].KhoangThoiGianHoiThoai;
                            cuocgoi.KieuCuocGoi = g_ListCuocGoiLogInComing[i].KieuCuocGoi;
                            cuocgoi.Line = g_ListCuocGoiLogInComing[i].Line;
                            cuocgoi.ThoiDiemGoiDen = g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen;
                            cuocgoi.ThoiDiemKhongNhacMay = g_ListCuocGoiLogInComing[i].ThoiDiemKhongNhacMay;
                            cuocgoi.ThoiDiemNgheMay = ThoiGianNhacMay;
                            g_ListCuocGoiLogInComing[i] = cuocgoi ;
                        }
                    }
                }
                
            }

            
        }

        /// <summary>
        /// lấy nhưng cuộc gọi đã có duration, và cập nhật BD
        /// </summary>
        private void XacDinhCuocGoiCoDuration_VOC()
        {
           
            try
            {
                List<int> ListInDexDurationXoa = new List<int>();             
                int index = -1;
                if ((g_ListCuocGoiLogInComing == null) || (g_ListCuocGoiLogInComing.Count <= 0)) return;
                for (int i = 0; i < g_ListCuocGoiLogInComing.Count; i++)
                {
                    
                        index++;
                        DateTime Duration;
                        string FileAmThanh;
                        DateTime ThoiDiemBatDauNghe;
                        TimeSpan timeSpan = DateTime .Now - g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen;
                        if (timeSpan.TotalSeconds > 5) // nhung cuoc cach thoi gian nghe may it nhat 5 giay thi moi xu ly
                        {

                            bool bOK = TaxiCapture.GetThongTinCuaCuocGoiDaNgheMayCo_Duration_VOC(g_ListCuocGoiLogInComing[i].PhoneNumber, g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, g_FileVOCPath, out ThoiDiemBatDauNghe, out Duration, out FileAmThanh);

                            if (bOK)
                            {

                                CapNhatDuratoin_FileAmThanh_LogInComing(g_ConnecString, g_ListCuocGoiLogInComing[i].PhoneNumber, g_ListCuocGoiLogInComing[i].ThoiDiemNgheMay, GetSoChuong(g_ListCuocGoiLogInComing[i].ThoiDiemGoiDen, ThoiDiemBatDauNghe), Duration, FileAmThanh);
                                ListInDexDurationXoa.Add(index);
                            }
                        }
                }
                
                if ((ListInDexDurationXoa!=null) && (ListInDexDurationXoa.Count > 0))
                {
                    foreach (int indexXoa in ListInDexDurationXoa)
                    {
                        if( (indexXoa>=0) && (g_ListCuocGoiLogInComing.Count >0))
                            g_ListCuocGoiLogInComing.RemoveAt(indexXoa);
                    }
                    ListInDexDurationXoa.Clear();
                    ListInDexDurationXoa = null;
                }
              

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi  XacDinhCuocGoiCoDuration_VOC ", ex);
            }
        }
        /// <summary>
        /// cập nhật duration vào database
        /// xoa các cuộc goi này đi
        /// </summary>
        /// <param name="objCuocGoi"></param>
        /// <param name="Duration"></param>
        /// <param name="FileAmThanh"></param>
        private void CapNhatDuratoin_FileAmThanh_LogInComing(string ConnectionString, string PhoneNumber, DateTime ThoiDiemNgheMay, int SoChuong, DateTime Duration, string FileAmThanh)
        {
            try
            {

                for (int i = 0; i < g_ListCuocGoiLogInComing.Count;i++)
                {
                   
                    if (PhoneNumber == g_ListCuocGoiLogInComing[i].PhoneNumber)
                    {
                        ///Capnhat DB  - Duration , FileAmThanh, so chuong
                        if (!TaxiCapture.Update_DienThoai_KetThucCuocGoiDenCoBatMay(ConnectionString, g_ListCuocGoiLogInComing[i].CuocGoiID, SoChuong ,Duration, FileAmThanh, TrangThaiCuocGoiTaxi.TrangThaiKhac, TrangThaiLenhTaxi.KhongTruyenDi))
                        {
                            LogError.WriteLogError("Loi luu xuong DB Update_DienThoai_KetThucCuocGoiDenCoBatMay ", new Exception("Loi luu cuoc goi da Bat May"));
                        }
                        
                    }
                }                 
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi  CapNhatDuratoin_FileAmThanh_LogInComing ", ex);
            }
        } 
         
        #endregion CUOCGOI_CONGHEMAY-- VOC

        #region Tien ich

         
        /// <summary>
        /// xoa số điện thoại đầu của số từ tổng đài trả về ('9','5')
        /// </summary>
        /// <param name="PhoneNumberFromTongDai"></param>
        /// <returns></returns>
        private string XoaSoDauCuaTongDai(string PhoneNumberFromTongDai)
        {
            string PhoneNumber = PhoneNumberFromTongDai;
            string SoDauTongDai = StringTools.TrimSpace(Configuration.GetSoDauCuaTongDai());
            if (SoDauTongDai.Length > 0) // có tồn tại số từ tổng đài
            {
                if (PhoneNumber.Substring(0, 1) == SoDauTongDai)
                {
                    PhoneNumber = PhoneNumber.Substring(1, PhoneNumber.Length - 1);
                }
            }
            return PhoneNumber; // return so dien thoai da qua xu ly
        }

        #endregion
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
                LogError.WriteLogError("Loi tinh so chuong : ", ex);
                return 10;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show ("Thoát chương trình sẽ không thể bắt số điện thoại-điều hành cuộc gọi");
            if (MessageBox.Show(this,"Bạn có đồng ý đồng ý thoát chương trình không?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Error  ) == DialogResult.OK)
            {
                g_Thoat = true;
                Application.Exit();
                
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_Thoat) e.Cancel = false;
            else e.Cancel = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
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
            this.WindowState =FormWindowState.Minimized;

        }

        #region CUOC GOI DI

        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            try
            {
                 
                DataTable dt = new DataTable();
                dt = TaxiCapture.GetEarlyPhoneDialOut(g_FileVOCPath);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
                        if (!objGoiDi.Insert())
                        {
                            LogError.WriteLogError("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi luu xuong DB cuoc goi di ", ex);
            }
        }


        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Restart();
        }
    }
}