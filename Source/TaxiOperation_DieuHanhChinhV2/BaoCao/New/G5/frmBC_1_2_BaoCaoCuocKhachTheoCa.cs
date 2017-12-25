using System;
using DevExpress.XtraGrid.Columns;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "Báo cáo cuốc khách theo ca/ theo vùng/ theo giờ")]
    public partial class frmBC_1_2_BaoCaoCuocKhachTheoCa : FrmReportBase
    {
        public int IsCa { get; set; }
        public frmBC_1_2_BaoCaoCuocKhachTheoCa()
        {
            InitializeComponent();
        }

        protected override void AfterFind()
        {
            InitGridControl();
        }
        protected override object GetData()
        {
            return bc_1_2_BaoCaoCuocKhachTheoCa.GetReport(FromDate.Value, ToDate.Value, IsCa);
        }

        private void inputIsCa_EditValueChanged(object sender, EventArgs e)
        {            
            if (inputIsCa.EditValue.Equals(0))
            {
                grcGroup.Caption = "Ca";
                grcGroup.FieldName = "Ca";
            }
            if (inputIsCa.EditValue.Equals(1))
            {
                grcGroup.Caption = "Vùng";
                grcGroup.FieldName = "Ca";
            }
            if (inputIsCa.EditValue.Equals(2))
            {
                grcGroup.Caption = "Thời gian";
                grcGroup.FieldName = "GioHienThi";
            }
        }

        private void InitGridControl()
        {
            gridView1.BeginSort();
            try
            {
                gridView1.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                {
                    new GridColumnSortInfo(gridView1.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),                        
                    new GridColumnSortInfo(gridView1.Columns[1], DevExpress.Data.ColumnSortOrder.Ascending)//Cột ca
                }, 1);

                if (inputIsCa.EditValue.Equals(2))
                {
                    gridView1.SortInfo.ClearAndAddRange(new GridColumnSortInfo[]
                    {
                        new GridColumnSortInfo(gridView1.Columns[0], DevExpress.Data.ColumnSortOrder.Ascending),                        
                        new GridColumnSortInfo(gridView1.Columns[25], DevExpress.Data.ColumnSortOrder.Ascending)//Cột Giờ
                    }, 1);
                }               
            }
            finally
            {
                gridView1.EndSort();
            }
        }
    }
}
