namespace WebAPI.Domain.Models;

public class ResponseError
{
    public string ExceptionError { get; set; }
    public string Errors { get; set; }
    public int StatusCode { get; set; }
    public bool Success { get; set; }
}
