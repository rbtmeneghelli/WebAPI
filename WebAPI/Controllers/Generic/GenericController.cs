using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAPI.Domain.Constants;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Repository;

namespace WebAPI.Controllers.Base;

[EnableCors("EnableCORS")]
[Produces("application/json")]
[ApiController]
public abstract class GenericController : ControllerBase
{
    protected readonly IMapper _iMapperService;
    protected readonly IHttpContextAccessor _iHttpContextAccessor;
    protected readonly IGenericNotifyLogsService _iGenericNotifyLogsService;

    protected long UserId { get; set; }
    protected string UserName { get; set; }
    protected long ProfileId { get; set; }
    protected string AppPath { get; set; }

    protected GenericController(IMapper iMapperService, IHttpContextAccessor iHttpContextAccessor, IGenericNotifyLogsService iGenericNotifyLogsService)
    {
        _iMapperService = iMapperService;
        _iHttpContextAccessor = iHttpContextAccessor;
        _iGenericNotifyLogsService = iGenericNotifyLogsService;

        if (IsAuthenticated())
        {
            UserId = GetCurrentUserId();
            UserName = GetCurrentUserName();
            ProfileId = GetCurrentUserProfileId();
        }
    }

    #region Metodos Privados

    /// <summary>
    /// Exemplo de um retorno detalhado de uma ocorrência de erro, ao invès de BadRequest, NotFound ou InternalError
    /// Segue o padrão RFC 7807
    /// Exemplo de um retorno detalhado caso um Registro não exista
    /// </summary>
    /// <param name="detail">"A categoria não existe."</param>
    /// <param name="instance">$"/categoria//{id}"</param>
    /// <param name="statusCode">400,404 ou 500</param>
    /// <param name="title">Não foi possível encontrar a categoria.</param>
    /// <param name="type">"http://exemplo.com/problemas/nao-encontrada"</param>
    /// <returns></returns>

    private IActionResult ReturnErrorDetail(string detail, string instance = "", int statusCode = ConstantHttpStatusCode.INTERNAL_ERROR_CODE, string title = "", string type = "")
    {
        return Problem(detail, instance, statusCode, title, type);
    }

    private void NotificationModelIsInvalid(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var errorMsg = GuardClauses.ObjectIsNull(erro.Exception) ? erro.ErrorMessage : erro.Exception.Message;
            NotificationError(errorMsg);
        }
    }

    private long GetCurrentUserId()
    {
        string userId = _iHttpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "Id")?.Value;
        return long.TryParse(userId, out _) ? long.Parse(userId) : 0;
    }

    private string GetCurrentUserName()
    {
        return _iHttpContextAccessor.HttpContext.User.Identity.Name ?? StringExtensionMethod.GetEmptyString();
    }

    protected bool IsAuthenticated()
    {
        return _iHttpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
    }

    private long GetCurrentUserProfileId()
    {
        string profileId = _iHttpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "ProfileId")?.Value;
        return long.TryParse(profileId, out _) ? long.Parse(profileId) : 0;
    }

    #endregion

    protected void NotificationError(string mensagem)
    {
        _iGenericNotifyLogsService.NotificationMessageService.Handle(new Domain.Models.NotificationMessage(mensagem));
    }

    private bool OperationIsValid()
    {
        return !_iGenericNotifyLogsService.NotificationMessageService.HaveNotification();
    }

    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        NotificationModelIsInvalid(modelState);
        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    protected TDestination ApplyMapToEntity<TSource, TDestination>(TSource source)
    {
        return _iMapperService.Map<TDestination>(source);
    }

    [HttpGet]
    [Route("/errors")]
    [ApiExplorerSettings(IgnoreApi = true)]
    protected IActionResult HandleErrors()
    {
        var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

        ResponseError responseError = new ResponseError { Success = false };

        if (contextException.Error is UnauthorizedAccessException)
        {
            responseError.ExceptionError = contextException.Error.GetType().Name.ToString();
            responseError.Errors = FixConstants.MESSAGE_ERROR_UNAUTH_EX;
            responseError.StatusCode = ConstantHttpStatusCode.UNAUTHORIZED_CODE;
        }

        else if (contextException.Error is ApplicationException || contextException.Error is Exception)
        {
            responseError.ExceptionError = contextException.Error.GetType().Name.ToString();
            responseError.Errors = FixConstants.MESSAGE_ERROR_APP_EX;
            responseError.StatusCode = ConstantHttpStatusCode.INTERNAL_ERROR_CODE;
        }

        else
        {
            responseError.ExceptionError = contextException.Error.GetType().Name.ToString();
            responseError.Errors = FixConstants.MESSAGE_ERROR_APP_EX;
            responseError.StatusCode = ConstantHttpStatusCode.INTERNAL_ERROR_CODE;
        }

        return ReturnErrorDetail($"Ocorreu um erro interno - {responseError.Errors}, Entre em contato com o administrador.", "", responseError.StatusCode);
    }

    protected bool ModelStateIsInvalid()
    {
        return ModelState.IsValid ? false : true;
    }

    protected IActionResult CustomResponse(int statusCode = ConstantHttpStatusCode.OK_CODE, object result = null, string messageToSend = "")
    {
        int[] arrStatusCode = [ConstantHttpStatusCode.OK_CODE, ConstantHttpStatusCode.CREATE_CODE];

        if (OperationIsValid() && arrStatusCode.Contains(statusCode))
        {
            return StatusCode(statusCode, new
            {
                success = true,
                data = result,
                message = messageToSend
            });
        }
        else
        {
            return StatusCode(statusCode, new
            {
                success = false,
                message = _iGenericNotifyLogsService.NotificationMessageService.HaveNotification()
                          ? ConstantMessageResponse.GetMessageResponse(statusCode)
                          : string.Join(',', _iGenericNotifyLogsService.NotificationMessageService.GetNotifications().Select(n => n.Message))
            });
        }
    }
}
