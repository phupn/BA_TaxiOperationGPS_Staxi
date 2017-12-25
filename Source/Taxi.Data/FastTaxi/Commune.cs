using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[GIS.T_Commune]")]
    public class Commune : DbEntityBase<Commune>
    {
        [Field(IsKey = true)]
        [ValueField]
        public int PK_CommuneID { get; set; }

        [Field]
        public string NameEN { get; set; }

        [Field]
        [DisplayField]
        [ColumnField]
        public string NameVN { get; set; }

        [Field]
        public string Polygon { get; set; }

        [Field]
        public int FK_DistrictID { get; set; }

        //[Field]
        //public double Lat { get; set; }

        //[Field]
        //public double Lng { get; set; }
        public Commune()
        {
            PK_CommuneID = 0;
            FK_DistrictID = 0;
            NameEN = "Chon Phuong Xa";
            NameVN = "Chọn Phường Xã";
        }
        public Commune(int pK_CommuneID, int fK_DistrictID, string nameEN, string nameVN)
        {
            PK_CommuneID = pK_CommuneID;
            FK_DistrictID = fK_DistrictID;
            NameEN = nameEN;
            NameVN = nameVN;
        }
        public List<Commune> GetAll_List()
        {
            return GetAllToList();
        }
    }
}
