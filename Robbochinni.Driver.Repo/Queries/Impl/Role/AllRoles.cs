using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl
{
    internal class AllRoles : Query<AllQuery, Role, RoleInfo>
    {
        public AllRoles(DbCtx ctx) : base(ctx)
        {
        }

        protected override IQueryable<Role> Queryable => Entity.Include(i => i.Users)!;
    }
}
