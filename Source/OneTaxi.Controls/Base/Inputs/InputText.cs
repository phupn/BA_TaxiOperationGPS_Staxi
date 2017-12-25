using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.ComponentModel;

namespace OneTaxi.Controls.Base.Inputs
{
    /// <summary>
    /// Control nhập Text
    /// </summary>
    public class InputText : TextEdit, IInput, IKeyPress, ITextChange
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
            this.Text = string.Empty;
        }


        /// <summary>
        /// Thiết lập giá trị
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            // this.Text = value == null ? string.Empty : value.ToString();
            this.EditValue = value;
        }

        /// <summary>
        /// Lấy ra giá trị
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            //return this.Text.Trim();
            return this.EditValue == null ? null : EditValue.ToString().Trim();
        }

        [DefaultValue(Keys.None)]
        public Keys KeyCommand { set; get; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}