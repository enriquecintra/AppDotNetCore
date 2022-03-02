using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Promocao : EntidadeBase
    {
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        [Required]
        public int LojaId { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public decimal Desconto { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool Ativa { get; set; }
        public IList<ProdutoPromocao> ProdutoPromocoes { get; set; }
    }
}
