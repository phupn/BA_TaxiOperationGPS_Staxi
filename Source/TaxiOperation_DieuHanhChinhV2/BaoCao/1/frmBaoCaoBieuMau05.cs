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

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoBieuMau5 : Form
    {
        List<DieuHanhTaxi> g_lstCuocGoiKetThuc = new List<DieuHanhTaxi> ();
        int g_ThoiGianDieuXe = 0;
        int g_ThoiGianDonKhach = 0;
        int g_ThoiDiemChuyenTongDai = 0;
        public frmBaoCaoBieuMau5()
        {
            InitializeComponent();
        }
        private void frmBaoCaoBieuMau5_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = btnRefresh.Enabled;
            btnExportExcel.Enabled = btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                string strPhoneNumber = string.Empty;   
               //Vung
                string strVung = string.Empty;
                if (StringTools.TrimSpace(editVung .Text).Length > 0)
                {
                    strVung = editVung.Text;
                }
                //ThoiDiemChuyenTongDai (giay)                
                g_ThoiDiemChuyenTongDai = timeThoiGianChuyenTongDai.Value.Hour * 3600 + timeThoiGianChuyenTongDai.Value.Minute * 60 + timeThoiGianChuyenTongDai.Value.Second; 
               
                // ThoiGianDieuXe (phut)
                g_ThoiGianDieuXe = timeThoiGianDieuXe.Value.Hour * 60 + timeThoiGianDieuXe.Value.Minute;
                  
                // ThoiGianDonKhach (phut)
                g_ThoiGianDonKhach = timeThoiGianDonKhach.Value.Hour * 60 + timeThoiGianDonKhach.Value.Minute; 
                
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                
                string NRecords = "";
                int MoiGioiVangLai = 0; //0 ca moi gioi và vang lai; 1 : Môi giới, 3 : Vãng lai,  4 : Cac vang lai va moi giới 
                if (chkMoiGioi.Checked) MoiGioiVangLai = 1;
                if (chkVangLai.Checked) MoiGioiVangLai += 3;
                string SQLCondition = this.BuildStringQuery(calTuNgay.Value, calDenNgay.Value, StringTools.TrimSpace(this.editDienThoai.Text), strVung, g_ThoiDiemChuyenTongDai, g_ThoiGianDieuXe, g_ThoiGianDonKhach, MoiGioiVangLai);
                g_lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);

                gridDienThoai.SetDataBinding(g_lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
                btnRefresh.Enabled = false ;
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

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false ;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
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
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay, string PhoneNumber, string Vung, int ThoiDiemChuyenTongDai, int ThoiGianDieuXe, int ThoiGianDonKhach, int MoiGioiVangLai)
        {
            string SQLCondition = string.Empty;
            string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay);
            string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay);

            SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
           // cuoc goi co xe don duoc
            SQLCondition += " AND ( LEN(XeDon) >0) ";
            if (Vung.Length  > 0)
            {
                SQLCondition += GetSQLStringQueryVung(Vung);
            }
            if (PhoneNumber.Length >= 9)
                SQLCondition += " AND ( PhoneNumber  LIKE '%" + PhoneNumber + "') ";

            if(ThoiDiemChuyenTongDai>0)
                SQLCondition += " AND ( ThoiDiemChuyenTongDai >= " + ThoiDiemChuyenTongDai.ToString() + ") ";
            //ThoiGianDieuXe
            //ThoiGianDonKhach
            if (ThoiGianDieuXe > 0)
                SQLCondition += " AND ( ThoiGianDieuXe >= " + ThoiGianDieuXe.ToString() + ") ";

            if (ThoiGianDonKhach > 0)
                SQLCondition += " AND ( ThoiGianDonKhach > " + ThoiGianDonKhach.ToString() + ") ";
            // chon moi gioi vang lai
            if ((MoiGioiVangLai == 0) || (MoiGioiVangLai == 4)) // không cần gán điều kiện
            { }
            else if (MoiGioiVangLai == 1)  // chọn môi giới
            {
                SQLCondition += " AND ( KieuKhachHangGoiDen ='2' ) ";
            }
            else if (MoiGioiVangLai == 3)  // chọn môi giới
            {
                SQLCondition += " AND ( KieuKhachHangGoiDen <> '2' ) ";
            }


            return SQLCondition;
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
                strReturn += "OR   (Vung = " +  arrVung[i] + " ) ";
            }
            strReturn = " AND (" + strReturn + ")";
            return strReturn;
        }
     
       
        


        private void editPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit ( e.KeyChar) || (e.KeyChar == (char) Keys.Back ))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        // int ascii = Convert.ToInt16(e.KeyChar);
        //    if (char.IsDigit(e.KeyChar) || (e.KeyChar==(char)Keys.Back ) || (ascii == 46)) // dau cham "."
        private void editSoChuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = Convert.ToInt16(e.KeyChar);
            if (char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back) || (ascii  == 59 )) // dau ';'
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
               

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //string MoiGioiVangLai = "";
            //if (chkMoiGioi.Checked) MoiGioiVangLai += "Môi giới";
            //if (chkVangLai.Checked) MoiGioiVangLai += "/VãngLai";
            //frmPrint.InBaoCaoBieuMau5(Configuration.GetReportPath() + "\\Baocao_Bieumau5.rpt",g_lstCuocGoiKetThuc, calTuNgay.Value, calDenNgay.Value, StringTools.TrimSpace(editDienThoai.Text), g_ThoiDiemChuyenTongDai.ToString(), g_ThoiGianDieuXe.ToString(), g_ThoiGianDonKhach.ToString(),MoiGioiVangLai);
            //frmPrint.ShowDialog();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau5.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

        private void editPhut_TextChanged(object sender, EventArgs e)
        {

        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editVung_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editDienThoai_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void timeThoiGianChuyenTongDai_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void timeThoiGianDieuXe_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void timeThoiGianDonKhach_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkMoiGioi_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkVangLai_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

       

       
        
    }
}