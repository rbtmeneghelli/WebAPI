using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace WebJobs.DefaultWebAPI
{
    public class WebAPIJob
    {
        private static readonly object _lockObject = new object();

        [FunctionName("DefaultWebAPIJob")]
        public void Run([TimerTrigger("* */1 5-23 * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            lock (_lockObject)
            {
                log.LogInformation("Iniciando o DefaultWebAPIJob");
                Thread.Sleep(5000);
                log.LogInformation("Finalizando o DefaultWebAPIJob");
            }
        }
    }
}