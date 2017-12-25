using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.KhachDat
{
    [TableInfo(TableName = "T_SystemBook")]
    public class SystemBook : DbEntityBase<SystemBook>
    {
        [Field(IsKey= true, IsIdentity= true)]
        public int PK_SystemBookID { get; set; }
        [Field]
        public string Name { get; set; }
    }
}
