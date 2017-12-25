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
    public partial class frmBaoCaoBieuMa08 : Form
    {
        private fmProgress m_fmProgress = null;
        List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi=new List<BacCao_CuocGoiMoiGioi> ();
        public frmBaoCaoBieuMa08()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ;
            btnPrint.Enabled = false ;
            btnExportExcel.Enabled = false; 
            LoadNhanVien();
        }
        private void LoadNhanVien()
        {
            cboNhanVien.ValueMember = "USER_ID";
            cboNhanVien.DisplayMember = "FULLNAME";
            cboNhanVien.Items.Add("Tất cả", "000"); 
            DataTable dt = new Users().GetDSUserLaTiepThi();
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cboNhanVien.Items.Add(dr["FULLNAME"].ToString(), dr["USER_ID"].ToString()); 
                }
            }
            
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
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            DateTime timeServer = DieuHanhTaxi.GetTimeServer();

            if (calTuNgay.Value  > timeServer )
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập  nhỏ hơn hoặc bằng tháng hiện tại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
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

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

            DoiTac objDoiTac = new DoiTac();
            string MaNhanVien = "";
            if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
                MaNhanVien = cboNhanVien.SelectedItem.Value.ToString(); 
           
            List<DoiTac> lstDoiTac = new List<DoiTac> ();
            if (MaNhanVien.Length > 0)
                lstDoiTac = objDoiTac.GetListOfDoiTacs_ByNhanVien(MaNhanVien);
             else
                lstDoiTac = objDoiTac.GetListOfDoiTacs();
            
            int iDays = 0;
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            if ((calTuNgay.Value.Month == timeServer.Month) && (calTuNgay.Value.Year == timeServer.Year))
                iDays = timeServer.Day;
            else iDays = StringTools.GetDayOfMonth(calTuNgay.Value.Year, calTuNgay.Value.Month);

            DataTable dtDoiTacTheoNgay = CreateTableBaoCao8(iDays );

            int i = 0;  
            string strYYYYMM = string.Format("{0:yyyy-MM}", calTuNgay.Value);
            foreach (DoiTac objDT in lstDoiTac)
            {                
                DataRow dr = dtDoiTacTheoNgay.NewRow();
                dr["MaMoiGioi"] = objDT.MaDoiTac;
                dr["DiaChi"] = objDT.Address;
                dr["DienThoais"] = objDT.Phones;
                dr["TenNhanVien"] = objDT.TenNhanVien;
                int iTongXe = 0;int iSoChuyen =0;
                string strDay = "";
                for (int iDay = 1; iDay <= iDays; iDay++)
                {
                    strDay = strYYYYMM + "-" + StringTools.GeDayString(iDay);
                    iSoChuyen = TimKiem_BaoCao.GetSoChuyenCuocGoiMoiGioiInOneDay(strDay, objDT);
                    dr["Ngay" + iDay.ToString()] = iSoChuyen.ToString();
                    iTongXe += iSoChuyen; iSoChuyen = 0;
                }
                dr["SoChuyen"] = iTongXe.ToString();
                if(iTongXe >(int)intSoChuyen.Value)
                     dtDoiTacTheoNgay.Rows.Add(dr);
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
            gridDienThoai.DataMember = "ListDienThoai";
            gridDienThoai.SetDataBinding(dtDoiTacTheoNgay, "ListDienThoai");
            if (iDays < 31)
            {
                for (int t = iDays + 1; t <= 31; t++)
                {
                    gridDienThoai.RootTable.Columns["Ngay" + t.ToString()].Visible = false;    
                }
            }
                      
        }

        /// <summary>
        /// hàm xử lý tạo bảng dữ liệu hiển thị ds các cuộc gọi đối tác theo ngày.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bw_DoWorkNew(object sender, DoWorkEventArgs e)
        { 
            string MaNhanVien = "";
            if ((cboNhanVien.SelectedIndex != 0) && (cboNhanVien.SelectedIndex != -1))
                MaNhanVien = cboNhanVien.SelectedItem.Value.ToString();
             
            int iDays = 0;
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            if ((calTuNgay.Value.Month == timeServer.Month) && (calTuNgay.Value.Year == timeServer.Year))
                iDays = timeServer.Day;
            else iDays = StringTools.GetDayOfMonth(calTuNgay.Value.Year, calTuNgay.Value.Month);

            DataTable dtDoiTacTheoNgay = CreateTableBaoCao8(iDays);
            DataTable dtDoiTacSoChuyen = TimKiem_BaoCao.GetBCChiTietCuocKhachMoiGioiTheoNgay_BC08(calTuNgay.Value,MaNhanVien,intSoChuyen.Value);
             
            if(dtDoiTacSoChuyen !=null && dtDoiTacSoChuyen.Rows.Count>0)
            {   // DT.Ma_DoiTac,DT.Name,DT.Address,Phones,DT.FK_MaNhanVien, DT.TenNhanVien,DTT.Ngay, DTT.SoChuyen


                int iTongXe = 0;
                int iIndex = 0;
                int LenRows = dtDoiTacSoChuyen.Rows.Count;
                string MaDoiTac = "";
                string TenDiaChi ="";
                bool bNewRow = true;
                // Moi mot so hieu xe la mot dong cua bang 

                DataRow dr = null;
                while (iIndex < LenRows)
                {
                    if (bNewRow)  // tạo dòng mới, thiết lập mã tên (thiết lập các ngày mặc định là 0 chuyến)
                    {
                        MaDoiTac =  dtDoiTacSoChuyen.Rows[iIndex]["Ma_DoiTac"].ToString() ;
                        TenDiaChi = dtDoiTacSoChuyen.Rows[iIndex]["Name"].ToString() + " - " + dtDoiTacSoChuyen.Rows[iIndex]["Address"].ToString() ;
                         dr = dtDoiTacTheoNgay.NewRow();
                        dr["MaMoiGioi"] = MaDoiTac;
                        dr["DiaChi"] = dtDoiTacSoChuyen.Rows[iIndex]["Address"].ToString();
                        dr["DienThoais"] = dtDoiTacSoChuyen.Rows[iIndex]["Phones"].ToString();
                        dr["TenNhanVien"] = dtDoiTacSoChuyen.Rows[iIndex]["TenNhanVien"].ToString();
                       
                        int iSoChuyen =0;
                        string strDay = "";

                        for (int iDay = 1; iDay <= iDays; iDay++)
                        {
                            dr["Ngay" + iDay.ToString()] = "0";                             
                        }
                        if(dtDoiTacSoChuyen.Rows[iIndex]["Ngay"].ToString().Length >0)
                            dr["Ngay" + dtDoiTacSoChuyen.Rows[iIndex]["Ngay"].ToString()] = dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString();
                        if(dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString().Length >0)
                            iTongXe = Convert.ToInt32(dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString());
                        dr["SoChuyen"] = iTongXe.ToString();
                        bNewRow = false; iIndex++;
                    }
                    else
                    {
                        if (MaDoiTac == dtDoiTacSoChuyen.Rows[iIndex]["Ma_DoiTac"].ToString() ) // chua co cot moi
                        {
                            try
                            {
                                dr["Ngay" + dtDoiTacSoChuyen.Rows[iIndex]["Ngay"].ToString()] = dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString();
                            }
                            catch (Exception ex)
                            {  }
                            if(dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"]!=null && dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString ().Length >0)
                                iTongXe += Convert.ToInt32(dtDoiTacSoChuyen.Rows[iIndex]["SoChuyen"].ToString());
                            bNewRow = false; iIndex++;
                            dr["SoChuyen"] = iTongXe.ToString();
                        }
                        else  // chuyển sang môi giới khác
                        {
                            iTongXe = 0;
                            bNewRow = true;
                            dtDoiTacTheoNgay.Rows.Add(dr);
                        }
                    }
                    if (iIndex == LenRows) dtDoiTacTheoNgay.Rows.Add(dr);
                }                         
                        

                m_fmProgress.lblDescription.Invoke(
                   (MethodInvoker)delegate()
                   {
                       m_fmProgress.lblDescription.Text = "Hệ thống đang xử lý dữ liệu ... " + TenDiaChi;
                      
                   }
               );
                if (m_fmProgress.Cancel){
              
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was canceled.
                    e.Cancel = true;
                    return;
                }
             }
            gridDienThoai.DataMember = "ListDienThoai";
            gridDienThoai.SetDataBinding(dtDoiTacTheoNgay, "ListDienThoai");
            if (iDays < 31)
            {
                for (int t = iDays + 1; t <= 31; t++)
                {
                    gridDienThoai.RootTable.Columns["Ngay" + t.ToString()].Visible = false;
                }
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
        /// tao bao lu du lieu cuoc goi moi gioi theo ngay
        /// </summary>
        /// <param name="Month"></param>
        /// <returns></returns>
        private DataTable CreateTableBaoCao8(int iDays)
        {
             

            DataTable dt = new DataTable();
            //channel
            DataColumn dcChannel = new DataColumn("MaMoiGioi", Type.GetType("System.String"));
            dt.Columns.Add(dcChannel);
            //StartTime
            DataColumn dcStartTime = new DataColumn("DiaChi", Type.GetType("System.String"));
            dt.Columns.Add(dcStartTime);
            //Duration
            DataColumn dcDuration = new DataColumn("DienThoais", Type.GetType("System.String"));
            dt.Columns.Add(dcDuration);
            //code
            DataColumn dcCode = new DataColumn("SoChuyen", Type.GetType("System.String"));
            dt.Columns.Add(dcCode);
            //Fomin
            DataColumn dcFomin = new DataColumn("TenNhanVien", Type.GetType("System.String"));
            dt.Columns.Add(dcFomin);

            for (int i = 1; i <= iDays; i++)
            {
                // tao cot NGAY
                DataColumn dc = new DataColumn("Ngay" + i.ToString(), Type.GetType("System.String"));
                dt.Columns.Add(dc);
            }

            return dt;
        }


        public void LoadChart(double[] data)
        {
            // The data for the line chart
          //  double[] data0 = { 60.2, 51.7, 81.3, 48.6, 56.2, 68.9, 52.8 };
          //  double[] data1 = { 30.0, 32.7, 33.9, 29.5, 32.2, 28.4, 29.8 };
            string[] labels = new string [31];
            for (int iDay = 0; iDay < 31; iDay++)
            {
                labels[iDay] = ((int)(iDay+1)).ToString();
            }
            // Create a XYChart object of size 300 x 180 pixels, with a pale yellow
            // (0xffffc0) background, a black border, and 1 pixel 3D border effect.
            //834, 207
            XYChart c = new XYChart(800, 190, 0xffffc0, 0x000000, 1);

            // Set the plotarea at (45, 35) and of size 240 x 120 pixels, with white
            // background. Turn on both horizontal and vertical grid lines with light
            // grey color (0xc0c0c0)
            c.setPlotArea(30, 20, 760, 150, 0xffffff, -1, -1, 0xc0c0c0, -1);

            // Add a legend box at (45, 12) (top of the chart) using horizontal
            // layout and 8 pts Arial font Set the background and border color to
            // Transparent.
            c.addLegend(45, 12, false, "", 8).setBackground(Chart.Transparent);

            // Add a title to the chart using 9 pts Arial Bold/white font. Use a 1 x
            // 2 bitmap pattern as the background.
            c.addTitle("Biều đồ khách môi giới theo ngày (Tháng " + calTuNgay.Value.Month .ToString () + " )" , "Arial Bold", 9, 0xffffff
                ).setBackground(c.patternColor(new int[] { 0x004000, 0x008000 }, 2));

            // Set the y axis label format to nn%
            c.yAxis().setLabelFormat("{value}");

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add a line layer to the chart
            LineLayer layer = c.addLineLayer();

            // Add the first line. Plot the points with a 7 pixel square symbol
            layer.addDataSet(data, 0xcf4040, "Số xe đón").setDataSymbol(
                Chart.SquareSymbol, 7);
 

            // Enable data label on the data points. Set the label format to nn%.
            layer.setDataLabelFormat("{value|0}");

            // output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{xLabel}: {dataSetName} {value}'");
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
            string FilenameDefault = "BaoCao_BieuMau08.xls";
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

            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            double[] arrSoChuyenNgay = new double[31];
            if (gridDienThoai.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridDienThoai.SelectedItems[0]).GetRow();
                for (int iDay = 1; iDay <= 31; iDay++)
                {
                    try
                    {
                        arrSoChuyenNgay[iDay - 1] = double.Parse(row.Cells["Ngay" + iDay.ToString()].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        arrSoChuyenNgay[iDay - 1] = 0;
                    }
                }
                LoadChart(arrSoChuyenNgay);
            }
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }



    }
}