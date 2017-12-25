using System;
using System.ComponentModel;

namespace Taxi.Utils
{
    [DefaultValue(None)]
    public enum TaxiLicense
    {
        #region === 2015 ===

        [TaxiInfo(Name = "Common", PhoneNumber = "01234567989", Date = "2015")]
        None=-1,
        /// <summary>
        /// Triệu quốc đạt
        /// </summary>
        [TaxiInfo(Name = "Triệu quốc đạt", PhoneNumber = "0438303030",Date="2015")]
        TaxiTrieuQuocDat=0,
        /// <summary>
        /// Sơn Tây
        /// </summary>
        [TaxiInfo(Name = "Sơn Tây", PhoneNumber = "0433626262", Date = "2015")]
        TaxiSonTay = 1,
        /// <summary>
        /// Linh Anh
        /// </summary>
        [TaxiInfo(Name = "Linh Anh", PhoneNumber = "0437656565", Date = "2015")]
        TaxiLinhAnh = 2,
        /// <summary>
        /// Xuân Thành Hà Nội
        /// </summary>
        [TaxiInfo(Name = "Xuân Thành Hà Nội", PhoneNumber = "0462767676", Date = "2015")]
        TaxiXuanThanhHaNoi = 3,
        /// <summary>
        /// Tiên Sa - Đà Nẵng
        /// </summary>
        [TaxiInfo(Name = "Tiên Sa - Đà Nẵng", PhoneNumber = "05113797979", Date = "2015")]
        TaxiTienSaDaNang = 4,
        /// <summary>
        /// Yên Bái
        /// </summary>
        [TaxiInfo(Name = "Yên Bái", PhoneNumber = "0293868686", Date = "2015")]
        TaxiYenBai = 5,
        /// <summary>
        /// Khải Oanh
        /// </summary>
        [TaxiInfo(Name = "Khải Oanh", PhoneNumber = "02103636363", Date = "2015")]
        TaxiKhaiOanh = 6,
        /// <summary>
        /// Lạng Sơn
        /// </summary>
        [TaxiInfo(Name = "Lạng Sơn", PhoneNumber = "0253766766", Date = "2015")]
        TaxiLangSon = 7,
        /// <summary>
        /// SH
        /// </summary>
        [TaxiInfo(Name = "SH", PhoneNumber = "030378788", Date = "2015")]
        TaxiSH = 8,
        /// <summary>
        /// Vina Taxi
        /// </summary>
        [TaxiInfo(Name = "Vina Taxi", PhoneNumber = "0432868686", Date = "2015")]
        TaxiVina = 9,
        /// <summary>
        /// Hà Nội Mới
        /// </summary>
        [TaxiInfo(Name = "Hà Nội Mới", PhoneNumber = "0437616161", Date = "2015")]
        TaxiHaNoiMoi = 10,
        /// <summary>
        /// Tiên Sa - Quảng Bình
        /// </summary>
        [TaxiInfo(Name = "Tiên Sa - Quảng Bình", PhoneNumber = "0523797979", Date = "2015")]
        TaxiTienSaQuangBinh = 11,
        /// <summary>
        /// Sông Lam
        /// </summary>
        [TaxiInfo(Name = "Sông Lam", PhoneNumber = "0383727272", Date = "2015")]
        TaxiSongLam =12,
        /// <summary>
        /// Vạn Xuân Nghệ An
        /// </summary>
        [TaxiInfo(Name = "Vạn Xuân Nghệ An", PhoneNumber = "0383989898", Date = "2015")]
        TaxiVanXuanNgheAn = 13,
        /// <summary>
        /// ABC
        /// </summary>
        [TaxiInfo(Name = "ABC", PhoneNumber = "0432191919", Date = "2015")]
        TaxiABC = 14,
        /// <summary>
        /// Tiên Sa Huế
        /// </summary>
        [TaxiInfo(Name = "Tiên Sa Huế", PhoneNumber = "0543797979", Date = "2015")]
        TaxiTienSaHue = 15,
        /// <summary>
        /// Taxi Nam Cường
        /// </summary>
        [TaxiInfo(Name = "Taxi Nam Cường", PhoneNumber = "02103686868", Date = "2015")]
        TaxiNamCuong = 16,
        /// <summary>
        /// Taxi Việt Way
        /// </summary>
        [TaxiInfo(Name = "Taxi Việt Way", PhoneNumber = "03203869869", Date = "2015")]
        TaxiVietWay = 17,
        /// <summary>
        /// Taxi Ba Sao
        /// </summary>
        [TaxiInfo(Name = "Taxi Ba Sao", PhoneNumber = "0432323232", Date = "2015")]
        TaxiBaSao = 18,
        /// <summary>
        /// Taxi Phiệt Học
        /// </summary>
        [TaxiInfo(Name = "Taxi Phiệt Học", PhoneNumber = "0363696969", Date = "2015")]
        TaxiPhietHoc = 19,
        /// <summary>
        /// Taxi Phú Bình
        /// </summary>
        [TaxiInfo(Name = "Taxi Phú Bình", PhoneNumber = "0333573573", Date = "2015")]
        TaxiPhuBinh = 20,
        /// <summary>
        /// Thành Công - Huế
        /// </summary>
        [TaxiInfo(Name = "Thành Công - Huế", PhoneNumber = "0546575757", Date = "2015")]
        TaxiThanhCongHue = 21,
        /// <summary>
        /// Taxi Bình An
        /// </summary>
        [TaxiInfo(Name = "Taxi Bình An", PhoneNumber = "02803545454", Date = "2015")]
        TaxiBinhAn = 22,
        /// <summary>
        /// Taxi Hà Đông
        /// </summary>
        [TaxiInfo(Name = "Taxi Hà Đông", PhoneNumber = "0433535353", Date = "2015")]
        TaxiHaDong = 23,
        /// <summary>
        /// Taxi Sao HN
        /// </summary>
        [TaxiInfo(Name = "Taxi Sao HN", PhoneNumber = "02413898989", Date = "2015")]
        TaxiSaoHN = 24,
        /// <summary>
        /// Taxi Hoàng Thắng
        /// </summary>
        [TaxiInfo(Name = "Taxi Hoàng Thắng", PhoneNumber = "03213938938", Date = "2015")]
        TaxiHoangThang = 25,
        /// <summary>
        /// Taxi Phú Bình - Cửa Ông
        /// </summary>
        [TaxiInfo(Name = "Taxi Phú Bình - Cửa Ông", PhoneNumber = "0333599599", Date = "2015")]
        TaxiPhuBinhCuaOng = 26,
        /// <summary>
        /// Taxi Rồng Vàng
        /// </summary>
       [TaxiInfo(Name = "Taxi Rồng Vàng", PhoneNumber = "0433866866", Date = "2015")]
        TaxiRongVang = 27,
        /// <summary>
       /// Taxi Sao HN
        /// </summary>
        [TaxiInfo(Name = "Taxi Sao HN", PhoneNumber = "0432535353", Date = "2015")]
        TaxiSaoHaNoi = 28,
        /// <summary>
        /// Taxi Thanh Nga
        /// </summary>
        [TaxiInfo(Name = "Taxi Thanh Nga", PhoneNumber = "0438215215", Date = "2015")]
        TaxiThanhNga = 29,
        /// <summary>
        /// Taxi VIC
        /// </summary>
        [TaxiInfo(Name = "Taxi VIC", PhoneNumber = "0438230230", Date = "2015")]
        TaxiVIC = 30,
        /// <summary>
        /// Taxi Mỹ Đình
        /// </summary>
        [TaxiInfo(Name = "Taxi Mỹ Đình", PhoneNumber = "0438333888", Date = "2015")]
        TaxiMyDinh = 31,
        /// <summary>
        /// Taxi Sông Đà
        /// </summary>
        [TaxiInfo(Name = "Taxi Sông Đà", PhoneNumber = "02183898989", Date = "2015")]
        TaxiSongDa = 32,
        /// <summary>
        /// Taxi Vạn Xuân HN
        /// </summary>
        [TaxiInfo(Name = "Taxi Vạn Xuân HN", PhoneNumber = "0438222888", Date = "2015")]
        TaxiVanXuanHaNoi = 33,
        /// <summary>
        /// Taxi Minh Giang
        /// </summary>
        [TaxiInfo(Name = "Taxi Minh Giang", PhoneNumber = "06503738738", Date = "2015")]
        TaxiMinhGiang = 34,
        /// <summary>
        /// Taxi Sài Gòn
        /// </summary>
        [TaxiInfo(Name = "Taxi Sài Gòn", PhoneNumber = "06136363636", Date = "2015")]
        TaxiSaiGon = 35,
        /// <summary>
        /// Taxi VIC Bắc Ninh
        /// </summary>
        [TaxiInfo(Name = "Taxi VIC Bắc Ninh", PhoneNumber = "02416565656", Date = "2015")]
        TaxiVicBacNinh = 36,
        /// <summary>
        /// Taxi Quê Lụa
        /// </summary>
        [TaxiInfo(Name = "Taxi Quê Lụa", PhoneNumber = "0433533533", Date = "2015")]
        TaxiQueLua = 37,
        /// <summary>
        /// Taxi Sao thủ đô
        /// </summary>
        [TaxiInfo(Name = "Taxi Sao Thủ Đô", PhoneNumber = "0432232323", Date = "2015")]
        TaxiSaoThuDo = 38,
        /// <summary>
        /// Taxi Hoàng Hà
        /// </summary>
        [TaxiInfo(Name = "Taxi Hoàng Hà", PhoneNumber = "0363842842", Date = "2015")]
        TaxiHoangHa = 39,
        /// <summary>
        /// Taxi Mạnh Huyền
        /// </summary>
        [TaxiInfo(Name = "Taxi Mạnh Huyền", PhoneNumber = "02413686868", Date = "2015")]
        TaxiManhHuyen = 40,
        /// <summary>
        /// Én Vàng Vip
        /// </summary>
        [TaxiInfo(Name = "Én Vàng VIP", PhoneNumber = "0437333555", Date = "2015")]
        TaxiEnVangVip = 41,
        /// <summary>
        /// Taxi Ngọc lan
        /// </summary>
        [TaxiInfo(Name = "Taxi Ngọc Lan", PhoneNumber = "02113878787", Date = "2015")]
        TaxiNgocLan = 42,
        /// <summary>
        /// Taxi Bắc Trung Nam
        /// </summary>
        [TaxiInfo(Name = "Taxi Bắc Trung Nam", PhoneNumber = "0373888999", Date = "2015")]
        TaxiBacTrungNam = 43,
        /// <summary>
        /// Taxi Thành Lời Hà Nam
        /// </summary>
        [TaxiInfo(Name = "Taxi Thành Lợi Hà Nam", PhoneNumber = "03513550550", Date = "2015")]
        TaxiThanhLoiHaNam = 44,
        /// <summary>
        /// Taxi Cường Thịnh
        /// </summary>
        [TaxiInfo(Name = "Taxi Cường Thịnh", PhoneNumber = "0436789789", Date = "2015")]
        TaxiCuongThinh = 45,
        /// <summary>
        /// Taxi Đăng quang - Phú quốc
        /// </summary>
        [TaxiInfo(Name = "Taxi Đăng Quang - Phú Quốc", PhoneNumber = "0773789789", Date = "2015")]
        TaxiDangQuang = 46,
        /// <summary>
        /// Taxi Phương Trang
        /// </summary>
        [TaxiInfo(Name = "Taxi Phương Trang", PhoneNumber = "0838181818", Date = "2015")]
        TaxiPhuongTrang = 47,
        /// <summary>
        /// Taxi 123
        /// </summary>
        [TaxiInfo(Name = "Taxi 123", PhoneNumber = "0438123123", Date = "2015")]
        Taxi123 = 48,
        /// <summary>
        /// Taxi Thành Công Hà nội
        /// </summary>
        [TaxiInfo(Name = "Taxi Thành Công Hà nội", PhoneNumber = "0432575757", Date = "2015")]
        TaxiThanhCongHaNoi = 49,
        #endregion


    }
    public class TaxiInfoAttribute : Attribute
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        /// <summary>
        /// dd/MM/yyyy
        /// Hạn sử dụng phần mềm
        /// </summary>
        public string Exprie { get; set; }
    }
}
