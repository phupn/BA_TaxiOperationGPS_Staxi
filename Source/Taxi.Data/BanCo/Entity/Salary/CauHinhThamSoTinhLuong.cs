using System;
using System.Linq;
using Taxi.Data.BanCo.DbConnections;
using Taxi.Common.DbBase.Attributes;
using Taxi.Common.Extender;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Cấu hình tham số tính lương
    /// </summary>
    /// <Modified>
    /// Name     Date         Comments
    /// PPM-HAUNV  9/12/2014   created
    /// </Modified>
      [TableInfo(TableName = "Luong_CauHinhThamSoTinhLuong")]
    public class CauHinhThamSoTinhLuong : TaxiOperationDbEntityBase<CauHinhThamSoTinhLuong>
    {
        #region Propertion
        [Field(IsKey = true, IsIdentity = false)]
        [ValueField]
        public int ID { get; set; }
        /// <summary>
        /// Tiền quỹ đội xe
        /// </summary>
        [Field]
        public decimal TienQuyDoiXe { get; set; }
        /// <summary>
        /// % hưởng thêm của cuốc tự khai thác đường dài
        /// </summary>
        [Field]
        public double PhanTramTuKhaiThac { get; set; }
        /// <summary>
        /// % hưởng thêm của cuốc tự khai thác đường ngắn
        /// </summary>
        [Field]
        public double PhanTramTuKhaiThacDuongNgan { get; set; }
        /// <summary>
        /// Tiền trực đêm
        /// </summary>
        [Field]
        public decimal TienTrucMotDem { get; set; }
        /// <summary>
        /// Đường dài một chiều hưởng
        /// </summary>
        [Field]
        public double DuongDaiMotChieuHuong { get; set; }
        /// <summary>
        /// - Chênh lệch đường dài 1 chiều và 2 chiều hưởng thêm (%)
        /// </summary>
        [Field]
        public double ChenhLenhDuongDai_1_2_ChieuHuongThem { get; set; }
        /// <summary>
        /// Phần trăm được hưởng của cuối gối (%)
        /// </summary>
        [Field]
        public double PhanTramHuongCuocGoi { get; set; }
        /// <summary>
        /// % doanh thu rửa xe
        /// </summary>
        [Field]
        public double PhanTramDoanhThuRuaXe { get; set; }
        /// <summary>
        /// Phí mua bảo hiểm Xã hội hàng tháng
        /// </summary>
        [Field]
        public decimal PhiMuaBHXHHangThang { get; set; }
        /// <summary>
        /// Số năm thâm niên đủ để được hỗ trợ tiền BHXH
        /// </summary>
        [Field]
        public Int16 SoNamHoTroBHXH { get; set; }
        /// <summary>
        /// Số tiền hỗ trợ hàng tháng
        /// </summary>
        [Field]
        public decimal SoTienHoTroBHXHThang { get; set; }
        /// <summary>
        /// Số tiền mua bảo hiểm thất nghiệp
        /// </summary>
        [Field]
        public decimal PhiMuaBHTN { get; set; }
        /// <summary>
        /// Số tiền BHXH được hỗ trợ hàng tháng  từ 3 năm thâm niên trở lên
        /// </summary>
        [Field]
        public decimal SoTienHoTroBHXH3NamTroLen { get; set; }
        /// <summary>
        /// Số năm thâm niêm miễn bảo hiểm xe
        /// </summary>
        [Field]
        public Int16 SoNamMienBHXe { get; set; }
        /// <summary>
        /// Số năm thâm niên đc hưởng thêm % doanh thu
        /// </summary>
        [Field]
        public Int16 SoNamThamNienHuongDoanhThu { get; set; }
        /// <summary>
        /// % hưởng thêm doanh thu
        /// </summary>
        [Field]
        public double PhanTramHuongDoanhThu { get; set; }
        [Field]
        public string UpdatedByUser { get; set; }
        [Field]
        public DateTime UpdatedDate { get; set; }
        #endregion
        public CauHinhThamSoTinhLuong Get()
        {
            var model = this.ExeStore("Luong_CauHinhThamSoTinhLuong_Get").ToList <CauHinhThamSoTinhLuong>();
            return model == null ? null : model.FirstOrDefault();
        }
    }
}
