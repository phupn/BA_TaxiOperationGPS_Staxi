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

namespace Taxi.GUI.BaoCao
{
    public partial class frm_5_6_BaoCaoMoiGioiTheoBangKe : Form
    {
        private fmProgress m_fmProgress = null;
        //List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi=new List<BacCao_CuocGoiMoiGioi> ();
        private string g_MaNhanVien="";
        private int  g_SoChuyen = -1; // tat ca
        private int g_CongTyID = 0;
        private bool g_DaLoadDuLieu = false; // da thuc hien load du lieu
        private DataTable g_dtDuLieu;
        public frm_5_6_BaoCaoMoiGioiTheoBangKe()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false ; 
            btnExportExcel.Enabled = false;  
            LoadDSCongTy();
            LoadDSDoiTac();
        }
     
        private void LoadDSCongTy()
        {
            cboCongTy.ValueMember = "CongTyID";
            cboCongTy.DisplayMember = "TenCongTy";
            cboCongTy.DataSource = null;
            cboCongTy.DataSource = CongTy.GetListOfCongTys_NAME();
            cboCongTy.SelectedIndex = 0;
        }

        private void LoadDSDoiTac()
        {
            DoiTac objDoiTac = new DoiTac();
            cboKH.DisplayMember = "Name";
            cboKH.ValueMember = "Ma_DoiTac";
            cboKH.DataSource = null;
            cboKH.DataSource = (new DoiTac()).GetListOfDoiTacs_NAME();
            cboKH.SelectedIndex = 0;            
        }

        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true; 
            btnExportExcel.Enabled = !btnRefresh.Enabled;
            g_DaLoadDuLieu = false;
        }
        private void SetUnActiveRefreshButton()
        {
            btnRefresh.Enabled = false;
             
            btnExportExcel.Enabled = !btnRefresh.Enabled;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                string strCongtyID = cboCongTy.SelectedValue.ToString();
                string strMaKH = cboKH.SelectedValue.ToString();
                g_dtDuLieu = (new BangKe()).BaoCaoCuocKhachMoGioi_BangKe(strMaKH, strCongtyID, calTuNgay.Value, calDenNgay.Value);
                gridDienThoai.DataMember = "tblDSBangKe";
                gridDienThoai.SetDataBinding(g_dtDuLieu, "tblDSBangKe");

                gridEX1.DataMember = "tblDSBangKe";
                gridEX1.SetDataBinding(g_dtDuLieu, "tblDSBangKe");
                SetUnActiveRefreshButton();  
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new Taxi.MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
                return;
            }
        }

        private void gridDienThoai_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            
        } 
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_MoiGioi_BangKe";
                DateTime frmDate = calTuNgay.Value;
                DateTime toDate = calDenNgay.Value;
                string rptDate = String.Format("{0}{1}{2}-{3}{4}{5}", frmDate.Year, frmDate.Month, frmDate.Day, toDate.Year, toDate.Month, toDate.Day);
                saveFileDialog1.FileName = String.Format("{0}_{1}.xls", FilenameDefault, rptDate);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {                    
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    new MessageBox.MessageBoxBA().Show("Tạo file Excel thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                new MessageBox.MessageBoxBA().Show("Có lỗi tạo file Excel.", "Thông báo");
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

        private void editNhanVien_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboNhanVien_SelectedValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void editSochuyen_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepMaKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radSapXepSoChuyen_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void intSoChuyen_ValueChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetActiveRefreshButton();
            try
            {
                g_CongTyID = int.Parse(cboCongTy.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                g_CongTyID = 0;
            }
        }
    }
}