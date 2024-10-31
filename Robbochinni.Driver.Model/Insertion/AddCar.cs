using Robbochinni.Driver.Mag.Enums;

namespace Robbochinni.Driver.Mag.Insertion
{
    public record AddCar(Guid? DriverId,
                         string? Brand,
                         string? Class,
                         int? Year,
                         string? Color,
                         int? Code,
                         int? Number,
                         RideType RideType,
                         Location Location);
}
