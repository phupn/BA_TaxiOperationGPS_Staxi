using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.Attributes.Validator;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_DM_NHAMANG")]
    public class T_NhaMang : TaxiOperationDbEntityBase<T_NhaMang>
    {
        [Field(IsKey = true,Name = "mã nhà mạng")]
        [ValueField]
        [ValidatorRequire]
        public string Ma { get; set; }
        [Field(Name = "tên nhà mạng")]
        [DisplayField]
        [ValidatorRequire]
        public string NhaMang { get; set; }
        [Field(Name = "đầu số")]
        [ValidatorRequire]
        public string DauSo { get; set; }

        public List<T_NhaMang> GetListAll()
        {
            return GetAll().ToList<T_NhaMang>();
        }
    }
}
