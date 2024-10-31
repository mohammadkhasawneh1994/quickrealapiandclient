using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Mag.Statics;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl
{
    internal class LoginQuery : Query<UserLogin, User, UserInfo>
    {
        public LoginQuery(DbCtx ctx) : base(ctx)
        {
        }

        protected override IQueryable<User> Queryable => Entity.Include(i => i.Role).Where(i => i.Mobile == input.Mobile && i.Password == input.Password!.EncryptSHA256());
    }
}
