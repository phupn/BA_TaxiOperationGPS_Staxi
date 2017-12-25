using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.XuLyDieuXe
{
    public partial class frmDieuXe : FormBase
    {
        #region Biến cục bộ
        private List<DUONGDAI_KHACHHEN> _khachhen;
        private List<DUONGDAI_KHACHHEN_XEDK> _khachhenXedk;
        private DateTime _timeKhachHen;
        private DateTime _timeXeDon;
        private int timeKhachHen = -1;
        private int timeXeDon = -1;
        private int _s = 0;
        #endregion

        #region Hàm xử lý
        private void LoadData()
        {
            _khachhen = new DUONGDAI_KHACHHEN().GetByTime(null).OrderBy(p => p.ThoiDiemDon).ToList();
            shGridControl1.SetDataSource(_khachhen);
            _khachhenXedk = new DUONGDAI_KHACHHEN_XEDK().GetByTime(null).OrderBy(p => p.ThoiDiemGoi).ToList();
            shGridControl2.SetDataSource(_khachhenXedk);
        }

        private void XuLyDuLieu()
        {
            //if (timeKhachHen>-1)
            //    timeKhachHen--;
            //if (timeXeDon > -1)
            //    timeXeDon--;
            //Thêm dữ liệu
            var db = new DUONGDAI_KHACHHEN().GetByTime(_timeKhachHen);
            if (db.Count > 0)
            {
                _timeKhachHen = CommonBL.GetTimeServer();
                db.ForEach(p =>
                {
                    var ldb = _khachhen.Where(p1 => p1.Id == p.Id).ToList();
                    //Khi có trạng thái chưa điều thì sẽ thêm mới hoặc là thay đổi.
                    if (p.TrangThai == 1)
                    {
                        if (ldb.Count > 0) // tồn tại thì sẽ khi sửa
                            ldb.ForEach(p1 => _khachhen.Remove(p1));
                        _khachhen.Add(p);
                    }
                    else
                    {
                        ldb.ForEach(p1 => _khachhen.Remove(p1));
                    }
                   
                });
            }
            var db1 = new DUONGDAI_KHACHHEN_XEDK().GetByTime(_timeXeDon);
            if (db1.Count > 0)
            {
                db1.ForEach(p =>
                {
                    var ldb = _khachhenXedk.Where(p1 => p1.Id == p.Id && p1.IsXeDangKy == p.IsXeDangKy).ToList();
                    if (p.TrangThai == 1)
                    {
                        if (ldb.Count > 0)
                            ldb.ForEach(p1 => _khachhenXedk.Remove(p1));
                        _khachhenXedk.Add(p);
                    }
                    else
                    {
                        ldb.ForEach(p1 => _khachhenXedk.Remove(p1));
                    }
                });
                _timeXeDon = CommonBL.GetTimeServer();
               
            }
            if (timeKhachHen == -1)
                shGridControl1.RefreshDataSource();
            if (timeKhachHen == 0)
            {
                shGridControl1.SetDataSource(_khachhen);
                shGridControl1.RefreshDataSource();
                timeKhachHen = -1;
            } 
            //--
            if (timeXeDon == -1)
                shGridControl2.RefreshDataSource();
            if (timeXeDon == 0)
            {
                shGridControl2.SetDataSource(_khachhenXedk);
                shGridControl2.RefreshDataSource();
                timeXeDon = -1;
            }
            // Khách hẹn
        }

        private void FormXuLyDieuXe()
        {
            var frm = new frmXuLyDieuXe();
            frm.SetModel(gridView1.GetFocusedRow() as DUONGDAI_KHACHHEN,_khachhenXedk);
            frm.ShowDialog();
        }
        #endregion

        #region Sự kiện
        private void timer_XuLyDuLieu_Tick(object sender, EventArgs e)
        {
            XuLyDuLieu();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormXuLyDieuXe();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                FormXuLyDieuXe();
            }
        }

        private void frmDieuXe_Load(object sender, EventArgs e)
        {
            reLoaiXe.DataSource = CommonBL.GetLoaiXe();
            reLoaiXe.DisplayMember = "TenLoaiXe";
            reLoaiXe.ValueMember = "LoaiXeID";
            _s = splitContainer1.SplitterDistance;
            LoadData();
            deNgayLichDon.EditValue = CommonBL.GetTimeServer().Date;
            deNgayXeDon.EditValue = CommonBL.GetTimeServer().Date;
            _timeKhachHen = CommonBL.GetTimeServer();
            _timeXeDon = CommonBL.GetTimeServer();
        }

        private void reXoa_Click(object sender, EventArgs e)
        {
            var enti = gridView2.GetFocusedRow() as DUONGDAI_KHACHHEN_XEDK;
            if (enti != null)
            {
                enti.UpdatedBy = ThongTinDangNhap.USER_ID;
                if (enti.IsXeDangKy == 0)
                {
                    var frm = new frmXeDiTinhXoa();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this._khachhenXedk.Remove(enti);
                        if(!string.IsNullOrEmpty(frm.GhiChu))enti.GhiChu = enti.GhiChu + "- Điều:" + frm.GhiChu;
                        enti.TrangThai = int.Parse(frm.LyDo.Trim());
                        shGridControl2.RefreshDataSource();
                        enti.DeleteDieuXe();
                    }
                }
                else
                {
                    if (
                    MessageBox.Show("Bạn có muốn xóa bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this._khachhenXedk.Remove(enti);
                        shGridControl2.RefreshDataSource();
                        enti.TrangThai = 3;
                        enti.DeleteDieuXe();
                    }
                   
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = piAn.Visible?splitContainer1.Width : _s;
            piAn.Visible = piHien.Visible;
            piHien.Visible = !piHien.Visible;
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle>0&&(gridView2.GetRow(e.RowHandle) as DUONGDAI_KHACHHEN_XEDK).IsXeDangKy==0)
            {
                e.Appearance.BackColor=Color.Plum;
            }
        }

        private void btnTimDonKhach_Click(object sender, EventArgs e)
        {
            //if (deNgayLichDon.EditValue == null)
            //{
            //    MessageBox.Show("Bạn chưa chọn ngày đón khách để tìm kiếm");
            //    return;
            //}
            timeKhachHen = 10;
            var db = new DUONGDAI_KHACHHEN().DieuxeTimKiem(deNgayLichDon.EditValue == null?(DateTime?)null:deNgayLichDon.DateTime, txtSDT.Text, txtDiaChi.Text,
                txtTenKhachHang.Text).OrderBy(p=>p.ThoiDiemDon).ToList();
            
            shGridControl1.SetDataSource(db);
            shGridControl1.Refresh();
            if (db == null || db.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
            }

        }

        private void btnTimXeDon_Click(object sender, EventArgs e)
        {

            //if (deNgayXeDon.EditValue == null)
            //{
            //    MessageBox.Show("Bạn chưa chọn ngày xe đón để tìm kiếm");
            //    return;
            //}
            var db = new DUONGDAI_KHACHHEN_XEDK().DieuxeTimKiem(deNgayXeDon.EditValue==null ?(DateTime?) null:deNgayXeDon.DateTime, txtSoxe.Text, txtDiemDo.Text).OrderBy(p => p.ThoiDiemGoi).ToList();
            shGridControl2.SetDataSource(db);
            shGridControl2.Refresh();
            timeXeDon = 10;
            if (db.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu.");
            }
        }
        #endregion

        private void gridView2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void shGridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                shGridControl1.SetDataSource(_khachhen);
                shGridControl1.RefreshDataSource();
                timeKhachHen = -1;
                deNgayLichDon.EditValue = CommonBL.GetTimeServer();
                txtSDT.Text = string.Empty;
                txtDiaChi.Text = string.Empty;
                txtTenKhachHang.Text=string.Empty;
            }
        }

        private void shGridControl2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                shGridControl2.SetDataSource(_khachhenXedk);
                shGridControl2.RefreshDataSource();
                timeXeDon = -1;
                deNgayXeDon.EditValue = CommonBL.GetTimeServer();
                txtSoxe.Text = string.Empty;
                txtDiemDo.Text = string.Empty;
            }
        }
    }
}
