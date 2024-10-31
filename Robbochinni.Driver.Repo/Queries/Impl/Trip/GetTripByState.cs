using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Trip
{
    internal class GetTripByState(DbCtx ctx) : Query<TripByState, Entities.Trip, TripInfo>(ctx)
    {
        protected override IQueryable<Entities.Trip> Queryable
        {
            get
            {
                if (input.Id == Guid.Empty)
                    return Entity
                        .Include(i => i.Requester)
                        .Include(i => i.From)
                        .Include(i => i.To)
                        .OrderByDescending(i => i.CreateDate)
                        .Where(i => i.State == (int)input.State!);
                else
                    return Entity
                        .Include(i => i.Requester)
                        .Include(i => i.From)
                        .Include(i => i.To)
                        .OrderByDescending(i => i.CreateDate)
                        .Where(i => i.Id == input.Id && i.State == (int)input.State!);

            }

        }
    }
}
