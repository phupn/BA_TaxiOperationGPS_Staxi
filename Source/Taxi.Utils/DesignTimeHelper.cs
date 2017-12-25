using System.ComponentModel;
using System.Diagnostics;

namespace Taxi.Utils
{
    public static class DesignTimeHelper
    {
        public static bool IsInDesignMode
        {
            get
            {
                bool isInDesignMode = System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime;

                if (!isInDesignMode)
                {
                    using (var process = Process.GetCurrentProcess())
                    {
                        return process.ProcessName.ToLowerInvariant().Contains("devenv");
                    }
                }

                return true;
            }
        }
    }
}
