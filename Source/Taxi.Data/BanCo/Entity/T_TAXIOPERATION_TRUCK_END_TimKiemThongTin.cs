using System.Data;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.Extender;
using Taxi.Utils.Enums;
using Taxi.Utils;
using System;
using Taxi.Common.DbBase.Attributes;
using Taxi.Utils.Validators;
namespace Taxi.Data.BanCo.Entity
{
    public class T_TAXIOPERATION_TRUCK_END_TimKiemThongTin : TaxiOperationDbEntityBase<T_TAXIOPERATION_TRUCK_END_TimKiemThongTin>, IReportData
    {
        #region Thông tin dùng để tìm kiếm -- Không phải là thuộc tính của entity
        [Field(Name = "Từ ngày")]
        [ValidatorRequire]
        public DateTime? FromDate { set; get; }

        [Field(Name = "Đến ngày")]
        [ValidatorRequire]
        [ValidatorDateGreater("FromDate")]
        public DateTime? ToDate { set; get; }

        public string DienThoai { set; get; }
        public string SoXe { set; get; }
        public CaLamViec CaLamViec { set; get; }
        public int LoaiXe { set; get; }
        public string LaiXe { set; get; }
        public int DiemDo { set; get; }
        public int ChayTuyen { set; get; }
        public int Chieu { set; get; }
        public int TuyenDuong { set; get; }
        public int DuongDon { set; get; }
        public string MaKH { set; get; }
        public int DuongTra { set; get; }

        public bool DangGiaiQuyet { set; get; }
        public bool DaGiaiQuyet { set; get; }
        public bool THang { set; get; }
        public bool KhongTHang { set; get; }
        public bool MoCua { set; get; }
        public bool KhongMoCua { set; get; }
        public bool TTDieu { set; get; }
        public bool KhaiThac { set; get; }
        public bool BuXang { set; get; }
        public bool BuXangTruot { set; get; }
        public bool ThueBaoTuyen { get; set; }
        public string DiaChi { set; get; }
        public string DiaChiTra { set; get; }
        public int KieuCuocGoi { set; get; }
        public bool CuocGoi100 { get; set; }
        public string NhanVienDieu { set; get; }
        public string NhanVienTiepNhan { set; get; }
        #endregion

        /// <summary>
        /// Lấy dữ liệu cho báo cáo
        /// </summary
        /// <returns></returns>
        public object GetData()
        {
            var dt = this.ExeStore("EnVang_T_TAXIOPERATION_TRUCK_END_TimKiemThongTin_V2");
            var data = dt.Clone();
            dt.Columns["SoXe"].AllowDBNull = true;
            data.Columns["SoXe"].AllowDBNull = true;
            data.Columns["SoXe"].DefaultValue = null;
            data.Columns["SoXe"].DataType = typeof(int);
            foreach (DataRow row in dt.Rows)
            {
                int r = 0;
                
                if (string.IsNullOrEmpty(row["SoXe"].ToString().Trim()) ||
                    !int.TryParse(row["SoXe"].ToString().Trim(), out r))
                {
                    row.SetField<string>("SoXe",null);
                    row.AcceptChanges();
                }
                else
                {
                    row["SoXe"] = row["SoXe"].ToString().Trim();
                }
                data.ImportRow(row);
            }
            return data;
        }
    }
}
