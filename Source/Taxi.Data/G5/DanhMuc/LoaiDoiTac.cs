using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.G5
{
    [TableInfo(TableName = "[T_DOITAC_LOAI]")]
    public class LoaiDoiTac : DbEntityBase<LoaiDoiTac>
    {
        [Field(IsIdentity=true,IsKey=true)]
        [ValueField]
        public int Id { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string Name { get; set; }
    }
}
