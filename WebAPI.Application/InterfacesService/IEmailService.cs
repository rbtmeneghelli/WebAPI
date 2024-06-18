namespace WebAPI.Application.Interfaces;

public interface IEmailService : IDisposable
{
    Task SendEmailToResetPswAsync(string userName, string appPath);
}
