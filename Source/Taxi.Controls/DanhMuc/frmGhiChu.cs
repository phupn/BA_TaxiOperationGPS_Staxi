using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.QuanTri;
using Taxi.Controls.Base;
using Taxi.Data;

namespace Taxi.Controls
{
    public partial class frmGhiChu : FormBase
    {
        #region==Form events==
        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {
            txtNoiDung.Focus();
            txtNoiDung.Select();
            this.Activate();
        }
        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            Msg msg = new Msg();
            msg.Subject = txtTieuDe.Text.Trim();
            txtNoiDung.Text = txtNoiDung.Text.Trim();
            msg.Contents = txtNoiDung.Text;
            msg.Date = Taxi.Business.DieuHanhTaxi.GetTimeServer();
            msg.UserName = ThongTinDangNhap.USER_ID;
            msg.IPAddress = QuanTriCauHinh.GetIPPC();
            try
            {
                if (String.IsNullOrEmpty(msg.Contents))
                {
                    System.Windows.Forms.MessageBox.Show("Nội dung không được để trống", "Thông báo");
                    txtNoiDung.Focus();
                }
                else
                {
                    msg.Save();
                    this.Close();
                }
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Có lỗi, cập nhật không thành công", "Thông báo");
            }
        }
        int flgNoiDung = 2;
        bool flgKeyEnter = false;
        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flgKeyEnter = true;
                flgNoiDung--;

                if (flgNoiDung <= 0)
                {
                    btnThem.PerformClick();
                }
               
            }
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            if (!flgKeyEnter)
            {
                flgNoiDung = 2;
            }
        }

        private void txtNoiDung_KeyUp(object sender, KeyEventArgs e)
        {
            flgKeyEnter = false;
        }

        private void btnThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
