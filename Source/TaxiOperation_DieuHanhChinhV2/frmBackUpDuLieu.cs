using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Taxi.Business;
using Taxi.MessageBox;
using Taxi.GUI;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmBackUpDuLieu : Form
    {
        private fmProgress m_fmProgress = null;
        public frmBackUpDuLieu()
        {
            InitializeComponent();
        }
        private void frmBackUpDuLieu_Load(object sender, EventArgs e)
        { 
            if (!Directory.Exists(ThongTinCauHinh.ThuMucDuLieuTanasonic) || (ThongTinDangNhap.USER_ID != "admin"))
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Công việc này chỉ thực hiện trên máy chủ.", "Thông báo");
                btnBrowse2.Enabled = false;
                btnBrowseSaoLuu.Enabled = false;
                btnSaoLuu1.Enabled = false;
                btnSaoLuu2.Enabled = false;
            }
            lblNgayGanDay1.Text = Configuration.GetNgaySaoLuuTatCaGanDay();
            lblNgayGanDay2.Text = Configuration.GetNgaySaoLuuMotPhanGanDay();
         
            string Path = @"c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Backup";
            string FilenameDefault = string.Format("TaxiOperation{0:yyyyMMdd}.bak", DateTime.Now);
            txtDuongDanSaoLuu.Text = Path + "\\" + FilenameDefault;
            txtBrowse2.Text = "";
        }

        private void btnBrowseSaoLuu_Click(object sender, EventArgs e)
        {
            string Path = @"c:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Backup";
            string FilenameDefault = string.Format("TaxiOperation{0:yyyyMMdd}.bak", DateTime.Now);
            saveFileDialog1.FileName = Path + "\\" + FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            { 
                if (Directory.Exists(Path))
                {
                    txtDuongDanSaoLuu.Text = saveFileDialog1.FileName;                    
                }
                else
                    new Taxi.MessageBox.MessageBoxBA().Show("Đường dẫn không tồn tại.", "Thông báo");
            }
             
        }

      

        private void btnSaoLuu1_Click(object sender, EventArgs e)
        {
            // kiem tra thong tin duong dẫn
           

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
            string FileLuu = txtDuongDanSaoLuu.Text;
            if (!HeThong.SaoLuuToanBoDB(FileLuu))
            {
                e.Cancel = true;                
            }
    
            m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = "Processing backup database... ";                             
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
                new Taxi.MessageBox.MessageBoxBA().Show("Có lỗi sao lưu dữ liệu. Bạn cần kiểm tra đường dẫn xem có quyền ghi không.", "Thông báo");             
            }
            else
            {
              new Taxi.MessageBox.MessageBoxBA().Show("Sao lưu dữ liệu thành công.", "Thông báo");
              Configuration.SetNgaySaoLuuTatCaGanDay(string.Format("{0: dd/MM/yyyy}", DateTime.Now));
              this.Close();
            }
            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
              
                return;
            }          
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            
            string FilenameDefault = string.Format("TaxiOperation_MotPhan{0:yyyyMMdd}.dat", DateTime.Now);
            saveFileDialog1.FileName =   FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {             
                 txtBrowse2.Text = saveFileDialog1.FileName;                
            }
             
        }

        private void btnSaoLuu2_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtBrowse2.Text).Length <= 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Không có đường dẫn, bạn phải nhập file lưu..", "Thông báo");
            }
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork2);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted2);

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
        private void bw_DoWork2(object sender, DoWorkEventArgs e)
        {
            string FileLuu = txtBrowse2.Text;
            if (!HeThong.SaoLuuMotPhanDB(FileLuu))
            {
                e.Cancel = true;
            }

            m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = "Processing backup database... ";
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
        private void bw_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
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
                new Taxi.MessageBox.MessageBoxBA().Show("Có lỗi sao lưu dữ liệu. Bạn cần kiểm tra đường dẫn xem có quyền ghi không.", "Thông báo");
            }
            else
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Sao lưu dữ liệu thành công.", "Thông báo");
                Configuration.SetNgaySaoLuuMotPhanGanDay(string.Format("{0: dd/MM/yyyy}", DateTime.Now));
                this.Close();
            }
            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {

                return;
            }
        }

    }
}