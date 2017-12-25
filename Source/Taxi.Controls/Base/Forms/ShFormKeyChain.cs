using System.Windows.Forms;
using Taxi.Utils;

namespace Taxi.Controls.Base.Forms
{
    /// <summary>
    /// Xử lý Key trên Form
    /// </summary>
    public abstract class ShFormKeyChain : Chain<ShFormKeyChain>
    {
        private static ShFormKeyChain inst = null;
        /// <summary>
        /// Khởi tạo một đối tượng để sử dụng
        /// </summary>
        public static ShFormKeyChain Inst
        {
            get
            {
                if (inst == null)
                {
                    // Check key với phương thức trước
                    inst = new ShFormKeyWithMethodChain();

                    // Tiếp đến là control có 1 Command
                    inst.SetHandler<ShFormKeypressChain>();
                }
                return inst;
            }
        }

        /// <summary>
        /// Check việc thực hiện kiểm tra bàn phím
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected abstract bool CheckKey(Control form, ref Message msg, Keys keyData);

        /// <summary>
        /// Check việc thực hiện Key
        /// </summary>
        /// <param name="form"></param>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        public bool DoCheckKey(Control form, ref Message msg, Keys keyData)
        {
            // Kiểm tra
            var hasTrue = CheckKey(form, ref msg, keyData);

            // Check tiếp ở Handler
            if (this.Handler != null && !hasTrue) hasTrue = this.Handler.DoCheckKey(form, ref msg, keyData);

            // return kết quả
            return hasTrue;
        }
    }
}
