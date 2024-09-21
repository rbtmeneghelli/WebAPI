using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Interfaces.Services.Configuration;

public interface IEmailService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, string userName, string appPath = "");
}
