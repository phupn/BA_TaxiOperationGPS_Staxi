using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// Input checkbox
    /// </summary>
    public class InputCheckbox : CheckEdit, IShInput, IShKeyPress, ITextChange
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
        /// Clear Form
        /// </summary>
        public void Clear()
        {
            // System.Windows.Forms.Design.AnchorEditor
            this.Checked = false;
        }

        /// <summary>
        /// Thiết lập giá trị cho checkbox
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            this.Checked = value != null && bool.Parse(value.ToString());
        }

        /// <summary>
        /// Lấy giá trị của CheckBox
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return this.Checked;
        }

        /// <summary>
        /// Phím mặc định
        /// </summary>       
        public Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
            this.Checked = !this.Checked;
        }
    }
}