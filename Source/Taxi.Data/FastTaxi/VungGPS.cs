using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[dbo].[DM_VUNG_GPS]")]
    public class VungGPS : DbEntityBase<VungGPS>
    {
        [Field(IsKey=true)]
        public int Id { get; set; }
        [DisplayField]
        [Field]
        [ColumnField]
        public string TenVungGPS { get; set; }
        [Field]
        [ValueField]
        
        public int KenhVung { get; set; }
        [Field]
        public int KenhGop { get; set; }
        [Field]
        public string ToaDoVung { get; set; }
        [Field]
        public int BanKinhTimXe { get; set; }
    }
}
