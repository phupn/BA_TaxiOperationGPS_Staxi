using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[T_Staxi_CarType]")]
    public class StaxiCarType : DbEntityBase<StaxiCarType>,ICloneable
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { set; get; }
        [Field]
        public int StaxiType { set; get; }
        [Field]
        public string Name { set; get; }
        [Field]
        public int Seat { get; set; }
        [Field]
        public bool IsActive { set; get; }
        [Field]
        public StaxiCarType_Type Type { get; set; }
        [Field]
        public int OrderBy { get; set; }
        [Field]
        public DateTime UpdateTime { get; set; }
        public static void DeleteAll()
        {
            Inst.ExeStoreNoneQuery("sp_T_Staxi_CarType_DeleteAll");
        }
        public static List<StaxiCarType> GetList()
        {
            return Inst.ExeStore("sp_T_Staxi_CarType_SelectAll").ToList<StaxiCarType>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
