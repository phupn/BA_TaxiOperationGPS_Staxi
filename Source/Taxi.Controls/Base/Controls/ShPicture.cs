using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Controls.Base.Inputs;

namespace Taxi.Controls.Base.Controls
{
    public class ShPicture : PictureEdit,IShKeyPress
    {
        [DefaultValue(Keys.None)]
        public Keys KeyCommand{get; set; }

        public void DoKeyCommand(object sender)
        {
            if (!DesignMode &&this.Visible && this.Enabled) this.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
