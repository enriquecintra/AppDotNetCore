using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(100)")] 
        public string Email { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Senha { get; set; }
        public string Avatar { get; set; }
        public bool Ativo { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public IList<Documento> Documentos { get; set; }
        public IList<Endereco> Enderecos { get; set; }
        public IList<Telefone> Telefones { get; set; }
        public DateTime? DataAceiteTermos { get; set; }
        public DateTime? DataAceitePolitica { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Role { get; set; }
        public IList<Loja> Lojas { get; set; }
        public IList<UsuarioProvedor> UsuarioProvedores { get; set; }
 
    }
}
