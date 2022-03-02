using System;

namespace OPPI.Dominio.Entidades
{
    public class LojaPlanoPreco : EntidadeBase
    {
        public int LojaId { get; set; }
        public Loja Loja { get; set; }
        public int PlanoPrecoId { get; set; }
        public PlanoPreco PlanoPreco { get; set; }
        public DateTime DataInicioVigencia { get; set; }
        public bool RenovacaoAutomatica { get; set; }
    }
}
