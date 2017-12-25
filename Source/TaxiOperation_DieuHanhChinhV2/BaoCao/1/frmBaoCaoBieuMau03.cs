using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using ChartDirector;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau3 : Form
    {
        List<BaoCaoBieuMau3> g_lstBaoCaoBieuMau3;
        private fmProgress m_fmProgress = null;  
        public frmBaoCaoBieuMau3()
        {
            InitializeComponent();
          
        }

        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
            //LoadDuLieuCuocGoiDenTuPhanCung_VoiceFile();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                string strPhoneNumber = string.Empty;
                int LoaiCuocGoi = 0;
                int SoLuotDoChuong = 0;
                DateTime ThoiGianDamThoai = DateTime.MinValue;
                
                if (StringTools.TrimSpace(editPhoneNumber.Text).Length >0)
                {
                    if (StringTools.TrimSpace(editPhoneNumber.Text).Length <8)
                    {
                        MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                        msgDialog.Show(this, "Bạn phải nhập chính xác số điện thoại.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                        return;
                    }
                    else
                        strPhoneNumber = StringTools.TrimSpace(editPhoneNumber.Text);
                }
                // Loai cuoc goi
                if (chkGoiTaxi.Checked) LoaiCuocGoi += 1;
                if (chkGoiLai.Checked) LoaiCuocGoi += 2;
                if (chkGoiKhac.Checked) LoaiCuocGoi += 4;
                if (chkGoiKhieuNai.Checked) LoaiCuocGoi += 8;
                // SoLuotDoChuong
                if (StringTools.TrimSpace(editSoChuong .Text).Length > 0)
                {
                    SoLuotDoChuong = int.Parse(StringTools.TrimSpace(editSoChuong.Text));
                    if (SoLuotDoChuong <= 1) SoLuotDoChuong = 0;
                }
                // SoPhutDamThoai
                if ((timeThoiGianDamThoai.Value.Hour != 0) || (timeThoiGianDamThoai.Value.Minute  != 0) || (timeThoiGianDamThoai.Value.Second  != 0))
                {
                    ThoiGianDamThoai = new DateTime(1900, 1, 1, timeThoiGianDamThoai.Value.Hour, timeThoiGianDamThoai.Value.Minute, timeThoiGianDamThoai.Value.Second);
                }
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();
                string NRecords = "";
                int SoGiayChuyenTongdai = calThoiGianChuyenTongDai.Value.Hour*60*60 + calThoiGianChuyenTongDai.Value.Minute *60 + calThoiGianChuyenTongDai.Value.Second ;
                string SQLCondition = this.BuildStringQuery(calTuNgay.Value, calDenNgay.Value, LoaiCuocGoi,txtDiaChi.Text  ,  strPhoneNumber, SoLuotDoChuong, ThoiGianDamThoai, SoGiayChuyenTongdai, editVung.Text); 
                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                g_lstBaoCaoBieuMau3 = new List<BaoCaoBieuMau3>();
                g_lstBaoCaoBieuMau3 = ConvertToBaoCaoBieuMau3(lstCuocGoiKetThuc);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(g_lstBaoCaoBieuMau3, "lstCuocGoiKetThuc");
                
                btnRefresh.Enabled = false;
                btnPrint.Enabled = !btnRefresh.Enabled;
                btnExportExcel.Enabled = !btnRefresh.Enabled;

            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }

        /// <summary>
        /// Kieu du lieu vung co dang
        /// 1;2;3 Cac vung phan cach bang dau ';' 
        /// </summary>
        /// <param name="Vung"></param>
        /// <returns></returns>
        private string GetSQLStringQueryVung(string Vung)
        {
            if (Vung.Length <= 0) return "";
            string strReturn = string.Empty;

            string[] arrVung = Vung.Split(";".ToCharArray());
            strReturn = " (1<>1) ";
            for (int i = 0; i < arrVung.Length; i++)
            {
                strReturn += "OR   (Vung = " + arrVung[i] + " ) ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }


        private List<BaoCaoBieuMau3> ConvertToBaoCaoBieuMau3(List<DieuHanhTaxi> lstCuocGoiKetThuc)
        {
            List<BaoCaoBieuMau3> lstBaoCaoBieuMau3 = new List<BaoCaoBieuMau3>();
            if (lstCuocGoiKetThuc != null)
            {
                foreach (DieuHanhTaxi objDHTX in lstCuocGoiKetThuc)
                {
                    BaoCaoBieuMau3 objBM3 = new BaoCaoBieuMau3();
                    objBM3.ID_DieuHanh = objDHTX.ID_DieuHanh;
                    objBM3.Line = objDHTX.Line;
                    objBM3.PhoneNumber = objDHTX.PhoneNumber;
                    objBM3.MaVung =  objDHTX.MaVung;
                    objBM3.ThoiDiemGoi = objDHTX.ThoiDiemGoi;
                    objBM3.SoLuotDoChuong  = objDHTX.SoLuotDoChuong ;
                    objBM3.GoiTaxi  = objDHTX.GoiTaxi ;
                    objBM3.GoiLai  = objDHTX.GoiLai ;
                    objBM3.ThongTinKhac  = objDHTX.ThongTinKhac ;
                    objBM3.DiaChiDonKhach  = objDHTX.DiaChiDonKhach ;
                    objBM3.KieuKhachHangGoiDen = objDHTX.KieuKhachHangGoiDen;
                    if(objDHTX.XeDon .Length >0 )
                        objBM3.DonDuocKhach = true;
                    else objBM3.DonDuocKhach = false  ;
                    // truot 
                    if (objDHTX.GhiChuTongDai.Contains("trượt"))
                        objBM3.TruotKhach = true;
                    else objBM3.TruotKhach=false;

                    if (objDHTX.GhiChuTongDai.Contains("hoãn"))
                        objBM3.KhachHoan  = true;
                    else objBM3.KhachHoan = false;
                    if (objDHTX.GhiChuDienThoai.Contains("không xe"))
                        objBM3.KhongXe  = true;
                    else objBM3.KhongXe = false;

                    objBM3.DoDaiCuocGoi  = objDHTX.DoDaiCuocGoi ;
                    objBM3.FileVoicePath = objDHTX.FileVoicePath;
                    objBM3.MaNhanVienDienThoai  = objDHTX.MaNhanVienDienThoai ;
                    objBM3.MaNhanVienTongDai = objDHTX.MaNhanVienTongDai;
                    objBM3.ThoiDiemChuyenTongDai = objDHTX.ThoiDiemChuyenTongDai;
                    objBM3.LenhDienThoai = objDHTX.LenhDienThoai;
                    objBM3.LenhTongDai = objDHTX.LenhTongDai;
                    objBM3.GhiChuDienThoai = objDHTX.GhiChuDienThoai;
                    objBM3.GhiChuTongDai = objDHTX.GhiChuTongDai;

                    objBM3.XeNhan = objDHTX.XeNhan;
                    objBM3.XeDon = objDHTX.XeDon;

                    lstBaoCaoBieuMau3.Add(objBM3);
                }

            }
            return lstBaoCaoBieuMau3;
        }

        #region XuLyCacCuocGoi ket thuc
        private void LoadCacCuocGoiKetThuc()
        {
            try
            {
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                DateTime TimeServer = DieuHanhTaxi.GetTimeServer();

                string strDate = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TimeServer);

                string NRecords = " TOP 50 ";
                string SQLCondition = "  ORDER BY ThoiDiemGoi DESC";
                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
            }
            catch (Exception ex)
            {
                //TimerCapturePhone.Stop();
                // new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình load dữ liệu", "Thông báo lỗi", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Error);
            }

        }
        #endregion XuLyCacCuocGoi ket thuc
        /// <summary>
        /// xay dung chuoi query 
        ///     - TuNgay, Den ngay (bat buoc)
        ///     - Loai Cuoc goi, 1 : Goi Taxi, 3 : GoiLai 7 : GoiKhac
        ///                      4 : GoiTaxi + GoiLai
        ///                      8 : GoiTaxi+GoiKhac
        ///                      10 : GoiLai + Goi Khac
        ///     - PhoneNumber : lay ra voi so may; rống : thì không so
        ///     - SoLuotDoChung : Số lượt đổ chuông lớn hơn ; >1
        ///     - ThoiGianDamThoại : Tính theo phút >1
        ///  
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="LoaiCuocGoi"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="SoLuotDoChuong"></param>
        /// <param name="ThoiGianDamThoai"></param>
        /// <returns></returns>
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay, int LoaiCuocGoi, string DiaChi, string PhoneNumber, int SoLuotDoChuong, DateTime  ThoiGianDamThoai, int SoGiayChuyenTongDay, string Vungs)
        {
            string SQLCondition = string.Empty;
            string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay);
            string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay);

            SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
            if (LoaiCuocGoi > 0)
            {
                SQLCondition += GetSQLStringQueryLoaiCuocGoi(LoaiCuocGoi);
            }

            if (Vungs.Length > 0)
            {
                SQLCondition += GetSQLStringQueryVung(Vungs);
            }

            SQLCondition += GetSQLStringQueryPhoneNumbers(PhoneNumber);
            if (SoLuotDoChuong > 1)
                SQLCondition += " AND ( SoLuotDoChuong >= " + SoLuotDoChuong.ToString() + ") ";

            if(DiaChi.Length >0)
                SQLCondition += " AND ( DiaChiDonKhach LIKE N'%" + DiaChi + "%') ";


            if (ThoiGianDamThoai != DateTime.MinValue)
                SQLCondition += " AND ( Duration > cast('" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", ThoiGianDamThoai) + "' as Datetime ) )";
            if(SoGiayChuyenTongDay>0)  SQLCondition += " AND (ThoiDiemChuyenTongDai > "+ SoGiayChuyenTongDay.ToString() + ") ";

            return SQLCondition;
        }
        /// - Loai Cuoc goi,  
        /// 1111 :  Gọi Khiếu nai | Gọi Khác | Gọi Lại | Gọi Taxi
        /// 1 : Gọi taxi        ///     
        /// 2: Gọi lại
        ///   3 : Gọi taxi && Gọi lại
        /// 4: Gọi khác
        ///   5 : 0101 Goi taxi | Gọi khác
        ///   6 : 0110 Gọi lại | Gọi khác
        ///   7 : 0111 Gọi taxi | Gọi lại | Gọi khác
        /// 8: Gọi khiếu nại
        ///   9 : 1001 : Gọi khieu | Goi taxi
        ///   10: 1010 : Gọi khieu nại | Gọi lại
        ///   11: 1011 : Gọi khiếu nại | Gọi lại |Gọi taxi
        ///   12: 1100 : Gọi khiếu nại | Gọi khác
        ///   13: 1101 : GỌi khiếu nại | Gọi khác | Gọi taxi
        ///   14: 1110 : Gọi khiếu nại | Goi khác | gọi lại
        ///   15: 1111 : GỌi khiếu nại | Gọi khác | Gọi lại | Gọi taxi
        private string GetSQLStringQueryLoaiCuocGoi(int LoaiCuocGoi)
        {
            string strReturn = string.Empty;
            switch (LoaiCuocGoi)
            {
                case 1: { strReturn = " AND (GoiTaxi='1') "; break; }
                case 2: { strReturn = " AND (GoiLai='1') "; break; }               
                case 3: { strReturn = " AND ((GoiTaxi='1') OR (GoiLai='1')) "; break; }
                case 4: { strReturn = " AND (ThongTinKhac='1') "; break; }          
                case 5: { strReturn = " AND ((GoiTaxi='1') OR (ThongTinKhac='1'))  "; break; }
                case 6: { strReturn = " AND ((GoiLai='1') OR (ThongTinKhac='1'))  "; break; }
                case 7: { strReturn = " AND ((GoiTaxi='1') OR (GoiLai='1') OR (ThongTinKhac='1'))  "; break; }
                case 8: { strReturn = " AND (GoiKhieuNai='1') "; break; }
                case 9: { strReturn = " AND ((GoiTaxi='1') OR (GoiKhieuNai='1')) "; break; }
                case 10: { strReturn = " AND ((GoiLai='1') OR (GoiKhieuNai='1')) "; break; }
                case 11: { strReturn = " AND ((GoiTaxi='1') OR (GoiLai='1') OR (GoiKhieuNai='1')) "; break; }
                case 12: { strReturn = " AND ( (ThongTinKhac='1') OR (GoiKhieuNai='1')) "; break; }
                case 13: { strReturn = " AND ( (GoiTaxi='1') OR (ThongTinKhac='1') OR (GoiKhieuNai='1')) "; break; }
                case 14: { strReturn = " AND ( (GoiLai='1') OR (ThongTinKhac='1') OR (GoiKhieuNai='1')) "; break; }
                case 15: { strReturn = " AND ( (GoiTaxi='1') OR(GoiLai='1') OR (ThongTinKhac='1') OR (GoiKhieuNai='1')) "; break; }
                    
            }

            return strReturn;
        }

        /// <summary>
        /// nhieu so dien thoi cach nhau = ";"
        /// vd : 043494950;0980030404
        /// </summary>
        /// <param name="PhoneNumbers"></param>
        /// <returns></returns>
        private string GetSQLStringQueryPhoneNumbers(string PhoneNumbers)
        {
            string strReturn = "";
            if (PhoneNumbers.Length < 6) return strReturn;

            string[] arrPhone = PhoneNumbers.Split(";".ToCharArray());
            strReturn = " (1<>1) ";
            for (int i = 0; i < arrPhone.Length; i++)
            {
                strReturn +=  "OR ( PhoneNumber  LIKE '%" +  arrPhone[i].ToString () + "') ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }


        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  chr = Convert.ToChar(";");
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ) || (e.KeyChar == chr  ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void editPhut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                HienThiAnhTrangThai_MauChu(e.Row);
                    
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// - Hien thi anh trang thai tuong ung voi trang thai lenh
        /// - thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
        /// - Thay mau chu cua dia chi cua khach goi lai
        /// - thay doi may cua cuoc goi khong phai cua minh phu trach
        /// </summary>
        private void HienThiAnhTrangThai_MauChu(GridEXRow row)
        {
            try
            {
                BaoCaoBieuMau3 objBC3 = (BaoCaoBieuMau3)row.DataRow;

                // thay doi mau nen cua khach VIP, moi gioi, khach binh thuong
                if (objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor = Color.Yellow;
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                }
                if (objBC3.GoiLai )
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.ForeColor = Color.Red;
                    row.Cells["DiaChiDon"].FormatStyle = RowStyle;
                }
                if (objBC3.KieuKhachHangGoiDen == Taxi.Utils.KieuKhachHangGoiDen.KhachHangMoiGioi)
                {
                    GridEXFormatStyle RowStyle = new GridEXFormatStyle();
                    RowStyle.BackColor  = Color.Yellow ;
                    row.Cells["PhoneNumber"].FormatStyle = RowStyle;
                }
            }
            catch (Exception ex)
            {
                ////  LogError.WriteLog("Lỗi xử lý hiển thị màu của lưới", ex);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau3(Configuration.GetReportPath() + "\\Baocao_Bieumau3.rpt", g_lstBaoCaoBieuMau3, calTuNgay.Value, calDenNgay.Value, GetLoaiCuocGoi(), StringTools.TrimSpace(editPhoneNumber.Text), editSoChuong.Text, string.Format("{0: HH:mm:ss}", timeThoiGianDamThoai.Value ));  
            //frmPrint .ShowDialog();
        }

        private int GetLoaiCuocGoi()
        {  // Loai cuoc goi
            int LoaiCuocGoi = 0;
            if (chkGoiTaxi.Checked) LoaiCuocGoi += 1;
            if (chkGoiLai.Checked) LoaiCuocGoi += 3;
            if (chkGoiKhac.Checked) LoaiCuocGoi += 7;
            return LoaiCuocGoi;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau3.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
               
                gridEXExporter1.Export((Stream)objFile);
                
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        #region play wave sound 
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string filenameDB = "";
             string filenameVoice = "";
            gridDienThoai .SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            BaoCaoBieuMau3 objItem = null ;

            if (gridDienThoai.SelectedItems.Count > 0)
            {                
                objItem = (BaoCaoBieuMau3)(gridDienThoai.SelectedItems[0]).GetRow().DataRow; 

                 filenameDB = (gridDienThoai.SelectedItems[0]).GetRow().Cells["FileVoicePath"].Text;
                 filenameVoice = NgheLaiCuocGoi.GetFileNameCuocDi(filenameDB);
            }

            if (!FileTools.IsExsitFile(filenameVoice))
            {

                filenameVoice = NgheLaiCuocGoi.GetFileVoiceCuaMotCuocGoi(objItem.Line, objItem.PhoneNumber, objItem.ThoiDiemGoi, Taxi.Utils.TypeCall.Incoming, ThongTinCauHinh.ThuMucFileAmThanh);
            }

            if (filenameVoice.Length > 0)
            {
                player1.FileName = filenameVoice;
                if (player1.FileName != "")
                {
                    player1.Play();
                    btnPause.Text = "Pause";
                    this.timer1.Enabled = true;
                }
                else
                {
                    new MessageBox.MessageBoxBA().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\\maychu\GhiAm");
                }
            }
            else
            {
                new MessageBox.MessageBoxBA().Show(@"File không tồn tại.Bạn cần kiểm tra lại đường dẫn tới thư mục lưu file âm thanh.Thư mục này phải được lưu cùng với thư mục của hệ thống bắt số.Ví dụ : \\maychu\GhiAm");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnPause.Enabled = player1.Status != "stopped";
            btnStop.Enabled = player1.Status != "stopped";
            int pos = (player1.PositionInMS * this.tbPosition.Maximum) / player1.DurationInMS;
            this.tbPosition.Value = pos;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player1.Status == "paused")
            {
                player1.Resume();
                btnPause.Text = "Pause";
            }
            else
            {
                player1.Pause();
                btnPause.Text = "Resume";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            player1.Stop();
            this.timer1.Enabled = false;
        }
        #endregion


        #region Cap nhat du lieu duration + filepathvoice
        ///// <summary>
        ///// load du lieu tu phan cung Voice File + duration
        ///// </summary>
        //private void LoadDuLieuCuocGoiDenTuPhanCung_VoiceFile()
        //{
        //    // Create a background thread
        //    BackgroundWorker bw = new BackgroundWorker();
        //    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        //    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        //    // Create a progress form on the UI thread
        //    m_fmProgress = new fmProgress();
        //    // Kick off the Async thread
        //    bw.RunWorkerAsync();

        //    // Lock up the UI with this modal progress form.
        //    try
        //    {
        //        m_fmProgress.ShowDialog(this);
        //        m_fmProgress = null;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        //private void bw_DoWork(object sender, DoWorkEventArgs e)
        //{


        //    m_fmProgress.lblDescription.Invoke(
        //       (MethodInvoker)delegate()
        //       {
        //           m_fmProgress.lblDescription.Text = "Loading ... cuộc gọi đi";
        //           m_fmProgress.progressBar1.Value = 50;
        //       }
        //   );
        //    // capture du lieu 
        //    Taxi.Business.ProcessVocFile.UpdateVoiceFile_DurationHearCall();
        //    //
        //    if (m_fmProgress.Cancel)
        //    {
        //        // Set the e.Cancel flag so that the WorkerCompleted event
        //        // knows that the process was canceled.
        //        e.Cancel = true;
        //        return;
        //    }
        //}
        //private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    // The background process is complete. First we should hide the
        //    // modal Progress Form to unlock the UI. The we need to inspect our
        //    // response to see if an error occured, a cancel was requested or
        //    // if we completed succesfully.

        //    // Hide the Progress Form
        //    if (m_fmProgress != null)
        //    {
        //        m_fmProgress.Hide();
        //        m_fmProgress = null;
        //    }

        //    // Check to see if an error occured in the 
        //    // background process.
        //    if (e.Error != null)
        //    {
        //        new MessageBox.MessageBox().Show(this, "Có lỗi trong quá trình xử lý dữ liệu. [" + e.Error.Message + "]");
        //        return;
        //    }

        //    // Check to see if the background process was cancelled.
        //    if (e.Cancelled)
        //    {
        //        // new Taxi.MessageBox.MessageBox().Show("Processing cancelled.");
        //        return;
        //    }
        //}

        /// <summary>
        /// nhan thong tin cac cuoc goi di va cap nhat vao DB
        /// </summary>
        private void CaptureCuocGoiDi()
        {
            try
            {
                // lay du lieu
                DateTime timeServer = DieuHanhTaxi.GetTimeServer();
                string VOCFileName = ProcessVocFile.GetVOCFileFullPath(timeServer);
                DataTable dt = new DataTable();
                dt = ProcessVocFile.GetEarlyPhoneDialOut(VOCFileName);
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CuocGoiDi objGoiDi = new CuocGoiDi(dr["Line"].ToString(), dr["PhoneNumber"].ToString(), (DateTime)dr["ThoiDiemGoi"], (DateTime)dr["DoDaiCuocGoi"], dr["VoiceFilePath"].ToString());
                        if (!objGoiDi.Insert())
                        {
                            //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", new Exception("[ Cuoc goi di ]"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  LogError.WriteLog("Loi luu xuong DB cuoc goi di ", ex);
            }
        }

        #endregion 

        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void tbPosition_Scroll(object sender, EventArgs e)
        {

        }

        private void calThoiGianChuyenTongDai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}