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
    public partial class frmBaoCaoBieuMau6 : Form
    {
        private int g_ThoiGianDieuXe = 0;  
        private List<BaoCaoBieuMau3> g_lstBaoCaoBieuMau6 = new List<BaoCaoBieuMau3>();
        public frmBaoCaoBieuMau6()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = false;
            btnExportExcel.Enabled = false;
        
        }
        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
            btnPrint.Enabled = !btnRefresh.Enabled;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {                           
                //Vung
                string strVung = string.Empty;
                
                if (StringTools.TrimSpace(editVung.Text).Length > 0)
                {
                    strVung = editVung.Text;
                }
                int ThoiGianChuyenTongDai = timeChuyenTongDai.Value.Hour * 3600 + timeChuyenTongDai.Value.Minute * 60 + timeChuyenTongDai.Value.Second ;
                // ThoiGianDieuXe (phut)
                g_ThoiGianDieuXe = timeThoiGianDieuXe.Value.Hour * 60 + timeThoiGianDieuXe.Value.Minute;
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();
                string NRecords = "";
                string SQLCondition = this.BuildStringQuery(calTuNgay.Value, calDenNgay.Value, strVung,ThoiGianChuyenTongDai,g_ThoiGianDieuXe, chkTruot.Checked, chkKhachHoan.Checked, chkKhongXe.Checked);
                lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);

                g_lstBaoCaoBieuMau6 = ConvertToBaoCaoBieuMau3(lstCuocGoiKetThuc);
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(g_lstBaoCaoBieuMau6, "lstCuocGoiKetThuc");
                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }
          private void btnPrint_Click(object sender, EventArgs e)
        {
            //string strTruotHoanKhongXe = "";
            //if(chkTruot.Checked) strTruotHoanKhongXe = " Trượt;";
            //if(chkKhachHoan.Checked) strTruotHoanKhongXe += " Khách hoãn;";
            //if(chkKhongXe.Checked) strTruotHoanKhongXe+= " Không xe";

            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau6(Configuration.GetReportPath() + "\\Baocao_Bieumau6.rpt", g_lstBaoCaoBieuMau6, calTuNgay.Value, calDenNgay.Value, editVung.Text, g_ThoiGianDieuXe.ToString(), strTruotHoanKhongXe);
            //frmPrint.ShowDialog();
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
                    objBM3.PhoneNumber = objDHTX.PhoneNumber;
                    objBM3.ThoiDiemGoi = objDHTX.ThoiDiemGoi;
                    objBM3.SoLuotDoChuong = objDHTX.SoLuotDoChuong;
                    objBM3.GoiTaxi = objDHTX.GoiTaxi;
                    objBM3.GoiLai = objDHTX.GoiLai;
                    objBM3.ThongTinKhac = objDHTX.ThongTinKhac;
                    objBM3.DiaChiDonKhach = objDHTX.DiaChiDonKhach;
                    objBM3.KieuKhachHangGoiDen = objDHTX.KieuKhachHangGoiDen;
                    objBM3.XeNhan = objDHTX.XeNhan;
                    if (objDHTX.XeDon.Length > 0)
                        objBM3.DonDuocKhach = true;
                    else objBM3.DonDuocKhach = false;
                    // truot 
                    if (objDHTX.GhiChuTongDai.Contains("trượt"))
                        objBM3.TruotKhach = true;
                    else objBM3.TruotKhach = false;

                    if (objDHTX.GhiChuTongDai.Contains("hoãn"))
                        objBM3.KhachHoan = true;
                    else objBM3.KhachHoan = false;
                    if (objDHTX.MOIKHACH_LenhMoiKhach .Contains("đã xin lỗi"))
                        objBM3.KhongXe = true;
                    else objBM3.KhongXe = false;

                    objBM3.DoDaiCuocGoi = objDHTX.DoDaiCuocGoi;
                    objBM3.FileVoicePath = objDHTX.FileVoicePath;
                    objBM3.MaNhanVienDienThoai = objDHTX.MaNhanVienDienThoai;
                    objBM3.MaNhanVienTongDai = objDHTX.MaNhanVienTongDai;
                  
                    objBM3.ThoiDiemChuyenTongDai = objDHTX.ThoiDiemChuyenTongDai;


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
       /// Xay dung chuoi query sql
       /// </summary>
       /// <param name="TuNgay"></param>
       /// <param name="DenNgay"></param>
       /// <param name="strVung"></param>
       /// <param name="ThoiGianDieuXe"></param>
       /// <returns></returns>
        private string BuildStringQuery(DateTime TuNgay, DateTime DenNgay, string strVung,int ThoiGianChuyenTongDai,int ThoiGianDieuXe, bool TruotKhach, bool KhachHoan, bool KhongXe)
        {
            string SQLCondition = string.Empty;
            string SQLKhachHoanKhongXe = string.Empty;
            string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", TuNgay);
            string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DenNgay);

            SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
        		
            // Cuoc goi khong dong duoc khch
            string SQLTruotKhach = "";
            if(TruotKhach)
                SQLTruotKhach = " OR (GhiChuTongDai LIKE N'%trượt%')";
           
            string SQLKhachHoan = "";
            if(KhachHoan )
                SQLKhachHoan = "OR (GhiChuTongDai LIKE N'%hoãn%')";
            string SQLKhongXe = "";
            if (KhongXe )
                SQLKhongXe = " OR ( [MOIKHACH_LenhMoiKhach] LIKE N'%đã xin lỗi%')";

            SQLKhachHoanKhongXe = " AND ((1<>1) " + SQLTruotKhach + SQLKhachHoan + SQLKhongXe + ")";

            if((KhachHoan==false ) && (TruotKhach ==false ) && (KhongXe ==false ))
                SQLKhachHoanKhongXe = " AND ((GhiChuTongDai LIKE N'%trượt%') OR (GhiChuTongDai LIKE N'%hoãn%') OR ([MOIKHACH_LenhMoiKhach] LIKE N'%đã xin lỗi%')) ";

             SQLCondition += SQLKhachHoanKhongXe;

            if (strVung.Length > 0)
            {
                SQLCondition += GetSQLStringQueryVung(strVung);
            }

            if (ThoiGianDieuXe > 1)
                SQLCondition += " AND ( ThoiGianDieuXe >= " + ThoiGianDieuXe.ToString() + ") ";
            if (ThoiGianChuyenTongDai > 0) SQLCondition += " AND ( ThoiDiemChuyenTongDai >= " +  ThoiGianChuyenTongDai .ToString() + ") ";

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
                
                    
            }
            catch (Exception ex)
            {

            }
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    frmInBaoCao frmPrint = new frmInBaoCao();
        //    frmPrint.InBaoCaoBieuMau5(Configuration.GetReportPath() + "\\Baocao_Bieumau6.rpt",g_lstBaoCaoBieuMau6  , calTuNgay.Value, calDenNgay.Value, StringTools.TrimSpace(editDienThoai.Text), g_ThoiDiemChuyenTongDai.ToString(), g_ThoiGianDieuXe.ToString(), g_ThoiGianDonKhach.ToString());
        //    frmPrint.ShowDialog();
        //}

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

        private void timeThoiGianDieuXe_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkTruot_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkKhachHoan_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void chkKhongXe_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }




        #region play wave sound
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string filenameDB = "";
            string filenameVoice = "";
            gridDienThoai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            BaoCaoBieuMau3 objItem = null;

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

        private void timeChuyenTongDai_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

    }
}