using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_TAXIOPERATION_KETTHUC")]
    public class TaxiOperationKetThuc : TaxiOperationDbEntityBase<TaxiOperationKetThuc>
    {
        [Field(IsKey = true, IsIdentity = false)]
        public long ID { get; set; }

        [Field]
        public string XeNhan { get; set; }

        
        [Field]
        public DateTime? ThoiDiemThayDoiDuLieu { get; set; }

        [Field]
        public string PhoneNumber { get; set; }

        [Field]
        public string MaDoiTac { get; set; }

        public List<TaxiOperationKetThuc> GetAllPhoneNum()
        {
            return getSDT().ToList<TaxiOperationKetThuc>();
        }

        public DataTable getSDT() {
            return ExeStore("sp_T_TAXIOPERATION_KETTHUC_BC_GET_PhoneNum");;
        }

        public int DongBoCuocGoi(params object[] para) {
            return ExeStoreNoneQuery("sp_T_TAXIOPERATION_KETTHUC_BC_Update_MDT", para);
        }
    }
}
