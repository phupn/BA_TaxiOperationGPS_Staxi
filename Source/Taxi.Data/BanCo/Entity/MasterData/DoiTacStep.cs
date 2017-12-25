using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Linq;


namespace Taxi.Data.BanCo.Entity.MasterData
{
    [TableInfo(TableName = "T_DOITAC_STEP")]
    public class DoiTacStep : TaxiOperationDbEntityBase<DoiTacStep>
    {
        #region Properties
        [ValueField]
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [DisplayField]
        [ColumnField]
        [Field]
        public int Money { get; set; }
        [Field]
        public int Step1From { get; set; }
        [Field]
        public int Step1To { get; set; }
        [Field]
        public int Step1Money { get; set; }
        [Field]
        public int Step2From { get; set; }
        [Field]
        public int Step2To { get; set; }
        [Field]
        public int Step2Money { get; set; }
        [Field]
        public int Step3From { get; set; }
        [Field]
        public int Step3Money { get; set; }
        [ColumnField]
        [Field]
        public string StepNotes { get; set; }
        #endregion
        public List<DoiTacStep> GetAllDoiTacStep()
        {
            return GetAll().ToList<DoiTacStep>();
        }
    }
}
