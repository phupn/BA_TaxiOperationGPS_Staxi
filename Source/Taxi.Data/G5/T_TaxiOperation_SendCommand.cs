using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.G5
{    
    [TableInfo(TableName = "T_TaxiOperation_SendCommand")]
    public class T_TaxiOperation_SendCommand : DbEntityBase<T_TaxiOperation_SendCommand>
    {
        #region ==== Const ====
        private const string SP_T_TaxiOperation_SendCommand_GetById = "SP_T_TaxiOperation_SendCommand_GetById";
        #endregion
        [Field(IsIdentity = true, IsKey = true)]
        public long Id { get; set; }
        [Field]
        public long IdCuocGoi { get; set; }

        [Field]
        public Guid BookId { get; set; }

        [Field]
        public string CommandText { get; set; }

        [Field]
        public int CommandID { get; set; }

        [Field]
        public string PrivateCode { get; set; }

        [Field]
        public bool Result { get; set; }

        public DateTime CreatedDate { get; set; }

        [Field]
        public string CreatedBy { get; set; }

        public List<T_TaxiOperation_SendCommand> GetAllById(long idCuocGoi)
        {
            return ExeStore(SP_T_TaxiOperation_SendCommand_GetById, idCuocGoi).ToList<T_TaxiOperation_SendCommand>();
        }

        /// <summary>
        /// Báo cáo giao tiếp lệnh app
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public List<T_TaxiOperation_SendCommand> GetBaoCao_13_1_GiaoTiepLenhApp(DateTime fromDate, DateTime toDate, string commandText)
        {
            return ExeStore("sp_BC_13_1_BaoCaoGiaoTiepLenhApp", fromDate, toDate, commandText).ToList<T_TaxiOperation_SendCommand>();
        }
    }
}
