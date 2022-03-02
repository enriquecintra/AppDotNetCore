using OPPI.Dominio.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Categoria : EntidadeBase
    {
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public TipoCategoriaEnum Tipo { get; set; }
        public IList<Segmento> Segmentos { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Icone { get; set; }
    }
}
