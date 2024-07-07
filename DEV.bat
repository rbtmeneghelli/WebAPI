C:

setx WebAPI_Docker "server=sqlData;database=DefaultAPI;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=true;"
setx WebAPI_KissLog "{"OrganizationId": "XXXX", "ApplicationId": "XXXX", "ApiUrl": "https://api.kisslog.net"}";
setx WebAPI_Logs "Server=.\\SQLEXPRESS;Database=DefaultAPI_Logs;User Id=sa;Password=#XXXX;MultipleActiveResultSets=true;trustservercertificate=true;"
setx WebAPI_Sql "Server=.\\SQLEXPRESS;Database=DefaultAPI;User Id=sa;Password=#XXXX;MultipleActiveResultSets=true;trustservercertificate=true;"
setx WebAPI_Cors "["http://localhost:4200", "https://localhost:4200", "https://api.kisslog.net/", "http://api.kisslog.net/"]"

pause