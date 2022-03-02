using OPPI.Dominio.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Produto : EntidadeBase
    {
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public bool Destaque { get; set; }
        public IList<ProdutoPromocao> ProdutoPromocoes { get; set; }
        public IList<ProdutoFoto> ProdutoFotos { get; set; }
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        public int LojaId { get; set; }
        [ForeignKey("SegmentoId")]
        public Segmento Segmento { get; set; }
        [Required]
        public int SegmentoId { get; set; }
    }
}
