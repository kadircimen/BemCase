using AutoMapper;
using BemCase.Application.Features.HealthCheckUrls.Commands.CreateHealthCheckUrl;
using BemCase.Application.Features.HealthCheckUrls.Dto;
using BemCase.Application.Features.HealthCheckUrls.Models;
using BemCase.Domain.Entities;
using Core.Application.Responses;
using Core.Persistence.Paging;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace BemCase.Application.Features.HealthCheckUrls.MappingProfiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateHealtCheckUrlRequest, HealthCheckUrl>().ReverseMap();
        CreateMap<HealthCheckUrl, CreateHealthCheckUrlDto>().ReverseMap();

        CreateMap<HealthCheckUrl, HealthCheckUrlModel>().ReverseMap();
        CreateMap<IPaginate<HealthCheckUrl>, GetListresponse<HealthCheckUrlModel>>().ReverseMap();
    }
}
