namespace Robbochinni.Driver.Mag.Input
{
    public record AddNewCar(Guid? DriverId,
                         string? Brand,
                         string? Class,
                         int? Year,
                         string? Color,
                         int? Code,
                         int? Number);
    public record CarByDriverId(Guid? Id);
    public record CarByLocation(decimal Lat, decimal Long);
}
