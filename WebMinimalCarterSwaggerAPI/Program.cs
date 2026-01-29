using Carter;
using WebMinimalCarterSwaggerAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegistrarSwagger();
builder.Services.RegistrarAutenticacaoSwagger();
builder.Services.RegistrarServicos();
builder.Services.AddCarter();
builder.Services.AddAuthorization();
builder.Services.AddOutputCache(p =>
{
    p.AddPolicy("listMethods", builder =>
    {
        builder.Expire(TimeSpan.FromSeconds(60));
        builder.Tag("produtos");
    });
});

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = "swagger";
    });
}


app.MapCarter();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();
app.Run();