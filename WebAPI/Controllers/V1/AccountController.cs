using KissLog;
using WebAPI.Application.Generic;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.V1.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AllowAnonymous]
public sealed class AccountController : GenericController
{
    private readonly IGeneralService _generalService;
    private readonly IGenericUnitofWorkService _unitofWorkService;

    public AccountController(IKLogger iKLogger, IMapper mapper, IHttpContextAccessor accessor, INotificationMessageService notificationMessageService, IGeneralService generalService, IGenericUnitofWorkService unitofWorkService) : base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _generalService = generalService;
        _unitofWorkService = unitofWorkService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _unitofWorkService.Accounts.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _unitofWorkService.Accounts.GetUserCredentialsAsync(loginUser.Login);
            var userToken = _generalService.CreateJwtToken(credentials);
            return CustomResponse(userToken);
        }
        else
        {
            return CustomResponse();
        }
    }

    [HttpPost("ConfirmLogin")]
    public IActionResult ConfirmLogin([FromBody] ConfirmLoginUser confirmLoginUser)
    {
        if (!IsAuthenticated())
        {
            NotificationError("Acesso negado! Metódo permitido apenas para usuário logado");
        }

        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = _unitofWorkService.Accounts.CheckCodeTwoFactory(UserId, UserName, confirmLoginUser.CodeTwoFactory);

        if (!result)
        {
            NotificationError("Código de validação duas etapas fornecido está expirado. Faça o login novamente para que um novo código seja gerado");
        }

        return CustomResponse();
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] User user)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _unitofWorkService.Accounts.ChangePasswordAsync(UserId, user);
        if (result)
            return CustomResponse(null, FixConstants.SUCCESS_IN_CHANGEPASSWORD);

        return CustomResponse();
    }

    [HttpGet("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        var result = await _unitofWorkService.Accounts.ResetPasswordAsync(email);

        if (result)
            return CustomResponse(null, FixConstants.SUCCESS_IN_RESETPASSWORD);

        return CustomResponse();
    }

    [HttpPost("LoginRefresh")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _unitofWorkService.Accounts.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _unitofWorkService.Accounts.GetUserCredentialsAsync(loginUser.Login);
            string dataToken = _generalService.CreateJwtToken(credentials);
            var dataRefreshToken = _generalService.GenerateRefreshToken();
            _generalService.SaveRefreshToken(credentials.Login, dataRefreshToken);
            return CustomResponse(new { token = dataToken, refreshToken = dataRefreshToken });
        }
        else
        {
            NotificationError("Autenticação invalida. tente novamente!");
            return CustomResponse();
        }
    }

    [HttpPost("RefreshToken")]
    public IActionResult RefreshToken([FromBody] Tokens tokens)
    {
        var principal = _generalService.GetPrincipalFromExpiredToken(tokens.Token);
        var savedRefreshToken = _generalService.GetRefreshToken(principal.Identity.Name);
        if (savedRefreshToken != tokens.RefreshToken)
            throw new SecurityTokenException(FixConstants.ERROR_IN_REFRESHTOKEN);

        var newJwtToken = _generalService.GenerateToken(principal.Claims);
        var newRefreshToken = _generalService.GenerateRefreshToken();
        _generalService.DeleteRefreshToken(principal.Identity.Name, tokens.RefreshToken);
        _generalService.SaveRefreshToken(principal.Identity.Name, newRefreshToken);

        return CustomResponse(new Tokens() { Token = newJwtToken, RefreshToken = newRefreshToken });
    }
}
