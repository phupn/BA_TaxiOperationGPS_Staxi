using System.Collections.Generic;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;
using System.Data;

namespace Taxi.Data.BanCo.Entity.GiamSatXe
{
    [TableInfo(TableName = "T_DMXE")]
    public class DMXE : TaxiOperationDbEntityBase<DMXE>
    {
        //public DataTable GetAllLaiXe(){
        //    return ExeStore("SP_DMLAIXE_GETALL");
        //}
        //DataTable dt = new DataTable();
        //public int getLoaiXeID(params object[] para)
        //{
        //    int id = 0;
        //    dt = ExeStore("sp_T_DMXE_GetLoaiXeID",para);
        //    if (dt.Rows.Count > 0) {
        //        id = int.Parse(dt.Rows[0]["FK_LoaiXeID"].ToString());
        //    }
        //    return id;
        //}

        //public DataTable getAllUser() {
        //    return ExeStore("SP_SYS_USER_SELECT_ALL");
        //}
    }
}
