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
    public partial class frmDiaDanh: Form
    {
        private DiaDanh  mDiaDanh;
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public frmDiaDanh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmDiaDanh(DiaDanh DiaDanh, bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới địa danh";
            }
            else
            {
                this.Text = "Sửa đổi thông tin địa danh";
            }

            mDiaDanh = DiaDanh;
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
            LoadDSLoaiDiaDanh();
            SetDiaDanh(mDiaDanh);
        }

        private void LoadDSLoaiDiaDanh()
        {
             TuDienLoaiDiaDanh objLoaiDiaDanh = new TuDienLoaiDiaDanh();
             cboLoaiDiaDanh.DisplayMember = "TenLoaiDiaDanh";
             cboLoaiDiaDanh.ValueMember = "PK_LoaiDiaDanh";
             cboLoaiDiaDanh.DataSource = objLoaiDiaDanh.LayDanhSach(); 
        }
        
        private void SetDiaDanh(DiaDanh  diadanh)
        { 
            if(diadanh != null )
            {
                editName.Text = mDiaDanh.TenDiaDanh;
                 editAddress.Text = mDiaDanh.DiaChi;
                 editPhone.Text = mDiaDanh.DienThoai;
                 editMoTa.Text = mDiaDanh.GhiChu;
                 cboLoaiDiaDanh.SelectedValue = (int)mDiaDanh.LoaiDiaDanhID;

            }
        }

        public DiaDanh GetDiaDanh()
        {
            if (mDiaDanh == null)
                mDiaDanh = new DiaDanh();

            mDiaDanh.TenDiaDanh = StringTools.TrimSpace(editName.Text);
            mDiaDanh.DiaChi = StringTools.TrimSpace(editAddress.Text);
            mDiaDanh.DienThoai = StringTools.TrimSpace(editPhone.Text);
            mDiaDanh.GhiChu = StringTools.TrimSpace(editMoTa.Text);
            mDiaDanh.LoaiDiaDanhID = int.Parse(cboLoaiDiaDanh.SelectedValue.ToString());

            return mDiaDanh;
        }


            #region Validate du lieu
        private void editName_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin tên địa danh bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }
        private void editName_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin tên địa danh bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }

        private void editAddress_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin địa chỉ bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        }

        private void editAddress_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editAddress.Text).Length <= 0)
                errorProvider.SetError(editAddress, "Trường tin địa chỉ bắt buộc phải nhập");
            else
                errorProvider.SetError(editAddress, "");
        } 
        #endregion Validate du lieu

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
            {
                errorProvider.SetError(editName, "Trường tin tên địa danh bắt buộc phải nhập");
                editName.Focus();
                return;
            }
            else 
             this.Close();
        }

        
    }
}