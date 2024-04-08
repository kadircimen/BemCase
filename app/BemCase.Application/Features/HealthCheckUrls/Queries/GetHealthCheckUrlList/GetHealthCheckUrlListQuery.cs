using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Models;
using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
namespace BemCase.Application.Features.HealthCheckUrls.Queries.GetHealthCheckUrls;
public class GetHealthCheckUrlListQuery : IRequest<GetListresponse<HealthCheckUrlModel>>
{
    public PageRequest PageRequest { get; set; }
    public class GetHealthCheckUrlListQueryHandler : IRequestHandler<GetHealthCheckUrlListQuery, GetListresponse<HealthCheckUrlModel>>
    {
        private readonly IHealthCheckUrlRepository _healthCheckUrls;
        private readonly IMapper _mapper;
        public GetHealthCheckUrlListQueryHandler(IHealthCheckUrlRepository healthCheckUrls, IMapper mapper)
        {
            _healthCheckUrls = healthCheckUrls;
            _mapper = mapper;
        }
        public async Task<GetListresponse<HealthCheckUrlModel>> Handle(GetHealthCheckUrlListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<HealthCheckUrl> urls = await _healthCheckUrls.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            var response = _mapper.Map<GetListresponse<HealthCheckUrlModel>>(urls);
            return response;
        }
    }
}
