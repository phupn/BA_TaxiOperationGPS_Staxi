
namespace TaxiOperation_TongDai.SMS
{
    /// <summary>
    /// API Gửi tin nhắn của Mobifone - Group
    /// </summary>
    public class OneSMSMobifone
    {
        public string PhoneNumber { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Content { get; set; }
        private const string SUCCESS = "Gửi tin nhắn thành Công";
        private const string INVALID_USER = "Sai tài khoản gửi tin nhắn";
        private const string INVALID_PASSWORD = "Sai mật khẩu gửi tin nhắn";
        private const string INVALID_CONTENT = "Nội dung gửi bị lỗi";
        private const string OTHER_FAIL = "Lỗi gửi tin nhắn";

        public OneSMSMobifone()
        {
            //http://onesms.mobifone.com.vn/SMSAPI/SendSMS?msisdn=0901234568&account=user&password=pass&content=TestAPI
        }

        public string Send()
        {
            return SUCCESS;
        }
    }

    /// <summary>
    /// Tham số đầu ra của OneSMS
    /// </summary>
    public enum Enum_OneSMS_Result
    {
        /// <summary>
        /// 1. Gửi tin thành công
        /// </summary>
        SUCCESS = 1,
        /// <summary>
        /// 10. Sai tài khoản
        /// </summary>
        INVALID_USER = 10,
        /// <summary>
        /// 11. Sai mật khẩu
        /// </summary>
        INVALID_PASSWORD = 11,
        /// <summary>
        /// 13. Nội dung gửi bị lỗi
        /// </summary>
        INVALID_CONTENT = 13,
        /// <summary>
        /// 0.Lỗi khác
        /// </summary>
        OTHER_FAIL = 0
    }
}
