using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Provedor : EntidadeBase
    {
        [Column(TypeName = "varchar(200)")]
        public string RazaoSocial { get; set; }
        [Column(TypeName = "varchar(14)")] 
        public string CNPJ { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
        public bool Ativo { get; set; }
        public IList<UsuarioProvedor> UsuarioProvedores { get; set; }
        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
        [Required]
        public int EnderecoId { get; set; }
    }
}
