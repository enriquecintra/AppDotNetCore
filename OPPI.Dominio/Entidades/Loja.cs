using OPPI.Dominio.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OPPI.Dominio.Entidades
{
    public class Loja : EntidadeBase
    {
        [Column(TypeName = "varchar(14)")]
        public string CNPJ { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public TipoFornecedorEnum TipoFornecedor { get; set; }
        public string Logo { get; set; }
        public IList<Produto> Produtos { get; set; }
        public IList<Telefone> Telefones { get; set; }
        public IList<Avaliacao> Avaliacoes { get; set; }
        public IList<Atendimento> Atendimentos { get; set; }
        public IList<Anuncio> Anuncios { get; set; }
        public IList<LojaFoto> LojaFotos { get; set; }
        public IList<LojaCampanha> LojaCampanhas { get; set; }
        public IList<Navegacao> Navegacoes { get; set; }
        public bool Ativa { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [ForeignKey("EnderecoId")]
        public Endereco Endereco { get; set; }
        [Required]
        public int EnderecoId { get; set; }
        public IList<LojaPlanoPreco> LojaPlanoPrecos { get; set; }

        /// <summary>
        /// Campos que não estão na tabela, somente para consulta
        /// </summary>
        public long QuantidadeAvaliacoes { get; set; }
        public decimal MediaAvaliacoes { get; set; }
        public decimal Distancia { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
