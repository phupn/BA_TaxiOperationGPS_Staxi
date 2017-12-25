using System.Collections.Generic;
using System.Linq;
using Taxi.Data.BanCo.Entity.GiamSatXe;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe.BaoCaoTongHop
{
    public class BaoCaoLoi : BaoCaoTongHopBase<ConfigurationViolateError>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override List<ConfigurationViolateError> GetData()
        {
            return GetFromContext("ConfigurationViolateError", () => ConfigurationViolateError.Inst.GetInRangeDate(From, To))
                .Where(ve => ve.FK_ErrorType!=0).Where(ve => ve.FK_ErrorType == BanCo_GiamSatXe_Reason.Id).ToList();
        }

        /// <summary>
        /// Lỗi cần thống kê
        /// </summary>
        public BanCo_GiamSatXe_Reason BanCo_GiamSatXe_Reason { set; get; }

        /// <summary>
        /// Khoản mục => tên loại lỗi
        /// </summary>
        protected override string KhoanMuc
        {
            get { return BanCo_GiamSatXe_Reason.TypeName; }
        }

        /// <summary>
        /// Nội dung => tên lỗi
        /// </summary>
        protected override string NoiDung
        {
            get { return BanCo_GiamSatXe_Reason.Reason; }
        }

        /// <summary>
        /// Tạo các Binder fill báo cáo lỗi
        /// </summary>
        /// <returns></returns>
        public static List<BaoCaoLoi> CreateBinders()
        {
            return BanCo_GiamSatXe_Reason.Inst.GetAllToList().Where(r => r.Type == 1 || r.Type == 2).OrderBy(r => r.Type).
                Select(r => new BaoCaoLoi { BanCo_GiamSatXe_Reason = r }).ToList();
        }
    }

}
