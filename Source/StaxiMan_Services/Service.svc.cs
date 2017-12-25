using StaxiMan_DAL;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Taxi.Logger;

namespace StaxiMan_Services
{

    [ServiceBehavior(IncludeExceptionDetailInFaults = true), AspNetCompatibilityRequirements(
        RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        private const string KeyEngypt = "binhanh.vn";
        public string GetData(string userName, string password, int value)
        {
            if (!ValidateAuthen(userName, password))
            {
                return "Fail";
            }
            return string.Format("You entered: {0}", value);
        }

        /// <summary>
        /// Gửi thông tin request license key cho server
        /// </summary>
        /// <returns>
        /// return 0 :Request lỗi
        /// return -1:Không đúng tài khoản
        /// return -2:Không lưu được thông tin request
        /// return 1 : Thành Công
        /// </returns>
        public int RequestLicense(string MacAddress, string CPUId, string PhoneNumber, string CompName, string UserName, string Password)
        {
            try
            {
                
                //Validate User truoc khi thuc hien request key
                if (!ValidateAuthen(UserName, Password))
                {
                    return -1;//Không đúng tài khoản
                }

                if (!RequestLicenseKey.Inst.SaveRequest(MacAddress, CPUId, PhoneNumber, CompName, UserName,new BACryptor.Encryption(KeyEngypt).Encrypt(Password) ))
                    return -2;//Không lưu được thông tin request                
                //Request Thanh Cong
                return 1;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("RequestLicenseKey", ex);
                return 0;//Request lỗi
            }
        }

        /// <summary>
        /// hàm đồng bộ định kỳ license giữa hãng và server staxi Man
        /// </summary>
        public LicenseKey SyncLicense(string MacAddress, string CPUId, string PhoneNumber, string CompName, string licenseCode, string licenseKey, string apiCode)
        {
            LicenseKey objLicense = new LicenseKey();
            return objLicense;
        }

        /// <summary>
        /// Chứng thực tài khoản có khớp với server không
        /// </summary>
        private bool ValidateAuthen(string userName, string password)
        {
            string pass = new BACryptor.Encryption("binhanh.vn").Encrypt(password);
            return Company_User.Inst.ValidAuthen(userName, pass);
        }
    }

    [DataContract]
    public class LicenseKey
    {

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string APIKey { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
