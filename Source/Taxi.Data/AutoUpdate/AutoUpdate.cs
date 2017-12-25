using System;
using System.Collections.Generic;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils;
using Taxi.Common.Extender;

namespace Taxi.Data.AutoUpdate
{
    [TableInfo(TableName = "[T_AUTO_UPDATE_CONFIG]")]
    public class AutoUpdate : DbEntityBase<AutoUpdate>
    {
        [Field(IsKey = true)]
        public int Id { get; set; }
        [Field]
        public string UpdateFolder { get; set; }
        [Field]
        public string Module { get; set; }
        [Field]
        public string ModuleName { get; set; }
        [Field]
        public string UpdateDate { get; set; }
        [Field]
        public string Description { get; set; }
        [Field]
        public string Version { get; set; }

        /// <summary>
        /// Kiêm tra xem có phiên bản update nào không
        /// </summary>
        /// <param name="module"></param>
        /// <param name="dateUpdate"></param>
        /// <returns></returns>
        public AutoUpdate GetUpdateByDateTime(Module module, string version)
        {
            List<AutoUpdate> lstItem = ExeStore("T_AUTO_UPDATE_CONFIG_GET_NEWUPDATE", (int)module, version).ToList<AutoUpdate>();
            if (lstItem != null && lstItem.Count > 0)
                return lstItem[0];
            else
                return null;
        }

        /// <summary>
        /// Update trang thai đã update để lần sau ko update nữa
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public bool Updated(int module)
        {
            return ExeStoreNoneQuery("SP_T_AUTO_UPDATE_CONFIG_UPDATED", module) > 0;
        }
    }
}
