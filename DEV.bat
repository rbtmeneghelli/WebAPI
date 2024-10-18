C:

setx WebAPI_Docker "server=sqlData;database=DefaultAPI;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=true;";
setx WebAPI_KissLog "{"OrganizationId": "XXXX", "ApplicationId": "XXXX", "ApiUrl": "https://api.kisslog.net"}";
setx WebAPI_Logs "Server=.\\SQLEXPRESS;Database=DefaultAPI_Logs;User Id=sa;Password=#XXXX;MultipleActiveResultSets=true;trustservercertificate=true;";
setx WebAPI_Sql "Server=.\\SQLEXPRESS;Database=DefaultAPI;User Id=sa;Password=#XXXX;MultipleActiveResultSets=true;trustservercertificate=true;";
setx WebAPI_Cors "["http://localhost:4200", "https://localhost:4200", "https://api.kisslog.net/", "http://api.kisslog.net/", "http://localhost:5187"]";
setx WebAPI_MongoDb "mongodb://localhost:27017";
setx WebAPI_RabbitMQ "{"HostName": "localhost", "UserName": "guest", "Password": "guest"}";
setx WebAPI_Kafka "{"BootstrapServers": "localhost:9092"}";
setx WebAPI_ServiceBus "{"Server": "localhost"}";
setx WebAPI_SendGrid "{"ApiKey": "XPTO", "Client": "localhost", "EmailSender": "non-reply@webapi.com.br", "EmailSenderName": "WebAPI"}"
setx WebAPI_Environment "5";
setx WebAPI_Version "1.0.0";

pause