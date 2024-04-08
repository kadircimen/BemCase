using Core.Application.Requests;
using MediatR;
using BemCase.Application.Features.User.Dto;

namespace BemCase.Application.Features.User.Commands.Register;
public class CreateUserRequest : IRequest<CreateUserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
