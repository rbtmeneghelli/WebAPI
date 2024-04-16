using WebAPI.Application.Interfaces.NfService;

namespace WebAPI.Application.Services.NfService;

public class NfService : INfService
{
    private readonly ReadNfXmlService _readNfXmlService;
    private readonly ReadNfTxtService _readNfTxtService;

    public NfService()
    {
        _readNfXmlService = new ReadNfXmlService();
        _readNfTxtService = new ReadNfTxtService();
    }

    public ReadNfXmlService GetReadNfXmlService() => _readNfXmlService;
    public ReadNfTxtService GetReadNfTxtService() => _readNfTxtService;
}
