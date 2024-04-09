using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Features.HealthCheckUrls.Rules;
using BemCase.Application.Services;
using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using Core.CrossCuttingConcerns.Utils;
using Hangfire;
using MediatR;

namespace BemCase.Application.Features.HealthCheckUrls.Commands.UpdateHealthCheckUrl;
public class UpdateHealthCheckUrlHandler : IRequestHandler<UpdateHealthCheckUrlRequest, HealthCheckUrlDto>
{
    private readonly IHealthCheckUrlRepository _healthCheckUrls;
    private readonly IMapper _mapper;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly HealthCheckBusinessRules _businessRules;
    public UpdateHealthCheckUrlHandler(IHealthCheckUrlRepository healthCheckUrls, IMapper mapper, IBackgroundJobClient backgroundJobClient, HealthCheckBusinessRules businessRules)
    {
        _healthCheckUrls = healthCheckUrls;
        _mapper = mapper;
        _backgroundJobClient = backgroundJobClient;
        _businessRules = businessRules;
    }
    public async Task<HealthCheckUrlDto> Handle(UpdateHealthCheckUrlRequest request, CancellationToken cancellationToken)
    {
        HealthCheckUrl? healthCheckUrl = await _healthCheckUrls.GetAsync(x => x.Id == request.Id);
        await _businessRules.UrlNotFound(healthCheckUrl);
        _mapper.Map(request, healthCheckUrl);
        var updated = await _healthCheckUrls.UpdateAsync(healthCheckUrl);
        var response = _mapper.Map<HealthCheckUrlDto>(updated);

        string cron = CronExpGenerator.CreateCronExpression(updated.Unit, (ECheckFrequencies)updated.Frequency);
        RecurringJob.AddOrUpdate<CheckUrlJob>("CheckUrl_" + request.Id, job => job.Execute(updated.Id), cron);
        return response;
    }
}
