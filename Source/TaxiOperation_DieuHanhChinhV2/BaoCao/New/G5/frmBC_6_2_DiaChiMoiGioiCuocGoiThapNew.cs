#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Linq;
using Taxi.Controls.BaoCao;
using Taxi.Data.G5.BaoCao;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.4 Tổng hợp môi giới gọi qua trung tâm")]
    public partial class frmBC_6_2_DiaChiMoiGioiCuocGoiThapNew : FrmReportBase
    {
        #region == Field ==
        private DateTime NgayKyKetBatDau;
        private int TuNguong1;
        private int DenNguong1;
        private int HuongNguong1;

        private int TrenNguong2;
        private int HuongNguong2;
        
        private int TrenNguong3;
        private int HuongNguong3;
        #endregion

        public frmBC_6_2_DiaChiMoiGioiCuocGoiThapNew()
        {
            InitializeComponent();
        }
        protected override object GetData()
        {
            NgayKyKetBatDau = deNgayKyKet.DateTime;
            TuNguong1 = txtTuNguong1.EditValue.To<int>();
            DenNguong1 = txtDenNguong1.EditValue.To<int>();
            HuongNguong1 = txtHuongNguong1.EditValue.To<int>();

            TrenNguong2 = txtTrenNguong2.EditValue.To<int>();
            HuongNguong2 = txtHuongNguong2.EditValue.To<int>();

            TrenNguong3 = txtTrenNguong3.EditValue.To<int>();
            HuongNguong3 = txtHuongNguong3.EditValue.To<int>();

            return bc_6_2_DiaChiMoiGioiCuocGoiThap.GetReport(ipFromDate.DateTime, ipToDate.DateTime, txtMaDoiTac.Text, txtSoLuong.Text.To<int>(), lupLoaiDoiTac.EditValue.To<int>(), lupCongTy.EditValue.To<int>()).Select(TinhHuongHoaHong).ToList();
        }
        private bc_6_2_DiaChiMoiGioiCuocGoiThap TinhHuongHoaHong(bc_6_2_DiaChiMoiGioiCuocGoiThap bc)
        {
            if (bc.NgayKyKet >= NgayKyKetBatDau)
            {
                if (bc.DonDuocKhach > TrenNguong3 && HuongNguong3 > 0)
                {
                    bc.PhiHoaHong = HuongNguong3 * bc.DonDuocKhach;
                }
                else if (bc.DonDuocKhach > TrenNguong2 && HuongNguong2 > 0)
                {
                    bc.PhiHoaHong = HuongNguong2 * bc.DonDuocKhach;
                }
                else
                {
                    bc.PhiHoaHong = HuongNguong1 * bc.DonDuocKhach;
                }
            }
          
            return bc;
        }
    }
}
