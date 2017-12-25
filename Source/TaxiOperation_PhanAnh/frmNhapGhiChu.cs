using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business.ThongTinPhanAnh;

namespace Taxi.GUI
{
    public partial class frmGhiChu : Form
    {
        private long  id = 0;
        private string ghiChu = string.Empty;

        public frmGhiChu()
        {
            InitializeComponent(); 
             
        }

        public frmGhiChu(long  ID )
        {
            InitializeComponent(); 
            this.id = ID;
            this.ghiChu = ThongTinPhanAnh.GetGhiChu(ID);
            txtTenGara.Text = this.ghiChu;
        } 
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ghiChu = StringTools.TrimSpace(txtTenGara.Text);
            if (ghiChu.Length <= 0)
            {

                new MessageBox.MessageBox().Show(this, "Bạn phải nhập ghi chú.", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (ThongTinPhanAnh.UpdateGhiChu(id, ghiChu))
                {
                    new MessageBox.MessageBox().Show(this, "Nhập ghi chú thành công.", "Thông báo",
                   Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    new MessageBox.MessageBox().Show(this, "Lỗi nhập ghi chú.", "Thông báo",
                  Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel ;
                }
            }
             
            this.Close();
        }
    }
}