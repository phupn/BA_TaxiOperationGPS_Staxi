using System;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class Config_CommonDA : DBObject
    {
        
        public DataTable GetAllConfig()
        {
            SqlParameter[] parameters = new SqlParameter[] { };

            return RunProcedure("SP_Config_Common_GetAll", parameters, "tblListIP").Tables[0];
        }

        public DataTable GetLastDate(DateTime dt)
        {
            return ExeStoreData("Sp_Config_Common_LastUpdate", dt);
        }
        public bool Update(int id, string value)
        {
            string sql = string.Format(@"IF((SELECT COUNT(0) FROM Config_Common WHERE Id={0})=0)
                                            INSERT INTO [dbo].[Config_Common]([Id],[Name],[HasValue],[Description])VALUES({0},'','{1}','')
                                         ELSE UPDATE [dbo].[Config_Common] SET HasValue='{1}' WHERE Id={0}", id, value);
            return this.RunSQL(sql)>0;          
        }
        public bool Update(int id, string value, string Name, string Description)
        {
            string sql = string.Format(@"IF((SELECT COUNT(0) FROM Config_Common WHERE Id={0})=0)
                                            INSERT INTO [dbo].[Config_Common]([Id],[Name],[HasValue],[Description])VALUES({0},N'{2}','{1}',N'{3}')
                                         ELSE UPDATE [dbo].[Config_Common] SET HasValue='{1}',Name=N'{2}',Description=N'{3}' WHERE Id={0}", id, value, Name, Description);
            return this.RunSQL(sql) > 0;
        }
    }
}
