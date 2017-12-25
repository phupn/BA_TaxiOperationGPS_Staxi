using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{

    [TableInfo(TableName = "T_CANHBAO")]
    public class CanhBao_Entity : TaxiOperationDbEntityBase<CanhBao_Entity>
    {
        [Field]
        public string FK_SoHieuXe {set;get;}
        [Field]
        public DateTime   ThoiDiemViPham {set;get;}
        [Field]
        public int FK_LoaiCanhBao {set;get;}
        [Field]
        public string NoiDung {set;get;}
        [Field]
        public DateTime CreateDate { set; get; }

        public int UpdateDiemDoMoi()
        {
            return ExeStoreNoneQuery("SP_T_TAXIOPERATION_VEHICLE_STOP_UPDATE");
        }

        public int GetDiemDungDo(params object[] para)
        {
            DataTable tbl = ExeStore("SP_T_TAXIOPERATION_VEHICLE_STOP_GET", para);

            if (tbl.Rows.Count > 0)
            {
                int ret = -1;
                int.TryParse(tbl.Rows[0]["FK_DiemDo"].ToString(),out ret);
                return ret;
            }
            return -1;
        }
    }
}