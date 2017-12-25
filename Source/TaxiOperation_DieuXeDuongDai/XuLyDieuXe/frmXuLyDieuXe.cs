using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.XuLyDieuXe
{
    public partial class frmXuLyDieuXe : FormBase
    {
        #region Biến cục bộ
        private DateTime thoigianDieu { get; set; }
        private DUONGDAI_KHACHHEN _model;
        private List<DUONGDAI_KHACHHEN_XEDK> _xedks;
        public void SetModel(DUONGDAI_KHACHHEN model,List<DUONGDAI_KHACHHEN_XEDK> xedks)
        {
            _xedks = xedks;
            _model = model;
            inLoaiXe.Properties.DataSource = CommonBL.GetLoaiXe();
            inLoaiXe.Properties.DisplayMember = "TenLoaiXe";
            inLoaiXe.Properties.ValueMember = "LoaiXeID";
            lblThoiGianDon.Text = _model.ThoiDiemDon.ToString("HH:mm dd/MM/yyyy");
            lblDiaChiDon.Text = _model.DiaChiDon;
            lblDiaChiTra.Text = _model.DiaChiTra;
            lblGhiChu.Text = _model.GhiChu;
            lblTongTien.Text = _model.TongTien.ToString("#,###.##");
            lblTenKH.Text = _model.TenKhachHang;
            txtXeDon.Text = _model.XeDon;
            lblBaoTruoc.Text = _model.SoPhutBaoTruoc.ToString();
            txtGhiChu.Text = _model.GhiChuDieu;
            inLoaiXe.SetValue(_model.LoaiXe);
            txtXeDon.Focus();

        }
        #endregion
        
        #region Sự kiện
        private void frmXuLyDieuXe_Load(object sender, System.EventArgs e)
        {
            SendKeys.Send("%");
            SendKeys.Send("%");
            lupTrangThai.Properties.DataSource = CommonBL.GetTrangThaiDatLichDonKhach();
            lupTrangThai.ItemIndex = 1;
            thoigianDieu = CommonBL.GetTimeServer();
            lblThoiGianDieu.Text = thoigianDieu.ToString("HH:mm dd/MM/yyyy");
            this.Activate();
            txtXeDon.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtXeDon.Text.Trim()))
                {
                    MessageBox.Show("Bạn chưa nhập xe đón.");
                    txtXeDon.Focus();
                    return;
                }
                if (_xedks == null || _xedks.Count == 0)
                {
                    MessageBox.Show("Không có xe đăng ký nào.");
                    return;
                }
                var xe = _xedks.Where( p => p.SoXe.Contains(txtXeDon.Text.Trim())).OrderByDescending(p=>p.ThoiDiemGoi).FirstOrDefault();
                if (xe == null)
                {
                    MessageBox.Show("Xe đón chưa đăng ký hoặc đã được điều");
                    return;
                }
                _model.TrangThai = int.Parse(lupTrangThai.GetValue().ToString());
                _model.XeDon = txtXeDon.Text;
                _model.GhiChuDieu = txtGhiChu.Text;
                _model.UpdateDieuXe();

                xe.FK_DUONGDAI_KHACHHEN = _model.Id;
                xe.TrangThai = 2; //Trạng thái đã điều
                xe.UpdatedBy = ThongTinDangNhap.USER_ID;
                xe.UpdateDieuXe();
                MessageBox.Show("Xe đã điều thành công");
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Trong quá trình xử lý xảy ra lỗi ngoại lệ.\nVui lòng liên hệ với hỗ trợ viên.\nLỗi:" +
                                ex.Message);
            }
           
        }
        private void txtXeDon_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
