using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services.Tools
{
    public interface INotificationMessageService
    {
        void Handle(NotificationMessage notificacao);
        List<NotificationMessage> GetNotifications();
        bool HaveNotification();
    }
}
