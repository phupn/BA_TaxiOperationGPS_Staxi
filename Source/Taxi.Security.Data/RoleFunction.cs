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
    public class RoleFunction:DBObject 
    {

        public RoleFunction()
        {

        }

        public DataTable GetRoleFunction(string strRoleID)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME05_ROLEID",SqlDbType.Char,3)                    
                };
            parameters[0].Value = strRoleID;

            return this.RunProcedure("GET_ME05", parameters, "tblRoleFunction").Tables[0];
        }

        public DataTable GetRoleFunctions()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME05", parameters, "tblRoleFunction").Tables[0];
        }

        public bool Save(string strRoleID, string strFunctionID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME05_ROLEID",SqlDbType.Char,3),
                    new SqlParameter("@ME05_FUNCTIONID",SqlDbType.Char,10)                    
                };
                parameters[0].Value = strRoleID;
                parameters[1].Value = strFunctionID;                

                this.RunProcedure("INSERT_ME05", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strRoleID, string strFunctionID)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME05_ROLEID",SqlDbType.Char,3),
                    new SqlParameter("@ME05_FUNCTIONID",SqlDbType.Char,10)                    
                };
                parameters[0].Value = strRoleID;
                parameters[1].Value = strFunctionID;                

                this.RunProcedure("UPDATE_ME05", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(string strRoleID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME05_ROLEID",SqlDbType.Char,3)                    
                };

                parameters[0].Value = strRoleID;

                this.RunProcedure("DELETE_ME05", parameters, rowAffected);
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
                SqlParameter[] parameters = new SqlParameter[] { };
                this.RunProcedure("CLEAN_ME05", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}