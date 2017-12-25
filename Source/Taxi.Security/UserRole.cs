//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class UserRole
    {
        private string strUserName;
        private string strRoleID;

        public string UserName
        {
            set { strUserName = value.Trim(); }
            get {return strUserName; }
        }
        public string RoleID
        {
            set { strRoleID = value.Trim(); }
            get { return strRoleID; }
        }

        public UserRole()
        {
            UserName = string.Empty;
            RoleID = string.Empty;
        }

        public UserRole(string strUserName, string strRoleID)
        {
            UserName = strUserName;
            RoleID = strRoleID;
        }

        public UserRole[] GetUserRoles(string strUserName)
        {
            DataTable dt = new Data.UserRole().GetUserRole(strUserName);
            List<UserRole> lstUserRole = new List<UserRole>(0);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserRole oUserRole = new UserRole();
                    oUserRole.UserName = string.Empty + dr["ME07_USERNAME"].ToString();
                    oUserRole.RoleID = string.Empty + dr["ME07_ROLEID"].ToString();
                    if (!lstUserRole.Contains(oUserRole))                            
                        lstUserRole.Add(oUserRole);
                }
            }
            return lstUserRole.ToArray();
        }

        public UserRole[] GetUserRoles()
        {
            List<UserRole> lstUserRole = new List<UserRole>(0);
            DataTable dt = new Data.UserRole().GetUserRoles();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserRole oUserRole = new UserRole();
                    oUserRole.UserName = string.Empty + dr["ME07_USERNAME"].ToString();
                    oUserRole.RoleID = string.Empty + dr["ME07_ROLEID"].ToString();
                    if (!lstUserRole.Contains(oUserRole))                            
                        lstUserRole.Add(oUserRole);
                }
            }
            return lstUserRole.ToArray();
        }

        public bool Save()
        {
            return new Data.UserRole().Save(UserName, RoleID );
        }

        public bool Update()
        {
            return new Data.UserRole().Update(UserName, RoleID);
        }

        public bool Delete()
        {
            return new Data.UserRole().Delete(UserName);
        }

        public bool Clear()
        {
            return new Data.UserRole().Clear();
        }
    }
}
