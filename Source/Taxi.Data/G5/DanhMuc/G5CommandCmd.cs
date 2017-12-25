#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Drawing;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Utils.Enums;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = TABLE)]
    public class G5CommandCmd : DbEntityBase<G5CommandCmd>
    {
        #region ==== Const ====
        private const string TABLE = "[G5_Command_Cmd]";
        #endregion
        [Field(IsKey=true,IsIdentity=true)]
        public int Id { get; set; }
        [Field]
        [ValueField]
        public int CmdId { get; set; }
        [Field]
        [DisplayField]
        [ColumnField]
        public string CmdName { get; set; }
    }
}
