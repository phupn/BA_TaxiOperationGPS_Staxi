using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Common.DbBase.Attributes;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.Extender;
using System.Data;
using System.Data.SqlTypes;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Entity bảng giá nhiêu liệu trong tháng
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PhongNC  11/09/2014   created
    /// </Modified>
    [TableInfo(TableName = "Luong_GiaNhienLieu")]
    public class BangGiaNhienLieuTrongThang : TaxiOperationDbEntityBase<BangGiaNhienLieuTrongThang>
    {
        #region field

        [Field(IsKey = true, IsIdentity = true)]
        public int ID { get; set; }
        
        [Field]
        public int FK_LoaiNhienLieuID { get; set; }

        [Field]
        public SqlDateTime TuNgay { get; set; }

        public string TuNgayStr
        {
            get
            {
                return TuNgay.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", TuNgay.Value);
            }
        }

        [Field]
        public SqlDateTime DenNgay { get; set; }

        public string DenNgayStr
        {
            get
            {
                return DenNgay.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", DenNgay.Value);
            }
        }

        [Field]
        public decimal GiaTien { get; set; }

        /// <summary>
        /// Giá tiền với 2 chữ số thập phân sau dấu phấy
        /// </summary>
        public decimal GiaTien2
        {
            get
            {
                if (GiaTien % 1 == 0) //nếu ko có phần thập phân
                {
                    return Math.Round(GiaTien, 0);
                }
                return Math.Round(GiaTien, 2);
            }
        }

        [Field]
        public string CreatedByUser { get; set; }

        [Field]
        public SqlDateTime CreatedDate { get; set; }

        public string CreatedDateStr
        {
            get
            {
                return CreatedDate.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", CreatedDate.Value);
            }
        }

        [Field]
        public string UpdatedByUser { get; set; }

        [Field]
        public SqlDateTime UpdatedDate { get; set; }

        public string UpdateDateStr
        {
            get
            {
                return UpdatedDate.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", UpdatedDate.Value);
            }
        }

        public int STT { get; set; }
        public string TenLoaiNhienLieu { get; set; }

        #endregion

        /// <summary>
        /// Gets the by month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PhongNC  11/09/2014   created
        /// </Modified>
        public List<BangGiaNhienLieuTrongThang> GetByMonth(int month, int year)
        {
            return ExeStore("Luong_BangGiaNhienLieuTrongThang_SearchByMonth", month, year).ToList<BangGiaNhienLieuTrongThang>();
        }

        public bool Update(BangGiaNhienLieuTrongThang entity)
        {
            int i = ExeStoreNoneQuery("Luong_BangGiaNhienLieuTrongThang_Update", entity.FK_LoaiNhienLieuID, entity.TuNgay, entity.DenNgay, entity.GiaTien, entity.UpdatedByUser, entity.UpdatedDate);
            if (i > 0) return true;
            return false;
        }

        /// <summary>
        /// Lấy về giá nhiên liệu theo loại xe và ngày
        /// </summary>
        /// <param name="soXe"></param>
        /// <param name="ngay"></param>
        /// <returns></returns>
        public decimal GetGiaNhienLieuTheoSoXeVaNgay(string soXe, DateTime ngay)
        {
            DataTable dt = ExeStore("Luong_BangGiaNhienLieuTrongThang_GetGiaNhienLieuTheoSoXeVaNgay", soXe, ngay);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    return decimal.Parse(dt.Rows[0]["GiaTien"].ToString());
                }
            }
            catch
            {
            }
            return 0;
        }
    }
}
