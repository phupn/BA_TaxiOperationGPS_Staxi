using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "RequestLicenseKey")]
    public class RequestLicenseKey : DBServices<RequestLicenseKey>
    {
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string MacAddress { get; set; }
        [Field]
        public string CPUID { get; set; }
        [Field]
        public string PhoneNumber { get; set; }
        [Field]
        public string CompName { get; set; }
        [Field]
        public string UserName { get; set; }
        [Field]
        public string Password { get; set; }
        [Field]
        public DateTime RequestDate { get; set; }
        [Field]
        public bool? Responsed { get; set; }
        [Field]
        public DateTime? ResponsedDate { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }

        public List<RequestLicenseKey> GetAllData()
        {
            return this.GetAll().ToList<RequestLicenseKey>();
        }

        public bool SaveRequest(string macAddress, string cPUId, string phoneNumber, string compName, string userName, string password)
        {
            try
            {
                MacAddress = macAddress;
                CPUID = cPUId;
                PhoneNumber = phoneNumber;
                CompName = compName;
                UserName = userName;
                Password = password;
                
                RequestDate = DateTime.Now;
                this.Insert();
                return true;
            }
            catch (Exception ex)
            {
                Taxi.Logger.LogError.WriteLogError("RequestLicenseKey.SaveRequest", ex);
            }
            return false;
        }
    }
}