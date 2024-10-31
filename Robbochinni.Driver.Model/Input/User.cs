using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Mag.Input
{
    public record UserLogin(string? Mobile, Secret? Password);
    public record UserByMobile(string? Mobile);
    public record UserByEmail(string? Email);
    public record UserById(Guid? Id);
    public record UserByRole(Guid? RoleId);
}
