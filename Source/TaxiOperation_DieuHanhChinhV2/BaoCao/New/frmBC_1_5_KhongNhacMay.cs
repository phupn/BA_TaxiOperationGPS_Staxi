using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taxi.Business;
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
            try
            {
                if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
                {
                    DieuHanhTaxi objDHTaxi = new DieuHanhTaxi();
                    g_lstCuocGoiKetThuc = new List<DieuHanhTaxi>();
                    string sLine = StringTools.TrimSpace(txtLine.Text);
                    string strWhereClause = string.Empty;
                    string strTuNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calTuNgay.Value);
                    string strDenNgay = string.Format("{0:yyyy-MM-dd HH:mm:ss}", calDenNgay.Value);
                    strWhereClause = " AND ((ThoiDiemGoi >= cast('" + strTuNgay + "' as datetime)) AND (ThoiDiemGoi <= cast('" + strDenNgay + "' as datetime))) ";
                    strWhereClause += " AND (GhiChuDienThoai LIKE N'%nhỡ%') ";
                    string soDienThoai = StringTools.TrimSpace(txtDienThoai.Text);
                    if (soDienThoai.Length > 0)
                    {
                        strWhereClause += " AND (PhoneNumber LIKE '%" + soDienThoai + "%')";
                    }
                    string idNhanVien = StringTools.TrimSpace(txtNhanVien.Text);
                    if (idNhanVien.Length > 0)
                    {
                        strWhereClause += " AND (MaNhanVienDienThoai Like '%" + idNhanVien + "%')";
                    }
                    if (sLine.Length > 0)
                    {
                        strWhereClause += " AND (Line = '" + sLine + "')";
                    }

                    string NRecords = " Top 1000 ";
                    g_lstCuocGoiKetThuc = objDHTaxi.Get_CuocGoi_KetThuc(NRecords, strWhereClause);
                    if (g_lstCuocGoiKetThuc != null && g_lstCuocGoiKetThuc.Count > 0)
                    {
                        List<string> danhsachThoiDiemGoiLai = new List<string>();
                        foreach (DieuHanhTaxi item in g_lstCuocGoiKetThuc)
                        {
                            danhsachThoiDiemGoiLai.Add(DieuHanhTaxi.GetThoiDiemGoiLaiCuocGioNho(item.ThoiDiemGoi, item.PhoneNumber));
                        }

                        for (int i = 0; i < g_lstCuocGoiKetThuc.Count; i++)
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
                    MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                    msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("btnRefresh_Click : ",ex);                
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCaoCuocGoiKhongNhacMay_"+string.Format("{0:yyyy-MM-dd-HH-mm}",CommonBL.GetTimeServer())+".xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export(objFile);
                if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
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