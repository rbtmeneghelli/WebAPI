namespace WebAPI.Application.Interfaces;

public interface IEmailService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, string userName, string appPath);
}
