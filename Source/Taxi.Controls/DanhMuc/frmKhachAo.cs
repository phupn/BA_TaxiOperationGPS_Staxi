using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmKhachAo: FormBase
    {
        private DanhBaKhachAo mKhachAo;
        private bool mIsAdd = false;
        public bool IsSuccess = false;

        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public frmKhachAo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        public frmKhachAo(DanhBaKhachAo  KhachAo, bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới khách ảo";
            }
            else
            {
                this.Text = "Sửa đổi thông tin khách ảo";
                editSoDienThoai.Enabled  = false ;
            }
            mKhachAo = KhachAo;
             
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            SetKhachAo(mKhachAo); 
        }


        private void SetKhachAo(DanhBaKhachAo KhachAo)
        {
            editSoDienThoai.Text  = KhachAo.PhoneNumber;
            editTen.Text  = KhachAo.Name;
            editDiaChi.Text  = KhachAo.Address;
        }

        public DanhBaKhachAo GetKhachAo()
        {
            mKhachAo.PhoneNumber  = StringTools.TrimSpace (editSoDienThoai.Text);
            mKhachAo.Name = StringTools.TrimSpace (editTen.Text);
            mKhachAo.Address = StringTools.TrimSpace (editDiaChi.Text);
            return mKhachAo;
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

                this.GetKhachAo();
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}