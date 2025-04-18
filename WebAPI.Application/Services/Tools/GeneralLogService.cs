using KissLog;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public sealed class GeneralLogService : IGeneralLogService
{
    private readonly IKLogger _iKLogger;
    private readonly ILogger<string> _iLogger;

    public GeneralLogService(IKLogger iKLogger, ILogger<string> iLogger)
    {
        _iKLogger = iKLogger;
        _iLogger = iLogger;
    }

    public void SaveLogOnLogger(string message, EnumLogger enumLogger)
    {
        switch (enumLogger)
        {
            case EnumLogger.LogInformation:
                _iLogger.LogInformation(message);
                break;
            case EnumLogger.LogTrace:
                _iLogger.LogTrace(message);
                break;
            case EnumLogger.LogDebug:
                _iLogger.LogDebug(message);
                break;
            case EnumLogger.LogWarning:
                _iLogger.LogWarning(message);
                break;
            case EnumLogger.LogError:
                _iLogger.LogError(message);
                break;
            case EnumLogger.LogCritical:
                _iLogger.LogCritical(message);
                break;
        }
    }

    public void SaveLogOnKissLog(string message, EnumLogger enumLogger)
    {
        switch (enumLogger)
        {
            case EnumLogger.LogTrace:
                _iKLogger.Trace(message);
                break;
            case EnumLogger.LogDebug:
                _iKLogger.Debug(message);
                break;
            case EnumLogger.LogInformation:
                _iKLogger.Info(message);
                break;
            case EnumLogger.LogCritical:
                _iKLogger.Critical(message);
                break;
        }
    }

    public void SaveLogOnSeriLog(EnumLogger enumLogger, string className = "", string methodName = "", string messageError = "", string obj = "")
    {
        // Fazendo o Serilog funcionar pra gravarlog
        Serilog.ILogger log = Log.ForContext(typeof(Serilog.ILogger));
        log.Write
        (
            LogEventLevel.Information,
            "{Class},{Method},{MessageError},{Object},{CreatedDate}",
            className,
            methodName,
            messageError,
            obj,
            DateOnlyExtension.GetDateTimeNowFromBrazil()
        );
    }
}
