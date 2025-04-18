using Newtonsoft.Json;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Models;

public class MesoRegion
{
    public int Id { get; set; }
    [JsonProperty("Nome")]
    public string Name { get; set; }
    public States UF { get; set; }
}
