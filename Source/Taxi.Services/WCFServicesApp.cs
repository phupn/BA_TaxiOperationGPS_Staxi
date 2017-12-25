using Taxi.Common;
using System;
using System.Collections.Generic;
using Taxi.Business;
using Taxi.Services.ServiceApp;
using Taxi.Utils;

namespace Taxi.Services
{
    /// <summary>
    /// Giao tiếp với Server và App
    /// </summary>
    public static class WCFServicesApp
    {
        private static readonly ConnectService<OperationServiceClient> serviceApp = new ConnectService<OperationServiceClient>();

        public static ConnectService<OperationServiceClient> Client
        {
            get
            {
                return serviceApp;
            }
        }

        public static bool IsOperatorClientConnecting()
        {
            return Client.TryGet(p => p.IsOperatorClientConnecting()).Value;
        }

        public static bool SendACKGetPhone(Guid bookId, byte result, string vehicle)
        {
            return Client.TryGet(p => p.SendACKGetPhone(bookId, result, vehicle)).Value;
        }

        public static bool SendACKInvite(Guid bookId, string vehicle, bool result, string msg)
        {
            return Client.TryGet(p => p.SendACKInvite(bookId, vehicle, result, msg)).Value;
        }

        public static bool SendOperatorCancel(Guid bookId, string msg, SourceCancelType cancelType)
        {
            return Client.TryGet(p => p.SendOperatorCancel(bookId, msg, cancelType)).Value;
        }

        public static bool SendWrongCustomer(Guid bookId, string vehicle)
        {
            return Client.TryGet(p => p.SendWrongCustomer(bookId, vehicle)).Value;
        }
        public static bool SendInitTrip(CuocGoi objCuocGoi)
        {
            try
            {
                var tenKH = "";
                if (!string.IsNullOrEmpty(objCuocGoi.DiaChiGoi.Trim()))
                {
                    tenKH = string.Format("-[{0}]", objCuocGoi.DiaChiGoi.Trim());
                }
                LatLng currentLatLng = new LatLng { Lat = (float)objCuocGoi.GPS_ViDo, Lng = (float)objCuocGoi.GPS_KinhDo };
                var from = new AddressInfo
                {
                    Address = string.Format("{0}{1}", objCuocGoi.DiaChiDonKhach, tenKH),
                    Name = objCuocGoi.DiaChiDonKhach,
                    LatLng = currentLatLng
                };
                var to = new AddressInfo
                {
                    Address = objCuocGoi.DiaChiTraKhach,
                    Name = objCuocGoi.DiaChiTraKhach,
                    LatLng = new LatLng { Lat = (float)objCuocGoi.GPS_ViDo_Tra, Lng = (float)objCuocGoi.GPS_KinhDo_Tra }
                };
                byte carType = 0;
                if (objCuocGoi.G5_CarType == "" || objCuocGoi.G5_CarType.Split(',').Length > 1)
                {
                    carType = 0;
                }
                else
                {
                    byte.TryParse(objCuocGoi.G5_CarType, out carType);
                }
                byte customerType = 0;
                var vehicleOptions = new List<VehicleOption>();
                string xeDonChiDinh = "";// objCuocGoi.XeDenDiem != null && objCuocGoi.XeDenDiem != "" ? objCuocGoi.XeDenDiem : objCuocGoi.XeNhan;
                string xeDieuChiDinh = "";// objCuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe ? string.Empty : xeDonChiDinh;
                if (Config_Common.App_SendRadioTrip && objCuocGoi.XeDenDiem.IndexOf(".") <= 0)
                {
                    xeDonChiDinh =  objCuocGoi.XeDenDiem != null && objCuocGoi.XeDenDiem != "" ? objCuocGoi.XeDenDiem : objCuocGoi.XeNhan;
                    xeDieuChiDinh =  objCuocGoi.TrangThaiCuocGoi == TrangThaiCuocGoiTaxi.DieuLaiAppLaiXe ? string.Empty : xeDonChiDinh;
                }
                if (!string.IsNullOrEmpty(xeDieuChiDinh))
                {
                    var lst = xeDieuChiDinh.Split('.');
                    foreach (var s in lst)
                    {
                        vehicleOptions.Add(new VehicleOption
                        {
                            Distance = 0,//Khoảng cách
                            Vehicle = CommonBL.ConvertSangBienSo(s)// Chuyển đổi thành biển số
                        });
                    }
                }
                string[] arrVehicleDeny = null;
                if (!string.IsNullOrEmpty(objCuocGoi.XeNhan))
                {
                    arrVehicleDeny = new string[] { objCuocGoi.XeNhan };
                }
                else if (!string.IsNullOrEmpty(objCuocGoi.XeDungDiem))
                {
                    arrVehicleDeny = new string[] { objCuocGoi.XeDungDiem };
                }
                Direction chieu = Direction.One;
                if (objCuocGoi.Long_ChieuID == 2)
                {
                    chieu = Direction.Two;
                }
                int GiaPhuTroi_Km = 0;
                int GiaPhuTroi_Gio = 0;
                int LoaiXeID = 0;
                int.TryParse(objCuocGoi.Long_LoaiXeID, out LoaiXeID);
                if (CommonBL.ListDanhMucVuotGio != null)
                {

                    Data.BanCo.Entity.TuyenThueBao.VuotGioQuyDinh temp = CommonBL.ListDanhMucVuotGio.Find(a => a.FK_LoaiXeID == LoaiXeID);
                    if (temp != null)
                    {
                        if (chieu == Direction.Two)
                        {
                            int.TryParse(temp.GiaDinhMucVuot1KmHaiChieu.ToString(), out GiaPhuTroi_Km);
                            int.TryParse(temp.GiaDinhMucVuot1GioHaiChieu.ToString(), out GiaPhuTroi_Gio);
                        }
                        else
                        {
                            int.TryParse(temp.GiaDinhMucVuot1KmMotChieu.ToString(), out GiaPhuTroi_Km);
                        }
                    }
                }
                BookTripType tripType = BookTripType.Normal;
                if (objCuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = BookTripType.Long;
                }
                if (objCuocGoi.BookId == Guid.Empty)//Chưa khởi tạo thì khởi tạo
                {
                    objCuocGoi.BookId = Guid.NewGuid();
                    CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(objCuocGoi.BookId, objCuocGoi.IDCuocGoi, Enum_G5_Type.DieuApp, objCuocGoi.LenhDienThoai);
                    LogError.WriteLogInfo(string.Format("G5_DIENTHOAI_UpdateBookIdByIdCuocGoi:{0}-{1}-{2} Taxi", objCuocGoi.IDCuocGoi, objCuocGoi.CuocGoiLaiIDs, objCuocGoi.BookId));
                }

                string comment = objCuocGoi.GhiChuDienThoai;
                string ghichu = "";
                string showphone = "0";
                if (Config_Common.AppLX_CMDID_ShowPhoneNumber > 0)
                {
                    //{"p":1, "c":"ghi chu"}
                    if (objCuocGoi.GhiChuDienThoai != null && objCuocGoi.GhiChuDienThoai != "")
                    {
                        ghichu = objCuocGoi.GhiChuDienThoai;
                    }
                    if ((objCuocGoi.ShowPhoneAppDriver != null && objCuocGoi.ShowPhoneAppDriver) || objCuocGoi.LenhDienThoai.Contains(CommandCode.LENH_SHOWPHONENUMBER))
                    {
                        showphone = "1";
                    }

                    comment = "{" + string.Format("\"p\":{0}, \"c\":\"{1}\"", showphone, ghichu) + "}";
                }
                //temp.GiaDinhMucVuot1GioHaiChieu
                return Client.TryGet(p => p.SendInitTrip(
                    objCuocGoi.BookId,
                    from,
                    to,
                    comment,
                    (byte)objCuocGoi.SoLuong,
                    carType,
                    customerType,
                    objCuocGoi.PhoneNumber,
                    vehicleOptions.ToArray(),
                    currentLatLng,
                    arrVehicleDeny,
                    tripType,
                    objCuocGoi.Money_Contract > 0 ? objCuocGoi.Money_Contract : objCuocGoi.Long_GiaTien,
                    objCuocGoi.Long_Km,
                    chieu,
                    GiaPhuTroi_Km,
                    GiaPhuTroi_Gio)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("App SendInitTrip", ex);
                return false;
            }
        }

        //public static bool SendInitTrip(Guid bookId, AddressInfo from, AddressInfo to, string note, byte quantity, 
        //                                byte carType, byte customerType, string phone, VehicleOption[] vehicleOptions,
        //                                LatLng currentLatLng, BookTripType tripType, int money, float distance = 0, Direction direction = Direction.One, int moneyExtend = 0)
        //{
        //    try
        //    {
        //        return Client.TryGet(p => p.SendInitTrip(bookId, from, to, note, quantity, 
        //                                    carType, customerType, phone, vehicleOptions, 
        //                                    currentLatLng, null, tripType, money, distance, direction, moneyExtend)).Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.WriteLogError("App SendInitTrip", ex);
        //        return false;
        //    }            
        //}
        
        public static bool SendLogoutDriver(string vehicle)
        {
            return Client.TryGet(p => p.SendLogoutDriver(vehicle)).Value;
        }

        public static bool SendOperatorCatched(Guid bookId)
        {
            return Client.TryGet(p => p.SendOperatorCatched(bookId)).Value;
        }

        public static bool SendMissCar(Guid bookId)
        {
            return Client.TryGet(p => p.SendMissCar(bookId)).Value;
        }

        public static bool SendText(string vehiclePlate, string text, Guid bookId)
        {
            return Client.TryGet(p => p.SendText(vehiclePlate, text, bookId)).Value;
        }

        public static bool SendConfirmDone(Guid bookId, bool result, string msg)
        {
            return Client.TryGet(p => p.SendConfirmDone(bookId, result, msg)).Value;
        }

        public static bool SendOperatorCmd(string vehiclePlate, Guid bookId, int cmdId, string msg, bool result)
        {
            return Client.TryGet(p => p.SendOperatorCmd(vehiclePlate, bookId, cmdId, msg, result)).Value;
        }

        /// <summary>
        /// Xoa cuoc sanh
        /// </summary>
        public static bool SendDeleteBook(Guid[] bookIds, string userName)
        {
            return Client.TryGet(p => p.SendDeleteBook(bookIds, userName)).Value;
        }
        /// <summary>
        /// Gửi xe nhận từ điều đàm lên cho app KH
        /// </summary>
        public static bool SendOperatorDispatched(Guid bookId, string privateCode)
        {
            try
            {                
                return Client.TryGet(p => p.SendOperatorDispatched(bookId, privateCode)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendOperatorDispatched", ex);
                return false;
            }
        }

        /// <summary>
        /// Gửi SMS khi có xe nhận
        /// </summary>
        public static bool SendSMS_ReceiveCarInfo(Guid bookId, string mobile, string privateCode, LoaiCuocKhach loaiCuoc, string privateCodeOld)
        {
            try
            {                
                string driverName = "";
                string driverPhone = "";
                if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
                {
                    driverName = CommonBL.DictDriver[privateCode].TenNhanVien;
                    driverPhone = CommonBL.DictDriver[privateCode].DiDong;
                }
                TcpOPBookTripType tripType = TcpOPBookTripType.Normal;
                if (loaiCuoc == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = TcpOPBookTripType.Long;
                }
                else if (loaiCuoc == LoaiCuocKhach.ChoKhachSanBay)
                {
                    tripType = TcpOPBookTripType.Airport;

                    #region BaSao : Xe nội thành chở khách đi sân bay mới nhắn tin
                    if (license.IsTaxiBaSao)
                    {
                        int soXe = 0;
                        if (int.TryParse(privateCode, out soXe))//Nhiều xe cũng ko gửi sms
                        {
                            if (soXe >= 1000)//Xe sân bay của Ba Sao là xe lớn hơn 1000
                            {
                                return true;
                            }
                        }
                    }
                    #endregion
                }
                return Client.TryGet(p => p.SendSMS_ReceiveCarInfo(bookId, mobile, privateCode,
                                                CommonBL.ConvertSangBienSo(privateCode), driverName, driverPhone,
                                                tripType, privateCodeOld)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendOperatorDispatched", ex);
                return false;
            }
        }

        /// <summary>
        /// Gửi sms khi xe đến điểm gặp khách trong điều xe đường dài! (VD: Ba Sao)
        /// </summary>
        public static bool SendSMS_ReceiveCatchedUser(Guid bookId, string mobile, string privateCode, int money, LoaiCuocKhach loaiCuoc, int giaPhuTroi, int quangduong, TcpOPDirection dir,
            string param6 = "", string param7 = "", string param8 = "", string param9 = "", string param10 = "")
        {
            try
            {
                string driverName = "";
                if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
                {
                    driverName = UnicodeStrings.UnicodeFormat_V2(CommonBL.DictDriver[privateCode].TenNhanVien);
                    
                }   
                TcpOPBookTripType tripType = TcpOPBookTripType.Normal;
                if (loaiCuoc == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = TcpOPBookTripType.Long;
                }
                else if (loaiCuoc == LoaiCuocKhach.ChoKhachSanBay)
                {
                    tripType = TcpOPBookTripType.Airport;
                    #region BaSao : Xe nội thành chở khách đi sân bay mới nhắn tin
                    if (license.IsTaxiBaSao)
                    {
                        int soXe = 0;
                        if (int.TryParse(privateCode, out soXe))//Nhiều xe cũng ko gửi sms
                        {
                            if (soXe >= 1000)//Xe sân bay của Ba Sao là xe lớn hơn 1000
                            {
                                return true;
                            }
                        }
                    }
                    #endregion
                }
                if (Config_Common.SMS_CuocDuongDai_LaiXe)
                {
                    return Client.TryGet(p => p.SendSMS_ReceiveCatchedUser_V2(bookId, mobile, privateCode, driverName, CommonBL.ConvertSangBienSo(privateCode), money, tripType, giaPhuTroi, quangduong, dir, param6, param7, param8, param9, param10)).Value;
                }
                else
                {
                    return Client.TryGet(p => p.SendSMS_ReceiveCatchedUser(bookId, mobile, privateCode, money, tripType, giaPhuTroi, quangduong, dir, param6, param7, param8, param9, param10)).Value;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_ReceiveCatchedUser", ex);
                return false;
            }
        }

        public static bool SendSMS_ReceiveCatchedUser_V2(Guid bookId, string mobile, string privateCode, string driverName, string vehiclePlate, int money, LoaiCuocKhach loaiCuoc, int giaPhuTroi, int quangduong, TcpOPDirection dir,
            string param6 = "", string param7 = "", string param8 = "", string param9 = "", string param10 = "")
        {
            try
            {
                TcpOPBookTripType tripType = TcpOPBookTripType.Normal;
                if (loaiCuoc == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = TcpOPBookTripType.Long;
                }
                else if (loaiCuoc == LoaiCuocKhach.ChoKhachSanBay)
                {
                    tripType = TcpOPBookTripType.Airport;
                    #region BaSao : Xe nội thành chở khách đi sân bay mới nhắn tin
                    if (license.IsTaxiBaSao)
                    {
                        int soXe = 0;
                        if (int.TryParse(privateCode, out soXe))//Nhiều xe cũng ko gửi sms
                        {
                            if (soXe >= 1000)//Xe sân bay của Ba Sao là xe lớn hơn 1000
                            {
                                return true;
                            }
                        }
                    }
                    #endregion
                }
                return Client.TryGet(p => p.SendSMS_ReceiveCatchedUser_V2(bookId, mobile, privateCode, driverName, vehiclePlate, money, tripType, giaPhuTroi, quangduong, dir, param6, param7, param8, param9, param10)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_ReceiveCatchedUser V2", ex);
                return false;
            }
        }

        /// <summary>
        /// Gửi sms khi xe hủy
        /// </summary>
        public static bool SendSMS_ReceiveDriverCancel(Guid bookId, string mobile, string privateCode, LoaiCuocKhach loaiCuoc)
        {
            try
            {
                TcpOPBookTripType tripType = TcpOPBookTripType.Normal;
                if (loaiCuoc == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = TcpOPBookTripType.Long;
                }
                else if (loaiCuoc == LoaiCuocKhach.ChoKhachSanBay)
                {
                    tripType = TcpOPBookTripType.Airport;

                    #region BaSao : Xe nội thành chở khách đi sân bay mới nhắn tin
                    if (license.IsTaxiBaSao)
                    {
                        int soXe = 0;
                        if (int.TryParse(privateCode, out soXe))//Nhiều xe cũng ko gửi sms
                        {
                            if (soXe >= 1000)//Xe sân bay của Ba Sao là xe lớn hơn 1000
                            {
                                return true;
                            }
                        }
                    }
                    #endregion
                }
                return Client.TryGet(p => p.SendSMS_ReceiveDriverCancel(bookId, mobile, privateCode, tripType)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_ReceiveDriverCancel", ex);
                return false;
            }
        }

        /// <summary>
        /// Gửi sms khi không có xe nhận
        /// </summary>
        public static bool SendSMS_ReceiveNoCar(Guid bookId, string mobile, LoaiCuocKhach loaiCuoc)
        {
            try
            {
                TcpOPBookTripType tripType = TcpOPBookTripType.Normal;
                if (loaiCuoc == LoaiCuocKhach.ChoKhachDuongDai)
                {
                    tripType = TcpOPBookTripType.Long;
                }
                else if (loaiCuoc == LoaiCuocKhach.ChoKhachSanBay)
                {
                    tripType = TcpOPBookTripType.Airport;
                }
                return Client.TryGet(p => p.SendSMS_ReceiveNoCar(bookId, mobile, tripType)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_ReceiveNoCar", ex);
                return false;
            }
        }

        public static bool SendSMS_CustomerInfo(Guid bookId,string privateCode, string mobileCustomer, string info)
        {
            try
            {
                string[] arrPrivateCode = privateCode.Split('.');
                bool result = false;
                foreach (var item in arrPrivateCode)
                {
                    string driverPhone = "";
                    if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
                    {
                        driverPhone = CommonBL.DictDriver[privateCode].DiDong;
                    }
                    result = Client.TryGet(p => p.SendSMS_CustomerInfo(bookId, driverPhone, mobileCustomer, info)).Value;
                }
                return result;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_CustomerInfo", ex);
                return false;
            }
        }

        /// <summary>
        /// cập nhật lại giá đường dài trước khi gửi tin nhắn
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="distance"></param>
        /// <param name="money2"></param>
        /// <param name="moneyExtend"></param>
        /// <param name="moneyExtendByTime"></param>
        /// <param name="carNo"></param>
        /// <param name="vehiclePlate"></param>
        /// <returns></returns>
        public static bool SendSMS_UpdateMoneyLongTrip(Guid bookId, float distance, int money2, int moneyExtend, int moneyExtendByTime, string carNo, string vehiclePlate)
        {
            try
            {
                return Client.TryGet(p => p.SendUpdateMoneyLongTrip(bookId, distance, money2, moneyExtend, moneyExtendByTime, carNo, vehiclePlate)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_ReceiveNoCar", ex);
                return false;
            }
        }
        /// <summary>
        /// Gửi tin nhắn SMS
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSMS(string mobile, string message)
        {
            try
            {
                return Client.TryGet(p => p.SendSMS(mobile, message)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS", ex);
                return false;
            }
        }

        #region Dương Thảo

        /// <summary>
        /// Gửi SMS riêng cho Dương Thảo, API Viettel
        /// </summary>
        /// <param name="mobileCustomer"></param>
        /// <param name="privateCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendSMS_DuongThao_CustomerPhone(string mobileCustomer, string privateCode, string message)
        {
            try
            {
                string driverPhone = "";
                if (CommonBL.DictDriver != null && CommonBL.DictDriver.ContainsKey(privateCode))
                {
                    driverPhone = CommonBL.DictDriver[privateCode].DiDong;
                    if (string.IsNullOrEmpty(driverPhone))
                    {
                        driverPhone = CommonBL.DictDriver[privateCode].DienThoai;
                    }
                }
                return Client.TryGet(p => p.SendSMS_DuongThao_CustomerPhone(StringTools.ConvertPhoneNumber(driverPhone), StringTools.ConvertPhoneNumber(mobileCustomer), message)).Value;
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("SendSMS_DuongThao_CustomerPhone", ex);
                return false;
            }
        }
        #endregion
    }
}
