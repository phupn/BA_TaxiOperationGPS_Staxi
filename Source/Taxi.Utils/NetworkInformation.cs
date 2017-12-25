using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Taxi.Utils
{
    public class NetworkInformation
    {
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                if (reply.Status == IPStatus.Success)
                    pingable = true;                
            }
            catch (PingException ex)
            {
                LogErrorUtils.WriteLogError("PingHost: ",ex);
            }
            return pingable;
        }

        public static string FormatIP(string pInput, string pSeperator)
        {
            try
            {
                string result = string.Empty;
                string[] arrString = pInput.Split(new[] {pSeperator}, StringSplitOptions.RemoveEmptyEntries);
                if (arrString.Any())
                {
                    result = arrString[0];
                }
                return result;
            }
            catch (Exception ex)
            {
                LogErrorUtils.WriteLogError("FormatIP:",ex);
                return string.Empty;
            }
        }
    }
}
