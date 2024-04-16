using WebAPI.Domain.Models.NFE.Impostos;

namespace WebAPI.Domain.Models.NFE.Classe;

public sealed record NFE_Imposto
{
    public List<NFE_Produto> Produto { get; set; }
    public List<NFE_ICMS> ICMS { get; set; }
    public List<NFE_PIS> PIS { get; set; }
    public List<NFE_COFINS> COFINS { get; set; }
}
