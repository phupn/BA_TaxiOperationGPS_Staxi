using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoKetQuaHoatDongCuaCacXe : TaxiOperationDbEntityBase<BaoCaoKetQuaHoatDongCuaCacXe>
    {
        public string TenLoaiXe { get; set; }
        public int TongCuoc { get; set; }
        public int TongKMKD { get; set; }
        public int KmCoHang { get; set; }
        public int KmKhongCoHang { get; set; }
        public int KhaiThac { get; set; }
        public int ThueBao { get; set; }
        public int MoCua { get; set; }
        public int Truot { get; set; }
        public int SoXeDiKD { get; set;}
        public decimal KmXeNgay { get; set; }
        public decimal CuocNgay { get; set; }
        public decimal CuocNgayXe { get; set; }
        public List<BaoCaoKetQuaHoatDongCuaCacXe> GetData(DateTime start, DateTime end, string loaiXeId)
        {
            var curent= ExeStore("EnVang_Report_BaoCaoKetQuaHoatDongCuaCacXe", start, end,loaiXeId).ToList<TaxiOperation_Truck_End>();
            var prev = ExeStore("EnVang_Report_BaoCaoKetQuaHoatDongCuaCacXe", start.AddMonths(-1), start.AddMinutes(-1), loaiXeId).ToList<TaxiOperation_Truck_End>();
            
            return null;
        }
    }
}
