using Robbochinni.Driver.Mag.Insertion;

namespace Robbochinni.Driver.Mag.Output
{
    public record TripInfo(
        Guid Id,
        Guid UserId,
        int State,
        string UserName,
        string Date,
        Location PickUp,
        Location DropOff
        );
}
