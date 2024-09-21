using WebAPI.Domain.Filters.Generic;

namespace WebAPI.Domain.Filters.Others;

public class CepFilter : GenericFilter
{
    public string Cep { get; set; }
}
