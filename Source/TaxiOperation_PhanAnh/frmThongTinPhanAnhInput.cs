using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.ThongTinPhanAnh;
using Taxi.Utils;
using Taxi.Business;
using System.Collections.Generic;

namespace Taxi.GUI
{
    public partial class frmThongTinPhanAnhInput : Form
    {
        #region declare variable
        private ThongTinPhanAnh _thongTinPA = new ThongTinPhanAnh();
        public bool isChuyen = false;
        public bool ChuyenType = false;
        List<int> idCongTy = new List<int>();
        List<int> idSelected = new List<int>();
        List<int> lstCongTyID = new List<int>();
        #endregion

        #region Constructor
        public frmThongTinPhanAnhInput()
        {
            InitializeComponent();
            LoadDonVi();
            LoadLoaiPhanAnh();
        }
        public frmThongTinPhanAnhInput(ThongTinPhanAnh objThongTinPA, string role , bool chuyen, List<int> lstCongTy)
        {          
            InitializeComponent();
            _thongTinPA = objThongTinPA;
            this.EditTab(role);
            ChuyenType = chuyen;
            lstCongTyID = lstCongTy;
        }
      
        #endregion

        #region Load du lieu
        private void frmThongTinPhanAnhInput_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTenKH;
            txtTenKH.Focus();
            //tab thông tin phản ánh
            LoadDonVi();
            LoadLoaiPhanAnh();
            lblDienThoai.Text = _thongTinPA.DienThoai;
            if (_thongTinPA.ThoiGianPhanAnh == DateTime.MinValue)
            {
                lblThoiGian.Text = string.Format("{0:HH:mm dd/MM/yyyy}", DateTime.Now);
            }
            else
            {
                lblThoiGian.Text = string.Format("{0:HH:mm dd/MM/yyyy}", _thongTinPA.ThoiGianPhanAnh);
            }
            txtTenKH.Text = _thongTinPA.TenKhachHang;
            txtNoiDung.Text = _thongTinPA.NoiDung;
            cbLoaiPhanAnh.SelectedValue = _thongTinPA.LoaiPhanhAnhID ;
            if (_thongTinPA.MucDoPhanAnh  == "bình thường")
            {
                chkBinhThuong.Checked = true;
               // chkNghiemTrong.Checked = false;
            }
            else if (_thongTinPA.MucDoPhanAnh  == "nghiêm trọng")
            {
                chkNghiemTrong.Checked = true;
                //chkBinhThuong.Checked = false ;
            }

            // bind danh sách công ty vào checkedlistbox
            for (int i = 0; i < lstCongTyID.Count;i++ )
            {
               // chlCongTy.SelectedItem = lstCongTyID[i].ToString();             
               
                chlCongTy.SetItemChecked(lstCongTyID[i] -1, true);
             
            }
            

            if (_thongTinPA.ChuyenDonVi == true)
            {
                chkChuyenDV.Checked = true;
            }
            else
            {
                chkChuyenDV.Checked = false ;
            }

            // tab ket qua giai quyet
            lblDTGiaiQuyet.Text = _thongTinPA.DienThoai;
            if (_thongTinPA.ThoiGianPhanAnh == DateTime.MinValue)
            {
                lblTGGiaiQuyet.Text = string.Format("{0:HH:mm dd/MM/yyyy}", DateTime.Now);
            }
            else
            {
                lblTGGiaiQuyet.Text = string.Format("{0:HH:mm dd/MM/yyyy}", _thongTinPA.ThoiGianPhanAnh);
            }
            txtKetQua.Text = _thongTinPA.KetQua;
            if (_thongTinPA.NgayGiaiQuyet == DateTime.MinValue )
            {
                txtNgayGiaiQuyet.Text = string.Format("{0:HH:mm dd/MM/yyyy}", DateTime.Now);
            }
            else
            {
                txtNgayGiaiQuyet.Text = string.Format("{0:HH:mm dd/MM/yyyy}", _thongTinPA.NgayGiaiQuyet);
            }
            if (_thongTinPA.MucHaiLong == string.Empty)
            {
                chkHaiLong.Checked = false;
                chkKhongHL.Checked = false;

            }
            else if (_thongTinPA.MucHaiLong == "0")
            {
                chkHaiLong.Checked = true;
                chkKhongHL.Checked = false;
            }
            else
            {
                chkKhongHL.Checked = true;
                chkHaiLong.Checked = false;
            }
            txtYKienKh.Text = _thongTinPA.YKien;

            //---- Kiểm tra xem có các cuộc gọi trước đó --
            // nếu có thì hiển thị nút ngược lại ẩn 
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
            List<ThongTinPhanAnh> lstPhanAnhs = new List<ThongTinPhanAnh>();
            lstPhanAnhs = objPhanAnh.SearchPhanAnh(lblDienThoai.Text, "",
                   timeServer.AddDays(-10),timeServer,  false , false );
            if (lstPhanAnhs != null && lstPhanAnhs.Count > 0)
            {
                btnCuocGoiTruoc.Visible = true;
            }
            else
            {
                btnCuocGoiTruoc.Visible = false;
            }

            //---------------------------------------------
           
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
                       
            foreach(DataRow row in dtCongTy.Rows )
            {                
                string index = row.ItemArray[0].ToString();
                idCongTy.Add(int.Parse(index));
                chlCongTy.Items.Add(row["TenCongTy"].ToString());               
            }

        }
        #endregion
       
       #region ĐẶT CHẾ ĐỘ CHO CÁC TAB
        public void EditTab( string roleNhanVien)
        {
            //if(roleNhanVien == string.Empty )
            //{
            //    tbThongTinPA.TabVisible = true;
            //    tbGiaiQuyet.TabVisible = true ;
            //    tbThongTinPA.Enabled = false;
            //    tbGiaiQuyet.Enabled = false;
            //}
           // else 
            if (roleNhanVien == "NVNHANPHANANH")
            {
                tbThongTinPA.TabVisible  = true;
                tbGiaiQuyet.TabVisible = false;
                                
            }
            else if (roleNhanVien == "NVGIAIQUYETPHANANH")
            {
                tbThongTinPA.TabVisible = true;
                tbGiaiQuyet.TabVisible = true;
                //ko cho sửa thong tin phan anh
                txtTenKH.Enabled = false;
                txtNoiDung.Enabled = false;
                cbLoaiPhanAnh.Enabled = false;
                chlCongTy.Enabled = false;
                chkBinhThuong.Enabled = false;
                chkNghiemTrong.Enabled = false;
               // btnSave.Enabled = false;
               // btnCancel.Enabled = false;
                
            }
            else if (roleNhanVien == "All" )
            {
                tbThongTinPA.TabVisible = true;
                tbGiaiQuyet.TabVisible = true;
                tbGiaiQuyet.Focus();
            }

        }
        #endregion

        private void chkHaiLong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHaiLong.Checked)
            {
                chkKhongHL.Checked = false;
            }
            else
            {
                chkKhongHL.Checked = true ;
            }

        }

        private void chkKhongHL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhongHL.Checked)
            {
                chkHaiLong.Checked = false;
            }
            else
            {
                chkHaiLong.Checked = true ;
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            ThongTinPhanAnh objThongTinPA = new ThongTinPhanAnh();
            objThongTinPA.NhanVienTiepNhan = ThongTinDangNhap.USER_ID;
            bool isGoiLaiGoiKhac = false;
            //thong tin chung
            int loaiPhanAnh = 0;
            int congTyID = 0;
            int mucDoPA = 0;
            isGoiLaiGoiKhac = chkGoiLaiGoiKhac.Checked;
            string maThongTin = StringTools.TrimSpace(txtMaThongTin.Text);
            // CUOC GOI LAI GOI KHAC

            if (chkGoiLaiGoiKhac.Checked) // chọn gọi khác thì không cần kiểm tra cái gì, không cần nhập thông tiin
            {
                objThongTinPA.ID = _thongTinPA.ID; 
                objThongTinPA.TenKhachHang = txtTenKH.Text;
                objThongTinPA.NoiDung = txtNoiDung.Text;
                loaiPhanAnh = 1;
                congTyID = 1;
                mucDoPA = 0;
                isChuyen = false;

               
                

                if ((objThongTinPA.UpdateCuocGoi(loaiPhanAnh, mucDoPA, congTyID, isChuyen, isGoiLaiGoiKhac,maThongTin) > 0)
                        && (objThongTinPA.InsertPhanAnh_CongTy(Convert.ToInt32(objThongTinPA.ID), idSelected)))
                {                     
                    this.DialogResult = DialogResult.Yes;
                    this.Close(); 
                }
                else
                {
                      
                    new Taxi.MessageBox.MessageBox().Show("Cập nhật thông tin bị lỗi");
                    return;
                }
            }
            else
            {
                if(CheckThongTinPA())
                {
                    
                    objThongTinPA.ID = _thongTinPA.ID;

                    objThongTinPA.TenKhachHang = txtTenKH.Text;
                    objThongTinPA.NoiDung = txtNoiDung.Text;
                    
                    if (cbLoaiPhanAnh.Text == _thongTinPA.LoaiPhanAnh)
                    {
                        loaiPhanAnh = _thongTinPA.LoaiPhanhAnhID;
                    }
                    else
                    {
                        loaiPhanAnh = int.Parse(cbLoaiPhanAnh.SelectedValue.ToString());
                    }
                    // nếu chỉ chọn 1 đơn vị thì vẫn ghi vào bảng phản ánh
                    // nếu chọn nhiều đơn vị thì CongtyID =0 và ghi vào bảng phụ
                    if (idSelected.Count == 1)
                    {
                        congTyID = idSelected[0];
                    }
                    else if (idSelected.Count > 1)
                    {
                        congTyID = 0;
                    }

                    if (chkBinhThuong.Checked)
                    {
                        mucDoPA = 0;
                    }
                    else
                    {
                        mucDoPA = 1;
                    }
                    if (chkChuyenDV.Checked)
                    {
                        isChuyen = true;
                    }
                    else
                    {
                        isChuyen = false;
                    }
                    if (loaiPhanAnh <= 0)
                    {
                        new Taxi.MessageBox.MessageBox().Show("Bạn chọn loại phải ánh.");
                        return;
                    }
                    
                    if ((objThongTinPA.UpdateCuocGoi(loaiPhanAnh, mucDoPA, congTyID, isChuyen,isGoiLaiGoiKhac,maThongTin) > 0)
                        && (objThongTinPA.InsertPhanAnh_CongTy(Convert.ToInt32(objThongTinPA.ID), idSelected)))
                    {
                        if (isChuyen == true)
                        {
                            this.DialogResult = DialogResult.Yes;
                            this.Close();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Yes;
                        }
                    }
                    else
                    {
                        LogError.WriteLogError("Loi  : luu du lieu vao database [Insert_DienThoai_LanDau]", new Exception("Loi luu lan dau cuoc goi tu log file"));
                        new Taxi.MessageBox.MessageBox().Show("Cập nhật thông tin bị lỗi");
                        return;
                    }
                    // new Taxi.MessageBox.MessageBox().Show("Cập nhật thông tin phản ánh thành công");

                    //this.Close();
                }
           }
            
        }
        /// <summary>
        /// Ham thuc hien lay ds cong ty duoc chon
        /// </summary>
        /// <param name="danhSachCongTyChon"></param>
        private void GetDSCongTyDuocChon(ref List<int> danhSachCongTyChon)
        {

            danhSachCongTyChon = null;
        }

        public bool CheckThongTinPA()
        {
            if (StringTools.TrimSpace(txtTenKH.Text).Length <= 0)
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn hãy nhập tên khách hàng", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if (StringTools.TrimSpace(txtNoiDung.Text).Length <= 0)
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn hãy nhập nội dung phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if (cbLoaiPhanAnh.SelectedValue.ToString() == "0")
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn hãy chọn loại phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if ((chkBinhThuong.Checked == false) && (chkNghiemTrong.Checked == false))
            {
                new Taxi.MessageBox.MessageBox().Show("Hãy chọn 1 mức độ phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if (idSelected.Count <= 0)
            {
                new Taxi.MessageBox.MessageBox().Show("Bạn hãy chọn tên đơn vị", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public bool CheckGiaiQuyetPA()
        { 
            if(StringTools.TrimSpace(txtKetQua.Text).Length <=0)
            {
                new Taxi.MessageBox.MessageBox().Show("Hãy nhập kết quả giải quyết phản ánh", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if ((chkHaiLong.Checked == false) && (chkKhongHL.Checked == false))
            {
                new Taxi.MessageBox.MessageBox().Show("Hãy chọn mức đánh giá của khách hàng", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            else if(StringTools.TrimSpace(txtYKienKh.Text).Length<=0)
            {
                new Taxi.MessageBox.MessageBox().Show("Hãy nhập nội dung ý kiến khách hàng", "Thông báo",  Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xu li hotkey
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {                
                this.Close();
                return true;
            }             
            else if (keyData ==Keys.F1 )
            {
                if (uiTab1.SelectedIndex != 0)
                    uiTab1.SelectedIndex = 0;
                return true;
            }
            else if (keyData == Keys.F2 )
            {
                if (uiTab1.SelectedIndex != 1)
                    uiTab1.SelectedIndex = 1;
                return true;
            }
            else if(keyData== Keys.Enter )
            {
                if(uiTab1.SelectedIndex == 0)
                {
                    btnSave_Click(null, null);
                }
                else if(uiTab1.SelectedIndex == 1)
                {
                    btnSaveKQ_Click(null, null);
                }
                return true;
            }
            
            return false;
        }
        #endregion

        #region xu li mui ten o tab thong tin phan anh
        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtNoiDung.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
               // txtDienThoai.Focus();
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
                chkChuyenDV.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkNghiemTrong.Focus();
            }
            //else if (e.KeyCode == Keys.Enter)
            //{
            //    btnSave_Click(sender, new EventArgs());
            //}
        }

        private void chkChuyenDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                //this.ActiveControl = btnThem;
                btnSave.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chlCongTy.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, new EventArgs());
            }
        }

     
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnCancel.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkChuyenDV.Focus();
            }
        }
       
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtTenKH.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnSave.Focus();
            }
        }
        #endregion

       
        #region xu li mui ten o tab giai quyet
        private void txtKetQua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkHaiLong.Focus();
            }
            else if(e.KeyCode == Keys.Left)
            { 
                
            }
        }

        private void chkHaiLong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkKhongHL.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                txtKetQua.Focus();
            }
        }

        private void chkKhongHL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtYKienKh.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkHaiLong.Focus();
            }
        }

        private void txtYKienKh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                chkTrangThai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkKhongHL.Focus();
            }
        }

        private void chkTrangThai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnSaveKQ.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkHaiLong.Focus();
            }
            else if(e.KeyCode == Keys.Enter )
            {
                btnSaveKQ_Click(sender, new EventArgs());
            }
         

        }
        private void btnSaveKQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnHuyKQ.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkTrangThai.Focus();
            }
        }
        private void btnHuyKQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                txtKetQua.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                btnHuyKQ.Focus();
            }
        }
        #endregion

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if(e.Page.Name == "tbThongTinPA")
            {
                this.ActiveControl = txtTenKH;
                txtTenKH.Focus();
            }
            else if(e.Page.Name == "tbGiaiQuyet")
            {
                this.ActiveControl = txtKetQua ;
                txtKetQua.Focus();
            }
        }

        private void btnSaveKQ_Click(object sender, EventArgs e)
        {
            //thong tin chung
            
            int mucHaiLong = 0;
            
            ThongTinPhanAnh objThongTinPA = new ThongTinPhanAnh();
            objThongTinPA.ID = _thongTinPA.ID;
             if(CheckGiaiQuyetPA())
             {
                 objThongTinPA.KetQua = txtKetQua.Text;
                 if (_thongTinPA.NgayGiaiQuyet == DateTime.MinValue)
                 {
                     objThongTinPA.NgayGiaiQuyet = DateTime.Now;
                 }
                 else
                 {
                     objThongTinPA.NgayGiaiQuyet = _thongTinPA.NgayGiaiQuyet;
                 }
                 if (chkHaiLong.Checked)
                 {
                     mucHaiLong = 0;
                 }
                 else
                 {
                     mucHaiLong = 1;
                 }
                 objThongTinPA.YKien = txtYKienKh.Text;
                 objThongTinPA.NguoiGiaiQuyet = ThongTinDangNhap.FULLNAME;
                 if (ChuyenType == true)
                 {
                     if (chkTrangThai.Checked)
                     {
                         isChuyen = false;
                         objThongTinPA.TrangThaiGiaiQuyet = true;
                     }
                     else
                     {
                         isChuyen = true;
                         objThongTinPA.TrangThaiGiaiQuyet = false;
                     }
                     if (objThongTinPA.UpdateGiaiQuyet(mucHaiLong, isChuyen)>0)
                     {
                         this.DialogResult = DialogResult.OK;
                         this.Close();
                     }
                     else
                     {
                         LogError.WriteLogError("Loi  : luu du lieu vao database [Insert_DienThoai_LanDau]", new Exception("Loi luu lan dau cuoc goi tu log file"));
                         new Taxi.MessageBox.MessageBox().Show("Cập nhật thông tin bị lỗi");
                         return;
                     }
                 }
                 else
                 {
                     if (chkChuyenDV.Checked)
                     {
                         isChuyen = true;
                         objThongTinPA.TrangThaiGiaiQuyet = false;
                     }
                     else
                     {
                         isChuyen = false;
                         if (chkTrangThai.Checked)
                         {
                             objThongTinPA.TrangThaiGiaiQuyet = true;
                         }
                         else
                         {
                             objThongTinPA.TrangThaiGiaiQuyet = false;
                         }
                     }
                     if (objThongTinPA.UpdateGiaiQuyet(mucHaiLong, isChuyen)>0)
                     {
                         this.DialogResult = DialogResult.OK;
                         this.Close();
                     }
                     else
                     {
                         LogError.WriteLogError("Loi  : luu du lieu vao database [Insert_DienThoai_LanDau]", new Exception("Loi luu lan dau cuoc goi tu log file"));
                         new Taxi.MessageBox.MessageBox().Show("Cập nhật thông tin bị lỗi");
                         return;
                     }
                 }
                 //new Taxi.MessageBox.MessageBox().Show("Cập nhật giải quyết phản ánh thành công");
                
             }
        }

        private void btnHuyKQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }
             

        private void chlCongTy_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id = idCongTy[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                if (idSelected == null) idSelected = new List<int>();
                idSelected.Add(id);
            }
            else
            {
                if(idSelected != null && idSelected.Count >0)
                    idSelected.Remove(id);
            }
             
        }

        private void btnCuocGoiTruoc_Click(object sender, EventArgs e)
        {
            frmTimKiem frmSearch = new frmTimKiem(lblDienThoai.Text);
             
            if (frmSearch.ShowDialog() == DialogResult.OK)
            {
                txtTenKH.Text = frmSearch.GetTenKhachHang;
                txtNoiDung.Text = frmSearch.GetNoiDung;
            }

        } 
    }
}
