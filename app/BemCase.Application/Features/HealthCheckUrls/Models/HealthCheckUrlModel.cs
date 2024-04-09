namespace BemCase.Application.Features.HealthCheckUrls.Models;
public class HealthCheckUrlModel
{
    public int Id { get; set; }
    public string AppName { get; set; }
    public string Url { get; set; }
    public int Unit { get; set; }
    public int Frequency { get; set; }
    public DateTime Created { get; set; }
}
