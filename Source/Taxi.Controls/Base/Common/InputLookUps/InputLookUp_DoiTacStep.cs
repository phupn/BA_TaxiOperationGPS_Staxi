using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.BanCo;
using Taxi.Data.BanCo.Entity.MasterData;

namespace Taxi.Controls.Base.Common
{
    public class InputLookUp_DoiTacStep : InputLookUp<DoiTacStep>
    {
        public InputLookUp_DoiTacStep()
        {
            this.SetFunc(() => CommonData.ListDoiTacStep.OrderBy(p => p.Money).ToList());
        }
    }
}
