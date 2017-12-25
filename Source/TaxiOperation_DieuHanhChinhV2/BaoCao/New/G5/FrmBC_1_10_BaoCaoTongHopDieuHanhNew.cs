using Taxi.Controls.BaoCao;
using Taxi.Data.G5;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title="Báo cáo tổng hợp điều app và điều đàm")]
    public partial class FrmBC_1_10_BaoCaoTongHopDieuHanhNew : FrmReportBase
    {
        public FrmBC_1_10_BaoCaoTongHopDieuHanhNew()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return G5_1_10_BCCuocKhachTTDHDieuApp.GetBaoCaoTongHopDieuAppNew(FromDate.Value,ToDate.Value);
        }
    }
}
