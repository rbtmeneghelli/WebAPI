namespace WebAPI.Domain.Models;

public class ProblemDetailsException : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public EnumLogger Logger { get; set; }
    public string File { get; set; }
    public string Class { get; set; }
    public string Method { get; set; }
    public int Line { get; set; }
}
