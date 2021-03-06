using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
 
using Taxi.Business;

namespace Taxi.GUI
{

	public partial class DMPhong_QuanLy: Form {
        // Biến toàn cục
        int glbPhongID=0;
        // Hàm khởi tạo
		public DMPhong_QuanLy() {
			InitializeComponent();
			 
		}
        //Load form
        private void DMPhong_QuanLy_Load(object sender, EventArgs e)
        {
			 

            LayDsPhong();
            ChuyenTrangThaiTruocSoanThao();
            dgrPhong.ReadOnly = true;


        }
        /// <summary>
        /// Hiển thị danh sách các phòng lên control gridview
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public void LayDsPhong()
        {
            TuDienPhong objTuDienPhong = new TuDienPhong();
            DataTable dtPhong = objTuDienPhong.LayDanhSach();
            ThemSTT(dtPhong);
            dgrPhong.DataSource = dtPhong;
            if (dgrPhong.RowCount > 1)
            {
                txtPhong.Text = dgrPhong.Rows[0].Cells["TenPhong"].Value.ToString();
                
            }
        }
        /// <summary>
        /// Khi người dùng click chọn  một phòng trên gridview
        ///  - Load thông tin về phòng đó lên textbox phòng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void dgrPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int intRowPost = dgrPhong.CurrentCell.RowIndex;
            int intPhongID =Convert.ToInt32(dgrPhong.Rows[intRowPost].Cells["PhongID"].Value.ToString());
            //Hiển thị dữ liệu chi tiết của một phòng
            TuDienPhong objPhong = new TuDienPhong(intPhongID);
            txtPhong.Text = objPhong.TenPhong;
            int intQuyenCapPhep = objPhong.QuyenCapPhepHoSo;
            if (intQuyenCapPhep == 1)
                chkQuyenCapPhep.Checked = true;
            else
                chkQuyenCapPhep.Checked = false;
            //Đặt giá trị cho biến toàn cục glbTenPhong
            glbPhongID=intPhongID;
            
        }
        /// <summary>
        /// Thêm mới một phòng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            glbPhongID  = 0;
            txtPhong.Text = "";
            chkQuyenCapPhep.Checked = false;
            ChuyenTrangThaiSoanThao();
        }
        /// <summary>
        /// Cập nhật thông tin cho một phòng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (glbPhongID == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa chọn phòng để sửa!", "Lỗi!", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }
            else
            {
                ChuyenTrangThaiSoanThao();
            }
        }
        /// <summary>
        /// Xóa một phòng
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (glbPhongID == 0)
            {
                new Taxi.MessageBox.MessageBoxBA().Show("Bạn chưa chọn phòng muốn xóa!", "Lỗi!", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }
            else
            {
                string dlChapNhan = new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn có chắc chắn muốn xóa phòng này?", "Thông báo!", Taxi.MessageBox.MessageBoxButtonsBA.YesNo, Taxi.MessageBox.MessageBoxIconBA.Question);
                if (dlChapNhan == DialogResult.Yes.ToString ())
                {
                    // Lấy vị trí của Row có cell được click chọn
                    int intViTriRow = dgrPhong.CurrentCell.RowIndex;
                    // Lấy ID được chọn
                    int intPhongDuocChon = int.Parse(dgrPhong.Rows[intViTriRow].Cells["PhongID"].Value.ToString());
                    glbPhongID = intPhongDuocChon;
                    TuDienPhong objTuDienPhong = new TuDienPhong(glbPhongID);                    
                    bool boolThanhCong = objTuDienPhong.Xoa();
                    if (boolThanhCong)
                    {
                        //Ghi log
                        Log objlog = new Log();
                        objlog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.DanhMucPhong_Xoa, DateTime.Now, "Xóa phòng trong danh mục: " + txtPhong.Text.Trim());

                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Phòng đã bị xóa!", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                        LayDsPhong();
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! Không xóa được phòng này, mời bạn kiểm tra lại hệ thống!", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);

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
        /// 
        private void btnCapNhat_Click(object sender, EventArgs e)
        { 
            //Them mới
            if (glbPhongID == 0)
            {
                if (txtPhong.Text.Length == 0)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập tên phòng.", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    TuDienPhong objTuDienPhong = new TuDienPhong();
                    objTuDienPhong.TenPhong = txtPhong.Text.Trim();
                    if(chkQuyenCapPhep.Checked)
                        objTuDienPhong.QuyenCapPhepHoSo=1;
                    else
                        objTuDienPhong.QuyenCapPhepHoSo=0;
                    //Kiểm tra trùng lặp
                    if (!objTuDienPhong.KiemTraTrungLap(txtPhong.Text.Trim()))
                    {
                        bool boolThanhCong = objTuDienPhong.ThemMoi();
                        if (boolThanhCong)
                        {
                            //Ghi log
                            Log objlog = new Log();
                            objlog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.DanhMucPhong_ThemMoi, DateTime.Now, "Thêm mới phòng: " + txtPhong.Text.Trim());


                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn vừa thêm mới thành công một phòng", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            ChuyenTrangThaiTruocSoanThao();
                            LayDsPhong();
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! Không thể thêm mới phòng này , yêu cầu kiểm tra lại hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else
                    {
                        new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! phòng này đã có trong cơ sở dữ liệu", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    }
                }

            }
            else //Sửa chữa
            {
                if (txtPhong.Text.Length == 0)
                {
                    new Taxi.MessageBox.MessageBoxBA().Show(this, "Bạn chưa nhập thông tin cho phòng.", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                }
                else
                {
                    TuDienPhong objTuDienPhong = new TuDienPhong(glbPhongID);
                    
                    if (chkQuyenCapPhep.Checked)
                        objTuDienPhong.QuyenCapPhepHoSo = 1;
                    else
                        objTuDienPhong.QuyenCapPhepHoSo = 0;
                    if (!objTuDienPhong.KiemTraTrungLap(txtPhong.Text.Trim() ))//Neu khong trùng lặp
                    {
                        objTuDienPhong.TenPhong = txtPhong.Text.Trim();   
                        bool boolThanhCong = objTuDienPhong.CapNhat();
                        if (boolThanhCong)
                        {
                            //Ghi log
                            Log objlog = new Log();
                            objlog.WriteLog(ThongTinDangNhap.USER_ID, HanhDongGhiLog.DanhMucPhong_Sua, DateTime.Now, "Sửa phòng: " + txtPhong.Text.Trim());

                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Thông tin đã được cập nhật thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                            ChuyenTrangThaiTruocSoanThao();
                            LayDsPhong();
                        }
                        else
                        {
                            new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! Cập nhật thông tin thất bại, mời bạn kiểm tra lại hệ thống", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        }
                    }
                    else //Nếu trùng lặp
                    {
                        if (objTuDienPhong.TenPhong.Equals(txtPhong.Text.Trim()))
                            {
                                objTuDienPhong.CapNhat();
                                new Taxi.MessageBox.MessageBoxBA().Show(this, "Thông tin đã được cập nhật thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                                ChuyenTrangThaiTruocSoanThao();
                                LayDsPhong();
                            }
                            else
                            {
                                new Taxi.MessageBox.MessageBoxBA().Show(this, "Lỗi! phòng này đã có trong cơ sở dữ liệu", "Lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
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

            ChuyenTrangThaiTruocSoanThao();
            LayDsPhong();
            
        }
        public void HienThiDuLieuChiTiet()
        {
            glbPhongID =Convert.ToInt32( dgrPhong.Rows[0].Cells["PhongID"].Value.ToString());
            TuDienPhong objPhong=new TuDienPhong(glbPhongID);
            txtPhong.Text = objPhong.TenPhong ;
            if (objPhong.QuyenCapPhepHoSo == 1)
                chkQuyenCapPhep.Checked = true;
            else
                chkQuyenCapPhep.Checked = false;
        }
        // Thoát khỏi Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Phương thức dùng chung
        /// <summary>
        /// Thêm số thứ tự vào Gridview
        /// </summary>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
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
        /// <summary>
        /// Thiết lập trạng thái của các điều khiển để bắt đầu cho việc thêm mới, sửa
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public void ChuyenTrangThaiSoanThao()
        {
            pnlThemSua.Visible = false;
            pnlCapNhat.Visible = true;
            txtPhong.ReadOnly = false;
            dgrPhong.Enabled = false;
            chkQuyenCapPhep.Enabled = true;
        }
        /// <summary>
        /// Thiết lập trạng thái của các điều khiển để kết thúc cho việc thêm mới, sửa
        /// </summary>
        /// <returns></returns>
        /// <Modified>
        ///     Author      Date        Comments
        ///     TuanND    31/01/2008    Tạo mới
        /// </Modified>
        public void ChuyenTrangThaiTruocSoanThao()
        {
            pnlThemSua.Visible = true;
            pnlCapNhat.Visible = false;
            txtPhong.ReadOnly = true;
            dgrPhong.Enabled = true;
            chkQuyenCapPhep.Enabled = false;
            if (dgrPhong.RowCount > 1)
            {
                glbPhongID = int.Parse(dgrPhong.Rows[0].Cells["PhongID"].Value.ToString());
                txtPhong.Text = dgrPhong.Rows[0].Cells["TenPhong"].Value.ToString();
            }
        }
        #endregion

        private void dgrPhong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            btnSua_Click(sender, e);
        }

	}
}