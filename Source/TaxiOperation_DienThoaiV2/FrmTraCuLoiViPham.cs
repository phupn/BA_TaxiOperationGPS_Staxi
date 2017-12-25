using System;
using Taxi.Controls.Base;
using Taxi.Data.FastTaxi;

namespace TaxiApplication
{
    public partial class FrmTraCuLoiViPham : FormBase
    {
        public FrmTraCuLoiViPham()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblMsg.Text =string.Empty;
            try
            {
                grdLoiViPham.DataSource = LoiViPham.Inst.TimKiem(deStart.DateTime, deEnd.DateTime, txtSoXe.Text);
                if (grvLoiViPham.RowCount == 0)
                {
                    lblMsg.Text = "Không tìm thấy";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        private void FrmTraCuLoiViPham_Load(object sender, EventArgs e)
        {
            deStart.EditValue = DateTime.Now.Date;
            deEnd.EditValue = DateTime.Now;
        }
    }
}
