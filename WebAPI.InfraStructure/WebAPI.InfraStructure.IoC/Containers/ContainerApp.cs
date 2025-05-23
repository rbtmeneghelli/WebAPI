﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WebAPI.InfraStructure.IoC.Containers;
using WebAPI.InfraStructure.Data.Context;
using KissLog.AspNetCore;
using WebAPI.Domain;
using KissLog;
using KissLog.CloudListeners.RequestLogsListener;
using FastPackForShare.Models;

namespace WebAPI.InfraStructure.IoC.Containers;

public static class ContainerApp
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
        var configKissLog = EnvironmentVariablesExtension.GetEnvironmentVariableToObject<KissLogModel>(configuration, "WebAPI_Settings:kissLogSettings");

        var configs = configKissLog.OrganizationId;
        KissLogConfiguration.Listeners
            .Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(configKissLog.OrganizationId, configKissLog.ApplicationId))
            {
                ApiUrl = configKissLog.ApiUrl
            });
    }

    private static void UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = p => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
    }

    public static void UseCompressData(this IApplicationBuilder app)
    {
        app.UseResponseCompression();

        app.Use(async (context, next) =>
        {
            if (!context.Request.Headers.ContainsKey("Accept-Encoding"))
            {
                context.Request.Headers["Accept-Encoding"] = "gzip, br";
            }

            await next();
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
            app.UseHsts();
        }

        app.MigrateDatabase();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("APICORS");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseKissLogConfig(configuration);

        app.UseExceptionHandler();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            //endpoints.MapHub<NotificationHub>("/notificationHub");
        });

        app.UseHealthChecks();

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
    }
}

