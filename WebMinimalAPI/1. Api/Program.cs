using WebMinimalAPI._1._Api.Endpoints;
using WebMinimalAPI._4._InfraStructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

ProductEndpoints.Map(app);
FileEndpoints.Map(app);

app.Run();
