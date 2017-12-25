using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Taxi.Controls.Base.Inputs
{
    public class InputButtonEdit : ButtonEdit, IShInput, IShKeyPress, ITextChange
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
            EditValue = null;
        }

        public void SetValue(object value)
        {
            EditValue = value;
        }

        public object GetValue()
        {
            return EditValue;
        }

        public Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            //if(((InputButtonEdit)(sender)).Focused)
            this.Focus();
        }
    }
}