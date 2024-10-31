using Mapster;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Mapping
{
    internal class RoleMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddRole, Role>()
                .Map(dest => dest.RoleName, src => src.Name);

            config.NewConfig<Role, RoleInfo>()
                .Map(dest => dest.Id, src => src.Id.ToString())
                .Map(dest => dest.Name, src => src.RoleName)
                .Map(dest => dest.Users, src => src.Users!.ToArray());

        }
    }
}
