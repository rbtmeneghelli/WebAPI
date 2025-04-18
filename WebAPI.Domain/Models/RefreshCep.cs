using WebAPI.Domain.ValueObject;

namespace WebAPI.Domain.Models;

public record RefreshCep
{
    public string Cep { get; set; }
    public AddressData ModelCep { get; set; }
    public AddressData ModelCepAPI { get; set; }

    public RefreshCep(string cep, AddressData modelCep, AddressData modelCepAPI)
    {
        Cep = cep;
        ModelCep = modelCep;
        ModelCepAPI = modelCepAPI;
    }
}
