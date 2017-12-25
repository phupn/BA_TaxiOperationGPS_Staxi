using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.G5.DanhMuc
{
    /// <summary>
    /// Danh mục đầu số của nhà mạng
    /// </summary>
    [TableInfo(TableName = "T_MobileNetwork")]
    public class MobileNetwork : DbEntityBase<MobileNetwork>
    {
        [Field(IsIdentity = true)]
        public string ID { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public Enum_MobileNetWork_Type NetworkType { get; set; }
    }
}
