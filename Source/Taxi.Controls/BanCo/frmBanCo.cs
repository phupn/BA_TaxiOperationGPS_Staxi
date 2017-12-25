using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Taxi.Data.BanCo.Entity.MasterData;

namespace Taxi.Controls.BanCo
{
    public partial class frmBanCo : Form
    {
        private Control_DieuHanhBanCo_BanCo _controlDieuHanhBanCoBanCo;
        /// <summary>
        /// Vùng điều hành ( điểm đỗ)
        /// </summary>
        private Dictionary<int, Vung> dicVung;
        private Dictionary<int, int> dicVungId_IDGPS;
        private void LoadVungDieuHanh()
        {
            List<VungDieuHanh> lstVungDieuHanh = new VungDieuHanh().GetAllVungDieuHanh();

            this.dicVung = lstVungDieuHanh.Where(t => t.FK_CodeVungGPS != null).OrderBy(t => t.Sort).ToDictionary(t => (int)t.FK_CodeVungGPS, t => new Vung
            {
                Id = t.Id,
                VungGPSID = t.FK_CodeVungGPS == null ? 0 : (int)t.FK_CodeVungGPS.Value,
                MauChu = t.ColorOfVungDH == null ? "" : t.ColorOfVungDH.ToString(),
                Ten = t.NameVungDH == null ? "" : t.NameVungDH.ToString(),
            });
            this.dicVungId_IDGPS = this.dicVung.Values.ToDictionary(t => t.Id, t => t.VungGPSID);
        }
        public frmBanCo()
        {
            InitializeComponent();
        }

        private void frmBanCo_Load(object sender, EventArgs e)
        {
            LoadVungDieuHanh();
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
                    MinWidthVung = 230,
                    MaxWidthVung = MaxWidth,
                    HeighVung = 116,
                    HeighCell = MaxHeightCell,
                    IsBanCo = true,
                    dicVung=this.dicVung,
                    dicVungId_IDGPS=this.dicVungId_IDGPS
                };
                //control_DieuHanhBanCo_BanCo.ShowHienTrangXe += control_DieuHanhBanCo_BanCo_ShowHienTrangXe;
                //control_DieuHanhBanCo_BanCo.HideHienTrangXe += control_DieuHanhBanCo_BanCo_HideHienTrangXe;
                //control_DieuHanhBanCo_BanCo1.TimXeTrenBanDo += control_DieuHanhBanCo_BanCo_TimXeTrenBanDo;
                //control_DieuHanhBanCo_BanCo1.VungDieuHanhTrong += control_DieuHanhBanCo_BanCo_VungDieuHanhTrong;
                panel_BanCo.Controls.Add(_controlDieuHanhBanCoBanCo);
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi ReloadControlBanCo " + ex.Message);
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
