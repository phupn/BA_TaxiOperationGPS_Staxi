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
    public partial class frmNhanVien: Form
    {
        private NhanVien mNhanVien;
        private bool mIsAdd = false;
        /// <summary>
        /// Get trang thi cua control (add/update)
        /// </summary>
        public bool IsAdd
        {
            get { return mIsAdd; }           
        }

        public frmNhanVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khoi tao mot doi tương DoiTac, o che do thêm mơi hay sửa đổi thông tin
        /// </summary>
        /// <param name="DoiTac"></param>
        /// <param name="boolAdd"></param>
        public frmNhanVien(NhanVien NhanVien, bool boolAdd)
        {
            InitializeComponent();
            mIsAdd = boolAdd;
            if (boolAdd)
            {
                this.Text = "Thêm mới lái xe";
            }
            else
            {
                this.Text = "Sửa đổi thông tin lái xe";
            }

            mNhanVien = NhanVien;
        }
        private void frmDoiTac_Load(object sender, EventArgs e)
        {
          //  LoadDSPhong();
          //  LoadDSChucVu();
            SetDoiTac(mNhanVien);
        }

        private void LoadDSPhong()
        {
            //TuDienPhong objPhong = new TuDienPhong();
            //cboPhong.DisplayMember = "TenPhong";
            //cboPhong.ValueMember = "PhongID";
            //cboPhong.DataSource = objPhong.LayDanhSach();  
        }
        private void LoadDSChucVu()
        {
            //TuDienChucVu objChucVu = new TuDienChucVu();
            //cboChucVu.DisplayMember = "TenChucVu";
            //cboChucVu.ValueMember = "ChucVuID";
            //cboChucVu.DataSource = objChucVu.LayDanhSach(); 
        }
        private void LoadDSLoaiXe()
        {
            
        }
        private void SetDoiTac(NhanVien  NhanVien)
        {
            editMaNhanVien.Text = NhanVien.MaNhanVien;
            editName.Text = NhanVien.TenNhanVien;
            cboCalendarNgaySinh.Value = NhanVien.NgaySinh??DateTime.Now;

            chkGioiTinh.Checked = NhanVien.GioiTinh;
            editSoCMT.Text = NhanVien.SoCMT;
            editAddress.Text = NhanVien.DiaChi;
            editPhone.Text = NhanVien.DienThoai;
            editDiDong.Text = NhanVien.DiDong ;
            editEmail.Text = NhanVien.Email;
            editVanBang.Text = NhanVien.VanBang;
            editSoHieuXe.Text =  mNhanVien.SoHieuXeLai ;
            editSoTheLaiXe.Text = mNhanVien.SoTheLaiXe ;
           // cboChucVu.SelectedValue = NhanVien.ChucVuID;
           // cboPhong.SelectedValue = NhanVien.PhongID;
            
        }

        public NhanVien  GetNhanVien()
        {
            mNhanVien.MaNhanVien=editMaNhanVien.Text ;
            mNhanVien.TenNhanVien  = editName.Text;
            mNhanVien.NgaySinh  = cboCalendarNgaySinh.Value;
            mNhanVien.GioiTinh  = chkGioiTinh.Checked;
            mNhanVien.SoCMT = editSoCMT.Text;
            mNhanVien.DiaChi  = editAddress.Text;
            mNhanVien.DienThoai  = editPhone.Text;
            mNhanVien.DiDong  = StringTools.TrimSpace ( editDiDong.Text);
            mNhanVien.Email  = editEmail.Text;
            mNhanVien.VanBang  = editVanBang.Text;
            mNhanVien.PhongID = 1;// int.Parse(cboChucVu.SelectedValue.ToString());
            mNhanVien.ChucVuID = 1;// int.Parse(cboPhong.SelectedValue.ToString());
            mNhanVien.SoTheLaiXe = editSoTheLaiXe.Text;
            mNhanVien.SoHieuXeLai = editSoHieuXe.Text;
            
            return mNhanVien;
        }


            #region Validate du lieu
        private void editName_TextChanged(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên lái xe bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }
        private void editName_Leave(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
                errorProvider.SetError(editName, "Trường tin Tên lái xe bắt buộc phải nhập");
            else
                errorProvider.SetError(editName, "");
        }      
        #endregion Validate du lieu

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (StringTools.TrimSpace(editName.Text).Length <= 0)
            {
                errorProvider.SetError(editName, "Trường tin Tên lái xe bắt buộc phải nhập");
                editName.Focus();
                return;
                 
            }
            string SoThe = StringTools.TrimSpace(editSoTheLaiXe.Text);
             
            if (IsAdd && (SoThe.Length>0) && (NhanVien.CheckTheLaiXeTonTai(SoThe)))
            {
                new MessageBox.MessageBoxBA().Show("Mã thẻ lái xe đã tồn tại.Bạn cần kiểm tra lại.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }   
            // Kiểm tra số điện thoại di động
            string Phones = StringTools.TrimSpace ( editDiDong.Text);
            if(this.CheckTrungTrongChinhMinh(Phones ))
            {
                new MessageBox.MessageBoxBA().Show("Bạn nhập số điện thoại trùng nhau cần kiểm tra lại.");
                this.DialogResult = DialogResult.Cancel;
                return ;
            }
            string MessageTrung ="";

            if( this.CheckTonTaiSoDienThoai(IsAdd,Phones,mNhanVien,out MessageTrung))
            {
                 new MessageBox.MessageBoxBA().Show("Số điện thoại bạn nhập đã trùng với số trước đố đã nhập.["+MessageTrung+"]");
                this.DialogResult = DialogResult.Cancel;
                
                return;
            }
            this.DialogResult = DialogResult.OK;
             this.Close();
        }

        /// <summary>
        /// kiem tra ds so điện thoại nhập có số nào trùng không
        /// IsNew = true không cần truyeenf nhanvien
        ///       = false thì truyền thêm nhânviên  
        /// true : có trùng, trả về dữ liệu trùng trong MessageTrung
        /// false : không trùng
        /// </summary>
        /// <param name="IsAdd"></param>
        /// <param name="ListPhones"></param>
        /// <returns></returns>
        private bool CheckTonTaiSoDienThoai(bool IsNew, string ListPhones,NhanVien nhanvien, out string MessageTrung)
        {
            List<NhanVien> lstNhanVien = new NhanVien().GetListNhanViens();
            string[] lstPhone = ListPhones.Split(";".ToCharArray());
            if (IsNew) // tạo mới thì check cả
            {

                foreach (NhanVien nv in lstNhanVien)
                {
                    for (int i = 0; i < lstPhone.Length; i++)
                    {
                        if (nv.DiDong.Contains(lstPhone[i]))
                        {
                            MessageTrung = " Trùng nhân viên : " + nv.TenNhanVien + "; số thẻ : " + nv.SoTheLaiXe;
                            return true;
                        }
                    }
                }
            }
            else
            {
                foreach (NhanVien nv in lstNhanVien)
                {
                    for (int i = 0; i < lstPhone.Length; i++)
                    {
                        if (nv.MaNhanVien != nhanvien.MaNhanVien)
                        {
                            if (nv.DiDong.Contains(lstPhone[i]))
                            {
                                MessageTrung = " Trùng nhân viên : " + nv.TenNhanVien + "; số thẻ : " + nv.SoTheLaiXe;
                                return true;
                            }
                        }
                    }
                }

            }
            MessageTrung = "";
            return false;
        }
        /// <summary>
        /// check so điện thọai trùng trong chính mình
        /// </summary>
        /// <param name="ListPhone"></param>
        /// <returns></returns>
        private bool CheckTrungTrongChinhMinh(string ListPhone)
        {
             string[] lstPhone = ListPhone.Split(";".ToCharArray());
             if (lstPhone.Length <= 1) return false ;
             else
             {
                 for (int i = 0; i < lstPhone.Length - 1; i++)
                 {
                     for (int j = i + 1; j < lstPhone.Length; j++)
                     {
                         if (lstPhone[i] == lstPhone[j])
                             return true;
                     }
                 }
             }
             return false;
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (StringTools.TrimSpace(editName.Text).Length <= 0)
            //{
            //    errorProvider.SetError(editName, "Trường tin Tên lái xe bắt buộc phải nhập");
            //    editName.Focus();
            //    e.Cancel = true;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xử lý hot key

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #endregion
       
    }
}