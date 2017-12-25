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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau11 : Form
    {
        private fmProgress m_fmProgress = null;

        public frmBaoCaoBieuMau11()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {

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

            DoiTac objDoiTac = new DoiTac();
            List<DoiTac> lstDoiTac = objDoiTac.GetListOfDoiTacs();
            List<BacCao_CuocGoiMoiGioi> lstBacCao_CuocGoiMoiGioi = new List<BacCao_CuocGoiMoiGioi>();
            int i=0;
            foreach (DoiTac objDT in lstDoiTac)
            {
                BacCao_CuocGoiMoiGioi objCGMG = TimKiem_BaoCao.GetBaoCao_CuocGoiMoiGioi(calTuNgay.Value, calDenNgay.Value, objDT);
                lstBacCao_CuocGoiMoiGioi.Add(objCGMG);
                i++;
                m_fmProgress.lblDescription.Invoke(
                   (MethodInvoker)delegate()
                   {
                       m_fmProgress.lblDescription.Text = "Processing ... " + objDT.Name ;
                       m_fmProgress.progressBar1.Value = Convert.ToInt32(i * (100.0 / lstDoiTac.Count ));
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
            gridDienThoai.DataMember = "ListDienThoai";
            gridDienThoai.SetDataBinding(lstBacCao_CuocGoiMoiGioi, "ListDienThoai");   
                                  
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
                new MessageBox .MessageBoxBA ().Show (this,"Có lỗi trong quá trình xử lý dữ liệu. [" +e.Error.Message +"]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
               // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }           
        }

        #region XuLyCacCuocGoi ket thuc
        private void LoadCacCuocGoiKetThuc()
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                DateTime TimeServer = DieuHanhTaxi.GetTimeServer();

                string strDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer);

                string NRecords = " TOP 50 ";
                string SQLCondition = "  ORDER BY ThoiDiemGoi DESC";
                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }

        }
        #endregion XuLyCacCuocGoi ket thuc
       /// <summary>
       /// Xay dung chuoi query sql
       /// </summary>
       /// <param name="TuNgay"></param>
       /// <param name="DenNgay"></param>
       /// <param name="strVung"></param>
       /// <param name="ThoiGianDieuXe"></param>
       /// <returns></returns>
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay,string strVung,int ThoiGianDieuXe)
        {
            string SQLCondition = string.Empty;
            string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay);
            string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay);

            SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
        		
            // Cuoc goi khong dong duoc khch
            SQLCondition += " AND ((GhiChuTongDai LIKE N'%trượt%') OR (GhiChuTongDai LIKE N'%hoãn%') OR (GhiChuDienThoai LIKE N'%không xe%')) ";
            if (strVung.Length > 0)
            {
                SQLCondition += GetSQLStringQueryVung(strVung);
            }

            if (ThoiGianDieuXe > 1)
                SQLCondition += " AND ( ThoiGianDieuXe >= " + ThoiGianDieuXe.ToString() + ") ";
                

            return SQLCondition;
        }

        /// <summary>
        /// Kieu du lieu vung co dang
        /// 1;2;3 Cac vung phan cach bang dau ';' 
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private string GetSQLStringQueryVung(string Vung)
        {
            string strReturn = string.Empty;
            string[] arrVung = Vung.Split(";".ToCharArray());

            foreach (string strV in arrVung)
            {
                if (strV.Length > 0) strReturn = " AND (Vung = " + strV + ") ";
            }
            return strReturn;
        }
     
       
        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ))
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

        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                DieuHanhTaxi objDieuHanhTaxi = (DieuHanhTaxi)e.Row.DataRow;
                //  if (e.Row.Cells["XeDon"].Value.ToString().Length > 0)
                //    ((CheckBox) e.Row.Cells["DonDuoc"].Value) .Checked =true;
                if (objDieuHanhTaxi.XeDon.Length > 0)
                    e.Row.Cells ["DonDuoc"].Text= true.ToString ();
                    
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
            this.printPreviewDialog1.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau3.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void gridDienThoai_GroupsChanging(object sender, Janus.Windows.GridEX.GroupsChangingEventArgs e)
        {
           
        }
        
    }
}