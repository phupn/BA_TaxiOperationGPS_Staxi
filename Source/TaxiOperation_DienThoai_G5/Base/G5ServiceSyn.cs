#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.ComponentModel;
using Taxi.Business;
using Taxi.Services;
using Taxi.Utils;
using Taxi.Services.Operations.Inferfaces;
using Taxi.Services.Operations;
using System.Windows.Forms;
using Taxi.Data.G5.DanhMuc;
using Taxi.Data.G5;
using System.Threading.Tasks;
//using Taxi.Services.ServiceG5;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace TaxiApplication.Base
{
    /// <summary>
    /// Giao tiếp tới Server TTDH.
    /// </summary>
    public class G5ServiceSyn
    {
        #region === Server ====
        public const int soMini = 5;
        #region ==== 0.Service ===
        static private IServiceOperation serviceOperation;
        static public IServiceOperation ServiceOperation
        {
            get
            {
                if (serviceOperation == null)
                {
                    serviceOperation = ServiceOperationFactory.Get(Config_Common.ServiceDieuApp,Config_Common.ServiceConnectString);
                }
                return serviceOperation;
            }
        }
        public static void BackgroupAction(Action action, string nameError = "BackgroupActionServer")
        {
            try
            {
                if (action != null)
                {
                    using (var ActionWorker = new BackgroundWorker())
                    {
                        ActionWorker.DoWork += (sender, e) => action();
                        ActionWorker.RunWorkerCompleted += (Sender, e) =>
                        {
                            if (e.Error != null)
                            {
                                LogError.WriteLogError(nameError, e.Error);
                            }
                        };
                        ActionWorker.RunWorkerAsync();
                    }
                  
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(string.Format("BackgroupAction.{0}", nameError), ex);
            }
        }
        /// <summary>
        /// Xử Lý trong Backgroup.Không ảnh hưởng tới hệ thống
        /// </summary>
        public static void BackgroupActionServer(Action<IServiceOperation> action, string nameError = "BackgroupActionServer")
        {
            try
            {
                if (action != null)
                {
                    using (var ActionWorker = new BackgroundWorker())
                    {
                        ActionWorker.DoWork += (sender, e) => action(ServiceOperation);
                        ActionWorker.RunWorkerCompleted += (Sender, e) =>
                        {
                            if (e.Error != null)
                            {
                                LogError.WriteLogError(nameError, e.Error);
                            }
                        };
                        ActionWorker.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(string.Format("BackgroupActionServer.{0}",nameError), ex);
            }                
        }

        #endregion

        #region ==== 1.InitTrip ====
        ///// <summary>
        ///// Khởi tạo cuốc khách tới Server TTDH
        ///// </summary>
        ///// <param name="idCuocKhach">ID Cuốc Khách</param>
        ///// <param name="diaChiDon">Địa chỉ đón</param>
        ///// <param name="toaDoDon">Tọa độ đón</param>
        ///// <param name="diaChiTra">Địa chỉ trả</param>
        ///// <param name="toaDoTra">Tọa độ trả</param>
        ///// <param name="note">Ghi chú</param>
        ///// <param name="quantity">Số lượng xe</param>
        ///// <param name="carType">Loại xe</param>
        ///// <param name="customerType">Loại Cuốc</param>
        ///// <param name="phone">Số điện thoại</param>
        ///// <param name="currentLatLng">Tọa độ khách hàng</param>
        ///// <param name="SoLuongCuocSaoChep">Số lượng cuốc sao chép</param>
        ///// <param name="isCopy">Là cuốc sao chép</param>
        ///// <param name="bookId">BookId</param>
        ///// <param name="xeDieuChiDinh">Xe điều chỉ định</param>
        ///// <param name="sleepCuoc">Ngủ tí.Chưa dùng</param>
        //public static void InitTripSyn(long idCuocKhach, string diaChiDon, LatLngOperation toaDoDon, string diaChiTra,
        //   LatLngOperation toaDoTra, string note, byte quantity, string carType, byte customerType, string phone,
        //    LatLngOperation currentLatLng, int SoLuongCuocSaoChep = 0, bool isCopy = false, Guid? bookId = null,
        //    string xeDieuChiDinh = "", int sleepCuoc = 0, string LenhDTV = "", string[] vehiclesDeny = null,
        //    BookTripType tripType = BookTripType.Normal, int money = 0)
        //{
        //    var listXeDieuChiDinh = new List<Vehicle>();
        //    if (!string.IsNullOrEmpty(xeDieuChiDinh))
        //    {
        //        var lst = xeDieuChiDinh.Split('.');
        //        foreach (var s in lst)
        //            listXeDieuChiDinh.Add(new Vehicle()
        //            {
        //                Distance = 0,//Khoảng cách
        //                VehicleName = CommonBL.ConvertSangBienSo(s)// Chuyển đổi thành biển số
        //            });
        //    }
        //    var content = new TripOperation()
        //    {
        //        IdCuocKhach = idCuocKhach,
        //        DiaChiDon = diaChiDon,
        //        ToaDoDon = toaDoDon,
        //        DiaChiTra = diaChiTra,
        //        ToaDoTra = toaDoTra,
        //        Note = note,
        //        Quantity = quantity,
        //        CarType = carType,
        //        CustomerType = customerType,
        //        Phone = phone,
        //        CurrentLatLng = currentLatLng,
        //        SoLuongCuocSaoChep = SoLuongCuocSaoChep,
        //        IsCopy = isCopy,
        //        BookId = bookId,
        //        XeDieuChiDinh = listXeDieuChiDinh,
        //        SleepCuoc = sleepCuoc,
        //        VehiclesDeny = vehiclesDeny,
        //        Money = money
        //    };
        //    if (content.CurrentLatLng == null)
        //    {
        //        content.CurrentLatLng = content.ToaDoDon;
        //    }
        //    BackgroupActionServer(p =>
        //    {
        //        if (content.BookId == null || content.BookId == Guid.Empty)//Chưa khởi tạo thì khởi tạo
        //        {
        //            content.BookId = Guid.NewGuid();
        //            CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(content.BookId.Value, content.IdCuocKhach, Enum_G5_Type.DieuApp, LenhDTV);
        //        }
        //        var done = ServiceOperation.InitTrip(content, tripType); //InitTrip(trip);
        //        if (!done) // Không gửi được lên thì chuyển cuốc điều đàm.
        //        {
        //            CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(content.BookId ?? Guid.NewGuid(), content.IdCuocKhach, Enum_G5_Type.ChuyenSangDam, LenhDTV);
        //        }
        //        if (content.SoLuongCuocSaoChep > 0)
        //            G5ServiceSyn.CopyCuocGoi(content.IdCuocKhach, content.SoLuongCuocSaoChep, Enum_G5_Type.DieuApp);
        //    }, "Khởi tạo cuốc");
        //}
        #endregion

        #region ==== 2.CatchUser ====
        /// <summary>
        /// Gặp xe
        /// </summary>
        public static void SendCatchUserSyn(Guid bookId, bool isContract)
        {
            if (bookId != Guid.Empty)
            {
                if (isContract)
                {
                    Task.Factory.StartNew(() =>
                    {
                        return WCFServicesAppXHD.SendOperatorCatched(bookId);
                    });
                }
                else
                {
                    BackgroupActionServer(p => p.SendOperatorCatched(bookId), "Gặp xe");
                }
            }
        }
        #endregion

        #region ==== 3.OperatorCancel ====
        /// <summary>
        /// Gửi lệnh hoãn xe đến server G5
        /// </summary>
        /// <param name="bookId">BookId</param>
        public static void SendOperatorCancel(Guid bookId, LoaiCuocKhach loaiCK, string msg = "", Taxi.Services.ServiceG5.SourceCancelType type = Taxi.Services.ServiceG5.SourceCancelType.Unknown)
        {
            if (bookId != Guid.Empty)
            {
                if (loaiCK == LoaiCuocKhach.ChoKhachHopDong)
                {
                    Task.Factory.StartNew(() =>
                    {
                        return WCFServicesAppXHD.SendOperatorCancel(bookId, msg, (Taxi.Services.ServiceApp_XHD.SourceCancelType)type);
                    });
                }
                else
                {
                    WCFServicesApp.SendOperatorCancel(bookId, msg, (Taxi.Services.ServiceApp.SourceCancelType)type);
                }
            }
        }
        #endregion

        #region ==== 4.SendConfirmDone ==== 
        /// <summary>
        /// Cuốc hoàn thành
        /// </summary>
        /// <param name="bookId">BookId</param>
        /// <param name="msg">Thông báo</param>
        public static void SendConfirmDone(Guid bookId, string msg = "", bool isContract = false)
        {
            if (bookId != Guid.Empty)
            {
                if (isContract)
                {
                    Task.Factory.StartNew(() =>
                    {
                        return WCFServicesAppXHD.SendConfirmDone(bookId, false, msg);
                    });
                }
                else
                {
                    var Content = new GuidMsg()
                    {
                        BookId = bookId,
                        Msg = msg
                    };
                    BackgroupActionServer(p => p.SendConfirmDone(Content), "Hoàn thành");
                }
            }
        }
        #endregion

        #region ==== 4.SendConfirmDoneBook ====
        /// <summary>
        /// Gửi kết quả hoàn thành của cuốc lên server
        /// </summary>
        /// <param name="cuocGoi">BookId</param>
        /// <param name="state">Trạng thái confirm</param>
        public static void SendConfirmDoneBook(CuocGoi cuocGoi, EnumConfirmDoneBook state)
        {
            if (cuocGoi.BookId != Guid.Empty)
            {
                if (cuocGoi.LoaiCuocKhach == LoaiCuocKhach.ChoKhachHopDong)
                {
                    Task.Factory.StartNew(() =>
                    {
                        return WCFServicesAppXHD.SendConfirmDoneBook(cuocGoi.BookId, CommonBL.ConvertSangBienSo(cuocGoi.XeDon), (Taxi.Services.ServiceApp_XHD.ConfirmDoneBook)state);
                    });
                }
                else
                {
                    BackgroupActionServer(p => p.SendConfirmDoneBook(cuocGoi.BookId, CommonBL.ConvertSangBienSo(cuocGoi.XeDon), state), "Hoàn thành");
                }
            }
        }
        #endregion

        #region ==== 5.SendText ====
        /// <summary>
        /// Gửi lệnh cho lái xe bằng biển số.
        /// </summary>
        /// <param name="privateCode">Số hiệu xe</param>
        /// <param name="Text">Lệnh gửi lái xe</param>
        /// <param name="BookId">BookId</param>
        /// <param name="idCuocGoi">ID Cuộc gọi</param>
        /// <param name="userId">nhân viên gửi Lệnh</param>
        /// <param name="cmdId">Mã Lệnh</param>
        /// <param name="result">Driver Command gửi lên từ lái xe, tới điều hành là gửi ACKDriver Command
        /// Để xác nhận lệnh từ lái xe đã tới điều hành.
        /// Vì thế để biết ĐH xử lý thế nào thì gửi OperatorCmd result là true: false
        /// Ví dụ: lái xe xin số, điều hành gửi về result:false => ko được, true: có được xem số</param>
        public static void SendText(string privateCode, string Text, Guid BookId, long idCuocGoi, string userId, bool isContract, int cmdId = 0, bool result = true)
        {
            try
            {
                //LogError.WriteLogInfo(string.Format("SendText:{0}" , Text));
                var Content = new SendTextContext
                {
                    VehiclePlate = CommonBL.ConvertSangBienSo(privateCode),
                    TextCommand = Text,
                    CmdId = cmdId,
                    BookId = BookId,
                    Result = result
                };
                if (Content.VehiclePlate != "")
                {
                    //Nếu là xe Car thì gửi cho bên Car
                    if(CommonBL.DictDriver.ContainsKey(privateCode))
                    {
                        if(CommonBL.DictDriver[privateCode].SystemType == Enum_SystemType.Car)
                        {
                            isContract = true;
                        }
                    }
                    Task.Factory.StartNew(() =>
                        {
                            if (isContract)
                            {
                                if (Content.CmdId == 0)
                                {
                                    return WCFServicesAppXHD.SendText(Content.VehiclePlate, Content.TextCommand, Content.BookId);
                                }
                                else
                                    return WCFServicesAppXHD.SendOperatorCmd(Content.VehiclePlate, Content.BookId, Content.CmdId, Content.TextCommand, Content.Result);
                            }
                            else
                            {
                                if (Content.CmdId == 0)
                                    return WCFServicesApp.SendText(Content.VehiclePlate, Content.TextCommand, Content.BookId);
                                else
                                    return WCFServicesApp.SendOperatorCmd(Content.VehiclePlate, Content.BookId, Content.CmdId, Content.TextCommand, Content.Result);
                            }
                        }).ContinueWith(x =>
                                        {
                                            if (x.Result == false)
                                            {
                                                if (MessageBox.Show("Lỗi gửi lệnh cho lái xe, Vui lòng gửi lại", "Thông báo",
                                                    MessageBoxButtons.RetryCancel,
                                                    MessageBoxIcon.Warning,
                                                    MessageBoxDefaultButton.Button1) == DialogResult.Retry)
                                                {
                                                    SendText(privateCode, Text, BookId, idCuocGoi, userId, isContract, cmdId, Content.Result);
                                                }
                                            }
                                        });
                    
                    var history = new T_TaxiOperation_SendCommand()
                    {
                        BookId = Content.BookId,
                        CommandID = Content.CmdId,
                        CommandText = Content.TextCommand,
                        CreatedBy = userId,
                        IdCuocGoi = idCuocGoi,
                        PrivateCode = privateCode,
                        Result = false
                    };
                    history.Insert();
                }
            }
            catch (Exception ex)
            {
                if(MessageBox.Show("Lỗi gửi lệnh cho lái xe, Vui lòng gửi lại","Thông báo", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
                {
                    SendText(privateCode, Text, BookId, idCuocGoi, userId, isContract, cmdId = 0, result);
                }
                LogError.WriteLogError("SendText:", ex);
            }
        }

       
        /// <summary>
        /// Mời khách
        /// </summary>
        /// <param name="BookId">BookId</param>
        /// <param name="vehicle">Biển Số</param>
        /// <param name="result">Kết quả</param>
        /// <param name="msg">Thông báo</param>
        /// <param name="isContract">Xe hợp đồng</param>
        public static void SendACKInvite(Guid BookId, string vehicle, bool result, string msg, bool isContract)
        {
            if (isContract)
            {
                Task.Factory.StartNew(() =>
                {
                    return WCFServicesAppXHD.SendText(CommonBL.ConvertSangBienSo(vehicle), msg, BookId);
                });
            }
            else
            {
                BackgroupActionServer(p =>
                {
                    var Content = new SendTextContext
                        {
                            BookId = BookId,
                            VehiclePlate = CommonBL.ConvertSangBienSo(vehicle),
                            TextCommand = msg,
                            Result = result
                        };

                    p.SendACKInvite(Content);
                }, "Mời khách");
            }
        }    
        #endregion

        #region ==== 6.Ping ====
        public static Enum_G5_Ping PingServer;

        public static Enum_G5_Ping PingServer_XHD;
        public static Enum_G5_Ping Ping()
        {
            try
            {
                if (Config_Common.CoDieuApp)
                {
                    if (WCFServicesApp.IsOperatorClientConnecting())
                    {
                        PingServer = Enum_G5_Ping.PingSu;
                    }
                    else
                        PingServer = Enum_G5_Ping.PingFail;
                }
                if (Config_Common.App_DieuXeHopDong)
                {
                    if (WCFServicesAppXHD.IsOperatorClientConnecting())
                    {
                        PingServer_XHD = Enum_G5_Ping.PingSu;
                    }
                    else
                        PingServer_XHD = Enum_G5_Ping.PingFail;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("G5_Ping:", ex);
                PingServer = Enum_G5_Ping.PingNotConenct;
                PingServer_XHD = Enum_G5_Ping.PingNotConenct;
            }
            return PingServer;
        }
        #endregion

        #region ==== 7.SendWrongCustomer ====
        /// <summary>
        /// Gửi khách lên nhầm xe cho server
        /// </summary>
        public static void SendWrongCustomer(Guid bookId, string privateCode, bool isContract)
        {
            if (isContract)
            {
                Task.Factory.StartNew(() =>
                {
                    return WCFServicesAppXHD.SendWrongCustomer(bookId, CommonBL.ConvertSangBienSo(privateCode));
                });
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    return WCFServicesApp.SendWrongCustomer(bookId, CommonBL.ConvertSangBienSo(privateCode));
                });
            }
        }
        #endregion

        #region ==== SendOperatorDispatched ====
        /// <summary>
        /// Gửi xe nhận cho app KH
        /// </summary>
        public static void SendOperatorDispatched(Guid bookId, string privateCode, bool isContract)
        {
            if (isContract)
            {
                Task.Factory.StartNew(() =>
                {
                    return WCFServicesAppXHD.SendOperatorDispatched(bookId, CommonBL.ConvertSangBienSo(privateCode));
                });
            }
            else
            {
                BackgroupActionServer(p => p.SendOperatorDispatched(bookId, CommonBL.ConvertSangBienSo(privateCode)), "Gửi xe nhận cho app KH");
            }
        }
        #endregion

        #region ==== SendOperatorDispatched ====
        /// <summary>
        /// Gửi server để hỏi xem cuốc có chuyển đàm dc không.
        /// ACK sẽ quyết định chuyển đàm hay ko
        /// </summary>
        public static void SendAskBook(Guid bookId, bool isContract)
        {
            if (isContract)
            {
                Task.Factory.StartNew(() =>
                {
                    return WCFServicesAppXHD.SendAskBook(bookId);
                });
            }
            else
            {
                BackgroupActionServer(p => p.SendAskBook(bookId), "Hỏi trước khi chuyển đàm");
            }
        }
        #endregion

        #region SMS

        #endregion
        #endregion

        #region ==== Function ====

        #region===== Copy ========
        /// <summary>
        /// Sao Chép Cuốc Gọi
        /// </summary>
        /// <param name="idCuocGoi">Id Cuốc Gọi</param>
        /// <param name="soluong">Số lượng cuốc</param>
        /// <param name="G5Type">Kiểu điều cuốc</param>
        public static void CopyCuocGoi(long idCuocGoi, int soluong, Enum_G5_Type G5Type)
        {
            BackgroupActionServer(p =>
            {
                for (int i = 0; i < soluong; i++) // Copy theo số lượng.
                {
                    CuocGoi.G5_DIENTHOAI_CopyCuocGoi(idCuocGoi, G5Type);
                }
            },"Sao Chép Cuốc Gọi");
        }
        #endregion
        /// <summary>
        /// Cập nhật thói quen khách hàng đi.
        /// </summary>
        public static void CustomerHabitUpdate(string PhoneNumber, string Address, DateTime CallDate)
        {
            BackgroupAction(() =>
            {
                int days= 1+(int)CallDate.DayOfWeek;
                CustomerHabits.Update(PhoneNumber, days, CallDate.TimeOfDay, Address);
            }, "CustomerHabitUpdate");
        }
        #endregion
        //public static void SendServer(IServerFunction func, int cmdId, string cmdMsg, Guid bookId, string xeNhan)
        //{
        //    switch (func)
        //    {
        //        case IServerFunction.OperatorCancel:
        //            SendOperatorCancel(bookId, LoaiCuocKhach.ChoKhachNoiTinh, cmdMsg);
        //            break;
        //        case IServerFunction.ConfirmDone:
        //            SendConfirmDone(bookId, cmdMsg);
        //            break;
        //        case IServerFunction.SendText:
        //            SendText(xeNhan, cmdMsg, bookId, 0, "",false, cmdId);
        //            break;
        //        case IServerFunction.WrongCustomer:
        //            SendWrongCustomer(bookId, xeNhan, false);
        //            break;
        //        case IServerFunction.ACKInvite:
        //            SendACKInvite(bookId, xeNhan, true, cmdMsg, false);
        //            break;
        //    }
        //}
    }
}
