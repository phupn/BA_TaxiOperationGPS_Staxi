using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;
using DanhBaCongTy = Taxi.Business.DanhBaCongTy;

namespace Taxi.GUI
{
    public partial class frmDanhBaCongTy: FormBase
    {
        #region Khởi tạo và khai báo

        public  bool IsSuccess = false;
        private DanhBaCongTy mDanhBaCongTy;
        private bool _isAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return _isAdd; }           
        }
        
        public frmDanhBaCongTy()
        {
            InitializeComponent();
        }


        // Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        public frmDanhBaCongTy(DanhBaCongTy DanhBaCongTy, bool boolAdd)
        {
            InitializeComponent();
            _isAdd = boolAdd;
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

        #endregion

        #region Methods

        private void SetDanhBaCongTy(DanhBaCongTy DanhBaCongTy)
        {
            editSoDienThoai.Text = DanhBaCongTy.PhoneNumber;
            editTen.Text = DanhBaCongTy.Name;
            editDiaChi.Text = DanhBaCongTy.Address;
        }

        public DanhBaCongTy GetDanhBaCongTy()
        {
            try
            {
                mDanhBaCongTy.PhoneNumber = StringTools.TrimSpace(editSoDienThoai.Text);
                mDanhBaCongTy.Name = StringTools.TrimSpace(editTen.Text);
                mDanhBaCongTy.Address = StringTools.TrimSpace(editDiaChi.Text);
                return mDanhBaCongTy;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("GetDanhBaCongTy: ", ex);
                return new DanhBaCongTy();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    btnSave.PerformClick();                  
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Events!
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            SetDanhBaCongTy(mDanhBaCongTy); 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IsSuccess = false;
                if (StringTools.TrimSpace(editSoDienThoai.Text).Length < 8)
                {
                    new MessageBox.MessageBoxBA().Show("Điện thoại phải lớn hơn 8 số");
                    return;
                }

                if (StringTools.TrimSpace(editTen.Text).Length <= 0)
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
                IsSuccess = true;
                this.Close();
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnSave_Click: ", ex);                
            }
        }
        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}