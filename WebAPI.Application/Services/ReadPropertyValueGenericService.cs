using WebAPI.Domain.ExtensionMethods;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Application.Services;

public sealed class ReadPropertyValueGenericService<TSource, TDestination> : IReadPropertyValueGenericService<TSource, TDestination> where TSource : class where TDestination : class
{
    private bool PropertyIsNotValid(object obj) => GuardClauses.ObjectIsNull(obj) ? true : false;

    private void GetItemFromListToRead(IEnumerable elems)
    {
        foreach (var item in elems)
        {
            ReadPropertyFromObject(item);
        }
    }

    private void GetItemFromObjectToRead(object propValue) => ReadPropertyFromObject(propValue);

    private bool IsNotList(object obj)
    {
        if (GuardClauses.ObjectIsNull(obj))
            return true;

        else if (obj is IList &&
                 obj.GetType().IsGenericType &&
                 obj.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
        {
            return false;
        }

        return true;
    }

    private bool IsNotObject(object obj)
    {
        if (GuardClauses.ObjectIsNull(obj))
            return true;

        else if (obj.GetType() == typeof(TSource))
        {
            return false;
        }

        return true;
    }

    private void makeReplaceSpecialCharactersInResponse(PropertyInfo property, object obj)
    {
        GeneralMethod extensionMethods = GeneralMethod.GetLoadExtensionMethods();
        List<string> charactersStringList = new List<string>() { "%", "'", "#", "“", "”", "`", "(", ")", "\"" };
        string data = string.Empty;

        if (property.PropertyType == typeof(string))
        {
            charactersStringList.ForEach(spCharacter =>
            {
                data = property.GetValue(obj, null) as string;

                if (GuardClauses.IsNullOrWhiteSpace(data) == false)
                {
                    string base64Decoded = StringExtensionMethod.EncodingString(spCharacter);
                    if (data.IndexOf(base64Decoded) != -1)
                    {
                        property.SetValue(obj, Regex.Replace(data.ApplyTrim(), base64Decoded, spCharacter, RegexOptions.IgnoreCase));
                    }
                }
            });
        }
    }

    public object ReadPropertyFromObject(object obj)
    {
        if (PropertyIsNotValid(obj))
            return obj;

        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            object propValue = property.GetValue(obj, null);
            var elems = propValue as IEnumerable;

            if (elems != null)
            {
                GetItemFromListToRead(elems);
            }
            if (property.PropertyType.Assembly == objType.Assembly)
            {
                GetItemFromObjectToRead(propValue);
            }
            else
            {
                makeReplaceSpecialCharactersInResponse(property, obj);
            }
        }

        return obj;
    }

    public TDestination TradeSpecialCharactersToStringFromObject(object obj)
    {
        if (IsNotObject(obj))
            return obj as TDestination;

        return ReadPropertyFromObject(obj) as TDestination;
    }

    public TDestination TradeSpecialCharactersToStringFromList(object obj)
    {
        if (IsNotList(obj))
            return obj as TDestination;

        List<TSource> result = new List<TSource>();

        foreach (object objItem in obj as IList)
        {
            var item = ReadPropertyFromObject(objItem) as object;
            result.Add((TSource)item);
        }

        return result as TDestination;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

public class Teste
{
    public void ShowResult()
    {
        var result = new ReadPropertyValueGenericService<User, List<User>>().TradeSpecialCharactersToStringFromList(BuildUserList()) as List<User>;
        var result2 = new ReadPropertyValueGenericService<User, User>().TradeSpecialCharactersToStringFromObject(BuildUser()) as User;
        Console.WriteLine("OK");
    }

    private User BuildUser(int id = 1)
    {
        return new User() { Id = id, Login = "Dev JQ== KA== KQ==" };
    }

    private List<User> BuildUserList()
    {
        List<User> result = new List<User>();
        for (int i = 0; i < 2; i++)
        {
            result.Add(BuildUser(i));
        }
        return result;
    }
}