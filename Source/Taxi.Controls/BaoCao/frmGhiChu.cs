using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Data.G5.BaoCao;

namespace Taxi.Controls.BaoCao
{
    public partial class frmGhiChu : Form
    {
        public string ID = string.Empty;
        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID))
            {
                new bc_1_3_BaoCaoChiTietCuocGoiDen().CapNhatGhiChu(txtGhiChu.Text,ID);
                this.Close();
            }
        }
    }
}
