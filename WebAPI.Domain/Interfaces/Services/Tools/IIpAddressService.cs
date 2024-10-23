using System.Net;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IIpAddressService
{
    bool IsIPAddressBlocked(IPAddress ipAddress);
}
