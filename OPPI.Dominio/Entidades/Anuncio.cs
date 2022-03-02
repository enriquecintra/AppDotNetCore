using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Anuncio : EntidadeBase
    {
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        [Required]
        public int LojaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public IList<AnuncioFoto> AnuncioFotos { get; set; }
    }
}
