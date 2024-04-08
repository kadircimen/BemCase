using BemCase.Application.Services.Repositories;
using BemCase.Domain.Entities;
using BemCase.Persistence.Contexts;
using Core.Persistence.Repositories;

namespace BemCase.Persistence.Repositories;
public class HealthCheckUrlRepository : EfRepositoryBase<HealthCheckUrl, BemCaseDbContext>, IHealthCheckUrlRepository
{
    public HealthCheckUrlRepository(BemCaseDbContext context) : base(context) { }
}
