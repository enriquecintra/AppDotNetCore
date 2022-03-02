using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Avaliacao : EntidadeBase
    {
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public int Nota { get; set; }
        public int Preco { get; set; }
        public string Descricao { get; set; }
        public string Resposta { get; set; }
        public bool Mostrar { get; set; }
        [ForeignKey("LojaId")]
        public Loja Loja { get; set; }
        [Required]
        public int LojaId { get; set; }
    }
}
