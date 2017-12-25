using System;
using System.Collections.Generic;
using Taxi.Services.ServiceG5;

namespace Taxi.Services.Operations.Inferfaces
{
    public interface IServiceOperation
    {
        //bool InitTrip(TripOperation trip, BookTripType tripType);
        bool SendOperatorCancel(GuidMsg msg);
        bool SendOperatorCatched(Guid bookId);
        bool SendConfirmDone(GuidMsg msg);
        bool SendConfirmDoneBook(Guid bookId, string vehiclePlate, EnumConfirmDoneBook state);
        bool SendText(SendTextContext Content);
        bool SendACKInvite(SendTextContext Content);
        bool IsOperatorClientConnecting();
        bool SendWrongCustomer(Guid BookId, string VehiclePlate);
        bool SendOperatorDispatched(Guid BookId, string VehiclePlate);
        bool SendAskBook(Guid BookId);

        OneTaxiCar[] FindCar(int carType, float lat, float lng);
    }
}
