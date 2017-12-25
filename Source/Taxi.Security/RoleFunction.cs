//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

namespace Taxi.Security.Business
{
    public class RoleFunction
    {

        private string strRoleID;
        private string strFunctionID;
        
        public string RoleID
        {
            set { strRoleID = value.Trim(); }
            get { return strRoleID; }
        }

        public string FunctionID
        {
            set { strFunctionID = value.Trim(); }
            get {return strFunctionID; }
        }

        public RoleFunction()
        {
            FunctionID = string.Empty;
            RoleID = string.Empty;
            List<RoleFunction> lstRoleFunction = new List<RoleFunction>(0);
        }
        public  RoleFunction[] GetRoleFunctions(string strRoleID)
        {
            List<RoleFunction> lstRoleFunction = new List<RoleFunction>(0);
            DataTable dt = new Data.RoleFunction().GetRoleFunction(strRoleID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    RoleFunction oRoleFunction = new RoleFunction();
                    oRoleFunction.RoleID = string.Empty + dr["ME05_ROLEID"].ToString();
                    oRoleFunction.FunctionID = string.Empty + dr["ME05_FUNCTIONID"].ToString();
                    if (!lstRoleFunction.Contains(oRoleFunction))                            
                        lstRoleFunction.Add(oRoleFunction);
                }
            }
            return lstRoleFunction.ToArray();
        }
        public RoleFunction[] GetRoleFunctions()
        {
            List<RoleFunction> lstRoleFunction = new List<RoleFunction>(0);
            DataTable dt = new Data.RoleFunction().GetRoleFunctions();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    RoleFunction oRoleFunction = new RoleFunction();
                    oRoleFunction.RoleID = string.Empty + dr["ME05_ROLEID"].ToString();
                    oRoleFunction.FunctionID = string.Empty + dr["ME05_FUNCTIONID"].ToString();
                    if (!lstRoleFunction.Contains(oRoleFunction))                            
                        lstRoleFunction.Add(oRoleFunction);
                }
            }
            return lstRoleFunction.ToArray();
        }

        public bool Save()
        {
            return new Data.RoleFunction().Save(RoleID, FunctionID);
        }

        public bool Update()
        {
            return new Data.RoleFunction().Update(RoleID,FunctionID);
        }

        public bool Delete()
        {
            return new Data.RoleFunction().Delete(RoleID);
        }

        public bool Clear()
        {
            return new Data.RoleFunction().Clear();
        }
    }
}
