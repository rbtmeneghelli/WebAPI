namespace WebMinimalAPI._2._Application.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file);
    Task<(Stream stream, string contentType)> GetFileAsync(string filename);
}
