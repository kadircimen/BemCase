using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using Hangfire;
using MediatR;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;

public class CreateHealtCheckUrlHandler : IRequestHandler<CreateHealtCheckUrlRequest, CreateHealthCheckUrlDto>
{
    private readonly IHealthCheckUrlRepository _healthCheckUrls;
    private readonly IMapper _mapper;
    private readonly IBackgroundJobClient _backgroundJobClient;
    public CreateHealtCheckUrlHandler(IHealthCheckUrlRepository healthCheckUrls, IMapper mapper, IBackgroundJobClient backgroundJobClient)
    {
        _healthCheckUrls = healthCheckUrls;
        _mapper = mapper;
        _backgroundJobClient = backgroundJobClient;
    }
    public async Task<CreateHealthCheckUrlDto> Handle(CreateHealtCheckUrlRequest request, CancellationToken cancellationToken)
    {
        HealthCheckUrl data = _mapper.Map<HealthCheckUrl>(request);
        HealthCheckUrl healtCheckUrl = await _healthCheckUrls.AddAsync(data);
        var dto = _mapper.Map<CreateHealthCheckUrlDto>(healtCheckUrl);
        //RecurringJob.AddOrUpdate("CheckUrlJob_"+dto.Id,()=> HangfireJob)
        return dto;
    }
}
