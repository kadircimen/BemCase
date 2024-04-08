using BemCase.Application.Features.User.Dto;
using MediatR;

namespace BemCase.Application.Features.User.Commands.Login;

public class LoginUserRequest : IRequest<LoginUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}