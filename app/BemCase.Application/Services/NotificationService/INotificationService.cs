namespace BemCase.Application.Services.NotificationService;
public interface INotificationService
{
    Task SendAsync(string message);
}
