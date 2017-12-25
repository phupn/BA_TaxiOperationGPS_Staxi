using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Taxi.Common.Attributes;
using Taxi.Controls.Base;
using Taxi.Data.BanCo.Entity.TuyenThueBao;

namespace Taxi.Controls.ThueBaoTuyen
{
    public partial class frm_DMTuyenThueBao : FormRibbon
    {
        #region Biến toàn cục
        private DMTuyenThueBao ttb;       
        private string TuyenDuongID;
        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    this.grcTuyen.Size = new Size(this.Size.Width, this.Size.Height - 190);
        //    base.OnSizeChanged(e);

        //}
        #endregion

        public frm_DMTuyenThueBao()
        {
            InitializeComponent();
            ttb = new DMTuyenThueBao();            
            TuyenDuongID = string.Empty;

            DataTable dt = new DataTable();
            dt = ttb.getAllKieuTuyen();
            DataRow dr = dt.NewRow();
            dr[0] = "-1";
            dr[1] = "Tất cả";
            dt.Rows.Add(dr);

            //cboLoaiTuyen.Items.Insert(0, "Nội tỉnh");
            //cboLoaiTuyen.Items.Insert(1, "Ngoại tỉnh");
            //cboLoaiTuyen.SelectedIndex = 1;
            cboLoaiTuyen.DataSource = new THUEBAO_T_ChayTuyen().GetAllChayTuyen();
            cboLoaiTuyen.DisplayMember = "ChayTuyen";
            cboLoaiTuyen.ValueMember = "Id";
            cboLoaiTuyen.SelectedIndex = 0;
        }

        #region Load data
        private void loadData()
        {
            grcTuyen.DataSource = ttb.getAllTuyenDuong();
        }

        private void frm_DMTuyenThueBao_Load(object sender, EventArgs e)
        {
            loadData();
        }
        #endregion

        #region xử lý nút
        DataTable dtSearch = new DataTable();
        private void btnTim_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (txtTenTuyen.Text.Equals("") && txtVietTat.Text.Equals(""))
            {
                loadData();
                grcTuyen.Update();
            }
            else
            {
                dtSearch = new DMTuyenThueBao().SearchTuyenDuong(txtTenTuyen.Text, cboLoaiTuyen.SelectedIndex+1, txtVietTat.Text);
                if (dtSearch.Rows.Count > 0)
                {
                    grcTuyen.DataSource = dtSearch;
                    grcTuyen.Update();
                }
                else
                {
                    dtSearch.Clear();
                    grcTuyen.DataSource = dtSearch;
                    lblMsg.Text = "Không tìm thấy kết quả phù hợp";
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            #region Validate
            lblMsg.ForeColor = Color.Red;
            if (txtTenTuyen.Text.Equals("")) { lblMsg.Text = "Bạn chưa nhập tên tuyến đường"; txtTenTuyen.Focus(); return; }
            if (txtTenTuyen.Text.Trim().Length > 20) { lblMsg.Text = "Tên tuyến đường không quá 20 ký tự"; txtTenTuyen.Focus(); return; }
            if (txtVietTat.Text.Equals("")) { lblMsg.Text = "Bạn chưa nhập tên viết tắt"; txtVietTat.Focus(); return; }
            if (txtVietTat.Text.Trim().Length > 10) { lblMsg.Text = "Tên viết tắt không quá 10 ký tự"; txtVietTat.Focus(); return; }
            //if (lueLoaiTuyen.Text.Trim().Equals("") || lueLoaiTuyen.Text.Trim().Equals("Chọn loại tuyến") || lueLoaiTuyen.Text.Trim().Equals("Tất cả")) { lblMsg.Text = "Bạn chưa chọn loại tuyến"; lueLoaiTuyen.Focus(); return; }
            else lblMsg.Text = "";
            #endregion

            if (TuyenDuongID.Equals(""))
            {
                int ThemMoi = ttb.InsertTuyenDuong(txtTenTuyen.Text, cboLoaiTuyen.SelectedIndex+1, txtVietTat.Text);
                if (ThemMoi > 0)
                {
                    
                    RefreshForm();
                    grcTuyen.Update();
                    lblMsg.Text = "Thêm mới thành công";
                    lblMsg.ForeColor = Color.Blue;
                }
                else
                {
                    lblMsg.Text = "Tuyến đường bị trùng. Bạn kiểm tra lại";
                    lblMsg.ForeColor = Color.Red;
                    txtTenTuyen.Focus();
                }

            }
            else
            {
                int CapNhat = ttb.UpdateAllTuyenDuong(TuyenDuongID, txtTenTuyen.Text, cboLoaiTuyen.SelectedIndex+1, txtVietTat.Text);
                if (CapNhat > 0)
                {
                    
                    RefreshForm();
                    grcTuyen.Update();
                    lblMsg.Text = "Cập nhật thành công";
                    lblMsg.ForeColor = Color.Blue;
                }
                else
                {
                    lblMsg.Text = "Tuyến đường bị trùng. Bạn kiểm tra lại";
                    lblMsg.ForeColor = Color.Red;
                    txtTenTuyen.Focus();
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            if (grvTuyen.FocusedRowHandle < 0)
            {
                return;
            }
            else if (txtTenTuyen.Text.Equals(""))
            {
                lblMsg.Text = "Bạn cần chọn bản ghi để xóa";
                lblMsg.ForeColor = Color.Red;
                return;
            }
            else if (new MessageBox.MessageBoxBA().Show(this, "Bạn có thực sự muốn xóa?", "Xác nhận", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
            {

                int XoaTuyen = ttb.DeleteTuyenDuong(grvTuyen.GetRowCellValue(grvTuyen.FocusedRowHandle, "TuyenDuongID").ToString());

                if (XoaTuyen > 0)
                {
                    lblMsg.Text = "Xóa thành công";
                    lblMsg.ForeColor = Color.Blue;
                    RefreshForm();
                }
                else
                {
                    lblMsg.Text = "Xóa không thành công hoặc tuyến đang được cấu hình trong bảng giá cước. Bạn kiểm tra lại!";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "Bạn cần chọn bản ghi để xóa";
                lblMsg.ForeColor = Color.Red;
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region sự kiện thêm sửa xóa
        private void grvTuyen_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == STT)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void grcTuyen_ProcessGridKey(object sender, KeyEventArgs e)
        {
            lblMsg.Text = "";
            if (e.KeyCode == Keys.Delete)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có thực sự muốn xóa?", "Xác nhận", MessageBox.MessageBoxButtonsBA.YesNo, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    int XoaTuyen = ttb.DeleteTuyenDuong(grvTuyen.GetRowCellValue(grvTuyen.FocusedRowHandle, "TuyenDuongID").ToString());

                    if (XoaTuyen > 0)
                    {
                        lblMsg.Text = "Xóa thành công";
                        lblMsg.ForeColor = Color.Blue;
                        loadData();
                    }
                }
            }
        }

        private void grvTuyen_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            TuyenDuongID = string.Empty;
            txtTenTuyen.Text = grvTuyen.GetFocusedRowCellValue("TenTuyenDuong").ToString();
            txtVietTat.Text = grvTuyen.GetFocusedRowCellValue("VietTat").ToString();
            cboLoaiTuyen.SelectedIndex = int.Parse(grvTuyen.GetFocusedRowCellValue("KieuTuyenDuong").ToString())-1;
            TuyenDuongID = grvTuyen.GetFocusedRowCellValue("TuyenDuongID").ToString(); 
        }
        #endregion

        #region validate
        private void txtTenTuyen_TextChanged(object sender, EventArgs e)
        {
            txtTenTuyen.Text = txtTenTuyen.Text.TrimStart();
            lblMsg.Text = "";
        }

        private void txtVietTat_TextChanged(object sender, EventArgs e)
        {
            txtVietTat.Text = txtVietTat.Text.TrimStart();
            lblMsg.Text = "";
        }
        #endregion


        [MethodWithKey(Keys = Keys.F5)]
        private void RefreshForm()
        {
            lblMsg.Text = "";
            txtTenTuyen.Text = "";
            txtVietTat.Text = "";
            //lueLoaiTuyen.EditValue = null;
            TuyenDuongID = string.Empty;
            loadData();
        }
    }
}
