namespace Robbochinni.Driver.Mag.Enums
{
    public enum TripState
    {
        New, //IssuedByUser
        ConfirmedByDriver, //DriverAcceptedRequest
        Arrived, //CodeConfirmed
        Cancelled, //UserOrDriverCancelled
        Finished, //PaymentCompleted
        All //All Orders
    }

    public enum RideType
    {
        Lemo,
        Passenger
    }
}
