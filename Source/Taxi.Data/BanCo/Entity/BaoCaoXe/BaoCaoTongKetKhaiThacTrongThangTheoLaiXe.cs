using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using System.Collections.Generic;
using System;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoTongKetKhaiThacTrongThangTheoLaiXe : TaxiOperationDbEntityBase<BaoCaoTongKetKhaiThacTrongThangTheoLaiXe>
    {
        public string MaLaiXe { set; get; }
        public string TenNhanVien { set; get; }
        public int TongCuocCuocDuongNgan { set; get; }
        public int TongCuocCuocDuongDai { set; get; }
        public int TongCuoc { set; get; }
        public decimal TongTienDuongNgan { set; get; }
        public decimal TongTienDuongDai { set; get; }
        public decimal TongTien { set; get; }
        public int KieuCuocHang { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="laixe"></param>
        /// <returns></returns>
        public List<BaoCaoTongKetKhaiThacTrongThangTheoLaiXe> GetDataReport(DateTime? fromDate, DateTime? toDate, string laixe)
        {
            var db =
                this.ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetKhaiThacTrongThangTheoLaiXe_2",
                    fromDate, toDate, laixe).ToList<BaoCaoTongKetKhaiThacTrongThangTheoLaiXe>();
            var db1 =
                db.GroupBy(p => new {p.TenNhanVien, p.MaLaiXe})
                    .Select(p => new BaoCaoTongKetKhaiThacTrongThangTheoLaiXe()
                    {
                        MaLaiXe=p.Key.MaLaiXe,
                        TenNhanVien = p.Key.TenNhanVien,
                        TongCuocCuocDuongNgan=p.Where(p1=>p1.KieuCuocHang==1).Sum(p1=>p1.TongCuoc),
                        TongCuocCuocDuongDai= p.Where(p1=>p1.KieuCuocHang==2).Sum(p1=>p1.TongCuoc),
                        TongTienDuongNgan = p.Where(p1 => p1.KieuCuocHang == 1).Sum(p1 => p1.TongTien),
                        TongTienDuongDai = p.Where(p1 => p1.KieuCuocHang == 2).Sum(p1 => p1.TongTien),
                        TongCuoc = p.Sum(p1=>p1.TongCuoc),
                        TongTien = p.Sum(p1=>p1.TongTien)
                    }).ToList();
            return db1;
        }
    }
}
