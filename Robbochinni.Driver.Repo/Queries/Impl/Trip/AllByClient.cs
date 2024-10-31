using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Trip
{
    internal class AllByClient(DbCtx ctx) : Query<TripByClient, Entities.Trip, TripInfo>(ctx)
    {
        protected override IQueryable<Entities.Trip> Queryable
        {
            get
            {
                if (input.IsDriver)
                    if (input.State == Mag.Enums.TripState.All)
                        return Entity
                            .Include(i => i.Requester)
                            .Include(i => i.From)
                            .Include(i => i.To)
                            .OrderByDescending(i => i.CreateDate)
                            .Where(i => i.DriverId == input.ClientId);
                    else
                        return Entity
                                    .Include(i => i.Requester)
                                    .Include(i => i.From)
                                    .Include(i => i.To)
                                    .OrderByDescending(i => i.CreateDate)
                                    .Where(i => i.State == (int)input.State! && i.DriverId == input.ClientId);
                else if (input.State == Mag.Enums.TripState.All)
                    return Entity
                        .Include(i => i.Requester)
                        .Include(i => i.From)
                        .Include(i => i.To)
                        .OrderByDescending(i => i.CreateDate)
                        .Where(i => i.RequesterId == input.ClientId);
                else
                    return Entity
                        .Include(i => i.Requester)
                        .Include(i => i.From)
                        .Include(i => i.To)
                        .OrderByDescending(i => i.CreateDate)
                        .Where(i => i.State == (int)input.State! && i.RequesterId == input.ClientId);

            }

        }
    }
}
