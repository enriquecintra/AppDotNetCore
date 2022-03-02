using System;

namespace OPPI.WebApi.Requests
{
    public class LojaPlanoPrecoRequest
    {
        public int LojaId { get; set; }
        public int PlanoPrecoId { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public bool RenovacaoAutomatica { get; set; }

    }
}
