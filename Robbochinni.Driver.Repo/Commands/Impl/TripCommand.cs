using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Commands.Impl
{
    internal class TripCommand(DbCtx ctx) : Command<Trip, AddTrip>(ctx)
    {
    }
}
