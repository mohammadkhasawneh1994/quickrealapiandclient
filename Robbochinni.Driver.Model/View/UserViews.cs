namespace Robbochinni.Driver.Mag.View
{
    public record AddUserView(string? FirstName, string? LastName, string? Email, string? Password, string? Phone);
    public record AddDriverView(AddUserView User,
                                string? Driver,
                                string? Brand,
                                string? Class,
                                string? Year,
                                string? Color,
                                int? Code,
                                int? Number);

    public record UserLoginView(string? Mobile, string? Password);
}
