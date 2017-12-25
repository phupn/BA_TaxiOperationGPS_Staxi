using System.Data;
using Taxi.Data.BanCo.DbConnections;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Taxi.Common.Extender;
using Taxi.Common.DbBase.Attributes;

namespace Taxi.Data.BanCo.Entity.Salary
{
    /// <summary>
    /// Thông tin thuê bao tuyến
    /// </summary>
    [Serializable]
    [TableInfo(TableName = "Luong_CuocKhach")]
    public class CuocKhach : TaxiOperationDbEntityBase<CuocKhach>, ICloneable
    {
        #region properties

        public int STT { get; set; }
        
        [Field(IsKey=true, IsIdentity=true)]
        public Int64 ID { get; set; }
        [Field]
        public Int64? ChotCoID { get; set; }
        [Field]
        public Int64 FK_TaxiOperationId { get; set; }

        [Field]
        public SqlDateTime TGTiepNhan { get; set; }

        public DateTime? TGTiepNhanDate
        {
            get
            {
                return TGTiepNhan.ToDateTime();
            }
        }

        [Field]
        public int FK_DiemDo { get; set; }

        /// <summary>
        /// Gets or sets the ten diem do.
        /// </summary>
        /// <value>
        /// The ten diem do.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/17/2014   created
        /// </Modified>
        public string TenDiemDo { get; set; }

        [Field]
        public string DiaChiDon { get; set; }

        [Field]
        public string SoXe { get; set; }

        [Field]
        public int ChiSoDi { get ; set ; }

        [Field]
        public bool CuocGoi { get; set; }

        [Field]
        public SqlDateTime TGGap { get; set; }
        public DateTime? TGGapDate
        {
            get
            {
                return TGGap.ToDateTime();
            }
        }

        [Field]
        public string DiaChiTra { get; set; }

        /// <summary>
        /// ID tuyến đường
        /// </summary>
        [Field]
        public string TuyenDuong { get; set; }

        /// <summary>
        /// Tên tuyến đường
        /// </summary>
        public string TenTuyenDuong { get; set; }

        /// <summary>
        /// Tên kiểu tuyến đường
        /// </summary>
        public string TenKieuTuyenDuong
        {
            get
            {
                if (Chieu == 1) return "1 chiều";
                else if (Chieu == 2) return "2 chiều";
                return string.Empty;
            }
        }

        /// <summary>
        /// Trạng thái cuộc gọi taxi
        /// </summary>
        [Field]
        public int KetQua { get; set; }

        //public float KmQuyDinh1Chieu { get; set; }
        //public float KmQuyDinh2Chieu { get; set; }

        [Field]
        public float BazemKm{get;set;}
        [Field]
        public  float BazemKm2 { get; set; }

        /// <summary>
        /// 1 chiều hay 2 chiều
        /// </summary>
        [Field]
        public int Chieu { get; set; }

        [Field]
        public string GiaThueBao { get; set; }

        [Field]
        public SqlDateTime TGTra { get; set; }
        public DateTime? TGTraDate
        {
            get
            {
                return TGTra.ToDateTime();
            }
        }
        [Field]
        public int ChiSoVe { get; set; }

        [Field]
        public int KmCoDH { get; set; }

        [Field]
        public float KmThucDi { get; set; }


        [Field]
        public decimal TienDH { get; set; }

        [Field]
        public decimal PhatSinh { get; set; }

        [Field]
        public decimal TienTroiKM { get; set; }

        public string TienTroiKMStr
        {
            get
            {
                return MoneyStr(TienTroiKM);
            }
        }

        [Field]
        public decimal TienTroiPhut { get; set; }

        public string TienTroiPhutStr
        {
            get
            {
                return MoneyStr(TienTroiPhut);
            }
        }

        public decimal TienGioVuot
        {
            get
            {
                //decimal money = (TienTroiPhut * PhutVuot) / 60;
                decimal money = TienTroiPhut; 
                if (money % 1 == 0) //nếu ko có phần thập phân
                {
                    return Math.Round(money, 0);
                }
                return Math.Round(money, 2);
            }
        }

        /// <summary>
        /// Tiền cộng trội km và trội phút
        /// </summary>
        public decimal TienCong
        {
            get
            {
                return TienTroiKM + TienTroiPhut + GiaGoc;
            }
        }

        public string TienCongStr
        {
            get
            {
                return MoneyStr(TienCong);
            }
        }

        [Field]
        public decimal GiaGoc { get; set; }

        public string GiaGocStr
        {
            get
            {
                return MoneyStr(GiaGoc);
            }
        }

        [Field]
        public decimal ThanhTien { get; set; }

        public string ThanhTienStr
        {
            get
            {
                return MoneyStr(ThanhTien);
            }
        }

        [Field]
        public int CuocKhachID { get; set; }

        [Field]
        public string MaLaiXe { get; set; }

        public string TenLaiXe { get; set; }

        [Field]
        public int ChayTuyen { get; set; }

        /// <summary>
        /// Tên chạy tuyến
        /// </summary>
        public string TenChayTuyen { get; set; }

        /// <summary>
        /// Loại cuốc hàng
        /// </summary>
        [Field]
        public int LoaiCuocHang { get; set; }
        [Field]
        public int KieuCuocHang { get; set; }
        /// <summary>
        /// true: cước đường dài
        /// </summary>
        [Field]
        public bool CuocDuongDai { get; set; }

        [Field]
        public string CungDuong { get; set; }

        [Field]
        public decimal Luong_TienXangDauDinhMuc { get; set; }

        public string Luong_TienXangDauDinhMucStr
        {
            get
            {
                return MoneyStr(Luong_TienXangDauDinhMuc);
            }
        }

        [Field]
        public decimal Luong_TienLaiXeHuongDinhMuc { get; set; }

        public string Luong_TienLaiXeHuongDinhMucStr
        {
            get
            {
                return MoneyStr(Luong_TienLaiXeHuongDinhMuc);
            }
        }

        [Field]
        public decimal Luong_TienHuongDuongDai { get; set; }

        [Field]
        public decimal Luong_TienHuongKmVuot { get; set; }

        [Field]
        public decimal Luong_TienHuongGioVuot { get; set; }

        [Field]
        public string PhuTroi { get; set; }

        [Field]
        public float KmVuot { get; set; }

        public string KmVuotStr
        {
            get
            {
                return KmVuot == 0 ? string.Empty : KmVuot.ToString();
            }
        }

        /// <summary>
        /// Tổng của KmVuot và Bazem
        /// </summary>
        public float KmTong
        {
            get
            {
                return BazemKm + KmVuot;
            }
        }

        [Field]
        public int PhutVuot { get; set; }

        public string PhutVuotStr
        {
            get
            {
                return PhutVuot == 0 ? string.Empty : PhutVuot.ToString();
            }
        }
        [Field]
        public DateTime TGDieuXe { get; set; }

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

        public string UpdatedDateStr
        {
            get
            {
                return UpdatedDate.IsNull == true ? string.Empty : string.Format("{0:dd/MM/yyyy}", UpdatedDate.Value);
            }
        }
        /// <summary>
        /// Gets or sets the bu xang_ don.
        /// Thêm trường
        /// </summary>
        /// <value>
        /// The bu xang_ don.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/26/2014   created
        /// </Modified>
        [Field]
        public int BuXang_Don { get; set; }
        /// <summary>
        /// Gets or sets the bu xang_ truot.
        /// thêm trường
        /// </summary>
        /// <value>
        /// The bu xang_ truot.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/26/2014   created
        /// </Modified>
        [Field]
        public int BuXang_Truot { get; set; }
        [Field]
        public int IsCaBa { get; set; }
        /// <summary>
        /// Tạm thời 
        /// chưa biết là cái gì
        /// </summary>
        public decimal SoBD
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the diem xuat phat.
        /// Thực hiện để tính khi chuyển dữ liệu từ TrunkEnd Sang
        /// </summary>
        /// <value>
        /// The diem xuat phat.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/26/2014   created
        /// </Modified>
        public int DiemXuatPhat { get; set; }
        public DateTime Ngay
        {
            get
            {
                var data = (SoXe != "" ? TGDieuXe : TGTiepNhan.Value);
                if ((IsCaBa==3)&&(data.TimeOfDay > new TimeSpan(06,59,59)))
                {
                    data = data.AddDays(1);
                }
                return data;
            }
        }

        public DateTime? Ngay2
        {
            get
            {
                return TGGapDate ?? TGTiepNhanDate;
            }
        }

        public int? SoXeInt
        {
            get
            {
                int i = 0;
                if (int.TryParse(SoXe.Trim(), out i))
                {
                    return i;
                }
                return null;
            }
        }

        #endregion 

        #region Hàm thực hiện

        /// <summary>
        /// Trả về chuỗi format tiền
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        private string MoneyStr(decimal money)
        {
            if (money == 0)
            {
                return string.Empty;
            }
            if (money % 1 == 0) //nếu ko có phần thập phân
            {
                return Math.Round(money, 0).ToString();
            }
            return Math.Round(money, 2).ToString();
        }

        /// <summary>
        /// Lấy ra danh sách lương cuốc khách theo thời gian bắt đầu, kết thúc, mã lái xe và số xe
        /// </summary>
        /// <param name="maLaiXe"></param>
        /// <param name="thoiGianBatDau"></param>
        /// <param name="soXe"></param>
        /// <returns></returns>
        public List<CuocKhach> GetListCuocKhach(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string maLaiXe, string soXe)
        {
            return ExeStore("Luong_CuocKhach_Search", thoiGianBatDau, thoiGianKetThuc, maLaiXe, soXe).ToList<CuocKhach>();
        }

        public List<CuocKhach> GetListCuocKhach(DateTime tuNgay, DateTime denNgay, int loaiXe, string laiXe, string soXe)
        {
            return ExeStore("Luong_CuocKhach_SearchBaoCao", tuNgay, denNgay, loaiXe, laiXe, soXe).ToList<CuocKhach>();
        }


        /// <summary>
        /// Gets the list cuoc khachfrom truck end.
        /// Thực hiện lấy danh sách cuốc khách theo ngày từ bảng T_TAXIOPERATION_TRUCK_END.
        /// </summary>
        /// <param name="dateSart">Thời gian bắt đầu</param>
        /// <param name="ngayDinhKinhDoanh"></param>
        /// <param name="dateEnd">Thời gian kết thúc</param>
        /// <param name="ngayThuNgan"></param>
        /// <param name="laiXeId">Mã lái xe</param>
        /// <param name="SoHieuXe">Số xe</param>
        /// <returns>Trả về 1 danh sách cuốc khách trong bảng TruckEnd</returns>
        /// <Modified>
        /// Name     Date         Comments
        /// PPM-HAUNV  9/17/2014   created
        /// </Modified>
        public List<CuocKhach> GetListCuocKhachfromTruckEnd(DateTime ngayDinhKinhDoanh,DateTime ngayThuNgan,string laiXeId,string SoHieuXe)
        {
            return ExeStore("Luong_CuocKhach_GetListFromTruckEnd_V2", ngayDinhKinhDoanh, ngayThuNgan, laiXeId, SoHieuXe).ToList<CuocKhach>();
        }

        public List<CuocKhach> GetListCuocKhachfromCuocKhach(DateTime ngayDinhKinhDoanh, DateTime ngayThuNgan, string LaiXeId, string SoHieuXe)
        {
            return ExeStore("Luong_CuocKhach_GetListFromCuocKhach_V2", ngayDinhKinhDoanh, ngayThuNgan, LaiXeId, SoHieuXe).ToList<CuocKhach>();
        }
        /// <summary>
        /// Xóa bằng store
        /// </summary>
        /// <returns></returns>
        public override int Delete()
        {
            return ExeStoreNoneQuery("Luong_CuocKhach_delete",this.ID);
          //  return base.Delete();
        }

        #endregion

        public object Clone()
        {
          return  this.MemberwiseClone();
        }
    }
    #region Extension
    public static class ExtensionDate
    {
        public static DateTime? ToDateTime(this SqlDateTime date)
        {
            if(date.IsNull)
                return null;
            else
            return date.Value;
        }

    }
    #endregion
}
