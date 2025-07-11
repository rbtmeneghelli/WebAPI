using System.Security.Claims;
using System.Threading.RateLimiting;
using FastPackForShare;
using FastPackForShare.Controllers.Generics;
using Microsoft.AspNetCore.Authentication.BearerToken;

namespace WebAPI.V1.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[AllowAnonymous]
public sealed class AccountController : GenericController
{
    private readonly IGeneralService _iGeneralService;
    private readonly IGenericUnitOfWorkService _iGenericUnitOfWorkService;
    private readonly IUserLoggedService _iUserLoggedService;
    private static readonly PartitionedRateLimiter<string> _limiter =
    PartitionedRateLimiter.Create<string, string>(_ =>
        RateLimitPartition.GetTokenBucketLimiter(
            partitionKey: "default",
            factory: _ => new TokenBucketRateLimiterOptions
            {
                TokenLimit = 1,
                TokensPerPeriod = 1,
                ReplenishmentPeriod = TimeSpan.FromSeconds(120),
                QueueLimit = 0,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                AutoReplenishment = true
            }));

    public AccountController(
        IGeneralService iGeneralService,
        IGenericUnitOfWorkService iGenericUnitOfWorkService,
        IMapper iMapperService,
        INotificationMessageService notificationMessageService,
        IUserLoggedService iUserLoggedService)
        : base(notificationMessageService)
    {
        _iGeneralService = iGeneralService;
        _iGenericUnitOfWorkService = iGenericUnitOfWorkService;
        _iUserLoggedService = iUserLoggedService;
    }

    [HttpPost("login")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> Login([FromBody, Required] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            AuthenticationModel credentials = await _iGenericUnitOfWorkService.AccountService.GetUserAuthenticationAsync(loginUser.Login);
            var userToken = _iGeneralService.CreateJwtToken(credentials);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, userToken);
        }
        else
        {
            NotificationError("Autenticações de usuário são invalidas");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    /// <summary>
    /// Em caso de uso desse enpoint, deve-se registrar os serviços da classe ContainerFPFSwaggerOptional
    /// Os demais serviços relacionados ao swagger, desativa-los.
    /// </summary>
    /// <param name="loginUser"></param>
    /// <returns></returns>
    [HttpPost("login-optional-swagger")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> LoginOptionalSwagger([FromBody, Required] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            AuthenticationModel authenticationModel = await _iGenericUnitOfWorkService.AccountService.GetUserAuthenticationAsync(loginUser.Login);
            var claims = new[]
            {
                new Claim("Id", authenticationModel.Id.ToString()),
                new Claim(ClaimTypes.Name, authenticationModel.Login ?? string.Empty),
                new Claim("profile", authenticationModel.Profile ?? string.Empty),
                new Claim(ClaimTypes.Role, string.Join(",", authenticationModel.Roles ?? Enumerable.Empty<Claim>().ToList())),
                new Claim("access_date", authenticationModel.AccessDate.ToString("yyyy-MM-dd")),
                new Claim("access_time", authenticationModel.AccessDate.ToString("HH:mm:ss"))
            };

            var claimsIdentity = new ClaimsIdentity(claims, BearerTokenDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return SignIn(claimsPrincipal);
        }
        else
        {
            NotificationError("Autenticações de usuário são invalidas");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpPost("confirmLogin")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public IActionResult ConfirmLogin([FromBody, Required] ConfirmLoginUser confirmLoginUser)
    {
        //if (!_iUserLoggedService.UserAuthenticated)
        //{
        //    NotificationError("Acesso negado! Metódo permitido apenas para usuário logado");
        //    return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        //}

        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = _iGenericUnitOfWorkService.AccountService.CheckCodeTwoFactory(_iUserLoggedService.UserId, _iUserLoggedService.UserName, confirmLoginUser.CodeTwoFactory);

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
        #region Validação para habilitar o uso desse endpoint, após primeira solicitação

        using var lease = await _limiter.AcquireAsync("default");

        if (!lease.IsAcquired)
            return CustomResponse(new CustomResponseModel(ConstantHttpStatusCode.BAD_REQUEST_CODE, "Método já executado. Tente novamente após 120 segundos."));

        #endregion

        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.ChangePasswordAsync(_iUserLoggedService.UserId, user);
        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, FixConstants.SUCCESS_IN_CHANGEPASSWORD);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpGet("resetPassword/{email: string}")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    [ProducesResponseType(ConstantHttpStatusCode.NOT_FOUND_CODE, Type = typeof(CustomValidResponseTypeModel<object>))]
    public async Task<IActionResult> ResetPassword([FromRoute, Required] string email)
    {
        var result = await _iGenericUnitOfWorkService.AccountService.ResetPasswordAsync(email);

        if (result)
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, null, FixConstants.SUCCESS_IN_RESETPASSWORD);

        return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
    }

    [HttpPost("loginRefresh")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<Tokens>))]
    public async Task<IActionResult> LoginRefresh([FromBody, Required] LoginUser loginUser)
    {
        if (ModelStateIsInvalid()) return CustomResponseModel(ModelState);

        var result = await _iGenericUnitOfWorkService.AccountService.CheckUserAuthenticationAsync(loginUser);

        if (result)
        {
            AuthenticationModel authenticationModel = await _iGenericUnitOfWorkService.AccountService.GetUserAuthenticationAsync(loginUser.Login);
            string dataToken = _iGeneralService.CreateJwtToken(authenticationModel);
            var dataRefreshToken = _iGeneralService.GenerateRefreshToken();
            _iGeneralService.SaveRefreshToken(authenticationModel.Login, dataRefreshToken);
            return CustomResponse(ConstantHttpStatusCode.OK_CODE, new Tokens() { Token = dataToken, RefreshToken = dataRefreshToken });
        }
        else
        {
            NotificationError("Autenticação invalida. tente novamente!");
            return CustomResponse(ConstantHttpStatusCode.BAD_REQUEST_CODE);
        }
    }

    [HttpPost("refreshToken")]
    [ProducesResponseType(ConstantHttpStatusCode.OK_CODE, Type = typeof(CustomValidResponseTypeModel<Tokens>))]
    public IActionResult RefreshToken([FromBody, Required] Tokens tokens)
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
