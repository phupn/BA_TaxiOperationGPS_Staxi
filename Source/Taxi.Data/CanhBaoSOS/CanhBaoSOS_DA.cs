using System;
using System.Data.SqlClient;
using System.Data;
using Taxi.Utils;
namespace Taxi.Data.CanhBaoSOS
{
    public class CanhBaoSOS_DA : DBObject
    {
        
        public string ConnectString = string.Empty;

        public CanhBaoSOS_DA()
        { 
            // chuỗi kết nối cơ sở dữ liệu
            ConnectString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString.ToString();
        }
        public DataTable GetList(string lineActive)
        {
            using (SqlConnection connect = new SqlConnection(ConnectString))
            {

                SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Line", SqlDbType.VarChar, 20) };
                parameters[0].Value = lineActive;
                using (DataSet ds = RunProcedure("CanhBaoSOS_GetList", parameters, "CanhBaoSOS"))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                }
                return null;
            }
        }

        public int CheckAll(string ListID)
        {
            int rowAffects = 0;
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                     new SqlParameter("@ListID",SqlDbType.VarChar ,4000)
                     };
                parameters[0].Value = ListID;
                return RunProcedure("CanhBaoSOS_CheckAllListID", parameters, rowAffects);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
