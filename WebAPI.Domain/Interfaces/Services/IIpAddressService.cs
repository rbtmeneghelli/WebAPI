using System.Net;

namespace WebAPI.Application.Interfaces;

public interface IIpAddressService
{
    bool IsIPAddressBlocked(IPAddress ipAddress);
}
