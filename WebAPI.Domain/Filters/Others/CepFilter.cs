using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public sealed record CepFilter : BaseFilterModel
{
    public string ZipPostalCode { get; set; }
}
