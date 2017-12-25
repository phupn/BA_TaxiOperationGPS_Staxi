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
    public class Privilege : DBObject
    {
        public Privilege()
        {
        }

        public DataTable GetPrivilege(string strRoleID)
        {           
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME04_PRIVILEGEID",SqlDbType.Char,3)                    
                };
            parameters[0].Value = strRoleID;

            return this.RunProcedure("GET_ME04", parameters, "tblPrivilege").Tables[0];
        }

        public DataTable GetPrivileges()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME04", parameters, "tblPrivilege").Tables[0];
        }

        public bool Save(string strRoleID,string strVnName,string strEnName)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME04_PRIVILEGEID",SqlDbType.Char,3),
                    new SqlParameter("@ME04_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME04_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strRoleID;
                parameters[1].Value = strVnName;
                parameters[2].Value = strEnName;                

                this.RunProcedure("INSERT_ME04", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strRoleID, string strVnName, string strEnName)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME04_PRIVILEGEID",SqlDbType.Char,3),
                    new SqlParameter("@ME04_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME04_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strRoleID;
                parameters[1].Value = strVnName;
                parameters[2].Value = strEnName;   

                this.RunProcedure("UPDATE_ME04", parameters, rowAffected);
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
                    new SqlParameter("@ME04_PRIVILEGEID",SqlDbType.Char,3)                    
                };

                parameters[0].Value = strUserName;                

                this.RunProcedure("DELETE_ME04", parameters, rowAffected);
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
                this.RunProcedure("CLEAN_ME04", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
