using WebAPI.Domain.Constants;
using WebAPI.Domain.Entities.ControlPanel;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.V1.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AllowAnonymous]
public sealed class AccountController : GenericController
{
    private readonly IGeneralService _iGeneralService;
    private readonly IGenericUnitOfWorkService _iGenericUnitOfWorkService;

    public AccountController(
        IGeneralService iGeneralService,
        IGenericUnitOfWorkService iGenericUnitOfWorkService,
        IMapper iMapperService,
        IHttpContextAccessor iHttpContextAccessor,
        IGenericNotifyLogsService iGenericNotifyLogsService)
        : base(iMapperService, iHttpContextAccessor, iGenericNotifyLogsService)
    {
        _iGeneralService = iGeneralService;
        _iGenericUnitOfWorkService = iGenericUnitOfWorkService;
    }

    [HttpPost("Login")]
    [ProducesResponseType((int)FixConstants.OK_CODE)]
    [ProducesResponseType((int)FixConstants.BADREQUEST_CODE)]
    [ProducesResponseType((int)FixConstants.INTERNAL_CODE)]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _iGenericUnitOfWorkService.AccountService.GetUserCredentialsAsync(loginUser.Login);
            var userToken = _iGeneralService.CreateJwtToken(credentials);
            return CustomResponse(FixConstants.BADREQUEST_CODE, userToken);
        }
        else
        {
            NotificationError("Autenticações de usuário são invalidas");
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

        var result = _iGenericUnitOfWorkService.AccountService.CheckCodeTwoFactory(UserId, UserName, confirmLoginUser.CodeTwoFactory);

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

        var result = await _iGenericUnitOfWorkService.AccountService.ChangePasswordAsync(UserId, user);
        if (result)
            return CustomResponse(FixConstants.BADREQUEST_CODE, null, FixConstants.SUCCESS_IN_CHANGEPASSWORD);

        return CustomResponse(FixConstants.BADREQUEST_CODE);
    }

    [HttpGet("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        var result = await _iGenericUnitOfWorkService.AccountService.ResetPasswordAsync(email);

        if (result)
            return CustomResponse(FixConstants.BADREQUEST_CODE, null, FixConstants.SUCCESS_IN_RESETPASSWORD);

        return CustomResponse(FixConstants.BADREQUEST_CODE);
    }

    [HttpPost("LoginRefresh")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _iGenericUnitOfWorkService.AccountService.GetUserCredentialsAsync(loginUser.Login);
            string dataToken = _iGeneralService.CreateJwtToken(credentials);
            var dataRefreshToken = _iGeneralService.GenerateRefreshToken();
            _iGeneralService.SaveRefreshToken(credentials.Login, dataRefreshToken);
            return CustomResponse(FixConstants.BADREQUEST_CODE, new { token = dataToken, refreshToken = dataRefreshToken });
        }
        else
        {
            NotificationError("Autenticação invalida. tente novamente!");
            return CustomResponse(FixConstants.BADREQUEST_CODE);
        }
    }

    [HttpPost("RefreshToken")]
    public IActionResult RefreshToken([FromBody] Tokens tokens)
    {
        var principal = _iGeneralService.GetPrincipalFromExpiredToken(tokens.Token);
        var savedRefreshToken = _iGeneralService.GetRefreshToken(principal.Identity.Name);
        if (savedRefreshToken != tokens.RefreshToken)
            throw new SecurityTokenException(FixConstants.ERROR_IN_REFRESHTOKEN);

        var newJwtToken = _iGeneralService.GenerateToken(principal.Claims);
        var newRefreshToken = _iGeneralService.GenerateRefreshToken();
        _iGeneralService.DeleteRefreshToken(principal.Identity.Name, tokens.RefreshToken);
        _iGeneralService.SaveRefreshToken(principal.Identity.Name, newRefreshToken);

        return CustomResponse(FixConstants.OK_CODE, new Tokens() { Token = newJwtToken, RefreshToken = newRefreshToken });
    }
}
