using Robbochinni.Driver.Mag.Enums;

namespace Robbochinni.Driver.Mag.Input
{
    public record TripByCode(Guid? Id, string? Code);
    public record TripByState(Guid? Id, TripState? State);
    public record TripByClient(Guid? ClientId, TripState? State, bool IsDriver);
}
