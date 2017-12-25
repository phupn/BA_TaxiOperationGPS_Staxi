using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
 public class DanhBaKhachAo : DBObject
    {

     public DanhBaKhachAo()
         :base()
     {

     }
     /// <summary>
     /// Insert mot doi tuong vao database
     /// </summary>
     /// <param name="PhoneNumber">so dien thoai</param>
     /// <param name="Name">ten nguoi</param>
     /// <param name="Address">dia chi</param>
     /// <returns></returns>
     public bool Insert(string PhoneNumber, string Name, string Address)
     {
         try
         {
             int rowAffected = 0;
             SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255)                    
                };
             parameters[0].Value = PhoneNumber;
             parameters[1].Value = Name;
             parameters[2].Value = Address;


             rowAffected = this.RunProcedure("sp_T_DANHBA_KHACHAO_Insert", parameters, rowAffected);
             return (rowAffected > 0);
         }
         catch (Exception e)
         {
             return false;
         }
     }


     public bool Update(string PhoneNumber, string Name, string Address)
     {
         try
         {
             int rowAffected = 0;
             SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11),
                    new SqlParameter("@Name",SqlDbType.NVarChar,50),
                    new SqlParameter("@Address",SqlDbType.NVarChar,255)                    
                };
             parameters[0].Value = PhoneNumber;
             parameters[1].Value = Name;
             parameters[2].Value = Address;


             rowAffected = this.RunProcedure("sp_T_DANHBA_KHACHAO_Update", parameters, rowAffected);
             return (rowAffected > 0);
         }
         catch (Exception e)
         {
             return false;
         }
     }

     /// <summary>
     /// Get thong tin cua mot so dien thoai
     /// If PhoneNumber= rong thi lay tat ca
     /// </summary>
     /// <param name="PhoneNumber"></param>
     /// <returns></returns>
     public DataTable GetDanhBaKhachAo(string PhoneNumber)
     {
         SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11)                    
                };
         parameters[0].Value = PhoneNumber;

         return this.RunProcedure("sp_T_DANHBA_KHACHAO_Select", parameters, "tblUser").Tables[0];
     }

     public bool Delete(string PhoneNumber)
     {
         try
         {
             int rowAffected = 0;
             SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar,11)                                  
                };
             parameters[0].Value = PhoneNumber;
             rowAffected = this.RunProcedure("sp_T_DANHBA_KHACHAO_Delete", parameters, rowAffected);
             return (rowAffected > 0);
         }
         catch (Exception e)
         {
             return false;
         }
     }

     public DataTable GetKhachAos(string strSQL)
     {
         return RunSQL(strSQL, "tblKhachao");
     }
 }
}
