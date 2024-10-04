using WebAPI.Domain.Models;

namespace WebAPI.Domain.Interfaces.Services.Tools;

public interface IAzureService : IDisposable
{
    Task<FileShareModel> DownloadFile(string fileName, string fileExtension = ".pdf", string shareReference = "documentFiles");
    Task UploadFile(string storageFolder,string fileName);
    Task<string> GetSecretFromAzureKeyVault(string secretName);
}
