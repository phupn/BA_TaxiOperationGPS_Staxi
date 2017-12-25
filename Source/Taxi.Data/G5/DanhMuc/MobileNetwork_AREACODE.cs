using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.G5.DanhMuc
{
    /// <summary>
    /// Danh mục đầu số của nhà mạng
    /// </summary>
    [TableInfo(TableName = "T_MobileNetwork_AREACODE")]
    public class MobileNetwork_AREACODE : DbEntityBase<MobileNetwork_AREACODE>
    {
        [Field(IsIdentity = true)]
        public string AreaCode { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public string FK_MobileNetwork { get; set; }

        public Enum_MobileNetWork_Type MobileNetworkType { get; set; }

        public List<MobileNetwork_AREACODE> GetListItem()
        {
            return ExeStore("SP_T_MobileNetwork_AREACODE_GetAllWithType").ToList<MobileNetwork_AREACODE>();
        }
    }
}
