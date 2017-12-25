using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Logger;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "RequestLicenseKey_Responsed")]
    public class RequestLicenseResponsed:DBServices<RequestLicenseResponsed>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string MacAddress { get; set; }
        [Field]
        public string CPUID { get; set; }
        [Field]
        public string PhoneNumber { get;set; }
        [Field]
        public string CompName { get; set; }
        [Field]
        public string UserName { get; set; }
        [Field]
        public string PassWord { get; set; }
        [Field]
        public DateTime RequestDate { get; set; }
        [Field]
        public bool Responsed { get; set; }
        [Field]
        public DateTime ResponsedDate { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }

        public List<RequestLicenseResponsed> SearchLicenseResponsed(params object[] pInput)
        {
            try
            {
                return this.ExeStore("sp_SearchLicenseResponsed", pInput).ToList<RequestLicenseResponsed>();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SearchLicenseResponsed: ", ex);
                return new List<RequestLicenseResponsed>();
            }
        }

        /// <summary>
        /// Get responsed by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RequestLicenseKey GetResponsedByID(int id)
        {
            return ExeStore("SP_RequestLicenseKey_Responsed_GetByID", id).ToList<RequestLicenseKey>()[0];
        }
    }
}
