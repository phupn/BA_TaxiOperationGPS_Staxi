using System;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmCheckInOut : Form
    {
        private int g_SoLan = 0;
        private bool g_Success = false;
        public bool IsDieuSanBay = false;
        private bool IsTruongCa = false;
        private bool IsUserDieuSb = false;
        public frmCheckInOut()
        {
            InitializeComponent();
        }

        private void frmCheckInOut_Load(object sender, EventArgs e)
        {
            try
            {
                lblNguoiLamViecTruoc.Text = ThongTinDangNhap.GetThongTinDangNhapCuaMayNay();
                if (Config_Common.DieuSanBay != 0)
                {
                    string userName = CheckUserDieuSanBay();
                    if (userName == null)
                    {
                        IsUserDieuSb = false;
                        lblmsg.Text = "Chưa có nhân viên nào điều sân bay.";
                        chkDieuCuocSanBay.Visible = true;
                    }
                    else
                    {
                        IsUserDieuSb = true;
                        lblmsg.Text = userName + ": đang điều sân bay";
                        lblmsg.Location = chkDieuCuocSanBay.Location;
                        chkDieuCuocSanBay.Visible = false;
                    }
                }
                else
                {
                    lblmsg.Text = "";
                    chkDieuCuocSanBay.Visible = false;
                    IsDieuSanBay = false;
                    IsUserDieuSb = false;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("frmCheckInOut_Load: ",ex);                
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin về username và password người dùng nhập vào
                string strUserName = txtTenDangNhap.Text.Trim();
                string strPassword = txtMatKhau.Text.Trim();

                // Kiểm tra xem có nhập username hay không
                if (strUserName.Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                    txtTenDangNhap.Focus();
                    return;
                }
                else if (strPassword.Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập mật khẩu", "Thông báo");
                    txtMatKhau.Focus();
                    return;
                }
                // Kiểm tra xem có đăng nhập được không
                if (ThongTinDangNhap.ValidateLogin(strUserName, strPassword))
                {
                    if (IsUserDieuSb)
                    {
                        IsDieuSanBay = false;                        
                    }
                    else
                    {
                        if (chkDieuCuocSanBay.Checked)
                        {
                            IsDieuSanBay = true;
                        }
                        else
                        {
                            IsDieuSanBay = false;
                        }
                    }
                    g_Success = true;
                    // goi den form chinh
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    g_SoLan++;
                    new MessageBox.MessageBoxBA().Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                    txtTenDangNhap.Focus();
                    if (g_SoLan >= 3) Application.Exit();
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Stop);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            Application.Exit();
        }

        private void frmCheckInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!g_Success)
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtTenDangNhap.Focus();
            }
        }
        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (Config_Common.DieuSanBay !=0)
            {
                IsTruongCa = CheckTruongCa(txtTenDangNhap.Text.Trim());
                if (!IsUserDieuSb && IsTruongCa)
                {
                    chkDieuCuocSanBay.Checked = true;
                }
                else
                {
                    chkDieuCuocSanBay.Checked = false;
                }
            }
        }
        #region=== Điều cuốc sân bay ===
        private bool CheckTruongCa(string userId)
        {
            return ThongTinDangNhap.CheckTruongCa(userId);
        }

        /// <summary>
        /// Kiểm tra có user nào đang điều sân bay không chỉ cho phép 1 user được điều sân bay tại 1 thời điểm
        /// </summary>
        private string CheckUserDieuSanBay()
        {
            return ThongTinDangNhap.CheckUserDieuSanBay();
        }
        #endregion

        private void chkDieuCuocSanBay_CheckedChanged(object sender, EventArgs e)
        {
            IsDieuSanBay = chkDieuCuocSanBay.Checked;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.D))
            {
                chkDieuCuocSanBay.Checked = !chkDieuCuocSanBay.Checked;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}