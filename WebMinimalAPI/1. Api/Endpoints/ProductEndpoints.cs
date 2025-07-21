using FluentValidation;
using WebMinimalAPI._2._Application.DTOS;
using WebMinimalAPI._2._Application.Interfaces;

namespace WebMinimalAPI._1._Api.Endpoints;

public static class ProductEndpoints
{
    public static void Map(WebApplication app)
    {
        var productApi = app.MapGroup("/products").WithTags("Products");

        productApi.MapPost("/", async (
                    ProductDTO dto,
                    IValidator<ProductDTO> validator,
                    IProductService uc) =>
        {
            var validation = await validator.ValidateAsync(dto);
            if (!validation.IsValid)
                return Results.ValidationProblem(validation.ToDictionary());

            await uc.CreateAsync(dto.Name);
            return Results.Created($"/products/{dto.Name}", dto);
        })
        .WithSummary("Cria um novo produto")
        .WithDescription("Endpoint para criar produto com validação de entrada.")
        .Produces(201)
        .ProducesValidationProblem();

        productApi.MapGet("/", async (IProductService uc) =>
        {
            var list = await uc.GetByIdAsync(Guid.Empty); // simula recuperar todos via repository internamente
            return Results.Ok(list);
        });

        productApi.MapGet("/{id:guid}", async (Guid id, IProductService uc) =>
        {
            var p = await uc.GetByIdAsync(id);
            return p is not null ? Results.Ok(p) : Results.NotFound();
        });

        productApi.MapPut("/{id:guid}", async (Guid id, string name, IProductService uc) =>
        {
            await uc.UpdateAsync(id, name);
            return Results.NoContent();
        });

        productApi.MapDelete("/{id:guid}", async (Guid id, IProductService uc) =>
        {
            await uc.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
