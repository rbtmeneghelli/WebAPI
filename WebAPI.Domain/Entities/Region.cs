using WebAPI.Domain.EntitiesDTO;
using WebAPI.Domain.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebAPI.Domain.Entities;

[DebuggerDisplay("Id: {Id}, Nome: {Name}, Sigla: {Initials}")]
public class Region : GenericEntity
{
    [JsonProperty("Nome")]
    public string Name { get; set; }
    [JsonProperty("Sigla")]
    public string Initials { get; set; }
    public IEnumerable<States> States { get; set; }

    /// <summary>
    /// Faz a conversão implicita do objeto Region para RegionDto, ao passar a entidade
    /// O explicit você precisa efetuar um cast antes de mandar o parametro
    /// </summary>
    /// <param name="region"></param>
    public static implicit operator RegionResponseDTO(Region region)
    {
        return new()
        {
            Name = region.Name,
            Initials = region.Initials
        };
    }

    public static implicit operator string(Region region)
    {
        return $"Nome da região {region.Name}, Iniciais da região {region.Initials}";
    }
}
