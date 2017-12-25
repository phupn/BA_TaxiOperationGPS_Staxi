using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using DevExpress.XtraEditors;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity;
namespace TaxiOperation_BanCo.Config
{
    public partial class frmConfigDHBanCo_AddStatus : FormBase
    {
        List<ColorOfStatusModel> List_ColorOfStatus = new List<ColorOfStatusModel>();
        public frmConfigDHBanCo_AddStatus()
        {
            InitializeComponent();
        }

        private void gvColorOfStatus_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gvColorOfStatus.GetDataRow(e.RowHandle);
            row["StatusName"] = "";
            row["Color"] = "";
            row["Description"] = "";
        }
        #region Form Load
        private void frmConfigDHBanCo_AddStatus_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataTable dt_ColorOfStatus = new ColorOfStatusModel().GetAllData_Datatable();
            dt_ColorOfStatus.Columns.Add("clColor", typeof(Color));
            gridControl_ColorOfStatus1.DataSource = dt_ColorOfStatus;
            
        }
        #endregion

        private void gvColorOfStatus_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gvColorOfStatus_Layout(object sender, EventArgs e)
        {
            //updateLayout = true;
            //icbNewItemRow.EditValue = grvReport.OptionsView.NewItemRowPosition;
            //ceMultiSelect.Checked = grvReport.OptionsSelection.MultiSelect;
            //SetPosition();
            //updateLayout = false;
        }

        private void gvColorOfStatus_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "clColor")
            //{
            //    DataRow row = gvColorOfStatus.GetDataRow(e.RowHandle);
            //    //gvColorOfStatus.SetRowCellValue(e.RowHandle,"Value",Value.FromName(((Value)e.Value).ConfigName));
            //    gvColorOfStatus.SetFocusedRowCellValue("Value", Value.FromName(((Value)e.Value).ConfigName));
            //}
        }

        private void gvColorOfStatus_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.FieldName == "clColor")
            //{
            //    DataRow row = gvColorOfStatus.GetDataRow(e.RowHandle);
            //    //gvColorOfStatus.SetRowCellValue(e.RowHandle,"Value",Value.FromName(((Value)e.Value).ConfigName));
            //    gvColorOfStatus.SetFocusedRowCellValue("Value", Value.FromName(((Value)e.Value).ConfigName));
            //}
        }

        private void gvColorOfStatus_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            
        }        
    }
}