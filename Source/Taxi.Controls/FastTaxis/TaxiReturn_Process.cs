using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Taxi.Business;
using Taxi.Data.FastTaxi;
using Taxi.Services;
using Taxi.Services.FastTaxi_OperationService;
using Taxi.Common.Extender;
using System.Windows.Forms;
namespace Taxi.Controls.FastTaxis.TaxiChieuVe
{
    public class TaxiReturnSend
    {
        public Func<bool> func;
        public string Tree;
    }
    public static class TaxiReturn_Process
    {
        public static bool IsDebug { get; set; }
        private static bool _isKetThuc = true;
        public static bool IsKetThuc { get { return _isKetThuc; } set { _isKetThuc = value; } }

        public static ConcurrentQueue<TaxiReturnSend> queueTaxiReturnSend = new ConcurrentQueue<TaxiReturnSend>();

        public static void DoProcess()
        {
            bool KetThuc = false;
            while (!KetThuc)
            {
                TaxiReturnSend data;
                if (queueTaxiReturnSend.TryDequeue(out data))
                {
                    try
                    {
                        var re = data.func();
                        if (IsDebug) ProcessFastTaxi.WriteLog(data.Tree, "Gửi thành công", "thành công", re ? 1 : 0);
                    }
                    catch (Exception ex)
                    {
                        new Log().WriteLog(ThongTinDangNhap.USER_ID, data.Tree, DateTime.Now, ex.Message);
                        if (IsDebug) ProcessFastTaxi.WriteLog(data.Tree, ex.Message, "Lỗi");
                    }
                }
                KetThuc = queueTaxiReturnSend.Count == 0;
            }
        }

        public static void RunProcess()
        {
            {
                new Thread(DoProcess).Start();
            }
        }

        #region Các hàm chạy ngầm ko làm ảnh hưởng tốc độ xử lý
        public static bool ReplaceTrip(long tripIDOld, XeDiDuongDai objXeDiDuongDai)
        {
            return Service_Common.FastTaxi.Try(client => client.ReplaceTrip(tripIDOld, Parse(objXeDiDuongDai)));
        }
        public static void ReplaceTripProcess(long tripIDOld, XeDiDuongDai objXeDiDuongDai)
        {
            Func<bool> func = () =>
            {
                try
                {
                    Service_Common.FastTaxi.Try(client => client.ReplaceTrip(tripIDOld, Parse(objXeDiDuongDai)));
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            };
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\ReplaceTripProcess"
            });
            RunProcess();
        }
        public static void AddTripProcess(XeDiDuongDai objXeDiDuongDai)
        {
            Func<bool> func = () =>
            {
                try
                {
                    Service_Common.FastTaxi.Try(client => client.AddTrip(Parse(objXeDiDuongDai)));
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            };
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\AddTripProcess"
            });
            RunProcess();
        }
            /// <summary>
            /// hủy trip trong bus
            /// </summary>
            /// <param name="bookId"></param>
            /// <param name="tripId"></param>
            /// <param name="XnCode"></param>
        public static void DenyTripInBookingProcess(long bookId, long tripId, int XnCode)
        {
            Func<bool> func = () =>
            {
                try
                {
                    return Service_Common.FastTaxi.Try(client => client.DenyTripInBooking(bookId, tripId, XnCode));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            };
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\DenyTripInBookingProcess"
            });
            RunProcess();
        }
        /// <summary>
        ///Khi mobi gọi lên trung tâm điều hành hủy cuốc đó đi.
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveScheduleVehicleReturnProcess(string key)
        {
            Func<bool> func = () =>
            {
                try
                {
                    return Service_Common.FastTaxi.Try(client => client.RemoveScheduleVehicleReturn(key));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            };
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\RemoveScheduleVehicleReturnProcess"
            });
            RunProcess();
        }
        #endregion


        public static TripBookingsSendResult AddTrip(XeDiDuongDai objXeDiDuongDai)
        {
            try
            {
                TripBookingsSendResult rs = Service_Common.FastTaxi.TryGet(client => client.AddTrip(Parse(objXeDiDuongDai))).Value;
                if (rs.AddTripSuccess) 
                    ProcessFastTaxi.WriteLog("TaxiReturn_Process\\AddTrip", "Gửi thành công", "thành công");
                else
                    ProcessFastTaxi.WriteLog("TaxiReturn_Process\\AddTrip", "Gửi thất bại", "thất bại");
                    
                return rs;

            }
            catch (Exception ex)
            {
                if (IsDebug) ProcessFastTaxi.WriteLog("TaxiReturn_Process\\AddTrip", ex.Message, "Lỗi");
                return null;
            }
        }

        /// <summary>
        /// Confirm da nhan cuoc dat xe chieu ve
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="XNCode"></param>
        public static void OperationHasReceive(long BookId, int XNCode)
        {
            if (BookId != 0)
            {
                Func<bool> func = () => Service_Common.FastTaxi.Try(
                            client => client.OperationHasReceive(BookId, new TimerSendBookingTimerSendBookingHasReceive()
                            {
                                XNCode = XNCode
                            }));
                queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
                {
                    func = func,
                    Tree = "TaxiReturn_Process\\OperationHasReceive"
                });
                RunProcess();
            }
        }

        public static bool OperationAnswer2(Taxi.Services.FastTaxi_OperationService.TimerSendTripTimerSendTripAnswer item)
        {
           return Service_Common.FastTaxi.Try(client => client.OperationAnswer2( item));
        }

        /// <summary>
        /// Xac nhan ghep xe thanh cong hay ko.
        /// Timeout2
        /// </summary>
        /// <param name="BookId"></param>
        /// <param name="TripId"></param>
        /// <param name="XNCode"></param>
        public static void OperationAnswer(long BookId, TimerSendBookingTimerSendBookingAnswer item)
        {
            Func<bool> func = () => Service_Common.FastTaxi.Try(client => client.OperationAnswer(BookId, item));
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\OperationAnswer"
            });
            RunProcess();

        }

        public static void EditTrip(XeDiDuongDai objXeDiDuongDai)
        {
            Func<bool> func = () => Service_Common.FastTaxi.Try(client => client.UpdateTrip(Parse(objXeDiDuongDai)));
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\EditTrip"
            });
            RunProcess();
        }

        /// <summary>
        /// Cập nhật trạng thái các cuốc khách lên server.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xnCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static void TripUpdateStatus(long id, int xnCode, Trip.Status status)
        {
            Func<bool> func = () => Service_Common.FastTaxi.Try(client => client.TripUpdateStatus(id, xnCode, status));
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\TripUpdateStatus"
            });
            RunProcess();

        }

        /// <summary>
        /// Hàm gửi lên server kết thúc cái book ClientKey.
        /// </summary>
        /// <param name="ClientKey">Chuỗi id của mobile</param>
        public static void FinishVehicleReturn(string ClientKey)
        {
            Func<bool> func = () => Service_Common.FastTaxi.Try(client => client.FinishVehicleReturn(ClientKey));
            queueTaxiReturnSend.Enqueue(new TaxiReturnSend()
            {
                func = func,
                Tree = "TaxiReturn_Process\\FinishVehicleReturn"
            });
            RunProcess();
        }

        public static Trip Parse(XeDiDuongDai item)
        {
            try
            {
                //string BienSoXe = "";
                //if (ProcessFastTaxi.Vehicles_GPS.ContainsKey(item.FK_SoHieuXe))
                //{
                //    BienSoXe = ProcessFastTaxi.Vehicles_GPS[item.FK_SoHieuXe];
                //}
                return new Trip()
                {
                    AddressFrom = item.DiaDiemDi,
                    AddressFromLat = item.Di_ViDo,
                    AddressFromLng = item.Di_KinhDo,
                    AddressTo = item.DiaDiemDen,
                    AddressToLat = item.Den_ViDo,
                    AddressToLng = item.Den_KinhDo,
                    DriverName = item.TenLaiXe,
                    DriverPhone = item.SoDienThoai,
                    KmExpected = item.KmDuKien,
                    MoneyExpected = (decimal)item.TienDuKien,
                    TimeExpected = item.TGDuKien,
                    Notes = item.GhiChu,
                    PK_TripID = item.ID,
                    TimeFrom = item.ThoiDiemDi.Value,
                    TimeTo = item.ThoiDiemVe ?? item.TGDuKien,
                    TripStatus = Trip.Status.DangDi,
                    //TripType
                    Vehicle_Lat = item.Xe_ViDo,
                    Vehicle_Lng = item.Xe_KinhDo,
                    VehiclePlate = item.BienSoXe,
                    //XNCode
                    //ExtensionData
                    //FK_CompanyID
                    //InputType
                    //PrivateCode
                    //Route
                    //Route_Points
                };
            }
            catch (Exception ex)
            {
                if (IsDebug) ProcessFastTaxi.WriteLog("TaxiReturn_Process\\Parse", ex.Message, "Lỗi");
                return null;
            }
        }

        #region Hàm Xử lý lấy lộ trình
        /// <summary>
        /// Hàm xử lý lấy lộ trình và quãng đường theo tọa độ 2 điểm
        /// </summary>
        /// <param name="Alat"></param>
        /// <param name="Alng"></param>
        /// <param name="Blat"></param>
        /// <param name="Blng"></param>
        /// <returns></returns>
        public static LoTrinh LayLoTrinh(float Alat, float Alng, float Blat, float Blng)
        {
            var A = new GMap.NET.PointLatLng(Alat, Alng);
            var B = new GMap.NET.PointLatLng(Blat, Blng);
            return LayLoTrinh(A, B);
        }
        /// <summary>
        /// Hàm xử lý lấy lộ trình và quãng đường theo 2 điểm
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static LoTrinh LayLoTrinh(GMap.NET.PointLatLng A, GMap.NET.PointLatLng B)
        {
            return LayLoTrinh(A, B, ThongTinCauHinh.FT_ServiceMap);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="FT_ServiceMap"></param>
        /// <returns></returns>
        public static LoTrinh LayLoTrinh(GMap.NET.PointLatLng A, GMap.NET.PointLatLng B, Utils.Enums.Enum_FT_ServiceMap FT_ServiceMap)
        {
            KeyValuePair<float, string> value;
            switch (FT_ServiceMap)
            {
                case Utils.Enums.Enum_FT_ServiceMap.BinhAnh:
                    value = LayLoTrinhBA(A, B);
                    break;
                case Utils.Enums.Enum_FT_ServiceMap.Google:
                default:
                    value = LayLoTrinhGo(A, B);
                    break;
            }
            LoTrinh loTrinh;
            loTrinh.Distance = value.Key;
            loTrinh.LoTrinh_ToaDo = value.Value;
            loTrinh.ListPoint = ConvertToPointLatLng(loTrinh.LoTrinh_ToaDo);
            loTrinh.LoTrinh_DiaChi = LayLoTrinhTheoToaDo(loTrinh.ListPoint).RemoveRoutePr();
            return loTrinh;
        }
       
        /// <summary>
        /// Hàm xử lý lộ trình Theo google
        /// </summary>
        /// <param name="A">Điểm đầu</param>
        /// <param name="B">Điểm cuối</param>
        /// <returns>Lộ trình</returns>
        private static KeyValuePair<float, string> LayLoTrinhGo(GMap.NET.PointLatLng A, GMap.NET.PointLatLng B)
        {
            try
            {
                var route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(A, B, false, false, 15);
                if (route != null)
                {
                    string address = string.Empty;
                    //int n = 1;
                    //if (route.Points.Count > 20)
                    //    n = (int)(route.Points.Count / 10);
                    for (int i = 1; i < route.Points.Count - 1; i++)
                    {
                        address += string.Format("{0} {1};", (float)route.Points[i].Lat, (float)route.Points[i].Lng);
                    }
                    return new KeyValuePair<float, string>((float)route.Distance, address);
                }                  
                return new KeyValuePair<float, string>(0, string.Empty);
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "LayLoTrinhBA", DateTime.Now, ex.Message);
                return new KeyValuePair<float, string>(0, string.Empty);
            }
        }
        /// <summary>
        /// Hàm xử lý lộ trình Theo BA
        /// </summary>
        /// <param name="Alat"></param>
        /// <param name="Alng"></param>
        /// <param name="Blat"></param>
        /// <param name="Blng"></param>
        /// <returns></returns>

        private static KeyValuePair<float, string> LayLoTrinhBA(GMap.NET.PointLatLng A, GMap.NET.PointLatLng B)
        {
            return LayLoTrinhBA((float)A.Lat, (float)A.Lng, (float)B.Lat, (float)B.Lng);
        }
        /// <summary>
        /// Hàm xử lý lộ trình Theo BA
        /// </summary>
        /// <param name="Alat"></param>
        /// <param name="Alng"></param>
        /// <param name="Blat"></param>
        /// <param name="Blng"></param>
        /// <returns></returns>
        private static KeyValuePair<float, string> LayLoTrinhBA(float Alat, float Alng, float Blat, float Blng)
        {
            try
            {
                var rs = Service_Common.FastTaxi.TryGet(p => p.CalRoute(Alat, Alng, Blat, Blng));
                if (!rs.Success) throw new Exception("Không kết nối đến server được.");
                if (rs.Value == null) throw new Exception("Không kết nối đến server được. Value=null");
                return new KeyValuePair<float, string>((float)rs.Value.Distance, rs.Value.Coordinates);
            }
            catch (Exception ex)
            {
                new Log().WriteLog(ThongTinDangNhap.USER_ID, "LayLoTrinhBA", DateTime.Now, ex.Message);
                return new KeyValuePair<float, string>(0, string.Empty);
            }
        }
        /// <summary>
        /// Lấy lộ trình theo danh sách lộ trình
        /// </summary>
        /// <param name="listPonit"></param>
        /// <returns></returns>
        public static string LayLoTrinhTheoToaDo(List<GMap.NET.PointLatLng> listPonit)
        {
            string address = string.Empty;
            int n = 2;// bước nhảy của các điểm
            int t = listPonit.Count;// số lượng các điểm
            if (t < 10)
                n = 2;
            if (t < 50)
                n = 3;
            else if (t < 300)
            {
                n = 10;
            }
            else if (t < 500)
            {
                n = 20;
            }
            else if (t < 1000)
            {
                n = 50;
            }
            else
            {
                n = 90;
            }
            string strLat = "";
            string strLng = "";
            for (int i = 0; i < t; i = i + n)
            {
                strLat += listPonit[i].Lat.ToString()+"@";
                strLng += listPonit[i].Lng.ToString() + "@";
                //var s = Service_Common.ServiceSoapClient.GetAddressByGeo((float)listPonit[i].Lat, (float)listPonit[i].Lng);
                //if (address.IndexOf(s) == -1)
                //    address += "->" + s;
            }
            return Service_Common.FastTaxi.TryGet(p => p.GetAddressByGeos(ConvertToStringSystemNumber(strLng.TrimEnd('@')), ConvertToStringSystemNumber(strLat.TrimEnd('@')))).Value;
            ///GetAddressByGeos
            //return address;//.Length>3?address.Remove(address.Length-2):address;
        }
        /// <summary>
        /// Lấy lộ trình theo các tọa độ
        /// </summary>
        /// <param name="lsToDo"></param>
        /// <returns></returns>
        public static string LayLoTrinhTheoToaDo(string lsToDo)
        {           
            return LayLoTrinhTheoToaDo(ConvertToPointLatLng(lsToDo));
        }
        public static List<GMap.NET.PointLatLng> ConvertToPointLatLng(string toDo)
        {
           
            List<GMap.NET.PointLatLng> ls = new List<GMap.NET.PointLatLng>();
            if (!string.IsNullOrEmpty(toDo))
            {
                if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                {
                    toDo = toDo.Replace('.', '#');
                    toDo = toDo.Replace(',', '.');
                    toDo = toDo.Replace('#', ',');
                }
                var lotrinh = toDo.Split(';');
                for (int i = 0; i < lotrinh.Length; i++)
                {
                    if (lotrinh[i].Trim() != "")
                    {
                        float lat = lotrinh[i].Split(' ')[0].To<float>();
                        float lng = lotrinh[i].Split(' ')[1].To<float>();
                        ls.Add(new GMap.NET.PointLatLng(lat, lng));
                    }
                }
            } 
            return ls;
        }
        /// <summary>
        /// Tính thời gian đi hết quãng đường km
        /// theo công thức tg=km/vận tốc.
        /// </summary>
        /// <param name="km">Khoảng cách</param>
        /// <returns>số phút đi hết quãng đường.</returns>
        public static int TinhThoiGianDiHetQuangDuong(float km)
        {
            float vt = 40.0f;
            return (int)(60f * (km / vt));
        }
        public static KeyValuePair<float, float>? Search(string address)
        {
           var str= Service_Common.GetGeobyAddress(address, ThongTinCauHinh.GPS_TenTinh);
           if (str.Split(' ').Length == 2)
           {
               return new KeyValuePair<float, float>(str.Split(' ')[0].ConvertToFloat(), str.Split(' ')[1].ConvertToFloat());
           }
           return null;
        }
        public static float ConvertToFloat(this string strNumber)
        {
            if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
            {
                strNumber = strNumber.Replace('.', '#');
                strNumber = strNumber.Replace(',', '.');
                strNumber = strNumber.Replace('#', ',');
            }
            return strNumber.To<float>();
        }
        public static string ConvertToStringSystemNumber(string str)
        {
            if (Application.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
            {
                str = str.Replace('.', '#');
                str = str.Replace(',', '.');
                str = str.Replace('#', ',');
            }
            return str;
        }
        #endregion
        /// <summary>
        /// Xóa những tiền tố của việt nam không làm ảnh hưởng kết quả tìm kiếm
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public static string RemoveRoutePr(this string route)
        {
            if (string.IsNullOrEmpty(route)) return string.Empty;
            return
                route.Replace(", Việt Nam", "")
                    .Replace(", Vietnam", "")
                    .Replace("Unnamed Road,", "")
                    .Replace("tp.", "")
                    .Replace("tx.", "")
                    .Replace("tt.", "")
                    .Replace("q.", "")
                    .Replace("*", "")
                    .Replace("Q.", "")
                    .Replace("TP.", "")
                    .Replace("TX.", "")
                    .Replace("TT.", "");
        }

        #region timer server
        /// <summary>
        /// Map thời gian server sql sang phần mềm điều hành.
        /// </summary>
        public static DateTime timerServer;
        /// <summary>
        /// Map thời gian server sql sang phần mềm điều hành.
        /// chạy thời gian thay đổi từng giây.
        /// </summary>
        public static System.Windows.Forms.Timer G_TimerServer;
        /// <summary>      
        /// Bắt đầu
        /// Map thời gian server sql sang phần mềm điều hành.
        /// chạy thời gian thay đổi từng giây.
        /// </summary>
        public static void StartTimeServer()
        {
            if (G_TimerServer == null)
            {
                G_TimerServer = new System.Windows.Forms.Timer();
                Action<object, EventArgs> tick = (o,e) => {
                    timerServer = timerServer.AddSeconds(1);
                };
                G_TimerServer.Tick += new EventHandler(tick);
                G_TimerServer.Interval = 995;
                timerServer = DieuHanhTaxi.GetTimeServer().AddSeconds(1);
                G_TimerServer.Start();
            }
        }
       
        #endregion
    }
    public struct LoTrinh
    {
        public float Distance;
        public string LoTrinh_DiaChi;
        public string LoTrinh_ToaDo;
        public List<GMap.NET.PointLatLng> ListPoint;
    }
}
