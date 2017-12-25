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
     [ReportInfo(Title = "7.1 Báo cáo tình trạng đàm")]
    public partial class frmBC_7_1_BaoCaoTinhTrangDam : FrmReportBase
    {
        public frmBC_7_1_BaoCaoTinhTrangDam()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return bc_7_1_BaoCaoTinhTrangDam.GetReport();
        }
    }
}
