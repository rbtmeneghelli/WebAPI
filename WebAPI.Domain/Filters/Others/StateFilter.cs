using FastPackForShare.Default;

namespace WebAPI.Domain.Filters.Others;

public record StateFilter : BaseFilterModel
{
    public string Name { get; set; }
}
