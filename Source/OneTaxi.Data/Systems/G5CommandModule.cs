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
    public class G5CommandModule : DataEntityBase<G5CommandModule>
    {
        private const string _Table = "[G5_Command_Module]";
        [Field(IsIdentity=true,IsKey=true)]
        public int Id { get; set; }
        [Field]
        public int ModuleId { get; set; }
        [Field]
        public int CommandId { get; set; }
        [Field]
        public int OrderBy { get; set; }

    }
}
