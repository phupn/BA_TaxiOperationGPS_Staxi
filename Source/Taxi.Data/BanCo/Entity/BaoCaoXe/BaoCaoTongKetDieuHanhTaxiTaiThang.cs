using Taxi.Data.BanCo.DbConnections;
using System.Data;
using System;
using System.Linq;
using Taxi.Common.Extender;
using System.Collections.Generic;
using Taxi.Utils;
namespace Taxi.Data.BanCo.Entity.BaoCaoXe
{
    public class BaoCaoTongKetDieuHanhTaxiTaiThang : TaxiOperationDbEntityBase<BaoCaoTongKetDieuHanhTaxiTaiThang>
    {
        #region Tổng kết điện thoại
        public List<TruckSummary> GetTongKetDienThoai(DateTime? from, DateTime? to)
        {
            var list = new List<TruckSummary> { };

            var thangnay = ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetDieuHanh2", from, to).ToList<TruckInfo>();
            var thangtruoc = ExeStore("EnVang_Report_T_TAXIOPERATION_TRUCK_END_BaoCaoTongKetDieuHanh2", from.Value.AddMonths(-1), from.Value.AddSeconds(-1)).ToList<TruckInfo>();

            var ts = new TruckSummary { };
            foreach (var tn in thangnay)
            {
                if (tn.DienThoaiCoKhach) ts.CoHang++;
                if (tn.GoiLai) ts.GoiLai++;
                if (tn.HoiGia) ts.HoiGia++;
                if (tn.BocXep) ts.BocXep++;
                if (tn.KhachHen) ts.KhachHen++;
                if (tn.NhayMay) ts.NhayMay++;
                if (tn.NoiBo) ts.NoiBo++;
                if (tn.GoiKhac) ts.GoiKhac++;
                if (tn.XinLoi) ts.XinLoi++;
                if (tn.TongGoiDen) ts.TongCuoc++;
                if (tn.GoiNho) ts.GoiNho++;
                if (tn.PhanAnh) ts.PhanAnh++;
                if (tn.KhachHoan) ts.KhachHoan++;
                if (tn.HetXe) ts.HetXe++;
                if (tn.GiucXe) ts.GiucXe++;
            }
            foreach (var tt in thangtruoc)
            {
                if (tt.DienThoaiCoKhach) ts.CoHang_t++;
                if (tt.GoiLai) ts.GoiLai_t++;
                if (tt.HoiGia) ts.HoiGia_t++;
                if (tt.BocXep) ts.BocXep_t++;
                if (tt.KhachHen) ts.KhachHen_t++;
                if (tt.NhayMay) ts.NhayMay_t++;
                if (tt.NoiBo) ts.NoiBo_t++;
                if (tt.GoiKhac) ts.GoiKhac_t++;
                if (tt.XinLoi) ts.XinLoi_t++;
                if (tt.TongGoiDen) ts.TongCuoc_t++;
                if (tt.GoiNho) ts.GoiNho_t++;
                if (tt.PhanAnh) ts.PhanAnh_t++;
                if (tt.KhachHoan) ts.KhachHoan_t++;
                if (tt.HetXe) ts.HetXe_t++;
                if (tt.GiucXe) ts.GiucXe_t++;
            }
            ts.CoHang_s = ts.CoHang - ts.CoHang_t;
            ts.GoiLai_s = ts.GoiLai - ts.GoiLai_t;
            ts.HoiGia_s = ts.HoiGia - ts.HoiGia_t;
            ts.BocXep_s = ts.BocXep - ts.BocXep_t;
            ts.KhachHen_s = ts.KhachHen - ts.KhachHen_t;
            ts.NhayMay_s = ts.NhayMay - ts.NhayMay_t;
            ts.NoiBo_s = ts.NoiBo - ts.NoiBo_t;
            ts.GoiKhac_s = ts.GoiKhac - ts.GoiKhac_t;
            ts.XinLoi_s = ts.XinLoi - ts.XinLoi_t;
            ts.GoiNho_s = ts.GoiNho - ts.GoiNho_t;
            ts.PhanAnh_s = ts.PhanAnh - ts.PhanAnh_t;
            ts.KhachHoan_s = ts.KhachHoan - ts.KhachHoan_t;
            ts.HetXe_s = ts.HetXe - ts.HetXe_t;
            ts.GiucXe_s = ts.GiucXe - ts.GiucXe_t;

            //ts.TongCuoc = thangnay.Count;
            //ts.TongCuoc_t = thangtruoc.Count;
            ts.TongCuoc_s = ts.TongCuoc - ts.TongCuoc_t;

            list.Add(ts);

            return list;
        }
        #endregion

        #region Tổng kết cuốc hàng
        public List<TruckSummary> GetTongKetCuocHang(DateTime? from, DateTime? to)
        {
            var data = BaoCaoTongKetLoaiXeTheoThang.Inst.GetDataReport(from, to, string.Empty).ToList<TruckSummary>();

            data = data.GroupBy(d => d.Ca).Select(g => 
            {
                var d = g.First();

                foreach (var di in g.Where(di => !di.Equals(d)))
                {
                    d.TongCuoc += di.TongCuoc;
                    d.TongCuoc_t += di.TongCuoc_t;
                   // d.TongCuoc_s += di.TongCuoc_s;

                    d.ThueBao += di.ThueBao;
                    d.ThueBao_t += di.ThueBao_t;
                   // d.ThueBao_s += di.ThueBao_s;

                    d.KhaiThac += di.KhaiThac;
                    d.KhaiThac_t += di.KhaiThac_t;
                    //d.KhaiThac_s += di.KhaiThac_s;

                    d.MoCua += di.MoCua;
                    d.MoCua_t += di.MoCua_t;
                    // d.MoCua_s += di.MoCua_s;

                    d.Truot += di.Truot;
                    d.Truot_t += di.Truot_t;
                    //d.Truot_s += di.Truot_s;
                }
                d.TongCuoc_s = d.TongCuoc - d.TongCuoc_t;
                d.ThueBao_s = d.ThueBao - d.ThueBao_t;
                d.KhaiThac_s = d.KhaiThac - d.KhaiThac_t;
                d.MoCua_s = d.MoCua - d.MoCua_t;
                d.Truot_s = d.Truot - d.Truot_t;
                return d;
            }).ToList(); ;

            return data;
        }
        #endregion
    }

    
    #region Định nghĩa thông tin truck
    public class TruckSummary
    {
        public int TongCuoc { set; get; }
        public int TongCuoc_t { set; get; }
        public int TongCuoc_s { set; get; }

        public int CoHang { set; get; }
        public int CoHang_t { set; get; }
        public int CoHang_s { set; get; }

        public int GoiLai { set; get; }
        public int GoiLai_t { set; get; }
        public int GoiLai_s { set; get; }

        public int HoiGia { set; get; }
        public int HoiGia_t { set; get; }
        public int HoiGia_s { set; get; }

        public int BocXep { set; get; }
        public int BocXep_t { set; get; }
        public int BocXep_s { set; get; }

        public int XinLoi { set; get; }
        public int XinLoi_t { set; get; }
        public int XinLoi_s { set; get; }

        public int ThueBao { set; get; }
        public int ThueBao_t { set; get; }
        public int ThueBao_s { set; get; }

        public int KhaiThac { set; get; }
        public int KhaiThac_t { set; get; }
        public int KhaiThac_s { set; get; }

        public int MoCua { set; get; }
        public int MoCua_t { set; get; }
        public int MoCua_s { set; get; }

        public int Truot { set; get; }
        public int Truot_t { set; get; }
        public int Truot_s { set; get; }

        public int GoiNho { set; get; }
        public int GoiNho_t { set; get; }
        public int GoiNho_s { set; get; }

        public int PhanAnh { set; get; }
        public int PhanAnh_t { set; get; }
        public int PhanAnh_s { set; get; }

        public int NoiBo { set; get; }
        public int NoiBo_t { set; get; }
        public int NoiBo_s { set; get; }

        public int NhayMay { set; get; }
        public int NhayMay_t { set; get; }
        public int NhayMay_s { set; get; }

        public int GoiKhac { set; get; }
        public int GoiKhac_t { set; get; }
        public int GoiKhac_s { set; get; }

        public int KhachHen { set; get; }
        public int KhachHen_t { set; get; }
        public int KhachHen_s { set; get; }

        public int KhachHoan { set; get; }
        public int KhachHoan_t { set; get; }
        public int KhachHoan_s { set; get; }

        public int HetXe { set; get; }
        public int HetXe_t { set; get; }
        public int HetXe_s { set; get; }

        public int GiucXe { set; get; }
        public int GiucXe_t { set; get; }
        public int GiucXe_s { set; get; }

        public string Ca { set; get; }
        #region Thông tin tiếp nhận điện thoại gọi đên
        
        /// <summary>
        /// tổng cuốc có xe nhận đi đón (tính cả trường hợp trượt)
        /// </summary>
        public int TongCuocHang { set; get; }
        /// <summary>
        /// Tổng cuộc gọi mà nhân viên điện thoại tiếp nhận
        /// </summary>
        public int TongCuocDen { set; get; }
        public int DienThoaiCoKhach { set; get; }
        public int LaCuocGoiChen { set; get; }
        //public int GoiLai { set; get; }
       // public int HetXe { set; get; }
        //public int GiucXe { set; get; }
        public int HoanXe { set; get; }
        public int KhieuNai { set; get; }
        //public int XinLoi { set; get; }
        //public int BocXep { set; get; }
        //public int KhachHen { set; get; }
        //public int HoiGia { set; get; }
       // public int NhayMay { set; get; }
       // public int NoiBo { set; get; }
        //public int GoiKhac { set; get; }
        public int KhongCapNhat { set; get; }

        #endregion
        public int TBDuongDai { set; get; }

        //public int GetAllCuocGoi()
        //{
        //    return this.ThueBao + this.KhaiThac + this.MoCua + this.Truot;
        //}
    }
    public class TruckInfo
    {
        public string Ca { set; get; }
        public string SoDT { set; get; }
        public string SoXe { set; get; }
        public DateTime TGTiepNhan { set; get; }
        public int KieuCuocGoi { set; get; }
        public int KieuCuocHang { set; get; }

        public string GiaThueBao { set; get; }
        public int KieuKhachHangGoiDen { set; get; }
        public int TrangThaiLenh { set; get; }
        public int LoaiCuocHang { set; get; }
        public int LyDoTruot { set; get; }
        public int KetQua { set; get; }
        public int ChiSoDi { set; get; }
        public int? ChiSoVe { set; get; }
        public int KmThucDi { set; get; }
        public string GhiChu { set; get; }
        /// <summary>
        /// Là những cuốc chưa xử lý , vẫn còn ở bảng Truck
        /// </summary>
        public int? CuocKhongCapNhat { set; get; }
        public bool LaCuocGoiChen { set; get; }

        #region Phân tích loại cuốc  (Trường KieuCuocGoi) Enum_CallType
        public bool CoHang
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiXe && SoXe != ""
                                    && (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach );
            }
        }

        /// <summary>
        /// Cuốc hàng là cuộc gọi xe và có xe nhận. (Thành công hoặc trượt)
        /// </summary>
        public bool CuocHang
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiXe
                                        && SoXe != "" 
                                        && (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiDonDuocKhach || KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiTruot
                                        );
            }
        }

        public bool GoiLai
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiLai;
            }
        }
        public bool HetXe
        {
            get { return KieuCuocGoi == (int)Enum_CallType.HetXe; }
        }
        public bool GiucXe
        {
            get { return KieuCuocGoi == (int)Enum_CallType.GiucXe; }
        }
        public bool HoanXe
        {
            get { return KieuCuocGoi == (int)Enum_CallType.KhachHoan; }
        }
        public bool KhieuNai
        {
            get { return KieuCuocGoi == (int)Enum_CallType.KhieuNai; }
        }
        public bool XinLoi
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.XinLoiKhach;
            }
        }
        public bool BocXep
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.BocXep;
            }
        }
        public bool KhachHen
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.KhachHen;
            }
        }
        public bool HoiGia
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.HoiGia;
            }
        }
        public bool NhayMay
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.NhayMay;
            }
        }
        public bool NoiBo
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.NoiBo;
            }
        }
        public bool GoiKhac
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiKhac;
            }
        }
        public bool GoiNho
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiNho;
            }
        }
        public bool PhanAnh
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.KhieuNai;
            }
        }
        public bool KhachHoan
        {
            get
            {
                return KieuCuocGoi == (int)Enum_CallType.KhachHoan;
            }
        }
        public bool TongDienThoai
        {
            get
            {
                return KetQua != (int)TrangThaiCuocGoiTaxi.CuocGoiKhongXe && KetQua != (int)TrangThaiCuocGoiTaxi.CuocGoiChuaXacDinh && KetQua != (int)TrangThaiCuocGoiTaxi.CuocDaXoa;
            }
        }
        public bool KhongCapNhat
        {
            get { return CuocKhongCapNhat == 1; }
        }
        #endregion

        #region Phân tích điện thoại và loại hàng
        ///<summary>
        ///Tổng cuộc gọi khách hàng gọi đến
        ///Tổng gọi đến không bao gồm cuốc chèn
        ///</summary>
        public bool TongGoiDen
        {
            get { return  !LaCuocGoiChen ? true : false; }
        }

        /// <summary>
        /// Tổng cuộc gọi yêu cầu xe
        /// </summary>
        public bool DienThoaiCoKhach
        {
            get 
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && KetQua != (int)TrangThaiCuocGoiTaxi.TrangThaiKhac &&
                    (KieuCuocHang == (int)Taxi.Utils.KieuCuocHang.BinhThuong) &&
                    !string.IsNullOrEmpty(SoXe); 
            
            }
        }
        public bool ThueBao
        {
            get
            {
                //return !string.IsNullOrEmpty(GiaThueBao);
                return KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.CuocBinhThuong 
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.MoCua
                    && LoaiCuocHang != (int)LoaiCuocHangThucHien.ThueBaoMeter;
            }
        }
        public bool KhaiThac
        {
            get
            {
                return KieuCuocGoi == (int) Enum_CallType.GoiXe
                       &&
                //       KieuCuocHang == (int)Taxi.Utils.KieuCuocHang.LaiXeKhaiThac
                //       KieuCuocHang == (int) Taxi.Utils.KieuCuocHang.LaiXeKhaiThacDuongDai
                         SoDT.Equals(CommonData.SDTLXKT);
            }
        }
        public bool MoCua
        {
            get
            {
                return LoaiCuocHang == (int)LoaiCuocHangThucHien.MoCua;
            }
        }
        public bool Truot 
        { 
            get 
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && (KetQua == (int)TrangThaiCuocGoiTaxi.CuocGoiTruot); 
            }
        }
        public bool TBDuongDai 
        { 
            get 
            {
                return KieuCuocGoi == (int)Enum_CallType.GoiXe
                    && LoaiCuocHang == (int)LoaiCuocHangThucHien.ThueBaoNgoaiTinh;
            } 
        }

        #endregion
    }
    public static class TruckSummaryExtender
    {
        public static TruckSummary DoSum(this IEnumerable<TruckSummary> tss)
        {
            var ts = new TruckSummary();

            foreach (var ti in tss)
            {
                ts.TongCuocDen += ti.TongCuocDen;
                ts.DienThoaiCoKhach += ti.DienThoaiCoKhach;
                ts.ThueBao += ti.ThueBao;
                ts.KhaiThac += ti.KhaiThac;
                ts.MoCua += ti.MoCua;
                ts.Truot += ti.Truot;
                ts.TBDuongDai += ti.TBDuongDai;
                ts.TongCuocHang += ti.TongCuocHang;
                ts.GiucXe += ti.GiucXe;
                ts.HoanXe += ti.HoanXe;
                ts.KhieuNai += ti.KhieuNai;
                ts.XinLoi += ti.XinLoi;
                ts.BocXep += ti.BocXep;

                ts.GoiLai += ti.GoiLai;
                ts.KhachHen += ti.KhachHen;
                ts.HoiGia += ti.HoiGia;
                ts.GoiKhac += ti.GoiKhac;
                ts.NoiBo += ti.NoiBo;
                ts.NhayMay += ti.NhayMay;
                ts.HetXe += ti.HetXe;

                ts.KhongCapNhat += ti.KhongCapNhat;
            }

            return ts;
        }

        /// <summary>
        /// Tổng hợp cuốc hàng - cuộc gọi
        /// </summary>
        /// <param name="ti"></param>
        /// <returns></returns>
        public static TruckSummary ToTruckSummary(this TruckInfo ti)
        {
            var ts = new TruckSummary();
            if (ti.KhongCapNhat) ts.KhongCapNhat = 1;
            ts.Ca = ti.Ca;
            if (ti.TongGoiDen) ts.TongCuocDen = 1;
            //Nếu là dữ liệu bảng Truck thì không cần tính các thông số sau
            if (ti.CuocKhongCapNhat == 1) return ts;

            if (ti.ThueBao) ts.ThueBao = 1;
            if (ti.KhaiThac) ts.KhaiThac = 1;
            if (ti.MoCua) ts.MoCua = 1;
            if (ti.Truot) ts.Truot = 1;
            if (ti.TBDuongDai) ts.TBDuongDai = 1;
            if (ti.CuocHang) ts.TongCuocHang = 1;

            if (ti.DienThoaiCoKhach) ts.DienThoaiCoKhach = 1;
            if (ti.HetXe) ts.HetXe = 1;
            if (ti.GiucXe) ts.GiucXe = 1;
            if (ti.HoanXe) ts.HoanXe = 1;
            if (ti.KhieuNai) ts.KhieuNai = 1;
            if (ti.XinLoi) ts.XinLoi = 1;
            if (ti.BocXep) ts.BocXep = 1;

            if (ti.GoiLai) ts.GoiLai = 1;
            if (ti.KhachHen) ts.KhachHen = 1;
            if (ti.NhayMay) ts.NhayMay = 1;
            if (ti.NoiBo) ts.NoiBo = 1;
            if (ti.GoiKhac) ts.GoiKhac = 1;
            if (ti.HoiGia) ts.HoiGia = 1;
            return ts;
        }
    }
    #endregion

    /// <summary>
    /// Class Nhân sự trong ca
    /// </summary>
    public class EmployeeCheckIn
    {
        public string Ca { set; get; }
        public string TenNhanVien { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime TGCheckin { get; set; }
    }
}
