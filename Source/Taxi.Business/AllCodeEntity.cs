using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using Taxi.Utils;

namespace Taxi.Business
{
    /// <summary>
    /// Dùng để lưu trữ và quản lý các danh mục đơn giản!
    /// </summary>
    [TableInfo(TableName = "AllCode")]
    public class AllCodeEntity:DbEntityBase<AllCodeEntity>
    {
        [Field]
        public string Code { get; set; }

        [Field]
        public int Value { get; set; }

        [Field]
        public string Display { get; set; }

        [Field]
        public int? OrderSort { get; set; }

        public List<AllCodeEntity> GetListAll()
        {
            return this.GetAll().ToList<AllCodeEntity>();
        }

        /// <summary>
        /// Lấy danh mục hiển thị theo mã
        /// </summary>
        public List<AllCodeEntity> GetAllCodeByCode(string pCode)
        {
            List<AllCodeEntity> lstResult = new List<AllCodeEntity>();
            try
            {
                foreach (AllCodeEntity item in CommonBL.ListAllCode)
                {
                    if (item.Code == pCode)
                    {
                        lstResult.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetAllCodeByCode; ", ex);
            }
            return lstResult.OrderBy(x => x.OrderSort).ToList();
        }
    }
}
