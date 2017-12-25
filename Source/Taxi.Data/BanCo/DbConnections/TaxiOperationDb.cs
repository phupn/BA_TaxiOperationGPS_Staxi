using Taxi.Common.DbBase;

namespace Taxi.Data.BanCo.DbConnections
{
    public class TaxiOperationDb : MainDBBase
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        protected override string ConnectionString
        {
            get { return Taxi.Utils.Settings.ConnectionSetting.ConnectionString; }
        }
    }
}
