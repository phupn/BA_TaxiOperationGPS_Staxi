using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace OneTaxi.Controls.Base.Inputs
{
    public class InputImageComboBox : ImageComboBoxEdit, IInput, ITextChange
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

        public void Clear()
        {
            this.EditValue = 0;
        }

        public void SetValue(object value)
        {
            this.EditValue = value;
        }

        public object GetValue()
        {
            return this.EditValue;
        }
    }
}
