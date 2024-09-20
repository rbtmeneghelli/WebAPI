using Serilog.Events;

namespace WebAPI.Application.InterfacesService;

public interface IKissLogService
{
    void SaveLogOnKissLog(string errorMessage, EnumLogger enumLogger);
    public void SaveLogOnSeriLog(LogEventLevel logEventLevel = LogEventLevel.Information, string className = "", string methodName = "", string messageError = "", string obj = "");
}
