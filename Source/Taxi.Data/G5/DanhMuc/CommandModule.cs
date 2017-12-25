#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Drawing;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Utils.Enums;
using Taxi.Common.Extender;
using System.Linq;
using System.Collections.Generic;
using Taxi.Common.EnumUtility;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = _Table)]
    public class CommandModule : DbEntityBase<CommandModule>
    {
        #region ==== Const ====
        private const string _Table = "[G5_Command_Module]";
        private const string SP_G5_Command_Module_GetCommandByModule = "SP_G5_Command_Module_GetCommandByModule";
        private const string SP_G5_Command_Module_AddCommand = "SP_G5_Command_Module_AddCommand";
        private const string SP_G5_Command_Module_DeleteComand = "SP_G5_Command_Module_DeleteComand";
        #endregion

        #region ==== Properties ====
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public int ModuleId { get; set; }
        [Field]
        public int CommandId { get; set; }
        [Field]
        public int OrderBy { get; set; }
        public PhimTat Shortcuts { get; set; }
        public string CommandName { get; set; }
        public string CommandText
        {
            get
            {
                return string.Format("Phím {0}:{1}", typeof(PhimTat).GetField(Shortcuts.ToString()).GetAttribute<EnumItemAttribute>().Name, CommandName.Trim().Trim().WhenEmpty(() => "Xóa lệnh"));
            }
        }
        #endregion

        #region ==== Method ====
        public List<CommandModule> GetCommandByModule(int moduleId)
        {
            return ExeStore(SP_G5_Command_Module_GetCommandByModule, moduleId).ToList<CommandModule>();
        }

        public void AddCommand(string id, int moduleId)
        {
            ExeStoreNoneQuery(SP_G5_Command_Module_AddCommand, id, moduleId);
        }
        public void DeleteCommand(string id, int moduleId)
        {
            ExeStoreNoneQuery(SP_G5_Command_Module_DeleteComand, id, moduleId);
        }
        #endregion
    }
}
