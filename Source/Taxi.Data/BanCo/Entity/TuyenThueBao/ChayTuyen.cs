using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity.TuyenThueBao
{
    [TableInfo(TableName = "[THUEBAO.T_CHAYTUYEN]")]
    public class THUEBAO_T_ChayTuyen : TaxiOperationDbEntityBase<THUEBAO_T_ChayTuyen>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int Id { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(Name = "Kiểu tuyến")]
        public string ChayTuyen { get; set; }

        [Field]
        public string GhiChu { get; set; }
        #endregion

        public List<THUEBAO_T_ChayTuyen> GetListAll() {
            return GetAll().ToList<THUEBAO_T_ChayTuyen>();
        }

        public DataTable GetAllChayTuyen()
        {
            return ExeStore("sp_T_CHAYTUYEN_GetAll");
        }
    }
}
