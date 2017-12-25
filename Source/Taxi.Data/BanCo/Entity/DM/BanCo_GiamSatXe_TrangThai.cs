using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "BanCo_GiamSatXe_TrangThai")]
    public class BanCo_GiamSatXe_TrangThai : TaxiOperationDbEntityBase<BanCo_GiamSatXe_TrangThai>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { set; get; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Trạng thái")]
        public string Name { set; get; }
    }
}
