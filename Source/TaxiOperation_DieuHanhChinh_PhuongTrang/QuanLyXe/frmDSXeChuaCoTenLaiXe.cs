using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Taxi.Business;
using Janus.Windows.GridEX;

namespace Taxi.GUI
{
    public partial class frmDSXeChuaCoTenLaiXe : Form
    {
        public frmDSXeChuaCoTenLaiXe()
        {
            InitializeComponent();
        }

        private void frmDSXeChuaCoTenLaiXe_Load(object sender, EventArgs e)
        {
            LoadDSXeChuaCoTenLaiXe(calendarCombo1.Value, radXeChuaCoTen.Checked);
        }

        private void LoadDSXeChuaCoTenLaiXe(DateTime Ngay, bool bKhongTenLaiXe)
        {
            KiemSoatXeLienLac objKSXe = new KiemSoatXeLienLac();
             
            grdDSXeChuaCoLai.DataMember = "ListDSXe";
            grdDSXeChuaCoLai.SetDataBinding(objKSXe.GetDSXeKhongTenLaiXe(Ngay, bKhongTenLaiXe), "ListDSXe");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSXeChuaCoTenLaiXe(calendarCombo1.Value, radXeChuaCoTen.Checked);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdDSXeChuaCoLai_DoubleClick(object sender, EventArgs e)
        {
            grdDSXeChuaCoLai.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            if (grdDSXeChuaCoLai.SelectedItems.Count > 0)
            {
                GridEXRow row = grdDSXeChuaCoLai.SelectedItems[0].GetRow();
                string SoHieuXe = row.Cells["SoHieuXe"].Value.ToString();
                DateTime  ThoiGianHoatDong  = Convert.ToDateTime ( row.Cells["ThoiDiemBao"].Value.ToString());
                new frmCapNhatTenLaiXe(SoHieuXe, ThoiGianHoatDong).ShowDialog();
                LoadDSXeChuaCoTenLaiXe(calendarCombo1.Value, radXeChuaCoTen.Checked);
            }
        }

        private void btnNhapTuExcel_Click(object sender, EventArgs e)
        {
            // chọn để lấy ngày, cập nhật sẽ cập nhật  lại hết.
            DateTime GioChon = new DateTime(calendarCombo1.Value.Year, calendarCombo1.Value.Month, calendarCombo1.Value.Day, 23, 59, 59);
            new frmImportTenLaiXeTuExcel(GioChon).ShowDialog( );
            LoadDSXeChuaCoTenLaiXe(calendarCombo1.Value, radXeChuaCoTen.Checked);
        }
    }
}