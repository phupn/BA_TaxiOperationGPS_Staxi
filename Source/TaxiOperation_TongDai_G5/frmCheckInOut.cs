using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmCheckInOut : Form
    {        
        public frmCheckInOut()
        {
            InitializeComponent();
        }
        public void ShowCheckin()
        {
            
        }

        private void frmCheckInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctrlCheckInCheckOut.frmCheckInOut_FormClosing(sender, e);
        }

        private void frmCheckInOut_Load(object sender, EventArgs e)
        {
            ctrlCheckInCheckOut.ShowCheckIn();
        }

    }
}