using System.Diagnostics;
using System.Windows.Forms;

namespace Taxi.Utils
{
    public static class license
    {
        public static class VersionInfo
        {
            #region ==== G5Version ===
            public static string G5Version_DienThoai()
            {
                return "V2 Build20171206 V2";
            }
            public static string G5Version_TongDai()
            {
                return "V2 Build20171018 V7";
            }
            #endregion

            #region ==== StaxiVersion ===
            public static string StaxiVersion_DienThoai()
            {
                return "V2 Build20161004 V2";
            }
            public static string StaxiVersion_TongDai()
            {
                return "V2 Build20161004 V2";
            }
            #endregion

            #region ==== EnvangVersion ===
            public static string EnvangVersion_DienThoai()
            {
                return "Cập nhật ngày 01/11/2015";
            }
            public static string EnvangVersion_TongDai()
            {
                return "Cập nhật ngày 01/11/2015";
            }
            #endregion

            #region === Common ===
            public static string Version_DieuHanhChinh()
            {
                return "V2 Build20171114";
            }

            public static string Version_License()
            {
                return "V20170301";
            }
            #endregion
        }

        public static string Version()
        {
            switch (Global.Module)
            {
                case EnumModule.DieuHanhChinh:
                    return VersionInfo.Version_DieuHanhChinh();
                case EnumModule.G5_DienThoai:
                    return VersionInfo.G5Version_DienThoai();
                case EnumModule.G5_TongDai:
                    return VersionInfo.G5Version_TongDai();
                case EnumModule.Staxi_DienThoai:
                    return VersionInfo.StaxiVersion_DienThoai();
                case EnumModule.Staxi_TongDai:
                    return VersionInfo.StaxiVersion_TongDai();
                case EnumModule.EnVang_DienThoai:
                    return VersionInfo.EnvangVersion_DienThoai();
                case EnumModule.EnVang_TongDai:
                    return VersionInfo.EnvangVersion_TongDai();
            }
            return "V2 Build20170621";
        }


        public readonly static int idxCompany = int.Parse(System.Configuration.ConfigurationManager.AppSettings["idxCompany"]);
        public readonly static bool IsThanhCong = System.Configuration.ConfigurationManager.AppSettings["IsThanhCong"] != null;
        public readonly static bool IsTaxiGroup = idxCompany == 58;
        public readonly static bool IsTaxiBaSao = idxCompany == 18;
        private static string[] ListSDT = new string[]
      {
          //0
            "0438303030", 
          //1
            "0433626262",
          //2
            "0437656565",
          //3
            "0462767676",
          //4
            "05113797979",
          //5
            "0293868686",
          //6
            "02103636363",
          //7 : 22_07_2014
            "0253766766",
          //8 : 22_07_2014
            "030378788",
          //9 : 24_07_2014
          "0432868686",
          //10 : 24_07_2014
          "0437616161",
          //11 : 24_07_2014
          "0523797979",
          //12 : 26_08_2014
          "0383727272",
          //13 : 26_08_2014
          "0383989898",
          //14 : 22_09_2014 Thử
          "0432191919",
          //15 : 22_09_2014 Thử
          "0543797979",
          //16 : 22_10_2014 Thử
          "02103686868",
          //17 : 4_11_2014
          "03203869869",
          //18 : 12/11/2014
          "0432323232",
          //19 : 09/12/2014
          "0363696969",
          //20 : 27/12/2014
          "02033573573",
          //21 : 31/12/2014
          "0546575757",
          //22 : 13/2/2015
          "02803545454",
          //23 : 13/5/2015
          "0433535353",
          //24 : 15/5/2015
          "02413898989",
          //25 : 20/5/2015
          "03213938938",
          //26 : 25/5/2015 Taxi Phú Bình - Bãi Cháy=> 22/02/2017
          "‎02033599599",
          //27 : 8/6/2015
          "0433866866",
          //28 : 23/06/2015
          "0432535353",
          //29 : 26/06/2015
          "0438215215",
          //30 : 06/07/2015
          "0438230230",
          //31 : 13/07/2015
          "0438333888",
          //32 : 13/07/2015
          "02183898989",
          //33 : 13/07/2015
          "0438222888",
          //34 : 17/07/2015
          "06503738738",
          //35 : 18/07/2015
          "06136363636",
          //36 : 28/07/2015
          "02416565656",
          //37 : 25/07/2015
          "0433533533",
          //38 : 30/07/2015
          "0432232323",
          //39 : 4/08/2015--Update Bat So T4
          "0363842842",
          //40 : 12/08/2015--Update Staxi
          "02413686868",
          //41 : 28/08/2015--EnVangVIP
          "0437333555",
          //42 : 1/09/2015--Taxi Ngọc Lan - Vĩnh Phúc 518
          "02113878787",
          //43 : 16/09/2015--Taxi Bắc Trung Nam 415
          "0373888999",
          //44 : 18/09/2015--Taxi Thành Lợi ND 9142
          "03513550550",
          //45 : 21/09/2015--Taxi Cường Thịnh 768
          "0436789789",
          //46 : 2/10/2015--Taxi Đăng Quang - Phú Quốc 9258
          "0773789789",
          //47 : 9/11/2015--Taxi Phương Trang - Sài Gòn 
          "0838181818",
          //48 : 15/12/2015--Taxi 123 - Sóc Sơn
          "0438123123",
          //49 : 07/1/2016--Taxi Thành Công HN
          "0432575757",
          //50 : 07/1/2016--Taxi Thành Công Vĩnh Phúc
          "02116575757",
          //51 : 07/1/2016--Taxi Thành Công Hà Nam
          "03513575757",
          //52 : 23/2/2016--Taxi Quyết Tiến Daklak
          "05003813813",
          //53 : 14/04/2016 -- Taxi Gruop
          "0438535353",
          //54 : 16/05/2016 -- Taxi Long Biên
          "0438736736",
          //55 : 20/06/2016 -- Taxi Thành Đông
          "03203836836",
          //56 : 29/06/2016 -- Taxi Song Nhue
          "0463252525",
          //57 : 11/08/2016 -- Taxi Hội Lim Bắc Ninh
          "02413711711",
          //58 : 12/08/2016 -- Taxi Group Bắc Ninh
          "02413696969",
          //59 : 13/08/2016 -- Taxi Nguyễn Gia Đồ Sơn Hải Phòng
          "0313898989",
          //60 : 5/9/2016 -- Taxi Thành Công Hạ Long
          "0333675757",
          //61 : 7/9/2016
          "0313569569",
          //62 : 20/9/2016
          "03213535353",
          //63 : 5/10/2016
          "0437191919",
          //64 : 1/11/2016 Taxi Đồng Đội: 0253767767
          "0253767767",
          //65 : 1/11/2016 Taxi Lạng Sơn 0253877877
          "0253877877",
          //66 : 23/11/2016 Taxi Vạn An Hải Phòng
          "0313929292",
          //67 : 07/12/2016 Taxi Rồng Vàng
          "03203866866",
          //68 : 20/12/2016 Taxi Trung Thanh HP
          "0313959595",
          //69 : 22/12/2016 Taxi Ba Sao Thai Nguyen
          "02803656565",
          //70 : 23/12/2016 Taxi Phù Đổng Ninh Bình
          "0303887799",
          //71 : 27/12/2016 Taxi Futa Vung Tau
          "06438383838",
          //72 : 30/12/2016 Taxi Cường Thịnh HN
          "0436789789",
          //73 : 30/12/2016 Taxi Vạn Xuân HN
          "0438222888",
          //74 : 5/1/2016 Taxi hoàng xa nam định
          "03503222888",
          //75 : 12/1/2016 Taxi Phù Đổng HN
          "0462666666",
          //76 : 17/1/2016 Taxi Trường Sơn Quảng Nam
          "05103959595",
          //77 : 15/2/2017 Taxi Nam Dương Phú Thọ
          "02103668866",
          //78 : 22/2/2017 Taxi Phú Bình mạo Khê
          "02033855855"
      };

        private static string[] ListCongTy = new string[]
      {
          //0
          "Triệu Quốc Đạt",
          //1
          "Sơn Tây",
          //2 
          "Linh Anh", 
          //3
          "Xuân Thành Hà Nội",
          //4
          "Tiên Sa - Đà Nẵng ",
          //5
          "Yên Bái",
          //6
          "Khải Oanh",
          //7 : 22_07_2014
          "Lạng Sơn",
          //8 : 22_07_2014
          "SH",
          //9 : 24_07_2014
          "Vina Taxi",
          //10 : 24_07_2014
          "Hà Nội Mới",
          //11 : 24_07_2014
          "Tiên Sa - Quảng Bình",
          //12 : 26_08_2014
          "Sông Lam",
          //13 : 26_08_2014
          "Vạn Xuân Nghệ An",
          //14 : 22_09_2014 Thử
          "ABC",
          //15 : 15_10_2014 Thử
          "Tiên Sa Huế",
          //16 : 22_10_2014 Thử
          "Taxi Nam Cường",
          //17
          "Taxi Việt Way",
          //18
          "Taxi Ba Sao",
          //19
          "Taxi Phiệt Học",
          //20
          "Taxi Phú Bình Uông Bí",
          //21 : 31/12/2014
          "Thành Công - Huế",
          //22 : 13/2/2015
          "Taxi Bình An",
          //23 : 13/5/2015
          "Taxi Hà Đông",
          //24 : 15/5/2015
          "Taxi Sao HN BN",
          //25 : 20/5/2015
          "Taxi Hoàng Thắng",
          //26 : 25/5/2015
          "Taxi Phú Bình - Bãi Cháy",
          //27 : 8/6/2015
          "Taxi Rồng Vàng",
          //28 : 23/06/2015
          "Taxi Sao HN",
          //29 : 26/06/2015
          "Taxi Thanh Nga",
          //30 : 06/07/2015
          "Taxi VIC",
          //31 : 13/07/2015
          "Taxi Mỹ Đình",
          //32 : 13/07/2015
          "Taxi Sông Đà",
          //33 : 15/07/2015
          "Taxi Vạn Xuân HN",
          //34 : 17/07/2015
          "Taxi Minh Giang",
          //35 : 18/07/2015
          "Taxi Sài Gòn",
          //36 : 28/07/2015
          "Taxi VIC Bắc Ninh",
          //37 : 25/07/2015
          "Taxi Quê Lụa",
          //38 : 30/07/2015
          "Taxi Sao Thủ Đô",
          //39 : 4/08/2015--Update Bat So T4
          "Taxi Hoàng Hà",
          //40 : 12/08/2015--Update Staxi
          "Taxi Mạnh Huyền",
          //41 : 28/08/2015--EnVangVIP
          "Én Vàng VIP",
          //42 : 1/09/2015--Taxi Ngọc Lan - Vĩnh Phúc 518
          "Taxi Ngọc Lan",
          //43 : 16/09/2015--Taxi Bắc Trung Nam 415
          "Taxi Bắc Trung Nam",
          //44 : 18/09/2015--Taxi Thành Lợi ND 9142
          "Taxi Thành Lợi Hà Nam",
          //45 : 21/09/2015--Taxi Cường Thịnh 768
          "Taxi Cường Thịnh",
          //46 : 2/10/2015--Taxi Đăng Quang - Phú Quốc 9258
          "Taxi Đăng Quang - Phú Quốc",
          //47 : 9/11/2015--Taxi Phương Trang - Sài Gòn 
          "Taxi Phương Trang",
          //48 : 15/12/2015--Taxi 123 - Sóc Sơn
          "Taxi 123",
          //49 : 07/1/2016--Taxi Thành Công HN
          "Taxi Thành Công HN",
          //50 : 07/1/2016--Taxi Thành Công Vĩnh Phúc
          "02116575757",
          //51 : 07/1/2016--Taxi Thành Công Hà Nam
          "Taxi Thành Công",
          //52 : 23/2/2016--Taxi Quyết Tiến Daklak
          "Taxi Quyết Tiến",
          //53 : 14/04/2016 -- Taxi Gruop
          "Taxi Gruop",
          //54 : 16/05/2016 -- Taxi Long Biên
          "Taxi Long Biên",
           //55 : 20/06/2016 -- Taxi Thành Đông
          "Taxi Thành Đông",
          //56 : 29/06/2016 -- Taxi Song Nhue
          "Taxi Sông Nhuệ",
          //57 : 11/08/2016 -- Taxi Hội Lim Bắc Ninh
          "Taxi Hội Lim",
          //58 : 12/08/2016 -- Taxi Group Bắc Ninh
          "Taxi Group Bắc Ninh",
          //59 : 13/08/2016 -- Taxi Nguyễn Gia Đồ Sơn Hải Phòng
          "Taxi Nguyễn Gia",
          //60 : 5/9/2016 -- Taxi Thành Công Hạ Long
          "Taxi Thành Công Hạ Long",
          //61 : 7/9/2016
          "Taxi EG",
          //62 : 20/9/2016 TAXI OLYMPIC Hưng Yên
          "TAXI OLYMPIC",
          //63 : 5/10/2016 Taxi ABC
          "‎Taxi ABC",
          //64 : 1/11/2016 Taxi Đồng Đội: 0253767767
          "Taxi Đồng Đội",
          //65 : 1/11/2016 Taxi Lạng Sơn 0253877877
          "Taxi Lạng Sơn",
          //66 : 23/11/2016 Taxi Vạn An Hải Phòng
          "Vạn An",
          //67 : 07/12/2016 Taxi Rồng Vàng
          "Taxi",
          //68 : 20/12/2016 Taxi Trung Thanh HP
          "Taxi được cấp phép",
          //69 : 22/12/2016 Taxi Ba Sao Thai Nguyen
          "Taxi được cấp phép",
          //70 : 23/12/2016 Taxi Phù Đổng Ninh Bình
          "Taxi được cấp phép",
          //71 : 27/12/2016 Taxi Futa Vung Tau
          "Taxi được cấp phép",
          //72 : 30/12/2016 Taxi Cường Thịnh HN
          "Taxi được cấp phép",
          //73 : 30/12/2016 Taxi Vạn Xuân HN
          "Taxi được cấp phép",
          //74 : 5/1/2016 Taxi hoàng xa nam định
          "Taxi được cấp phép",
          //75 : 12/1/2016 Taxi Phù Đổng HN
          "Taxi được cấp phép",
          //76 : 17/1/2016 Taxi Trường Sơn Quảng Nam
          "Taxi được cấp phép",
          //77 : 15/2/2017 Taxi Nam Dương Phú Thọ
          "Taxi được cấp phép",
          //78 : 22/2/2017 Taxi Phú Bình mạo Khê
          "‎Taxi được cấp phép"
      };

        public static void CheckThongTinSDTCongTy(string sdtCty)
        {
            try
            {
                if (!ListSDT[idxCompany].Equals(sdtCty) && !Debugger.IsAttached)
                {
                    MessageBox.Show(string.Format("Không thuộc {0}. Vui lòng liên hệ nhà cung cấp", ListCongTy[idxCompany]));
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show(string.Format("Lỗi cấu hình license"));
                Application.Exit();
            }
        }
    }
    public static class CompanyCode
    {
        public const int SaoHaNoi = 28;
        public const int SongNhue = 56;
        public const int ThanhCong = 49;
    }
}
