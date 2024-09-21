using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IKissLogService
{
    void SaveLogOnKissLog(string errorMessage, EnumLogger enumLogger);
    public void SaveLogOnSeriLog(EnumLogger enumLogger, string className = "", string methodName = "", string messageError = "", string obj = "");
}
