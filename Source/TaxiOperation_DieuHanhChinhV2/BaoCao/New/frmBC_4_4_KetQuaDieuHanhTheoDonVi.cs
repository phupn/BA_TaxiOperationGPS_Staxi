using System;
using System.Data;
using System.Windows.Forms;
using Taxi.Business;
using System.IO;
using Taxi.Utils;

namespace TaxiOperation_DieuHanhChinh.BaoCao.New
{
    public partial class frmBC_4_4_KetQuaDieuHanhTheoDonVi : Form
    {
        public frmBC_4_4_KetQuaDieuHanhTheoDonVi()
        {
            InitializeComponent();
        }

        private void frmBC_4_4_KetQuaDieuHanhTheoDonVi_Load(object sender, EventArgs e)
        {
            KhoiTaoDuLieu();
        }

        private void KhoiTaoDuLieu()
        {
            DateTime dateCurrent = DieuHanhTaxi.GetTimeServer();

            dateCurrent = new DateTime(dateCurrent.Year, dateCurrent.Month, dateCurrent.Day, 0, 0, 0);
            calTuNgay.Value = dateCurrent;
            calDenNgay.Value = dateCurrent;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (TimKiem_BaoCao.CheckTuNgayDenNgay(calTuNgay.Value, calDenNgay.Value))
            {
                DateTime dateGioDauCa;
                DataTable dt = ThongTinCauHinh.GetThongTinCa(1);
                try
                {
                    dateGioDauCa = Convert.ToDateTime(dt.Rows[0]["DauCa1"].ToString());
                }
                catch 
                {
                    dateGioDauCa = new DateTime(1900, 1, 1, 6, 0, 0);
                }
                DateTime TuNgay = new DateTime(calTuNgay.Value.Year, calTuNgay.Value.Month, calTuNgay.Value.Day, dateGioDauCa.Hour, 0, 0);
                DateTime DenNgay = calDenNgay.Value;
                DenNgay = DenNgay.AddDays(1);
                DenNgay = new DateTime(DenNgay.Year, DenNgay.Month, DenNgay.Day, dateGioDauCa.Hour - 1, 59, 59);
                lblTuNgayDen.Text = string.Format("({0:HH:mm dd/MM} - {1:HH:mm dd/MM})", TuNgay, DenNgay);

                if (rbFilter.Checked)
                {
                    DataTable dtDHTheoDonVi = new BangKe().GetBaoCao_KQDieuHanh_DV(TuNgay, DenNgay, false);
                    if (dtDHTheoDonVi.Rows.Count > 0)
                    {
                        grdDieuHanhTheoDonVi.RootTable.Groups.Clear();
                        grdDieuHanhTheoDonVi.RootTable.Columns["Vung"].Visible = true;
                        grdDieuHanhTheoDonVi.RootTable.Columns["NgayHienThi"].Visible = false;
                        grdDieuHanhTheoDonVi.RootTable.Groups.Add(grdDieuHanhTheoDonVi.RootTable.Columns["NgayHienThi"]);
                        grdDieuHanhTheoDonVi.RootTable.Groups[0].GroupFormatString = "dd/MM/yyyy";
                        grdDieuHanhTheoDonVi.RootTable.Groups[0].GroupPrefix = "Ngày :";
                        grdDieuHanhTheoDonVi.RootTable.Groups[0].Column = grdDieuHanhTheoDonVi.RootTable.Columns["NgayHienThi"];
                        btnVung.Text = "Vùng";

                        grdDieuHanhTheoDonVi.DataMember = "KetQuaDieuHanh";
                        grdDieuHanhTheoDonVi.SetDataBinding(dtDHTheoDonVi, "KetQuaDieuHanh");
                        btnExportExcel.Enabled = true;
                        lblMessage.Text = "";
                        lblMessage.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Không có dữ liệu vào khoảng thời gian này.";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    DataTable dtDHTheoDonVi = new BangKe().GetBaoCao_KQDieuHanh_DV(TuNgay, DenNgay,true);                    
                    if(dtDHTheoDonVi.Rows.Count>0)
                    {
                        grdDieuHanhTheoDonVi.RootTable.Columns["Vung"].Visible = false;
                        grdDieuHanhTheoDonVi.RootTable.Columns["NgayHienThi"].Visible = true;
                        grdDieuHanhTheoDonVi.RootTable.Groups.Clear();
                        btnVung.Text = "Ngày";

                        grdDieuHanhTheoDonVi.DataMember = "KetQuaDieuHanh";
                        grdDieuHanhTheoDonVi.SetDataBinding(dtDHTheoDonVi, "KetQuaDieuHanh");
                        btnExportExcel.Enabled = true;
                        lblMessage.Text = "";
                        lblMessage.Visible = false;
                    }
                    else
                    {
                        lblMessage.Text = "Không có dữ liệu vào khoảng thời gian này.";
                        lblMessage.Visible = true;
                    }
                }
            }
            else
            {               
                MessageBox.Show(this, "Bạn phải nhập [Từ ngày] nhỏ hơn hoặc bằng [Đến ngày].", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }       

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string FilenameDefault = "BC_KetQua_DieuHanh_TheoDonVi.xls";
            saveFileDialog1.FileName = FilenameDefault;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream objFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);               
                gridEXExporter1.Export(objFile);
                if (MessageBox.Show(this, "Tạo file Excel thành công. Bạn có muốn mở file?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question).ToString() == DialogResult.Yes.ToString())
                {
                    FileTools.OpenFileExcel(saveFileDialog1.FileName);
                }
            }
        }

        private void grdDieuHanhTheoDonVi_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.GroupFooter)
            {
               
                try
                {
                    double donDuoc = Convert.ToDouble(e.Row.Cells["TongDonDuoc"].Value.ToString());
                    double cuocTaxi = Convert.ToDouble(e.Row.Cells["TongCuocTaxi"].Value.ToString());
                    if (cuocTaxi > 0)
                    {
                        e.Row.Cells["PhanTramDonDuoc"].Text = string.Format("{0:#.#}", Convert.ToDouble(donDuoc / cuocTaxi * 100));
                    }
                }
                catch
                {

                }
            }
        }
    }
}