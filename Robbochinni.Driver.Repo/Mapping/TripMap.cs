using Mapster;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Mapping
{
    internal class TripMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddTrip, Trip>()
                .Map(dest => dest.From, src => src.Pickup)
                .Map(dest => dest.To, src => src.DropOff)
                .Map(dest => dest.RequesterId, src => src.Client!)
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.ArrivingDate, src => src.ArrivedAt)
                .Map(dest => dest.CancellationDate, src => src.CancelledAt)
                .Map(dest => dest.ConfirmationDate, src => src.ConfirmedAt)
                .Map(dest => dest.FinishingDate, src => src.FinishedAt)
                .Map(dest => dest.DriverId, src => src.Driver)
                .Map(dest => dest.ConfirmationCode, src => src.Code!)
                .IgnoreNullValues(true);

            config.NewConfig<Trip, TripInfo>()
                .Map(dest => dest.PickUp, src => src.From)
                .Map(dest => dest.DropOff, src => src.To)
                .Map(dest => dest.UserId, src => src.RequesterId!)
                .Map(dest => dest.State, src => src.State!)
                .Map(dest => dest.Date, src => src.CreateDate.ToString("dd-MM-yyyy")!)
                .Map(dest => dest.UserName, src => src.Requester!.FullName);
        }
    }
}
