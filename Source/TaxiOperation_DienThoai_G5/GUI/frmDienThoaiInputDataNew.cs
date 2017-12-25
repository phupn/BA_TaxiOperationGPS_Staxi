using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using Taxi.Business.ThongTinPhanAnh;

namespace Taxi.GUI
{
    public partial class frmDienThoaiInputDataNew : Form
    {
        private DieuHanhTaxi mDieuHanhTaxi = new DieuHanhTaxi();
       // private bool gGoiLai = false;
        private bool g_boolIsTrungSoDienThoaiDangGiaiQuyen;
        private bool  g_FormValidate = false;
        private bool g_FormHuyBo = false;
        private bool g_CoThayDoiDuLieu = false;
        private DieuHanhTaxi gDieuHanhGoiLai = new DieuHanhTaxi();

        public DieuHanhTaxi GetDieuHanhTaxi
        {
            get {
                  
                return mDieuHanhTaxi; }
            //  set { mDieuHanhTaxi = value; }
        }
        private int gLen = 0;
        public frmDienThoaiInputDataNew()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// </summary>
        /// <param name="DieuHanhTaxi"></param>
        public frmDienThoaiInputDataNew(DieuHanhTaxi _DieuHanhTaxi, bool boolIsTrungSoDienThoaiDangGiaiQuyen)
        {
            InitializeComponent();
            mDieuHanhTaxi = _DieuHanhTaxi;
            g_boolIsTrungSoDienThoaiDangGiaiQuyen = boolIsTrungSoDienThoaiDangGiaiQuyen;

        }
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        { 
            this.SetData2Form();
            if (mDieuHanhTaxi.TrangThaiLenh == Taxi.Utils.TrangThaiLenhTaxi.KhongTruyenDi &&  mDieuHanhTaxi.CuocGoiLaiIDs != null && mDieuHanhTaxi.CuocGoiLaiIDs.Length > 0)
            {
                chkGoiLai.Checked = true;
            }
            g_CoThayDoiDuLieu = false;
            txtDiaChiDonKhach.Focus();
            g_CoThayDoiDuLieu = false;  // chưa có thay đổi dữ liệu.
            if ((chkGoiTaxi.Checked == false) && (chkGoiLai.Checked == false) && (chkGoiKhac.Checked == false) && chkGoiKhieuNai.Checked ==false )
            {//Thiet lap mac dinh
                chkGoiTaxi.Checked = true;
                editSoLuongXe.TextBox.Text   = "1";
                if(mDieuHanhTaxi.MaVung.Length <= 0) editVung.TextBox.Text = GetVungMacDinh();
                chkXe4.Checked = false ;
                chkXe7.Checked = false;                
            }
            txtDiaChiDonKhach.SelectionStart = txtDiaChiDonKhach.Text.Length;
        }

        private string GetVungMacDinh()
        {
            if (ThongTinCauHinh.CacVungTongDai != null && ThongTinCauHinh.CacVungTongDai.Length == 1)
                return ThongTinCauHinh.CacVungTongDai;
            else
                return "";
        }
        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mDieuHanhTaxi != null)
            {
                // line + phone + time

                lblInfo.Text = "[ " + mDieuHanhTaxi.Line + " ]  " + mDieuHanhTaxi.PhoneNumber + "  " + mDieuHanhTaxi.ThoiDiemGoiGio;
                chkGoiTaxi.Checked = mDieuHanhTaxi.GoiTaxi;
                chkGoiLai.Checked = mDieuHanhTaxi.GoiLai;
                chkGoiKhac.Checked = mDieuHanhTaxi.ThongTinKhac;
                chkGoiKhieuNai.Checked = mDieuHanhTaxi.GoiKhieuNai;
                // set default 
              
                txtDiaChiDonKhach.Text = mDieuHanhTaxi.DiaChiDonKhach;
                if (mDieuHanhTaxi.LoaiXe.Contains("0")) chkXeKhongChon.Checked = true;
                else if (mDieuHanhTaxi.LoaiXe.Contains("4  chỗ")) chkXe4.Checked = true;                 
                else if (mDieuHanhTaxi.LoaiXe.Contains("7  chỗ")) { chkXe7.Checked = true; }
                
                editSoLuongXe.TextBox.Text  = mDieuHanhTaxi.SoLuong;
                editVung.TextBox.Text = mDieuHanhTaxi.MaVung;                

              //  chkSanBayDuongDai.Checked = mDieuHanhTaxi.SanBay_DuongDai;
                editLenhDienThoai.Text = mDieuHanhTaxi.LenhDienThoai;
                editGhiChu.Text = mDieuHanhTaxi.GhiChuDienThoai;
            }
        }
        /// <summary>
        /// lay du lieu tra form gan vao cho doi tuong mDieuHanhTaxi
        /// </summary>
        private void GetData2Form()
        {
             mDieuHanhTaxi.GoiTaxi=chkGoiTaxi .Checked ;
             mDieuHanhTaxi.GoiLai = chkGoiLai.Checked ;
             mDieuHanhTaxi.ThongTinKhac=chkGoiKhac.Checked ;
             mDieuHanhTaxi.GoiKhieuNai = chkGoiKhieuNai.Checked;
             if (mDieuHanhTaxi.GoiKhieuNai) mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach;
             mDieuHanhTaxi.DiaChiDonKhach = StringTools.TrimSpace( txtDiaChiDonKhach.Text);
            

            if (chkXe4.Checked == true) { mDieuHanhTaxi.LoaiXe = "4  chỗ"; mDieuHanhTaxi.ChonTaxi4Cho = true; }
            if (chkXe7.Checked == true) { mDieuHanhTaxi.LoaiXe = "7  chỗ"; mDieuHanhTaxi.ChonTaxi7Cho = true; }
            if (chkXeKhongChon .Checked == true ) mDieuHanhTaxi.LoaiXe = "0";
            
           // if(StringTools.TrimSpace (editSoLuongXe.Text).Length>0)
                mDieuHanhTaxi.SoLuong= editSoLuongXe.Text;
           // if (StringTools.TrimSpace(editVung.Text).Length > 0)
            mDieuHanhTaxi.MaVung =editVung.Text;
            if (mDieuHanhTaxi.MaVung == "11" && !mDieuHanhTaxi.GoiKhieuNai)
            {
                mDieuHanhTaxi.GoiKhieuNai = true;
                mDieuHanhTaxi.TrangThaiLenh = Taxi.Utils.TrangThaiLenhTaxi.DienThoaiGuiSangMoiKhach;
            }
            if (mDieuHanhTaxi.GoiKhieuNai && mDieuHanhTaxi.MaVung != "11")
            {
                mDieuHanhTaxi.MaVung = "11";
            }


           // mDieuHanhTaxi.SanBay_DuongDai= chkSanBayDuongDai.Checked;
                if (mDieuHanhTaxi.ThoiDiemChuyenTongDai == 0)// chua cap nhat thoi gian.
                {
                    TimeSpan timeTemp = ( DieuHanhTaxi.GetTimeServer() - mDieuHanhTaxi.ThoiDiemGoi);
                    mDieuHanhTaxi.ThoiDiemChuyenTongDai = StringTools.GetSoGiayTuKhoangThoiGian(timeTemp); //

                }

            mDieuHanhTaxi.GhiChuDienThoai = StringTools.TrimSpace( editGhiChu.Text);
            mDieuHanhTaxi.LenhDienThoai = editLenhDienThoai.Text;
            
        }
      

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.g_FormValidate = true;
            // check da chon loai cuoc goi chua
            if ((chkGoiTaxi.Checked == false) && (chkGoiLai.Checked == false) && (chkGoiKhac.Checked == false) && (chkGoiKhieuNai.Checked==false ) && (chkHoiDam.Checked==false) &&(!chkGoiDichVu.Checked) )
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải chọn loại cuộc gọi [Gọi taxi],[Gọi lại],[Gọi khiếu nại],[Gọi d.vụ],[Gọi khác].", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                this.g_FormValidate = false;
                return;
            }
            int Vung = 0;
            #region GoiTaxi
            // check cuốc khách taxi

            if (chkGoiTaxi.Checked)
            {               
                // check nhap thongtin dia chi
                if (StringTools.TrimSpace(txtDiaChiDonKhach.Text).Length <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập địa chỉ đón khách.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    txtDiaChiDonKhach.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                // check chon loai xe , bat buoc phai chon lai xe
                if (chkXe4.Checked == false && chkXe7.Checked == false && chkXeKhongChon.Checked == false )
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải chọn loại xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    chkXe4.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                int SoXe = 0;
                if (StringTools.TrimSpace(editSoLuongXe.Text).Length > 0)
                    SoXe = int.Parse(editSoLuongXe.Text);
                if (SoXe <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập số lượng xe đón khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editSoLuongXe.Focus();
                    this.g_FormValidate = false;
                    return;
                }

                
                if (StringTools.TrimSpace(editVung.Text).Length > 0 && editVung.Text !="_")
                {
                    try
                    {
                        Vung = int.Parse(editVung.Text.Replace("_",""));
                    }
                    catch (Exception ex)
                    {
                        Vung = 0;
                    }
                }
                if (Vung <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập vùng đón khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editVung.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                else // check ton tai vung trong vung cai hinh
                {
                    if (!CheckVungNamTrongVungCauHinh(Vung))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Bạn phải nhập vùng đón khách thuộc vùng cấu hình.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        editVung.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }
                
                // Kiểm tra nếu có CuocGoiLaiIDs >0 --> thi set lại để không phải là cuộc gọi lại
                if(mDieuHanhTaxi.CuocGoiLaiIDs!=null &&  mDieuHanhTaxi.CuocGoiLaiIDs.Length >0)
                {
                    mDieuHanhTaxi.CuocGoiLaiIDs ="";
                }
            }
            #endregion GoiTaxi

            #region GoiKhac

            if (chkGoiKhac.Checked)
            {
                
                if (mDieuHanhTaxi.GoiTaxi || mDieuHanhTaxi.GoiLai || mDieuHanhTaxi.GoiKhieuNai)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn bạn không thể chuyển sang cuộc gọi khác.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error );
                    this.g_FormValidate = false;
                    return;
                }

                // Check xem so dien thoai nay da ton tai trong danh sach chua,
                // neu ton tai thi cảnh báo là cuộc gọi  lai hay gọi khác
                if (g_boolIsTrungSoDienThoaiDangGiaiQuyen)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    if (msgDialog.Show(this, "Bạn kiểm tra lại cuộc gọi này là cuộc gọi lại, hay gọi khác. Là cuộc gọi khác?", "Thông báo", Taxi.MessageBox.MessageBoxButtons.YesNo, Taxi.MessageBox.MessageBoxIcon.Warning) == DialogResult.Yes.ToString())
                    {// dung la dcuo goi lai
                        this.g_FormValidate = true ; 
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.g_FormValidate = false;
                        return;
                    }
                }

                // check nhap thongtin dia chi
                if (StringTools.TrimSpace(txtDiaChiDonKhach.Text).Length <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập thông tin cuộc gọi khác vào trường địa chỉ. Mục đích tra cứu lại thông tin bạn đã xử lý.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    txtDiaChiDonKhach.Focus();
                    this.g_FormValidate = false;
                    return;
                }
            }

            #endregion GoiKhac

            #region GoiLai
            // neu la goi lai
            if (chkGoiLai.Checked)
            {
                if (mDieuHanhTaxi.XeNhan.Length > 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải gửi lệnh yêu cầu tổng đài xóa thông tin xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editLenhDienThoai.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                mDieuHanhTaxi.LenhDienThoai = "khách gọi lại";
                mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiLai;
                
                if (StringTools.TrimSpace(editVung.Text).Length > 0 && editVung.Text != "_")
                {
                    try
                    {
                        Vung = int.Parse(editVung.Text.Replace("_", ""));
                    }
                    catch (Exception ex)
                    {
                        Vung = 0;
                    }
                }
                if (Vung <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập vùng đón khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editVung.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                else // check ton tai vung trong vung cai hinh
                {
                    if (!CheckVungNamTrongVungCauHinh(Vung))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Bạn phải nhập vùng đón khách thuộc vùng cấu hình.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        editVung.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }

            }

            #endregion GoiLai

            #region GoiKhieuNai
            if (chkGoiKhieuNai.Checked)
            {
                // check nhap thongtin dia chi
                if (StringTools.TrimSpace(txtDiaChiDonKhach.Text).Length <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập thông tin khách khiếu nại vào trường địa chỉ.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    txtDiaChiDonKhach.Focus();
                    this.g_FormValidate = false;
                    return;
                }

                if (StringTools.TrimSpace(editVung.Text).Length > 0 && editVung.Text != "_")
                {
                    try
                    {
                        Vung = int.Parse(editVung.Text.Replace("_", ""));
                    }
                    catch (Exception ex)
                    {
                        Vung = 0;
                    }
                }
                if (Vung <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập vùng đón khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editVung.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                else // check ton tai vung trong vung cai hinh
                {
                    if (!CheckVungNamTrongVungCauHinh(Vung))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Bạn phải nhập vùng đón khách thuộc vùng cấu hình.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        editVung.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }
            }
             
            #endregion

            #region GoiDichVu
             
            if (chkGoiDichVu.Checked || chkHoiDam.Checked)
            {
                if (StringTools.TrimSpace(editVung.Text).Length > 0 && editVung.Text != "_")
                {
                    try
                    {
                        Vung = int.Parse(editVung.Text.Replace("_", ""));
                    }
                    catch (Exception ex)
                    {
                        Vung = 0;
                    }
                }
                if (Vung <= 0)
                {
                    MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                    msgDialog.Show(this, "Bạn phải nhập vùng đón khách", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                    editVung.Focus();
                    this.g_FormValidate = false;
                    return;
                }
                else // check ton tai vung trong vung cai hinh
                {
                    if (!CheckVungNamTrongVungCauHinh(Vung))
                    {
                        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                        msgDialog.Show(this, "Bạn phải nhập vùng đón khách thuộc vùng cấu hình.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                        editVung.Focus();
                        this.g_FormValidate = false;
                        return;
                    }
                }
                if (chkHoiDam.Checked) mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiHoiDam;
                else if (chkGoiDichVu.Checked) mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiDichVu;
            }
            #endregion

            
            this.g_FormValidate = true ;
            if (g_CoThayDoiDuLieu)
            {
                this.GetData2Form();
                this.DialogResult = DialogResult.OK; 
            }
            this.Close();
        }
        /// <summary>
        /// check vung nhan năm trong vùng cấu hình.
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private bool CheckVungNamTrongVungCauHinh(int Vung)
        {
            bool bCheck = false;
            if(ThongTinCauHinh.CacVungTongDai!= null && ThongTinCauHinh.CacVungTongDai.Length >0)
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
            else bCheck = false ;
            return bCheck;
        } 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            g_FormHuyBo = true;
            this.DialogResult = DialogResult.Cancel;
           
        }

        //private void btnDanhSachCuocGoi_Click(object sender, EventArgs e)
        //    {
                
                
        //        frmListCalls frmListCalls = new frmListCalls(this.mDieuHanhTaxi.ID_DieuHanh);
        //        if (frmListCalls.ShowDialog(this) == DialogResult.OK)
        //        {
        //            if (frmListCalls.DieuHanhTaxiChon != null)
        //            {   
        //                gGoiLai = true;
        //                gDieuHanhGoiLai = frmListCalls.DieuHanhTaxiChon;
        //                // thiet lap gia tri len form

        //            }
        //        }
        //        else
        //        {
        //            gGoiLai = false;
        //        }

        //        if (gGoiLai)
        //        {
        //            txtDiaChiDonKhach.Text = gDieuHanhGoiLai.DiaChiDonKhach;
        //            editVung.TextBox.Text = gDieuHanhGoiLai.MaVung.ToString();
        //            this.mDieuHanhTaxi.DiaChiDonKhach = gDieuHanhGoiLai.DiaChiDonKhach;
        //            this.mDieuHanhTaxi.MaVung = gDieuHanhGoiLai.MaVung;
        //            this.mDieuHanhTaxi.CuocGoiLaiIDs = gDieuHanhGoiLai.ID_DieuHanh + ";" + this.mDieuHanhTaxi.CuocGoiLaiIDs;
        //        }
        //    }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            if(chkGoiTaxi.Checked)
            {
                chkGoiLai.Checked=false;
                chkGoiKhieuNai.Checked  = false;               
                chkHoiDam.Checked = false;
                chkGoiDichVu.Checked = false;
                chkGoiKhac.Checked = false;

                mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiTaxi;

            }
         
            txtDiaChiDonKhach.Enabled = chkGoiTaxi.Checked;
            chkXe4.Enabled = chkGoiTaxi.Checked;
            chkXe7.Enabled = chkGoiTaxi.Checked;
            editSoLuongXe.Enabled = chkGoiTaxi.Checked;
            editVung.Enabled = chkGoiTaxi.Checked;
            editLenhDienThoai.Enabled = chkGoiTaxi.Checked;
            editGhiChu.Enabled = chkGoiTaxi.Checked;

            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
           
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
            {
                if (chkGoiLai.Checked)
                {                  
                        chkGoiTaxi.Checked = false;
                        chkGoiKhieuNai.Checked = false;
                        chkGoiKhac.Checked = false;
                        chkHoiDam.Checked = false;
                        chkGoiDichVu.Checked = false; 
                         
                        editLenhDienThoai.Text = "khách gọi lại";
                        editLenhDienThoai.Enabled = true;
                        //Thiet lap cac con control khac
                        chkXe4.Enabled = false;
                        chkXe7.Enabled = false;
                        editSoLuongXe.TextBox.Text = string.Empty;
                        editVung.Enabled = true;
                        if(mDieuHanhTaxi.MaVung !=null && mDieuHanhTaxi.MaVung.Length >0)
                            editVung.TextBox.Text = mDieuHanhTaxi.MaVung;
                        else
                            editVung.TextBox.Text = "";
                        txtDiaChiDonKhach.Enabled = true;

                        mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiLai;
                        editSoLuongXe.TextBox.Text = "0";
                }
                else
                {
                    
                    editLenhDienThoai.Text = "";
                }
                
                chkXe4.Enabled = !chkGoiLai.Checked;
                chkXe7.Enabled = !chkGoiLai.Checked;
                editSoLuongXe.Enabled = !chkGoiLai.Checked; 
                editGhiChu.Enabled = !chkGoiLai.Checked;
                g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            }
        private void chkGoiKhieuNai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGoiKhieuNai.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhac.Checked = false;
                chkHoiDam.Checked = false;
                chkGoiDichVu.Checked = false;

                chkXe4.Enabled = false;
                chkXe7.Enabled = false;
                editSoLuongXe.TextBox.Text = string.Empty;
                editSoLuongXe.Enabled = false;
                editVung.Enabled = true;
                editVung.TextBox.Text = "11"; //vùng nhận phàn nàn về chất lượng dịch vụ
                txtDiaChiDonKhach.Enabled = true;
                editGhiChu.Enabled = false;
                mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiKhieuNai;
                g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            }
            else
            {
                editVung.TextBox.Text = "";
            }
        }
        /// <summary>
        /// thông tin dịch vụ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGoiDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGoiDichVu.Checked)
            {
                chkGoiTaxi.Checked = false;
                chkGoiLai.Checked = false;
                chkGoiKhac.Checked = false;
                chkHoiDam.Checked = false;
                chkGoiKhieuNai .Checked = false;
                editSoLuongXe.TextBox.Text = string.Empty;
                editSoLuongXe.Enabled = false;
                editVung.Enabled = true;
                chkXe4.Enabled = false;
                chkXe7.Enabled = false;
                txtDiaChiDonKhach.Enabled = true;
                editGhiChu.Enabled = false;
                mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiDichVu;
                g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            }
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
            {
                if(chkGoiKhac.Checked)
                {
                    chkGoiLai.Checked=false;
                    chkGoiTaxi.Checked=false;
                    chkGoiKhieuNai.Checked = false;
                    chkHoiDam.Checked = false;
                    chkGoiDichVu.Checked = false;

                    mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiKhac;
                     
                }
                txtDiaChiDonKhach.Enabled = chkGoiKhac.Checked;
                chkXe4.Enabled = !chkGoiKhac.Checked;
                chkXe7.Enabled = !chkGoiKhac.Checked;
                editSoLuongXe.Enabled = !chkGoiKhac.Checked;
                editVung.Enabled = !chkGoiKhac.Checked;
                editLenhDienThoai.Enabled = !chkGoiKhac.Checked;

                editGhiChu.Enabled = !chkGoiKhac.Checked;
                g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            }
        private void chkLaiXeBao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHoiDam.Checked)
            {
                chkGoiLai.Checked = false;
                chkGoiKhieuNai.Checked = false;
                chkGoiKhac.Checked = false;
                chkGoiTaxi.Checked = false;
                chkGoiDichVu.Checked = false;
                
                txtDiaChiDonKhach.Enabled = chkHoiDam.Checked;
                chkXe4.Enabled = chkHoiDam.Checked;
                chkXe7.Enabled = chkHoiDam.Checked;
                editSoLuongXe.Enabled = chkHoiDam.Checked;
                editVung.Enabled = chkHoiDam.Checked;
                editLenhDienThoai.Enabled = chkHoiDam.Checked;
                editGhiChu.Enabled = chkHoiDam.Checked;
                mDieuHanhTaxi.KieuCuocGoi = Taxi.Utils.KieuCuocGoi.GoiHoiDam;
                g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            }

        }
        private void editLenhDienThoai_TextChanged(object sender, EventArgs e)
        { 
             if (StringTools.TrimSpace(editLenhDienThoai.Text).Contains ("3"))
             {
                editLenhDienThoai.Text = "khách hẹn";
             }
            
            //    this.GetData2Form();

            //    frmDienThoaiHenKhach frm = new frmDienThoaiHenKhach(mDieuHanhTaxi );
                
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {

            //        CuocGoiKhachHen mCuocGoiKhachHen = new CuocGoiKhachHen();
            //        mCuocGoiKhachHen = frm.GetCuocGoiKhachHen;
            //        if (mCuocGoiKhachHen!=null )
            //        {
            //            if (!mCuocGoiKhachHen.Insert_Update())
            //            {
            //                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
            //                msgDialog.Show(this, "Cập nhật thông tin khách hẹn không thành công", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK,Taxi.MessageBox.MessageBoxIcon.Error);
            //                return;
            //            }
            //            else
            //            {
            //                // cap nhat cuoc goi la cuoc goi hen
            //                mDieuHanhTaxi.KieuKhachHangGoiDen = Taxi.Utils.KieuKhachHangGoiDen.KhachHangHen;
                            
            //                this.DialogResult = DialogResult.OK;
            //                this.Close();
            //                // 
            //            }
            //        }
            //    }
            //}
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
        }

        

        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData ==Keys.Escape  )
            {
                g_FormHuyBo = true;
                g_FormValidate = false;
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Alt|Keys.N))
            {
                txtDiaChiDonKhach.Focus(); 
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                chkGoiKhieuNai.Focus();
                chkGoiKhieuNai.Checked = !chkGoiKhieuNai.Checked;
                return true;
            }
            else if (keyData == (Keys.Alt | Keys.S))
            {
                editSoLuongXe.Focus();
                return true;
            }
            else if (keyData ==(Keys.Alt|Keys.V))
            {
                editVung.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt|Keys.T))
            {
                editLenhDienThoai.Focus();
                return true;
            }
            else if (keyData == (Keys.Alt|Keys.I))
            {
                editGhiChu.Focus();
                return true;
            }
            else if (keyData == Keys.Enter) // Mo nhap du lieu dong 1
            {
                
                this.btnOK_Click(null, null); 
               // this.DialogResult = DialogResult.OK;
                this.Close(); return true;
            }
            return false;
        }
        #endregion XU LY HOTKEY


        #region VALIDATE du lieu
        /// <summary>
        /// Tong dai nhap khong xe, DIen thoai nhap ko xe de ket thuc, nhung phai check ko xe cualen tong dai truoc
        /// </summary>
        /// <returns></returns>
        private bool CheckKhongXeDaCoCuaTongDai(DieuHanhTaxi CallTaxi)
        {
            return CallTaxi.LenhTongDai.Contains("không xe");
        }
       /// <summary>
       /// Kiem tra mot cuoc goi da duoc gan du lieu chua
       /// </summary>
       /// <param name="CallTaxi"></param>
       /// <returns></returns>
        private bool CheckDaChonCuocGoi(DieuHanhTaxi CallTaxi)
        {
            return (CallTaxi.GoiLai || CallTaxi.GoiTaxi || CallTaxi.ThongTinKhac);
                
        }
        #endregion VALIDATE du lieu

        private void editGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D4)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }


        #region XU LY phim mui ten

        private void txtDiaChiDonKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkGoiTaxi.Focus();
            }
            // else if (e.KeyCode == Keys.Left)
            //{

            //}
            //else if (e.KeyCode == Keys.Right)
            //{

            //}


        }
        private void editSoLuongXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkXe4.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                chkXe7.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                editVung.Focus();
            }
        }
        private void editVung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                chkXe4.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editLenhDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                editSoLuongXe.Focus();
            }
            else if (e.KeyCode == Keys.Right)
            {
                chkXe4.Focus();
            }
        }
        private void editLenhDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editVung.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                editGhiChu.Focus();
            }
        }
        private void editGhiChu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                editLenhDienThoai.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }
        #endregion XU LY phim mui ten

        private void frmDienThoaiInputDataCP_FormClosing(object sender, FormClosingEventArgs e)
        {
             
            if (g_FormValidate || g_FormHuyBo)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }


        private void txtDiaChiDonKhach_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void chkXe4_CheckedChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            if (chkXe4.Checked)
            {
                chkXe7.Checked    =!chkXe4.Checked;
                chkXeKhongChon.Checked = !chkXe4.Checked;
            }
           
        }

        private void chkXe7_CheckedChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            if (chkXe7.Checked)
            {
                chkXe4.Checked    = !chkXe7.Checked;
                chkXeKhongChon.Checked  = !chkXe7.Checked; 
            }
            
        }
        private void chkXeKhongChon_CheckedChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
            if (chkXeKhongChon.Checked)
            {
                chkXe4.Checked  = !chkXeKhongChon.Checked;
                chkXe7.Checked  = !chkXeKhongChon.Checked;
            }
        }
        private void editSoLuongXe_Click(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
        }

        private void editVung_Click(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
        }

        private void editGhiChu_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; // co thay doi du lieu.
        }

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
             
            string sVung = StringTools.TrimSpace ( editVung.Text);
            if (sVung == "11")
            {
                chkGoiKhieuNai.Checked = true;
            }
             
        }

        private void editSoLuongXe_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true; 
        }

       

       

         

       

       

         

    }
}