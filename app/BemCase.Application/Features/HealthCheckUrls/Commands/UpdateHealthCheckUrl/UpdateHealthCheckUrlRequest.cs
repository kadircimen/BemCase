using BemCase.Application.Features.HealthCheckUrls.Dto;
using MediatR;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.UpdateHealthCheckUrl;
public class UpdateHealthCheckUrlRequest : IRequest<HealthCheckUrlDto>
{
    public int Id { get; set; }
    public string AppName { get; set; }
    public string Url { get; set; }
    public int Unit { get; set; }
    public int Frequency { get; set; }
}
