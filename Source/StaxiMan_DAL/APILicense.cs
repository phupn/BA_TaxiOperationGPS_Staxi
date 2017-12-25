using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace StaxiMan_DAL
{
    [TableInfo(TableName = "APILicense")]
    public class APILicense:DBServices<APILicense>
    {
        [Field(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }
        [Field]
        public string APICode { get; set; }
        [Field]
        public string APIKey { get; set; }
        [Field]
        public int FK_CompanyID { get; set; }

        public APILicense GetItemFromCompanyId(int companyId)
        {
            return ExeStore("SP_APILicense_GetByCompanyID", companyId).ToItem<APILicense>();
        }

        public bool UpdateAPI(int companyId, string APICode, string APIKey)
        {
            return ExeStoreNoneQuery("SP_APILicense_Update", companyId, APICode, APIKey) > 0;
        }
    }
}
