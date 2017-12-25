using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Business;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Business.DM;
using Taxi.Controls.Base.Inputs;
using TaxiOperation_DieuXeDuongDai.Base;
using TaxiOperation_DieuXeDuongDai.Base.Extender;

namespace TaxiOperation_DieuXeDuongDai.XeDiTinh
{
    public partial class frmThemXeDiTinh : FormBase
    {
        #region Tập quyền
        /// <summary>
        /// Có sử dụng quyền không?
        /// </summary>
        public bool Quyen = false;
        public string QuyenThem { get; set; }
        public string QuyenSua { get; set; }
        public string QuyenXoa { get; set; }
        public string QuyenXemLichSu { get; set; }
        #endregion

        #region Biến cục bộ
        public DateTime ThoiDiemGoi;
        private bool IsChangeData { get; set; }
        private DUONGDAI_DONKHACH_XEDITINH _model;

        protected DUONGDAI_DONKHACH_XEDITINH Model
        {
            get { return _model ?? (_model = new DUONGDAI_DONKHACH_XEDITINH()); }
        }

        public void SetModel(DUONGDAI_DONKHACH_XEDITINH model)
        {
            _model = model;
            if (_model == null || _model.Id == 0) return;
            btnXoa.Visible = true;
            btnLichSu.Visible = true;
            deThoiDiemBao.EditValue = _model.ThoiDiemDon;
            txtDienThoai.Text = _model.DienThoai;
            txtSoXe.Text = _model.SoXe;
            txtDiaChi.Text = _model.DiaChiDon;
            txtTongTien.EditValue = _model.TongTien;
            lupTrangThai.EditValue=_model.TrangThai;
            txtNguoiNhap.Text = _model.NguoiNhap;
            ThoiDiemGoi = _model.ThoiDiemGoi;
            txtGhiChu.Text = _model.GhiChu;
            if (_model.TrangThai == 2)// nếu trạng thái đã điều thì sẽ không cho sửa trạng thái.
            {
                lupTrangThai.Properties.ReadOnly = true;
            }
        }
        #endregion

        #region Hàm xử lý
        /// <summary>
        /// Kiểm tra giá trị trên form
        /// </summary>
        /// <returns></returns>
        public bool ValidateData()
        {
            // trim tự động cho tất cả các text box
            panelInput.FindAllChildrenByType<IShInput>().ToList().Where(p => !(p is PopupBaseEdit)).ToList().ForEach(p => ((BaseEdit)p).Text = ((BaseEdit)p).Text.Trim());
            SetError("");
            if (string.IsNullOrEmpty(deThoiDiemBao.Text.Trim()) || deThoiDiemBao.EditValue == null)
            {
                SetError("Bạn chưa nhập thời gian đón");
                deThoiDiemBao.Focus();
                return false;
            }
            else
            {
                //if (ThoiDiemGoi >= deThoiDiemBao.DateTime)
                //{
                //    SetError("Thời gian đón lớn hơn thời gian gọi");
                //    deThoiDiemBao.Focus();
                //    return false;
                //}
                Model.ThoiDiemDon = deThoiDiemBao.DateTime;
            }
            if (string.IsNullOrEmpty(txtSoXe.Text.Trim()))
            {
                SetError("Bạn chưa nhập số xe");
                txtSoXe.Focus();
                return false;
            }
            else
            {
                Model.SoXe = txtSoXe.Text.Trim();
            }
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
            if (string.IsNullOrEmpty(deThoiDiemBao.Text.Trim()) || deThoiDiemBao.EditValue == null)
            {
                SetError("Bạn chưa nhập thời điểm báo");
                deThoiDiemBao.Focus();
                return false;
            }
            else
            {
                //if (ThoiDiemGoi >= deThoiDiemBao.DateTime)
                //{
                //    SetError("Thời gian đón lớn hơn thời gian gọi");
                //    deThoiDiemBao.Focus();
                //    return false;
                //}
                Model.ThoiDiemDon = deThoiDiemBao.DateTime;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                SetError("Bạn chưa nhập địa chỉ");
                txtDiaChi.Focus();
                return false;
            }
            else
            {
                Model.DiaChiDon = txtDiaChi.Text.Trim();
            }
            if (!Xe.KiemTraTonTaiCuaSoHieuXe(Model.SoXe))
            {
                SetError(string.Format("Xe '{0}' không tồn tại trong danh sách xe hệ thống", Model.SoXe));
                txtSoXe.Focus();
                return false;
            }
            return true;
        }
        public bool Luu()
        {
            try
            {
                if (ValidateData())
                {
                    Model.GhiChu = txtGhiChu.Text.Trim();
                    Model.UpdatedDate = DateTime.Now;
                    Model.CreatedDate = DateTime.Now;
                    Model.ThoiDiemGoi = ThoiDiemGoi;
                    Model.TrangThai = int.Parse(lupTrangThai.EditValue.ToString());
                    long tong = 0;
                    long.TryParse(txtTongTien.Text, out tong);
                    Model.TongTien = tong;
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
                        Model.CreatedBy = ThongTinDangNhap.USER_ID;
                        Model.UpdatedBy = string.Empty;
                        Model.IsDelete = false;
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
        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            SetError("");
            if (Luu())
            {
                btnLamMoi.PerformClick();
            }

        }

        private void btnLuuThoat_Click(object sender, System.EventArgs e)
        {
            SetError("");
            if (Luu())
                this.Close();
        }

        private void btnLamMoi_Click(object sender, System.EventArgs e)
        {
            panelInput.FindAllChildrenByType<IShInput>().ToList().ForEach(p => p.Clear());
         //   lblThoiGianGoi.Text = string.Empty;
            SetError("");
            lupTrangThai.ItemIndex = 0;
            if (_model != null && _model.Id > 0)
            {
                SetModel(_model);
            }
            else
            {
                SetModel(null);
              
                txtNguoiNhap.Text = ThongTinDangNhap.USER_ID;
                ThoiDiemGoi = DUONGDAI_KHACHHEN.GetTimeServer();
                deThoiDiemBao.EditValue = ThoiDiemGoi;
                //lblThoiGianGoi.Text = ThoiDiemGoi.ToString("HH:mm dd/MM/yyyy");
            }
            txtSoXe.Focus();
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            SetError("");
            if (MessageBox.Show("Bạn có muốn xóa bảng ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Quyen && ThongTinDangNhap.HasPermission(this.QuyenXoa))
                {
                    SetError("Bạn không có quyền xóa");
                    return;
                }
                Model.UpdatedBy = ThongTinDangNhap.USER_ID;
                Model.Delete();
                btnLamMoi.PerformClick();
                _model = null;
                this.Close();
            }
        }

        private void btnLichSu_Click(object sender, System.EventArgs e)
        {
            SetError("");
            if (_model != null && _model.Id > 0)
            {
                if (Quyen && ThongTinDangNhap.HasPermission(this.QuyenXemLichSu))
                {
                    SetError("Bạn không có quyền xem lịch sử");
                    return;
                }
                var frm = new frmLichSuXeDiTinh();
                frm.SetId(_model.Id);
                frm.ShowDialog();
            }
        }

        private void frmThemXeDiTinh_Load(object sender, EventArgs e)
        {
            SendKeys.Send("%");
            SendKeys.Send("%");
            lupTrangThai.Properties.DataSource = CommonBL.GetTrangThaiXeDiTinh();
            Action<object, EventArgs> textchange = (o, eventArgs) => { IsChangeData = true; };
            panelInput.FindAllChildrenByType<IShInput>().ToList().ForEach(p => ((BaseEdit)p).TextChanged += new EventHandler(textchange));
            btnLamMoi.PerformClick();
            this.Activate();
            txtSoXe.Focus();
        }
        #endregion
    }
}
