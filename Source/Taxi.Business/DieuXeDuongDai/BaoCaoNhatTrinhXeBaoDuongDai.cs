using System;
using System.Collections.Generic;
using Taxi.Common.Extender;
using Taxi.Data.DieuXeDuongDai;

namespace Taxi.Business.DieuXeDuongDai
{
    public class BaoCaoNhatTrinhXeBaoDuongDai
    { 
        #region Field
        public long Id { get; set; }
        public DateTime ThoiDiemGoi { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }
        public string DiaChiDon { get; set; }
        public DateTime ThoiDiemDon { get; set; }
        public string LoaiXe { get; set; }
        public int SoPhutBaoTruoc { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string GhiChuDieu { get; set; }
        public string XeNhan { get; set; }
        public string MaNVDieu { get; set; }
        public DateTime ThoiDiemDieu { get; set; }
        public string XeDon { get; set; }
        public float TongTien { get; set; }
        public string DiaChiTra { get; set; }
        public float KinhDo { get; set; }
        public float ViDo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public long IDCuocGoi { get; set; }

        public int? SoXe
        {
            get
            {
                if (!string.IsNullOrEmpty(XeDon))
                {
                    int sxe = 0;
                    if (int.TryParse(XeDon, out sxe))
                        return sxe;
                    
                }
                
                return null;

            }
        }

        #region Trạng thái
        //dt.Rows.Add("Chờ xử lý", 1);
        //    dt.Rows.Add("Đón được", 2);
        //    dt.Rows.Add("Khách hủy", 3);
        //    dt.Rows.Add("Không xe", 4);
        //    dt.Rows.Add("Trượt", 5);
        //    dt.Rows.Add("Hoãn", 6);
        public string ChoXuLy { get { return TrangThai == 1 ? "X" : string.Empty; } }
        public string DonDuoc{get { return TrangThai == 2 ? "X" : string.Empty; }}
        public string KhachHuy { get { return TrangThai == 3 ? "X" : string.Empty; } }
        public string KhongXe { get { return TrangThai == 4 ? "X" : string.Empty; } }
        public string Truot { get { return TrangThai == 5 ? "X" : string.Empty; } }
        public string Hoan { get { return TrangThai == 6 ? "X" : string.Empty; } }
        #endregion
        #endregion

        public static List<BaoCaoNhatTrinhXeBaoDuongDai> TimKiem(DateTime deStart,DateTime deEnd,string soXe,string soDt,int trangThai)
        {
            return new BaoCaoDieuxeDuongDai().BaoCaoNhatTrinhXeBaoDuongDai(deStart,deEnd,soXe,soDt,trangThai).ToList<BaoCaoNhatTrinhXeBaoDuongDai>();
        } 
    }
}
