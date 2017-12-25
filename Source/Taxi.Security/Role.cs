//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data; 
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class Role
    {
        private string strRoleID;
        private string strVnName;
        private string strEnName;
        private List<Function> lstFunction;

        public string RoleID
        {
            set { strRoleID = value.Trim(); }
            get { return strRoleID; }
        }

        public string VnName
        {
            set { strVnName = value.Trim(); }
            get { return strVnName; }
        }

        public string EnName
        {
            set { strEnName = value.Trim(); }
            get { return strEnName; }
        }
        public List<Function> Functions
        {
            set { lstFunction = value; }
            get { return lstFunction; }
        }

        public Role()
        {
            RoleID = string.Empty;
            VnName = string.Empty;
            EnName = string.Empty;
            lstFunction = new List<Function>(0);  
        }

        public Role(string strRoleID)
        {
            lstFunction = new List<Function>(0);  

            DataTable dt = new Data.Role().GetRole(strRoleID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    RoleID = string.Empty + dt.Rows[0]["ME02_ROLEID"].ToString();
                    VnName = string.Empty + dt.Rows[0]["ME02_VNNAME"].ToString();
                    EnName = string.Empty + dt.Rows[0]["ME02_ENNAME"].ToString();
                    lstFunction.Clear(); 
                    foreach (RoleFunction oRoleFunction in new RoleFunction().GetRoleFunctions(strRoleID))
                    {
                        Function oFunction = new Function(oRoleFunction.FunctionID);
                        if (!lstFunction.Contains(oFunction))                            
                            lstFunction.Add(oFunction); 
                    }                    
                }
            }
        }

        public Role[] GetRoles()
        {
            List<Role> lstRole = new List<Role>(0);
            DataTable dt = new Data.Role().GetRoles();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Role oRole = new Role();
                    oRole.RoleID = string.Empty + dr["ME02_ROLEID"].ToString();
                    oRole.VnName = string.Empty + dr["ME02_VNNAME"].ToString();
                    oRole.EnName = string.Empty + dr["ME02_ENNAME"].ToString();
                    if (!lstRole.Contains(oRole))                            
                        lstRole.Add(oRole);
                }
            }
            return lstRole.ToArray();
        }

        public bool Save()
        {
            return new Data.Role().Save(RoleID, VnName, EnName);
        }

        public bool Update()
        {
            return new Data.Role().Update(RoleID, VnName, EnName);
        }

        public bool Delete()
        {
            return new Data.Role().Delete(RoleID);
        }

        public bool Clear()
        {
            return new Data.Role().Clear();
        }
    }
}
