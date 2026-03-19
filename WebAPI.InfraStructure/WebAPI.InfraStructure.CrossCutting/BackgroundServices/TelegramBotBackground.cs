using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using WebAPI.Domain.Interfaces.Services.Common;

namespace WebAPI.InfraStructure.CrossCutting.BackgroundServices;

public class TelegramBotBackground : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    private const string TOKEN_TELEGRAM_BOT = "SEU_TOKEN_TELEGRAM";
    private const string CELPHONE_FIX = "5500900001234";
    public TelegramBotBackground()
    {

    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var _iMetaService = scope.ServiceProvider.GetRequiredService<IMetaService>();

        var botClient = new TelegramBotClient(TOKEN_TELEGRAM_BOT);

        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(90));

        botClient.StartReceiving(
            async (bot, update, token) =>
            {
                if (update.Message?.Text != null)
                {
                    var mensagem = update.Message.Text;
                    await _iMetaService.SendMessageToWhatsApp(CELPHONE_FIX, mensagem);
                }
            },
            async (bot, exception, token) =>
            {
                Console.WriteLine(exception.Message);
            },
            cancellationToken: cts.Token
        );
    }
}
