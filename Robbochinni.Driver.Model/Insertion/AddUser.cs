using Robbochinni.Driver.Mag.ValueObjects;

namespace Robbochinni.Driver.Mag.Insertion
{
    public record AddUser(string? FirstName, string? LastName, string? Email, Secret? Password, string? Code, string? Phone, Guid? RoleId, bool? IsBlocked);
}
