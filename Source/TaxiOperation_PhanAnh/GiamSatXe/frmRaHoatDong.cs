using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business.DM;
using Taxi.Business;
using Taxi.Utils;
using EFiling.Utils;

namespace Taxi.GUI 
{
    public partial class frmRaHoatDong : Form
    {
       
        private bool g_boolValidate = false;
        
        private DateTime timeServer;
        private Form frmParent = new Form();
        private int mKieuBao = 0; // 1: Hoạt động , 2 điểm , 3 nghỉ 4 về

        public frmRaHoatDong()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// báo hoạt động
        /// </summary>
        /// <param name="ParentForm"></param>
        public frmRaHoatDong(Form ParentForm)
        {
            InitializeComponent();
            this.frmParent = ParentForm;
            this.mKieuBao = 1;
              DisplayControls();
        }
        /// <summary>
        /// báo về báo 
        /// </summary>
        /// <param name="ParentForm"></param>
        /// <param name="KieuBao"></param>
        public frmRaHoatDong(Form ParentForm, int KieuBao)
        {
            InitializeComponent();
            this.frmParent = ParentForm;
            this.mKieuBao = KieuBao;
            DisplayControls( );
        }

        public frmRaHoatDong(Form ParentForm, int KieuBao, string SoHieuXe)
        {
            InitializeComponent();
            this.frmParent = ParentForm;
            this.mKieuBao = KieuBao;
            DisplayControls();
            editSoHieuXe.Text = SoHieuXe;
            // lấy thong tin xe
            //  editSoHieuXe_TextChanged(null, null);
        }
        /// <summary>
        /// hàm hiện thị thông tin , 2 điểm , 3 nghỉ 4 về
        /// </summary>
        private void DisplayControls()
        {
            chkSanBay.Visible = false;
            chkDuongDai.Visible = false;
            txtViTriBao1.Visible = false;
            chkTongDaiGoi.Visible = false;
            if ( mKieuBao == 4) //  bao ve
            {
                editTenLaiXe.Enabled = false;
                editSoTheLaiXe.Enabled = false;
                editViTriBao.Text = " ";
                editViTriBao.Enabled = false;
                if (mKieuBao == 3) this.Text = "Lái xe báo nghỉ (ESC : thoát)";
                else if (mKieuBao == 4) this.Text = "Lái xe báo về (ESC : thoát)";
            }
            else if (mKieuBao == 3)// báo nghỉ
            {
                editTenLaiXe.Enabled = false;
                editSoTheLaiXe.Enabled = false;
                editViTriBao.Text = " ";
                editViTriBao.Enabled = true ;
                if (mKieuBao == 3) this.Text = "Lái xe báo nghỉ (ESC : thoát)";
                else if (mKieuBao == 4) this.Text = "Lái xe báo về (ESC : thoát)";
      
            }
            else if(mKieuBao ==2) // bao diem don khach
            {
                lblMaThe.Visible = false; editTenLaiXe.Visible = false; editSoTheLaiXe.Visible = false;
                lblTenLaiXe .Text ="Vị trí đón (*)";
                lblViTriBao.Text ="Vị trí trả ";
                chkSanBay.Visible = true;
                chkDuongDai.Visible = true ;
                txtViTriBao1.Visible = true;
                chkTongDaiGoi.Visible = true;
            }
            else if (mKieuBao == 1) // bao ra hoat dong
            {
                lblMaThe.Visible = true ; editTenLaiXe.Visible = true ; editSoTheLaiXe.Visible = true ;  
                chkSanBay.Visible = false ;
                chkDuongDai.Visible = false ;
                txtViTriBao1.Visible = false ;
            }
        }

        private void frmRaHoatDong_Load(object sender, EventArgs e)
        {
            if (ThongTinDangNhap.USER_ID.Length <= 0)
            {
                new MessageBox.MessageBox().Show(this, "Bạn cần đăng nhập hệ thống để sử dụng chức năng này.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                this.Close();
            }

            timeServer = DieuHanhTaxi.GetTimeServer();
            if (timeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", timeServer);
                editThoiDiemBao.ReadOnly = true;
            }
            editSoHieuXe.Focus();
            if (mKieuBao == 4)
            {
                Xe objXe = new Xe();
                editViTriBao.Text = objXe.GetChiTietXe(editSoHieuXe.Text ).GaraName;
                if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0) editViTriBao.Text = "Gara";
            }
        }
        

        private void ResetForm()
        {
            timeServer = DieuHanhTaxi.GetTimeServer();
            if (timeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", timeServer);

            }
            lblMessage.Text = "";
            editSoHieuXe.Text = "";
            editSoTheLaiXe.Text="";
            editTenLaiXe.Text = "";
            editViTriBao.Text = "";
            txtViTriBao1.Text = "";
            chkDuongDai.Checked = false;
            chkSanBay.Checked = false;
            
        }

        /// <summary>
      
        /// 2 : Bạn phải nhập thông tin tên lái xe.
        /// 3 : Bạn phải nhập thông tin vị trí báo.
        /// </summary>
        /// <returns></returns>
        private int  IsValidate()
        {
            
            
            if (ThongTinCauHinh.KiemTraXeDaRaHoatDong)
            {
                if (StringTools.TrimSpace(editTenLaiXe.Text).Length <= 0) return 2;

                if (mKieuBao == 1)
                    if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0) return 3;
            }

            return 0;
        }

        private void DisplayMessage(int ErrorCode)
        {
            if (ErrorCode == 1) lblMessage.Text = "Số hiệu xe quy định là 3 ký tự.";
            else if (ErrorCode == 2) lblMessage.Text = "Bạn phải nhập thông tin tên lái xe.";
            else if (ErrorCode == 3) lblMessage.Text = "Bạn phải nhập thông tin vị trí báo.";
        }

        private void  LuuThongTin()
        {
            // lưu bảng hoạt động

            // lưu bảng ksxll
            KiemSoatXeLienLac objKSXeLL = new KiemSoatXeLienLac();

            objKSXeLL.SoHieuXe = StringTools.TrimSpace (editSoHieuXe.Text);
            objKSXeLL.ThoiDiemBao =timeServer;             
            objKSXeLL.ViTriDiemBao =  StringTools.TrimSpace (editViTriBao.Text);
            objKSXeLL.MaLaiXe = StringTools.TrimSpace(editTenLaiXe.Text);

            if (mKieuBao == 1)
            {
                objKSXeLL.IsHoatDong = true;

                objKSXeLL.TrangThaiLaiXeBao = EFiling.Utils.KieuLaiXeBao.BaoRaHoatDong;
                objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                objKSXeLL.ViTriDiemDen = string.Empty;

                objKSXeLL.GhiChu = "";
            }
            else if (mKieuBao == 2) // báo điểm
            {
                 objKSXeLL.IsHoatDong = true;
                objKSXeLL.ViTriDiemBao =  StringTools.TrimSpace (txtViTriBao1.Text);
                if (chkTongDaiGoi.Checked) objKSXeLL.TrangThaiLaiXeBao = KieuLaiXeBao.TongDaiCheck;
                else
                 objKSXeLL.TrangThaiLaiXeBao = EFiling.Utils.KieuLaiXeBao.BaoDiemDo;                
                 objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                 if (chkDuongDai.Checked) objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachDuongDai;
                 else if (chkSanBay.Checked) objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachSanBay;

                 objKSXeLL.ViTriDiemDen = StringTools.TrimSpace(editViTriBao.Text);

                 objKSXeLL.GhiChu = "";
            }
            else if (mKieuBao == 3) // báo  nghỉ
            {
                objKSXeLL.IsHoatDong = true;

                objKSXeLL.TrangThaiLaiXeBao = EFiling.Utils.KieuLaiXeBao.BaoNghi;
                objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                objKSXeLL.ViTriDiemDen = string.Empty; 
                objKSXeLL.GhiChu = "";
            }
            else if (mKieuBao == 4) // báo  về
            {
                objKSXeLL.IsHoatDong = false ;

                objKSXeLL.TrangThaiLaiXeBao = EFiling.Utils.KieuLaiXeBao.BaoVe;
                objKSXeLL.LoaiChoKhach = EFiling.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                objKSXeLL.ViTriDiemDen = string.Empty;
                objKSXeLL.GhiChu = "";
            }


            if (!objKSXeLL.InsertUpdate())
            {
                lblMessage.Text = "Lỗi lưu thông tin.Bạn cần liên hệ với quản trị hệ thống."; lblMessage.Visible = true;
                return;
            }
            else lblMessage.Text ="";

            if ((mKieuBao == 1) || (mKieuBao == 4))
            {
                if (!KiemSoatXeLienLac.InsertUpdateXeDangHoatDong(objKSXeLL.SoHieuXe, objKSXeLL.ThoiDiemBao, objKSXeLL.IsHoatDong))
                {
                    lblMessage.Text = "Lỗi lưu thông tin xe hoạt động.Bạn cần liên hệ với quản trị hệ thống."; lblMessage.Visible = true;
                    return;
                }
                else lblMessage.Text = "";
            }
           lblMessage.Text = "Lưu thông tin thành công.";
        }
       
        private void editSoTheLaiXe_TextChanged(object sender, EventArgs e)
        {
            if (editSoTheLaiXe.Text.Length > 0)
            {
                string SoThe = StringTools.TrimSpace(editSoTheLaiXe.Text);
                NhanVien objNV = NhanVien.GetNhanVienByTheLaiXe(SoThe);
                if (objNV != null)
                {
                    editTenLaiXe.Text = SoThe + " - " + objNV.TenNhanVien + objNV.DienThoai;
                }
                else editTenLaiXe.Text = "";
            }
        }

        private void editSoTheLaiXe_Leave(object sender, EventArgs e)
        {
            if (editTenLaiXe.Text.Length <= 0)
            {

                string SoThe = StringTools.TrimSpace(editSoTheLaiXe.Text);
                if (SoThe.Length > 0)
                {
                    NhanVien objNV = NhanVien.GetNhanVienByTheLaiXe(SoThe);
                    if (objNV != null)
                    {
                        editTenLaiXe.Text = SoThe + " - " + objNV.TenNhanVien + objNV.DienThoai;
                    }
                }
            }

        }
        //  ----------------------
        // LUU VAO DATABASE
        //  ----------------------
        private void btnCapNhatKhongDong_Click(object sender, EventArgs e)
        {
            if (!g_boolValidate)
            {
                lblMessage.Text = "Thông tin số hiệu xe không phù hợp."; return;
            }
            int ErrorCode = IsValidate();
            if ((mKieuBao == 2) && (ErrorCode == 3)) ErrorCode = 0;
            if (ErrorCode == 0)
            {
                LuuThongTin();
                ((frmGiamSatXe)this.frmParent).LoadDSXe();
                ResetForm();
                editSoHieuXe.Focus();
            }
            else DisplayMessage(ErrorCode); 
        }

        /// <summary>
        /// luwuw vaf dong form luon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!g_boolValidate)
            {
                lblMessage.Text = "Thông tin số hiệu xe không phù hợp."; return;
            }
            int ErrorCode = IsValidate();
            if ((mKieuBao == 2) && (ErrorCode == 3)) ErrorCode = 0;
            if (ErrorCode == 0)
            {
                LuuThongTin();
                ((frmGiamSatXe)this.frmParent).LoadDSXe();
                ResetForm();
                this.Close();
            }
            else DisplayMessage(ErrorCode);
        }

        private void chkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSanBay.Checked) { chkDuongDai.Checked = false; editViTriBao.Text = "Sân bay"; };
        }

        private void chkDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuongDai.Checked) {chkSanBay.Checked = false; editViTriBao.Text = "";}
        }

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape  :
                    {
                        this.Close();
                        break;
                    }
                case Keys.F5:  
                    {
                        this.mKieuBao = 1;
                        this.DisplayControls();
                        break;
                    }
                case Keys.F6:
                    {
                        this.mKieuBao = 2;
                        this.DisplayControls();
                        break;
                    }
                case Keys.F7:  
                    {
                        this.mKieuBao = 3;
                        this.DisplayControls();
                        break; 
                    }
                case Keys.F8:   
                    {
                        this.mKieuBao = 4;
                        this.DisplayControls();
                        break;
 
                    }
            }
            return base.ProcessDialogKey(keyData);
        }

       

        #endregion XU LY HOTKEY

        private void editSoHieuXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (mKieuBao == 1) //
                {
                    editSoTheLaiXe.Focus();
                }
                else if (mKieuBao == 2)
                {
                    chkSanBay.Focus();
                }
                else if (mKieuBao == 3)
                {
                    editViTriBao.Focus();
                }
            }
            else if(e.KeyCode== Keys.Up)
            {
                btnSave.Focus();
            }
        }

        private void editSoHieuXe_Leave(object sender, EventArgs e)
        {
             string SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);

            //if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
            //{
            //    g_boolValidate = false;

            //    errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
            //    new MessageBox.MessageBox().Show(this, "Số hiệu xe này không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //    editTenLaiXe.Text = "";
            //    editSoHieuXe.Focus();
            //    return;
            //}
            //else
            //{
            //    KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
            //    objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(SoHieuXe); // số hiệu xe này đã được khai báo trước đó.
            //    if (objKSXe != null)
            //    {
            //        if (StringTools.TrimSpace(editTenLaiXe.Text).Length <= 0)
            //            editTenLaiXe.Text = objKSXe.MaLaiXe;
            //    }
            //    if (KiemSoatXeLienLac.CheckXeDangHoatDong(SoHieuXe))
            //    {
            //        if (mKieuBao == 1) // xe hoạt động
            //        {
            //            g_boolValidate = false;
            //            errorProvider.SetError(editSoHieuXe, "Xe đang hoạt động. Bạn cần kiểm tra lại.");
            //            new MessageBox.MessageBox().Show(this, "Xe đang hoạt động, bạn không thể nhập lại trạng thái này", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //            editSoHieuXe.Focus();
            //            return;
            //        }
            //        else if (mKieuBao == 4)
            //        {
            //            Xe objXe = new Xe();
            //            editViTriBao.Text = objXe.GetChiTietXe(SoHieuXe).GaraName;
            //            if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0) editViTriBao.Text = "Gara";
            //        }
            //    }
            //    else
            //    {  // lấy thông tin nhập cho xe haọt động       
            //        if (mKieuBao == 1) // xe hoạt động
            //        {
            //            Xe objXe = new Xe();
            //            editViTriBao.Text = objXe.GetChiTietXe(SoHieuXe).GaraName;
            //            objXe = null;
            //        }
            //        else if (mKieuBao == 2 || mKieuBao == 3 || mKieuBao == 4) // xe hoạt điểm 
            //        {
            //            g_boolValidate = false;
            //            lblMessage.Text = "Xe chưa hoạt động bạn cần phải cho xe ra hoạt động";
            //            editSoHieuXe.Focus();
            //            return;
            //        }
            //    }
            //}
            //g_boolValidate = true;
            //errorProvider.SetError(editSoHieuXe, "");

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
        }
        private void editSoHieuXe_TextChanged(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            if (SoHieuXe.Length <= 0) return;

            if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
            {
                g_boolValidate = false;

                errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
               // new MessageBox.MessageBox().Show(this, "Số hiệu xe này không tồn tại", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                editTenLaiXe.Text = "";
                return;
            }
            else
            {
                KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                objKSXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(SoHieuXe); // số hiệu xe này đã được khai báo trước đó.
                if (objKSXe != null)
                {
                    if (StringTools.TrimSpace(editTenLaiXe.Text).Length <= 0)
                        editTenLaiXe.Text = objKSXe.MaLaiXe;
                }
                if (KiemSoatXeLienLac.CheckXeDangHoatDong(SoHieuXe))
                {
                    if (mKieuBao == 1) // xe hoạt động
                    {
                        g_boolValidate = false;
                        errorProvider.SetError(editSoHieuXe, "Xe đang hoạt động. Bạn cần kiểm tra lại.");
                        new MessageBox.MessageBox().Show(this, "Xe đang hoạt động, bạn không thể nhập lại trạng thái này", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        return;
                    }
                    else if (mKieuBao == 4)
                    {
                        Xe objXe = new Xe();
                        editViTriBao.Text = objXe.GetChiTietXe(SoHieuXe).GaraName;
                        if (StringTools.TrimSpace(editViTriBao.Text).Length <= 0) editViTriBao.Text = "Gara";
                    }
                }
                else
                {  // lấy thông tin nhập cho xe haọt động       
                    if (mKieuBao == 1) // xe hoạt động
                    {
                        Xe objXe = new Xe();
                        editViTriBao.Text = objXe.GetChiTietXe(SoHieuXe).GaraName;
                        objXe = null;
                    }
                    else if (mKieuBao == 2 || mKieuBao == 3 || mKieuBao == 4) // xe hoạt điểm 
                    {
                        g_boolValidate = false;
                        lblMessage.Text = "Xe chưa hoạt động bạn cần phải cho xe ra hoạt động"; return;
                    }
                }
            }
            g_boolValidate = true;
            errorProvider.SetError(editSoHieuXe, "");

        }


        private void editSoTheLaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (mKieuBao == 1) //
                {
                    editTenLaiXe.Focus();
                } 
            }
            else if (e.KeyCode == Keys.Up)
            {
                editSoHieuXe.Focus();
            }
        
        }
        private void editTenLaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (mKieuBao == 1) //
                {
                    editViTriBao.Focus();
                }
                 
            }
            else if (e.KeyCode == Keys.Up)
            {
                editSoTheLaiXe.Focus();
            }
        }

        private void txtViTriBao1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                 
                 if (mKieuBao == 2)
                {
                    editViTriBao.Focus();
                }
                else if (mKieuBao == 3)
                {
                    editViTriBao.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                chkDuongDai.Focus();
            }
        }

        private void editViTriBao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (mKieuBao == 1)
                {
                    btnSave .Focus();
                }
                else if (mKieuBao == 2)
                {
                    btnSave.Focus();
                }
                else if (mKieuBao == 3)
                {
                    btnSave.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (mKieuBao == 1)
                {
                    editTenLaiXe.Focus();
                }
                else if (mKieuBao == 2)
                {
                    txtViTriBao1.Focus();
                }
                else if (mKieuBao == 3)
                {
                    editSoHieuXe.Focus();
                }
            }
        }

        private void chkTongDaiGoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTongDaiGoi.Checked)
                txtViTriBao1.Text = "[Tổng đài gọi]";
            else
                txtViTriBao1.Text = "";
        }

        

      

         
        
    }
}