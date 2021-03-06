using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
namespace Taxi.Business
{

    public enum LoaiSaoLuu
    {
        Ngay = 4,
        Tuan = 8,
        Thang = 16
    }

    public enum NgayTrongTuan
    {
        ChuNhat = 1,
        ThuHai = 2,
        ThuBa = 4,
        ThuTu = 8,
        ThuNam = 16,
        ThuSau = 32,
        ThuBay = 64
    }


    public class KieuMayTinh
    {
        public const string MAYDIENTHOAI = "DT"; // may dien thoai
        public const string MAYTONGDAI = "TD";   // may tong dai
        public const string MAYMOIKHACH = "MK";  // may moi khach - moi trong vung nao
        public const string MAYKHACHMOI = "KM";     // may khach moi voi dien thoai
    }
    /// <summary>
    /// kiểu vị trị người sử dụng gọi ra
    /// </summary>
    public class KieuLineGoiRa
    {
        public const string MAYDIENTHOAI = "DT"; // may dien thoai 
        public const string MAYMOIKHACH = "MK";  // may moi khach - moi trong vung nao
        public const string MAYCSKHACHHACH = "KH";     // may khach moi voi dien thoai
        public const string MAYTRUONGCA = "TC";     // goi phia trưởng cả theo line
        public const string MAYKHAC = "KA";     //  máy khác - không xác định vị trí.
    }

    /// <summary>
    /// Danh sách quyền trong CSDL
    /// </summary>
    /// <Modified>
    /// Name        Date        Comment
    /// LamDS       06/05/2008  Thêm mới
    /// </Modified>
    /// 

    public class DanhSachVaiTro
    {
        public const string DIEUHANHHIENTHOAI = "NVDT"; // may dien thoai
        public const string DIEUHANHTONGDAI = "NVTD"; // may dien thoai
        public const string DIEUHANHCSKH = "NVCAMON"; // may dien thoai
        public const string NVNHANPHANANH = "NVNHANPHANANH"; // nhan vien nhan phan anh
        public const string NVGIAIQUYETPHANANH = "NVGIAIQUYETPHANANH"; // nhan vien giai quyet phan anh
        public const string NVGIAIQUYETPHANANH_II = "NVGIAIQUYETPHANANH_II"; // nhan vien giai quyet phan anh cap II
        public const string App_CARRole = "CAR"; // may dien thoai

    }
    
    public class DSLoaiXe
    {
        public const string MORNING = "MOR";
        public const string VIOS = "VIOS";
        public const string CARENS = "CAR";
        public const string INOVA = "INO";
    }

    public class DanhSachQuyen
    {
        public const string Taxi = "01";
        public const string QuanTriHeThong = "0101";
        public const string QuanLyCauHinh = "010101";
        public const string QuanLyNguoiDung = "010102";
        public const string QuanLyVaiTrong = "010103";
        public const string ThemGhiChuTrongCaKhac = "010208";

        public const string QuanLy = "0102";
        public const string QuanLyNhanVien = "010201";
        public const string QuanLyVe = "010202";
		public const string NgheCuocGoiDi = "010203";
		public const string NgheCuocGoiDen = "010204";
	     public const string BaoCao = "0103";
        public const string BaoCao_01 = "010301";
        public const string BaoCao_02 = "010302";
        public const string BaoCao_03 = "010303";
        public const string BaoCao_04 = "010304";
		public const string BaoCao_05 = "010305";
		public const string BaoCao_06 = "010306";
		public const string BaoCao_07  = "010307";
        public const string BaoCao_08  = "010308";
        public const string BaoCao_09  = "010309";
        public const string BaoCao_10  = "010310";
        public const string BaoCao_11  = "010311";
        public const string BaoCao_12  = "010312";
        public const string BaoCao_13  = "010313";
        public const string BaoCao_14  = "010314";
        public const string BaoCao_15  = "010315";
        public const string BaoCao_16  = "010316";
        public const string BaoCao_17  = "010317";
       

        public const string DanhMuc = "0104";
        public const string DanhMucDoiTac = "010401";
        public const string DanhMucKhachVIP = "010402";
        public const string DanhMucKhachAo = "010403";
		public const string DanhBaCongTy = "010404";
		public const string DanhMucXe = "010405";
		public const string DanhMucPhong = "010406";
        public const string DanhMucChucVu = "010407";

        public const string DieuHanh = "0105";

        public const string TagQLTinNhan = "01020502";
        public const string TagGuiTinNhan = "01020501";
        public const string TagSoanTinNhanMau = "01020503";

        /// <summary>
        /// Tổng đài được phép sửa địa chỉ đón
        /// </summary>
        public const string CuocGoi_TD_SuaDiaChiDon = "01020901";
        /// <summary>
        /// Mời khách được phép sửa địa chỉ đón
        /// </summary>
        public const string CuocGoi_MK_SuaDiaChiDon = "01020902";

        //public const string DieuHanhDienThoai = "990101";
        //public const string DieuHanhTongDai = "990102"; 


        // Quyen module CẢM ƠN KHÁCH
        public const string ModuleCamOnKhach = "0201";
        public const string CamOnKhach = "020101";
        /// <summary>
        /// Cập nhật thuê bao tuyến
        /// </summary>
        public const string UpdateThueBaoTuyen = "010208";
        // =========================
        public const string BaoCao_1_2_XoaCuocGoi = "0104010301";

        public const string DieuSanBay = "CH06";

    }

    /// <summary>
    /// Danh sách các hành động ghi log
    /// </summary>
    /// <Modified>
    /// Name        Date        Comment
    /// LamDS       06/05/2008  Thêm mới
    /// </Modified>
    public class HanhDongGhiLog
    {
        public const string HoSo_Loc_VanThu = "0101";
        public const string HoSo_PhanBo_VanThu = "0102";
        public const string HoSo_TraVe_VanThu = "0103";
        public const string HoSo_NhapSoCVDen = "0104";
        public const string HoSo_ThemMoi = "0105";
        public const string HoSo_Sua = "0106";
        public const string HoSo_Xoa = "0107";
        public const string HoSo_Loc_TruongPhong = "0108";
        public const string HoSo_PhanBo_TruongPhong = "0109";
        public const string HoSo_TraVe_TruongPhong = "0110";
        public const string HoSo_ChuyenChuyenVienQuanLy = "0111";
        public const string BanKhai_Loc = "0201";
        public const string BanKhai_TraVe = "0202";
        public const string BanKhai_XacNhanHopLe = "0203";
        public const string BanKhai_ThemMoi = "0204";
        public const string BanKhai_Sua = "0205";
        public const string BanKhai_SuaMoi = "0206";
        public const string BanKhai_Xoa = "0207";
        public const string BanKhai_XacNhanKhongHopLe = "0208";
        public const string GiayPhep_Loc = "0301";
        public const string GiayPhep_XacNhanDaKy = "0302";
        public const string GiayPhep_In = "0303";
        public const string GiayPhep_GiaHan = "0304";
        public const string GiayPhep_ThemMoi = "0305";
        public const string GiayPhep_Sua = "0306";
        public const string GiayPhep_SuaMoi = "0307";
        public const string GiayPhep_Xoa = "0308";
        public const string GiayPhep_Ngung = "0309";
        public const string GiayPhep_KhoiPhuc = "0310";
        public const string TBNP_Loc = "0401";
        public const string TBNP_XacNhanDaKy = "0402";
        public const string TBNP_In = "0403";
        public const string TBNP_ThemMoi = "0404";
        public const string TBNP_Sua = "0405";
        public const string TBNP_Xoa = "0406";
        public const string ChuyenGiao_Loc = "0501";
        public const string ChuyenGiao_ThemMoi = "0502";
        public const string ChuyenGiao_Sua = "0503";
        public const string ChuyenGiao_Xoa = "0504";
        public const string TraCuuGPCongCongDungRieng_TimGiayPhep = "0601";
        public const string TraCuuGPCongCongDungRieng_XuatRaExcel = "0602";
        public const string TraCuuGPPTTH_TimGiayPhep = "0701";
        public const string TraCuuGPPTTH_XuatRaExcel = "0702";
        public const string TraCuuTBNP_TimTBNP = "0801";
        public const string TraCuuTBNP_XuatRaExcel = "0802";
        public const string KhachHang_ThemMoi = "0901";
        public const string KhachHang_Sua = "0902";
        public const string KhachHang_Xoa = "0903";
        public const string KhachHang_DanhSach = "0904";
        public const string KhachHang_TimNhanhUsercode = "0905";
        public const string DanhMucTinhThanh_ThemMoi = "1001";
        public const string DanhMucTinhThanh_Sua = "1002";
        public const string DanhMucTinhThanh_Xoa = "1003";
        public const string DanhMucTinhThanh_DanhSach = "1004";
        public const string DanhMucTrungTam_ThemMoi = "1101";
        public const string DanhMucTrungTam_Sua = "1102";
        public const string DanhMucTrungTam_Xoa = "1103";
        public const string DanhMucTrungTam_DanhSach = "1104";
        public const string DanhMucLoaiNghiepVu_ThemMoi = "1201";
        public const string DanhMucLoaiNghiepVu_Sua = "1202";
        public const string DanhMucLoaiNghiepVu_Xoa = "1203";
        public const string DanhMucLoaiNghiepVu_DanhSach = "1204";
        public const string DanhMucLoaiMang_ThemMoi = "1301";
        public const string DanhMucLoaiMang_Sua = "1302";
        public const string DanhMucLoaiMang_Xoa = "1303";
        public const string DanhMucLoaiMang_DanhSach = "1304";
        public const string DanhMucPhi_Sua = "1401";
        public const string DanhMucPhi_DanhSach = "1402";
        public const string DanhMucPhong_ThemMoi = "1501";
        public const string DanhMucPhong_Sua = "1502";
        public const string DanhMucPhong_Xoa = "1503";
        public const string DanhMucPhong_DanhSach = "1504";
        public const string DanhMucThietBi_ThemMoi = "1601";
        public const string DanhMucThietBi_Sua = "1602";
        public const string DanhMucThietBi_Xoa = "1603";
        public const string DanhMucThietBi_DanhSach = "1604";
        public const string DanhMucAnten_ThemMoi = "1701";
        public const string DanhMucAnten_Sua = "1702";
        public const string DanhMucAnten_Xoa = "1703";
        public const string DanhMucAnten_DanhSach = "1704";
        public const string DanhMucVeTinh_ThemMoi = "1801";
        public const string DanhMucVeTinh_Sua = "1802";
        public const string DanhMucVeTinh_Xoa = "1803";
        public const string DanhMucVeTinh_DanhSach = "1804";
        public const string DanhMucDaiTanCam_ThemMoi = "1901";
        public const string DanhMucDaiTanCam_Sua = "1902";
        public const string DanhMucDaiTanCam_Xoa = "1903";
        public const string DanhMucDaiTanCam_DanhSach = "1904";
        public const string DanhMucKenhPTTH_ThemMoi = "2001";
        public const string DanhMucKenhPTTH_Sua = "2002";
        public const string DanhMucKenhPTTH_Xoa = "2003";
        public const string DanhMucKenhPTTH_DanhSach = "2004";
        public const string DanhMucKenhViBa_ThemMoi = "2101";
        public const string DanhMucKenhViBa_Sua = "2102";
        public const string DanhMucKenhViBa_Xoa = "2103";
        public const string DanhMucKenhViBa_DanhSach = "2104";
        public const string DanhMucDiaDiemDat_ThemMoi = "2201";
        public const string DanhMucDiaDiemDat_Sua = "2202";
        public const string DanhMucDiaDiemDat_Xoa = "2203";
        public const string DanhMucDiaDiemDat_DanhSach = "2204";
        public const string HeThong_ThayDoiThongTinCaNhan = "2301";
        public const string HeThong_ThietLapCoCheSaoLuuTuDong = "2302";
        public const string HeThong_SaoLuuBangTay = "2303";
        public const string HeThong_Phuchoi_DanhSach = "2304";
        public const string HeThong_Phuchoi_Xoa = "2305";
        public const string HeThong_Phuchoi = "2306";
        public const string HeThong_ThietLapCauHinhCSDL = "2307";
        public const string QuanLyNguoiDung_ThemMoi = "2401";
        public const string QuanLyNguoiDung_Sua = "2402";
        public const string QuanLyNguoiDung_Xoa = "2403";
        public const string QuanLyNguoiDung_DanhSach = "2404";
        public const string QuanLyNguoiDung_PhanQuyen = "2405";
        public const string QuanLyNguoiDung_PhanVaiTro = "2406";
        public const string QuanLyVaiTro_ThemMoi = "2501";
        public const string QuanLyVaiTro_Sua = "2502";
        public const string QuanLyVaiTro_Xoa = "2503";
        public const string QuanLyVaiTro_DanhSach = "2504";
        public const string QuanLyVaiTro_PhanQuyen = "2505";
        public const string QuanLyVaiTro_PhanVaiTrochoNguoiDung = "2506";
        public const string QuanLyNhatKyHeThong_Loc = "2601";
        public const string QuanLyNhatKyHeThong_ThietLapCoCheGhiNhatKy = "2602";
        public const string QuanLyNhatKyHeThong_Xoa = "2603";
        public const string QuanLyThuPhi_TimKiem = "2701";
        public const string QuanLyThuPhi_ThuPhi = "2702";
        public const string QuanLyThuPhi_XinNo = "2703";
        public const string QuanLyThuPhi_XoaLanThuPhi = "2704";
        public const string QuanLyThuPhi_SuaLanThuPhi = "2705";
        public const string DangKyQuaMang_TraCuuGiayPhep = "2801";
        public const string DangKyQuaMang_TraCuuThuPhi = "2802";
        public const string DangKyQuaMang_ThayDoiThongTinCaNhan = "2901";
        public const string DangKyQuaMang_TimNhanhUsercode = "2902";
        public const string DangKyQuaMang_XuatRaExcel = "2903";
        public const string DangKyQuaMang_QuanLyHoSo_Loc = "3001";
        public const string DangKyQuaMang_QuanLyHoSo_ThemMoi = "3002";
        public const string DangKyQuaMang_QuanLyHoSo_CapNhat = "3003";
        public const string DangKyQuaMang_QuanLyHoSo_Xoa = "3004";
        public const string DangKyQuaMang_QuanLyHoSo_Gui = "3005";
        public const string DangKyQuaMang_QuanLyBanKhai_ThemMoi = "3101";
        public const string DangKyQuaMang_QuanLyBanKhai_Sua = "3102";
        public const string DangKyQuaMang_QuanLyBanKhai_Xoa = "3103";
        public const string DangKyQuaMang_QuanLyBanKhai_In = "3104";
        public const string DangKyQuaMang_QuanLyBanKhai_DanhSach = "3105";
        public const string DangKyQuaMang_DangKyNgung_ThemMoi = "3201";
        public const string DangKyQuaMang_DangKyNgung_Xoa = "3202";
        public const string DangKyQuaMang_DangKyNgung_DanhSach = "3203";
        public const string DangKyQuaMang_DangKyNgung_LocGP = "3204";
        public const string DangKyQuaMang_DangKyGiaHan_ThemMoi = "3301";
        public const string DangKyQuaMang_DangKyGiaHan_Xoa = "3302";
        public const string DangKyQuaMang_DangKyGiaHan_DanhSach = "3303";
        public const string DangKyQuaMang_DangKyGiaHan_LocGP = "3304";
        public const string DangKyQuaMang_KhachHang_TraCuu_GiayPhep = "3401";
        public const string DangKyQuaMang_KhachHang_TraCuu_TraPhi = "3402";
        public const string DangKyQuaMang_KhachHang_BaoCao_GiayPhep = "3501";
        public const string DangKyQuaMang_KhachHang_BaoCao_TBNP = "3502";
    }
}
