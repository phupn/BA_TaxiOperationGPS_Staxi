
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class User
    {
        #region Private Members

        private string strUserName;
        private string strFullName;
        private string strPosition;
        private string strPassword;
        private List<Privilege> lstPrivilege;
        private List<Role> lstRole;
        private static User _UnknownUser = new User("Unknown");

        #endregion

        #region Properties

        /// <summary>
        /// Gets UnknownUser constant. This constant is used instead of null to reference unknown user.
        /// </summary>
        /// 

        public static User UnknownUser
        {
            get
            {
                return _UnknownUser;
            }
        }

        public string UserName
        {
            set { strUserName = value.Trim(); }
            get { return strUserName; }
        }

        public string FullName
        {
            set { strFullName = value.Trim(); }
            get { return strFullName; }
        }

        public string Position
        {
            set { strPosition = value.Trim(); }
            get { return strPosition; }
        }

        public string Password
        {
            set { strPassword = value.Trim(); }
            get { return strPassword; }
        }

        public List<Privilege> Privileges
        {
            set { lstPrivilege = value; }
            get { return lstPrivilege; }
        }

        public List<Role> Roles
        {
            set { lstRole = value; }
            get { return lstRole; }
        }

        #endregion

        #region Construction
        public User()
        {
            UserName = string.Empty;
            FullName = string.Empty;
            Position = string.Empty;
            Password = string.Empty;
            lstPrivilege = new List<Privilege>(0);
            lstRole = new List<Role>(0);
        }

        public User(string strUserName)
        {
            lstPrivilege = new List<Privilege>(0);
            lstRole = new List<Role>(0);
            this.GetUser(strUserName);
        }

        public User(string strUserName, string strPassword)
        {
            try
            {
                Authenticate(strUserName, strPassword);
                lstPrivilege = new List<Privilege>(0);
                lstRole = new List<Role>(0);
                this.GetUser(strUserName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Methods
        private void GetUser(string strUserName)
        {
            DataTable dt = new Data.User().GetUser(strUserName);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    UserName = string.Empty + dt.Rows[0]["ME01_USERNAME"].ToString();
                    FullName = string.Empty + dt.Rows[0]["ME01_FULLNAME"].ToString();
                    Position = string.Empty + dt.Rows[0]["ME01_POSITION"].ToString();
                    Password = string.Empty + dt.Rows[0]["ME01_PASSWORD"].ToString();
                    lstPrivilege.Clear();
                    foreach (UserPrivilege oUserPrivilege in new UserPrivilege().GetUserPrivileges(strUserName))
                    {
                        Privilege oPrivilege = new Privilege(oUserPrivilege.PrivilegeID);
                        if (!lstPrivilege.Contains(oPrivilege))
                            lstPrivilege.Add(oPrivilege);
                    }

                    lstRole.Clear();
                    foreach (UserRole oUserRole in new UserRole().GetUserRoles(strUserName))
                    {
                        Role oRole = new Role(oUserRole.RoleID);
                        if (!lstRole.Contains(oRole))
                            lstRole.Add(oRole);
                    }
                }
            }
        }

        public User[] GetUsers()
        {
            List<User> lstUser = new List<User>(0);
            DataTable dt = new Data.User().GetUsers();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    User oUser = new User();
                    oUser.UserName = string.Empty + dr["ME01_USERNAME"].ToString();
                    oUser.FullName = string.Empty + dr["ME01_FULLNAME"].ToString();
                    oUser.Position = string.Empty + dr["ME01_POSITION"].ToString();
                    oUser.Password = string.Empty + dr["ME01_PASSWORD"].ToString();

                    lstUser.Add(oUser);
                }
            }
            return lstUser.ToArray();
        }

        public User Authenticate(string strUserName, string strPassword)
        {
            foreach (User oUser in GetUsers())
            {
                if ((oUser.UserName.Equals(strUserName)) && (oUser.Password.Equals(strPassword)))
                    return oUser;
            }
            throw new Exception(string.Format("Couldn't load user {0} because credentials were invalid.", strUserName));
        }
        public bool HasRole(string RoleID)
        {
            foreach (Role r in Roles)
            {
                if (r.RoleID.Trim().ToLower().Equals(RoleID.Trim().ToLower()))
                {
                    return true;
                }
            }

            return false;
        }
        public bool CheckFunction(string strFunctionID)
        {
            List<Function> lstFunction = new List<Function>(0);
            foreach (Role oRole in lstRole)
            {
                foreach (Function oFunction in oRole.Functions)
                {
                    if (!lstFunction.Contains(oFunction))
                        lstFunction.Add(oFunction);
                }
            }

            foreach (Function oFunction in lstFunction)
            {
                if (oFunction.FunctionID.Equals(strFunctionID))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasPrivilege(string PrivilegeID)
        {
            foreach (Privilege r in Privileges)
            {
                if (r.PrivilegeID.Trim().ToLower().Equals(PrivilegeID.Trim().ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasPrivilege(Privilege privilege)
        {
            return HasPrivilege(privilege.PrivilegeID);
        }

        public bool Save()
        {
            foreach (Role rl in lstRole)
            {
                UserRole oUserRole = new UserRole(UserName, rl.RoleID);
                oUserRole.Save();
            }
            foreach (Privilege pr in lstPrivilege)
            {
                UserPrivilege oUserPrivilege = new UserPrivilege(UserName, pr.PrivilegeID);
                oUserPrivilege.Save();
            }
            return new Data.User().Save(UserName, FullName, Position, Password);
        }

        public bool Update()
        {
            foreach (UserRole rl in new UserRole().GetUserRoles(UserName))
                rl.Delete();

            foreach (UserPrivilege upr in new UserPrivilege().GetUserPrivileges(UserName))
                upr.Delete();

            //
            foreach (Role rl in lstRole)
            {
                UserRole oUserRole = new UserRole(UserName, rl.RoleID);
                oUserRole.Save();
            }
            foreach (Privilege pr in lstPrivilege)
            {
                UserPrivilege oUserPrivilege = new UserPrivilege(UserName, pr.PrivilegeID);
                oUserPrivilege.Save();
            }
            return new Data.User().Update(UserName, FullName, Position, Password);
        }

        public bool Delete()
        {
            foreach (UserRole rl in new UserRole().GetUserRoles(UserName))
                rl.Delete();

            foreach (UserPrivilege upr in new UserPrivilege().GetUserPrivileges(UserName))
                upr.Delete();

            return new Data.User().Delete(UserName);
        }

        public bool Clear()
        {
            return new Data.User().Clear();
        }

        #endregion


    }
}
