using Microsoft.Practices.EnterpriseLibrary.Data;
using Staxi.Utils.DbBase;
using Staxi.Utils.DbBase.Attributes;

namespace OneTaxi.Utils
{
    public class DBOneTaxi : MainDBBase
    {
        private static Database InstDb = DatabaseFactory.CreateDatabase("OperatorDb");

        protected override Database Db
        {
            get { return InstDb; }
        }
    }
    public class DbService : DataBaseServiceSql<DBOneTaxi> { }

    [DbServiceType(Type = typeof(DbService))]
    public class DataEntityBase : ModelBase { }

    [DbServiceType(Type = typeof(DbService))]
    public class DataEntityBase<T> : ModelBase<T> where T : ModelBase, new() { }
}
