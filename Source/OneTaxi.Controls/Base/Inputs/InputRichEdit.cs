using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace OneTaxi.Controls.Base.Inputs
{
    public class InputRichEdit : RichEditControl, IInput, IKeyPress, ITextChange
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
            this.HtmlText = string.Empty;
        }

        public void SetValue(object value)
        {
            this.HtmlText = value.ToString();
        }

        public object GetValue()
        {
            return this.HtmlText;
        }

        public Keys KeyCommand { get; set; }

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}