using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Commands.Impl
{
    internal class UserCommand(DbCtx ctx) : Command<User, AddUser>(ctx)
    {
    }
}
