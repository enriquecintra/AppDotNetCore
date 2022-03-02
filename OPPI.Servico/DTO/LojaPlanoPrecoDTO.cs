using System;

namespace OPPI.Servico.DTO
{
    public class LojaPlanoPrecoDTO : DTOBase
    {
        public LojaDTO Loja { get; set; }
        public PlanoPrecoDTO PlanoPreco { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public bool RenovacaoAutomatica { get; set; }
    }
}