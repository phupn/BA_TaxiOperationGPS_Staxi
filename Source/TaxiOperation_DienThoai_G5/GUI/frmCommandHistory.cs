using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaxiApplication.GUI
{
    public partial class frmCommandHistory : Form
    {
        public frmCommandHistory()
        {
            InitializeComponent();
        }
        public frmCommandHistory(long IdCuocGoi, string info)
        {
            InitializeComponent();
            ctrlListCommandHistory.Id = IdCuocGoi;
            ctrlListCommandHistory.Info = info;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
