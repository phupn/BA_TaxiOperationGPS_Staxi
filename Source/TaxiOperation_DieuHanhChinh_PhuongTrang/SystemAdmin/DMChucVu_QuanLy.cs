using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
using Taxi.Business;
namespace Taxi.GUI {
	public partial class DMChucVu_QuanLy: Form {

        // Biến toàn cục
        string glbTenChucVu;

		public DMChucVu_QuanLy() {
			InitializeComponent();
			 
		}
        private void DMChucVu_QuanLy_Load(object sender, EventArgs e)
        {

            dgrChucVu.AutoGenerateColumns = false;
            LayDsChucVu();
            ResetControlAfterEdit();
            dgrChucVu.ReadOnly = true;
            if (dgrChucVu.RowCount > 1)
            {
                glbTenChucVu = dgrChucVu.Rows[0].Cells["TenChucVu"].Value.ToString();
                txtChucVu.Text = glbTenChucVu;
            }
        }
        /// <summary>
        /// Load danh sách các chức vụ lên control gridview
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public void LayDsChucVu()
        {
            TuDienChucVu objTuDienChucVu = new TuDienChucVu();
            DataTable dtChucVu = objTuDienChucVu.LayDanhSach();
            ThemSTT(dtChucVu);
            dgrChucVu.DataSource = dtChucVu;

        }
        /// <summary>
        /// Khi người dùng click chọn  một chức vụ trên gridview
        ///  - Load thông tin về chức vụ đó lên textbox TenLoaiNghiepVu
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void dgrChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int intRowPost = dgrChucVu.CurrentCell.RowIndex;
            string strTenChucVu = dgrChucVu.Rows[intRowPost].Cells[0].Value.ToString();
            //Đặt giá trị cho biến toàn cục glbTenChucVu
            glbTenChucVu = strTenChucVu;
            //Ghi tên chức vụ được chọn lên textbox txtTenLoaiNghiepVu
            txtChucVu.Text = strTenChucVu;
        }

        /// <summary>
        /// Thêm mới một chức vụ
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            glbTenChucVu = "";
            txtChucVu.Text = "";
            SetControlForEdit();
        }
        /// <summary>
        /// Cập nhật thông tin cho một chức vụ
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (glbTenChucVu.Length == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa chọn chức vụ để sửa!", "Lỗi!", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }
            else
            {
                SetControlForEdit();
            }
        }
        /// <summary>
        /// Xóa một chức vụ
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (glbTenChucVu.Length == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa chọn chức vụ muốn xóa!", "Lỗi!", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }
            else
            {
                string dlChapNhan = new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có chắc chắn muốn xóa chức vụ này?", "Thông báo!", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (dlChapNhan == DialogResult.Yes.ToString ())
                {
                    TuDienChucVu objTuDienChucVu = new TuDienChucVu(glbTenChucVu);
                    objTuDienChucVu.Xoa();
                    LayDsChucVu();
                    ResetControlAfterEdit();
                    if (dgrChucVu.RowCount > 1)
                    {
                        glbTenChucVu = dgrChucVu.Rows[0].Cells["TenChucVu"].Value.ToString();
                        txtChucVu.Text = glbTenChucVu;
                    }
                }
            }
        }
        /// <summary>
        /// Khi người dùng nhấn vào nút cập nhật
        /// Lưu thông tin cập nhật hoặc thêm mới         
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Them moi
            if (glbTenChucVu == "")
            {
                if (txtChucVu.Text.Length == 0)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập thông tin cho loại mang.", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    TuDienChucVu objTuDienChucVu = new TuDienChucVu();
                    objTuDienChucVu.TenChucVu = txtChucVu.Text.Trim();
                    if (!objTuDienChucVu.KiemTraTrungLap())
                    {
                        bool boolThanhCong = objTuDienChucVu.ThemMoi();
                        if (boolThanhCong)
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn vừa thêm mới thành công một chức vụ", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            ResetControlAfterEdit();
                            LayDsChucVu();
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! Thêm mới chức vụ thất bại, mời bạn kiểm tra lại hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! chức vụ này đã có trong cơ sở dữ liệu", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }

            }
            else //Sửa chữa
            {
                if (txtChucVu.Text.Length == 0)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập thông tin cho chức vụ.", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    TuDienChucVu objTuDienChucVu = new TuDienChucVu();
                    objTuDienChucVu.TenChucVu = txtChucVu.Text.Trim();

                    if (!objTuDienChucVu.KiemTraTrungLap())
                    {
                        bool boolThanhCong = objTuDienChucVu.CapNhat(glbTenChucVu);
                        if (boolThanhCong)
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Thông tin đã được cập nhật thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            ResetControlAfterEdit();
                            LayDsChucVu();
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! Cập nhật thông tin thất bại, mời bạn kiểm tra lại hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else
                    {
                        if (objTuDienChucVu.TenChucVu.Equals(glbTenChucVu))
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Thông tin đã được cập nhật thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            ResetControlAfterEdit();
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! chức vụ này đã có trong cơ sở dữ liệu", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Reset lại toàn bộ thông tin
        /// Quay về trạng thái ban đầu như khi vừa load Form
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnBoQua_Click(object sender, EventArgs e)
        {

            ResetControlAfterEdit();
            LayDsChucVu();
            glbTenChucVu = dgrChucVu.Rows[0].Cells["TenChucVu"].Value.ToString();
            txtChucVu.Text = glbTenChucVu;
        }
        // Thoát khỏi Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Các phương thức dùng chung gồm
        /// Thiết lập các control cho việc thêm sửa xóa
        /// Thêm số thứ tự vào Gridview
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>

        #region Phương thức dùng chung

        public void ThemSTT(DataTable dtb)
        {
            DataColumn dtColumn = new DataColumn();
            dtColumn.ColumnName = "SoTT";
            dtb.Columns.Add(dtColumn);
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                dtb.Rows[i]["SoTT"] = i + 1;
            }
        }
        public void SetControlForEdit()
        {
            btnThemMoi.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Visible = true;
            btnBoQua.Visible = true;
            txtChucVu.ReadOnly = false;
            dgrChucVu.Enabled = false;
        }
        public void ResetControlAfterEdit()
        {
            btnThemMoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnCapNhat.Visible = false;
            btnBoQua.Visible = false;
            txtChucVu.ReadOnly = true;
            dgrChucVu.Enabled = true;
        }
        #endregion
         
	}
}