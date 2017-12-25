#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
using System.Data;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.ConfigLayout
{
    [TableInfo(TableName = TABLE_NAME)]
    public class LayoutSetting : DbEntityBase<LayoutSetting>
    {
        private const string TABLE_NAME = "SYS_LAYOUT_SETTING";
        private const string SYS_LAYOUT_SETTING_SELECT = "SYS_LAYOUT_SETTING_SELECT";
        private const string sp_SYS_LAYOUT_SETTING_SaveLayout = "sp_SYS_LAYOUT_SETTING_SaveLayout";

        #region===Field===
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }
        [Field]
        public string AppName { get; set; }
        [Field]
        public string FormId { get; set; }
        [Field]
        public string ControlId { get; set; }
        [Field]
        public string LayoutString { get; set; }

        [Field]
        public string User_Id { get; set; }
        #endregion

        #region===Methods===
        public LayoutSetting GetLayout(string User_Id, string AppName, string FormId, string ControlId)
        {
            var dt = ExeStore(SYS_LAYOUT_SETTING_SELECT, User_Id, AppName, FormId, ControlId);
            if (dt.Rows.Count>0)
            {
                return dt.ToList<LayoutSetting>()[0];
            }
            return null;
        }

        public void SaveLayout()
        {
           int a = ExeStoreNoneQuery(sp_SYS_LAYOUT_SETTING_SaveLayout);
        }
        #endregion
    }
}
