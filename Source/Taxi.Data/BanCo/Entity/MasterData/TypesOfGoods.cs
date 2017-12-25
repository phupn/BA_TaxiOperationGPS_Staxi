using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity.MasterData
{

    [TableInfo(TableName = "T_TypesOfGoods")]
    public class TypesOfGoods : TaxiOperationDbEntityBase<TypesOfGoods>
    {
        #region Properties
        
        [Field(IsKey = true, IsIdentity = true)]
        [ValueField]
        public int Id { get; set; }

        [Field]
        [DisplayField]
        [ColumnField(ColumnName = "Tên hàng hóa")]
        public string Name { get; set; }

        [Field]
        public int OrderItem { get; set; }

        [Field]
        public string Description { get; set; }

        [Field]
        public string ShortName { get; set; }
        #endregion

        #region Methods
        public List<TypesOfGoods> GetListAll()
        {
            return GetAll().ToList<TypesOfGoods>();
        }

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
        #endregion
    }
}
