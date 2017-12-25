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

namespace Taxi.GUI 
{
    public partial class frmBC_6_5_BaoCaoMoiGioiTheoDiaChi : Form
    {
        private fmProgress m_fmProgress = null;
        List<BacCao_CuocGoiMoiGioi> g_lstBacCao_CuocGoiMoiGioi=new List<BacCao_CuocGoiMoiGioi> ();
        

        private string g_MaNhanVien="";
        private int  g_SoChuyen = -1; // tat ca
        private int g_CongTyID = 0;
        private bool g_DaLoadDuLieu = false; // da thuc hien load du lieu
        private DataTable g_dtDuLieu;
        public frmBC_6_5_BaoCaoMoiGioiTheoDiaChi()
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
                //-------------------------------------------------------------------
                // congnt them tinh thoi gian theo ca 
                //-------------------------------------------------------------------
                DateTime dateGioDauCa;
                // lay gio cua ca
                DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                try
                {
                    dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
                }
                catch (Exception ex)
                {
                    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                }
                DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, 0, 0);
                DateTime DenNgay = calDenNgay.Value;
                DenNgay = DenNgay.AddDays(1);
                DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, dateGioDauCa.Hour - 1, 59, 59);
                lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);
                //-------------------------------------------------------------------

                string strCongtyID = cboCongTy.SelectedValue.ToString();
                string strMaKH = cboKH.SelectedValue.ToString();
                g_dtDuLieu = (new BangKe()).BaoCaoChiTietCuocKhachMoGioi_DiaChi(strMaKH, strCongtyID, TuNgay, DenNgay );
                gridReport.DataMember = "tblBaoCao";
                gridReport.SetDataBinding(g_dtDuLieu, "tblBaoCao");

                gridEX1.DataMember = "tblDSBangKe";
                gridEX1.SetDataBinding(g_dtDuLieu, "tblDSBangKe");
                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBox msgDialog = new Taxi.MessageBox.MessageBox();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtons.OK, Taxi.MessageBox.MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_ChiTiet_CuocKhach_MG_DiaChi";
                DateTime frmDate = calTuNgay.Value;
                DateTime toDate = calDenNgay.Value;
                string rptDate = String.Format("{0}{1}{2}-{3}{4}{5}", frmDate.Year, frmDate.Month, frmDate.Day, toDate.Year, toDate.Month, toDate.Day);
                saveFileDialog1.FileName = String.Format("{0}_{1}.xls", FilenameDefault, rptDate);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (gridReport.Visible)
                    {
                        gridReport.Visible = true;
                        gridReport.DataMember = "ListReport";
                        gridReport.SetDataBinding(g_dtDuLieu, "ListReport");

                        gridEXExporter1.GridEX = this.gridEX1;
                    }                    
                    FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                    gridEXExporter1.Export((Stream)objFile);
                    gridEX1.Visible = false;
                    new MessageBox.MessageBox().Show("Tạo file Excel thành công.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                gridEX1.Visible = false;
                new MessageBox.MessageBox().Show("Có lỗi tạo file Excel.", "Thông báo");
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

        private void cboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetActiveRefreshButton();
        }

        private void cboKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }        
    }
}