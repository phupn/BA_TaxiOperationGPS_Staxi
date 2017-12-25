#region ============= Copyright © 2016 BinhAnh =============
using System;
using System.Collections.Generic;
using Taxi.Services.Operations.Inferfaces;
using Taxi.Services.ServiceG5;
using Taxi.Common.Extender;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Services.Operations
{
    public class ServiceOperationG5 : IServiceOperation
    {
        private const string NetTcpBindingG5 = "NetTcpBindingG5";
         public ServiceOperationG5()
        {
            Service = new ConnectService<OperationServiceClient>();
        }
         public ServiceOperationG5(string ServiceConnect)
        {
            Service = new ConnectService<OperationServiceClient>();
            Service.SetClient(new OperationServiceClient(NetTcpBindingG5, ServiceConnect));
        }
        private ConnectService<OperationServiceClient> Service = new ConnectService<OperationServiceClient>();
        //public bool InitTrip(TripOperation trip, BookTripType tripType)
        //{
        //    //Địa chỉ đón
        //    var from = new AddressInfo()
        //    {
        //        Address = trip.DiaChiDon,
        //        Name = trip.DiaChiDon,
        //        LatLng = new LatLng() { Lat = trip.ToaDoDon.Lat, Lng = trip.ToaDoDon.Lng }
        //    };
        //    //Địa chỉ trả
        //    var to = new AddressInfo
        //    {
        //        Address = trip.DiaChiTra,
        //        Name = trip.DiaChiTra,
        //        LatLng = new LatLng() { Lat = trip.ToaDoTra.Lat, Lng = trip.ToaDoTra.Lng }
        //    };
        //    // Danh sách xe đề cử
        //    var vehicleOptions = new List<VehicleOption>();
        //    if (trip.XeDieuChiDinh!=null)
        //    {
        //        foreach (var s in trip.XeDieuChiDinh)
        //        {
        //            var vehicle = new VehicleOption();
        //            vehicle.Vehicle = s.VehicleName;// Biển số
        //            vehicle.Distance = s.Distance;// Khoảng cách
        //            vehicleOptions.Add(vehicle);
        //        }
        //    }

        //    byte carType = 0;
        //    if (trip.CarType == "" || trip.CarType.Split(',').Length > 1)
        //    {
        //        carType = 0;
        //    }
        //    else
        //    {
        //        carType = trip.CarType.To<byte>();
        //    }
        //    var CurrentLatLng = new LatLng();
            

        //    return Service.TryGet(
        //    p => p.SendInitTrip(trip.BookId.Value, @from, to, trip.Note, trip.Quantity, carType, trip.CustomerType, trip.Phone, vehicleOptions.ToArray(), CurrentLatLng, trip.VehiclesDeny, tripType, trip.Money, 0, Direction.One,)).Value;
        //}


        public bool SendOperatorCancel(GuidMsg msg)
        {
            return Service.TryGet(p => p.SendOperatorCancel(msg.BookId, msg.Msg, ServiceG5.SourceCancelType.Unknown)).Value;
        }


        public bool SendOperatorCatched(Guid bookId)
        {
            return Service.TryGet(p => p.SendOperatorCatched(bookId)).Value;
        }


        public bool SendConfirmDone(GuidMsg msg)
        {
            return Service.TryGet(p => p.SendConfirmDone(msg.BookId,msg.Flag, msg.Msg)).Value;
        }


        public bool SendConfirmDoneBook(Guid bookId, string vehiclePlate, EnumConfirmDoneBook state)
        {
            return Service.TryGet(p => p.SendConfirmDoneBook(bookId, vehiclePlate, (ConfirmDoneBook)state)).Value;
        }

        public bool SendText(SendTextContext Content)
        {
            if (Content.CmdId == 0)
                return Service.TryGet(p => p.SendText(Content.VehiclePlate, Content.TextCommand, Content.BookId)).Value;
            else
                return Service.TryGet(p => p.SendOperatorCmd(Content.VehiclePlate, Content.BookId, Content.CmdId, Content.TextCommand,Content.Result)).Value;
        }


        public bool SendACKInvite(SendTextContext Content)
        {
            return false;
          //  return Service.TryGet(p => p.SendACKInvite(Content.BookId, Content.VehiclePlate, Content.Result, Content.TextCommand)).Value;
        }


        public bool IsOperatorClientConnecting()
        {
            return Service.TryGet(p => p.IsOperatorClientConnecting()).Value;
        }

        public bool SendWrongCustomer(Guid bookId, string vehiclePlate)
        {
            return Service.TryGet(p => p.SendWrongCustomer(bookId, vehiclePlate)).Value;
        }

        public bool SendOperatorDispatched(Guid bookId, string vehiclePlate)
        {
            return Service.TryGet(p => p.SendOperatorDispatched(bookId, vehiclePlate)).Value;
        }
        public bool SendAskBook(Guid bookId)
        {
            return Service.TryGet(p => p.SendAskBook(bookId)).Value;
        }

        public OneTaxiCar[] FindCar(int carType, float lat, float lng)
        {
            return Service.TryGet(p => p.FindCar(carType, lat, lng)).Value;
        }
    }
}
