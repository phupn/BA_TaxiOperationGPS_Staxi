using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
namespace Taxi.Data.FastTaxi
{
    [TableInfo(TableName = "[T_G5_LoaiXe]")]
    public class G5LoaiXe : DbEntityBase<G5LoaiXe>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public int G5_CarType { get; set; }
        [Field]
        public string TenHienThi { get; set; }
        [Field]
        public int SoCho { get; set; }
        [Field]
        public bool IsXeTo { get; set; }
        [Field]
        public bool IsSanBay { get; set; }
        [Field]
        public int OrderBy { get; set; }
        [Field]
        public DateTime UpdateTime { get; set; }
        public System.Collections.Generic.List<G5LoaiXe> GetList()
        {
            return GetAll().ToList<G5LoaiXe>();
        }
    }
}
