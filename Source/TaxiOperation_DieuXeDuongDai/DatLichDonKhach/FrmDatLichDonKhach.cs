using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GMap.NET;
using Taxi.Business;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Business.DM;
using Taxi.Controls.Base.Inputs;
using TaxiOperation_DieuXeDuongDai.Base;
using TaxiOperation_DieuXeDuongDai.Base.Extender;

namespace TaxiOperation_DieuXeDuongDai
{
    public partial class FrmDatLichDonKhach : FormBase
    {
        #region Tập Quyền
        /// <summary>
        /// Cờ để sử dụng quyền hay là ko
        /// </summary>
        public bool Quyen = false;
        public string QuyenThem { get; set; }
        public string QuyenSua { get; set; }
        public string QuyenXoa { get; set; }
        public string QuyenXemLichSu { get; set; }
        #endregion

        #region Biến nội bộ
        private bool IsChangeData { get; set; }
        public DateTime ThoiDiemGoi;
        public PointLatLng ToaDo;
        private DUONGDAI_KHACHHEN _model;
        protected DUONGDAI_KHACHHEN Model
        {
            get { return _model ?? (_model = new DUONGDAI_KHACHHEN()); }
        }
        public void SetModel(DUONGDAI_KHACHHEN model)
        {
            _model = model;
            if (_model == null || _model.Id == 0) return;
            btnXoa.Visible = true;
            btnLichSu.Visible = true;
            ThoiDiemGoi = _model.ThoiDiemGoi;
            lblThoiGianGoi.Text = ThoiDiemGoi.ToString("HH:mm:ss dd/MM/yyyy");
            txtDienThoai.Text = _model.DienThoai;
            txtDiaChiDon.Text = _model.DiaChiDon;
            deThoiGianDon.EditValue = _model.ThoiDiemDon;
            txtDiaChiTra.Text = _model.DiaChiTra;
            txtTenKhachHang.Text = _model.TenKhachHang;
            ccbLoaiXe.SetValue(_model.LoaiXe);
            txtTongTien.EditValue = _model.TongTien;
            ccbTrangThai.SetValue(_model.TrangThai);
            txtBaoTruoc.EditValue = _model.SoPhutBaoTruoc;
            txtXeNhan.Text = _model.XeNhan;
            txtGhiChu.Text = _model.GhiChu;
            ccbTrangThai.EditValue = _model.TrangThai;
            txtXeDon.Text = _model.XeDon;
            ToaDo = new PointLatLng(_model.ViDo, _model.KinhDo);
            if (_model.TrangThai == 2)
            {
                ccbTrangThai.Properties.ReadOnly = true;
            }
        }
        #endregion

        #region Hàm xử lý
        /// <summary>
        /// Kiểm tra dữ liệu đưa vào
        /// </summary>
        /// <returns>true là thỏa mãi/fase là lỗi</returns>
        private bool ValidateData()
        {
            panelInput.FindAllChildrenByType<IShInput>().ToList().Where(p => !(p is PopupBaseEdit)).ToList().ForEach(p => ((BaseEdit)p).Text = ((BaseEdit)p).Text.Trim());
            SetError("");
            if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                SetError("Bạn chưa nhập số điện thoại");
                txtDienThoai.Focus();
                return false;
            }
            else
            {
                Model.DienThoai = txtDienThoai.Text.Trim();
            }
            if (string.IsNullOrEmpty(txtDiaChiDon.Text.Trim()))
            {
                SetError("Bạn chưa nhập địa chỉ đón");
                txtDiaChiDon.Focus();
                return false;
            }
            else
            {
                Model.DiaChiDon = txtDiaChiDon.Text.Trim();
            }
            if (string.IsNullOrEmpty(deThoiGianDon.Text.Trim()) || deThoiGianDon.EditValue == null)
            {
                SetError("Bạn chưa nhập thời gian đón");
                deThoiGianDon.Focus();
                return false;
            }
            else
            {
                if (deThoiGianDon.DateTime <= ThoiDiemGoi)
                {
                    SetError("Thời gian đón lớn hơn thời gian gọi");
                    deThoiGianDon.Focus();
                    return false;
                }
                Model.ThoiDiemDon = deThoiGianDon.DateTime;
            }
            Model.DiaChiTra = txtDiaChiTra.Text.Trim();

            if (string.IsNullOrEmpty(txtTenKhachHang.Text.Trim()))
            {
                SetError("Bạn chưa nhập tên khách hàng");
                txtTenKhachHang.Focus();
                return false;
            }
            else
            {
                Model.TenKhachHang = txtTenKhachHang.Text.Trim();
            }
            if (string.IsNullOrEmpty(ccbLoaiXe.EditValue.ToString()))
            {
                SetError("Bạn chưa chọn loại xe");
                ccbLoaiXe.Focus();
                return false;
            }
            else
            {
                Model.LoaiXe = ccbLoaiXe.GetValue().ToString();
            }
          
            if (ccbTrangThai.EditValue == null)
            {
                SetError("Bạn chưa chọn trạng thái");
                ccbTrangThai.Focus();
                return false;
            }
            else
            {
                Model.TrangThai = int.Parse(ccbTrangThai.GetValue().ToString());
            }
            if (!string.IsNullOrEmpty(txtXeNhan.Text))
            {
                string ms = string.Empty;
                if (!Xe.KiemTraTonTaiCuaDanhSachSoHieuXe(txtXeNhan.Text,out ms))
                {
                    SetError(string.Format("Bạn nhập xe nhận '{0}' không tồn tại trong hệ thống",ms));
                    txtXeNhan.Focus();
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(txtXeDon.Text))
            {
                string ms = string.Empty;
                if (!Xe.KiemTraTonTaiCuaDanhSachSoHieuXe(txtXeDon.Text, out ms))
                {
                    SetError(string.Format("Bạn nhập xe đón '{0}' không tồn tại trong hệ thống", ms));
                    txtXeDon.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool Luu()
        {
            try
            {
                if (ValidateData())
                {
                    Model.TongTien = string.IsNullOrEmpty(txtTongTien.Text.Trim())
                        ? 0
                        : float.Parse(txtTongTien.Text.Trim());
                    Model.SoPhutBaoTruoc = int.Parse(txtBaoTruoc.Text.Trim());
                    Model.XeNhan = txtXeNhan.Text.Trim();
                    Model.GhiChu = txtGhiChu.Text.Trim();
                    Model.XeDon = txtXeDon.Text.Trim();
                    Model.CreatedDate = DUONGDAI_KHACHHEN.GetTimeServer();
                    Model.UpdatedDate = DUONGDAI_KHACHHEN.GetTimeServer();
                    Model.ViDo = (float) ToaDo.Lat;
                    Model.KinhDo = (float) ToaDo.Lng;
                    Model.MaNVDieu = ThongTinDangNhap.USER_ID;
                    if (Model.Id > 0)
                    {
                        if (Quyen && ThongTinDangNhap.HasPermission(this.QuyenSua))
                        {
                            SetError("Bạn không có quyền sửa");
                            return false;
                        }
                        if (!IsChangeData)
                        {
                            btnXoa.Visible = false;
                            btnLichSu.Visible = false;
                            _model = null;
                            MessageBox.Show("Lưu thành công");
                            return true;
                        }
                        Model.UpdatedBy = ThongTinDangNhap.USER_ID;
                        Model.Update();
                    }
                    else
                    {
                        if (Quyen && ThongTinDangNhap.HasPermission(this.QuyenThem))
                        {
                            SetError("Bạn không có quyền thêm");
                            return false;
                        }
                        Model.ThoiDiemDieu = ThoiDiemGoi;
                        Model.ThoiDiemGoi = ThoiDiemGoi;

                        Model.CreatedBy = ThongTinDangNhap.USER_ID;
                        Model.UpdatedBy = string.Empty;
                        Model.Insert();
                    }
                    btnXoa.Visible = false;
                    btnLichSu.Visible = false;
                    _model = null;
                    MessageBox.Show("Lưu thành công");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trong quá trình xử lý xảy ra lỗi ngoại lệ.\nVui lòng liên hệ với hỗ trợ viên.\nLỗi:" +
                                ex.Message);
            }
            return false;
        }

        private void SetError(string msg)
        {
            lblMsg.ForeColor = Color.Red;
            lblMsg.Text = msg;
        }
        #endregion

        #region Sự kiện
        private void FrmDatLichDonKhach_Load(object sender, EventArgs e)
        {
            SendKeys.Send("%");
            SendKeys.Send("%"); 
            panelInput.FindAllChildrenByType<IShControl>().ToList().ForEach(p => p.Bind());
            ccbLoaiXe.Properties.DataSource = CommonBL.GetLoaiXe();
            ccbLoaiXe.Properties.DisplayMember = "TenLoaiXe";
            ccbLoaiXe.Properties.ValueMember = "LoaiXeID";
            ccbTrangThai.Properties.DataSource = CommonBL.GetTrangThaiDatLichDonKhach();
            btnLamMoi.PerformClick();
            Action<object, EventArgs> textchange = (o, eventArgs) => { IsChangeData = true; };
            panelInput.FindAllChildrenByType<IShInput>().ToList().ForEach(p => ((BaseEdit)p).TextChanged += new EventHandler(textchange));
            txtDienThoai.Focus();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            SetError("");
            if (_model != null && _model.Id > 0)
            {
                if (Quyen && ThongTinDangNhap.HasPermission(this.QuyenXemLichSu))
                {
                    SetError("Bạn không có quyền xem lịch sử");
                    return;
                }
                var frm = new frmLichSuDatLichDonKhach();
                frm.SetID(_model.Id);
                frm.ShowDialog();
            }
          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SetError("");
            if (Luu())
            {
                btnLamMoi.PerformClick();
            }
           
        }

        private void btnLuuThoat_Click(object sender, EventArgs e)
        {
            SetError("");
            if (Luu())
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetError("");
            panelInput.FindAllChildrenByType<IShInput>().ToList().ForEach(p => p.Clear());
            lblThoiGianGoi.Text = string.Empty;
            ccbTrangThai.ItemIndex = 0;
            SetError("");
            txtDienThoai.Focus();
            txtBaoTruoc.EditValue = 180;
            if (_model != null && _model.Id > 0)
            {
                SetModel(_model);
            }
            else
            {
                ThoiDiemGoi = DUONGDAI_KHACHHEN.GetTimeServer();
                lblThoiGianGoi.Text = ThoiDiemGoi.ToString("HH:mm:ss dd/MM/yyyy");
                SetModel(null);
            }
            txtNguoiNhap.Text = ThongTinDangNhap.USER_ID;
            IsChangeData = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SetError("");
            if (
                MessageBox.Show("Bạn có muốn xóa bảng ghi này không?", "Thông báo", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Quyen&&ThongTinDangNhap.HasPermission(this.QuyenXoa))
                {
                    SetError("Bạn không có quyền xóa");
                    return ;
                }
                Model.UpdatedBy = ThongTinDangNhap.USER_ID;
                Model.Delete();
                btnLamMoi.PerformClick();
                _model = null;
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SetError("");
            using (var frm = new frmMap())
            {
                frm.ToaDo = ToaDo;
                frm.DiaChi = txtDiaChiDon.Text.Trim();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frm.DiaChi))
                    {
                        txtDiaChiDon.Text = frm.DiaChi;
                        ToaDo = frm.ToaDo;
                    }
                }
               
            }
            
           
        }

        private void ccbLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyData == (Keys.Control|Keys.Space) )
            {
                ccbLoaiXe.ShowPopup();
            }
        }
        #endregion
    }
}
