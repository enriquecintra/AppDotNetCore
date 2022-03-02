using OPPI.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Models
{
    public class PrimeiroAcessoModel : TemplateEmailModelBase
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
