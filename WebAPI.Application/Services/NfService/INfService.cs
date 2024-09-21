using WebAPI.Application.Services.NfService;

namespace WebAPI.Domain.Interfaces.Services.NfService;

public interface INfService
{
    ReadNfXmlService GetReadNfXmlService();
    ReadNfTxtService GetReadNfTxtService();
}
