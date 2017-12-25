using StaxiMan_DAL;
using System.ComponentModel;
using System.Linq;
using Taxi.Common.Extender;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Common.License
{
    public class InputLookUp_Company : InputLookUp<Company>
    {

        public InputLookUp_Company()
        {
            if (!System.Diagnostics.Debugger.IsAttached && (LicenseManager.UsageMode != LicenseUsageMode.Designtime) && !DesignMode)
            {
                this.SetFunc(() => Company.Inst.GetAll().ToList<Company>().OrderBy(p => p.Name).ToList());
            }
            else
            {
                this.SetFunc(() => Company.Inst.GetAll().ToList<Company>().OrderBy(p => p.Name).ToList());
            }
        }
    }
}
