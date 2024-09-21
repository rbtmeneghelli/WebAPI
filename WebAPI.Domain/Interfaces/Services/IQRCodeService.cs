using Microsoft.AspNetCore.Http;
using WebAPI.Domain.Models;

namespace WebAPI.Application.Interfaces;

public interface IQRCodeService : IDisposable
{
    byte[] CreateQRCode(QRCodeFile qRCodeFile);
    string ReadQrCode(IFormFile file);
}
