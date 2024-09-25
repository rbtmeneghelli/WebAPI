using Serilog;

// Configura��o para executar Minimal API sem a classe startup
//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Add Middlewares
//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/errors");
//}

//app.UseSwagger();
//app.UseSwaggerUI();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

// ---------------------------------------------------------------------------------------------------------------- //

// Configura��o para executar API padr�o

//var builder = Host.CreateDefaultBuilder(args);

//builder.ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseStartup<Startup>();
//});

//var app = builder.Build();

//app.Run();

namespace WebAPI;
public class Program
{
    public static void Main(string[] args)
    {
        #if DEBUG
            CreateHostBuilder(args).UseSerilog().Build().Run();
        #else
            CreateHostBuilder(args).Build().Run();
        #endif
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}