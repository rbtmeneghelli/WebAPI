using Microsoft.AspNetCore.Http;

namespace WebAPI.Domain.Models;

public class MultFiles
{
    public long IdReference { get; set; }
    public IFormFile ArchiveFile { get; set; }
}
