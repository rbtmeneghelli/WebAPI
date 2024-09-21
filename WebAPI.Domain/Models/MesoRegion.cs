using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Entities.Others;

namespace WebAPI.Domain.Models
{
    public class MesoRegion
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public States UF { get; set; }
    }
}
