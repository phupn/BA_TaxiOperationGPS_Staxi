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
    public class UserRole:DBObject 
    {
        public UserRole()
        {

        }

        public DataTable GetUserRole(string strUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME07_USERNAME",SqlDbType.VarChar,20)                    
                };
            parameters[0].Value = strUserName;

            return this.RunProcedure("GET_ME07", parameters, "tblUserRole").Tables[0];
        }

        public DataTable GetUserRoles()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME07", parameters, "tblUserRole").Tables[0];
        }

        public bool Save(string strUserName, string strRoleID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME07_USERNAME",SqlDbType.VarChar,20),
                    new SqlParameter("@ME07_ROLEID",SqlDbType.Char,3)                    
                };
                parameters[0].Value = strUserName;
                parameters[1].Value = strRoleID;                

                this.RunProcedure("INSERT_ME07", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strUserName, string strRoleID)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME07_USERNAME",SqlDbType.VarChar,20),
                    new SqlParameter("@ME07_ROLEID",SqlDbType.Char,3)                    
                };
                parameters[0].Value = strUserName;
                parameters[1].Value = strRoleID;                

                this.RunProcedure("UPDATE_ME07", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(string strUserName)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME07_USERNAME",SqlDbType.VarChar ,20)                    
                };

                parameters[0].Value = strUserName;

                this.RunProcedure("DELETE_ME07", parameters, rowAffected);
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
                this.RunProcedure("CLEAN_ME07", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}