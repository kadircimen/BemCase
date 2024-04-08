using FluentValidation;
namespace BemCase.Application.Features.User.Commands.Login;
public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(c => c.Email).NotEmpty().MinimumLength(3).WithMessage("Email is not valid");
        RuleFor(c => c.Password).NotEmpty().MinimumLength(6).WithMessage("Password is not valid");
    }
}

