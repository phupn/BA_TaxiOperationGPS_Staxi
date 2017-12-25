

using Taxi.Common.DbBase.Attributes;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "Company_Connection")]
    public class CompanyConnection:DBServices<CompanyConnection>
    {
        [Field(IsKey = true,IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }
        [Field]
        public string Source { get; set; }
        [Field]
        public string Catalog { get; set; }
        [Field]
        public string UserName { get; set; }
        [Field]
        public string Password { get; set; }
    }
}
