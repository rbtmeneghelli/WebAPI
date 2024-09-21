using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.Others;

public class LogFilter : GenericFilter
{
    public string Class { get; set; }
    public string Method { get; set; }
}
