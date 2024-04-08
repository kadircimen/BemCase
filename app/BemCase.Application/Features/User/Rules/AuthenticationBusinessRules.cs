using Core.CrossCuttingConcerns.Exceptions;
using BemCase.Domain.Entities;

namespace BemCase.Application.Features.User.Rules;
public class AuthenticationBusinessRules
{
    public Task UserNotExists(AppUser? user)
    {
        if (user is null) throw new BusinessException("User doesn't exists");
        return Task.CompletedTask;
    }
    public Task LoginDenied(bool status)
    {
        if (!status) throw new BusinessException("Login Denied");
        return Task.CompletedTask;
    }
}
