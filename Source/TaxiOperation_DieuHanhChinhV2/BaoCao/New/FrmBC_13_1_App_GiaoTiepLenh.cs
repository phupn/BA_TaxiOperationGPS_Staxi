using Taxi.Controls.BaoCao;
using Taxi.Data.G5;
using System.Collections.Generic;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title="Báo cáo giao tiếp lệnh app")]
    public partial class FrmBC_13_1_App_GiaoTiepLenh : FrmReportBase
    {
        public FrmBC_13_1_App_GiaoTiepLenh()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            grid_CuocGoi.DataSource = new T_TaxiOperation();
            return T_TaxiOperation_SendCommand.Inst.GetBaoCao_13_1_GiaoTiepLenhApp(FromDate.Value, ToDate.Value,txtNoiDung.Text.Trim() );
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (gridView_Command.FocusedRowHandle > 0)
            {
                T_TaxiOperation_SendCommand item = (T_TaxiOperation_SendCommand)gridView_Command.GetFocusedRow();
                List<T_TaxiOperation> lstCuocgoi = T_TaxiOperation.Inst.GetByID(item.IdCuocGoi);
                if (lstCuocgoi != null && lstCuocgoi.Count > 0)
                {
                    grid_CuocGoi.DataSource = lstCuocgoi;
                }
                else
                {
                    grid_CuocGoi.DataSource = new T_TaxiOperation();
                }
            }
            
        }
    }
}
