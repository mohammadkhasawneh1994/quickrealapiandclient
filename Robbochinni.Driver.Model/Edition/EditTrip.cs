using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Enums;
using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Mag.Edition
{
    public record EditTo(TripState? State);
    public record ConfirmTrip(Guid? Driver);
    public record ArriveTrip(Secret? Code);

    public record EditToConfirmed(Guid? Driver) : IEditTripModel
    {
        public DateTime? ConfirmedAt { get; set; } = DateTime.UtcNow;
        public TripState? State { get; set; } = TripState.ConfirmedByDriver;
    }

    public record EditToArrived(string? Code) : IEditTripModel
    {
        public DateTime? ArrivedAt { get; set; } = DateTime.UtcNow;
        public TripState? State { get; set; } = TripState.Arrived;
    }

    public record EditToCancelled : IEditTripModel
    {
        public DateTime? CancelledAt { get; set; } = DateTime.UtcNow;
        public TripState? State { get; set; } = TripState.Cancelled;
    }

    public record EditToFinished : IEditTripModel
    {
        public DateTime? FinishedAt { get; set; } = DateTime.UtcNow;
        public TripState? State { get; set; } = TripState.Finished;
    }
}
