using System;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.DanhMuc;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    [ReportInfo(Title="1.10 Báo cáo thống kê theo tên đường")]
    public partial class FrmBC_1_10_BaoCaoThongKeTheoTenDuong : FrmReportBase
    {
        public FrmBC_1_10_BaoCaoThongKeTheoTenDuong()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return DuongPho.Report(ipFromDate.DateTime,ipToDate.DateTime);
        }
    }
}
