using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Robbochinni.Driver.Mag.Abstracions;
using Robbochinni.Driver.Mag.Input;
using Robbochinni.Driver.Mag.Insertion;
using Robbochinni.Driver.Mag.Output;
using Robbochinni.Driver.Repo.Commands.Impl;
using Robbochinni.Driver.Repo.Entities;
using Robbochinni.Driver.Repo.Queries.Impl;
using Robbochinni.Driver.Repo.Queries.Impl.Auth;
using Robbochinni.Driver.Repo.Queries.Impl.Car;
using Robbochinni.Driver.Repo.Queries.Impl.Trip;
using System.Reflection;

namespace Robbochinni.Driver.Repo
{
    public static class DependencyInjection
    {
        public static void AddDbContext(this IServiceCollection services, string Conn)
        {
            services.AddDbContext<DbCtx>(i => i.UseSqlServer(Conn));

            services.AddScoped<ICommand<AddUser>, UserCommand>();
            services.AddScoped<ICommand<AddRole>, RoleCommand>();
            services.AddScoped<ICommand<AddTrip>, TripCommand>();
            services.AddScoped<ICommand<AddCar>, CarCommand>();

            services.AddScoped<IQuery<UserLogin, UserInfo>, LoginQuery>();

            services.AddScoped<IQuery<AllQuery, RoleInfo>, AllRoles>();

            services.AddScoped<IQuery<UserById, UserInfo>, GetUserById>();
            services.AddScoped<IQuery<UserByMobile, UserInfo>, GetUserByMobile>();
            services.AddScoped<IQuery<UserByEmail, UserInfo>, GetUserByEmail>();
            services.AddScoped<IQuery<UserByRole, UserInfo>, GetUserByRole>();
            services.AddScoped<IQuery<AllQuery, UserInfo>, AllUsers>();

            services.AddScoped<IQuery<CarByDriverId, CarInfo>, GetCarByDriver>();
            services.AddScoped<IQuery<CarByLocation, CarInfo>, GetCarByNearest>();
            services.AddScoped<IQuery<AllQuery, CarInfo>, AllCars>();

            services.AddScoped<IQuery<TripByCode, TripInfo>, GetTripByCode>();
            services.AddScoped<IQuery<TripByState, TripInfo>, GetTripByState>();
            services.AddScoped<IQuery<TripByClient, TripInfo>, AllByClient>();
            services.AddScoped<IQuery<AllQuery, TripInfo>, AllTrips>();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
