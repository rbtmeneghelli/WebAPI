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
        Location = location;
        Uf = uf;
        Ibge = ibge;
        Gia = gia;
        Ddd = ddd;
        Siafi = siafi;
        StateId = stateId;
    }

    public static AddressData Create(
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
        ArgumentException.ThrowIfNullOrWhiteSpace(cep, "Cep é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(street, "Rua é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(complement, "Complemento é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(district, "Distrito é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(location, "Localização é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(uf, "Uf é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(ibge, "Ibge é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(gia, "Gia é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(ddd, "Ddd é obrigatório.");
        ArgumentException.ThrowIfNullOrWhiteSpace(siafi, "Siafi é obrigatório.");

        var cepNormalizado = NormalizarCep(cep);

        if (!ValidarCep(cepNormalizado))
            throw new ArgumentException("CEP inválido.");

        return new AddressData(
            cep.Trim(),
            street.Trim(),
            complement.Trim(),
            district.Trim(),
            location.Trim(),
            uf.Trim(),
            ibge.Trim(),
            gia.Trim(),
            ddd.Trim(),
            siafi.Trim(),
            stateId
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
               Location == other.Location &&
               Uf == other.Uf &&
               Ibge == other.Ibge &&
               Gia == other.Gia &&
               Ddd == other.Ddd &&
               Siafi == other.Siafi;
    }

    public override bool Equals(object obj) => Equals(obj as AddressData);

    public override int GetHashCode()
    {
        return HashCode.Combine(
            Cep,
            Street,
            District,
            Location,
            Uf,
            Ibge,
            Gia,
            Siafi
        );
    }

    public override string ToString()
    {
        return $"{Cep}, {Complement} - {Street}, {District}";
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
