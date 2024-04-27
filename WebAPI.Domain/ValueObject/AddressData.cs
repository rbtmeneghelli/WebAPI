using WebAPI.Domain.Entities;
using WebAPI.Domain.Generic;

namespace WebAPI.Domain.ValueObject;

public class AddressData : GenericEntity
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
    => (Id, District, Cep, Complement, Ddd, Gia, UpdateTime, Ibge, Location, Street, Siafi, Uf, StateId, CreatedTime)
    = (id, modelCepAPI.District, cep, modelCepAPI.Complement, modelCepAPI.Ddd, modelCepAPI.Gia, FixConstants.GetDateTimeNowFromBrazil(), modelCepAPI.Ibge, modelCepAPI.Location,
       modelCepAPI.Street, modelCepAPI.Siafi, modelCepAPI.Uf, stateId, createdTime);

    public AddressData(string cep, AddressData modelCepAPI)
    {
        District = modelCepAPI.District;
        Cep = cep;
        Complement = modelCepAPI.Complement;
        Ddd = modelCepAPI.Ddd;
        Gia = modelCepAPI.Gia;
        UpdateTime = FixConstants.GetDateTimeNowFromBrazil();
        Ibge = modelCepAPI.Ibge;
        Location = modelCepAPI.Location;
        Street = modelCepAPI.Street;
        Siafi = modelCepAPI.Siafi;
        Uf = modelCepAPI.Uf;
        IsActive = true;
        CreatedTime = FixConstants.GetDateTimeNowFromBrazil();
        StateId = modelCepAPI.StateId;
    }
}
