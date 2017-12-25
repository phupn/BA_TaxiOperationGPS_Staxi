using System.Linq;
using System.Windows.Forms;
using Taxi.Controls.Base.Inputs;

namespace TaxiOperation_DieuXeDuongDai.Base.Extender
{
    public static class WinformKey
    {
        public static bool WithKey(this Control control, Keys key)
        {
            var ctl = control.FindAllChildrenByType<IShKeyPress>().Where(p => p.KeyCommand == key).ToList();
            if (ctl.Count == 1)
            {
                ctl.ForEach(p=>p.DoKeyCommand(p));
                return true;
            }
            return false;
        }
    }
}
