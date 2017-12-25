using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_DMGARA")]
    public class DMGara : TaxiOperationDbEntityBase<DMGara>
    {
        
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int ID { get; set; }
        
        [Field]
        [DisplayField]
        [ColumnField(Name = "Gara")]
        public string Name { get; set; }

        [Field]
        public string VietTat { get; set; }

        [Field]
        public int? IDGPS { get; set; }

        [Field]
        public double? KinhDo { get; set; }

        [Field]
        public double? ViDo { get; set; }

        [Field]
        public int? BanKinh { get; set; }

        public List<DMGara> GetListAll()
        {
            return this.GetAll().ToList<DMGara>();
        }
    }
}
