namespace BemCase.Application.Features.HealthCheckUrls.Dto;
public record HealthCheckUrlDto(int Id, string AppName, string Url, int Unit, int Frequency);
