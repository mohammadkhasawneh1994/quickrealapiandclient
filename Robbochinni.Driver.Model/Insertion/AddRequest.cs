namespace Robbochinni.Driver.Mag.Insertion
{
   // public record AddRequest(Location? Pickup, Location? DropOff, string? Client, string? Code, double? Distance, bool? State = true);
    public record Location(decimal? Lat, decimal? Long, string LocationName);
}
