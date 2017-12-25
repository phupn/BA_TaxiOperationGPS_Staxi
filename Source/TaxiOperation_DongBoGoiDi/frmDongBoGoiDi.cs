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
using System.Diagnostics;
using Taxi.Business.KhachDat;

namespace DongBoGoiDi
{
    public partial class frmDongBoGoiDi : Form
    {
        /// <summary>
        /// Khai bao du lieu toan cu
        /// </summary>
        // Khai bao timer
        private bool g_Thoat = false;
        private System.Timers.Timer timerCapture = null ; 
        private int g_BlinkIcon = 0; 
        long g_iCount = 0; 
        private List<StructCuocGoi> g_ListCuocGoiChoXuLy = new List<StructCuocGoi>(); 
        private bool g_HasSoDauTongDai = false;
        private string  g_ConnecString = "";
        private int g_TimerStepGetDatHen = 0;
        private long g_iCountUpdateVOCVoiceFile = 0;  // xuly doc VOC file ghi am
        private DateTime g_ThoiDiemLayTruocVOC;       // xuly doc VOC file ghi am
        private string g_FileVOCPath = null;
        private int g_iCountXoaCuocTuDong = 0;        // dem xoa tu dong 
        private int g_SoCuocGoiGiuLai = 800;  // So cuộc gọi giữ lại trong trường hợp khách đông.
        private string g_ListLines = string.Empty;
        private int g_TimeSecondOnDay = 0;
        private bool g_ChuaThucHien = false;
        //--------------------------------------------------------------------
        public frmDongBoGoiDi()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            g_ChuaThucHien = false;
            this.Init(); 
        }

        /// <summary>
        /// Khoi tao du lieu luc dau
        /// </summary>
        private void Init()
        {
            timerCapture = new System.Timers.Timer(1000); // nửa giây quét một lần.
            timerCapture.Elapsed += new System.Timers.ElapsedEventHandler(timerCapture_Elapsed);
            timerCapture.Enabled = true;
               

            g_ConnecString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            // Lay thong tin he thong
            ThongTinCauHinh.LayThongTinCauHinh();

            g_ThoiDiemLayTruocVOC = DateTime.Now;

            if (ThongTinCauHinh.SoDauCuaTongDai.Length > 0) g_HasSoDauTongDai = true;
            else g_HasSoDauTongDai = false;
          
            g_SoCuocGoiGiuLai = Configuration.GetSoCuocGoiGiuLai();
            g_FileVOCPath = Configuration.VocFilePath();

            if ((!FileTools.IsExsitFile(g_FileVOCPath)))
            {
                MessageBox.Show("Không tồn tại file thông tin cuộc gọi.Liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }
            else
            {
                TaxiCapture.DeletePhoneCallVocFile(DateTime.Now, g_FileVOCPath);
            }


            // check connection 
            if (!DieuHanhTaxi.CheckConnection())
            {
                MessageBox.Show("Không kết nối được với cơ sở dữ liệu.Cần liên lạc với quản trị hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }  
            /// end check connection
    
               
            // Thong tin status bar
            statusLblKhoiDongLuc.Text = " Khởi động : " + string.Format("{0:HH:mm dd/MM}", DateTime.Now);
            statusLblSoCuocChoXuLy.Text = " Cuộc chờ xử lý : 0";
            statusLblServer.Text = " Server: " +  GetServerName(g_ConnecString);
            statusLblDatabase.Text =" DB: " + GetDatabaseName(g_ConnecString); 
            this.Text = Configuration.GetCompanyName() + " - " + this.Text;

            g_ListLines = TaxiCapture.GetLineDialOutCS(g_ConnecString);  // lấy line của CS

            g_TimeSecondOnDay = (int)DateTime.Now.TimeOfDay.TotalSeconds; 
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
                return arrString[1].Replace("Initial Catalog=","");
            }
            return "";
        }

        private string GetServerName(string ConnectString)
        {
            string[] arrString = ConnectString.Split(";".ToCharArray());
            if (arrString != null && arrString.Length > 2)
            {
                return arrString[0].Replace("Data Source=", "");
            }
            return "";
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
            lblRuntime.Invoke(
                (MethodInvoker)delegate() {
                    lblRuntime.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
                }  
                );
           
            if (DateTime.Now.Hour == 3 && !g_ChuaThucHien)
            {
                try{
                DateTime ngayThucHien = DateTime.Now.AddDays(-1);
                DateTime tuNgay = new DateTime(ngayThucHien.Year, ngayThucHien.Month, ngayThucHien.Day, 0, 0, 0);
                DateTime denNgay = new DateTime(ngayThucHien.Year, ngayThucHien.Month, ngayThucHien.Day, 23, 59, 59);
                // Lấy cuộc gọi đi trong VOC (Access) 
                string fileVOCPath = VocFilePath(tuNgay);
                TaxiCapture.DeleteXoaCuocGoiDi(g_ConnecString, tuNgay, denNgay, g_ListLines);

                List<VOC> listCuocGoiDi = TaxiCapture.GetThongTinCuocGoiDiTrongVOC(tuNgay, denNgay, fileVOCPath, g_ListLines);
                // lấy ds đăng nhập hiện thống của các máy trong CS
                List<CheckInCheckOut> listCheckIO = TaxiCapture.GetCheckInCheckOut(g_ConnecString, tuNgay, denNgay);

                // Quét lần lượt các cuốc gọi đi 
                // Lấy thông số Line + Thời điểm gọi tìm ra nhân viên đang làm việc.
                if (listCuocGoiDi != null && listCuocGoiDi.Count > 0)
                {
                    foreach (VOC cuocGoi in listCuocGoiDi)
                    {
                        string username = TaxiCapture.GetUserGoiDi(cuocGoi.Channel.ToString(), cuocGoi.StartTime, listCheckIO);
                        TaxiCapture.InsertCuocGoiDi(g_ConnecString, cuocGoi, username);
                    }
                }
                }
                catch(Exception ex)
                {

                }
                g_ChuaThucHien = true;
                lblLanThucHienGanDay.Invoke(
                    (MethodInvoker)delegate()
                    {
                        lblLanThucHienGanDay.Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
                    }
                );
                
            }

            if (DateTime.Now.Hour != 3)
            {
                g_ChuaThucHien = false;
            }
        }

        /// <summary>
        /// Ham lay ds VOC va cap nhat file ghi am
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWorkUpdateVOCVoiceFile(object sender, DoWorkEventArgs e)
        {
            DateTime temp = DateTime .Now ;
            ThucHienLayFileGhiAm(g_ThoiDiemLayTruocVOC, temp,g_FileVOCPath );
            g_ThoiDiemLayTruocVOC = temp;
        }

        

        private void bw_RunWorkerCompletedUpdateVOCVoiceFile(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi bw_DoWorkUpdateVOCVoiceFile  ", new Exception(e.Error.Message));
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
            if (ThongTinCauHinh.KichHoachTaxiGroupDon)
            {
                if (g_SoCuocGoiGiuLai < 300) g_SoCuocGoiGiuLai = 300; // kiểm tra lại giá trị
                DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(g_SoCuocGoiGiuLai);
            }
            else
                DieuHanhTaxi.XoaTuDongCacCuocKhachQuaLau(30, ThongTinCauHinh.CacVungTongDai);
        }
        private void bw_RunWorkerCompletedUpdateNhanVien(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi XoaTuDongCacCuocKhachQuaLau  ", new Exception(e.Error.Message));
            }
        }
        /// <summary>
        /// Hamf thuc hien lay file ghi am tu thoi diem ThoiDiemLayTruoc toi bay gio
        /// </summary>
        /// <param name=" "></param>
        private void ThucHienLayFileGhiAm(DateTime  TuThoiDiem, DateTime DenThoiDiem ,string VOCFilenamePath)
        {
            // Lay VOC file 
            List<VOC> lstVOC = new List<VOC>();
            lstVOC = TaxiCapture.GetThongTinCuocGoiTrongVOC(TuThoiDiem, DenThoiDiem, VOCFilenamePath);
            if (lstVOC != null && lstVOC.Count > 0)
            {
                foreach (VOC objVoc in lstVOC)
                { 
                     
                     TaxiCapture.InsertVOC(objVoc, this.g_ConnecString);
                    // LogError.WriteLogError(string.Format("VOC : line {0}, phone : {1}, thoidiem : {2:HH:mm:ss dd/MM},Foming : {3}, file : {4} ", objVoc.Channel, objVoc.Code, objVoc.StartTime,objVoc.Fomin,objVoc.FilePath), new Exception(""));
   
                }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Restart();
        }
        #region XuLyCaptureCuocGoiUDP

        /// <summary>
        /// ham kiem tra Popup con dang chay hay khong
        /// </summary>
        /// <returns></returns>
        private bool KiemTraPOPUPDangChay()
        {
            Process[] processlist = Process.GetProcesses();

            foreach(Process theprocess in processlist){
                if (theprocess.ProcessName.ToLower() == "popup")
                    return true;
            }

            return false  ;
        }
        
        /// ham thuc hien xu ly cac cuoc goi tu UDP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {                         
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            if (e.Error != null)
            {
                LogError.WriteLogError("Loi  : Loi trong BackgroudWorker" + e.Result.ToString (), new Exception(e.Error.Message));
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

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Loi trong DeleteNhungCuocDuThua ", ex);
            }
        }
        #endregion XuLyCaptureCuocGoiUDP

        /// <summary>
        /// ham tra ve ds connection string cua cong ty ung voi line cua cong ty do
        /// </summary>
        /// <param name="Line"></param>
        /// <returns></returns>
        //private string GetConnectionStringFromLines(string Line)
        //{
        //    if (Line != null && Line.Length > 0)
        //    { 

                 

                
        //        if (KiemTraLineTrongListLine(Line,g_LinesHN) ) return g_ConnectionStringHN;
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
        private bool KiemTraLineTrongListLine(string Line, string Lines)
        {
            if (Lines.Length > 0 && Line.Length > 0)
            {
                string[] arrLine = Lines.Split(";".ToCharArray());
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i] == Line) return true;
                }
            }

            return false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
         

        }



        #region ----------------Khách đặt hẹn--------------------------------
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

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = new DateTime(dateNgay.Value.Year, dateNgay.Value.Month, dateNgay.Value.Day, 0, 0, 0);
            DateTime denNgay = new DateTime(dateNgay.Value.Year, dateNgay.Value.Month, dateNgay.Value.Day, 23, 59, 59);
            // Lấy cuộc gọi đi trong VOC (Access) 
            string fileVOCPath = VocFilePath(tuNgay);
            TaxiCapture.DeleteXoaCuocGoiDi(g_ConnecString, tuNgay, denNgay,g_ListLines);

            List < VOC > listCuocGoiDi = TaxiCapture.GetThongTinCuocGoiDiTrongVOC(tuNgay, denNgay, fileVOCPath,g_ListLines);
            // lấy ds đăng nhập hiện thống của các máy trong CS
            List<CheckInCheckOut> listCheckIO = TaxiCapture.GetCheckInCheckOut(g_ConnecString, tuNgay, denNgay);

            // Quét lần lượt các cuốc gọi đi 
            // Lấy thông số Line + Thời điểm gọi tìm ra nhân viên đang làm việc.
            if (listCuocGoiDi != null && listCuocGoiDi.Count > 0)
            {
                foreach (VOC cuocGoi in listCuocGoiDi)
                {
                    string username = TaxiCapture.GetUserGoiDi(cuocGoi.Channel.ToString(), cuocGoi.StartTime, listCheckIO);
                    TaxiCapture.InsertCuocGoiDi(g_ConnecString, cuocGoi, username);
                }
            }
            MessageBox.Show(" Thực hiện xong lấy cuộc gọi ngày : " + tuNgay.ToShortDateString());
        } 
        private string VocFilePath(DateTime time)
        {
            return ThongTinCauHinh.ThuMucDuLieuTanasonic + "\\" + "Voc" + time.Year.ToString() + "-" + StringTools.GeMonthString(time.Month) + ".mdb";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
    }
}