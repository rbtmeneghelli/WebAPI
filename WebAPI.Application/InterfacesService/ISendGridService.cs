using SendGrid.Helpers.Mail;

namespace WebAPI.Application.InterfacesService;

public interface ISendGridService : IDisposable
{
    Task CustomSendEmailAsync(EnumEmail enumEmail, EmailAddress emailAddress, object emailData);
}
