using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Utils;
using System.Data;
using System.Data.SqlClient;

namespace Taxi.Data
{
    public class DanhBaCongTy : DBObject
    {

        public DanhBaCongTy() : base()
        {

        }
        /// <summary>
        /// Insert mot doi tuong vao database
        /// </summary>
        /// <param name="PhoneNumber">so dien thoai</param>
        /// <param name="Name">ten nguoi</param>
        /// <param name="Address">dia chi</param>
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

                rowAffected = this.RunProcedure("sp_T_DANHBA_CONGTY_Insert", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogErrorUtils.WriteLogError("Insert: ", e);
                return false;
            }
        }

        /// <summary>
        /// Get thong tin cua mot so dien thoai
        /// If PhoneNumber= rong thi lay tat ca
        /// </summary>
        public DataTable GetDanhBaCONGTY(string PhoneNumber)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PhoneNumber",SqlDbType.VarChar ,11)                    
                };
            parameters[0].Value = PhoneNumber;

            return this.RunProcedure("sp_T_DANHBA_CONGTY_Select", parameters, "tblUser").Tables[0];
        }
        
        public DataTable GetDanhBaCONGTY_GetLast(DateTime LastUpdate)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@LastUpdate",SqlDbType.DateTime)                    
                };
            parameters[0].Value = LastUpdate;

            return this.RunProcedure("sp_T_DANHBA_CONGTY_Select_LastUpdate", parameters, "tblUser").Tables[0];
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
                rowAffected = this.RunProcedure("sp_T_DANHBA_CONGTY_Delete", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogErrorUtils.WriteLogError("Delete: ", e);
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

                rowAffected = this.RunProcedure("[sp_T_DANHBA_CONGTY_Update]", parameters, rowAffected);
                return (rowAffected > 0);
            }
            catch (Exception e)
            {
                LogErrorUtils.WriteLogError("Update: ", e);
                return false;
            }
        }

        public DataTable GetDanhBaCongTys(string strSQL)
        {
            return RunSQL(strSQL, "tblKhachao");
        }
    }
}
