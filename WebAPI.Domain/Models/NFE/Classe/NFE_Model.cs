using WebAPI.Domain.Models.NFE.Outros;
using WebAPI.Domain.Models.NFE.Total;
using WebAPI.Domain.Models.NFE.Transporte;

namespace WebAPI.Domain.Models.NFE.Classe;

public class NFE_Model
{
    public NFE_Ide Ide { get; set; }
    public NFE_Emit Emit { get; set; }
    public NFE_Dest Dest { get; set; }
    public NFE_Retirada Ret { get; set; }
    public NFE_Entrega Entr { get; set; }
    public NFE_Imposto Imposto { get; set; }
    public NFE_Transporta Transporte { get; set; }
    public NFE_InfAdic InfAdic { get; set; }
    public NFE_IcmsTot Total { get; set; }
}
