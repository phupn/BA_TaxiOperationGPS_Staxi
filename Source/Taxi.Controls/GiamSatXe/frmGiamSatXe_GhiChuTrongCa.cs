using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.GiamSatXe;
using Taxi.Common.Attributes;
using Taxi.Business;

namespace TaxiOperation_BanCo.GiamSatXe
{

    public partial class frmGiamSatXe_GhiChuTrongCa : FormBase
    {
        #region Ini_Form
        GiamSatXe_Shift shift = new GiamSatXe_Shift();
        GiamSatXe_Shift ca;
        GiamSatXe_ShiftNotes shiftNote;
        private Int64 ID;
        private string user;
        private string ghichu;
        private string TrangThaiCa = "";
        DateTime TimeServer;
        public frmGiamSatXe_GhiChuTrongCa()
        {
            InitializeComponent();
            TimeServer = CommonBL.GetTimeServer();
            Ini();
            ID = -1;
            LoadData_ShiftNote();
            gridView2.IndicatorWidth = 40;
        }
        #region LoadData_ShiftNote()
        private void Ini()
        {

            shiftNote = new GiamSatXe_ShiftNotes();
            shift.loadShift(ThongTinCauHinh.GetThongTinCa(1).Rows[0]);
            cbCa.SelectedItem = shift.GetCaNow();
            TrangThaiCa = cbCa.EditValue.ToString();
            Time.EditValue = CommonBL.GetTimeServer();
            user = Taxi.Business.ThongTinDangNhap.USER_ID;
        }
        private void LoadData_ShiftNote()
        {
            grdGhiChu.DataSource = shiftNote.GetToDay();
            grdGhiChu.Update();
        }
        private bool CheckTime()
        {
            lblMsg.Text = "";
            if (!ThongTinDangNhap.HasPermission(DanhSachQuyen.ThemGhiChuTrongCaKhac))
            {
                var end = ca.End.TimeOfDay;
                var start = ca.Start.TimeOfDay;
                var n = DateTime.Parse(Time.EditValue.ToString()).TimeOfDay;
                if ((n >= start && n < end) || ((n >= start && n <= (new TimeSpan(23, 59, 59)) || (new TimeSpan(0, 0, 0) <= n && n < end)) && ca.ShiftName.Contains("3")))
                {
                    if (DateTime.Now < DateTime.Parse(Time.EditValue.ToString()))
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = "Thời điểm lớn hơn thời điểm hiện tại";
                        return false;
                    }
                    return true;
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Thời điểm nằm ngoài thời gian của ca " + cbCa.Text;
                    return false;
                }
            }
            return true;
        }
        #endregion
        #endregion

        #region Các Nút Chức năng
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = "";
                if (!CheckTime()) return;
                if (txtGhiChu.Text.Trim() == "")
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Ghi chú không được bỏ trống";
                    txtGhiChu.Focus();
                    return;
                }

                //MessageBox.Show(loginUser);
                shiftNote.Shift = cbCa.Text.Trim();
                shiftNote.Time = TimeServer.Date.Add(DateTime.Parse(Time.EditValue.ToString()).TimeOfDay);
                shiftNote.CreatedDate = TimeServer;
                shiftNote.CreatedByUser = user;
                shiftNote.UpdatedDate = null;

                shiftNote.Id = this.ID;
                if (this.ID <= 0)
                {
                    shiftNote.Description = txtGhiChu.Text;
                    shiftNote.Insert();
                    btnLamMoi_Click(null, null);
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Lưu thành công";
                }
                else if (user.Equals(Taxi.Business.ThongTinDangNhap.USER_ID))
                {
                    shiftNote.Description = txtGhiChu.Text;
                    shiftNote.UpdatedByUser = Taxi.Business.ThongTinDangNhap.USER_ID;
                    shiftNote.UpdatedDate = TimeServer;
                    shiftNote.Update();
                    btnLamMoi_Click(null, null);
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Cập nhật thành công";
                }
                else if (Taxi.Business.ThongTinDangNhap.USER_ID.Equals("admin"))
                {
                    shiftNote.Description = ghichu;
                    shiftNote.UpdatedByUser = Taxi.Business.ThongTinDangNhap.USER_ID;
                    shiftNote.UpdatedDate = TimeServer;
                    shiftNote.Update();
                    btnLamMoi_Click(null, null);
                    lblMsg.ForeColor = Color.Blue;
                    lblMsg.Text = "Cập nhật thành công";
                }
                else
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Bạn không được phép sửa ghi chú này!";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Lỗi thao tác!";
                return;
            }



        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.ID <= 0) { lblMsg.ForeColor = Color.Red; lblMsg.Text = "Chưa chọn để xóa"; return; }
            if (new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn muốn xóa ghi chú này không?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo) != System.Windows.Forms.DialogResult.Yes.ToString()) return;
            lblMsg.Text = "";
            shiftNote.Id = this.ID;
            if (shiftNote.Delete() > 0)
            {
                btnLamMoi_Click(null, null);
                lblMsg.ForeColor = Color.Blue;
                lblMsg.Text = "Xóa thành công";
            }
            else
            {
                btnLamMoi_Click(null, null);
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Xóa không thành công";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            frmGiamSatXe_GhiChuTrongCa_TimKiem tk = new frmGiamSatXe_GhiChuTrongCa_TimKiem(shift.GetCaNow());
            tk.ShowDialog();
            if (tk.data == null) return;
            if (tk.data.Rows.Count == 0)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Không tìm thấy kết quả tìm kiếm nào";
                grdGhiChu.DataSource = null;
                grdGhiChu.Update();
            }
            else
            {
                grdGhiChu.DataSource = tk.data;
                grdGhiChu.Update();
            }
            cbCa.Focus();

        }
        #endregion

        #region Event
        private void txtGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.TrimStart();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtGhiChu.Text = txtGhiChu.Text.TrimStart();
        }

        private void txtGhiChu_KeyUp(object sender, KeyEventArgs e)
        {
            lblMsg.Text = "";
            txtGhiChu.Text = txtGhiChu.Text.TrimStart();
        }

        private void cbCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            ca = shift.GetShift(cbCa.Text.Trim());
            Time.EditValue = ca.Start;

        }

        private void Time_EditValueChanged(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            CheckTime();

        }
        

        private void grdGhiChu_MouseClick(object sender, MouseEventArgs e)
        {
        }


        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView2_Click(object sender, EventArgs e)
        {

            try
            {
                lblMsg.Text = "";
                var row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                this.ID = Int64.Parse(row["Id"].ToString());
                cbCa.EditValue = row["Shift"].ToString();
                Time.EditValue = DateTime.Parse(row["Time"].ToString());
                txtGhiChu.Text = row["Description"].ToString();
                user = row["CreatedByUser"].ToString();
                ghichu = row["Description"].ToString();
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Bắt sự kiện bàn phím
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            lblMsg.Text = "";
            //if (keyData == Keys.Down)
            //{
            //    ProcessTabKey(true);
            //    return true;
            //}
            //if (keyData == Keys.Up)
            //{
            //    ProcessTabKey(false);
            //    return true;
            //}
            if (keyData == (Keys.Control | Keys.F))
            {
                btnTimKiem_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        protected override bool ProcessTabKey(bool forward)
        {
            return base.ProcessTabKey(forward);
        }
        #endregion

        private void Time_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        [MethodWithKey(Keys= Keys.F5)]
        private void LamMoi()
        {
            lblMsg.Text = "";
            txtGhiChu.Text = "";
            this.ID = 0;
            Ini();
            LoadData_ShiftNote();
        }
    }
}