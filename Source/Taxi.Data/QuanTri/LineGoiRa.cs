using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.QuanTri
{
   public  class LineGoiRa:DBObject
    {
       /// <summary>
       /// chèn một thông tin line gọi ra
       /// </summary>
       /// <param name="IP"></param>
       /// <param name="Line_Vung"></param>
       /// <param name="IsMayTinh"></param>
       /// <param name="IsActive"></param>
       /// <returns></returns>
       public bool Insert(string IP, string Line_Vung, string IsMayTinh, bool IsActive)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@IP_Address",SqlDbType.VarChar,15),
                    new SqlParameter("@Line_Vung",SqlDbType.VarChar ,50),
                    new SqlParameter("@IsMayTinh",SqlDbType.VarChar ,2) ,
                    new SqlParameter("@IsHoatDong",SqlDbType.VarChar,1)   

                };
               parameters[0].Value = IP;
               parameters[1].Value = Line_Vung;
               parameters[2].Value = IsMayTinh;
               parameters[3].Value = IsActive == true ? "1" : "0";

               rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_LINEGOIRA_Insert", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
        
       public bool Delete(int id)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int)   
                };
               parameters[0].Value = id ;


               rowAffected = this.RunProcedure("SP_T_QUANTRICAUHINH_LINEGOIRA_Delete", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public DataTable GetDSLineRa()
       {
           string sql = "";
           sql = "SELECT *";
           sql+= " FROM  [T_QUANTRICAUHINH_LINEGOIRA]";

           return RunSQL(sql, "tblLineGoiRa");
       }
      

   }
}
