using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Trip
{
    internal class AllTrips(DbCtx ctx) : Query<AllQuery, Entities.Trip, TripInfo>(ctx)
    {
        protected override IQueryable<Entities.Trip> Queryable => Entity.Include(i => i.Requester);
    }
}
