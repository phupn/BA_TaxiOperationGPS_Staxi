using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
   public class Gara : DBObject
    {

       public int Insert(string _Name)
       {
           //sp_T_DMGARA_Insert
            // @Name nvarchar(100),
            // @ID int OUTPUT
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@ID",SqlDbType.Int  )                    
                    
                };
               parameters[0].Value = _Name;
               parameters[1].Direction = ParameterDirection.Output; 

               rowAffected = this.RunProcedure("sp_T_DMGARA_Insert", parameters, rowAffected);
               if (rowAffected > 0)
               {
                   return int.Parse(parameters[1].Value.ToString());
               }
               return -1;
           }
           catch (Exception e)
           {
               return -1;
           }

       }

       public bool Update(int ID, string Name)
       {
           //sp_T_DMGARA_Update
            // @ID int ,
            // @Name nvarchar(100)
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@ID",SqlDbType.Int  )  ,
                    new SqlParameter("@Name",SqlDbType.NVarChar,100)  
                };
               parameters[0].Value = ID;
               parameters[1].Value = Name;

               rowAffected = this.RunProcedure("sp_T_DMGARA_Update", parameters, rowAffected);
               return (rowAffected > 0); 
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public System.Data.DataTable GetGaraByID(int ID)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int  )                    
                };
           parameters[0].Value = ID;

           return this.RunProcedure("sp_T_DMGARA_SelectByID", parameters, "tblGara").Tables[0];
       }

       public DataTable GetAllGara()
       {
           
            SqlParameter[] parameters = new SqlParameter[] {                                     
                };
            

           return this.RunProcedure("sp_T_DMGARA_SelectAll", parameters, "tblGara").Tables[0];
       }

       public bool Delete(int ID)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@ID",SqlDbType.Int  )   
                };
               parameters[0].Value = ID;
                

               rowAffected = this.RunProcedure("sp_T_DMGARA_Delete", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public bool CheckTonTaiTenGara(string _Name)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@iCount",SqlDbType.Int  )      
                };
           parameters[0].Value = _Name;
           parameters[1].Direction = ParameterDirection.Output;

           this.RunProcedure("sp_T_DMGARA_CheckTonTaiTen", parameters, "tblGara");

           int iCount = int.Parse(parameters[1].Value.ToString());

           if (iCount > 0) return true;

           return false;
       }
   }
}
