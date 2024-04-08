using AutoMapper;
using BemCase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using BemCase.Application.Features.User.Dto;

namespace BemCase.Application.Features.User.Commands.Register;
public class CreateUserCommand : IRequestHandler<CreateUserRequest, CreateUserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    public CreateUserCommand(UserManager<AppUser> userManager, IMapper mapper) { _userManager = userManager; _mapper = mapper; }
    public async Task<CreateUserDto> Handle(CreateUserRequest request, CancellationToken cancelToken)
    {
        var user = _mapper.Map<AppUser>(request);
        user.UserName = user.Email.Split('@')[0].ToString();
        var identityResult = await _userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
        {
            return new CreateUserDto(null, null, null, identityResult.Errors.Select(x => x.Description).ToArray());
        }
        var result = _mapper.Map<CreateUserDto>(user);
        return result;
    }
}