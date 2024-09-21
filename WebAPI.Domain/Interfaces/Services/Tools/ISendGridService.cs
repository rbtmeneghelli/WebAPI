using SendGrid.Helpers.Mail;
using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface ISendGridService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, EmailAddress emailAddress, object emailData);
}
