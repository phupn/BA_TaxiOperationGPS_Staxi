using System;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Data.G5.DanhMuc;
using Taxi.Utils;

namespace Taxi.GUI
{
    
    public partial class frmDanhBaCongTy: Form
    {
        private DanhBaCongTy mDanhBaCongTy;
        private bool mIsAdd = false;
        private DanhBa_Type mType;
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
        public frmDanhBaCongTy(DanhBaCongTy DanhBaCongTy, int Type)
        {
            InitializeComponent();
            mIsAdd = Type == 0;
            mType = (DanhBa_Type)Type;
            string Title = "";
            if (mIsAdd)
            {
                Title = "Thêm mới danh bạ ";
                pnlType.Visible = true;
            }
            else
            {
                pnlType.Visible = false;
                Title = "Cập nhật danh bạ ";
                editSoDienThoai.Enabled  = false ;
            }
            if (mType == DanhBa_Type.DanhBaCongTy || mType == DanhBa_Type.None)
            {
                Title += "Công Ty";
                mType = DanhBa_Type.DanhBaCongTy;
                rb_CongTy.Checked = true;
            }
            else if (mType == DanhBa_Type.DanhBaKhachAo)
            {
                Title += "Khách Ảo";
                rb_KhachAo.Checked = true;
            }
            else if (mType == DanhBa_Type.DanhBaKhachHang)
            {
                Title += "Khách Hàng";
                rb_KhachHang.Checked = true;
            }
            else
            {
                rb_CongTy.Checked = true;
            }
            mDanhBaCongTy = DanhBaCongTy;
            Text = Title;
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            SetDanhBaCongTy(mDanhBaCongTy);
            editTen.Focus();
        }

        private void SetDanhBaCongTy(DanhBaCongTy DanhBaCongTy)
        {
            editSoDienThoai.Text  = DanhBaCongTy.PhoneNumber;
            editTen .Text  = DanhBaCongTy.Name;
            editDiaChi .Text  = DanhBaCongTy.Address;
            editTen.Focus();
        }

        public DanhBaCongTy GetDanhBaCongTy()
        {
            mDanhBaCongTy.PhoneNumber  = StringTools.TrimSpace (editSoDienThoai.Text);
            mDanhBaCongTy.Name = StringTools.TrimSpace (editTen.Text);
            mDanhBaCongTy.Address = StringTools.TrimSpace (editDiaChi.Text);
            return mDanhBaCongTy;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editDiaChi.Text).Length <= 0)
            {
                new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin trường [Địa chỉ] của số điện thoại.");
                return;
            }
            this.GetDanhBaCongTy();
            if (mType == DanhBa_Type.DanhBaCongTy)
            {
                SaveCongTy();
            }
            else if (mType == DanhBa_Type.DanhBaKhachAo)
            {
                SaveKhachAo();
            }
            else if (mType == DanhBa_Type.DanhBaKhachHang)
            {
                SaveKhachHang();
            }           

            this.Close();
        }

        private void SaveCongTy()
        {
            DMDanhBaCongTy item = new DMDanhBaCongTy()
            {
                Address = mDanhBaCongTy.Address,
                Name = mDanhBaCongTy.Name,
                PhoneNumber = mDanhBaCongTy.PhoneNumber,
                isAuto = false
            };
            item.Save();
        }

        private void SaveKhachAo()
        {
            DMKhachAo item = new DMKhachAo()
            {
                Address = mDanhBaCongTy.Address,
                Name = mDanhBaCongTy.Name,
                PhoneNumber = mDanhBaCongTy.PhoneNumber
            };
            item.Save();
        }

        private void SaveKhachHang()
        {
            DMKhachHang.Inst.SaveKhachHang(mDanhBaCongTy.PhoneNumber, mDanhBaCongTy.Name, mDanhBaCongTy.Address, mIsAdd);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.D1:
                    rb_CongTy.Checked = true;
                    return true;

                case Keys.Alt | Keys.D2:
                    rb_KhachAo.Checked = true;
                    return true;

                case Keys.Alt | Keys.D3:
                    rb_KhachHang.Checked = true;
                    return true;

                case Keys.Alt | Keys.T:
                    editTen.Focus();
                    return true;

                case Keys.Alt | Keys.D:
                    editDiaChi.Focus();
                    return true;

                case Keys.Alt | Keys.S:
                    editSoDienThoai.Focus();
                    return true;

                case Keys.Alt | Keys.L:
                    btnSave.PerformClick();
                    return true;

                case Keys.Escape:
                    btnCancel.PerformClick();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void editSoHieuXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_CongTy_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_CongTy.Checked)
            {
                mType = DanhBa_Type.DanhBaCongTy;
            }
        }

        private void rb_KhachAo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_KhachAo.Checked)
            {
                mType = DanhBa_Type.DanhBaKhachAo;
            }
        }

        private void rb_KhachHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_KhachHang.Checked)
            {
                mType = DanhBa_Type.DanhBaKhachHang;
            }
        }
    }
}