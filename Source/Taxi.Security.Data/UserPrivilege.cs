

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Taxi.Utils;

namespace Taxi.Security.Data
{
    public class UserPrivilege:DBObject 
    {
        public UserPrivilege()
        {

        }

        public DataTable GetUserPrivilege(string strUserName)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME06_USERNAME",SqlDbType.VarChar,20)                    
                };
            parameters[0].Value = strUserName;

            return this.RunProcedure("GET_ME06", parameters, "tblUserPrivilege").Tables[0];
        }

        public DataTable GetUserPrivileges()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME06", parameters, "tblUserPrivilege").Tables[0];
        }

        public bool Save(string strUserName, string strPrivilegeID)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME06_USERNAME",SqlDbType.VarChar,20),
                    new SqlParameter("@ME06_PRIVILEGEID",SqlDbType.Char,3)                    
                };
                parameters[0].Value = strUserName;
                parameters[1].Value = strPrivilegeID;                

                this.RunProcedure("INSERT_ME06", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strUserName, string strPrivilegeID)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME06_USERNAME",SqlDbType.VarChar,20),
                    new SqlParameter("@ME06_PRIVILEGEID",SqlDbType.Char,3)                    
                };
                parameters[0].Value = strUserName;
                parameters[1].Value = strPrivilegeID;                

                this.RunProcedure("UPDATE_ME06", parameters, rowAffected);
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
                    new SqlParameter("@ME06_USERNAME",SqlDbType.VarChar ,20)                    
                };

                parameters[0].Value = strUserName;

                this.RunProcedure("DELETE_ME06", parameters, rowAffected);
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
                this.RunProcedure("CLEAN_ME06", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}