//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Taxi.Utils;


namespace Taxi.Security.Data
{
    public class Function : DBObject
    {
        public Function()
        {
        }

        public DataTable GetFunction(string strFunctionID)
        {           
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME03_FUNCTIONID",SqlDbType.Char,10)                    
                };
            parameters[0].Value = strFunctionID;

            return this.RunProcedure("GET_ME03", parameters, "tblFunction").Tables[0];
        }

        public DataTable GetFunctions()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME03", parameters, "tblFunction").Tables[0];
        }

        public bool Save(string strFunctionID, string strVnName, string strEnName)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME03_FUNCTIONID",SqlDbType.Char,10),
                    new SqlParameter("@ME03_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME03_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strFunctionID;
                parameters[1].Value = strVnName;
                parameters[2].Value = strEnName;                

                this.RunProcedure("INSERT_ME02", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strFunctionID, string strVnName, string strEnName)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME03_FUNCTIONID",SqlDbType.Char,10),
                    new SqlParameter("@ME03_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME03_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strFunctionID;
                parameters[1].Value = strVnName;
                parameters[2].Value = strEnName;   

                this.RunProcedure("UPDATE_ME03", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(string strFunctionID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME03_FUNCTIONID",SqlDbType.Char,10)                    
                };

                parameters[0].Value = strFunctionID;                

                this.RunProcedure("DELETE_ME03", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Clear()
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {};
                this.RunProcedure("CLEAN_ME03", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
