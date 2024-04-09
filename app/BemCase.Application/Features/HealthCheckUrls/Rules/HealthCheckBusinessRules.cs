using BemCase.Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;

namespace BemCase.Application.Features.HealthCheckUrls.Rules;
public class HealthCheckBusinessRules
{
    public async Task UrlNotFound(HealthCheckUrl request)
    {
        if (request == null)
        {
            throw new BusinessException($"{nameof(request)} cannot be null.");
        }
    }
}
