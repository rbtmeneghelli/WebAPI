namespace WebAPI.Application.Interfaces;

public interface IFirebaseService : IDisposable
{
    Task SendPushNotification(string tokenToSend, string message);
}
