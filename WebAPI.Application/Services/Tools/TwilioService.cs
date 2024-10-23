using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public sealed class TwilioService : GenericService, ITwilioService
{
    private EnvironmentVariables _environmentVariables { get; }

    public TwilioService(EnvironmentVariables environmentVariables, INotificationMessageService iNotificationMessageService) : base(iNotificationMessageService)
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
        try
        {
            await SendMessageAsync(numberTo, bodyMessage, true);
        }
        catch (Exception ex)
        {
            Notify($@"Ocorreu uma exception {ex.InnerException} para envio de SMS, segue detalhe do erro: ${ex.Message}");
        }
    }

    public async Task SendSmsMessageAsync(string numberTo, string bodyMessage)
    {
        try
        {
            await SendMessageAsync(numberTo, bodyMessage, false);
        }
        catch (Exception ex)
        {
            Notify($@"Ocorreu a exception {ex.InnerException} para envio de WhatsApp, segue detalhe do erro: ${ex.Message}");
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
