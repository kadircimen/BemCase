using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
//using BemCase.Application.Services.AuthService;
using BemCase.Application.Features.User.Rules;

namespace BemCase.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //services.AddScoped<IAuthService, AuthService>();


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddScoped<AuthenticationBusinessRules>();

        return services;
    }
}

