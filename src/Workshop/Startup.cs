using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Workshop.Account;
using Workshop.Data;
using Workshop.Data.Models.Account;
using Workshop.Filters;
using Workshop.Logging;
using Workshop.MappingProfiles;

namespace Workshop
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration prop
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup class ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures app the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                options.Filters.AddService<LogExceptionFilter>()             
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<WorkshopDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("Workshop.Data")));

            ConfigureIdentity(services);

            ConfigureAuthentication(services);

            services.AddSpaStaticFiles(c =>
            {
                c.RootPath = "wwwroot";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Workshop API",
                    Description = "A simple example ASP.NET Core Web API",
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "Workshop.xml");
                c.IncludeXmlComments(xmlPath);
            });

            ConfigureWorkshopModules(services);
        }
        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<WorkshopUser, WorkshopRole>()
              .AddEntityFrameworkStores<WorkshopDbContext>()
              .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            services
              .AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(config =>
              {
                  config.RequireHttpsMetadata = false;
                  config.SaveToken = true;
                  config.TokenValidationParameters = new TokenValidationParameters
                  {
                      IssuerSigningKey = signingKey,
                      ValidateLifetime = true,
                      ValidateAudience = false,
                      ValidateIssuer = false,
                      ValidateIssuerSigningKey = true
                  };
              });
        }

        private static void ConfigureWorkshopModules(IServiceCollection services)
        {
            services.RegisterDataModule();
            services.RegisterAccountModule();
            services.RegisterLoggingModule();

            ConfigureFilters(services);
        }

        private static void ConfigureFilters(IServiceCollection services)
        {
            services.AddTransient<LogExceptionFilter, LogExceptionFilter>();
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The hosting environment</param>
        /// <param name="userManager">User manager</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<WorkshopUser> userManager)
        {
            UpdateDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workshop V1");
            });
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action=index}/{id}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "wwwroot";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new AccountProfile());
                cfg.AddProfile(new LoggingProfile());
            });

            WorkshopDbInitializer.SeedUsers(userManager);
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
              .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<WorkshopDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
