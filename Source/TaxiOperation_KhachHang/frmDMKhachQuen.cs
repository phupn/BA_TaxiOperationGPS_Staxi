using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;
using Taxi.Utils;
using Taxi.GUI.BaoCao;

namespace Taxi.GUI
{
    public partial class frmDMKhachQuen : Form
    {
        #region ==========================Init=================================
        private List<DanhBaKhachQuen_Type> G_lstKhachQuen_Type;
        private List<DanhBaKhachQuen_Rank> G_lstKhachQuen_Rank;
        private string g_strUsername = "";
        private string g_strFullName = "";
        #endregion

        #region =======================Constructor=============================
        public frmDMKhachQuen()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDMKhachAo_Load);
        }
        #endregion

        #region ========================Load Form==============================
        void frmDMKhachAo_Load(object sender, EventArgs e)
        {
            
                if (DieuHanhTaxi.CheckConnection())
                {
                   
                    // Lay thong tin he thong
                        ThongTinCauHinh.LayThongTinCauHinh();
                        LoadListKhachQuen();
                    //CheckIn();
                        LoadListKhachQuen_Type();
                    LoadListKhachQuen_Rank();
                }
           
            
        }

        //private void CheckIn()
        //{
        //    frmCheckInOut frm = new frmCheckInOut();
        //    frm.ShowDialog();
        //    g_strUsername = ThongTinDangNhap.USER_ID;
        //    g_strFullName = ThongTinDangNhap.FULLNAME;
        //    if (g_strUsername.Length > 0)
        //    {
        //        if (ThongTinDangNhap.IsUserPostionTrust(g_strUsername, g_IPAddress)) // trươc đây đã checkin, nhưng do hệ thống mất điện nên checkin lại
        //        {
        //            cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //            cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;

        //            //--------------------------LAYOUT-------------------------------------
        //            loadLayout(gridDienThoai);
        //            //--------------------------LAYOUT-------------------------------------
        //        }
        //        else
        //        {
        //            // kiểm tra xem máy tính này trước đay đã có ai dăng nhập chưa
        //            if (ThongTinDangNhap.IsPCCheckInWithOutUser(g_strUsername, g_IPAddress))
        //            {
        //                new MessageBox.MessageBox().Show(this, "Máy tính này đã có người đăng nhập vào hệ thống", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                Application.Exit();
        //                return;
        //            }
        //            // kiểm tra xem user này trước đây đã có ai dăng nhập chưa.
        //            if (ThongTinDangNhap.IsUserCheckInAtOtherPC(g_strUsername, g_IPAddress))
        //            {
        //                new MessageBox.MessageBox().Show(this, "Bạn đã đăng nhập vào hệ thống từ một mày tính khác. Bạn cần phải trở lại máy đó để checkout ra khỏi hệ thống.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                ThongTinDangNhap.USER_ID = "";
        //                g_strUsername = "";
        //                g_strFullName = "";
        //                Application.Exit();
        //                return;

        //            }

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
        //            else
        //            {
        //                if (!((ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHHIENTHOAI) || (ThongTinDangNhap.IsInRole(DanhSachVaiTro.DIEUHANHTONGDAI)))))
        //                {
        //                    new MessageBox.MessageBox().Show(this, "Bạn không có quyền điều hành điện thoại.", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);

        //                    ThongTinDangNhap.USER_ID = "";
        //                    g_strUsername = "";
        //                    g_strFullName = "";
        //                    Application.Exit();
        //                    return;
        //                }
        //            }

        //            // thiet lap menu disable 
        //            cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //            cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.True;

        //            //--------------------------LAYOUT-------------------------------------
        //            loadLayout(gridDienThoai);
        //            //--------------------------LAYOUT-------------------------------------
        //        }
        //        Text = String.Format("{0} - Điện thoại viên  [{1} - {2}] - {3} - {4}", Taxi.Business.Configuration.GetCompanyName(), g_LinesDuocCapPhep, g_IPAddress, ThongTinDangNhap.USER_ID, ThongTinDangNhap.FULLNAME);
        //        statusBar.Panels["TenDangNhap"].Text = string.Format("NV : {0} - {1}", g_strUsername, g_strFullName);

        //    }
        //    else
        //    {
        //        cmdCheckOut.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //        cmdLogin.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //        ThongTinDangNhap.USER_ID = "";
        //        g_strUsername = "";
        //        g_strFullName = "";
        //    }
        //}

        private void LoadListKhachQuen()
        {
            try
            {
                List<DanhBaKhachQuen> lstKhachAo = new List<DanhBaKhachQuen>();
                lstKhachAo = DanhBaKhachQuen.GetDanhSachKhachQuen();

                gridKhachAo.DataMember = "ListOfKhachHang";
                gridKhachAo.SetDataBinding(lstKhachAo, "ListOfKhachHang");
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show("LoadListKhachQuen" + ex.Message);
            }
            
        }

        private void LoadListKhachQuen_Type()
        {
            G_lstKhachQuen_Type = new List<DanhBaKhachQuen_Type>();
            G_lstKhachQuen_Type = DanhBaKhachQuen_Type.GetDanhSachKhachQuen_Type();
        }

        private void LoadListKhachQuen_Rank()
        {
            G_lstKhachQuen_Rank = new List<DanhBaKhachQuen_Rank>();
            G_lstKhachQuen_Rank = DanhBaKhachQuen_Rank.GetDanhSachKhachQuen_Rank();
        }

        #endregion

        #region =========================Get Data==============================
        
        #endregion

        #region ======================Validation Form==========================

        #endregion

        #region ========================Form Events============================
        
        /// <summary>
        /// Mo form KhachAo de edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridKhachAo_DoubleClick(object sender, EventArgs e)
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems.Count > 0 && gridKhachAo.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    frm.Dispose();
                    //Insert DataBase
                    if (!objKhachQuen.Update())
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen(); 
                    }
                }
                else return;
            }
        }
        #endregion

        #region ========================Grid Events============================
        #endregion

        #region =======================Method Process==========================

        private void ThemKhachQuen()
        {
            DanhBaKhachQuen objKhachQuen = new DanhBaKhachQuen();
            frmKhachQuen frm = new frmKhachQuen(objKhachQuen, true, G_lstKhachQuen_Type,G_lstKhachQuen_Rank);// them moi
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    //Insert DataBase
                    if (!objKhachQuen.Insert())
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                        
                    }

                }
                  
        }

        private void SuaKhachQuen()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems != null && gridKhachAo.SelectedItems.Count > 0 && gridKhachAo.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                frmKhachQuen frm = new frmKhachQuen(objKhachQuen, false,G_lstKhachQuen_Type,G_lstKhachQuen_Rank);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    objKhachQuen = frm.GetKhachQuen();
                    if (StringTools.TrimSpace(objKhachQuen.Name).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachQuen.Address).Length <= 0) return;

                    if (StringTools.TrimSpace(objKhachQuen.Phones).Length < 8) return;
                    //Insert DataBase
                    if (!objKhachQuen.Update())
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                        
                    }                
                
                }
            }
        }

        private void XoaKhachQuen()
        {
            gridKhachAo.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridKhachAo.SelectedItems != null && gridKhachAo.SelectedItems.Count > 0 && gridKhachAo.SelectedItems[0].RowType == RowType.Record)
            {
                GridEXRow row = ((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow();
                DanhBaKhachQuen objKhachQuen = (DanhBaKhachQuen)((GridEXSelectedItem)gridKhachAo.SelectedItems[0]).GetRow().DataRow;
                MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();

                if (msg.Show(this, "Bạn có xóa khách quen " + objKhachQuen.Name + " không ?", "Xóa khách quen", Taxi.MessageBox.MessageBoxButtons.OKCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.OK.ToString())
                {
                    if (!objKhachQuen.Delete(objKhachQuen.Phones ))
                    {
                        new MessageBox.MessageBox().Show("Lỗi thêm mới khách quen");
                        return;
                    }
                    else
                    {
                        //Load lai grid
                        LoadListKhachQuen();
                    }
                }

            }
        }
        #endregion

        private void gridKhachAo_FormattingRow(object sender, RowLoadEventArgs e)
        {
            
        }

        #region Report
        private void mnu_BC_1_1_DSKhachHangVIP_Click(object sender, EventArgs e)
        {
            new frmBC_DanhSachKH(G_lstKhachQuen_Type).Show();
        }

        private void mnuBC_1_2_TichLuyDiemKH_Click(object sender, EventArgs e)
        {

        }
        
        #endregion

        private void mnuThemMoi_Click(object sender, EventArgs e)
        {
            this.ThemKhachQuen();
        }

        private void mnhUpdate_Click(object sender, EventArgs e)
        {
            this.SuaKhachQuen();
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            this.XoaKhachQuen();
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            frmKhachQuenTimKiem frm = new frmKhachQuenTimKiem();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (frm.GetResultListOfKhachQuen().Count > 0)
                {
                    gridKhachAo.DataSource = null;
                    gridKhachAo.DataMember = "ListOfKhachAo";
                    gridKhachAo.SetDataBinding(frm.GetResultListOfKhachQuen(), "ListOfKhachAo");
                }
                else
                {
                    new MessageBox.MessageBox().Show("Không tìm thấy kết quả nào");
                    return;
                }
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            //if (strUser_Id.Length > 0)
            //{
            //    Application.Restart();
            //}
            //else
            //{
            //    // Nếu trong CSDL có rồi thì chỉ xuất ra form Đăng nhập 
            //    HeThong_DangNhap frmDangNhap = new HeThong_DangNhap();
            //    DialogResult dlgResult = frmDangNhap.ShowDialog();
            //    strUser_Id = ThongTinDangNhap.USER_ID;
            //}
        }

        private void mnuThayDoiTTUser_Click(object sender, EventArgs e)
        {
            new CapNhatThongTinCaNhan().ShowDialog();
        }

        private void mnuTinhTienKM_Click(object sender, EventArgs e)
        {
            using (frmTinhTienTheoKmCP frm = new frmTinhTienTheoKmCP())
            {
                frm.ShowDialog(this);
            } 
        }

        private void cmd_THPhanAnh_Click(object sender, EventArgs e)
        {
            new frmBC_3_1_TongHopPhanAnh().Show();
        }

        private void mnuBC_GQTTPhanAnh_Click(object sender, EventArgs e)
        {
            new frmBC_3_2_GiaiQuyetPhanAnh().Show();
        }

        private void mnuChiTietCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHTongHop().Show();
        }

        private void mnuTongHopCSKH_Click(object sender, EventArgs e)
        {
            new frmBaoCaoCSKHChiTiet().Show();
        }

        private void mnuBCChiTietCGDen_Click(object sender, EventArgs e)
        {
            new frmBC_1_3_ChiTietCuocGoiDen().Show();
        }

        private void mnuBCChiTietCGDi_Click(object sender, EventArgs e)
        {
            new frmBC_1_4_BCChiTietGoiDi().Show();
        }

        private void mnuBCTHKHThuongXuyen_Click(object sender, EventArgs e)
        {

        }

        private void mnuBCChiTietKHThuongXuyen_Click(object sender, EventArgs e)
        {

        }
        

    }
}