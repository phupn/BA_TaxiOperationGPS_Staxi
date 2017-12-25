using System;
using System.Data;
using System.Data.SqlClient;
using Taxi.Utils;

namespace Taxi.Data.DieuXeDuongDai
{
    public class BaoCaoDieuxeDuongDai : DBObject
    {
        #region SQL

        public string Store_BaoCaoNhatTrinhXeBaoDuongDai = "sp_BaoCao_NhatTrinhXeBaoDuongDai";
        #endregion

        #region Hàm
        public DataTable BaoCaoNhatTrinhXeBaoDuongDai(DateTime deStart, DateTime deEnd, string soXe, string soDt,
            int trangThai)
        {
            return RunProcedure(this.Store_BaoCaoNhatTrinhXeBaoDuongDai, new IDataParameter[]
            {
                new SqlParameter("deStart", deStart), 
                new SqlParameter("deEnd", deEnd), 
                new SqlParameter("soXe", soXe),
                new SqlParameter("soDt", soDt),
                new SqlParameter("trangThai", trangThai),
            },"BaoCao").Tables[0];
        }
        #endregion
    }
}
