using Microsoft.AspNetCore.Http;

namespace WebAPI.Application.Interfaces;

public interface IQRCodeService : IDisposable
{
    byte[] CreateQRCode(QRCodeFile qRCodeFile);
    string ReadQrCode(IFormFile file);
}
