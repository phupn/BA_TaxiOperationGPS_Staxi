using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data.DM
{
   public class Sanh : DBObject
    {

       public int Insert(string _Name)
       {
           //sp_T_DMSanh_Insert
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

               rowAffected = this.RunProcedure("sp_T_DMSanh_Insert", parameters, rowAffected);
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
           //sp_T_DMSanh_Update
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

               rowAffected = this.RunProcedure("sp_T_DMSanh_Update", parameters, rowAffected);
               return (rowAffected > 0); 
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public System.Data.DataTable GetSanhByID(int ID)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ID",SqlDbType.Int  )                    
                };
           parameters[0].Value = ID;

           return this.RunProcedure("sp_T_DMSanh_SelectByID", parameters, "tblSanh").Tables[0];
       }

       public System.Data.DataTable GetAllSanh()
       {
           
            SqlParameter[] parameters = new SqlParameter[] {                                     
                };
            

           return this.RunProcedure("sp_T_DMSanh_SelectAll", parameters, "tblSanh").Tables[0];
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
                

               rowAffected = this.RunProcedure("sp_T_DMSanh_Delete", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }

       public bool CheckTonTaiTenSanh(string _Name)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@Name",SqlDbType.NVarChar,100),
                    new SqlParameter("@iCount",SqlDbType.Int  )      
                };
           parameters[0].Value = _Name;
           parameters[1].Direction = ParameterDirection.Output;

           this.RunProcedure("sp_T_DMSanh_CheckTonTaiTen", parameters, "tblSanh");

           int iCount = int.Parse(parameters[1].Value.ToString());

           if (iCount > 0) return true;

           return false;
       }
       /// <summary>
       /// ham tra ve ds xe thuoc sanh
       /// </summary>
       /// <param name="SanhID"></param>
       /// <returns></returns>
       public DataTable GetDSXeThuocSanh(int SanhID)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SanhID",SqlDbType.Int  )                    
                };
           parameters[0].Value = SanhID;

           return this.RunProcedure("sp_T_XE_SANH_SelectBySanhID", parameters, "tblSanh").Tables[0];
       }
       /// <summary>
       /// hamf tra ve thong tin sanh cua xe
       /// </summary>
       /// <param name="BienSoXe"></param>
       /// <returns></returns>
       public DataTable GetSanhCuaXe(string SoHieuXe)
       {
           SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4 )                    
                };
           parameters[0].Value = SoHieuXe;

           return this.RunProcedure("sp_T_XE_SANH_SelectSanhOfXe", parameters, "tblSanh").Tables[0];
   
       }
       /// <summary>
       /// ham tra ve ds xe khong thuoc sanh nao
       /// </summary>
       /// <returns></returns>
       public DataTable GetDSXeKhongThuocSanhNao()
       {
           SqlParameter[] parameters = new SqlParameter[] {
                
                };
            

           return this.RunProcedure("sp_T_XE_SANH_SelectAllXeKhongThuocSanhNao", parameters, "tblSanh").Tables[0];
       }

        
       /// <summary>
       /// them xe vao sanh
       /// </summary>
       /// <param name="SoHieuXe"></param>
       /// <param name="SanhID"></param>
       /// <returns></returns>
       public bool AddXeVaoSanh(string SoHieuXe, int SanhID)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {
                   new SqlParameter("@SanhID",SqlDbType.Int  )  ,
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)  
                };
               parameters[0].Value = SanhID;
               parameters[1].Value = SoHieuXe;

               rowAffected = this.RunProcedure("sp_T_XE_SANH_AddXeVaoSanh", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }


       public bool XoaXeTrongSanh(string SoHieuXe)
       {
           try
           {
               int rowAffected = 0;
               SqlParameter[] parameters = new SqlParameter[] {                 
                    new SqlParameter("@SoHieuXe",SqlDbType.VarChar,4)  
                };
               parameters[0].Value = SoHieuXe;


               rowAffected = this.RunProcedure("sp_T_XE_SANH_XoaXeTrongSanh", parameters, rowAffected);
               return (rowAffected > 0);
           }
           catch (Exception e)
           {
               return false;
           }
       }
   }
}
