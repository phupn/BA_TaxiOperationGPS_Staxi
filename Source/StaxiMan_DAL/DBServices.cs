using System.Configuration;
using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils.Settings;

namespace StaxiMan_DAL
{
    [DbServiceType(Type = typeof(DbService))]
    public class DBServices<T> : ModelBase<T> where T : ModelBase, new()
    {

    }
    [DbServiceType(Type = typeof(DbService))]
    public class DbEntityBase : ModelBase
    {
        public static DbEntityBase Inst = new DbEntityBase();
    }

    public class DbService : DataBaseService<DbStringConnect> { }

    public class DbStringConnect : MainDBBase
    {
        protected override string ConnectionString
        {
            get
            {
                if (ConnectionSetting.UseDynamicConnection)
                {
                    return ConnectionSetting.DynamicConnectionString;
                }

                if (ConfigurationManager.AppSettings["ConnectionString"] != null && ConfigurationManager.AppSettings["ConnectionString"] != "")
                {
                    return ConfigurationManager.AppSettings["ConnectionString"];
                } 
                return ConnectionSetting.ConnectionString;
            }
        }
    }
}