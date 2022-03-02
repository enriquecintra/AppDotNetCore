using System;

namespace OPPI.Servico.DTO
{
    public class PlanoPrecoDTO : DTOBase
    {
        public int PlanoId { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}