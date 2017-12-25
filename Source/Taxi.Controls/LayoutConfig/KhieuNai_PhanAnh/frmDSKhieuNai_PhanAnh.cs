using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taxi.Controls.KhieuNai_PhanAnh
{
    public partial class frmDSKhieuNai_PhanAnh : Form
    {
        public frmDSKhieuNai_PhanAnh()
        {
            InitializeComponent();
        }

        private void frmDSKhieuNai_PhanAnh_Load(object sender, EventArgs e)
        {
            ctrlDSKhieuNai1.LoadPhanAnh_ChuaGiaiQuyet(0);
        }
    }
}
