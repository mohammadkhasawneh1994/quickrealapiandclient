using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Commands.Impl
{
    internal class RoleCommand(DbCtx ctx) : Command<Role, AddRole>(ctx)
    {
    }
}
