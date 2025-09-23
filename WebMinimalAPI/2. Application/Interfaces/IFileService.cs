using Microsoft.AspNetCore.WebUtilities;
using System.IO.Pipelines;

namespace WebMinimalAPI._2._Application.Interfaces;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file);
    Task SaveFileAsync(PipeReader reader);
    Task SaveFileAsync(MultipartReader reader);
    Task<(Stream stream, string contentType)> GetFileAsync(string filename);
}
