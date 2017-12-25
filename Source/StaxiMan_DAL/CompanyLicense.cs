using System;
using Taxi.Logger;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Collections.Generic;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "Company_License")]
    public class CompanyLicense : DBServices<CompanyLicense>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }
        [Field]
        public DateTime CreateDate { get; set; }
        [Field]
        public DateTime ExpDate { get; set; }
        [Field]
        public string LicenseCode { get; set; }
        [Field]
        public string LicenseKey { get; set; }
        /// <summary>
        /// License API code Taxi3
        /// </summary>
        [Field]
        public string LicenseTaxiAPI_Code { get; set; }
        /// <summary>
        /// License API Key : là chuỗi đã mã hóa
        /// </summary>
        [Field]
        public string LicenseTaxiAPI { get; set; }
        [Field]
        public bool IsActive { get; set; }
        [Field]
        public string Notes { get; set; }
        #endregion

        public List<CompanyLicense> GetList()
        {
            return GetAll().ToList<CompanyLicense>();
        }
        public string BuildLicenseKey(RequestLicenseKey itemRequest, DateTime expDate, out string licenseCode)
        {
            try
            {
                licenseCode = BuildLicenseUtil.BuildEncrypt(string.Format("{0}{1}", itemRequest.CompName, itemRequest.PhoneNumber));
                string strLicenseKey = BuildLicenseUtil.BuildEncrypt(string.Format("{0}&{1}", itemRequest.MacAddress, itemRequest.CPUID));
                return BuildLicenseUtil.BuildEncrypt(string.Format("{0:yyyyMMdd}@{1}@{2}", expDate, licenseCode, strLicenseKey));
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Build", ex);
            }
            licenseCode = "";
            return "";
        }

        public bool InsertData(long requestLicenseID)
        {
            return ExeStoreNoneQuery("SP_Company_License_Insert",FK_CompanyID,CreateDate,ExpDate,LicenseCode,LicenseKey,LicenseTaxiAPI_Code,LicenseTaxiAPI, IsActive,Notes,requestLicenseID ) > 0;
        }

        /// <summary>
        /// Get license dang active của hang
        /// </summary>
        /// <param name="fkCompanyID"></param>
        /// <returns></returns>
        public CompanyLicense GetDataById(int fkCompanyID)
        {
            return ExeStore("SP_Company_License_GetByCompanyID", fkCompanyID).ToItem<CompanyLicense>();
        }

        public int GetRequestIDByCompanyLicenseId(int Id)
        {
            int requestId = 0;
            var result = ExeStoreNoneQueryWithOutput("SP_Company_License_GetRequestID", Id, requestId);
            if (result != null && result.Value["RequestId"] != DBNull.Value && result.Value["RequestId"] != "")
            {
                requestId = (int)result.Value["RequestId"];
            }
            return requestId;
        }

        /// <summary>
        /// Active hoac deactive license
        /// </summary>
        /// <param name="isActive"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ActiveLicense(bool isActive, int id)
        {
            return ExeStoreNoneQuery("SP_Company_License_Active", isActive, id) > 0;
        }
    }
}
