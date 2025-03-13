using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Entities.Generic;

namespace WebAPI.Domain.Entities.ControlPanel
{
    public class Product : GenericEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
