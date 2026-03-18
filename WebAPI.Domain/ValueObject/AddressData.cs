using FastPackForShare.Default;
using FastPackForShare.Extensions;
using System.Text.RegularExpressions;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.ValueObject;

public class AddressData : BaseEntityModel, IEquatable<AddressData>
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
    public States State { get; set; }
    public long StateId { get; set; }

    public AddressData()
    {

    }

    //Expression Body Constructor
    public AddressData(long id, string cep, AddressData modelCepAPI, long stateId, DateTime? createdTime)
    => (Id, District, Cep, Complement, Ddd, Gia, UpdatedAt, Ibge, Location, Street, Siafi, Uf, StateId, CreatedAt)
    = (id, modelCepAPI.District, cep, modelCepAPI.Complement, modelCepAPI.Ddd, modelCepAPI.Gia, DateOnlyExtension.GetDateTimeNowFromBrazil(), modelCepAPI.Ibge, modelCepAPI.Location,
       modelCepAPI.Street, modelCepAPI.Siafi, modelCepAPI.Uf, stateId, createdTime);

    public AddressData(string cep, AddressData modelCepAPI)
    {
        District = modelCepAPI.District;
        Cep = cep;
        Complement = modelCepAPI.Complement;
        Ddd = modelCepAPI.Ddd;
        Gia = modelCepAPI.Gia;
        UpdatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
        Ibge = modelCepAPI.Ibge;
        Location = modelCepAPI.Location;
        Street = modelCepAPI.Street;
        Siafi = modelCepAPI.Siafi;
        Uf = modelCepAPI.Uf;
        IsActive = true;
        CreatedAt = DateOnlyExtension.GetDateTimeNowFromBrazil();
        StateId = modelCepAPI.StateId;
    }

    private AddressData(
    string cep,
    string street,
    string complement,
    string district,
    string location,
    string uf,
    string ibge,
    string gia,
    string ddd,
    string siafi,
    long stateId)
    {
        Cep = cep;
        Street = street;
        Complement = complement;
        District = district;
        City = city;
        State = state;
    }

    public static AddressData Create(
        string cep,
        string street,
        string complement,
        string district,
        City city,
        States state)
    {
        if (string.IsNullOrWhiteSpace(cep))
            throw new ArgumentException("Logradouro é obrigatório.");

        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Número é obrigatório.");

        if (string.IsNullOrWhiteSpace(complement))
            throw new ArgumentException("Bairro é obrigatório.");

        if (string.IsNullOrWhiteSpace(district))
            throw new ArgumentException("Cidade é obrigatória.");

        ArgumentNullException.ThrowIfNull(city, "Cidade é obrigatória.");
        ArgumentNullException.ThrowIfNull(state, "Estado é obrigatório.");

        var cepNormalizado = NormalizarCep(cep);

        if (!ValidarCep(cepNormalizado))
            throw new ArgumentException("CEP inválido.");

        return new AddressData(
            cep.Trim(),
            street.Trim(),
            complement.Trim(),
            district.Trim(),
            city,
            state
        );
    }

    private static string NormalizarCep(string cep)
    {
        return Regex.Replace(cep ?? "", "[^0-9]", "");
    }

    private static bool ValidarCep(string cep)
    {
        return Regex.IsMatch(cep, @"^\d{8}$");
    }

    public bool Equals(AddressData other)
    {
        if (other is null) return false;

        return Cep == other.Cep &&
               Street == other.Street &&
               Complement == other.Complement &&
               District == other.District &&
               City == other.City &&
               State == other.State;
    }

    public override bool Equals(object obj) => Equals(obj as AddressData);

    public override int GetHashCode()
    {
        return HashCode.Combine(
            Cep,
            Street,
            Complement,
            District,
            City,
            State
        );
    }

    public override string ToString()
    {
        return $"{Cep}, {Complement} - {Street}, {District} - {City?.Name} - {State?.Name}";
    }

    protected override void CreateEntityIsValid()
    {
        throw new NotImplementedException();
    }

    protected override void UpdateEntityIsValid()
    {
        throw new NotImplementedException();
    }
}
