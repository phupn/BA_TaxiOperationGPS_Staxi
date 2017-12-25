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
    public partial class frmBC_1_5_KhongNhacMay : Form
    {
        private List<DieuHanhTaxi> g_lstCuocGoiKetThuc;
        public frmBC_1_5_KhongNhacMay()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
           
            btnExportExcel.Enabled = btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                
                DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                g_lstCuocGoiKetThuc = new List<DieuHanhTaxi>();

                string sLine = StringTools.TrimSpace(txtLine.Text);
                string SQLCondition = string.Empty;
                string strTuNgay  = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calTuNgay.Value);
                string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calDenNgay.Value);

                SQLCondition = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
                // Cuoi goi nho
                SQLCondition += " AND (GhiChuDienThoai LIKE N'%nhỡ%') ";
                string soDienThoai = StringTools.TrimSpace(txtDienThoai.Text);
                if (soDienThoai.Length > 0)
                {
                    SQLCondition += " AND (PhoneNumber LIKE '%" + soDienThoai + "%')";
                }
                string idNhanVien = StringTools.TrimSpace  (txtNhanVien.Text);
                if (idNhanVien.Length > 0)
                {
                    SQLCondition += " AND (MaNhanVienDienThoai = '" + idNhanVien + "')";
                }
                if (sLine.Length > 0)
                {
                    SQLCondition += " AND (Line = '" + sLine + "')";
                }


                string NRecords = "";                
                g_lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, SQLCondition);
                // tim cuoc thuc hien lai cho khach
                if (g_lstCuocGoiKetThuc != null && g_lstCuocGoiKetThuc.Count > 0)
                {
                    List<string> danhsachThoiDiemGoiLai = new List<string>();
                    foreach (DieuHanhTaxi item in g_lstCuocGoiKetThuc)
                    {
                        danhsachThoiDiemGoiLai.Add(DieuHanhTaxi.GetThoiDiemGoiLaiCuocGioNho(item.ThoiDiemGoi, item.PhoneNumber));
                    }
                    // dong nhat vao ghi chú 
                    for(int i=0 ;i<g_lstCuocGoiKetThuc.Count ;i++)
                    {
                        g_lstCuocGoiKetThuc[i].GhiChuDienThoai = danhsachThoiDiemGoiLai[i];
                    }
                }
                gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                gridDienThoai.SetDataBinding(g_lstCuocGoiKetThuc, "lstCuocGoiKetThuc");
                btnRefresh.Enabled = false;
               
                btnExportExcel.Enabled = !btnRefresh.Enabled;
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
            //if (g_lstCuocGoiKetThuc != null)
            //{
            //    if (g_lstCuocGoiKetThuc.Count > 0)
            //    {
            //        frmInBaoCao frmPrint= new frmInBaoCao();
            //        frmPrint.InBaoCaoBieuMau4(Configuration.GetReportPath() + "\\Baocao_Bieumau4.rpt", g_lstCuocGoiKetThuc, calTuNgay.Value, calDenNgay.Value);
            //        frmPrint.ShowDialog(this);
            //    }
            //    else
            //    {
            //        MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
            //        msgDialog.Show(this, "Không có dữ liệu để tạo báo cáo", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau4.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.YesNoCancel, Taxi.MessageBox.MessageBoxIconBA.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true ;
            
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

            btnRefresh.Enabled = true;

            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void txtNhanVien_TextChanged(object sender, EventArgs e)
        {

            btnRefresh.Enabled = true;

            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }

        private void txtLine_TextChanged(object sender, EventArgs e)
        {

            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        
    }
}