namespace BemCase.Application.Features.HealthCheckUrls.Dto;
public record CreateHealthCheckUrlDto(int Id, string AppName, string Url, int Unit, int Frequency);
