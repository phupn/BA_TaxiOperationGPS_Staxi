using Taxi.Data.BanCo.DbConnections;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.DieuXe
{
    [TableInfo(TableName = "BanCo_VungDieuHanh")]
    public class BanCo_VungDieuHanh : TaxiOperationDbEntityBase<BanCo_VungDieuHanh>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { set; get; }

        [Field]
        public string NameVungDH { set; get; }

        [Field]
        public string ShortName { get; set; }


        [DisplayField]
        [ColumnField(ColumnName = "Vùng")]
        public string MergerName
        {
            get
            {
                if (!string.IsNullOrEmpty(ShortName))
                {
                    return ShortName + " - " + NameVungDH;
                }
                return NameVungDH;
            }
        }

        public List<BanCo_VungDieuHanh> GetListAll()
        {
            return this.GetAll().ToList<BanCo_VungDieuHanh>();
        }
    }
}
