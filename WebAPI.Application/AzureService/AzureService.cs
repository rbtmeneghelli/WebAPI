using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.File;

namespace WebAPI.Application.AzureService;

public static class AzureService
{
    private static CloudFileClient GetStorageClientFileToDownload()
    {
        string accountName = "Azure-FileShare-AccountName";
        string keyValue = "Azure-FileShare-KeyValue";

        CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, keyValue), true);

        return storageAccount.CreateCloudFileClient();
    }

    private static async Task<ShareClient> GetStorageClientFileToUpload()
    {
        ShareServiceClient serviceClient = new ShareServiceClient("CONNECTION_STRING_STORAGE");
        ShareClient shareClient = serviceClient.GetShareClient("STORAGE_FOLDER");

        if (!await shareClient.ExistsAsync())
        {
            await shareClient.CreateAsync();
        }

        return shareClient;
    }

    /// <summary>
    /// Metodo respónsavel pelo download de um documento armazenado no storage/file share do Azure
    /// </summary>
    /// <param name="fileName">Nome completo do arquivo. ex: arquivo.pdf</param>
    /// <param name="fileExtension">Sua extensão somente. ex: .pdf</param>
    /// <param name="shareReference">Pasta em que o arquivo se encontra</param>
    /// <returns></returns>
    public static async Task<FileShareModel> DownloadFile(string fileName, string fileExtension = ".pdf", string shareReference = "documentFiles")
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
            throw new Exception(ex.Message, ex.InnerException);
        }
    }

    /// <summary>
    /// Metodo respónsavel pelo upload de um documento no storage/file shared do azure
    /// </summary>
    /// <param name="fileName">Nome do arquivo que será carregado no storage do Azure via upload</param>
    /// <returns></returns>
    public static async Task UploadFile(string fileName)
    {
        ShareClient shareClient = await GetStorageClientFileToUpload();
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
}
