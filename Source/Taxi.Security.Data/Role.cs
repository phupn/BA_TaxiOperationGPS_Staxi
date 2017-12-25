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
    public class Role : DBObject
    {
        public Role()
        {
        }

        public DataTable GetRole(string strRoleID)
        {           
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME02_ROLEID",SqlDbType.Char,3)                    
                };
            parameters[0].Value = strRoleID;

            return this.RunProcedure("GET_ME02", parameters, "tblRole").Tables[0];
        }

        public DataTable GetRoles()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME02", parameters, "tblRole").Tables[0];
        }

        public bool Save(string strRoleID,string strVnName,string strEnName)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME02_ROLEID",SqlDbType.Char,3),
                    new SqlParameter("@ME02_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME02_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strRoleID;
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

        public bool Update(string strRoleID, string strVnName, string strEnName)
        {
            try
            {
                int rowAffected = 0;

                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME02_ROLEID",SqlDbType.Char,3),
                    new SqlParameter("@ME02_VNNAME",SqlDbType.VarChar,100),
                    new SqlParameter("@ME02_ENNAME",SqlDbType.VarChar,100)                    
                };
                parameters[0].Value = strRoleID;
                parameters[1].Value = strVnName;
                parameters[2].Value = strEnName;   

                this.RunProcedure("UPDATE_ME02", parameters, rowAffected);
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
                    new SqlParameter("@ME02_ROLEID",SqlDbType.Char,3)                    
                };

                parameters[0].Value = strRoleID;                

                this.RunProcedure("DELETE_ME02", parameters, rowAffected);
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
                this.RunProcedure("CLEAN_ME02", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

