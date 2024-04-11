namespace WebAPI.Application.Services
{
    public class NotificationMessageService : INotificationMessageService
    {
        private List<NotificationMessage> _notifications;

        public NotificationMessageService()
        {
            _notifications = new List<NotificationMessage>();
        }

        public void Handle(NotificationMessage notification)
        {
            _notifications.Add(notification);
        }

        public List<NotificationMessage> GetNotifications()
        {
            return _notifications;
        }

        public bool HaveNotification()
        {
            return _notifications?.Count() > 0;
        }
    }
}
