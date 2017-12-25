using System;
using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using System.Linq;

using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "BanCo_Config")]
    public class BanCo_Config : TaxiOperationDbEntityBase<BanCo_Config>
    {
        [Field(IsKey = true, IsIdentity = false)]
        public Taxi.Utils.Enum_Config_Alert Id { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public string Value { get; set; }

        [Field]
        new public byte? Type { get; set; }

        [Field]
        public DateTime? DateCreated { get; set; }
        
        [Field]
        public bool? Notify { get; set; }

        [Field]
        public string Description { get; set; }

        public List<BanCo_Config> GetListAll()
        {
            return GetAll().ToList<BanCo_Config>();
        }
    }
}
