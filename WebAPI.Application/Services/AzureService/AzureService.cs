using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Files.Shares;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;
using WebAPI.Application.Generic;
using WebAPI.Domain.Interfaces.Services.Tools;

namespace WebAPI.Application.Services.AzureService;

public class AzureService : GenericService, IAzureService
{
    private EnvironmentVariables _environmentVariables { get; }

    public AzureService(EnvironmentVariables environmentVariables, INotificationMessageService iNotificationMessageService):base(iNotificationMessageService)
    {
        _environmentVariables = environmentVariables;
    }

    /// <summary>
    /// Metodo respónsavel pelo download de um documento armazenado no storage/file share do Azure
    /// </summary>
    /// <param name="fileName">Nome completo do arquivo. ex: arquivo.pdf</param>
    /// <param name="fileExtension">Sua extensão somente. ex: .pdf</param>
    /// <param name="shareReference">Pasta em que o arquivo se encontra</param>
    /// <returns></returns>
    public async Task<FileShareModel> DownloadFile(string fileName, string fileExtension = ".pdf", string shareReference = "documentFiles")
    {
        try
        {
            CloudFileShare fileShare = GetStorageClientFileToDownload().GetShareReference(shareReference);

            if (await fileShare.ExistsAsync())
            {
                CloudFileDirectory rootDir = fileShare.GetRootDirectoryReference();
                CloudFile file = rootDir.GetFileReference(fileName);
                var streamFile = await file.OpenReadAsync();
                return new FileShareModel(fileName, fileExtension, streamFile);
            }

            return null;
        }
        catch (Exception ex)
        {
            Notify(ex.Message);
            return null;
        }
    }

    /// <summary>
    /// Metodo respónsavel pelo upload de um documento no storage/file shared do azure
    /// </summary>
    /// <param name="fileName">Nome do arquivo que será carregado no storage do Azure via upload</param>
    /// <returns></returns>
    public async Task UploadFile(string storageFolder, string fileName)
    {
        ShareClient shareClient = await GetStorageClientFileToUpload(storageFolder);
        ShareDirectoryClient shareDirectoryClient = shareClient.GetRootDirectoryClient();
        ShareFileClient shareFileClient = shareDirectoryClient.GetFileClient(fileName);

        using (FileStream stream = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
        {
            if (await shareFileClient.ExistsAsync() == false)
            {
                await shareFileClient.CreateAsync(stream.Length);
            }

            await shareFileClient.UploadRangeAsync(new HttpRange(0, stream.Length), stream);
        }
    }

    public async Task<string> GetSecretFromAzureKeyVault(string secretName)
    {
        try
        {
            var client = new SecretClient(new Uri(_environmentVariables.AzureKeyVaultUrl), new DefaultAzureCredential());
            KeyVaultSecret secret = await client.GetSecretAsync(secretName);
            return secret.Value;
        }
        catch (Exception ex)
        {
            Notify(ex.Message);
            return string.Empty;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    #region Metodos Privados

    private CloudFileClient GetStorageClientFileToDownload()
    {
        var storageCredentials = new StorageCredentials(_environmentVariables.AzureFileShareAccountName, _environmentVariables.AzureFileShareKeyValue);
        CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
        return storageAccount.CreateCloudFileClient();
    }

    private async Task<ShareClient> GetStorageClientFileToUpload(string storageFolder)
    {
        ShareServiceClient serviceClient = new ShareServiceClient(_environmentVariables.AzureConnectionStringStorage);
        ShareClient shareClient = serviceClient.GetShareClient(storageFolder);

        if (!await shareClient.ExistsAsync())
        {
            await shareClient.CreateAsync();
        }

        return shareClient;
    }

    #endregion
}
