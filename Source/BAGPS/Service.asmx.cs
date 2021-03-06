using System;
using System.Web.Services;
using System.ComponentModel;
using BAGPS.APIServices;

namespace BAGPS
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Service : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// cau truc dia chi : 12,nguyen trai, ha noi
        /// </summary>
        /// <param name="address"></param>
        /// <returns>"20.9868345082291 105.867611181313"</returns>
        [WebMethod]
        public string GetGeobyAddressBA(string address)
        {
            string result;
            try
            {
                using (BAGPS.gis BAgis = new BAGPS.gis())
                {
                    BAGPS.GSAuthenticationHeader auth = new BAGPS.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGPS.GSAddressResult rs = BAgis.GetGeoByName2(address, "vn");
                    result = String.Format("{0} {1}", rs.Lat, rs.Lng);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        /// <summary>
        /// cau truc dia chi : 12,nguyen trai,thanh xuân, ha noi
        /// </summary>
        /// <param name="address"></param>
        /// <returns>"20.9868345082291 105.867611181313"</returns>
        [WebMethod]
        public string GetGeobyAddressBA3(string address)
        {
            string result;
            try
            {
                using (BAGPS.gis BAgis = new BAGPS.gis())
                {
                    BAGPS.GSAuthenticationHeader auth = new BAGPS.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGPS.GSAddressResult rs = BAgis.GetGeoByName3(address, "vn");
                    result = String.Format("{0} {1}", rs.Lat, rs.Lng);
                    return result.Replace(",",".");
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        [WebMethod]
        public string GetGeobyAddressBA_HN(string address)
        {
            string result;
            try
            {
                using (BAGPS.gis BAgis = new BAGPS.gis())
                {
                    BAGPS.GSAuthenticationHeader auth = new BAGPS.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGPS.GSAddressResult rs = BAgis.GetGeoByNameHaNoi(address, "vn");
                    result = String.Format("{0} {1}", rs.Lat, rs.Lng);
                    return result.Replace(",", ".");
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        /// <summary>
        /// Lay dia chi theo tao do
        /// </summary>
        /// <param name="address"></param>
        /// <returns>"20.9868345082291 105.867611181313"</returns>
        [WebMethod]
        public string GetAddressByGeo(float lat, float lng)
        {
            string result;
            try
            {
                using (BAGPS.gis BAgis = new BAGPS.gis())
                {
                    BAGPS.GSAuthenticationHeader auth = new BAGPS.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGPS.GSAddressResult rs = BAgis.GetAddressByGeo(lng, lat, "vn");

                    result = String.Format("{0},{1},{2}", rs.Road, rs.District, rs.Province);
                    if (rs.Building > 0)
                        result = string.Format("{0},{1}",rs.Building, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        /// <summary>
        /// Lấy tọa độ của xe nhận
        /// </summary>
        /// <param name="KD"></param>
        /// <param name="VD"></param>
        /// <param name="maXN"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns>KD VD KhoangCach TrangThaiXe</returns>
        [WebMethod]
        public string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe)
        {
            return new APIServices.APIServices().LayToaDoXeNhan(KD, VD, maXN, SoHieuXe);
        }

        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// Hàm sẽ gọi services để lấy ra ds xe đề cử.
        ///       
        /// </summary>
        /// 
        /// <param name="KD">Kinh do</param>
        /// <param name="VD">Vi do</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="isBAMap">Co phai ban do BinhAnh ko</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu BSXe_KhoangCach_KD_VD_MaLoi : 1232-(1.2)-20.9868345082291-105.867611181313-0,3253-(1.4)-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap,int soLuongXe)
        {
            try
            {
                if (VD == 0 || KD == 0)
                {
                    return "2";
                }
                //return 5 : Lỗi không lấy được dữ liệu
                return new APIServices.APIServices().LayDanhSachXeDeCu_ToaDo(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }

        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// Hàm sẽ gọi services để lấy ra ds xe đề cử.
        ///       
        /// </summary>
        /// 
        /// <param name="diaChi">địa chỉ phía ĐiênThoại nhập - địa chỉ khách gọi</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="isBAMap">Co phai ban do BinhAnh ko</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu BSXe_KhoangCach_KD_VD_MaLoi : 1232-(1.2)-20.9868345082291-105.867611181313-0,3253-(1.4)-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_DiaChi(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe)
        {
            try
            {
                string toaDo = GetGeobyAddressBA(diaChi);
                if (toaDo.Equals("*") || toaDo == string.Empty)
                {
                    return "1";//Lỗi Service lấy tạo độ (mất kết nối,...).
                }
                else
                {
                    string[] arrString = toaDo.Split(' ');
                    double VD = Convert.ToDouble(arrString[0]);
                    double KD = Convert.ToDouble(arrString[1]);
                    return new APIServices.APIServices().LayDanhSachXeDeCu_ToaDo(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
                }
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }


        /// <summary>
        /// hàm thực hiện lấy ra ds xe đề cử.
        /// Hàm sẽ gọi services để lấy ra ds xe đề cử.
        ///       
        /// </summary>
        /// 
        /// <param name="diaChi">địa chỉ phía ĐiênThoại nhập - địa chỉ khách gọi(2,nguyen trai, thanh xuan, ha noi)</param>
        /// <param name="maXN"> thông mã xí nghiệp trên hệ thống GPS </param>
        /// <param name="loaiXe">loại xe, chuyển đổi về loại xe tương ứng của GPS, (KIA, VIO, INO, LIMO). KHong chọn là tất cả </param>
        /// <param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="isBAMap">Co phai ban do BinhAnh ko</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu BSXe_KhoangCach_KD_VD_MaLoi : 1232-(1.2)-20.9868345082291-105.867611181313-0,3253-(1.4)-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_DiaChi3(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe)
        {
            try
            {
                string toaDo = GetGeobyAddressBA3(diaChi);
                if (toaDo.Equals("*") || toaDo == string.Empty)
                {
                    return "1";//Lỗi Service lấy tạo độ (mất kết nối,...).
                }
                else
                {
                    string[] arrString = toaDo.Split(' ');
                    double VD = Convert.ToDouble(arrString[0]);
                    double KD = Convert.ToDouble(arrString[1]);
                    return new APIServices.APIServices().LayDanhSachXeDeCu_ToaDo(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe);
                }
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }

        #region LAY XE TOI DIEM
        /// <summary>
        /// Congnt
        /// Ham tra ve ds cac xe toi diem cuar moi cuoc goi
        /// 
        /// </summary>
        /// <param name="dsCuocGoi">DS cac cuoc goi : IDCuocGoi;KinhDo;ViDo;DSXeNhan#IDCuocGoi;KinhDo;ViDo;DSXeNhan#
        ///                         Vi du : 190;105.010254;21.902343;4320.9890.4578#198;105.010254;21.902343;1209.8900.2578
        /// </param>
        /// <param name="banKinhGioiHan">met , 50</param>
        /// <returns> IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach#IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach#
        /// vd :      190;4320-43,4578-43#105;1209-12,8900-30
        /// </returns>
        [WebMethod]
        public string LayDanhSachXeToiDiem(string cuocCanKiemTraXeToiDiems, int soGiayGioiHanCoTinHieu, string maCungXNs, int banKinhGioiHan)
        {
            return new APIServices.APIServices().LayDanhSachXeToiDiem(cuocCanKiemTraXeToiDiems, soGiayGioiHanCoTinHieu, maCungXNs, banKinhGioiHan);
        }

        [WebMethod]
        public string LayDanhSachXeToiDiemDonDuocKhach(string cuocCanKiemTraXeToiDiemDonKhachs, int soGiayGioiHanCoTinHieu, string maCungXNs)
        {
            return new APIServices.APIServices().LayDanhSachXeToiDiemDonDuocKhach(cuocCanKiemTraXeToiDiemDonKhachs, soGiayGioiHanCoTinHieu, maCungXNs);
        }
        #endregion 

        [WebMethod]
        public System.Data.DataTable GetViTriOnline(DateTime TGLayGuLieuTruoc)
        {
            TGLayGuLieuTruoc = DateTime.Now;
            return new APIServices.APIServices().GetViTriOnline(TGLayGuLieuTruoc);
        }

        [WebMethod]
        public LicenseEntity GetLicense(string requestKey)
        {
            return BAService.GetLicense(requestKey);
        }
    }
}
