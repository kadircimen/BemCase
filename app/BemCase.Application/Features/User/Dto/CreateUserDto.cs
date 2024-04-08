namespace BemCase.Application.Features.User.Dto;
public record CreateUserDto(string Email, string Name, string Surname, string[] errors = null);
