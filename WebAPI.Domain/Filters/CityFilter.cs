using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class CityFilter : GenericFilter
{
    public long? Id { get; set; }

    public string Name { get; set; }

    public long? IBGE { get; set; }

    public long? IdState { get; set; }
}
