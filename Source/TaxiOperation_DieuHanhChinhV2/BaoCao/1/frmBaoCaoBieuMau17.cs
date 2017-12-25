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
    public partial class frmBaoCaoBieuMau17 : Form
    {
         
        private fmProgress m_fmProgress = null;

        private DataTable g_dtDuLieuBC17;
        List<DieuHanhTaxi> g_ListCuocGoiCuaDoiTac;
        public frmBaoCaoBieuMau17()
        {
            InitializeComponent();          
        }        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
            g_dtDuLieuBC17 = this.CreateBangDuLieuChoReport_BC17(); 
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();

            if ((calDenNgay.Value.Year > timeServer.Year) || ((calDenNgay.Value.Year == timeServer.Year) && (calDenNgay.Value.Month > timeServer.Month)))
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn chọn [tháng-năm] nhỏ hơn hoặc bằng [tháng-năm] hiện tại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return;
            }

            // check thang co nho hơn hoặc bằng tháng hiện tại không.

            if (g_dtDuLieuBC17 == null)
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Không tạo được dữ liệu báo cáo.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                return;

            }
           

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




            btnPrint.Enabled = true;
            btnExportExcel.Enabled = true;
             
        }


     
       /// <summary>
       /// 
       /// </summary>
       /// <param name="drNVTiepThi">Thong tin cua mot nhan vien tiep thi</param>
       /// <param name="dtDSMoiGioiCuaNhanVien">DS cac cuoc goi cua nhan vien </param>
       /// <param name="dtDSCacCuocGoi">DS cac cuôc goi trong thang cua he thong</param>
       /// <returns>du lieu cua bao cao 17 </returns>
        /// //  <BaoCaoBieuMau17>
        //    <FULLNAME></FULLNAME>
        //    <USER_ID></USER_ID>
        //    <SoDiaChiMoiGioiPhuTrach></SoDiaChiMoiGioiPhuTrach>
        //    <SoDiaChiMoiGioiGoiTaxi></SoDiaChiMoiGioiGoiTaxi>
        //    <SoChuyen></SoChuyen>
        //    <SoDiaChiMoiGioiKhongGoiTaxi></SoDiaChiMoiGioiKhongGoiTaxi>
        //    <PhanTramMoiGioiGoiTaxi> </PhanTramMoiGioiGoiTaxi>
        //    <GhiChu></GhiChu>
        //  </BaoCaoBieuMau17>
        private DataRow GetSoLieuKetQuaCuaNVTiepThi(DataRow drNVTiepThi, List<DoiTac> DSMoiGioiCuaNhanVien, List<DieuHanhTaxi> DSCacCuocGoi)
        {
            try
            {
                DataRow drBC17 = g_dtDuLieuBC17.NewRow();

                drBC17["FULLNAME"] = drNVTiepThi["FULLNAME"];
                drBC17["USER_ID"] = drNVTiepThi["USER_ID"];
                int iSoDiaChiMoiGioiPhuTrach = 0;
                int iSoDiaChiMoiGioiGoiTaxi = 0;
                int iSoChuyen = 0;
                int iSoDiaChiMoiGioiKhongGoiTaxi = 0;
                double dPhanTramMoiGioiGoiTaxi = 0;

                iSoDiaChiMoiGioiPhuTrach = DSMoiGioiCuaNhanVien.Count;

                foreach (DoiTac objDoiTac in DSMoiGioiCuaNhanVien)
                {
                    int iSoDCGoi = 0;
                    // phan tach so dien thoai 
                    string[] arrPhones = objDoiTac.Phones.Split(";".ToCharArray());
                    if (arrPhones.Length > 0)
                    {

                        for (int i = 0; i < arrPhones.Length; i++)
                        {
                            string PhoneCall = arrPhones[i].ToString();
                            if (PhoneCall.Length >= 8)
                            {
                                if (PhoneCall.Length >= 8)
                                {
                                    PhoneCall = PhoneCall.Substring(PhoneCall.Length - 8, 8);

                                    foreach (DieuHanhTaxi objDHT in DSCacCuocGoi)
                                    {
                                        if (objDHT.PhoneNumber.Length >= 8)
                                        {
                                            string Phones = objDHT.PhoneNumber.Substring(objDHT.PhoneNumber.Length - 8, 8);

                                            if (Phones == PhoneCall)
                                            {
                                                iSoDCGoi += 1;  // tang cuoc goi duoc goi
                                                iSoChuyen += (objDHT.XeDon.Length + 1) / 4;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (iSoDCGoi <= 0)
                    {
                        iSoDiaChiMoiGioiKhongGoiTaxi += 1;
                    }
                    else
                        iSoDiaChiMoiGioiGoiTaxi += 1;
                }

                dPhanTramMoiGioiGoiTaxi = (Convert.ToDouble(iSoDiaChiMoiGioiKhongGoiTaxi) / Convert.ToDouble(iSoDiaChiMoiGioiPhuTrach)) * 100;


                drBC17["SoDiaChiMoiGioiPhuTrach"] = iSoDiaChiMoiGioiPhuTrach;                
                drBC17["SoDiaChiMoiGioiGoiTaxi"] = iSoDiaChiMoiGioiGoiTaxi;
                drBC17["SoChuyen"] = iSoChuyen;
                drBC17["SoDiaChiMoiGioiKhongGoiTaxi"] = iSoDiaChiMoiGioiPhuTrach - iSoDiaChiMoiGioiGoiTaxi ;
                drBC17["PhanTramMoiGioiGoiTaxi"] = dPhanTramMoiGioiGoiTaxi;
                drBC17["GhiChu"] = "";

                return drBC17;
            }
            catch (Exception ex)
            {
                throw new Exception("Loi xu ly du lieu bao cao ket qua nhan vien tiep thi");
                return null;
            }
        }


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
           

            // Lấy ds nhân viên là tiếp thị
            Users objUser = new Users();
            DataTable dtDSNVTiepThi = objUser.GetDSUserLaTiepThi();
            g_ListCuocGoiCuaDoiTac = new DieuHanhTaxi().GetAllCuocGoiCuaDoiTac_GoiTaxi(calDenNgay.Value.Month, calDenNgay.Value.Year);
            if (g_ListCuocGoiCuaDoiTac != null)
            {

                if (dtDSNVTiepThi.Rows.Count > 0) // có tồn tại ds nhân viên
                {
                    int i = 0;
                    foreach (DataRow drNVTiepThi in dtDSNVTiepThi.Rows)
                    {
                        i += 1;
                        m_fmProgress.lblDescription.Invoke(
                             (MethodInvoker)delegate()
                             {
                                 m_fmProgress.lblDescription.Text = "Hệ thống đang xử lý dữ liệu ... ";
                                 m_fmProgress.progressBar.Value = (int)((i / dtDSNVTiepThi.Rows.Count) * 100);
                             }
                         );

                        //lay ds moi gioi cua nhan vien tiep thi
                        List<DoiTac> ListOfDT = new DoiTac().GetListOfDoiTacs_ByNhanVien(drNVTiepThi["USER_ID"].ToString());
                        if ((ListOfDT != null) && (ListOfDT.Count > 0))
                        {

                            DataRow drBC17 = GetSoLieuKetQuaCuaNVTiepThi(drNVTiepThi, ListOfDT, g_ListCuocGoiCuaDoiTac);
                            if (drBC17 != null)
                            {
                                g_dtDuLieuBC17.Rows.Add(drBC17);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Không có dữ liệu cuộc gọi bạn cần chọn tháng-năm khác.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                e.Cancel = true;

                return;

            }

           
            
            m_fmProgress.lblDescription.Invoke(
               (MethodInvoker)delegate()
               {
                   m_fmProgress.lblDescription.Text = " Kết thúc ";
                   m_fmProgress.progressBar.Value = 100;
               }
           );
            gridKQNVTT.DataMember = "KQNVTiepThi";
            gridKQNVTT.SetDataBinding(g_dtDuLieuBC17, "KQNVTiepThi");
 




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
 
        /// <summary>
        /// lay du lieu tu grid --> reports, và tạo dữ liệu
        /// </summary>
        /// <returns></returns>
        private DataTable CreateBangDuLieuChoReport_BC17()
        {


            //<dataroot>
            //  <BaoCaoBieuMau17>
            //    <FULLNAME></FULLNAME>
            //    <USER_ID></USER_ID>
            //    <SoDiaChiMoiGioiPhuTrach></SoDiaChiMoiGioiPhuTrach>
            //    <SoDiaChiMoiGioiGoiTaxi></SoDiaChiMoiGioiGoiTaxi>
            //    <SoChuyen></SoChuyen>
            //    <SoDiaChiMoiGioiKhongGoiTaxi></SoDiaChiMoiGioiKhongGoiTaxi>
            //    <PhanTramMoiGioiGoiTaxi> </PhanTramMoiGioiGoiTaxi>
            //    <GhiChu></GhiChu>
            //  </BaoCaoBieuMau17>
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
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoDiaChiMoiGioiPhuTrach";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoDiaChiMoiGioiGoiTaxi";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoChuyen";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Int32");
            dc.ColumnName = "SoDiaChiMoiGioiKhongGoiTaxi";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.Double");
            dc.ColumnName = "PhanTramMoiGioiGoiTaxi";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.DataType = Type.GetType("System.String");
            dc.ColumnName = "GhiChu";
            dt.Columns.Add(dc);

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
        //    DataTable dtNVTongDai = CreateBangDuLieuChoReport_NVTongDai();
        //    DataTable dtNVDienThoai = this.CreateBangDuLieuChoReport_NVDienThoai();
        //      frmInBaoCao frmPrint = new frmInBaoCao();
        //      frmPrint.InBaoCaoBieuMau16(Configuration.GetReportPath() + "\\Baocao_Bieumau16.rpt", dtNVDienThoai, dtNVTongDai, calTuNgay.Value, calDenNgay.Value);  
        //      frmPrint .ShowDialog();
        }

         

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau17.xls";
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
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                //objFile.Close();
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
 
        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        

       
    }
}