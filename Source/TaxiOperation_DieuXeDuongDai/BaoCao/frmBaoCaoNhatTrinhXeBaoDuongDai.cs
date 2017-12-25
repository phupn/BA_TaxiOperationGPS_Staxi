using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Forms;
using Taxi.Business.DieuXeDuongDai;
using TaxiOperation_DieuXeDuongDai.Base;

namespace TaxiOperation_DieuXeDuongDai.BaoCao
{
    public partial class frmBaoCaoNhatTrinhXeBaoDuongDai : FormBase
    {
        public frmBaoCaoNhatTrinhXeBaoDuongDai()
        {
            InitializeComponent();
        }

        private void frmBaoCaoNhatTrinhXeBaoDuongDai_Load(object sender, System.EventArgs e)
        {
            var db = CommonDuongDai.GetTrangThaiDatLichDonKhach();
            var row=db.NewRow();
            row["TrangThai"] = "Tất cả";
            row["GiaTri"] = 0;
            db.Rows.InsertAt(row,0);
            lupTrangThai.Properties.DataSource = db;
            lupTrangThai.ItemIndex = 0;
            deStart.EditValue = CommonDuongDai.GetTimeServer().Date;
            deEnd.EditValue   = CommonDuongDai.GetTimeServer().Date.AddDays(1).AddSeconds(-1);
            txtSoXe.Focus();
        }

        private void btnTim_Click(object sender, System.EventArgs e)
        {
            if (deStart.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn từ ngày");
                deStart.Focus();
                return;
            }
            if (deEnd.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn đến ngày");
                deEnd.Focus();
                return;
            }
            if (deStart.DateTime > deEnd.DateTime)
            {
                MessageBox.Show("Từ ngày nhỏ hơn đến ngày");
                deEnd.Focus();
                return;
            }
            var db = BaoCaoNhatTrinhXeBaoDuongDai.TimKiem(deStart.DateTime, deEnd.DateTime, txtSoXe.Text, txtSDT.Text,
                Convert.ToInt32(lupTrangThai.EditValue.ToString())).OrderBy(p=>p.SoXe).ToList();
            shGridControl1.SetDataSource(db);
            shGridControl1.Refresh();
            btnXuatExcel.Enabled = true;
            if (db.Count == 0)
            {
                btnXuatExcel.Enabled = false;
                MessageBox.Show("Không tìm thấy dữ liệu!", "Thông báo");
            }
        }

        private void btnXuatExcel_Click(object sender, System.EventArgs e)
        {
            using (var ope = new SaveFileDialog())
            {
                ope.Filter = "Excel 2003|*.xls|Excel 2007-2010|*.xlsx";
                ope.FileName = "Bao-Cao-Nhat-Trinh-Xe-Bao-Duong-Dai";
                if (ope.ShowDialog() == DialogResult.OK)
                {
                    if (ope.FileName.Split('.')[1] == "xls")
                    {
                        shGridControl1.ExportToXls(ope.FileName);
                    }
                    else
                    {
                        shGridControl1.ExportToXlsx(ope.FileName);
                    }
                    Process.Start(ope.FileName);

                }
            }
            
        }
    }
}
