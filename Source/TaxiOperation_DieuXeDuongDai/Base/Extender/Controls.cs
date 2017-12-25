using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TaxiOperation_DieuXeDuongDai.Base.Extender
{
    public static class Controls
    {
        public static IEnumerable<T> FindAllChildrenByType<T>(this Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.OfType<T>().Concat<T>(controls.SelectMany<Control, T>(FindAllChildrenByType<T>));
        }
    }
}
