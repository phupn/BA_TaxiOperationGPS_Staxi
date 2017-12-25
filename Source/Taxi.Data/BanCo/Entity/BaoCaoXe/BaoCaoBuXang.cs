using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoBuXang : TaxiOperationDbEntityBase<BaoCaoBuXang>
    {
        /// <summary>
        /// Ngày giờ tiếp nhận
        /// </summary>
        public DateTime TGTiepNhan { set; get; }

        /// <summary>
        /// Di chuyển xa
        /// </summary>
        public int BuXang_Don { set; get; }

        /// <summary>
        /// Trượt hàng
        /// </summary>
        public int BuXang_Truot { set; get; }

        /// <summary>
        /// Mã lái xe
        /// </summary>
        public string MaLaiXe { set; get; }

        /// <summary>
        /// Loại xe
        /// </summary>
        public string LoaiXe { set; get; }

        /// <summary>
        /// Tổng Km bù
        /// </summary>
        public int TotalKmBu { set; get; }

        /// <summary>
        /// Thành tiền
        /// </summary>
        public decimal TongTien { set; get; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string TenNhanVien { set; get; }

        /// <summary>
        /// Lấy dữ liệu báo cáo chi tiết
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="malaixe"></param>
        /// <returns></returns>
        public static List<BaoCaoBuXang> GetReportDetail(DateTime? from, DateTime? to, string malaixe)
        {
            return BaoCaoBuXang.Inst.ExeStore("EnVang_Report_BaoCaoBuXang", from, to, malaixe).ToList<BaoCaoBuXang>();
        }

        /// <summary>
        /// Lấy dữ liệu báo cáo tổng quát
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="malaixe"></param>
        /// <returns></returns>
        public static List<BaoCaoBuXang> GetReportGeneral(DateTime? from, DateTime? to, string malaixe)
        {
            var data = GetReportDetail(from, to, malaixe);
            var ldata = data.GroupBy(p => p.TenNhanVien).Select(p =>
                new BaoCaoBuXang
                {
                    TenNhanVien = p.Key,
                    BuXang_Don = p.Sum(p1 => p1.BuXang_Don),
                    BuXang_Truot = p.Sum(p1 => p1.BuXang_Truot),
                    TotalKmBu = p.Sum(p1 => p1.TotalKmBu),
                    TongTien = p.Sum(p1 => p1.TongTien),
                }).ToList();
            return ldata;//return BaoCaoBuXang.Inst.ExeStore("EnVang_Report_BaoCaoBuXang_General", from, to, malaixe).ToList<BaoCaoBuXang>();
        }

    }
}
