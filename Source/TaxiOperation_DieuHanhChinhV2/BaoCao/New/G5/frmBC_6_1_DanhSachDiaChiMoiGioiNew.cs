#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.1 Báo cáo danh sách địa chỉ môi giới")]
    public partial class frmBC_6_1_DanhSachDiaChiMoiGioiNew : FrmReportBase
    {
        public string MaDoiTac { get; set; }
        public string TenDoiTac { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MaNV { get; set; }
        public int MucMG { get; set; }
        public string Vung { get; set; }

        public frmBC_6_1_DanhSachDiaChiMoiGioiNew()
        {
            InitializeComponent();
        }
        protected override void AfterLoad()
        {
           
        }
       
        protected override object GetData()
        {
            int TrangThaiHopDong = 0;
            if (rdbConHD.Checked)
            {
                TrangThaiHopDong = 1;
            }
            else if (rdbHetHD.Checked)
            {
                TrangThaiHopDong = 2;
            }
            else if (rdTatCaNgay.Checked)
            {
                TrangThaiHopDong = 3;//Tất cả theo ngày!
            }
            return bc_6_1_DanhSachDiaChiMoiGioi.GetReport_V2(FromDate,ToDate,MaDoiTac,TenDoiTac,DiaChi,SoDienThoai,MaNV,MucMG,Vung,TrangThaiHopDong);
        }
        private void cbkNgayBatdau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkNgayBatdau.Checked)
            {
                ipFromDate.Enabled = true;
                ipToDate.Enabled = true;
                ipFromDate.Bind();
                ipToDate.Bind();
            }
            else
            {
                ipFromDate.Enabled = false;
                ipToDate.Enabled = false;
                ipFromDate.EditValue = null;
                ipToDate.EditValue = null;
            }
        }

        private void cbkNgayKetThuc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkNgayKetThuc.Checked)
            {
                deKetThucTuNgay.Enabled = true;
                deKetThucDenNgay.Enabled = true;
                deKetThucTuNgay.Bind();
                deKetThucDenNgay.Bind();
            }
            else
            {
                deKetThucTuNgay.Enabled = false;
                deKetThucDenNgay.Enabled = false;
                deKetThucTuNgay.EditValue = null;
                deKetThucDenNgay.EditValue = null;
            }
        }

        private void rdbConHD_CheckedChanged(object sender, EventArgs e)
        {
            btnTim.Enabled = true;
        }
    }
}
