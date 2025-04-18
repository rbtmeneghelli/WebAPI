using FastPackForShare.Default;

namespace WebAPI.Domain.DTO.Others;

public record AddressDataDTO : BaseDTOModel
{
    public string Cep { get; set; }
    public string Street { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string Location { get; set; }
    public string Uf { get; set; }
    public string Ibge { get; set; }
    public string Gia { get; set; }
    public string Ddd { get; set; }
    public string Siafi { get; set; }
    public long StateId { get; set; }
}
