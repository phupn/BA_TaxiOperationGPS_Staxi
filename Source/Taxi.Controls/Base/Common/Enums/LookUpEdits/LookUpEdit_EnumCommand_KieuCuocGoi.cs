using System;
using System.Collections;
using System.Collections.Generic;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Common.Enums.LookUpEdits
{
    /// <summary>
    /// 
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// Administrator   24/08/2015   created
    /// </Modified>
    public partial class LookUpEdit_EnumCommand_KieuCuocGoi : InputEnumLookUp<Taxi.Utils.KieuCuocGoi>
    {
        /// <summary>
        /// Nếu sử dụng trong báo cáo thì insert thêm chọn tất cả cuộc gọi không điều xe
        /// </summary>
        public bool IsReport { set; get; }

        protected override List<Taxi.Common.EnumUtility.EnumItemAttribute> Data
        {
            get
            {
                var data = base.Data;

                if (IsReport && !data[0].Value.Equals(-3))
                {
                    data.Insert(0, new Taxi.Common.EnumUtility.EnumItemAttribute("tc-Tất cả cuộc gọi không điều xe") { Value = -1 });
                    data.Insert(0, new Taxi.Common.EnumUtility.EnumItemAttribute("tc-Tất cả cuộc gọi") { Value = -2 });
                    data.Insert(0, new Taxi.Common.EnumUtility.EnumItemAttribute("tc-Tất cả cuốc hàng") { Value = -3 });
                }

                return data;
            }
        }
    }
}
