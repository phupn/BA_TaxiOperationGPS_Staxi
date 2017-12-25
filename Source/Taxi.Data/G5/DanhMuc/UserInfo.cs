#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5
{
    [TableInfo(TableName = "[SYS_USER]")]
    public class UserInfo : DbEntityBase<UserInfo>
    {
        [ValueField]
        [Field(IsKey=true,IsIdentity=false)]
        public string USER_ID { get; set; }
        [Field]
        public string PASSWORD { get; set; }
        [Field]
        public string EMAIL { get; set; }
        [Field]
        public int STATUS { get; set; }
        [ColumnField]
        [DisplayField]
        [Field]
        public string FULLNAME { get; set; }
        [Field]
        public int SECURITY_LEVEL { get; set; }
        [Field]
        public int LDAP_ADS_PATH { get; set; }
        [Field]
        public int PhongID { get; set; }
    }
}
