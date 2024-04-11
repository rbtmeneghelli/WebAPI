using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Entities;

public class City : GenericEntity
{
    public string Name { get; set; }

    public long? IBGE { get; set; }

    public long StateId { get; set; }

    public virtual States States { get; set; }
}
