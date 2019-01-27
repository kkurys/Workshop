using Microsoft.Extensions.DependencyInjection;
using Workshop.Logging.Contracts;
using Workshop.Logging.Services;

namespace Workshop.Logging
{
    public static class ServiceConfigurator
    {
        public static void RegisterLoggingModule(this IServiceCollection services)
        {
            services.AddScoped<ILoggingService, LoggingService>();
        }
    }
}
