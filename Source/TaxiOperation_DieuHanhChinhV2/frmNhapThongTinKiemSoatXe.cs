using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Utils;

namespace Taxi.GUI
{
    public partial class frmNhapThongTinKiemSoatXe : Form
    {
        private List<KiemSoatXeLienLac> g_ListXeMatLienLac = new List<KiemSoatXeLienLac>(); // danh sach xe mat lien lac 
        private int g_intTrangThai = -1; //  1 :ra hoat dong, 2 : dang trong hoat dong, 3; Check mat lien lac,4 : ve
        private bool g_boolValidate = false ;
        private string mSoHieuXe = string.Empty;
        public frmNhapThongTinKiemSoatXe()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Khoi tao lop : , 1 :ra hoat dong, 2 : dang trong hoat dong, 3; Check mat lien lac,4 : ve
        /// Gan pim nong nong la ctrl+1, ctrl+2, ctrl+3, ctrl+4
        /// </summary>
        /// <param name="iTrangThai"></param>
        public frmNhapThongTinKiemSoatXe(int iTrangThai)
        {
            InitializeComponent();
            g_intTrangThai = iTrangThai;
        }
        /// <summary>
        /// click xe mat lien lac, o control
        /// </summary>
        /// <param name="iTrangThai"></param>
        /// <param name="SoHieuXe"></param>
        public frmNhapThongTinKiemSoatXe(int iTrangThai, string SoHieuXe)
        {
            InitializeComponent();
            g_intTrangThai = iTrangThai;
            mSoHieuXe = SoHieuXe;
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(mSoHieuXe);
            editTenLaiXe.Text = objKSXe.MaLaiXe;
            editSoHieuXe.Enabled = false;
            //chkTongDaiGoi.Focus();
        }
        private void frmNhapThongTinKiemSoatXe_Load(object sender, EventArgs e)
        {
            // lay danh sach xe mất liên lác.
            KhoiTaoDuLieu();
        }     
        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate du lieu nhap
            if ((rdiBaoHoatDong.Checked == false) && (rdiBaoVe.Checked == false) && (rdiBaoDonKhach.Checked == false)
                && (rdiBaoNghi.Checked == false) && (rdiBaoSuCoTaiNan.Checked == false))
            {
                new MessageBox.MessageBoxBA().Show(this, "Bạn phải chọn một loại thông báo của lái xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
            // check thong tin xe, kiem tra xem xe co trong danh sach xe hay khong
 
            // chon khac hoat dong thi phai check xe da ton tai 

            // check dang hoat dong
            if (!KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
            {
                
                if ((g_intTrangThai == 2) || (g_intTrangThai == 3) || (g_intTrangThai == 4))
                {
                    new MessageBox.MessageBoxBA().Show(this, "Xe chưa ra hoạt động, bạn cần kiểm tra lại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }                
            }
            else
            {
                if (g_intTrangThai == 1)
                {
                    new MessageBox.MessageBoxBA().Show(this, "Xe đang hoạt động, bạn không thể nhập lại trạng thái này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
                else if (g_intTrangThai == 2)
                {
                    if ((radBaoDiem.Checked == false) && (rdiBaoDonKhach.Checked == false) && (rdiBaoNghi.Checked == false) && (rdiBaoSuCoTaiNan.Checked == false))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Bạn phải chọn một trạng thái để cập nhật trạng thái xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                }
                else if (g_intTrangThai == 3) // xe mat lien lac
                {
                    // kiem tra tong dai co thay doi gi khong
                    if((radBaoDiem .Checked ==false )&&(rdiBaoDonKhach.Checked==false) && (rdiBaoNghi.Checked ==false )  && (rdiBaoVe.Checked ==false) && (chkTongDaiGoi.Checked==false ))
                    {
                         new MessageBox.MessageBoxBA().Show(this, "Bạn cần chọn [Tổng đài đã gọi] để ghi nhận bạn đã liên lạc với xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                }

            }
            if (ThongTinCauHinh.KiemTraXeDaRaHoatDong)
            {
                if (StringTools.TrimSpace(editTenLaiXe.Text).Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin lái xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
            }
            if (g_intTrangThai != 3)
            {
                if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin vị trí báo.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
            }
            if (rdiBaoDonKhach.Checked)
            {
              
                if (StringTools.TrimSpace(editViTriDen.Text).Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin vị trí đến.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
            }            
            KiemSoatXeLienLac objKSXeLL = new KiemSoatXeLienLac();
          
                objKSXeLL.SoHieuXe = editSoHieuXe.Text;
              
                objKSXeLL.ThoiDiemBao = DieuHanhTaxi.GetTimeServer();
                if (chkTongDaiGoi.Checked) { editViTriBao.Text = "Tổng đài gọi"; }  
                if (editViTriBao.Text.Length <= 0)
                {
                    new MessageBox.MessageBoxBA().Show(this, "Bạn phải nhập thông tin vị trí báo.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
                objKSXeLL.ViTriDiemBao = editViTriBao.Text;
                objKSXeLL.ViTriDiemDen = string.Empty;
                
                if (g_intTrangThai == 1)//ra hoat dong
                {
                    objKSXeLL.IsHoatDong = true;
                    objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoRaHoatDong ;
                    objKSXeLL.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachNoiTinh ;
                  
                }
                else if (g_intTrangThai == 2)//dang hoat dong
                {
                    objKSXeLL.IsHoatDong = true;
                }
                else if (g_intTrangThai == 3)// Kiem soat xe mat lien lac
                {
                    objKSXeLL.IsHoatDong = true;
                }
                else if (g_intTrangThai == 4)// ve
                {
                    objKSXeLL.IsHoatDong = false ;
                }
                if (rdiBaoDonKhach.Checked)
                {
                    objKSXeLL.ViTriDiemDen = editViTriDen.Text;
                    objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoDonDuocKhach;
                    objKSXeLL.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                    if (chkDuongDai.Checked) objKSXeLL.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachDuongDai;
                    else if(chkSanBay.Checked)objKSXeLL.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachSanBay ;
                }
                if (radBaoDiem.Checked) objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoDiemDo;
                else if (rdiBaoNghi.Checked) objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoNghi ;
                else if (rdiBaoSuCoTaiNan.Checked) objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoSuCoTaiNanCongAn;

                objKSXeLL.MaLaiXe = StringTools.TrimSpace(editTenLaiXe.Text);

                objKSXeLL.GhiChu = editGhiChu.Text;

                if (g_intTrangThai == 3) // xe mat lien lac
                {
                    // kiem tra tong dai co thay doi gi khong
                    if ((radBaoDiem.Checked == false) && (rdiBaoDonKhach.Checked == false) && (rdiBaoNghi.Checked == false) && (rdiBaoVe.Checked == false) && (chkTongDaiGoi.Checked == true))
                    {
                        objKSXeLL.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.TongDaiCheck;
                    }
                }

                if (!objKSXeLL.InsertUpdate())
                {
                    new MessageBox.MessageBoxBA().Show(this, "Không lưu được thông tin báo, cần liên lạc với quản trị để được trợ giúp.[InsertUpdate]", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }

                if ((g_intTrangThai == 1) || (g_intTrangThai == 4)) // bao hoat dong + bao ve
                {
                    if (!KiemSoatXeLienLac.InsertUpdateXeDangHoatDong(objKSXeLL.SoHieuXe, objKSXeLL.ThoiDiemBao, objKSXeLL.IsHoatDong))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Không lưu được thông tin báo, cần liên lạc với quản trị để được trợ giúp.[InsertUpdateXeDangHoatDong]", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                
        }
        /// <summary>
        /// Khoi tao du lieu dau tien cho form
        ///   - Lay time server ve, thiet lap la khoong duoc thay doi
        ///   - thiet lap option la "Ra hoat dong"
        ///   - an mot so control:
        /// </summary>
        private void KhoiTaoDuLieu()
        {
            DateTime timeServer = DieuHanhTaxi.GetTimeServer();
            if (timeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", timeServer);
                if (g_intTrangThai == 4)// ve
                {
                    rdiBaoVe.Checked = true;
                    rdiBaoHoatDong.Enabled = false;
                    grpLaiXeBao2.Enabled = false;
                    editSoHieuXe.Text = "";
                    editTenLaiXe.Enabled = false;
                    editViTriBao.Text = "Gara"; editViTriBao.Enabled = false;
                    chkTongDaiGoi.Visible = false;
                    lblMessage.Text = "Lái xe báo về";
                }
                else if (g_intTrangThai == 1)// ra hoat dong 
                {   
                   // editSoHieuXe.Focus ();
                    rdiBaoHoatDong.Checked  = true; 
                    
                    rdiBaoVe.Enabled  = false ;                    
                    grpLaiXeBao2.Enabled = false;
                    editSoHieuXe.Text = "";
                    editViTriBao.Text = "Gara";
                    editViTriBao.Enabled = false;
                   
                    chkTongDaiGoi.Visible = false;
                    lblMessage.Text = "Lái xe báo ra hoạt động";
                }
                else if (g_intTrangThai ==2)// dang hoat dong
                {
                    rdiBaoHoatDong.Checked = true; ;
                    grpLaiXeBao1 .Enabled = false;
                    grpLaiXeBao2.Enabled = true ;
                    editTenLaiXe.Enabled = false;
                    radBaoDiem.Checked = true; // khoi tao mac dinh mot cai
                    editSoHieuXe.Text = "";
                
                    chkTongDaiGoi.Visible = false;
                    lblMessage.Text = "Thông tin lái xe báo.";
                }
                else if (g_intTrangThai == 3)// check xe dang mat lien lac
                {
                    rdiBaoHoatDong.Checked = true; ;
                    grpLaiXeBao1.Enabled = false;
                    grpLaiXeBao2.Enabled = true;
                    chkTongDaiGoi.Visible = true ;
                    editTenLaiXe.Enabled = false;
                    // Lay danh sach xe mat lien lac
                    // thiet lap xe dau tien
                   
                    editSoHieuXe.Text = mSoHieuXe;
                    //...
                    lblMessage.Text = "Xe mất liên lạc";
                }
                HideBaoDonKhach(rdiBaoDonKhach.Checked);
                
            }
            else
            {
                new MessageBox.MessageBoxBA().Show(this, "Không khởi tạo được thời gian phía máy chủ.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                this.Close();
            }
        }
               

        private void editSoHieuXe_Validating(object sender, CancelEventArgs e)
        {
            //if (StringTools.TrimSpace(editSoHieuXe.Text).Length < 3)
            //{
            //    g_boolValidate = false;
            //    e.Cancel = true;
            //    errorProvider.SetError(editSoHieuXe, "Số hiệu xe có độ dài bằng 3");
            //    editTenLaiXe.Text = "";
            //}
            //else
            //{
            //    if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
            //    {
            //        g_boolValidate = false;
            //        e.Cancel = true;
            //        errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
            //        new MessageBox.MessageBox().Show(this, "Số hiệu xe này không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //        editTenLaiXe.Text = "";
            //        return;
            //    }
            //    else
            //    {
            //        if (g_intTrangThai == 1)// xe bao haot dong
            //        {
            //            if (KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
            //            {
            //                if (g_intTrangThai == 1)
            //                {
            //                    g_boolValidate = false;
            //                    e.Cancel = true;
            //                    errorProvider.SetError(editSoHieuXe, "Xe đang hoạt động. Bạn cần kiểm tra lại.");
            //                    new MessageBox.MessageBox().Show(this, "Xe đang hoạt động, bạn không thể nhập lại trạng thái này", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //                    return;
            //                }
            //            }

            //        }

            //        KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            //        objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
            //        editTenLaiXe.Text = objKSXe.MaLaiXe;

            //    }
            //    e.Cancel = false;
            //    errorProvider.SetError(editSoHieuXe, "");
            //}
        }

        private void rdiBaoDonKhach_CheckedChanged(object sender, EventArgs e)
        {
            HideBaoDonKhach(rdiBaoDonKhach.Checked);
            if (rdiBaoDonKhach .Checked)
            {
                chkTongDaiGoi.Checked = false;
            }
        }

        private void chkDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuongDai.Checked)
                chkSanBay.Checked = false;
        }

        private void chkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSanBay.Checked)
                chkDuongDai .Checked = false;
        }


        private void HideBaoDonKhach(bool boolHide)
        {
             lblViTriBaoDen.Visible = boolHide;
            editViTriDen.Visible = boolHide;
            chkDuongDai.Visible = boolHide;
            chkSanBay.Visible = boolHide;
        
        }

        private void editSoHieuXe_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void radBaoDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (radBaoDiem.Checked)
            {
                chkTongDaiGoi.Checked = false;
            }
        }

        private void rdiBaoNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdiBaoNghi .Checked)
            {
                chkTongDaiGoi.Checked = false;
            }
        }

        private void rdiBaoSuCoTaiNan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdiBaoSuCoTaiNan.Checked)
            {
                chkTongDaiGoi.Checked = false;
            }
        }

        private void chkTongDaiGoi_CheckedChanged(object sender, EventArgs e)
        {
            
            radBaoDiem.Enabled  =!chkTongDaiGoi.Checked ;
            rdiBaoDonKhach.Enabled = !chkTongDaiGoi.Checked;
            rdiBaoNghi.Enabled = !chkTongDaiGoi.Checked;
            rdiBaoSuCoTaiNan.Enabled = !chkTongDaiGoi.Checked;
            editViTriBao.Enabled = !chkTongDaiGoi.Checked;
        }

        private void editSoTheLaiXe_KeyDown(object sender, KeyEventArgs e)
        { 
        }

        private void editSoTheLaiXe_Leave(object sender, EventArgs e)
        {
            string SoThe = StringTools.TrimSpace(editSoTheLaiXe.Text);
            NhanVien objNV = NhanVien.GetNhanVienByTheLaiXe(SoThe);
            if (objNV != null)
            {
                editTenLaiXe.Text = objNV.TenNhanVien;
            }
        }

        private void editSoTheLaiXe_TextChanged(object sender, EventArgs e)
        {
            if (editSoTheLaiXe.Text.Length > 0)
            {

                string SoThe = StringTools.TrimSpace(editSoTheLaiXe.Text);
                NhanVien objNV = NhanVien.GetNhanVienByTheLaiXe(SoThe);
                if (objNV != null)
                {
                    editTenLaiXe.Text = objNV.TenNhanVien;
                }
                else editTenLaiXe.Text = "";
            }
        }

        private void editSoHieuXe_Leave(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            if (SoHieuXe.Length > 0)
            {
                if (!Xe.KiemTraTonTaiCuaSoHieuXe(editSoHieuXe.Text))
                {
                    g_boolValidate = false;

                    errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
                    new MessageBox.MessageBoxBA().Show(this, "Số hiệu xe này không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    editTenLaiXe.Text = "";
                    editSoHieuXe.Focus();
                    return;
                }
                else
                {
                    // KIEM TRA CO QUYEN CHO RA HOAT DONG XE 999
                    //if (SoHieuXe == "999")
                    //{
                    //    if (!ThongTinDangNhap.HasPermission("010299"))
                    //    {
                    //        g_boolValidate = false;

                    //        errorProvider.SetError(editSoHieuXe, "Bạn không có quyền cho xe 999 ra hoạt động, hoặc về.");
                    //        new MessageBox.MessageBox().Show(this, "Bạn không có quyền cho xe 999 ra hoạt động, hoặc về", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    //        editSoHieuXe.Focus();
                    //    }
                    //}                    
                    if (g_intTrangThai == 1)// xe bao haot dong
                    {
                        if (KiemSoatXeLienLac.CheckXeDangHoatDong(editSoHieuXe.Text))
                        {
                            g_boolValidate = false;

                            errorProvider.SetError(editSoHieuXe, "Xe đang hoạt động. Bạn cần kiểm tra lại.");
                            new MessageBox.MessageBoxBA().Show(this, "Xe đang hoạt động, bạn không thể nhập lại trạng thái này", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                            editSoHieuXe.Focus();
                            return;

                        }
                        else  // lấy thông tin xe ở gara nào
                        {
                            Xe objXe = new Xe();
                            editViTriBao.Text = objXe.GetChiTietXe(editSoHieuXe.Text).GaraName;
                        }

                    }

                    KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                    objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(StringTools.TrimSpace(editSoHieuXe.Text));
                    if (StringTools.TrimSpace(editTenLaiXe.Text).Length <= 0)
                        editTenLaiXe.Text = objKSXe.MaLaiXe;

                }
                errorProvider.SetError(editSoHieuXe, "");
            }
        }

        


        #region XU LY HOTKEY

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    //else if (keyData == (Keys.Alt | Keys.N))
        //    //{
        //    //    maskXeNhan.Focus();
        //    //    return true;
        //    //}
        //    //else if (keyData == (Keys.Alt | Keys.X))
        //    //{
        //    //    maskXeDon.Focus();
        //    //    return true;
        //    //}
        //    //else if (keyData == (Keys.Alt | Keys.L))
        //    //{
        //    //    editLenhTongDai.Focus();
        //    //    return true;
        //    //}
        //    //else if (keyData == (Keys.Alt | Keys.G))
        //    //{
        //    //    editGhiChu.Focus();
        //    //    return true;
        //    //}

        //    //return true ;
        //}
        #endregion XU LY HOTKEY
    }
}