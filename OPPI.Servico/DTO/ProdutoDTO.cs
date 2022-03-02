using OPPI.Dominio.Enums;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class ProdutoDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Destaque { get; set; }
        public IList<ProdutoFotoDTO> ProdutoFotos { get; set; }
        public int LojaId { get; set; }
        public string Segmento { get; set; }
        public int SegmentoId { get; set; }
        public string Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
