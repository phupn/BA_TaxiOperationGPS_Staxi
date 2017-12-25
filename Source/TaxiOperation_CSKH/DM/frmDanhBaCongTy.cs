using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmDanhBaCongTy: Form
    {
        private DanhBaCongTy mDanhBaCongTy;
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public frmDanhBaCongTy()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmDanhBaCongTy(DanhBaCongTy DanhBaCongTy, bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới danh bạ công ty";
            }
            else
            {
                this.Text = "Sửa đổi thông tin danh bạ công ty";
                editSoDienThoai.Enabled  = false ;
            }
            mDanhBaCongTy = DanhBaCongTy;
             
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            SetDanhBaCongTy(mDanhBaCongTy); 
        }


        private void SetDanhBaCongTy(DanhBaCongTy DanhBaCongTy)
        {
            editSoDienThoai.Text  = DanhBaCongTy.PhoneNumber;
            editTen .Text  = DanhBaCongTy.Name;
             editDiaChi .Text  = DanhBaCongTy.Address;
        }

        public DanhBaCongTy GetDanhBaCongTy()
        {

            mDanhBaCongTy.PhoneNumber  = StringTools.TrimSpace (editSoDienThoai.Text);
            mDanhBaCongTy.Name = StringTools.TrimSpace (editTen.Text);
            mDanhBaCongTy.Address = StringTools.TrimSpace (editDiaChi.Text);


            return mDanhBaCongTy;
        }


            #region Validate du lieu

               
        #endregion Validate du lieu


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editSoDienThoai.Text).Length < 8)
            {
                new MessageBox.MessageBoxBA().Show("Điện thoại phải lớn hơn 8 số");
                return;
            }

            if (StringTools.TrimSpace(editTen.Text).Length <=0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin trường [Tên]của số điện thoại.");
                return;
            }
            if (StringTools.TrimSpace(editDiaChi.Text).Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin trường [Địa chỉ] của số điện thoại.");
                return;
            }
            this.GetDanhBaCongTy();
            this.Close();
        }

        private void frmXe_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

  
       
    }
}