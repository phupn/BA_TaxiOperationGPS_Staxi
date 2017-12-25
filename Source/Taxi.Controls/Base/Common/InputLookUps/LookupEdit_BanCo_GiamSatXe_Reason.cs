using Taxi.Controls.Base.Inputs;
using Taxi.Common.Extender;
using System.Linq;
using System.Collections.Generic;
using Taxi.Utils;
using System.ComponentModel;
using Taxi.Data.BanCo.Entity.GiamSatXe;
namespace Taxi.Controls.Common.LookupEdits
{
    public class LookupEdit_BanCo_GiamSatXe_Reason : InputLookUp<BanCo_GiamSatXe_Reason>
    {

        [DefaultValue(Enum_ReasonType.LyDoBaoVe)]
        /// <summary>
        /// Loại lỗi cần hiển thị
        /// </summary>
        public Enum_ReasonType TypeReason { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public LookupEdit_BanCo_GiamSatXe_Reason()
        {
            this.SetFunc(() => BanCo_GiamSatXe_Reason.Inst.GetAll().ToList<BanCo_GiamSatXe_Reason>().Where(r => r.Type == (int)TypeReason).OrderBy(r => r.Sort).Select(r => 
            {
                r.Reason = (string.IsNullOrEmpty(r.ShortName) ? "" : r.ShortName + " - ") + r.Reason;
                return r;
            }).ToList());
        }
    }
}
