using System;
using System.Data;
using Taxi.Utils;

namespace Taxi.Data.FastTaxi.BaoCao
{
    /// <summary>
    /// 
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// HauNV  18/09/2015   created
    /// </Modified>
    public class BaoCaoChiTietCuocGoiTheoMaMoiGioi : DbEntityBase<BaoCaoChiTietCuocGoiTheoMaMoiGioi>
    {
        /// <summary>
        /// Gets the thong tin cong ty.
        /// CongTyID,TenCongTy
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  18/09/2015   created
        /// </Modified>
        public DataTable GetThongTinCongTy()
        {
            return ExeStore("SP_CONGTY_SELECT_ALL_NAME");
        }
        /// <summary>
        /// Gets the thong tin doi tac.
        /// Ma_DoiTac,Name
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  18/09/2015   created
        /// </Modified>
        public DataTable GetThongTinDoiTac()
        {
            return ExeStore("SP_DOITAC_SELECT_ALL_NAME");
        }
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="congTyId">The cong ty identifier.</param>
        /// <param name="doiTacId">The doi tac identifier.</param>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  18/09/2015   created
        /// </Modified>
        public DataTable GetData(DateTime start, DateTime end, int congTyId, string doiTacId)
        {
            return  ExeStore("sp_BaoCaoChiTietCuocGoiTheoMaMoiGioi_GetData", start, end, congTyId, doiTacId);
        }
    }
}
