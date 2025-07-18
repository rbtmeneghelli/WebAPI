﻿using SendGrid;
using SendGrid.Helpers.Mail;
using WebAPI.Domain.Interfaces.Factory;
using ISendGridService = WebAPI.Domain.Interfaces.Services.Tools.ISendGridService;

namespace WebAPI.Application.Services.Tools;

public sealed class SendGridService : BaseHandlerService, ISendGridService
{
    private EnvironmentVariables _environmentVariables { get; }
    private readonly IEmailFactory _iEmailFactory;

    public SendGridService(
        EnvironmentVariables environmentVariables, 
        IEmailFactory iEmailFactory, 
        INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _iEmailFactory = iEmailFactory;
        _environmentVariables = environmentVariables;
    }

    private async Task SendEmailAsync(SendGridMessage sendGridMessage)
    {
        var sendGridClient = new SendGridClient(_environmentVariables.SendGridSettings.Client);
        sendGridMessage.SetFrom(_environmentVariables.SendGridSettings.EmailSender, _environmentVariables.SendGridSettings.EmailSenderName);
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
