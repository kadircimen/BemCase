using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using BemCase.Persistence.Contexts;
using BemCase.Persistence.Repositories;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BemCase.Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BemCaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BemConnectionString")));
        services.AddHangfire(conf => conf.UseSqlServerStorage(configuration.GetConnectionString("BemConnectionString")));
        services.AddHangfireServer();
        services.AddIdentity<AppUser, AppRole>()
        .AddEntityFrameworkStores<BemCaseDbContext>();
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = new PathString("/Auth/Login");
            options.LogoutPath = new PathString("/Auth/Logout");
            options.AccessDeniedPath = new PathString("/Home/AccessDenied");
            options.Cookie = new()
            {
                Name = "IdentityCookie",
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                SecurePolicy = CookieSecurePolicy.Always
            };
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromDays(30);
        });
        services.AddAuthentication();

        services.AddScoped<IHealthCheckUrlRepository, HealthCheckUrlRepository>();

        return services;
    }
}
