using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Requests
{
    public class AlterarSenhaRequest
    {
        public string SenhaAtual { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
