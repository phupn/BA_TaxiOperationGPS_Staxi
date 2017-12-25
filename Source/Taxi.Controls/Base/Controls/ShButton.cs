using DevExpress.XtraEditors;
using System.ComponentModel;
using Taxi.Controls.Base.Inputs;
using System.Windows.Forms;
using System;

namespace Taxi.Controls.Base.Controls
{
    /// <summary>
    /// Kế thừa Button
    /// </summary>
    public class ShButton : SimpleButton, IShKeyPress
    {
        [DefaultValue(Keys.None)]
        public Keys KeyCommand
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public void DoKeyCommand(object sender)
        {
            if (this.Visible && this.Enabled) this.InvokeOnClick(this, EventArgs.Empty);
        }
    }

    // DevExpress.XtraEditors.SimpleButton
    // Taxi.Controls.Base.Controls.ShButton
}
