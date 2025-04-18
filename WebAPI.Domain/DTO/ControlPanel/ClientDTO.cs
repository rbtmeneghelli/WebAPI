using FastPackForShare.Default;
using WebAPI.Domain.Entities.ControlPanel;

namespace WebAPI.Domain.DTO.ControlPanel;

public record ClientRequestDTO : BaseDTOModel
{
    public string ClientName { get; set; }
    public Address ClientAddress { get; set; }
    public Document ClientDocument { get; set; }
}
