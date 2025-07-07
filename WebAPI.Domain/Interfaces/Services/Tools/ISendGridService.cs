using SendGrid.Helpers.Mail;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface ISendGridService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, EmailAddress emailAddress, object emailData);
}
