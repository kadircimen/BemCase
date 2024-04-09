using BemCase.Application.Features.HealthCheckUrls.Dto;
using MediatR;
namespace BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
public class CreateHealtCheckUrlRequest : IRequest<HealthCheckUrlDto>
{
    public string AppName { get; set; }
    public string Url { get; set; }
    public int Unit { get; set; }
    public int Frequency { get; set; }
}
