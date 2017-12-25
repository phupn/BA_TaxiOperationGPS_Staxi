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
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.Threading;

namespace Taxi.GUI 
{
    public partial class frm_2_3_BaoCaoNhanVien : Form
    {
         
        private fmProgress m_fmProgress = null;
        DataTable g_dtNVDienThoai;
        DataTable g_dtNVTongDai;

        public frm_2_3_BaoCaoNhanVien()
        {
            InitializeComponent();          
        }        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            btnRefresh.Enabled = false;          
            btnExportExcel.Enabled = btnRefresh.Enabled;            

        }

        private void LoadNhanVien()
        {
            cboNhanVien.ValueMember = "USER_ID";
            cboNhanVien.DisplayMember = "FULLNAME";
            cboNhanVien.Items.Add("Tất cả", "000");
            DataTable dt = new Users().GetAllUserInfo();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cboNhanVien.Items.Add(dr["FULLNAME"].ToString(), dr["USER_ID"].ToString());
                }
            }

            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
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
                btnExportExcel.Enabled = true;
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
            string Vung = StringTools.TrimSpace( textBox1.Text);
           
            string NhanVienID = "";
            if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
            {
                NhanVienID = cboNhanVien.SelectedItem.Value.ToString();
                if (NhanVienID == "000") NhanVienID = "";
            }
            g_dtNVDienThoai = Business.TimKiem_BaoCao.GROUP_BC_2_3_BaoCaoNhanVien(calTuNgay.Value, calDenNgay.Value, Vung, NhanVienID);
               // gridNhanVienDienThoai.DataSource = dt;
                gridEX1.DataMember = "ListDienThoai";
                gridEX1.SetDataBinding(g_dtNVDienThoai, "ListDienThoai");

                m_fmProgress.lblDescription.Invoke(
                   (MethodInvoker)delegate()
                   {
                       m_fmProgress.lblDescription.Text = " Kết thúc ";
                       m_fmProgress.progressBar.Value = 100;
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

        private void gridKQDHNV_DienThoai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            // tinh %

            try
            {
                if(int.Parse(e.Row .Cells["SoCuocTaxi"] .Value.ToString ()) != 0)
                    e.Row.Cells["PhanTramChuyenCham"].Text = string.Format("{0: ##.##}",  ((double.Parse(e.Row.Cells["SoCuocBiCham"].Value.ToString()) / double.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) * 100))); 
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        private void gridKQDHNV_TongDai_FormattingRow(object sender, RowLoadEventArgs e)
        {
            try
            {
                if (int.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) != 0)
                    e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0: ##.##}", ((double.Parse(e.Row.Cells["SoCuocDonDuoc"].Value.ToString()) / double.Parse(e.Row.Cells["SoCuocTaxi"].Value.ToString()) * 100)));
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
 
        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  chr = Convert.ToChar(";");
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ) || (e.KeyChar == chr  ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

         
        private void btnPrint_Click(object sender, EventArgs e)
        {
           //// DataTable dtNVTongDai = CreateBangDuLieuChoReport_NVTongDai();
           // DataTable dtNVDienThoai = this.CreateBangDuLieuChoReport_NVDienThoai();
           //   frmInBaoCao frmPrint = new frmInBaoCao();
           //   frmPrint.InBaoCaoBieuMau16(Configuration.GetReportPath() + "\\Baocao_Bieumau16.rpt", dtNVDienThoai, dtNVTongDai, calTuNgay.Value, calDenNgay.Value);  
           //   frmPrint .ShowDialog();
        }

         

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "2_3_BaoCao_NhanVien.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                Thread.Sleep(200);
                objFile.Close();
                 
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
                 
            } 
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
 
        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
         //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //   btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        

       
    }
}