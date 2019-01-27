using Microsoft.Extensions.DependencyInjection;
using Workshop.Data.Contracts;
using Workshop.Data.Services;

namespace Workshop.Data
{
    public static class ServiceConfigurator
    {
        public static void RegisterDataModule(this IServiceCollection services)
        {
            services.AddScoped<IDataService, DataService>();
        }
    }
}
