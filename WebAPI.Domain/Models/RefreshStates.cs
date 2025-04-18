using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Models;

public record RefreshStates
{
    public IEnumerable<States> ListState { get; set; }
    
    public IEnumerable<States> ListStateAPI { get; set; }

    public IEnumerable<Region> ListRegion { get; set; }

    public RefreshStates(IEnumerable<States> listState, IEnumerable<States> listStateAPI, IEnumerable<Region> listRegion)
    {
        ListState = listState;
        ListStateAPI = listStateAPI;
        ListRegion = listRegion;
    }
}
