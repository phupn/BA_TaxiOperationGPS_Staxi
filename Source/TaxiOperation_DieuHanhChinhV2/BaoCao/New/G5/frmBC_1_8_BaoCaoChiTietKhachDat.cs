using System;
using System.Collections.Generic;
using System.ComponentModel;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.GUI;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "1.8 Báo cáo chi tiết khách đặt")]
    public partial class frmBC_1_8_BaoCaoChiTietKhachDat : FrmReportBase
    {
        public string MaDoiTac { get; set; }
        public bool CuocChuaPhucVu { get; set; }
        public bool SanBay { get; set; }
        public DateTime? ThoiGianDon { get; set; }

        private List<bc_1_8_BaoCaoChiTietKhachDat> _dataTable;
        private fmProgress _frmProgress;
        public frmBC_1_8_BaoCaoChiTietKhachDat()
        {
            InitializeComponent();
        }
    
        protected override object GetData()
        {
            BackgroundWorker bwWorker = new BackgroundWorker();
            bwWorker.DoWork += bwWorker_DoWork;
            bwWorker.RunWorkerCompleted+=bwWorker_Completed;
            _frmProgress = new fmProgress();
            bwWorker.RunWorkerAsync();
            try
            {
                _frmProgress.ShowDialog(this);
                _frmProgress = null;
                this.Activate();
                this.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(ex.ToString(), "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }

            return _dataTable;            
        }

        private void bwWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if(_frmProgress != null)
            {
                _frmProgress.Hide();
                _frmProgress = null;
            }

            if(e.Error != null)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }

        private void bwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_frmProgress.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (ckbTGDon.Checked)
            {
                ThoiGianDon = (DateTime)ipThoiGianDon.GetValue();
            }
            else
            {
                ThoiGianDon = null;
            }
            _dataTable= bc_1_8_BaoCaoChiTietKhachDat.GetReport(FromDate.Value, ToDate.Value, MaDoiTac, ThoiGianDon, SanBay, CuocChuaPhucVu);
        }

        private void ckbTGDon_CheckedChanged(object sender, EventArgs e)
        {
            ipThoiGianDon.Enabled = ckbTGDon.Checked;
        }

        private void ckbCuocChuaPhucVu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCuocChuaPhucVu.Checked)
            {
                ipThoiGianDon.Enabled = false;
                ckbTGDon.Enabled = false;
                ckbTGDon.Checked = false;
            }
            else
            {
                ckbTGDon.Enabled = true;
            }
        }
    }
}
