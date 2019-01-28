using Microsoft.Extensions.DependencyInjection;
using Workshop.Account.Contracts;
using Workshop.Account.Services;

namespace Workshop.Account
{
    public static class ServiceConfigurator
    {
        public static void RegisterAccountModule(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthValidationService, AuthValidationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
