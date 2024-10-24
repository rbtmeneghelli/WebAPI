﻿using Microsoft.Extensions.Configuration;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.Tools;

public class IpAddressService : IIpAddressService
{
    private readonly string[] _ipsBlockeds;

    public IpAddressService(IConfiguration configuration)
    {
        var ipsBlocked = configuration.GetValue<string>("IPsBloqueados");
        _ipsBlockeds = ipsBlocked.Split(',');
    }

    public bool IsIPAddressBlocked(IPAddress ipAddress)
    {
        return _ipsBlockeds.Contains(ipAddress.ToString());
    }
}