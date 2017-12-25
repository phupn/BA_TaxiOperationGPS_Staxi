using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System;

namespace Taxi.Data.BanCo.Entity
{
    [TableInfo(TableName = "T_CHECKIN_CHECKOUT")]
    public class CheckInCheckOut : TaxiOperationDbEntityBase<CheckInCheckOut>
    {
        [Field(IsKey = true, IsIdentity = false)]
        public long ID { get; set; }

        [Field]
        public string Username { get; set; }

        [Field]
        public DateTime ThoiDiemCheckIn { get; set; }

        [Field]
        public DateTime? ThoiDiemCheckOut { get; set; }

        [Field]
        public string IPAdress { get; set; }

        [Field]
        public string GhiChu { get; set; }


    }
}
