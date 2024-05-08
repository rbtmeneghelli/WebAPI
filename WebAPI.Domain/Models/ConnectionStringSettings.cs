namespace WebAPI.Domain.Models;

public sealed record ConnectionStringSettings
{
    private string _DefaultConnectionToDocker;
    private string _DefaultConnection;
    private string _DefaultConnectionLogs;

    public string DefaultConnectionToDocker
    {
        get
        {
            return _DefaultConnectionToDocker;
        }

        init
        {
            _DefaultConnectionToDocker = GetConnectionString(value);
        }
    }

    public string DefaultConnection
    {
        get
        {
            return _DefaultConnection;
        }

        init
        {
            _DefaultConnection = GetConnectionString(value);
        }
    }

    public string DefaultConnectionLogs
    {
        get
        {
            return _DefaultConnectionLogs;
        }

        init
        {
            _DefaultConnectionLogs = GetConnectionString(value);
        }
    }

    public static string GetConnectionString(string varName)
    {
        return Environment.GetEnvironmentVariable(varName)
        .Replace("\\\\", "\\") ?? string.Empty;
    }
}


