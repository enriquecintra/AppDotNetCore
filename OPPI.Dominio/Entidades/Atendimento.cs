using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Atendimento : EntidadeBase
    {
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        [Required]
        public int LojaId { get; set; }
        public bool Encerrado { get; set; }
        public int Avaliacao { get; set; }
        public IList<Mensagem> Mensagens { get; set; }
    }
}
