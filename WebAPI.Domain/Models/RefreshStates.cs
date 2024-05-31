using WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Models
{
    public class RefreshStates
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
}
