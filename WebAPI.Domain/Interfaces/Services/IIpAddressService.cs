using System.Net;

namespace WebAPI.Domain.Interfaces.Services;

public interface IIpAddressService
{
    bool IsIPAddressBlocked(IPAddress ipAddress);
}
