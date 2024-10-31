using Microsoft.EntityFrameworkCore;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Queries.Impl.Car
{
    internal class GetCarByDriver(DbCtx ctx) : Query<CarByDriverId, Entities.Car, CarInfo>(ctx)
    {
        protected override IQueryable<Entities.Car> Queryable => Entity
            .Include(i => i.Driver)
            .Include(i => i.AvaialableIn)
            .Where(i => i.DriverId == input.Id);
    }

    internal class GetCarByNearest(DbCtx ctx) : Query<CarByLocation, Entities.Car, CarInfo>(ctx)
    {
        protected override IQueryable<Entities.Car> Queryable
        {
            get
            {
                var latMinus = input.Lat - 5;
                var latPlus = input.Lat + 5;

                var longMinus = input.Long - 5;
                var longPlus = input.Long + 5;


                return Entity
                    .Include(i => i.Driver)
                    .Include(i => i.AvaialableIn)
                    .Where(i => (i.AvaialableIn!.Longitude >= longMinus && i.AvaialableIn!.Longitude! <= longPlus)
                    && ((i.AvaialableIn!.Latitude >= latMinus && i.AvaialableIn!.Latitude <= latPlus)));

            }
        }
    }
}
