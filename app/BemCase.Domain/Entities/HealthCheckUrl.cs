using Core.Persistence.Repositories;
namespace BemCase.Domain.Entities;
public class HealthCheckUrl : Entity
{
    public string AppName { get; set; }
    public string Url { get; set; }
    public int Unit { get; set; }
    public int Frequency { get; set; }
}
