using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmKhachVIP : Form
    {
        private KhachVIP mKhachVIP;
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public frmKhachVIP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương KhachVIP, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="KhachVIP"></param>
        /// <param name="boolAdd"></param>
        public frmKhachVIP(KhachVIP  KhachVIP , bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới đối tác";
            }
            else
            {
                this.Text = "Sửa đổi thông tin đối tác";
            }

            mKhachVIP = KhachVIP;
        }
        private void frmKhachVIP_Load(object sender, EventArgs e)
        {
            SetKhachVIP(mKhachVIP);
        }
        private void SetKhachVIP(KhachVIP KhachVIP)
        {
            editMaKhachVIP.Text = KhachVIP.MaKhachVIP;
            editName.Text = KhachVIP.Name;
            editAddress.Text = KhachVIP.Address;
            editPhones.Text = KhachVIP.Phones;
            editFax.Text = KhachVIP.Fax;
            editEmail.Text = KhachVIP.Email;
           
            editNotes.Text = KhachVIP.Notes;
            chkIsActive.Checked = KhachVIP.IsActive;

        }

        public KhachVIP GetKhachVIP()
        {
            mKhachVIP.Name = editName.Text;
            mKhachVIP.Address = editAddress .Text;
            mKhachVIP.Phones = editPhones .Text;
            mKhachVIP.Fax = editFax.Text;
            mKhachVIP.Email = editEmail.Text;
       
            mKhachVIP.Notes  = editNotes.Text;
            mKhachVIP.IsActive  = chkIsActive.Checked ;            
            return mKhachVIP;
        }


            #region Validate du lieu
        private void editName_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }
        private void editName_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }
        private void editAddress_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin Địa chỉ đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        }
        private void editAddress_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin Địa chỉ đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        }
        private void editPhones_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editPhones.Text).Length <= 0)
                errorProvider.SetError(editPhones, "Trường tin Điện thoại đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editPhones, "");
        }
        private void editPhones_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editPhones.Text).Length <= 0)
                errorProvider.SetError(editPhones, "Trường tin Điện thoại đối tác bắt buộc phải nhập");
            else
                errorProvider.SetError(editPhones, "");
        }

        #endregion Validate du lieu

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((StringTools.TrimSpace(editName.Text).Length <= 0) ||

            (StringTools.TrimSpace(editAddress.Text).Length <= 0) ||

            (StringTools.TrimSpace(editPhones.Text ).Length < 8))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin đầy đủ ở các trường (*).", "Thông báo ",  
                     Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);   return;

            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}