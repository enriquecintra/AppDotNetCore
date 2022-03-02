using OPPI.Dominio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Documento : EntidadeBase
    {
        public TipoDocumentoEnum TipoDocumento { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Numero { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}