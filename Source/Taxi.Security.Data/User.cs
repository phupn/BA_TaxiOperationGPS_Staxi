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
    public class User:DBObject
    {
        public User()
        {
        }        

        public DataTable GetUser(string strUserName)
        {           
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME01_USERNAME",SqlDbType.NVarChar,20)                    
                };
            parameters[0].Value = strUserName;

            return this.RunProcedure("GET_ME01", parameters, "tblUser").Tables[0];
        }

        public DataTable GetUsers()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return this.RunProcedure("LIST_ME01", parameters, "tblUser").Tables[0];
        }

        public bool Save(string strUserName,string strFullName,string strPosition,string strPassword)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME01_USERNAME",SqlDbType.NVarChar,20),
                    new SqlParameter("@ME01_FULLNAME",SqlDbType.NVarChar,100),
                    new SqlParameter("@ME01_POSITION",SqlDbType.NVarChar,100),
                    new SqlParameter("@ME01_PASSWORD",SqlDbType.NVarChar,256)
                };
                parameters[0].Value = strUserName;
                parameters[1].Value = strFullName;
                parameters[2].Value = strPosition;
                parameters[3].Value = strPassword;

                this.RunProcedure("INSERT_ME01", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(string strUserName, string strFullName, string strPosition, string strPassword)
        {
            try
            {
                int rowAffected = 0;
                SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ME01_USERNAME",SqlDbType.NVarChar,20),
                    new SqlParameter("@ME01_FULLNAME",SqlDbType.NVarChar,100),
                    new SqlParameter("@ME01_POSITION",SqlDbType.NVarChar,100),
                    new SqlParameter("@ME01_PASSWORD",SqlDbType.NVarChar,256)
                };
                
                parameters[0].Value = strUserName;
                parameters[1].Value = strFullName;
                parameters[2].Value = strPosition;
                parameters[3].Value = strPassword;

                this.RunProcedure("UPDATE_ME01", parameters, rowAffected);
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
                    new SqlParameter("@ME01_USERNAME",SqlDbType.NVarChar,20)                    
                };

                parameters[0].Value = strUserName;                

                this.RunProcedure("DELETE_ME01", parameters, rowAffected);
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
                this.RunProcedure("CLEAN_ME01", parameters, rowAffected);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
