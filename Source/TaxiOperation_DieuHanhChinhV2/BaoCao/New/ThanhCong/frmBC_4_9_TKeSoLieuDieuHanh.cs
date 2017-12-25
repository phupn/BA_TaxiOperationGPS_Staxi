using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.BaoCao;
using Taxi.Controls.Base.Extender;
using Taxi.Data.BaoCaoNew;
using Taxi.GUI;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.ThanhCong
{
    [ReportInfo(Title = "4.9 Báo cáo thống kê số liệu phòng Điều Hành", BinderType = ExcelBinderType.Grid)]
    public partial class frmBC_4_9_TKeSoLieuDieuHanh : FrmReportByMonthBase
    {
        private DataTable  _dataTable;
        private fmProgress _frmProgress;
        public frmBC_4_9_TKeSoLieuDieuHanh()
        {
            InitializeComponent();
        }

        #region Các hàm quan trọng trong báo cáo

        protected override object GetData()
        {
            //Dùng backgroundworker để chia nhỏ dữ liệu lấy lên giao diện!
            BackgroundWorker bwWorker = new BackgroundWorker();
            bwWorker.DoWork += bwWorker_DoWork;
            bwWorker.RunWorkerCompleted += bwWorker_Completed;
            _frmProgress = new fmProgress();
            bwWorker.RunWorkerAsync();
            //Lock up the UI with this modal progress form.
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

        private void bwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_frmProgress.Cancel)
            {
                e.Cancel = true;
                return;
            }
            DateTime searchDate = new DateTime(ipYear.GetValue().To<int>(), ipMonth.GetValue().To<int>(), 1);
            _dataTable = BC_4_9_TKeSoLieuDieuHanh.Inst.GetDataReport(searchDate, new DateTime(searchDate.Year, searchDate.Month, DateTime.DaysInMonth(searchDate.Year, searchDate.Month), 23, 59, 59));
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
                new Taxi.MessageBox.MessageBoxBA().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
            }
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();
            GenerateDayColumns();
        }

        protected override void BeforeFind()
        {
            GenerateDayColumns();
        }

        private void GenerateDayColumns()
        {
            bgDays.Columns.Clear();

            var from = ipFromDate.GetValue().To<DateTime>();
            var to = ipToDate.GetValue().To<DateTime>();

            for (var d = from; d <= to; d = d.AddDays(1))
            {
                bgDays.Columns.CreateColumn("Day_" + d.Day, d.Day.ToString(), Color.Empty, Color.Empty);                
            }

            bgDays.Columns.CreateColumn("Total", "Tổng", Color.FromArgb(255, 255, 0), Color.Empty,70);
            bgDays.Columns.CreateColumn("ChiTieu", "Chỉ tiêu", Color.FromArgb(255, 255, 0), Color.Empty,80);
            bgDays.Columns.CreateColumn("ChiPhiHH", "Chi phí hoa hồng", Color.FromArgb(255, 255, 0), Color.Empty,100);
            bgDays.Columns.CreateColumn("%", "%", Color.FromArgb(255, 255, 0), Color.Empty);
            bgDays.Columns.CreateColumn("GhiChu", "Ghi chú", Color.FromArgb(255, 255, 0),Color.Empty,80);            
        }

        #endregion


        private void shBandedView_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle==0 ||e.RowHandle==33)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold); 
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("shBandedView_RowStyle",ex);
            }
        }

    }
}
