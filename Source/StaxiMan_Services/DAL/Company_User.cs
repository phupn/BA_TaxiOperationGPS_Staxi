using StaxiMan_Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi.Common.DbBase.Attributes;

namespace StaxiMan_Services.DAL
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
    }
}