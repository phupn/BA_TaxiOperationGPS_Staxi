#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Linq;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.4 Tổng hợp môi giới gọi qua trung tâm")]
    public partial class frmBC_6_4_BaoCaoMoiGioiQuaTrungTam : FrmReportBase
    {
        public string MaDoiTac { get; set; }
        public int SoLuong { get; set; }
        public string MaNhanVien { get; set; }
        public string  TenDoiTac { get; set; }
        public string DiaChi { get; set; }
        public string  SoDienThoai { get; set; }
        public frmBC_6_4_BaoCaoMoiGioiQuaTrungTam()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            return bc_6_2_DiaChiMoiGioiCuocGoiThap.GetReport_V2(FromDate.Value, ToDate.Value, MaDoiTac, SoLuong, MaNhanVien, TenDoiTac, DiaChi, SoDienThoai).ToList();
        }

        private void shGridControl1_DoubleClick(object sender, EventArgs e)
        {
            bc_6_2_DiaChiMoiGioiCuocGoiThap item = gridView1.GetFocusedRow() as bc_6_2_DiaChiMoiGioiCuocGoiThap;
            if (item != null)
                new frmBC_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi(item.Ma_DoiTac, (DateTime)ipFromDate.GetValue(), (DateTime)ipToDate.GetValue()).Show();
        }
    }
}
