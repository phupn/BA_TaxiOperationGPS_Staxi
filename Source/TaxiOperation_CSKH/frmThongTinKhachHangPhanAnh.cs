using System;
using System.Collections.Generic;
using System.Windows.Forms; 
using Janus.Windows.GridEX; 
using System.Data;
using System.ComponentModel; 
using System.Collections;
using System.Drawing;

using Taxi.GUI.BaoCao;
using System.IO;
using Taxi.Business.PhanAnh;
using Taxi.Business.QuanTri;
using Taxi.Business;
using Taxi.Business.BanGiaGoc;
using System.Diagnostics;

namespace Taxi.GUI
{
    public partial class frmThongTinKhachHangPhanAnh : Form
    {
        #region ===========================Initialize==================================
        public List<PhanAnh> g_lstThongTinPA = new List<PhanAnh>();
        public static string RoleNhanVien = string.Empty;
        private string g_strUsername = "";
        private string g_IPAddress = "";
        private string g_strFullName = "";
        private string g_LinesDuocCapPhep = string.Empty;
        private ArrayList G_DanhSachQuyen;

        private DateTime g_ThoiDiemNhanDulieuTruoc = DateTime.MinValue;
        private DateTime g_ThoiDiemNhanDulieuCapNhatTruoc = DateTime.MinValue;
        private DateTime g_TimeServer = DateTime.MinValue;
        private int g_TimerStep = 0; //
        string g_COMPort = "";
        public static frmDangGoi frmCalling = new frmDangGoi();
        //--------------------------------LAYOUT----------------------------------------------------
        private Taxi.Business.GridLayout.GridLayout gridLayout;
        private void loadLayout(GridEX gridEX)
        {
          //  gridLayout = new Taxi.Business.GridLayout.GridLayout(ThongTinDangNhap.USER_ID, "PhanAnh", Name, gridEX.Name);
           // gridEX.LoadLayout(gridLayout.getLayout(gridEX.GetLayout()));
        }
        //--------------------------------LAYOUT----------------------------------------------------
        
        public frmThongTinKhachHangPhanAnh()
        {
            InitializeComponent();
        }
        #endregion       

        #region ===========================Load Form===================================
        private void frmThongTinKhachHangPhanAnh_Load(object sender, EventArgs e)
        {
           
            HeThong_DangNhap frmDangNhap = new HeThong_DangNhap();
            DialogResult dlgResult = frmDangNhap.ShowDialog(); 

            g_IPAddress = QuanTriCauHinh.GetIPPC();

            g_LinesDuocCapPhep = QuanTriCauHinh.GetVungsOfPCTongDai(g_IPAddress);
            g_strUsername = ThongTinDangNhap.USER_ID;
            //using (DataTable dt = QuanTriCauHinh.GetLines_LoaiXeOfPCDienThoai(g_IPAddress))
            //{
            //    if (dt.Rows != null && dt.Rows.Count > 0)
            //        g_LinesDuocCapPhep = dt.Rows[0]["Line_Vung"].ToString();
            //    else
            //        g_LinesDuocCapPhep = string.Empty;
            //}
            if (Debugger.IsAttached)
            {
                g_LinesDuocCapPhep = "11";
            }
             if (g_LinesDuocCapPhep.Length > 0)
            {
                g_TimeServer = DieuHanhTaxi.GetTimeServer();
                g_ThoiDiemNhanDulieuTruoc = g_TimeServer;
                g_ThoiDiemNhanDulieuCapNhatTruoc = g_TimeServer;
              
                 LoadPhanAnh_ChuaGiaiQuyet(0);
                
                 ThongTinCauHinh.LayThongTinCauHinh();
               
                statusBar.Panels["TenDangNhap"].Text = string.Format("NV : {0} - {1}", g_strUsername, g_strFullName);
                grdGiaiQuyetPA.Focus();
                InitTimerCapturePhone();
                
                KhoiTaoCOMPort(); // khoi dong kiem tra COM, lay cong co the mo duoc
                statusBar.Panels["COM"].Text = " COM: " + g_COMPort; 
            }
            else
            {
                new MessageBox.MessageBoxBA().Show(this, "Máy tính này không được cấp phép trong hệ thống, cần liên lạc với quản trị.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                //LogError.WriteLogError("IP : " + g_IPAddress, new Exception("Thong tin dia chi ip"));
                Application.Exit();
            }
        } 
        public void LoadPhanAnh_ChuaGiaiQuyet(int Position)
        {
            //g_lstThongTinPA = new PhanAnh().GetPhanAnh(false);

            grdGiaiQuyetPA.DataMember = "lstThongTinPA";
            grdGiaiQuyetPA.SetDataBinding(new PhanAnh().GetPhanAnh(false), "lstThongTinPA");

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
            //g_lstThongTinPA = new PhanAnh().GetPhanAnh(true);

            grdDaGiaiQuyetPA.DataMember = "lstThongTinPA";
            grdDaGiaiQuyetPA.SetDataBinding(new PhanAnh().GetPhanAnh(true), "lstThongTinPA");
            // Congnt sua ----
            if (Position > 0) { grdDaGiaiQuyetPA.Row = Position; }
            // ---------------

        }

        #region-----------------------------Send Message--------------------------------------
        private void timerMessage()
        {
            //if (ThongTinDangNhap.USER_ID == "")
            //    return;
            //// Kiem tra tin nhan
            //if (frmMessenger.IsDisposed == false)
            //{

            //    if (frmMessenger.Visible == false)
            //    {
            //        if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
            //        {
            //            frmMessenger.Show();
            //        }
            //    }
            //    else
            //    {
            //        frmMessenger.BringToFront();
            //    }
            //}
            //else
            //{
            //    frmMessenger = new Messenger();
            //    if (new Chatting().CheckNewMessage(ThongTinDangNhap.USER_ID) > 0)
            //    {
            //        frmMessenger.Show();
            //    }
            //}
        }
        #endregion--------------------------End Message---------------------------------------

        #endregion

        #region  ===========================ChẹckIn/CheckOut ===========================
        /// <summary>
        /// check in, goi form frmCheckInOut
        /// </summary>
        //private void CheckIn()
        //{
        //    using (frmCheckInOut frm = new frmCheckInOut())
        //    {
        //        if (frm.ShowDialog() != DialogResult.OK)
        //            return;
        //    }

        //    g_strFullName = ThongTinDangNhap.FULLNAME;
        //    g_strUsername = ThongTinDangNhap.USER_ID;
        //    if (g_strUsername.Length > 0)
        //    {
        //        if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
        //        {
        //            CheckIn1.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //            CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //            if ((ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH)) && (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH)))
        //            {
        //                RoleNhanVien = "All";
        //            }
        //            else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH))
        //            {
        //                RoleNhanVien = DanhSachVaiTro.NVNHANPHANANH;
        //            }
        //            else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
        //            {
        //                RoleNhanVien = DanhSachVaiTro.NVGIAIQUYETPHANANH;
        //            }

        //            //--------------------------LAYOUT-------------------------------------
        //            loadLayout(grdGiaiQuyetPA);
        //            //--------------------------LAYOUT-------------------------------------

        //        }
        //        else
        //        {
        //            // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
        //            if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
        //            {
        //                string msgConfirm = new MessageBox.MessageBox().Show(this,
        //                     "Máy tính này đã có người đăng nhập vào hệ thống. Bạn có muốn tiếp tục đăng nhập vào máy tính này không ?",
        //                     "Thông báo",
        //                     Taxi.MessageBox.MessageBoxButtons.YesNo,
        //                     Taxi.MessageBox.MessageBoxIcon.Warning);
        //                confirmCheckIn(msgConfirm, 1);
        //            }
        //            // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
        //            else if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
        //            {
        //                string msgConfirm = new MessageBox.MessageBox().Show(this,
        //                    "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn có muốn tiếp tục đăng nhập vào máy tính này không ?",
        //                                                    "Thông báo",
        //                                                    Taxi.MessageBox.MessageBoxButtons.YesNo,
        //                                                    Taxi.MessageBox.MessageBoxIcon.Warning);
        //                confirmCheckIn(msgConfirm, 2);
        //            }
        //            else
        //                doCheckIn();
        //            //if (!(ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) || ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH) || ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhDienThoai) || (ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhTongDai))))
        //            //{
        //            //    new MessageBox.MessageBox().Show(this, "Bạn không có quyền truy cập chức năng Phản Ánh.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //            //    ThongTinDangNhap.USER_ID = "";
        //            //    g_strUsername = "";
        //            //    g_strFullName = "";
        //            //    Application.Exit();
        //            //    return;
        //            //}
        //            //else
        //            //{

        //            //    // cap nhat trang thai
        //            //    if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
        //            //    {
        //            //        new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //            //        ThongTinDangNhap.USER_ID = "";
        //            //        g_strUsername = "";
        //            //        g_strFullName = "";
        //            //        Application.Exit();
        //            //        return;
        //            //    }

        //            //}
        //            // thiet lap menu disable 
        //            CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //            CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //            if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) && ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
        //            {
        //                RoleNhanVien = "All";
        //            }
        //            else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH))
        //            {
        //                RoleNhanVien = DanhSachVaiTro.NVNHANPHANANH;
        //            }
        //            else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
        //            {
        //                RoleNhanVien = DanhSachVaiTro.NVGIAIQUYETPHANANH;
        //            }
        //            //--------------------------LAYOUT-------------------------------------
        //            loadLayout(grdGiaiQuyetPA);
        //            //--------------------------LAYOUT-------------------------------------
        //        }
        //    }
        //    else
        //    {
        //        CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //        CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //        ThongTinDangNhap.USER_ID = "";
        //        g_strUsername = "";
        //        g_strFullName = "";
        //    }
        //}
        private void CheckIn()
        {
            ////using (frmCheckInOut frm = new frmCheckInOut())
            ////{
            ////    if (frm.ShowDialog() != DialogResult.OK)
            ////        return;
            ////}

            ////g_strFullName = ThongTinDangNhap.FULLNAME;
            ////g_strUsername = ThongTinDangNhap.USER_ID;
            //if (g_strUsername.Length > 0)
            //{
            //    //if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
            //    //{
            //    //    CheckIn1.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            //    //    CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            //    //    if ((ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH)) && (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH)))
            //    //    {
            //    //        RoleNhanVien = "All";
            //    //    }
            //    //    else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH))
            //    //    {
            //    //        RoleNhanVien = DanhSachVaiTro.NVNHANPHANANH;
            //    //    }
            //    //    else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
            //    //    {
            //    //        RoleNhanVien = DanhSachVaiTro.NVGIAIQUYETPHANANH;
            //    //    }

            //    //    //--------------------------LAYOUT-------------------------------------
            //    //    loadLayout(grdGiaiQuyetPA);
            //    //    //--------------------------LAYOUT-------------------------------------

            //    //}
            //    //else
            //    //{
            //        // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
            //        //if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
            //        //{
            //        //    new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống.Cần checkout hoặc đăng xuất cưỡng chế.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //        //    Application.Exit();
            //        //    return;
            //        //}
            //        // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
            //        //if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
            //        //{
            //        //    new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //        //    ThongTinDangNhap.USER_ID = "";
            //        //    g_strUsername = "";
            //        //    g_strFullName = "";
            //        //    Application.Exit();
            //        //    return;
            //        //}
            //        if (!(ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) || ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH) || ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhDienThoai) || (ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhTongDai))))
            //        {
            //            new MessageBox.MessageBox().Show(this, "Bạn không có quyền truy cập chức năng Phản Ánh.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

            //            ThongTinDangNhap.USER_ID = "";
            //            g_strUsername = "";
            //            g_strFullName = "";
            //            Application.Exit();
            //            return;
            //        }
            //        else
            //        {

            //            // cap nhat trang thai
            //            if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
            //            {
            //                new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //                ThongTinDangNhap.USER_ID = "";
            //                g_strUsername = "";
            //                g_strFullName = "";
            //                Application.Exit();
            //                return;
            //            }

            //        }
            //        // thiet lap menu disable 
            //        CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            //        CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            //        if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) && ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
            //        {
            //            RoleNhanVien = "All";
            //        }
            //        else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH))
            //        {
            //            RoleNhanVien = DanhSachVaiTro.NVNHANPHANANH;
            //        }
            //        else if (ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH))
            //        {
            //            RoleNhanVien = DanhSachVaiTro.NVGIAIQUYETPHANANH;
            //        }
            //        //--------------------------LAYOUT-------------------------------------
            //        loadLayout(grdGiaiQuyetPA);
            //        //--------------------------LAYOUT-------------------------------------
            //    //}
            //}
            //else
            //{
            //    CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            //    CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            //    ThongTinDangNhap.USER_ID = "";
            //    g_strUsername = "";
            //    g_strFullName = "";
            //}
        }

        /// <summary>
        /// Confirm có tiếp tục check in hay không. nếu có sẽ check out toàn bộ các account đã check in trên máy.
        /// </summary>
        /// <param name="msgConfirm"></param>
        /// <param name="Type">
        /// 1 : có người đăng nhập trên máy này rồi
        /// 2 : account này đã đăng nhập ở 1 máy tính khác</param>
        private void confirmCheckIn(string msgConfirm, int Type)
        {
            //if (msgConfirm == "Yes")
            //{
            //    //check out ở máy tính khác trước
            //    if (Type == 2 && ThongTinDangNhap.CheckOut_AllIn_OtherIP(g_strUsername, g_IPAddress))
            //    {
            //        doCheckIn();
            //    }
            //    // check out account khác đã checkin trên máy tính này trước.
            //    else if (Type == 1 && ThongTinDangNhap.CheckOut_AllInIP(g_strUsername, g_IPAddress))
            //    {
            //        doCheckIn();
            //    }
            //    else
            //    {
            //        new MessageBox.MessageBox().Show(this,
            //        "Có lỗi checkin hệ thống. Vui lòng thử lại.",
            //                                        "Thông báo lỗi",
            //                                        Taxi.MessageBox.MessageBoxButtons.OK,
            //                                        Taxi.MessageBox.MessageBoxIcon.Error);
            //        ThongTinDangNhap.USER_ID = "";
            //        g_strUsername = "";
            //        g_strFullName = "";
            //        Application.Exit();
            //        return;
            //    }
            //}
            //else
            //{
            //    ThongTinDangNhap.USER_ID = "";
            //    g_strUsername = "";
            //    g_strFullName = "";
            //    Application.Exit();
            //    return;
            //}
        }


        private void doCheckIn()
        {
            //// cap nhat trang thai
            //if (!ThongTinDangNhap.CheckIn(g_strUsername, g_IPAddress))
            //{
            //    new MessageBox.MessageBox().Show(this, "Có lỗi checkin hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            //    ThongTinDangNhap.USER_ID = "";
            //    g_strUsername = "";
            //    g_strFullName = "";
            //    Application.Exit();
            //    return;
            //}
            //else
            //{
            //    if (!(ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVNHANPHANANH) || ThongTinDangNhap.IsInRole(DanhSachVaiTro.NVGIAIQUYETPHANANH) || ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhDienThoai) || (ThongTinDangNhap.HasPermission(DanhSachQuyen.DieuHanhTongDai))))
            //    {
            //        new MessageBox.MessageBox().Show(this, "Bạn không có quyền truy cập chức năng Phản Ánh.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

            //        ThongTinDangNhap.USER_ID = "";
            //        g_strUsername = "";
            //        g_strFullName = "";
            //        Application.Exit();
            //        return;
            //    }
            //}
        }

        private void checkout()
        {
            // check co dung may cua user dang ngồi không.
            if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // ngôi đúng vị trí checkout
            {
                if (ThongTinDangNhap.CheckOut(g_strUsername, g_IPAddress))
                {
                    new MessageBox.MessageBoxBA().Show(this, "CheckOut thành công, bạn cần bảo người đổi ca checkin luôn.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    CheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    CheckIn2.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    //statusBar.Panels["TenDangNhap"].Text = "NV: ";
                    ThongTinDangNhap.USER_ID = "";
                    CheckIn();
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(this, "Lỗi CheckOut bạn cần thực hiện lại, hoặc liên lạc với quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                }
            }
            else
                new MessageBox.MessageBoxBA().Show(this, "Bạn ngồi không đúng vị trí cần ngồi đúng máy bạn đã khai báo vào hệ thống (checkin).", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            // nếu đúng thì cập nhật thời gian checkout.
        }
        #endregion
        
        #region ======================Form Status======================================

        private void HienThiTrangThaiChu(GridEXRow row)
        {
            if (((PhanAnh)row.DataRow).TGPA != DateTime.MinValue)
                return;

            row.Cells["TGPA"].Text = string.Empty;
            //else if (objPhanAnh.GQ_TGGQ == DateTime.MinValue)
            //{
            //    row.Cells["NgayGiaiQuyet"].Text = string.Empty;
            //}
        }

        public void NhapDuLieuVaoTruyenDi(int iRowPosition)
        {
            grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                PhanAnh objThongTinPA = (PhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau                 
                using (frmGhiNhanPhanAnh frmPAInPut = new frmGhiNhanPhanAnh(objThongTinPA, RoleNhanVien))
                {
                    DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                    }
                    else
                        if (_dialogResult == DialogResult.OK)
                            LoadPhanAnh_ChuaGiaiQuyet(frmPAInPut.chkDaGiaiQuyet.Checked ? 0 : rowSelect.Position);
                        else
                            LoadPhanAnh_ChuaGiaiQuyet(rowSelect.Position);
                }

                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;

            }

        }

        public void XemLaiDuLieuPA(int iRowPosition)
        {
            grdDaGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDaGiaiQuyetPA.SelectedItems.Count > 0)
            {
                PhanAnh objThongTinPA = (PhanAnh)((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                //Thu doi mau
                GridEXRow rowSelect = ((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).GetRow();
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Highlight;
                rowSelect.RowStyle = RowStyle;

                //End - Thu doi mau
                //true : da giai quyet
                using (frmGhiNhanPhanAnh frmPAInPut = new frmGhiNhanPhanAnh(objThongTinPA, RoleNhanVien, true))
                {
                    DialogResult _dialogResult = frmPAInPut.ShowDialog(this);
                    if (_dialogResult == DialogResult.Yes)
                    {
                        LoadPhanAnh_DaGiaiQuyet(rowSelect.Position);
                    }
                }
                //tra ve mau cu
                RowStyle = new GridEXFormatStyle();
                RowStyle.BackColor = System.Drawing.SystemColors.Window;
                rowSelect.RowStyle = RowStyle;
            }
        }

        /// <summary>
        /// Nếu có cuộc gọi mới đến line Phản Anh thì chuyển thông tin cuộc gọi sang bảng thông tin phản ánh
        /// </summary>
        private void GetNewCuocGoi(int Position)
        {           
            try
            {
                List<PhanAnh> lstThongTinPA = new PhanAnh().GetPhanAnh_By_CuocGoi(ThongTinDangNhap.USER_ID,g_LinesDuocCapPhep);
                if (lstThongTinPA == null)
                    return;

                grdGiaiQuyetPA.DataMember = "lstThongTinPA";
                grdGiaiQuyetPA.SetDataBinding(lstThongTinPA, "lstThongTinPA");

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
            catch (Exception ext)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi không nhận được cuộc gọi mới. Vui lòng thông báo với ban quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }          
        #endregion

        #region =========================Grid Event====================================

        private void grdGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (grdGiaiQuyetPA.SelectedItems.Count <= 0)
                return; 
           
            NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);

        }

        private void grdGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (g_strUsername.Length <= 0)
            {
                CheckIn();
                return;
            }
            if (e.KeyCode == Keys.Enter && grdGiaiQuyetPA.SelectedItems.Count > 0)
            {
                NhapDuLieuVaoTruyenDi(((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).Position);
            }
            else if (e.KeyCode == Keys.Space)
            {
                
                grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdGiaiQuyetPA.SelectedItems.Count > 0)
                {
                    PhanAnh phanAnh = (PhanAnh)((GridEXSelectedItem)grdGiaiQuyetPA.SelectedItems[0]).GetRow().DataRow;
                    HienThiFormGoiDienThoai(DieuHanhTaxi.GetSoDienThoai(ThongTinCauHinh.SoDauCuaTongDai, phanAnh.SoDT), phanAnh.DiaChi);
                }
            }

        }

        private void grdDaGiaiQuyetPA_DoubleClick(object sender, EventArgs e)
        {
            if (grdDaGiaiQuyetPA.SelectedItems.Count <= 0)
                return;

            if (g_strUsername.Length <= 0)
            {
                CheckIn();
                return;
            }
            XemLaiDuLieuPA(((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).Position);
        }

        private void grdDaGiaiQuyetPA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (grdDaGiaiQuyetPA.SelectedItems.Count <= 0)
                return;

            if (g_strUsername.Length <= 0)
            {
                CheckIn();
                return;
            }
            XemLaiDuLieuPA(((GridEXSelectedItem)grdDaGiaiQuyetPA.SelectedItems[0]).Position);
        }

        private void grdGiaiQuyetPA_FormattingRow(object sender, RowLoadEventArgs e)
        {
            HienThiTrangThaiChu(e.Row);
        }

      

        private void mnuRigthDaGiaiQuyet_CommandClick_1(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {

            if (grdDaGiaiQuyetPA.SelectedItems.Count <= 0) return;

            grdDaGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            PhanAnh phanAnh = (PhanAnh)grdDaGiaiQuyetPA.SelectedItems[0].GetRow().DataRow;
            if (e.Command.Key == "cmdXoaPhanAnhDaGiaiQuyet")
            {
                if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa phản ánh này?", "Xóa phản ánh", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    if (!(new PhanAnh().Delete(phanAnh.IdPA)))
                        new MessageBox.MessageBoxBA().Show("Cập nhật không thành công", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    else
                        LoadPhanAnh_DaGiaiQuyet(0);
                }
            }
        }

        private void mnuPhanAnhDangGiaiQuyet_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            if (grdGiaiQuyetPA.SelectedItems.Count > 0)
            {

                grdGiaiQuyetPA.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                PhanAnh phanAnh = (PhanAnh)grdGiaiQuyetPA.SelectedItems[0].GetRow().DataRow;
                if (e.Command.Key == "cmdKetThucPhanAnh")
                {

                    if (!(new PhanAnh().UpdatePhanAnh_Status(ThongTinDangNhap.USER_ID, phanAnh.IdPA)))
                        new MessageBox.MessageBoxBA().Show("Cập nhật không thành công", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                    else
                        LoadPhanAnh_ChuaGiaiQuyet(0);

                }
                else if (e.Command.Key == "cmdXoaPhanAnhDangGiaiQuyet")
                {
                    if (new MessageBox.MessageBoxBA().Show("Bạn có đồng ý xóa phản ánh này?", "Xóa phản ánh", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                    {
                        if (!(new PhanAnh().Delete(phanAnh.IdPA)))
                            new MessageBox.MessageBoxBA().Show("Cập nhật không thành công", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        else
                            LoadPhanAnh_ChuaGiaiQuyet(0);
                    }
                }
            }
        } 


        #endregion

        #region ==========================Key Event====================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                    checkout();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int iRowSelect = -1;
            switch (keyData)
            {
                case (Keys.Alt | Keys.D1):
                    iRowSelect = 0;
                    break;
                case (Keys.Alt | Keys.D2):
                    iRowSelect = 1;
                    break;
                case (Keys.Alt | Keys.D3):
                    iRowSelect = 2;
                    break;
                case (Keys.Alt | Keys.D4):
                    iRowSelect = 3;
                    break;
                case (Keys.Alt | Keys.D5):
                    iRowSelect = 4;
                    break;
                case (Keys.Alt | Keys.D6):
                    iRowSelect = 5;
                    break;
                case (Keys.Alt | Keys.D7):
                    iRowSelect = 6;
                    break;
                case (Keys.Alt | Keys.D8):
                    iRowSelect = 7;
                    break;
                case (Keys.Alt | Keys.D9):
                    iRowSelect = 8;
                    break;
                case (Keys.Alt | Keys.D0):
                    iRowSelect = 9;
                    break;
                case (Keys.Shift | Keys.D1):
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 0;
                    break;
                case (Keys.Shift | Keys.D2):
                    if (uiTabCuocGoiDangThucHien.SelectedIndex != 1)
                        uiTabCuocGoiDangThucHien.SelectedIndex = 1;
                    break;
            }

            if (iRowSelect >= 0)
            {
                if (uiTabCuocGoiDangThucHien.SelectedIndex != 0)
                    return true;

                if (grdGiaiQuyetPA.RowCount <= iRowSelect)
                    return true;

                grdGiaiQuyetPA.Row = iRowSelect;
                if (g_strUsername.Length <= 0)
                    CheckIn();
                else
                    NhapDuLieuVaoTruyenDi(iRowSelect);
                return true;
            }

            //switch (keyData)
            //{
            //    case Keys.F10:
            //        using (TraCuuTheMCC traCuuTheMCC = new TraCuuTheMCC())
            //        {
            //            traCuuTheMCC.ShowDialog();
            //        }
            //        return true;
            //    case Keys.F11:
            //        using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai())
            //        {
            //            thongTinSanBay_DuongDai.ShowDialog();
            //        }
            //        return true;
            //}
            return false;
        }

        #endregion

        #region ========================Menu Event=====================================

        private void MainMenu_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "DoiMatKhau":
                    using (CapNhatThongTinCaNhan capNhatThongTinCaNhan = new CapNhatThongTinCaNhan())
                    {
                        capNhatThongTinCaNhan.ShowDialog();
                    }
                    break;
                case "CheckIn":
                    CheckIn();
                    break;
                case "CheckOut":
                    checkout();
                    break;
                case "cmdTaoPhanAnh":
                    using (frmGhiNhanPhanAnh frmChenCuocGoi = new frmGhiNhanPhanAnh(RoleNhanVien))
                    {
                        DialogResult dialogResult = frmChenCuocGoi.ShowDialog(this);
                        if (dialogResult == DialogResult.OK)
                        {
                            LoadPhanAnh_ChuaGiaiQuyet(grdGiaiQuyetPA.Row);
                            new Taxi.MessageBox.MessageBoxBA().Show("Chèn thêm cuộc gọi thành công");
                            frmChenCuocGoi.Close();
                        }
                    }
                    break;
                case "cmdBCTongHop":
                    using (frmBC_3_1_TongHopPhanAnh frmBC_3_1_TongHopPhanAnh = new frmBC_3_1_TongHopPhanAnh())
                    {
                        frmBC_3_1_TongHopPhanAnh.ShowDialog();
                    }
                    break;
                case "cmdBCGiaiQuyet":
                    using (frmBC_3_2_GiaiQuyetPhanAnh frmBC_3_2_GiaiQuyetPhanAnh = new frmBC_3_2_GiaiQuyetPhanAnh())
                    {
                        frmBC_3_2_GiaiQuyetPhanAnh.ShowDialog();
                    }
                    break;
                case "cmdBCKhachQuen":
                    using (frmBaoCaoKhachQuen frmBaoCaoKhachQuen = new frmBaoCaoKhachQuen())
                    {
                        frmBaoCaoKhachQuen.ShowDialog();
                    }
                    break;
                case "cmdBCKhachQuenTheoThang":
                    using (frmBaoCaoKhachQuenTheoThang frm = new frmBaoCaoKhachQuenTheoThang())
                    {
                        frm.ShowDialog();
                    }
                    break;
                case "cmdChotCo":
                    using (frmDMKhachQuen frmKhachQuen = new frmDMKhachQuen())
                    {
                        frmKhachQuen.ShowDialog();
                    }
                    break;
                case "cmdTraCuuTheMCC":
                    //using (TraCuuTheMCC traCuuTheMCC = new TraCuuTheMCC())
                    //{
                    //    traCuuTheMCC.ShowDialog();
                    //}
                    break;
                case "cmdQuanLyTinNhan":
                    //using (Messenger messenger = new Messenger())
                    //{
                    //    messenger.ShowDialog();
                    //}
                    break;
                case "cmdLuuCauHinhHienThi":
                    //if (gridLayout != null)
                    //{
                    //    switch (uiTabCuocGoiDangThucHien.SelectedTab.Name)
                    //    {
                    //        case "tbCuocGoiDangGiaiQuyet":
                    //            gridLayout.setLayout(grdGiaiQuyetPA.GetLayout().LayoutString);
                    //            grdGiaiQuyetPA.LoadLayout(gridLayout.getLayout(grdGiaiQuyetPA.GetLayout()));
                    //            break;
                    //        case "tbCuocGoiDaGiaiQuyet":
                    //            gridLayout.setLayout(grdDaGiaiQuyetPA.GetLayout().LayoutString);
                    //            grdDaGiaiQuyetPA.LoadLayout(gridLayout.getLayout(grdDaGiaiQuyetPA.GetLayout()));
                    //            break;
                    //    }
                    //}
                    break;
                case "cmdMacDinh":
                    //if (gridLayout != null)
                    //{
                    //    ComponentResourceManager resources = new ComponentResourceManager(typeof(frmThongTinKhachHangPhanAnh));
                    //    switch (uiTabCuocGoiDangThucHien.SelectedTab.Name)
                    //    {
                    //        case "tbCuocGoiDangGiaiQuyet":                                
                    //            gridLayout.setLayout(resources.GetString("gridEXLayout1.LayoutString"));
                    //            grdGiaiQuyetPA.LoadLayout(gridLayout.getLayout(grdGiaiQuyetPA.GetLayout()));
                    //            break;
                    //        case "tbCuocGoiDaGiaiQuyet":
                    //            gridLayout.setLayout(resources.GetString("gridEXLayout2.LayoutString"));
                    //            grdDaGiaiQuyetPA.LoadLayout(gridLayout.getLayout(grdDaGiaiQuyetPA.GetLayout()));
                    //            break;
                    //    }
                    //}
                    break;
                case "cmdDMXe":
                    //using (frmDSXe frmDSXe = new frmDSXe())
                    //{
                    //    frmDSXe.ShowDialog();
                    //}
                     break;
                case "cmdDMLaiXe":
                    //using (frmDSNhanVien frmDSNhanVien = new frmDSNhanVien())
                    //{
                    //    frmDSNhanVien.ShowDialog();
                    //}
                    break;
            }
           //endregion----------------------------------------------------------------------------------
        }

        private void ToolBar_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            switch (e.Command.Key)
            {
                case "cmdThemMoi":
                    using (frmGhiNhanPhanAnh frmChenCuocGoi = new frmGhiNhanPhanAnh(RoleNhanVien))
                    {
                        DialogResult dialogResult = frmChenCuocGoi.ShowDialog(this);
                        if (dialogResult == DialogResult.OK)
                        {
                            LoadPhanAnh_ChuaGiaiQuyet(grdGiaiQuyetPA.Row);
                            new Taxi.MessageBox.MessageBoxBA().Show("Chèn thêm cuộc gọi thành công");
                            frmChenCuocGoi.Close();
                        }
                    }
                    break;
                case "cmdTinhTien":
                    using (frmTinhTienTheoKm frmTinhTienTheoKm = new frmTinhTienTheoKm())
                    {
                        frmTinhTienTheoKm.ShowDialog();
                    }
                    break;
                case "cmdTongDai1080":
                    using (frmDMDiaDanh frmDMDiaDanh = new frmDMDiaDanh())
                    {
                        frmDMDiaDanh.ShowDialog();
                    }
                    break;
                case "cmdVeHuy":
                    //new frmTraCuu().ShowDialog();
                    break;
                case "cmdCheckCo":
                    //using (ThongTinSanBay_DuongDai thongTinSanBay_DuongDai = new ThongTinSanBay_DuongDai(G_arrProvince, G_arrDistrict, G_arrCommune, ""))
                    //{
                    //    thongTinSanBay_DuongDai.ShowDialog();
                    //}
                    break;
                case "cmdTraCuuTheMCC":
                    //using (TraCuuTheMCC traCuuTheMCC = new TraCuuTheMCC())
                    //{
                    //    traCuuTheMCC.ShowDialog();
                    //}
                    break;
                case "cmdTimKiemCuocGoi":
                    //new Taxi.GUI.TimKiemCuocGoi(DieuHanhTaxi.GetTimeServer(), g_LinesDuocCapPhep, 1, "KIA").Show();
                   break;
            }
        }
                
        #endregion

        #region ========================Form Event=====================================
        private void BaoCuocGoiMoi_Tick(object sender, EventArgs e)
        {
            //GetNewCuocGoi(grdGiaiQuyetPA.Row);
        }

        private void uiTabCuocGoiDangThucHien_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            if (tbCuocGoiDaGiaiQuyet.Selected)
            {
                LoadPhanAnh_DaGiaiQuyet(0);
                grdDaGiaiQuyetPA.Focus();
                //--------------------------LAYOUT-------------------------------------
                loadLayout(grdDaGiaiQuyetPA);
                //--------------------------LAYOUT-------------------------------------
                return;
            }
            else if (tbCuocGoiDangGiaiQuyet.Selected)
            {
                grdGiaiQuyetPA.Focus();
                //--------------------------LAYOUT-------------------------------------
                loadLayout(grdGiaiQuyetPA);
                //--------------------------LAYOUT-------------------------------------
            }
            else if (tabThueBaoTuyen.Selected)
            {
                LoadDSThueBao(1,grdNhanVien);
                // LoadDSCuoc(grdCuocSanBayDuongDai.Row);
            }
            else if(tabThueBaoTuyenDaGoi.Selected )
            {
                LoadDSThueBao(2,gridThueBaoDaGoi); 
            }
            else if (tabGoiKHThanThiet.Selected)
            {
                GetDSKhachThanThiet(dateThang.Value);
            }
        }

        /// <summary>
        /// load ds sách các thuê bao tuyến kết thúc
        /// </summary>
        /// <param name="dieuKien">1 : load chưa ket thuc cskh, 2: chi co cuoc ket thuc, 3: tat cả</param>
        private void LoadDSThueBao(int dieuKien , GridEX grid)
        {
            NhatkyThuebao NhatkyThuebaoControl = new NhatkyThuebao();
            DataTable dt;
             
            string sql = "";
            // chi lọc các cuốc chưa kết thúc của cskh
            if (dieuKien == 1)
            {
                
                sql += " SELECT  * FROM [TRUNGKIEN.T_NHATKYTHUEBAO]  WHERE (CSKH_KetThuc IS NULL) OR (CSKH_KetThuc = 0)   order by   [ThoiDiem] desc ";
                dt =  NhatkyThuebao.GetBCNhatKyThueBao(sql);
             
            }
            else if (dieuKien == 2) // cuoc da ket thuc
            {
                sql += " SELECT  * FROM [TRUNGKIEN.T_NHATKYTHUEBAO]  WHERE   CSKH_KetThuc = 1    order by   [ThoiDiem] desc ";
                dt =  NhatkyThuebao.GetBCNhatKyThueBao(sql);
            }
            else
            {
                dt   = NhatkyThuebaoControl.GetAll();
                 
            }

            grid.DataMember = "lID";
            grid.SetDataBinding(dt, "lID");
            grid.Refresh();
            
        }

        #endregion

        #region ====================Timer nhận cuộc gọi mới(Update)====================
        private Timer TimerCapturePhone;

        /// <summary>
        /// Lay time tu file cau hinh
        /// </summary>
        private void InitTimerCapturePhone()
        {
            int TimerLength = Configuration.GetTimerCapturePhone();

            TimerCapturePhone = new Timer();
            TimerCapturePhone.Interval = TimerLength;
            TimerCapturePhone.Tick += TimerCapturePhone_Tick;
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
                bool hasCuocGoiMoi = false;
                bool hasCuocGoiThayDoi = false;
                g_TimeServer = g_TimeServer.AddSeconds(1);
                
                GetNewCuocGoi(grdGiaiQuyetPA.Row);
               
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Lỗi Timer không nhận được cuộc gọi mới. Vui lòng thông báo với ban quản trị", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
            }
        }

        private void HienThiTrenLuoi(bool hasCuocGoiMoi, bool hasThayDoiThongTin)
        {
            
        }
        
        
        #endregion

        #region Nhap thong tin cskh thue bao tuyen

        private void grdNhanVien_FormattingRow(object sender, RowLoadEventArgs e)
        {
            GridEXRow row = e.Row;
            string text = row.Cells["CSKH_TrangThaiGoi"].Text;
            if (text.Length <= 0) return;
            else
            {
                //Gọi thành công
                //Gọi không nghe máy
                //Không liên lạc được
                //Khác
                GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                if (text == "1")
                { 
                    RowStyle.BackColor = Color.Cyan; 
                }
                else if (text == "2" || text == "3")
                { 
                    RowStyle.BackColor = Color.Yellow; 
                }
                else if (text == "9")
                {
                    RowStyle.BackColor = Color.Violet ; 
                }
                
                 row.Cells["CSKH_TrangThaiGoi"].FormatStyle = RowStyle;
            }
        }

        private void grdNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyData == Keys.Space)
            {
                // lấy dữ liệu dòng đang chọn
                grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
                if (grdNhanVien.SelectedItems.Count > 0)
                {
                    DataRowView dr = (DataRowView)(((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow().DataRow);
                    if (dr["SoDienThoai"] == null) return;
                    string soDienThoai =  dr["SoDienThoai"].ToString();
                    string tuyenDuong = dr["TenTuyenDuong"].ToString();
                    int id = Convert.ToInt32(dr["ID"].ToString());
                     
                    if( soDienThoai.Length >=8 ) // so dien thoai chuan
                        HienThiFormGoiDienThoai( DieuHanhTaxi.GetSoDienThoai(ThongTinCauHinh.SoDauCuaTongDai,  soDienThoai), tuyenDuong);

                    frmNhapCSKHNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapCSKHNhatKyThueBao(id, true);
                    frmNhapNhatKyThueBaocontrol.ShowDialog();
                    this.LoadDSThueBao(1, grdNhanVien);
                } 
            }
        }

        private void grdNhanVien_DoubleClick(object sender, EventArgs e)
        {
            grdNhanVien.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdNhanVien.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)grdNhanVien.SelectedItems[0]).GetRow();
                
                int ID = int.Parse(row.Cells["ID"].Value.ToString()); 
                frmNhapCSKHNhatKyThueBao frmNhapNhatKyThueBaocontrol = new frmNhapCSKHNhatKyThueBao(ID, true);
                frmNhapNhatKyThueBaocontrol.ShowDialog();
                this.LoadDSThueBao(1,grdNhanVien);
                 
            }
        }

#endregion

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
                    string Call = String.Format("ATDT{0}{1}{2}", Taxi.Business.Configuration.GetSoDienThoaiGoiNhanh(SoDienThoai), Convert.ToChar(13), Convert.ToChar(11));
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
            else
            {
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                msg.Show("Không kết nối được bộ gọi số tự động.");
            }
        }
        #endregion COM PORT 

        private void gridKhachAo_DoubleClick(object sender, EventArgs e)
        {
            // lấy thông tin khách quen theo dòng.
            gridKhachThanThiet.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachThanThiet.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachThanThiet.SelectedItems[0]).GetRow();

                string maKH=  row.Cells["MaKH"].Value.ToString() ;
                string tenKH = row.Cells["Name"].Value.ToString();
                string diaChi = row.Cells["Address"].Value.ToString();
                string soDienThoai = row.Cells["Phones"].Value.ToString();

                using (frmNhapThongTinGoiKhachThanThiet frm = new frmNhapThongTinGoiKhachThanThiet(maKH, tenKH + " - " + diaChi, soDienThoai))
                {
                    frm.ShowDialog();
                }


                GetDSKhachThanThiet(dateThang.Value);

            }
        }

        /// <summary>
        /// hàm thực hiện set độ rộng của lưới, căn cứ vào độ rộng của màn hình
        /// 
        /// </summary>
        private void SetWidthGridKhachHangThanThiet()
        {
            gridKhachThanThiet.Width = this.Width - 20;
        }

        /// <summary>
        /// hàm thực hiện lấy ds khách hàng thân thiết đã gọi trong tháng
        /// </summary>
        /// <param name="dateTime"></param>
        private void GetDSKhachThanThiet(DateTime dateTime)
        {
            DateTime denNgay;
            DateTime tuNgay = new DateTime (dateTime.Year,dateTime.Month,01,0,0,0);
            if(dateTime.Month == 12)
                denNgay = new DateTime (dateTime.Year+1,1,01,0,0,0); 
            else 
                denNgay = new DateTime (dateTime.Year,dateTime.Month+1,01,0,0,0);

            List<DanhBaKhachQuenEx> list = DanhBaKhachQuen.GetKhachQuens(tuNgay, denNgay);

            SetWidthGridKhachHangThanThiet();

            gridKhachThanThiet.DataMember = "lID";
            gridKhachThanThiet.SetDataBinding(list, "lID");
            gridKhachThanThiet.Refresh();

            gridKhachThanThietExPort.DataMember = "lID";
            gridKhachThanThietExPort.SetDataBinding(list, "lID");
            gridKhachThanThietExPort.Refresh();
        }
        //lấy thoogn tin cua thang đã chọn
        private void button1_Click(object sender, EventArgs e)
        {
            GetDSKhachThanThiet(dateThang.Value);
        }
        // lấy thông tin xuất ra excel
        private void button2_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "GoiKhachHangThanThiet.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                 
            }
             
        }

        private void gridKhachThanThiet_FormattingRow(object sender, RowLoadEventArgs e)
        {
            DanhBaKhachQuenEx kq = (DanhBaKhachQuenEx)e.Row.DataRow;

            if (kq == null) return;
            if (kq.ThoiDiemGoiGanDay ==   new DateTime(2000,1,1,0,0,0) )
            {
                e.Row.Cells["ThoiDiemGoiGanDay"].Text = "";
            }

            if (kq.TrangThaiGoi == 0)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "";
            }
            else  if (kq.TrangThaiGoi == 1)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Gọi thành công";
            }
            else  if (kq.TrangThaiGoi ==2)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Gọi không nghe máy";
            }
            else  if (kq.TrangThaiGoi ==3)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Không liên lạc được";
            }
                else  if (kq.TrangThaiGoi ==9)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Khác";
            } 
        }

        private void gridKhachThanThietExPort_FormattingRow(object sender, RowLoadEventArgs e)
        {
            DanhBaKhachQuenEx kq = (DanhBaKhachQuenEx)e.Row.DataRow;

            if (kq == null) return;
            if (kq.ThoiDiemGoiGanDay == new DateTime(2000,1,1,0,0,0) )
            {
                e.Row.Cells["ThoiDiemGoiGanDay"].Text = "";
            }
            if (kq.TrangThaiGoi == 0)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "";
            }
            else if (kq.TrangThaiGoi == 1)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Gọi thành công";
            }
            else if (kq.TrangThaiGoi == 2)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Gọi không nghe máy";
            }
            else if (kq.TrangThaiGoi == 3)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Không liên lạc được";
            }
            else if (kq.TrangThaiGoi == 9)
            {
                e.Row.Cells["TrangThaiGoi"].Text = "Khác";
            } 
        }
    }
}
