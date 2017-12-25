using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business;
using Taxi.Services;
using Taxi.Utils;

namespace TaxiOperation_TongDai.App
{
    public class ServerApp
    {
        #region ==== 6.Ping ====
        public static Enum_G5_Ping PingServer;

        public static Enum_G5_Ping PingServer_XHD;
        public static Enum_G5_Ping Ping()
        {
            try
            {
                if (Config_Common.CoDieuApp)
                {
                    if (WCFServicesApp.IsOperatorClientConnecting())
                    {
                        PingServer = Enum_G5_Ping.PingSu;
                    }
                    else
                        PingServer = Enum_G5_Ping.PingFail;
                }
                if (Config_Common.App_DieuXeHopDong)
                {
                    if (WCFServicesAppXHD.IsOperatorClientConnecting())
                    {
                        PingServer_XHD = Enum_G5_Ping.PingSu;
                    }
                    else
                        PingServer_XHD = Enum_G5_Ping.PingFail;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_Ping:", ex);
                PingServer = Enum_G5_Ping.PingNotConenct;
                PingServer_XHD = Enum_G5_Ping.PingNotConenct;
            }
            return PingServer;
        }
        #endregion
    }
}
