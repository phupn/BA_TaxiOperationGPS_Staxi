using System;
using System.Collections.Generic;
using System.Data;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace StaxiMan_DAL
{

    [TableInfo(TableName = "Company")]
    public class Company : DBServices<Company>
    {
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { get; set; }
        [Field]
        public int XNCode { get; set; }

        [Field]
        public int CompanyId { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(Name = "Company")]
        public string Name { get; set; }
        [Field]
        public DateTime DeployDate { get; set; }
        [Field]
        public string Hotline { get; set; }
        [Field]
        public DateTime CreatedDate { get; set; }
        [Field]
        public DateTime? UpdatedDate { get; set; }

        public List<Company> GetListAll()
        {
            return this.GetAll().ToList<Company>();
        }
        public DataTable GetListAll_NotParentCompany()
        {
            return this.ExeStore("SP_Company_GetAll_NotParentCompany"); //this.GetAll().ToList<Company>().FindAll(T=>T.CompanyId != 0);
        }

    }
}
