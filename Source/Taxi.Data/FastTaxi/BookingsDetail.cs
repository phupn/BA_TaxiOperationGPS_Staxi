using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[T_TAXIRETURN_BOOKINGS_DETAIL]")]
    public class BookingsDetail : DbEntityBase<BookingsDetail>
    {
        #region Field

        // [Field(IsKey = true)]
        public long PK_BookingDetailID { get; set; }

        [Field(IsKey = true)]
        public long FK_BookID { get; set; }

        [Field]
        public int CompanyID { get; set; }

        [Field(IsKey = true)]
        public long TripID { get; set; }

        [Field]
        public int Status { get; set; }
        [Field]
        public string LyDo { get; set; }
        //[Field]
        public bool IsCustBook { get; set; }
        [Field]
        public DateTime? DateUpdated { get; set; }
        [Field]
        public string ABRoute { get; set; }
        [Field]
        public string CDRoute { get; set; }
        [Field]
        public float CalF { get; set; }

        #endregion

        #region Mở rộng
        public string FK_SoHieuXe { get; set; }
        public string TenLaiXe { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaDiemDen { get; set; }
        public int KmDuKien { get; set; }
        public DateTime TGDuKien { get; set; }
        public int TrangThai { get; set; }
        public float Xe_ViDo { get; set; }
        public float Xe_KinhDo { get; set; }
        public float Di_ViDo { get; set; }
        public float Di_KinhDo { get; set; }
        public float Den_ViDo { get; set; }
        public float Den_KinhDo { get; set; }
        public string GhiChu { get; set; }
        #endregion

        #region hàm
        public List<BookingsDetail> GetListByBookID(long id)
        {
            return ExeStore("sp_FT_BookingsDetail_GetListByBookID", id).ToList<BookingsDetail>();
        }

        #endregion
    }

}
