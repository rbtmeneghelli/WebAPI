using Microsoft.AspNetCore.WebUtilities;
using System.IO.Pipelines;
using WebMinimalAPI._2._Application.Interfaces;

namespace WebMinimalAPI._2._Application.Services;

public sealed class FileService : IFileService
{
    private readonly string _folder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    public FileService()
    {
        if (!Directory.Exists(_folder))
            Directory.CreateDirectory(_folder);
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var path = Path.Combine(_folder, filename);
        using var stream = File.Create(path);
        await file.CopyToAsync(stream);
        return filename;
    }

    public async Task SaveFileAsync(PipeReader reader)
    {
        var filename = $"{Guid.NewGuid()}_{"arq_env.bin"}";
        var path = Path.Combine(_folder, filename);
        await using var fileStream = File.Create(path);

        while (true)
        {
            ReadResult result = await reader.ReadAsync();
            var buffer = result.Buffer;

            foreach (var segment in buffer)
            {
                await fileStream.WriteAsync(segment);
            }

            reader.AdvanceTo(buffer.End);

            if (result.IsCompleted)
                break;
        }

        await reader.CompleteAsync();
    }

    public async Task SaveFileAsync(MultipartReader reader)
    {
        MultipartSection? section;

        while ((section = await reader.ReadNextSectionAsync()) != null)
        {
            var contentDisposition = section.GetContentDispositionHeader();
            if (contentDisposition != null && contentDisposition.DispositionType.Equals("form-data") &&
                contentDisposition.FileName.HasValue)
            {
                var filename = $"{Guid.NewGuid()}_{contentDisposition.FileName.Value!}";
                var path = Path.Combine(_folder, filename);

                await using var targetStream = File.Create(path);
                await section.Body.CopyToAsync(targetStream);
            }
        }
    }

    public Task<(Stream stream, string contentType)> GetFileAsync(string filename)
    {
        var path = Path.Combine(_folder, filename);
        if (!File.Exists(path))
            throw new FileNotFoundException();
        var stream = File.OpenRead(path);
        var contentType = filename.EndsWith(".png") ? "image/png" : "application/octet-stream";
        return Task.FromResult<(Stream, string)>((stream, contentType));
    }
}
