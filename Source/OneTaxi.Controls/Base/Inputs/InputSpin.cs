using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTaxi.Controls.Base.Inputs
{
    public class InputSpin : SpinEdit, IKeyPress
    {
        public System.Windows.Forms.Keys KeyCommand{ get;set;}

        public void DoKeyCommand(object sender)
        {
            this.Focus();
        }
    }
}
