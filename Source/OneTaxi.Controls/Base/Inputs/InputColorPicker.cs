using DevExpress.XtraEditors;
using System.Drawing;

namespace OneTaxi.Controls.Base.Inputs
{

    public class InputColorPicker : ColorEdit, IInput, ITextChange
    {
        public bool IsChangeText { get; set; }
        public bool IsForceChangeText { get; private set; }
        public bool IsFocus { get; set; }
        public bool GetText { get; set; }

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
            this.EditValue = null;
        }

        public void SetValue(object value)
        {
            if (value is Color)
                this.EditValue = value;
            else if (value is string)
                this.EditValue = Color.FromName(value.ToString());
            else if (value is int)
                this.EditValue = Color.FromArgb((int)value);
        }

        public object GetValue()
        {
           
            if (GetText) {
                var col = (Color?)this.EditValue;
                return col == null || col.Value.IsEmpty || col.Value==Color.Transparent ? null : col.Value.Name;
            }
            else
            {

                var col = (Color?)this.EditValue;
                return col == null || col.Value.IsEmpty ? null : col;
            }
        }
    }
}