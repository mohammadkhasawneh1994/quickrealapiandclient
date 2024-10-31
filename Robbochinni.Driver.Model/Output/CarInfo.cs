using Robbochinni.Driver.Mag.Insertion;

namespace Robbochinni.Driver.Mag.Output
{
    public record CarInfo(Guid? Id,
                          Guid? DriverId,
                          string? DriverName,
                          string? Brand,
                          string? Class,
                          int? Year,
                          string? Color,
                          int? Code,
                          int? Number,
                          Location Location);
}
