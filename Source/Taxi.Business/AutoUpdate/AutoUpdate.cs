using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;
using System.Linq;
namespace Taxi.Business.AutoUpdate
{
    [TableInfo(TableName = "[T_AUTO_UPDATE_CONFIG]")]
    public class AutoUpdate : DbEntityBase<AutoUpdate>
    {
        [Field(IsKey = true,IsIdentity=true)]
        public int Id { get; set; }
        [Field]
        public string UpdateFolder { get; set; }
        [Field]
        public string Module { get; set; }
        [Field]
        public string ModuleName { get; set; }
        [Field]
        public DateTime UpdateDate { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public string Version { get; set; }
        public bool IsUpdate { get; set; }
        /// <summary>
        /// Kiêm tra xem có phiên bản update nào không
        /// </summary>
        public AutoUpdate GetUpdateByDateTime(Module module, string version)
        {
            try
            {
                List<AutoUpdate> lstItem =
                    ExeStore("T_AUTO_UPDATE_CONFIG_GET_NEWUPDATE", (int) module, version).ToList<AutoUpdate>();
                if (lstItem != null && lstItem.Count > 0)
                    return lstItem[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetUpdateByDateTime",ex);
                return null;
            }
          
        }

        /// <summary>
        /// Update trang thai đã update để lần sau ko update nữa
        /// </summary>
        public bool Updated(int module)
        {
            return ExeStoreNoneQuery("SP_T_AUTO_UPDATE_CONFIG_UPDATED", module) > 0;
        }
        public static AutoUpdate GetVersionNew(EnumModule module)
        {
            var entity = new AutoUpdate();
            try
            {

                var dt = Inst.ExeStore("SP_AutoUpdate_GetVersionNew", module.ToString()).ToList<AutoUpdate>();
                if (dt.Count == 1)
                    entity = dt.First();
            }
            catch
            {
            }
            return entity;

        }
    }
}
