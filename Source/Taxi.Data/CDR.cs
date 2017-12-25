using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Taxi.Data
{
    public class CDR
    {
        private string g_ConnectionString = string.Empty;
        private SqlConnection g_sqlCon;

        public CDR()
        {
            g_ConnectionString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
            g_sqlCon = new SqlConnection(g_ConnectionString);
        }



        /// <summary>
        /// lay thong tin chi tiet mot cuoc goi CDR
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="line"></param>
        /// <param name="phone"></param>
        /// <param name="isIncomming"></param>
        /// <returns></returns>
        public DataTable GetCDRs(DateTime from, DateTime to, string line, string phone, bool isIncomming)
        {
            string sql = " SELECT  calldate,src ,dst,duration, (((duration - billsec)/5 ) + 1  ) AS bells,disposition,REPLACE(userfield,\'audio:\',\'\') AS FileVoicePath FROM  [Asterisk.CDR] ";
            sql += string.Format(" WHERE  calldate >= '{0:yyyy-MM-dd HH:mm:ss}' AND calldate <= '{1:yyyy-MM-dd HH:mm:ss}' ", from, to);

            // cuoc goi den / di
            if (isIncomming)    // goi den
            {
                sql += " AND ((CHARINDEX(\'audio\',userfield,0) >0) ) AND (CHARINDEX(\'OUT\',userfield,0) <= 0) ";
                if (line.Length > 0)
                    sql += string.Format(" AND dst='{0}' ", line);
                if (phone.Length > 0) //
                    sql += string.Format(" AND src='{0}'  ", phone);
            }
            else
            {
                sql += " AND ((CHARINDEX(\'audio\',userfield,0) >0) ) AND (CHARINDEX(\'OUT\',userfield,0) > 0) ";

                if (line.Length > 0)
                    sql += string.Format(" AND src='{0}' ", line);
                if (phone.Length > 0) //
                    sql += string.Format(" AND dst='{0}'  ", phone);
            }
            // cuoc goi voi so va line



            using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.Text, sql))
            {
                g_sqlCon.Close();
                if (ds.Tables != null && ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }

            return null;

        }
    }
}
