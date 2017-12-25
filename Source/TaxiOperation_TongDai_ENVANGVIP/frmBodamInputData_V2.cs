using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.DM;

namespace Taxi.GUI
{
    public partial class frmBodamInputData_V2: Form
    {
        private DieuHanhTaxi mDieuHanhTaxi = new DieuHanhTaxi();
        private bool gGoiLai = false;
        private int g_intGoilaiHoanTruot = 0;
        private bool g_FormValidate = false;  // kiểm tra form nhập hợp lệ thì ẩn
        private bool g_FormHuyBo = false; // khi check hủy
        private bool g_CoThayDoiDuLieu = false;

        private DieuHanhTaxi gDieuHanhGoiLai = new DieuHanhTaxi();

        private string mDSXeNhanDangHoatDong;

        public string DSXeNhanDangHoatDong
        {
            get { return mDSXeNhanDangHoatDong; }
            set { mDSXeNhanDangHoatDong = value; }
        }
        // ghi nhat trang thai cap nhat dia chi don khach
        private bool g_boolCapNhatDCTraKhach = false;

        public bool IsCapNhatDCTraKhach
        {
            get { return g_boolCapNhatDCTraKhach; }
        }

        public DieuHanhTaxi GetDieuHanhTaxi
        {
            get {
                  
                return mDieuHanhTaxi; }
            //  set { mDieuHanhTaxi = value; }
        }
        private int gLen = 0;


        private    DateTime g_TimeServer;
        private    int g_SoLuongMayDangNhapCS = 0;

        public frmBodamInputData_V2()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>
        public frmBodamInputData_V2(DieuHanhTaxi DieuHanhTaxi,int SoLuongMayCSDangNhap, DateTime TimeServer)
        {
            InitializeComponent();
            mDieuHanhTaxi = DieuHanhTaxi;
            editDiaChiTraKhach.Visible = false;
            chkSanBay.Visible = false;
            chkDuongDai.Visible = false;
            g_TimeServer = TimeServer;
            g_SoLuongMayDangNhapCS = SoLuongMayCSDangNhap;
        }

        public frmBodamInputData_V2(DieuHanhTaxi DieuHanhTaxi,  DateTime TimeServer, bool boolCapNhatDCTraKhach)
        {
            InitializeComponent();
            mDieuHanhTaxi = DieuHanhTaxi;
            g_boolCapNhatDCTraKhach = boolCapNhatDCTraKhach;

            this.SetData2Form();
            editDiaChiTraKhach.Visible = true ;
            chkSanBay.Visible = true ;
            chkDuongDai.Visible = true ;
            editDiaChiTraKhach.Text = mDieuHanhTaxi.DiaChiTraKhach ; // thiet lap cho nhap
            lblGhiChu.Text = "Đ/C trả khách";
           // label23.Text = string.Empty;
            label24.Text = string.Empty;
            label25.Text = string.Empty;
            label27.Text = string.Empty;
            maskXeDon.Enabled = false;
            maskXeNhan.Enabled = false;
            editLenhTongDai.Enabled = false;
            editGhiChu.Visible  = false ;
            g_TimeServer = TimeServer;
        }




        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            ////txtDiaChiDonKhach.Focus();
            //if(mDieuHanhTaxi.XeNhan.Length<=0)
            //    maskXeDon.Enabled = false;
            //else 
            this.SetData2Form();
            if (mDieuHanhTaxi.LenhDienThoai.Contains("gọi lại"))
            {
                maskXeDon.Enabled = false;
                maskXeNhan.Enabled = false;
                editLenhTongDai.Enabled = true ;
                editGhiChu.Focus();
                editGhiChu.Text = "1";
            }

            if(!g_boolCapNhatDCTraKhach)
                maskXeDon.Enabled =true;
            if (mDieuHanhTaxi.GoiLai || mDieuHanhTaxi.GoiKhieuNai )
            {
                maskXeDon.Enabled = false;
                maskXeNhan.Enabled = false;
            }          
            if (mDieuHanhTaxi.XeNhan.Length > 0)
            {
                maskXeNhan.TextBox.SelectionLength = 0;
                maskXeNhan.TextBox.SelectionStart = mDieuHanhTaxi.XeNhan.Length;
                SendKeys.Send("{RIGHT}");
            }         
            g_CoThayDoiDuLieu = false;
            
            label22.Visible   = (g_SoLuongMayDangNhapCS <= 0);
            maskXeDon.Visible = (g_SoLuongMayDangNhapCS <= 0);
            label24.Visible   = (g_SoLuongMayDangNhapCS <= 0);
            chkTaxiGroupDon.Visible =  (g_SoLuongMayDangNhapCS <= 0);
        }
        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mDieuHanhTaxi != null)
            {
                // line + phone + time

                lblLinePhoneTime.Text = "[" + mDieuHanhTaxi.Line + "]  " + mDieuHanhTaxi.PhoneNumber + "  " + mDieuHanhTaxi.ThoiDiemGoiGio;
               
                lblDiaChiDonKhach.Text = mDieuHanhTaxi.DiaChiDonKhach;
                
                int iSoLuong = 0;

                if (mDieuHanhTaxi.SoLuong == "") iSoLuong = 0;
                else iSoLuong = int.Parse(mDieuHanhTaxi.SoLuong);
                string strXeCho;
                if ((iSoLuong == 2) && (mDieuHanhTaxi.LoaiXe.Contains("0")))
                {
                    strXeCho = "1 xe 4 chỗ, 1 xe 7 chỗ";
                }
                else
                {
                    if (iSoLuong <= 0) iSoLuong = 1;
                    strXeCho = iSoLuong.ToString ();
                    if (mDieuHanhTaxi.LoaiXe.Length <= 0) strXeCho += " xe, 4 hoặc 7 chỗ";
                    else if (mDieuHanhTaxi.LoaiXe.Contains("4")) strXeCho+= " xe, 4 chỗ" ;
                    else if (mDieuHanhTaxi.LoaiXe.Contains("7")) strXeCho += " xe, 7 chỗ";
                     
                }                
               lblSoLuong_LoaiXe.Text = strXeCho;
               maskXeDon.TextBox.Text = mDieuHanhTaxi.XeDon;
               if (mDieuHanhTaxi.XeNhan != null && mDieuHanhTaxi.XeNhan.Length > 0)
               {
                   maskXeNhan.TextBox.Text = mDieuHanhTaxi.XeNhan + ".";
                   maskXeNhan.TextBox.SelectionStart = maskXeNhan.TextBox.Text.Length;
               }
               else maskXeNhan.TextBox.Text = "";      
                
               editLenhTongDai.Text = mDieuHanhTaxi.LenhTongDai;
               editGhiChu.Text = mDieuHanhTaxi.GhiChuTongDai; 

                if(mDieuHanhTaxi.SanBay_DuongDai=="D")
                {
                     chkDuongDai.Checked = true;
                     chkSanBay.Checked  = false;
                }
                else if (mDieuHanhTaxi.SanBay_DuongDai == "S")
                {
                    chkDuongDai.Checked = false ;
                    chkSanBay.Checked  = true ;
                }
                else 
                {
                    chkDuongDai.Checked = false;
                    chkSanBay.Checked = false;
                }

                // Hiển thị chkTaxiGroup
                if (mDieuHanhTaxi.XeNhan.Length > 0 && ThongTinCauHinh.KichHoachTaxiGroupDon)
                    chkTaxiGroupDon.Visible = ThongTinCauHinh.KichHoachTaxiGroupDon;
                else chkTaxiGroupDon.Visible = false;
            }
        }
        /// <summary>
        /// lay du lieu tra form gan vao cho doi tuong mDieuHanhTaxi
        /// </summary>
        
        private void GetData2Form()
        {
            
        }

        #region Validate du lieu
        /// <summary>
        /// Kiem tra trong cac xe da trung nhau khong
        /// </summary>
        /// <param name="DanhSachTaxi"></param>
        /// <returns></returns>
        private bool CheckTrungLapXeChay(string DanhSachTaxi)
        {
           
                string[] arrTaxi = DanhSachTaxi.Split(".".ToCharArray());
                ////for (int i = 0; i < arrTaxi.Length; i++)
                //// {
                ////     if (arrTaxi[i].Length != 3) { return true; }
                ////}
                for (int i = 0; i < arrTaxi.Length - 1; i++)
                {
                    for (int j = i + 1; j < arrTaxi.Length; j++)
                    {
                 
                        if(arrTaxi[j] == arrTaxi[i]) return true ;
                    }
                }
                return false;
           
        }

        /// <summary>
        /// Check xe cua Taxi Chay co trong Nhung ChieuTaxichay hay khong
        /// </summary>
        /// <param name="NhungXeCoTheChay"></param>
        /// <param name="TaxiChay"></param>
        /// <returns></returns>
        private bool CheckDulieu_XeChay(string NhungXeCoTheChay, string TaxiChay)
        {
            bool boolRet = true;    
            if (TaxiChay.Contains("."))
            {

                string[] arrTaxiChay = TaxiChay.Split(".".ToCharArray());

                for (int i = 0; i < arrTaxiChay.Length; i++)
                {
                    boolRet = boolRet & NhungXeCoTheChay.Contains((string)arrTaxiChay[i]);
                }

                return boolRet;
            }
            else
            {
                return (boolRet & NhungXeCoTheChay.Contains(TaxiChay));
            }
            return false;
        }

        /// <summary>
        /// kiểm tra xem ds xe đón có nằm trong xe nhận hay không
        /// </summary>
        /// <param name="DSXeNhan"></param>
        /// <param name="DSXeDon"></param>
        /// <returns></returns>
        private bool KiemTraXeDonCoNamTrongXeNhan(string DSXeNhan, string DSXeDon)
        {
            if (DSXeDon.Length > 0 && DSXeNhan.Length > 0)
            {
                string[] arrTaxiXeNhan = DSXeNhan.Split(".".ToCharArray());
                string[] arrTaxiXeDon = DSXeDon.Split(".".ToCharArray());
                bool bRet = true;
                for (int i = 0; i < arrTaxiXeDon.Length; i++)
                {
                    bool bCoXeDon = false;
                    for (int j = 0; j < arrTaxiXeNhan.Length; j++)
                    {
                        if (arrTaxiXeDon[i] == arrTaxiXeNhan[j])
                        {
                            bCoXeDon = true; break;
                        }
                    }
                    if (!bCoXeDon) return false;
                }
                return bRet;
            }

            return false;
        }

        #endregion Validate du lieu

        private void editXeNhanDon_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void editXeNhanDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == 46)) && (!Char.IsWhiteSpace(e.KeyChar)))
            {

                e.Handled = false;

            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editXeNhanDon_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt) && (e.KeyCode == Keys.N))
            {
                maskXeNhan.Focus();
            }
        }


        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.No;
            this.g_FormValidate = true;

            string[] arrTaxi;
            DateTime timeServer = new DateTime();
            timeServer = this.g_TimeServer;
            if (timeServer == DateTime.MinValue)
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show("Không nhận được thời gian của tổng đài.");
                return;
            }

            string strXeNhanTruoc = mDieuHanhTaxi.XeNhan;

            #region Khong xe chuyen vung
            if (txtVungChuyen.Text.Length > 0)
            {
                int iVungChuyen = -1;  
                try { iVungChuyen = int.Parse(txtVungChuyen.Text); }
                catch (Exception xe) { iVungChuyen = -1; }
                if (iVungChuyen > 0)
                {

                    // kiem tra vung co nam trong vung hay khong
                    if (!CheckVungNamTrongVungCauHinh(iVungChuyen))
                    {
                        MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();
                        msg.Show("Vùng chuyển phải nằm trong các vùng bộ đàm đã cấu hình.");
                        g_FormValidate = false;
                        return;
                    }

                    if (DieuHanhTaxi.TongDai_ChuyenVung(mDieuHanhTaxi.ID_DieuHanh, iVungChuyen))
                    {
                        this.g_FormValidate = true;
                        this.DialogResult = DialogResult.No; 
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();
                        msg.Show("Có lỗi chuyển vùng.");
                    }
                }
            }
            #endregion Khong xe chuyen vung

            #region // CAP NHAT CHO TRUONG HOP NHAP DIA CHI TRA KHACH

            if (g_boolCapNhatDCTraKhach)
            {
                mDieuHanhTaxi.DiaChiTraKhach = editDiaChiTraKhach.Text; // Lay thong tin tu day
                if (chkSanBay.Checked) mDieuHanhTaxi.SanBay_DuongDai = "S";
                if (chkDuongDai.Checked) mDieuHanhTaxi.SanBay_DuongDai = "D";
                if (!(chkSanBay.Checked) && !(chkDuongDai.Checked)) mDieuHanhTaxi.SanBay_DuongDai = "N";

                 arrTaxi = mDieuHanhTaxi.XeDon.Split(".".ToCharArray());
                for (int i = 0; i < arrTaxi.Length; i++)
                {
                   
                     
                    KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                    if (KiemSoatXeLienLac.CheckXeDangHoatDong(arrTaxi[i].ToString ()))
                    {
                       
                        objKSXe.SoHieuXe = arrTaxi[i].ToString();
                        objKSXe.ThoiDiemBao = timeServer;
                        objKSXe.MaLaiXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(arrTaxi[i].ToString()).MaLaiXe;
                        objKSXe.ViTriDiemBao = mDieuHanhTaxi.DiaChiTraKhach;
                        objKSXe.ViTriDiemDen = mDieuHanhTaxi.DiaChiTraKhach ;
                        objKSXe.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoDiemCuaTrungTam_DCTraKhach   ;
                        
                        if(mDieuHanhTaxi.SanBay_DuongDai == "S")
                            objKSXe.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachSanBay ;
                        else if (mDieuHanhTaxi.SanBay_DuongDai == "D")
                            objKSXe.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachDuongDai;
                        else if (mDieuHanhTaxi.SanBay_DuongDai == "N")
                            objKSXe.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachNoiTinh ;

                        objKSXe.GhiChu = editGhiChu.Text;
                        objKSXe.IsHoatDong = true;
                        if (!objKSXe.InsertUpdate())
                        {
                            //  LogError.WriteLog("Loi luu xe don vao KiemSoat_LienLac", new Exception("Luu DB"));
                        }
                    }
                }
                if (g_CoThayDoiDuLieu)
                {
                    this.DialogResult = DialogResult.OK;
                   
                }
                this.Close();
                return;
            }
            //////////////////////////////////////////////////
            #endregion

            #region KhongXe
            // Neu la lenh tong dai = Khong xe (khong can nhap xe nhan)
            if (editLenhTongDai.Text.Contains("không xe"))
            {
                 // da nhap xe nhan, thi khong the nhap khong xe
                if (mDieuHanhTaxi.XeNhan.Length > 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show("Bạn đã nhập xe nhận, không thể nhập không xe.");
                    this.g_FormValidate = false;
                    return;
                }
                string strXeNhan = GetDSXeNhanDonChuan(maskXeNhan.TextBox.Text);
                 
                if (strXeNhan.Length > 0)
                {
                    if (CheckTrungLapXeChay(strXeNhan))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe taxi chạy chính xác");
                        this.g_FormValidate = false;
                        maskXeNhan.Focus();
                        return;
                    }
                      
                }

                string strXeDon = GetDSXeNhanDonChuan(maskXeDon.TextBox.Text);
                 
                if (strXeDon.Length > 0)
                {
                    if (CheckTrungLapXeChay(strXeDon))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe taxi chạy chính xác");
                        maskXeDon.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }
                 if ((strXeNhan.Length > 0) || (strXeDon.Length > 0))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn không được nhập xe nhận, xe đón - cho trường hợp không xe");
                        maskXeNhan.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
               
                mDieuHanhTaxi.LenhTongDai = editLenhTongDai.Text;
                if (mDieuHanhTaxi.LenhTongDai.Contains("không xe xin lỗi khách"))
                {
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach;
                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiKhongXe;
                }
                else
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.BoDam;  // chuyển vùng
                mDieuHanhTaxi.XeNhan = strXeNhan;
            }
            #endregion KhongXe

            #region MoiKhach
            else if (editLenhTongDai.Text.Contains("mời khách") || editLenhTongDai.Text.Contains("giữ khách"))
            {
                string strXeNhan = GetDSXeNhanDonChuan(maskXeNhan.TextBox.Text);
               
                if (strXeNhan.Length<=0)
                {
                    
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Phải có xe nhận mới được mời khách");
                        maskXeNhan.Focus();
                        this.g_FormValidate = false;
                        return;                  
                }
                string strXeDon = GetDSXeNhanDonChuan(maskXeDon.TextBox.Text);
                 
                if (strXeDon.Length > 0)
                {
                    // KIEM TRA XE DON có năm trong xe nhận không
                    if (!KiemTraXeDonCoNamTrongXeNhan(strXeNhan, strXeDon))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe đón nằm trong xe nhận.");
                        this.g_FormValidate = false;
                        return;
                    } 

                     mDieuHanhTaxi.XeDon = strXeDon;
                     mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;// ket thuc 
                     mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                }
                else
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.TongGuiSangMoiKhach;

                mDieuHanhTaxi.LenhTongDai =StringTools.TrimSpace ( editLenhTongDai.Text);
                
            }
            #endregion MoiKhach
            
            else
            {
                
                //Neu  co xe (co xe nhan)
                string strXeNhan = GetDSXeNhanDonChuan(maskXeNhan.TextBox.Text);                 
                if (strXeNhan.Length > 0)
                {
                    if (CheckTrungLapXeChay(strXeNhan))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe taxi chạy chính xác - bị trùng xe nhận.");
                        maskXeNhan.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                     
                }

                string strXeDon = GetDSXeNhanDonChuan(maskXeDon.TextBox.Text);
                
                // nhap xe don , chua co xe nhan
                if ((strXeDon.Length > 0) && (strXeNhan.Length<=0 ))
                {
                    
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe nhận.");
                        maskXeDon.Focus();
                        this.g_FormValidate = false;
                        return;

                }

                if (strXeDon.Length > 0)
                {
                    if (CheckTrungLapXeChay(strXeDon))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn phải nhập xe taxi chạy chính xác. Trùng xe đón.");
                        maskXeDon.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                    // check tồn tại
                    // Kiem tra nhap xe 999
                    if (strXeDon == "999" || strXeDon.EndsWith(".999") || strXeDon.Contains(".999."))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Bạn không được nhập xe 999. Chỉ vị trí mời khách mới được nhập.");
                        maskXeDon.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }
                if((strXeNhan.Length>0)&&(strXeDon.Length>0))
                {                	 
                    
                    if (!(CheckDulieu_XeChay(strXeNhan, strXeDon)))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show("Xe đón không có trong xe nhận.Bạn phải nhập xe taxi chạy chính xác");
                        maskXeDon.Focus();
                        this.g_FormValidate = false;
                        return;
                    }        
                   
                  // KIEM TRA XE DON có năm trong xe nhận không
                  if (!KiemTraXeDonCoNamTrongXeNhan(strXeNhan, strXeDon))
                  {
                      MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                      msgDialog.Show("Bạn phải nhập xe đón nằm trong xe nhận.");
                      this.g_FormValidate = false;
                      return;
                  } 
               }
               if (strXeDon.Length > 0)
               {                    
                    editGhiChu.Text = "";
                    editLenhTongDai.Text = "";                       
               }

                // Goi lai khi lenh dien thoai co goi lai
                //Kiem tra xe du lieu cu phan ghi chu co bi sua khong

                   //-- Kiem tra xe nhan va xe don da hoat dong chua
               if (strXeNhan.Length > 0)
               {
                   arrTaxi = strXeNhan.Split(".".ToCharArray());
                   if (arrTaxi != null)
                   {
                       // Kiem tra xe ton tai
                       for (int i = 0; i < arrTaxi.Length; i++)
                       {
                           if (!Xe.KiemTraTonTaiCuaSoHieuXe(arrTaxi[i]))
                           {
                               MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                               msgDialog.Show("Xe " + arrTaxi[i] + " chưa được nhập cần kiểm tra lại.");
                               this.g_FormValidate = false;
                               return;
                           }
                       }
                   }
                   
               }

               
               //    // Kiem tra xe nhan da co trong ds xe chua
               if (this.g_CoThayDoiDuLieu && strXeDon.Length <=0)
               {
                   string strDSXeNhanDaNhanDiem = KiemTraXeNhanDaNhanCuoc(mDieuHanhTaxi.ID_DieuHanh, strXeNhan);
                   if (strDSXeNhanDaNhanDiem.Length > 0)
                   {
                       MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                       if (msgDialog.Show(this, "Xe " + strDSXeNhanDaNhanDiem + " đang nhận điểm cần kiểm tra lại. Bạn có cho nhận điểm không?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OKCancel, Taxi.MessageBox.MessageBoxIcon.Question).ToString() == DialogResult.Cancel.ToString())
                       {
                           this.g_FormValidate = false;
                           return;
                       } 
                   }
               }
                
               //-- END--  Kiem tra xe nhan va xe don da hoat dong chua  ---
                mDieuHanhTaxi.XeNhan = strXeNhan;
                mDieuHanhTaxi.XeDon = strXeDon;
                mDieuHanhTaxi.LenhTongDai = editLenhTongDai.Text;
                mDieuHanhTaxi.GhiChuTongDai = lblGhiChuTongDai.Text; //editGhiChu.Text;
                mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.BoDam;
                
                // KHACH CO XE DON
                if (mDieuHanhTaxi.XeDon.Length > 0)
                {
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach;
                }
                // KHACH TRUOT
                if (mDieuHanhTaxi.GhiChuTongDai.Contains("trượt"))
                {
                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiTruot;
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;                  
                }
                //NHAN THONG TIN GOI LAI-->KETHUC
                if (mDieuHanhTaxi.GhiChuTongDai.Contains("gọi lại"))
                {
                    g_CoThayDoiDuLieu = true;
                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac ;
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                }

                // KHACH HOAN
                if (mDieuHanhTaxi.GhiChuTongDai.Contains("hoãn"))
                {

                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.CuocGoiHoan;
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                    
                }
                if (mDieuHanhTaxi.GhiChuTongDai.Contains("hỏi đàm"))
                {
                    mDieuHanhTaxi.TrangThaiCuocGoi = Taxi.Utils.TrangThaiCuocGoiTaxi.TrangThaiKhac;
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;                   
                }
               
                // Thiet lap thoi gian dieu xe
                if ((StringTools.TrimSpace(mDieuHanhTaxi.XeNhan).Length > 0)&&(mDieuHanhTaxi.ThoiGianDieuXe<=0))
                {                   
                    // Xu ly gio truot ngay
                    //timeServer 
                    TimeSpan  timeTemp = (timeServer - mDieuHanhTaxi.ThoiDiemGoi);
                    mDieuHanhTaxi.ThoiGianDieuXe = StringTools.GetSoGiayTuKhoangThoiGian(timeTemp);
                  
                }
                if ((StringTools.TrimSpace(mDieuHanhTaxi.XeNhan).Length > 0))
                {
                    // Ghi nhan trang thai cua xe
                    // cap nhật từng xe                    
                    arrTaxi = mDieuHanhTaxi.XeNhan.Split(".".ToCharArray());
                           
                    for (int i = 0; i < arrTaxi.Length; i++)
                    {
                         if(!strXeNhanTruoc.Contains (arrTaxi[i].ToString()))
                         {
                            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                            if (KiemSoatXeLienLac.CheckXeDangHoatDong(arrTaxi[i].ToString()))
                            {
                                objKSXe.SoHieuXe = arrTaxi[i].ToString();
                                objKSXe.ThoiDiemBao = timeServer;
                                objKSXe.MaLaiXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(arrTaxi[i].ToString()).MaLaiXe;
                                objKSXe.ViTriDiemBao = mDieuHanhTaxi.DiaChiDonKhach;
                                objKSXe.ViTriDiemDen = string.Empty;
                                objKSXe.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoDiemCuaTrungTam_NhanDiem;
                                objKSXe.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                                objKSXe.GhiChu = string.Empty;
                                objKSXe.IsHoatDong = true;
                                if (!objKSXe.InsertUpdate())
                                {
                                    //  LogError.WriteLog("Loi luu xe don vao KiemSoat_LienLac", new Exception("Luu DB"));
                                }
                             }
                         }
                    }
                }
                // Thiet lap thoi gian don khach
                if ((StringTools.TrimSpace(mDieuHanhTaxi.XeDon).Length > 0) && (mDieuHanhTaxi.ThoiGianDonKhach<=0))
                {
                     
                    TimeSpan timeTemp = (timeServer - mDieuHanhTaxi.ThoiDiemGoi);
                    mDieuHanhTaxi.ThoiGianDonKhach = StringTools.GetSoGiayTuKhoangThoiGian(timeTemp);


                    // Ghi nhan trang thai cua xe
                    // cap nhật từng xe                    
                    arrTaxi = mDieuHanhTaxi.XeDon .Split(".".ToCharArray());

                    for (int i = 0; i < arrTaxi.Length; i++)
                    {
                        
                               KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
                               objKSXe.SoHieuXe = arrTaxi[i].ToString();
                                objKSXe.ThoiDiemBao = timeServer;
                                objKSXe.MaLaiXe = KiemSoatXeLienLac.GetKSXe_BySoHieuXe(arrTaxi[i].ToString()).MaLaiXe;
                                objKSXe.ViTriDiemBao = mDieuHanhTaxi.DiaChiDonKhach;
                                objKSXe.ViTriDiemDen = string.Empty;
                                objKSXe.TrangThaiLaiXeBao = Taxi.Utils.KieuLaiXeBao.BaoDiemCuaTrungTam_DonKhach  ;
                                objKSXe.LoaiChoKhach = Taxi.Utils.LoaiChoKhach.ChoKhachNoiTinh;
                                objKSXe.GhiChu = string.Empty;
                                objKSXe.IsHoatDong = true;
                               
                                if (!objKSXe.InsertUpdate())
                                {
                                    //  LogError.WriteLog("Loi luu xe don vao KiemSoat_LienLac", new Exception("Luu DB"));
                                }
                             
                    }
                }  
            }
            this.g_FormValidate = true;
            if (g_CoThayDoiDuLieu)
            {
                this.DialogResult = DialogResult.OK;
 
            }
            this.Close();
        }

        /// <summary>
        /// Hàm trả về ds xe nhận hoặc xe đón chuẩn '23.234.4322.32' 
        /// (loại bỏ các dấu chấmở đầu và ở cuối)
        /// 
        /// </summary>
        /// <param name="Xe"></param>
        /// <returns></returns>
        private string GetDSXeNhanDonChuan(string DSXe)
        {
            string strXe  = StringTools.TrimSpace(DSXe);
            while ((strXe.Length > 0) && (strXe[0].ToString() == "."))
            {
                strXe = strXe.Substring(1, strXe.Length - 1);
            }
            while ((strXe.Length > 0) && (strXe[strXe.Length - 1].ToString() == "."))
            {
                strXe = strXe.Substring(0, strXe.Length - 1);
            }
            return strXe;
        }


        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length > 0)
            {
                string[] arrVung = ThongTinCauHinh.CacVungTongDai.Split(";".ToCharArray());
                for (int i = 0; i < arrVung.Length; i++)
                {
                    if (Convert.ToInt32(arrVung[i]) == Vung)
                    {
                        bCheck = true; break;
                    }
                }
            }
            else bCheck = false;
            return bCheck;
        }
        
        
        /// <summary>
        /// ham tra ve ds xe nhan da nhan diem truoc day
        /// input : 123.546.897
        /// ouptpt: 123
        /// </summary>
        /// <param name="strXeNhan"></param>
        /// <returns></returns>
        private string  KiemTraXeNhanDaNhanCuoc(long IDCuocKhach,string strXeNhan)
        {
              if (strXeNhan.Length <= 0) return strXeNhan;
            DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
            string strDSXeNhanDaNhanDiem = "";
            string[] arrTaxi = strXeNhan.Split(".".ToCharArray());
            string SQLCondition = " AND  (len(XeNhan)>0) AND (ID <> " + IDCuocKhach.ToString() +" ) ";
             
            List<DieuHanhTaxi>  lstDienThoai = objDHTaxi.GetAllOf_DienThoai(SQLCondition);
            if (lstDienThoai != null && lstDienThoai.Count > 0)
            {
                for (int i = 0; i < arrTaxi.Length; i++)
                {
                    if (KiemTraXeCoTrongCuocKhachHienTai(lstDienThoai, arrTaxi[i]))
                        strDSXeNhanDaNhanDiem += arrTaxi[i].ToString() + ".";
                }
            }
             return strDSXeNhanDaNhanDiem;
        }
  /// <summary>
        /// kiem tra xe da co trong ds chua
        /// </summary>
        /// <param name="lstDienThoai"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns></returns>
        private bool KiemTraXeCoTrongCuocKhachHienTai(List<DieuHanhTaxi> lstDienThoai, string SoHieuXe)
        { 
            foreach (DieuHanhTaxi objDH in lstDienThoai)
            {
                if (objDH.XeNhan.Length > 0)
                {
                    string[] arrXeDaNhan = objDH.XeNhan.Split(".".ToCharArray());
                    for (int i = 0; i < arrXeDaNhan.Length; i++)
                        if (arrXeDaNhan[i] == SoHieuXe)
                            return true;
                }
            }
            return false;
        }


        private void editLenhTongDai_TextChanged(object sender, EventArgs e)
        {
            if (editLenhTongDai.Text != "không xe chuyển vùng")
            {
                txtVungChuyen.Visible = false;
                txtVungChuyen.Text = "";
                lblVungChuyen.Visible = false;
            }
            if (StringTools.TrimSpace(editLenhTongDai.Text).Contains ("1")) // moi khach
            {
                if (!(mDieuHanhTaxi.XeNhan .Length >0))
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show("Bạn không thể nhập mời khách, khi chưa có xe nhận");
                    editLenhTongDai.Text = string.Empty;
                    return;
                }
                editLenhTongDai.Text = "mời khách";
            }
            else if (StringTools.TrimSpace(editLenhTongDai.Text).Contains ("2")) // Giữ khách
            {

                editLenhTongDai.Text = "giữ khách";
            }

            else if (StringTools.TrimSpace(editLenhTongDai.Text).Contains("3")) //"không xe chuyển vùng";
            {
                string strXeNhan = GetDSXeNhanDonChuan(maskXeNhan.TextBox.Text);
                
                if (strXeNhan.Length > 0)
                {                 
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show("Bạn không thể nhập không xe chuyển vùng, khi đã có xe nhận.");
                    editLenhTongDai.Text = string.Empty;
                    return;
                }
                else
                {
                    editLenhTongDai.Text = "không xe chuyển vùng";
                    txtVungChuyen.Visible = true;
                    lblVungChuyen.Visible = true;
                    txtVungChuyen.Focus();
                     
                }
            }
            else if (StringTools.TrimSpace(editLenhTongDai.Text).Contains("4")) //"không xe xin lỗi khách";
            {

                editLenhTongDai.Text = "không xe xin lỗi khách";
            }
            g_CoThayDoiDuLieu = true;
        }

        private void editGhiChu_TextChanged(object sender, EventArgs e)
        {
            if (g_boolCapNhatDCTraKhach) return;


            //(1-Gọi lại, 2-Hoãn, 3-Trượt)
            if (StringTools.TrimSpace(editGhiChu.Text).Contains ("1")) // moi khach
            {
                if (!mDieuHanhTaxi.LenhDienThoai.Contains("gọi lại"))
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show("Bạn không thể nhập gọi lại, khi chưa có lệnh điện thoại gọi lại");
                    editGhiChu.Text = string.Empty; lblGhiChuTongDai.Text = "";
                    return;
                }
                g_intGoilaiHoanTruot = 1;
                
               //[ editGhiChu.Text = "gọi lại";]
                lblGhiChuTongDai.Text = "gọi lại"; 

            }
            if (StringTools.TrimSpace(editGhiChu.Text).Contains("2")) // moi khach
            {
                if (!mDieuHanhTaxi.LenhDienThoai.Contains("hoãn"))
                {
                    //MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    //msgDialog.Show("Bạn không thể nhập hoãn, khi chưa có lệnh điện thoại hoãn");
                    //editGhiChu.Text = string.Empty; lblGhiChuTongDai.Text = "";
                    //return;
                }
                mDieuHanhTaxi.LenhDienThoai = "hoãn";

                g_intGoilaiHoanTruot = 2;
                //[editGhiChu.Text = "hoãn"; ]
                lblGhiChuTongDai.Text = "hoãn";
            }
            if (StringTools.TrimSpace(editGhiChu.Text).Contains ("3")) // moi khach
            {
                if (!(mDieuHanhTaxi.XeNhan.Length >0))
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show("Bạn không thể nhập trượt, khi chưa có khi chưa có xe nhận");
                    editGhiChu.Text = string.Empty; lblGhiChuTongDai.Text = "";
                    return;
                }
                g_intGoilaiHoanTruot = 3;
                
                lblGhiChuTongDai.Text = "trượt";
            }
            if (StringTools.TrimSpace(editGhiChu.Text).Contains("4")) // Hỏi đàm
            {
                if (mDieuHanhTaxi.KieuCuocGoi == Taxi.Utils.KieuCuocGoi.GoiHoiDam)
                {
                    mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.KetThuc;
                    lblGhiChuTongDai.Text = "hỏi đàm";
                }
                else lblGhiChuTongDai.Text = "";
            }
            g_CoThayDoiDuLieu = true;
        }

        /// <summary>
        /// Input :
        ///     - SoXeDon : 2  
        ///     - XeDon : 123.356
        /// Output :
        ///     - True if la dung
        ///     - False if la sai
        /// </summary>
        /// <param name="SoXeDon"></param>
        /// <param name="XeDon"></param>
        /// <returns></returns>        
         private bool CheckSoXeDonVoiXeDon(int SoXeDon, string XeDon)
        {
            int intSoXe = 0;           
            
            string[] arrXeDons = XeDon.Split(".".ToCharArray() );
            intSoXe = arrXeDons.Length;
            
            if (SoXeDon == intSoXe)
                return true;
            else return false;
        }

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.g_FormValidate = false;
                this.g_FormHuyBo = true;               
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.N))
            {
                maskXeNhan.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.X))
            {
                maskXeDon.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.L))
            {
                editLenhTongDai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.G))
            {
                editGhiChu.Focus();
                return true;
            }
            else if (keyData == Keys.F5)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if(objT!=null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 1).ShowDialog();
            }
            else if (keyData == Keys.F6)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 2).ShowDialog();
            }
            else if (keyData == Keys.F7)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT,3).ShowDialog();
            }
            else if (keyData == Keys.F8)
            {
                object objT = DieuHanhTaxi.GetFormGiamSatXe();
                if (objT != null)
                    new frmRaHoatDong((frmGiamSatXe)objT, 4).ShowDialog();
            }
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                this.btnOK_Click(null, null);
                if(this.DialogResult!= DialogResult.No)
                    this.DialogResult = DialogResult.OK;
                this.Close(); return true;
            }
            return false;
        }
        #endregion XU LY HOTKEY

        private void maskXeNhan_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        /// <summary>
        /// kiem soat nhap phim 1;2;3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (g_boolCapNhatDCTraKhach) return;
            if ((e.KeyChar == (char)Keys.D1) || (e.KeyChar == (char)Keys.D2) || (e.KeyChar == (char)Keys.D3) || (e.KeyChar == (char)Keys.D4))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        //private void editGhiChu_Validating(object sender, CancelEventArgs e)
        //{
        //    //if (g_boolCapNhatDCTraKhach) return;
        //    //e.Cancel = false;
        //    //if (g_intGoilaiHoanTruot == 1)//goi lai
        //    //{
        //    //    if (editGhiChu.Text != "gọi lại")
        //    //    {
        //    //        e.Cancel = true  ;
        //    //        errorProvider.SetError(editGhiChu, "Bạn không được sửa thông tin");
                    
        //    //    }
        //    //}
        //    //else if (g_intGoilaiHoanTruot == 2)//goi lai
        //    //{
        //    //    if (editGhiChu.Text != "hoãn")
        //    //    {
        //    //        e.Cancel = true  ;
        //    //        errorProvider.SetError(editGhiChu, "Bạn không được sửa thông tin");
                    
        //    //    }
        //    //}
        //    //else if (g_intGoilaiHoanTruot == 3)//goi lai
        //    //{
        //    //    if (editGhiChu.Text != "trượt")
        //    //    {
        //    //        e.Cancel = true  ;
        //    //        errorProvider.SetError(editGhiChu, "Bạn không được sửa thông tin");
                    
        //    //    }
        //    //}
        //    //if (!e.Cancel)
        //    //{
        //    //    e.Cancel = false;
        //    //    errorProvider.SetError(editGhiChu, "");
        //    //}
        //    //return;
        //}

        private void maskXeNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (g_boolCapNhatDCTraKhach) return;
            int ascii = Convert.ToInt16(e.KeyChar);
            if (char.IsDigit(e.KeyChar) || (e.KeyChar==(char)Keys.Back ) || (ascii == 46)) // dau cham "."
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void chkSanBay_CheckedChanged(object sender, EventArgs e)
        {
            if((chkSanBay.Checked)&&(chkDuongDai.Checked))
                chkDuongDai.Checked = !chkSanBay.Checked; 
        }

        private void chkDuongDai_CheckedChanged(object sender, EventArgs e)
        {
            if ((chkSanBay.Checked) && (chkDuongDai.Checked))
                chkSanBay.Checked = !chkDuongDai.Checked;
            g_CoThayDoiDuLieu = true;
        }

        private void maskXeNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (maskXeDon.Visible) maskXeDon.Focus();
                else editLenhTongDai.Focus();
            }
        }

        private void maskXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }       
        
            if (e.KeyCode == Keys.Up)
            {
                maskXeNhan.Focus();
                maskXeNhan.TextBox.SelectionStart = maskXeNhan.TextBox.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhTongDai.Focus();
            }
        
        }

        private void editLenhTongDai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                if (maskXeDon.Visible) maskXeDon.Focus();
                else maskXeNhan.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editGhiChu .Focus();
            }
        }

        private void editDiaChiTraKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }
        }

        private void editGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                editLenhTongDai  .Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }

        private bool CheckTonTaiXeNhan(string DSXeNhan)
        {
            bool bTonTaiXe = false;
            string[] arrTaxi = DSXeNhan.Split(".".ToCharArray());

            for (int i = 0; i < arrTaxi.Length; i++)
            {
                if (DSXeNhanDangHoatDong.Contains(arrTaxi[i])){ bTonTaiXe = true;break;}
            }
            return bTonTaiXe ;
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.g_FormValidate = false;
            this.g_FormHuyBo = true;
            this.Close();
        }

        private void frmBodamInputData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (g_FormValidate || g_FormHuyBo)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void maskXeDon_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void txtVungChuyen_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void editDiaChiTraKhach_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void chkSanBay_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        /// <summary>
        /// hàm xử lý kết thúc cuốc khách này ngày
        /// đặt cuộc khách kiểu cuốc khách là Cuộc gọi Taxi
        /// TrangThaiCuocGoi - khong xác định : TrangThaiKhac
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTaxiGroupDon_CheckedChanged(object sender, EventArgs e)
        { 

            if (chkTaxiGroupDon.Checked)
            {
                if (mDieuHanhTaxi.XeNhan != null && mDieuHanhTaxi.XeNhan.Length > 0)
                {
                    g_FormValidate = true;
                    this.g_CoThayDoiDuLieu = true;
                    this.DialogResult = DialogResult.Ignore;
                    this.Close();
                }
                else chkTaxiGroupDon.Checked = false;
            }
        }

        
    }
}