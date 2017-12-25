using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace TaxiOperation.API.Enties
{
    [DbServiceType(Type = typeof(DbService))]
    public class EntityBase<T> : ModelBase<T> where T : new()
    {
        public DateTime? GetTimeServer()
        {
            try
            {
                return DataBaseService.ExeSql("Select GetDate()").Rows[0][0].To<DateTime>();
            }
            catch
            {
                return null;
            }
        }
    }

    public class DbService : DataBaseService<DbStringConnect> { }

    public class DbStringConnect : MainDBBase
    {
        protected override string ConnectionString
        {
            get { return Taxi.Utils.Settings.ConnectionSetting.ConnectionStringService; }
        }
    }
   
}