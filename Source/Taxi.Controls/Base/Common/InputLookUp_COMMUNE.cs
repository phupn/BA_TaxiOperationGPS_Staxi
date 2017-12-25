
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.Base.Common
{
    public class InputLookUp_COMMUNE: InputLookUp<Commune>
    {
        public InputLookUp_COMMUNE()
        {
            this.SetFunc(() => Commune.Inst.GetAll().ToList<Commune>().OrderBy(p => p.NameVN).ToList());
        }
    }
}
