using BemCase.Application.Services.NotificationService;
using BemCase.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Logging;
namespace BemCase.Application.Services;
public class CheckUrlJob
{
    private readonly IHealthCheckUrlRepository _healthCheckRepo;
    public CheckUrlJob(IHealthCheckUrlRepository healthCheckRepo, LoggerServiceBase logger)
    {
        _healthCheckRepo = healthCheckRepo;
    }
    public async Task Execute(int UrlId)
    {
        var data = await _healthCheckRepo.GetAsync(x => x.Id == UrlId);
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(data.Url);
        var emailService = new EmailNotificationService();
        var notificationManager = new NotificationSender(emailService);
        if (!response.IsSuccessStatusCode)
        {
            await notificationManager.SendAsync($"Url: {data.Url} Response Code: {response.StatusCode}");
        }
    }
}
