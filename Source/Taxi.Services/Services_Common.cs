#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Services.WCFServices;
using Taxi.Business;
using Taxi.Utils;
using System.Collections.Generic;
using Taxi.Services.WCFServiceGEO;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Services
{
    public static class Service_Common
    {
        #region WCF_GEO
        
        private static ConnectService<ServicesOnlineClient> _WCF_GEO = new ConnectService<ServicesOnlineClient>();
        public static ConnectService<ServicesOnlineClient> WCF_GEO
        {
            get
            {
                if (_WCF_GEO_Authen == null || _WCF_GEO_Authen.Key != "")
                {
                    _WCF_GEO_Authen = new AuthenticationHeader {
                        UserName = "BAGIS_BinhAnh",
                        PassWord = "BAGIS_BinhAnh_BAGIS_20160126",
                        Key = "BAGIS_20160126"
                    };
                }
                return _WCF_GEO;
            }
        }
        private static AuthenticationHeader _WCF_GEO_Authen;
        public static AuthenticationHeader WCF_GEO_Authen
        {
            get{return _WCF_GEO_Authen;}
        }
        #endregion

        #region Route
        /// <summary>
        /// Lấy lộ trình và giá
        /// </summary>
        /// <param name="fromLat"></param>
        /// <param name="fromLng"></param>
        /// <param name="toLat"></param>
        /// <param name="toLng"></param>
        /// <param name="compid"></param>
        /// <param name="carType"></param>
        /// <returns></returns>
        public static PriceResponse GetPrice(float fromLat, float fromLng, float toLat, float toLng, int compid, int carType)
        {
            return WCF_GEO.TryGet(p => p.GetPrice_FromTwoLocation(fromLat, fromLng, toLat, toLng, compid, carType)).Value;
        }
        #endregion

        #region BAGIS
        //private static BAGPS.ServiceSoapClient _ServiceSoapClient;

        //public static BAGPS.ServiceSoapClient ServiceSoapClient
        //{
        //    get
        //    {
        //        if (_ServiceSoapClient == null ||
        //            _ServiceSoapClient.State == System.ServiceModel.CommunicationState.Faulted)
        //        {
        //            _ServiceSoapClient = new BAGPS.ServiceSoapClient();
        //        }
        //        else if (_ServiceSoapClient.State == System.ServiceModel.CommunicationState.Closed)
        //        {
        //            _ServiceSoapClient.Open();
        //        }
        //        return _ServiceSoapClient;
        //    }
        //    set { _ServiceSoapClient = value; }
        //}

        /// <summary>
        /// Service Get dia chi uu tien Ha Noi
        /// </summary>
        public static string GetGeobyAddress(string address, string TenTinh)
        {
            try
            {
                if (Config_Common.GEOService == EnumGEOService.Google)
                    return WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(WCF_GEO_Authen, address, TenTinh)).Value;
                    //return WCFService_Common.GetGeoByAddress_Google(address, TenTinh);
                else if (Config_Common.GEOService == EnumGEOService.BinhAnh)
                {
                    if (TenTinh.ToLower().Equals("hà nội") || TenTinh.ToLower().Equals("ha noi"))
                        return WCF_GEO.TryGet(p => p.GetGeobyAddressBA_HN_First(WCF_GEO_Authen, address, TenTinh)).Value;
                        //return ServiceSoapClient.GetGeobyAddressBA_HN(String.Format("{0},{1}", address, TenTinh));
                    else
                        return WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, TenTinh)).Value;
                        //return ServiceSoapClient.GetGeobyAddressBA3(String.Format("{0},{1}", address, TenTinh));
                }
                else
                {
                    string AddressReturn = "";

                    if (TenTinh.ToLower().Equals("hà nội") || TenTinh.ToLower().Equals("ha noi"))
                        AddressReturn = WCF_GEO.TryGet(p => p.GetGeobyAddressBA_HN_First(WCF_GEO_Authen, address, TenTinh)).Value;
                        //AddressReturn = ServiceSoapClient.GetGeobyAddressBA_HN(String.Format("{0},{1}", address, TenTinh));
                    else
                        AddressReturn = WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, TenTinh)).Value;
                        //AddressReturn = ServiceSoapClient.GetGeobyAddressBA3(String.Format("{0},{1}", address, TenTinh));

                    if (AddressReturn == "" || AddressReturn == "*")
                    {
                        AddressReturn = WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(WCF_GEO_Authen, address, TenTinh)).Value;
                        //AddressReturn = WCFService_Common.GetGeoByAddress_Google(address, TenTinh);
                    }
                    return AddressReturn;
                }
            }
            catch
            {
                return "*";
            }
        }
        
        public static string GetGeobyAddressV2(string address)
        {
            try
            {
                if (Config_Common.GEOService == EnumGEOService.Google)
                    return WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(WCF_GEO_Authen, address, ThongTinCauHinh.GPS_TenTinh)).Value;
                    //return WCFService_Common.GetGeoByAddress_Google(address,ThongTinCauHinh.GPS_TenTinh);
                else
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, ThongTinCauHinh.GPS_TenTinh)).Value;
                    //return ServiceSoapClient.GetGeobyAddressBA3(address);
            }
            catch
            {
                return "*";
            }
        }

        public static string GetGeobyAddressV2_Full(string address)
        {
            try
            {
                if (Config_Common.GEOService == EnumGEOService.Google)
                    return WCF_GEO.TryGet(p => p.GetGeoByAddress_GoogleV2(WCF_GEO_Authen, address)).Value;
                else
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA_Full(WCF_GEO_Authen, address)).Value;
            }
            catch
            {
                return "*";
            }
        }
        public static string GetGeobyAddressV2_Gooogle_Full(string address)
        {
            try
            {
                return WCF_GEO.TryGet(p => p.GetGeoByAddress_GoogleV2(WCF_GEO_Authen, address)).Value;
            }
            catch
            {
                return "*";
            }
        }
        public static string GetGeobyAddressV2_NotProvince(string address)
        {
            try
            {
                if (Config_Common.GEOService == EnumGEOService.Google)
                    return WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(WCF_GEO_Authen, address, ThongTinCauHinh.GPS_TenTinh)).Value;
                //return WCFService_Common.GetGeoByAddress_Google(address,ThongTinCauHinh.GPS_TenTinh);
                else
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, ThongTinCauHinh.GPS_TenTinh)).Value;
                //return ServiceSoapClient.GetGeobyAddressBA3(address);
            }
            catch
            {
                return "*";
            }
        }

        /// <param name="isServiceGoogle">True: Google; false: Binh Anh</param>
        /// <returns></returns>
        public static string GetGeobyAddressV3(string tenTinh,string address, bool isServiceGoogle)
        {
            try
            {
                if (isServiceGoogle )
                    return WCF_GEO.TryGet(p => p.GetGeoByAddress_Google(WCF_GEO_Authen, address,tenTinh)).Value;
                else
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, tenTinh)).Value;
            }
            catch
            {
                return "*";
            }
        }
       
        public static string GetGeobyAddressBA_Vinhomes_First(float lat, float lng)
        {
            try
            {
                BAGIS.GSAuthenticationHeader auth = new BAGIS.GSAuthenticationHeader();
                auth.Username = "gps";
                auth.Password = "binhanh";

                BAGIS.GSPOIResult result = new BAGIS.gisSoapClient().GetGeoByPOIVinhome(auth, lat, lng, "vn");
                if (result != null)
                    return result.Name;
                else return "";
            }
            catch
            {
                return "*";
            }
        }

        public static string GetAddressByGeoBA(float lat, float lng)
        {
            try
            {
                string strbuilding = "";
                if (lat <= 0 || lng <= 0) return "";
                if (Config_Common.GEOService == EnumGEOService.Google)
                    return WCF_GEO.TryGet(p => p.GetAddressByGeo_Google(WCF_GEO_Authen, lng, lat)).Value;                    
                    //return WCFService_Common.GetAddressByGeo_Google(lat, lng);
                else
                    return WCF_GEO.TryGet(p => p.GetAddressByGeo(out strbuilding, WCF_GEO_Authen, lng, lat)).Value;
                    //return ServiceSoapClient.GetAddressByGeo(lat, lng);

            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Get dia chi, ham google co tra ve so nha
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="building"></param>
        /// <returns></returns>
        public static string GetAddressByGeo_BA_WithBuilding(float lat, float lng,out string building)
        {
            string strbuilding = ""; 
            building = "";
            try
            {
                if (lat <= 0 || lng <= 0) return "";
                if (Config_Common.GEOService == EnumGEOService.Google)
                {
                    string value = WCF_GEO.TryGet(p => p.GetAddressByGeo_Google_WithBuilding(out strbuilding, WCF_GEO_Authen, lng, lat)).Value;
                    building = strbuilding;
                    return value;
                }
                //return WCFService_Common.GetAddressByGeo_Google(lat, lng);
                else
                {
                    string value = WCF_GEO.TryGet(p => p.GetAddressByGeo(out strbuilding, WCF_GEO_Authen, lng, lat)).Value;
                    building = strbuilding;
                    return value;
                }
                //return ServiceSoapClient.GetAddressByGeo(lat, lng);

            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="isService">True = google, false = BA</param>
        /// <returns></returns>
        public static string GetAddressByGeoBAV2(float lat, float lng, bool isService)
        {
            try
            {
                string strbuilding = "";
                if (lat <= 0 || lng <= 0) return "";
                if (isService)
                    return WCF_GEO.TryGet(p => p.GetAddressByGeo_Google(WCF_GEO_Authen, lng, lat)).Value;
                //return WCFService_Common.GetAddressByGeo_Google(lat, lng);
                else
                    return WCF_GEO.TryGet(p => p.GetAddressByGeo(out strbuilding, WCF_GEO_Authen, lng, lat)).Value;
                //return ServiceSoapClient.GetAddressByGeo(lat, lng);

            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Service Get dia chi uu tien Ha Noi
        /// </summary>
        public static string GetGeobyAddressBA_HN_First(string address, string TenTinh)
        {
            try
            {
                string street = address;
                if (TenTinh.ToLower().Equals("hà nội") || TenTinh.ToLower().Equals("ha noi"))
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA_HN_First(WCF_GEO_Authen, address, TenTinh)).Value;
                    //return ServiceSoapClient.GetGeobyAddressBA_HN(String.Format("{0},{1}", street, TenTinh));
                else
                    return WCF_GEO.TryGet(p => p.GetGeobyAddressBA(WCF_GEO_Authen, address, TenTinh)).Value;
                    //return ServiceSoapClient.GetGeobyAddressBA3(String.Format("{0},{1}", street, TenTinh));
            }
            catch
            {
                return "*";
            }
        }
        #endregion

        #region ---------------- Common -------------------

        /// <summary>
        /// Cap nhat license online
        /// </summary>
        public static bool UpdateLicense()
        {
            try
            {
                BAGPS.LicenseEntity objLicense = new BAGPS.LicenseEntity();// ServiceSoapClient.GetLicense(ThongTinCauHinh.SoDienThoaiCongTy);
                if (objLicense.LicenseKey != "")
                {
                    return new LicenseBL().UpdateLicense(objLicense.LicenseKey, objLicense.FromDate, objLicense.ToDate);
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string CheckLicense()
        {
            try
            {
                new LicenseBL().GetLicense();

                BAGPS.LicenseEntity objLicense = new BAGPS.LicenseEntity();//ServiceSoapClient.GetLicense(ThongTinCauHinh.SoDienThoaiCongTy);
                if (objLicense.LicenseKey != "")
                {
                    if (true)
                    {

                    }
                    return string.Format("");
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region ---------------- DataClient ---------------
        private static ConnectService<Service_ServerCenter.DataClient> _ServerCenter = new ConnectService<Service_ServerCenter.DataClient>();
        /// <summary>
        /// Gets the server center.
        /// </summary>
        /// <value>
        /// The server center.
        /// </value>
        /// <Modified>
        /// Name     Date         Comments
        /// HauNV  27/08/2015   created
        /// </Modified>
        public static ConnectService<Service_ServerCenter.DataClient> ServerCenter
        {
            get
            {
                return _ServerCenter;
            }
        }
        #endregion

        #region ---------------- FastTaxi -----------------

        private static ConnectService<FastTaxi_OperationService.OperationServiceClient> _fastTaxi = new ConnectService<FastTaxi_OperationService.OperationServiceClient>();
        /// <summary>
        /// TaxiReturnService => gọi của SơnPC
        /// </summary>
        public static ConnectService<FastTaxi_OperationService.OperationServiceClient> FastTaxi
        {
            get { return _fastTaxi; }
        }
        #endregion

        #region ---------------- EnVangVip ----------------

        private static ConnectService<ServiceEnVangVip.OperationServiceClient> _EnvangVip = new ConnectService<ServiceEnVangVip.OperationServiceClient>();
       /// <summary>
       /// Gọi đến server envang.
       /// </summary>
        public static ConnectService<ServiceEnVangVip.OperationServiceClient> EnvangVip
        {
            get
            {
                return _EnvangVip;
            }
        }
        #endregion

        #region ---------------- G5 -----------------------
        private static readonly ConnectService<ServiceG5.OperationServiceClient> serviceG5 = new ConnectService<ServiceG5.OperationServiceClient>();

        public static ConnectService<ServiceG5.OperationServiceClient> ServiceG5
        {
            get
            {
                return serviceG5;
            }
        }
        #endregion

        #region ---------------- BaSao -----------------------
        //private static readonly ConnectService<ServiceBaSao.OperationServiceClient> serviceBaSao = new ConnectService<ServiceBaSao.OperationServiceClient>();

        //public static ConnectService<ServiceBaSao.OperationServiceClient> ServiceBaSao
        //{
        //    get
        //    {
        //        return serviceBaSao;
        //    }
        //}
        #endregion

        

        /// <summary>
        /// Kiem tra ket noi Service Dong Bo Xe
        /// </summary>
        public static void PingWcf()
        {
            try
            {
                WCFService_Common.WCFServiceClient.Try(p=> p.GetTimeServer());
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("PingWcf:", ex);
            }
        }
    }

    public static class StaxiManServices
    {
        private static ConnectService<StaxiMan_Services.ServiceClient> _client = new ConnectService<StaxiMan_Services.ServiceClient>();
        public static ConnectService<StaxiMan_Services.ServiceClient> Client
        {
            get
            {
                if (_client == null) _client = new ConnectService<StaxiMan_Services.ServiceClient>();
                return _client;
            }
            set { _client = value; }
        }

        /// <summary>
        /// Gửi thông tin request license key cho server
        /// </summary>
        /// <returns>
        /// return 0 :Request lỗi
        /// return -1:Không đúng tài khoản
        /// return -2:Không lưu được thông tin request
        /// return 1 : Thành Công
        /// </returns>
        public static int RequestLicenseKey(string userName, string password, string macAddress, string cPUId, string phoneNumber, string compName)
        {
            return Client.TryGet(s => s.RequestLicense(macAddress, cPUId, phoneNumber, compName, userName, password)).Value;
        }
    }
    public static class WCFService_Common
    {
        private static ConnectService<SyncServiceOnlineClient> _wcfServiceClient = new ConnectService<SyncServiceOnlineClient>();
        public static ConnectService<SyncServiceOnlineClient> WCFServiceClient
        {
            get
            {
                if (_wcfServiceClient == null) _wcfServiceClient = new ConnectService<SyncServiceOnlineClient>();
                return _wcfServiceClient;
            }
            set { _wcfServiceClient = value; }
        }

        /// <summary>
        /// Get GEO Google
        /// </summary>
        //public static string GetGeoByAddress_Google(string address, string TenTinh)
        //{
        //    return WCFServiceClient.TryGet(p => p.GetGeoByAddress_Google(address, TenTinh)).Value;
        //}

        /// <summary>
        /// Get Address by Google
        /// </summary>
        //public static string GetAddressByGeo_Google(float lat, float lng)
        //{
        //    return WCFServiceClient.TryGet(p => p.GetAddressByGeo_Google(lng, lat)).Value;
        //}

        //public static string GetGeobyAddress(string address, string TenTinh)
        //{
        //    try
        //    {
        //        if (Config_Common.GEOService == EnumGEOService.Google)
        //            return GetGeoByAddress_Google(address, TenTinh);
        //        else if (Config_Common.GEOService == EnumGEOService.BinhAnh)
        //            return Service_Common.ServiceSoapClient.GetGeobyAddressBA3(String.Format("{0},{1}", address, TenTinh));
        //        else
        //        {
        //            string AddressReturn = Service_Common.ServiceSoapClient.GetGeobyAddressBA3(String.Format("{0},{1}", address, TenTinh));
        //            if (AddressReturn == "" || AddressReturn == "*")
        //            {
        //                AddressReturn = GetGeoByAddress_Google(address, TenTinh);
        //            }
        //            return AddressReturn;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "*";
        //    }
        //}

        /// <summary>
        /// Trả về danh sách xe online
        /// </summary>
        public static T_XeOnline[] GetListObjectXeOnline()
        {
            return WCFServiceClient.TryGet(p => p.GetListObjectXeOnline(Taxi.Business.ThongTinCauHinh.GPS_MaCungXN)).Value;
        }

        /// <summary>
        /// Trả về thông tin tổng cuốc xe online
        /// </summary>
        public static TongCuoc_Ca GetTongCuoc(string BienSoXe, bool isChotCo)
        {
            return WCFServiceClient.TryGet(p => p.GetTongCuoc(ThongTinCauHinh.GPS_MaCungXN, BienSoXe, isChotCo)).Value;
        }

        /// <summary>
        /// Trả về thông tin  xe online
        /// </summary>
        public static T_XeOnline GetXeOnlineBySHX(string SoXe)
        {
            return WCFServiceClient.TryGet(p => p.GetXeOnlineBySHX(SoXe)).Value;
        }
        /// <summary>
        /// Trả về thông tin xe đón khách gần nhất
        /// </summary>
        public static T_XeOnline_TT GetXeDonKhach(string SoXe)
        {
            return WCFServiceClient.TryGet(p => p.GetXeDonKhach(SoXe)).Value;
        }

        /// <summary>
        /// Trả về danh sách xe đề cử
        /// </summary>
        public static string LayDanhSachXeDeCu_ToaDoV2(double KD, double VD, string maXN, string loaiXe, int banKinhGioiHan, bool isBAMap, int soLuongXe, System.DateTime thoiDiemGoi, long idCG, string phoneNumber, string diaChi)
        {
            return WCFServiceClient.TryGet(p => p.LayDanhSachXeDeCu_ToaDoV2(KD, VD, maXN, loaiXe, banKinhGioiHan, isBAMap, soLuongXe, thoiDiemGoi, idCG, phoneNumber, diaChi)).Value;
        }

        /// <summary>
        /// Trả về danh sách số hiệu xe - Biên số
        /// </summary>
        public static Dictionary<string, string> GetVehicles()
        {
            return WCFServiceClient.TryGet(p => p.GetVehicles()).Value;
        }

        /// <summary>
        /// Trả về danh sách số hiệu xe - Biên số
        /// </summary>
        public static void RemoveTaxiOperation(long idCG, int vung, string xeNhan, string xeDon)
        {
            //WCFServiceClient.Try(p => p.RemoveTaxiOperation(idCG, vung, xeNhan, xeDon));
        }
        
        /// <summary>
        /// Get DateTime Server
        /// </summary>
        public static DateTime GetTimeServer()
        {
            return WCFServiceClient.TryGet(p => p.GetTimeServer()).Value;
        }
        /// <summary>
        /// Kết nối lại service
        /// </summary>
        public static void RefreshWcf()
        {
            _wcfServiceClient = null;
            _wcfServiceClient = new ConnectService<SyncServiceOnlineClient>();
        }
    }

    public static class Services_TCPOP_App
    {
        private static ConnectService<Services_TCPOP.TcpOPClient> _client = new ConnectService<Services_TCPOP.TcpOPClient>();
        public static ConnectService<Services_TCPOP.TcpOPClient> Client
        {
            get
            {
                if (_client == null) _client = new ConnectService<Services_TCPOP.TcpOPClient>();
                return _client;
            }
            set { _client = value; }
        }

        /// <summary>
        /// Service Lấy thông tin giá tiền từ điểm A => B
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="companyId"></param>
        /// <param name="carType"></param>
        /// <returns></returns>
        public static Services_TCPOP.TcpOPCalPriceResponse GetPrice_FromTwoLocation(Services_TCPOP.LatLng from, Services_TCPOP.LatLng to, int companyId, int carType )
        {
            return Client.TryGet(p => p.CalPriceNew(from, to, companyId, carType)).Value;
        }
        
    }
}
