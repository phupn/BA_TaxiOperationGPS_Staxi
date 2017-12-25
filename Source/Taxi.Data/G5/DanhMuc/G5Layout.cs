#region ============= Copyright © 2016 BinhAnh =============

using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Linq;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Data.G5.DanhMuc
{
    [TableInfo(TableName = _Table)]
    public class G5Layout : DbEntityBase<G5Layout>
    {
        #region ==== Const ====
        private const string _Table = "[G5_Command]";
        private const string SP_G5_Layout_Save = "SP_G5_Layout_Save";
        private const string SP_G5_Layout_GetLayout = "SP_G5_Layout_GetLayout";
        #endregion

        [Field(IsIdentity=true,IsKey=true)]
        public int Id{get;set;}
        [Field]
        public string ModuleId { get; set; }
        [Field]
        public string FormId { get; set; }
        [Field]
        public string ControlId { get; set; }
        [Field]
        public string UserId { get; set; }
        [Field]
        public string LayoutXml { get; set; }
        [Field]
        public string LastUpdate { get; set; }

        public static void SaveLayout(string ModuleId, string FormId, string ControlId, string UserId, string LayoutXml)
        {
            Inst.ExeStoreNoneQuery(SP_G5_Layout_Save, ModuleId, FormId, ControlId, UserId, LayoutXml);
        }
        public static string GetLayout(string ModuleId, string FormId, string ControlId, string UserId)
        {
            var dt = Inst.ExeStore(SP_G5_Layout_GetLayout, ModuleId, FormId, ControlId, UserId).ToList<G5Layout>().FirstOrDefault();
            if (dt != null)
            {
                return dt.LayoutXml;
            }
            return string.Empty;
        }
    }
}
