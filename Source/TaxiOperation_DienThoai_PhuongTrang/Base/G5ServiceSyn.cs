using System;
using System.ComponentModel;
using System.Threading;
using Taxi.Business;
using Taxi.Services;
using Taxi.Services.ServiceG5;
using Taxi.Utils;

namespace TaxiApplication.Base
{
    /// <summary>
    /// Thực hiện lệnh lái xe.
    /// </summary>
    public class G5ServiceSyn
    {
        #region =========== InitTrip ===========
        //public static bool InitTrip(Guid bookId, long idCuocKhach,string diaChiDon, float gpsDonKd, float gpsDonVd, string diaChiTra, float gpsTraKd,
        //    float gpsTraVd, string note, byte quantity, string carTypes, byte customerType, string phone, LatLng currentLatLng,BookTripType tripType, int money)
        //{
        //    //Địa chỉ đón
        //    var from = new AddressInfo()
        //    {
        //        Address = diaChiDon,
        //        Name = diaChiDon,
        //        LatLng = new LatLng() { Lat = gpsDonVd, Lng = gpsDonKd }
        //    };
        //    //Địa chỉ trả
        //    var to = new AddressInfo
        //    {
        //        Address = diaChiTra,
        //        Name = diaChiTra,
        //        LatLng = new LatLng(){Lat = gpsTraVd,Lng = gpsTraKd}
        //    };
        //    // Danh sách xe đề cử
        //    var vehicleOptions = new List<VehicleOption>();
        //    //if (!string.IsNullOrEmpty(cuocGoi.DanhSachXeDeCu))
        //    //{
        //    //    var ds=cuocGoi.DanhSachXeDeCu.Split('.');
        //    //    foreach (var s in ds)
        //    //    {
        //    //        var vehicle= new VehicleOption();
        //    //        vehicle.Vehicle = s;// Biển số(viết tạm số hiệu xe)
        //    //        vehicle.Distance = 0;// Khoảng cách
        //    //        vehicleOptions.Add(vehicle);
        //    //    }
        //    //}
        //    byte carType = 4;
        //    return Service_Common.ServiceG5.TryGet(
        //        p => p.SendInitTrip(bookId, @from, to, note, quantity, carType, customerType, phone, vehicleOptions.ToArray(), currentLatLng, null, tripType, money)).Value;
        //}

        public static void InitTripSyn(long idCuocKhach, string diaChiDon, float gpsDonKd, float gpsDonVd, string diaChiTra,
            float gpsTraKd,
            float gpsTraVd, string note, byte quantity, string carType, byte customerType, string phone,
            LatLng currentLatLng,int SoLuong=0,bool isCopy=false)
        {
            var trip = new Trip
            {
                IdCuocKhach = idCuocKhach,
                DiaChiDon = diaChiDon,
                GPSDonKD = gpsDonKd,
                GPSDonVD = gpsDonVd,
                DiaChiTra = diaChiTra,
                GPSTraKD = gpsTraKd,
                GPSTraVD = gpsTraVd,
                Note = note,
                Quantity = quantity,
                CarType = carType,
                CustomerType = customerType,
                Phone = phone,
                CurrentLatLng = currentLatLng,
                SoLuong = SoLuong,
                IsCopy=isCopy
            };
            var background= new BackgroundWorker();
            background.DoWork += background_DoWork;
            background.RunWorkerAsync(trip);
         
        }

        static void background_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var trip = e.Argument as Trip;
                if (trip != null)
                {
                    if (trip.CurrentLatLng == null)
                    {
                        trip.CurrentLatLng = new LatLng {Lat = trip.GPSDonVD, Lng = trip.GPSDonKD};
                    }
                    Guid bookId = Guid.NewGuid();

                    CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(bookId, trip.IdCuocKhach, Enum_G5_Type.DieuApp,"");
                   
                    //var done = InitTrip(bookId, trip.IdCuocKhach, trip.DiaChiDon, trip.GPSDonKD, trip.GPSDonVD,
                    //    trip.DiaChiTra, trip.GPSTraKD, trip.GPSTraVD, trip.Note,
                    //    trip.Quantity, trip.CarType, trip.CustomerType, trip.Phone, trip.CurrentLatLng, BookTripType.Normal,0);
                    //if (!done) // Không gửi được lên thì chuyển cuốc điều đàm.
                    //{
                    //    bookId = Guid.Empty;
                    //    CuocGoi.G5_DIENTHOAI_UpdateBookIdByIdCuocGoi(bookId, trip.IdCuocKhach, Enum_G5_Type.ChuyenSangDam, "");
                    //}
                    if (trip.SoLuong>0)
                    CopyCuocGoi1163353336(trip.IdCuocKhach, trip.SoLuong, Enum_G5_Type.DieuApp);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteLogError("Khởi tạo cuốc điều App",ex);
            }
            

        }
        public class Trip
        {
           public long IdCuocKhach { get; set; }
           public string DiaChiDon { get; set; }
           public float GPSDonKD { get; set; }
           public float GPSDonVD { get; set; }
           public string DiaChiTra { get; set; }
           public float GPSTraKD { get; set; }
           public float GPSTraVD { get; set; }
           public string Note { get; set; }
           public byte Quantity { get; set; }
           public string CarType { get; set; }
           public byte CustomerType { get; set; }
           public string Phone { get; set; }
           public LatLng CurrentLatLng { get; set; }
           public int SoLuong { get; set; }
           public bool IsCopy { get; set; }
        }
        #endregion

        #region =========== CatchUser ===========

        public static void SendCatchUserSyn(Guid bookId)
        {
            if (bookId != Guid.Empty) {
                var backgroup = new BackgroundWorker();
                backgroup.DoWork += SendCatchUserSyn_DoWork;
                backgroup.RunWorkerAsync(bookId);
            }
        }

        private static void SendCatchUserSyn_DoWork(object sender, DoWorkEventArgs e)
        {
            var bookId = e.Argument is Guid ? (Guid) e.Argument :Guid.Empty;
            if (bookId != Guid.Empty)
            {
                var rs = Service_Common.ServiceG5.TryGet(p =>
                    p.SendOperatorCatched(bookId));
            }
        }
        #endregion

        #region =========== OperatorCancel ============

        public static void SendOperatorCancel(Guid bookId)
        {
            if (bookId != Guid.Empty)
            {
                var backgroup = new BackgroundWorker();
                backgroup.DoWork += SendOperatorCancelSyn_DoWork;
                backgroup.RunWorkerAsync(bookId);
            }
        }

        private static void SendOperatorCancelSyn_DoWork(object sender, DoWorkEventArgs e)
        {
            var bookId = e.Argument is Guid ? (Guid)e.Argument : Guid.Empty;
            if (bookId != Guid.Empty)
            {
                var rs = Service_Common.ServiceG5.TryGet(p =>
                    p.SendOperatorCancel(bookId,String.Empty, SourceCancelType.Unknown));              
            }
        }
        #endregion

        #region =========== SendConfirmDone ===========

        public static void SendConfirmDone(Guid bookId)
        {
            if (bookId != Guid.Empty)
            {
                var backgroup = new BackgroundWorker();
                backgroup.DoWork += SendConfirmDoneSyn_DoWork;
                backgroup.RunWorkerAsync(bookId);
            }
        }

        private static void SendConfirmDoneSyn_DoWork(object sender, DoWorkEventArgs e)
        {
            var bookId = e.Argument is Guid ? (Guid)e.Argument : Guid.Empty;
            if (bookId != Guid.Empty)
            {
                var rs = Service_Common.ServiceG5.TryGet(p =>
                    p.SendConfirmDone(bookId,true, String.Empty));
            }
        }

        #endregion

        #region===== Copy ========

        public struct cuocSaoChep
        {
            public long IdCuocGoi;
            public int soLuong;
            public Enum_G5_Type G5Type;
        }

        public static void CopyCuocGoi1163353336(long idCuocGoi, int soluong,Enum_G5_Type G5Type)
        {
            var cuocWorker = new BackgroundWorker();
            cuocWorker.DoWork += cuocWorker_DoWork1734803978;
            var soChep= new cuocSaoChep();
            soChep.IdCuocGoi = idCuocGoi;
            soChep.soLuong = soluong;
            soChep.G5Type = G5Type;
            cuocWorker.RunWorkerAsync(soChep);
        }

        static void cuocWorker_DoWork1734803978(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is cuocSaoChep)
            {               
                var copy = (cuocSaoChep)e.Argument ;               
                for (int i = 0; i < copy.soLuong; i++) // Copy theo số lượng.
                {
                    Thread.Sleep(1000);
                    CuocGoi.G5_DIENTHOAI_CopyCuocGoi(copy.IdCuocGoi,copy.G5Type);
                   
                }}
         
        }

        #endregion

        #region ===== SendText ====

        #endregion

        #region ==== Ping ====
        public static Enum_G5_Ping Ping()
        {
            //Service_Common.ServiceG5.TryGet(p => p.IsOperatorClientConnecting());
            
            return Enum_G5_Ping.None;
        }
        #endregion
    }   
}
