using Taxi.Data.BanCo.DbConnections;
using System.Collections.Generic;
using System;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoKmCaoTrongThang : TaxiOperationDbEntityBase<BaoCaoKmCaoTrongThang>
    {
        /// <summary>
        /// Số hiệu xe
        /// </summary>
        public string SoHieuXe { set; get; }

        /// <summary>
        /// Mã lái xe
        /// </summary>
        public string MaLaiXe { set; get; }

        /// <summary>
        /// Tên lái xe
        /// </summary>
        public string TenLaiXe { set; get; }

        /// <summary>
        /// Km kinh doanh (Về - Đi)
        /// </summary>
        public long KmKinhDoanh { set; get; }

        /// <summary>
        /// Km Thực đi
        /// </summary>
        public float KmThucDi { set; get; }

        /// <summary>
        /// Tổng cuộc gọi 1
        /// </summary>
        public int TotalKieuCuocGoi { set; get; }

        /// <summary>
        /// Km Rỗng
        /// </summary>
        public float KmRong { set; get; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { set; get; }

        public int SoHieuXe_int{get { return SoHieuXe.To<int>(); }}
        /// <summary>
        /// Lấy dữ liệu báo cáo
        /// </summary>
        /// <returns></returns>
        public List<BaoCaoKmCaoTrongThang> GetDataReport(DateTime? from, DateTime? to, string loaixe, string sohieuxe, string malaixe, float kmRong)
        {
            return this.ExeStore("EnVang_Report_BanCo_GiamSatXe_BaoCaoKmRongCao", from, to, loaixe, sohieuxe, malaixe, kmRong).ToList<BaoCaoKmCaoTrongThang>();
        }
    }
}
