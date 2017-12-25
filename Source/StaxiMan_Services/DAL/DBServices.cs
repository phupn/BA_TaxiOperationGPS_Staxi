using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;

namespace StaxiMan_Services.DAL
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
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }
    }
}