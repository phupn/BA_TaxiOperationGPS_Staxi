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
    [ReportInfo(Title = "4.5 Tổng hợp kết quả điều hành theo nhân viên")]
    public partial class frmBC_4_5_BaoCaoTongHopKQDieuHanhNV : FrmReportBase
    {
        public frmBC_4_5_BaoCaoTongHopKQDieuHanhNV()
        {
            InitializeComponent();
        }

        protected override object GetData()
        {
            DateTime TuNgay = (DateTime)ipFromDate.GetValue();
            DateTime DenNgay = (DateTime)ipToDate.GetValue();
            if (TuNgay>DenNgay)
            {
                lbMessage.Text = "Ngày bắt đầu không được lớn hơn ngày kết thúc";
                return null;
            }
            else
            {
                lbMessage.Text = "";
                int SoGiayGioiHanChuyenTongDai = ThongTinCauHinh.SoGiayGioiHanThoiGianChuyenTongDai;
                string MaNhanVien = string.IsNullOrEmpty(txtMaNV.Text) ? null : txtMaNV.Text.Trim();
                return bc_4_5_BaoCaoTongHopKQDieuHanhNV.Inst.GetReport(TuNgay, DenNgay, SoGiayGioiHanChuyenTongDai, MaNhanVien);
            }
        }
    }
}
