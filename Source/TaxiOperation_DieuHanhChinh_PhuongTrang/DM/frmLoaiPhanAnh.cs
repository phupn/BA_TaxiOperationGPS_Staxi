using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.DM;
using Taxi.Business;
namespace TaxiOperation_DieuHanhChinh.DM
{
    public partial class frmLoaiPhanAnh : Form
    {
        private int _id;
        private string _tenPhanAnh;
        private string _user;
       
               
        public frmLoaiPhanAnh()
        {
            InitializeComponent();
            _id = 0;
            _tenPhanAnh = string.Empty ;
            _user = string.Empty;

        }
        public frmLoaiPhanAnh(int id, string tenPhanAnh, string user)
        {
            InitializeComponent();
            _id = id;
            _tenPhanAnh = tenPhanAnh;
            _user  = user;
            txtTenPhanAnh.Text = tenPhanAnh;
        }
        private void frmLoaiPhanAnh_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTenPhanAnh;
            txtTenPhanAnh.Focus();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(txtTenPhanAnh.Text).Length <= 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại phản ánh", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (LoaiPhanAnh.CheckTen(StringTools.TrimSpace(txtTenPhanAnh.Text)))
            {
                MessageBox.Show("Tên loại phản ánh này đã tồn tại. Hãy nhập tên khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoaiPhanAnh objPhanAnh = new LoaiPhanAnh(this._id, StringTools.TrimSpace(txtTenPhanAnh.Text), ThongTinDangNhap.USER_ID );
                if (_id > 0) // ton tai Id ==> update
                {
                    if (objPhanAnh.Update())
                    {
                        MessageBox.Show("Cập nhật loại phản ánh thành công ", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật loại phản ánh bị lỗi ", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // id chua co nen them moi
                {
                    if (objPhanAnh.Insert())
                    {
                        MessageBox.Show("Thêm mới loại phản ánh thành công ", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới loại phản ánh bị lỗi ", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Xu li mui ten

        private void txtTenPhanAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                this.btnLuu_Click(sender, new EventArgs());
            }
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down )
            {
                this.btnHuy.Focus();
            }
        }

        #endregion

        #region XU li hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Escape )
            {
                this.Close();
                return true;
            }
            return false;
        }

        #endregion
    }
}