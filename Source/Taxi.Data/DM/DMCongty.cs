using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
    public class Congty : DBObject
    {
        /// <summary>
        /// ham lay ds cong ty
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDSCongTy()
        {
            string strSQL = " SELECT [PK_CongtyID] CongTyID ,[TenCongTy] FROM  T_DMCongTy ";
            return this.RunSQL(strSQL, "tblCongTy");
        }

        /// <summary>
        /// fill to Combobox
        /// </summary>
        /// <returns>Tat ca Cong Ty (CongTyID + [TenCongTy])</returns>
        public DataTable GetListOfCongTys_NAME()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return this.RunProcedure("SP_CONGTY_SELECT_ALL_NAME", parameters, "tblCongTy").Tables[0];
        }
    }
}
