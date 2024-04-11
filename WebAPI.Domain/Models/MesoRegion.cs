using WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Domain.Models
{
    public class MesoRegion
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public States UF { get; set; }
    }
}
