using Microsoft.OpenApi.Models;
using FluentValidation;
using WebMinimalAPI._2._Application.Services;
using WebMinimalAPI._2._Application.Interfaces;
using WebMinimalAPI._4._InfraStructure.Repositories;
using WebMinimalAPI._2._Application.Validators;
using WebMinimalAPI._2._Application.DTOS;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebMinimalAPI._4._InfraStructure;

public static class BootServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services
        .AddScoped<IProductRepository, ProductRepository>()
        .AddScoped<IFileService, FileService>()
        .AddScoped<IProductService, ProductService>()
        .AddScoped<ITokenService, TokenService>();
    }

    public static void RegisterFluentValidationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProductDTOValidator>();
    }

    public static void RegisterSwaggerService(this IServiceCollection services)
    {
        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp API", Version = "v1" });

            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "Token",
                In = ParameterLocation.Header,
                Description = "Token Access",
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });

            var xmlPath = Path.Combine(AppContext.BaseDirectory, "MyApp.Api.xml");
            if (File.Exists(xmlPath))
                opt.IncludeXmlComments(xmlPath);
        });
    }

    public static void RegisterSwaggerJwtBearerTokenService(this IServiceCollection services, JwtOptions jwtOptionsDTO)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opts =>
        {
            //convert the string signing key to byte array
            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(jwtOptionsDTO.PrivateKey);
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptionsDTO.Issuer,
                ValidAudience = jwtOptionsDTO.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
            };
        });

        services.AddAuthorization();
    }

    public static void RegisterSwaggerBearerTokenService(this IServiceCollection services)
    {
        services.AddAuthentication().AddBearerToken();
        services.AddAuthorization();
    }
}
