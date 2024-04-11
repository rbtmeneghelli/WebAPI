using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class StateFilter : GenericFilter
{
    public string Nome { get; set; }
}
