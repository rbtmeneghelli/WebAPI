using WebAPI.Domain.Enums;

namespace WebAPI.Domain.Interfaces.Services.Common;

public interface IGeneralLogService
{
    void SaveLogOnKissLog(string errorMessage, EnumLogger enumLogger);
    public void SaveLogOnSeriLog(EnumLogger enumLogger, string className = "", string methodName = "", string messageError = "", string obj = "");
}
