//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class UserPrivilege
    {
        private string strUserName;
        private string strPrivilegeID;
        
        public string UserName
        {
            set { strUserName = value.Trim(); }
            get {return strUserName; }
        }
        public string PrivilegeID
        {
            set { strPrivilegeID = value.Trim(); }
            get { return strPrivilegeID; }
        }
        

        public UserPrivilege()
        {
            UserName = string.Empty;
            PrivilegeID = string.Empty;
            List<UserPrivilege> lstUserPrivilege = new List<UserPrivilege>(0);
        }
        public UserPrivilege(string strUserName, string strPrivilegeID)
        {
            UserName = strUserName;
            PrivilegeID = strPrivilegeID;
            List<UserPrivilege> lstUserPrivilege = new List<UserPrivilege>(0);
        }

        public UserPrivilege[] GetUserPrivileges(string strUserName)
        {
            DataTable dt = new Data.UserPrivilege().GetUserPrivilege(strUserName);
            List<UserPrivilege> lstUserPrivilege = new List<UserPrivilege>(0);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserPrivilege oUserPrivilege = new UserPrivilege();
                    oUserPrivilege.UserName = string.Empty + dr["ME06_USERNAME"].ToString();
                    oUserPrivilege.PrivilegeID = string.Empty + dr["ME06_PRIVILEGEID"].ToString();
                    
                    if (!lstUserPrivilege.Contains(oUserPrivilege))                            
                        lstUserPrivilege.Add(oUserPrivilege);
                }
            }
            return lstUserPrivilege.ToArray();
        }
        public UserPrivilege[] GetUserRoles()
        {
            List<UserPrivilege> lstUserPrivilege = new List<UserPrivilege>(0);
            DataTable dt = new Data.UserPrivilege().GetUserPrivileges();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserPrivilege oUserPrivilege = new UserPrivilege();
                    oUserPrivilege.UserName = string.Empty + dr["ME06_USERNAME"].ToString();
                    oUserPrivilege.PrivilegeID = string.Empty + dr["ME06_PRIVILEGEID"].ToString();
                    
                    if (!lstUserPrivilege.Contains(oUserPrivilege))                            
                        lstUserPrivilege.Add(oUserPrivilege);
                }
            }
            return lstUserPrivilege.ToArray();
        }

        public bool Save()
        {
            return new Data.UserPrivilege().Save(UserName, PrivilegeID);
        }

        public bool Update()
        {
            return new Data.UserPrivilege().Update(UserName, PrivilegeID);
        }

        public bool Delete()
        {
            return new Data.UserPrivilege().Delete(UserName);
        }

        public bool Clear()
        {
            return new Data.UserPrivilege().Clear();
        }
    }
}
