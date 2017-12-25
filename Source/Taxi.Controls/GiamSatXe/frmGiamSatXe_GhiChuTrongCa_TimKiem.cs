using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace TaxiOperation_BanCo.GiamSatXe
{
    public partial class frmGiamSatXe_GhiChuTrongCa_TimKiem : FormBase
    {
        public DataTable data;
        private GiamSatXe_ShiftNotes de = new GiamSatXe_ShiftNotes();
        public frmGiamSatXe_GhiChuTrongCa_TimKiem(string ca)
        {
            InitializeComponent();
            txtNgay.Properties.MaxValue = DateTime.Today.AddDays(1);
            txtNgay.EditValue = DateTime.Today;
            cbCa.Properties.Items.Insert(0, "Tất cả");
            cbCa.EditValue = ca;
        }

        private void frmGiamSatXe_GhiChuTrongCa_TimKiem_Load(object sender, EventArgs e)
        {

        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            data = de.Find(txtNgay.DateTime, cbCa.SelectedIndex.ToString());
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!txtNgay.IsPopupOpen)
                {
                    cbCa.Focus();
                }
            }
        }

        private void cbCa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (!cbCa.IsPopupOpen)
                {
                    btnTimKiem.Focus();
                }
            }
        }
    }
}