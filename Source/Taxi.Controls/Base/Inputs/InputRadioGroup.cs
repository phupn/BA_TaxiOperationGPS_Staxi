using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Windows.Forms;

namespace Taxi.Controls.Base.Inputs
{
    /// <summary>
    /// Mở rộng RadioGroup
    /// </summary>
    public class InputRadioGroup : RadioGroup, IShInput, ITextChange
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
        /// Clear
        /// </summary>
        public void Clear()
        {
            this.Reset();
        }

        /// <summary>
        /// Set Value
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(object value)
        {
            this.EditValue = value;
        }

        /// <summary>
        /// Get Value
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            return this.EditValue;
        }

        /// <summary>
        /// Chuyển nút tab thành lựa chọn item
        /// </summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (this.SelectedIndex < this.Properties.Items.Count - 1)
                {
                    this.SelectedIndex++;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
