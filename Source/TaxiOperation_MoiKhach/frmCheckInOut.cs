using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmCheckInOut : Form
    {
        private int g_SoLan = 0;
        private bool g_Success = false;
        public frmCheckInOut()
        {
            InitializeComponent();
        }

        private void frmCheckInOut_Load(object sender, EventArgs e)
        {
            lblNguoiLamViecTruoc.Text = ThongTinDangNhap.GetThongTinDangNhapCuaMayNay();   
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
                    new Taxi.MessageBox.MessageBoxBA().Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                    return;
                }
                // Kiểm tra xem có đăng nhập được không
                if (ThongTinDangNhap.ValidateLogin(strUserName, strPassword))
                {
                    g_Success = true;
                    // goi den form chinh
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    g_SoLan++;
                    new Taxi.MessageBox.MessageBoxBA().Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                    if(g_SoLan>=3) Application.Exit ();
                }

            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Stop);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
    }
}