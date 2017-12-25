using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using System.Collections.Generic;
using Taxi.Common.Extender;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    /// <summary>
    /// 
    /// </summary>
    [TableInfo(TableName = "BanCo_GiamSatXe_Reasons")]
    public class BanCo_GiamSatXe_Reason : TaxiOperationDbEntityBase<BanCo_GiamSatXe_Reason>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { set; get; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Lý do")]
        public string Reason { set; get; }

        [Field]
        public string ShortName { set; get; }

        [Field]
        new public int Type { set; get; }

        [Field]
        new public int Sort { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string TypeName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BanCo_GiamSatXe_Reason> GetAllToList()
        {
            return this.ExeStore("sp_EnVang_BanCo_GiamSatXe_Reasons_GetAll").ToList<BanCo_GiamSatXe_Reason>();
        }
    }
}
