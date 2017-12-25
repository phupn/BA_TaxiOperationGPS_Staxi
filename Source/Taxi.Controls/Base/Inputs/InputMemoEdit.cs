using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.ComponentModel;

namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// Input Memo Edit
    /// </summary>
    public class InputMemoEdit : MemoEdit, IShInput, IShKeyPress, ITextChange
    {
        public bool IsChangeText { get; set; }
        public bool IsForceChangeText { get; private set; }
        public bool IsFocus { get; set; }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);
            IsForceChangeText = false;
            IsFocus = true;
        }

        protected override void OnEditValueChanged()
        {
            if (this.IsFocus)
            {
                IsForceChangeText = true;
                IsChangeText = true;
            }
            base.OnEditValueChanged();
        }

        protected override void OnTextChanged(System.EventArgs e)
        {

            if (this.IsFocus)
            {
                IsForceChangeText = true;
                IsChangeText = true;
            }
            base.OnTextChanged(e);
        }

        protected override void OnLeave(System.EventArgs e)
        {
            IsFocus = false;
            base.OnLeave(e);
        }

        /// <summary>
        /// Clear Text
        /// </summary>
        public void Clear()
        {
            this.Text = string.Empty;
        }

        /// <summary>
        /// Thiết lập giá trị
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            this.Text = value == null ? string.Empty : value.ToString();
        }

        /// <summary>
        /// Lấy ra giá trị
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return this.Text.Trim();
        }

        [DefaultValue(Keys.None)]
        public Keys KeyCommand { set; get; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}