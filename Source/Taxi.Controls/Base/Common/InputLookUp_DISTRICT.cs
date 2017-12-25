using System.Linq;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.Base.Common
{
    public class InputLookUp_DISTRICT : InputLookUp<District>
    {
       public InputLookUp_DISTRICT()
        {
            this.SetFunc(()=> District.Inst.GetAll().ToList<District>().OrderBy(p=>p.NameVN).ToList());
        }
    }
}
