using WebAPI.Domain.Interfaces.Services.Common;

namespace WebAPI.Application.Services.Common;

public sealed class TwilioService : BaseHandlerService, ITwilioService
{
    private EnvironmentVariables _environmentVariables { get; }

    public TwilioService(
        EnvironmentVariables environmentVariables,
        INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
    {
        _environmentVariables = environmentVariables;
    }

    private async Task SendMessageAsync(string numberTo, string bodyMessage, bool isWhatsApp)
    {
        //TwilioClient.Init(_environmentVariables.TwilioSettings.AccountSid, _environmentVariables.TwilioSettings.AuthToken);

        //if (isWhatsApp)
        //{
        //    await MessageResource.CreateAsync(
        //        body: bodyMessage,
        //        from: new PhoneNumber($@"whatsapp:{_environmentVariables.TwilioSettings.TwilioNumber}"),
        //        to: new PhoneNumber($@"whatsapp:{numberTo}")
        //    );
        //}
        //else
        //{
        //    await MessageResource.CreateAsync(
        //        body: bodyMessage,
        //        from: new PhoneNumber(_environmentVariables.TwilioSettings.TwilioNumber),
        //        to: new PhoneNumber(numberTo)
        //    );
        //}

        await Task.CompletedTask;
    }

    public async Task SendWhatsAppMessageAsync(string numberTo, string bodyMessage)
    {
        await SendMessageAsync(numberTo, bodyMessage, true);
    }

    public async Task SendSmsMessageAsync(string numberTo, string bodyMessage)
    {
        await SendMessageAsync(numberTo, bodyMessage, false);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
