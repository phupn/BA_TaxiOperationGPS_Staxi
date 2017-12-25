using System.Linq;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;
using Taxi.Data.FastTaxi;

namespace Taxi.Controls.Base.Common
{
    public class InputLookUp_Province : InputLookUp<Province>
    {

        public InputLookUp_Province()
        {
            this.SetFunc(() => Province.Inst.GetAll().ToList<Province>().OrderBy(p => p.NameVN).ToList());
        }
    }
}
