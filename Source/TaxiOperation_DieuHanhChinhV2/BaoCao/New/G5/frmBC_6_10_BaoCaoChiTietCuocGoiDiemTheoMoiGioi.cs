#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Taxi.Business;
using Taxi.Controls;
using Taxi.Controls.BaoCao;
using Taxi.Data.BanCo.Entity.DM;
using Taxi.Data.G5.BaoCao;
using Taxi.Controls.Base.Extender;
using Taxi.Controls.Base.Common.RepositoryItems;
using Taxi.Utils;

#endregion ============= Copyright © 2016 BinhAnh =============
namespace TaxiOperation_DieuHanhChinh.BaoCao.New.G5
{
    [ReportInfo(Title = "6.10 Báo cáo chi tiết cuộc gọi điểm theo môi giới")]
    public partial class frmBC_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi : FrmReportBase
    {
        private bool IsGoiTuFormKhac = false;
        private DateTime _fromDate = DateTime.Now;
        private DateTime _toDate = DateTime.Now;
        public string TenDoiTac { get; set; }
        public string DiaChi { get; set; }
        public frmBC_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi()
        {
            InitializeComponent();         
        }
       
        public frmBC_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi(string MaDoiTac, DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent();
            _fromDate = TuNgay;
            _toDate   = DenNgay;
            txtMaDoiTac.Text = MaDoiTac;
            IsGoiTuFormKhac = true;
        }
        protected override void AfterLoad()
        {
            gridView1.Add<RepostionryItemEnum_KieuCuocGoi>("KieuCuocGoi");
            gridView1.Add<RepostionryItemEnum_TrangThaiCuocGoi>("TrangThaiCuocGoi");
            if (IsGoiTuFormKhac)
            {               
                ipFromDate.SetValue(_fromDate);
                ipToDate.SetValue(_toDate);
                btnTim.PerformClick();
            }
        }
        protected override object GetData()
        {
            int TrangThaiDon;
            if (ckbDonDuoc.Checked && !ckbKhongDonDuoc.Checked)
            {
                TrangThaiDon = 1;// Đón được, có xe đón
            }
            else if (ckbKhongDonDuoc.Checked && !ckbDonDuoc.Checked)
            {
                TrangThaiDon = 2;// ko đón được
            }
            else
            {
                TrangThaiDon = 0;// cả đón đc và k đón đc
            }

            return bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi.GetReport_V2(ipFromDate.DateTime, ipToDate.DateTime, txtMaDoiTac.Text.Trim(),txtSoDT.Text.Trim(),txtXeDon.Text.Trim(),TenDoiTac, DiaChi,TrangThaiDon);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int row = gridView1.FocusedRowHandle;
                var dataRow = ((List<bc_6_10_BaoCaoChiTietCuocGoiDiemTheoMoiGioi>)shGridControl1.DataSource)[row];
                if (dataRow != null)
                {
                    string strSHX = dataRow.XeDon;
                    DateTime fromDate = dataRow.ThoiDiemGoi;
                    DateTime toDate = dataRow.ThoiDiemThayDoiDuLieu.AddMinutes(10);
                    string strBienSo = new DMXe().GetDMXeTheoSoXe(strSHX).BienKiemSoat;
                    string strURL;
                    if (strBienSo.Length > 0)
                    {
                        strURL = Config_Common.GPS_Domain_Route + "?fromDate=" + FormatDateTime(fromDate) + "&toDate=" + FormatDateTime(toDate) + "&VehiclePlate=" + strBienSo;
                        Process.Start("chrome.exe", strURL);
                    }
                }                
            }
            catch
            {

            }
        }

        private string FormatDateTime(DateTime pDate)
        {
            string result = string.Format("{0:yyyy/MM/dd}", pDate)+"%20"+string.Format("{0:HH:mm}",pDate);
            return result;
        }
    }
}
