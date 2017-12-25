using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "SYS_USER")]
    public class SYS_USER : TaxiOperationDbEntityBase<SYS_USER>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public string USER_ID { get; set; }
        [Field]
        public string PASSWORD { get; set; }
        [Field]
        public string EMAIL { get; set; }
        [Field]
        public string STATUS { get; set; }
        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên nhân viên")]
        public string FULLNAME { get; set; }
        [Field]
        public int SECURITY_LEVEL { get; set; }
        [Field]
        public int PhongID { get; set; }
        [Field]
        public string LDAP_ADS_PATH { get; set; }
        #endregion
    }
}
