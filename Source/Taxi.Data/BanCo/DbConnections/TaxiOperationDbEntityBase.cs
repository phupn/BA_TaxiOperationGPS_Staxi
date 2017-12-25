using Taxi.Common.DbBase;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Data.BanCo.DbConnections
{
    /// <summary>
    /// EntityBase của TaxiOperation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DbServiceType(Type = typeof (TaxiOperationDbService))]
    public class TaxiOperationDbEntityBase<T> : ModelBase<T> where T : new(){}
}
