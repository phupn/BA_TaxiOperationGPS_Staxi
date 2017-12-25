using System.Linq;
using System.Windows.Forms;
using Staxi.Utils.Extender;

namespace OneTaxi.Controls.Base.Forms
{
    /// <summary>
    /// Thực hiện Check Key với các phương thức
    /// </summary>
    public class ShFormKeyWithMethodChain : ShFormKeyChain
    {
        /// <summary>
        /// Check Key với các phương thức có attribute định nghĩa Key Press
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool CheckKey(Control form, ref Message msg, Keys keyData)
        {
            // Thực hiện xử lý với các phương thức có gắn Keys
            var methodKeys = form.GetType().GetMethodWithKeys().Where(m => m.Keys == keyData).ToList();

            // Thực hiện keys với Method nếu có
            methodKeys.ForEach(m => m.Method.Invoke(form, new object[] { }));

            // return true nếu có key được thực hiện
            return methodKeys.Count != 0;
        }
    }
}
