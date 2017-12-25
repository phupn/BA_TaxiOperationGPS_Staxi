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
    public partial class frmBC_6_7_MoiGioiTheoDiaChi : Form
    {

        private List<BaoCao_BieuMau8> g_lstBaoCaoBieuMau8 = new List<BaoCao_BieuMau8>();
        public frmBC_6_7_MoiGioiTheoDiaChi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            LoadMoiGioi();
            btnRefresh.Enabled = false;
            btnPrint.Enabled = false;
            btnExportExcel.Enabled = false;
        }
        private void LoadMoiGioi()
        {
            DoiTac objDoiTac = new DoiTac();
            cboMoiGioi.DisplayMember = "Name";
            cboMoiGioi.ValueMember = "MaDoiTac";
            cboMoiGioi.DataSource = objDoiTac.GetListOfDoiTacs();
 
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
                if(cboMoiGioi.SelectedItem !=null)
                {
                    List<DieuHanhTaxi> lstCuocGoiKetThuc = new List<DieuHanhTaxi>();
                    TimKiem_BaoCao  objBaoCao = new TimKiem_BaoCao();
                    DoiTac objDT = (DoiTac)cboMoiGioi.SelectedItem;
                    if(objDT !=null){
                        lstCuocGoiKetThuc = objBaoCao.GetBaoCao_ChiTietCuocGoiMoiGioiByMaDoiTac(calTuNgay.Value, calDenNgay.Value, objDT);

                        g_lstBaoCaoBieuMau8 = TimKiem_BaoCao.ConvertToBaoCaoBieuMau10(lstCuocGoiKetThuc);
                        gridDienThoai.DataMember = "lstCuocGoiKetThuc";
                        gridDienThoai.SetDataBinding(g_lstBaoCaoBieuMau8, "lstCuocGoiKetThuc");
                        SetUnActiveRefreshButton();
                    }
                }
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
            //frmInBaoCao frmPrint = new frmInBaoCao();
            //frmPrint.InBaoCaoBieuMau10(Configuration.GetReportPath() + "\\Baocao_Bieumau10.rpt", g_lstBaoCaoBieuMau8, calTuNgay.Value, calDenNgay.Value, cboMoiGioi.Text, lblDiaChi.Text, lblDienThoai.Text, lblNhanVien.Text);  
            //frmPrint.ShowDialog();
        }

        private void cboMoiGioi_ValueChanged(object sender, EventArgs e)
        {
            DoiTac objDT = (DoiTac)cboMoiGioi.SelectedItem;
            lblDiaChi.Text = objDT.Address;
            lblDienThoai.Text = objDT.Phones;
            // lay thong tin nhan vien 
            Users objUser = new Users(objDT.MaNhanVien);
            if (objUser != null)
                lblNhanVien.Text = objUser.FullName;
            else lblNhanVien.Text = "";
            SetActiveRefreshButton();
        }

        private void calTuNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void calDenNgay_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BaoCao_BieuMau10.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEXExporter1.Export((Stream)objFile);
                new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
            }
        }

       

       
    }
}