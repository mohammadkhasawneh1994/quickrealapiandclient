using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Repo.Entities;

namespace Robbochinni.Driver.Repo.Commands.Impl
{
    internal class CarCommand(DbCtx ctx) : Command<Car, AddCar>(ctx)
    {
    }
}
