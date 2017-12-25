using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Taxi.Business;
using Taxi.Business.DieuXeDuongDai;
using Taxi.Business.DM;
using Taxi.Controls.Base.Inputs;
using TaxiOperation_DieuXeDuongDai.Base.Extender;

namespace TaxiOperation_DieuXeDuongDai.DangKyDonKhach
{
    public partial class frmThemDangKyDonKhach : FormBase
    {
        #region Tập quyền
        /// <summary>
        /// Cờ có sử dụng quyền không?
        /// </summary>
        public bool Quyen = false;
        public string QuyenThem { get; set; }
        public string QuyenSua { get; set; }
        public string QuyenXoa { get; set; }
        public string QuyenXemLichSu { get; set; }
        #endregion

        #region biến nội bộ
        public DateTime ThoiDiemGoi;
        /// <summary>
        /// Cờ khi thay đổi dữ liệu
        /// </summary>
        private bool IsChangeData { get; set; }
        private DUONGDAI_KHACHHEN_XEDK _model;

        protected DUONGDAI_KHACHHEN_XEDK Model
        {
            get { return _model ?? (_model = new DUONGDAI_KHACHHEN_XEDK()); }
        }

        public void SetModel(DUONGDAI_KHACHHEN_XEDK model)
        {
            _model = model;
            if (_model == null || _model.Id == 0) return;
            btnXoa.Visible = true;
            btnLichSu.Visible = true;
            txtDienThoai.Text = _model.DienThoai;
            txtSoXe.Text = _model.SoXe;
            ThoiDiemGoi = _model.ThoiDiemGoi;
            lblThoiGianGoi.Text = ThoiDiemGoi.ToString("HH:mm dd/MM/yyyy");
            deThoiGianDon.EditValue = _model.ThoiDiemDon;
            txtDiemDo.Text = _model.DiemDo;
            txtGhiChu.Text = _model.GhiChu;
        }
        #endregion

        #region hàm xử lý

        public bool ValidateData()
        {
            this.FindAllChildrenByType<IShInput>().ToList().Where(p => !(p is PopupBaseEdit)).ToList().ForEach(p => ((BaseEdit)p).Text = ((BaseEdit)p).Text.Trim());
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
            if (string.IsNullOrEmpty(deThoiGianDon.Text.Trim()) || deThoiGianDon.EditValue == null)
            {
                SetError("Bạn chưa nhập thời gian đón");
                deThoiGianDon.Focus();
                return false;
            }
            else
            {
                if (ThoiDiemGoi >= deThoiGianDon.DateTime)
                {
                    SetError("Thời gian đón lớn hơn thời gian gọi");
                    deThoiGianDon.Focus();
                    return false;
                }
                Model.ThoiDiemDon = deThoiGianDon.DateTime;
            }
            if (string.IsNullOrEmpty(txtDiemDo.Text.Trim()))
            {
                SetError("Bạn chưa nhập điểm đỗ");
                txtDiemDo.Focus();
                return false;
            }
            else
            {
                Model.DiemDo = txtDiemDo.Text.Trim();
            }
            if (!Xe.KiemTraTonTaiCuaSoHieuXe(Model.SoXe))
            {
                SetError(string.Format("Xe '{0}' không tồn tại trong danh sách xe hệ thống",Model.SoXe));
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
                        Model.TrangThai = 1;

                        Model.CreatedBy = ThongTinDangNhap.USER_ID;
                        Model.UpdatedBy = string.Empty;
                        Model.Insert();
                    }
                    MessageBox.Show("Lưu thành công");
                    _model = null;
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
            if(Luu())
                this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.FindAllChildrenByType<IShInput>().ToList().ForEach(p => p.Clear());
            lblThoiGianGoi.Text = string.Empty;
            SetError("");
            if (_model != null && _model.Id > 0)
            {
                SetModel(_model);
            }
            else
            {
                SetModel(null);
                ThoiDiemGoi = CommonBL.GetTimeServer();
                deThoiGianDon.EditValue = CommonBL.GetTimeServer();
                lblThoiGianGoi.Text = ThoiDiemGoi.ToString("HH:mm dd/MM/yyyy");
            }
            IsChangeData = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SetError("");
            if (MessageBox.Show("Bạn có muốn xóa bảng ghi này không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
                var frm = new frmLichSuDangKyDonKhach();
                frm.SetId(_model.Id);
                frm.ShowDialog();
            }
        }

        private void frmThemDangKyDonKhach_Load(object sender, EventArgs e)
        {
            SendKeys.Send("%");
            SendKeys.Send("%");
            btnLamMoi.PerformClick();
            Action<object, EventArgs> textchange = (o, eventArgs) => { IsChangeData = true; };
            this.FindAllChildrenByType<IShInput>().ToList().ForEach(p => ((BaseEdit)p).TextChanged += new EventHandler(textchange));
            this.Activate();
            txtDienThoai.Focus();
        }
        #endregion
    }
}
