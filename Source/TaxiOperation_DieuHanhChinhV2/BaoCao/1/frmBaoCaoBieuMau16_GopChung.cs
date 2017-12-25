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
    public partial class frmBaoCaoBieuMau16_GopChung : Form
    {
         
        private fmProgress m_fmProgress = null;
        DataTable g_dtNVDienThoai;
        DataTable g_dtNVTongDai;

        public frmBaoCaoBieuMau16_GopChung()
        {
            InitializeComponent();          
        }        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
             btnRefresh.Enabled = false;            
             btnExportExcel.Enabled = btnRefresh.Enabled;             
        }

        private void LoadDSNhanVien()
        {
            cboNhanVien.Items.Add("Tất cả");
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

               


               // btnPrint.Enabled = true;
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
              
              g_dtNVDienThoai   = Business.TimKiem_BaoCao.GetKetQuaHoatDongCuaNhanVien_BaoCao16_GopChung( calTuNgay.Value, calDenNgay.Value);
               // gridNhanVienDienThoai.DataSource = dt;
                gridKQDHNV_DienThoai.DataMember = "ListDienThoai";
                gridKQDHNV_DienThoai.SetDataBinding(g_dtNVDienThoai, "ListDienThoai");

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

        /// <summary>
        /// lay du lieu tu grid --> reports
        /// </summary>
        /// <returns></returns>
        private DataTable CreateBangDuLieuChoReport_NVDienThoai()
        {


            //<dataroot>
            //  <BaoCaoBieuMau16_TongDai>
            //        < FULLNAME></FULLNAME>
            //    < USER_ID></USER_ID>
            //    <SoPhutKhaiThac></SoPhutKhaiThac>
            //    <SoCuocTaxi></SoCuocTaxi>
            //    <SoCuocDonDuoc></SoCuocDonDuoc>
            //    <PhanTramDonDuoc></PhanTramDonDuoc>
            //    <GhiChu></GhiChu>
            //  </BaoCaoBieuMau16_TongDai>
            //</dataroot>

            DataTable dt = new DataTable();

            DataColumn dc;

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "FULLNAME";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "USER_ID";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Double");
            dc.ColumnName = "SoPhutKhaiThac";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoCuocTaxi";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoCuocBiCham";
            dt.Columns.Add(dc);


            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "PhanTramChuyenCham";
            dt.Columns.Add(dc);

           
            for (int i = 0; i < this.gridKQDHNV_DienThoai .RowCount; i++)
            {
                int iSoCuocGoiTaxi = 0;
                int iSoCuocBiCham = 0;

                DataRow row;
                GridEXRow gRow = gridKQDHNV_DienThoai.GetRow(i);
                row = dt.NewRow();

                row["FULLNAME"] = gRow.Cells["FULLNAME"].Value;
                row["USER_ID"] = gRow.Cells["USER_ID"].Value;

                if (gRow.Cells["SoPhutKhaiThac"].Text.Length > 0)
                    row["SoPhutKhaiThac"] = Convert.ToDouble(int.Parse(gRow.Cells["SoPhutKhaiThac"].Text.ToString()) / 60);
                else row["SoPhutKhaiThac"] = 0;

                if (gRow.Cells["SoCuocTaxi"].Text.Length > 0)
                {
                    iSoCuocGoiTaxi = Convert.ToInt32(gRow.Cells["SoCuocTaxi"].Text);
                    row["SoCuocTaxi"] = iSoCuocGoiTaxi;

                }
                else row["SoPhutKhaiThac"] = 0;

                if (gRow.Cells["SoCuocBiCham"].Text.Length > 0)
                {
                    iSoCuocBiCham = Convert.ToInt32(gRow.Cells["SoCuocBiCham"].Text);
                    row["SoCuocBiCham"] = iSoCuocBiCham;

                }
                else row["SoCuocBiCham"] = 0;

                if (iSoCuocBiCham <= 0) row["PhanTramChuyenCham"] = 0;
                else
                    row["PhanTramChuyenCham"] = string.Format("{0:##.##}", iSoCuocBiCham / iSoCuocGoiTaxi * 100);

                dt.Rows.Add(row);
            }
            return dt;
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
            string FilenameDefault = "BaoCao_BieuMau16.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                Thread.Sleep(200);
                objFile.Close();


               
                //objFile = new FileStream(saveFileDialog1.FileName, FileMode.Append);
                //gridEXExporter1.GridEX = gridKQDHNV_TongDai;
                //gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel KQNV điện thoại thành công.", "Thông báo");
                //objFile.Close();
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

        

       
    }
}