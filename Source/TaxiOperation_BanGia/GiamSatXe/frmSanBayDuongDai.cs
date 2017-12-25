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
using System.Text.RegularExpressions;

namespace Taxi.GUI 
{
    public partial class frmSanBayDuongDai : Form
    {
       
        private bool g_boolValidate = false;
        
        private DateTime timeServer;
        private Form frmParent = new Form();
        private int mKieuBao = 0; // 1: Hoạt động , 2 điểm , 3 nghỉ 4 về

        string g_soHieuXe = string.Empty;
        DateTime g_thoiDiemDon = DateTime.MinValue;

        private string diemDon = string.Empty;
        private string diemTra = string.Empty;
        private long coDi = 0;
        private long coVe = 0;
        private string ghiChu = string.Empty;

        private bool isNewItem = false;

        public frmSanBayDuongDai()
        {
            InitializeComponent();
            
        }
        ///// <summary>
        ///// báo hoạt động
        ///// </summary>
        ///// <param name="ParentForm"></param>
        public frmSanBayDuongDai(Form ParentForm)
        {
            InitializeComponent();
            this.frmParent = ParentForm;
            isNewItem = true;
        }

        public frmSanBayDuongDai(Form ParentForm, string soHieuXe, DateTime thoiDiemDon)
        {
            InitializeComponent();
            this.frmParent = ParentForm;
            isNewItem = false ;
            g_soHieuXe = soHieuXe;
            g_thoiDiemDon = thoiDiemDon;
        }

        ///// <summary>
        ///// báo về báo 
        ///// </summary>
        ///// <param name="ParentForm"></param>
        ///// <param name="KieuBao"></param>
        //public frmSanBayDuongDai(Form ParentForm, int KieuBao)
        //{
        //    InitializeComponent();
        //    this.frmParent = ParentForm;
        //    this.mKieuBao = KieuBao;
        //    DisplayControls( );
        //}

        //public frmSanBayDuongDai(Form ParentForm, int KieuBao, string SoHieuXe)
        //{
        //    InitializeComponent();
        //    this.frmParent = ParentForm;
        //    this.mKieuBao = KieuBao;
        //    DisplayControls();
        //    editSoHieuXe.Text = SoHieuXe;
        //    // lấy thong tin xe
        //    //  editSoHieuXe_TextChanged(null, null);
        //}       

        private void frmRaHoatDong_Load(object sender, EventArgs e)
        {
            if (ThongTinDangNhap.USER_ID.Length <= 0)
            {
                new MessageBox.MessageBox().Show(this, "Bạn cần đăng nhập hệ thống để sử dụng chức năng này.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                this.Close();
            }
            

            if (isNewItem)
            {
                timeServer = DieuHanhTaxi.GetTimeServer();
                lblTitle.Text = "Tạo mới cuốc sân bay, đường dài";
                radSanBay.Checked = true;
                ThietLapConTrolChoSanBay();
            }
            else
            {
                timeServer = g_thoiDiemDon; // update 
                editSoHieuXe.Text = g_soHieuXe;
                editSoHieuXe.Enabled = false;
                lblTitle.Text = "Cập nhật cuốc sân bay, đường dài";
                // lấy thông tin cuộc đường dài
                GetThongTinXe(g_soHieuXe, g_thoiDiemDon);
            }  
            if (timeServer != DateTime.MinValue)
            {
                editThoiDiemBao.Text = string.Format("{0: HH:mm:ss dd/MM/yyyy}", timeServer);
                editThoiDiemBao.ReadOnly = true;
            } 

           
        }

        private void GetThongTinXe(string  soHieuXe, DateTime  thoiDiemDon)
        {
            try
            {
                KiemSoatXeLienLac xe = new KiemSoatXeLienLac();
                xe = KiemSoatXeLienLac.GetKSXeBySoHieuXeThoiDiemBao(soHieuXe, thoiDiemDon);

                // san bay - duong dai
                if (xe.LoaiChoKhach == LoaiChoKhach.ChoKhachSanBay)
                {
                    radSanBay.Checked = true;
                    if (xe.ChieuChoKhach == LoaiChieuChoKhach.MotChieu)
                    {
                        rad1.Checked = true;
                    }
                    else if (xe.ChieuChoKhach == LoaiChieuChoKhach.HaiChieu)
                    {
                        rad2.Checked = true;
                    }
                    else if (xe.ChieuChoKhach == LoaiChieuChoKhach.MotChieuSanBayCoKhach)
                    {
                        rad3.Checked = true;
                    }
                }
                else if (xe.LoaiChoKhach == LoaiChoKhach.ChoKhachDuongDai)
                {
                    radDuongDai.Checked = true;
                    if (xe.ChieuChoKhach == LoaiChieuChoKhach.MotChieu)
                    {
                        rad1.Checked = true;
                    }
                    else if (xe.ChieuChoKhach == LoaiChieuChoKhach.HaiChieu)
                    {
                        rad2.Checked = true;
                    }
                    else if (xe.ChieuChoKhach == LoaiChieuChoKhach.DuongDaiThueBao)
                    {
                        rad3.Checked = true;
                    }
                    else if (xe.ChieuChoKhach == LoaiChieuChoKhach.MotChieuDonKhachTinh)
                    {
                        rad4.Checked = true;
                    }
                }

                editViTriTra.Text = xe.ViTriDiemDen;
                txtViTriDon.Text = xe.ViTriDiemBao;
                txtCo.Text = xe.CoDi.ToString();
                if (xe.CoVe > 0)
                    txtCoVe.Text = xe.CoVe.ToString();
                else
                    txtCoVe.Text = string.Empty;
                txtGhiChu.Text = xe.GhiChu;
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBox().Show(this, ex.Message, "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                
            }
             
        }

       /// <summary>
       /// Hàm trả về thông tin còn thiếu
       /// - Số hiệu xe
       /// - Điểm đón
       /// - Điểm trả
       /// - Cơ đi
       /// </summary>
       /// <returns></returns>
        private int  IsValidate()
        {
            diemDon = StringTools.TrimSpace(txtViTriDon.Text );
            if (diemDon.Length <= 0) return 1;  // chua co diem đón

            diemTra = StringTools.TrimSpace(editViTriTra.Text);
            if (diemTra.Length <= 0) return 2;  // chua co diem tra

            if (!long.TryParse(txtCo.Text, out coDi))
            {
                coDi = 0;
                return 3;// thông tin co đi chưa đúng
            }
            ghiChu = StringTools.TrimSpace(txtGhiChu.Text);

            if (StringTools.TrimSpace(txtCoVe.Text).Length >0 )
            {
                if (!long.TryParse(txtCoVe.Text, out coVe))
                {
                    coVe = 0;
                    return 3;// thông tin co đi chưa đúng
                }
            }
            return 0;
        }

        private void DisplayMessage(int ErrorCode)
        {
            if (ErrorCode == 1) lblMessage.Text = "Bạn phải nhập địa chỉ đón.";
            else if (ErrorCode == 2) lblMessage.Text = "Bạn phải nhập địa chỉ trả khách.";
            else if (ErrorCode == 3) lblMessage.Text = "Bạn phải nhập chính xác thông tin cơ.";
        }

        private void  LuuThongTin()
        {
             KiemSoatXeLienLac objKSXeLL = new KiemSoatXeLienLac();
           
             objKSXeLL.SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
             objKSXeLL.ThoiDiemBao = timeServer;
              
            objKSXeLL.ViTriDiemBao = diemDon;
            objKSXeLL.ViTriDiemDen = diemTra;
            objKSXeLL.CoDi = coDi;
            objKSXeLL.GhiChu = ghiChu;
            if (radSanBay.Checked)
            {
                objKSXeLL.LoaiChoKhach = LoaiChoKhach.ChoKhachSanBay;    
                if(rad1.Checked) // 
                {
                    objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.MotChieu;
                }
                else if (rad2.Checked)
                {
                     objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.HaiChieu;
                }
                else if (rad3.Checked)
                {
                     objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.MotChieuSanBayCoKhach;
                }
            }
            else 
            {
                objKSXeLL.LoaiChoKhach = LoaiChoKhach .ChoKhachDuongDai;
                if(rad1.Checked) // 
                {
                    objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.MotChieu;
                }
                else if (rad2.Checked)
                {
                     objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.HaiChieu;
                }
                else if (rad3.Checked)
                {
                     objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.DuongDaiThueBao;
                }
                 else if (rad4.Checked)
                {
                     objKSXeLL.ChieuChoKhach = LoaiChieuChoKhach.MotChieuDonKhachTinh;
                }
            }
            objKSXeLL.CoVe = coVe;

            if(!objKSXeLL.InsertUpdateSanBayDuongDai())
            {
                lblMessage.Text = "Lỗi nhập liệu, bạn kiểm tra lại.";
            }
        }        
        
        /// <summary>
        /// luu va dong form luon
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
            
            if (ErrorCode == 0)
            {
                LuuThongTin();
                ((frmGiamSatXe)this.frmParent).LoadDSXe(); 
                this.Close();
            }
            else DisplayMessage(ErrorCode);
        }   

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape  :
                    {
                        this.Close();
                        g_boolValidate = true;
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
                radSanBay.Focus();
            }
            else if(e.KeyCode== Keys.Up)
            {
                btnSave.Focus();
            }
        }
 
        private void editSoHieuXe_TextChanged(object sender, EventArgs e)
        {
            string SoHieuXe = StringTools.TrimSpace(editSoHieuXe.Text);
            if (SoHieuXe.Length <= 0) return;

            if (!Xe.KiemTraTonTaiCuaSoHieuXe(SoHieuXe))
            {
                g_boolValidate = false; 
                errorProvider.SetError(editSoHieuXe, "Số hiệu xe này không tồn tại");
                return;
            }
             
            g_boolValidate = true;
            errorProvider.SetError(editSoHieuXe, "");

        }         
  
        private void editViTriBao_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (mKieuBao == 1)
            //    {
            //        btnSave .Focus();
            //    }
            //    else if (mKieuBao == 2)
            //    {
            //        txtCo.Focus();
            //    }
            //    else if (mKieuBao == 3)
            //    {
            //        btnSave.Focus();
            //    }
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    if (mKieuBao == 1)
            //    {
            //        editTenLaiXe.Focus();
            //    }
            //    else if (mKieuBao == 2)
            //    {
            //        txtViTriDon.Focus();
            //    }
            //    else if (mKieuBao == 3)
            //    {
            //        editSoHieuXe.Focus();
            //    }
            //}
        }

        private void txtCo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (mKieuBao == 1)
            //    {
            //        btnSave.Focus();
            //    }
            //    else if (mKieuBao == 2)
            //    {
            //        btnSave.Focus();
            //    }
            //    else if (mKieuBao == 3)
            //    {
            //        btnSave.Focus();
            //    }
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    if (mKieuBao == 1)
            //    {
            //        editTenLaiXe.Focus();
            //    }
            //    else if (mKieuBao == 2)
            //    {
            //        editViTriBao.Focus();
            //    }
            //    else if (mKieuBao == 3)
            //    {
            //        editSoHieuXe.Focus();
            //    }
            //}
        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void radSanBay_CheckedChanged(object sender, EventArgs e)
        {
            if (radSanBay.Checked)
            {
                ThietLapConTrolChoSanBay();
            }
        }

        private void radDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if (radDuongDai.Checked)
            {
                ThietLapControlChoDuongDai();
            }
        }
        /// <summary>
        /// đặt các control cho phep nhap du lieu san bay
        /// </summary>
        void ThietLapConTrolChoSanBay()
        {
            rad1.Text = "1 chiều";
            rad2.Text = "2 chiều";
            rad3.Text = "SB - HN";
            rad4.Visible = false;
            editViTriTra.Text = "Sân bay";
        }
        /// <summary>
        /// Đặt control cho phep nhap du lieu duong dai
        /// </summary>
        void ThietLapControlChoDuongDai()
        {
            rad1.Text = "1 chiều";
            rad2.Text = "2 chiều";
            rad3.Text = "Thuê bao";
            rad4.Text = "Tỉnh-HN";
            rad4.Visible = true ;
            editViTriTra.Text = string.Empty ;
        }
    }
}