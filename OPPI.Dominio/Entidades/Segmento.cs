using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Segmento : EntidadeBase
    {
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}