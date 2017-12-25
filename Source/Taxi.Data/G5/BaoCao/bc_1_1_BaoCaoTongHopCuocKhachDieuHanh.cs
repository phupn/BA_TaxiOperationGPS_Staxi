using System;
using System.Data;
using System.Threading;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.G5.BaoCao
{
    public class BC_1_1_BaoCaoTongHopCuocKhachDieuHanh : DbEntityBase<BC_1_1_BaoCaoTongHopCuocKhachDieuHanh>
    {
        private const string spReport = "sp_bc_1_1_BaoCaoTongHopCuocKhachDieuHanh";
        /// <summary>
        /// Báo cáo Tổng hợp cuốc khách điều hành
        /// </summary>
        /// <param name="start">Từ ngày</param>
        /// <param name="end">Đến ngày</param>
        /// <returns>Danh sách thông tin về cuốc khách điều hành</returns>
        public static DataTable GetReport(DateTime start, DateTime end)
        {
            DataTable dtAll = new DataTable();
            int countLoop = (end - start).TotalDays.To<int>();
            for (int i = 1; i <= countLoop + 1; i++)
            {                
                if(start.AddDays(1)<end)
                    dtAll.Merge(Inst.ExeStore(spReport,start,start.AddDays(1)));
                else
                    dtAll.Merge(Inst.ExeStore(spReport,start,end));
                start=start.AddDays(1);
                Thread.Sleep(100);
            }
            return dtAll;
        }



        public DateTime Ngay { get; set; }
        public int GoiTaxi { get; set; }
        public int GoiLai { get; set; }
        public int ChuyenKH { get; set; }
        public int DichVu { get; set; }
        public int HoiDam { get; set; }
        public int GoiKhac { get; set; }
        public int Tong { get; set; }
        public int CuocGoiNho { get; set; }
        public int DonDuoc { get; set; }
        public int KhongDonDuoc { get; set; }
        public int Truot { get; set; }
        public int Hoan { get; set; }
        public int KhongXe { get; set; }
        public int Khac { get; set; }
        public float PhanTramDonDuoc { get; set; }
        public int XeKhongXacDinh { get; set; }
        public int CuocG5 { get; set; }
        public int DonDuocG5 { get; set; }
        public float PhanTramG5 { get; set; }

    }
}
