using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmTinhTienTheoKmCP : Form
    {
        
        public frmTinhTienTheoKmCP()
        {
            InitializeComponent();
        }

        private void frmTinhTienTheoKm_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}