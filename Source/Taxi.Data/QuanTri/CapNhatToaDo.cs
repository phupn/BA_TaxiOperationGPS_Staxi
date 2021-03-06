using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Taxi.Data
{
   public class CapNhatToaDo
    {
       string connString;
       private SqlConnection g_sqlCon;
       public CapNhatToaDo() {
           connString = Taxi.Utils.Settings.ConnectionSetting.ConnectionString;
           g_sqlCon = new SqlConnection(connString);
       }

       public DataTable GET_ALL(int Type,bool isGetAll)
       {
           if (g_sqlCon.State == ConnectionState.Closed)
           {
               g_sqlCon.Open();
           }
           SqlParameter[] parameters = { new SqlParameter("@isGetAll", SqlDbType.Bit), new SqlParameter("@Type", SqlDbType.Int) };
           parameters[0].Value = isGetAll;
           parameters[1].Value = Type;
           using (DataSet ds = SqlHelper.ExecuteDataset(g_sqlCon, CommandType.StoredProcedure, "GPS_SELECT_TOADO", parameters))
           {
               g_sqlCon.Close();
               if (ds.Tables != null && ds.Tables.Count > 0)
                   return ds.Tables[0];
           }
           return null;
       }

       public bool UPDATE(int Type, string ID, double KinhDo, double ViDo, string NameVN, string DiaChi, string viettat)
       {
           try
           {
               if (g_sqlCon.State == ConnectionState.Closed)
               {
                   g_sqlCon.Open();
               }
               SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter ("@Type",SqlDbType.Int),
                    new SqlParameter ("@ID",SqlDbType.VarChar,50),
                    new SqlParameter ("@KinhDo",SqlDbType.Float),
                    new SqlParameter ("@ViDo",SqlDbType.Float),
                    new SqlParameter ("@NameVN",SqlDbType.NVarChar,250),
                    new SqlParameter ("@DiaChi",SqlDbType.NVarChar,250),
                    new SqlParameter ("@VietTat",SqlDbType.VarChar,50)
                };
               parameters[0].Value = Type;
               parameters[1].Value = ID;
               parameters[2].Value = KinhDo;
               parameters[3].Value = ViDo;
               parameters[4].Value = NameVN;
               parameters[5].Value = DiaChi;
               parameters[6].Value = viettat;
               

               int rowAffeced = SqlHelper.ExecuteNonQuery(g_sqlCon, CommandType.StoredProcedure, "SP_GPS_UPDATE_TOADO", parameters);
               g_sqlCon.Close();
               return (rowAffeced > 0);
           }
           catch
           {
               return false;
           }
       }
    }
}

