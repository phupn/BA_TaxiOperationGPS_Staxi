using System;
using System.Collections.Generic;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Common.Enums.LookUpEdits
{
    public partial class LookUpEdit_EnumCommand_TrangThaiLenh : InputEnumLookUp<Taxi.Utils.TrangThaiLenhTaxi>
    {
        protected override List<Taxi.Common.EnumUtility.EnumItemAttribute> Data
        {
            get
            {
                var data = base.Data.FindAll(T => (int)T.Value >= 0 && (int)T.Value <= 4);

                return data;
            }
        }
    }
}
