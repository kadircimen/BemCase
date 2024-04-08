using BemCase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BemCase.Application.Features.User.Commands.Logout;
public class LogoutUserCommand : IRequest<bool>
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, bool>
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LogoutUserCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(LogoutUserCommand command, CancellationToken cancelToken)
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
