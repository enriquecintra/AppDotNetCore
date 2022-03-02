using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Mensagem : EntidadeBase
    {
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
    }
}
