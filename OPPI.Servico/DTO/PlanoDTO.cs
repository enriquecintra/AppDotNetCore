using OPPI.Dominio.Enums;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class PlanoDTO : DTOBase
    {
        public TipoPlanoEnum TipoPlano { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int PeriodoGratuito { get; set; }
        public int Quantidade { get; set; }
        public decimal Comissao { get; set; }
        public decimal TaxaFrete { get; set; }
        public decimal ValorFreteGratis { get; set; }
        public bool Promocao { get; set; }
        public bool Campanha { get; set; }
        public bool Anuncio { get; set; }
        public bool PagSeguro { get; set; }
        public bool AtendimentoVIP { get; set; }
        public bool CupomDesconto { get; set; }
        public bool ValeCompra { get; set; }
        public bool EmailMarketing { get; set; }
        public bool EmailPersonalizado { get; set; }
        public bool PaginaPersonalizada { get; set; }
        public bool FormasEntrega { get; set; }
        public bool GoogleShopping { get; set; }
        public bool InteligenciaMercado { get; set; }
        public IList<PlanoPrecoDTO> Precos { get; set; }
    }
}
