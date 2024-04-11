using Microsoft.Extensions.Logging;

namespace WebAPI.Application.Services
{
    public class LoggerService<T> : ILoggerService<T> where T : class
    {
        private List<LogMessage> _loggerMessages;
        private readonly ILogger<T> _logger;

        public LoggerService(ILogger<T> logger)
        {
            _loggerMessages = new List<LogMessage>();
            _logger = logger;
        }

        public void Handle(LogMessage message)
        {
            _loggerMessages.Add(message);
        }

        public List<LogMessage> GetLoggerMessages()
        {
            _loggerMessages.ForEach(item =>
            {
                SaveLogMessageInKissLog(item);
            });

            return _loggerMessages;
        }

        public bool HaveLogMessage()
        {
            return _loggerMessages?.Count() > 0;
        }

        private void SaveLogMessageInKissLog(LogMessage logMessage)
        {
            switch (logMessage.Type)
            {
                case EnumLogger.LogInformation:
                    _logger.LogInformation(logMessage.Message);
                    break;
                case EnumLogger.LogTrace:
                    _logger.LogTrace(logMessage.Message);
                    break;
                case EnumLogger.LogDebug:
                    _logger.LogDebug(logMessage.Message);
                    break;
                case EnumLogger.LogWarning:
                    _logger.LogWarning(logMessage.Message);
                    break;
                case EnumLogger.LogError:
                    _logger.LogError(logMessage.Message);
                    break;
                case EnumLogger.LogCritical:
                    _logger.LogCritical(logMessage.Message);
                    break;
            }
        }
    }
}
