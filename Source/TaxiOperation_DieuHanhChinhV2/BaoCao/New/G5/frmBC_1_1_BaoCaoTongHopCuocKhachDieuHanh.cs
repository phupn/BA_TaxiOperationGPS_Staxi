using System;
using System.ComponentModel;
using System.Data;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.GUI;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "Báo cáo tổng hợp cuốc khách điều hành")]
    public partial class frmBC_1_1_BaoCaoTongHopCuocKhachDieuHanh : FrmReportBase
    {
        private DataTable _dataTable;
        private fmProgress _frmProgress;
        public frmBC_1_1_BaoCaoTongHopCuocKhachDieuHanh()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            //Dùng backgroundworker để chia nhỏ dữ liệu lấy lên giao diện!
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
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBox().Show(ex.ToString(), "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }

            return _dataTable;
        }

        private void bwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_frmProgress.Cancel)
            {
                e.Cancel = true;
                return;
            }

            _dataTable = bc_1_1_BaoCaoTongHopCuocKhachDieuHanh.GetReport(this.FromDate.Value, this.ToDate.Value);
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
                new Taxi.MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }
    }
}
