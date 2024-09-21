using WebAPI.Domain.Enums;
using KissLog;
using System.Diagnostics;
using LogMessage = WebAPI.Domain.Models.LogMessage;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.V1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[AllowAnonymous]
public sealed class LoggerController : GenericController
{
    private readonly ILoggerService<LoggerController> _logger;

    public LoggerController(ILoggerService<LoggerController> logger, IMapper mapper, IHttpContextAccessor accessor, INotificationMessageService notificationMessageService, IKLogger iKLogger): base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ShowLogger(); //Metodo executado exclusivamente em modo debug
        _logger.GetLoggerMessages();
        return Ok();
    }

    [Conditional("DEBUG")]
    private void ShowLogger()
    {
        _logger.Handle(new LogMessage("testando...", EnumLogger.LogInformation));
        _logger.Handle(new LogMessage("testando...2", EnumLogger.LogTrace));
    }
}