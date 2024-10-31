
using Microsoft.Extensions.DependencyInjection;
using Robbochinni.Driver.Business.Operations;
using Robbochinni.Driver.Mag.Output;

namespace Robbochinni.Driver.Business
{
    public static class DependencyInjection
    {
        public static void AddAppManagers(this IServiceCollection services)
        {
            services.AddScoped<AuthManager>();
            services.AddScoped<RoleManager>();
            services.AddScoped<CarManager>();
            services.AddScoped<TripManager>();

            services.AddScoped<ResultBuilder>();
        }
    }
}
