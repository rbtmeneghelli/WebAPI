using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class LogFilter : GenericFilter
{
    public string Class { get; set; }
    public string Method { get; set; }
}
