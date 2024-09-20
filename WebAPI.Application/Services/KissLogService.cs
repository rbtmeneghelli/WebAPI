using KissLog;
using Serilog;
using Serilog.Events;
using WebAPI.Application.InterfacesService;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.Services;

public class KissLogService : IKissLogService
{
    private readonly IKLogger _iKLogger;

    public void SaveLogOnKissLog(string errorMessage, EnumLogger enumLogger)
    {
        switch (enumLogger)
        {
            case EnumLogger.LogTrace:
                _iKLogger.Trace("Trace log");
                break;
            case EnumLogger.LogDebug:
                _iKLogger.Debug("Trace log");
                break;
            case EnumLogger.LogInformation:
                _iKLogger.Info("Trace log");
                break;
            case EnumLogger.LogCritical:
                _iKLogger.Critical("Trace log");
                break;
        }
    }

    public void SaveLogOnSeriLog(LogEventLevel logEventLevel = LogEventLevel.Information, string className = "", string methodName = "", string messageError = "", string obj = "")
    {
        // Fazendo o Serilog funcionar pra gravarlog
        ILogger log = Serilog.Log.ForContext(typeof(ILogger));
        log.Write
        (
            logEventLevel,
            "{Class},{Method},{MessageError},{Object},{CreatedDate}",
            className,
            methodName,
            messageError,
            obj,
            DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()
        );
    }
}
