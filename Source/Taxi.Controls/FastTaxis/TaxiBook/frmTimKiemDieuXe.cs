using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Common.Extender;

namespace Taxi.Controls.FastTaxis.TaxiDieuXe
{
    public partial class frmTimKiemDieuXe : Form
    {
        public frmTimKiemDieuXe()
        {
            InitializeComponent();
        }

        public string SoXe { get; set; }
        public string SoDT { get; set; }
        public string TenKH { get; set; }
        public int TinhID { get; set; }
        public DateTime NgayDon { get; set; }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SoXe = txtSoXe.Text;
            SoDT = txtSoDT.Text;
            TenKH = txtTenKH.Text;
            TinhID = txtTinhDon.EditValue.To<int>();
            NgayDon = txtNgayDon.EditValue.To<DateTime>();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
