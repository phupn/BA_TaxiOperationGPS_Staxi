using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.Controls.Maps
{
    public partial class FrmBanDo_Online : Form
    {
        public FrmBanDo_Online()
        {
            InitializeComponent();
        }

        private void FrmBanDo_Online_Load(object sender, EventArgs e)
        {
            if (Config_Common.MapOnline) 
                gMaps1.StartTimerLoadMap();
        }

        private void FrmBanDo_Online_FormClosing(object sender, FormClosingEventArgs e)
        {
            gMaps1.isLoadSuccess = false;
        }

    }
}
