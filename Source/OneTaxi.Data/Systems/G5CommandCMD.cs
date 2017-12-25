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
    public class G5CommandCMD : DataEntityBase<G5CommandCMD>
    {
        private const string _Table = "[G5_Command_Cmd]";
        [Field(IsIdentity = true, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public int CmdId { get; set; }
        [Field]
        public string CmdName { get; set; }
    }
}
