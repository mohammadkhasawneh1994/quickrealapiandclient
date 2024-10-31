using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Auth
{
    internal class GetUserById(DbCtx ctx) : Query<UserById, User, UserInfo>(ctx)
    {
        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role).Where(i => i.Id == input.Id);
    }

    internal class GetUserByMobile(DbCtx ctx) : Query<UserByMobile, User, UserInfo>(ctx)
    {
        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role).Where(i => i.Mobile == input.Mobile);
    }

    internal class GetUserByEmail(DbCtx ctx) : Query<UserByEmail, User, UserInfo>(ctx)
    {
        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role).Where(i => i.Email == input.Email);
    }

    internal class GetUserByRole(DbCtx ctx) : Query<UserByRole, User, UserInfo>(ctx)
    {
        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role).Where(i => i.RoleId == input.RoleId);
    }
}
