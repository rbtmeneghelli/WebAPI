namespace WebAPI.Domain.Interfaces.Services.Common;

public interface IMetaService
{
    Task SendMessageToWhatsApp(string celPhone, string message);
}
