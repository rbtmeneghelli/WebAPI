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
