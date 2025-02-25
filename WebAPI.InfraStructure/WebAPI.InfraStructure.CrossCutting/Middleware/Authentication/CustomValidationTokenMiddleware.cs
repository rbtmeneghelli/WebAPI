using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json;
using WebAPI.Domain;
using WebAPI.Domain.Constants;
using WebAPI.Domain.Interfaces.Services;

namespace WebAPI.Infrastructure.CrossCutting.Middleware.Authentication;

/// <summary>
/// Middleware para verificar se o token fornecido no Bearer Token e o mesmo que foi gerado e gravado na tabela UserToken
/// </summary>
public sealed class CustomValidationTokenMiddleware
{
    private readonly RequestDelegate _next;

    public CustomValidationTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        if (endpoint != null && endpoint.Metadata.GetMetadata<IAllowAnonymous>() != null)
        {
            await _next(context);
            return;
        }

        if (context.Request.Headers.TryGetValue("Authorization", out var tokenHeader))
        {
            var tokenAutenticacaoAPI = tokenHeader.ToString().Replace("Bearer ", "");
            // Carrega os serviços
            var iTokenServico = context.RequestServices.GetRequiredService<IGeneralService>();
            //var iUserTokenServico = context.RequestServices.GetRequiredService<IUsuarioTokenServico>();

            try
            {
                if (iTokenServico.ValidateToken(tokenAutenticacaoAPI))
                {
                    var dadosParametroTokenAPI = iTokenServico.ExtractDataToken(tokenAutenticacaoAPI);
                    var resultadoValidacaoTokenAPI = ValidateToken(dadosParametroTokenAPI);

                    if (resultadoValidacaoTokenAPI.DadosValidos)
                    {
                        //var tokenOriginal = await iUserTokenServico.ObterTokenAutenticacaoPorChaveComposta(dadosParametroTokenAPI.Id, dadosParametroTokenAPI.UserNum.Value);
                        var tokenOriginal = "";

                        if (tokenOriginal != null)
                        {
                            var dadosParametroTokenOriginal = iTokenServico.ExtractDataToken(tokenAutenticacaoAPI);
                            bool tokenValido = ValidateTokens(dadosParametroTokenAPI, dadosParametroTokenOriginal);
                            if (tokenValido)
                            {
                                await _next(context);
                                return;
                            }
                            else
                            {
                                context.Response.StatusCode = ConstantHttpStatusCode.UNAUTHORIZED_CODE;
                                await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensagem = FixConstants.ERROR_TOKEN_INVALID, sucesso = false }, GeneralMethod.GetConfigJson()));
                                return;
                            }
                        }
                        else
                        {
                            context.Response.StatusCode = ConstantHttpStatusCode.UNAUTHORIZED_CODE;
                            await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensagem = FixConstants.ERROR_TOKEN_INVALID, sucesso = false }, GeneralMethod.GetConfigJson()));
                            return;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = ConstantHttpStatusCode.UNAUTHORIZED_CODE;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensagem = FixConstants.ERROR_TOKEN_INVALID, sucesso = false }, GeneralMethod.GetConfigJson()));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = ConstantHttpStatusCode.INTERNAL_ERROR_CODE;
                await context.Response.WriteAsync(JsonSerializer.Serialize(new { mensagem = ex.Message, sucesso = false }, GeneralMethod.GetConfigJson()));
                return;
            }
        }
    }

    private (bool DadosValidos, string MensagemErro) ValidateToken(object dadosAutenticacaoTokenDTO)
    {
        StringBuilder stringBuilder = new StringBuilder();
        //Logica de validação
        return (true, stringBuilder.ToString());
    }

    private bool ValidateTokens(object tokenAPI, object tokenOriginal)
    {
        //COMPARA AS PROPRIEDADES DO TOKEN informado no Bearer Token da API vs o token original armazenado na tabela
        return true;
    }
}