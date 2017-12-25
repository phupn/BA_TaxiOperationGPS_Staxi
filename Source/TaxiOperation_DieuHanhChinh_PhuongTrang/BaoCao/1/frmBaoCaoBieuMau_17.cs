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
    public partial class frmBaoCaoBieuMau17 : Form
    {
         
        private fmProgress m_fmProgress = null;
        public frmBaoCaoBieuMau17()
        {
            InitializeComponent();
          
        }

        
        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
          //  btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
            //LoadDuLieuCuocGoiDenTuPhanCung_VoiceFile();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (StringTools.TrimSpace(editBienSoXe.Text).Length>0)
            {
                try
                {
                    int iSoXe = int.Parse(StringTools.TrimSpace(editBienSoXe.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "Lỗi nhập dữ liệu Biển số xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập dữ liệu Biển số xe.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }

            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                gridDienThoai.DataMember = "HanhTrinhXe";
                gridDienThoai.SetDataBinding(Business.TimKiem_BaoCao.GetHanhTrinhXe_BaoCao17 (StringTools.TrimSpace (editBienSoXe.Text),calTuNgay.Value,calDenNgay.Value), "lstCuocGoiKetThuc");
                btnRefresh.Enabled = false;
                btnExportExcel.Enabled = true;
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
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
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay, int LoaiCuocGoi, string PhoneNumber, int SoLuotDoChuong, DateTime  ThoiGianDamThoai)
        {
            string SQLCondition = string.Empty;
            string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay);
            string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay);

            SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
            if (LoaiCuocGoi > 0)
            {
                SQLCondition += GetSQLStringQueryLoaiCuocGoi(LoaiCuocGoi);
            }
            SQLCondition += GetSQLStringQueryPhoneNumbers(PhoneNumber);
            if (SoLuotDoChuong > 1)
                SQLCondition += " AND ( SoLuotDoChuong >= " + SoLuotDoChuong.ToString() + ") ";

            if (ThoiGianDamThoai != DateTime.MinValue)
                SQLCondition += " AND ( Duration > cast('" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", ThoiGianDamThoai) + "' as Datetime ) )";

            return SQLCondition;
        }
        /// - Loai Cuoc goi, 1 : Goi Taxi, 3 : GoiLai 7 : GoiKhac
        ///                      4 : GoiTaxi + GoiLai
        ///                      8 : GoiTaxi+GoiKhac
        ///                      10 : GoiLai + Goi Khac
        ///                      11 : GoiTaxi + GoiLai + GoiKhac
        private string GetSQLStringQueryLoaiCuocGoi(int LoaiCuocGoi)
        {
            string strReturn = string.Empty;
            switch (LoaiCuocGoi)
            {
                case 1: { strReturn = " AND (GoiTaxi='1') "; break; }
                case 3: { strReturn = " AND (GoiLai='1') "; break; }
                case 7: { strReturn = " AND (ThongTinKhac='1') "; break; }
                case 4: { strReturn = " AND ((GoiTaxi='1') OR (GoiLai='1')) "; break; }
                case 8: { strReturn = " AND ((GoiTaxi='1') OR (ThongTinKhac='1'))  "; break; }
                case 10: { strReturn = " AND ((GoiLai='1') OR (ThongTinKhac='1'))  "; break; }
                case 11: { strReturn = " AND ((GoiTaxi='1') OR (GoiLai='1') OR (ThongTinKhac='1'))  "; break; }
                
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
        //private void btnPrint_Click(object sender, EventArgs e)
        //{
         //   frmInBaoCao frmPrint = new frmInBaoCao();
        //    //frmPrint.InBaoCaoBieuMau3(Configuration.GetReportPath() + "\\Baocao_Bieumau3.rpt", g_lstBaoCaoBieuMau3, calTuNgay.Value, calDenNgay.Value, GetLoaiCuocGoi(), StringTools.TrimSpace(editBienSoXe.Text), editSoChuong.Text, string.Format("{0: HH:mm:ss}", timeThoiGianDamThoai.Value ));  
        //    frmPrint .ShowDialog();
        //}

         

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau17.xls";
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
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiTaxi_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiLai_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void chkGoiKhac_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
           
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editSoChuong_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
 
 
        private void timeThoiGianDamThoai_TextChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
    }
}