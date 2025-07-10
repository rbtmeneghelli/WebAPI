using Newtonsoft.Json;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;
using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Domain.Models.Factory.ProblemDetails;

namespace WebAPI.Application.Factory;

public sealed class ProblemDetailsFactory : IProblemDetailsFactory
{
    public IProblemDetailsConfigFactory GetProblemDetailsByException(Exception exception)
    {
        return exception switch
        {
            ArgumentException or ArgumentNullException or FormatException or
            InvalidCastException or KeyNotFoundException or ValidationException or
            ValidationException or BadRequestException or Newtonsoft.Json.JsonException or JsonReaderException
            => new BadRequestProblemDetails(),
            UnauthorizedAccessException or ForbiddenException
            => new TokenProblemDetails(),
            NullReferenceException or InvalidOperationException or IndexOutOfRangeException or DivideByZeroException or
            IOException or FileNotFoundException or TimeoutException or OutOfMemoryException or
            StackOverflowException or TaskCanceledException 
            => new InternalErrorProblemDetails(),
            _ => new InternalErrorProblemDetails()
        };
    }
}