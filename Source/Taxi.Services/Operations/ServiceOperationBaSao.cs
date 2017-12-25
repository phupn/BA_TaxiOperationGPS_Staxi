#region ============= Copyright © 2016 BinhAnh =============
using System;
using Taxi.Services.Operations.Inferfaces;
using Taxi.Common.Extender;
using System.Collections.Generic;
#endregion ============= Copyright © 2016 BinhAnh =============

namespace Taxi.Services.Operations
{
    public  class ServiceOperationBaSao: IServiceOperation
    {
        private const string NetTcpBindingBaSao = "NetTcpBindingBaSao";
        public ServiceOperationBaSao()
        {
            Service = new ConnectService<OperationServiceClient>();
        }
        public ServiceOperationBaSao(string ServiceConnect)
        {
            Service = new ConnectService<OperationServiceClient>();
            Service.SetClient(new OperationServiceClient(NetTcpBindingBaSao, ServiceConnect));
        }
        private ConnectService<OperationServiceClient> Service;
        public bool InitTrip(TripOperation trip)
        {
            //Địa chỉ đón
            var from = new AddressInfo()
            {
                Address = trip.DiaChiDon,
                Name = trip.DiaChiDon,
                LatLng = new LatLng() { Lat = trip.ToaDoDon.Lat, Lng = trip.ToaDoDon.Lng }
            };
            //Địa chỉ trả
            var to = new AddressInfo
            {
                Address = trip.DiaChiTra,
                Name = trip.DiaChiTra,
                LatLng = new LatLng() { Lat = trip.ToaDoTra.Lat, Lng = trip.ToaDoTra.Lng }
            };
            // Danh sách xe đề cử
            var vehicleOptions = new List<VehicleOption>();
            if (trip.XeDieuChiDinh!=null)
            {
                foreach (var s in trip.XeDieuChiDinh)
                {
                    var vehicle = new VehicleOption();
                    vehicle.Vehicle = s.VehicleName;// Biển số
                    vehicle.Distance = s.Distance;// Khoảng cách
                    vehicleOptions.Add(vehicle);
                }
            }

            byte carType = 0;
            if (trip.CarType == "" || trip.CarType.Split(',').Length > 1)
            {
                carType = 0;
            }
            else
            {
                carType = trip.CarType.To<byte>();
            }
            var CurrentLatLng = new LatLng();
            

            return Service.TryGet(
            p => p.SendInitTrip(trip.BookId.Value, @from, to, trip.Note, trip.Quantity, carType, trip.CustomerType, trip.Phone, vehicleOptions.ToArray(), CurrentLatLng)).Value;
        }


        public bool SendOperatorCancel(GuidMsg msg)
        {  
            return Service.TryGet(p => p.SendOperatorCancel(msg.BookId, msg.Msg,(ServiceBaSao.SourceCancelType)msg.TypeMsg)).Value;
        }


        public bool SendOperatorCatched(Guid bookId)
        {
            return Service.TryGet(p => p.SendOperatorCatched(bookId)).Value;
        }


        public bool SendConfirmDone(GuidMsg msg)
        {
            return Service.TryGet(p => p.SendConfirmDone(msg.BookId,msg.Flag, msg.Msg)).Value;
        }


        public bool SendText(SendTextContext Content)
        {
            if (Content.CmdId == 0 || Content.BookId == Guid.Empty || Content.BookId == null)
                return Service.TryGet(p => p.SendText(Content.VehiclePlate, Content.TextCommand)).Value;
            else
                return Service.TryGet(p => p.SendOperatorCmd(Content.VehiclePlate, Content.BookId, Content.CmdId, Content.TextCommand,Content.Result)).Value;
        }


        public bool SendACKInvite(SendTextContext Content)
        {
           return Service.TryGet(p => p.SendACKInvite(Content.BookId, Content.VehiclePlate, Content.Result, Content.TextCommand)).Value;
        }

        public bool IsOperatorClientConnecting()
        {
            return Service.TryGet(p => p.IsOperatorClientConnecting()).Value;
        }


        public bool SendWrongCustomer(Guid BookId, string VehiclePlate)
        {
            return Service.TryGet(p => p.SendWrongCustomer(BookId, VehiclePlate)).Value;
        }
    }
}
