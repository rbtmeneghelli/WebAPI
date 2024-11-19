using Microsoft.Extensions.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public class IpAddressService : IIpAddressService
{
    private readonly string[] _ipsBlockeds;

    public IpAddressService(IConfiguration configuration)
    {
        var ipsBlocked = "192.168.0.0,192.168.0.2";
        if(GuardClauses.IsNullOrWhiteSpace(ipsBlocked))
            ipsBlocked = string.Empty;
        else if(ipsBlocked.IndexOf(',') == -1)
            ipsBlocked = string.Empty;
        else
        _ipsBlockeds = ipsBlocked.Split(',');
    }

    public bool IsIPAddressBlocked(IPAddress ipAddress)
    {
        return _ipsBlockeds.Contains(ipAddress.ToString());
    }
}