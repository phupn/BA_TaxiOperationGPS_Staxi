using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo;
using Taxi.Data.BanCo.Entity.MasterData;

namespace Taxi.Controls.Base.Common
{
    public class InputLookUp_VungDieuHanh : InputLookUp<VungDieuHanh>
    {
        public InputLookUp_VungDieuHanh()
        {
            this.SetFunc(() => CommonData.DSVungDieuHanh.OrderBy(p => p.NameVungDH).ToList());
        }
    }
}
