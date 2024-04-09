using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Services;
using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using Core.CrossCuttingConcerns.Utils;
using Hangfire;
using MediatR;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;

public class CreateHealtCheckUrlHandler : IRequestHandler<CreateHealtCheckUrlRequest, HealthCheckUrlDto>
{
    private readonly IHealthCheckUrlRepository _healthCheckUrls;
    private readonly IMapper _mapper;
    public CreateHealtCheckUrlHandler(IHealthCheckUrlRepository healthCheckUrls, IMapper mapper)
    {
        _healthCheckUrls = healthCheckUrls;
        _mapper = mapper;
    }
    public async Task<HealthCheckUrlDto> Handle(CreateHealtCheckUrlRequest request, CancellationToken cancellationToken)
    {
        HealthCheckUrl data = _mapper.Map<HealthCheckUrl>(request);
        HealthCheckUrl healthCheckUrl = await _healthCheckUrls.AddAsync(data);
        var dto = _mapper.Map<HealthCheckUrlDto>(healthCheckUrl);

        string cron = CronExpGenerator.CreateCronExpression(healthCheckUrl.Unit, (ECheckFrequencies)healthCheckUrl.Frequency);
        RecurringJob.AddOrUpdate<CheckUrlJob>("CheckUrl_" + healthCheckUrl.Id, job => job.Execute(healthCheckUrl.Id), cron);
        return dto;
    }
}
