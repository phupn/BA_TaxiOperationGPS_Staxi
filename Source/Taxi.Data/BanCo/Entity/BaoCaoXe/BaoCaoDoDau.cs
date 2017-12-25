using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoDoDau:TaxiOperationDbEntityBase<BaoCaoDoDau>
    {
        public int LoaiXeId { get; set; }
        public string LoaiXe { get; set; }
        public DateTime NgayDoDau { get; set; }
        public DateTime Ngay { get { return NgayDoDau.Date; } }
        public string SoXe { get; set; }
        public DateTime TGKD { get; set; }
        public float SoDauDo { get; set; }
        public int SoCongToMet { get; set; }
        public string GhiChu { get; set; }
        public string TenLaiXe { get; set; }
        public long SoKmThucHien { get; set; }
        public int SoLuong { get; set; }
        public int SoCuoc { get; set; }
        public float KmCoHang { get; set; }
        public float KmRong { get; set; }
        public float TongKm { get; set; }
        public float SoTuyen { get; set; }
        public decimal TongDT { get; set; }
        public decimal BinhQuan { get; set; }
        public List<BaoCaoDoDau> LsCaoDoDaus { get; set; } 
        public List<BaoCaoDoDau> GetReportDetail(DateTime? from,DateTime? to,string loaiXe)
        {
            return ExeStore("sp_EnVang_BaoCaoDoDau", from, to, loaiXe).ToList<BaoCaoDoDau>();
        }

        public List<BaoCaoDoDau> GetReport(DateTime? from, DateTime? to, string loaiXe)
        {
            var data = GetReportDetail(from, to, loaiXe);
            var trunk = GetTrunkEnd(from, to, loaiXe);
            var data1 = data.GroupBy(p => p.LoaiXe).Select(p =>
            {
                var tk = trunk.Where(p1 => p1.TenLoaiXe.Equals(p.Key)).ToList();
                var kmcohang = tk.Where(p1=>p1.KetQua==TrangThaiCuocGoiTaxi.CuocGoiThanhCong||p1.KetQua==TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach).Sum(p1 => p1.KmThucDi);
                var ls = p.ToList();
                return new BaoCaoDoDau()
                {
                    LsCaoDoDaus=ls,
                    KmCoHang = (float) kmcohang,
                    TongKm = p.Sum(p1=>p1.SoKmThucHien),
                    KmRong = (float) (p.Sum(p1=>p1.SoKmThucHien)-kmcohang),
                    TongDT = tk.Sum(p1=>p1.ThanhTien),
                    LoaiXe = p.Key,
                    SoLuong = p.Count(),
                    SoCuoc = tk.Count,
                    SoDauDo = p.Sum(p1 => p1.SoDauDo),
                    BinhQuan =  p.Sum(p1 => p1.SoKmThucHien)!=0?(decimal)(100 * p.Sum(p1 => p1.SoDauDo) / p.Sum(p1 => p1.SoKmThucHien)):0
                };
            }
               ).ToList();
            return data1;
        }

        public List<TaxiOperation_Truck_End> GetTrunkEnd(DateTime? from, DateTime? to, string loaiXe)
        {
            return ExeStore("sp_EnVang_GetTruckEnd", from, to, loaiXe).ToList<TaxiOperation_Truck_End>();
        }
    }
}
