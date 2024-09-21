using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IFirebaseService : IDisposable
{
    Task SendPushNotification_V1(string tokenUser, FirebaseNotificationDetails firebaseNotificationDetails);
    Task SendPushNotification_V2(string tokenToSend, string message);
}
