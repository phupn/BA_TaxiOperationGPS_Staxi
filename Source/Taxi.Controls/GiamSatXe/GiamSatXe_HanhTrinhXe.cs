using System.Windows.Forms;
using System.Data;
using System;
using System.ComponentModel;
using Taxi.Data.BanCo.Entity.GiamSatXe;

namespace TaxiOperation_BanCo.Controls.GiamSatXe
{
    public partial class GiamSatXe_HanhTrinhXe : UserControl
    {
        #region ======= ini form =====
        public GiamSatXe_HanhTrinhXe()
        {
            InitializeComponent();
            if (!DesignMode && LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                lienlac = new GiamSatXe_LienLac();
                grvHanhTrinhXe.IndicatorWidth = 30;
                dateThoiGian.EditValue = DateTime.Today;
            }
        }
        #endregion

        #region  ======= các biến toàn cục =======
        private GiamSatXe_LienLac lienlac = null;
        #endregion

        #region ======= Event  =======

        private void grvHanhTrinhXe_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dateThoiGian.EditValue == null) { lblmsg.Text = ("Bạn chưa chọn ngày"); return; }
            if (txtSoHieu.Text.Trim() == "") { lblmsg.Text = ("Bạn chưa nhập số hiệu"); return; }
            DataTable dt = lienlac.GetHanhTrinhXe(dateThoiGian.DateTime, txtSoHieu.Text);
            //if (dt == null || dt.Rows.Count == 0) { lblmsg.Text = ("Không tìm thấy hành trình xe"); }
            grcHanhTrinhXe.DataSource = dt;
            grcHanhTrinhXe.Update();
        }
        #region Xử lý dấu cách của textbox SoHieu

        private void txtSoHieu_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.TrimStart();
        }

        private void txtSoHieu_Properties_KeyDown(object sender, KeyEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.TrimStart();
            if (e.KeyData == Keys.Enter)
            {
                btnTimKiem_Click(null, null);
            }
            else
                lblmsg.Text = "";
        }

        private void txtSoHieu_Properties_KeyUp(object sender, KeyEventArgs e)
        {
            txtSoHieu.Text = txtSoHieu.Text.TrimStart();
        }
        #endregion

        private void txtSoHieu_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
