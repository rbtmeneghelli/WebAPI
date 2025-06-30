using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using WebAPI.Domain;
using WebAPI.Infrastructure.CrossCutting.Middleware.Swagger;
using WebAPI.Domain.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;
using System.Buffers.Text;
using WebAPI.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using FastPackForShare.Extensions;
using FastPackForShare.Cryptography;
using FastPackForShare.Constants;
using FastPackForShare.Models;

namespace WebAPI.InfraStructure.IoC.Containers;

/// <summary>
/// Pacote Nuget >> Swashbuckle.AspNetCore.Annotations
/// c.EnableAnnotations(); >> Essa configuração faz que seja possivel documentar com mais detalhes a API
/// No Endpoint podemos utilizar os data Annotation abaixo:
/// [SwaggerOperation(Summary ="Obtém a lista da previsão de tempo ")]
/// [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<WeatherForecast>))]
/// [SwaggerResponse(StatusCodes.Status400BadRequest)]
/// [SwaggerSchema(Description = "Resumo da previsão")]
/// Referencia >> https://macoratti.net/22/04/swagger_aprdoc2.htm
/// </summary>
public static class ContainerSwagger
{
    #region Configuração padrão do swagger

    public static void RegisterDefaultSwaggerConfig(IServiceCollection services)
    {
        services.AddSwaggerGen(
        c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WebAPI - Default",
                Version = "V1",
                Description = "Lista de endpoints disponíveis",
                Contact = new OpenApiContact() { Name = "Dev", Email = "dev@test.com.br" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                Scheme = "Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                          Type = ReferenceType.SecurityScheme,
                          Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebAPI.xml"));
        });
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/V1/swagger.json", "WebAPI");
            c.InjectStylesheet("/Arquivos/swagger-dark.css");
        });
    }

    #endregion

    #region Configuração do swagger com varias versões

    private static OpenApiSecurityScheme GetBearerConfig()
    {
        return new OpenApiSecurityScheme
        {
            Description = "Insira o token JWT desta maneira: Bearer {seu token}",
            Name = "Authorization",
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        };
    }

    private static OpenApiReference GetSecurityConfig()
    {
        return new OpenApiReference()
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        };
    }

    public static void RegisterSwaggerConfig(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.OperationFilter<SwaggerDefaultValues>();

            c.AddSecurityDefinition("Bearer", GetBearerConfig());

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = GetSecurityConfig()
                    },
                    new string[] {}
                }
            });
        });

        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    options.InjectStylesheet("/Arquivos/swagger-dark.css");
                }
            });
    }

    #endregion

    #region Configuração padrão de autenticação do swagger

    public static IServiceCollection RegisterJwtTokenConfig(this IServiceCollection services)
    {
        var tokenSettings = JsonSerializer.Deserialize<JwtConfigModel>(Environment.GetEnvironmentVariable("WebAPI_Token"));

        services.AddAuthentication
              (x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = tokenSettings.Issuer,
                      ValidAudience = tokenSettings.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes(tokenSettings.Key))
                  };
              });

        return services;
    }

    #endregion

    #region Configuração de criptografia para autenticação do swagger

    public static void RegisterJwtTokenEncryptConfig(this IServiceCollection services, EnvironmentVariables environmentVariables)
    {
        services.AddAuthentication
              (x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = environmentVariables.JwtConfigSettings.Issuer,
                      ValidAudience = environmentVariables.JwtConfigSettings.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes(environmentVariables.JwtConfigSettings.Key))
                  };
                  options.Events = new JwtBearerEvents
                  {
                      OnMessageReceived = async context =>
                      {
                          var endpoint = context.HttpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                          if (endpoint != null && endpoint.Metadata.GetMetadata<IAllowAnonymous>() != null)
                          {
                              return;
                          }

                          else if (context.Request.Headers.TryGetValue("Authorization", out var tokenHeader))
                          {
                              var iGeneralService = context.HttpContext.RequestServices.GetRequiredService<IGeneralService>();
                              var environmentVariables = context.HttpContext.RequestServices.GetRequiredService<EnvironmentVariables>();
                              var tokenAuthAPI = StringExtension.ApplyReplaceToAll(tokenHeader.ToString(), "Bearer ", "");

                              if (GuardClauseExtension.IsNullOrWhiteSpace(tokenAuthAPI))
                              {
                                  return;
                              }

                              else if (Base64.IsValid(tokenAuthAPI))
                              {
                                  try
                                  {
                                      string tokenDecrypt = CryptographyHashTokenManager.DecryptToken(tokenAuthAPI, environmentVariables.JwtConfigSettings.Key);
                                      if (iGeneralService.ValidateToken(tokenDecrypt))
                                          context.Token = tokenDecrypt;
                                  }
                                  catch
                                  {
                                      return;
                                  }
                              }
                          }

                          await Task.CompletedTask;
                          return;
                      },
                      OnChallenge = async context =>
                      {
                          if (context.Error == "invalid_token" || context.Error == "missing_token")
                          {
                              context.HandleResponse();
                              context.Response.StatusCode = ConstantHttpStatusCode.FORBIDDEN_CODE;
                              context.Response.ContentType = "application/json";
                              var responseForbidden = new
                              {
                                  sucesso = false,
                                  mensagem = FixConstants.MESSAGE_ERROR_FORB_EX
                              };
                              await context.Response.WriteAsJsonAsync(responseForbidden);
                              return;
                          }

                          context.HandleResponse();
                          context.Response.StatusCode = ConstantHttpStatusCode.UNAUTHORIZED_CODE;
                          context.Response.ContentType = "application/json";
                          var response = new
                          {
                              sucesso = false,
                              mensagem = FixConstants.MESSAGE_ERROR_UNAUTH_EX
                          };
                          await context.Response.WriteAsJsonAsync(response);
                          return;
                      }
                  };
              });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser()
                .Build());

            auth.AddPolicy("BearerRole", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .RequireClaim("Admin")
                .Build());
        });
    }

    #endregion

    /// <summary>
    /// Faz a ligação com um Middleware customizado para que o swagger seja exibido, apenas quando o usuário estiver autenticado
    /// Link >> https://macoratti.net/22/04/swagger_secprod1.htm
    /// </summary>
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerBasicAuthenticationMiddleware>();
    }
}

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    readonly IApiVersionDescriptionProvider provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, GetApiConfig(description));
            // Apresentar documentação mais detalhe do Swagger
            // options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "WebAPISwagger.xml"));
        }
    }

    private static OpenApiInfo GetApiConfig(ApiVersionDescription description)
    {
        return new OpenApiInfo
        {
            Title = "WebAPI - Default",
            Version = description.ApiVersion.ToString(),
            Description = description.IsDeprecated ? " Esta versão está obsoleta!" : "Lista de endpoints disponíveis",
            Contact = new OpenApiContact() { Name = "Dev", Email = "dev@test.com.br" },
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };
    }
}

public class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        int[] arrHttpStatusCode = [
            ConstantHttpStatusCode.BAD_REQUEST_CODE,
            ConstantHttpStatusCode.UNAUTHORIZED_CODE,
            ConstantHttpStatusCode.FORBIDDEN_CODE,
            ConstantHttpStatusCode.INTERNAL_ERROR_CODE
        ];

        for (var i = 0; i <= arrHttpStatusCode.Length - 1; i++)
            operation.Responses.Remove(arrHttpStatusCode[i].ToString());

        operation.Responses.Add(ConstantHttpStatusCode.BAD_REQUEST_CODE.ToString(), new OpenApiResponse { Description = ConstantMessageResponse.BAD_REQUEST_CODE, });
        operation.Responses.Add(ConstantHttpStatusCode.UNAUTHORIZED_CODE.ToString(), new OpenApiResponse { Description = ConstantMessageResponse.UNAUTHORIZED_CODE, });
        operation.Responses.Add(ConstantHttpStatusCode.FORBIDDEN_CODE.ToString(), new OpenApiResponse { Description = ConstantMessageResponse.FORBIDDEN_CODE });
        operation.Responses.Add(ConstantHttpStatusCode.INTERNAL_ERROR_CODE.ToString(), new OpenApiResponse { Description = ConstantMessageResponse.INTERNAL_ERROR_CODE });
        operation.Deprecated = context.ApiDescription.IsDeprecated() ? true : OpenApiOperation.DeprecatedDefault;

        if (GuardClauseExtension.IsNull(operation.Parameters))
        {
            return;
        }

        foreach (var parameter in operation.Parameters)
        {
            var description = context.ApiDescription
                .ParameterDescriptions
                .First(p => p.Name == parameter.Name);

            var routeInfo = description.RouteInfo;

            operation.Deprecated = context.ApiDescription.IsDeprecated() ? true : OpenApiOperation.DeprecatedDefault;

            if (GuardClauseExtension.IsNull(parameter.Description))
            {
                parameter.Description = description.ModelMetadata?.Description;
            }

            if (GuardClauseExtension.IsNull(routeInfo))
            {
                continue;
            }

            if (parameter.In != ParameterLocation.Path && GuardClauseExtension.IsNull(parameter.Schema.Default))
            {
                parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
            }

            parameter.Required |= !routeInfo.IsOptional;
        }
    }
}
