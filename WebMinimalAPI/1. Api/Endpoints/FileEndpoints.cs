using WebMinimalAPI._2._Application.Interfaces;
using WebMinimalAPI_Aot._2._Application.Interfaces;

namespace WebMinimalAPI._1._Api.Endpoints;

public static class FileEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/products/{id:guid}/upload", async (Guid id, IFormFile file,
            IProductRepository repo, IFileService fs) =>
        {
            var product = await repo.GetByIdAsync(id);
            if (product is null) return Results.NotFound();

            var filename = await fs.SaveFileAsync(file);
            product.SetFile(filename);
            await repo.UpdateAsync(product);

            return Results.Ok(new { filename });
        });

        app.MapGet("/products/{id:guid}/download", async (Guid id,
            IProductRepository repo, IFileService fs) =>
        {
            var product = await repo.GetByIdAsync(id);
            if (product is null || product.FileName is null)
                return Results.NotFound();

            var (stream, contentType) = await fs.GetFileAsync(product.FileName);
            return Results.File(stream, contentType, product.FileName);
        });
    }
}
