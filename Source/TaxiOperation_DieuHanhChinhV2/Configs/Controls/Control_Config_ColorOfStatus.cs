using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Data.BanCo.Entity;

namespace TaxiOperation_BanCo.Controls.Config
{
    public partial class Control_Config_ColorOfStatus : UserControl
    {
        public Control_Config_ColorOfStatus()
        {
            InitializeComponent();
        }

        private void gridControl_ColorOfStatus_Load(object sender, EventArgs e)
        {
            if (DesignMode && System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime) return;

            DataTable dt_ColorOfStatus = new ColorOfStatusModel().GetAllData_Datatable();
            if (dt_ColorOfStatus != null)
            {
                gridControl_ColorOfStatus.DataSource = dt_ColorOfStatus;
            }
        }

        private void gvColorOfStatus_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
          
            DataRow row = ((DataRowView)e.Row).Row;
            if (row != null)
            {
                ColorOfStatusModel objColorOfStatus = new ColorOfStatusModel();
                objColorOfStatus.Id = Int16.Parse(row["Id"].ToString());
                objColorOfStatus.Color = row["Color"].ToString();
                objColorOfStatus.BackColor = row["BackColor"].ToString();
                objColorOfStatus.Description = row["Description"].ToString();
                objColorOfStatus.StatusName = row["StatusName"].ToString();
                objColorOfStatus.Update();
            }
            else
            {
                gvColorOfStatus.RefreshData();
            }

        }

        private void gvColorOfStatus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvColorOfStatus_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == SttName)
            {
                var data = gvColorOfStatus.GetRow(e.RowHandle) as DataRowView;

                string cl = data["BackColor"].ToString();
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(int.Parse(cl));
                cl = data["Color"].ToString();
                e.Appearance.ForeColor = System.Drawing.Color.FromArgb(int.Parse(cl));
            }
        }

    }
}
