using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Auth
{
    internal class AllUsers(DbCtx ctx) : Query<AllQuery, User, UserInfo>(ctx)
    {
        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role);
    }
}
