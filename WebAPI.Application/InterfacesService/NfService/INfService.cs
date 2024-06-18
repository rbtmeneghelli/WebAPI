using WebAPI.Application.Services.NfService;

namespace WebAPI.Application.Interfaces.NfService;

public interface INfService
{
    ReadNfXmlService GetReadNfXmlService();
    ReadNfTxtService GetReadNfTxtService();
}
