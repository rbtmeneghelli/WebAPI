using System.ComponentModel.DataAnnotations;
using FastPackForShare.Controllers.Generics;
using FastPackForShare.Interfaces;

namespace WebAPI.V1.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AllowAnonymous]
public sealed class AccountController : GenericController
{
    private readonly IGeneralService _iGeneralService;
    private readonly IGenericUnitOfWorkService _iGenericUnitOfWorkService;
    private readonly IUserLoggedService _userLoggedService;

    public AccountController(
        IGeneralService iGeneralService,
        IGenericUnitOfWorkService iGenericUnitOfWorkService,
        IMapper iMapperService,
        INotificationMessageService notificationMessageService,
        IUserLoggedService userLoggedService)
        : base(notificationMessageService)
    {
        _iGeneralService = iGeneralService;
        _iGenericUnitOfWorkService = iGenericUnitOfWorkService;
        _userLoggedService = userLoggedService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody, Required] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _iGenericUnitOfWorkService.AccountService.GetUserCredentialsAsync(loginUser.Login);
            var userToken = _iGeneralService.CreateJwtToken(credentials);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, userToken);
        }
        else
        {
            NotificationError("Autenticações de usuário são invalidas");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpPost("confirmLogin")]
    public IActionResult ConfirmLogin([FromBody, Required] ConfirmLoginUser confirmLoginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = _iGenericUnitOfWorkService.AccountService.CheckCodeTwoFactory(_userLoggedService.UserId, _userLoggedService.UserName, confirmLoginUser.CodeTwoFactory);

        if (!result)
        {
            NotificationError("Código de validação duas etapas fornecido está expirado. Faça o login novamente para que um novo código seja gerado");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }

        return CustomResponse();
    }

    [HttpPost("changePassword")]
    public async Task<IActionResult> ChangePassword([FromBody, Required] User user)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.ChangePasswordAsync(UserId, user);
        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, FixConstants.SUCCESS_IN_CHANGEPASSWORD);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpGet("resetPassword/{email: string}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        var result = await _iGenericUnitOfWorkService.AccountService.ResetPasswordAsync(email);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, FixConstants.SUCCESS_IN_RESETPASSWORD);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPost("loginRefresh")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginRefresh([FromBody, Required] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _iGenericUnitOfWorkService.AccountService.GetUserCredentialsAsync(loginUser.Login);
            string dataToken = _iGeneralService.CreateJwtToken(credentials);
            var dataRefreshToken = _iGeneralService.GenerateRefreshToken();
            _iGeneralService.SaveRefreshToken(credentials.Login, dataRefreshToken);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, new { token = dataToken, refreshToken = dataRefreshToken });
        }
        else
        {
            NotificationError("Autenticação invalida. tente novamente!");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpPost("refreshToken")]
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

        return CustomResponse(ConstantHttpStatusCode.OK_CODE, new Tokens() { Token = newJwtToken, RefreshToken = newRefreshToken });
    }
}
