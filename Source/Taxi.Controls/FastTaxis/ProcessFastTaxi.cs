using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using Taxi.Business;
using Taxi.Business.DM;
using Taxi.Controls.FastTaxis.FormFastTaxi;
using Taxi.Services;
using Taxi.Services.FastTaxi_OperationService;
using Taxi.Utils.Enums;
using TaxiOperation_TongDai;
using Taxi.Controls.FastTaxis.TaxiChieuVe;
using System.ComponentModel;
using System.Net.Sockets;
using Taxi.Common.Extender;
using System.Diagnostics;
using System.Text;
using Taxi.Utils;
namespace Taxi.Controls.FastTaxis
{
    #region class ProcessFastTaxi
    /// <summary> 
    /// Class viết xử lý chung cho các messge gửi tới FT
    /// </summary>
    public class ProcessFastTaxi
    {    
        #region Các thành phần FastTaxi

        public static string TitleLog;
        public static bool Debug = true;
        public static bool ketThuc = false;
        /// <summary>
        /// Hàng đợi xử lý gửi thông tin gửi cho fastTaxi
        /// </summary>
        private static ConcurrentQueue<SendFastTaxiData> queueFastTaxi = new ConcurrentQueue<SendFastTaxiData>();
        /// <summary>
        /// Hàng đợi xử lý gửi thông tin gửi cho fastTaxi đã thất bại
        /// </summary>
        private static ConcurrentQueue<SendFastTaxiData> queueFastTaxiFail = new ConcurrentQueue<SendFastTaxiData>();

        private static BackgroundWorker bwFastTaxiProcess = new BackgroundWorker();
        private static BackgroundWorker bwFastTaxiProcess_Fail = new BackgroundWorker();
        private static bool isStop = false;
        public static void DoFastTaxi()
        {
            //if (Debug)
            //{
            //    frmlog.Text = TitleLog; 
            //    frmlog.Show();
            //}
            isStop = true;
            bwFastTaxiProcess.DoWork += bwFastTaxiProcess_DoWork;
            bwFastTaxiProcess.RunWorkerAsync();

            bwFastTaxiProcess_Fail.DoWork += bwFastTaxiProcess_Fail_DoWork;
            bwFastTaxiProcess_Fail.RunWorkerAsync();

           // new Thread(SendFastTaxi_Process).Start();
          //  new Thread(SendFastTaxiFail_Process).Start();
            //var timer = new System.Windows.Forms.Timer {Enabled = true, Interval = 1000};
            //timer.Tick += timer_Tick;
            //timer.Start();
            // bwSync_SendFastTaxiCuocGoi.DoWork += bwSync_SendFastTaxiCuocGoi_DoWork;
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            if (ketThuc) ((System.Windows.Forms.Timer) sender).Stop();
            if (!bwFastTaxiProcess.IsBusy)
            {
                bwFastTaxiProcess.RunWorkerAsync();
            }
        }

        private static void bwFastTaxiProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                SendFastTaxiData data;
                if (queueFastTaxi.TryDequeue(out data))
                {
                    try
                    {
                        SendDataFastTaxi(data);
                    }
                    catch (Exception ex)
                    {
                        //new Log().WriteLog(ThongTinDangNhap.USER_ID, "SendFastTaxi_Process", DateTime.Now, ex.Message);
                        LogError.WriteLogError("SendFastTaxi_Process", ex);
                    }
                }
                Thread.Sleep(30);
            }
        }

        private static void bwFastTaxiProcess_Fail_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                SendFastTaxiData data;
                if (queueFastTaxiFail.TryDequeue(out data))
                {
                    try
                    {
                        var frm = new frmPopupSendFastTaxiFail { Data = data };
                        frm.GuiLaiFastTaxi += frm_GuiLaiFastTaxi; frm.Show();
                    }
                    catch (Exception ex)
                    {
                        //new Log().WriteLog(ThongTinDangNhap.USER_ID, "bwFastTaxiProcess_Fail_DoWork", DateTime.Now, ex.Message);
                        LogError.WriteLogError("bwFastTaxiProcess_Fail_DoWork", ex);
                    }
                }
                Thread.Sleep(30);
            }
        }

       // private static frmLogDebug frmlog = new frmLogDebug();
        #region Không dùng
        ///// <summary>
        ///// Xử lý gửi fastTaxi
        ///// </summary>
        //private BackgroundWorker bwSync_SendFastTaxiCuocGoi = new BackgroundWorker();
        ///// <summary>
        ///// Sự kiện thực hiện 1 công việc
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void bwSync_SendFastTaxiCuocGoi_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var fast = e.Argument as SendFastTaxiData;
        //    if (fast!=null)
        //        queueFastTaxi.Enqueue(fast);
        //}
        #endregion

        /// <summary>
        /// luôn thực hiện kiểm tra có công việc nào cần thực hiện để thực hiện
        /// </summary>
        private static void SendFastTaxi_Process()
        {
            if (ketThuc == true) return;
            while (ketThuc == false)
            {
                SendFastTaxiData data;
                if (queueFastTaxi.TryDequeue(out data))
                {
                    try
                    {
                        SendDataFastTaxi(data);
                    }
                    catch (Exception ex)
                    {
                        //new Log().WriteLog(ThongTinDangNhap.USER_ID, "SendFastTaxi_Process", DateTime.Now, ex.Message);
                        LogError.WriteLogError("SendFastTaxi_Process", ex);
                    }
                }
                Thread.Sleep(30);
            }
        }

        private static void SendFastTaxiFail_Process()
        {
            if (ketThuc == true) return;
            while (ketThuc == false)
            {
                SendFastTaxiData data;
                if (queueFastTaxiFail.TryDequeue(out data))
                {
                    try
                    {
                      
                        var frm = new frmPopupSendFastTaxiFail {Data = data};
                        frm.GuiLaiFastTaxi += frm_GuiLaiFastTaxi;new Thread(frm.Show).Start();
                    }
                    catch (Exception ex)
                    {
                        //new Log().WriteLog(ThongTinDangNhap.USER_ID, "SendFastTaxi_Process", DateTime.Now, ex.Message);
                        LogError.WriteLogError("SendFastTaxiFail_Process", ex);
                    }
                }
                Thread.Sleep(30);
            }
        }

        /// <summary>
        /// Thực hiện thêm vào hàng đợi để xử lý
        /// </summary>
        /// <param name="data"></param>
        static void frm_GuiLaiFastTaxi(SendFastTaxiData data)
        {
            data.GuiLai = true;
            queueFastTaxi.Enqueue(data);
        }

        /// <summary>
        /// Thực hiện gửi từng bảng ghi cho fastTaxi
        /// </summary>
        /// <param name="fast"></param>
        private static void SendDataFastTaxi(SendFastTaxiData fast)
        {
            if (fast != null)  
            {
                //if (Debug && !frmlog.Visible)
                //{
                //    frmlog.ShowForm();
                //}
                //if (Debug) frmlog.WriteLog(fast.IdCuocGoi, fast.Msg, fast.Content, "Bắt đầu gửi" + (fast.GuiLai ? " Gửi lại" : ""));
                var flg = false;
                var soLan = 0;
                var thuchien = false;
                try
                {do
                    {
                        try
                        {
                            flg = fast.Func();
                            thuchien = true;
                        }
                        catch(Exception ex)
                        {                            
                            flg = false;
                            //new Log().WriteLog(ThongTinDangNhap.USER_ID, "RefreshServerFastTaxi", DateTime.Now, "ID:"+fast.IdCuocGoi.ToString()+" - Số lần:"+soLan.ToString());
                            LogError.WriteLogError("SendDataFastTaxi", ex);
                        }
                        soLan++;
                        if (!thuchien&&soLan < 5) Thread.Sleep(1);
                        else
                        {
                           // thuchien = true;
                        }
                    } while (!thuchien && soLan < 5);
                }
                catch(Exception ex)
                {
                    //LogError.WriteLogError("SendDataFastTaxi", ex);
                    //new Log().WriteLog(ThongTinDangNhap.USER_ID, "bwSync_SendFastTaxiCuocGoi_DoWork", DateTime.Now, "fast==null");
                    LogError.WriteLogError("SendDataFastTaxi 2", ex);
                    flg = false;
                }
                finally
                {
                    //if (Debug && !frmlog.Visible)
                    //{
                    //    frmlog.ShowForm();
                    //}
                    //if (Debug) frmlog.WriteLog(fast.IdCuocGoi, fast.Msg, fast.Content, "Kq:" + (flg ? "Thành công" : "Thất bại") + ";" + "TH:" + (thuchien ? "Được" : "Không"));
                    CuocGoi.FT_History_Create((int)fast.IdCuocGoi, fast.Content, (int)fast.Status, flg);
                    if (!thuchien) queueFastTaxiFail.Enqueue(fast);
                }
            }
            else
            {
                LogError.WriteLogErrorForDebug("SendDataFastTaxi null");
                //new Log().WriteLog(ThongTinDangNhap.USER_ID, "bwSync_SendFastTaxiCuocGoi_DoWork", DateTime.Now, "xảy ra lỗi khi gửi dữ liệu");
            }
        }

        #region SendFastTaxi
        /// <summary>
        /// Tạo công việc thực hiện chạy nền. 
        /// </summary>
        public static void SendFastTaxi(CuocGoi cuocGoiRow, Enum_FastTaxi_Status status)
        {
            if (!cuocGoiRow.FT_IsFT) return; 
            #region Ini
            Func<bool> func = () => false;
            string content = string.Empty;
            string msg=string.Empty;
            #endregion

            switch (status)
            {
                    #region Chuyển sang đàm
                    case Enum_FastTaxi_Status.ChuyenSangDam:
                        //Trạng thái cập nhật dữ liệu
                        func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterSigningCar(cuocGoiRow.PhoneNumber,cuocGoiRow.FT_ID));
                        //“[Địa chỉ đón]-[Địa chỉ trả]-[SL xe]-[Loại xe]”
                        content = string.Format("{0}-{1}-{2}-{3}", cuocGoiRow.DiaChiDonKhach,
                                                                cuocGoiRow.DiaChiTraKhach,
                                                                cuocGoiRow.SoLuong,
                                                                cuocGoiRow.LoaiXe);
                        msg = "Chuyển sang đàm";
                    break;
                    #endregion

                    #region Tiếp nhận hủy
                    case Enum_FastTaxi_Status.TiepNhanHuy:
                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterOperationCancel(cuocGoiRow.PhoneNumber, cuocGoiRow.FT_ID));
                            //“[Địa chỉ đón]”
                        content = string.Format("{0}", cuocGoiRow.DiaChiDonKhach);
                        msg = "Tiếp nhận hủy";
                    break;
                    #endregion

                    #region Mời khách
                    case Enum_FastTaxi_Status.MoiKhach: //Mời khách
                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterCatchingCar(cuocGoiRow.PhoneNumber, cuocGoiRow.FT_ID));
                        content = string.Format("{0}-{1}-{2}-{3}-{4}", cuocGoiRow.DiaChiDonKhach, cuocGoiRow.DiaChiTraKhach,
                        cuocGoiRow.SoLuong, cuocGoiRow.LoaiXe, cuocGoiRow.XeNhan);
                        msg = "Mời khách";
                    break;
                    #endregion
                
                    #region không xe
                    case Enum_FastTaxi_Status.KhongXe://không xe
                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Enum_TaxiOperation_CallStatus.KhongXe, cuocGoiRow.FT_ID));
                        content = "Không xe";
                        msg = "Không xe";
                    break;
                    #endregion

                    #region Không xe,Đã xin lỗi khách
                    case Enum_FastTaxi_Status.KhongXe_DaXinLoi://Không xe,Đã xin lỗi khách
                        status = Enum_FastTaxi_Status.KhongXe;
                        func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Enum_TaxiOperation_CallStatus.KhongXe, cuocGoiRow.FT_ID));
                        content = string.Format("Không xe,Đã xin lỗi khách");
                        msg = "Không xe,Đã xin lỗi khách";
                    break;
                    #endregion

                    #region Nhập xe nhận
                    case Enum_FastTaxi_Status.NhapXeNhan://Nhập xe nhận

                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterSignedCar(cuocGoiRow.PhoneNumber, GetCarOnline(cuocGoiRow.XeNhan.Trim()), cuocGoiRow.FT_ID));
                        content = string.Format("{0}-{1}-{2}-{3}-{4}", cuocGoiRow.DiaChiDonKhach, cuocGoiRow.DiaChiTraKhach, cuocGoiRow.SoLuong, cuocGoiRow.LoaiXe, cuocGoiRow.XeNhan);
                        msg = "Nhập xe nhận";
                    break;
                    #endregion

                    #region Nhập xe đến điểm
                    case Enum_FastTaxi_Status.NhapXeNhan_XeDenDiem://Nhập xe nhận
                    
                    func = () =>
                    {
                        try
                        {
                            Service_Common.FastTaxi.Try(client => client.SendToMasterSignedCar(cuocGoiRow.PhoneNumber, GetCarOnline(cuocGoiRow.XeDenDiem.Trim()), cuocGoiRow.FT_ID));
                            Thread.Sleep(5000);
                            Service_Common.FastTaxi.Try(client => client.SendToMasterCatchingCar(cuocGoiRow.PhoneNumber, cuocGoiRow.FT_ID));
                          
                            return true;
                        }
                        catch (Exception ex)
                        {
                            
                            LogError.WriteLogError("NhapXeNhan_XeDenDiem", ex);
                            return false;
                        }
                    };
                    content = string.Format("{0}-{1}-{2}-{3}-{4}", cuocGoiRow.DiaChiDonKhach, cuocGoiRow.DiaChiTraKhach, cuocGoiRow.SoLuong, cuocGoiRow.LoaiXe, cuocGoiRow.XeNhan);
                  
                    msg = "Nhập xe đến điểm";
                    break;
                    #endregion

                    #region Nhập xe đón
                    case Enum_FastTaxi_Status.NhapXeDon: //Nhập xe đón
                    string xeDon = string.Empty;
                    if (cuocGoiRow.XeDon.Trim()!="")
                        xeDon = cuocGoiRow.XeDon.Trim();//.Split('.').Select(int.Parse).ToArray();
                     
                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingDone(cuocGoiRow.PhoneNumber, GetCarOnline(xeDon), cuocGoiRow.FT_ID));    
                        //“[Địa chỉ đón]-[Địa chỉ trả]-[SL xe]-[Loại xe]-[Xe nhận]”
                        content = string.Format("{0}-{1}-{2}-{3}-{4}",
                                            cuocGoiRow.DiaChiDonKhach,
                                            cuocGoiRow.DiaChiTraKhach,
                                            cuocGoiRow.SoLuong,
                                            cuocGoiRow.LoaiXe,
                                            cuocGoiRow.XeDon);
                        msg = "Nhập xe đón";
                                        break;
                    #endregion

                    #region Trượt
                    case Enum_FastTaxi_Status.Truot:
                                        func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Enum_TaxiOperation_CallStatus.Truot, cuocGoiRow.FT_ID));
                        content = "Trượt";
                        msg = "Trượt";
                    break;
                    #endregion

                    #region Hoãn
                    case Enum_FastTaxi_Status.Hoan:
                    func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Enum_TaxiOperation_CallStatus.Hoan, cuocGoiRow.FT_ID));
                        content = "Hoãn";
                        msg = "Hoãn";
                    break;
                    #endregion

                    #region Đã Hoãn
                    case Enum_FastTaxi_Status.Hoan_DaHoan:
                        status = Enum_FastTaxi_Status.Hoan;
                        func = () => Service_Common.FastTaxi.Try(client =>client.SendToMasterBookingFail(cuocGoiRow.PhoneNumber, string.Empty, Enum_TaxiOperation_CallStatus.Hoan, cuocGoiRow.FT_ID));
                        content = "Đã Hoãn";
                        msg = "Đã Hoãn";
                    break;
                    #endregion
            }

            #region Thực hiện kiểm tra và đưa vào hàng đợi để xử lý
            if (content != string.Empty)
            {
              var fasttaxi = new SendFastTaxiData
                {
                    Func = func,
                    IdCuocGoi = cuocGoiRow.IDCuocGoi,
                    Content = content,
                    Status = status,
                    Msg=msg
                    ,PhoneNumber=cuocGoiRow.PhoneNumber,
                    DiaChiDon=cuocGoiRow.DiaChiDonKhach,
                    XeDon=cuocGoiRow.XeDon,
                    XeNhan=cuocGoiRow.XeNhan
                };
                //đưa vào hàng đợi xử lý
                queueFastTaxi.Enqueue(fasttaxi);//  bwSync_SendFastTaxiCuocGoi.RunWorkerAsync(fasttaxi);
            }
            #endregion
        }
        #endregion

        private static CarOnline[] GetCarOnline(string sohieuxe)
        {
            string[] arrSoHieuXe = sohieuxe.Split('.');
            CarOnline[] lstCarOnline = new CarOnline[arrSoHieuXe.Length];
            int XNCODE = ThongTinCauHinh.CompanyID;
            for (int i = 0; i < arrSoHieuXe.Length; i++)
            {
                if (Vehicles_GPS!= null && Vehicles_GPS.ContainsKey(arrSoHieuXe[i]))
                {
                    lstCarOnline[i] = new CarOnline() { CarNo = arrSoHieuXe[i], VehiclePlate = Vehicles_GPS[arrSoHieuXe[i]], XNCode = XNCODE };
                }
                else
                {
                    lstCarOnline[i] = new CarOnline() { CarNo = arrSoHieuXe[i], VehiclePlate = "", XNCode = XNCODE };
                }
            }
            return lstCarOnline;
        }


        private static Dictionary<string, string> _Vehicles_GPS;

        /// <summary>
        /// Danh sách số xe và biển số
        /// </summary>
        public static Dictionary<string, string> Vehicles_GPS
        {
            get;
            set;
        }


        /// <summary>
        /// Lấy về danh sách biển số xe dựa trên biển số.
        /// </summary>
        /// <param name="privateCodes">The private codes.</param>
        /// <returns></returns>
        /// <Modified>
        /// Name     Date         Comments
        /// LuanBH  7/30/2015   created
        /// </Modified>
        public static string GetVehiclePlatesFromPrivateCode(string privateCodes, string seperator)
        {
            if (string.IsNullOrEmpty(privateCodes)) return string.Empty;

            //if(Global.KhongCheckXeOnline)
            //{
            //    return privateCodes;
            //}

            string[] arrSoHieuXe = privateCodes.Split(seperator.ToCharArray());
            string[] arrBienSoXe = new string[arrSoHieuXe.Length];
            var count = 0;
            for (int i = 0; i < arrSoHieuXe.Length; i++)
            {

                if (TaxiApplication.ServiceEnVang.EnVangProcess.Vehicles_Dict.ContainsKey(arrSoHieuXe[i]))
                {
                    arrBienSoXe[count] = TaxiApplication.ServiceEnVang.EnVangProcess.Vehicles_Dict[arrSoHieuXe[i]];
                    count++;
                }
                //if (Vehicles_GPS != null && Vehicles_GPS.ContainsKey(arrSoHieuXe[i]))
                //{
                //    arrBienSoXe[count] = Vehicles_GPS[arrSoHieuXe[i]];
                //    count++;
                //}
            }
            return String.Join(seperator, arrBienSoXe);
        }

        /// <summary>
        /// Get Danh sách số xe và biển số
        /// </summary> 
        public static void GetVehicleGPS()
        {
            try
            {
                if (!ThongTinCauHinh.GPS_TrangThai) return;
                // Vehicles_GPS = WCFService_Common.WCFServiceClient.GetVehicles();
                if (Vehicles_GPS == null) Vehicles_GPS = new Dictionary<string, string>();

                var newVehicles_GPS = WCFService_Common.GetVehicles();

                newVehicles_GPS.SLeftJoin(Vehicles_GPS, nvo => nvo.Key, vo => vo.Key, (nvo, vo) =>
                {
                    if (nvo.Value != vo.Value)
                        Vehicles_GPS[nvo.Key] = nvo.Value;
                }, nvo =>
                {
                    Vehicles_GPS.Add(nvo.Key, nvo.Value);
                });
            }
            catch (Exception ex)
            {
                LogError.WriteLogError(ex.Message, ex);
            }
            
        }
        #endregion

        #region ---- Các hàm Sử dụng ------

        public static float TinhQuangDuong(float start_lat, float start_lng, float end_lat, float end_lng)
        {
            return TaxiReturn_Process.LayLoTrinh(start_lat, start_lng, end_lat, end_lng).Distance;
        }

        public static void WriteLog(string name, string Content,string status,int rs=-1)
        {
            //if (Debug && !frmlog.Visible)
            //{
            //    frmlog.ShowForm();
            //}
            //if (Debug) frmlog.WriteLog(rs, name, Content, status);
        }
        #endregion
    }
    #endregion

    public static class ListExtender
    {
        public static void SLeftJoin<T1, T2, T>(this IEnumerable<T1> listNews, IEnumerable<T2> listOlds, Func<T1, T> ex1, Func<T2, T> ex2, Action<T1, T2> map, Action<T1> notmap)
        {
            (from vi_new in listNews
             join vi_old in listOlds on ex1(vi_new) equals ex2(vi_old) into vi_old_
             from vi_old_item in vi_old_.DefaultIfEmpty()
             select new { vi_new, vi_old_item }).Where(o =>
             {
                 if (o.vi_old_item == null) return true;
                 else
                 {
                     map(o.vi_new, o.vi_old_item);
                     return false;
                 }
             }).ToList().Select(o =>
             {
                 notmap(o.vi_new);
                 return false;
             }).Count();
        }
    }

    #region Class SendFastTaxiData
    /// <summary>
    /// Class đóng gói những thông tin cần xử lý gửi đi.
    /// </summary>
    public class SendFastTaxiData
    {

        /// <summary>
        /// Hàm cần sử dụng gửi
        /// </summary>
        public Func<bool> Func { get; set; }
        /// <summary>
        /// ID cuốc gọi
        /// </summary>
        public long IdCuocGoi { get; set; }
        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public Enum_FastTaxi_Status Status { get; set; }
        /// <summary>
        /// messga gửi cần hiển thị khi buge
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// Thực hiện gửi lại
        /// </summary>
        public bool GuiLai { get; set; }
        public string PhoneNumber { get; set; }
        public string DiaChiDon { get; set; }
        public string XeDon { get; set; }
        public string XeNhan { get; set; }

    }
    #endregion
}
