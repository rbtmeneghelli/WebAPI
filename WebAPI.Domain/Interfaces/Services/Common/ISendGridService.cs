using SendGrid.Helpers.Mail;

namespace WebAPI.Domain.Interfaces.Services.Common;

public interface ISendGridService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, EmailAddress emailAddress, object emailData);
}
