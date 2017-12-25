using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StaxiMan_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetData(string userName, string password, int value);
        
        /// <summary>
        /// Gửi thông tin request license key cho server
        /// </summary>
        /// <param name="MacAddress"></param>
        /// <param name="CPUId"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="CompName"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns>
        /// return 0 :Request lỗi
        /// return -1:Không đúng tài khoản
        /// return -2:Không lưu được thông tin request
        /// return 1 : Thành Công
        /// </returns>
        [OperationContract]
        int RequestLicense(string MacAddress, string CPUId, string PhoneNumber, string CompName, string UserName, string Password);

        [OperationContract]
        LicenseKey SyncLicense(string MacAddress, string CPUId, string PhoneNumber, string CompName, string licenseCode, string licenseKey, string apiCode);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
