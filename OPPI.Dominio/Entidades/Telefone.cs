using OPPI.Dominio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Telefone : EntidadeBase
    {
        public Telefone()
        {
            DDI = 55;
        }
        public TipoTelefoneEnum TipoTelefone { get; set; }
        public int DDI { get; set; }
        [Required]
        public int DDD { get; set; }
        [Column(TypeName = "varchar(20)")]
        [Required] 
        public string Numero { get; set; }
        public string Ramal { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int? UsuarioId { get; set; }
        [ForeignKey("ProvedorId")]
        public Provedor Provedor { get; set; }
        public int? ProvedorId { get; set; }
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        public int? LojaId { get; set; }
    }
}
