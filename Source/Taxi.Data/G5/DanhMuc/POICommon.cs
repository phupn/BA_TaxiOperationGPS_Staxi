#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System.Data;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{

    [TableInfo(TableName = "GPS_POI")]
    public class POICommon : DbEntityBase<POICommon>
    {
        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }

        public string NameEN { get; set; }

        [Field]
        public string NameVN { get; set; }

        public int Type { get; set; }

        public string Acronym { get; set; }

        public double Lng { get; set; }

        public double Lat { get; set; }

        public string Address { get; set; }

        [Field]
        public string VietTat { get; set; }

        [Field]
        public double KinhDo { get; set; }

        [Field]
        public double ViDo { get; set; }

        [Field]
        public string DiaChi { get; set; }

        [Field]
        public DateTime? LastUpdate { get; set; }
        public DateTime? InsertedUpdate { get; set; }
        public string InsertedBy { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region===Methods===
        public List<POICommon> GetPoints(int type, bool isGetAll)
        {
            return ExeStore("GPS_SELECT_TOADO_V2", isGetAll, type).ToList<POICommon>();
        }

        public int InsertObject(params object[] inputs)
        {
            return this.ExeStoreNoneQuery("sp_InsertGPS_POI",inputs);
        }

        public int DeletePOI(string pID)
        {
            try
            {
                int pId = pID.To<int>();
                return this.ExeStoreNoneQuery("sp_DeletePOI", pId);
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("DeletePOI",ex);
                return -10;
            }
        }
        #endregion


    }
}
