using System.ComponentModel;
using System.Windows.Forms;
namespace OneTaxi.Controls.Base
{
    public interface IKeyPress
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
