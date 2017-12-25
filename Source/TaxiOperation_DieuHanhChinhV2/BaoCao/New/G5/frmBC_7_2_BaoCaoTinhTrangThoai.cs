#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Linq;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
using Taxi.Business;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
     [ReportInfo(Title = "7.2 Báo cáo tình trạng thoại")]
    public partial class frmBC_7_2_BaoCaoTinhTrangThoai : FrmReportBase
    {
        public frmBC_7_2_BaoCaoTinhTrangThoai()
        {
            InitializeComponent();
        }

        protected override object GetData()
        {
            return bc_7_2_BaoCaoTinhTrangThoai.GetReport();
        }
    }
}
