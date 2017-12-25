#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;

using Staxi.Utils.Attributes;
using Staxi.Utils.DbBase.Attributes;
using Staxi.Utils.Extender;

using OneTaxi.Utils;
using OneTaxi.Utils.Enums;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace OneTaxi.Data.Systems
{
    [TableInfo(TableName = _Table)]
    public class ConfigCommon : DataEntityBase<ConfigCommon>
    {
        private const string _Table = "[Config_Common]";

        [Field(IsIdentity = false, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public string Name { get; set; }
        [Field]
        public string HasValue { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public DateTime? LastUpdate { get; set; }
    }
}
