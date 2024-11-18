using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.SignalR
{
    public sealed class NotificationHub : Hub
    {
        //public async Task SendNotification(string message)
        //{
        //    await Clients.All.SendAsync("ReceiveNotification", message);
        //}
    }
}
