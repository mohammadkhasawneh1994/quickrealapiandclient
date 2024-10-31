using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Trip
{
    internal class GetTripByCode(DbCtx ctx) : Query<TripByCode, Entities.Trip, TripInfo>(ctx)
    {
        protected override IQueryable<Entities.Trip> Queryable => Entity
            .Include(i => i.Requester)
            .Where(i => i.Id == input.Id && i.State == 1 && i.ConfirmationCode == input.Code);
    }
}
