using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.AutoUpdate;
using Taxi.Controls.Base;

namespace Taxi.Controls
{
    public partial class frmNotifyAutoUpdate : FormBase
    {

        public bool IsNoUpdate = false;
        public frmNotifyAutoUpdate()
        {
            InitializeComponent();
        }

        public void SetMessage(string version)
        {
            txtVer.Text = version;
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            IsNoUpdate = true;
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            AutoUpdate.Inst.IsUpdate = true;
            Application.Restart();
        }

        private void frmNotifyAutoUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
