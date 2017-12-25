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

namespace Taxi.GUI
{
    public partial class frmMoiKhachInputDataCuocKetThuc: Form
    {
        private CuocGoi mCuocGoi = new CuocGoi();
        private bool gGoiLai = false;
        private int g_intGoilaiHoanTruot = 0;
        private bool g_CoThayDoiDuLieu = false;
        private bool g_IsThoatDuoc999  = false;
        private CuocGoi gDieuHanhGoiLai = new CuocGoi();
        private LENHCUATONGDAI_MOIKHACH mlenhTongDai;
        private List<string> g_ListSoHieuXe;

        private const string MOIKHACH_KHACHDANGRA = "khách đang ra";
        private const string MOIKHACH_DAMOI = "đã mời";
        private const string MOIKHACH_DOIKHACH = "đợi khách {0} phút";

        
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
        public frmMoiKhachInputDataCuocKetThuc(CuocGoi CuocGoi, LENHCUATONGDAI_MOIKHACH lenhTongDai, bool isThoatDuoc999)
        {
            InitializeComponent();
            mCuocGoi = CuocGoi;
            mlenhTongDai = lenhTongDai;
            g_IsThoatDuoc999 = isThoatDuoc999;
        }

        public frmMoiKhachInputDataCuocKetThuc(CuocGoi CuocGoi, LENHCUATONGDAI_MOIKHACH lenhTongDai, bool isThoatDuoc999, List<string> listSoHieuXe)
        {
            InitializeComponent();
            mCuocGoi = CuocGoi;
            mlenhTongDai = lenhTongDai;
            g_IsThoatDuoc999 = isThoatDuoc999;
            g_ListSoHieuXe = listSoHieuXe;
        } 

        private void frmBoDamInputData_Load(object sender, EventArgs e)
        {
            lblThoiDiemChen.Text = string.Format("{0: HH:mm:ss dd/MM}", DieuHanhTaxi.GetTimeServer()); 
            this.SetData2Form(); 
        }
         
        /// <summary>
        /// Thiet lap gia tri của dư lieu len form
        /// </summary>
        private void SetData2Form()
        {
            if (mCuocGoi != null)
            {
               
                // line + phone + time

                lblLinePhoneTime.Text = "[" + mCuocGoi.Line + "]  " + mCuocGoi.PhoneNumber + "  " + mCuocGoi.ThoiDiemGoiGio;
               
                lblDiaChiDonKhach.Text = mCuocGoi.DiaChiDonKhach;
                
                int iSoLuong = 0;

                if (mCuocGoi.SoLuong == 0) iSoLuong = 0;
                else iSoLuong = mCuocGoi.SoLuong;
                string strXeCho;
                if ((iSoLuong == 2) && (mCuocGoi.LoaiXe.Contains("0")))
                {
                    strXeCho = "1 xe 4 chỗ, 1 xe 7 chỗ";
                }
                else
                {
                    strXeCho = mCuocGoi.SoLuong.ToString();
                    if (mCuocGoi.LoaiXe.Contains("4")) strXeCho+= " xe, 4 chỗ" ;
                    else if (mCuocGoi.LoaiXe.Contains("7")) strXeCho += " xe, 7 chỗ";
                    else if (mCuocGoi.LoaiXe.Contains("0")) strXeCho += " xe, 4 hoặc 7 chỗ";
                }
                
                lblSoLuong_LoaiXe.Text = strXeCho;                 
                lblXeNhan .Text  =mCuocGoi.XeNhan;
                maskXeDon.TextBox.Text = mCuocGoi.XeDon;
                txtThongThiThem.Text = mCuocGoi.MOIKHACH_KhieuNai_ThongTinThem;
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

        


        /// <summary>
        /// Nhap thong tin va thiet lap trang thai cuoc goi
        /// trang thai lenh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string strXeDon = StringTools.TrimSpace(maskXeDon.TextBox.Text);
            
            if (XuLyCoThongTinXeDon(strXeDon))
            {
                bool truot = chkMKTruot.Checked;
                string ghiChu = StringTools.TrimSpace(txtThongThiThem.Text);

                CuocGoi.MOIKHACH_UpdateThongTinCuocGoiKetThuc(mCuocGoi.IDCuocGoi, strXeDon, truot, ghiChu, mCuocGoi.MOIKHACH_NhanVien);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool KiemTraXeNhan(string xeNhan, List<string> dsXe)
        {
            bool ret = true;
            if (xeNhan.Length <= 0) return true;
            if (dsXe == null || dsXe.Count <= 0) return false;

            string[] arrXeNhan = xeNhan.Split(".".ToCharArray());
            for (int i = 0; i < arrXeNhan.Length; i++)
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
        /// có thông tin xe đón
        /// </summary>
        private bool XuLyCoThongTinXeDon(string XeDon)
        {
            if (XeDon == mCuocGoi.XeDon)
            {
                return true;
            }
            else
            {
                MessageBox.MessageBoxBA msg = new Taxi.MessageBox.MessageBoxBA();

                if (XeDon == "999")
                {
                    if (g_IsThoatDuoc999)
                    {
                        if (mCuocGoi.XeNhan.Length <= 0)
                            mCuocGoi.XeNhan = "999";
                        else
                            mCuocGoi.XeNhan += ".999";  // cong them xe cu
                    }
                    else
                    {
                        XeDon = "";
                    }
                }
                if (mCuocGoi.XeNhan != null && mCuocGoi.XeNhan.Length > 0)
                {
                    string sXeDon = XeDon;
                    if (CheckTrungLapXeChay(sXeDon))
                    {
                        msg.Show("Bạn phải nhập xe taxi chạy chính xác");
                        maskXeDon.Focus();
                        return false;
                    }
                    else if (!KiemTraXeNhan(XeDon, g_ListSoHieuXe))
                    {
                        msg.Show(this, "Vui lòng nhập chính xác xe đón.Báo quản trị bổ sung xe nếu thiếu", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Error);
                        maskXeDon.Focus();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else // có thông tin xe đón 
                {

                    msg.Show(this, "Chưa có thông tin xe nhận.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Information);
                    return false;
                }
            }
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
              
                return true;
            }
            else if (keyData ==  Keys.Enter )
            {
                this.btnOK_Click(null, null);
            }
            else if (keyData == (Keys.Alt | Keys.A))
            {
                
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

        

        private void maskXeDon_TextChanged(object sender, EventArgs e)
        {
            g_CoThayDoiDuLieu = true;
        }
         
    }
}