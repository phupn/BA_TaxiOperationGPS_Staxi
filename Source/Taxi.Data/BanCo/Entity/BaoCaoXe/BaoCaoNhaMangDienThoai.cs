using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// Báo cáo nhà mạng điện thoại
    /// </summary>
    public class BaoCaoNhaMangDienThoai : TaxiOperationDbEntityBase<BaoCaoNhaMangDienThoai>
    {
        /// <summary>
        /// Mã nhà mạng
        /// </summary>
        public string MaNhaMang { get; set; }
        /// <summary>
        /// Nhà mạng
        /// </summary>
        public string NhaMang {get; set;}
        /// <summary>
        /// Số lượng thuê bao
        /// </summary>
        public int SoLuong { get; set; }
        /// <summary>
        /// Số cuốc khách
        /// </summary>
        public int SoCuoc { get; set; }
        /// <summary>
        /// Tổng tiền
        /// </summary>
        public decimal ThanhTien { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string SoDienThoai { get; set; }
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string TenKhachHang { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string DiaChi { get; set; }
        /// <summary>
        /// Kết quả
        /// </summary>
        public int KetQua { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }
        public List<BaoCaoNhaMangDienThoai> GetDataReport(DateTime? from, DateTime? to)
        {
            var data = GetDataReportDetail(from, to);
            return data.GroupBy(p => p.NhaMang).Select(pg =>
               new BaoCaoNhaMangDienThoai()
            {
                NhaMang = pg.Key,
                SoCuoc = pg.Sum(p => p.SoCuoc),
                SoLuong = pg.Count(),
                ThanhTien = pg.Sum(p => p.ThanhTien)
            }).OrderBy(p=>p.NhaMang).ToList();
        }

        public List<BaoCaoNhaMangDienThoai> GetDataReportDetail(DateTime? from, DateTime? to)
        {
            var data = ExeStore("sp_EnVang_BaoCaoNhaMangDienThoai", from, to).ToList<BaoCaoNhaMangDienThoai>();
            var nhaMang = T_NhaMang.Inst.GetListAll();
            data.ForEach(
                p =>
                {
                    var nm = nhaMang.FirstOrDefault(p1 => dieuKien(p1.DauSo, p.SoDienThoai));
                    if (nm != null)
                    {
                        p.NhaMang = nm.NhaMang;
                        p.MaNhaMang = nm.Ma;
                    }
                    //else
                    //{
                    //    p.NhaMang = "Khác";
                    //    p.MaNhaMang = "Khac";
                    //}
                });
          return data.Where(p=>p.MaNhaMang!=null).GroupBy(p => new {mnm=p.MaNhaMang,nm = p.NhaMang, sdt = p.SoDienThoai})
                    .Select(pg =>
                    {
                        var a = pg.FirstOrDefault(p=>!string.IsNullOrEmpty(p.TenKhachHang));
                        var b = pg.FirstOrDefault(p => !string.IsNullOrEmpty(p.DiaChi));
                        return new BaoCaoNhaMangDienThoai()
                                      {
                                          MaNhaMang = pg.Key.mnm,
                                          NhaMang = pg.Key.nm,
                                          SoDienThoai = pg.Key.sdt,
                                          TenKhachHang = a != null ? a.TenKhachHang : b!=null?b.TenKhachHang:string.Empty,
                                          DiaChi = a != null ? a.DiaChi : b!=null?b.DiaChi:string.Empty,
                                          SoCuoc = pg.Count(p => DieuKienKetQua(p.KetQua)),
                                          SoLuong = 0,
                                          ThanhTien = pg.Where(p => DieuKienKetQua(p.KetQua)).Sum(p => p.ThanhTien)
                                      };
                    }).OrderBy(p => p.NhaMang).ToList();
        }

        private bool dieuKien(string dauSo, string sdt)
        {
            return dauSo.Split(',').Any(p => sdt.Trim().StartsWith(p.Trim()));
        }

        private bool DieuKienKetQua(int dk)
        {
            return dk == 1 || dk == 8;
        }
    }
}
