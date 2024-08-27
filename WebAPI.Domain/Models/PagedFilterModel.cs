namespace WebAPI.Domain.Models;

public class PagedFilterModel
{
    public string Column { get; set; }
    public object Value { get; set; } = null;
    public string Parameter { get; set; }
}
