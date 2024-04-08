using BemCase.Domain.Entities;
using Core.Persistence.Repositories;
namespace BemCase.Application.Services.Repositories;
public interface IHealthCheckUrlRepository : IAsyncRepository<HealthCheckUrl>
{
}
