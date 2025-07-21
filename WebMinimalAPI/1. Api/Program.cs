using WebMinimalAPI._1._Api.Endpoints;
using WebMinimalAPI._4._InfraStructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterFluentValidationService();
builder.Services.RegisterSwaggerService();

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

ProductEndpoints.Map(app);
FileEndpoints.Map(app);

app.Run();
