using AutoMapper;
using BemCase.Application.Features.User.Commands.Login;
using BemCase.Application.Features.User.Commands.Register;
using BemCase.Application.Features.User.Dto;
using BemCase.Domain.Entities;
namespace BemCase.Application.Features.User.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppUser, LoginUserCommand>().ReverseMap();
        CreateMap<AppUser, LoginUserDto>().ReverseMap();
        CreateMap<AppUser, CreateUserRequest>().ReverseMap();
        CreateMap<AppUser, CreateUserDto>().ReverseMap();
    }
}