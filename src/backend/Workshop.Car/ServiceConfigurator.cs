using Microsoft.Extensions.DependencyInjection;
using Workshop.Cars.Contracts;
using Workshop.Cars.Services;

namespace Workshop.Cars
{
    public static class ServiceConfigurator
    {
        public static void RegisterCarModule(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }
    }
}