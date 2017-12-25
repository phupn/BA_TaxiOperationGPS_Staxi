using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Taxi.Utils;
using TaxiOperation_MoiKhach;
using Taxi.Utils;

namespace Taxi.GUI
{ 
    public partial class frmMoiKhachInputData_V3: Form
    {
        private CuocGoi mCuocGoi = new CuocGoi();
        private bool gGoiLai = false;
        private int g_intGoilaiHoanTruot = 0;
        private bool g_CoThayDoiDuLieu = false;
        private bool g_IsThoatDuoc999  = false;
        private CuocGoi gDieuHanhGoiLai = new CuocGoi();
        private LENHCUATONGDAI_MOIKHACH mlenhTongDai;
        private int G_XeDonLength = 0;
        private const string MOIKHACH_KHACHDANGRA = "khách đang ra";
        private const string MOIKHACH_DAMOI = "Đã mời";
        private const string MOIKHACH_DOIKHACH = "đợi khách {0} phút";
        private List<string> g_ListSoHieuXe;
        private bool g_CloseForm = true;    // kiểm soát đóng form
        private bool g_IsKetThuc = false;

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

        public CuocGoi GetCuocGoi
        {
            get {
                  
                return mCuocGoi; }
            //  set { mCuocGoi = value; }
        }
        private int gLen = 0; 
        /// <summary>
        /// Truyen vao mot doi tuong DieuHanh, tuong duoc mot cuoc goi 
        /// 
        /// </summary>
        /// <param name="CuocGoi"></param>
        public frmMoiKhachInputData_V3(CuocGoi CuocGoi, LENHCUATONGDAI_MOIKHACH lenhTongDai, bool isThoatDuoc999, List<string> listSoHieuXe)
        {
            InitializeComponent();
            mCuocGoi = CuocGoi;
            mlenhTongDai = lenhTongDai;
            g_IsThoatDuoc999 = isThoatDuoc999;
            g_ListSoHieuXe = listSoHieuXe;

            txtDiaChiDon.ReadOnly = !ThongTinDangNhap.HasPermission(DanhSachQuyen.CuocGoi_MK_SuaDiaChiDon);
        } 
        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            lblThoiDiemChen.Text = string.Format("{0: HH:mm:ss dd/MM}", DieuHanhTaxi.GetTimeServer()); 
            this.SetData2Form();
            if (mCuocGoi.LenhDienThoai.Contains("gọi lại"))
            {               
                txtMKPhut.Enabled = false;                 
            }
            g_CoThayDoiDuLieu = false;

            chkTaxiGroupDon.Visible = ThongTinCauHinh.KichHoachTaxiGroupDon;

                      
        }

        /// <summary>
        /// với các đầu vào thì sẽ có nhưng hiển thị khác nhau
        /// LENHMOIKHACH = 0,
        /// LENHGIUKHACH = 1,
        /// LENHKHONGXEXINLOI = 2,
        /// LENHKHIEUNAI = 3, 
        /// </summary>
        /// <param name="lenhTongDai"></param>
        private void KhoiTaoDuLieuHienThi(LENHCUATONGDAI_MOIKHACH lenhTongDai)
        {
            if (lenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH)
            {
                // hiển thị các control cho mời khách
                this.Text += " - Mời khách";
                chkMKCho.Text = "&1 Chờ";
                txtMKPhut.Visible = true;
                lblMKPhut.Visible = true;
                lblMKGiaiThich.Visible = true;
                chkMKHoan.Visible = true;
                chkMKTruot.Visible = true;
                chkMKKhac.Visible = true;
                txtMKKhac.Visible =  false;

                // Ẩn nhưng control khách
                txtKNai_ThongThiThem.Visible = false;
                lblKNai_ThongTinThem.Visible = false;
            }
            else if(lenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH)
            {
                this.Text += " - Giữ khách";
                chkMKCho.Text = "&1 Đã giữ"; 

                txtMKPhut.Visible = false ;
                lblMKPhut.Visible = false ;
                lblMKGiaiThich.Visible = false ;
                chkMKHoan.Visible = true; chkMKHoan.Checked = false;
                chkMKTruot.Visible = true; chkMKTruot.Checked = false;
                chkMKKhac.Visible = true; chkMKKhac.Checked = false;
                txtMKKhac.Visible = true;

                // Ẩn nhưng control khách
                txtKNai_ThongThiThem.Visible = false;
                lblKNai_ThongTinThem.Visible = false;
            }
            else if (lenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI)
            {
                this.Text += " - Không xe xin lỗi khách";
                chkMKCho.Text = "&1 Đã xin lỗi";

                txtMKPhut.Visible = false;
                lblMKPhut.Visible = false;
                lblMKGiaiThich.Visible = false;
                chkMKHoan.Visible = false;
                chkMKTruot.Visible = false;
                chkMKKhac.Visible = false;
                txtMKKhac.Visible = false;

                // Ẩn nhưng control khách
                txtKNai_ThongThiThem.Visible = false;
                lblKNai_ThongTinThem.Visible = false;
            }

            else if (lenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI)
            {
                this.Text += " - Xử lý khiếu nại";
                chkMKCho.Text = "&1 Đã xử lý";  

                txtMKPhut.Visible = false;
                lblMKPhut.Visible = false;
                lblMKGiaiThich.Visible = false;
                chkMKHoan.Visible = false;
                chkMKTruot.Visible = false;
                chkMKKhac.Visible = false;
                txtMKKhac.Visible = false;

                // Ẩn nhưng control khách
                txtKNai_ThongThiThem.Visible = true ;
                lblKNai_ThongTinThem.Visible = true ;
            }

        }


        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mCuocGoi != null)
            {
                KhoiTaoDuLieuHienThi(mlenhTongDai);
                // line + phone + time

                lblLinePhoneTime.Text = String.Format("[{0}]  {1}  {2}", mCuocGoi.Line, mCuocGoi.PhoneNumber, mCuocGoi.ThoiDiemGoiGio);
               
                txtDiaChiDon.Text = mCuocGoi.DiaChiDonKhach;
                
                int iSoLuong = 0;

                if (mCuocGoi.SoLuong == null) iSoLuong = 0;
                else iSoLuong = mCuocGoi.SoLuong;
                string strXeCho;
                //if ((iSoLuong == 2) && (mCuocGoi.LoaiXe.Contains("0")))
                //{
                //    strXeCho = "1 xe 4 chỗ, 1 xe 7 chỗ";
                //}
                //else
                //{
                    strXeCho = mCuocGoi.SoLuong.ToString();
                    if (mCuocGoi.LoaiXe.Contains("4")) strXeCho+= " xe, 4 chỗ" ;
                    else if (mCuocGoi.LoaiXe.Contains("7")) strXeCho += " xe, 7 chỗ";
                    //else if (mCuocGoi.LoaiXe.Contains("0")) strXeCho += " xe, 4 hoặc 7 chỗ";
                //}
                
                lblSoLuong_LoaiXe.Text = strXeCho;                 
                lblXeNhan.Text  =mCuocGoi.XeNhan;

                txt_GhiChuMoiKhach.Text = mCuocGoi.MOIKHACH_KhieuNai_ThongTinThem;

                if (this.mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH)
                {

                    chkMKCho.Checked = true;
                    chkMKTruot.Checked = false;
                    chkMKHoan.Checked = false;
                    chkMKKhac.Checked = false;
                    if (mCuocGoi.MOIKHACH_LenhMoiKhach == MOIKHACH_KHACHDANGRA)
                    {
                        txtMKPhut.Text = "0";
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach == MOIKHACH_DAMOI)
                    {
                        txtMKPhut.Text = "1";
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("phút"))
                    {
                        txtMKPhut.Text = GetNumberTrongChuoi(mCuocGoi.MOIKHACH_LenhMoiKhach);
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("trượt"))
                    {
                        txtMKPhut.Text = "";
                        chkMKCho.Checked = false;
                        chkMKTruot.Checked = true;
                        chkMKHoan.Checked = false;
                        chkMKKhac.Checked = false;
                        txtMKKhac.Visible = false;
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("hoãn"))
                    {
                        txtMKPhut.Text = "";
                        chkMKCho.Checked = false;
                        chkMKTruot.Checked = false;
                        chkMKHoan.Checked = true;
                        chkMKKhac.Checked = false;
                        txtMKKhac.Visible = false;
                    }
                    else if(mCuocGoi.MOIKHACH_LenhMoiKhach.Length >0)
                    {
                        txtMKPhut.Text = "";
                        chkMKCho.Checked = false;
                        chkMKTruot.Checked = false;
                        chkMKHoan.Checked = false;
                        chkMKKhac.Checked = true;
                        txtMKKhac.Visible = true;
                        txtMKKhac.Text = mCuocGoi.MOIKHACH_LenhMoiKhach;
                    }

                }
                else if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH)
                {
                    if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("đã giữ"))
                    {
                        chkMKCho.Checked = true ;
                        chkMKTruot.Checked = false;
                        chkMKHoan.Checked = false;
                        chkMKKhac.Checked = false ;
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("hoãn"))
                    {
                        chkMKCho.Checked = false ;
                        chkMKTruot.Checked = false;
                        chkMKHoan.Checked = true ;
                        chkMKKhac.Checked = false;
                    }
                    else if (mCuocGoi.MOIKHACH_LenhMoiKhach.Contains("trượt"))
                    {
                        chkMKCho.Checked = false;
                        chkMKTruot.Checked = true ;
                        chkMKHoan.Checked = true;
                        chkMKKhac.Checked = false;
                    }
                    else  if (mCuocGoi.MOIKHACH_LenhMoiKhach.Length >0)
                    {
                        chkMKCho.Checked = false;
                        chkMKTruot.Checked = true;
                        chkMKHoan.Checked = true;
                        chkMKKhac.Checked = true;
                        txtMKKhac.Visible = true;
                        txtMKKhac.Text = mCuocGoi.MOIKHACH_LenhMoiKhach;
                    }
                }
                else if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI)
                {
                    chkMKCho.Checked = mCuocGoi.MOIKHACH_XinLoi_DaXinLoi;
                }
                else   if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHIEUNAI)
                {
                    chkMKCho.Checked = mCuocGoi.MOIKHACH_KhieuNai_DaXyLy;
                }
            }
        }

        private string GetNumberTrongChuoi(string p)
        {
            string[] arrWords = p.Split(" ".ToCharArray());
            try
            {
                int i = Convert.ToInt32(arrWords[arrWords.Length - 2]);
                return arrWords[arrWords.Length - 2];
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// lay du lieu tra form gan vao cho doi tuong mCuocGoi
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

        private bool KiemTraXeNhan(string xeNhan, List<string> dsXe)
        {
            bool ret = true;
            if (xeNhan.Length <= 0) return true;
            if (dsXe == null || dsXe.Count <= 0) return false;

            string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
            G_XeDonLength = arrXeNhan.Length;
            for (int i = 0; i < G_XeDonLength; i++)
            {
                bool timThayXe = false;
                foreach (string xe in dsXe)
                {
                    if (xe == arrXeNhan[i])
                    {
                        timThayXe = true;
                        break; // thoát khỏi vòng ds xe
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; }  // có một xe không thuộc ds
            }
            return ret;
        }

        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            mCuocGoi.MOIKHACH_KhieuNai_ThongTinThem = txt_GhiChuMoiKhach.Text.Trim();
            if (!txtDiaChiDon.ReadOnly)
            {
                if (mCuocGoi.DiaChiDonKhach != txtDiaChiDon.Text.Trim())
                {
                    mCuocGoi.DiaChiDonKhach = txtDiaChiDon.Text.Trim();
                    g_CoThayDoiDuLieu = true;
                }
            }
            string xeDon = StringTools.TrimSpace(maskXeDon.TextBox.Text);
            string xeNhan = mCuocGoi.XeNhan;
            #region XeDon
            if (xeDon != null && xeDon.Length > 0 && xeDon != mCuocGoi.XeDon)
            {
                
                    if (!KiemTraXeNhan(xeDon, g_ListSoHieuXe))
                    {
                        new MessageBox.MessageBoxBA().Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        g_CloseForm = false;
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                    
                    if (G_XeDonLength < mCuocGoi.SoLuong)
                    {
                        string message = "Chưa đủ xe số lượng xe yêu cầu";
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == DialogResult.OK)
                            {
                                if (confirmXeDon.Result == 2)
                                {
                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(mCuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                    {
                                        new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                        return;
                                    }
                                    g_IsKetThuc = true;
                                }
                                else
                                {
                                    g_IsKetThuc = false;
                                    return;
                                }
                            }
                            else
                            {
                                g_IsKetThuc = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        g_IsKetThuc = true;
                    }
                    if (!KiemTraXeDonThuocXeNhan(xeDon, xeNhan))
                    {
                        string message = string.Format("Xe {0} đón nhưng không thuộc Xe Nhận", xeDon);
                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message,xeDon))
                        {
                            confirmXeDon.ShowDialog();
                            if (confirmXeDon.DialogResult == DialogResult.OK)
                            {
                                xeDon = confirmXeDon.XeDonResult;
                                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(mCuocGoi.IDCuocGoi, message, confirmXeDon.Result, ThongTinDangNhap.USER_ID, KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon))
                                {
                                    new MessageBox.MessageBoxBA().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                                    return;
                                }
                                g_IsKetThuc = true;
                            }
                            else
                            {
                                g_IsKetThuc = false;
                                return;
                            }
                        }
                    }
                

                if (g_IsKetThuc)
                {
                    mCuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                    mCuocGoi.XeDon = xeDon;
                }
            }
            #endregion

            if (!FormValidate(mlenhTongDai))
            {
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();
                msg.Show(this, "Bạn phải chọn một phần thực hiện để lưu.","Thông báo",Taxi.MessageBox.MessageBoxButtonsBA.OK,Taxi.MessageBox.MessageBoxIconBA.Information);
                return;
            }
             
            if (g_IsKetThuc == false)
            {
                #region MOIKHACH
                if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH)
                {
                    if (chkMKCho.Checked)
                    {
                        if (txtMKPhut.Text == "0")
                            mCuocGoi.MOIKHACH_LenhMoiKhach = MOIKHACH_KHACHDANGRA;
                        else if (txtMKPhut.Text == "1")
                            mCuocGoi.MOIKHACH_LenhMoiKhach = MOIKHACH_DAMOI;
                        else if (txtMKPhut.Text.Length > 0)
                        {
                            try
                            {
                                int i = Convert.ToInt32(txtMKPhut.Text);
                                mCuocGoi.MOIKHACH_LenhMoiKhach = string.Format(MOIKHACH_DOIKHACH, i);
                            }
                            catch (Exception ex)
                            {
                                mCuocGoi.MOIKHACH_LenhMoiKhach = txtMKPhut.Text;
                            }
                        }
                    }
                    else if (chkMKHoan.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = "khách hoãn";
                    }
                    else if (chkMKTruot.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = "trượt";
                    }
                    else if (chkMKKhac.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = txtMKKhac.Text;
                    }
                    mCuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                }
             #endregion MOIKHACH

                #region GIUKHACH
                else if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHGIUKHACH)
                {
                    if (chkMKCho.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = "đã giữ";
                    }
                    else if (chkMKHoan.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = "khách hoãn";
                    }
                    else if (chkMKTruot.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = "trượt";
                    }
                    else if (chkMKKhac.Checked)
                    {
                        mCuocGoi.MOIKHACH_LenhMoiKhach = txtMKKhac.Text;
                    }
                    mCuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.MoiKhachGui;
                }

                #endregion GIUKHACH

                #region KHONG XE XIN LOI KHACH

                else if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHKHONGXEXINLOI)
                {
                    mCuocGoi.MOIKHACH_LenhMoiKhach = "đã xin lỗi";
                    mCuocGoi.MOIKHACH_XinLoi_DaXinLoi = true;
                    mCuocGoi.TrangThaiLenh = TrangThaiLenhTaxi.KetThuc;
                }

                #endregion KHONG XE XIN LOI KHACH

            }
            if (g_CoThayDoiDuLieu)
            {
                 this.DialogResult = DialogResult.OK;        
            }
            
            this.Close();
        }
        /// <summary>
        /// có thông tin xe đón
        /// </summary>
        //private bool XuLyCoThongTinXeDon(string XeDon)
        //{
        //    MessageBox.MessageBox msg = new Taxi.MessageBox.MessageBox();

        //    if (XeDon == "999")
        //    {
        //        if (g_IsThoatDuoc999)
        //        {
        //            if (mCuocGoi.XeNhan.Length <= 0)
        //                mCuocGoi.XeNhan = "999";
        //            else
        //                mCuocGoi.XeNhan += ".999";  // cong them xe cu

        //            mCuocGoi.XeDon = "999";
        //        }
        //        else
        //        {
        //            XeDon = "";
        //        }
        //    }
        //    else
        //    {
        //        if (mCuocGoi.XeNhan != null && mCuocGoi.XeNhan.Length > 0)
        //        {
        //            string sXeDon = XeDon;
        //            if (CheckTrungLapXeChay(sXeDon))
        //            {
        //                msg.Show("Bạn phải nhập xe taxi chạy chính xác");
        //                maskXeDon.Focus();
        //                return false;
        //            }
        //            else
        //            {
        //                // KIEM TRA XE DON có năm trong xe nhận không
        //                if (!KiemTraXeDonCoNamTrongXeNhan(mCuocGoi.XeNhan, sXeDon))
        //                {
        //                    msg.Show("Bạn phải nhập xe đón nằm trong xe nhận.");
        //                    return false;
        //                }
        //                else
        //                {
        //                    if (!KiemTraXeDonThuocXeNhan(XeDon, mCuocGoi.XeDenDiem) && mCuocGoi.GPS_KinhDo > 0 && mCuocGoi.GPS_ViDo > 0)
        //                    {
        //                        string message = string.Format("Xe {0} đón nhưng không thuộc Xe đến điểm", XeDon);
        //                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.XeDonKhongThuocXeNhan, message))
        //                        {
        //                            confirmXeDon.ShowDialog();
        //                            if (confirmXeDon.DialogResult == DialogResult.OK)
        //                            {
        //                                if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(mCuocGoi.IDCuocGoi, message, confirmXeDon.Result))
        //                                {
        //                                    new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                                    return false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                return false;
        //                            }
        //                        }
        //                        //new MessageBox.MessageBox().Show("Xe " + xeDon + " không nằm trong xe đến điểm", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
        //                        //return;
        //                    }
        //                    if (G_XeDonLength < mCuocGoi.SoLuong)
        //                    {
        //                        string message = "Chưa đủ xe số lượng xe yêu cầu";
        //                        using (frmConfirmXeDon confirmXeDon = new frmConfirmXeDon(KieuCanhBaoKhiNhapThongTin.ChuaDuSoLuongXeDon, message))
        //                        {
        //                            confirmXeDon.ShowDialog();
        //                            if (confirmXeDon.DialogResult == DialogResult.OK)
        //                            {
        //                                if (confirmXeDon.Result == 2)
        //                                {
        //                                    if (!new Taxi.Data.CuocGoi().TONGDAI_UPDATE_XACNHAN(mCuocGoi.IDCuocGoi, message, confirmXeDon.Result))
        //                                    {
        //                                        new MessageBox.MessageBox().Show("Cập nhật lỗi", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
        //                                        return false;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    return false;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                return false;
        //                            }
        //                        }

        //                    }
        //                    // Cập nhật DB 
        //                    CuocGoi.UpdateCSThongTinXeDon(mCuocGoi.IDCuocGoi, mCuocGoi.XeNhan, sXeDon, ThongTinDangNhap.USER_ID);
        //                    return true;
        //                }
        //            }
        //        }
        //        else // có thông tin xe đón 
        //        {

        //            msg.Show(this, "Chưa có thông tin xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Information);
        //            return false;
        //        }
        //    }
        //}

        /// <summary>
        /// hàm thực hiện kiểm tra xe đón thuộc xe nhận        
        /// INPUT :
        ///    xeDon : 3210.2900.3213
        ///    xeNhan: 3211.2900.0900.3210.3213
        /// OUTPUT
        ///    true : xeDon nằm trong xe nhận
        ///    false: xeDon không nằm trong xe nhận
        /// </summary>
        /// <param name="xeDon"></param>
        /// <param name="xeNhan"></param>
        /// <returns></returns>
        private bool KiemTraXeDonThuocXeNhan(string xeDon, string xeNhan)
        {
            string[] arrXeDon = xeDon.Split(".".ToCharArray());
            G_XeDonLength = arrXeDon.Length;
            string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
            bool ret = true;
            for (int i = 0; i < arrXeDon.Length; i++)
            {
                bool timThayXe = false;
                for (int j = 0; j < arrXeNhan.Length; j++)
                {
                    if (arrXeDon[i] == arrXeNhan[j])
                    {
                        timThayXe = true;
                        break;
                    }
                }
                ret &= timThayXe;
                if (!ret) { break; };
            }
            return ret;
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
            string strXe = StringTools.TrimSpace(DSXe);
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
        /// check validate form tra ve mã lỗi cho từng trường hợp
        /// 1 : chế độ Mời khách 
        /// </summary>
        /// <param name="mlenhTongDai"></param>
        /// <returns></returns>
        private bool FormValidate(LENHCUATONGDAI_MOIKHACH LenhTongDai)
        {
            return (chkMKCho.Checked || chkMKHoan.Checked || chkMKTruot.Checked || chkMKKhac.Checked);
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
            string strDSXeNhanDaNhanDiem = "";
             string[] arrTaxi = strXeNhan.Split(".".ToCharArray());
             for (int i = 0; i < arrTaxi.Length; i++)
             {
                 if (CuocGoi.KiemTraXeNhanDaDangNhanCuocKhach(IDCuocKhach, arrTaxi[i].ToString()))
                     strDSXeNhanDaNhanDiem += arrTaxi[i].ToString() +".";
             }
             return strDSXeNhanDaNhanDiem;
        }
         
        #region XU LY HOTKEY

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            
            else if (keyData == (Keys.Alt | Keys.L))
            {
                txtMKPhut.Focus();
                return true;
            }
            else if (keyData ==  Keys.Enter )
            {
                this.btnOK_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                chkTaxiGroupDon.Checked = !chkTaxiGroupDon.Checked;
            }
            else if (keyData == (Keys.Alt | Keys.D))
            {
                if (!txtDiaChiDon.ReadOnly)
                    txtDiaChiDon.Focus();
                return true;
            }
           
            return false;
        }
        #endregion XU LY HOTKEY
         
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

        #region THAY DOI CAC CHECK BOX

        private void chkMKCho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMKCho.Checked)
            {
                if (mlenhTongDai == LENHCUATONGDAI_MOIKHACH.LENHMOIKHACH)
                    txtMKPhut.Focus();
                chkMKHoan.Checked = !chkMKCho.Checked;
                chkMKTruot.Checked = !chkMKCho.Checked;
                chkMKKhac.Checked = !chkMKCho.Checked;
            }
            g_CoThayDoiDuLieu = true;
        }
        private void chkMKTruot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMKTruot.Checked)
            {
                chkMKCho.Checked = !chkMKTruot.Checked;
                chkMKHoan.Checked = !chkMKTruot.Checked;
                chkMKKhac.Checked = !chkMKTruot.Checked;
            }
            g_CoThayDoiDuLieu = true;
        }
        private void chkMKHoan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMKHoan.Checked)
            {
                chkMKCho.Checked = !chkMKHoan.Checked;
                chkMKTruot.Checked = !chkMKHoan.Checked;
                chkMKKhac.Checked = !chkMKHoan.Checked;
            }
            g_CoThayDoiDuLieu = true;
        }
        private void chkMKKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMKKhac.Checked)
            {
                chkMKCho.Checked = !chkMKKhac.Checked;
                chkMKTruot.Checked = !chkMKKhac.Checked;
                chkMKHoan.Checked = !chkMKKhac.Checked;                
            }
            txtMKKhac.Visible =  chkMKKhac.Checked;
            g_CoThayDoiDuLieu = true;
        }
        #endregion THAY DOI CAC CHECK BOX

        private void uiTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtMKPhut_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void txtKNai_ThongThiThem_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void txtMKKhac_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void chkTaxiGroupDon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTaxiGroupDon.Checked)
            { 
                //this.g_CoThayDoiDuLieu = true;
                //this.DialogResult = DialogResult.Ignore; // cho truong hop taxi group don 
                //this.Close(); 
                if (chkTaxiGroupDon.Checked)
                {
                    maskXeDon.Text = "000";
                    if (mCuocGoi.XeNhan.Length <= 0)
                        mCuocGoi.XeNhan = "000";
                    else
                        mCuocGoi.XeNhan += ".000";
                }
                else
                {
                    maskXeDon.Text = maskXeDon.Text.Replace("000", "");
                    mCuocGoi.XeNhan = mCuocGoi.XeNhan.Replace("000", "");
                }
            }
        }

        private void maskXeDon_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }

        private void maskXeDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                btnOK.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkMKCho.Focus();
            }
        }

        private void chkMKCho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                maskXeDon.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkMKTruot.Focus();
            }
            else if (e.KeyData == Keys.Left)
            {
                txtMKPhut.Focus();
            }
        }

        private void txtMKPhut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                chkMKCho.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                chkMKTruot.Focus();
            }
            
        }

        private void txt_GhiChuMoiKhach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                txtMKKhac.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnOK.Focus();
            }
        }

        private void txtMKKhac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                chkMKCho.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txt_GhiChuMoiKhach.Focus();
            }
        }

        private void txtDiaChiDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.btnOK_Click(sender, new EventArgs());
            }

            if (e.KeyCode == Keys.Up)
            {
                txt_GhiChuMoiKhach.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                maskXeDon.Focus();
            }
        }

        private void txtDiaChiDon_TextChanged(object sender, EventArgs e)
        {
        } 
       
    }
}