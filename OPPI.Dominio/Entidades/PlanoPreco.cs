using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class PlanoPreco : EntidadeBase
    {
        [ForeignKey("PlanoId")]
        public Plano Plano { get; set; }
        [Required]
        public int PlanoId { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public IList<LojaPlanoPreco> LojaPlanoPrecos { get; set; }
    }
}