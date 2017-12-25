using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.DM
{
    [TableInfo(TableName="T_DOITAC_LOAI")]
    public class LoaiDoiTac: DbEntityBase<LoaiDoiTac>
    {
        [Field(IsKey=true, IsIdentity=true)]
        public int Id { get; set; }
        [Field]
        public string Name { get; set; }
    }
}
