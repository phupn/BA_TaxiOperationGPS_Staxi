using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace TaxiApplication.GUI
{
    public partial class ConfigLine : FormBase
    {
        public ConfigLine()
        {
            InitializeComponent();
        }

        private void ConfigLine_Load(object sender, EventArgs e)
        {
            lblLineConfig.Text = Global.LineDuocCapPhep;
            txtLine.Text = Global.LineDuocCapPhep;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtLine.Text = Taxi.Business.ThongTinCauHinh.CacLineCuaTaxiOperation;
            SaveLine();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLine();
        }

        private void SaveLine()
        {
            Global.LineDuocCapPhep = txtLine.Text.Trim();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtLine.Text = Global.LineDuocCapPhep_MacDinh;
            SaveLine();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
