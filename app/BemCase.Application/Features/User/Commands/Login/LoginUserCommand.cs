using AutoMapper;
using BemCase.Application.Features.User.Dto;
using BemCase.Application.Features.User.Rules;
using BemCase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BemCase.Application.Features.User.Commands.Login;

public class LoginUserCommand : IRequestHandler<LoginUserRequest, LoginUserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly AuthenticationBusinessRules _authRules;
    public LoginUserCommand(UserManager<AppUser> userManager, IMapper mapper,
        SignInManager<AppUser> signInManager, AuthenticationBusinessRules authRules)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _authRules = authRules;
    }
    public async Task<LoginUserDto> Handle(LoginUserRequest request, CancellationToken cancelToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        await _authRules.UserNotExists(user);
        var login = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
        await _authRules.LoginDenied(login.Succeeded);
        await _userManager.ResetAccessFailedCountAsync(user);
        await _userManager.SetLockoutEndDateAsync(user, null);

        var result = _mapper.Map<LoginUserDto>(user);

        return result;
    }
}