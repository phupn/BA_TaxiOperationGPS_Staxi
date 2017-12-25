//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class Privilege
    {
        private string strPrivilegeID;
        private string strVnName;
        private string strEnName;

        public string PrivilegeID
        {
            set { strPrivilegeID = value.Trim(); }
            get { return strPrivilegeID; }
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
       

        public Privilege()
        {
            PrivilegeID = string.Empty;
            VnName = string.Empty;
            EnName = string.Empty;
        }

        public Privilege(string strPrivilegeID)
        {
            DataTable dt = new Data.Privilege().GetPrivilege(strPrivilegeID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    PrivilegeID = string.Empty + dt.Rows[0]["ME04_PRIVILEGEID"].ToString();
                    VnName = string.Empty + dt.Rows[0]["ME04_VNNAME"].ToString();
                    EnName = string.Empty + dt.Rows[0]["ME04_ENNAME"].ToString();
                }
            }
        }
        public Privilege[] GetPrivilege()
        {
            List<Privilege> lstPrivilege = new List<Privilege>(0);
            DataTable dt = new Data.Privilege().GetPrivileges();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Privilege oPrivilege = new Privilege();
                    oPrivilege.PrivilegeID = string.Empty + dr["ME04_PRIVILEGEID"].ToString();
                    oPrivilege.VnName = string.Empty + dr["ME04_VNNAME"].ToString();
                    oPrivilege.EnName = string.Empty + dr["ME04_ENNAME"].ToString();

                    lstPrivilege.Add(oPrivilege);
                }
            }
            return lstPrivilege.ToArray();
        }

        public bool Save()
        {
            return new Data.Privilege().Save(PrivilegeID, VnName, EnName);
        }

        public bool Update()
        {
            return new Data.Privilege().Update(PrivilegeID, VnName, EnName);
        }

        public bool Delete()
        {
            return new Data.Privilege().Delete(PrivilegeID);
        }

        public bool Clear()
        {
            return new Data.Privilege().Clear();
        }
    }
}
