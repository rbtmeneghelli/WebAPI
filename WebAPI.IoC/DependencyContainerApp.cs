using WebAPI.Infra.Data.Context;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace WebAPI.Infra.Structure.IoC;

public static class DependencyContainerApp
{
    private static void MigrateDatabase(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<WebAPIContext>();
            context.Database.EnsureCreated(); //ou context.Database.Migrate();
        }
    }

    private static void UseKissLogConfig(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseKissLogMiddleware(options => ConfigureKissLog(configuration));
    }

    private static void ConfigureKissLog(IConfiguration configuration)
    {
        var configs = configuration.GetSection("KissLogSettings:OrganizationId");
        KissLogConfiguration.Listeners
            .Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(configuration.GetSection("KissLogSettings:OrganizationId").Value, configuration.GetSection("KissLogSettings:ApplicationId").Value))
            {
                ApiUrl = configuration.GetSection("KissLogSettings:ApiUrl").Value
            });
    }

    public static void UseAppConfig(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/errors");
            app.UseHsts();
        }

        app.MigrateDatabase();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("EnableCORS");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseKissLogConfig(configuration);
        //app.UseRateLimiter(); // Para Utilizar o Ratelimit de Requisição

        // Configuração de Exception Handler Customizado
        //app.UseExceptionHandler(new ExceptionHandlerOptions
        //{
        //    ExceptionHandler = new CustomExceptionHandler().InvokeAsync
        //});

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        //app.UseHangfireDashboard("/hangfire", new DashboardOptions
        //{
        //    DashboardTitle = "Lista de Jobs",
        //    Authorization = new[]
        //    {
        //        new HangfireCustomBasicAuthenticationFilter
        //        {
        //           User = "",
        //           Pass = ""
        //        }
        //    }
        //});

        //app.MapHangfireDashboard();
        //app.UseMiddleware<ApiLoggingMiddleware>(); // Caso for usar Middleware no net core 2.2, basta descomentar essa linha
        //app.UseMiddleware<RequestResponseLoggingMiddleware>(); // Caso for usar Middleware no net core 3.0, basta descomentar essa linha
        //app.UseMiddleware<HttpLoggingMiddleware>(); // Caso for usar Middleware no net core 5.0, basta descomentar essa linha
    }
}

