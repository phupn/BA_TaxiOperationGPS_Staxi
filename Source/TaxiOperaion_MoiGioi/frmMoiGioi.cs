using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Janus.Windows.GridEX;
using System.IO;
using System.Collections;
using TaxiOperation_DieuHanhChinh.BaoCao.New;
using Taxi.GUI.BaoCao;

namespace Taxi.GUI
{
    public partial class frmMoiGioi : Form
    {
        #region ==========================Init=================================

        private static Taxi.MessageBox.MessageBox MessageBox = new Taxi.MessageBox.MessageBox();
        private int g_iStatus = 0;
        // Khai bao ma nguoi dung he thong
        private string strUser_Id;
        private List<DoiTac> G_ListDoiTac = new List<DoiTac>();
        private List<DoiTac> G_ListDoiTacUnActive = new List<DoiTac>();
        private bool G_IsActive = true;
        private DateTime g_TimeServer;
        private Timer TimerCapturePhone;
        private DateTime g_ThoiDiemLayDuLieuTruoc;
        private DateTime g_ThoiDiemLayDuLieuTruoc_Unactive;
        private int g_TimeStep = 0;
        private fmProgress m_fmProgress = null;
        private BackgroundWorker bw = new BackgroundWorker();
        #endregion

        #region =======================Constructor=============================

        public frmMoiGioi()
        {
            InitializeComponent();
        }

        #endregion

        #region ====================Load Form-Set Data=========================
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (DieuHanhTaxi.CheckConnection())
                {
                    // Lay thong tin he thong
                    ThongTinCauHinh.LayThongTinCauHinh();
                    //---------------------------------------------------- 
                    HeThong_DangNhap frmDangNhap = new HeThong_DangNhap();
                    DialogResult dlgResult = frmDangNhap.ShowDialog();
                    if (dlgResult == DialogResult.Cancel) Application.Exit();
                    strUser_Id = ThongTinDangNhap.USER_ID;

                    this.Text = Configuration.GetCompanyName() + " - " + this.Text;
                    G_IsActive = true;

                    LoadData();
                    g_TimeServer = DieuHanhTaxi.GetTimeServer();
                    InitTimerCapturePhone();
                }
                else
                {
                    new MessageBox.MessageBox().Show(this, "Có lỗi kết nối máy chủ, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
                    Application.Exit();
                }

                statusBar.Panels["TenDangNhap"].Text = ThongTinDangNhap.FULLNAME;

                if (ThongTinDangNhap.USER_ID != "admin")
                {
                    //thực hiện phân quyền trên menu
                    PhanQuyenMenu(EF02_mnuMain, ThongTinDangNhap.PermissionsFull);
                }                
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show(this, ex.Message, "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

            }
        }

        private void LoadData()
        {
            // Create a background thread
            
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            // Create a progress form on the UI thread
            m_fmProgress = new fmProgress();
            // Kick off the Async thread
            bw.RunWorkerAsync();
            // Lock up the UI with this modal progress form.
            try
            {
                m_fmProgress.ShowDialog(this);
                m_fmProgress = null;                
                return;
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadListDoiTac()
        {
            G_ListDoiTac = new DoiTac().GetListOfDoiTacs(true);
            HienThiTrenLuoi(true, true);
        }

        private void LoadListDoiTacUnActive()
        {
            G_ListDoiTacUnActive = new DoiTac().GetListOfDoiTacs(false);
            HienThiTrenLuoi_UnActive(true, true);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            m_fmProgress.lblDescription.Text = "Đang tải dữ liệu Môi giới ... ";
            bw.ReportProgress(10);

            LoadListDoiTac();
            bw.ReportProgress(80);
            LoadListDoiTacUnActive();
            bw.ReportProgress(100);
            
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_fmProgress.progressBar1.Value = e.ProgressPercentage;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. First we should hide the
            // modal Progress Form to unlock the UI. The we need to inspect our
            // response to see if an error occured, a cancel was requested or
            // if we completed succesfully.

            // Hide the Progress Form
            if (m_fmProgress != null)
            {
                m_fmProgress.Hide();
                m_fmProgress = null;
            }

            // Check to see if an error occured in the 
            // background process.
            if (e.Error != null)
            {
                new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
                return;
            }

            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
                return;
            }
        }

        #endregion

        #region ======================Validation Form==========================
        /// <summary>
        /// Phân quyền trên menu theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="menu">Menu cần phân quyền</param>
        /// <param name="DataTablePermission">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// </Modified> 
        private void PhanQuyenMenu(MenuStrip MenuPhanQuyen, ArrayList DanhSachQuyen)
        //Phân quyền trên menu
        {
            if (MenuPhanQuyen != null && MenuPhanQuyen.Tag != null && MenuPhanQuyen.Tag.ToString().ToString().Length <= 0)
                MenuPhanQuyen.Visible = true;
            foreach (ToolStripMenuItem mnuItem in MenuPhanQuyen.Items)
            {
                if (DanhSachQuyen != null && mnuItem.Tag != null)
                {
                    if (DanhSachQuyen.Contains(mnuItem.Tag.ToString()))
                        mnuItem.Visible = true;
                    else
                        mnuItem.Visible = false;
                    if (mnuItem != null && mnuItem.Tag != null && mnuItem.Tag.ToString().Length <= 0)
                        mnuItem.Visible = true;
                }
                //Phân quyền các menu con (nếu có)
                if (mnuItem != null && mnuItem.DropDownItems.Count > 0)
                {
                    PhanQuyenMenuItem(mnuItem, DanhSachQuyen);
                }
            }
        }

        /// <summary>
        /// Phân quyền trên menu item theo danh sách quyền của người dùng
        /// </summary>
        /// <param name="MenuItemPhanQuyen">Menu item cần phân quyền</param>
        /// <param name="DanhSachQuyen">Danh sách quyền người dùng</param>
        /// <Modified>
        /// Name        Date        Comment
        /// LongNM      06/05/2008  Tạo mới
        /// HaiNT       26/05/2008  Kiểm tra DanhSachQuyen not null
        /// </Modified>
        private void PhanQuyenMenuItem(ToolStripMenuItem MenuItemPhanQuyen, ArrayList DanhSachQuyen)
        {
            if (MenuItemPhanQuyen != null && MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag.ToString().Length <= 0)
                MenuItemPhanQuyen.Visible = true;
            //phân quyền cho menu item
            if (DanhSachQuyen != null && MenuItemPhanQuyen != null && MenuItemPhanQuyen.Tag != null)
            {
                if (DanhSachQuyen.Contains(MenuItemPhanQuyen.Tag.ToString()))
                    MenuItemPhanQuyen.Visible = true;
                else
                    MenuItemPhanQuyen.Visible = false;
                if (MenuItemPhanQuyen != null && MenuItemPhanQuyen.Tag != null && MenuItemPhanQuyen.Tag.ToString().Length <= 0)
                    MenuItemPhanQuyen.Visible = true;
            }
            //phân quyền cho các menu item con (nếu có)
            if (MenuItemPhanQuyen != null && MenuItemPhanQuyen.DropDownItems.Count > 0)
            {
                for (int i = 0; i < MenuItemPhanQuyen.DropDownItems.Count; i++)
                {
                    object mnuItem = MenuItemPhanQuyen.DropDownItems[i];
                    if (mnuItem != null)
                    {
                        if (!(mnuItem is System.Windows.Forms.ToolStripSeparator))
                            PhanQuyenMenuItem((ToolStripMenuItem)mnuItem, DanhSachQuyen);
                    }
                }
            }
        }

        private void HienThiTrenLuoi(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                if (IsCapNhat)
                {
                    if (IsThemMoi)
                    {
                        grdDoiTac.DataSource = null;
                        grdDoiTac.DataMember = "ListDoiTac";
                        grdDoiTac.SetDataBinding(G_ListDoiTac, "ListDoiTac");
                        grdDoiTac.UpdateData();
                        //grdDoiTac.Refresh();
                    }
                    else
                    {
                        grdDoiTac.Refresh();
                    }
                }
                else
                {
                    grdDoiTac.Refetch();
                }
            }
            catch (Exception)
            {
            }
        }

        private void HienThiTrenLuoi_UnActive(bool IsCapNhat, bool IsThemMoi)
        {
            try
            {
                if (IsCapNhat)
                {
                    if (IsThemMoi)
                    {
                        gridDoiTacUnActive.DataSource = null;
                        gridDoiTacUnActive.DataMember = "ListDoiTacUnActive";
                        gridDoiTacUnActive.SetDataBinding(G_ListDoiTacUnActive, "ListDoiTacUnActive");
                        gridDoiTacUnActive.UpdateData();
                        //gridDoiTacUnActive.Refetch();
                    }
                    else
                    {
                        gridDoiTacUnActive.Refresh();
                    }
                }
                else
                {
                    gridDoiTacUnActive.Refetch();
                }
            }
            catch (Exception)
            {
            }
        }

        private void TimVaCapNhatCuocGoi(ref List<DoiTac> ListDoiTac, DoiTac objDoiTac)
        {
            if (ListDoiTac != null && ListDoiTac.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < ListDoiTac.Count; i++)
                {
                    if (ListDoiTac[i].MaDoiTac == objDoiTac.MaDoiTac)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    if (objDoiTac.IsActive == true)
                    {
                        ListDoiTac[index].MaDoiTac = objDoiTac.MaDoiTac;
                        ListDoiTac[index].Name = objDoiTac.Name;
                        ListDoiTac[index].Address = objDoiTac.Address;
                        ListDoiTac[index].Phones = objDoiTac.Phones;
                        ListDoiTac[index].TenDuong = objDoiTac.TenDuong;
                        ListDoiTac[index].SoNha = objDoiTac.SoNha;
                        ListDoiTac[index].Fax = objDoiTac.Fax;
                        ListDoiTac[index].Email = objDoiTac.Email;
                        ListDoiTac[index].NgaySua = objDoiTac.NgaySua;
                        ListDoiTac[index].NguoiSua = objDoiTac.NguoiSua;

                        if (objDoiTac.TiLeHoaHongNoiTinh > 0)
                            ListDoiTac[index].TiLeHoaHongNoiTinh = objDoiTac.TiLeHoaHongNoiTinh = float.Parse(objDoiTac.TiLeHoaHongNoiTinh.ToString());
                        else
                            ListDoiTac[index].TiLeHoaHongNoiTinh = 0;

                        ListDoiTac[index].Notes = objDoiTac.Notes;
                        ListDoiTac[index].MaNhanVien = objDoiTac.MaNhanVien;
                        ListDoiTac[index].TenNhanVien = objDoiTac.TenNhanVien;
                        if (objDoiTac.Vung != null || objDoiTac.Vung <= 0)
                            ListDoiTac[index].Vung = int.Parse(objDoiTac.Vung.ToString().Length <= 0 ? "1" : objDoiTac.Vung.ToString());
                        else ListDoiTac[index].Vung = 1;

                        ListDoiTac[index].NgayKyKet = DateTime.Parse(objDoiTac.NgayKyKet.ToString().Length <= 0 ? "01-01-1900 01:01:01" : objDoiTac.NgayKyKet.ToString());

                    }
                    else
                    {
                        ListDoiTac.RemoveAt(index);
                        //objDoiTac.IsActive = false;
                        G_ListDoiTac.Insert(0, objDoiTac);
                        //HienThiTrenLuoi_UnActive(true,true);

                    }
                }
                else
                {
                    G_ListDoiTac.Insert(0, objDoiTac);
                }
            }
        }

        private void TimVaCapNhatCuocGoi_UnActive(ref List<DoiTac> ListDoiTac, DoiTac objDoiTac)
        {
            if (ListDoiTac != null && ListDoiTac.Count > 0)
            {
                int index = -1;
                for (int i = 0; i < ListDoiTac.Count; i++)
                {
                    if (ListDoiTac[i].MaDoiTac == objDoiTac.MaDoiTac)
                    {
                        index = i;
                        break;
                    }
                }
                if (index >= 0)
                {
                    if (objDoiTac.IsActive == false)
                    {
                        ListDoiTac[index].MaDoiTac = objDoiTac.MaDoiTac;
                        ListDoiTac[index].Name = objDoiTac.Name;
                        ListDoiTac[index].Address = objDoiTac.Address;
                        ListDoiTac[index].Phones = objDoiTac.Phones;
                        ListDoiTac[index].TenDuong = objDoiTac.TenDuong;
                        ListDoiTac[index].SoNha = objDoiTac.SoNha;
                        ListDoiTac[index].Fax = objDoiTac.Fax;
                        ListDoiTac[index].Email = objDoiTac.Email;
                        ListDoiTac[index].NgaySua = objDoiTac.NgaySua;
                        ListDoiTac[index].NguoiSua = objDoiTac.NguoiSua;

                        if (objDoiTac.TiLeHoaHongNoiTinh > 0)
                            ListDoiTac[index].TiLeHoaHongNoiTinh = objDoiTac.TiLeHoaHongNoiTinh = float.Parse(objDoiTac.TiLeHoaHongNoiTinh.ToString());
                        else
                            ListDoiTac[index].TiLeHoaHongNoiTinh = 0;

                        ListDoiTac[index].Notes = objDoiTac.Notes;
                        ListDoiTac[index].MaNhanVien = objDoiTac.MaNhanVien;
                        ListDoiTac[index].TenNhanVien = objDoiTac.TenNhanVien;
                        if (objDoiTac.Vung != null || objDoiTac.Vung <= 0)
                            ListDoiTac[index].Vung = int.Parse(objDoiTac.Vung.ToString().Length <= 0 ? "1" : objDoiTac.Vung.ToString());
                        else ListDoiTac[index].Vung = 1;

                        ListDoiTac[index].NgayKyKet = DateTime.Parse(objDoiTac.NgayKyKet.ToString().Length <= 0 ? "01-01-1900 01:01:01" : objDoiTac.NgayKyKet.ToString());

                    }
                    else
                    {
                        ListDoiTac.RemoveAt(index);
                        //objDoiTac.IsActive = true;
                        G_ListDoiTac.Insert(0,objDoiTac);
                        //HienThiTrenLuoi(true, true);
                    }
                }
                else
                {
                    G_ListDoiTac.Insert(0, objDoiTac);
                }
            }
        }

        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                DateTime tempDate = new DateTime(2000, 1, 1, 0, 0, 1);
                DoiTac objDoiTac = (DoiTac)row.DataRow;
                if (objDoiTac.NgayTao <= tempDate)
                {

                    row.Cells["NgayTao"].Text = string.Empty;
                }
                if (objDoiTac.NgaySua <= tempDate)
                {
                    row.Cells["NgaySua"].Text = string.Empty;
                }
                if (objDoiTac.NgayKetThuc <= tempDate)
                {
                    row.Cells["NgayKetThuc"].Text = string.Empty;
                }
                else
                {
                    //GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    //RowStyle.BackColor = Color.Pink;
                    //row.RowStyle = RowStyle;
                }

            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }        
        #endregion

        #region =======================Get Data Form===========================
        
        #endregion

        #region ========================Form Events============================
        
        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (e.Page.Name == "uiTabMGDangHoatDong")
            {
                G_IsActive = true;
                HienThiTrenLuoi(true, true);
            }
            else if (e.Page.Name == "uiTabMGNgungHoatDong")
            {
                G_IsActive = false;
                HienThiTrenLuoi_UnActive(true, true);
            }
        }

        private void mnuThemMoi_Click(object sender, EventArgs e)
        {
            this.ThemDoiTac();
        }

        private void mnhUpdate_Click(object sender, EventArgs e)
        {
            this.SuaDoiTac();
        }

        private void mnuBatDau_Click(object sender, EventArgs e)
        {
            this.ActiveDoiTac(true);
        }

        private void mnuDung_Click(object sender, EventArgs e)
        {
            this.ActiveDoiTac(false);
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            this.DeleteDoiTac();
        }

        private void mnuXuatExcel_Click(object sender, EventArgs e)
        {
            this.XuatExcel();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            frmDoiTacTimKiem frm = new frmDoiTacTimKiem();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.GetResultListOfDoiTac().Count > 0)
                {
                    grdDoiTac.DataSource = null;
                    grdDoiTac.DataMember = "ListOfDoiTac";
                    grdDoiTac.SetDataBinding(frm.GetResultListOfDoiTac(), "ListOfDoiTac");
                }
                else
                {
                    new MessageBox.MessageBox().Show("Không tìm thấy kết quả nào");
                    return;
                }
            }
        }

        private void mnuCapNhatCG_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinMoiGioi frm = new frmCapNhatThongTinMoiGioi(G_ListDoiTac);
            frm.ShowDialog();
        }

        private void mnuKTTrungDT_Click(object sender, EventArgs e)
        {
            frmKiemTraTrungSoDoiTac frm = new frmKiemTraTrungSoDoiTac(G_ListDoiTac, G_ListDoiTacUnActive);
            frm.Show();
        }

        private void EF02_mniExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EF02_mniUserManagement_Click(object sender, EventArgs e)
        {
            new CapNhatThongTinCaNhan().ShowDialog();
        }

        private void EF02_mniLogin_Click(object sender, EventArgs e)
        {
            if (strUser_Id.Length > 0)
            {
                Application.Restart();
            }
            else
            {
                // Nếu trong CSDL có rồi thì chỉ xuất ra form Đăng nhập 
                HeThong_DangNhap frmDangNhap = new HeThong_DangNhap();
                DialogResult dlgResult = frmDangNhap.ShowDialog();
                strUser_Id = ThongTinDangNhap.USER_ID;
            }

        }

        private void mnuNhapDuLieuBangKe_Click(object sender, EventArgs e)
        {
            frmBangKe frmBangKe = new frmBangKe();
            frmBangKe.ShowDialog();
        }

        private void mnuCalculateByKm_Click(object sender, EventArgs e)
        {
            frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP();
            frm.ShowDialog(this);
        }

        private void mnuTiLePhanBo_Click(object sender, EventArgs e)
        {
            new Taxi.GUI.frmTiLePhanBo().Show();
        }

        #region --Process method--
        private void ThemDoiTac()
        {
            // Khoi tao doi tuong DoiTac voi ma

            DoiTac objDoiTac = new DoiTac("", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, string.Empty, true, "", "", 0, "");

            frmDoiTac frm = new frmDoiTac(objDoiTac, true,G_ListDoiTac,G_ListDoiTacUnActive);// them moi
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                objDoiTac = frm.DoiTac;
                // objDoiTac.
                // Insert DataBase
                // Clone
                objDoiTac.NguoiTao = ThongTinDangNhap.USER_ID;
                objDoiTac.NgayTao = DieuHanhTaxi.GetTimeServer();
                if (!objDoiTac.Insert())
                {
                    new MessageBox.MessageBox().Show("Lỗi thêm mới đối tác");
                    return;
                }
                else
                {
                    //Load lai grid
                    if (G_IsActive)
                    {
                        TimVaCapNhatCuocGoi(ref G_ListDoiTac, objDoiTac);
                        HienThiTrenLuoi(true, true);
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi_UnActive(ref G_ListDoiTacUnActive, objDoiTac);
                        HienThiTrenLuoi_UnActive(true, true);
                    }
                    //if (new MessageBox.MessageBox().Show("Có một môi giới mới, bạn cần cập nhật lại cuộc gọi môi giới", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    //{
                    //    // Lay cuoc goi da ket thuc
                    //    List<DieuHanhTaxi> lstDieuHanhTaxi = new List<DieuHanhTaxi>();
                    //    lstDieuHanhTaxi = new DieuHanhTaxi().Get_CuocGoi_KetThuc(" ", " ");

                    //    if (!DieuHanhTaxi.UpdateLaiCuocGoiMoiGioi(objDoiTac, lstDieuHanhTaxi))
                    //    {
                    //        new MessageBox.MessageBox().Show("Lỗi cập nhật cuộc gọi môi giới");
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        new MessageBox.MessageBox().Show("Cập nhật cuộc gọi môi giới thành công");
                    //        return;
                    //    }
                    //}
                }

            }


        }

        private void SuaDoiTac()
        {
            DoiTac objDoiTac = new DoiTac();
            if (grdDoiTac.SelectedItems.Count > 0 && grdDoiTac.SelectedItems[0].RowType == RowType.Record && G_IsActive)
            {
                objDoiTac = DoiTac.Clone<DoiTac>((DoiTac)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow);
            }
            else
            {
                objDoiTac = DoiTac.Clone<DoiTac>((DoiTac)((GridEXSelectedItem)gridDoiTacUnActive.SelectedItems[0]).GetRow().DataRow);
            }
            string maDoiTac_Old = objDoiTac.MaDoiTac;
            frmDoiTac frm = new frmDoiTac(objDoiTac, false, G_ListDoiTac, G_ListDoiTacUnActive);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                objDoiTac = frm.DoiTac;
                //Insert DataBase
                objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                objDoiTac.NgaySua = DieuHanhTaxi.GetTimeServer();
                if (!objDoiTac.Update(maDoiTac_Old))
                {
                    new MessageBox.MessageBox().Show("Lỗi cập nhật đối tác");
                    return;
                }
                else
                {
                    if (G_IsActive)
                    {
                        TimVaCapNhatCuocGoi(ref G_ListDoiTac, objDoiTac);
                        HienThiTrenLuoi(true, false);
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi_UnActive(ref G_ListDoiTacUnActive, objDoiTac);
                        HienThiTrenLuoi_UnActive(true, false);
                    }                        
                }
            }
        }

        private void DeleteDoiTac()
        {
            MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();
            try
            {
                grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                gridDoiTacUnActive.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                GridEXRow[] rows = null;
                if (grdDoiTac.SelectedItems.Count > 0 && G_IsActive)
                {
                    rows = grdDoiTac.GetCheckedRows();
                }
                else if (gridDoiTacUnActive.SelectedItems.Count > 0 && !G_IsActive)
                {
                    rows = gridDoiTacUnActive.GetCheckedRows();
                }
                if (rows != null && rows.Length > 0)
                {                    
                    if (msg.Show(this, "Bạn có xóa danh sách môi giới không ?", "Xóa môi giới", Taxi.MessageBox.MessageBoxButtons.OKCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.OK.ToString())
                    {
                        string[] arrMaDoiTac = new string[rows.Length];
                        int i = 0;
                        foreach (GridEXRow row in rows)
                        {
                            DoiTac objDoiTac = (DoiTac)row.DataRow;
                            if (objDoiTac == null) return;
                            if (objDoiTac.Delete(objDoiTac.MaDoiTac))
                            {                                
                                arrMaDoiTac[i] = objDoiTac.MaDoiTac;
                                i++;
                            }
                        }

                        foreach (string strMaDoiTac in arrMaDoiTac)
                        {
                            if (string.IsNullOrEmpty(strMaDoiTac)) continue;
                            if (G_IsActive)
                                removeDoiTac(strMaDoiTac);
                            else
                                removeDoiTacUnActive(strMaDoiTac);
                        }

                        if (G_IsActive)
                            HienThiTrenLuoi(true, true);
                        else
                            HienThiTrenLuoi_UnActive(true, true);
                    }
                }
            }
            catch (Exception ex)
            {
                msg.Show(this, "Lỗi trong quá trình xử lý, vui lòng thông báo cho người quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }

        private void ActiveDoiTac(bool isActive)
        {
            MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();
            try
            {
                grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                gridDoiTacUnActive.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                GridEXRow[] rows = null;
                if (grdDoiTac.SelectedItems.Count > 0 && G_IsActive && !isActive)
                {
                    rows = grdDoiTac.GetCheckedRows();
                }
                else if (gridDoiTacUnActive.SelectedItems.Count > 0 && !G_IsActive && isActive)
                {
                    rows = gridDoiTacUnActive.GetCheckedRows();
                }

                if (rows != null && rows.Length > 0)
                {                    
                    if (msg.Show(this, "Bạn có muốn thay đổi hoạt động của danh sách môi giới không ?", "Thay đổi trạng thái môi giới", Taxi.MessageBox.MessageBoxButtons.OKCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.OK.ToString())
                    {
                        string[] arrMaDoiTac = new string[rows.Length];
                        int i = 0;
                        foreach (GridEXRow row in rows)
                        {
                            DoiTac objDoiTac = (DoiTac)row.DataRow;
                            if (objDoiTac == null) return;

                            objDoiTac.IsActive = isActive;
                            objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                            objDoiTac.NgaySua = g_TimeServer;

                            if (objDoiTac.Active(objDoiTac.MaDoiTac, isActive, objDoiTac.NguoiSua))
                            {
                                arrMaDoiTac[i] = objDoiTac.MaDoiTac;
                                i++;
                                if (isActive)
                                {
                                    objDoiTac.NgayKyKet = g_TimeServer;
                                    objDoiTac.NgayKetThuc = new DateTime(2000, 1, 1, 0, 0, 1);
                                }
                                else
                                {
                                    objDoiTac.NgayKetThuc = g_TimeServer;
                                }
                                if (G_IsActive)
                                {
                                    G_ListDoiTacUnActive.Insert(0, objDoiTac);
                                    //TimVaCapNhatCuocGoi(ref G_ListDoiTac, objDoiTac);
                                    //HienThiTrenLuoi(true, true);
                                }
                                else
                                {
                                    G_ListDoiTac.Insert(0, objDoiTac);
                                    //TimVaCapNhatCuocGoi_UnActive(ref G_ListDoiTacUnActive, objDoiTac);
                                    //HienThiTrenLuoi_UnActive(true, true);
                                }
                            }
                        }

                        foreach (string strMaDoiTac in arrMaDoiTac)
                        {
                            if (string.IsNullOrEmpty(strMaDoiTac)) continue;
                            if (G_IsActive)
                                removeDoiTac(strMaDoiTac);
                            else
                                removeDoiTacUnActive(strMaDoiTac);
                        }

                        if (G_IsActive)
                            HienThiTrenLuoi(true, true);
                        else                    
                            HienThiTrenLuoi_UnActive(true, true);


                    }
                }


            }
            catch (Exception ex)
            {
                msg.Show(this, "Lỗi trong quá trình xử lý, vui lòng thông báo cho người quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }
        }

        private void removeDoiTac(string maDoiTac)
        {
            for (int i = 0; i < G_ListDoiTac.Count; i++)
            {
                if (G_ListDoiTac[i].MaDoiTac == maDoiTac)
                {
                    G_ListDoiTac.RemoveAt(i);
                    break;
                }
            }
        }

        private void removeDoiTacUnActive(string maDoiTac)
        {
            for (int i = 0; i < G_ListDoiTacUnActive.Count; i++)
            {
                if (G_ListDoiTacUnActive[i].MaDoiTac == maDoiTac)
                {
                    G_ListDoiTacUnActive.RemoveAt(i);
                    break;
                }
            }
        }

        private void XuatExcel()
        {
            string FilenameDefault = "DSMoiGioi.xls";
            if (G_IsActive)
            {
                gridEXExporter1.GridEX = grdDoiTac;
                FilenameDefault = "DSMoiGioi_DangHoatDong.xls";
            }
            else
            {
                gridEXExporter1.GridEX = gridDoiTacUnActive;
                FilenameDefault = "DSMoiGioi_DaNgungHoatDong.xls";
            }
            
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                {                    
                    gridEXExporter1.Export((Stream)objFile);
                    if (new MessageBox.MessageBox().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNoCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
                
            }
        }
        #endregion
        
        #endregion

        #region =========================Grid Event============================
        private void grdDoiTac_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        private void grdDoiTac_DoubleClick(object sender, EventArgs e)
        {
            SuaDoiTac();
            //grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            //if (grdDoiTac.SelectedItems.Count > 0 && grdDoiTac.SelectedItems[0].RowType == RowType.Record)
            //{
            //    GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
            //    DoiTac objDoiTac = (DoiTac)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
            //    string maDoiTac_Old = objDoiTac.MaDoiTac;
            //    frmDoiTac frm = new frmDoiTac(objDoiTac, false, G_ListDoiTac, G_ListDoiTacUnActive);
            //    if (frm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        //Insert DataBase
                    
            //        objDoiTac = frm.DoiTac;
            //        frm.Dispose();
            //        //Insert DataBase
            //        objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
            //        if (!objDoiTac.Update(maDoiTac_Old))
            //        {
            //            new MessageBox.MessageBox().Show("Lỗi cập nhật đối tác");
            //            return;
            //        }
            //        else
            //        {
            //            TimVaCapNhatCuocGoi(ref G_ListDoiTac, objDoiTac);
            //            HienThiTrenLuoi(true, false);
            //        }
            //    }
            //    else return;
            //}
        }

        private void gridDoiTacUnActive_DoubleClick(object sender, EventArgs e)
        {
            grdDoiTac.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDoiTac.SelectedItems.Count > 0 && grdDoiTac.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = ((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow();
                DoiTac objDoiTac = (DoiTac)((GridEXSelectedItem)grdDoiTac.SelectedItems[0]).GetRow().DataRow;
                string maDoiTac_Old = objDoiTac.MaDoiTac;
                frmDoiTac frm = new frmDoiTac(objDoiTac, false, G_ListDoiTac, G_ListDoiTacUnActive);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {                    
                    objDoiTac = frm.DoiTac;
                    frm.Dispose();
                    //Insert DataBase
                    objDoiTac.NguoiSua = ThongTinDangNhap.USER_ID;
                    if (!objDoiTac.Update(maDoiTac_Old))
                    {
                        new MessageBox.MessageBox().Show("Lỗi update đối tác");
                        return;
                    }
                    else
                    {
                        TimVaCapNhatCuocGoi_UnActive(ref G_ListDoiTacUnActive, objDoiTac);
                        HienThiTrenLuoi_UnActive(true, false);
                    }
                }
                else return;
            }
        }

        private void gridDoiTacUnActive_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiAnhTrangThai_MauChu(e.Row);
        }

        #endregion

        #region =========================Timer=================================
        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += new EventHandler(TimerCapturePhone_Tick);
            TimerCapturePhone.Start();

        }
        /// <summary>
        /// Nhan cac cuoc goi moi 
        /// Nhan thong tin moi chuyen ve
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eArgs"></param>
        public void TimerCapturePhone_Tick(object sender, EventArgs eArgs)
        {
            try
            {
                g_TimeServer = g_TimeServer.AddSeconds(1);
                bool hasThemMoi = false;
                bool hasCapNhat = false;
                //LoadCuocGoiMoiThayDoiTuDTV_TDV(ref g_lstDienThoai, g_strVungsDuocCapPhep, g_ThoiDiemLayDuLieuTruoc, ref hasCapNhat, ref hasThemMoi, g_MayCS);

                if (hasCapNhat) // co thay doi du lieu moi cap nhat cuoc goi
                {
                    //HienThiTrenLuoi(hasCapNhat, hasThemMoi);
                    g_ThoiDiemLayDuLieuTruoc = g_TimeServer;
                }
                g_TimeStep++;
                if (g_TimeStep >= 3)  // 3 giay thuc hien mot lan
                {
                    //CapNhatCuocGoiDaKetThuc(ref g_lstDienThoai, g_strVungsDuocCapPhep, ref hasCapNhat, g_MayCS);
                    if (hasCapNhat)
                    {
                        //HienThiTrenLuoi(false, false);
                    }
                    g_TimeStep = 0;
                }

                if (G_IsActive == false)
                {
                    try
                    {
                        //LoadCacCuocGoiKetThuc(this.g_strVungsDuocCapPhep, g_soDong, g_MayCS);
                    }
                    catch (Exception ex)
                    {
                        //new MessageBox.MessageBox().Show("TimerCapturePhone_Tick " + ex.Message);
                        // //  LogError.WriteLog("Loi trong timer: LoadCacCuocGoiKetThuc().", ex);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        //private void Get(List<CuocGoi> listCuocGoiHienTai, string linesDuocCapPhep, DateTime thoiDiemNhanDulieuTruoc, ref bool hasCuocGoiMoi)
        //{
        //    hasCuocGoiMoi = false;
        //    List<CuocGoi> listCuocGoiMoi = CuocGoi.DIENTHOAI_LayDSCuocGoiMoi_V3(linesDuocCapPhep, thoiDiemNhanDulieuTruoc);
        //    CuocGoi objCuocGoi;
        //    if (listCuocGoiMoi != null && listCuocGoiMoi.Count > 0)
        //    {
        //        foreach (CuocGoi objCG in listCuocGoiMoi)
        //        {
        //            if (!KiemTraCuocGoiDaTonTai(listCuocGoiHienTai, objCG))
        //            {
        //                listCuocGoiHienTai.Insert(0, objCG);
        //                hasCuocGoiMoi = true;
        //                //
        //            }
        //            //Kiem tra cuoc goi lai
        //            //long IDCG = objCG.IDCuocGoi;
        //            //objCuocGoi = listCuocGoiHienTai.Find(T=> T.PhoneNumber == objCG.PhoneNumber
        //            //                                    && T.CuocGoiLaiIDs.Length <=0
        //            //                                    && T.PhoneNumber != ThongTinCauHinh.SoDienThoaiCongTy
        //            //                                    && T.TrangThaiLenh == TrangThaiLenhTaxi.KhongTruyenDi);
        //            //if (objCuocGoi != null)
        //            //{
        //            //    objCG.CuocGoiLaiIDs = objCuocGoi.IDCuocGoi.ToString();
        //            //}
        //        }
        //    }
        //}

        #endregion

        #region Báo cáo
        private void mnu6_1_DanhSachDiaChiMoiGioi_Click(object sender, EventArgs e)
        {
            new frmBC_6_1_DSDiaChiMoiGioi().Show();
        }

        private void mnu6_4_TongHopMoiGioiQuaTrungTam_Click(object sender, EventArgs e)
        {
            new frmBC_6_4_TongHopMoiGioiGoiQuaTT().Show();
        }

        private void mnu6_5_ChiTietCuocKhachMoiGioi_Click(object sender, EventArgs e)
        {
            new frmBC_6_5_BaoCaoMoiGioiTheoDiaChi().Show();
        }

        private void mnu6_7_BCCuocKhachMGTheoDiaChi_Click(object sender, EventArgs e)
        {
            new frmBC_6_7_MoiGioiTheoDiaChi().Show();
        }

        private void mnu4_4BCDieuHanhTheoDonVi_Click(object sender, EventArgs e)
        {
            new frmBC_4_4_KetQuaDieuHanhTheoDonVi().Show();
        }

        private void mnuBCMoiGioiCu_Click(object sender, EventArgs e)
        {
            new frmBaoCaoGroupMoiGioiCuocKetQuaDieuHanh().Show();
        }

        private void mnu1_3_ChiTietCuocGioDen_Click(object sender, EventArgs e)
        {
            new frmBC_1_3_ChiTietCuocGoiDen().Show();
        }
        #endregion
    }
}