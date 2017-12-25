using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class DMLoaiDiaDanh : Form
    {
        //Biến toàn cục glbTenLoaiDiaDanh
        public int g_LoaiDiaDanhID=-1;
        private string gblTenLoaiDiaDanh = "";
        public DMLoaiDiaDanh()
        {
            InitializeComponent();            
            LayDanhSachLoaiDiaDanh();
        }
        /// <summary>
        /// Formload
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void DMLoaiDiaDanh_Load(object sender, EventArgs e)
        {
            //GiaoDienChinh frmMain = this.ParentForm as GiaoDienChinh;
            //if (frmMain.ActiveMdiChild != null)
            //    frmMain.ActiveMdiChild.Close();

            pnlCapNhat.Visible = false;
            txtLoaiDiaDanh.Enabled = false;
        }
        /// <summary>
        /// Lấy danh sách các loại địa danh hiện có trong cơ sở dữ liệu
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        public void LayDanhSachLoaiDiaDanh() 
        {
            TuDienLoaiDiaDanh objLoaiDiaDanh = new TuDienLoaiDiaDanh();
            DataTable dtLoaiDiaDanh = objLoaiDiaDanh.LayDanhSach();
            grdLoaiDiaDanh.DataSource = dtLoaiDiaDanh;
        }

        /// <summary>
        /// Thực hiện thêm mới một loại địa danh vào csdl
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            pnlCapNhat.Visible = true;
            txtLoaiDiaDanh.Enabled = true;
            txtLoaiDiaDanh.Text = "";
            pnlThaoTac.Visible = false;
        }

        /// <summary>
        /// Thực hiện cập nhật lại thông tin của một loại địa danh
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnSua_Click(object sender, EventArgs e)
        {
            TuDienLoaiDiaDanh objLoaiDiaDanh = new TuDienLoaiDiaDanh();
            if (grdLoaiDiaDanh.Rows.Count == 0) return;
            int LoaiDiaDanhID = int.Parse(grdLoaiDiaDanh.CurrentRow.Cells["LoaiDiaDanhID"].Value.ToString());
            
            g_LoaiDiaDanhID  = LoaiDiaDanhID ;
            pnlCapNhat.Visible = true;
            txtLoaiDiaDanh.Enabled = true;
            pnlThaoTac.Visible = false; 
            gblTenLoaiDiaDanh = grdLoaiDiaDanh.CurrentRow.Cells["TenLoaiDiaDanh"].Value.ToString();            
        }

        /// <summary>
        /// Xóa một loại địa danh khỏi cơ sở dữ liệu
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TuDienLoaiDiaDanh objLoaiDiaDanh = new TuDienLoaiDiaDanh();
            if (grdLoaiDiaDanh.Rows.Count == 0) return;
            int LoaiDiaDanhID = int.Parse(grdLoaiDiaDanh.CurrentRow.Cells["LoaiDiaDanhID"].Value.ToString());

            g_LoaiDiaDanhID = LoaiDiaDanhID;
            //if (objLoaiDiaDanh.KiemTraDaDuocSuDung(strTenLoaiDiaDanh) == 1)
            //{
            //    new Taxi.MessageBox.MessageBox().Show("Bạn không thể xóa loại địa danh này do loại địa danh đã được sử dụng trong hệ thống dữ liệu chương trình.",
            //                        "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //    return;
            //}

            //Confirm lại hành động của người dùng
            string dlOK = new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn muốn xóa loại địa danh này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
            if (dlOK == DialogResult.No.ToString ())
                return;

            try
            {
                int intThanhCong = objLoaiDiaDanh.Xoa(g_LoaiDiaDanhID );
                if (intThanhCong == 1)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Xóa loại địa danh thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    LayDanhSachLoaiDiaDanh();
                }
                else
                    new Taxi.MessageBox.MessageBoxBA().Show("Xóa loại địa danh thất bại, bạn hãy kiểm tra lại thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
            }
            catch (Exception ex)
            {
                new Taxi.MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }

        /// <summary>
        /// Thực hiện thêm mới hoặc cập nhật loại địa danh
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            TuDienLoaiDiaDanh objLoaiDiaDanh = new TuDienLoaiDiaDanh();
            errorProvider.Clear();
            //Nếu người dùng chọn button Thêm mới
            if (string.IsNullOrEmpty(gblTenLoaiDiaDanh))
            {
                if (string.IsNullOrEmpty(txtLoaiDiaDanh.Text.Trim()))
                {
                    errorProvider.SetError(txtLoaiDiaDanh, "Bạn phải nhập vào tên loại địa danh");
                    return;
                }

                if (objLoaiDiaDanh.KiemTraTrungTen(txtLoaiDiaDanh.Text.Trim()) == 1)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Tên loại địa danh này đã có trong cơ sở dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }

                try
                {
                    int intThanhCong = objLoaiDiaDanh.ThemMoi(txtLoaiDiaDanh.Text.Trim());
                    if (intThanhCong == 1)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Thêm mới loại địa danh thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        LayDanhSachLoaiDiaDanh();
                        pnlThaoTac.Visible = true;
                        pnlCapNhat.Visible = false;
                        txtLoaiDiaDanh.Enabled = false;
                    }
                    else
                        new Taxi.MessageBox.MessageBoxBA().Show("Thêm mới loại địa danh thất bại, bạn hãy kiểm tra lại thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                }
                catch (Exception ex)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
            }
            //Nếu người dùng chọn button Sửa
            else
            {
                if (string.IsNullOrEmpty(txtLoaiDiaDanh.Text.Trim()))
                {
                    errorProvider.SetError(txtLoaiDiaDanh, "Bạn phải nhập vào tên loại địa danh");
                    return;
                }

                //Confirm lại hành động của người dùng
                string  dlOK = new Taxi.MessageBox.MessageBoxBA().Show("Bạn có chắc chắn muốn sửa loại địa danh này?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (dlOK == DialogResult.No.ToString ())
                    return;

                //Nếu người dùng không thay đổi gì mà vẫn click button cập nhật
                if (txtLoaiDiaDanh.Text.Trim().ToUpper() == gblTenLoaiDiaDanh.ToUpper())
                {
                    new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật loại địa danh thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    LayDanhSachLoaiDiaDanh();
                    pnlThaoTac.Visible = true;
                    txtLoaiDiaDanh.Enabled = false;
                    pnlCapNhat.Visible = false;
                }
                else
                {
                    if (objLoaiDiaDanh.KiemTraTrungTen(txtLoaiDiaDanh.Text.Trim()) == 1)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show("Tên loại địa danh này đã có trong cơ sở dữ liệu.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }

                    try
                    {
                        int intThanhCong = objLoaiDiaDanh.CapNhat(g_LoaiDiaDanhID, txtLoaiDiaDanh.Text.Trim());
                        if (intThanhCong == 1)
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật loại địa danh thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            LayDanhSachLoaiDiaDanh();
                            pnlThaoTac.Visible = true;
                            pnlCapNhat.Visible = false;
                            txtLoaiDiaDanh.Enabled = false;
                        }
                        else
                            new Taxi.MessageBox.MessageBoxBA().Show("Cập nhật loại địa danh thất bại, bạn hãy kiểm tra lại thông tin.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    }
                    catch (Exception ex)
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Hủy bỏ các hành động trước đó
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            gblTenLoaiDiaDanh = "";
            errorProvider.Clear();
            LayDanhSachLoaiDiaDanh();
            pnlThaoTac.Visible = true;
            txtLoaiDiaDanh.Enabled = false;
            pnlCapNhat.Visible = false;
        }

        /// <summary>
        /// Load tên của loại địa danh lên textbox loại địa danh tại mỗi lần click lựa chọn trên gridview của người dùng
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void grdLoaiDiaDanh_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                gblTenLoaiDiaDanh = "";
                errorProvider.Clear();                
                pnlThaoTac.Visible = true;
                txtLoaiDiaDanh.Enabled = false;
                pnlCapNhat.Visible = false;
                txtLoaiDiaDanh.Text = grdLoaiDiaDanh.CurrentRow.Cells["TenLoaiDiaDanh"].Value.ToString();
            }
            catch (Exception ex) { }
        }

      
        /// <summary>
        /// Thoát khỏi form danh mục loại địa danh
        /// </summary>
        /// <Modified>
        ///     Author          Date            Comments
        ///     Tuanpv       02/07/2008         Tạo mới
        /// </Modified>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdLoaiDiaDanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        
    }
}