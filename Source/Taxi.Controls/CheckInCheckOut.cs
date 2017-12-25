using System;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.Controls
{
    public partial class CheckInCheckOut : UserControl
    {
        Timer G_Timer = new Timer();
        public CheckInCheckOut()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                //pnlWelcome.Visible = true;
                lblNguoiLamViecTruoc.Text = ThongTinDangNhap.GetThongTinDangNhapCuaMayNay();
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    txtMatKhau.Text = "123123";
                    txtTenDangNhap.Text = "admin";
                }
                G_Timer.Tick += G_Timer_Tick;
            }
        }

        void G_Timer_Tick(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CheckInCheckOut tick", ex);
            }
        }
        private int g_SoLan = 0;
        public bool g_Success { get; set; }
        DialogResult g_DialogResult { get { return g_Success == true ? DialogResult.OK : DialogResult.Cancel; } }

        public void ShowCheckIn()
        {
            //pnlWelcome.Visible = false;
            //System.Threading.Tasks.Task.Factory.StartNew(() =>
            //        {
            //            Application.DoEvents();
            //        });
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
                    g_Success = true;
                    // goi den form chinh
                    this.ParentForm.DialogResult = DialogResult.OK;
                    this.ParentForm.Close();
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
                g_Success = false;
                new MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Stop);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
            g_Success = false;
            Application.Exit();
        }

        public void frmCheckInOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!g_Success)
            {
                this.ParentForm.DialogResult = DialogResult.Cancel;
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                    Application.Exit();
                    return true;
                case Keys.Enter:
                    btnCheckIn_Click(null, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
