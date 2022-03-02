using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Requests
{
    public class PrimeiroAcessoRequest
    {
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
