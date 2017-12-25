using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    [TableInfo(TableName = "BanCo_GiamSatXe_Reasons_Type")]
    public class BanCo_GiamSatXe_Reasons_Type : TaxiOperationDbEntityBase<BanCo_GiamSatXe_Reasons_Type>
    {
        #region Properties
        [Field(IsKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [Field]
        public string TypeName { get; set; }

        [Field]
        public string ShortName { get; set; }
        #endregion

        // get all
        public List<BanCo_GiamSatXe_Reasons_Type> GetListAll() {
            return ExeStore("sp_BanCo_GiamSatXe_Reasons_Type_GetAll").ToList<BanCo_GiamSatXe_Reasons_Type>();
        }

        //thêm mới
        public int InsertReasonType(params object[] para) {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXe_Reasons_Type_Insert",para);
        }

        //sửa
        public int UpdateReasonType(params object[] para)
        {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXe_Reasons_Type_Update", para);
        }

        //xóa
        public int DeleteReasonType(params object[] para)
        {
            return ExeStoreNoneQuery("sp_BanCo_GiamSatXe_Reasons_Type_Delete", para);
        }
    }
}
