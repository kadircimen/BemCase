using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BemCase.Application.Features.User.Rules;
using BemCase.Application.Features.HealthCheckUrls.Rules;
using Core.Application.Pipelines.Logging;
using MediatR;
using Core.CrossCuttingConcerns.Logging;
using BemCase.Application.Services.NotificationService;
using Core.Application.Pipelines.Validation;

namespace BemCase.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient<INotificationService, EmailNotificationService>();
        services.AddTransient<INotificationService, SmsNotificationService>();
        services.AddTransient<INotificationService, PushNotificationService>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddSingleton<LoggerServiceBase, MsSqlLogger>();
        services.AddScoped<AuthenticationBusinessRules>();
        services.AddScoped<HealthCheckBusinessRules>();
        return services;
    }
}

