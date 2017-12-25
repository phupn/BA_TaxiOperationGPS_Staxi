using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[GIS.T_PROVINCE]")]
    public class Province : DbEntityBase<Province>
    {
        [Field(IsKey = true)]
        [ValueField]
        public int PK_ProvinceID { get; set; }

        [Field]
        public string NameEN { get; set; }

        [Field]
        [DisplayField]
        [ColumnField]
        public string NameVN { get; set; }

        [Field]
        public string Polygon { get; set; }

        [Field]
        public string CountryCode { get; set; }
        public List<Province> GetAll_List()
        {
            return GetAllToList();
        }
    }
}
