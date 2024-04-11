using WebAPI.Domain.Generic;

namespace WebAPI.Domain.Filters;

public class CepFilter : GenericFilter
{
    public string Cep { get; set; }
}
