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
using Taxi.Business.DM;
using Janus.Windows.GridEX;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoKhachQuenTheoThang : Form
    {
        private fmProgress m_fmProgress = null;
        List<BacCao_MoiGioiThang_BC09> g_lstBacCao_CuocGoiMoiGioiThang = new List<BacCao_MoiGioiThang_BC09>();
        private bool g_bChuaCoDuLieu=true;
        private bool g_bThayDoiChonNam = false;
        private int g_Nam = 0;
        public frmBaoCaoKhachQuenTheoThang()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ;
            
            btnExportExcel.Enabled = false; 

            KhoiTaoDuLieu();
           // LoadNhanVien();
        }

        private void KhoiTaoDuLieu()
        {
            //lay gio may chu
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();

            intUDDenThang.Value = timeServer.Month;
            int startYear = 2008;
            for(int i = startYear ;i<= timeServer.Year ;i++)
            {
                ddlNam.Items.Add(i);
            }
           int index =  ddlNam.Items.IndexOf(timeServer.Year);
            ddlNam.SelectedIndex = index ;


        }
        private void LoadNhanVien()
        {
            //cboNhanVien.ValueMember = "USER_ID";
            //cboNhanVien.DisplayMember = "FULLNAME";
            //cboNhanVien.Items.Add("Tất cả", "TATCA"); 
            //DataTable dt = new Users().GetDSUserLaTiepThi();
            //if ((dt != null) && (dt.Rows.Count > 0))
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        cboNhanVien.Items.Add(dr["FULLNAME"].ToString(), dr["USER_ID"].ToString()); 
            //    }
            //}
            
            //if (MaNhanVien.Length > 0)
            //{
            //    int iIndex = 0;
            //    for (int i = 0; i < lstNhanVien.Count; i++)
            //    {
            //        if (lstNhanVien[i].MaNhanVien == MaNhanVien)
            //        {
            //            iIndex = i;
            //            break;
            //        }
            //    }
            //    // set current select item cua combo = MaDoiTac
            //    cboNhanVien.SelectedIndex = iIndex;
            //}
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (intUDTuThang.Value <= 0 || intUDTuThang.Value > 12 || (intUDDenThang.Value <= 0) || (intUDDenThang.Value > 12))
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập tháng trong khoảng [1..12].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }

            if (intUDTuThang.Value > intUDDenThang.Value)
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ tháng] nhỏ hơn hoặc bằng [Đến tháng].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            if (ddlNam.Text.Length < 4)
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập phải nhập dữ liệu năm.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            else g_Nam = int.Parse(ddlNam.Text);
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
                if (m_fmProgress == null) m_fmProgress = new fmProgress();
                m_fmProgress.ShowDialog(this);
                m_fmProgress = null;

            }
            catch (Exception ex)
            {

            }
            SetUnActiveRefreshButton();  
           
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //#region Lay  du lieu
            if (g_bChuaCoDuLieu && (!g_bThayDoiChonNam))  // chưa có dữ liệu ghép và chưa có lựa chọn thay đổi dữ liệu theo năm
            {
                try
                {
                    m_fmProgress.lblDescription.Invoke(
                       (MethodInvoker)delegate()
                       {
                           m_fmProgress.lblDescription.Text = "Đang xử lý ... ";

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
                catch (Exception ex)
                {
                        
                }
            }
                            
                     
            //#endregion


            DateTime tuNgay = new DateTime(g_Nam, intUDTuThang.Value, 1, 0, 0, 0);
            DateTime denNgay = new DateTime(g_Nam, intUDDenThang.Value, 1, 0, 0, 0);
            if(intUDDenThang.Value>=12 )
                denNgay = new DateTime(g_Nam+1, 1, 1, 0, 0, 0);
            
                

            gridCuocGoiMGThang.DataMember = "ListDienThoai";
            gridCuocGoiMGThang.SetDataBinding( TimKiem_BaoCao.BaoCaoKhachHangThanThietTheoThang(tuNgay,denNgay), "ListDienThoai");
            

            HideCotCuaGrid(intUDTuThang.Value, intUDDenThang.Value, gridCuocGoiMGThang);
            

        }

        private void HideCotCuaGrid(int TuThang, int DenThang, GridEX gridCuocGoiMGThang)
        {
            for (int i = 1; i <= 12; i++)
            {
                gridCuocGoiMGThang.RootTable.Columns[i + 4].Visible = false;
            }
            for (int i = TuThang; i <= DenThang; i++)
            {
                gridCuocGoiMGThang.RootTable.Columns[i + 4].Visible = true;
            }
        }
        /// <summary>
        /// tim vi trí dòng của mã đối tác 
        /// </summary>
        /// <param name="MaDoiTac"></param>
        /// <param name="dtDuLieuNam"></param>
        /// <returns></returns>
        private int TimViTriCuaMaDoiTac(string MaDoiTac, DataTable dtDuLieuNam)
        {
            int iRow = -1;

            bool bTimThay = false;
            if ((dtDuLieuNam != null) && (dtDuLieuNam.Rows.Count >0))
            {
                iRow = 0;
                foreach(DataRow dr in  dtDuLieuNam.Rows)
                {
                   if(MaDoiTac == dr["MaDoiTac"].ToString())
                   {
                       bTimThay = true;
                       break;
                   }
                   iRow++;
                }
            }
            if (!bTimThay)   iRow = -1;
              
            return iRow;
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
                m_fmProgress.Close();
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

       
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //frmInBaoCao frmPrint = new frmInBaoCao();
                //List<BacCao_CuocGoiMoiGioi> lstBacCao_CuocGoiMoiGioi_Print = new List<BacCao_CuocGoiMoiGioi>();
                //for (int i = 0; i < gridDienThoai.RowCount; i++)
                //{
                //    BacCao_CuocGoiMoiGioi objBacCao_CuocGoiMoiGioi = (BacCao_CuocGoiMoiGioi)gridDienThoai.GetRow(i).DataRow;
                //    lstBacCao_CuocGoiMoiGioi_Print.Add(objBacCao_CuocGoiMoiGioi);
                //}
                //frmPrint.InBaoCaoBieuMau7(Configuration.GetReportPath() + "\\Baocao_Bieumau7.rpt", lstBacCao_CuocGoiMoiGioi_Print, calTuNgay.Value, calDenNgay.Value, "");
                //frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi tạo dư liệu in báo cáo.", "Thông báo");
            }

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau09.xls";
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

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editNhanVien_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editSochuyen_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepSoChuyen_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void gridDienThoai_Click(object sender, EventArgs e)
        {
        }

        private void gridDienThoai_SelectionChanged(object sender, EventArgs e)
        {

            //gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            //double[] arrSoChuyenNgay = new double[31];
            //if (gridDienThoai.SelectedItems.Count > 0)
            //{
            //    GridEXRow row = ((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).GetRow();
            //    for (int iDay = 1; iDay <= 31; iDay++)
            //    {
            //        try
            //        {
            //            arrSoChuyenNgay[iDay - 1] = double.Parse(row.Cells["Ngay" + iDay.ToString()].Value.ToString());
            //        }
            //        catch (Exception ex)
            //        {
            //            arrSoChuyenNgay[iDay - 1] = 0;
            //        }
            //    }
            //    LoadChart(arrSoChuyenNgay);
            //}
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }
        private void ddlNam_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
            if (g_bThayDoiChonNam) g_bThayDoiChonNam = false;
        }
        private void intUDTuThang_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }
        private void intUDDenThang_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }


        #region Validate dữ liệu nhập

        private void intUDTuThang_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intUDTuThang.TextBox.Text);
                if (iValue <= 0 || iValue > 12)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
            }
        }

        private void intUDDenThang_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intUDDenThang.TextBox.Text);
                if (iValue <= 0 || iValue > 12)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
            }
        }

        private void intSoChuyen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int iValue = int.Parse(intSoChuyen.TextBox.Text);
                if (iValue < 0)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
            }
        }

        #endregion Validate dữ liệu nhập

       

       
       

       

    }
}