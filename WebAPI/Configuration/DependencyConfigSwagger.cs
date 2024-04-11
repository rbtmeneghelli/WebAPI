using WebAPI.Configuration.Middleware.Swagger;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPI.Configuration;

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
public static class DependencyConfigSwagger
{
    public static void RegisterSwaggerConfigWithAnnotations(IServiceCollection services)
    {
        services.AddSwaggerGen(
        c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WebAPI - Default",
                Version = "V1",
                Description = "Lista de endpoints disponíveis",
                Contact = new OpenApiContact() { Name = "Roberto Meneghelli", Email = "roberto.mng.89.com.br" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
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

    /// <summary>
    /// Faz a ligação com um Middleware customizado para que o swagger seja exibido, apenas quando o usuário estiver autenticado
    /// Link >> https://macoratti.net/22/04/swagger_secprod1.htm
    /// </summary>
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerBasicAuthenticationMiddleware>();
    }

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

    internal static void UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
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
            Contact = new OpenApiContact() { Name = "Roberto Meneghelli", Email = "roberto.mng.89.com.br" },
            License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        };
    }
}

public class SwaggerDefaultValues : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Deprecated = context.ApiDescription.IsDeprecated() ? true : OpenApiOperation.DeprecatedDefault;

        if (GuardClauses.ObjectIsNull(operation.Parameters))
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

            if (GuardClauses.ObjectIsNull(parameter.Description))
            {
                parameter.Description = description.ModelMetadata?.Description;
            }

            if (GuardClauses.ObjectIsNull(routeInfo))
            {
                continue;
            }

            if (parameter.In != ParameterLocation.Path && GuardClauses.ObjectIsNull(parameter.Schema.Default))
            {
                parameter.Schema.Default = new OpenApiString(routeInfo.DefaultValue.ToString());
            }

            parameter.Required |= !routeInfo.IsOptional;
        }
    }
}
