using Carter;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using WebMinimalCarterScalarAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi("v1", p =>
{
    p.AddDocumentTransformer((document, context, CancellationToken) =>
    {
        document.Info = new()
        {
            Title = "WebMinimalAPI - Desktop",
            Description = "Endpoints destinados a uso de aplicativos fixos",
            Version = "1.0.0",

        };
        document.Servers = 
        [
            new() { Url = "https://localhost:44377/", Description = "URL Local" },
            new() { Url = "https://cloud.google.com/apis?hl=pt-BR", Description = "URL de PRD" }
        ];
        document.ExternalDocs = new()
        {
            Url = new Uri("https://www.google.com"),
            Description = "Documentação externa"
        };

        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();
        document.Security = new List<OpenApiSecurityRequirement>();

        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Insira o token JWT"
        };

        document.Security.Add(new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("Bearer", document)] = []
        });

        return Task.CompletedTask;
    });
});
builder.Services.AddOpenApi("v2", p =>
{
    p.AddDocumentTransformer((document, context, CancellationToken) =>
    {
        document.Info = new()
        {
            Title = "WebMinimalAPI - Mobile",
            Description = "Endpoints destinados a uso de aplicativos moveis",
            Version = "2.0.0",

        };
        document.Servers =
        [
            new() { Url = "https://localhost:44377/", Description = "URL Local" },
            new() { Url = "https://cloud.google.com/apis?hl=pt-BR", Description = "URL de PRD" }
        ];
        document.ExternalDocs = new()
        {
            Url = new Uri("https://www.google.com"),
            Description = "Documentação externa"
        };

        return Task.CompletedTask;
    });
});

builder.Services.RegistrarServicos();
builder.Services.AddCarter();

//#region Configuração de Authenticação do Swagger (Somente apenas para Swagger)

//builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
//{
//    options.Audience = "";
//    options.Authority = "https://localhost:44377/";
//});

//builder.Services.AddAuthorization();

//#endregion

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/scalar", p =>
    {
        p.Title = "Scalar";
        p.AddDocument("v1", "Minha API v1");
        p.AddDocument("v2", "Minha API v2");
        p.WithTheme(ScalarTheme.BluePlanet);
        p.ForceDarkMode();
    });

    app.UseSwaggerUI(p =>
    {
        p.SwaggerEndpoint("/openApi/v1.json", "Minha API v1");
        p.SwaggerEndpoint("/openApi/v2.json", "Minha API v2");
        p.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapCarter();
app.Run();