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
using Taxi.Business.DM;
using Janus.Windows.GridEX;

namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoKhachQuen : Form
    {
        List<DieuHanhTaxi> g_lstCuocGoiKetThuc = new List<DieuHanhTaxi> ();
        int g_ThoiGianDieuXe = 0;
        int g_ThoiGianDonKhach = 0;
        int g_ThoiDiemChuyenTongDai = 0;
        public frmBaoCaoKhachQuen()
        {
            InitializeComponent();
        }
        private void frmBaoCaoBieuMau5_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
           
            btnExportExcel.Enabled = btnRefresh.Enabled;
            
        }
        private void LoadListXe()
        {
           
             
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
               int SoCuoc = 0;
                bool IsCoDinh = true;
                try{
                    SoCuoc = Convert.ToInt32(txtSoCuoc.Text );
                }
                catch (Exception ex)
                {
                    SoCuoc =0;
                     MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                     msgDialog.Show(this, "Bạn phải nhập số cuốc phải lớn hơn 0.", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
 
                    return;
                } 
                gridEX1 .DataMember = "lstKhachHang";

                if(checkBox1.Checked)
                    gridEX1.SetDataBinding(TimKiem_BaoCao.BaoCaoKhachHangThanThietDaCoMa (calTuNgay.Value, calDenNgay.Value, SoCuoc), "lstKhachHang");
                else
                    gridEX1.SetDataBinding(TimKiem_BaoCao.BaoCaoKhachHangThanThiet(calTuNgay.Value, calDenNgay.Value, SoCuoc), "lstKhachHang");

                btnRefresh.Enabled = false ;                
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
           // btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false ;
          //  btnPrint.Enabled = !btnRefresh.Enabled;
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
                //gridDienThoai.DataMember = "lstCuocGoiKetThuc";
               // gridDienThoai.SetDataBinding(lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
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
            string strReturn = string.Empty;
            string[] arrVung = Vung.Split(";".ToCharArray());

            foreach (string strV in arrVung)
            {
                if (strV.Length > 0) strReturn = " AND (Vung = " + strV + ") ";
            }
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
         

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCaoKhachHangThanThiet.xls";
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

        private void cboDXXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void gridEX1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void gridEX1_DoubleClick(object sender, EventArgs e)
        {
            gridEX1.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (gridEX1.SelectedItems.Count > 0)
            {
                GridEXRow row = ((GridEXSelectedItem)gridEX1.SelectedItems[0]).GetRow () ;                 
                new frmBaoCaoKhachQuen_ChiTiet(calTuNgay.Value,calDenNgay.Value,row.Cells["SoDienThoai"].Value.ToString()).ShowDialog();
            }
        }

        private void radSoCoDinh_CheckedChanged(object sender, EventArgs e)
        {
            this.SetActiveRefreshButton();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.SetActiveRefreshButton();
        }

        private void txtSoCuoc_TextChanged(object sender, EventArgs e)
        {
            this.SetActiveRefreshButton();
        }

       

       
        
    }
}