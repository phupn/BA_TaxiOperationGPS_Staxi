using System;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmDSNhanVien : Form
    {
        public frmDSNhanVien()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDSNhanVien_Load);
        }

        private void frmDSNhanVien_Load(object sender, EventArgs e)
        {
            ucDSLaiXe1.SetListNhanVien(CommonBL.ListDriver_Active);
        }
    }
}