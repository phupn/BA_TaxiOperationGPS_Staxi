using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;
using Janus.Windows.GridEX;

namespace Taxi.GUI.ThanhCong 
{
    public partial class frmBC_1_1_TongHopCuocGoiDenTheoGio : Form
    {
        private DataTable g_dt = new DataTable();
        private DataTable danhSachBinhQuan = new DataTable();
        public frmBC_1_1_TongHopCuocGoiDenTheoGio()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBieuMau2_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
        }

        private void KhoiTaoDuLieu()
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();           
            
            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = DateTime.Now; 
        }
 
        /// <summary>
        /// Load phan len bieu mau
        /// </summary>        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                LoadData(calTuNgay.Value, calDenNgay.Value);
            }
            else
            {
                MessageBox.MessageBoxBA msgDialog = new MessageBox.MessageBoxBA();
                msgDialog.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBox.MessageBoxButtonsBA.OK, MessageBox.MessageBoxIconBA.Warning);
            }            
        }
        
        private void LoadData(DateTime TuNgay, DateTime DenNgay   )
        {
            string id = string.Empty;
            g_dt = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGio(TuNgay, DenNgay, ref id);
            griTongCuocGoiDen.DataMember = "ListDienThoai";
            griTongCuocGoiDen.SetDataBinding(g_dt, "ListDienThoai");             
            danhSachBinhQuan = new TimKiem_BaoCao().GROUP_BC_1_1_BaoCaoTongHopCuocGoiDenTheoGioBinhQuan(id);
            gridBinhQuan.DataMember = "ListBQ";
            gridBinhQuan.SetDataBinding(danhSachBinhQuan, "ListBQ");
            btnRefresh.Enabled = false;            
            btnExportExcel .Enabled = !btnRefresh.Enabled;           
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {            
            saveFileDialog1.FileName = FileTools.GetFilenameReport("BC_1_1_TongHopGoiDenGio", calTuNgay.Value, calDenNgay.Value, false);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX1.DataMember = "list1";
                gridEX1.SetDataBinding(g_dt, "list1");
                gridEXExporter1.GridEX = gridEX1; 
                gridEXExporter1.Export(objFile);
                objFile.Close();
                string Directory = new FileInfo(saveFileDialog1.FileName).DirectoryName;
                saveFileDialog1.FileName = Directory + "\\" + FileTools.GetFilenameReport("BC_1_1_TongHopGoiDenGioBinhQuan", calTuNgay.Value, calDenNgay.Value, false);
                objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                gridEX2.DataMember = "listBinhQuan";
                gridEX2.SetDataBinding(danhSachBinhQuan, "listBinhQuan");
                gridEXExporter1.GridEX = gridEX2;
                gridEXExporter1.Export(objFile);
                if (new MessageBox.MessageBoxBA().Show(this,"Tạo 2 file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBox.MessageBoxButtonsBA.YesNoCancel, MessageBox.MessageBoxIconBA.Question) == DialogResult.Yes.ToString())
                {
                    FileTools.OpenDirectory(new FileInfo(saveFileDialog1.FileName).DirectoryName);
                }
                objFile.Close();
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

        private void griTongCuocGoiDen_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.GroupFooter)
            {
                try
                {
                    double donDuoc = Convert.ToDouble (e.Row.Cells["TongDonDuoc"].Value.ToString());
                    double  cuocTaxi = Convert.ToDouble (e.Row.Cells["TongTaxi"].Value.ToString());
                    if(cuocTaxi>0)
                    {
                        e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0:#.#}", Convert.ToDouble(donDuoc / cuocTaxi * 100));
                    }
                }
                catch (Exception ex)
                {
                    LogError.WriteLogError("griTongCuocGoiDen_FormattingRow",ex);
                }
            }
        }
    }
}