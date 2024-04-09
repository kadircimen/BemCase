using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Models;
using BemCase.Application.Services.Repositories;
using MediatR;

namespace BemCase.Application.Features.HealthCheckUrls.Queries.GetHealthCheckUrlById;
public class GetHealthCheckUrlByIdQuery : IRequest<HealthCheckUrlModel>
{
    public int Id { get; set; }
    public class GetHealthCheckUrlByIdQueryHandler : IRequestHandler<GetHealthCheckUrlByIdQuery, HealthCheckUrlModel>
    {
        private readonly IHealthCheckUrlRepository _healthCheckUrls;
        private readonly IMapper _mapper;
        public GetHealthCheckUrlByIdQueryHandler(IHealthCheckUrlRepository healthCheckUrls, IMapper mapper)
        {
            _healthCheckUrls = healthCheckUrls;
            _mapper = mapper;
        }
        public async Task<HealthCheckUrlModel> Handle(GetHealthCheckUrlByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _healthCheckUrls.GetAsync(x => x.Id == request.Id);
            var response = _mapper.Map<HealthCheckUrlModel>(data);
            return response;
        }
    }
}
