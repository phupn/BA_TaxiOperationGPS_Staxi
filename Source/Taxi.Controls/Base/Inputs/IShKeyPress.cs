using System.ComponentModel;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// KeyPress
    /// </summary>
    public interface IShKeyPress
    {
        /// <summary>
        /// KeyCommand, mặc định là None
        /// </summary>
        [DefaultValue(Keys.None)]
        Keys KeyCommand { set; get; }

        /// <summary>
        /// Thực hiện KeyCommand
        /// </summary>
        void DoKeyCommand(object sender);
    }
}
