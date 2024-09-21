using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services;
public interface ILoggerService<T> where T : class
{
    void Handle(LogMessage message);
    List<LogMessage> GetLoggerMessages();
    bool HaveLogMessage();
}

