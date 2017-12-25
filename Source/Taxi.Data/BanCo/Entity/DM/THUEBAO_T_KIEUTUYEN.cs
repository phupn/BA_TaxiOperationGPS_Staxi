using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "[THUEBAO.T_KIEUTUYEN]")]
    public class THUEBAO_T_KIEUTUYEN : TaxiOperationDbEntityBase<THUEBAO_T_KIEUTUYEN>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { set; get; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Kiểu tuyến")]
        public string TypeName { set; get; }

        [Field]
        public int FK_ChayTuyen { set; get; }
    }
}
