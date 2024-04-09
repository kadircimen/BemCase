using FluentValidation;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
public class CreateHealthCheckValidator : AbstractValidator<CreateHealtCheckUrlRequest>
{
    public CreateHealthCheckValidator()
    {
        RuleFor(x => x.AppName).NotEmpty();
        RuleFor(x => x.Url).NotEmpty();
        RuleFor(x => x.Unit).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Frequency).NotEmpty().GreaterThan(0);
    }
}
