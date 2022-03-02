using OPPI.Dominio.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Endereco : EntidadeBase
    {
        public TipoEnderecoEnum TipoEndereco { get; set; }
        [Column(TypeName = "varchar(8)")]
        public string CEP { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Logradouro { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Numero { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Complemento { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Bairro { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Cidade { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string UF { get; set; }
        public bool Padrao { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public int? UsuarioId { get; set; }
        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }
    }
}
