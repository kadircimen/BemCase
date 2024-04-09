namespace BemCase.Application.Services.NotificationService;
public class NotificationSender
{
    private readonly INotificationService _notificationService;
    public NotificationSender(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public async Task SendAsync(string message)
    {
        await _notificationService.SendAsync(message);
    }
}
