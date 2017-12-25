using System.Configuration;
using Taxi.Common;

namespace Taxi.Data.BanCo
{
    /// <summary>
    /// Settings ở file App.Config
    /// </summary>
    public class Settings : Singleton<Settings>
    {
        /// <summary>
        /// Connection String Db Taxi Operation
        /// </summary>
        public string TaxiOperationDbConnectionString { get { return Taxi.Utils.CommonUtils.ConnectionString; } }
    }
}
