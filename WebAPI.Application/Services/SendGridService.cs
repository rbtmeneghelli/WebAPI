using SendGrid;
using SendGrid.Helpers.Mail;
using WebAPI.Application.FactoryInterfaces;
using WebAPI.Application.Generic;
using WebAPI.Application.InterfacesService;

namespace WebAPI.Application.Services;

public class SendGridService : GenericService, ISendGridService
{
    private EnvironmentVariables environmentVariables { get; }
    private readonly IEmailFactory _iEmailFactory;

    public SendGridService(IEmailFactory emailFactory, INotificationMessageService notificationMessageService) : base(notificationMessageService)
    {
        _iEmailFactory = emailFactory;
    }

    private async Task SendEmailAsync(SendGridMessage sendGridMessage)
    {
        var sendGridClient = new SendGridClient(environmentVariables.SendGridSettings.Client);
        sendGridMessage.SetFrom(environmentVariables.SendGridSettings.EmailSender, environmentVariables.SendGridSettings.EmailSenderName);
        await sendGridClient.SendEmailAsync(sendGridMessage);
    }

    public async Task CustomSendEmailAsync(EnumEmail enumEmail, EmailAddress emailAddress, object emailData)
    {
        IEmailConfigFactory iEmailFactoryConfig = _iEmailFactory.SendEmailByEnumEmail(enumEmail);
        var sendGridSettings = iEmailFactoryConfig.GetSendGridIdToSend();
        var sendGridMessage = new SendGridMessage();
        sendGridMessage.Subject = sendGridSettings.Subject;
        sendGridMessage.AddTo(emailAddress);
        sendGridMessage.SetTemplateData(emailData);
        sendGridMessage.SetTemplateId(sendGridSettings.TemplateId);
        await SendEmailAsync(sendGridMessage);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
