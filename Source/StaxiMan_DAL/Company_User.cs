using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "Company_User")]
    public class Company_User : DBServices<Company_User>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }
        [Field]
        public string UserName { get; set; }
        [Field]
        public string Password { get; set; }
        [Field]
        public bool IsActive { get; set; }
        public string CompanyName
        {
            get
            {
                if (DALCommon.ListCompany != null && DALCommon.ListCompany.Count > 0)
                {
                    var temp = DALCommon.ListCompany.FirstOrDefault(a => a.Id == FK_CompanyID);
                    if (temp == null) return string.Empty;
                    else return temp.Name;
                }
                else return string.Empty;
            }
        }
        public bool ValidAuthen(string userName, string password)
        {
            try
            {
                return this.ExeStore("SP_Company_User_VALIDATE", userName, password).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Taxi.Logger.LogError.WriteLogError("Company_User.ValidAuthen", ex);
            }
            return false;
        }

        public bool ValidAuthen_Server(string userName, string password)
        {
            try
            {
                return this.ExeStore("SP_Company_User_VALIDATE_Server", userName, password).Rows.Count > 0;
            }
            catch (Exception ex)
            {
                Taxi.Logger.LogError.WriteLogError("Company_User.ValidAuthen", ex);
            }
            return false;
        }

        public List<Company_User>  GetListAllUser()
        {
            return this.GetAll().ToList<Company_User>();
        }
    }
}