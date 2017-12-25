using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "[T_DMKHACHHANG_TYPE]")]
    public class DMKhachQuen_Type : TaxiOperationDbEntityBase<DMKhachQuen_Type>
    {
        #region Members
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int ID { get; set; }
        [Field]
        [DisplayField]
        public new string Type { get; set; }
        [Field]
        public string Notes { get; set; }
        #endregion
    }
}
