using BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
using FluentValidation;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.UpdateHealthCheckUrl;
public class UpdateHealthCheckUrlValidator : AbstractValidator<UpdateHealthCheckUrlRequest>
{
    public UpdateHealthCheckUrlValidator()
    {
        RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        RuleFor(x => x.AppName).NotEmpty();
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.Unit).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Frequency).NotEmpty().GreaterThan(0);
    }
}
