namespace WebAPI.Application.Interfaces
{
    public interface INotificationMessageService
    {
        void Handle(NotificationMessage notificacao);
        List<NotificationMessage> GetNotifications();
        bool HaveNotification();
    }
}
