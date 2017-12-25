using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Janus.Windows.GridEX;
using Taxi.Utils;

namespace Taxi.GUI.BaoCao
{
    public partial class frm_1_3_BCChiTietGoiDi : Form
    {
        private fmProgress m_fmProgress = null;
        private DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;

        public frm_1_3_BCChiTietGoiDi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent;
          //  LoadData(calTuNgay.Value, calDenNgay.Value);

            btnRefresh.Enabled = false ;
            btnPrint.Enabled = false ;
            btnExportExcel.Enabled = false ;
           // LoadDuLieuCuocGoiDiTuPhanCung();
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value) )
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

                SetUnActiveRefreshButton(); 
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {


             
            if (m_fmProgress.Cancel)
            {
                // Set the e.Cancel flag so that the WorkerCompleted event
                // knows that the process was canceled.
                e.Cancel = true;
                return;
            }
            string PhoneNumber = StringTools.TrimSpace(txtPhoneNumber.Text);
            string Line = StringTools.TrimSpace(txtLine.Text);
            if ((timeThoiGianDamThoai.Value != new DateTime(1900, 1, 1, 0, 0, 0)) || (PhoneNumber.Length > 0))
            {
                g_dt = CuocGoiDi.GetDSCuocGoiDi(calTuNgay.Value, calDenNgay.Value, timeThoiGianDamThoai.Value, PhoneNumber,Line);
                gridBaoCaoBieuMau1.DataSource = g_dt;
               
            }
            else LoadData(calTuNgay.Value, calDenNgay.Value);

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
                // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }
        }

        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {

            g_dt = CuocGoiDi.GetDSCuocGoiDi(calTuNgay.Value, calDenNgay.Value);
            gridBaoCaoBieuMau1.DataSource = g_dt;
           
        }
        
       

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // frmInBaoCao frmPrint = new frmInBaoCao();
            // string strCuocGoiTren = string.Format("{0:mm:ss}", timeThoiGianDamThoai.Value); 
            //frmPrint.InBaoCaoBieuMau13(Configuration.GetReportPath() + "\\Baocao_Bieumau13.rpt", g_dt,strCuocGoiTren, calTuNgay.Value, calDenNgay.Value);
            //frmPrint.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau13.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string filenameDB = "";
            string filenameVoice = "";
            gridBaoCaoBieuMau1 .SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridBaoCaoBieuMau1.SelectedItems.Count > 0)
            {
                filenameDB = (gridBaoCaoBieuMau1.SelectedItems[0]).GetRow().Cells["VoiceFilePath"].Text;
                filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);
            }
            if (filenameVoice.Length > 0)
            {
                player1.FileName = filenameVoice;
                if (player1.FileName != "")
                {
                    player1.Play();
                    btnPause.Text = "Pause";
                    this.timer1.Enabled = true;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("File không tồn tại");
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("File không tồn tại - filenameVoice.Length <0 !");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPause.Enabled = player1.Status != "stopped";
            btnStop.Enabled = player1.Status != "stopped";
            int pos = (player1.PositionInMS * this.tbPosition.Maximum) / player1.DurationInMS;
            this.tbPosition.Value = pos;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player1.Status == "paused")
            {
                player1.Resume();
                btnPause.Text = "Pause";
            }
            else
            {
                player1.Pause();
                btnPause.Text = "Resume";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            player1.Stop();
            this.timer1.Enabled = false;
        }

        #region Cap nhat du lieu cuoc goi di tu phan cung

        //private void LoadDuLieuCuocGoiDiTuPhanCung()
        //{
        //    // Create a background thread
        //    BackgroundWorker bw = new BackgroundWorker();
        //    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        //    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        //    // Create a progress form on the UI thread
        //    m_fmProgress = new fmProgress();

        //    // Kick off the Async thread
        //    bw.RunWorkerAsync();

        //    // Lock up the UI with this modal progress form.
        //    try
        //    {
        //        m_fmProgress.ShowDialog(this);
        //        m_fmProgress = null;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //private void bw_DoWork(object sender, DoWorkEventArgs e)
        //{


        //    m_fmProgress.lblDescription.Invoke(
        //       (MethodInvoker)delegate()
        //       {
        //           m_fmProgress.lblDescription.Text = "Loading ... cuộc gọi đi";
        //           m_fmProgress.progressBar1.Value = 50;
        //       }
        //   );
        //    CaptureCuocGoiDi();
        //    if (m_fmProgress.Cancel)
        //    {
        //        // Set the e.Cancel flag so that the WorkerCompleted event
        //        // knows that the process was canceled.
        //        e.Cancel = true;
        //        return;
        //    }
        //}

        //private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    // The background process is complete. First we should hide the
        //    // modal Progress Form to unlock the UI. The we need to inspect our
        //    // response to see if an error occured, a cancel was requested or
        //    // if we completed succesfully.

        //    // Hide the Progress Form
        //    if (m_fmProgress != null)
        //    {
        //        m_fmProgress.Hide();
        //        m_fmProgress = null;
        //    }

        //    // Check to see if an error occured in the 
        //    // background process.
        //    if (e.Error != null)
        //    {
        //        new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
        //        return;
        //    }

        //    // Check to see if the background process was cancelled.
        //    if (e.Cancelled)
        //    {
        //        // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
        //        return;
        //    }
        //}

        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            try
            {
                // lay du lieu
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                string VOCFileName = ProcessVocFile.GetVOCFileFullPath(timeServer);
                DataTable dt = new DataTable();
                dt = ProcessVocFile.GetEarlyPhoneDialOut(VOCFileName);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
                        if (!objGoiDi.Insert())
                        {
                            //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", ex);
            }
        }

        #endregion 

        private void timeThoiGianDamThoai_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }
        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

    }
}