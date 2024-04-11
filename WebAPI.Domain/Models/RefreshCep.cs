using WebAPI.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Domain.Models
{
    public class RefreshCep
    {
        public string Cep { get; set; }
        public AddressData ModelCep { get; set; }
        public AddressData ModelCepAPI { get; set; }

        public RefreshCep(string cep, AddressData modelCep, AddressData modelCepAPI)
        {
            Cep = cep;
            ModelCep = modelCep;
            ModelCepAPI = modelCepAPI;
        }
    }
}
