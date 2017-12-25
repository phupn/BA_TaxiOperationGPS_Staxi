using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmTimKiemXeThueBao : Form
    {
       
        public frmTimKiemXeThueBao()
        {
            InitializeComponent();
        }

        public DateTime TuNgay()
        {
            return calTuNgay.Value;
        }
        public DateTime DenNgay()
        {
            return calDenNgay.Value;
        }

        public string SoHieuXe()
        {
            return StringTools.TrimSpace(txtSoHieuXe.Text);
        }

        private void frmTimKiemXeThueBao_Load(object sender, EventArgs e)
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Value = timeServer.Subtract(new TimeSpan(4, 0, 0, 0, 0));
            calDenNgay.Value = timeServer;
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