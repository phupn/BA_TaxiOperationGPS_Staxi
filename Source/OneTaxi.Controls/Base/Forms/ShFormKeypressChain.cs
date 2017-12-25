using System.Windows.Forms;
using OneTaxi.Controls.Base.Extender;

namespace OneTaxi.Controls.Base.Forms
{
    /// <summary>
    /// Kiểm tra KeyPress trên Control có một Command
    /// </summary>
    public class ShFormKeypressChain : ShFormKeyChain
    {
        /// <summary>
        /// Kiểm tra Key với interface IKeyPress
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool CheckKey(Control form, ref Message msg, Keys keyData)
        {
            return form.SetEventKeypress(ref msg, keyData);
        }
    }
}
