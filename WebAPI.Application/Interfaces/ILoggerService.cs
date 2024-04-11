namespace WebAPI.Application.Interfaces
{
    public interface ILoggerService<T> where T : class
    {
        void Handle(LogMessage message);
        List<LogMessage> GetLoggerMessages();
        bool HaveLogMessage();
    }
}
