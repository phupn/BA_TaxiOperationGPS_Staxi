using System;
using System.Web.Services;
using System.ComponentModel;
using APIServices.BL;
using System.Data;
using APIServices.DAL;
using System.Web.Services.Protocols;
using APIServices.Entities;
using System.Web.Configuration;

namespace APIServices
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class APIServices : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
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
        /// <param name="isBAMap">map binh anh</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu SHXe-KhoangCach-KD-VD-TrangThai : 1232-1.2-20.9868345082291-105.867611181313-0,3253-1.4-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_DiaChi(string diaChi, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe)
        {
            int intMaLoi = 0;
            double KD = 0;
            double VD = 0;
            string[] arrGEO;
            string strGEO = "";
            if (isBAMap)
            {
                strGEO = GetGeobyAddressBA(diaChi);
            }
            else
            {
                strGEO = GetAddressByAddressGeobiz(diaChi);
            }

            if (strGEO.Equals("*"))
            {
                intMaLoi = 1;//Lỗi Service lấy tạo độ (mất kết nối,...).
            }

            if (!string.IsNullOrEmpty(strGEO))
            {

                arrGEO = strGEO.Split(' ');
                if (arrGEO.Length > 1)
                {
                    VD = Convert.ToDouble(arrGEO[0].Trim());
                    KD = Convert.ToDouble(arrGEO[1].Trim());
                }
                else
                {
                    intMaLoi = 2;//Lỗi không lấy được tạo độ
                }
            }
            else
            {
                intMaLoi = 2;//Lỗi không lấy được tạo độ
            }
            if (VD == 0 || KD == 0)
            {
                intMaLoi = 2;//Lỗi không lấy được tạo độ
            }
            if (intMaLoi == 0)
            {
                //return 5 : Lỗi không lấy được dữ liệu
                return new APIServicesBL().LayDanhSachXeDeCu(KD, VD, maXN, loaiXe, banKinhGioiHan, soLuongXe);
            }
            else
            {
                return intMaLoi.ToString();
            }
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
        ///<param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="isBAMap">map binh anh</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu SHXe-KhoangCach-KD-VD-TrangThai : 1232-1.2-20.9868345082291-105.867611181313-0,3253-1.4-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_ToaDo(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe)
        {
            //int intMaLoi = 0;
            //if (VD == 0 || KD == 0)
            //{
            //    intMaLoi = 2;//Lỗi không lấy được tạo độ
            //}

            //if (intMaLoi == 0)
            //{
            //return 5 : Lỗi không lấy được dữ liệu
            return new APIServicesBL().LayDanhSachXeDeCu(KD, VD, maXN, loaiXe, banKinhGioiHan, soLuongXe);
            //}
            //else
            //{
            //    return intMaLoi.ToString();
            //}
        }

        /// <summary>
        /// Lấy tọa độ của xe nhận
        /// </summary>
        /// <param name="KD"></param>
        /// <param name="VD"></param>
        /// <param name="maXN"></param>
        /// <param name="SoHieuXe"></param>
        /// <returns>SHXe-KhoangCach-KD-VD-TrangThai</returns>
        [WebMethod]
        public string LayToaDoXeNhan(double KD, double VD, string maXN, string SoHieuXe)
        {
            return new APIServicesBL().LayToaDoXeNhan(KD, VD, maXN, SoHieuXe);
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
                using (BAGis.gis BAgis = new BAGis.gis())
                {
                    BAGis.GSAuthenticationHeader auth = new BAGis.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGis.GSAddresResult rs = BAgis.GetGeoByName2(address, "vn");
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
        /// cau truc dia chi : 12,nguyen trai,Thanh xuân, ha noi
        /// </summary>
        /// <param name="address"></param>
        /// <returns>"20.9868345082291 105.867611181313"</returns>
        [WebMethod]
        public string GetGeobyAddressBA3(string address)
        {
            string result;
            try
            {
                using (BAGis.gis BAgis = new BAGis.gis())
                {
                    BAGis.GSAuthenticationHeader auth = new BAGis.GSAuthenticationHeader();
                    auth.Username = "gps";
                    auth.Password = "binhanh";
                    BAgis.GSAuthenticationHeaderValue = auth;
                    BAGis.GSAddresResult rs = BAgis.GetGeoByName3(address, "vn");
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
        /// cau truc dia chi : 12,nguyen trai, ha noi
        /// </summary>
        /// <param name="address"></param>
        /// <returns>"20.9868345082291 105.867611181313"</returns>

        [WebMethod]
        private string GetAddressByAddressGeobiz(string address)
        {
            string result;
            string number = null;
            string street = null;
            string city = null;
            string[] arrVar;
            arrVar = address.Split(',');
            try
            {
                if (arrVar.Length > 2)
                {
                    number = arrVar[0].Trim();
                    street = arrVar[1].Trim();
                    city = arrVar[2].Trim();
                }
                RouteService geo = new RouteService();
                result = geo.doTestGeocoderByAddress(number, street, city, GetRandomPasswordUsingGUID(5));
                return result;
            }
            catch (Exception ex)
            {
                return "*";
            }
        }

        private static string GetRandomPasswordUsingGUID(int length)
        {
            string guidResult = Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty);
            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
            return guidResult.Substring(0, length);
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
        ///<param name="banKinhGioiHan">trong vòng bán kính giới hạn (bán kính từ khách tới xe) 3000 m</param>
        /// <param name="isBAMap">map binh anh</param>
        /// <param name="soLuongXe">giới hạn số xe trả về. MẶC ĐỊNH là 5 xe </param>
        /// <returns>mẫu SHXe-KhoangCach-KD-VD-TrangThai : 1232-1.2-20.9868345082291-105.867611181313-0,3253-1.4-20.9868345082291-105.867611181313-0</returns>
        /// <remarks>
        /// 1 : Lỗi Service lấy tạo độ (mất kết nối,...)
        /// 2 : Lỗi không lấy được tọa độ
        /// 5 : Lỗi không lấy được dữ liệu
        /// </remarks>
        [WebMethod]
        public string LayDanhSachXeDeCu_ToaDo_CalGEO(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe)
        {
            float KDMin = 0, VDMin = 0, KDMax = 0, VDMax = 0;
            float[] arrKD = new float[2];
            float[] arrVD = new float[2];
            arrKD = tinhtoanDiemLanCanKinhDo((float)KD, banKinhGioiHan);
            arrVD = tinhtoanDiemLanCanKinhDo((float)VD, banKinhGioiHan);
            KDMax = (arrKD[0] > arrKD[1]) ? arrKD[0] : arrKD[1];
            KDMin = (arrKD[0] > arrKD[1]) ? arrKD[1] : arrKD[0];
            VDMax = (arrVD[0] > arrVD[1]) ? arrVD[0] : arrVD[1];
            VDMin = (arrVD[0] > arrVD[1]) ? arrVD[1] : arrVD[0];
            return new APIServicesBL().LayDanhSachXeDeCu2_CalGEO(KDMin, VDMin, KDMax, VDMax, maXN, loaiXe, soLuongXe);

        }
        
        #region LAY XE TOI DIEM
        /// <summary>
        /// Congnt
        /// Ham tra ve ds cac xe toi diem cuar moi cuoc goi
        /// 
        /// </summary>
        /// <param name="dsCuocGoi">DS cac cuoc goi : IDCuocGoi;KinhDo;ViDo;DSXeNhan#IDCuocGoi;KinhDo;ViDo;DSXeNhan
        ///                         Vi du : 190;105.010254;21.902343;4320.9890.4578#198;105.010254;21.902343;1209.8900.2578
        /// </param>
        /// <param name="banKinhGioiHan">met , 50</param>
        /// <returns> IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach#IDCuocGoi;XeNhan-KhoangCach,XeNhan-KhoangCach
        /// vd :      190;4320-43,4578-43#105;1209-12,8900-30
        /// </returns>
        [WebMethod]
        public string LayDanhSachXeToiDiem(string cuocCanKiemTraXeToiDiems, int soGiayGioiHanCoTinHieu, string maCungXNs, int banKinhGioiHan)
        {
            return new APIServicesBL().GetDSToiDiem(cuocCanKiemTraXeToiDiems, soGiayGioiHanCoTinHieu, maCungXNs, banKinhGioiHan);
        }
        #endregion

        /// <summary>
        /// Hàm trả về ds xe tới điểm đón khách
        /// </summary>
        /// <param name="cuocCanKiemTraXeToiDiemDonKhachs">Ds cuocj gọi có xe nhận, 
        /// IDCuocGoi;KinhDo;ViDo;DSXeNhan#IDCuocGoi;KinhDo;ViDo;DSXeNhan
        ///                         Vi du : 190;105.010254;21.902343;4320.9890.4578#198;105.010254;21.902343;1209.8900.2578
        /// </param>
        /// <param name="soGiayGioiHanCoTinHieu">số giây giới hạn kiểm tra</param>
        /// <param name="maCungXNs">ds công ty</param>
        /// <returns></returns>

        [WebMethod]
        public string LayDanhSachXeToiDiemDonDuocKhach(string cuocCanKiemTraXeToiDiemDonKhachs, int soGiayGioiHanCoTinHieu, string maCungXNs)
        {
            return new BL.APIServicesBL().GetDSToiDiemDaDonKhach(cuocCanKiemTraXeToiDiemDonKhachs, soGiayGioiHanCoTinHieu, maCungXNs);
        }
        
        static float[] tinhtoanDiemLanCanKinhDo(float kd, int kc)
        {
            float[] arrkq = new float[2];
            const double const_do = 0.000001;
            const double kc_met = 0.13441;// 0.55;
            float con_kd = (float)(kc * const_do / kc_met);
            arrkq[0] = kd + con_kd;
            arrkq[1] = kd - con_kd;
            return arrkq;
        }

        static float[] tinhtoanDiemLanCanViDo(float vd, int kc)
        {
            float[] arrkq = new float[2];
            const double const_do = 0.000001;
            const double kc_met = 0.12688;// 0.94;
            float con_kd = (float)(kc * const_do / kc_met);
            arrkq[0] = vd + con_kd;
            arrkq[1] = vd - con_kd;
            return arrkq;
        }
        [WebMethod]
        public DataTable GetViTriOnline(DateTime TGLayGuLieuTruoc)
        {
            return new APIServicesDAL().GetViTriOnline_TGCapNhat(TGLayGuLieuTruoc);
        }

        [WebMethod]
        public DataTable GetViTriOnline_MaXN_TGCapNhat(DateTime TGLayGuLieuTruoc, string MaXN)
        {
            return new APIServicesDAL().GetViTriOnline_MaXN_TGCapNhat(TGLayGuLieuTruoc, MaXN);
        }

        [WebMethod]
        public DataTable GetViTriOnline_Paging(DateTime TGLayGuLieuTruoc, int pageIndex)
        {
            return new APIServicesDAL().GetViTriOnline_TGCapNhat_Paging(TGLayGuLieuTruoc, pageIndex);
        }

        [WebMethod]
        public DataTable GetViTriOnline_TGCapNhat_MaXN_Paging(DateTime TGLayGuLieuTruoc, int pageIndex, string MaXN)
        {
            return new APIServicesDAL().GetViTriOnline_TGCapNhat_MaXN_Paging(TGLayGuLieuTruoc, pageIndex, MaXN);
        }

        [WebMethod]
        public DataTable GetAllVehicles()
        {
            return new APIServicesDAL().GetAllVehicles();
        }

        [WebMethod]
        public DataTable GetAllVehicles_MaXN(string MaXN)
        {
            return new APIServicesDAL().GetAllVehicles_MaXN(MaXN);
        }
                
        [WebMethod]
        public DataTable GetVehicleInfo(string MaXN, string BienSoXe)
        {
            return new APIServicesDAL().GetVehicles_BienSoXe(MaXN, BienSoXe);
        }

        #region License
        
        public Authentication auth = null;
        private bool CheckAuth()
        {
            try
            {
                string user = WebConfigurationManager.AppSettings["user"];
                string pass = WebConfigurationManager.AppSettings["pass"];
                if (auth == null || auth.UserName != user || auth.Password != pass)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        [SoapHeader("auth")]
        public LicenseEntity GetLicense(string RequestKey)
        {
            //RequestKey là số điện thoại của hãng. hoặc mã XN
            LicenseEntity objLicense = new LicenseEntity();
            try
            {
                if (CheckAuth())
                {
                    
                }

                return objLicense;
            }
            catch (Exception ex)
            {
                return objLicense;
            }
        }
        #endregion
    }
}
