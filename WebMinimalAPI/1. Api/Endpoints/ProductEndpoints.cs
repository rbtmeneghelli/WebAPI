using WebMinimalAPI._2._Application.Interfaces;

namespace WebMinimalAPI._1._Api.Endpoints;

public static class ProductEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/products", async (string name, IProductService uc) =>
        {
            await uc.CreateAsync(name);
            return Results.Created($"/products/{name}", new { name });
        });

        app.MapGet("/products", async (IProductService uc) =>
        {
            var list = await uc.GetByIdAsync(Guid.Empty); // simula recuperar todos via repository internamente
            return Results.Ok(list);
        });

        app.MapGet("/products/{id:guid}", async (Guid id, IProductService uc) =>
        {
            var p = await uc.GetByIdAsync(id);
            return p is not null ? Results.Ok(p) : Results.NotFound();
        });

        app.MapPut("/products/{id:guid}", async (Guid id, string name, IProductService uc) =>
        {
            await uc.UpdateAsync(id, name);
            return Results.NoContent();
        });

        app.MapDelete("/products/{id:guid}", async (Guid id, IProductService uc) =>
        {
            await uc.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
