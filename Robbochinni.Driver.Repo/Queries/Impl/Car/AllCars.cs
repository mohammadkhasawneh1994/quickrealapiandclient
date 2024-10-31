using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Car
{
    internal class AllCars(DbCtx ctx) : Query<AllQuery, Entities.Car, CarInfo>(ctx)
    {
        protected override IQueryable<Entities.Car> Queryable => Entity
            .Include(i => i.Driver)
            .Include(i => i.AvaialableIn);
    }
}
