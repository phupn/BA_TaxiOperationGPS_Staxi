using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlClient;


namespace Taxi.Data.BanCo.Entity.DM
{
    [TableInfo(TableName = "T_TypesOfGoods")]
    public class T_TypesOfGoods : TaxiOperationDbEntityBase<T_TypesOfGoods>
    {
        #region Properties

        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public int OrderItem { get; set; }

        [Field]
        public string Description { get; set; }

        [Field]
        public string ShortName { get; set; }
        #endregion

        // lấy dữ liệu chủng loại hàng hóa
        public DataTable GetTypesOfGoods()
        {
            return ExeStore("sp_GetTypesOfGoods");
        }

        //thêm mới hàng hóa
        public int InsertTypeOfGoods(params object[] para)
        {
            return ExeStoreNoneQuery("sp_TypesOfGoods_Insert", para);
        }

        //cập nhật thông tin hàng hóa
        public int UpdateTypeOfGoods(params object[] para)
        {
            return ExeStoreNoneQuery("sp_TypesOfGoods_Update", para);
        }
        //xóa thông tin hàng hóa
        public int DeleteTypeOfGoods(params object[] para)
        {
            return ExeStoreNoneQuery("sp_TypeOfGoods_Delete", para);
        }
    }
}
