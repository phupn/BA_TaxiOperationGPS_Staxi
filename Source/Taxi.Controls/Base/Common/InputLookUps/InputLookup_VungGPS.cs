using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.Base.Common.InputLookUps
{
    public class InputLookup_VungGPS :InputLookUp<VungGPS>
    {
        protected override List<VungGPS> Data
        {
            get
            {
                if (!DesignMode)
                {
                    return base.Data.OrderBy(p => p.KenhVung).ToList();
                }
                return null;
            }
        }
    }
}
