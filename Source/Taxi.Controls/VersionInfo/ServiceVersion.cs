using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Business.QuanTri;
using Taxi.Data.FastTaxi;
using Taxi.Utils;

namespace Taxi.Controls.VersionInfo
{
    public  class ServiceVersion
    {
        public static DateTime? LastUpdate;
        public static bool IsRequired=false;
        public static void CheckVersionStart()
        {
            try
            {
                var version = SYS_VersionInfo.GetVersionIPAddress(QuanTriCauHinh.IpAddress, Global.Module.ToString(), LastUpdate);

                var dt = version.GetTimeServer();
                if (version.Id > 0)
                {
                    LastUpdate = version.LastUpdate;
                    if (!version.IsRequired && version.IsCheck) return;
                    IsRequired = version.IsRequired;
                    if (version.IsCheck)
                    {
                        version.Version = license.Version();
                        version.IsCheck = false;
                    }
                    version.IsRequired = false;
                    version.LastUpdate = dt;
                }
                else
                {
                    version.IPAddress = QuanTriCauHinh.IpAddress;
                    version.IsPC = Global.Module.ToString();
                    version.Version = license.Version();
                    version.DateUpdate = dt;
                    version.LastUpdate = dt;
                }
                version.Save();
            }
            catch
            {

            }     
        }
        public static void CheckVersion()
        {
            try
            {
                var version = SYS_VersionInfo.GetVersionIPAddress(QuanTriCauHinh.IpAddress, Global.Module.ToString(), LastUpdate);
                if (version.Id > 0)
                {
                    LastUpdate = version.LastUpdate;
                    if (!version.IsRequired && !version.IsCheck) return;
                    IsRequired = version.IsRequired;
                    bool IsSave = false;
                    if (version.IsCheck)
                    {
                        version.Version = license.Version();
                        version.Status = "Đã cập nhật";
                        version.IsCheck = false;
                        IsSave = true;
                    }
                    if (version.IsRequired)
                    {
                        new FrmRequired() {
                            versionInfo = version
                         }.Show();
                    }

                    if (IsSave)
                    {
                        var dt = version.GetTimeServer();
                        version.LastUpdate = dt; 
                        version.Save();
                    }
                    
                }
               
            }
            catch
            {

            }
        }
    }
}
