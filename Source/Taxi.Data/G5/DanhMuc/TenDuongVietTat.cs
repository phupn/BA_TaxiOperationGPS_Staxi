#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = TABLE_NAME)]
    public class TenDuongVietTat : DbEntityBase<TenDuongVietTat>
    {
        private const string TABLE_NAME = "[GPS.T_ROAD]";
        private const string sp_GPS_T_ROAD_GetPoint = "sp_GPS_T_ROAD_GetPoint";

        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }
        [Field]
        public string NameEN { get; set; }
        [Field]
        public string NameVN { get; set; }
        [Field]
        public string Polygon { get; set; }
        [Field]
        public int Type { get; set; }
        [Field]
        public int FK_CommuneID { get; set; }
        [Field]
        public int FK_DistrictID { get; set; }
        [Field]
        public int FK_ProvinceID { get; set; }
        [Field]
        public int FK_VungDieuHanhID { get; set; }
        [Field]
        public string VietTat { get; set; }
        [Field]
        public string MaCungXN { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public string Road { get; set; }
        [Field]
        public long FK_CuocGoiID { get; set; }

        #endregion

        #region===Methods===
        public List<TenDuongVietTat> GetPoint(long idCuocGoi)
        {
            return ExeStore(sp_GPS_T_ROAD_GetPoint, idCuocGoi).ToList<TenDuongVietTat>();
        }
        #endregion
    }
}
