using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Taxi.Business;
using Taxi.Common.Extender;
using Taxi.Controls.BaoCao;
namespace Taxi.Controls
{
    public partial class FrmTaxiOperationHistory : FrmReportBase
    {
        private FrmShowTaxiOperationHistory frmViewInfo;
        private List<TaxiperationHistory> _lstData;
        private frmProgressBar _frmProgress;
        public FrmTaxiOperationHistory()
        {
            InitializeComponent();
            gridView1.SortInfo.ClearAndAddRange(
                    new GridColumnSortInfo[]
	                    {
	                        new GridColumnSortInfo(gridView1.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),                        
	                        new GridColumnSortInfo(gridView1.Columns[1], DevExpress.Data.ColumnSortOrder.Ascending) 
	                    }, 1);
        }
        protected override object GetData()
        {
            //Dùng backgroundworker để chia nhỏ dữ liệu lấy lên giao diện!
            DateTime fromDate = ipFromDate.DateTime;
            DateTime toDate = ipToDate.DateTime;
            if ((toDate - fromDate).TotalHours > 1)
            {
                lbMessage.Visible = false;
                lblMsg.Text = "Bạn chỉ được tìm kiếm trong khoảng thời gian 1 giờ đồng hồ";
                ipFromDate.Focus();
                return new object();
            }
            else
            {
                lbMessage.Visible = true;
                lblMsg.Text = "";            
            }         
            BackgroundWorker bwWorker = new BackgroundWorker();
            bwWorker.DoWork += bwWorker_DoWork;
            bwWorker.RunWorkerCompleted += bwWorker_Completed;
            _frmProgress = new frmProgressBar();
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
                new MessageBox.MessageBoxBA().Show(ex.ToString(), "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Error);
            }

            return _lstData;         
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
            
            _lstData= TaxiperationHistory.Inst.GetDataTable(ipFromDate.DateTime, ipToDate.DateTime, txtPhoneNumber.Text, txtDiaChiDon.Text, txtLine.Text, txtVung.Text, txtIDCuoc.Text, txtBookID.Text).ToList<TaxiperationHistory>();
        }

        private void shGridControl1_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }

        private void FrmTaxiOperationHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmViewInfo != null)
            {
                frmViewInfo.Close();
            }
        }
        private void ShowInfo()
        {
            if (gridView1.RowCount > 0)
            {
                var model = gridView1.GetFocusedRow() as TaxiperationHistory;
                if (frmViewInfo == null || !frmViewInfo.Visible)
                {
                    frmViewInfo = new FrmShowTaxiOperationHistory();
                    Screen scr = Screen.PrimaryScreen;
                    frmViewInfo.Show(this);
                    frmViewInfo.Left = (scr.WorkingArea.Width - this.Width) / 2 + this.Width - frmViewInfo.Width;
                    frmViewInfo.Top = (scr.WorkingArea.Height - this.Height) / 2 + this.Height - frmViewInfo.Height;
                    frmViewInfo.SetModel(model);
                }
                else
                {
                    frmViewInfo.SetModel(model);
                }
            }
            else
            {
                if (frmViewInfo != null && frmViewInfo.Visible)
                    frmViewInfo.Hide();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ShowInfo();
        }

    }
}
