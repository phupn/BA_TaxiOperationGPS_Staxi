using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Services.Protocols;
using TaxiOperation_Services;
using TaxiOperation_Services.ServicesGEO;

namespace TaxiOperation
{
    /// <summary>
    /// Summary description for TaxiOperation_Services
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TaxiOperation_Services : WebService
    {
        DAO dao = new DAO();
        public Authentication auth = null;
        private bool CheckAuth(string domainName)
        {
            try
            {
                string user = WebConfigurationManager.AppSettings["user"];
                string pass = WebConfigurationManager.AppSettings["pass"];
                string domain = WebConfigurationManager.AppSettings["domain"];
                if (auth != null || auth.UserName == user || auth.Password == pass)
                {
                    if (domain == "" || domain == GetDomain() || 
                        domainName == "dichungtaxi.com" || 
                        domainName == "thanhcongtaxi.vn")
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("E3 : ", ex);
                return false;
            }
        }
        //[WebMethod]
        public string GetDomain()
        {
            return HttpContext.Current.Request.UserHostAddress;   //this.Context.Request.UserHostAddress
        }
        #region Service Đặt xe thành Công
        [WebMethod]
        [SoapHeader("auth")]
        public string BookingTaxi(string CustName, string Phone, string Addr, string VehType, int Qty, DateTime Time, string GhiChu, int brand, short src, string dmn)
        {
            try
            {

                if (CheckAuth(dmn))
                {
                    //Vĩnh Phúc: 117.0.37.249
                    //Taxi Thành Công: Hà Nam: 222.252.214.133
                    //Taxi Thành Công: Huế:  117.2.0.48
                    var taxi = new TaxiOperation()
                    {
                        SoDienThoai = Phone,
                        DiaChiDon = string.Format("[{0:HH:mm dd/MM}] {1}", Time, Addr)
                    };
                    //validate loại xe
                    if (VehType.Length > 0)
                    {
                        string[] arr = VehType.Split(';');
                        var lx = string.Empty;
                        foreach (string xe in arr)
                        {
                            if (xe.Length > 0)
                            {
                                lx += string.Format("{0}  chỗ;", xe);
                            }
                        }
                        taxi.LoaiXe = lx.Trim(';');
                    }
                    //check số lượng xe
                    if (Qty == null || Qty == 0)
                    {
                        Qty = 1;
                    }
                    else
                    {
                        taxi.SoLuongXe = Qty;
                    }
                    taxi.GioDon = Time;
                    taxi.TenKhachHang = CustName;
                    taxi.LenhDienThoai = VehType;
                    taxi.GhiChu = GhiChu;
                    taxi.brand = (Brand)brand;
                    taxi.Source = src;
                    string kq = "";
                    try
                    {
                        if (dao.bookTaxi(taxi) > 0)
                        {
                            kq = "1";
                        }
                        else
                        {
                            kq = "F";
                            LogError.WriteLogErrorForDebug("F : Không thành công");
                        }

                    }
                    catch (InvalidCastException ex)
                    {
                        kq = "E2";
                        LogError.WriteLogError("E2 :", ex);
                    }
                    catch (SqlException ex)
                    {
                        kq = "E1";
                        LogError.WriteLogError("E1 :", ex);
                    }
                    return kq;
                }
                else
                {
                    LogError.WriteLogErrorForDebug("E3 : Không đúng  thông tin truy cập");
                    return "E3";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("E4 : ", ex);
                return "E4";
            }
        }


        [WebMethod]
        [SoapHeader("auth")]
        public string BookingTaxi_V2(string CustName, string Phone, string Addr, string VehType, int Qty, DateTime Time,
            string description, int brand, short src, string dmn, string lat, string lng, string senderID, 
            string extension1 = "", string extension2 = "")
        {
            try
            {

                if (CheckAuth(dmn))
                {
                    //Vĩnh Phúc: 117.0.37.249
                    //Taxi Thành Công: Hà Nam: 222.252.214.133
                    //Taxi Thành Công: Huế:  117.2.0.48
                    

                    float fLat = 0;
                    float fLng = 0;
                    float.TryParse(lat.Trim(), out fLat);
                    float.TryParse(lng.Trim(), out fLng);
                    if (fLat > 0 && fLng > 0)
                    {
                        string strlocation = string.Format("{0}, {1}", lat.Trim(), lng.Trim());

                        LogError.WriteLogErrorForDebug("strlocation : " + strlocation);

                        LogError.WriteLogErrorForDebug("Addr : " + Addr);
                        if (Addr.Contains("Location") || Addr.Contains("Pinned") || (Addr.Contains(lng.Trim()) && Addr.Contains(lng.Trim())))
                        {
                            try
                            {
                                using (ServicesOnlineClient geo = new ServicesOnlineClient())
                                {
                                    var auth = new AuthenticationHeader(){                                        
                                        UserName = "BAGIS_BinhAnh",
                                        PassWord = "BAGIS_BinhAnh_BAGIS_20160126",
                                        Key = "BAGIS_20160126"
                                    };
                                    string addressLocation = geo.GetAddressByGeo(auth, fLng, fLat);
                                    if (addressLocation != "" || addressLocation != "*")
                                    {
                                        //Addr = Addr.Replace(strlocation, "");
                                        Addr = addressLocation;
                                        LogError.WriteLogErrorForDebug("Addr new: " + Addr);                                
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError.WriteLogError("GEO ERR :", ex);
                            }
                        }
                    }
                    ////validate loại xe
                    //if (VehType.Length > 0)
                    //{
                    //    string[] arr = VehType.Split(';');
                    //    var lx = string.Empty;
                    //    foreach (string xe in arr)
                    //    {
                    //        if (xe.Length > 0)
                    //        {
                    //            lx += string.Format("{0}  chỗ;", xe);
                    //        }
                    //    }
                    //    taxi.LoaiXe = lx.Trim(';');
                    //}
                    var taxi = new TaxiOperation()
                    {
                        SoDienThoai = Phone,
                        DiaChiDon = string.Format("[{0:HH:mm dd/MM}] {1}", Time, Addr)
                    };
                    taxi.LoaiXe = VehType;
                    //check số lượng xe
                    if (Qty == null || Qty == 0)
                    {
                        Qty = 1;
                    }
                    else
                    {
                        taxi.SoLuongXe = Qty;
                    }
                    taxi.GioDon = Time;
                    taxi.TenKhachHang = CustName;
                    //taxi.LenhDienThoai = VehType;
                    taxi.GhiChu = description;
                    taxi.brand = (Brand)brand;
                    taxi.Source = src;
                    taxi.Lat = fLat;
                    taxi.Lng = fLng;
                    taxi.SenderID = senderID;
                    taxi.Ext1 = extension1;
                    taxi.Ext2 = extension2;
                    string kq = "";
                    try
                    {
                        long id = dao.bookTaxi_V2(taxi);
                        if (id > 0)
                        {
                            kq = id.ToString();
                        }
                        else
                        {
                            kq = "F";
                            LogError.WriteLogErrorForDebug("F : Không thành công");
                        }

                    }
                    catch (InvalidCastException ex)
                    {
                        kq = "E2";
                        LogError.WriteLogError("E2 :", ex);
                    }
                    catch (SqlException ex)
                    {
                        kq = "E1";
                        LogError.WriteLogError("E1 :", ex);
                    }
                    return kq;
                }
                else
                {
                    LogError.WriteLogErrorForDebug("E3 : Không đúng  thông tin truy cập");
                    return "E3";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("E4 : ", ex);
                return "E4";
            }
        }

        [WebMethod]
        [SoapHeader("auth")]
        public string CancelBooking_V2(string dmn, int brand, string tickedID)
        {
            try
            {
                string kq = "";
                if (CheckAuth(dmn))
                {
                    Brand brandItem = Brand.HaNoi;
                    long ID = 0;
                    try
                    {
                        brandItem = (Brand)brand;
                        ID = long.Parse(tickedID);
                    }
                    catch (Exception ex)
                    {
                        kq = "E2";
                        LogError.WriteLogError("CancelBooking_V2 E2 :", ex);
                    }
                    if (dao.Cancel_Booking_V2(brandItem, ID))
                    {
                        kq = "1";
                    }
                    else
                    {
                        kq = "F";
                        LogError.WriteLogErrorForDebug("CancelBooking_V2 F : Không thành công");
                    }
                }
                else
                {
                    LogError.WriteLogErrorForDebug("CancelBooking_V2 E3 : Không đúng  thông tin truy cập");
                    kq = "E3";
                }
                return kq;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CancelBooking_V2 E4 : ", ex);
                return "E4";
            }
        }

        [WebMethod]
        [SoapHeader("auth")]
        public RouterItem CalDistance_Money(string dmn, int brand, int LoaiXe, string fromLat, string fromLng, string toLat, string toLng)
        {
            RouterItem item = new RouterItem();
            try
            {
                if (CheckAuth(dmn))
                {
                    Brand brandItem = Brand.HaNoi;
                    float fLat = 0;
                    float fLng = 0;
                    float tLat = 0;
                    float tLng = 0;
                    try
                    {
                        brandItem = (Brand)brand;

                        float.TryParse(fromLat.Trim(), out fLat);
                        float.TryParse(fromLng.Trim(), out fLng);
                        float.TryParse(toLat.Trim(), out tLat);
                        float.TryParse(toLng.Trim(), out tLng);
                    }
                    catch (Exception ex)
                    {
                        item.Result = "E2";
                        LogError.WriteLogError("CalDistance_Money E2 :", ex);
                    }
                    TinhToanGiaTien objCal = new TinhToanGiaTien();
                    item.Distance = objCal.CalDistance(fLat, fLng, tLat, tLng);
                    item.Monney = objCal.TinhTienBinhThuong(item.Distance, LoaiXe, brandItem);

                    if (item.Distance > 0 && item.Monney > 0)
                    {
                        item.Result = "1";
                    }
                    else
                    {
                        item.Result = "F";
                        LogError.WriteLogErrorForDebug("CalDistance_Money F : Không thành công");
                    }
                }
                else
                {
                    LogError.WriteLogErrorForDebug("CalDistance_Money E3 : Không đúng  thông tin truy cập");
                    item.Result = "E3";
                }
                return item;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("CalDistance_Money E4 : ", ex);
                item.Result = "E4";
                return item;
            }
        }

        #endregion

        #region Service MPCC
        ///// <summary>
        ///// Get tất cả cuộc gọi theo ngày
        ///// </summary>
        //[WebMethod]
        //[SoapHeader("auth")]
        //public List<CallInfo> GetCallsInfo(DateTime CallDate, string dmn)
        //{
        //    try
        //    {
        //        if (CheckAuth(dmn))
        //        {
        //            try
        //            {
        //                return dao.GetCallsInfo(CallDate);
        //            }
        //            catch (InvalidCastException ex)
        //            {
        //                LogError.WriteLogError("E2 :", ex);
        //            }
        //            catch (SqlException ex)
        //            {
        //                LogError.WriteLogError("E1 :", ex);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("E4 : ", ex);
        //    }
        //    return null;
        //}

        //[WebMethod]
        //[SoapHeader("auth")]
        //public string GetCallsInfo_Test(DateTime CallDate, string dmn)
        //{
        //    if (CheckAuth(dmn))
        //    {
        //        return "OK";
        //    }
        //    return "fail";
        //}


        #endregion
    }
}
