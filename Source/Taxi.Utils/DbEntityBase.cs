using System;
using System.Collections.Generic;
using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Utils
{
    [DbServiceType(Type = typeof (DbService))]
    public class DbEntityBase<T> : ModelBase<T> where T : ModelBase,new()
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
        public static List<T> GetAllToList()
        {
            return Inst.GetAll().ToList<T>();
        }
    }

    [DbServiceType(Type = typeof(DbService))]
    public class DbEntityBase : ModelBase
    {
        public static DbEntityBase Inst = new DbEntityBase();
    }

    public class DbService : DataBaseService<DbStringConnect>{}

    public class DbStringConnect : MainDBBase
    {
        protected override string ConnectionString
        {
            get { return Settings.ConnectionSetting.ConnectionString; }
        }
    }
   
}
