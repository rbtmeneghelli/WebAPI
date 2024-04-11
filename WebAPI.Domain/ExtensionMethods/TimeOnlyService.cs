namespace WebAPI.Domain.ExtensionMethods;

public sealed class TimeOnlyExtensionMethod
{
    #region [Aplicando padrão Singleton do Design Pattern]

    private static readonly TimeOnlyExtensionMethod Instance = new TimeOnlyExtensionMethod();

    public static TimeOnlyExtensionMethod GetLoadTimeOnlyService()
    {
        return Instance;
    }

    #endregion

    public TimeOnly SetTimeOnly(int hour, int minute) => new TimeOnly(hour, minute);
    public TimeOnly SetTimeOnly(int hour, int minute, int second) => new TimeOnly(hour, minute, second);
    public TimeOnly SetTimeOnly(int hour, int minute, int second, int milliSecond) => new TimeOnly(hour, minute, second, milliSecond);
    public TimeOnly ConvertStringToTimeOnly(string time) => TimeOnly.Parse(time);
    public double DifferenceTimeInHours(TimeOnly timeStart, TimeOnly timeEnd) => (timeEnd - timeStart).TotalHours;
    public TimeOnly ConvertTimeToTimeOnly(DateTime dateTime) => TimeOnly.FromDateTime(dateTime);
}
