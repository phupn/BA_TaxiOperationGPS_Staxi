using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;


namespace Taxi.GUI.BaoCao
{
    public partial class frmBaoCaoCSKHTongHop : Form
    {
        private DataTable g_dtDuLieu;
        public frmBaoCaoCSKHTongHop()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau3_Load(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnExportExcel.Enabled = false;

            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();
            calTuNgay.Value = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calDenNgay.Value = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0); 
        }



        private void SetActiveRefreshButton()
        {
            btnRefresh.Enabled = true;
            btnExportExcel.Enabled = !btnRefresh.Enabled;
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


                string sVung = "";
                int  SoLanKhachGoiLai = 0;
                sVung = StringTools.TrimSpace(txtVung.Text);
                string idCSKH = StringTools.TrimSpace(txtIDCS.Text);
                int.TryParse(txtSoLanGoi.Text, out SoLanKhachGoiLai);

                int loaiSoDienThoai = 9;
                if (radMoiGioi.Checked)
                    loaiSoDienThoai = 1;
                else if (radVangLaiDiDong.Checked)
                    loaiSoDienThoai = 2;
                else if (radVLCD.Checked)
                    loaiSoDienThoai = 3;
                else loaiSoDienThoai = 0;

                g_dtDuLieu = TimKiem_BaoCao.CSKH_BaoCaoTongHop(calTuNgay.Value, calDenNgay.Value, sVung, SoLanKhachGoiLai,idCSKH,loaiSoDienThoai);
                gridEX1.DataMember = "ListDienThoai";
                gridEX1.SetDataBinding(g_dtDuLieu, "ListDienThoai"); 

                SetUnActiveRefreshButton();
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", Taxi.MessageBox.MessageBoxButtonsBA.OK, Taxi.MessageBox.MessageBoxIconBA.Warning);
            }
        }

       
       
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string FilenameDefault = "BaoCao_CSKH_TongHop.xls";
                saveFileDialog1.FileName = FilenameDefault;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        gridEXExporter1.Export(fs);
                    }

                    if (new MessageBox.MessageBoxBA().Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                    {
                        FileTools.OpenFileExcel(saveFileDialog1.FileName);
                    }
                }
            }
            catch
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

        private void txtSoLanGoi_TextChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radMoiGioi_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radVangLaiDiDong_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radVLCD_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            SetActiveRefreshButton();
        }

    }
}