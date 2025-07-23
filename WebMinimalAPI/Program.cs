using WebMinimalAPI._1._Api;
using WebMinimalAPI._1._Api.Endpoints;
using WebMinimalAPI._2._Application.DTOS;
using WebMinimalAPI._4._InfraStructure;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.RegisterServices();
builder.Services.RegisterFluentValidationService();
builder.Services.RegisterSwaggerService();
builder.Services.RegisterSwaggerJwtBearerTokenService(jwtOptions);
//builder.Services.RegisterSwaggerBearerTokenService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApp API");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

ProductEndpoints.Map(app);
FileEndpoints.Map(app);
AccountEndpoints.Map(app);

app.Run();
