using System.Globalization;

namespace WebAPI.Domain.ExtensionMethods;

public sealed class DateOnlyExtensionMethods
{
    #region [Aplicando padrão Singleton do Design Pattern]

    private static readonly DateOnlyExtensionMethods Instance = new DateOnlyExtensionMethods();

    public static DateOnlyExtensionMethods GetLoadDateOnlyService()
    {
        return Instance;
    }

    #endregion

    public DateOnly GetDate() => DateOnly.FromDateTime(FixConstants.GetDateTimeNowFromBrazil());
    public DateOnly SetDateOnly(int year, int month, int day) => new DateOnly(year, month, day);
    public DateOnly ConvertDateTimeToDateOnly(DateTime dateTime) => DateOnly.FromDateTime(dateTime);
    public int NumberDaysOfLife(DateOnly birthDay) => GetDate().DayNumber - birthDay.DayNumber;
    public int GetAgeByDays(DateOnly birthDay) => Math.Abs(NumberDaysOfLife(birthDay) / 365);
    public int GetAgeByYear(DateOnly birthDay) => Math.Abs(GetDate().Year - birthDay.Year);
    public DateTime GetDateTimeFromString(string dateTime) => DateTime.ParseExact(dateTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    public DateTime FirstDayCurrentMonth()
    {
        return DateTime.Parse($"01/{FixConstants.GetDateTimeNowFromBrazil().Month}/{FixConstants.GetDateTimeNowFromBrazil().Year}");
    }
    public DateTime GetNextUtilDay(DateTime dateTime)
    {
        try
        {
            // Caso tenha feriado nacional ou internacional, fazer uma consulta no BD pra isso...depois um IF para validar e somar 1 dia...
            Dictionary<DayOfWeek, DateTime> dictionary = new Dictionary<DayOfWeek, DateTime>();
            dictionary.Add(DayOfWeek.Saturday, dateTime.AddDays(2));
            dictionary.Add(DayOfWeek.Sunday, dateTime.AddDays(1));
            return dictionary.TryGetValue(dateTime.DayOfWeek, out var dtResult) ? dtResult : dateTime;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex.InnerException);
        }
    }
    public DateTime GetCurrentUtilDay()
    {
        return GetNextUtilDay(FirstDayCurrentMonth().AddDays(5));
    }
}
