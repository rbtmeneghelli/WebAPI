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
        public List<States> ListState { get; set; }
        
        public List<States> ListStateAPI { get; set; }

        public List<Region> ListRegion { get; set; }

        public RefreshStates(List<States> listState, List<States> listStateAPI, List<Region> listRegion)
        {
            ListState = listState;
            ListStateAPI = listStateAPI;
            ListRegion = listRegion;
        }
    }
}
