using WebAPI.Domain.Enums;
using WebAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Domain;

public sealed class GeneralMethod
{
    #region [Aplicando padrão Singleton do Design Pattern]

    private static readonly GeneralMethod Instance = new GeneralMethod();

    private static Dictionary<int, Func<UriBuilderAbstract>> DictionaryUriBuilder = new Dictionary<int, Func<UriBuilderAbstract>>
    {
              { 1, ()=>new UriBuilderDefault() },
              { 2, ()=>new UriBuilderSite() },
    };

    public static GeneralMethod GetLoadExtensionMethods()
    {
        return Instance;
    }

    #endregion

    #region Private Methods

    private int GetRandomNumber(int value, int? minValue = null)
    {
        if (minValue.HasValue)
            return Random.Shared.Next(minValue.GetValueOrDefault(0), value);

        return Random.Shared.Next(value);
    }

    private XmlDocument RemoveXmlDeclaration(XmlDocument doc)
    {
        var declarations = doc.ChildNodes.OfType<XmlNode>().Where(x => x.NodeType == XmlNodeType.XmlDeclaration).ToList();
        declarations.ForEach(x => doc.RemoveChild(x));
        return doc;
    }

    private DropDownList ParseRow(string row)
    {
        var columns = row.Split(',');
        return new DropDownList()
        {
            Id = int.Parse(columns[0]),
            Description = columns[1]
        };
    }

    private string ValidateContentTypeFile(string key)
    {
        Dictionary<string, string> dictionary = new()
        {
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".png", "image/png" },
            { ".pdf", "application/pdf" },
            { ".mp4", "video/mp4" }
        };

        if (dictionary.TryGetValue(key, out var value))
            return value;

        return StringExtensionMethod.GetEmptyString();
    }

    #endregion

    public string RemoveMimeType(string base64)
    {
        var keyValue = "base64,";
        if (!base64.Contains(keyValue))
            return base64;

        var start = base64.LastIndexOf(keyValue);
        return base64.Substring(start).ApplyReplace(keyValue, "");
    }

    public string BuildPassword(int length)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        StringBuilder res = new StringBuilder();
        while (0 < length--)
        {
            res.Append(valid[GetRandomNumber(valid.Length)]);
        }
        return res.ToString();
    }

    public string ConvertObjectParaJSon<T>(T obj)
    {
        try
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, obj);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        catch
        {
            throw;
        }
    }

    public T ConvertJSonParaObject<T>(string jsonString)
    {
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)serializer.ReadObject(ms);
            return obj;
        }
        catch
        {
            throw;
        }
    }

    public string RemoveHtmlTags(string value)
    {
        var tagList = Regex.Matches(value, @"(?<=</?)([^ >/]+)")
                           .Select(p => p.ToString())
                           .Distinct(StringComparer.OrdinalIgnoreCase)
                           .ToArray();

        var newText = value.ApplyTrim();

        foreach (var tag in tagList)
        {
            var start = newText.IndexOf($"<{tag}");
            var end = newText.IndexOf(">");

            if (start >= 0 && end >= 0 && end < newText.Length)
            {
                var lenght = end - start + 1;
                if (lenght > 0 && (start + lenght) < newText.Length)
                {
                    var removed = newText.ApplySubString(start, lenght);
                    newText = newText.ApplyReplace(removed, "");
                }
            }

            newText = newText.ApplyReplace($"</{tag}>", "");
        }

        return newText;
    }

    public bool ValidEmail(string email)
    {
        bool isEmailValid = false;

        string emailRegex = string.Format("{0}{1}",
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

        try
        {
            isEmailValid = Regex.IsMatch(email, emailRegex);
        }
        catch (RegexMatchTimeoutException)
        {
            isEmailValid = false;
        }

        return isEmailValid;
    }

    public bool ValidCpf(string vrCPF)
    {
        bool equal = true;
        string value = vrCPF.Replace(".", "").Replace("-", "");

        if (value.Length != 11)
            return false;

        for (int i = 1; i < 11 && equal; i++)

            if (value[i] != value[0])

                equal = false;

        if (equal || value == "12345678909")
            return false;

        int[] numbers = new int[11];

        for (int i = 0; i < 11; i++)

            numbers[i] = int.Parse(value[i].ToString());

        int sum = 0;

        for (int i = 0; i < 9; i++)

            sum += (10 - i) * numbers[i];

        int result = sum % 11;

        if (result == 1 || result == 0)
        {
            if (numbers[9] != 0)
                return false;
        }

        else if (numbers[9] != 11 - result)
            return false;

        sum = 0;

        for (int i = 0; i < 10; i++)

            sum += (11 - i) * numbers[i];

        result = sum % 11;

        if (result == 1 || result == 0)
        {
            if (numbers[10] != 0)
                return false;
        }

        else
            if (numbers[10] != 11 - result)
            return false;

        return true;

    }

    public bool ValidCnpj(string vrCNPJ)
    {

        string CNPJ = vrCNPJ.ApplyReplace(".", "").ApplyReplace("/", "").ApplyReplace("-", "");

        int[] digitos, soma, resultado;

        int nrDig;

        string ftmt;

        bool[] CNPJOk;

        ftmt = "6543298765432";

        digitos = new int[14];

        soma = new int[2];

        soma[0] = 0;

        soma[1] = 0;

        resultado = new int[2];

        resultado[0] = 0;

        resultado[1] = 0;

        CNPJOk = new bool[2];

        CNPJOk[0] = false;

        CNPJOk[1] = false;

        try
        {

            for (nrDig = 0; nrDig < 14; nrDig++)
            {

                digitos[nrDig] = int.Parse(

                    CNPJ.ApplySubString(nrDig, 1));

                if (nrDig <= 11)

                    soma[0] += (digitos[nrDig] *

                      int.Parse(ftmt.ApplySubString(

                      nrDig + 1, 1)));

                if (nrDig <= 12)

                    soma[1] += (digitos[nrDig] *

                      int.Parse(ftmt.ApplySubString(

                      nrDig, 1)));

            }

            for (nrDig = 0; nrDig < 2; nrDig++)
            {

                resultado[nrDig] = (soma[nrDig] % 11);

                if ((resultado[nrDig] == 0) || (

                     resultado[nrDig] == 1))

                    CNPJOk[nrDig] = (

                    digitos[12 + nrDig] == 0);

                else

                    CNPJOk[nrDig] = (

                    digitos[12 + nrDig] == (

                    11 - resultado[nrDig]));

            }

            return (CNPJOk[0] && CNPJOk[1]);

        }

        catch
        {
            return false;
        }

    }

    public string BuildPassword()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVYWXZ";
        return $"{letters.ApplySubString(GetRandomNumber(25, 0), 1)}{GetRandomNumber(9, 0)}{letters.ApplySubString(GetRandomNumber(25, 0), 1)}{GetRandomNumber(9, 0)}{letters.ApplySubString(GetRandomNumber(25, 0), 1)}";
    }

    public void ValidItensList()
    {
        List<string> arrNames = new List<string>() { "Macoratti", "Visual C#", null, ".NET", "2017" };
        string str = arrNames.TrueForAll(delegate (string val)
        {
            if (GuardClauses.ObjectIsNull(val))
                return false;
            else
                return true;
        }).ToString();
        Console.WriteLine("Todos os valores da lista são diferentes de null ? Resposta = {0}", str);
    }

    public void ValidItensArray()
    {
        var list = new List<int>() { 4, 6, 7, 8, 34, 33, 11 };
        //verifica se existe um valor menor ou igual a zero
        var isTrue = list.TrueForAll(n => n > 0);
        Console.WriteLine("Todos os valores da lista são diferentes de zero ? Resposta = {0}", isTrue);
    }

    public bool ValidTelAndCel(string numerosDigitados)
    {
        string[] stDigitoMovel = new string[] { "6", "7", "8", "9" };
        string[] stDigitosFixo = new string[] { "1", "2", "3", "4", "5" };

        if (GuardClauses.IsNullOrWhiteSpace(numerosDigitados) == false && numerosDigitados.Length > 5)
        {
            var digitosMoveis = string.Join(",", stDigitoMovel);
            var digitosFixos = string.Join(",", stDigitosFixo);

            if (numerosDigitados.Length < 13 && digitosMoveis.Contains(numerosDigitados.ApplySubString(5, 1)))
                return true;

            else if (numerosDigitados.Length < 14 && digitosFixos.Contains(numerosDigitados.ApplySubString(5, 1)))
                return true;
        }

        return false;
    }

    public string ConvertImageToBase64(string pImage)
    {
        var imagePath = Path.GetFileName(pImage);
        var imageArray = File.ReadAllBytes(imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(imageArray)}";
    }

    public string GetColorHex(string[] arrColorUsed)
    {
        string color = StringExtensionMethod.GetEmptyString();
        while (true)
        {
            color = GetColorHex();
            if (arrColorUsed.Any(x => x != color))
                break;
        }

        return color;
    }

    public string GetColorHex()
    {
        int r = GetRandomNumber(255, 0);
        int g = GetRandomNumber(255, 0);
        int b = GetRandomNumber(255, 0);
        int a = GetRandomNumber(255, 0);
        string cor = $"#{Color.FromArgb(a, r, g, b).Name.ApplyTrim().ApplySubString(0, 6)}";
        return cor;
    }

    public string GetColorRgb(string[] arrColorUsed)
    {
        string color = StringExtensionMethod.GetEmptyString();
        while (true)
        {
            color = GetColorRgb().ToString();
            if (arrColorUsed.Any(x => x != color))
                break;
        }

        return color;
    }

    public Color GetColorRgb()
    {
        Color randomColor = Color.FromArgb(GetRandomNumber(256), GetRandomNumber(256), GetRandomNumber(256));
        return randomColor;
    }

    public DateTime LastDayPreviousMonth(string currentMonth, string currentYear)
    {
        DateTime firstMonthDay = DateTime.Parse($"01/{currentMonth}/{currentYear}");
        DateTime lastMonthDay = firstMonthDay.AddDays(-1);
        return lastMonthDay;
    }

    public DateTime LastDayCurrentMonth(string currentMonth, string currentYear)
    {
        DateTime firstMonthDay = DateTime.Parse($"01/{currentMonth}/{currentYear}");
        DateTime firstMonthNextDay = firstMonthDay.AddMonths(1);
        DateTime lastMonthDay = firstMonthNextDay.AddDays(-1);
        return lastMonthDay;
    }

    public DataTable ConvertDynamicListToDataTable(IEnumerable<dynamic> list)
    {
        var json = JsonSerializer.Serialize(list);
        DataTable dt = (DataTable)JsonSerializer.Deserialize(json, (typeof(DataTable)));
        return dt;
    }

    public void CleanFiles(string rootFolder, string user)
    {
        string[] arrFiles = new string[] { "Arquivo1", "Arquivo2" };
        foreach (var item in arrFiles)
        {
            string fileName = $"{item}_{user}.xlsx";
            FileInfo fullPath = new FileInfo(Path.Combine(rootFolder, fileName));
            if (fullPath.Exists)
                fullPath.Delete();
        }
    }

    public void ShowAllDrivers()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        Array.ForEach(drives, drive =>
        {
            if (drive.IsReady)
            {
                Console.WriteLine($"Drive {drive.Name} esta pronto.");
                Console.WriteLine($"Espaço disponível livre: {drive.AvailableFreeSpace} " +
                 $"bytes ou {FormatBytes(drive.AvailableFreeSpace)}");
                Console.WriteLine($"Formato : {drive.DriveFormat}");
                Console.WriteLine($"Tipo: {drive.DriveType}");
                Console.WriteLine($"Nome: {drive.Name}");
                Console.WriteLine("Nome Completo da Raiz : " + $"{drive.RootDirectory.FullName}");
                Console.WriteLine($"Espaço total Livre : {drive.TotalFreeSpace} bytes ou {FormatBytes(drive.TotalFreeSpace)}");
                Console.WriteLine($"Espaço Total : {drive.TotalSize} bytes ou {FormatBytes(drive.TotalSize)}");
                Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
            }
            else
            {
                Console.WriteLine($"Drive {drive.Name} não esta pronto.");
            }
            Console.WriteLine();
        });
    }

    public void ShowAllAlternativeDrivers()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            if (drive.IsReady)
            {
                Console.WriteLine($"Nome do Drive: {drive.Name}");
                Console.WriteLine($"Formato: {drive.DriveFormat}");
                Console.WriteLine($"Tipo: {drive.DriveType}");
                Console.WriteLine($"Diretório Raiz : {drive.RootDirectory}");
                Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                Console.WriteLine($"Espaço Livre: {drive.TotalFreeSpace}");
                Console.WriteLine($"Espaço disponível: {drive.AvailableFreeSpace}");
                Console.WriteLine($"Tamanho Total: {drive.TotalSize}");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }

    private string FormatBytes(long bytes)
    {
        if (bytes >= 0x1000000000000000) { return ((double)(bytes >> 50) / 1024).ToString("0.### EB"); }
        if (bytes >= 0x4000000000000) { return ((double)(bytes >> 40) / 1024).ToString("0.### PB"); }
        if (bytes >= 0x10000000000) { return ((double)(bytes >> 30) / 1024).ToString("0.### TB"); }
        if (bytes >= 0x40000000) { return ((double)(bytes >> 20) / 1024).ToString("0.### GB"); }
        if (bytes >= 0x100000) { return ((double)(bytes >> 10) / 1024).ToString("0.### MB"); }
        if (bytes >= 0x400) { return ((double)(bytes) / 1024).ToString("0.###") + " KB"; }
        return bytes.ToString("0 Bytes");
    }

    public string GetUrlDetails(string url)
    {
        Uri uri = new Uri(url);
        StringBuilder result = new StringBuilder();
        result.Append($"AbsolutePath = {uri.AbsolutePath} || ");
        result.Append($"AbsoluteUri = {uri.AbsoluteUri} || ");
        result.Append($"Authority = {uri.Authority} || ");
        result.Append($"DnsSafeHost = {uri.DnsSafeHost} || ");
        result.Append($"Fragment = {uri.Fragment} || ");
        result.Append($"Host = {uri.Host} || ");
        result.Append($"HostNameType = {uri.HostNameType} || ");
        result.Append($"IsAbsoluteUri = {uri.IsAbsoluteUri} || ");
        result.Append($"IsDefaultPort = {uri.IsDefaultPort} || ");
        result.Append($"IsFile = {uri.IsFile} || ");
        result.Append($"IsLoopback = {uri.IsLoopback} || ");
        result.Append($"IsUnc = {uri.IsUnc} || ");
        result.Append($"LocalPath = {uri.LocalPath} || ");
        result.Append($"OriginalString = {uri.OriginalString} || ");
        result.Append($"PathAndQuery = {uri.PathAndQuery} || ");
        result.Append($"Port = {uri.Port} || ");
        result.Append($"Query = {uri.Query} || ");
        result.Append($"Scheme = {uri.Scheme} || ");
        result.Append($"UserEscaped = {uri.UserEscaped} || ");
        result.Append($"UserInfo = {uri.UserInfo} || ");
        result.Append(new string('-', 10));
        return result.ToString();
    }

    private bool CheckUrlIsValid(string baseUrl, string url)
    {
        // Vale a pena destacar o método IsBaseOf que determina se a instância Uri atual é uma base da instância da Uri especificada, ou seja, ele permite determinar se uma Uri esta contida no início da segunda Uri.
        Uri baseUri = new Uri(baseUrl);
        Uri uriAddress = new Uri(url);
        if (baseUri.IsBaseOf(uriAddress))
            return true;
        return false;
    }

    public string BuildUrlWithUriBuilder(int option)
    {
        UriBuilderAbstract uriBuilder = DictionaryUriBuilder[option]();
        return uriBuilder.GetUrl();
    }

    public bool CheckIpAddressIsValid(string ipAddress)
    {
        IPAddress IP;
        bool flag = false;
        try
        {
            flag = IPAddress.TryParse(ipAddress, out IP);
            if (flag)
                return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro : " + ex.Message);
        }
        return false;
    }

    public IPAddress GetIPAddress(string hostName)
    {
        // A partir de um hostname, o metodo ira retornar o endereço de IP
        Ping ping = new Ping();
        try
        {
            var replay = ping.Send(hostName);
            if (replay.Status == IPStatus.Success)
            {
                return replay.Address;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ConvertToDataTable<T>(IEnumerable<T> list)
    {
        DataTable table = CreateTable<T>();
        Type entityType = typeof(T);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
        foreach (T item in list)
        {
            DataRow row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                row[prop.Name] = prop.GetValue(item);
            }
            table.Rows.Add(row);
        }
        return table;
    }

    private DataTable CreateTable<T>()
    {
        Type entityType = typeof(T);
        DataTable table = new DataTable(entityType.Name);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
        foreach (PropertyDescriptor prop in properties)
        {
            table.Columns.Add(prop.Name, prop.PropertyType);
        }
        return table;
    }

    public string ConvertTimeSpanToString(TimeSpan hour)
    {
        if (hour != null)
        {
            if (hour.Hours < 10 && hour.Minutes < 10)
                return $"0{hour.Hours}:0{hour.Minutes}";
            else if (hour.Hours >= 10 && hour.Minutes < 10)
                return $"{hour.Hours}:0{hour.Minutes}";
            else if (hour.Hours < 10 && hour.Minutes >= 10)
                return $"0{hour.Hours}:0{hour.Minutes}";
            else
                return $"{hour.Hours}:{hour.Minutes}";
        }

        return StringExtensionMethod.GetEmptyString();
    }

    public string AddZeroToLeftOrRight(string text, int qty = 8, bool isLeft = true)
    {
        if (GuardClauses.IsNullOrWhiteSpace(text) == false)
            return isLeft ? text.PadLeft(qty, '0') : text.PadRight(qty, '0');
        return text;
    }

    public IEnumerable<DropDownList> GetListDrivers()
    {
        int count = 0;
        List<DropDownList> list = new List<DropDownList>();
        foreach (var drive in DriveInfo.GetDrives())
        {
            if (((drive.TotalFreeSpace / drive.TotalSize) * 100) < 90)
            {
                list.Add(new DropDownList() { Id = count, Description = drive.Name });
                count++;
            }
        }
        return list;
    }

    public string[] GetLocalDriversFromMachine()
    {
        return Environment.GetLogicalDrives();
    }

    public void BrokePassword(string password, int sizePassword, string keys)
    {
        // Exemplo: (123Abc, 8, "")

        char firstChar = 'a';
        char lastChar = 'z';
        long retries = 0;
        bool finish = false;

        if (keys == password)
        {
            finish = true;
        }

        if (keys.Length == sizePassword || finish == true)
        {
            return;
        }

        for (char c = firstChar; c <= lastChar; c++)
        {
            retries++;
            BrokePassword(password, sizePassword, keys + c);
        }
    }

    public bool CheckPassword(string password)
    {
        if (password.Length < 6 || password.Length > 15)
            return false;
        else if (password.Contains(" "))
            return false;
        else if (!password.Any(char.IsUpper))
            return false;
        else if (!password.Any(char.IsLower))
            return false;

        for (int i = 0; i < password.Length - 1; i++)
        {
            if (password[i] == password[i + 1])
                return false;
        }

        string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
        char[] specialCharactersArray = specialCharacters.ToCharArray();
        foreach (char c in specialCharactersArray)
        {
            if (password.Contains(c))
                return true;
        }

        return false;
    }

    public string ConvertXmlToJson(string xml)
    {
        if (GuardClauses.IsNullOrWhiteSpace(xml) == false)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            doc = RemoveXmlDeclaration(doc);
            var json = JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
            return json.ToString();
        }

        return null;
    }

    public string CreateCpf()
    {
        int sum = 0, rest = 0;
        int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string result = GetRandomNumber(999999999, 100000000).ToString();

        for (int i = 0; i < 9; i++)
            sum += int.Parse(result[i].ToString()) * mult1[i];

        rest = sum % 11;
        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;

        result = result + rest;
        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(result[i].ToString()) * mult2[i];

        rest = sum % 11;

        if (rest < 2)
            rest = 0;
        else
            rest = 11 - rest;

        result = result + rest;
        return result;
    }

    public IEnumerable<DropDownList> ReadCsvFile(string path)
    {
        return File.ReadAllLines(path)
        .Skip(1)
        .Where(row => row.Length > 0)
        .Select(row => ParseRow(row)).ToList();
    }

    public (string Type, string Extension) GetMemoryStreamType(EnumMemoryStreamFile key)
    {
        Dictionary<EnumMemoryStreamFile, (string, string)> dictionary = new Dictionary<EnumMemoryStreamFile, (string, string)>
        {
            { EnumMemoryStreamFile.XLSX, ("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx") },
            { EnumMemoryStreamFile.PDF, ("application/pdf", "pdf") },
            { EnumMemoryStreamFile.DOCX, ("application/octet-stream", "docx") },
            { EnumMemoryStreamFile.ZIP, ("application/zip", "zip") },
            { EnumMemoryStreamFile.PNG, ("image/png", "png") }
        };

        return dictionary[key];
    }

    public string GetCron(EnumJobTypeExecution typeExecution)
    {
        Dictionary<EnumJobTypeExecution, string> dictionary = new Dictionary<EnumJobTypeExecution, string>
        {
            { EnumJobTypeExecution.Never, "0 0 31 2 *" },
            { EnumJobTypeExecution.Daily, "0 0 * * *" },
            { EnumJobTypeExecution.Weekly, "0 0 * * 1" },
            { EnumJobTypeExecution.Monthly, "0 0 1 * *" },
            { EnumJobTypeExecution.Yearly, "0 0 1 1 *" }
        };
        return dictionary[typeExecution];
    }

    public string StartDateToJob(EnumJobTypeExecution key)
    {
        DateTime currentDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        Dictionary<EnumJobTypeExecution, string> dictionary = new Dictionary<EnumJobTypeExecution, string>
        {
            { EnumJobTypeExecution.Daily, currentDate.ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Weekly, GetFirstDayOfWeek(currentDate).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Monthly, new DateTime(currentDate.Year, currentDate.Month, 1).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Yearly, new DateTime(currentDate.Year, 1, 1).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Never, "" }
        };
        return dictionary[key];
    }

    public string EndDateToJob(EnumJobTypeExecution key)
    {
        DateTime currentDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        Dictionary<EnumJobTypeExecution, string> dictionary = new Dictionary<EnumJobTypeExecution, string>
        {
            { EnumJobTypeExecution.Daily, currentDate.ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Weekly, GetLastDayOfWeek(currentDate).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Monthly, new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Yearly, new DateTime(currentDate.Year, 12, 31).ToString("yyyy-MM-dd") },
            { EnumJobTypeExecution.Never, "" }
        };
        return dictionary[key];
    }

    public DateTime GetFirstDayOfWeek(DateTime date)
    {
        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        var diff = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
        if (diff < 0)
            diff += 7;
        return date.AddDays(-diff).Date;
    }

    public DateTime GetLastDayOfWeek(DateTime date)
    {
        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        var diff = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
        if (diff < 0)
            diff += 7;
        DateTime start = date.AddDays(-diff).Date;
        return start.AddDays(6).Date;
    }

    public string CreateStrongPassword(int numCharacters = 10, bool includeSpecialChars = true, bool onlyUpperCase = false)
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        const string special = "!@#$%ˆ&*(){}[];";
        var chars = includeSpecialChars ? (valid + special) : valid;
        var res = new StringBuilder();
        while (0 < numCharacters--)
            res.Append(chars[GetRandomNumber(chars.Length)]);
        return onlyUpperCase ? res.ToString().ApplyTrim() : res.ToString().ApplyTrim();
    }

    public string[] RepeatValues(int times, string word)
    {
        times = times > 0 ? times : 1;

        if (GuardClauses.IsNullOrWhiteSpace(word) == false)
            return Enumerable.Range(1, times).Select(x => word).ToArray();

        return Enumerable.Range(1, times).Select(x => "gray").ToArray();
    }

    public async Task<byte[]> SetFileToByteArray(IFormFile formfile)
    {
        MemoryStream ms = new MemoryStream(new byte[formfile.Length]);
        await formfile.CopyToAsync(ms);
        return ms.ToArray();
    }

    public void CreateJsonFile<T>(T model, string fileName = "arquivo.json")
    {
        File.WriteAllText(fileName, model.SerializeObject());
    }

    public void CreateXmlFile<T>(T model, string fileName = "arquivo.xml")
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        xmlSerializer.Serialize(new FileStream(fileName, FileMode.OpenOrCreate), model);
    }

    public T ConvertXmlToObject<T>(string xmlFile)
    {
        StreamReader xmlStream = new StreamReader(xmlFile);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        var result = (T)serializer.Deserialize(xmlStream);
        return result;
    }

    public Match EncontrarOcorrenciaDe(string fonte, string criterio, int ocorrencia)
    {
        Regex RE = new Regex(criterio, RegexOptions.Multiline);

        if (ocorrencia < 1)
            throw (new ArgumentException("Não pode ser menor que 1", nameof(ocorrencia)));

        MatchCollection correspondencias = RE.Matches(fonte);

        if (ocorrencia >= correspondencias.Count)
            return (null);

        return (correspondencias[ocorrencia]);
    }

    public IEnumerable<Match> EncontrarCadaOcorrenciaDe(string fonte, string criterio, int ocorrencia)
    {
        List<Match> ocorrencias = new List<Match>();
        Regex RE = new Regex(criterio, RegexOptions.Multiline);

        if (ocorrencia < 1)
            throw (new ArgumentException("Não pode ser menor que 1", nameof(ocorrencia)));

        MatchCollection correspondencias = RE.Matches(fonte);

        for (int index = (ocorrencia - 1); index < correspondencias.Count; index += ocorrencia)
        {
            ocorrencias.Add(correspondencias[index]);
        }

        return (ocorrencias);
    }

    /// <summary>
    /// Nesse metodo nós iremos receber um base64 em string
    /// </summary>
    /// <param name="file"></param>
    /// <param name="imgFile">Esse parametro tem que ser formado por um guid + "_" + nomearquivo</param>
    /// <returns></returns>
    public async Task<(bool, string)> UploadFile(string file, string imgFile)
    {

        if (GuardClauses.IsNullOrWhiteSpace(file))
        {
            return (false, "Forneça uma imagem!");
        }

        var imageDataByteArray = Convert.FromBase64String(file);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgFile);

        if (File.Exists(filePath))
        {
            return (false, "Já existe um arquivo com este nome!");
        }

        await File.WriteAllBytesAsync(filePath, imageDataByteArray);

        return (true, "Upload efetuado com sucesso");
    }

    /// <summary>
    /// Nesse metodo enviamos a imagem por stream sem necessidade de base 64
    /// </summary>
    /// <param name="file"></param>
    /// <param name="imgPrefix">Esse parametro tem que ser formado por um guid + "_"</param>
    /// <returns></returns>
    private async Task<(bool, string)> UploadArquivoAlternativo(IFormFile arquivo, string imgPrefix)
    {
        if (GuardClauses.ObjectIsNull(arquivo) || arquivo.Length == 0)
        {
            return (false, "Forneça uma imagem!");
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgPrefix + arquivo.FileName);

        if (System.IO.File.Exists(path))
        {
            return (false, "Já existe um arquivo com este nome!");
        }

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        return (true, "Upload efetuado com sucesso");
    }

    public bool VerificaSenhaForte(string senha)
    {
        if (GuardClauses.IsNullOrWhiteSpace(senha))
            return false;

        if (GuardClauses.IntervalMaxLengthIsOk(senha, 6, 12))
            return false;

        if (GuardClauses.HasAnyDigit(senha) == false)
            return false;

        if (GuardClauses.HasAnyUpperChar(senha) == false)
            return false;

        if (GuardClauses.HasAnyLowerChar(senha) == false)
            return false;

        if (GuardClauses.HasAnySymbolChar(senha) == false)
            return false;

        var contadorRepetido = 0;
        var ultimoCaracter = '\0';

        foreach (var c in senha)
        {
            if (c == ultimoCaracter)
                contadorRepetido++;
            else
                contadorRepetido = 0;

            if (contadorRepetido == 2)
                return false;

            ultimoCaracter = c;
        }

        return true;
    }

    public string GetQueryAbleToSql(IQueryable sql)
    {
        return sql.ToQueryString();
    }

    public int MethodWithTwoResults(int value, out bool IsOk)
    {
        // Vai retornar o valor armazenado na variavel value, e podemos pegar o valor da variavel IsOk e
        // manipular como se fosse uma variavel local e não so um parametro
        IsOk = value > 0 ? true : false;
        if (value > 0 && value % 2 == 0) value = value * 2;
        else if (value > 0 && value % 3 == 0) value = value * 3;
        else value = 0;
        return value;
    }

    public string GenerateTokenNumbers()
    {
        int count = 0;
        string token = StringExtensionMethod.GetEmptyString();

        while (count < 8)
        {
            int number = GetRandomNumber(9, 0);
            token = string.Concat(token, number.ToString());
        }

        return token.ApplyTrim();
    }

    public string ConvertModelObjectToXml<T>(T modelObject)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        using (StringWriter textWriter = new StringWriter())
        {
            xmlSerializer.Serialize(textWriter, modelObject);
            return textWriter.ToString();
        }
    }

    public string ConvertXmlToJson<T>(string xmlData)
    {
        T modelObject;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        using (StringReader textReader = new StringReader(xmlData))
        {
            modelObject = (T)xmlSerializer.Deserialize(textReader);
        }
        return modelObject.SerializeObject();
    }

    public string ConvertJsonToXml<T>(string jsonData)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        T modelObject = System.Text.Json.JsonSerializer.Deserialize<T>(jsonData, options);

        return ConvertModelObjectToXml<T>(modelObject);
    }

    #region Metodos auxiliares para diminuir o tamanho de arquivos muito extensos, para arquivos compactos

    public byte[] CompressStream(byte[] originalSource)
    {
        using (var outStream = new MemoryStream())
        {
            using (var gzip = new GZipStream(outStream, CompressionMode.Compress))
            {
                gzip.Write(originalSource, 0, originalSource.Length);
            }
            return outStream.ToArray();
        }
    }

    public byte[] DecompressStream(byte[] originalSource)
    {
        using (var sourceStream = new MemoryStream(originalSource))
        {
            using (var outStream = new MemoryStream())
            {
                using (var gzip = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    gzip.CopyTo(outStream);
                }
                return outStream.ToArray();
            }
        }
    }

    #endregion

    public string RetornarTextoComAspas(string textStart, string word, string textEnd)
    {
        return $"{textStart}{FixConstants.QUOTE}{word}{FixConstants.QUOTE}{textEnd}";
    }

    public string GetBytesFromBinaryString(string binary)
    {
        StringBuilder sb = new StringBuilder();

        if (GuardClauses.IsNullOrWhiteSpace(binary) == false)
        {
            string[] binarySplited = binary.Split(' ');

            foreach (var item in binarySplited)
            {
                string binaryContent = item.ApplyTrim();

                if (GuardClauses.IsBinaryString(binaryContent) && GuardClauses.IsNullOrWhiteSpace(binaryContent) == false)
                    sb.Append((char)Convert.ToInt32(binaryContent, 2));

                else if (GuardClauses.IsNullOrWhiteSpace(binaryContent) == false)
                    sb.Append(binaryContent);
            }
        }

        return sb.ToString();
    }

    public string GenerateRandomPassword()
    {
        return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
            .Select(s => s[GetRandomNumber(s.Length)]).ToArray());
    }

    public int GetFibonacciFromNumber(int number)
    {
        if (number == 0 || number == 1) return number;

        int a = 0;
        int b = 1;
        int c = 3;

        for (int i = 2; i <= number; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }

    public int GetRecursiveFibonnaciFromNumber(int number)
    {
        if (number == 0 || number == 1) return number;

        return GetRecursiveFibonnaciFromNumber(number - 1) + GetRecursiveFibonnaciFromNumber(number - 2);
    }

    public int GetFatorialFromNumber(int number)
    {
        int fatorial = 1;

        if (number == 0 || number == 1) return fatorial;

        for (int i = number; i >= 1; i--)
        {
            fatorial = fatorial * i;
        }

        return fatorial;
    }

    public int GetRecursiveFatorialFromNumber(int number)
    {
        if (number == 0 || number == 1) return 1;

        return number * GetRecursiveFatorialFromNumber(number - 1);
    }

    public string ConvertNumberToRomanNumber(int number)
    {
        string result = StringExtensionMethod.GetEmptyString();

        string[] arrRoman = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        int[] arrArabic = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };

        for (int count = 13; count >= 0; count--)
        {
            while (number >= arrArabic[count])
            {
                number -= arrArabic[count];
                result += arrRoman[count];
            }
        }

        return result;
    }

    /// <summary>
    /// Utilizar a biblioteca UDE.NET para que seja possivel a ação
    /// A codificação windows-1252 é para arquivos gerados num MachinTosh
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    //public string GetTextFromFile(string filePath)
    //{
    //    var detector = new CharsetDetector();
    //    byte[] bytes = File.ReadAllBytes(filePath);
    //    detector.Feed(bytes, 0, bytes.Length);
    //    detector.DataEnd();
    //    string charset = detector.Charset ?? "unknown";

    //    if (charset.Equals("unknown", StringComparison.OrdinalIgnoreCase))
    //        return string.Empty;
    //    else if (charset.Equals("windows-1252", StringComparison.OrdinalIgnoreCase))
    //        return File.ReadAllText(filePath, Encoding.Unicode);
    //    else
    //        return File.ReadAllText(filePath, Encoding.Default);
    //}

    public bool CheckIsValidMailAddress(string mailAddress)
    {
        return MailAddress.TryCreate(mailAddress, out var _);
    }

    public bool IsValidCousinNumber(int numCousin)
    {
        bool numPrimo = true;

        for (int divider = 2; divider <= Math.Sqrt(numCousin); divider++)
        {
            if (numCousin % divider == 0)
            {
                numPrimo = false;
                break;
            }
        }

        return numPrimo;
    }

    public bool IsValidCousinNumberByLINQ(int numCousin)
    {
        return Enumerable.Range(2, (int)Math.Sqrt(numCousin) - 1).All(divider => numCousin % divider != 0);
    }

    /// <summary>
    /// Valores padrão para expressão lambda no C#12
    /// Esse procedimento a partir do NET 12 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="minValue"></param>
    //public void PrintValueBiggerThanMinValue(List<int> list, int minValue = 0)
    //{
    //    var filtroValorMinimo = (decimal valorMinimo = 0) =>
    //    {
    //        list.FindAll(x => x > valorMinimo);
    //    };

    //    foreach (var produto in filtroValorMinimo(minValue))
    //    {
    //    }
    //}

    public IEnumerable<PropertyDescriptor> GetDataProperties<T>() where T : class
    {
        var listaPropriedades = TypeDescriptor.GetProperties(typeof(T)).Cast<PropertyDescriptor>().ToList();
        var listaPropriedadesNome = typeof(T).GetProperties().Select(x => x.GetCustomAttribute<DisplayNameAttribute>()).Where(x => x != null).Select(x => x.DisplayName);
        if (listaPropriedadesNome != null)
        {
            return listaPropriedades.Where(x => listaPropriedadesNome.Contains(x.DisplayName)).ToList();
        }

        return null;
    }

    public bool ValidateCNH(string cnhDigits)
    {
        bool isValid = false;

        if (cnhDigits.Length == 11 && cnhDigits != new string('1', 11))
        {
            var dsc = 0;
            var v = 0;
            for (int i = 0, j = 9; i < 9; i++, j--)
            {
                v += (Convert.ToInt32(cnhDigits[i].ToString()) * j);
            }

            var vl1 = v % 11;
            if (vl1 >= 10)
            {
                vl1 = 0;
                dsc = 2;
            }

            v = 0;
            for (int i = 0, j = 1; i < 9; ++i, ++j)
            {
                v += (Convert.ToInt32(cnhDigits[i].ToString()) * j);
            }

            var x = v % 11;
            var vl2 = (x >= 10) ? 0 : x - dsc;

            isValid = vl1.ToString() + vl2.ToString() == cnhDigits.Substring(cnhDigits.Length - 2, 2);
        }

        return isValid;
    }

    public int CalculateAge(DateTime birthDate)
    {
        DateTime currentDate = DateOnlyExtensionMethods.GetDateTimeNowFromBrazil();
        int age = currentDate.Year - birthDate.Year;

        if (currentDate.DayOfYear < birthDate.DayOfYear)
        {
            age = age - 1;
        }

        return age;
    }

    public bool ValidateFullName(string fullName)
    {
        var arrName = fullName.ApplyTrim().Split(' ');

        if (string.IsNullOrEmpty(fullName) || arrName.Length == 1 || arrName.Where(x => x.Replace(".", string.Empty).Length == 1).Count() > 0)
            return false;

        return true;
    }

    public static IEnumerable<DropDownList> ConvertEnumToList<T>() where T : Enum
    {
        IEnumerable<DropDownList> list = Enum.GetValues(typeof(T))
          .Cast<T>()
          .Select(x => new DropDownList
          {
              Id = (long.Parse(x.ToString())),
              Description = x.GetDisplayName()
          });

        return list;
    }

    public bool ValidateFile(IFormFile formFile, string[] arrExtensions, double maxSizeFile)
    {
        var extension = Path.GetExtension(formFile.FileName).ToLowerInvariant();
        var contentType = ValidateContentTypeFile(extension);

        if (!arrExtensions.Contains(extension))
            return false;

        if (!formFile.ContentType.Equals(contentType))
            return false;

        if (formFile.Length > CalculateMaxSizeFile(maxSizeFile, EnumFileSize.MB))
            return false;

        return true;
    }

    public bool ExistFile(IFormFile formFile)
    {
        if (formFile == null || formFile.Length == 0)
            return false;

        return true;
    }

    public double CalculateMaxSizeFile(double size, EnumFileSize enumFileSize)
    {

        double maxSize = enumFileSize switch
        {
            EnumFileSize.KB => size * 1024,
            EnumFileSize.MB => size * 1024 * 1024,
            EnumFileSize.GB => size * 1024 * 1024 * 1024,
            EnumFileSize.TB => size * 1024 * 1024 * 1024 * 1024,
            _ => size
        };

        return maxSize;
    }

    public static JsonSerializerOptions GetConfigJson()
    {
        return new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
    }
}

public sealed class UriBuilderSite : UriBuilderAbstract
{
    public override string GetUrl()
    {
        uriBuilder.Scheme = "http";
        uriBuilder.Host = "site.net";
        uriBuilder.Path = "sistema";
        uriBuilder.Port = 8089;
        uriBuilder.UserName = "site";
        uriBuilder.Password = "numsey";
        uriBuilder.Query = "search=br";
        Uri uri = uriBuilder.Uri;
        return uri.ToString();
    }
}

public sealed class UriBuilderDefault : UriBuilderAbstract
{
    public override string GetUrl()
    {
        uriBuilder.Scheme = "http";
        uriBuilder.Host = "site.net";
        uriBuilder.Path = "sistema";
        Uri uri = uriBuilder.Uri;
        return uri.ToString();
    }
}

public abstract class UriBuilderAbstract
{
    protected readonly UriBuilder uriBuilder = new UriBuilder();

    public abstract string GetUrl();
}