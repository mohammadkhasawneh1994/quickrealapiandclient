using Mapster;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;
using Robbochinni.Driver.Mag.Statics;

namespace Robbochinni.Driver.Repo.Mapping
{
    internal class UserMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddUser, User>()
                .Map(dest => dest.FullName, src => checkName(src))
                .Map(dest => dest.Mobile, src => src.Phone)
                .Map(dest => dest.Password, src => src.Password!.EncryptSHA256())
                .Map(dest => dest.Varification, src => src.Code!)
                .Map(dest => dest.RoleId, src => src.RoleId!)
                .Map(dest => dest.IsLocked, src => src.IsBlocked)
                .IgnoreNullValues(true);

            config.NewConfig<User, UserInfo>()
                .Map(dest => dest.Id, src => src.Id.ToString())
                .Map(dest => dest.FullName, src => src.FullName)
                .Map(dest => dest.Mobile, src => src.Mobile)
                .Map(dest => dest.Role, src => src.Role!.RoleName);

        }

        private string checkName(AddUser addUser)
        {
            if (addUser.FirstName == null || addUser.LastName == null)
                return null!;
            else
                return $"{addUser.FirstName} {addUser.LastName}";
        }
    }
}
