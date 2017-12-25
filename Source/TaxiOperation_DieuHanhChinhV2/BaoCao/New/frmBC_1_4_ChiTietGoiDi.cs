using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Janus.Windows.GridEX;
using Taxi.MessageBox;
using Taxi.Utils;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBC_1_4_BCChiTietGoiDi : Form
    {
        private fmProgress m_fmProgress = null;
        private DataTable g_dt = new DataTable();
        private const int MAX_DATES = 100;

        private class Item
        {
            private int _id;

            public int id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _Text;

            public string Text
            {
                get { return _Text; }
                set { _Text = value; }
            }

            public Item(int ID, string text)
            {
                this.id = ID;
                this.Text = text;
            }
        }

        public frmBC_1_4_BCChiTietGoiDi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer ();
            calTuNgay.Value = new DateTime (dateCurrent.Year,dateCurrent.Month,dateCurrent.Day,0,0,0); 
            calDenNgay.Value = (new DateTime (dateCurrent.Year,dateCurrent.Month,dateCurrent.Day,0,0,0)).AddDays(1); 

            btnRefresh.Enabled = false ; 
            btnExportExcel.Enabled = false ;

            InitPhanLoaiGoiRa();
            cboPhanLoaiMay.SelectedValue = 10;
        }

        /// <summary>
        /// //0 : Điện thoại
        //1 : Tổng đài
        //2 : Mời khách
        //3 : Tin Giá
        //4 : Khách hàng
        //5 : Trưởng ca
        //9 : Khác
        /// </summary>
        private void InitPhanLoaiGoiRa()
        {
            //object  choices = new Dictionary<string, string>();
            //choices["A"] = "Arthur";
            //choices["F"] = "Ford";
            //choices["T"] = "Trillian";
            //choices["Z"] = "Zaphod";
            //comboBox1.DataSource = new BindingSource(choices, null);
            //comboBox1.DisplayMember = "Value";
            //comboBox1.ValueMember = "Key"; 

            //List<Item> lstItem = new List<Item>();
            //lstItem.Add(new Item(0, "Điện thoại"));
            //lstItem.Add(new Item(1, "Tổng đài"));
            //lstItem.Add(new Item(2, "Mời khách"));
            //lstItem.Add(new Item(3, "Tin giá"));
            //lstItem.Add(new Item(4, "Khách hàng"));
            //lstItem.Add(new Item(5, "Trưởng ca"));
            //lstItem.Add(new Item(9, "Khác"));
            //lstItem.Add(new Item(10, "Tất cả"));

            //cboPhanLoaiMay.DataSource = new BindingSource(lstItem, null).DataSource;
            //cboPhanLoaiMay.DisplayMember = "Text";
            //cboPhanLoaiMay.ValueMember = "id";
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true; 
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false; 
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        /// <summary>
        /// Load phan len bieu mau
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
                {
                    string PhoneNumber = StringTools.TrimSpace(txtPhoneNumber.Text);
                    string Line = StringTools.TrimSpace(txtLine.Text);
                    string nhanVienID = StringTools.TrimSpace(txtNVID.Text);
                    string phanLoai = string.Empty;
                    try
                    {
                        phanLoai = cboPhanLoaiMay.SelectedValue.ToString();
                    }
                    catch
                    {
                        phanLoai = string.Empty;
                    }
                    if (phanLoai == "10")  // taat cả
                        phanLoai = string.Empty;

                    g_dt = CuocGoiDi.GetDSCuocGoiDi(calTuNgay.Value, calDenNgay.Value, timeThoiGianDamThoai.Value, PhoneNumber, Line, nhanVienID, phanLoai);
                    gridChiTietGoiDi.DataSource = g_dt;
                    SetUnActiveRefreshButton();
                }
                else
                {
                    MessageBoxBA msgDialog = new MessageBoxBA();
                    msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBoxButtonsBA.OK, MessageBoxIconBA.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnRefresh_Click: ",ex);                
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string strFilenameDefault = "1-4-BaoCaoChiTietCuocGoiDi-"+string.Format("{0:yyyy-MM-dd HH-mm}",CommonBL.GetTimeServer())+".xls";
            saveFileDialog.FileName = strFilenameDefault;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                gridViewChiTietGoiDi.ExportToXls(objFile);
                if (new MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtonsBA.YesNoCancel, MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog.FileName);
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
            try
            {
                string filenameDB = "";
                string filenameVoice = "";
                if (gridViewChiTietGoiDi.RowCount > 0)
                {
                    filenameDB = gridViewChiTietGoiDi.GetFocusedDataRow()["VoiceFilePath"].ToString();
                    filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);
                }

                if (filenameVoice.Length > 0)
                {
                    player.FileName = filenameVoice;
                    if (player.FileName != "")
                    {
                        player.Play();
                        btnPause.Text = "Pause";
                        this.timer.Enabled = true;
                    }
                    else
                    {
                        new MessageBoxBA().Show("File không tồn tại");
                    }
                }
                else
                {
                    new MessageBoxBA().Show("File ghi âm không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnPlay_Click: ",ex);                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPause.Enabled = player.Status != "stopped";
            btnStop.Enabled = player.Status != "stopped";
            int pos = (player.PositionInMS * this.tbPosition.Maximum) / player.DurationInMS;
            this.tbPosition.Value = pos;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player.Status == "paused")
            {
                player.Resume();
                btnPause.Text = "Pause";
            }
            else
            {
                player.Pause();
                btnPause.Text = "Resume";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            player.Stop();
            this.timer.Enabled = false;
        }

        #region Cap nhat du lieu cuoc goi di tu phan cung - Sử dụng BackGroundWorker đang bỏ!

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
                            new MessageBoxBA().Show("Lỗi khi thêm mới dữ liệu!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CaptureCuocGoiDi: ", ex);
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

        private void txtLine_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void txtNVID_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboPhanLoaiMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void gridBaoCaoBieuMau1_FormattingRow(object sender, RowLoadEventArgs e)
        {
             if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() == "0")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Điện thoại";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString()== "1")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Tổng đài";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() =="2")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Mời khách";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() == "3")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Tin giá";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() == "4")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Khách hàng";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() == "5")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Trưởng ca";
            }
            else if (e.Row.Cells["ThuocViTriGoi"].Value.ToString() == "9")
            {
                e.Row.Cells["ThuocViTriGoi"].Text = "Khác";
            }
        }

        private void gridViewChiTietGoiDi_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ThuocViTriGoi")
                {
                    if (e.DisplayText == "0")
                        e.DisplayText = "Điện thoại";
                    else if (e.DisplayText == "1")
                        e.DisplayText = "Tổng đài";
                    else if (e.DisplayText == "2")
                        e.DisplayText = "Mời khách";
                    else if (e.DisplayText == "3")
                        e.DisplayText = "Tin giá";
                    else if (e.DisplayText == "4")
                        e.DisplayText = "Khách hàng";
                    else if (e.DisplayText == "5")
                        e.DisplayText = "Trưởng ca";
                    else if (e.DisplayText == "9")
                        e.DisplayText = "Khác";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("gridViewChiTietGoiDi_CustomColumnDisplayText: ",ex);                
            }
        }
    }
}