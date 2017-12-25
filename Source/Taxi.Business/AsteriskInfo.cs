
using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;

namespace Taxi.Business
{

    /// <summary>
    /// Cấu hình bắt số tổng đài Asterisk
    /// </summary>
    public static class AsteriskInfo
    {
        private static string _AST_HOSTNAME = "";
        private static int _AST_PORT_NUMBER = 0;
        private static string _AST_USERNAME = "";
        private static string _AST_PASSWORD = "";

        public static string AST_HOSTNAME
        {
            get
            {
                if (string.IsNullOrEmpty(_AST_HOSTNAME))
                    _AST_HOSTNAME = Config_Common.AMI_HostName;
                return _AST_HOSTNAME;
            }
        }

        public static int AST_PORT_NUMBER
        {
            get
            {
                if (_AST_PORT_NUMBER == 0)
                    _AST_PORT_NUMBER = Config_Common.AMI_Port;
                return _AST_PORT_NUMBER;
            }
        }

        public static string AST_USERNAME
        {
            get
            {
                if (string.IsNullOrEmpty(_AST_USERNAME))
                    _AST_USERNAME = Config_Common.AMI_UserName;
                return _AST_USERNAME;
            }
        }

        public static string AST_PASSWORD
        {
            get
            {
                if (string.IsNullOrEmpty(_AST_PASSWORD))
                    _AST_PASSWORD = Config_Common.AMI_Password;
                return _AST_PASSWORD;
            }
        }

        public static string AST_Channel_Callout
        {
            get
            {
                return Config_Common.ChannelDial;
            }
        }

        public static string GetLineIPPBX(string linesDienThoai)
        {
            string ret = string.Empty;
            if (!string.IsNullOrEmpty(linesDienThoai))
            {
                string[] arrLine = linesDienThoai.Split(";".ToCharArray());
                for (int i = 0; i < arrLine.Length; i++)
                {
                    if (arrLine[i].Length >= 3)
                    {
                        ret = arrLine[i];
                        break;
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Line 1
        /// </summary>
        public static string Extension_One { get; set; }
        /// <summary>
        /// Line 2
        /// </summary>
        public static string Extension_Two { get; set; }


        private static ManagerConnection _Manager;
        public static ManagerConnection Manager 
        {
            get
            {
                if (Config_Common.Asterisk_QuickCall && Config_Common.MPCC_LinkDial == "" && _Manager == null)
                {
                    _Manager = new ManagerConnection(AST_HOSTNAME, AST_PORT_NUMBER, AST_USERNAME, AST_PASSWORD);
                }
                return _Manager;
            }
            set { _Manager = value; }
        }

    }
}
