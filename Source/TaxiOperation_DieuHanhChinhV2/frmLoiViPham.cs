using System;
using System.Windows.Forms;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;

namespace TaxiOperation_DieuHanhChinh
{
    public partial class frmLoiViPham : FormBase
    {
        public frmLoiViPham()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (new frmXeViPham().ShowDialog() == DialogResult.OK)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var model = grvLoiViPham.GetFocusedRow() as LoiViPham;          
            if(model!=null&&new frmXeViPham(model).ShowDialog()==DialogResult.OK)
                btnTimKiem.PerformClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
             var model = grvLoiViPham.GetFocusedRow() as LoiViPham;
             if (model != null&&MessageBox.Show("Bạn có muốn xóa không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
             {
                 model.Delete();
                 btnTimKiem.PerformClick();
             }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            grdLoiViPham.DataSource = LoiViPham.Inst.TimKiem(deStart.DateTime, deEnd.DateTime, txtSoXe.Text);
        }

        private void frmLoiViPham_Load(object sender, EventArgs e)
        {
            deStart.EditValue = DateTime.Now.Date;
            deEnd.EditValue = DateTime.Now.Date.AddDays(1).AddMinutes(-1);          
            btnTimKiem.PerformClick();
        }

        private void grdLoiViPham_DoubleClick(object sender, EventArgs e)
        {
            var model = grvLoiViPham.GetFocusedRow() as LoiViPham;
            if (model != null && new frmXeViPham(model).ShowDialog() ==DialogResult.OK)
                btnTimKiem.PerformClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    btnTimKiem.PerformClick();
                    return true;
                case Keys.F2:
                    btnThem.PerformClick();
                    return true;
                case Keys.F3:
                    btnSua.PerformClick();
                    return true;
                case Keys.F4:
                    btnXoa.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
