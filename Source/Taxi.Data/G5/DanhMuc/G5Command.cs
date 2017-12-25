#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.Drawing;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Utils.Enums;
using Taxi.Common.Extender;
using Taxi.Common.EnumUtility;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = _Table)]
    public class G5Command : DbEntityBase<G5Command>, ICommand
    {
        #region ==== Const ====
        private const string _Table = "[G5_Command]";
        private const string SP_G5_Command_Module_GetCommandNotUse = "SP_G5_Command_Module_GetCommandNotUse";

        //lblPhim = typeof(PhimTat).GetField(cmd.Shortcuts.ToString()).GetAttribute<EnumItemAttribute>().Name;
        //                    lbl.Text = string.Format("Phím {0}\t : {1}", lblPhim, cmd.Command.WhenEmpty(() => "Xóa lệnh"));
        #endregion

        #region === Field ===
        #region == Info ==
        [Field(IsIdentity = true, IsKey = true)]
        public int Id { get; set; }
        [Field]
        public PhimTat Shortcuts { get; set; }
        [Field]
        public PhimTat Shortcuts2 { get; set; }
        [Field]
        public G5CommandType CommandType { get; set; }
        [Field]
        [DisplayField]
        public string Command
        {
            get;
            set;
        }
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

        public string CommandText
        {
            get
            {
                return string.Format("Phím {0}:{1}", typeof(PhimTat).GetField(Shortcuts.ToString()).GetAttribute<EnumItemAttribute>().Name.Trim(),Command.Trim().WhenEmpty(() => "Xóa lệnh"));
            }
        }
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
        public TrangThaiCuocGoiTaxi CallStatus { get; set; }

        [Field]
        public TrangThaiLenhTaxi Status { get; set; }

        [Field]
        public KieuCuocGoi CallType { get; set; }
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
