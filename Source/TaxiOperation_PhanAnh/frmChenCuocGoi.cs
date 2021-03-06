using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Utils;
using Taxi.Business.ThongTinPhanAnh ;
using Taxi.Business;

namespace Taxi.GUI
{
    public partial class frmChenCuocGoi : Form
    {
        #region declare variable
        List<int> idCongTy = new List<int>();
        List<int> idSelected = new List<int>();
        #endregion

        public frmChenCuocGoi()
        {
            InitializeComponent();        
            
        }

        #region Load Du lieu
        private void frmChenCuocGoi_Load(object sender, EventArgs e)
        {
            LoadDonVi();
            LoadLoaiPhanAnh();
            cbLoaiPhanAnh.SelectedIndex = 0;
            
            this.ActiveControl = txtDienThoai;
            bool t = txtDienThoai.Focus();            
            
        }

        public void LoadLoaiPhanAnh()
        { 
            ThongTinPhanAnh objLoaiPhanAnh = new ThongTinPhanAnh();
            DataTable dtLoaiPA = objLoaiPhanAnh.GetLoaiPhanAnh();
            cbLoaiPhanAnh.DisplayMember = "TenLoaiPhanAnh";
            cbLoaiPhanAnh.ValueMember = "ID";
            cbLoaiPhanAnh.DataSource = dtLoaiPA;
            
        }
        public void LoadDonVi()
        {
            ThongTinPhanAnh objDonVi = new ThongTinPhanAnh();
            DataTable dtCongTy = objDonVi.GetAllCongTy();
                      
            foreach (DataRow row in dtCongTy.Rows)
            {
                string index = row.ItemArray[0].ToString();
                idCongTy.Add(int.Parse(index));
                chlCongTy.Items.Add(row["TenCongTy"].ToString());
            }
        }
        #endregion

        /// <summary>
        /// xử lí để người dùng chỉ có thể nhập số vào trường điện thoại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             if (StringTools.TrimSpace(txtDienThoai.Text).Length <3)
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn hãy kiểm tra điều kiện số điện thoại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 txtDienThoai.Focus();
             }
             else if(StringTools.TrimSpace(txtTenKH.Text).Length <=0)
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn hãy nhập tên khách hàng", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 txtTenKH.Focus();
             }
             else if(StringTools.TrimSpace(txtNoiDung.Text).Length <=0)
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn hãy nhập nội dung phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 txtNoiDung.Focus();
             }
             else if(cbLoaiPhanAnh.SelectedValue.ToString()  == "0")
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn hãy chọn loại phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 cbLoaiPhanAnh.Focus();
             }
             else if (idSelected.Count <=0)
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn hãy chọn tên đơn vị", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 chlCongTy.Focus();
             }
             else if((chkBinhThuong.Checked ==false )&& (chkNghiemTrong.Checked ==false))
             {
                 new Taxi.MessageBox.MessageBox().Show("Bạn chỉ có thể chọn 1 mức độ phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                 chkBinhThuong.Focus();
             }
             else
             {
                 int congTyID = 0;
                 ThongTinPhanAnh objThongTinPA = new ThongTinPhanAnh();
                 objThongTinPA.DienThoai = StringTools.TrimSpace(txtDienThoai.Text);
                 objThongTinPA.TenKhachHang = StringTools.TrimSpace(txtTenKH.Text);
                 objThongTinPA.NoiDung = StringTools.TrimSpace(txtNoiDung.Text);
                 objThongTinPA.NhanVienTiepNhan = ThongTinDangNhap.FULLNAME;

                 int loaiPhanAnh = int.Parse(cbLoaiPhanAnh.SelectedValue.ToString());
                // int congTyID = int.Parse(cbTenCongTy.SelectedValue.ToString());
                 int mucDo =0;
                 if (chkNghiemTrong.Checked)
                 {
                     mucDo = 1;
                 }
                 else
                 {
                     mucDo = 0;
                 }
                 if(idSelected.Count == 1)
                 {
                    congTyID = idSelected[0];
                 }
                 else if (idSelected.Count > 1)
                 {
                    congTyID = 0;
                 }
                 int idPhanAnh = objThongTinPA.InsertCuocGoi(loaiPhanAnh,mucDo,congTyID,0);
                 if((idPhanAnh >0)&&(objThongTinPA.InsertPhanAnh_CongTy(idPhanAnh ,idSelected)))
                 {                    
                    this.DialogResult = DialogResult.OK;
                 }
                 else 
                 {
                     LogError.WriteLogError("Loi  : luu du lieu vao database [Insert_DienThoai_LanDau]", new Exception("Loi luu lan dau cuoc goi tu log file"));
                     new Taxi.MessageBox.MessageBox().Show("Chèn cuộc gọi bị lỗi");
                     return;
                 }
                
                // new Taxi.MessageBox.MessageBox () .Show("Chèn thêm cuộc gọi thành công");                
                 //this.Close();
             }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkBinhThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBinhThuong.Checked)
            {
                chkNghiemTrong.Checked = false;
            }
            else
            {
                chkNghiemTrong.Checked = true ;
            }
        }

        private void chkNghiemTrong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNghiemTrong.Checked)
            {
                chkBinhThuong.Checked = false;
            }
            else
            {
                chkBinhThuong.Checked = true ;
            }
        }

        #region Xu Ly HotKey

        protected override bool ProcessDialogKey(Keys keyData)
            {
            if (keyData == Keys.Escape)
            {              
                this.Close();
                return true;
            }             
            else if (keyData == (Keys.Alt | Keys.S))
            {
                txtDienThoai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.T))
            {
                txtTenKH.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                txtNoiDung.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                cbLoaiPhanAnh.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.M))
            {
                chkNghiemTrong.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.B))
            {
                chkBinhThuong.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                chlCongTy.Focus();
                return true;
            }
            else if (keyData == Keys.Enter)
            {
                this.btnThem_Click(null, null);
                //this.Close();
                return true;
            }
            return false;
        }        
      
        #endregion Xu Ly HotKey

        #region Xu li mui ten
        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtTenKH.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
              //  txtDienThoai.Focus();
            }
        }
        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtNoiDung.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtDienThoai.Focus();
            }
        }
        private void txtNoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cbLoaiPhanAnh.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtTenKH.Focus();
            }
        }
        private void cbLoaiPhanAnh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkBinhThuong.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtNoiDung.Focus();
            }
        }
        private void chkBinhThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkNghiemTrong.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                cbLoaiPhanAnh.Focus();
            }
        }
        private void chkNghiemTrong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chlCongTy.Focus();
                
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkBinhThuong.Focus();
            }
        }
        private void chlCongTy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                //this.ActiveControl = btnThem;
                btnThem.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkNghiemTrong.Focus();
            }
            else if(e.KeyCode == Keys.Enter )
            {
                btnThem_Click(sender, new EventArgs());
            }
        }
        private void btnThem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnCancel.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chlCongTy.Focus();
            }
        }
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnThem.Focus();
            }
        }
        #endregion        

        private void chlCongTy_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id = idCongTy[e.Index];
            string text = chlCongTy.SelectedItem.ToString();
            idSelected.Add(id);
            //new MessageBox.MessageBox().Show(idSelected.ToString() + text);
        }

    }
}