using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[GIS.T_DISTRICT]")]
    public class District : DbEntityBase<District>
    {
        [Field(IsKey = true)]
        [ValueField]
        public int PK_DistrictID { get; set; }

        [Field]
        public string NameEN { get; set; }

        [Field]
        [DisplayField]
        [ColumnField]
        public string NameVN { get; set; }

        [Field]
        public string Polygon { get; set; }

        [Field]
        public int FK_ProvinceID { get; set; }

        [Field]
        public double Lat { get; set; }

        [Field]
        public double Lng { get; set; }

        public List<District> GetAll_List()
        {
            return GetAllToList();
        }
    }
}
