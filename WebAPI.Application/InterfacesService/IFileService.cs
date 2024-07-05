using Microsoft.AspNetCore.Http;

namespace WebAPI.Application.Interfaces;

public interface IFileService<TModel> : IDisposable where TModel : class
{
    Task<MemoryStream> CreateExcelFileEPPLUS(IEnumerable<TModel> list, string excelName);
    Task<MemoryStream> CreateExcelFileNPOI(IEnumerable<TModel> list, string excelName);
    Task<MemoryStream> CreateWordFile(IEnumerable<string> list, string wordName);
    Task<MemoryStream> CreatePdfFile(IEnumerable<string> list, string pdfName);
    Task<MemoryStream> CreateCsvFile(IEnumerable<TModel> list);
    Task<IEnumerable<TModel>> ReadExcelDataFromUploadNPOI(IFormFile formFile);
    Task<IEnumerable<TModel>> ReadExcelDataFromFolderNPOI(FileInfo fileInfo);
    Task<IEnumerable<TModel>> ReadExcelDataFromUploadEPPLUS(IFormFile formFile);
    Task<IEnumerable<TModel>> ReadExcelDataFromFolderEPPLUS(FileInfo fileInfo);
    Task<IEnumerable<TModel>> ReadCsvData(string csvFilePath);
    Task<IEnumerable<TModel>> ReadCsvDataFromIFormFile(IFormFile formFile);
}
