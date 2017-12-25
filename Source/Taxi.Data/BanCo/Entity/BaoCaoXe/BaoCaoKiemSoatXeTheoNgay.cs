using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoKiemSoatXeTheoNgay : TaxiOperationDbEntityBase<BaoCaoKiemSoatXeTheoNgay>
    {
        /// <summary>
        /// Thời điểm báo
        /// </summary>
        public DateTime ThoiDiemBao { set; get; }

        /// <summary>
        /// Số hiệu xe
        /// </summary>
        public string SoHieuXe { set; get; }

        /// <summary>
        /// Tên lái xe
        /// </summary>
        public string TenLaiXe { set; get; }

        /// <summary>
        /// Tên trạng thái lái xe báo
        /// </summary>
        public string TrangThaiLaiXeBao { set; get; }

        /// <summary>
        /// Vị trí báo
        /// </summary>
        public string ViTriDiemBao { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int DiemDo { set; get; }

        /// <summary>
        /// Vùng điều hành
        /// </summary>
        public string NameVungDH { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public long DongHo { set; get; }

        /// <summary>
        /// Số phút nghỉ
        /// </summary>
        public int SoPhutNghi { set; get; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { set; get; }

        public int SoHieuXe_int{get { return SoHieuXe.To<int>(); }}

        /// <summary>
        /// Lấy dữ liệu báo cáo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sohieuxe"></param>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public List<BaoCaoKiemSoatXeTheoNgay> GetDataReport(DateTime? from, DateTime? to, string sohieuxe, string trangthai)
        {
            return this.ExeStore("EnVang_Report_BanCo_GiamSatXe_BaoCaoKiemSoatXeTheoNgay", from, to, sohieuxe, trangthai).ToList<BaoCaoKiemSoatXeTheoNgay>();
        }
    }
}
