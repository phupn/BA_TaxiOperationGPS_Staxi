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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau7 : Form
    {
        private fmProgress m_fmProgress = null;
        List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi=new List<BacCao_CuocGoiMoiGioi> ();


        private string g_MaNhanVien="";
        private int  g_SoChuyen = -1; // tat ca
        private int g_CongTyID = 0;
        private bool g_DaLoadDuLieu = false; // da thuc hien load du lieu

        public frmBaoCaoBieuMau7()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ;
            btnPrint.Enabled = false ;
            btnExportExcel.Enabled = false; 
            LoadNhanVien("");
            LoadDSCongTy(0);
        }
        private void LoadNhanVien(string MaNhanVien)
        {

            cboNhanVien.ValueMember = "USER_ID";
            cboNhanVien.DisplayMember = "FULLNAME";

            cboNhanVien.Items.Add("Tất cả", "TATCA");

            DataTable dt =  new Users().GetDSUserLaTiepThi();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                 foreach(DataRow dr in dt.Rows)
                 {
                     cboNhanVien.Items.Add(dr["FULLNAME"].ToString(), dr["USER_ID"].ToString());
                 }
            }


            //cboNhanVien.ValueMember = "MaNhanVien";
            //cboNhanVien.DisplayMember = "TenNhanVien";
            //cboNhanVien.DataSource = null;

            //NhanVien nhanvien = new NhanVien();
            //List<NhanVien> lstNhanVien = new List<NhanVien>();
            //lstNhanVien.Add(new NhanVien("NV00000", " Tất cả ", DateTime.Now, true, "", "", "", "", "", "", 0, 0, "",""));
            //List<NhanVien> listNhanVienTemp = nhanvien.GetListNhanViens();
            //if((listNhanVienTemp != null) && (listNhanVienTemp .Count > 0))
            //    foreach (NhanVien nv in listNhanVienTemp)
            //{
            //    lstNhanVien.Add(nv);
            //}
            //cboNhanVien.DataSource = lstNhanVien;
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

        private void LoadDSCongTy(int CongTyID)
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetAllDSCongTy();

            if (CongTyID > 0)
            {

                int iIndex = -1;
                foreach (Janus.Windows.EditControls.UIComboBoxItem objItem in cboCongTy.Items)
                {
                    iIndex += 1;
                    if (objItem.Value.ToString() == CongTyID.ToString())
                    {
                        break;
                    }

                }

                cboCongTy.SelectedIndex = iIndex;

            }

        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            g_DaLoadDuLieu = false;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                if (cboNhanVien.SelectedValue != null)
                g_MaNhanVien = cboNhanVien.SelectedValue.ToString();
                g_SoChuyen = intSoChuyen.Value; 
                // Create a background thread
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWorkNew);
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

            if(!g_DaLoadDuLieu )
            {
                DoiTac objDoiTac = new DoiTac();
                string MaNhanVien = "";
                if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
                    MaNhanVien = cboNhanVien.Items[cboNhanVien.SelectedIndex].DataRow.ToString();
               
                List<DoiTac> lstDoiTac = new List<DoiTac> ();
                if (MaNhanVien.Length > 0)
                    lstDoiTac = objDoiTac.GetListOfDoiTacs_ByNhanVien(MaNhanVien);
                 else
                    lstDoiTac = objDoiTac.GetListOfDoiTacs();

                g_lstBacCao_CuocGoiMoiGioi = new List<BacCao_CuocGoiMoiGioi>();
                int i=0;
                foreach (DoiTac objDT in lstDoiTac)
                {
                    BacCao_CuocGoiMoiGioi objCGMG = TimKiem_BaoCao.GetBaoCao_CuocGoiMoiGioi(calTuNgay.Value, calDenNgay.Value, objDT  );

                     
                        if (objCGMG.SoChuyen >= intSoChuyen.Value)
                        {
                            g_lstBacCao_CuocGoiMoiGioi.Add(objCGMG);                
                        }
                    
                    i++;
                    m_fmProgress.lblDescription.Invoke(
                       (MethodInvoker)delegate()
                       {
                           m_fmProgress.lblDescription.Text = "Processing ... " + objDT.Name ;
                           m_fmProgress.progressBar.Value = Convert.ToInt32(i * (100.0 / lstDoiTac.Count ));
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
            }
            else
            {
                gridDienThoai.DataMember = "ListDienThoai";
                gridDienThoai.SetDataBinding(LocDuLieu( g_lstBacCao_CuocGoiMoiGioi, g_MaNhanVien,g_SoChuyen)  , "ListDienThoai");
            }    
        }

        /// <summary>
        /// hamf thuc hien viec tao ra bao cao voi viec
        /// ma doi tac da duoc dua vao trong 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWorkNew(object sender, DoWorkEventArgs e)
        {

            if (!g_DaLoadDuLieu)
            {
                
                string MaNhanVien = "";
                if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
                    MaNhanVien = cboNhanVien.Items[cboNhanVien.SelectedIndex].DataRow.ToString();

                g_lstBacCao_CuocGoiMoiGioi = TimKiem_BaoCao.GetBCChiTietCuocKhachMoiGioi_BC07(MaNhanVien,calTuNgay.Value,calDenNgay.Value,g_SoChuyen);

                if (g_CongTyID > 0)
                {
                    g_lstBacCao_CuocGoiMoiGioi = LocTheoCongTyID(g_lstBacCao_CuocGoiMoiGioi, g_CongTyID);

                }

                    m_fmProgress.lblDescription.Invoke(
                       (MethodInvoker)delegate()
                       {
                           m_fmProgress.lblDescription.Text = "Hệ thống đang xử lý dữ liệu ... ";                           
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
            else
            {
                gridDienThoai.DataMember = "ListDienThoai";
                gridDienThoai.SetDataBinding( g_lstBacCao_CuocGoiMoiGioi , "ListDienThoai");
            }
        }

        private List<BacCao_CuocGoiMoiGioi> LocTheoCongTyID(List<BacCao_CuocGoiMoiGioi> lstBacCao_CuocGoiMoiGioi, int  CongTyID)
        {
            List<BacCao_CuocGoiMoiGioi> lstTemp = new List<BacCao_CuocGoiMoiGioi>();
            if (lstBacCao_CuocGoiMoiGioi != null && lstBacCao_CuocGoiMoiGioi.Count > 0)
            {
                foreach (BacCao_CuocGoiMoiGioi objT in lstBacCao_CuocGoiMoiGioi)
                {
                    if (objT.CongTyID == CongTyID)
                    {

                        lstTemp.Add(objT);
                    }
                }
            }
            return lstTemp;
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
                g_DaLoadDuLieu = false;
                new MessageBox .MessageBoxBA ().Show (this,"Có lỗi trong quá trình xử lý dữ liệu. [" +e.Error.Message +"]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                g_DaLoadDuLieu = false;
               // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }
            g_DaLoadDuLieu = true;
            gridDienThoai.DataMember = "ListDienThoai";
            gridDienThoai.SetDataBinding( g_lstBacCao_CuocGoiMoiGioi , "ListDienThoai");
  
        }

        /// <summary>
        /// loc du lieu theo so chuyen
        /// </summary>
        /// <param name="g_lstBacCao_CuocGoiMoiGioi"></param>
        /// <param name="aNhanVien"></param>
        /// <param name="SoChuyen"></param>
        /// <returns></returns>
        private List<BacCao_CuocGoiMoiGioi> LocDuLieu(List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi, string  MaNhanVien, int  SoChuyen)
        {
             List<BacCao_CuocGoiMoiGioi> lstTemp = new List<BacCao_CuocGoiMoiGioi>();
             // truong hop khong chon nhan vien - hoac chon tat ca 


             if ((MaNhanVien.Length <= 0) || (MaNhanVien.ToUpper() == "TATCA"))
             {
                 if (SoChuyen <= 0)
                     return g_lstBacCao_CuocGoiMoiGioi;
                 else
                 {
                     foreach (BacCao_CuocGoiMoiGioi objItem in g_lstBacCao_CuocGoiMoiGioi)
                     {
                         if (  objItem.SoChuyen >= SoChuyen )
                         {
                             lstTemp.Add(objItem);
                         }
                     }
                 }
             }
             else
             {
                 if ((g_lstBacCao_CuocGoiMoiGioi != null) && (g_lstBacCao_CuocGoiMoiGioi.Count > 0))
                 {
                     foreach (BacCao_CuocGoiMoiGioi objItem in g_lstBacCao_CuocGoiMoiGioi)
                     {
                         if ((objItem.MaNhanVien.ToUpper() == MaNhanVien.ToUpper()) && (objItem.SoChuyen >= SoChuyen))
                         {
                             lstTemp.Add(objItem);
                         }
                     }
                 }
             }
            return lstTemp;
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
               
                    
            }
            catch (Exception ex)
            {

            }
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
            string FilenameDefault = "BaoCao_BieuMau7.xls";
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

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetActiveRefreshButton();
            try
            {
                g_CongTyID = int.Parse(cboCongTy.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                g_CongTyID = 0;
            }
        }
        
    }
}