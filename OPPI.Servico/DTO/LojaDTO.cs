using OPPI.Dominio.Enums;
using System.Collections.Generic;

namespace OPPI.Servico.DTO
{
    public class LojaDTO : DTOBase
    {
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public TipoFornecedorEnum TipoFornecedor { get; set; }
        public string Logo { get; set; }
        public IList<ProdutoDTO> Produtos { get; set; }
        public IList<TelefoneDTO> Telefones { get; set; }
        public IList<AvaliacaoDTO> Avaliacoes { get; set; }
        public IList<AtendimentoDTO> Atendimentos { get; set; }
        public IList<LojaFotoDTO> LojaFotos { get; set; }
        public bool Ativa { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int UsuarioId { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public IList<LojaPlanoPrecoDTO> LojaPlanoPrecos { get; set; }
        public long QuantidadeAvaliacoes { get; set; }
        public decimal MediaAvaliacoes { get; set; }
        public decimal Distancia { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
