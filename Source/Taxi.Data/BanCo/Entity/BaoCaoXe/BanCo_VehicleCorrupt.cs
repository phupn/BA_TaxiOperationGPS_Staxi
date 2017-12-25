using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    [TableInfo(TableName = "BanCo_VehicleCorrupt")]
    public class BanCo_VehicleCorrupt : TaxiOperationDbEntityBase<BanCo_VehicleCorrupt>, IDayReport
    {
        [Field(IsKey = true, IsIdentity = true)]
        public long Id { set; get; }

        [Field]
        public string SoHieuXe { set; get; }
        [Field]
        public string MaLaiXe { set; get; }

        [Field]
        public DateTime? ReportedDate { set; get; }

        [Field]
        public string Description { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Reason { set; get; }

        /// <summary>
        /// Giờ cảnh báo
        /// </summary>
        public string ReportedTime
        {
            get
            {
                return ReportedDate == null ? string.Empty : ReportedDate.Value.TimeOfDay.ToString(@"hh\:mm\:ss");
            }
        }
        public string TenLaiXe { set; get; }

        public string TenLoaiXe { set; get; }
        public int SoHieuXe_int { get { return SoHieuXe.To<int>(); } }
        /// <summary>
        /// Lấy dữ liệu báo cáo
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sohieuxe"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public List<BanCo_VehicleCorrupt> GetReport(DateTime? from, DateTime? to, string sohieuxe, int statusId)
        {
            return this.ExeStore("EnVang_Report_BanCo_VehicleCorrupt", from, to, sohieuxe, statusId).ToList<BanCo_VehicleCorrupt>();
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get { return ReportedDate.Value; }
        }
    }
}
