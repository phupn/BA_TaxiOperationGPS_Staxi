using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taxi.GUI
{
    public partial class frmCall : Form
    {
        private string COMPortName = "";

        public frmCall()
        {
            InitializeComponent();
        }
        
        public frmCall(string COMPort)
        {
            this.COMPortName = COMPort;
            InitializeComponent();
        }

        private void frmCall_Load(object sender, EventArgs e)
        {
            this.ctrlGoiSo1.SetPortName(this.COMPortName);
        }
    }
}