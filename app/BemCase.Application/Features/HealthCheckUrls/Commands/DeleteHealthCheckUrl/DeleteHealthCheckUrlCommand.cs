using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using Hangfire;
using MediatR;
namespace BemCase.Application.Features.HealthCheckUrls.Commands.DeleteHealthCheckUrl;
public class DeleteHealthCheckUrlCommand : IRequest<HealthCheckUrlDto>
{
    public int Id { get; set; }
    public class DeleteHealthCheckUrlCommandHandler : IRequestHandler<DeleteHealthCheckUrlCommand, HealthCheckUrlDto>
    {
        private readonly IHealthCheckUrlRepository _healthCheckRepo;
        private readonly IMapper _mapper;
        public DeleteHealthCheckUrlCommandHandler(IHealthCheckUrlRepository healthCheckRepo, IMapper mapper)
        {
            _healthCheckRepo = healthCheckRepo;
            _mapper = mapper;
        }
        public async Task<HealthCheckUrlDto> Handle(DeleteHealthCheckUrlCommand request, CancellationToken cancellationToken)
        {
            var url = await _healthCheckRepo.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, url);

            HealthCheckUrl deleted = await _healthCheckRepo.DeleteAsync(url);
            var response = _mapper.Map<HealthCheckUrlDto>(deleted);

            RecurringJob.RemoveIfExists("CheckUrl_" + deleted.Id);
            return response;
        }
    }
}
