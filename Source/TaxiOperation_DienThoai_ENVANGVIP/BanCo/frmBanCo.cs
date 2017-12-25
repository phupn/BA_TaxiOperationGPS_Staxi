using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Controls.BanCo;

namespace TaxiApplication.BanCo
{
    public partial class frmBanCo : Form
    {
        private Control_DieuHanhBanCo_BanCo _controlDieuHanhBanCoBanCo;
        public frmBanCo()
        {
            InitializeComponent();
        }

        private void frmBanCo_Load(object sender, EventArgs e)
        {
            ReloadControlBanCo();

        }

        public void ReloadControlBanCo()
        {
            try
            {

                if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                panel_BanCo.Controls.Clear();
                System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
                int MaxWidth = 85;
                int MaxHeightCell = 20;

                if (Screen.PrimaryScreen.WorkingArea.Width >= 1360)
                {
                    MaxWidth = 250;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width >= 1280)
                {
                    MaxWidth = 220;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width >= 1024)
                {
                    MaxWidth = 180;
                    MaxHeightCell = 20;
                }
                else if (Screen.PrimaryScreen.WorkingArea.Width < 1024)
                {
                    MaxWidth = 100;
                    MaxHeightCell = 17;
                }
                _controlDieuHanhBanCoBanCo = new Control_DieuHanhBanCo_BanCo()
                {
                    Dock = DockStyle.Fill,
                    MinWidthVung = 90,
                    MaxWidthVung = MaxWidth,
                    HeighVung = 116,
                    HeighCell = MaxHeightCell,
                    IsBanCo = true

                };
                //control_DieuHanhBanCo_BanCo.ShowHienTrangXe += control_DieuHanhBanCo_BanCo_ShowHienTrangXe;
                //control_DieuHanhBanCo_BanCo.HideHienTrangXe += control_DieuHanhBanCo_BanCo_HideHienTrangXe;
                //control_DieuHanhBanCo_BanCo1.TimXeTrenBanDo += control_DieuHanhBanCo_BanCo_TimXeTrenBanDo;
                //control_DieuHanhBanCo_BanCo1.VungDieuHanhTrong += control_DieuHanhBanCo_BanCo_VungDieuHanhTrong;
                panel_BanCo.Controls.Add(_controlDieuHanhBanCoBanCo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ReloadControlBanCo " + ex.Message);
            }
        }

        private void FrmBanCo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _controlDieuHanhBanCoBanCo.Stop();
            _controlDieuHanhBanCoBanCo.Dispose();
        }

        private bool _flgTimXe = false;
        private void txtSoXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                _controlDieuHanhBanCoBanCo.TimXe(txtSoXe.Text);
                _flgTimXe = true;
            }
            if (e.KeyData == Keys.Escape)
            {
                _flgTimXe = false;
                txtSoXe.Text = "";
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_flgTimXe)
            {
                if (keyData == Keys.Escape)
                {
                    txtSoXe.Text = "";
                    txtSoXe.Focus();
                    _flgTimXe = false;
                    return false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
