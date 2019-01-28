using Microsoft.Extensions.DependencyInjection;
using Workshop.CarHelp.Contracts;
using Workshop.CarHelp.Services;

namespace Workshop.CarHelp
{
    public static class ServiceConfigurator
    {
        public static void RegisterCarHelpModule(this IServiceCollection services)
        {
            services.AddScoped<ICarHelpEntryService, CarHelpEntryService>();
        }
    }
}
