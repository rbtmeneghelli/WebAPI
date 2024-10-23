namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface ITwilioService : IDisposable
{
    Task SendSmsMessageAsync(string numberTo, string bodyMessage);
    Task SendWhatsAppMessageAsync(string numberTo, string bodyMessage);
}
