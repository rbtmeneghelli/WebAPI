using KissLog;
using WebAPI.Application.Generic;

namespace WebAPI.V1.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AllowAnonymous]
public sealed class AccountController : GenericController
{
    private readonly IGeneralService _generalService;
    private readonly IGenericUnitofWorkService _unitofWorkService;
    private readonly IGraphicLineService _baseGraphicService;

    public AccountController(IKLogger iKLogger, IMapper mapper, IHttpContextAccessor accessor, INotificationMessageService notificationMessageService, IGeneralService generalService, IGenericUnitofWorkService unitofWorkService, IGraphicLineService baseGraphicService) : base(mapper, accessor, notificationMessageService, iKLogger)
    {
        _generalService = generalService;
        _unitofWorkService = unitofWorkService;
        _baseGraphicService = baseGraphicService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _unitofWorkService.Accounts.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            Credentials credentials = await _unitofWorkService.Accounts.GetUserCredentialsAsync(loginUser.Login);
            return CustomResponse(_generalService.CreateJwtToken(credentials));
        }
        else
        {
            return CustomResponse();
        }
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] User user)
    {
        if (ModelStateIsInvalid()) return CustomResponse(ModelState);

        var result = await _unitofWorkService.Accounts.ChangePasswordAsync(UserId, user);
        if (result)
            return CustomResponse(null, Domain.FixConstants.SUCCESS_IN_CHANGEPASSWORD);

        return CustomResponse();
    }

    [HttpGet("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        var result = await _unitofWorkService.Accounts.ResetPasswordAsync(email);

        if (result)
            return CustomResponse(null, Domain.FixConstants.SUCCESS_IN_RESETPASSWORD);

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
            throw new SecurityTokenException(Domain.FixConstants.ERROR_IN_REFRESHTOKEN);

        var newJwtToken = _generalService.GenerateToken(principal.Claims);
        var newRefreshToken = _generalService.GenerateRefreshToken();
        _generalService.DeleteRefreshToken(principal.Identity.Name, tokens.RefreshToken);
        _generalService.SaveRefreshToken(principal.Identity.Name, newRefreshToken);

        return CustomResponse(new Tokens() { Token = newJwtToken, RefreshToken = newRefreshToken });
    }
}
