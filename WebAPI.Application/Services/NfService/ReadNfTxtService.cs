using System.Globalization;

namespace WebAPI.Application.Services.NfService;

public class ReadNfTxtService : GenericNfService<string>
{
    protected override IEnumerable<string> ReadNf()
    {
        
        CultureInfo c1 = new CultureInfo("pt-BR");
        StreamReader archive = new StreamReader("path", Encoding.GetEncoding(c1.TextInfo.ANSICodePage));

        string line = "";

        while (true)
        {
            line = archive.ReadLine();

            if (line != null)
            {
                string[] collectData = line.Split('|');

                //list.Add(new()
                //{
                //    Id = string.IsNullOrEmpty(collectData[0]) ? 0 : Convert.ToInt32(collectData[0]),
                //});

            }
            else
                break;
        }

        //return list;
        return Enumerable.Empty<string>();
    }
}

