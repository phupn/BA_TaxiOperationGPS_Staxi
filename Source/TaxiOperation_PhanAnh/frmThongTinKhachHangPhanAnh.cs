using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.ThongTinPhanAnh;
using Janus.Windows.GridEX;
using Taxi.GUI;
using Taxi.Business;
using Taxi.MessageBox;
using TaxiOperation_TongDai;
using System.IO;
using Taxi.Utils;
//using TaxiOperation_TongDai.BaoCaoPhanAnh;
namespace Taxi.GUI
{
    public partial class frmThongTinKhachHangPhanAnh : Form
    {

        #region declare variable
        public List<ThongTinPhanAnh> _lstThongTinPA = new List<ThongTinPhanAnh>();
        private string _strUsername = "";
        private string _ipAddress = "";
        public string RoleNhanVien = string.Empty;
        private string g_strUsername = "";
        private string g_IPAddress = "";

        private DateTime g_TimeServer = DateTime.MinValue;
        frmTimKiem frmSearch;
        bool trangThai = false;
        bool chuyenDV = false;
        ThongTinPhanAnh PhanAnhSelected = new ThongTinPhanAnh();

        #endregion

        //--- COM info ----
        string g_COMPort = "";
        public static frmDangGoi frmCalling = new frmDangGoi();
        //=================

        public frmThongTinKhachHangPhanAnh()
        {
            InitializeComponent();            
            
        }

        private void frmThongTinKhachHangPhanAnh_Load(object sender, EventArgs e)
        {
            if (DieuHanhTaxi.CheckConnection())
            {// Lay thong tin he thong
                ThongTinCauHinh.LayThongTinCauHinh();
                g_TimeServer = DieuHanhTaxi.GetTimeServer();
            }
            LoadPhanAnh_ChuaGiaiQuyet(0);
            CheckIn();
            grdGiaiQuyetPA.Focus();
            // Khoi tao cong COM
            KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
            
        }        

        public void LoadPhanAnh_ChuaGiaiQuyet(int Position)
        { 
            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
            _lstThongTinPA = objPhanAnh.JoinThongTinPhanAnh(false);

            grdGiaiQuyetPA.DataMember = "lstThongTinPA";
            grdGiaiQuyetPA.SetDataBinding(_lstThongTinPA, "lstThongTinPA");
          
            if (grdGiaiQuyetPA.RowCount > 0)
            {
                if (Position <= 0)
                {
                    grdGiaiQuyetPA.Row = 0;
                }
                else if (Position > 0)
                {
                    grdGiaiQuyetPA.Row = Position;
                }
            }
           
            
        }

        public void LoadPhanAnh_DaGiaiQuyet(int Position)
        {
            ThongTinPhanAnh objPhanAnh = new ThongTinPhanAnh();
            _lstThongTinPA = objPhanAnh.JoinThongTinPhanAnh(true);

            grdDaGiaiQuyetPA.DataMember = "lstThongTinPA";
            grdDaGiaiQuyetPA.SetDataBinding(_lstThongTinPA, "lstThongTinPA");
            // Congnt sua ----
            if (Position >  0) { grdDaGiaiQuyetPA.Row = Position; } 
            // ---------------

        }

        public void LoadPhanAnh_ChuyenDonVi(int Position)
        {
            ThongTinPhanAnh objPAChuyenDV = new ThongTinPhanAnh();
            _lstThongTinPA  = objPAChuyenDV.GetPhanAnhChuyenDonVi();
            grdChuyenDV.DataMember = "tbXuLyBanDau";
            grdChuyenDV.SetDataBinding(_lstThongTinPA, "tbXuLyBanDau");
            if (grdChuyenDV.RowCount > 0)
            {
                if (Position <= 0)
                {
                    grdChuyenDV.Row = 0;
                }
                else if (Position > 0)
                {
                    grdChuyenDV.Row = Position;
                }
            }
        }
        public void LoadPhanAnh_GoiLaiGoiKhac(int Position)
        {
            ThongTinPhanAnh objPAChuyenDV = new ThongTinPhanAnh();
            _lstThongTinPA = objPAChuyenDV.GetThongTinPhanAnhGoiLaiGoiKhac(new DateTime(2000, 01, 01, 00, 0, 0), DieuHanhTaxi.GetTimeServer());
            gridGoiLaiGoiKhac .DataMember = "tbXuLyBanDau";
            gridGoiLaiGoiKhac.SetDataBinding(_lstThongTinPA, "tbXuLyBanDau");
            if (gridGoiLaiGoiKhac.RowCount > 0)
            {
                if (Position <= 0)
                {
                    gridGoiLaiGoiKhac.Row = 0;
                }
                else if (Position > 0)
                {
                    gridGoiLaiGoiKhac.Row = Position;
                }
            }
        }
        #region ChẹckIn/CheckOut
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>
        private void CheckIn()
        {
            frmCheckInOut frm = new frmCheckInOut();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _strUsername = ThongTinDangNhap.USER_ID;
               
                if (_strUsername.Length > 0)
                {
                    if (ThongTinDangNhap.IsUserPostionTrust(_strUsername, _ipAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
                    {                        
                        //cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        //cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    }
                    else
                    {
                        //// kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
                        //if (ThongTinDangNhap.IsPCCheckInWithOutUser(_strUsername, _ipAddress))
                        //{
                        //    new Taxi.MessageBox.MessageBox().Show("Máy tính này đã có người đăng nhập vào hệ thống. Người đã sử dụng trước phải checkout ra thì bạn mới vào được hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //    Application.Exit();
                        //    return;
                        //}
                        //// kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
                        //if (ThongTinDangNhap.IsUserCheckInAtOtherPC(_strUsername, _ipAddress))
                        //{
                        //    new Taxi.MessageBox.MessageBox().Show("Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                        //    ThongTinDangNhap.USER_ID = "";
                        //    _strUsername = "";
                        //    Application.Exit();
                        //    return;

                        //}
                        // cap nhat trang thai
                        if (!ThongTinDangNhap.CheckIn(_strUsername, _ipAddress))
                        { 
                            new Taxi.MessageBox.MessageBox().Show("Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                            ThongTinDangNhap.USER_ID = "";
                            _strUsername = "";
                            Application.Exit();
                            return;
                        }
                        else
                        {
                            if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH)))))
                            {
                                new Taxi.MessageBox.MessageBox().Show("Bạn không có quyền xử lí phản ánh của khách hàng", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

                                ThongTinDangNhap.USER_ID = "";
                                _strUsername = "";
                                Application.Exit();
                                return;
                            }
                            else if ((ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH)) && (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH)))
                            {
                                RoleNhanVien = "All";
                            }
                            else if(ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH))
                            {
                                RoleNhanVien = "NVNHANPHANANH";
                            }
                            else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
                            {
                                RoleNhanVien = "NVGIAIQUYETPHANANH";
                            }
                           
                        }
                        // thiet lap menu disable 
                        //cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        //cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                       // statusBar.Panels["TenDangNhap"].Text = "NV : " + _strUsername;
                    }
                }
            }
            else
            {
               // cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                ThongTinDangNhap.USER_ID = "";
                _strUsername = "";

            }
        }

        #endregion 

        #region Nhap du lieu vao truyen di

        private void grdGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if(grdGiaiQuyetPA.SelectedItems.Count >0)
            {
                if (_strUsername.Length <= 0)
                {
                    CheckIn();
                }
                else
                {
                    NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);
                }
            }
           
        }

        private void grdGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdGiaiQuyetPA.SelectedItems.Count > 0)
                {
                    if (_strUsername.Length <= 0)
                    {
                        CheckIn();
                    }
                    else
                    {                        
                        NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);
                    }
                }
            }
            else if (e.KeyData == Keys.F4 || e.KeyData == Keys.Space)
            {
                grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdGiaiQuyetPA.SelectedItems.Count > 0)
                {
                    ThongTinPhanAnh objPhanAnh = (ThongTinPhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow; 
                    HienThiFormGoiDienThoai( Configuration.GetDauSoGoiDi() + objPhanAnh.DienThoai,objPhanAnh.NoiDung);
                }
            } 
        }

        public void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                ThongTinPhanAnh objThongTinPA = (ThongTinPhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                List<int> lstCongTyID = new List<int>();
                lstCongTyID = objThongTinPA.GetDonViXuLy(Convert.ToInt32(objThongTinPA.ID));
                //End - Thu doi mau                 
                frmThongTinPhanAnhInput frmPAInPut = new frmThongTinPhanAnhInput(objThongTinPA, RoleNhanVien, false, lstCongTyID);
                
                DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                if (_dialogResult == DialogResult.Yes)
                {
                    LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                }
               else if (_dialogResult == DialogResult.OK)
                {
                    if (frmPAInPut.chkTrangThai.Checked)
                    {
                        LoadPhanAnh_ChuaGiaiQuyet(0);
                    }
                    else
                    {
                        LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                    }
                  
                }
                else
                {
                    LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                }
                
                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
                
            }

        }

        private void grdChuyenDV_DoubleClick(object sender, EventArgs e)
        {
            if (grdChuyenDV.SelectedItems.Count > 0)
            {
                if (_strUsername.Length <= 0)
                {
                    CheckIn();
                }
                else
                {
                    NhapDuLieuVaoTruyenDi2(((GridEXSelectedItem)grdChuyenDV.SelectedItems[0]).Position);
                }
            }
        }

        private void grdChuyenDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdChuyenDV.SelectedItems.Count > 0)
                {
                    if (_strUsername.Length <= 0)
                    {
                        CheckIn();
                    }
                    else
                    {
                        NhapDuLieuVaoTruyenDi2(((GridEXSelectedItem)grdChuyenDV.SelectedItems[0]).Position);
                    }
                }

            }
            
        }

        public void NhapDuLieuVaoTruyenDi2(int iRowPosition)
        {
            grdChuyenDV.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdChuyenDV.SelectedItems.Count > 0)
            {
                ThongTinPhanAnh objThongTinPA = (ThongTinPhanAnh)((GridEXSelectedItem)grdChuyenDV.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdChuyenDV.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                List<int> lstCongTyID = new List<int>();
                lstCongTyID = objThongTinPA.GetDonViXuLy(Convert.ToInt32(objThongTinPA.ID));
                //End - Thu doi mau                 
                frmThongTinPhanAnhInput frmPAInPut = new frmThongTinPhanAnhInput(objThongTinPA, RoleNhanVien, true, lstCongTyID);

                DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                if (_dialogResult == DialogResult.Yes)
                {
                    LoadPhanAnh_ChuyenDonVi(rowSelect.Position);
                }
                else if (_dialogResult == DialogResult.OK)
                {
                    if (frmPAInPut.chkTrangThai.Checked)
                    {
                        LoadPhanAnh_ChuyenDonVi(0);
                    }
                    else
                    {
                        LoadPhanAnh_ChuyenDonVi(rowSelect.Position);
                    }

                }
                else
                {
                    LoadPhanAnh_ChuyenDonVi(rowSelect.Position);
                }

                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;

            }

        }

        #endregion
      
        private void HienThiTrangThaiChu(GridEXRow row)
        {
            ThongTinPhanAnh objPhanAnh = (ThongTinPhanAnh)row.DataRow;
            if(objPhanAnh.ThoiGianPhanAnh == DateTime.MinValue   )
            {
                row.Cells["ThoiGianPhanAnh"].Text = string.Empty;
            }
            else if (objPhanAnh.NgayGiaiQuyet == DateTime.MinValue )
            {
                row.Cells["NgayGiaiQuyet"].Text = string.Empty;
            }
            else if (objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangVIP)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Blue;
                row.Cells["TenKhachHang"].FormatStyle = RowStyle;
            }
            else if (objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangVang
                   || objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangBac)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.ForestGreen;
                row.Cells["TenKhachHang"].FormatStyle = RowStyle;
            }
        }

        private void grdGiaiQuyetPA_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

        #region xu li hot key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            int iRowSelect = -1;
            if (keyData == (Keys.Alt | Keys.D1)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 0;

            }
            else if (keyData == (Keys.Alt | Keys.D2)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 1;
            }
            else if (keyData == (Keys.Alt | Keys.D3)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 2;
            }
            else if (keyData == (Keys.Alt | Keys.D4)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 3;
            }
            else if (keyData == (Keys.Alt | Keys.D5)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 4;
            }
            else if (keyData == (Keys.Alt | Keys.D6)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 5;
            }
            else if (keyData == (Keys.Alt | Keys.D7)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 6;
            }
            else if (keyData == (Keys.Alt | Keys.D8)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 7;
            }
            else if (keyData == (Keys.Alt | Keys.D9)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 8;
            }

            else if (keyData == (Keys.Alt | Keys.D0)) // Mo nhap du lieu dong 1
            {
                iRowSelect = 9;
            }

            if (iRowSelect >= 0)
            {
                if (tabGoiLaiGoiKhac.SelectedIndex == 0)
                {

                    if (grdGiaiQuyetPA.RowCount > iRowSelect)
                    {
                        grdGiaiQuyetPA.Row = iRowSelect;
                        if (_strUsername.Length <= 0)
                            CheckIn();
                        else
                            NhapDuLieuVaoTruyenDi(iRowSelect);

                    }
                }
                return true;
            }

            if (keyData == (Keys.Shift | Keys.D1))
            {
                if (tabGoiLaiGoiKhac.SelectedIndex != 0)
                    tabGoiLaiGoiKhac.SelectedIndex = 0;
            }
            else if(keyData == (Keys.Shift | Keys.D2))
            {
                if (tabGoiLaiGoiKhac.SelectedIndex != 1)
                    tabGoiLaiGoiKhac.SelectedIndex = 1;
            }
            else if (keyData == (Keys.Shift | Keys.D3))
            {
                if (tabGoiLaiGoiKhac.SelectedIndex != 2)
                    tabGoiLaiGoiKhac.SelectedIndex = 2;
            }
          
            return false;
        }
        #endregion

        private void MainMenu_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "DoiMatKhau")
            {
                new CapNhatThongTinCaNhan().ShowDialog();
            }
            else if (e.Command.Key == "CheckIn")
            {
                CheckIn();
            }
            else if (e.Command.Key  == "CheckOut")
            {
                // check co dung may cua user dang ngồi không.
                if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
                {
                    if (ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress))
                    {
                        new MessageBox.MessageBox().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                        CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        //statusBar.Panels["TenDangNhap"].Text = "NV: ";
                        ThongTinDangNhap.USER_ID = "";
                        CheckIn();
                    }
                    else
                    {
                        new MessageBox.MessageBox().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
                    }
                }
                else
                    new MessageBox.MessageBox().Show(this, "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                // nếu đúng thì cập nhật thời gian checkout.

            }  
            else if (e.Command.Key == "cmdTaoPhanAnh")
            {
                frmChenCuocGoi frmChenCuocGoi = new frmChenCuocGoi();
                DialogResult dialogResult = frmChenCuocGoi.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    LoadPhanAnh_ChuaGiaiQuyet(grdGiaiQuyetPA.Row);

                    new Taxi.MessageBox.MessageBox().Show("Chèn thêm cuộc gọi thành công");
                    frmChenCuocGoi.Close();
                }
            }
        }

        private void uiCommandBar2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdThemCuocGoi")
            {
                frmChenCuocGoi frmChenCuocGoi = new frmChenCuocGoi();
                DialogResult dialogResult = frmChenCuocGoi.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    LoadPhanAnh_ChuaGiaiQuyet(grdGiaiQuyetPA.Row );
                   
                    new Taxi.MessageBox.MessageBox().Show("Chèn thêm cuộc gọi thành công");
                    frmChenCuocGoi.Close();
                }
            }
            else if (e.Command.Key == "cmdTinhTien")
            {
                new frmTinhTienTheoKmCP().ShowDialog();
            }
            else if (e.Command.Key == "cmdTongDai1080")
            {
                new frmDMDiaDanh().ShowDialog();
            }
            else if (e.Command.Key == "cmdVeHuy")
            {
                new frmTraCuu().ShowDialog();
            }             
             else if(e.Command.Key == "cmdXuatExcel")
             {
                 XuatExcel();
             }
             else if (e.Command.Key == "cmdNhapTuExcel")
             {
                 new frmNhapTuExcel().ShowDialog();
             }
             else if (e.Command.Key == "cmdTimKiem")
             {

                 if (tabGoiLaiGoiKhac.SelectedIndex == 0)
                 {
                     trangThai = false;
                     chuyenDV = false;
                 }
                 else if (tabGoiLaiGoiKhac.SelectedIndex == 1)
                 {
                     trangThai = false;
                     chuyenDV = true;
                 }
                 else if (tabGoiLaiGoiKhac.SelectedIndex == 2)
                 {
                     trangThai = true;
                     chuyenDV = false;
                 }
                 frmSearch = new frmTimKiem(trangThai, chuyenDV);
                 frmSearch.TimKiemThanhCongClick += new frmTimKiem.TimKiemThanhCongEvent(frmSearch_TimKiemThanhCongClick);
                 DialogResult diaLog = frmSearch.ShowDialog();

                 if (diaLog == DialogResult.OK)
                 {
                     List<ThongTinPhanAnh> lstThongTinPA = new List<ThongTinPhanAnh>();
                     lstThongTinPA = frmSearch.GetPhanAnh;

                     if (lstThongTinPA == null || lstThongTinPA.Count <= 0)
                     {
                         new Taxi.MessageBox.MessageBox().Show("Không tìm thấy dữ liệu");

                         BaoCuocGoiMoi.Enabled = true;
                     }
                     else
                     {
                         BaoCuocGoiMoi.Enabled = false;
                         if (trangThai == false && chuyenDV == false)
                         {
                             grdGiaiQuyetPA.DataMember = "listPhanAnh";
                             grdGiaiQuyetPA.SetDataBinding(lstThongTinPA, "listPhanAnh");
                             //grdGiaiQuyetPA.Focus();
                             frmSearch.Focus();
                         }
                         else if (trangThai == false && chuyenDV == true)
                         {
                             grdChuyenDV.DataMember = "listPhanAnh";
                             grdChuyenDV.SetDataBinding(lstThongTinPA, "listPhanAnh");
                             //grdChuyenDV.Focus();
                         }
                         else if (trangThai == true && chuyenDV == false)
                         {
                             grdDaGiaiQuyetPA.DataMember = "listPhanAnh";
                             grdDaGiaiQuyetPA.SetDataBinding(lstThongTinPA, "listPhanAnh");
                             //grdDaGiaiQuyetPA.Focus();
                         }
                         //frmSearch.Show();

                     }
                 }
                 else if (diaLog == DialogResult.Cancel)
                 {
                     BaoCuocGoiMoi.Enabled = true;
                 }
             }
        }

        /// <summary>
        /// hieenr thi thong tin tim kiem
        /// </summary>
        public void frmSearch_TimKiemThanhCongClick()
        {
            List<ThongTinPhanAnh> lstThongTinPA = new List<ThongTinPhanAnh>();
            lstThongTinPA = frmSearch.GetPhanAnh;

            if (lstThongTinPA == null || lstThongTinPA.Count <= 0)
            {
                new Taxi.MessageBox.MessageBox().Show("Không tìm thấy dữ liệu");
                BaoCuocGoiMoi.Enabled = true;
               
            }
            else
            {
                BaoCuocGoiMoi.Enabled = false;
                if (trangThai == false && chuyenDV == false)
                {
                    grdGiaiQuyetPA.DataMember = "listPhanAnh";
                    grdGiaiQuyetPA.SetDataBinding(lstThongTinPA, "listPhanAnh");
                    //grdGiaiQuyetPA.Focus();
                    frmSearch.Focus();
                }
                else if (trangThai == false && chuyenDV == true)
                {
                    grdChuyenDV.DataMember = "listPhanAnh";
                    grdChuyenDV.SetDataBinding(lstThongTinPA, "listPhanAnh");
                    //grdChuyenDV.Focus();
                }
                else if (trangThai == true && chuyenDV == false)
                {
                    grdDaGiaiQuyetPA.DataMember = "listPhanAnh";
                    grdDaGiaiQuyetPA.SetDataBinding(lstThongTinPA, "listPhanAnh");
                    //grdDaGiaiQuyetPA.Focus();
                }
                //frmSearch.Show();

            }
        }

        private void BaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
           LoadPhanAnh_ChuaGiaiQuyet(grdGiaiQuyetPA.Row);          
        }

        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (tbCuocGoiDaGiaiQuyet.Selected)
            {
                LoadPhanAnh_DaGiaiQuyet(0);
                grdDaGiaiQuyetPA.Focus();
            }
            else if(tbCuocGoiChuyenDV.Selected)
            {
                LoadPhanAnh_ChuyenDonVi(0);
                grdChuyenDV.Focus();
            }
            else if (utabGoiLaiGoiKhac.Selected)
            {
                LoadPhanAnh_GoiLaiGoiKhac(0);
                gridGoiLaiGoiKhac.Focus();
            }
            else
            {
                grdGiaiQuyetPA.Focus();
            }
        }
       
        private void grdChuyenDV_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }




        private void frmThongTinKhachHangPhanAnh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }


        #region COM PORT
        /// <summary>
        /// khoitao mo cong COM
        /// thu vo cac cong COM3, COM4, COM5
        /// </summary>
        private bool KhoiTaoCOMPort()
        {

            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;

            int iLanMo = 0; bool IsOpenCOM = false;
            while (!IsOpenCOM && iLanMo < 3)
            {
                string PortName = string.Format("COM{0}", iLanMo + 3);
                try
                {
                    serialPort1.PortName = PortName;
                    serialPort1.Open();
                    IsOpenCOM = true;
                    g_COMPort = PortName;
                    System.Threading.Thread.Sleep(500);
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    IsOpenCOM = false;

                    g_COMPort = "";
                }
                iLanMo++;
            }
            return IsOpenCOM;
        }

        private void DongCOMPort()
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }
        /// <summary>
        /// quy goi so dien thoai
        /// sau khi mo  COM thanh cong
        /// </summary>
        /// <param name="SoDienThoai"></param>
        private bool QuaySoGoiDien(string SoDienThoai)
        {
            try
            {
                serialPort1.PortName = g_COMPort; // thu tu cua cong com
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Open();
                if ((serialPort1 != null) && (serialPort1.IsOpen))
                {
                    string Call = "ATDT" + SoDienThoai + Convert.ToChar(13) + Convert.ToChar(11);
                    serialPort1.Write(Call);
                    return true;

                    System.Threading.Thread.Sleep(1000);
                    serialPort1.Close();
                }
            }
            catch (Exception ex)
            {


            }
            return false; // khong goi
        }
        /// <summary>
        /// ham thực hiện gửi lệnh kết thúc cuốc gọi , đều đặn 10s sẽ gưi một lần
        /// </summary>    
        private void KetThucCuocGoi()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    string Call = "ATH0" + Convert.ToChar(13) + Convert.ToChar(11);
                    serialPort1.Write(Call);
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// hàm hiển thị thông tin form gọi điện
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="DiaChi"></param>
        private void HienThiFormGoiDienThoai(string PhoneNumber, string DiaChi)
        {
            if (g_COMPort.Length > 0)
            {
                frmCalling.Show();
                frmCalling.Invoke(
                                (MethodInvoker)delegate()
                                {
                                    frmCalling.lblSoGoi.Text = "Đang gọi : " + PhoneNumber + " - " + DiaChi;
                                }
                );
                frmCalling.Refresh();
                frmCalling.Call(g_COMPort, PhoneNumber, DiaChi);
            }
        }
        #endregion COM PORT      

        private void uiRightClick_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (e.Command.Key == "cmdChuyenDam")
            {
                frmChuyenDam chuyenDam = new frmChuyenDam(PhanAnhSelected);
                DialogResult dialog = chuyenDam.ShowDialog();
                if(dialog == DialogResult.OK )
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Chuyển đàm thành công.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                }
            }
        }

        private void grdGiaiQuyetPA_Click(object sender, EventArgs e)
        {
            if (grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                if (_strUsername.Length <= 0)
                {
                    CheckIn();
                }
                else
                {
                   PhanAnhSelected  = (ThongTinPhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                }
            }
           
        }

        private void grdDaGiaiQuyetPA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void grdDaGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (grdDaGiaiQuyetPA.SelectedItems != null && grdDaGiaiQuyetPA.SelectedItems.Count > 0)
                {
                    PhanAnhSelected = (ThongTinPhanAnh)((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                    frmGhiChu frm = new frmGhiChu(PhanAnhSelected.ID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadPhanAnh_DaGiaiQuyet(0);
                    }
                }
            }
        }

        private void grdDaGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (grdDaGiaiQuyetPA.SelectedItems != null && grdDaGiaiQuyetPA.SelectedItems.Count > 0)
            {
                PhanAnhSelected = (ThongTinPhanAnh)((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                frmGhiChu frm = new frmGhiChu(PhanAnhSelected.ID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadPhanAnh_DaGiaiQuyet(0);
                }
            }
        }

        /// <summary>
        /// xuat excel 
        /// </summary>
        private void XuatExcel()
        {
           saveFileDialog1.FileName = string.Format("ThongTinPhanAnh_{0:HH_mm_dd_MM_yyyy}.xls", DateTime.Now);
           if (saveFileDialog1.ShowDialog() == DialogResult.OK)
           {
               FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);

               gridEXExporter1.GridEX = null;

               if (tbCuocGoiDaGiaiQuyet.Selected)
                {
                    gridEXExporter1.GridEX = grdDaGiaiQuyetPA  ;
                }
                else if(tbCuocGoiChuyenDV.Selected)
                {  
                    gridEXExporter1.GridEX = grdChuyenDV;
                }
                else if (utabGoiLaiGoiKhac.Selected)
                {

                    gridEXExporter1.GridEX =  gridGoiLaiGoiKhac;
                }
                else
                {
                    gridEXExporter1.GridEX =  grdGiaiQuyetPA;
                } 

               gridEXExporter1.Export((Stream)objFile);
               if (new MessageBox.MessageBox().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
               {
                   FileTools.OpenDirectory( saveFileDialog1.FileName);
               }
               objFile.Close();  

           }
        }

        private void grdDaGiaiQuyetPA_FormattingRow(object sender, RowLoadEventArgs e)
        {
            ThongTinPhanAnh objPhanAnh = (ThongTinPhanAnh)e.Row.DataRow;
            if (objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangVIP)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.Blue;
                e.Row.Cells["TenKhachHang"].FormatStyle = RowStyle;
            }
            else if (objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangVang
                   || objPhanAnh.KieuKhachHangGoiDen == EFiling.Utils.KieuKhachHangGoiDen.KhachHangBac)
            {
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = Color.ForestGreen;
                e.Row.Cells["TenKhachHang"].FormatStyle = RowStyle;
            }
        }

       
    }
}