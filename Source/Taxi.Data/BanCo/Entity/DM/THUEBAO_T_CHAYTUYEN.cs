using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "[THUEBAO.T_CHAYTUYEN]")]
    public class THUEBAO_T_CHAYTUYEN : TaxiOperationDbEntityBase<THUEBAO_T_CHAYTUYEN>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { set; get; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Chạy tuyến")]
        public string ChayTuyen { set; get; }

        [Field]
        public string GhiChu { set; get; }
    }
}
