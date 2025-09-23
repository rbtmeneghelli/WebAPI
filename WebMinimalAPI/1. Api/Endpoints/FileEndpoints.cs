using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System.IO.Pipelines;
using WebMinimalAPI._2._Application.Interfaces;

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

        // Esse endpoint com IFormFile é recomendado para upload de arquivos até 100mb
        app.MapPost("/upload/smallfiles", async (IFormFile file, IFileService fs) =>
        {
            await fs.SaveFileAsync(file);
            return Results.Ok("Upload concluído!");
        });

        app.MapPost("/upload/bigfiles/pipereader", async (HttpRequest request, IFileService fs) =>
        {
            PipeReader reader = request.BodyReader;
            await fs.SaveFileAsync(reader);
            return Results.Ok(new { Mensagem = "Upload concluído com sucesso!" });
        });

        app.MapPost("/upload/bigfiles", async (HttpRequest request, IFileService fs) =>
        {
            if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaType) ||
                string.IsNullOrEmpty(mediaType.Boundary.Value))
            {
                return Results.BadRequest("Content-Type inválido.");
            }

            var reader = new MultipartReader(mediaType.Boundary.Value, request.BodyReader.AsStream());
            await fs.SaveFileAsync(reader);

            return Results.Ok("Upload concluído!");
        });

        app.Run();
    }
}
