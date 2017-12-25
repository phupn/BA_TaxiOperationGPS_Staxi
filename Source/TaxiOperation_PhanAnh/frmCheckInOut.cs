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
                    new Taxi.MessageBox.MessageBox().Show("Bạn phải nhập tên đăng nhập", "Thông báo");
                    return;
                }
                // Kiểm tra xem có đăng nhập được không
                if (ThongTinDangNhap.ValidateLogin(strUserName, strPassword))
                {                    
                    // goi den form chinh
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    g_SoLan++;
                    new Taxi.MessageBox.MessageBox().Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                    if(g_SoLan>=3) Application.Exit ();
                }

            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBox().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Stop);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            
        }
         
    }
}