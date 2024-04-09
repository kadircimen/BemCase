using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Commands.DeleteHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Commands.UpdateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Features.HealthCheckUrls.Models;
using BemCase.Domain.Entities;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace BemCase.Application.Features.HealthCheckUrls.MappingProfiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateHealtCheckUrlRequest, HealthCheckUrl>().ReverseMap();
        CreateMap<HealthCheckUrl, HealthCheckUrlDto>().ReverseMap();

        CreateMap<HealthCheckUrl, HealthCheckUrlModel>().ReverseMap();
        CreateMap<IPaginate<HealthCheckUrl>, GetListresponse<HealthCheckUrlModel>>().ReverseMap();

        CreateMap<UpdateHealthCheckUrlRequest, HealthCheckUrl>().ReverseMap();

        CreateMap<DeleteHealthCheckUrlCommand, HealthCheckUrl>().ReverseMap();
    }
}
