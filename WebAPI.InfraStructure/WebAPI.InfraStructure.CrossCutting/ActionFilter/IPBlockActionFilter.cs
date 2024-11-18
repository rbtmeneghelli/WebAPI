using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Infrastructure.CrossCutting.ActionFilter;

public class IPBlockActionFilter : ActionFilterAttribute
{
    private readonly IIpAddressService _iIPAddressService;

    public IPBlockActionFilter(IIpAddressService iIPAddressService)
    {
        _iIPAddressService = iIPAddressService;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
        var estaBloqueado = _iIPAddressService.IsIPAddressBlocked(remoteIp!);
        if (estaBloqueado)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }
        base.OnActionExecuting(context);
    }
}