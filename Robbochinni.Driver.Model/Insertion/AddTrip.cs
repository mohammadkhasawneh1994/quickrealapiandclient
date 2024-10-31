using Robbochinni.Driver.Mag.Enums;
using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Mag.Insertion
{
    public record AddTrip(Location? Pickup,
                          Location? DropOff,
                          Guid? Client,
                          Guid? Driver,
                          TripState? State,
                          DateTime? ArrivedAt,
                          DateTime? ConfirmedAt,
                          DateTime? FinishedAt,
                          DateTime? CancelledAt,
                          string? Code);

    public record AddRequest(Location? Pickup,
                             Location? DropOff,
                             Guid? Client);
}
