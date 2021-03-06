using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Model;
using Taxi.Business;
using Taxi.Business.CheckCoDuongDai;
using System.Collections;
namespace Taxi.Controls
{
    public partial class CheckCoDuongDai : UserControl
    {
        #region declare variable
        public bool isInsert = true;
        public bool isSuccess = false;
        private bool G_isDaDuyet = false;
        private List<District> G_arrDistrictDi_Filter;
        private List<Commune> G_arrCommuneDi_Filter;

        private List<District> G_arrDistrictDen_Filter;
        private List<Commune> G_arrCommuneDen_Filter;

        private List<Province> _arrProvince;
        public List<Province> G_arrProvince
        {
            get { return _arrProvince; }
            set { _arrProvince = value; }
        }

        private List<District> _arrDistrict;
        public List<District> G_arrDistrict
        {
            get { return _arrDistrict; }
            set { _arrDistrict = value; }
        }

        private List<Commune> _arrCommune;
        public List<Commune> G_arrCommune
        {
            get { return _arrCommune; }
            set { _arrCommune = value; }
        }

        private bool G_isCompleted = false;
        private int G_StartProvinceSelected = 0;
        private int G_StartDistrictSelected = 0;
        private int G_EndProvinceSelected = 0;
        private int G_EndDistrictSelected = 0;

        public enum ActiveControl : int
        {
            Province = 0,
            District = 1,
            Commune = 2,
            No = 3
        }
        #endregion       

        public CheckCoDuongDai()
        {
            InitializeComponent();
        }
       
        #region Load Data
        private void CheckCoDuongDai_Load(object sender, EventArgs e)
        {
                       
        }

        public void LoadForm(string dtLaiXe)
        {
            txtDienThoai.Text = dtLaiXe;
            DateTime currDate = DieuHanhTaxi.GetTimeServer();
            cbThoiDiemDon.EditValue = currDate;
            cbThoiDiemTra.EditValue = currDate.AddHours(6);
            LoadTinhThanh();
            LoadQuanHuyen();
            LoadPhuongXa();
            lblThoiDiemNhap.Text = "Thời gian nhập: " + string.Format("{0:HH:mm dd/MM/yyyy}", currDate);
            G_isCompleted = true;  
            
        }

        
        private void ValidatePermission()
        {
            ArrayList DanhSachQuyen = ThongTinDangNhap.PermissionsFull;            
            if (DanhSachQuyen != null)
            {
                btnDelete.Visible = (DanhSachQuyen.Contains(btnDelete.Tag) || ThongTinDangNhap.USER_ID.ToLower() == "admin") ? true : false;
                btnLuuThoat.Visible = (DanhSachQuyen.Contains(btnLuuThoat.Tag) || ThongTinDangNhap.USER_ID.ToLower() == "admin") ? true : false;
                btnLuuTiep.Visible = (DanhSachQuyen.Contains(btnLuuTiep.Tag) || ThongTinDangNhap.USER_ID.ToLower() == "admin") ? true : false;
                cbDuyet.SelectedIndex = 0;
            }
        }
        public void SetValue(Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo)
        {
            if (objCheckCo == null) return;
            ValidatePermission();
            
            lbID.Text = objCheckCo.ID.ToString();
            txtSoHieuXe.Text = objCheckCo.SoHieuXe;
            txtNoiDi.Text = objCheckCo.NoiDi;
            txtNoiDen.Text = objCheckCo.NoiDen;
            txtCoDau.Text = objCheckCo.CoDau.ToString();
            txtCoCuoi.Text = objCheckCo.CoCuoi.ToString();

            if (objCheckCo.ThoiDiemDi == DateTime.Parse("01/01/1900 00:00:00"))
                cbThoiDiemDon.EditValue=CommonBL.GetTimeServer().Date;
            else
                cbThoiDiemDon.EditValue = objCheckCo.ThoiDiemDi;

            if (objCheckCo.ThoiDiemVe == DateTime.Parse("01/01/1900 00:00:00") || objCheckCo.ThoiDiemVe == DateTime.Parse("01/01/0001 00:00:00"))
                cbThoiDiemTra.EditValue = CommonBL.GetTimeServer().Date;
            else
                cbThoiDiemTra.EditValue = objCheckCo.ThoiDiemVe;

            cbTinh_Den.SelectedValue = objCheckCo.TinhThanhDenID;
            if (objCheckCo.ChieuDi == "Một chiều")
            {
                chkMotChieu.Checked = true;
                chkHaiChieu.Checked = false;
            }
            else
            {
                chkHaiChieu.Checked = true;
                chkMotChieu.Checked = false;
            }
            txtTongTien.Text = objCheckCo.TongTien.ToString();
            txtGhiChu.Text = objCheckCo.GhiChu;
            txtDienThoai.Text = objCheckCo.SoDienThoai;
            txtTenLaiXe.Text = objCheckCo.TenLaiXe;
            chkChiaSe.Checked = objCheckCo.isChiaSeChuyenDi;
            cb_PhuongXaDi.SelectedValue = objCheckCo.FK_PhuongXaDiID;
            cb_PhuongXaDen.SelectedValue = objCheckCo.FK_PhuongXaDenID;
            cbQH_Di.SelectedValue = objCheckCo.FK_QuanHuyenDiID;
            cbQH_Den.SelectedValue = objCheckCo.FK_QuanHuyenDenID;
            cbTinh_Di.SelectedValue = objCheckCo.FK_TinhThanhDiID;
            if (objCheckCo.NguoiDuyet != null)
            {
                G_isDaDuyet = true;
                if (objCheckCo.TrangThaiDuyet == true)
                    cbDuyet.SelectedIndex = 2;
                else
                    cbDuyet.SelectedIndex = 1;
            }
            else
            {
                G_isDaDuyet = false;
                cbDuyet.SelectedIndex = 0;
            }

            btnDelete.Visible = true;
        }

        public void LoadTinhThanh()
        {
            if (G_arrProvince != null && G_arrProvince.Count > 0)
            {
                cbTinh_Den.DisplayMember = "NameVN";
                cbTinh_Den.ValueMember = "PK_ProvinceID";
                cbTinh_Den.DataSource = G_arrProvince;

                cbTinh_Di.DisplayMember = "NameVN";
                cbTinh_Di.ValueMember = "PK_ProvinceID";
                cbTinh_Di.DataSource = Taxi.Business.CheckCoDuongDai.CheckCoDuongDai.CloneList<Province>(G_arrProvince);
            }
            if (cbTinh_Den.Items.Count > 0)                
                cbTinh_Den.SelectedValue = 0;

            if (cbTinh_Di.Items.Count > 0)
            {
                cbTinh_Di.SelectedValue = 0;
            }
        }

        public void LoadQuanHuyen()
        {
            if (G_arrDistrict != null && G_arrDistrict.Count > 0)
            {
                cbQH_Di.DisplayMember = "NameVN";
                cbQH_Di.ValueMember = "PK_DistrictID";
                cbQH_Di.DataSource = Business.CheckCoDuongDai.CheckCoDuongDai.CloneList(G_arrDistrict); 

                cbQH_Den.DisplayMember = "NameVN";
                cbQH_Den.ValueMember = "PK_DistrictID";
                cbQH_Den.DataSource = Business.CheckCoDuongDai.CheckCoDuongDai.CloneList(G_arrDistrict);
            }
        }

        public void LoadPhuongXa()
        {
            if (G_arrCommune != null && G_arrCommune.Count > 0)
            {
                cb_PhuongXaDi.DisplayMember = "NameVN";
                cb_PhuongXaDi.ValueMember = "PK_CommuneID";
                cb_PhuongXaDi.DataSource = G_arrCommune;
                cb_PhuongXaDi.SelectedIndex = 0;
                cb_PhuongXaDen.DisplayMember = "NameVN";
                cb_PhuongXaDen.ValueMember = "PK_CommuneID";
                cb_PhuongXaDen.DataSource = Business.CheckCoDuongDai.CheckCoDuongDai.CloneList<Commune>(G_arrCommune);
                cb_PhuongXaDen.SelectedIndex = 0;
            }
        }

        public void LoadPhuongXaDi_ByFilter()
        {
            G_arrCommuneDi_Filter.Insert(0, new Commune());
            if (G_arrCommuneDi_Filter != null && G_arrCommuneDi_Filter.Count > 0)
            {
                cb_PhuongXaDi.DisplayMember = "NameVN";
                cb_PhuongXaDi.ValueMember = "PK_CommuneID";
                cb_PhuongXaDi.DataSource = G_arrCommuneDi_Filter;
                cb_PhuongXaDi.SelectedIndex = 0;
            }
        }

        public void LoadQuanHuyenDi_ByFilter()
        {
            G_arrDistrictDi_Filter.Insert(0, new District());
            if (G_arrDistrictDi_Filter != null && G_arrDistrictDi_Filter.Count > 0)
            {                
                cbQH_Di.DisplayMember = "NameVN";
                cbQH_Di.ValueMember = "PK_DistrictID";
                cbQH_Di.DataSource = G_arrDistrictDi_Filter;
                cbQH_Di.SelectedIndex = 0;
            }
        }

        public void LoadPhuongXaDen_ByFilter()
        {
            G_arrCommuneDen_Filter.Insert(0, new Commune());
            if (G_arrCommuneDen_Filter != null && G_arrCommuneDen_Filter.Count > 0)
            {
                cb_PhuongXaDen.DisplayMember = "NameVN";
                cb_PhuongXaDen.ValueMember = "PK_CommuneID";
                cb_PhuongXaDen.DataSource = G_arrCommuneDen_Filter;
                cb_PhuongXaDen.SelectedIndex = 0;
                
            }
        }

        public void LoadQuanHuyenDen_ByFilter()
        {
            G_arrDistrictDen_Filter.Insert(0, new District());
            if (G_arrDistrictDen_Filter != null && G_arrDistrictDen_Filter.Count > 0)
            {
                cbQH_Den.DisplayMember = "NameVN";
                cbQH_Den.ValueMember = "PK_DistrictID";
                cbQH_Den.DataSource = G_arrDistrictDen_Filter;
                cbQH_Den.SelectedIndex = 0;

            }
        }
        #endregion

        #region Method
        public void Insert()
        {
            Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = new Business.CheckCoDuongDai.CheckCoDuongDai();
            BangMaValidate maValidate = ValidateFormNhap(objCheckCo);
            HienThiThongBao(maValidate);
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                int coCuoi = 0;
                float tongTien = 0;
                bool chieuDi = true;
                if (txtTongTien.Text == string.Empty)
                {
                    tongTien = 0;
                }
                else
                {
                    try { tongTien = float.Parse(txtTongTien.Text); }
                    catch { tongTien = 0; }
                }
                if (txtCoCuoi.Text == string.Empty)
                {
                    coCuoi = 0;
                }
                else
                {
                    try { coCuoi = int.Parse(txtCoCuoi.Text); }
                    catch { coCuoi = 0; }
                }
                if (chkMotChieu.Checked)
                {
                    chieuDi = true;
                }
                else
                {
                    chieuDi = false;
                }
                int TinhThanhDiID = 0;
                int TinhThanhDenID = 0;
                int QuanHuyenDiID = 0;
                int QuanHuyenDenID = 0;
                int PhuongXaDiID = 0;
                int PhuongXaDenID = 0;
                string TenLaiXe = txtTenLaiXe.Text.Trim();

                bool isChiaSe = true;
                if (chkChiaSe.Visible)
                    isChiaSe = chkChiaSe.Checked;

                if (cbTinh_Di.SelectedIndex >= 0)
                {
                    TinhThanhDiID = (int)cbTinh_Di.SelectedValue;
                }
                if (cbTinh_Den.SelectedIndex >= 0)
                {
                    TinhThanhDenID = (int) cbTinh_Den.SelectedValue;
                }
                if (cbQH_Di.SelectedIndex >= 0)
                {
                    QuanHuyenDiID = (int)cbQH_Di.SelectedValue;
                }
                if (cbQH_Den.SelectedIndex >= 0)
                {
                    QuanHuyenDenID = (int)cbQH_Den.SelectedValue;
                }
                if (cb_PhuongXaDi.SelectedIndex >= 0)
                {
                    PhuongXaDiID = (int)cb_PhuongXaDi.SelectedValue;
                }
                if (cb_PhuongXaDen.SelectedIndex >= 0)
                {
                    PhuongXaDenID = (int)cb_PhuongXaDen.SelectedValue;
                }
                DateTime ThoiDiemTra = DateTime.MinValue;
                if (cbThoiDiemTra.Text != "")
                {
                    ThoiDiemTra = cbThoiDiemTra.DateTime;
                }
                int output = objCheckCo.InsertCheckCo(txtSoHieuXe.Text, txtNoiDi.Text.ToUpperInvariant(), txtNoiDen.Text.ToUpperInvariant(), TinhThanhDenID,
                                    int.Parse(txtCoDau.Text), coCuoi, cbThoiDiemDon.DateTime, ThoiDiemTra, chieuDi, 
                                    tongTien,txtGhiChu.Text, ThongTinDangNhap.USER_ID, TinhThanhDiID, QuanHuyenDiID, QuanHuyenDenID, 
                                    PhuongXaDiID, PhuongXaDenID, TenLaiXe, txtDienThoai.Text.Trim(), isChiaSe);
                if (output > 0)
                {
                    new MessageBox.MessageBoxBA().Show("Lưu thông tin thành công", "Thông báo",
                    MessageBox.MessageBoxButtonsBA.OK,
                    MessageBox.MessageBoxIconBA.Information);

                    isSuccess = true;
                }
                else if (output == -1)
                {
                    new MessageBox.MessageBoxBA().Show(String.Format("Xe {0} đã chốt cơ trong khoảng 15 phút trở lại đây rồi", txtSoHieuXe.Text.Trim()), "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                    Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Lưu thông tin lỗi", "Thông báo",
                    Taxi.MessageBox.MessageBoxButtonsBA.OK,
                    Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }

        public void UpdateCheckCo()
        {
            Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = new Taxi.Business.CheckCoDuongDai.CheckCoDuongDai();

            BangMaValidate maValidate = ValidateFormNhap(objCheckCo);
            HienThiThongBao(maValidate);
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                bool TrangThaiDuyet = false;
                if (cbDuyet.SelectedIndex == 1)
                    TrangThaiDuyet = false;
                else
                    TrangThaiDuyet = true;
                int coCuoi = 0;
                float tongTien = 0;
                bool chieuDi = true;
                if (txtTongTien.Text == string.Empty)
                {
                    tongTien = 0;
                }
                else
                {
                    try { tongTien = float.Parse(txtTongTien.Text); }
                    catch { tongTien = 0; }
                }
                if (txtCoCuoi.Text == string.Empty)
                {
                    coCuoi = 0;
                }
                else
                {
                    try { coCuoi = int.Parse(txtCoCuoi.Text); }
                    catch { coCuoi = 0; }
                }
                if (chkMotChieu.Checked)
                {
                    chieuDi = true;
                }
                else
                {
                    chieuDi = false;
                }
                int TinhThanhDiID = 0;
                int QuanHuyenDiID = 0;
                int QuanHuyenDenID = 0;
                int PhuongXaDiID = 0;
                int PhuongXaDenID = 0;
                bool isChiaSe = chkChiaSe.Checked;
                string TenLaiXe = txtTenLaiXe.Text.Trim();

                if (cbTinh_Di.SelectedIndex > 0)
                {
                    TinhThanhDiID = (int)cbTinh_Di.SelectedValue;
                }
                if (cbQH_Di.SelectedIndex > 0)
                {
                    QuanHuyenDiID = (int)cbQH_Di.SelectedValue;
                }
                if (cbQH_Den.SelectedIndex > 0)
                {
                    QuanHuyenDenID = (int)cbQH_Den.SelectedValue;
                }
                if (cb_PhuongXaDi.SelectedIndex > 0)
                {
                    PhuongXaDiID = (int)cb_PhuongXaDi.SelectedValue;
                }
                if (cb_PhuongXaDen.SelectedIndex > 0)
                {
                    PhuongXaDenID = (int)cb_PhuongXaDen.SelectedValue;
                }
                DateTime ThoiDiemTra = DateTime.MinValue;
                if (cbThoiDiemTra.Text != "")
                {
                    ThoiDiemTra = cbThoiDiemTra.DateTime;
                }

                
                if (objCheckCo.UpdateCheckCo(int.Parse(lbID.Text), txtSoHieuXe.Text, txtNoiDi.Text.ToUpperInvariant(), txtNoiDen.Text.ToUpperInvariant(),
                                       Convert.ToInt32(cbTinh_Den.SelectedValue), int.Parse(txtCoDau.Text), coCuoi,
                                       cbThoiDiemDon.DateTime, ThoiDiemTra, chieuDi, tongTien, txtGhiChu.Text, ThongTinDangNhap.USER_ID
                                       , TinhThanhDiID, QuanHuyenDiID, QuanHuyenDenID, PhuongXaDiID, PhuongXaDenID, TenLaiXe, txtDienThoai.Text.Trim(),isChiaSe,TrangThaiDuyet,G_isDaDuyet
                                       ) > 0)
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thông tin thành công", "Thông báo",
                      Taxi.MessageBox.MessageBoxButtonsBA.OK,
                      Taxi.MessageBox.MessageBoxIconBA.Information);
                    G_isDaDuyet = true;
                    isSuccess = true;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show("Cập nhật thông tin lỗi", "Thông báo",
                      Taxi.MessageBox.MessageBoxButtonsBA.OK,
                      Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
        }

        private void ChangeStartCommune()
        {
            if (cb_PhuongXaDi.SelectedValue != null
                && cb_PhuongXaDi.SelectedValue.ToString() != "0"
                && cbQH_Di.Items.Count > 0 && cbTinh_Di.Items.Count > 0 && G_isCompleted)
            {
                Commune objCommune = (Commune)cb_PhuongXaDi.SelectedItem;
                if (objCommune != null && objCommune.FK_DistrictID > 0)
                {
                    G_StartDistrictSelected = objCommune.FK_DistrictID;
                    cbQH_Di.SelectedValue = objCommune.FK_DistrictID;
                }
            }
        }

        private void ChangeStartDistrict()
        {
            if (cbQH_Di.SelectedValue != null && cbQH_Di.SelectedValue.ToString() != "0" && G_isCompleted)
            {
                District objDistrict = (District)cbQH_Di.SelectedItem;
                if (objDistrict != null)
                {
                    G_isCompleted = false;
                    G_arrCommuneDi_Filter = new List<Commune>();                    
                    G_arrCommuneDi_Filter.AddRange(G_arrCommune.FindAll(delegate(Commune T)
                                                                   {
                                                                       return (T.FK_DistrictID == objDistrict.PK_DistrictID);
                                                                   }));
                    LoadPhuongXaDi_ByFilter();
                    G_isCompleted = true;

                    G_StartProvinceSelected = objDistrict.FK_ProvinceID;
                    if (G_StartDistrictSelected != (int)cbQH_Di.SelectedValue)
                        cb_PhuongXaDi.SelectedIndex = 0;

                    if (objDistrict.FK_ProvinceID > 0)
                        cbTinh_Di.SelectedValue = objDistrict.FK_ProvinceID;
                }
            }
        }

        private void ChangeStartProvince()
        {
            if (cbTinh_Di.SelectedValue != null
                && cbTinh_Di.SelectedValue.ToString() != "0"
                && G_isCompleted)
            {
                G_isCompleted = false;
                G_arrDistrictDi_Filter = new List<District>();

                G_arrDistrictDi_Filter = G_arrDistrict.FindAll(delegate(District T)
                                                                     {
                                                                         return (T.FK_ProvinceID == (int)cbTinh_Di.SelectedValue);
                                                                     });
                LoadQuanHuyenDi_ByFilter();

                G_isCompleted = true;
                if ((int)cbTinh_Di.SelectedValue != G_StartProvinceSelected)
                {
                    cbQH_Di.SelectedIndex = 0;
                    cb_PhuongXaDi.SelectedIndex = 0;
                }
            }
        }

        private void ChangeEndCommune()
        {
            if (cb_PhuongXaDen.SelectedValue != null
                && cb_PhuongXaDen.SelectedValue.ToString() != "0"
                && cbQH_Den.Items.Count > 0 && cbTinh_Den.Items.Count > 0 && G_isCompleted)
            {
                Commune objCommune = (Commune)cb_PhuongXaDen.SelectedItem;
                if (objCommune != null && objCommune.FK_DistrictID > 0)
                {
                    G_EndDistrictSelected = objCommune.FK_DistrictID;
                    cbQH_Den.SelectedValue = objCommune.FK_DistrictID;
                }
            }
        }

        private void ChangeEndDistrict()
        {
            if (cbQH_Den.SelectedValue != null
                && cbQH_Den.SelectedValue.ToString() != "0" && G_isCompleted)
            {
                District objDistrict = (District)cbQH_Den.SelectedItem;
                if (objDistrict != null)
                {
                    G_isCompleted = false;
                    G_arrCommuneDen_Filter = new List<Commune>();
                    G_arrCommuneDen_Filter.AddRange(G_arrCommune.FindAll(delegate(Commune T)
                                                                   {
                                                                       return (T.FK_DistrictID == (int)cbQH_Den.SelectedValue);
                                                                   }));
                    LoadPhuongXaDen_ByFilter();
                    G_isCompleted = true;

                    G_EndProvinceSelected = objDistrict.FK_ProvinceID;
                    if (G_EndDistrictSelected != (int)cbQH_Den.SelectedValue)
                        cb_PhuongXaDen.SelectedIndex = 0;

                    if (objDistrict.FK_ProvinceID > 0)
                        cbTinh_Den.SelectedValue = objDistrict.FK_ProvinceID;
                }
            }
        }

        private void ChangeEndProvince()
        {
            if (cbTinh_Den.SelectedValue != null
                && cbTinh_Den.SelectedValue.ToString() != "0" && G_isCompleted)
            {
                G_isCompleted = false;
                G_arrDistrictDen_Filter = new List<District>();
                G_arrDistrictDen_Filter = G_arrDistrict.FindAll(delegate(District T)
                                                                     {
                                                                         return (T.FK_ProvinceID == (int)cbTinh_Den.SelectedValue);
                                                                     });
                LoadQuanHuyenDen_ByFilter();

                G_isCompleted = true;
                if ((int)cbTinh_Den.SelectedValue != G_EndProvinceSelected)
                {
                    cbQH_Den.SelectedIndex = 0;
                    cb_PhuongXaDen.SelectedIndex = 0;
                }
            }
        }

        #endregion
        
        #region KeyDown event

        private void txtSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Down)
            {
                txtTenLaiXe.Focus();
            }
        }

        private void txtDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtNoiDi.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                txtTenLaiXe.Focus();
            }
        }

        private void txtNoiDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                cbTinh_Den.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                txtDienThoai.Focus();
            }
        }

        private void txtCoDau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtCoCuoi.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                cbTinh_Den.Focus();
            }
        }

        private void cbThoiDiemDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                cbThoiDiemTra.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtNoiDen.Focus();
            }
        }
        
        private void txtNoiDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                cbThoiDiemDon.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                cbTinh_Den.Focus();
            }
        }

        private void txtCoCuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                chkMotChieu.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtCoDau.Focus();
            }
        }

        private void cbThoiDiemTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
               txtCoDau.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                cbThoiDiemDon.Focus();
            }
        }

        private void chkMotChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                chkHaiChieu.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                txtCoCuoi.Focus();
            }
        }

        private void chkHaiChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtTongTien.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                chkMotChieu.Focus();
            }
        }     

        private void txtTongTien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtGhiChu.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                chkHaiChieu.Focus();
            }
        }

        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                btnLuuThoat.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                txtTongTien.Focus();
            }
            else if (e.KeyData == Keys.Enter)
            {
                btnLuuThoat_Click(null, null);                
            }
        }

        private void btnLuuThoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                btnLuuTiep.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                txtGhiChu.Focus();
            }
        }

        private void btnLuuTiep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                btnThoat.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                btnLuuThoat.Focus();
            }
        }             

        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                txtSoHieuXe.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                btnThoat.Focus();
            }
        }

        private void btnThoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                btnDelete.Focus();
            }
            else if (e.KeyData == Keys.Up)
            {
                btnLuuTiep.Focus();
            }
        }

        private void cb_PhuongXaDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (cb_PhuongXaDi.Text == "")
            {
                cb_PhuongXaDi.SelectedValue = 0;
            }
        }
        
        private void cbQH_Di_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cbTinh_Di_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cbTinhThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                txtNoiDen.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtNoiDi.Focus();
            }            
        }

        private void cb_PhuongXaDen_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeEndCommune();
        }

        private void cbQH_Den_KeyDown(object sender, KeyEventArgs e)
        {
            ChangeEndDistrict();
        }

        private void txtTenLaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                txtSoHieuXe.Focus();
            }
            else if (e.KeyData == Keys.Down)
            {
                txtDienThoai.Focus();
            }
        }
        #endregion        

        #region Form Event
        private void txtCoDau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCoCuoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }        

        private void chkMotChieu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMotChieu.Checked)
            {
                chkHaiChieu.Checked = false;
            }
            else
            {
                chkHaiChieu.Checked = true;
            }
        }

        private void chkHaiChieu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHaiChieu.Checked)
            {
                chkMotChieu.Checked = false;
            }
            else
            {
                chkMotChieu.Checked = true;
            }
        }

        private void txtCoCuoi_TextChanged(object sender, EventArgs e)
        {
            cbThoiDiemTra.EditValue = DieuHanhTaxi.GetTimeServer();
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            if (ThongTinDangNhap.USER_ID == "admin" || ThongTinDangNhap.IsInRole("TC") || ThongTinDangNhap.IsInRole("GD"))
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có muốn xóa không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question) == "Yes")
                {
                    Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo = new Taxi.Business.CheckCoDuongDai.CheckCoDuongDai();
                    if (objCheckCo.DeleteCheckCo(int.Parse(lbID.Text), ThongTinDangNhap.USER_ID) > 0)
                    {
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin thành công", "Thông báo",
                          Taxi.MessageBox.MessageBoxButtonsBA.OK,
                          Taxi.MessageBox.MessageBoxIconBA.Information);
                        isSuccess = true;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Xóa thông tin lỗi", "Thông báo",
                          Taxi.MessageBox.MessageBoxButtonsBA.OK,
                          Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show("Bạn không có quyền xóa dữ liệu", "Thông báo",
                     MessageBox.MessageBoxButtonsBA.OK,
                     MessageBox.MessageBoxIconBA.Error);
            }
        }

        public void btnLuuThoat_Click(object sender, EventArgs e)
        {
            if (isInsert == true)
            {
                this.Insert();
            }
            else
            {
                this.UpdateCheckCo();
            }
        }

        public void btnLuuTiep_Click(object sender, EventArgs e)
        {
            if (isInsert == true)
            {
                this.Insert();
            }
            else
            {
                this.UpdateCheckCo();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.O))
            {
                txtSoHieuXe.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                txtNoiDi.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                txtNoiDen.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                txtCoDau.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.C))
            {
                txtCoCuoi.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                txtTongTien.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.U))
            {
                txtGhiChu.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.H))
            {
                cbTinh_Den.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D1))
            {
                chkMotChieu.Checked = true;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.D2))
            {
                chkHaiChieu.Checked = true;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region ==================Validate - Thông Báo============================================
        public enum BangMaValidate
        {
            ValidateSuccess = 0,            
            Msg1 = 1,
            Msg2 = 2,
            Msg3 = 3,
            Msg4 = 4,
            Msg5 = 5,
            Msg6 = 6,
            Msg7 = 7,
            Msg8 = 8
        }

        private const string MSG_VALIDATESUCCESS = "";
        private const string MSG_1 = "Hãy nhập số hiệu xe";
        private const string MSG_2 = "Số hiệu xe này không tồn tại. Hãy kiểm tra lại";
        private const string MSG_3 = "Hãy nhập nơi đi";
        private const string MSG_4 = "Hãy nhập cơ đầu";
        private const string MSG_5 = "Hãy nhập nơi đến";
        private const string MSG_6 = "Tỉnh thành không chính xác";
        private const string MSG_7 = "Hãy nhập số điện thoại";
        private const string MSG_8 = "Thời điểm đón không được lớn hơn thời điểm trả";

        /// <summary>
        /// hàm thực hiện validate thông tin form nhập
        /// co cuoc goi truyen vao
        /// </summary>
        private BangMaValidate ValidateFormNhap(Taxi.Business.CheckCoDuongDai.CheckCoDuongDai objCheckCo)
        {
            if (txtSoHieuXe.Text.Length <= 0)
            {
                txtSoHieuXe.Focus();
                return BangMaValidate.Msg1;
            }
            if (objCheckCo.CheckSoHieuXe(txtSoHieuXe.Text) == false)
            {
                txtSoHieuXe.Focus();
                return BangMaValidate.Msg2;
            }
            if (txtCoDau.Text.Length <= 0)
            {
                txtCoDau.Focus();
                return BangMaValidate.Msg4;
            }
            if (cbThoiDiemDon.DateTime > cbThoiDiemTra.DateTime)
            {
                cbThoiDiemDon.Focus();
                return BangMaValidate.Msg8;
            } 
            //Vạn An Hải Phòng không cần nhập tỉnh thành phố sân bay đường dài!
            //else if (cbTinh_Di.SelectedValue == null || cbTinh_Di.SelectedIndex == 0)
            //{
            //    return BangMaValidate.Msg6;
            //}
            //else if (cbTinh_Den.SelectedValue == null || cbTinh_Den.SelectedIndex == 0)
            //{
            //    return BangMaValidate.Msg6;
            //}
            //else if (txtDienThoai.Text.Trim() == "")
            //{
            //    return BangMaValidate.Msg7;
            //}
            else
            {
                return BangMaValidate.ValidateSuccess;
            }
        }

        private void HienThiThongBao(BangMaValidate maValidate)
        {
            if (maValidate == BangMaValidate.ValidateSuccess)
            {
                lblThongBao.Text = MSG_VALIDATESUCCESS;
            }
            else if (maValidate == BangMaValidate.Msg1)
            {
                lblThongBao.Text = MSG_1;
            }
            else if (maValidate == BangMaValidate.Msg2)
            {
                lblThongBao.Text = MSG_2;
            }
            else if (maValidate == BangMaValidate.Msg3)
            {
                lblThongBao.Text = MSG_3;
            }
            else if (maValidate == BangMaValidate.Msg4)
            {
                lblThongBao.Text = MSG_4;
            }
            else if (maValidate == BangMaValidate.Msg5)
            {
                lblThongBao.Text = MSG_5;
            }
            else if (maValidate == BangMaValidate.Msg6)
            {
                lblThongBao.Text = MSG_6;
            }
            else if (maValidate == BangMaValidate.Msg7)
            {
                lblThongBao.Text = MSG_7;
            }
            else if (maValidate == BangMaValidate.Msg8)
            {
                lblThongBao.Text = MSG_8;
            }
        }

        #endregion==============================================================

        private void cb_PhuongXaDi_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeStartCommune();
        }

        private void cbQH_Di_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeStartDistrict();
        }

        private void cbTinh_Di_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeStartProvince();
        }

        private void cb_PhuongXaDen_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeEndCommune();
        }

        private void cbQH_Den_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeEndDistrict();
        }

        private void cbTinh_Den_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeEndProvince();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.OK;
            ParentForm.Close();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}