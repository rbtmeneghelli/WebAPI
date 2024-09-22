using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.IoC.Middleware.Security;

/// <summary>
/// Exemplo de filtro de segurança para impedir usuario sem a funcionalidade ou ação para utilizar o endpoint
/// </summary>
public class SecurityFilter : Attribute, IAsyncActionFilter
{
    private readonly int _idFunction = 0;
    private readonly int _idAction = 0;

    public SecurityFilter(int idFunction, int idAction)
    {
        _idFunction = idFunction;
        _idAction = idAction;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate actionExecutionDelegate)
    {
        // Obter o Service que precisa para validar
        var serviceProvider = context.HttpContext.RequestServices;
        var userService = serviceProvider.GetService<IUserService>();

        // Implementa a logica que precisa fazer

        // Metodo final para prosseguir,caso esteja tudo OK
        await actionExecutionDelegate();
    }
}
