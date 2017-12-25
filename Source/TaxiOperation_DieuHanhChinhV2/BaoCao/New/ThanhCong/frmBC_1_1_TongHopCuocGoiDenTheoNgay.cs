using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;

namespace Taxi.GUI.ThanhCong
{
    public partial class frmBC_1_1_TongHopCuocGoiDenTheoNgay : Form
    {
        #region Khởi tạo và khai báo
        private DataTable _dtData = new DataTable();
        private DataTable _dtBinhQuan = new DataTable();
        private fmProgress _frmProgress;
        private bool _blHaveData = true;
        public frmBC_1_1_TongHopCuocGoiDenTheoNgay()
        {
            InitializeComponent();
        }
        #endregion
        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
        }

        private void KhoiTaoDuLieu()
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();           
            
            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent; 
        }
   
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                return;
            }                 
            //Dùng backgroundworker để chia nhỏ dữ liệu lấy lên!
            BackgroundWorker bwWorker = new BackgroundWorker();
            bwWorker.DoWork += bwWorker_DoWork;
            bwWorker.RunWorkerCompleted += bwWorker_Completed;
            _frmProgress = new fmProgress();
            bwWorker.RunWorkerAsync();
            // Lock up the UI with this modal progress form.
            try
            {
                _frmProgress.ShowDialog(this);
                _frmProgress = null;
                this.Activate();
                this.MinimizeBox = false;

                btnRefresh.Enabled = false;
                btnExportExcel.Enabled = !btnRefresh.Enabled;
                if (!_blHaveData)
                {
                    new MessageBox.MessageBoxBA().Show("Không tìm thấy dữ liệu báo cáo!", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Information);
                    _dtData= new DataTable();
                    _dtBinhQuan = new DataTable();
                    griTongCuocGoiDen.DataMember = "ListDienThoai";
                    griTongCuocGoiDen.SetDataBinding(_dtData, "ListDienThoai");
                    // Su dung ID de lay phan binh quan voi id nay                    
                    gridBinhQuan.DataMember = "ListBQ";
                    gridBinhQuan.SetDataBinding(_dtBinhQuan, "ListBQ");
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.ToString(), "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
            }
        }

        private void bwWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_frmProgress != null)
            {
                _frmProgress.Hide();
                _frmProgress = null;
            }

            if (e.Error != null)
            {
                new MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }

        private void bwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_frmProgress.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                LoadData(calTuNgay.Value, calDenNgay.Value);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                string id = string.Empty;
                _dtData = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoNgay(TuNgay, DenNgay, ref id);
                if (_dtData != null && _dtData.Rows.Count > 0)
                {
                    griTongCuocGoiDen.DataMember = "ListDienThoai";
                    griTongCuocGoiDen.SetDataBinding(_dtData, "ListDienThoai");
                    // Su dung ID de lay phan binh quan voi id nay
                    _dtBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(id);
                    gridBinhQuan.DataMember = "ListBQ";
                    gridBinhQuan.SetDataBinding(_dtBinhQuan, "ListBQ");
                    _blHaveData = true;
                }
                else
                {
                    _blHaveData = false;
                }
            }
            catch 
            {
                
            }
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {            
           saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_1_1_TongHopGoiDenNgay", calTuNgay.Value, calDenNgay.Value, false);
           if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX1.DataMember = "list1";
                gridEX1.SetDataBinding(_dtData, "list1");
                gridEXExporter1.GridEX = gridEX1; 
                gridEXExporter1.Export(objFile);
                objFile.Close();
                string Directory = new FileInfo(saveFileDialog1.FileName).DirectoryName;
                // Tao binh quan
                saveFileDialog1.FileName =Directory + "\\" + FileTools.GetFilenameReport("BC_1_1_TongHopGoiNgayBinhQuan", calTuNgay.Value, calDenNgay.Value,false);
                objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX2.DataMember = "listBinhQuan";
                gridEX2.SetDataBinding(_dtBinhQuan, "listBinhQuan");
                gridEXExporter1.GridEX = gridEX2;
                gridEXExporter1.Export(objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo 2 file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);  
                }               
                objFile.Close();
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;  
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}