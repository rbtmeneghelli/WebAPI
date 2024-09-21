using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.Others;

public class StateFilter : GenericFilter
{
    public string Nome { get; set; }
}
