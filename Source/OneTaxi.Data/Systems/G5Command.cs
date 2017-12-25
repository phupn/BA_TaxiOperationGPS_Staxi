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
    public class G5Command : DataEntityBase<G5Command>,ICommand
    {
        #region ==== Const ====
        private const string _Table = "[G5_Command]";
        private const string SP_G5_Command_Module_GetCommandNotUse = "SP_G5_Command_Module_GetCommandNotUse";
        #endregion

        #region === Field ===
        #region == Info ==
        [Field(IsIdentity = true, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public EnumKeys Shortcuts { get; set; }
        [Field]
        public EnumKeys Shortcuts2 { get; set; }
        [Field]
        public G5CommandType CommandType { get; set; }
        [Field]
        [DisplayField]
        public string Command { get; set; }
        [Field]
        public string CommandColor { get; set; }
        [Field]
        public string ParentCommand { get; set; }
        [Field]
        public string ParentColor { get; set; }
        [Field]
        public CommandBool IsColorRow { get; set; }
        [Field]
        public CommandBool IsColorAll { get; set; }
        [Field]
        public int OrderBy { get; set; }
        #endregion

        #region == Require ==
        [Field]
        public CommandBool RequireTaxi { get; set; }
        [Field]
        public CommandBool RequireVehicle { get; set; }
        [Field]
        public CommandBool RequireVehicleCancel { get; set; }
        [Field]
        public CommandBool RequireApp { get; set; }
        [Field]
        public CommandBool RequireSanBay { get; set; }
        [Field]
        public CommandBool IsRequited { get; set; }
        #endregion

        #region == Opreation Status ==
        [Field]
        public EnumTrangThaiCuocGoi CallStatus { get; set; }

        [Field]
        public EnumTrangThaiLenh Status { get; set; }

        [Field]
        public EnumKieuCuocGoi CallType { get; set; }
        #endregion

        #region == Server Cmd ==
        [Field]
        public IServerFunction CmdServer { get; set; }
        [Field]
        public int CmdId { get; set; }
        [Field]
        public string CmdMsg { get; set; }

        #endregion
        #endregion

        #region=== Method ===
        public List<G5Command> GetCommandNotUse(int moduleId)
        {
            return ExeStore(SP_G5_Command_Module_GetCommandNotUse, moduleId).ToList<G5Command>();
        }
        #endregion
    }
}
