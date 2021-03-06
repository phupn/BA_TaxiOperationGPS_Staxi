
namespace Taxi.Common
{
    /// <summary>
    /// Danh sách quyền trong CSDL
    /// </summary>
    /// <Modified>
    /// Name        Date        Comment
    /// LamDS       06/05/2008  Thêm mới
    /// </Modified>
    public class DanhSachQuyen
    {
        public const string CapPhep = "01";
        public const string HoSo = "0101";
        public const string QuanLyHoSo = "010101";
        public const string TaoMoiHoSo = "010102";
        public const string PhanBoHoSo = "010103";
        public const string ChuyenChuyenVienQuanLyHoSo = "010104";
        public const string BanKhai = "0102";
        public const string QuanLyBanKhai = "010201";
        public const string TaoMoiBanKhai = "010202";
		public const string SuaBanKhai = "010203";
		public const string XoaBanKhai = "010204";
		public const string XacNhanBanKhaiHopLe = "010205";
		public const string BanKhaiTraVeChoTruongPhong = "010206";
        public const string GiayPhep = "0103";
        public const string QuanLyGiayPhep = "010301";
        public const string TaoMoiGiayPhep = "010302";
        public const string TaoGiayPhepBangTan = "010303";
        public const string XuLyNgungKhoiPhucGiayPhep = "010304";
		public const string SuaGiayPhep = "010305";
		public const string GiayPhepXacNhanDaKy = "010306";
		public const string GiayPhepGiaHan = "010307";
        public const string ThongBaoNopPhi = "0104";
        public const string QuanLyThongBaoNopPhi = "010401";
        public const string TaoMoiThongBaoNopPhi = "010402";
        public const string QuanLyChuyenGiao = "010403";
		public const string XoaThongBaoNopPhi = "010404";
		public const string SuaThongBaoNopPhi = "010405";
		public const string XacNhanDaKyTBNP = "010406";
        public const string TraCuu = "0105";
        public const string TraCuuGiayPhepCongCongDungRieng = "010501";
        public const string TraCuuGiayPhepPTTH = "010502";
        public const string TraCuuThongBaoNopPhi = "010503";
        public const string QuanLyKhachHang = "0106";
        public const string DanhMuc = "0107";
        public const string DanhMucTinhThanh = "010701";
        public const string DanhMucTrungTam = "010702";
        public const string DanhMucLoaiNghiepVu = "010703";
        public const string DanhMucLoaiMang = "010704";
        public const string DanhMucPhi = "010705";
        public const string DanhMucPhong = "010706";
        public const string DanhMucThietBi = "010707";
        public const string DanhMucAnten = "010708";
        public const string DanhMucVeTinh = "010709";
        public const string DanhMucDaiTanCam = "010710";
        public const string DanhMucKenhPTTH = "010711";
        public const string DanhMucKenhViBa = "010712";
        public const string DanhMucDiaDiemDat = "010713";
        public const string HeThong = "0108";
        public const string QuanLyNguoiDung = "010801";
        public const string QuanLyVaiTro = "010802";
        public const string QuanLyNhatKyHeThong = "010803";
        public const string SaoLuu = "010804";
        public const string PhucHoi = "010805";
        public const string DangKyQuaMang = "02";
        public const string QuanLyThuPhi = "0201";
        public const string QuanLyThuPhi_TimKiem = "020101";
        public const string QuanLyThuPhi_ThuPhi = "020102";
        public const string QuanLyThuPhi_XinNo = "020103";
        public const string DangKyQuaMang_TraCuu = "0202";
        public const string DangKyQuaMang_TraCuuGiayPhep = "020201";
        public const string DangKyQuaMang_TraCuuThuPhi = "020202";
        public const string DangKyQuaMang_TraCuu_TìmnhanhUsercode = "020203";
        public const string QuanLyTinNhan_XemGhiChu = "0102050201";
        public const string QuanLyTinNhan="010205";
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

    /// <summary>
    /// Lưu trữ mã của các lệnh trong hệ thống đối chiếu với CommandCode trong T_TaxiOperation_Command
    /// </summary>
    public class CommandCode
    {          
        //public const string GiucXe = "GIUCXE";

        //public const string NhamKhach = "NHAMKHACH";

        //public const string MoiKhach = "MOIKHACH";

        //public const string GiuKhach = "GIUKHACH";

        //public const string HoiLaiDiaChi = "HOIDC";

        //public const string ChuyenKenh = "CHUYENKENH";

        //public const string KhongXeXL = "KHONGXEXL";

        //public const string KoXeLan1 = "KHONGXE1";

        //public const string KiemTraKhach = "KIEMTRAKHACH";
        
        ////Lênh điện thoại
        //public const string DaMoi = "DAMOIDT";
        //public const string GapXe = "GAPXE";
        //public const string KhongXeXLDT = "KHONGXEXLDT";
        //public const string MayBan = "MAYBAN";
        //public const string TuChoi ="TUCHOI";
        //public const string DaXinLoi = "DAXINLOI";
        //public const string KhongNgheMay = "KHONGNGHEMAY";
        //public const string DaMoiLan2 ="DAMOILAN2";
        //public const string HuyHoan = "HUYHOAN";
        //public const string KhongThayXe = "KHONGTHAYXE";
        //public const string TruotChua = "TRUOTCHUA";
        //public const string KhachDat = "KHACHDAT";
        //public const string GiuRoi="GIUROI";
        //public const string MoiLan2 = "MOILAN2";

        //public const string RaDauNgo= "RADAUNGO";
        //public const string MatKetNoi = "MATKETNOI";
        //public const string GoiChoKhachKTX = "GOICHOKHACHKTX";
        //public const string KoLienLacDuoc = "KHONGLIENLACDUOC";
        //public const string KoXeNhan = "KOXENHAN";
        //public const string AppDieuDam = "APPDIEUDAM";
        //public const string AppKhongXe ="APPKHONGXE";
        //public const string DangRa="DANGRA";
        //public const string ChoKhach="CHOKHACH";

        //public const string DoiXe = "DOIXE";

        //public const string DangGoi = "DANGGOI";
        //public const string DangGoiTD = "DANGGOI_TD";

        //public const string KoTrucTiep = "KHONGTRUCTIEP";
        //public const string KoNoiGi = "KHONGNOIGI";
        //public const string TiepThiXe="TIEPTHIXE";
        //public const string ThueBao="THUEBAO";
        //public const string ThayXe="THAYXE";
        //public const string ChuyenApp = "CHUYENAPP";
        //public const string ChuyenDam = "CHUYENDIEUDAM";
        //public const string HoanThanh = "HOANTHANH";
        //public const string ChoSoDT = "CHOSO";
        //public const string KoChoSoDT = "KOCHOSO";
        //public const string HienThiSoDT = "HIENTHISO";
        //public const string HoanCuoc = "HOANCUOC";
        //public const string TruoTCuoc = "TRUOTCUOC";


        public const string PMDH_CONST_Msg_NoCarAccept = "Ko xe nhận";
        public const string PMDH_CONST_AppDieuDam = "App - điều đàm";
        public const string PMDH_CONST_Msg_NoCar = "App - ko xe";
        public const string LENH_DANGGOI = "Đang gọi...";
        public const string LENH_G_GIUCXE = "Giục xe";
        public const string LENH_KHACHDAT = "KHÁCH ĐẶT";
        public const string LENH_NhamKH = "Nhầm khách";
        public const string LENH_HUYXE = "Hủy xe/Hoãn";
        public const string LENH_TRUOTCHUA = "Trượt cuốc";
        public const string LENH_SHOWPHONENUMBER = "[Đã gửi sđt cho lx]";
    }
}
