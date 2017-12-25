using System;
using Taxi.Controls.Base;

namespace Taxi.Controls.FastTaxis.CuocAppKH
{
    public partial class FrmCuocAppKH : FormBase
    {
        public FrmCuocAppKH()
        {
            InitializeComponent();
        }

        private void FrmCuocAppKH_Load(object sender, EventArgs e)
        {
            uc_CuocAppKH1.Start();
        }

    }
}
