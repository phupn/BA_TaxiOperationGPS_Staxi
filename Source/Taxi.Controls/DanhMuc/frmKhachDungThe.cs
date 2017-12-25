using System;
using Taxi.Business;
using Taxi.Controls.Base;
using Taxi.Data.DM;
using Taxi.MessageBox;

namespace Taxi.Controls.DanhMuc
{
    public partial class frmKhachDungThe : FormBase
    {
        private KhachHangDungThe _model;
        private bool isEdit;
        public frmKhachDungThe()
        {
            InitializeComponent();
        }
        public frmKhachDungThe(KhachHangDungThe model)
        {
            InitializeComponent();
            _model = model;
            isEdit = true;
        }

        private void frmKhachDungThe_Load(object sender, System.EventArgs e)
        {
            try
            {
                if (_model != null)
                {
                    txtMaThe.EditValue = _model.MaThe;
                    _model.MaThe = txtMaThe.Text;
                    txtMaKH.Text = _model.MaKhachHang;
                    txtTenKH.Text = _model.TenKhachHang;
                    txtSDT.Text = _model.SoDienThoai;
                    deTuNgay.DateTime = _model.TuNgay;
                    deDenNgay.DateTime = _model.DenNgay;
                    txtDiaChi.Text=_model.DiaChi;
                }
                else
                {
                    _model = new KhachHangDungThe();
                    txtMaThe.EditValue = _model.GetMaThe();
                    deDenNgay.DateTime = DateTime.Now;
                    deTuNgay.DateTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Load Khách dùng thẻ cập nhật", ex);
            }
        }

        private void btnLuu_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Validate
                if (deTuNgay.EditValue == null)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa nhập từ ngày.", "Thông báo", MessageBoxButtonsBA.OK);
                    deTuNgay.Focus();
                    return;
                }
                if (deDenNgay.EditValue == null)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa nhập đến ngày.", "Thông báo", MessageBoxButtonsBA.OK);
                    deDenNgay.Focus();
                    return;
                }
                if (deDenNgay.DateTime.Date < deTuNgay.DateTime.Date)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn vui lòng nhập đến ngày lớn hơn từ ngày.", "Thông báo", MessageBoxButtonsBA.OK);
                    deDenNgay.Focus();
                    return;
                }
                if (txtMaKH.Text.Trim()=="")
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa nhập Mã KH.", "Thông báo", MessageBoxButtonsBA.OK);
                    txtMaKH.Focus();
                    return;
                }
                if (txtTenKH.Text.Trim() == "")
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa nhập tên KH.", "Thông báo", MessageBoxButtonsBA.OK);
                    txtTenKH.Focus();
                    return;
                }
                if (txtSDT.Text.Trim() == "")
                {
                    new MessageBox.MessageBoxBA().Show("Bạn chưa nhập SĐT.", "Thông báo", MessageBoxButtonsBA.OK);
                    txtSDT.Focus();
                    return;
                }
                _model.MaThe = txtMaThe.Text;
                _model.MaKhachHang = txtMaKH.Text.Trim();
                _model.TenKhachHang = txtTenKH.Text.Trim();
                _model.SoDienThoai = txtSDT.Text.Trim();
                _model.TuNgay = deTuNgay.DateTime.Date;
                _model.DenNgay = deDenNgay.DateTime.Date;
                _model.DiaChi = txtDiaChi.Text;
                //Lưu
                _model.Save();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Trong quá trình Lưu khách dùng thẻ sảy ra bị lỗi.\nLiên hệ với quản lý để khắc phục lỗi.", "Thông báo", MessageBoxButtonsBA.OK);
                LogError.WriteLogError("Lưu khách dùng thẻ", ex);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
