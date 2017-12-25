using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.QuanLyVe;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using Taxi.Business;
using System.Runtime.InteropServices;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmVeHuy : Form
    {
        private KhachHang g_objKhachHang = new KhachHang();
        private bool  g_ThemMoi = false ;

        DateTime g_Ngay; //phuc vu xoa        
        int g_SeriDau;    //phuc vu xoa
        int g_SeriCuoi; // phuc vu xoa
        int g_SoHopDong;
        int g_MaDonViVe;

        public frmVeHuy()
        {
            InitializeComponent();
        }
        private void frmVeHuy_Load(object sender, EventArgs e)
        {

            LockControl(); g_ThemMoi = false;
            //load ds khach hang
            LoadDSCongTy(0); 
            LoadDSVeHuy();
        }

        
        private void LoadDSCongTy(int CongTyID)
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetAllDSCongTy();

            if (CongTyID > 0)
            {

                int iIndex = -1;
                foreach (Janus.Windows.EditControls.UIComboBoxItem objItem in cboCongTy.Items)
                {
                    iIndex += 1;
                    if (objItem.Value.ToString() == CongTyID.ToString())
                    {
                        break;
                    }

                }

                cboCongTy.SelectedIndex = iIndex;

            }

        }

        private void LockControl()
        {
            chkNhapHopDongHuy.Enabled = false;
            calNgayPhatHanh.Enabled = false;
            cboCongTy.Enabled = false; 
            numSoHopDong.Enabled = false; 
            txtTenKhachHang.Enabled = false;
            txtTenKhachHang.Text = "";

            numSoHopDong.Value = 0;
            numSeriDau.Enabled = false; numSeriDau.Value = 0;
            numSeriCuoi.Enabled = false; numSeriCuoi.Value = 0;
            numSoLuong.Enabled = false; numSoLuong.Value = 0;
            txtGhiChu.Enabled = false; txtGhiChu.Text = "";
            cboLydoHuy.Enabled = false;
            chkTamNhap.Checked = false;

            btnThemMoi.Enabled = true;
            btnHuyBo.Enabled = false ;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
        }
        private void UnLockControl()
        {
            chkNhapHopDongHuy.Enabled = true;
            calNgayPhatHanh.Enabled = true;
            cboCongTy.Enabled = true;
            //cboKhachHang.Enabled = false ;
             numSoHopDong.Enabled = true ;
            numSeriDau.Enabled = true;
            numSeriCuoi.Enabled = true;
            numSoLuong.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTenKhachHang.Enabled = true;
            cboLydoHuy.Enabled = true;

            btnThemMoi.Enabled = false;
            btnHuyBo.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnXuatExcel.Enabled = true;
        }
       
        /// <summary>
        /// load ds khach hang cho vo combo
        /// </summary>
        private void LoadDSKhachHang()
        {
          //  cboKhachHang.DisplayMember = "TenKhachHang";
           // cboKhachHang.ValueMember = "IDKhachHang";
          //  cboKhachHang.DataSource = KhachHang.GetDSKhachHang("");
              
        }
        /// <summary>
        /// Load ds ve phat hanh
        /// </summary>
        private void LoadDSVeHuy()
        {
            grdVeHuy.DataMember = "ListVeHuy";
            grdVeHuy.SetDataBinding(Ve.SelectDSVeHuy(), "ListVeHuy");  
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            UnLockControl();
            g_ThemMoi = true;
            calNgayPhatHanh.Focus();
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockControl();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {


            //GetDuLieu nhap
            DateTime Ngay = DateTime.MinValue;
            int SeriDau = -1;
            int SeriCuoi = -1;
            string GhiChu = "";
            string LyDoHuy = "";
            string TenKhachHang = "";
            int MaDonViVe = 0;
            int SoHopDong = 0;
            
                try
                {
                    Random ran = new Random();
                    Ngay = new DateTime(calNgayPhatHanh.Value.Year, calNgayPhatHanh.Value.Month, calNgayPhatHanh.Value.Day, calNgayPhatHanh.Value.Hour, calNgayPhatHanh.Value.Minute, calNgayPhatHanh.Value.Second, ran.Next(1, 999));                     
                    SoHopDong = int.Parse(numSoHopDong.Value.ToString());
                    SeriDau = int.Parse(numSeriDau.Value.ToString());
                    SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                    TenKhachHang = StringTools.TrimSpace(txtTenKhachHang.Text);
                    MaDonViVe = Convert.ToInt32 ( cboCongTy.SelectedValue.ToString());
                    GhiChu = StringTools.TrimSpace(txtGhiChu.Text);
                    LyDoHuy = cboLydoHuy.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
                }
            if (!chkNhapHopDongHuy.Checked)
            {
                if (SeriDau <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin seri đầu của hợp đồng."); return;
                }
                if (SeriCuoi <= 0)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập thông tin seri cuối của hợp đồng."); return;
                }
                if (SeriDau > SeriCuoi)
                {
                    new MessageBox.MessageBoxBA().Show("Bạn phải nhập seri đầu nhỏ hoặc bằng seri cuối của hợp đồng."); return;
                }

                ////////KIEM TRA DA PHAT HANH
                //////DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
                //////if (!((dt != null) && (dt.Rows.Count > 0)))
                //////{
                //////    new MessageBox.MessageBox().Show("Seri đầu này không có trong dữ liệu vé phát hành.Bạn cần kiểm tra lại dữ  liệu nhập.");
                //////    return;
                //////}
                //////dt = Ve.GetVePhatHanhBySeri(SeriCuoi);
                //////if (!((dt != null) && (dt.Rows.Count > 0)))
                //////{
                //////    new MessageBox.MessageBox().Show("Seri cuối này không có trong dữ liệu vé phát hành.Bạn cần kiểm tra lại dữ  liệu nhập.");
                //////    return;
                //////}
                //////// KIEM TRA DA SU DUNG

                //////// KIEM TRA THEM DE HUY CHUA

               

                if (g_ThemMoi) // chen mới
                {
                     DataTable dtTim = Ve.TimKiemThongTinVe(MaDonViVe, SeriDau, Ngay.Year);
                     if (dtTim != null && dtTim.Rows.Count > 0) // da ton tai
                     {
                         new MessageBox.MessageBoxBA().Show("Seri nhập đã tồn tại.Bạn cần kiểm tra lại dữ  liệu nhập.");
                         return;
                     }
                    bool bSuccess = Ve.InsertVeHuy(Ngay, SoHopDong, SeriDau, SeriCuoi, TenKhachHang, MaDonViVe, LyDoHuy, GhiChu,chkTamNhap.Checked,ThongTinDangNhap.USER_ID);
                    if (bSuccess)
                    {
                        LoadDSVeHuy();
                        new MessageBox.MessageBoxBA().Show("Thêm mới thành công.");

                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới.");
                    }
                    LockControl(); return;
                }
                else
                {
                    bool bSuccess = Ve.DeleteVeHuy(g_Ngay, g_SoHopDong, g_SeriDau, g_SeriCuoi, g_MaDonViVe);
                    bSuccess = Ve.InsertVeHuy(Ngay, SoHopDong, SeriDau, SeriCuoi, TenKhachHang, MaDonViVe, LyDoHuy, GhiChu,chkTamNhap.Checked, ThongTinDangNhap.USER_ID);
                    if (bSuccess)
                      {
                          LoadDSVeHuy();
                          new MessageBox.MessageBoxBA().Show("Thêm mới thành công.");

                      }
                      else
                      {
                          new MessageBox.MessageBoxBA().Show("Lỗi thêm mới.");
                      }
                      LockControl(); return;
                }

            }
            else // chỉ nhạp hợp đông hủy
            {

                if (g_ThemMoi) // chen mới
                {

                    DataTable dt = Ve.TimKiemThongTinSoHopDong(MaDonViVe, SoHopDong, Ngay.Year);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        new MessageBox.MessageBoxBA().Show("Đã tồn tại hợp đồng hủy.Bạn cần kiểm tra lại.");
                        return;
                    }


                    SeriDau = 0;
                    SeriCuoi = 0;

                    bool bSuccess = Ve.InsertVeHuy(Ngay, SoHopDong, SeriDau, SeriCuoi, TenKhachHang, MaDonViVe, LyDoHuy, GhiChu,chkTamNhap.Checked,ThongTinDangNhap.USER_ID);
                    if (bSuccess)
                    {
                        LoadDSVeHuy();
                        new MessageBox.MessageBoxBA().Show("Thêm mới thành công.");

                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi thêm mới.");
                    }
                    LockControl(); return;
                }
                else
                {
                     bool bSuccess = Ve.DeleteVeHuy(g_Ngay,g_SoHopDong, g_SeriDau, g_SeriCuoi,g_MaDonViVe);
                     SeriDau = 0;
                     SeriCuoi = 0;

                     bSuccess = Ve.InsertVeHuy(Ngay, SoHopDong, SeriDau, SeriCuoi, TenKhachHang, MaDonViVe, LyDoHuy, GhiChu,chkTamNhap.Checked ,ThongTinDangNhap.USER_ID);
                     if (bSuccess)
                     {
                         LoadDSVeHuy();
                         new MessageBox.MessageBoxBA().Show("Cập nhật thành công.");

                     }
                     else
                     {
                         new MessageBox.MessageBoxBA().Show("Lỗi cập nhật mới.");
                     }
                     LockControl();
                }
            }

        }
        private void grdVeHuy_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if ((((int)e.Row.Cells["SeriDau"].Value) == 0) && (((int)e.Row.Cells["SeriCuoi"].Value) == 0))
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Cyan;
                e.Row.Cells["SoHopDong"].FormatStyle = RowStyle;
            }

            bool IsTamNhap = false;
            try
            {
                IsTamNhap = Convert.ToBoolean(e.Row.Cells["IsTamNhap"].Value.ToString());
            }
            catch (Exception ex)
            {
                IsTamNhap = false;
            }

            if (IsTamNhap)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Red ;
                e.Row.Cells["SoHopDong"].FormatStyle = RowStyle;
            }
        }
        private void grdVePhatHanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdVeHuy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdVeHuy.SelectedItems.Count > 0)
                {


                    UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false; btnLuu.Enabled = true ;
                    calNgayPhatHanh.Value = DateTime.Parse(grdVeHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                  //  cboKhachHang.SelectedValue = grdVeHuy.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value;
                    numSoHopDong.Value = grdVeHuy.SelectedItems[0].GetRow().Cells["SoHopDong"].Value;
                    numSeriDau.Value = grdVeHuy.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                    numSeriCuoi.Value = grdVeHuy.SelectedItems[0].GetRow().Cells["SeriCuoi"].Value;
                    txtGhiChu.Text = grdVeHuy.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                    cboLydoHuy.SelectedValue = grdVeHuy.SelectedItems[0].GetRow().Cells["LyDoHuy"].Value;
                    cboCongTy.SelectedValue = grdVeHuy.SelectedItems[0].GetRow().Cells["MaDonViVe"].Value; ;
                    txtTenKhachHang.Text = grdVeHuy.SelectedItems[0].GetRow().Cells["TenKhachHang"].Value.ToString ();
                    chkTamNhap.Checked = Convert.ToBoolean(grdVeHuy.SelectedItems[0].GetRow().Cells["IsTamNhap"].Value.ToString()); 
                    g_Ngay = DateTime.Parse(grdVeHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                    g_SeriDau = int.Parse (numSeriDau.Value.ToString());
                    g_SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                    g_MaDonViVe = Convert.ToInt32 ( cboCongTy.SelectedValue.ToString());
                    if (g_SeriCuoi == 0 && g_SeriDau == 0)
                    {
                        chkNhapHopDongHuy.Checked = true;

                        numSoHopDong.Enabled = false;
                        numSeriDau.Enabled = false;
                        numSeriCuoi.Enabled = false;
                    }
                    else chkNhapHopDongHuy.Checked = false;
                    chkNhapHopDongHuy.Enabled = false;
                }
            }
        }
       
        private void grdVePhatHanh_DoubleClick(object sender, EventArgs e)
        {
            grdVeHuy.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdVeHuy.SelectedItems.Count > 0)
            {
                UnLockControl(); btnXoa.Enabled = true; g_ThemMoi = false; btnLuu.Enabled = true ;
                calNgayPhatHanh.Value = DateTime.Parse(grdVeHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                //  cboKhachHang.SelectedValue = grdVeHuy.SelectedItems[0].GetRow().Cells["FK_IDKhachHang"].Value;
                numSoHopDong.Value   = grdVeHuy.SelectedItems[0].GetRow().Cells["SoHopDong"].Value;
                numSeriDau.Value     = grdVeHuy.SelectedItems[0].GetRow().Cells["SeriDau"].Value;
                numSeriCuoi.Value    = grdVeHuy.SelectedItems[0].GetRow().Cells["SeriCuoi"].Value;
                txtGhiChu.Text       = grdVeHuy.SelectedItems[0].GetRow().Cells["GhiChu"].Value.ToString();
                cboLydoHuy.SelectedValue = grdVeHuy.SelectedItems[0].GetRow().Cells["LyDoHuy"].Value;
                cboCongTy.SelectedValue  = grdVeHuy.SelectedItems[0].GetRow().Cells["MaDonViVe"].Value; ;
                txtTenKhachHang.Text     = grdVeHuy.SelectedItems[0].GetRow().Cells["TenKhachHang"].Value.ToString();
                chkTamNhap.Checked       = Convert.ToBoolean(grdVeHuy.SelectedItems[0].GetRow().Cells["IsTamNhap"].Value.ToString()); 
                //@NgayHuy datetime,
                //@SoHopDong int,
                //@SeriDau int,	 
                //@FK_IDKhachHang int
                g_Ngay = DateTime.Parse(grdVeHuy.SelectedItems[0].GetRow().Cells["NgayHuy"].Value.ToString());
                g_SeriDau = int.Parse(numSeriDau.Value.ToString());
                g_SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                g_MaDonViVe = int.Parse( cboCongTy.SelectedValue.ToString());
                g_SoHopDong = int.Parse(numSoHopDong.Value.ToString());
                if (g_SeriCuoi == 0 && g_SeriDau == 0)
                {
                    chkNhapHopDongHuy.Checked = true;
                     
                    numSoHopDong.Enabled = false;
                    numSeriDau.Enabled = false;
                    numSeriCuoi.Enabled = false;
                }
                else chkNhapHopDongHuy.Checked = false;
                chkNhapHopDongHuy.Enabled = false;
           }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (g_Ngay != DateTime.MinValue)
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa vé hủy (hợp đồng) không ?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {

                    bool bSuccess = Ve.DeleteVeHuy(g_Ngay,g_SoHopDong, g_SeriDau, g_SeriCuoi,g_MaDonViVe);
                    if (bSuccess)
                    {
                        LoadDSVeHuy();
                        new MessageBox.MessageBoxBA().Show("Xóa vé thành công.");
                        numSoHopDong.Value = 0;
                        numSeriDau.Value = 0;
                        numSeriCuoi.Value = 0;
                        numSoLuong.Value = 0;
                        txtGhiChu.Text = "";
                        g_Ngay = DateTime.MinValue;
                        LockControl();
                        return;
                    }
                    else
                    {
                        new MessageBox.MessageBoxBA().Show("Lỗi xóa vé."); return;
                    }
                }

            }
            else new MessageBox.MessageBoxBA().Show("Bạn chọn vé để xóa.");
        }
        /// <summary>
        /// tính số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numSeriDau_ValueChanged(object sender, EventArgs e)
        {
            
            int SeriDau = -1;
            int SeriCuoi = -1;
            

            try
            {
               
                SeriDau = int.Parse(numSeriDau.Value.ToString());
                SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                if ((SeriDau > 0) && (SeriDau <= SeriCuoi))
                {
                    numSoLuong.Text = string.Format("{0}", SeriCuoi - SeriDau + 1);
                }
                //// lay du lieu cong ty hop dong
                //if (SeriDau > 0)
                //{
                //    DataTable dt = Ve.GetVePhatHanhBySeri(SeriDau);
                //    if ((dt != null) && (dt.Rows.Count > 0))
                //    {
                //      //  cboKhachHang.SelectedValue = (object)(dt.Rows[0]["FK_IDKhachHang"].ToString());
                //        numSoHopDong.Text = dt.Rows[0]["SoLuong"].ToString();
                //    }
                //}
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }
        }

        private void numSeriCuoi_ValueChanged(object sender, EventArgs e)
        {
            int SeriDau = -1;
            int SeriCuoi = -1;


            try
            {

                SeriDau = int.Parse(numSeriDau.Value.ToString());
                SeriCuoi = int.Parse(numSeriCuoi.Value.ToString());
                if ((SeriDau > 0) && (SeriDau <= SeriCuoi))
                {
                    numSoLuong.Text = string.Format("{0}", SeriCuoi - SeriDau + 1);
                }

                //// lay du lieu cong ty hop dong
                //if (SeriCuoi > 0)
                //{
                //    DataTable dt = Ve.GetVePhatHanhBySeri(SeriCuoi);
                //    if ((dt != null) && (dt.Rows.Count > 0))
                //    {
                //       // cboKhachHang.SelectedValue = (object)(dt.Rows[0]["FK_IDKhachHang"].ToString());
                //        numSoHopDong.Text = dt.Rows[0]["SoLuong"].ToString();
                //    }
                //}
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi dữ liệu nhập. Bạn cần kiểm tra lại."); return;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

            string FilenameDefault = "DanhMucVeHuy.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                objFile.Close();
            }
        }

        private void chkNhapHopDongHuy_CheckedChanged(object sender, EventArgs e)
        {

            numSeriDau.Enabled = !chkNhapHopDongHuy.Checked;
            numSeriCuoi.Enabled = !chkNhapHopDongHuy.Checked;
            numSoLuong.Enabled = !chkNhapHopDongHuy.Checked;
            cboLydoHuy.SelectedIndex = 1; // huy hop dong
            cboLydoHuy.Enabled = !chkNhapHopDongHuy.Checked;
        }

       

      

              
    }
}