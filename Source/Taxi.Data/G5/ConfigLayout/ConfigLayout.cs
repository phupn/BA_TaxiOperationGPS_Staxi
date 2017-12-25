#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Collections.Generic;
#endregion ============= Copyright © 2016 BinhAnh =============
namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = TABLE_NAME)]
    public class ConfigLayout : DbEntityBase<ConfigLayout>
    {
        private const string TABLE_NAME = "ConfigLayout";
        private const string sp_ConfigLayot_GetLayoutGrid = "sp_ConfigLayot_GetLayoutGrid";
        private const string sp_ConfigLayot_SaveLayout = "sp_ConfigLayot_SaveLayout";
        #region===Field===
        [Field(IsKey= true, IsIdentity= true)]
        public int ID { get; set; }
        [Field]
        public string GridName { get; set; }
        [Field]
        public string ColumnName { get; set; }
        [Field]
        public int Width { get; set; }
        [Field]
        public bool Visible { get; set; }
        [Field]
        public int VisibleIndex { get; set; }
        [Field]
        public string UserID { get; set; }
        #endregion

        #region===Methods===
        public List<ConfigLayout> GetLayoutGrid(string gridName, string userID)
        {
            return ExeStore(sp_ConfigLayot_GetLayoutGrid, gridName, userID).ToList<ConfigLayout>();
        }

        public void SaveLayout()
        {
            ExeStoreNoneQuery(sp_ConfigLayot_SaveLayout);
        }
        #endregion
    }
}
