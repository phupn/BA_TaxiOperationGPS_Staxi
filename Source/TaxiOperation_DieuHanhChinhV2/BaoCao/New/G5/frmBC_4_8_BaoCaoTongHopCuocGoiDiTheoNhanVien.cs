using Taxi.Controls.BaoCao;
using Taxi.Data.G5;
using Taxi.Common.Extender;
namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "4.8 Báo cáo tổng hợp cuộc gọi đi theo nhân viên")]
    public partial class frmBC_4_8_BaoCaoTongHopCuocGoiDiTheoNhanVien : FrmReportBase
    {
        public frmBC_4_8_BaoCaoTongHopCuocGoiDiTheoNhanVien()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return bc_4_8_BaoCaoTongHoCuocGoiDiTheoNhanVien.GetReport(ipFromDate.DateTime, ipToDate.DateTime, inputLookUp_UserInfo1.EditValue.To<string>().Replace(inputLookUp_UserInfo1.Properties.NullText,""));
        }
    }
}
