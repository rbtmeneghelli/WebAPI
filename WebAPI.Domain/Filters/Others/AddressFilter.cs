using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record AddressFilter : BaseFilterModel
{
    public string ZipPostalCode { get; set; }
}
