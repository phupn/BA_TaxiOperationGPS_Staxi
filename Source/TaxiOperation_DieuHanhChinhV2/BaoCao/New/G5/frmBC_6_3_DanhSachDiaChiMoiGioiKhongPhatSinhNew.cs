#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.3 Báo cáo danh sách địa chỉ môi giới không phát sinh")]
    public partial class frmBC_6_3_DanhSachDiaChiMoiGioiKhongPhatSinhNew : FrmReportBase
    {
        public frmBC_6_3_DanhSachDiaChiMoiGioiKhongPhatSinhNew()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return bc_6_3_DanhSachDiaChiMoiGioiKhongPhatSinh.GetReport(ipFromDate.DateTime, ipToDate.DateTime, lupLoaiDoiTac.EditValue.To<int>(), lupCongTy.EditValue.To<int>(),txtMaDoiTac.Text,txtSDT.Text);
        }    
    }
}
