//Create by Luong Van Tuyen,PL
//Create date 22/12/2007

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taxi.Security.Data;

 
namespace Taxi.Security.Business
{
    public class Function
    {
        private string strFunctionID;
        private string strVnName;
        private string strEnName;

        public string FunctionID
        {
            set { strFunctionID = value.Trim(); }
            get { return strFunctionID; }
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
       

        public Function()
        {
            FunctionID = string.Empty;
            VnName = string.Empty;
            EnName = string.Empty;
        }

        public Function(string strFunctionID)
        {
            DataTable dt = new Data.Function().GetFunction(strFunctionID);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    FunctionID = string.Empty + dt.Rows[0]["ME03_FUNCTIONID"].ToString();
                    VnName = string.Empty + dt.Rows[0]["ME03_VNNAME"].ToString();
                    EnName = string.Empty + dt.Rows[0]["ME03_ENNAME"].ToString();
                }
            }
        }
        public Function[] GetFunctions()
        {
            List<Function> lstFunction = new List<Function>(0);
            DataTable dt = new Data.Function().GetFunctions();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Function oFunction = new Function();
                    oFunction.FunctionID = string.Empty + dr["ME03_FUNCTIONID"].ToString();
                    oFunction.VnName = string.Empty + dr["ME03_VNNAME"].ToString();
                    oFunction.EnName = string.Empty + dr["ME03_ENNAME"].ToString();

                    lstFunction.Add(oFunction);
                }
            }
            return lstFunction.ToArray();
        }

        public bool Save()
        {
            return new Data.Function().Save(FunctionID,VnName,EnName);
        }

        public bool Update()
        {
            return new Data.Function().Update(FunctionID, VnName, EnName);
        }

        public bool Delete()
        {
            return new Data.Function().Delete(FunctionID);
        }

        public bool Clear()
        {
            return new Data.Function().Clear();
        }
    }
}
