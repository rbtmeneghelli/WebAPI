
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebAPI_VerticalSlice.Features.Products;
using WebAPI_VerticalSlice.InfraStructure.Context;
using WebAPI_VerticalSliceArc.Domain.Enum;
using WebAPI_VerticalSliceArc.Domain.Generics;
using WebAPI_VerticalSliceArc.Domain.Generics.Interfaces;
using WebAPI_VerticalSliceArc.Features.Products;

namespace WebAPI_VerticalSliceArc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<WebAPIDbContext>(options =>
            options
            .UseInMemoryDatabase("VerticalSliceAPIDB")
            .ConfigureWarnings(p => p.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            builder.Services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
            builder.Services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vertical Slice API",
                    Version = "v1"
                });

                p.MapType<EnumTicketDescount>(() => new OpenApiSchema
                {
                    Type = "string",
                    Enum = Enum.GetNames(typeof(EnumTicketDescount)).Select(x => (IOpenApiAny)new OpenApiString(x)).ToList()
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
