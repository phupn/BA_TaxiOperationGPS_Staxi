using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.CanhBaoXe
{
    [TableInfo(TableName = "T_CanhBaoOnline")]
    public class CanhBaoSOS : TaxiOperationDbEntityBase<CanhBaoSOS>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string SoXe { get; set; }
        [Field]
        public float KinhDo { get; set; }
        [Field]
        public float ViDo { get; set; }
        [Field]
        public string DiaChi { get; set; }
        [Field]
        public DateTime ThoiDiem { get; set; }
        [Field]
        public bool TrangThai { get; set; }
        [Field]
        public string MaNV { get; set; }

        public List<CanhBaoSOS> GetList()
        {
            return ExeStore("CanhBaoSOS_GetList").ToList<CanhBaoSOS>();
        }

        public int CheckAll(string ListID)
        {
            return ExeStoreNoneQuery("CanhBaoSOS_CheckAllListID", ListID);
        }
    }
}
