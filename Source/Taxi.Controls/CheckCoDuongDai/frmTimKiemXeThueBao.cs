using System;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.Controls.FormCheckCoDuongDai
{
    public partial class frmTimKiemXeThueBao : Form
    {
       
        public frmTimKiemXeThueBao()
        {
            InitializeComponent();
        }

        public DateTime TuNgay()
        {
            return calTuNgay.DateTime;
        }
        public DateTime DenNgay()
        {
            return calDenNgay.DateTime;
        }

        public string SoHieuXe()
        {
            return StringTools.TrimSpace(txtSoHieuXe.Text);
        }
        public string NoiDungTimKhac()
        {
            return StringTools.TrimSpace(txtTimKiem.Text);

         }
        private void frmTimKiemXeThueBao_Load(object sender, EventArgs e)
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            calTuNgay.EditValue = timeServer.Subtract(new TimeSpan(4, 0, 0, 0, 0));
            calDenNgay.EditValue = timeServer;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}