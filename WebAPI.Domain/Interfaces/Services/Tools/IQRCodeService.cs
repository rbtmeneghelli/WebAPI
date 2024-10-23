using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IQRCodeService : IDisposable
{
    byte[] CreateQRCode(QRCodeFile qRCodeFile);
    string ReadQrCode(IFormFile file);
}
