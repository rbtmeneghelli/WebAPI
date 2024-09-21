using KissLog;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog.Events;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Interfaces.Services.Tools;
using FixConstants = WebAPI.Domain.Constants.FixConstants;
using ILogger = Serilog.ILogger;

namespace WebAPI.Controllers.Base
{
    [Produces("application/json")]
    [ApiController]
    public abstract class GenericController : ControllerBase
    {
        protected readonly IMapper _mapperService;
        protected readonly INotificationMessageService _notificationService;
        protected readonly IHttpContextAccessor _accessor;
        protected readonly IKissLogService _iKissLogService;
        
        protected long UserId { get; set; }
        protected string UserName { get; set; }
        protected long ProfileId { get; set; }
        protected string AppPath { get; set; }

        protected GenericController(IMapper mapperService, IHttpContextAccessor accessor, INotificationMessageService notificationService, IKissLogService iKissLogService)
        {
            _mapperService = mapperService;
            _accessor = accessor;
            _notificationService = notificationService;
            _iKissLogService = iKissLogService;

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

        private IActionResult ReturnErrorDetail(string detail, string instance = "", int statusCode = FixConstants.INTERNAL_ERROR_CODE, string title = "", string type = "")
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
            string userId = _accessor.HttpContext.User.FindFirst(x => x.Type == "Id")?.Value;
            return long.TryParse(userId, out _) ? long.Parse(userId) : 0;
        }

        private string GetCurrentUserName()
        {
            return _accessor.HttpContext.User.Identity.Name ?? StringExtensionMethod.GetEmptyString();
        }

        protected bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        private long GetCurrentUserProfileId()
        {
            string profileId = _accessor.HttpContext.User.FindFirst(x => x.Type == "ProfileId")?.Value;
            return long.TryParse(profileId, out _) ? long.Parse(profileId) : 0;
        }

        #endregion

        protected void NotificationError(string mensagem)
        {
            _notificationService.Handle(new Domain.Models.NotificationMessage(mensagem));
        }

        private bool OperationIsValid()
        {
            return !_notificationService.HaveNotification();
        }

        protected IActionResult CustomResponse(object result = null, string message = "")
        {
            if (OperationIsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result,
                    message = message
                });
            }

            //_iKissLogService.SaveLogOnSeriLog();

            return BadRequest(new
            {
                success = false,
                errors = _notificationService.GetNotifications().Select(n => n.Message)
            });
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            NotificationModelIsInvalid(modelState);
            return CustomResponse();
        }

        protected TDestination ApplyMapToEntity<TSource, TDestination>(TSource source)
        {
            return _mapperService.Map<TDestination>(source);
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
                responseError.StatusCode = FixConstants.UNAUTHORIZED_ERROR_CODE;
            }

            else if (contextException.Error is ApplicationException || contextException.Error is Exception)
            {
                responseError.ExceptionError = contextException.Error.GetType().Name.ToString();
                responseError.Errors = FixConstants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = FixConstants.INTERNAL_ERROR_CODE;
            }

            else
            {
                responseError.ExceptionError = contextException.Error.GetType().Name.ToString();
                responseError.Errors = FixConstants.MESSAGE_ERROR_APP_EX;
                responseError.StatusCode = FixConstants.INTERNAL_ERROR_CODE;
            }

            return ReturnErrorDetail($"Ocorreu um erro interno - {responseError.Errors}, Entre em contato com o administrador.", "", responseError.StatusCode);
        }

        protected bool ModelStateIsInvalid()
        {
            return ModelState.IsValid ? false : true;
        }
    }
}
