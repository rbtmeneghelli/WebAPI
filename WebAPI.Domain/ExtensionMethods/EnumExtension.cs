using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebAPI.Domain.ExtensionMethods;

public static class EnumExtensionMethod
{
    public static string GetDisplayName(this Enum value)
    {
        return value
            .GetType()
            .GetMember(nameof(value))
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayAttribute>(false)
            ?.Name
            ?? nameof(value);
    }

    public static string GetDisplayShortName(this Enum value)
    {
        return value
            .GetType()
            .GetMember(nameof(value))
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayNameAttribute>(false)
            ?.DisplayName
            ?? nameof(value);
    }

    public static T[] GetEnumValues<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");

        return (T[])Enum.GetValues(typeof(T));
    }
}
