using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Services
{
    public class WCF_SMSVina
    {
        #region ---------------- SMS Vina -----------------------
        private static readonly ConnectService<SMS_Viettel.TcpOPClient> serviceSMSVina = new ConnectService<SMS_Viettel.TcpOPClient>();

        public static ConnectService<SMS_Viettel.TcpOPClient> ServiceSMSVina
        {
            get
            {
                return serviceSMSVina;
            }
        }

        private static string ConvertPhoneNumber(string phonenumber)
        {
            if (phonenumber.StartsWith("0"))
            {
                return string.Format("84{0}", phonenumber.Substring(1));
            }
            return phonenumber;
        }

        /// <summary>
        /// Gửi sms thông tin xe nhận
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="carType"></param>
        /// <param name="privateCode"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_ReceiveCarInfo(string receiveNumber, string carType, string privateCode, float custLat, float custLng, Guid bookID)
        {
            string driverPhone = "";
            if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
            {
                driverPhone = CommonBL.DictDriver[privateCode].DiDong;
            }
            string vehiclePlate = CommonBL.ConvertSangBienSo(privateCode).Trim();
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_ReceiveCarInfo(ConvertPhoneNumber(receiveNumber), carType, privateCode, vehiclePlate, custLat, custLng, bookID)).Value;
        }
        /// <summary>
        /// Gửi sms thông báo xe đón và có view car
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="driverName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="privateCode"></param>
        /// <param name="vehiclePlate"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_ViewCar(string receiveNumber, string privateCode, float custLat, float custLng, System.Guid bookID, float estimateTime)
        {
            string driverName = "";
            string driverPhone = "";

            string vehiclePlate = CommonBL.ConvertSangBienSo(privateCode).Trim();
            if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
            {
                driverName = UnicodeStrings.UnicodeFormat_V2(CommonBL.DictDriver[privateCode].TenNhanVien);
                driverPhone = CommonBL.DictDriver[privateCode].DiDong;
            }
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_ViewCar(ConvertPhoneNumber(receiveNumber), driverName, driverPhone, privateCode, vehiclePlate, custLat, custLng, bookID, estimateTime)).Value;
        }
        /// <summary>
        /// Gửi sms 
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="privateCode"></param>
        /// <returns></returns>
        public static bool Vina_SendSMS_CatchedUser(string receiveNumber, string privateCode)
        {
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_CatchedUser(ConvertPhoneNumber(receiveNumber), privateCode)).Value;
        }
        /// <summary>
        /// Gửi sms không xe xin lỗi khách
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_NoCar(string receiveNumber)
        {
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_NoCar(ConvertPhoneNumber(receiveNumber))).Value;
        }
        /// <summary>
        /// Gửi SMS Cám ơn khi nhập xe đón
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="privateCode"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_ThankCustomer(string receiveNumber, string privateCode)
        {
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_ThankCustomer(ConvertPhoneNumber(receiveNumber), privateCode)).Value;
        }
        /// <summary>
        /// Gửi SMS với nội dung bất kỳ
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_Other(string receiveNumber, string content)
        {
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_Other(ConvertPhoneNumber(receiveNumber), content)).Value;
        }

        /// <summary>
        /// Tin nhắn chúc mừng sinh nhật
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <returns></returns>
        public static bool Vina_SendSms_VinaTaxi_HappyBirthDay(string receiveNumber)
        {
            return ServiceSMSVina.TryGet(t => t.SendSms_VinaTaxi_HappyBirthDay(ConvertPhoneNumber(receiveNumber))).Value;
        }
        /// <summary>
        /// SMS cho Dương Thảo
        /// </summary>
        /// <param name="receiveNumber"></param>
        /// <param name="customerName"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        //public static bool Vina_SendSms_DuongThao_CustomerPhone(string receiveNumber, string customerName, string info)
        //{
        //    return ServiceSMSVina.TryGet(t => t.SendSms_DuongThao_CustomerPhone(ConvertPhoneNumber(receiveNumber), customerName, info)).Value;
        //}

        #endregion
    }
}
